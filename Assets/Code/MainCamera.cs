using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    protected Transform myTransform;

    //Fields used to move Camera

    [SerializeField] private float timeToMoveCamera;
    private bool moveCamera = false;
    private Vector2 CameraFrom;
    private Vector2 CameraTo;
    private float cameraXMovementProgress;
    private float cameraYMovementProgress;
    private float cameraMoveProgress;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveCamera)
        {
            if(cameraMoveProgress >= timeToMoveCamera)
            {
                moveCamera = false;
            }
            else
            {
                cameraMoveProgress += Time.deltaTime;
                cameraXMovementProgress = cameraMoveProgress * (CameraFrom.x - CameraTo.x) / timeToMoveCamera;
                cameraYMovementProgress = cameraMoveProgress * (CameraFrom.y - CameraTo.y) / timeToMoveCamera;
                myTransform.position = new Vector3(CameraFrom.x - cameraXMovementProgress, CameraFrom.y - cameraYMovementProgress, myTransform.position.z);
            }
        }
    }

    //Only for 2D
    void CameraSmoothMove2D(Vector2 CFrom, Vector2 CTo)
    {
        CameraFrom = CFrom;
        CameraTo = CTo;
        moveCamera = true;
        cameraXMovementProgress = 0;
        cameraYMovementProgress = 0;
        cameraMoveProgress = 0;
    }
}
