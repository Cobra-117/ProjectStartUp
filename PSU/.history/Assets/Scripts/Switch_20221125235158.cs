using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private RectTransform recipeTag;
    private float recipeTagPosX;
    [SerializeField] private RectTransform restaurantTagPosX;
    private float recipeTagPosX;
    [SerializeField] private bool isRecipeSelected;
    [SerializeField] private RectTransform selectedBG;

    public void SwitchButton()
    {
        float newPosX = isRecipeSelected? recipeTagPosX : restaurantTagPosX;
        selectedBG.anchoredPosition = new Vector2(newPosX, selectedBG.anchoredPosition.y);
    }
}

