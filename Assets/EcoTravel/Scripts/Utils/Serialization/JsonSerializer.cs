using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class JsonSerializer : MonoBehaviour
{

        public static T Load<T>(string path) where T : class
        {       
            if (File.Exists(path))
            {
                return JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
            }
            return default(T);
        }
        public static T LoadFromString<T>(string content) where T : class
        {
            if (content !=null)
            {
                return JsonConvert.DeserializeObject<T>(content);
            }
            return default(T);
        }

    public static void Save<T>(string path, T data) where T : class
        {      
                string json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                });
        File.WriteAllText(path, json);    
        }
}
