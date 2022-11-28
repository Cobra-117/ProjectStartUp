using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


public class RecipeReccomendation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        User user = new User();
        user.tags = new int[] {5, 0, 0, 1};
        user.recipes = new int[] {};
        UnityEngine.Random.InitState((int)DateTime.Now.Ticks);
        string recipe =  ChooseBestRecipe(user);
        Debug.Log("returned recipe: " + recipe);
    }


    string ChooseBestRecipe(User user)
    {
        
        int[] availableIndex;


        //For V1: store all recipes from the tag the user likes the most
        int clusterIndex = findBestCluster(user);
        string[] availableRecipes = Database.getRecipesFromCluster(clusterIndex);

        //Pick all available recipes (exclude non wanted dishes)
        //Exclude all the already showed recipes
        List<string>  relevantRecipes = sortRecipes(availableRecipes, user);
        //For the V1: Pick a random one from the tag the user like the most
        for (int i  = 0; i < relevantRecipes.Count; i++) {
            Debug.Log("relevant recipe contains: " + relevantRecipes[i]);
        }
        string res = relevantRecipes[UnityEngine.Random.Range(0, relevantRecipes.Count)];
        //update player
        return res;
    }

    int findBestCluster(User user)
    {
        int bestCluster = -1;
        int besClusterValue = -1;

        for (int i  = 0; i < user.tags.Length; i ++) {
            if (user.tags[i] > besClusterValue) {
                bestCluster = i;
                besClusterValue = user.tags[i];
            }
        }
        Debug.Log("best cluster" + bestCluster.ToString() + "value:" +
        besClusterValue.ToString());
        return bestCluster;
    }

    List<string> sortRecipes(string[] recipes, User user)
    {
        List<string> keptRecipes = new List<string>();

        for (int i = 0; i < recipes.Length; i++) {
            Recipe curRecipe = Database.LoadRecipe(recipes[i]);
            if (isRecipeSuitableForUser(user, curRecipe)) {
                keptRecipes.Add(curRecipe.index.ToString());
                Debug.Log("adding " + curRecipe.name);
            }
            //else if (u)
        }
         for (int i  = 0; i < keptRecipes.Count; i++) {
            Debug.Log("kept recipe contains: " + keptRecipes[i]);
        }
        return keptRecipes;
    }

    bool isRecipeSuitableForUser(User user, Recipe recipe)
    {
        if (user.isVegan && !recipe.isVegan)
            return false;
        if (user.isVegetarian && !recipe.isVegetarian)
            return false;
        for (int i = 0; i < user.recipes.Length; i++ ) {
            if (user.recipes[i] == recipe.index)
                return false;
        }
        return true;
    }
}
