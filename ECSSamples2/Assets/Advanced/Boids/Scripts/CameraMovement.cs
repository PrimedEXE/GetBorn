using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float movementSpeed = 12f;

    public float fastSpeed = 60f;

    public float freeLookSens = 2.5f;

    public float zoomSens = 10f;

    public float fastZoomSens = 50f;

    private bool looking = false;

    void Update()
    {
        var fastMode = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        var movementSpeed = fastMode ? this.fastSpeed : this.movementSpeed;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) // Moving the camera left
        {
            transform.position = transform.position + (-transform.right * movementSpeed * Time.deltaTime);  
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) // Moving the camera right
        {
            transform.position = transform.position + (transform.right * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) // Moving the camera forward
        {
            transform.position = transform.position + (transform.forward * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) // Moving the camera back
        {
            transform.position = transform.position + (-transform.forward * movementSpeed * Time.deltaTime);
        }

        // Up and down Movement
        if (Input.GetKey(KeyCode.E)) // Moving the camera down
        {
            transform.position = transform.position + (-transform.up * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q)) // Moving the camera up
        {
            transform.position = transform.position + (transform.up * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.R))
        {
            transform.position = transform.position + (Vector3.up * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.F))
        {
            transform.position = transform.position + (-Vector3.up * movementSpeed * Time.deltaTime);
        }

        //Looking
        if (looking)
        {
            float nRotX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * freeLookSens;
            float nRotY = transform.localEulerAngles.x + Input.GetAxis("Mouse Y") * freeLookSens;
            transform.localEulerAngles = new Vector3(nRotY, nRotX, 0f);
        }

        float axis = Input.GetAxis("Mouse ScrollWheel");
        if(axis != 0)
        {
            var zoomSensL = fastMode ? this.fastZoomSens : this.zoomSens;
            transform.position = transform.position + transform.forward * axis * zoomSensL;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            StartLooking();
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            StopLooking();
        }

    }

    public void StartLooking()
    {
        looking = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void StopLooking()
    {
        looking = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
    }

    void OnDisable() // &*%$ found out to use this else it won't work
    {
        StopLooking();
    }

}
