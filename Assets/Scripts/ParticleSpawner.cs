using UnityEngine;

/// <summary>
/// Spawn particles from a gameobject that is hidden inside the collider cylinder.
/// </summary>
public class ParticleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _particle;
    [SerializeField]
    private GameObject _particleSpawner;

    private Vector3 _spawnerLocation;

    private readonly float _particleLifetime = 15.0f;  // Seconds
    private readonly float _maxParticleVelocity = 20.0f;  // Unity units/s

    void Start()
    {
        _spawnerLocation = transform.position;
    }

	private void Update()
	{

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateParticle();
		}
	}

    /// <summary>
    /// Create and destroy new particles.
    /// </summary>
    private void CreateParticle()
    {
		var particle = Instantiate(_particle, _spawnerLocation, Quaternion.identity);
        particle.GetComponent<Rigidbody>().velocity = new Vector3(
            Random.Range(-_maxParticleVelocity, _maxParticleVelocity),
			Random.Range(-_maxParticleVelocity, _maxParticleVelocity),
			Random.Range(-_maxParticleVelocity, _maxParticleVelocity));
        Destroy(particle, _particleLifetime);  // Destroy particles after a certain time to prevent too many existing
	}
}
