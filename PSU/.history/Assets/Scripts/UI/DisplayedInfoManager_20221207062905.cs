using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayedInfoManager : MonoBehaviour
{
    public static DisplayedInfoManager Instance;

    // Start is called before the first frame update
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        t
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}