using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace KeralaQuizApp.Helpers
{
    public static class SessionExtensions
    {
        // Save an object in session as JSON
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        // Retrieve an object from session and deserialize it
        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
