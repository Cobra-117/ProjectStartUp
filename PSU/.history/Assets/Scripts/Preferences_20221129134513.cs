using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preferences : MonoBehaviour
{

    string[] tags;
    
    void Start()
    {
        // Get tags from database (?) for now it's just premade
        tags = ["vegan", "vegetarian", "meat", "fish", "low carb", "high carb", ];
    }


    void Update()
    {
        
    }
}
