using AbpFullCalendar.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AbpFullCalendar.Permissions;

public class AbpFullCalendarPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AbpFullCalendarPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AbpFullCalendarPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AbpFullCalendarResource>(name);
    }
}
