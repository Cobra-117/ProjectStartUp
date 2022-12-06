using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailerTest : MonoBehaviour
{
    [SerializeField] private int MaxSwipes = 4;
    private int swipeCounter = 0;
    [SerializeField] private Animator itsAMatchAnimator;

    // Start is called before the first frame update
    void Start()
    {
        Swipe.onSwipped += swipe_onSwipped;
    }

    // Update is called once per frame
    void Update()
    {
        if(swipeCounter >= MaxSwipes)
        {
            itsAMatchAnimator.SetBool("itsAMatch", true);

        }
    }

    void swipe_onSwipped()
    {
        swipeCounter += 1;
    }
}
