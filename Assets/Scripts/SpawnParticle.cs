using UnityEngine;

/// <summary>
/// Spawn particles from a gameobject that is hidden inside the collider cylinder. 
/// Used by particles spawned in a circle on the USNExpo simulation.
/// </summary>
public class SpawnParticle : MonoBehaviour
{
	[SerializeField]
	private GameObject _particle;

	[SerializeField]
	private float _lifetime = 30.0f;
	[SerializeField]
	private float _velocity = 15.0f;

	private void Update()
	{
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Spawn();
		}
	}

    public void Spawn()
    {
		var particle = Instantiate(_particle, transform.position, Quaternion.identity);
		particle.GetComponent<Rigidbody>().velocity = new Vector3(
            Random.Range(-_velocity, _velocity),
			Random.Range(-_velocity, _velocity),
			Random.Range(-_velocity, _velocity));
        Destroy(particle, _lifetime);  // Destroy particles after a certain time to prevent too many existing
	}
}
