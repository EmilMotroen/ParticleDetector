using UnityEngine;

/// <summary>
/// Spawn particles from a gameobject. 
/// Used by particles spawned in a line for tracking simulation.
/// </summary>
public class SpawnParticleLine : MonoBehaviour, ISpawnParticle
{
	[SerializeField]
	private GameObject _particle;

	private float _distanceToFirstAlpide = 15.0f;
	private Vector3 _spawnPosition = Vector3.zero;

	public float ParticleLifetime { get { return 10.0f; } }
	public float ParticleVelocity { get { return 15.0f; } }

	private void Start()
	{
		_spawnPosition = new Vector3(0, 0, _distanceToFirstAlpide);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Spawn();
		}
	}

	public void Spawn()
	{
		var particle = Instantiate(_particle, _spawnPosition, Quaternion.identity);
		particle.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -ParticleVelocity);
	}
}
