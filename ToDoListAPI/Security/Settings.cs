namespace ToDoListAPI.Security
{
    public class Settings
    {
        private static string secret = "5f4a060881e5041ca61860ac66a97e021b03db0398c9324cc358a46592638d57";
        public static string Secret { get => secret; set => secret = value; }
    }
}
