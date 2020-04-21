using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Giftins.Core.Domain.User;
using Giftins.TestUtils.Initializers;

namespace Giftins.Application.Tests.Account.SetProfileInfo
{
    [TestClass]
    public class SetProfileInfoHandlerTest : ApplicationTestBase
    {
        public SetProfileInfoHandlerTest()
        {
            var dbInitializer = (BasicDummyInitializer)_services.GetService(typeof(BasicDummyInitializer));
            dbInitializer.Initialize(_userManager, _accountDbContext, 1);
        }

        [TestMethod]
        public void SetAllFieldsCorrectProfileInfoTest()
        {
            var account = _accountDbContext.Users.First();
            var oldProfile = _accountDbContext.UserProfiles.First();
            _userDbContext.Entry(oldProfile).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            // Ensure new values will be different
            string newFirstName = $"{oldProfile.FirstName}abc";
            string newLastName = $"{oldProfile.LastName}abc";

            Gender newGender = oldProfile.Gender == Gender.Male
                ? Gender.Female
                : Gender.Male;
            Relation newRetalion = oldProfile.Relation == Relation.HaveParthner
                ? Relation.Single
                : Relation.HaveParthner;
            DateTimeOffset newBdate = oldProfile.Birthdate.HasValue
                ? oldProfile.Birthdate.Value.AddDays(1)
                : DateTimeOffset.Parse("11.09.1991 0:00:00 +00:00");

            PrivacyPolicy new_bday_disp = oldProfile.BirthDisplayPolicy == PrivacyPolicy.Anyone
                ? PrivacyPolicy.OnlyMe
                : PrivacyPolicy.Anyone;

            PrivacyPolicy new_relation_disp = oldProfile.RelationDisplayPolicy == PrivacyPolicy.Anyone
                ? PrivacyPolicy.OnlyMe
                : PrivacyPolicy.Anyone;

            string newCity = oldProfile.City == "New York" ? "Old York" : "New York";
            string newCountry = oldProfile.Country == "US" ? "RUS" : "US";

            var setCmd = new Application.Account.SetProfileInfo.SetProfileInfoCommand()
            {
                AccountId = account.Id,
                NewProperties = new Dictionary<string, string>
                {
                    { "first_name", newFirstName },
                    { "last_name", newLastName },
                    { "gender", newGender.ToString("D") },
                    { "relation", newRetalion.ToString("D") },
                    { "bdate", newBdate.ToString() },
                    { "city", newCity },
                    { "country", newCountry },
                    { "bdate_display", new_bday_disp.ToString() },
                    { "relation_display", new_relation_disp.ToString() }
                }
            };
            _mediator.Send(setCmd).GetAwaiter().GetResult();

            var newProfile = _accountDbContext.UserProfiles.First();

            Assert.AreEqual(oldProfile.UserId, newProfile.UserId);
            Assert.AreEqual(newFirstName, newProfile.FirstName);
            Assert.AreEqual(newLastName, newProfile.LastName);
            Assert.AreEqual(newGender, newProfile.Gender);
            Assert.AreEqual(newRetalion, newProfile.RelationId);
            Assert.AreEqual(newBdate, newProfile.Birthdate);
            Assert.AreEqual(newCity, newProfile.City);
            Assert.AreEqual(newCountry, newProfile.Country);
            Assert.AreEqual(new_bday_disp, newProfile.BirthDisplayPolicy);
            Assert.AreEqual(new_relation_disp, newProfile.RelationDisplayPolicy);
        }
    }
}
