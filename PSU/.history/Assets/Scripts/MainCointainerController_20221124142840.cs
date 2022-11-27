using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainCointainerController : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;


    // Assigns the image, name and description to to UI elements
    public void TryAssignInfo(Sprite image, string name, string description)
    {
        this.image.i = image;
        nameText.text = name;
        descriptionText.text = description;
    }
}
