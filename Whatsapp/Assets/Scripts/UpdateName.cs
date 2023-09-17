using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateName : MonoBehaviour
{
    Button button;
    [SerializeField] TextMeshProUGUI _nameText;
    [SerializeField] Image _profileImage;
    string nameInMainPage;
    Sprite _profileImageOnMainPage;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(UpdateData);
        nameInMainPage = transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        _profileImageOnMainPage = transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite;
    }

    private void UpdateData()
    {
        _nameText.text = nameInMainPage;
        _profileImage.sprite = _profileImageOnMainPage;
    }
}
