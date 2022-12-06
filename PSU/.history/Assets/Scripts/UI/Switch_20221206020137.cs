using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public static Switch Instance;      // singleton instance
    [SerializeField] private RectTransform recipeTag;
    private float recipeTagPosX;
    [SerializeField] private RectTransform restaurantTag;
    private float restaurantTagPosX;
    [SerializeField] private bool isRecipeSelected;
    [SerializeField] private RectTransform selectedBG;

    public delegate void ModeChanged();
    public static event ModeChanged onModeChanged;

    private void Awake()
    {
        if(Instance != null)    // There is another instance of this class
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        recipeTagPosX = recipeTag.transform.localPosition.x;
        restaurantTagPosX = restaurantTag.transform.localPosition.x;

        

    }

    public void SwitchButton()
    {
        changeSelected();
        isRecipeSelected = !isRecipeSelected;
        //Debug.Log("changing postition");

        if(onModeChanged != null)
        {
            onModeChanged();
        }
    }

    private void changeSelected()
    {
        float newPosX = isRecipeSelected? restaurantTagPosX : recipeTagPosX;
        selectedBG.transform.localPosition = new Vector2(newPosX, selectedBG.transform.localPosition.y);
    }

    public bool GetisRecipeSelected()
    {
        return isRecipeSelected;
    }
}

