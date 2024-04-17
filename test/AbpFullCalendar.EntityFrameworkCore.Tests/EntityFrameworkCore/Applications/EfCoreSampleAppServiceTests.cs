using AbpFullCalendar.Samples;
using Xunit;

namespace AbpFullCalendar.EntityFrameworkCore.Applications;

[Collection(AbpFullCalendarTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<AbpFullCalendarEntityFrameworkCoreTestModule>
{

}
