using UnityEngine;

public class UserActionAnimationState : State
{
    private GameManager gameManager = null;
    private string animTrigger = null;
    private int framesToStall = 0;

    public UserActionAnimationState(StateMachine source, string animTrigger) : base(source)
    {
        gameManager = source as GameManager;
        this.animTrigger = animTrigger;
    }

    public override void OnStateEnter()
    {
        float duration = gameManager.plantAction.ShowAnimationAndReturnDuration(gameManager.Room.transform.position, animTrigger);
        framesToStall = (int) duration * Application.targetFrameRate;
    }

    public override void OnStateTick()
    {
        if (framesToStall <= 0)
        {
            gameManager.SetState(gameManager.roomExploreState);
        }
        else
        {
            --framesToStall;
        }
    }
}