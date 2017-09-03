using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGestures : MonoBehaviour {

    private bool holding = false;

    void OnSelect()
    {
        TextMessage.Instance.ChangeTextMessage_Gestures(Constants.TAP);
    }

    void OnHoldStart()
    {
        holding = true;
        TextMessage.Instance.ChangeTextMessage_Gestures(Constants.HOLD_START);
    }

    void OnHoldCompleted()
    {
        TextMessage.Instance.ChangeTextMessage_Gestures(Constants.HOLD_COMPLETED);
        holding = false;
    }

}
