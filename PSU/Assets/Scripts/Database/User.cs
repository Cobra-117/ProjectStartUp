using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class User
{
    public int [] recipesTags; //Tag index, tag score

    public int [] restaurantsTags; //Tag index, tag score
    public bool isVegetarian = false;
    public bool isVegan = false;

    public int [] recipes;

    public int [] restaurants;
}
