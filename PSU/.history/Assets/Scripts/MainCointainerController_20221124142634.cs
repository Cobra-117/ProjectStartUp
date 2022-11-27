using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainCointainerController : MonoBehaviour
{
    [SerializeField] private Sprite image;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;


    // Assigns the image, name and description to to UI elements
    public bool TryAssignInfo(Sprite image, string name, string description)
    {
        image = image
        return false;
    }
}
