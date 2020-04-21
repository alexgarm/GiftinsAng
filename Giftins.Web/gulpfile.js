"use strict";
var gulp = require("gulp");
var cache = require('gulp-cached'); //If cached version identical to current file then it doesn't pass it downstream so this file won't be copied
var concat = require('gulp-concat');
var rename = require('gulp-rename');
var pump = require('pump');

var sass = require("gulp-sass");
var ts = require('gulp-typescript');

let cleanCSS = require('gulp-clean-css');
var uglify = require('gulp-uglify');

var paths = {
    webroot: "./wwwroot/",
    dist: "./wwwroot/dist/",
    fonts: "./wwwroot/fonts/",
    styles: "./Styles/",
    scripts: "./Scripts/"
};

gulp.task('make-core-css', () => {
    return gulp.src(['./node_modules/bootstrap/dist/css/bootstrap.css',
            './node_modules/@fortawesome/fontawesome-free/css/all.css'
        ])
        .pipe(cache('./node_modules'))
        .pipe(concat('core.css'))
        .pipe(gulp.dest(paths.dist));
});

gulp.task('make-core-js', () => {
    return gulp.src(['./node_modules/jquery/dist/jquery.js',
            './node_modules/jquery-validation/dist/jquery.validate.js',
            './node_modules/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.js',
            './node_modules/bootstrap/dist/js/bootstrap.js',
            './node_modules/popper.js/dist/umd/popper.js',
            './node_modules/domurl/url.js'
        ])
        .pipe(cache('./node_modules'))
        .pipe(concat('core.js'))
        .pipe(gulp.dest(paths.dist));
});

gulp.task('copy-bootstrap-map', () => {
    return gulp.src(['./node_modules/bootstrap/dist/css/bootstrap.css.map',
            './node_modules/bootstrap/dist/css/bootstrap.min.css.map'
        ])
        .pipe(cache('./node_modules'))
        .pipe(gulp.dest(paths.dist));
});

gulp.task('copy-bootstrap-fonts', () => {
    return gulp.src(['./node_modules/@fortawesome/fontawesome-free/webfonts/*'])
        .pipe(cache('./node_modules'))
        .pipe(gulp.dest(paths.webroot + 'webfonts'));
});

gulp.task('sass-compile', () => {
    return gulp.src(paths.styles + 'site.scss')
        .pipe(sass())
        .pipe(concat('app.css'))
        .pipe(gulp.dest(paths.dist));
});

gulp.task('ts-compile', () => {
    var tsProject = ts.createProject(paths.scripts + 'tsconfig.json');
    return tsProject.src()
        .pipe(tsProject())
        .js.pipe(concat('app.js'))
        .pipe(gulp.dest(paths.dist));
});

gulp.task('minify-css-core', () => {
    return gulp.src(paths.dist + 'core.css')
        .pipe(cleanCSS())
        .pipe(rename('core.min.css'))
        .pipe(gulp.dest(paths.dist));
});
gulp.task('minify-css-app', () => {
    return gulp.src(paths.dist + 'app.css')
        .pipe(cleanCSS())
        .pipe(rename('app.min.css'))
        .pipe(gulp.dest(paths.dist));
});
gulp.task('minify-css', gulp.series('minify-css-core', 'minify-css-app'));

gulp.task('minify-js-core', (cb) => {
    return pump([
        gulp.src(paths.dist + 'core.js'),
        uglify(),
        rename('core.min.js'),
        gulp.dest(paths.dist)
    ], cb);
});
gulp.task('minify-js-app', (cb) => {
    return pump([
        gulp.src(paths.dist + 'app.js'),
        uglify(),
        rename('app.min.js'),
        gulp.dest(paths.dist)
    ], cb);
});
gulp.task('minify-js', gulp.series('minify-js-core', 'minify-js-app'));

gulp.task('sass-watch', () => {
    gulp.watch(paths.styles + '**/*', gulp.series('sass-compile', 'minify-css-app'));
});
gulp.task('ts-watch', () => {
    gulp.watch(paths.scripts + '**/*', gulp.series('ts-compile', 'minify-js-app'));
});

gulp.task('resources-build', gulp.series('make-core-css', 'make-core-js', 'copy-bootstrap-map', 'copy-bootstrap-fonts', 'sass-compile', 'ts-compile', 'minify-css', 'minify-js'));
gulp.task('resources-watch', gulp.parallel('sass-watch', 'ts-watch'));