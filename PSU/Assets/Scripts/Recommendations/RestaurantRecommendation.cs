using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class RestaurantRecommendation : MonoBehaviour
{
     void Start()
    {
        /*User user = new User();
        user.recipesTags = new int[] {5, 2, 0, 3, 0, 0, 0, 0, 1};
        user.restaurantsTags = new int[] {5, 2, 0, 3, 0, 0, 0, 0, 1};
        user.recipes = new int[] {};
        user.restaurants = new int[] {};
        UnityEngine.Random.InitState((int)DateTime.Now.Ticks);*/

        string restaurant =  ChooseBestRestaurant(Database.LoadUser());
        Debug.Log("returned restaurant: " + restaurant);
        //User test = Database.LoadUser();
        //Database.SaveUser(user);
        //Debug.Log("recipes: " + test.recipes[0].ToString());
    }

    public string ChooseBestRestaurant(User user)
    {
        
        int[] availableIndex;


        //For V1: store all recipes from the tag the user likes the most
        int clusterIndex = ChooseCluster(user);
        getRandomGoodCluster(user);
        string[] availableRecipes = Database.getRestaurantFromCluster(clusterIndex);
        Debug.Log("number of recipes: " + availableRecipes);
        //Pick all available recipes (exclude non wanted dishes)
        //Exclude all the already showed recipes
        List<string>  relevantRecipes = SortRestaurants(availableRecipes, user);
        //For the V1: Pick a random one from the tag the user like the most
        for (int i  = 0; i < relevantRecipes.Count; i++) {
            Debug.Log("relevant recipe contains: " + relevantRecipes[i]);
        }
        string res = relevantRecipes[UnityEngine.Random.Range(0, relevantRecipes.Count)];
        //update player
        user.recipes.Append<int>(int.Parse(res));
        Database.SaveUser(user);
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
                return UnityEngine.Random.Range(0, 4);
            default:
                return UnityEngine.Random.Range(0, 4);
        }
    }

    int findBestCluster(User user)
    {
        int bestCluster = -1;
        int besClusterValue = -1;

        for (int i  = 0; i < user.recipesTags.Length; i ++) {
            if (user.restaurantsTags[i] > besClusterValue) {
                bestCluster = i;
                besClusterValue = user.restaurantsTags[i];
            }
        }
        Debug.Log("best cluster" + bestCluster.ToString() + "value:" +
        besClusterValue.ToString());
        return bestCluster;
    }

    int getRandomGoodCluster(User user)
    {
        int[] clusters = new int[4] {-1, -1, -1, -1};
        int bestCluster = -1;
        int besClusterValue = -1;
        bool alreadySelected = false;

        for (int j = 0; j < 4; j ++) {
            for (int i  = 0; i < user.restaurantsTags.Length; i ++) {
                alreadySelected = false;
                for (int k = 0; k < 4; k++) {
                    if (i == clusters[k]) {
                        alreadySelected = true;
                    }                        
                }
                if (alreadySelected == false && user.restaurantsTags[i] > besClusterValue) {
                    bestCluster = i;
                    besClusterValue = user.restaurantsTags[i];
                }
            }
            clusters[j] = bestCluster;
            bestCluster = -1;
            besClusterValue = -1; 
        }
        return clusters[UnityEngine.Random.Range(0, 4)];
    }

    List<string> SortRestaurants(string[] recipes, User user)
    {
        List<string> keptRecipes = new List<string>();

        for (int i = 0; i < recipes.Length; i++) {
            if (recipes[i] == "-1")
                continue;
            Restaurant curRestaurant = Database.LoadRestaurant(recipes[i]);
            if (curRestaurant.index != -1 && isRecipeSuitableForUser(user, curRestaurant)) {
                keptRecipes.Add(curRestaurant.index.ToString());
                Debug.Log("adding " + curRestaurant.name);
            }
            //else if (u)
        }
        for (int i  = 0; i < keptRecipes.Count; i++) {
            Debug.Log("kept recipe contains: " + keptRecipes[i]);
        }
        return keptRecipes;
    }

    bool isRecipeSuitableForUser(User user, Restaurant restaurant)
    {
        if (user.isVegan && !restaurant.veganOption)
            return false;
        if (user.isVegetarian && !restaurant.vegetarianOption)
            return false;
        for (int i = 0; i < user.restaurants.Length; i++ ) {
            if (user.restaurants[i] == restaurant.index)
                return false;
        }
        return true;
    }
}
