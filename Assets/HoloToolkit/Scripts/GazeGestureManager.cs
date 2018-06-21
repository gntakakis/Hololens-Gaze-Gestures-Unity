using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class GazeGestureManager : MonoBehaviour {

    public static GazeGestureManager Instance { get; private set; }

    public GameObject FocusedObject { get; private set; }
    public GestureRecognizer recognizer;
    private bool updateFocusedObject = true;
    
    void Awake()
    {
        Instance = this;
        
        recognizer = new GestureRecognizer();
        recognizer.TappedEvent += (source, tapCount, ray) =>
        {
            if (FocusedObject != null)
            {
                updateFocusedObject = true;
                FocusedObject.SendMessageUpwards("OnSelect");
            }
        };
        recognizer.HoldStartedEvent += (source, ray) =>
        {
            if (FocusedObject != null)
            {
                updateFocusedObject = true;
                FocusedObject.SendMessageUpwards("OnHoldStart");
            }
        };
        recognizer.HoldCompletedEvent += (source, ray) =>
        {
            if (FocusedObject != null)
            {
                updateFocusedObject = true;
                FocusedObject.SendMessageUpwards("OnHoldCompleted");
            }
        };
        recognizer.HoldCanceledEvent += (source, ray) =>
        {
            if (FocusedObject != null)
            {
                updateFocusedObject = true;
                FocusedObject.SendMessageUpwards("OnHoldCompleted");
            }
        };
        recognizer.StartCapturingGestures();
    }

    void Update()
    {
        if (!updateFocusedObject)
        {
            return;
        }

        GameObject oldFocusObject = FocusedObject;
        
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;
        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            FocusedObject = hitInfo.collider.gameObject;
        }
        else
        {
            FocusedObject = null;
        }
        
        if (FocusedObject != oldFocusObject)
        {
            recognizer.CancelGestures();
            recognizer.StartCapturingGestures();
        }
    }
}
