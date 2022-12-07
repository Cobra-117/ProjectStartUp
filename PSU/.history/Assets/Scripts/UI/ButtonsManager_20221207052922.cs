using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    [SerializeField] private GameObject userSettingsOverlay;
    [SerializeField] private GameObject preferencesOverlay;
    [SerializeField] private GameObject joinRoomOverlay;
    [SerializeField] private GameObject createRoomOverlay;
    [SerializeField] private GameObject recipeRestaurantOverlay;
    private List<GameObject> overlays;

    [SerializeField] private GameObject userSettingsButton;
    [SerializeField] private GameObject preferencesButton;
    [SerializeField] private GameObject joinRoomButton;
    [SerializeField] private GameObject createRoomButton;
    [SerializeField] private GameObject discoverButton;
    private List<GameObject> buttons;


    // Start is called before the first frame update
    void Start()
    {
        overlays = new List<GameObject>();
        overlays.Add(userSettingsOverlay);
        overlays.Add(preferencesOverlay);
        overlays.Add(joinRoomOverlay);
        overlays.Add(createRoomOverlay);
        overlays.Add(recipeRestaurantOverlay);

        buttons = new List<GameObject>();
        buttons.Add(userSettingsButton);
        buttons.Add(preferencesButton);
        buttons.Add(joinRoomButton);
        buttons.Add(createRoomButton);
        buttons.Add(discoverButton);
    }

    public void hideEverything()
    {
        foreach(GameObject overlay in overlays)
        {
            // Hide overlay
            overlay.SetActive(false);
        }

        foreach(GameObject button in  buttons)
        {
            Debug.Log("ACCESING button " + button.gameObject.name);
            // Clear selection dots
            MainButton buttonComponent;
            
            TryGetComponent<MainButton>(out buttonComponent);
            Debug.Log
            if(buttonComponent != null) 
            {
                Debug.Log("deactivating button " + buttonComponent);
                buttonComponent.setSelected(false);
            }
        }
    }
}
