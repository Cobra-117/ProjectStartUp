using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Recipe
{
    public int index;
    public string name;
    public bool isVegetarian;
    public bool isVegan;
    public string [] tags;
}