using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButtons : MonoBehaviour
{
    [SerializeField] private GameObject selectedDot;

    public void setSelected(bool isSelected)
    {
        selectedDot.active = isSelected;
    }
}
