using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace AbpFullCalendar.Pages;

public class Index_Tests : AbpFullCalendarWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
