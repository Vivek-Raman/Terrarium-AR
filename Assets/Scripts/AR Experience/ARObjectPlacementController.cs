using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARObjectPlacementController : MonoBehaviour
{
    public GameObject meshToPlace = null;
    private GameManager gameManager = null;

    private ARRaycastManager raycastManager = null;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private bool placed = false;

    private Vector2 tapScreenSpace = Vector2.zero;

    private void Awake()
    {
        gameManager = this.GetComponent<GameManager>();
        raycastManager = this.GetComponent<ARRaycastManager>();
    }

    private void Update()
    {
        if (placed)
        {
            gameManager.SetState(gameManager.roomExploreState);
            this.enabled = false;
        }

        if (Input.touchCount <= 0) return;
        if (Input.GetTouch(0).phase != TouchPhase.Ended) return;
        
        tapScreenSpace = Input.GetTouch(0).position;
        if (raycastManager.Raycast(tapScreenSpace, hits, TrackableType.Planes))
        {
            placed = true;
            gameManager.Room = Instantiate(meshToPlace, hits[0].pose.position, hits[0].pose.rotation).GetComponent<RoomManager>();
        }
    }

    [ContextMenu(nameof(Debug_ForcePlacedTrue))]
    private void Debug_ForcePlacedTrue()
    {
        gameManager.Room = FindObjectOfType<RoomManager>();
        if (gameManager.Room == null) Debug.LogError("No room found.");
        placed = true;
    }
}
