using MyPlansLibrary.ApiResponses;
using MyPlansLibrary.Responses;
using MyPlansLibrary.Models;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace PlansTestProject.ApiModelTests
{
    public class AthenticationTests
    {

        [Fact]
        public async Task CheckingNullEmail ()
        {
            var res = new LoginApi();
            var email = res.Email;
            Assert.NotNull(email);

        }
        [Fact]
        public async Task CheckingNullPassword()
        {
            var res = new LoginApi();
            var password = res.Password;
            Assert.NotNull(password);

        }
        [Fact]
        public async Task Matchingpasswords()
        {
            var res = new RegisterAPI();
            var password = res.Password;
            var confirmpassword = res.ConfirmPassword;
            Assert.Equal(password, confirmpassword);

        }
        [Fact]
        public async Task MatchingNames()
        {
            var res = new RegisterAPI();
            var firstName = res.FirstName;
            var lastName = res.LastName;
            Assert.NotEqual(firstName, lastName);

        }
        [Fact]
        public async Task check_token_expiry()
        {
            var res = new LoginApiResult();
            DateTime expirydate = res.ExpiryDate;
            DateTime dateNow = DateTime.Now;
            Assert.Equal(expirydate, dateNow);
        }


    }
}

