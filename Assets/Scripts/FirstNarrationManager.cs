using UnityEngine;

public class FirstNarrationManager : MonoBehaviour
{
    [SerializeField] GameObject narrationpanel;
    [SerializeField] GameObject maskPanel;
    [SerializeField] GameObject button;

    textscroll scrolling;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scrolling = narrationpanel.GetComponentInChildren<textscroll>();
        scrolling.ActivateText();
    }

    // Update is called once per frame
    void Update()
    {
        if (!scrolling.isTyping)
        {
            maskPanel.SetActive(true);
            if (button != null)
            {
                button.SetActive(true);
            }
        }
    }
}
