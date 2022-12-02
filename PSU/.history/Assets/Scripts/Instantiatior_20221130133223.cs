using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiatior : MonoBehaviour
{

    public GameObject infoContainerPrefab;

    
    void InstantiateItem()
    {
        // Create user
        User user = new User();
        user.tags = new int[] {5, 2, 0, 3, 0, 0, 0, 0, 1};
        user.recipes = new int[] {};

        GameObject newItem = Instantiate(infoContainerPrefab, transform, false);
        newItem.gameObject.GetComponent<MainInfoContainerView>().AssignInfo(null, "name lol", "descriptionaaaaaaaaaaaaaaaaaaaaaaaa");
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
