using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class NameAndProfileUpdater : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _nameText;
    private Button button;


    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
    }

}
