public class GameManager : StateMachine
{
    public RoomPlacementState roomPlacementState;
    public RoomExploreState roomExploreState;
    public PlacePlantState placePlantState;
    
    private void Awake()
    {
        roomPlacementState = new RoomPlacementState(this);
        roomExploreState = new RoomExploreState(this);
        placePlantState = new PlacePlantState(this);
        
        initialState = roomPlacementState;
    }
}