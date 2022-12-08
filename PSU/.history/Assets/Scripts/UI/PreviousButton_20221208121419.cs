using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviousButton : MonoBehaviour
{
    public void showPrevious()
    {
        Debug.Log("showing previous item");
        if(Switch.Instance.GetIsRecipeSelected())
        {
            string index = DisplayedInfoManager.Instance.prevRecipeIndex
            Instantiatior.Instance.showNewRecipeOrRestaurant();
        }
        else
        {
            Instantiatior.Instance.showNewRecipeOrRestaurant(DisplayedInfoManager.Instance.prevRestaurantIndex);
        }
        
    }
}
