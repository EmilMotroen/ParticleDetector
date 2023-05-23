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
	private float _lifetime = 10.0f;
	[SerializeField]
	private float _velocity = 12.0f;
	[SerializeField]
	private float _timeToCollision = 20.0f;
	[SerializeField]
	private float _collisionDuration = 3.0f;

	private void Update()
	{
		CollisionTimer();
	}

	/// <summary>
	/// Counts down to the collision, then spends a couple seconds shooting out particles
	/// </summary>
	private void CollisionTimer()
	{
		_timeToCollision -= Time.deltaTime;
		if (_timeToCollision < 0)
		{
			Spawn();
			_collisionDuration -= Time.deltaTime;
			if (_collisionDuration < 0)
			{
				_timeToCollision = 20.0f;
				_collisionDuration = 3.0f;
			}
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
