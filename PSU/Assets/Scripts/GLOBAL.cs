using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GLOBAL : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Random.InitState((int)DateTime.Now.Ticks);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
