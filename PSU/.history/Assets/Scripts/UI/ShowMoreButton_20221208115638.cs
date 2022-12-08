using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMoreButton : MonoBehaviour
{
    static GameObject ingredientOverlay;
    private void Start() {
        ingredientOverlay = GameObject.Find("Ingredients overlay");
        ingredientOverlay.SetActive(false);
    }
    public void showMore()
    {
        ingredientOverlay.SetActive(true);
    }
}
