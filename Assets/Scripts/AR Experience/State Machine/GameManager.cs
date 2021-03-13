using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class GameManager : StateMachine
{
    public RoomPlacementState roomPlacementState;
    public RoomExploreState roomExploreState;
    public PlacePlantState placePlantState;
    public PlantInfoState plantInfoState;
    public UserActionAnimationState wateringPlantState;
    public UserActionAnimationState trimmingPlantState;

    public RoomManager Room { get; set; }
    public GameObject interactionCanvas = null;
    public GameObject infoPanel = null;
    public GameObject addPlantInfoCanvas = null;
    public PlantAction plantAction = null;
    public LoadingHandler spinner = null;

    private ARPlaneManager planeManager = null;

    private void Awake()
    {
        roomPlacementState = new RoomPlacementState(this);
        roomExploreState = new RoomExploreState(this);
        placePlantState = new PlacePlantState(this);
        plantInfoState = new PlantInfoState(this);
        wateringPlantState = new UserActionAnimationState(this, "Watering");
        trimmingPlantState = new UserActionAnimationState(this, "Trimming");
        
        initialState = roomPlacementState;

        planeManager = this.GetComponent<ARPlaneManager>();
    }

    public void UI_SetStateToRoomExploreState()
    {
        SetState(roomExploreState);
    }

    public void UI_SetStateToPlacePlantState()
    {
        SetState(placePlantState);
    }

    public void UI_SetStateToPlantInfoState()
    {
        SetState(plantInfoState);
    }

    public void UI_SetStateToWateringPlantState()
    {
        SetState(wateringPlantState);
    }

    public void UI_SetStateToTrimmingPlantState()
    {
        SetState(trimmingPlantState);
    }

    public void TurnOffDebugPlanes()
    {
        planeManager.planePrefab = null;
        foreach (ARPlane plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(false);
        }
    }
}