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

    // Start is called before the first frame update
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
