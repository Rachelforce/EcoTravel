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
    [SerializeField] object  file; 
    private void Awake()
    {
        this.path = Path.Combine(Application.dataPath, "/Resources/", this.fileName);
        this.path = Application.dataPath + "/Resources/" + this.fileName;
        if (File.Exists(this.path))
        {
            
            RouteStoreSerialize routeStoreSerialize = JsonSerializer.Load<RouteStoreSerialize>(this.path);
            routeStoreSerialize.OnAfterDeserialize();
        }
        
    }
    private void OnDestroy()
    {
        RouteStoreSerialize testSerialize = new RouteStoreSerialize(1);
        JsonSerializer.Save(this.path, testSerialize);
    }
 
}
