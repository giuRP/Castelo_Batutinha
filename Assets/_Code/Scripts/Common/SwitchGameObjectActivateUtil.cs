using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGameObjectActivateUtil : MonoBehaviour
{
    public void SwitchEnable()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }
}
