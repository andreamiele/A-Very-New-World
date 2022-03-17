using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{

    public float panSpeed = 2f;
    public float panBorderThickness = 1f;
    public Vector2 panLimit;
    public float scrollSpeed = 20f;
    private void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("up") || Input.mousePosition.y >=Screen.height-panBorderThickness)
        {
            pos.y += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("down") || Input.mousePosition.y <= panBorderThickness)
        {
            pos.y -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("right") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("left") || Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.z += scroll * scrollSpeed *50f* Time.deltaTime;
        //pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        //pos.y = Mathf.Clamp(pos.y, -panLimit.y, panLimit.y);

        transform.position = pos;
    }

}
