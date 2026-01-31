using UnityEngine;
using UnityEngine.InputSystem;
public class SlidingBoxController : MonoBehaviour
{
    public int boxIndex;//defines which box it is in the grid 0-8 
    int LastBoxIndex;
    SlidingPuzzleManager puzzleManager;
    public GameObject SlidingPuzzleManagerObject;
    public LayerMask HiddenBoxLayerMask;

    //definds X Positions for Columns
    public float LeftTileX = -1.9f;
    public float MiddleTileX = 0.16f;
    public float RightTileX = 2.17f;

    //definds Y Positions for Rows
    public float TopTileY = 0.9f;
    public float MiddleTileY = -1.12f;
    public float BottomTileY = -3.18f;

    public float raycastDistance = 1.0f;

    void Start()
    {
        puzzleManager = SlidingPuzzleManagerObject.GetComponent<SlidingPuzzleManager>();
    }

   public void ReloadPos()//checks box index and moves to correct position
    {
        if(boxIndex == 0)
        {
            transform.position = new Vector2(LeftTileX, TopTileY);
        }
        else if(boxIndex == 1)
        {
            transform.position = new Vector2(MiddleTileX, TopTileY);
        }
        else if(boxIndex == 2)
        {
            transform.position = new Vector2(RightTileX, TopTileY);
        }
        else if(boxIndex == 3)
        {
            transform.position = new Vector2(LeftTileX, MiddleTileY);
        }
        else if(boxIndex == 4)
        {
            transform.position = new Vector2(MiddleTileX, MiddleTileY);
        }
        else if(boxIndex == 5)
        {
            transform.position = new Vector2(RightTileX, MiddleTileY);
        }
        else if(boxIndex == 6)
        {
            transform.position = new Vector2(LeftTileX, BottomTileY);
        }
        else if(boxIndex == 7)
        {
            transform.position = new Vector2(MiddleTileX, BottomTileY);
        }
        else if(boxIndex == 8)
        {
            transform.position = new Vector2(RightTileX, BottomTileY);
        }

        
    }

    /*
    void Update()
    {
        Debug.DrawLine(transform.position, transform.position + Vector3.up * raycastDistance, Color.red);
        Debug.DrawLine(transform.position, transform.position + -Vector3.up * raycastDistance, Color.red);
        Debug.DrawLine(transform.position, transform.position + Vector3.left * raycastDistance, Color.red);
        Debug.DrawLine(transform.position, transform.position + -Vector3.left * raycastDistance, Color.red);
    }
    */
    

    public void WhenClicked()
    {
        RaycastHit2D UpCheck = Physics2D.Raycast(transform.position, Vector2.up, raycastDistance, HiddenBoxLayerMask);
        RaycastHit2D DownCheck = Physics2D.Raycast(transform.position, -Vector2.up, raycastDistance, HiddenBoxLayerMask);
        RaycastHit2D LeftCheck = Physics2D.Raycast(transform.position, Vector2.left, raycastDistance, HiddenBoxLayerMask);
        RaycastHit2D RightCheck = Physics2D.Raycast(transform.position, -Vector2.left, raycastDistance, HiddenBoxLayerMask);


        LastBoxIndex = boxIndex;
        if(UpCheck.collider != null || DownCheck.collider != null || LeftCheck.collider != null || RightCheck.collider != null)//if there is a hidden box next to the clicked box
        {
            //Debug.Log("Box Clicked");
            boxIndex = puzzleManager.boxEightController.boxIndex; //set clicked box index to hidden box index moving the box you clicked on around
            puzzleManager.MoveHiddenBox(LastBoxIndex);//set hidden box to where the last box was
            ReloadPos();//sets everything to correct positions
        }
    }
}
