using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButtons : MonoBehaviour
{
    private GameObject selectedDot;

    private void Awake() {
        selectedDot = gameObject.transform.Find("select dot").gameObject;
    }

    public void setSelected(bool isSelected)
    {
        selectedDot.SetActive(isSelected);
    }
}
