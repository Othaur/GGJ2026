using UnityEngine;

public class PuzzleBoxFinishPosition : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float FinalPositionX; //you must set this to the corect postion on where this peice finishes at or the puzzle will not regiter compleation
    public GameObject PuzzleBoxManagerObject;
    PuzzleBoxManager PuzzleBoxManager;
    public bool WhichPeice = true; //set to true if this is peice 1 false if peice 2
    public float tolerance = 0.5f;

    void Start()
    {
        PuzzleBoxManager = PuzzleBoxManagerObject.GetComponent<PuzzleBoxManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Mathf.Abs(transform.position.x - FinalPositionX) <= tolerance)//defult pos 0.16 postion for final pos is 0.06 but doesnt trigger untill -0.3
        {
            Debug.Log("Peice in position");
            if(WhichPeice == false)
            {
                PuzzleBoxManager.Peice2InPosition = true;
            }else
            {
                PuzzleBoxManager.Peice1InPosition = true;
            }
        }
    }
}
