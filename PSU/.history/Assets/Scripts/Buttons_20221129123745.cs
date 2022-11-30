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

    public void closeWindow(GameObject previousWindow)
    {
        this.transform.parent.gameObject.SetActive(false);
    }

    public void openCreateRoomWindow(GameObject createRoomWindow)
    {
        createRoomWindow.SetActive(true);
    }

    public open
    
}
