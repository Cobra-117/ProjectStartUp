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
    private List<GameObject> overlays;

    [SerializeField] private Button userSettingsButton;
    [SerializeField] private Button preferencesButton;
    [SerializeField] private Button joinRoomButton;
    [SerializeField] private Button createRoomButton;
    [SerializeField] private Button discoverButton;


    private enum MainStates {
        Preferences,
        Discover,
        UserSettings,
        CreateRoom,
        JoinRoom
    }
    
    private MainStates currentState = dis;

    // Start is called before the first frame update
    void Start()
    {
        overlays.Add(userSettingsOverlay);
        overlays.Add(preferencesOverlay);
        overlays.Add(joinRoomOverlay);
        overlays.Add(createRoomOverlay);
    }

    public void hideEverything()
    {
        foreach(GameObject overlay in overlays)
        {
            overlay.SetActive(false);
        }
    }
}
