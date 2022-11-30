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
        recipeTagPosX = recipeTag.transform.localPosition.x;
        restaurantTagPosX = restaurantTag.transform.localPosition.x;
    }

    public void SwitchButton()
    {
        float newPosX = isRecipeSelected?  : restaurantTagPosX;
        selectedBG.transform.localPosition = new Vector2(newPosX, selectedBG.transform.localPosition.y);
        isRecipeSelected = !isRecipeSelected;
        Debug.Log("changing postition");
    }
}

