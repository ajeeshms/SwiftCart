namespace SwiftCart.Data {
    public class Settings {
        private static string connectionString;
        public static string ConnectionString {
            get => connectionString; set {
                if (string.IsNullOrEmpty(connectionString))
                    connectionString = value;
            }
        }
    }
}
