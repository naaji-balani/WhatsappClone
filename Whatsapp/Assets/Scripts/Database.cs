using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
using System;

public class Database : MonoBehaviour
{
    public static Database database;
    FirebaseFirestore db;
    Message message = new Message();

    private void Awake()
    {
        if (database == null) database = this;
    }

    void Start()
    {
        db = FirebaseFirestore.DefaultInstance;       
    }

    public void PostMessage(Message message, Action callback, Action<AggregateException> fallback)
    {
        db.Collection("Messages").Document().SetAsync(message).ContinueWith(task =>
        {
            if (task.IsFaulted || task.IsCanceled)
            {
                fallback(task.Exception);
            }
            else
            {
                callback();
            }
        });
    }


    public void Listen(Action<Message> callback,Action<AggregateException> fallback)
    {
        Query query = db.Collection("Messages").OrderBy("time");

        ListenerRegistration listener = query.Listen(snapshot =>
        {
            foreach (DocumentChange change in snapshot.GetChanges())
            {
                if (change.ChangeType == DocumentChange.Type.Added)
                {
                    message = change.Document.ConvertTo<Message>();
                    string messageSender = change.Document.GetValue<string>("sender");

                    message.sender = messageSender;
                    callback(message);
                }
                else if (change.ChangeType == DocumentChange.Type.Modified)
                {
                    Debug.Log(string.Format("Modified Message : {0}", change.Document.Id));
                }
                else if (change.ChangeType == DocumentChange.Type.Removed)
                {
                    Debug.Log(string.Format("Removed Message : {0}", change.Document.Id));
                }
            }
        });
    }
}
