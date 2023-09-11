using Firebase.Firestore;


[FirestoreData]
public class Message
{

    [FirestoreProperty]
    public Timestamp time { get; set; }

    [FirestoreProperty]
    public string user { get; set; }

    [FirestoreProperty]
    public string message { get; set; }

}
