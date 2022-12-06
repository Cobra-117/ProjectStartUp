using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButton : MonoBehaviour
{
    [SerializeField] private GameObject selectedDot;

    private void Awake() {
        selectedDot = gameObject.transform.Find("selected dot").gameObject;
    }

    public void setSelected(bool isSelected)
    {
        selectedDot.SetActive(isSelected);
    }
}
