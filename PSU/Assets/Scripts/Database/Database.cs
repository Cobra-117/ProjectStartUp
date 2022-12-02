using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Database : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //test();
    }

    void test()
    {
        Recipe test = new Recipe();
        test.index = 0;
        test.isVegan = true;
        test.isVegetarian = true;
        test.name = "test";
        test.tags = new string [] {"test1", "test2"};
        string json = JsonUtility.ToJson(test);
        Debug.Log(json);
        Recipe testLoad = LoadRecipe("1");
        Debug.Log("name : " + testLoad.name);
        Debug.Log("name : " + testLoad.tags[0]);
        Debug.Log("recipe name : " + testLoad.name);
    }

    /*Do not use for now*/
    public void SaveRecipe(string data, string filename)
    {
        string dir = Application.persistentDataPath + "/recipes/recipes/" + filename;
        File.WriteAllText(dir, data);
    }

    /*Load a recipe from a json file 
    filename : the name of the database file, without .json*/
    public static Recipe LoadRecipe(string filename)
    {
        string path = Application.dataPath + "database/recipes/recipes/" + filename;
        Recipe recipe = new Recipe();
        Debug.Log("loading recipe n° " + filename);
        string json = Resources.Load<TextAsset>(
            "Databases/Recipes/Recipes/"  + filename).text;
        recipe = JsonUtility.FromJson<Recipe>(json);
      
        return recipe;
    }

    /*Load a recipe from a json file 
    filename : the name of the database file, without .json*/
    public static Restaurant LoadRestaurant(string filename)
    {
        string path = Application.dataPath + "database/recipes/recipes/" + filename;
        Restaurant restaurant = new Restaurant();
        Debug.Log("loading recipe n° " + filename);
        string json = Resources.Load<TextAsset>(
            "Databases/Recipes/Recipes/"  + filename).text;
        restaurant = JsonUtility.FromJson<Restaurant>(json);
      
        return restaurant;
    }

    /*Get the recipes that are inside a cluster*/
    public static string[] getRecipesFromCluster(int clusterIndex)
    {
        Cluster cluster = new Cluster();
        return JsonUtility.FromJson<Cluster>(Resources.Load<TextAsset>(
        "Databases/Recipes/Cluster/"+ clusterIndex.ToString()).text).recipes;
    }

    /*Get the recipes that are inside a cluster*/
    public static string[] getRestaurantFromCluster(int clusterIndex)
    {
        RestaurantCluster cluster = new RestaurantCluster();
        Debug.Log("loading cluster " + clusterIndex.ToString());
        return JsonUtility.FromJson<RestaurantCluster>(Resources.Load<TextAsset>(
        "Databases/Restaurants/Cluster/"+ clusterIndex.ToString()).text).restaurant;
    }

    /*Load the local user*/
    public static User LoadUser()
    {
        User user = new User();
        string dir = Application.persistentDataPath + "/user.json";
        if (!System.IO.File.Exists(dir))
            return null;
        string text = System.IO.File.ReadAllText(dir);
        Debug.Log("text : " + text);
        return JsonUtility.FromJson<User>(text);
    }

    /*Save the local user*/
    public static void SaveUser(User user)
    {
        string dir = Application.persistentDataPath + "/user.json";
        string json = JsonUtility.ToJson(user);
        System.IO.File.WriteAllText(dir, json);
    }
}
