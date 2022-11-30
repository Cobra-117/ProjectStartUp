using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Swipe : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Vector3 _initialPosition;
    private float _distanceMoved;
    private bool _swipeLeft;


    public void OnBeginDrag(PointerEventData eventData)
    {
        _initialPosition = transform.localPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.localPosition = new Vector2(transform.localPosition.x + eventData.delta.x, transform.localPosition.y);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _distanceMoved = Mathf.Abs(transform.localPosition.x - _initialPosition.x);
        if(_distanceMoved < 0.4 * Screen.width)
        {
            transform.localPosition = _initialPosition;
        }
        else 
        {
            if(transform.position.x > _initialPosition.x)
            {
                _swipeLeft = false;
            }
            else
            {
                _swipeLeft = true;
            }

            StartCoroutine(MovedItem)
        }
    }

    private IEnumerator MovedItem()
    {
        float time = 0;
        while(GetComponent<Image>().Color != new Color(1, 1, 1, 0))
        {
            time += Time.deltaTime;
        }
        yield return null;
    }
}
