using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Swipe : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Vector3 _initialPosition;
    private float _distanceMoved;
    private bool _swipeLeft;
    [SerializeField] private Image image;


    public void OnBeginDrag(PointerEventData eventData)
    {
        _initialPosition = transform.localPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.localPosition = new Vector2(transform.localPosition.x + eventData.delta.x, transform.localPosition.y);

        // If the item is dragged to the right
        if(transform.localPosition.x - _initialPosition.x > 0)
        {}

        }
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
            if(transform.localPosition.x > _initialPosition.x)
            {
                _swipeLeft = false;
            }
            else
            {
                _swipeLeft = true;
            }

            StartCoroutine(MovedItem());
        }
    }

    private IEnumerator MovedItem()
    {
        float time = 0;
        while(image.color != new Color(1, 1, 1, 0))
        {
            time += Time.deltaTime;


            if(_swipeLeft)
            {
                transform.localPosition = new Vector3(Mathf.SmoothStep(transform.localPosition.x, 
                    transform.localPosition.x - Screen.width, 4 * time), transform.localPosition.y, 0);
            }
            else
            {
                transform.localPosition = new Vector3(Mathf.SmoothStep(transform.localPosition.x, 
                    transform.localPosition.x + Screen.width, 4 * time), transform.localPosition.y, 0);
            }

            image.color = new Color(1, 1, 1, Mathf.SmoothStep(1, 0, 4 * time));
            yield return null;
        }
        Destroy(gameObject);
    }
}
