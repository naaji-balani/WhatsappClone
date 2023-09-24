using Firebase.Firestore;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatHandler : MonoBehaviour
{
    [SerializeField] Transform _chatMessageContent;
    [SerializeField] GameObject _senderMessagePrefab,_recieverMessagePrefab;

    [SerializeField] TMP_InputField _messageInputField;
    [SerializeField] Button _sendMessageButton;

    void Start()
    {
        _sendMessageButton.onClick.AddListener(SendMessage);
        Database.database.Listen(InstantiateMessage, Debug.Log);
    }

    private void SendMessage()
    {
        if (string.IsNullOrEmpty(_messageInputField.text)) return;

        Message message = new Message();
        message.time = Timestamp.GetCurrentTimestamp();
        message.message = _messageInputField.text;
        message.sender = PlayerPrefs.GetString("Number");

        Database.database.PostMessage(message, MessageSentSuccessfully, (exception) => {
            Debug.LogError("Error posting message: " + exception);
        });

        _messageInputField.text = "";
    }

    void MessageSentSuccessfully()
    {
    }

    void InstantiateMessage(Message message)
    {
        var newMessage = Instantiate(message.sender != PlayerPrefs.GetString("Number") ? _senderMessagePrefab : _recieverMessagePrefab, _chatMessageContent);
        newMessage.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = message.message;
    }
}       
