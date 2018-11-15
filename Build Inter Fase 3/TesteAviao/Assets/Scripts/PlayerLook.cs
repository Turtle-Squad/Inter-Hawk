using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour {
    public string mouseXInputName, mouseYInputName;
    public float mouseSensibility;

    private float xAxisClamp;

    public Transform playerBody;


	// Use this for initialization
	void Start () {
        LockCursor();
        xAxisClamp = 0.0f;
	}

    private void LockCursor() {
        Cursor.lockState = CursorLockMode.Locked;
    }

	// Update is called once per frame
	void Update () {
        CameraRotation();
	}

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensibility * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensibility * Time.deltaTime;

        xAxisClamp += mouseY;

        if (xAxisClamp > 30 ) {
            xAxisClamp = 30.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(330.0f);
        }
        else if (xAxisClamp < -30)
        {
            xAxisClamp = -30.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(30.0f);
        }

        transform.Rotate(Vector3.left * mouseY);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
}
