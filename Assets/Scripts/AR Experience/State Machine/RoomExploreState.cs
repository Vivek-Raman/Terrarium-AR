public class RoomExploreState : State
{
    private GameManager gameManager = null;
    
    public RoomExploreState(StateMachine source) : base(source)
    {
        gameManager = source as GameManager;
    }

    public override void OnStateEnter()
    {
        gameManager.Room.AssemblePlants();
    }
}