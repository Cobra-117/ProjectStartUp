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


    private enum MainStates {
        Preferences,
        Discover,
        UserSettings,
        CreateRoom,
        JoinRoom
    }
    
    private MainStates currentState = MainStates.Discover;

    // Start is called before the first frame update
    void Start()
    {
        overlays = new List<GameObject>();
        overlays.Add(userSettingsOverlay);
        overlays.Add(preferencesOverlay);
        overlays.Add(joinRoomOverlay);
        overlays.Add(createRoomOverlay);
        overlays.Add(recipeRestaurantOverlay);
    }

    public void hideEverything()
    {
        foreach(Button )

        foreach(GameObject overlay in overlays)
        {
            // Clear selection dots
            overlay.GetComponent<MainButtons>().setSelected(false);

            // Hide overlay
            overlay.SetActive(false);
        }
    }
}