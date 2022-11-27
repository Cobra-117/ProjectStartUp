using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiatior : MonoBehaviour
{

    public GameObject infoContainerPrefab;
    
    void InstantiateCard()
    {
        GameObject newItem = Instantiate(infoContainerPrefab, transform, flase)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
