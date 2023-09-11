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
        if (_mainPanel.anchoredPosition == Vector2.zero || _mainPanel.anchoredPosition == new Vector2(-1300, 0))
        {
            StartCoroutine(MoveObjectInUI(_chatsPanel, 4000, new Vector3(_chatsPanel.anchoredPosition.x == 1300 ? 0: 1300, 0)));
            StartCoroutine(MoveObjectInUI(_mainPanel, 4000, new Vector3(_mainPanel.anchoredPosition.x == 0 ? -1300 : 0, 0)));
        }
    }
}
