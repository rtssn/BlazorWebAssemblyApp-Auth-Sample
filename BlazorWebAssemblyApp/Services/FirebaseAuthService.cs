using Firebase.Auth.Providers;
using Firebase.Auth;
using System.Net;
using Microsoft.AspNetCore.Components;

namespace BlazorWebAssemblyApp.Services
{
    public class FirebaseAuthService
    {
        private readonly FirebaseAuthConfig config;

        public FirebaseAuthService(FirebaseSettings firebaseSettings)
        {
            config = new FirebaseAuthConfig
            {
                ApiKey = firebaseSettings.FirebaseApiKey,
                AuthDomain = firebaseSettings.FirebaseAuthDomain,
                Providers = new FirebaseAuthProvider[]
                {
                            new EmailProvider()
                }
            };
        }

        /// <summary>
        /// メールアドレスを使ってサインインします。
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public async Task<UserCredential?> SignInWithEmail(string? email, string? password)
        {
            UserCredential? userCredential = null;

            try
            {
                FirebaseAuthClient client = new FirebaseAuthClient(config);

                var result = await client.FetchSignInMethodsForEmailAsync(email);

                if (result.UserExists && result.AllProviders.Contains(FirebaseProviderType.EmailAndPassword))
                {
                    userCredential = await client.SignInWithEmailAndPasswordAsync(email, password);
                }
            }
            catch (FirebaseAuthException ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return userCredential;
        }

        public void Signout()
        {
            FirebaseAuthClient firebaseAuthClient = new FirebaseAuthClient(config);
            firebaseAuthClient.SignOut();
        }
    }
}
