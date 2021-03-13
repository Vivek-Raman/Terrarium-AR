using UnityEngine.XR.ARFoundation;

public class RoomPlacementState : State
{
    public RoomPlacementState(StateMachine source) : base(source)
    {
    }

    public override void OnStateExit()
    {
        (source as GameManager).TurnOffDebugPlanes();
    }
}