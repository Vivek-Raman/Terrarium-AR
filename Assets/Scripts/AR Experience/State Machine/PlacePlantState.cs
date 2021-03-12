using UnityEngine;

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
        gameManager.spinner.BeginLoading();
        APIController.RoomAPI.AddPlantToRoom(
            PrefsController.UserID, 
            1, 
            newTransform.position - gameManager.Room.transform.position,
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