using GoToApps.Serialization; 
using UnityEngine;
using routeSystem;
using System.IO;
using UnityEngine.UI;
public class StoreUpdater : MonoBehaviour
{
    [SerializeField] string path;
    [SerializeField] string fileName;
    
    private void Awake()
    {
        
        this.path = Path.Combine(Application.dataPath, this.fileName);
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
