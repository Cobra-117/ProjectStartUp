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
        float newPosX = Vector3 new(isRecipeSelected? recipeTagPosX : restaurantTagPosX, selectedBG.up, 0f);
        selectedBG.anchoredPosition = new Vector2(0f, 0f);
    }
}

