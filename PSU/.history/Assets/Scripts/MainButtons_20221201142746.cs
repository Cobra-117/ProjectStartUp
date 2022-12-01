using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButtons : MonoBehaviour
{
    [SerializeField] private GameObject selectedDot;

    [System.Obsolete]
    public void setSelected(bool isSelected)
    {
        selectedDot.active = isSelected;
    }
}
