using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayedInfoManager : MonoBehaviour
{
    public static DisplayedInfoManager Instance;

    public List<string> dislikedRecipes {get; private set;} = new List<string>();       // List with the indexes of the the disliked recipes
    public List<string> dislikedRestaurants {get; private set;} = new List<string>();   // List with the indexes of the the disliked restaurants
    public string prevRecipeIndex {get; private set;}
    public string prevRestaurantIndex {get; private set;}

    
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
        Swipe.onRightSwipped += Swipe_onRightSwipe;
        zoom.onMovedToFront += zoom_onMovedToFront;
    }

    void zoom_onMovedToFront()
    {
        if(Switch.Instance.GetIsRecipeSelected())
        {
            prevRecipeIndex = Instantiatior.currentRecipeIndex;
            //Debug.Log("previous recipe: " + prevRecipeIndex);
        }
        else
        {
            prevRestaurantIndex = Instantiatior.currentRestaurantIndex;
        }
    }

    void Swipe_onLeftSwipe()
    {
        Debug.Log("Displayed info manager: LEFT");

        // If recipe mode is selected
        if(Switch.Instance.GetIsRecipeSelected())
        {
            dislikedRecipes.Add(Instantiatior.currentRecipeIndex);
            Debug.Log("disliked recipe index: " + Instantiatior.currentRecipeIndex);
        }
        else    // if restaurant mode is selected
        {
            dislikedRestaurants.Add(Instantiatior.currentRestaurantIndex);
        }
        
    }

    void Swipe_onRightSwipe()
    {
        Debug.Log("Displayed info manager: RIGHT");
    }

}
