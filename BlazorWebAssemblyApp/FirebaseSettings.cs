namespace BlazorWebAssemblyApp
{
    /// <summary>
    /// Firebase設定情報のモデルです。
    /// </summary>
    public class FirebaseSettings
    {
        /// <summary>
        /// APIキーを取得/設定します。
        /// </summary>
        public string? FirebaseApiKey { get; set; }

        /// <summary>
        /// ドメインを取得/設定します。
        /// </summary>
        public string? FirebaseAuthDomain { get; set; }

        public FirebaseSettings()
        {
            FirebaseApiKey = string.Empty;

            FirebaseAuthDomain = string.Empty;
        }
    }
}
