using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButtons : MonoBehaviour
{
    private GameObject selectedDot;



    public void setSelected(bool isSelected)
    {
        selectedDot.SetActive(isSelected);
    }
}
