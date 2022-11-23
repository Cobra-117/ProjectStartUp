using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Database : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        test();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void test()
    {
        Recipe test = new Recipe();
        test.index = 0;
        test.isVegan = true;
        test.isVegetarian = true;
        test.name = "test";
        string json = JsonUtility.ToJson(test);
        Debug.Log(json);
        SaveData(json, "save");
        Recipe testLoad = LoadRecipe("save");
        Debug.Log("name : " + testLoad.name);
    }

    public void SaveData(string data, string filename)
    {
        string dir = Application.persistentDataPath + "/" + filename;
        File.WriteAllText(dir, data);
    }

    public Recipe LoadRecipe(string filename)
    {
        string path = Application.persistentDataPath + "/" + filename;
        Recipe recipe = new Recipe();

        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            recipe = JsonUtility.FromJson<Recipe>(json);
        }
        else 
        {
            Debug.LogError("This recipe file do not exist");
        }
        return recipe;
    }
}

//Json, serialized class