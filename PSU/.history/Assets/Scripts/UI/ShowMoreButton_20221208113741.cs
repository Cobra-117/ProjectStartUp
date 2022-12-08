using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMoreButton : MonoBehaviour
{
    private void Start() {
        
    }
    public void showMore()
    {
        GameObject.Find("Ingredients overlay").SetActive(true);
    }
}
