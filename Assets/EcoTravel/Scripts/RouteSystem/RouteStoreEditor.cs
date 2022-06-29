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

        [Space]
        [Space]

        [SerializeField] RoadEditor roadEditor;
        [SerializeField] bool getRoad;
        [SerializeField] bool setRoad;
        #endregion variables

        #region GetSetMethods
        private void Update()
        {
            if (getRout) GetRout();
            else if (setRout) SetRout();
            else if (getPoint) GetPoint();
            else if (setPoint) SetPoint();
            else if (getRoad) GetRoad();
            else if (setRoad) SetRoad();
        }
        private void GetRout()
        {
            routeEditor.GetRout();
            getRout = false;
        }
        private void GetRoad()
        {
            roadEditor.GetRoad();
            getRoad = false;
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
        private void SetRoad()
        {
            roadEditor.SetRoad();
            setRoad = false;
        }
        private void SetPoint()
        {
            pointEditor.SetPoint();
            setPoint = false;   
        }
        

        #endregion GetSetMethods


    }
}
