using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the collisions of the particles and ALPIDEs. Attached to the Particle object.
/// </summary>
public class CollisionManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pixel"))
        {
            Debug.Log($"Hit on {other.name}");
        }
    }
}
