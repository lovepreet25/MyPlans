using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlansTestProject.ApiModelTests
{
    using MyPlansLibrary.ApiResponses;
    using MyPlansLibrary.Responses;
    using MyPlansLibrary.Models;
    using FluentAssertions;
    using Microsoft.Extensions.DependencyInjection;
    using MudBlazor;

    namespace PlansTestProject.ApiModelTests
    {
        public class PlanModelTests
        {

            [Fact]
            public async Task CheckingId()
            {
                var res = new Plan();
                var planId = res.Id;
                Assert.NotNull(planId);

            }
            [Fact]
            public async Task CheckingNullTitle()
            {
                var res = new Plan();
                var title = res.Title;
                Assert.NotNull(title);

            }
            
           

 
            [Fact]
            public async Task descriptionLength()
            {
                var res = new Plan();
                var description = res.Description;

                Assert.EndsWith(".", description);

            }
            [Fact]
            public async Task checkingCurrentPage()
            {    
               Pagination<int> pageno = new Pagination<int>();
                pageno.Page= 1;
                Assert.True(pageno.Page<=1);
            }
            public async Task checkingtotalPage()
            {
                Pagination<int> totalPages = new Pagination<int>();
                totalPages.TotalPages= 1;
                Assert.True(totalPages.TotalPages >= 1);
            }

            public async Task checkingPageSize()
            {
                Pagination<int> size = new Pagination<int>();
                size.PageSize = 1;
                Assert.True(size.PageSize <= 10);
            }
            public async Task checkingItemcount()
            {
                Pagination<int> count = new Pagination<int>();
                count.ItemCount = 1;
                Assert.True(count.ItemCount <= count.TotalPages);
            }

        }
    }
}
