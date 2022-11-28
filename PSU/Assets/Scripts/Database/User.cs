using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class User
{
    public int [] tags; //Tag index, tag score
    public bool isVegetarian = false;
    public bool isVegan = false;

    public int [] recipes;
}
