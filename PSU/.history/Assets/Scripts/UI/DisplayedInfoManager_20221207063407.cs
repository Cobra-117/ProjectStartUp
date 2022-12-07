using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayedInfoManager : MonoBehaviour
{
    public static DisplayedInfoManager Instance;

    List<string> dislikedRecipes = new List<string>();       // List with the indexes of the the disliked recipes
    List<string> dislikedRestaurants = new List<string>();   // List with the indexes of the the disliked restaurants
    string prevRecipe;
    string prevRestaurant;

    
    void Awake()
    {
        // Set Instance of singleton
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        // Subscribe to swipe events
        Swipe.onLeftSwipped += Swipe_onLeftSwipe;
        Swipe.onRightSwipped += Swipe
    }

    void Swipe_onLeftSwipe()
    {
        Debug.Log("Displayed info manager: LEFT");
    }

    void Swipe_onRightSwipe()
    {
        Debug.Log("Displayed info manager: RIGHT");
    }

    void Update()
    {
        
    }
}
