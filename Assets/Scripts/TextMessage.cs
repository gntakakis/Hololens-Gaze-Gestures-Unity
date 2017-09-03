using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMessage : MonoBehaviour {

    public static TextMessage Instance { get; private set; }

    public GameObject textMessageCursorOverGmObj;
    public GameObject textMessageGesturesGmObj;

    void Awake()
    {
        Instance = this;
    }

    public void ChangeTextMessage_CursorOver(string textMessage)
    {
        textMessageCursorOverGmObj.GetComponent<TextMesh>().text = textMessage; 
    }
    public void ChangeTextMessage_Gestures(string textMessage)
    {
        textMessageGesturesGmObj.GetComponent<TextMesh>().text = textMessage;
    }
}
