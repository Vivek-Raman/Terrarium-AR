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
    }

    public override void OnStateExit()
    {
        plantPlacement.plantPlacedAction -= OnPlantPlaced;
    }

    private void OnPlantPlaced(Transform newTransform)
    {
        APIController.RoomAPI.AddPlantToRoom(
            PrefsController.UserID, 
            1, 
            newTransform)
            .Then(response =>
            {
                gameManager.SetState(gameManager.roomExploreState);
            })
            .Catch(Debug.LogError);
    }
}