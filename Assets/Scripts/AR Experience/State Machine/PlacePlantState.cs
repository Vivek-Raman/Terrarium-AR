using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlacePlantState : State
{
    private GameManager gameManager = null;
    private PlantPlacement plantPlacement = null;

    public PlacePlantState(StateMachine source) : base(source)
    {
        gameManager = source as GameManager;
        plantPlacement = source.GetComponent<PlantPlacement>();
    }

    public override void OnStateEnter()
    {
        plantPlacement.plantPlacedAction += OnPlantPlaced;
        plantPlacement.enabled = true;
        plantPlacement.placed = false;
        gameManager.addPlantInfoCanvas.SetActive(true);
    }

    public override void OnStateExit()
    {
        plantPlacement.plantPlacedAction -= OnPlantPlaced;
        gameManager.addPlantInfoCanvas.SetActive(false);
    }

    private void OnPlantPlaced(Transform newTransform)
    {
        newTransform.Rotate(0f, Random.Range(0f, 360f), 0f);
        gameManager.spinner.BeginLoading();
        Vector3 newTransformPosition = gameManager.Room.transform.InverseTransformPoint(newTransform.position);
        APIController.RoomAPI.AddPlantToRoom(
            PrefsController.UserID,
            1,
            newTransformPosition,
            newTransform.rotation.eulerAngles)
            .Then(response =>
            {
                gameManager.spinner.CompleteLoading();
                gameManager.SetState(gameManager.roomExploreState);
            })
            .Catch(error =>
            {
                gameManager.spinner.CompleteLoading();
                Debug.LogError(error);
            });
    }
}