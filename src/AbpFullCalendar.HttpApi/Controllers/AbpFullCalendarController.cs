using AbpFullCalendar.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpFullCalendar.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AbpFullCalendarController : AbpControllerBase
{
    protected AbpFullCalendarController()
    {
        LocalizationResource = typeof(AbpFullCalendarResource);
    }
}
