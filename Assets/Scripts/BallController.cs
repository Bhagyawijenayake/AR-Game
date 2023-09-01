using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using Unity.XR.CoreUtils;
using System;

public class BallController : MonoBehaviour
{

    public GameObject BallPrefab;
    public Transform BallThrowPoint;
    XROrigin aRSession;

    GameObject ARCam;
    private GameObject BallTemp;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        aRSession = GameObject.Find("XR Origin").GetComponent<XROrigin>();
        ARCam = aRSession.transform.Find("Main Camera").gameObject;


    }




    void OnEnable()
    {
        PlaceObjectOnPlane.onPlacedObject += BallInit;
    }

    void OnDisable()
    {
        PlaceObjectOnPlane.onPlacedObject -= BallInit;
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                if (raycastHit.collider.CompareTag("ball"))
                {
                    //Disable back touch Collider from ball
                    raycastHit.collider.enabled = false;

                    BallTemp.transform.parent = aRSession.transform;
                }
            }
        }
    }

    void BallInit()
    {
        StartCoroutine(WaitAndSpawnBall());
    }

    public IEnumerator WaitAndSpawnBall()
    {
        yield return new WaitForSeconds(0.1f);
        BallTemp = Instantiate(BallPrefab, BallThrowPoint.position, ARCam.transform.rotation);
        BallTemp.transform.parent = ARCam.transform;
        rb = BallTemp.GetComponent<Rigidbody>();
        rb.isKinematic = true;

    }

}
