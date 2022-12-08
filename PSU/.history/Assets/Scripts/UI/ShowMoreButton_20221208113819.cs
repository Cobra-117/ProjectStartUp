using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMoreButton : MonoBehaviour
{
    static GameObject ingredientOverlay;
    private void Start() {
        ingredientOverlay = GameObject.Find("Ingredients overlay");
    }
    public void showMore()
    {
        SetActive(true);
    }
}
