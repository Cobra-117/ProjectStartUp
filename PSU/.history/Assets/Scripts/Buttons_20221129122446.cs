using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void goToScene(int scene)
    {
        SceneManager.LoadScene(scene);
        Debug.Log("changing scene: " + scene);
    }

    public void closeWindow(GameObject recipesRestaurants)
    {
        
    }
    
}
