using UnityEngine;
using TMPro;

public class MessageView : MonoBehaviour
{
    [SerializeField] private TMP_Text messageText;

    public void ShowMessage(string message)
    {
        messageText.text = message;
    }

    public void Clear()
    {
        messageText.text = "";
    }
}