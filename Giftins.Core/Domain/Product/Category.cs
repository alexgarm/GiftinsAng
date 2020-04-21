using System;
using System.Collections.Generic;
using System.Text;

namespace Giftins.Core.Domain.Product
{
    public class Category
    {
        private Category _parentCategory;
        
        public int Id { get; protected set; }
        public int? ParentCategoryId { get; protected set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public bool Enabled { get; set; }

        public int DisplayOrder { get; set; }

        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitles { get; set; }

        /// <summary>
        /// Entity Framework
        /// </summary>
        protected Category()
        { }

        #region Navigation properties

        public virtual Category ParentCategory
        {
            get => _parentCategory;
            set
            {
                _parentCategory = value;
                ParentCategoryId = value?.Id;
            }
        }

        #endregion
    }
}
