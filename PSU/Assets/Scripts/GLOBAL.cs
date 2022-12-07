using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GLOBAL : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        UnityEngine.Random.InitState((int)DateTime.Now.Ticks);
        if (Database.LoadUser() == null)
            createEmptyUser();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void createEmptyUser()
    {
        User user = new User();
        user.recipesTags = new int[] {5, 2, 0, 3, 0, 0, 0, 0, 1};
        user.restaurantsTags = new int[] {5, 2, 0, 3, 0, 0, 0, 0, 1};
        user.recipes = new int[] {};
        user.restaurants = new int[] {};
        Database.SaveUser(user);
    }
}
