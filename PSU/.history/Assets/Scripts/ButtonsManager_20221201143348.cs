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

    // Start is called before the first frame update
    void Start()
    {
        overlays.Add(userSettingsOverlay);
        overlays.Add(preferencesOverlay);
        overlays.Add(joinRoomOverlay);
        overlays.Add(createRoomOverlay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hideEverything()
    {
        foreach(GameObject overlay in overlays)
        {
            
        }
    }
}
