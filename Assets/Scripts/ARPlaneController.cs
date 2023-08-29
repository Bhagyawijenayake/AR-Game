using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARPlaneManager))]

public class ARPlaneController : MonoBehaviour
{
    ARPlaneManager m_ARPlaneManager;
    void Awake()
    {
        m_ARPlaneManager = GetComponent<ARPlaneManager>();
    }

    void OnEnable()
    {
        m_ARPlaneManager.onPlacedObject += DisablePlaneDetection;
    }

    void OnDisable()
    {
        m_ARPlaneManager.onPlacedObject -= DisablePlaneDetection;
    }

    void DisablePlaneDetection()
    {
       //planeDetectionMessage = "Disable Plane Detection and Hide Existing Planes";
       SetAllPlanesActive(false);
         m_ARPlaneManager.enabled = false;
    }

    //summary
    //Iterates over all the existing planes and activates
    //or deactivates their <c>GameObject</c>s.
    //summary

    void SetAllPlanesActive(bool value)
    {
        foreach (var plane in m_ARPlaneManager.trackables)
            plane.gameObject.SetActive(value);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
