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

        [SerializeField] PointEditor pointEditor;
        [SerializeField] bool getPoint;
        [SerializeField] bool setPoint;
        [SerializeField] bool getPointPhoto;
        [SerializeField] bool setPointPhoto;

        [Space]
        [Space]


        [SerializeField] CollectionEditor collectionEditor;
        [SerializeField] bool getCollection;
        [SerializeField] bool setCollection;
        [SerializeField] bool getCollectionPhoto;
        [SerializeField] bool setCollectionPhoto;
        #endregion variables

        #region GetSetMethods
        private void Update()
        {
            if (getRout) GetRout();
            else if (setRout) SetRout();
            else if (getPoint) GetPoint();
            else if (setPoint) SetPoint();
            else if (getPointPhoto) GetPointPhoto();
            else if (setPointPhoto) SetPointPhoto();

            else if (getCollection) GetCollection();
            else if (setCollection) SetCollection();
            else if (getCollectionPhoto) GetCollectionPhoto();
            else if (setCollectionPhoto) SetCollectionPhoto();
        }
        private void GetRout()
        {
            routeEditor.GetRout();
            getRout = false;
        }

        private void GetPoint()
        {
            pointEditor.GetPoint();
            getPoint = false;
        }

        private void SetRout()
        {
            routeEditor.SetRout();
            setRout = false;
        }

        private void SetPoint()
        {
            pointEditor.SetPoint();
            setPoint = false;   
        }

        private void GetPointPhoto()
        {
            pointEditor.GetPhoto();
            getPointPhoto = false;
        }
        private void SetPointPhoto()
        {
            pointEditor.SetPhoto();
            setPointPhoto = false;
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

        private void GetCollectionPhoto()
        {
            collectionEditor.GetPhoto();
            getCollectionPhoto = false;
        }
        private void SetCollectionPhoto()
        {
            collectionEditor.SetPhoto();
            setCollectionPhoto = false;
        }

        #endregion GetSetMethods


    }
}
