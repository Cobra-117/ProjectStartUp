using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preferences : MonoBehaviour
{

    List<string> tags = new List<string>();
    
    void Start()
    {
        // Get tags from database (?) for now it's just premade manually
        tags.Add("vegan");
        tags.Add("vegetarian");
        tags.Add("meat");
        tags.Add("fish");
        tags.Add("low carb");
        tags.Add("high carb");
        tags.Add("high protein");

        // Make buttons
        foreach(string tag in tags)
        {
            // Create buttons
        }

    }


    void Update()
    {
        
    }
}
