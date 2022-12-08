using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMoreButton : MonoBehaviour
{
    static GameObject ingredientOverlay;
    private void Start() {
        
    }
    public void showMore()
    {
        GameObject.Find("Ingredients overlay").SetActive(true);
    }
}
