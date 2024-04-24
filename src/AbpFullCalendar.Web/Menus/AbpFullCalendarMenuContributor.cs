using System.Threading.Tasks;
using AbpFullCalendar.Localization;
using AbpFullCalendar.MultiTenancy;
using AbpFullCalendar.Permissions;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace AbpFullCalendar.Web.Menus;

public class AbpFullCalendarMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<AbpFullCalendarResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                AbpFullCalendarMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        context.Menu.AddItem(
            new ApplicationMenuItem(
                "AbpFullCalendar",
                l["Menu:AbpFullCalendar"],
                icon: "fas fa-database"
                    ).AddItem(
                        new ApplicationMenuItem(
                            "AbpFullCalendar.BusinessDays",
                            l["Menu:BusinessDays"],
                            url: "/BusinessDays",
                            icon: "fas fa-calendar"
                        ).RequirePermissions(AbpFullCalendarPermissions.BusinessDays.Default)
                    )
        );

        return Task.CompletedTask;
    }
}
