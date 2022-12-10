using FluentAssertions;
using MyPlansLibrary.ApiResponses;

namespace PlansTestProject.LoginRequestTests
{
    public class LoginTests

    {
        [Fact]
        public async Task  TrueIsSuccess()
        {
            var res = new ApiResponses();
            var result =  res.IsSuccess;
            result.Should().Be(true);

        }
        [Fact]
        public async Task SuccessMessage()
        {
            var res = new ApiResponses();
            var result = res.Message;
            result.Should().Be("Success");

        }
       

    }
}