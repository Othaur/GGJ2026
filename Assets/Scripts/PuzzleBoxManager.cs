using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PuzzleBoxManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    PuzzleBoxTiles TileClicked;
    public Button puzzleCompleteButton;

    public bool Peice1InPosition = false;
    public bool Peice2InPosition = false;
    void Start()
    {
        puzzleCompleteButton.enabled = false;
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
            //Debug.Log($"Mouse clicked at world position: {museWorldPos}");

            // Raycast to detect 2D objects under mouse
            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);
            if (hit.collider != null)
            {
                //Debug.Log($"Hit object: {hit.collider.name}");
                
                TileClicked = hit.collider.GetComponent<PuzzleBoxTiles>();
                if (TileClicked != null)
                {
                    TileClicked.IsGrabbed = true;
                }
            }
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            TileClicked.IsGrabbed = false;
        }

        if(Peice1InPosition && Peice2InPosition)
        {
            puzzleCompleteButton.enabled = true;
        }
    }
}
