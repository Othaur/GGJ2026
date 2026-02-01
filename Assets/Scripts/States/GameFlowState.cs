using UnityEngine;

public abstract class GameFlowState
{
    enum State
    {
        None,
        Start,
        Hover,
        Exit
    }

    State state = State.None;

    public void Trigger()
    {
        state = State.Start;
    }
    public GameFlowState()
    {
        state = State.None;
    }

    public void Update()
    {
        switch (state)
        {
            case State.Start:
                {
                    StartState();
                    state = State.Hover;
                    break;

                }
            case State.Hover:
                {
                    break;
                }
            case State.Exit:
                {
                    ExitState();
                    break;
                }
        }
    }

    public abstract void StartState();
   

    public virtual void Success()
    {
        state = State.Exit;
    }

    public abstract void ExitState();
    
}