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
        user.tags = new int[] {5, 2, 0, 3, 0, 0, 0, 0, 1};
        user.recipes = new int[] {};
        UnityEngine.Random.InitState((int)DateTime.Now.Ticks);
        //string recipe =  ChooseBestRecipe(user);
        //Debug.Log("returned recipe: " + recipe);
        User test = Database.LoadUser();
        Database.SaveUser(user);
        Debug.Log("recipes: " + test.recipes[0].ToString());
    }


    public string ChooseBestRecipe(User user)
    {
        
        int[] availableIndex;


        //For V1: store all recipes from the tag the user likes the most
        int clusterIndex = ChooseCluster(user);
        getRandomGoodCluster(user);
        string[] availableRecipes = Database.getRecipesFromCluster(clusterIndex);
        Debug.Log("number of recipes: " + availableRecipes);
        //Pick all available recipes (exclude non wanted dishes)
        //Exclude all the already showed recipes
        List<string>  relevantRecipes = sortRecipes(availableRecipes, user);
        //For the V1: Pick a random one from the tag the user like the most
        for (int i  = 0; i < relevantRecipes.Count; i++) {
            Debug.Log("relevant recipe contains: " + relevantRecipes[i]);
        }
        string res = relevantRecipes[UnityEngine.Random.Range(0, relevantRecipes.Count)];
        //update player
        user.recipes.Append<int>(int.Parse(res));
        return res;
    }

    int ChooseCluster(User user)
    {
        int rand = UnityEngine.Random.Range(0, 4);

        switch (rand)
        {
            case 0:
                return findBestCluster(user);
            case 1:
                return getRandomGoodCluster(user);
            case 2:
                return getRandomGoodCluster(user);
            case 3:
                return UnityEngine.Random.Range(0, 6);
            default:
                return UnityEngine.Random.Range(0, 6);
        }
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

    int getRandomGoodCluster(User user)
    {
        int[] clusters = new int[5] {-1, -1, -1, -1, -1};
        int bestCluster = -1;
        int besClusterValue = -1;
        bool alreadySelected = false;

        for (int j = 0; j < 5; j ++) {
            for (int i  = 0; i < user.tags.Length; i ++) {
                alreadySelected = false;
                for (int k = 0; k < 5; k++) {
                    if (i == clusters[k]) {
                        alreadySelected = true;
                    }                        
                }
                if (alreadySelected == false && user.tags[i] > besClusterValue) {
                    bestCluster = i;
                    besClusterValue = user.tags[i];
                }
            }
            clusters[j] = bestCluster;
            bestCluster = -1;
            besClusterValue = -1; 
        }
        return clusters[UnityEngine.Random.Range(0, 5)];
    }

    List<string> sortRecipes(string[] recipes, User user)
    {
        List<string> keptRecipes = new List<string>();

        for (int i = 0; i < recipes.Length; i++) {
            if (recipes[i] == "-1")
                continue;
            Recipe curRecipe = Database.LoadRecipe(recipes[i]);
            if (curRecipe.index != -1 && isRecipeSuitableForUser(user, curRecipe)) {
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
