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
    }
}
