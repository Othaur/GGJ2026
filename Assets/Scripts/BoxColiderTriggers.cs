using UnityEngine;

public class BoxColiderTriggers : MonoBehaviour
{
    //so uuuuuhhhh I really didnt want to try learning how to used box casts for a game jam so I am kinda cheating with trigger colliders mainly becuase I tryed learning last jam and it didnt go well
    public bool IsTouchingBox = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggering");
        if(collision.gameObject.tag == "PuzzleBoxTile")
        {
            IsTouchingBox = true;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PuzzleBoxTile")
        {
            IsTouchingBox = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PuzzleBoxTile")
        {
            IsTouchingBox = false;
        }
    }
}
