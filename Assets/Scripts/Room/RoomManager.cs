using APIs.Data;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    // on start, hit API for room state
    // instantiate GameObjects for each plant in response

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

        APIController.RoomAPI.GetRoomOfUser(PrefsController.UserID)
            .Then(response =>
            {
                if (response._status != "OK")
                {
                    Debug.LogError(response._status);
                }

                AssemblePlants(response.plants);
                spinner.CompleteLoading();
            });
    }

    private void AssemblePlants(Plant[] plants)
    {
        foreach (Plant plant in plants)
        {
            Transform myTransform = this.transform;
            GameObject go = Instantiate(
                plantContainerPrefab,
                myTransform.TransformPoint(new Vector3(plant.positionX, plant.positionY, plant.positionZ)),
                myTransform.rotation * Quaternion.Euler(plant.rotationX, plant.rotationY, plant.rotationZ),
                plantParentTransform
            );

            go.GetComponent<PlantContainer>().SetPlantState(plant);
        }
    }
}