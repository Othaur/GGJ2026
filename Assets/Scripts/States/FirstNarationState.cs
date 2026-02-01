using UnityEngine;
using UnityEngine.UI;

public class FirstNarationState : GameFlowState
{

    [SerializeField] GameObject narrationPanel;
    
    public override void StartState()
    {
        narrationPanel.SetActive(true);
    }

    public override void ExitState()
    {
        narrationPanel.SetActive(false);
    }
}
