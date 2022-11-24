using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeReccomendation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        User user = new User();
        user.tags = new int[] {5, 0, 0, 1};
        ChooseBestRecipe(user);
    }


    int ChooseBestRecipe(User user)
    {
        
        int[] availableIndex;

        Cluster cluster = new Cluster();

        //For V1: store all recipes from the tag the user likes the most
        int clusterIndex = findBestCluster(user);

        //Pick all available recipes (exclude non wanted tag)
        //Exclude all the already showed recipes
        //For the V1: Pick a random one from the tag the user like the most
        return 0;
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

    string[] getRecipesFromCluster(int clusterIndex)
    {
        string[] recipes = new string [] {};
        return recipes;
    }
}
