using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiatior : MonoBehaviour
{

    public GameObject infoContainerPrefab;
    
    void InstantiateItem()
    {
        GameObject newItem = Instantiate(infoContainerPrefab, transform, false);
        newItem.Ge
        newItem.transform.SetAsFirstSibling();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount < 2)
        {
            InstantiateItem();
        }
    }
}
