using System.Collections.Generic;
using APIs.Data;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    // on start, hit API for room state
    // instantiate GameObjects for each plant in response

    private List<GameObject> plantObjects = new List<GameObject>();
    private LoadingHandler spinner = null;

    [SerializeField] private GameObject plantContainerPrefab = null;
    [SerializeField] private Transform plantParentTransform = null;

    private void Start()
    {
        spinner = FindObjectOfType<LoadingHandler>(true);
        if (spinner == null)
        {
            Debug.LogError("No loading spinner found in scene");
        }
    }

    public void AssemblePlants()
    {
        spinner.BeginLoading();
        APIController.RoomAPI.GetRoomOfUser(PrefsController.UserID)
            .Then(response =>
            {
                if (response._status != "OK")
                {
                    Debug.LogError(response._status);
                }

                foreach (GameObject plantObject in plantObjects)
                {
                    Destroy(plantObject);
                }

                Transform roomTransform = this.transform;
                foreach (Plant plant in response.plants)
                {
                    plant.speciesID = 1; // TODO: remove
                    GameObject go = Instantiate(
                        plantContainerPrefab,
                        roomTransform.TransformPoint(new Vector3(plant.positionX, plant.positionY, plant.positionZ)),
                        roomTransform.rotation * Quaternion.Euler(plant.rotationX, plant.rotationY, plant.rotationZ),
                        plantParentTransform
                    );

                    go.GetComponent<PlantContainer>().SetPlantState(plant);

                    plantObjects.Add(go);
                }

                spinner.CompleteLoading();
            });
    }
}