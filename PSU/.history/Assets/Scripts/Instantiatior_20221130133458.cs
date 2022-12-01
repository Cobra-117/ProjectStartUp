using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiatior : MonoBehaviour
{

    public GameObject infoContainerPrefab;
    private RecipeReccomendation recipeReccomendation;

    
    void InstantiateItem()
    {
        // Create user
        User user = new User();
        user.tags = new int[] {5, 2, 0, 3, 0, 0, 0, 0, 1};
        user.recipes = new int[] {};

        // Get recipe index
        recipeReccomendation = GetComponent<RecipeReccomendation>();
        string index = recipeReccomendation.ChooseBestRecipe(user);

        GameObject newItem = Instantiate(infoContainerPrefab, transform, false);
        newItem.gameObject.GetComponent<MainInfoContainerView>().AssignInfo(null, "name lol", "descriptionaaaaaaaaaaaaaaaaaaaaaaaa");
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
