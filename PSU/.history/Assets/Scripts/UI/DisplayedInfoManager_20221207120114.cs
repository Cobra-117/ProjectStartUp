using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayedInfoManager : MonoBehaviour
{
    public static DisplayedInfoManager Instance;

    public List<string> dislikedRecipes {get; private set;} = new List<string>();       // List with the indexes of the the disliked recipes
    public List<string> dislikedRestaurants {get; private set;} = new List<string>();   // List with the indexes of the the disliked restaurants
    string prevRecipeIndex;
    string prevRestaurantIndex;

    
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
        Swipe.onSwipped += Swipe_onSwipe;
        
    }

    void Swipe_onSwipe()
    {
        if(Switch.Instance.GetIsRecipeSelected())
        {
            prevRecipeIndex = Instantiatior.currentRecipeIndex;
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
