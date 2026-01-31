using UnityEngine;
using UnityEngine.EventSystems;

public class UIImageClick : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("UI Image clicked: " + gameObject.name);

    }
}