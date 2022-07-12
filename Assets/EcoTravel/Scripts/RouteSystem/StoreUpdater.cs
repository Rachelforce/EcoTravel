using GoToApps.Serialization; 
using UnityEngine;
using routeSystem;
using System.IO;
using UnityEngine.UI;
using UnityEditor;
public class StoreUpdater : MonoBehaviour
{
    [SerializeField] string path;
    [SerializeField] string fileName;
    [SerializeField][TextArea] string startJsone;  
    private void Awake()
    {
        LoadFromString();


    }
    private bool LoadFromFile()
    {
        this.path = Path.Combine(Application.dataPath, this.fileName);

        if (File.Exists(this.path))
        {

            RouteStoreSerialize routeStoreSerialize = JsonSerializer.Load<RouteStoreSerialize>(this.path);
            routeStoreSerialize.OnAfterDeserialize();
            return true;
        }
        else {  return false; }
    }
    private bool LoadFromString()
    {
        if (startJsone != null)
        {

            RouteStoreSerialize routeStoreSerialize = JsonSerializer.LoadFromString<RouteStoreSerialize>(startJsone);
            routeStoreSerialize.OnAfterDeserialize();
            return true;
        }
        else { return false; }
    }
    private void OnDestroy()
    {
        RouteStoreSerialize testSerialize = new RouteStoreSerialize(1);
        JsonSerializer.Save(this.path, testSerialize);
    }
 
}
