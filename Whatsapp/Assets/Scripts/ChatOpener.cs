using UnityEngine;
using UnityEngine.UI;

public class ChatOpener : InteractionController
{
    [SerializeField] RectTransform _mainPanel, _chatsPanel,_canvas;
    private Button _button;
    private float _cornerPosition;


    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(MovePanelsOnClick);

        _cornerPosition = _canvas.rect.width / 2 + _chatsPanel.rect.width / 2;

        _chatsPanel.anchoredPosition = new Vector2(_cornerPosition, 0);
    }

    private void MovePanelsOnClick()
    {
        if (_mainPanel.anchoredPosition == Vector2.zero || _mainPanel.anchoredPosition == new Vector2(-_cornerPosition, 0))
        {
            StartCoroutine(MoveObjectInUI(_chatsPanel, Screen.width * 2.5f, new Vector3(_chatsPanel.anchoredPosition.x == _cornerPosition ? 0: _cornerPosition, 0)));
            StartCoroutine(MoveObjectInUI(_mainPanel, Screen.width * 2.5f, new Vector3(_mainPanel.anchoredPosition.x == 0 ? -_cornerPosition : 0, 0)));

        }
    }
}
