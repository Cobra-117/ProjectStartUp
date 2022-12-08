using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMoreButton : MonoBehaviour
{
    static GameObject ingredientOverlay;
    static GameObject restaurantOverlay;
    private void Start() {
        ingredientOverlay = FindInActiveObjectByTag("ingredients");
        restaurantOverlay = FindInActiveObjectByTag()
    }
    public void showMore()
    {
        ingredientOverlay.SetActive(true);
    }

GameObject FindInActiveObjectByTag(string tag)
{

    Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
    for (int i = 0; i < objs.Length; i++)
    {
        if (objs[i].hideFlags == HideFlags.None)
        {
            if (objs[i].CompareTag(tag))
            {
                return objs[i].gameObject;
            }
        }
    }
    return null;
}
}
