using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {


        Database.database.Listen(InstantiateMessage, Debug.Log);
    }

    void InstantiateMessage(Message message)
    {
        Debug.Log(message.message);
    }
}
