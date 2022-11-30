using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private RectTransform recipeTag;
    private float recipeTagPosX;
    [SerializeField] private RectTransform restaurantTag;
    private float restaurantTagPosX;
    [SerializeField] private bool isRecipeSelected;
    [SerializeField] private RectTransform selectedBG;

    private void Awake()
    {
        recipeTagPosX = recipeTag.anchoredPosition.x;
        recipeTagPosX = restaurantTag.anchoredPosition.x;
    }

    public void SwitchButton()
    {
        float newPosX = isRecipeSelected? recipeTagPosX : restaurantTagPosX;
        selectedBG.anchoredPosition = new Vector2(newPosX, selectedBG.anchoredPosition.y);
    }
}

