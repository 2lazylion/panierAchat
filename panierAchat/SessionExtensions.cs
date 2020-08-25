using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace panierAchat.Utils
{
    public static class SessionExtensions
    {
        //
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            // mets dans la session l'objet serialisee
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        //
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            // prends dans la session l'objet serialisee
            var value = session.GetString(key);

            // retourne l'objet deserialise
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value); 
        }
    }
}
