using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class that allows movement of the camera, instead of keeping it locked in one position
/// during the simulation.
/// </summary>
public class CameraController : MonoBehaviour
{
    private Vector3 initialPos = Vector3.zero;
    private Quaternion initialRot = Quaternion.identity;

    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private float sensitivity = 3.5f;

    private void Start()
    {
        initialPos = transform.position;
        initialRot = transform.rotation;
    }

    private void Update()
    {
        if (!PauseMenu.Paused)
        {
			// Move camera forward, backward, left and right
			transform.position += speed * Input.GetAxis("Vertical") * Time.deltaTime * transform.forward;
			transform.position += speed * Input.GetAxis("Horizontal") * Time.deltaTime * transform.right;

			// Rotate camera
			float mouseX = Input.GetAxis("Mouse X");
			float mouseY = Input.GetAxis("Mouse Y");
			transform.eulerAngles += new Vector3(-mouseY * sensitivity, mouseX * sensitivity, 0);

			// Reset camera position and rotation with the 'R' key
			if (Input.GetKeyDown(KeyCode.R))
			{
				transform.SetPositionAndRotation(initialPos, initialRot);
			}
		}
	}
}
