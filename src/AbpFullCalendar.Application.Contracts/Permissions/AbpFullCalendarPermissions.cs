namespace AbpFullCalendar.Permissions;

public class AbpFullCalendarPermissions : BasePermissions
{
    public const string GroupName = "AbpFullCalendar";

    // We'll keep the template
    //
    //public class BusinessDays
    //{
    //    public const string GroupPrefix = GroupName + "." + nameof(BusinessDays);

    //    public const string Default = GroupPrefix;
    //    public const string Create = GroupPrefix + "." + nameof(Create);
    //    public const string Edit = GroupPrefix + "." + nameof(Edit);
    //    public const string Delete = GroupPrefix + "." + nameof(Delete);

    //    public class Display
    //    {
    //        public const string Default = PermissionPrefix + GroupPrefix;
    //        public const string Create = PermissionPrefix + BusinessDays.Create;
    //        public const string Edit = PermissionPrefix + BusinessDays.Edit;
    //        public const string Delete = PermissionPrefix + BusinessDays.Delete;
    //    }
    //}

    public class BusinessDays
    {
        public const string GroupPrefix = GroupName + "." + nameof(BusinessDays);

        public const string Default = GroupPrefix;
        public const string Edit = GroupPrefix + "." + nameof(Edit);

        public class Display
        {
            public const string Default = PermissionPrefix + GroupPrefix;
            public const string Edit = PermissionPrefix + BusinessDays.Edit;
        }
    }
}