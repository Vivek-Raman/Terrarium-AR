using System;
using APIs.Data;
using APIs.Data.Enum;
using UnityEngine;

public class PlantAction : MonoBehaviour
{
    [SerializeField] private LoadingHandler spinner = null;

    private Plant activePlant = null;
    private Animator animator = null;

    private void Awake()
    {
        animator = this.GetComponent<Animator>();
    }

    private void OnEnable()
    {
        PlantContainer.playerEntersPlantProximityAction += OnPlayerEntersPlantProximity;
        PlantContainer.playerExitsPlantProximityAction += OnPlayerExitsPlantProximity;
    }

    private void OnDisable()
    {
        PlantContainer.playerEntersPlantProximityAction -= OnPlayerEntersPlantProximity;
        PlantContainer.playerExitsPlantProximityAction -= OnPlayerExitsPlantProximity;
    }

    public float ShowAnimationAndReturnDuration(Vector3 roomPos, string animToShow)
    {
        if (activePlant == null)
        {
            Debug.LogWarning("No active plant");
            return 0f;
        }

        this.transform.SetPositionAndRotation(
            roomPos + new Vector3(activePlant.positionX, activePlant.positionY, activePlant.positionZ),
            Quaternion.Euler(activePlant.rotationX, activePlant.rotationY, activePlant.rotationZ));

        animator.SetTrigger(animToShow);

        ActionType type;
        switch (animToShow)
        {
            case "Watering":
                type = ActionType.USER_WATERS_PLANT;
                break;
            case "Trimming":
                type = ActionType.USER_TRIMS_PLANT;
                break;
            default:
                type = ActionType.NULL;
                break;
        }

        spinner.BeginLoading();
        APIController.ActionAPI.AddAction(activePlant.plantID, type)
            .Then(response =>
            {
                spinner.CompleteLoading();
            })
            .Catch(error =>
            {
                spinner.CompleteLoading();
                Debug.LogError(error);
            });
        
        return 2f;
    }

    private void OnPlayerEntersPlantProximity(Plant plant)
    {
        activePlant = plant;
    }

    private void OnPlayerExitsPlantProximity(Plant plant)
    {
        activePlant = null;
    }
}
