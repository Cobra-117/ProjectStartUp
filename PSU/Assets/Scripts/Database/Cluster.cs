using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Cluster
{
    public int index;
    public string name;
    public string[] recipes;
}

[Serializable]
public class RestaurantCluster
{
    public int index;
    public string name;
    public string[] restaurant;
}
