using System;
using System.Collections.Generic;
using System.Text;
using AbpFullCalendar.Localization;
using Volo.Abp.Application.Services;

namespace AbpFullCalendar;

/* Inherit your application services from this class.
 */
public abstract class AbpFullCalendarAppService : ApplicationService
{
    protected AbpFullCalendarAppService()
    {
        LocalizationResource = typeof(AbpFullCalendarResource);
    }
}
