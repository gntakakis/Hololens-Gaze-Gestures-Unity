using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalCursor : MonoBehaviour {

    private MeshRenderer meshRenderer;

    void Start ()
    {
        meshRenderer = this.gameObject.GetComponentInChildren<MeshRenderer>();
    }

    void Update()
    {
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;

        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            meshRenderer.enabled = true;

            this.transform.position = hitInfo.point;
            
            this.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);

            //Display 3d text message (cursor over)
            TextMessage.Instance.ChangeTextMessage_CursorOver(Constants.CURSOR_OVER);
        }
        else
        {
            meshRenderer.enabled = false;

            //Display 3d text message (cursor over)
            TextMessage.Instance.ChangeTextMessage_CursorOver(Constants.CLEAR);
            //Display 3d text message (gestures)
            TextMessage.Instance.ChangeTextMessage_Gestures(Constants.CLEAR);
        }
    }
}
