using AbpFullCalendar.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace AbpFullCalendar.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class AbpFullCalendarPageModel : AbpPageModel
{
    protected AbpFullCalendarPageModel()
    {
        LocalizationResourceType = typeof(AbpFullCalendarResource);
    }
}
