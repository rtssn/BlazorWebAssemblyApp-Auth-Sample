namespace BlazorWebAssemblyApp
{
    public class FirebaseSettings
    {
        public string? FirebaseApiKey { get; set; }

        public string? FirebaseAuthDomain { get; set; }

        public FirebaseSettings()
        {
            FirebaseApiKey = string.Empty;

            FirebaseAuthDomain = string.Empty;
        }
    }
}
