using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Swipe : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Veco
    public void OnBeginDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.localPosition = new Vector2(transform.localPosition.x + eventData.delta.x, transform.localPosition.y);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
