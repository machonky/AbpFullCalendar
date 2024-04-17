using AbpFullCalendar.Samples;
using Xunit;

namespace AbpFullCalendar.EntityFrameworkCore.Domains;

[Collection(AbpFullCalendarTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<AbpFullCalendarEntityFrameworkCoreTestModule>
{

}
