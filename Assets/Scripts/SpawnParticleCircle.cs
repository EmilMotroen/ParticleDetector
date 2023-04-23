using UnityEngine;

/// <summary>
/// Spawn particles from a gameobject that is hidden inside the collider cylinder. 
/// Used by particles spawned in a circle on the USNExpo simulation.
/// </summary>
public class SpawnParticleCircle : MonoBehaviour, ISpawnParticle
{
	[SerializeField]
	private GameObject _particle;

	public float ParticleLifetime { get { return 10.0f; } }
	public float ParticleVelocity { get { return 15.0f; } }

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
            Random.Range(-ParticleVelocity, ParticleVelocity),
			Random.Range(-ParticleVelocity, ParticleVelocity),
			Random.Range(-ParticleVelocity, ParticleVelocity));
        Destroy(particle, ParticleLifetime);  // Destroy particles after a certain time to prevent too many existing
	}
}
