using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager : InteractionController
{
    RectTransform _rect;
    float _bottomPos;
    [SerializeField] Button _createButton;
    [SerializeField] TMP_InputField _nameField, _numberField;

    private void Start()
    {
        _rect = GetComponent<RectTransform>();
        _bottomPos =  _rect.rect.height / 2;
        _rect.anchoredPosition = new Vector2(0, -_bottomPos);

        StartCoroutine(MoveObjectInUI(_rect, 1500, new Vector2(0, _bottomPos)));

        _createButton.onClick.AddListener(CreateButton);
    }

    private void CreateButton()
    {
        if (string.IsNullOrEmpty(_nameField.text) || string.IsNullOrWhiteSpace(_nameField.text) || string.IsNullOrEmpty(_numberField.text) || string.IsNullOrWhiteSpace(_numberField.text)) return;

        PlayerPrefs.SetString("Name", _nameField.text);
        PlayerPrefs.SetString("Number", _numberField.text);

        StartCoroutine(MoveObjectInUI(_rect, 1500, new Vector2(0, -_bottomPos)));

        Invoke("DisablePanel", .5f);
    }

    private void DisablePanel() => transform.parent.gameObject.SetActive(false);
}
