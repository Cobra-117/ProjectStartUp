using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preferences : MonoBehaviour
{

    List<string> tags = new List<string>();
    
    void Start()
    {
        // Get tags from database (?) for now it's just premade
        tags.AddRange("vegan", "vegetarian", "meat", "fish", "low carb", "high carb", "high protein");
    }


    void Update()
    {
        
    }
}
