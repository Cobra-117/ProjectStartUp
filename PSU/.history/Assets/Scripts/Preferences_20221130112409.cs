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
    private float yOrigin = 0f;
    private float xOrigin = 0f;
    private float offsetBetweenButtons;
    private float buttonHeight;
    [SerializeField] private RectTransform xOriginGO
    
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

        // Set X Y origin
        xOrigin = Screen.width/-2;
        yOrigin = Screen.height * -0.1f;
        offsetBetweenButtons = Screen.height * 0.6f;

        for(int i = 0; i < tags.Count; i ++)
        {
            // Create button
            var button = Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity) as Button;
            var rectTransform = button.GetComponent<RectTransform>();

            //  Set text
            button.GetComponentInChildren<TextMeshProUGUI>().text = tags[i];
            rectTransform.SetParent(buttonsContainer.gameObject.transform);

            
            // Get button height
            buttonHeight = rectTransform.rect.height;
            rectTransform.localPosition = new Vector3(xOrigin, yOrigin + buttonHeight * i * 2, 0);

            // Set listener
            //button.onClick.AddListener();

        }

    }


    void Update()
    {
        // Update postition (for testing)
        /*for(int i = 0; i < buttonsContainer.GetComponents<Button>().Length; i ++)
        {
            var button = buttonsContainer.GetComponents<Button>()[i];
            button.GetComponent<RectTransform>().localPosition = new Vector3(xOrigin, yOrigin + buttonHeight * i * 2 + offsetBetweenButtons, 0);
        }*/
    }
}
