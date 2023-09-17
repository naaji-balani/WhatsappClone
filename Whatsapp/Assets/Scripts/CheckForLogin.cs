using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForLogin : MonoBehaviour
{
    [SerializeField] GameObject _loginPanel;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Name") && PlayerPrefs.HasKey("Number")) return;

        _loginPanel.SetActive(true);
    }
}
