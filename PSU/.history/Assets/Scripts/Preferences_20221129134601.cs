using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preferences : MonoBehaviour
{

    List<string> tags;
    
    void Start()
    {
        // Get tags from database (?) for now it's just premade
        tags = new List("vegan", "vegetarian", "meat", "fish", "low carb", "high carb", "high protein");
    }


    void Update()
    {
        
    }
}
