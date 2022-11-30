using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.

public class MainCointainerController : MonoBehaviour
{
    [SerializeField] private Im image;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;


    // Assigns the image, name and description to to UI elements
    public void TryAssignInfo(Sprite image, string name, string description)
    {
        this.image = image;
        nameText.text = name;
        descriptionText.text = description;
    }
}
