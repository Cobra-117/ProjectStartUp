using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButton : MonoBehaviour
{
    [SerializeField] private GameObject selectedDot;

    private void Awake() {
        selectedDot = gameObject.transform.Find("selected dot").gameObject;
        Debug.Log("selected dot assigned: " + selectedDot)
    }

    public void setSelected(bool isSelected)
    {
        selectedDot.SetActive(isSelected);
    }
}
