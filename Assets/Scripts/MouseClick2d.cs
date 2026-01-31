using UnityEngine;
using UnityEngine.InputSystem; // Required for the new Input System

public class MouseClick2D : MonoBehaviour
{
    [SerializeField] private Camera mainCamera; // Assign in Inspector (usually Main Camera)

    private void Awake()
    {
        // Auto-assign main camera if not set
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    private void Update()
    {
        // Get mouse position in screen coordinates
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();

        // Convert to world position (for 2D)
        Vector2 mouseWorldPos = mainCamera.ScreenToWorldPoint(mouseScreenPos);

        // Example: Draw a debug point at mouse position
        Debug.DrawLine(mouseWorldPos, mouseWorldPos + Vector2.up * 0.1f, Color.red);

        // Detect left mouse click
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log($"Mouse clicked at world position: {mouseWorldPos}");

            // Raycast to detect 2D objects under mouse
            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);
            if (hit.collider != null)
            {
                Debug.Log($"Hit object: {hit.collider.name}");
                // Example: Change color if object has a SpriteRenderer
                SpriteRenderer sr = hit.collider.GetComponent<SpriteRenderer>();
                if (sr != null)
                    sr.color = Random.ColorHSV();
            }
        }
    }
}
