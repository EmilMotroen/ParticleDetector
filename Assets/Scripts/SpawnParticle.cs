//using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Spawn particles from a gameobject that is hidden inside the collider cylinder. 
/// Used by particles spawned in a circle on the USNExpo simulation.
/// </summary>
public class SpawnParticle : MonoBehaviour
{
	[SerializeField]
	private GameObject _particle;
	[SerializeField]
	private Text _collisionText;
	[SerializeField]
	private Text _collisionEnergyText;
	[SerializeField]
	private Text _dateText;

	[SerializeField]
	private float _lifetime = 10.0f;
	[SerializeField]
	private float _velocity = 12.0f;
	[SerializeField]
	private float _timeToCollision = 25.0f;
	[SerializeField]
	private float _collisionDuration = 3.5f;

	private void Update()
	{
		_dateText.text = System.DateTime.Now.ToString();
		CollisionTimer();
	}

	/// <summary>
	/// Counts down to the collision, then spends a couple seconds shooting out particles
	/// </summary>
	private void CollisionTimer()
	{
		_timeToCollision -= Time.deltaTime;
		if (_timeToCollision > 12.0)
		{
			_collisionText.text = "Cleaning up after previous collision...";
		}
		else
		{
			_collisionText.text = "New collision in: " + _timeToCollision.ToString("0.000");
		}
		if (_timeToCollision < 0)
		{
			_collisionText.text = "Colliding!";
			_collisionEnergyText.text = "Collision Energy: " + Random.Range(3.0f, 7.0f).ToString("0.00") + " TeV";
			Spawn();
			_collisionDuration -= Time.deltaTime;
			if (_collisionDuration < 0)
			{
				_timeToCollision = 25.0f;
				_collisionDuration = 3.5f;
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
