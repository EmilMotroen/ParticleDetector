using UnityEngine;

/// <summary>
/// Manages the collisions of the particles and ALPIDEs. Attached to the Particle object.
/// Currently works for both sims, but may need to create another particle object and collision class.
/// </summary>
public class CollisionManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FullSensor"))  // Used for the USNExpo sim
        {
            Debug.Log($"Hit on sensor {other.name}");
        }
    }
}
