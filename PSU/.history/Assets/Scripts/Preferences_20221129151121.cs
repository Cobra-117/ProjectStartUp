using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Preferences : MonoBehaviour
{
    private List<string> tags = new List<string>();
    [SerializeField] private Button buttonPrefab;
    [SerializeField] private GameObject buttonsContainer;
    [SerializeField] private float yOrigin = 0;
    [SerializeField] private float xOrigin = 0;
    [SerializeField] private float offsetBetweenButtons = 50;
    private float buttonHeight
    
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
        for(int i = 0; i < tags.Count; i ++)
        {
            // Create buttons
            var button = Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity) as Button;
            var rectTransform = button.GetComponent<RectTransform>();
            button.GetComponentInChildren<TextMeshProUGUI>().text = tags[i];
            rectTransform.SetParent(buttonsContainer.gameObject.transform);

            
            // Get button height
            buttonHeight = rectTransform.rect.height;
            rectTransform.localPosition = new Vector3(xOrigin, yOrigin + buttonHeight * i * 2 + offsetBetweenButtons, 0);
            //button.onClick.AddListener(SpawnPlayer);

        }

    }


    void Update()
    {
        // Update postition (for testing)
        for(int i = 0; i < buttonsContainer.GetComponents<Button>().Length; i ++)
        {
            var button = buttonsContainer.GetComponents<Button>()[i];
            button.GetComponent<RectTransform>().localPosition = new Vector3(xOrigin, yOrigin + buttonHeight * i * 2 + offsetBetweenButtons, 0);
        }
    }
}
