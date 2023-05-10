namespace rfidProject.Core
{
    public class Constants
    {
        public static class Roles
        {
            public const string Administrator = "Administrator";
            public const string Producer = "Producer";
            public const string SlaughterHouse = "SlaughterHouse";
            public const string User = "User";
        }

        public static class Policies
        {
            public const string RequireAdmin = "RequireAdmin";
            public const string RequireProducer = "RequireProducer";
            public const string RequireSlaughterHouse = "RequireSlaughterHouse";
        }

    }
}
