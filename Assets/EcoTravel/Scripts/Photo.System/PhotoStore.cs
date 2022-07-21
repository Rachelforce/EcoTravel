using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using routeSystem;

namespace PhotoSystem
{

    public class PhotoStore : MonoBehaviour
    {

        static string path;
        public List<Photo> allPhoto;


        private void Awake()
        {

            path = Path.Combine(Application.persistentDataPath, "PhotoFolder");

            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        }
        public  void SetTextureToAllPhoto(ref bool state)
        {
            foreach (Photo photo in allPhoto)
            {
                string photoPath = Path.Combine(path, photo.namePhoto);
                if (!File.Exists(photoPath))
                {
                    IEnumerator coroutine = DownloadTexture(photoPath, photo);
                    StartCoroutine(coroutine);
                }
                else Debug.Log("Texture exist on disk");
            }
            state = true;
            Debug.Log("Load all Photo done");
        }

        private  IEnumerator DownloadTexture(string _path, Photo photo)
            {
                UnityWebRequest request = UnityWebRequestTexture.GetTexture(photo._url.Trim());

                yield return request.SendWebRequest();
                if (request.result == UnityWebRequest.Result.Success)
                {
                    Texture texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
                    SaveTextureOnDisk(_path, texture);
                }
                else
                    Debug.LogError(request.error + photo._url);

            }

        public static  Texture2D LoadTextureFromDisk(string namePhoto)
            {
            string photoPath = Path.Combine(path, namePhoto);
            if (File.Exists(photoPath))
                {
                    byte[] textureBytes = File.ReadAllBytes(photoPath);
                    Texture2D loadedTexture = new Texture2D(0, 0);
                    loadedTexture.LoadImage(textureBytes);
                    Debug.Log("Load Texture from disck done");
                    return loadedTexture;
                }
            Debug.Log("LoadTexture from disck false");
            return null;
            }

        private void SaveTextureOnDisk(string _path, Texture tex)
        {
            Texture2D texture2 = (Texture2D)tex;
            byte[] textureBytes = texture2.EncodeToJPG();
            File.WriteAllBytes(_path, textureBytes);
            Debug.Log($"File {_path} written");
        }
        
    }
}

