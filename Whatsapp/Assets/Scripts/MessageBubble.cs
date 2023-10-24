using UnityEngine;
using TMPro;

public class MessageBubble : MonoBehaviour
{
    private TMP_Text messageText;
    private RectTransform backgroundRect,messageRect;

    // Set a maximum width for the background.
    private float maxWidth = 700;

    private void Start()
    {
        backgroundRect = GetComponent<RectTransform>();
        messageText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        messageRect = transform.GetChild(0).GetComponent<RectTransform>();

        UpdateTextTransform();
    }

    private void Update()
    {
            UpdateTextTransform();
    }

    void UpdateTextTransform()
    {
        // Get the preferred width and height of the text based on its content and settings.
        float textWidth = messageText.preferredWidth;
        float textHeight = messageText.preferredHeight;

        // Calculate the new width for the background.
        float newWidth = Mathf.Min(100 + textWidth, maxWidth);

        // Update the background's size (width and height).
        backgroundRect.sizeDelta = new Vector2(newWidth, textHeight + 50);
        messageRect.sizeDelta = new Vector2(newWidth - 100, textHeight);
        backgroundRect.anchoredPosition = new Vector2(440 - newWidth / 2, backgroundRect.anchoredPosition.y);
    }
}
