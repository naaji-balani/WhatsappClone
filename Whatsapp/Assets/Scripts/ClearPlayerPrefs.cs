using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearPlayerPrefs : MonoBehaviour
{
    Button _button;
    [SerializeField] GameObject _loginPage;

    private void Start()
    {

        _button = GetComponent<Button>();

        _button.onClick.AddListener(DeletePlayerPrefs);
    }

    private void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        _loginPage.SetActive(true);

    }
}
