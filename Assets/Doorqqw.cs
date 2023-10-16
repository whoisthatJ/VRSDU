using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorqqw : MonoBehaviour
{
    public float doorOpenAngle = 90.0f; //The angle the door opens in degrees
    public float doorCloseAngle = 0.0f; //The angle the door closes in degrees
    public float smooth = 2.0f; //How smoothly the door opens/closes

    private bool open = false; //Whether or not the door is currently open
    private Vector3 defaultRotation; //The default rotation of the door

    void Start()
    {
        defaultRotation = transform.localEulerAngles; //Set the default rotation to the current local rotation
        doorOpenAngle += defaultRotation.y; //Adjust the door open angle to the installed angle
        doorCloseAngle += defaultRotation.y; //Adjust the door close angle to the installed angle
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (open) //If the door is open, close it
            {
                Quaternion targetRotation = Quaternion.Euler(defaultRotation.x, doorCloseAngle, defaultRotation.z);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
                open = false;
            }
            else //If the door is closed, open it
            {
                Quaternion targetRotation = Quaternion.Euler(defaultRotation.x, doorOpenAngle, defaultRotation.z);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
                open = true;
            }
        }
    }
}