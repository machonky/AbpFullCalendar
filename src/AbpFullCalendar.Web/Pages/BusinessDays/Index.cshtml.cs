using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using AbpFullCalendar.BusinessDays;

namespace AbpFullCalendar.Web.Pages.BusinessDays
{
    public class IndexModel : AbpFullCalendarPageModel
    {
        private readonly IBusinessDayAppService businessDayAppService;
        private readonly ILogger<IndexModel> logger;

        public IndexModel(IBusinessDayAppService businessDayAppService, ILogger<IndexModel> logger)
        {
            this.businessDayAppService = businessDayAppService;
            this.logger = logger;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnGetBusinessDays(DateTime start, DateTime end)
        {
            logger.LogInformation($"Getting Business Days from {start.ToString("yyyy-MM-dd")} to {end.ToString("yyyy-MM-dd")}");
            return new JsonResult(await businessDayAppService.GetBusinessDaysAsync(start, end));
        }

        public async Task<IActionResult> OnPostSelectedEvents([FromBody] SelectedBusinessDayEventsDto data)
        {
            await businessDayAppService.StoreBusinessDaysAsync(data);
            return new JsonResult(new { success = true });
        }
    }
}
