public class PlantInfoState : State
{
    private GameManager gameManager = null;

    public PlantInfoState(StateMachine source) : base(source)
    {
        gameManager = source as GameManager;
    }

    public override void OnStateEnter()
    {
        // enable info canvas
        gameManager.infoPanel.SetActive(true);

        // populate text
    }

    public override void OnStateExit()
    {
        gameManager.infoPanel.SetActive(false);
    }
}