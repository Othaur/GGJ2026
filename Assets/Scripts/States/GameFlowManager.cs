using UnityEngine;
using System.Collections.Generic;



public class GameFlowManager : MonoBehaviour
{
    public enum GameState
    {
        None,
        FirstNarration, 
        Puzzle1Narration, 
        Puzzle1Solve,
        Puzzle1Success,
        Puzzle2Narration, 
        Puzzle2Solve,
        Puzzle2Success,
        Puzzle3Narration,
        Puzzle3Solve,
        Puzzle3Success,
        Puzzle4Narration,
        Puzzle4Solve,
        Puzzle4Success,
    }

    public GameState state;

    [SerializeField] List<GameFlowState> gameflow;
    FirstNarationState fns;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = GameState.None;
        gameflow = new List<GameFlowState>();
        fns = new FirstNarationState();

        gameflow.Add(fns);
    }

    public void NextFlow()
    {
        GameFlowState temp = gameflow[0];
        gameflow.RemoveAt(0);

        temp.Trigger();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case GameState.FirstNarration:
                {
                    break;
                }
            case GameState.Puzzle1Narration:
                { 
                    break; 
                }            
            case GameState.Puzzle1Solve:
            case GameState.Puzzle1Success:
            case GameState.Puzzle2Narration:
                case GameState.Puzzle2Solve:
                case GameState.Puzzle2Success:
                case GameState.Puzzle3Narration:
                case GameState.Puzzle3Solve: 
            case GameState.Puzzle3Success:
            case GameState.Puzzle4Narration:
                case GameState.Puzzle4Solve:
                case GameState.Puzzle4Success:
                {
                    break;
                }

                
        }

            
    }
}
