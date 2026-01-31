using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIImageClick : MonoBehaviour, IPointerClickHandler
{
    public Image imageBlock { get; private set; }
    public Nono_Tile myTile { get; private set; }

    public bool Active { get; private set; }

    void Start()
    {
        imageBlock = GetComponent<Image>();
        myTile = GetComponent<Nono_Tile>();
        Active = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Active)
        {

            myTile.Toggle();

            if (myTile.Activated)
            {
                imageBlock.color = Color.red;
            }
            else
            {
                imageBlock.color = Color.white;
            }
        }
    }

    public void Deactivate()
    {
        Active = false;
    }
}