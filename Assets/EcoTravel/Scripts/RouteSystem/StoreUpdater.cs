using GoToApps.Serialization; 
using UnityEngine;
using routeSystem;
using System.IO;
public class StoreUpdater : MonoBehaviour
{
    [SerializeField] RouteStore routeStore;
    [SerializeField] string path;
    [SerializeField] string fileName;
    private void Awake()
    {
        this.path = Path.Combine(Application.dataPath, this.fileName);
        if (File.Exists(this.path))
        {
            this.routeStore = BinarySerializer.Deserialize<RouteStore>(this.path);
        }
    }
    private void OnApplicationQuit()
    {
        BinarySerializer.Serialize(this.path, this.routeStore);
    }
 
}
