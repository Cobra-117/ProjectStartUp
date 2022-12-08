using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiatior : MonoBehaviour
{   // I know it's "Instantiator" (not "Instantiatior") but I realised the typo too late TnT

    public GameObject infoContainerPrefabZoom;
    public GameObject infoContainerPrefabSwipe;
    private RecipeReccomendation recipeReccomendation;
    private RestaurantRecommendation restaurantRecommendation;
    private User user;
    [SerializeField] MainInfoContainerView firstRecipe;
    [SerializeField] MainInfoContainerView secondRecipe;
    private bool lookingForRecipes;

    public static string currentRestaurantIndex {get; private set;}
    public static string nextRestaurantIndex {get; private set;}
    public static string currentRecipeIndex {get; private set;}
    public static string nextRecipeIndex {get; private set;}


    private void Awake() {
        /*/ Create user
        user = new User();
        user.recipesTags = new int[] {5, 2, 0, 3, 0, 0, 0, 0, 1};
        user.restaurantsTags = new int[] {5, 2, 0, 3, 0, 0, 0, 0, 1};
        user.recipes = new int[] {};
        user.restaurants = new int[] {};*/

        recipeReccomendation = GetComponent<RecipeReccomendation>();
        restaurantRecommendation = GetComponent<RestaurantRecommendation>();

        // Subscribe to switch event
        Switch.onModeChanged += Switch_onModeChanged;
    }

    private void Start() {
        lookingForRecipes = Switch.Instance.GetIsRecipeSelected();
        if(lookingForRecipes)
        {
            // Asign first two recipes
            string index = recipeReccomendation.ChooseBestRecipe(Database.LoadUser());
            Recipe recipe = Database.LoadRecipe(index);
            firstRecipe.AssignInfo(GetRecipeImage(index), recipe.name, "description");
            Debug.Log("setting current recipe index: " + index);
            currentRecipeIndex = index;

            index = recipeReccomendation.ChooseBestRecipe(Database.LoadUser());
            recipe = Database.LoadRecipe(index);
            secondRecipe.AssignInfo(GetRecipeImage(index), recipe.name, "description"); 
            Debug.Log("setting next recipe index: " + index); 
            nextRecipeIndex = index;          
        }
        else
        {
            // Asign first two restaurants
            string index = restaurantRecommendation.ChooseBestRestaurant(Database.LoadUser());
            Restaurant restaurant = Database.LoadRestaurant(index);
            firstRecipe.AssignInfo(GetRestaurantImage(index), restaurant.name, "description");
            Debug.Log("setting current restaurant index: " + index);
            currentRestaurantIndex = index;


            index = restaurantRecommendation.ChooseBestRestaurant(Database.LoadUser());
            restaurant = Database.LoadRestaurant(index);
            secondRecipe.AssignInfo(GetRestaurantImage(index), restaurant.name, "description");  
            Debug.Log("setting next restaurant index: " + index);
            nextRestaurantIndex = index;  
        }
    }

    private void Switch_onModeChanged()
    {
        lookingForRecipes = !lookingForRecipes;
        //Debug.Log("changing mode. Looking for recipes: " + lookingForRecipes);

        // destroy current displayed info 
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // Assign new two 
        if(lookingForRecipes)
        {
            setRecipe(infoContainerPrefabSwipe);
        }
        else    // looking for restaurants
        {
            setRestaurant(infoContainerPrefabSwipe);
        }
    }

    void InstantiateItem()
    {
        if(lookingForRecipes)
        {
            setRecipe(infoContainerPrefabZoom);
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

    private Sprite GetRecipeImage(string index)
    {
        //Debug.Log("loading image: " + "RecipeImages/" + index.PadLeft(2, '0') + "_foodpicture");
        return Resources.Load<Sprite>("RecipeImages/" + index.PadLeft(2, '0') + "_foodpicture");
    }

    private void setRecipe(GameObject infoContainerPrefab)
    {
        // Get recipe index
        Debug.Log("disliked recipes" + DisplayedInfoManager.Instance.dislikedRecipes.ToString());
        string index;
        do
        {
            index = recipeReccomendation.ChooseBestRecipe(Database.LoadUser());
        } while (DisplayedInfoManager.Instance.dislikedRecipes.Contains(index)
            || index == DisplayedInfoManager.Instance.prevRecipeIndex);
    

        // Get recipe information
        Recipe recipe = Database.LoadRecipe(index);

        // Get image
        Sprite image = GetRecipeImage(index);

        // Assign to UI element
        GameObject newItem = Instantiate(infoContainerPrefab, transform, false);
        newItem.gameObject.GetComponent<MainInfoContainerView>().AssignInfo(image, recipe.name, "description");
        newItem.transform.SetAsFirstSibling();  

        // If the main container (swipe prefab) is being instantiated 
        if(infoContainerPrefab == infoContainerPrefabSwipe)
        {
            currentRecipeIndex = index;
            Debug.Log("updating current recipe index: " + index);
            Debug.Log("next recipe index: " + nextRecipeIndex);
        }
        else
        {
            nextRecipeIndex = index;
            Debug.Log("updating next recipe index: " + index);
            Debug.Log("current recipe index: " + currentRecipeIndex);
        }
    }

    private void setRestaurant(GameObject infoContainerPrefab)
    {
        // Get recipe index
        string index;
        do
        {
            index = restaurantRecommendation.ChooseBestRestaurant(Database.LoadUser());
        } while (DisplayedInfoManager.Instance.dislikedRestaurants.Contains(index) 
            || index == DisplayedInfoManager.Instance.prevRestaurantIndex);
        
        // Get recipe information
        Restaurant restaurant = Database.LoadRestaurant(index);

        // Get image
        Sprite image = GetRestaurantImage(index);

        // Assign to UI element
        GameObject newItem = Instantiate(infoContainerPrefab, transform, false);
        newItem.gameObject.GetComponent<MainInfoContainerView>().AssignInfo(image, restaurant.name, "description");
        newItem.transform.SetAsFirstSibling();  

        // If the main container (swipe prefab) is being instantiated 
        if(infoContainerPrefab == infoContainerPrefabSwipe)
        {
            currentRestaurantIndex = index;
            Debug.Log("updating current restaurant index: " + index);
        }
        else
        {
            nextRestaurantIndex = index;
            Debug.Log("updating next restaurant index: " + index);
        }
    }

    private Sprite GetRestaurantImage(string index)
    {
        // This doesn't work properly for now because the indexes are a mess (it starts at 1 in the Excel but at 0 in the json files)
        string fixedIndex = (Int32.Parse(index) + 1).ToString();
        return Resources.Load<Sprite>("RestaurantImages/" + index.PadLeft(2, '0') + "_restaurant");
    }

    public static void setRecipeIndex(string index)
    {
        currentRecipeIndex = index;
    }

    public static void setRestaurantIndex(string index)
    {
        currentRestaurantIndex = index;
    }

    public void showNewRestaurant(string index)
    {
        Restaurant restaurant = Database.LoadRestaurant(index);

        GameObject.
    }
}
