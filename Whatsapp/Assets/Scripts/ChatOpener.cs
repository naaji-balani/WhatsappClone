using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatOpener : InteractionController
{
    private Button _button;
    [SerializeField] RectTransform _mainPanel, _chatsPanel;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(MovePanelsOnClick);
    }

    private void MovePanelsOnClick()
    {
        if (_mainPanel.anchoredPosition == Vector2.zero || _mainPanel.anchoredPosition == new Vector2(-1000, 0))
        {
            StartCoroutine(MoveObjectInUI(_chatsPanel, 3000, new Vector3(_chatsPanel.anchoredPosition.x == 0 ? 1000 : 0, 0)));
            StartCoroutine(MoveObjectInUI(_mainPanel, 3000, new Vector3(_mainPanel.anchoredPosition.x == 0 ? -1000 : 0, 0)));
        }

        
    }
}
