using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private float recipeTagPosX;
    [SerializeField] private float restaurantTagPosX;
    [SerializeField] private bool isRecipeSelected;
    [SerializeField] private RectTransform selectedBG;

    public void SwitchButton()
    {
        selectedBG.r = isRecipeSelected? recipeTagPosX : restaurantTagPosX;
    }
}

