using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PuzzleBoxTiles : MonoBehaviour
{
    public bool XLocked;
    public bool YLocked;

    public GameObject TopLeftCorner;
    public GameObject BottomRightCorner;

    public bool IsGrabbed = false;

    float newX;
    float newY;

    public GameObject Left;
    public GameObject Right;

      //references to the trigger colliders on each side of the box to see if it can move or not. sorry I did this instead of box cast becuase last time I tryed it didnt go well
     BoxColiderTriggers LeftTrigger;
     BoxColiderTriggers RightTrigger;

     public float TileSpeed = 10f;

     public Rigidbody2D rb;
     Vector2 LastPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LastPos = rb.position;

        LeftTrigger = Left.GetComponent<BoxColiderTriggers>();
        RightTrigger = Right.GetComponent<BoxColiderTriggers>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(IsGrabbed)
        {
            Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);

            if(XLocked)
            {
                newX = transform.position.x;
                rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            }else
            {
                if(LeftTrigger.IsTouchingBox && mouseWorldPos.x < transform.position.x || RightTrigger.IsTouchingBox && mouseWorldPos.x > transform.position.x)
                {
                    newX = rb.position.x;
                }
                else
                {
                  newX = Mathf.MoveTowards(transform.position.x, Mathf.Clamp(mouseWorldPos.x, TopLeftCorner.transform.position.x, BottomRightCorner.transform.position.x) , TileSpeed * Time.fixedDeltaTime);
                }
            }

            if(YLocked)
            {

                newY = rb.position.y;
                rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            }else
            {
                if(LeftTrigger.IsTouchingBox && mouseWorldPos.y < transform.position.y || RightTrigger.IsTouchingBox && mouseWorldPos.y > transform.position.y)
                {
                    newY = rb.position.y;
                }
                else
                {
                    newY = Mathf.MoveTowards(transform.position.y, Mathf.Clamp(mouseWorldPos.y, BottomRightCorner.transform.position.y, TopLeftCorner.transform.position.y), TileSpeed * Time.fixedDeltaTime);
                }
            }

            rb.MovePosition(new Vector2(newX, newY));
            LastPos = rb.position;
        }else
        {
            rb.position = LastPos;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
