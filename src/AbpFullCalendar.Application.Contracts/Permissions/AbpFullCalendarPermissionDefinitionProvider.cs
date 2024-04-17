using AbpFullCalendar.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AbpFullCalendar.Permissions;

public class AbpFullCalendarPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var groupPermission = context.AddGroup(AbpFullCalendarPermissions.GroupName, L(AbpFullCalendarPermissions.PermissionPrefix + AbpFullCalendarPermissions.GroupName))
        .AddPermission(AbpFullCalendarPermissions.BusinessDays.GroupPrefix, L(AbpFullCalendarPermissions.BusinessDays.Display.Default));

        groupPermission.AddChild(AbpFullCalendarPermissions.BusinessDays.Create, L(AbpFullCalendarPermissions.BusinessDays.Display.Create));
        groupPermission.AddChild(AbpFullCalendarPermissions.BusinessDays.Edit, L(AbpFullCalendarPermissions.BusinessDays.Display.Edit));
        groupPermission.AddChild(AbpFullCalendarPermissions.BusinessDays.Delete, L(AbpFullCalendarPermissions.BusinessDays.Display.Delete));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AbpFullCalendarResource>(name);
    }
}
