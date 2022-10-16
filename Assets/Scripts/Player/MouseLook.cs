using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    private float sensitivity = 30f;
    [SerializeField]
    private Transform playerBody;

    private float xRotation;

    // Update is called once per frame
    void Update()
    {
        LookToCursor();
    }

    private void LookToCursor()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * 10 * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * 10 * Time.deltaTime;

        // Clamping the rotation limits the player to look 90deg up and 90deg down
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
