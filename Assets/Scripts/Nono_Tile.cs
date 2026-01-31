using UnityEngine;

public class Nono_Tile : MonoBehaviour
{
    public bool Activated { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Activated = false;    
        //Debug.Log("Start value " + Activated.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Toggle()
    {
        Activated = !Activated;
    }
}
