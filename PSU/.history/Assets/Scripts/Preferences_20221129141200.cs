using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Preferences : MonoBehaviour
{
    private List<string> tags = new List<string>();
    [SerializeField] private Button buttonPrefab;
    [SerializeField] private GameObject buttonsContainer;
    
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
            var button = Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity) as Button;
            var rectTransform = button.GetComponent<RectTransform>();
            rectTransform.SetParent(buttonsContainer.ga);
            rectTransform.offsetMin = Vector2.zero;
            rectTransform.offsetMax = Vector2.zero;
            //button.onClick.AddListener(SpawnPlayer);

        }

    }


    void Update()
    {
        
    }
}
