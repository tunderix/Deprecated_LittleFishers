using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{

    public float speed;
    float maxScreenWidth = Screen.width - 5;
    float maxScreenHeight = Screen.height - 5;

    public int cameraActivationBorders = 5;

    public bool cameraIsStill = false;

    public float numberOfPixlesToMove = 1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            toggleCameraMovement();
        }
    }

    void LateUpdate()
    {

        if (!cameraIsStill)
        {
            moveCameraOnXZ();
        }

    }

    private void moveCameraOnXZ()
    {

        Vector3 movement = Vector3.zero;
        bool cameraMoving = false;

        if (Input.mousePosition.x <= cameraActivationBorders)
        { //moves screen to the left
            movement.x = movement.x - numberOfPixlesToMove;
            cameraMoving = true;
        }
        else if (Input.mousePosition.x >= maxScreenWidth - cameraActivationBorders)
        { // moves screen to the right
            movement.x = movement.x + numberOfPixlesToMove;
            cameraMoving = true;
        }

        if (Input.mousePosition.y <= cameraActivationBorders)
        {// moves screen up
            movement.y = movement.z - numberOfPixlesToMove;
            cameraMoving = true;
        }
        else if (Input.mousePosition.y >= maxScreenHeight - cameraActivationBorders)
        {// moves screen down
            movement.y = movement.z + numberOfPixlesToMove;
            cameraMoving = true;
        }


        if (!cameraMoving)
        {
            movement.x = 0;
            movement.z = 0;
            movement.y = 0;
        }

        transform.Translate(movement * speed * Time.deltaTime, Space.Self);
    }

    public void setCamPosition(Vector3 rPosition)
    {
        transform.position = rPosition;
    }

    public void setCameraStill(bool state)
    {
        this.cameraIsStill = state;
        Debug.Log("Camera toggled" + cameraIsStill);
    }

    public void toggleCameraMovement()
    {
        setCameraStill(!this.cameraIsStill);
    }
}
