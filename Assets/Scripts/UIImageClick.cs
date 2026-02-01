using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIImageClick : MonoBehaviour, IPointerClickHandler
{
    public Image imageBlock { get; private set; }
    //public Nono_Tile myTile { get; private set; }
    public bool Activated { get; private set; }

    public bool Active { get; private set; }

    void Awake()
    {
        imageBlock = GetComponent<Image>();
        //myTile = GetComponent<Nono_Tile>();
        Active = true;
        Activated = false;
    }

    public void Toggle()
    {
        Debug.Log("Swapped Value");
        Activated = !Activated;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Active)
        {

            Toggle();

            if (Activated)
            {
                imageBlock.color = Color.red;
            }
            else
            {
                imageBlock.color = Color.white;
            }
        }
    }

    public void Prefill()
    {
        Toggle();
        Debug.Log("Toggled to " + Activated);
       // imageBlock.color = Color.red;
    }
    public void Deactivate()
    {
        Active = false;
    }

    void Update()
    {
        if (Activated)
        {
            imageBlock.color = Color.red;            
        }
        else
        {
            imageBlock.color = Color.white;
        }
    }
}