using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;

namespace routeSystem
{
    public class RouteStoreEditor : MonoBehaviour
    {
        #region Set variables
        [SerializeField] RouteEditor routeEditor;
        [SerializeField] bool getRout;
        [SerializeField] bool setRout;

        [Space]
        [Space]


        [SerializeField] CollectionEditor collectionEditor;
        [SerializeField] bool getCollection;
        [SerializeField] bool setCollection;
        #endregion variables

        #region GetSetMethods
        private void Update()
        {
            if (getRout) GetRout();
            else if (setRout) SetRout();

            else if (getCollection) GetCollection();
            else if (setCollection) SetCollection();
        }
        private void GetRout()
        {
            routeEditor.GetRout();
            getRout = false;
        }


        private void SetRout()
        {
            routeEditor.SetRout();
            setRout = false;
        }





        private void GetCollection()
        {
            collectionEditor.GetCollection();
            getCollection = false;
        }
        private void SetCollection()
        {
            collectionEditor.SetCollection();
            setCollection = false;
        }



        #endregion GetSetMethods


    }
}
