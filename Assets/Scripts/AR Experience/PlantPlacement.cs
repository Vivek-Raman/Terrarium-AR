using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;

public class PlantPlacement : MonoBehaviour
{
    public UnityAction<Transform> plantPlacedAction;
    [HideInInspector] public bool placed = false;

    [SerializeField] private GameObject placeholderPrefab = null;

    private readonly Vector3 centreOfScreen = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0f);
    private Camera cam = null;
    private Transform dummy = null;
    private RaycastHit[] hits = new RaycastHit[5];

    private void OnEnable()
    {
        cam = Camera.main;
        dummy = Instantiate(placeholderPrefab, -cam.transform.forward, Quaternion.identity).transform;
    }

    private void Update()
    {
        if (placed)
        {
            Destroy(dummy.gameObject);
            this.enabled = false;
        }

        Ray ray = cam.ScreenPointToRay(centreOfScreen);
        if (Physics.RaycastNonAlloc(
            ray,
            hits, 3f, 1 << 7) > 0)
        {
            dummy.position = hits[0].point;
            dummy.rotation = Quaternion.identity;

            if (Input.GetMouseButtonUp(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                plantPlacedAction?.Invoke(dummy);
                placed = true;
            }
        }
        else
        {
            dummy.position = -cam.transform.forward;
        }
    }
}