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
    private Vector3 _initialPos = Vector3.zero;
    private Quaternion _initialRot = Quaternion.identity;

    [SerializeField]
    private float _speed = 5.0f;  // Speed of the camera
    [SerializeField]
    private float _sensitivity = 3.5f;  // Sensitivity of the camera

    private void Start()
    {
        _initialPos = transform.position;
        _initialRot = transform.rotation;
    }

    private void Update()
    {
        // Move camera forward, backward, left and right
        transform.position += _speed * Input.GetAxis("Vertical") * Time.deltaTime * transform.forward;
		transform.position += _speed * Input.GetAxis("Horizontal") * Time.deltaTime * transform.right;

        // Rotate camera
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.eulerAngles += new Vector3(-mouseY * _sensitivity, mouseX * _sensitivity, 0);

        // Reset camera position and rotation with the 'R' key
        if (Input.GetKeyDown(KeyCode.R))
        {
			transform.SetPositionAndRotation(_initialPos, _initialRot);
		}
	}
}
