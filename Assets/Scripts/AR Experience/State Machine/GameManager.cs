using System;
using UnityEngine;

public class GameManager : StateMachine
{
    public RoomPlacementState roomPlacementState;
    public RoomExploreState roomExploreState;
    public PlacePlantState placePlantState;
    public PlantInfoState plantInfoState;

    public RoomManager Room { get; set; }

    private void Awake()
    {
        roomPlacementState = new RoomPlacementState(this);
        roomExploreState = new RoomExploreState(this);
        placePlantState = new PlacePlantState(this);
        plantInfoState = new PlantInfoState(this);
        
        initialState = roomPlacementState;
    }

    private void OnGUI()
    {
        GUILayout.TextArea(currentState.ToString());
    }

    public void UI_SetStateToPlacePlantState()
    {
        SetState(placePlantState);
    }

    public void UI_SetStateToPlantInfoState()
    {
        SetState(plantInfoState);
    }
}