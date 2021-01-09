namespace DIMS_Core.Identity
{
    public static class IdentityConstants
    {
        public static class RoleNames
        {
            public const string User = "User";
            public const string Mentor = "Mentor";
            public const string Admin = "Admin";

            public static readonly string[] Roles =
            {
                User,
                Mentor,
                Admin
            };
        }
    }
}