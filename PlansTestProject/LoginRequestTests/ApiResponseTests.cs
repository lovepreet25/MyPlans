using FluentAssertions;
using MyPlansLibrary.ApiResponses;
using MyPlansLibrary.Responses;

namespace PlansTestProject.LoginRequestTests
{
    public class ApiResponseTests

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
        [Fact]
        public async Task ErrorIsSuccess()
        {
            var res = new ApiErrorsResponses();
            var result = res.IsSuccess;
            result.Should().Be(true);

        }
        [Fact]
        public async Task ErrorMessage()
        {
            var res = new ApiErrorsResponses();
            var result = res.Message;
            result.Should().Be("Success");

        }


    }
}