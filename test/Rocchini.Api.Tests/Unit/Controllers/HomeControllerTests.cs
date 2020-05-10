using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Rocchini.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Rocchini.Api.Tests.Unit.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public void home_controller_get_should_return_string()
        {
            var controller = new HomeController();

            var result = controller.Get();

            var contentResult = result as ContentResult;
            contentResult.Should().NotBeNull();
            contentResult.Content.ShouldAllBeEquivalentTo("Hello from Rocchini Api");
        }
    }
}
