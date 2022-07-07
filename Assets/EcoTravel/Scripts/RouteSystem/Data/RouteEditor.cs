using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace routeSystem
{
    [CreateAssetMenu(fileName = "RouteEditor", menuName = "RouteSystem/RouteEditor", order = 1)]
    public class RouteEditor : ScriptableObject
    {
        public int ID;

        public Route route;

        public void GetRout()
        {          
            route = RouteStore.GetRoute(ID);
        }
        
        public void SetRout()
        {
            ID = RouteStore.SetRout(route);
        }


    }
}
