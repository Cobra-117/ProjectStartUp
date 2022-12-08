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
            string index = DisplayedInfoManager.Instance.prevRecipeIndex;
            if(index != null)
            {
                Instantiatior.Instance.showNewRecipeOrRestaurant(index);
            }
        }
        else
        {
            string index = DisplayedInfoManager.Instance.prevRestaurantIndex;
            if(index != null)
            {

            }
            
        }
        
    }
}
