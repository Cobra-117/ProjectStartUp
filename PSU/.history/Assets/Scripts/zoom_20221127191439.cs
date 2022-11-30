using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoom : MonoBehaviour
{

    public Swipe _swipeEffect;
    private GameObject _firstItem;


    // Start is called before the first frame update
    void Start()
    {
        _firstItem = _swipeEffect.gameObject;
        _swipeEffect.itemMoved += ItemMovedFront;
        transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        if(_firstItem != null)
        {
            float distanceMoved = _firstItem.transform.localPosition.x;
            
            if(Mathf.Abs(distanceMoved) > 0)
            {
                float step = Mathf.SmoothStep(0.8f, 1, Mathf.Abs(distanceMoved)/(Screen.width/2));
                transform.localScale = new Vector3(step, step, step);
            }
        }
    }

    void ItemMovedFront()
    {
        gameObject.AddComponent<Swipe>();
        Destroy(this);
    }
}
