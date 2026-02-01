using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class SlidingPuzzleManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    [SerializeField] GameObject narrationPanel;
    [SerializeField] GameObject maskPiece;
    [SerializeField] GameObject successPanel;
    [SerializeField] GameObject puzzle;

    public GameObject BoxZero;
    SlidingBoxController boxZeroController;
    public GameObject BoxOne;
    SlidingBoxController boxOneController;
    public GameObject BoxTwo;
    SlidingBoxController boxTwoController;
    public GameObject BoxThree;
    SlidingBoxController boxThreeController;
    public GameObject BoxFour;
    SlidingBoxController boxFourController;
    public GameObject BoxFive;
    SlidingBoxController boxFiveController;
    public GameObject BoxSix;
    SlidingBoxController boxSixController;
    public GameObject BoxSeven;
    SlidingBoxController boxSevenController;
    public GameObject BoxEight;
    [HideInInspector] public SlidingBoxController boxEightController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        // Auto-assign main camera if not set
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    public void ShowPuzzle()
    {
        narrationPanel.SetActive(false);        
        puzzle.SetActive(true);
    }
    public void ShowSuccess()
    {
        narrationPanel.SetActive(false);
        puzzle.SetActive(false);
        successPanel.SetActive(true);
        maskPiece.SetActive(true);

        successPanel.GetComponentInChildren<textscroll>().ActivateText();
    }

    void Start()
    {
        puzzle.SetActive(false);
        successPanel.SetActive(false);
        narrationPanel.SetActive(true);
        narrationPanel.GetComponentInChildren<textscroll>().ActivateText();
        

        //to whom ever is reading this, im sorry for everything that is about to follow please forgive me and my crappy Game Jam Coding skills
        boxZeroController = BoxZero.GetComponent<SlidingBoxController>();
        boxOneController = BoxOne.GetComponent<SlidingBoxController>();
        boxTwoController = BoxTwo.GetComponent<SlidingBoxController>();
        boxThreeController = BoxThree.GetComponent<SlidingBoxController>();
        boxFourController = BoxFour.GetComponent<SlidingBoxController>();
        boxFiveController = BoxFive.GetComponent<SlidingBoxController>();
        boxSixController = BoxSix.GetComponent<SlidingBoxController>();
        boxSevenController = BoxSeven.GetComponent<SlidingBoxController>();
        boxEightController = BoxEight.GetComponent<SlidingBoxController>();

        boxZeroController.boxIndex = 8; //sets all boxes to their starting index positions make sure to suffle these numbers to randomize the puzzle
        boxOneController.boxIndex = 6;
        boxTwoController.boxIndex = 5;
        boxThreeController.boxIndex = 7;
        boxFourController.boxIndex = 4;
        boxFiveController.boxIndex = 1;
        boxSixController.boxIndex = 0;
        boxSevenController.boxIndex = 3;
        boxEightController.boxIndex = 2;

        boxZeroController.ReloadPos();
        boxOneController.ReloadPos();
        boxTwoController.ReloadPos();
        boxThreeController.ReloadPos();
        boxFourController.ReloadPos();
        boxFiveController.ReloadPos();
        boxSixController.ReloadPos();
        boxSevenController.ReloadPos();
        boxEightController.ReloadPos();
    }

    public void MoveHiddenBox(int boxIndex) //moves the hidden box to the given index
    {
        boxEightController.boxIndex = boxIndex;
        boxEightController.ReloadPos();
        if(boxZeroController.boxIndex == 0 &&
           boxOneController.boxIndex == 1 &&
           boxTwoController.boxIndex == 2 &&
           boxThreeController.boxIndex == 3 &&
           boxFourController.boxIndex == 4 &&
           boxFiveController.boxIndex == 5 &&
           boxSixController.boxIndex == 6 &&
           boxSevenController.boxIndex == 7)
        {
            Debug.Log("Puzzle Solved!"); //put puzzle solved code here!
            ShowSuccess();
        }
    }

    private void Update()
    {
        // Get mouse position in screen coordinates
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();

        // Convert to world position (for 2D)
        Vector2 mouseWorldPos = mainCamera.ScreenToWorldPoint(mouseScreenPos);

        // Example: Draw a debug point at mouse position
        //Debug.DrawLine(mouseWorldPos, mouseWorldPos + Vector2.up * 0.1f, Color.red);

        // Detect left mouse click
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            //Debug.Log($"Mouse clicked at world position: {mouseWorldPos}");

            // Raycast to detect 2D objects under mouse
            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);
            if (hit.collider != null)
            {
                //Debug.Log($"Hit object: {hit.collider.name}");
                
                SlidingBoxController LastBoxClicked = hit.collider.GetComponent<SlidingBoxController>();
                if (LastBoxClicked != null)
                {
                    LastBoxClicked.WhenClicked();
                }
            }
        }
    }
}
