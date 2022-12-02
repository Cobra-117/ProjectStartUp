using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiatior : MonoBehaviour
{

    public GameObject infoContainerPrefab;
    private RecipeReccomendation recipeReccomendation;
    private User user;
    [SerializeField] MainInfoContainerView firstRecipe;
    [SerializeField] MainInfoContainerView secondRecipe;


    private void Awake() {
        // Create user
        user = new User();
        user.tags = new int[] {5, 2, 0, 3, 0, 0, 0, 0, 1};
        user.recipes = new int[] {};

        // Asign first two recipes
        string index = recipeReccomendation.ChooseBestRecipe(user);
        Recipe recipe = Database.LoadRecipe(index);
        firstRecipe.AssignInfo(null, recipe.name, "descriptino lol");
        

        index = recipeReccomendation.ChooseBestRecipe(user);
        recipe = Database.LoadRecipe(index);
        secondRecipe.AssignInfo(null, recipe.name, "descriptino2222 lol");
    }
    
    void InstantiateItem()
    {
        // Get recipe index
        recipeReccomendation = GetComponent<RecipeReccomendation>();
        string index = recipeReccomendation.ChooseBestRecipe(user);

        // Get recipe information
        Recipe recipe = Database.LoadRecipe(index);

        // Assign to UI element
        GameObject newItem = Instantiate(infoContainerPrefab, transform, false);
        newItem.gameObject.GetComponent<MainInfoContainerView>().AssignInfo(null, recipe.name, "descriptionaaaaaaaaaaaaaaaaaaaaaaaa");
        newItem.transform.SetAsFirstSibling();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount < 2)
        {
            InstantiateItem();
        }
    }
}
