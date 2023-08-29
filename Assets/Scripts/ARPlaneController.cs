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
        PlaceObjectOnPlane.OnPlacedObject += DisablePlaneDetection;
    }

    void OnDisable()
    {
        PlaceObjectOnPlane.OnPlacedObject -= DisablePlaneDetection;
    }

    /// <summary>
    /// Disables plane detection and hides existing planes.
    /// </summary>
    void DisablePlaneDetection()
    {
        SetAllPlanesActive(false);
        m_ARPlaneManager.enabled = !m_ARPlaneManager.enabled;
    }

    /// <summary>
    /// Iterates over all the existing planes and activates
    /// or deactivates their <c>GameObject</c>s.
    /// </summary>
    void SetAllPlanesActive(bool value)
    {
        foreach (var plane in m_ARPlaneManager.trackables)
        {
            plane.gameObject.SetActive(value);
        }
    }

    void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        // You can handle plane changes here if needed
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initialization code if needed
    }

    // Update is called once per frame
    void Update()
    {
        // Update logic if needed
    }
}
