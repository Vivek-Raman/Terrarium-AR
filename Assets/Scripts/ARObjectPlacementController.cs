using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARObjectPlacementController : MonoBehaviour
{
    public GameObject meshToPlace = null;

    private ARRaycastManager raycastManager = null;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private bool placed = false;

    private readonly Vector2 centreOfScreen = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);

    private void Awake()
    {
        raycastManager = this.GetComponent<ARRaycastManager>();
    }

    private void Update()
    {
        if (placed) this.enabled = false;

        if (Input.touchCount <= 0) return;
        if (Input.GetTouch(0).phase != TouchPhase.Ended) return;
        
        if (raycastManager.Raycast(centreOfScreen, hits, TrackableType.Planes))
        {
            placed = true;
            Instantiate(meshToPlace, hits[0].pose.position, hits[0].pose.rotation);
        }
    }
}
