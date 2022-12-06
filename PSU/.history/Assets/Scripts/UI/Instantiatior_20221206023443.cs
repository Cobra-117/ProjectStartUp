using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiatior : MonoBehaviour
{

    public GameObject infoContainerPrefabZoom;
    public GameObject infoContainerPrefabSwipe;
    private RecipeReccomendation recipeReccomendation;
    private RestaurantRecommendation restaurantRecommendation;
    private User user;
    [SerializeField] MainInfoContainerView firstRecipe;
    [SerializeField] MainInfoContainerView secondRecipe;
    private bool lookingForRecipes;


    private void Awake() {
        // Create user
        user = new User();
        user.recipesTags = new int[] {5, 2, 0, 3, 0, 0, 0, 0, 1};
        user.restaurantsTags = new int[] {5, 2, 0, 3, 0, 0, 0, 0, 1};
        user.recipes = new int[] {};
        user.restaurants = new int[] {};

        recipeReccomendation = GetComponent<RecipeReccomendation>();
        restaurantRecommendation = GetComponent<RestaurantRecommendation>();

        // Subscribe to switch event
        Switch.onModeChanged += Switch_onModeChanged;
    }

    private void Start() {
        lookingForRecipes = Switch.Instance.GetisRecipeSelected();
        Debug.Log("looking for bithcse: " + lookingForRecipes);
        if(lookingForRecipes)
        {
            // Asign first two recipes
            string index = recipeReccomendation.ChooseBestRecipe(user);
            Recipe recipe = Database.LoadRecipe(index);
            firstRecipe.AssignInfo(GetImage(index), recipe.name, "description");
            //Debug.Log("changing first recipe");

            index = recipeReccomendation.ChooseBestRecipe(user);
            recipe = Database.LoadRecipe(index);
            secondRecipe.AssignInfo(GetImage(index), recipe.name, "description");            
        }
        else
        {
            // Asign first two restaurants
            string index = restaurantRecommendation.ChooseBestRestaurant(user);
            Restaurant restaurant = Database.LoadRestaurant(index);
            firstRecipe.AssignInfo(null, restaurant.name, "description");
            Debug.Log("changing first restaurant");

            index = restaurantRecommendation.ChooseBestRestaurant(user);
            restaurant = Database.LoadRestaurant(index);
            secondRecipe.AssignInfo(null, restaurant.name, "description");    
        }
    }

    private void Switch_onModeChanged()
    {
        lookingForRecipes = !lookingForRecipes;
        Debug.Log("changing mode. Looking for recipes: " + lookingForRecipes);

        // destroy current displayed info 
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // Assign new 
    }

    void InstantiateItem()
    {
        if(lookingForRecipes)
        {
            setRecipe();
        }
        else    // looking for restaurants
        {
            setRestaurant(infoContainerPrefabZoom);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount < 2)
        {
            InstantiateItem();
        }
    }

    private Sprite GetImage(string index)
    {
        //Debug.Log("loading image: " + "RecipeImages/" + index.PadLeft(2, '0') + "_foodpicture");
        return Resources.Load<Sprite>("RecipeImages/" + index.PadLeft(2, '0') + "_foodpicture");
    }

    private void setRecipe()
    {
        // Get recipe index
        string index = recipeReccomendation.ChooseBestRecipe(user);

        // Get recipe information
        Recipe recipe = Database.LoadRecipe(index);

        // Get image
        Sprite image = GetImage(index);

        // Assign to UI element
        GameObject newItem = Instantiate(infoContainerPrefabZoom, transform, false);
        newItem.gameObject.GetComponent<MainInfoContainerView>().AssignInfo(image, recipe.name, "description");
        newItem.transform.SetAsFirstSibling();  
    }

    private void setRestaurant(GameObject infoContainerPrefab)
    {
        Debug.Log("looking for restaurants...");
        // Get recipe index
        string index = restaurantRecommendation.ChooseBestRestaurant(user);

        // Get recipe information
        Restaurant restaurant = Database.LoadRestaurant(index);

        // Get image
        Sprite image = null;//GetImage(index);

        // Assign to UI element
        GameObject newItem = Instantiate(infoContainerPrefab, transform, false);
        newItem.gameObject.GetComponent<MainInfoContainerView>().AssignInfo(image, restaurant.name, "description");
        newItem.transform.SetAsFirstSibling();  
    }
}
