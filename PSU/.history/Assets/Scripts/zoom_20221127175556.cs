using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoom : MonoBehaviour
{

    private Swipe _swipeEffect;
    private GameObject _firstItem;


    // Start is called before the first frame update
    void Start()
    {
        _swipeEffect = FindObjectOfType<Swipe>();
        _firstItem = _swipeEffect.gameObject;

        transform
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
