using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Spawn particles from a gameobject that is hidden inside the collider cylinder. 
/// Used by particles spawned in a circle on the USNExpo simulation.
/// </summary>
public class SpawnParticle : MonoBehaviour
{
	[SerializeField]
	private GameObject particle;
	[SerializeField]
	private Text collisionText;
	[SerializeField]
	private Text collisionEnergyText;
	[SerializeField]
	private Text dateText;


	[SerializeField]
	private float lifetime = 10.0f;
	[SerializeField]
	private float velocity = 12.0f;
	[SerializeField]
	private float timeToCollision = 18.0f;
	[SerializeField]
	private float collisionDuration = 4.0f;

	private void Update()
	{
		dateText.text = System.DateTime.Now.ToString();
		CollisionTimer();
	}

	/// <summary>
	/// Counts down to the collision, then spends a couple seconds shooting out particles
	/// </summary>
	private void CollisionTimer()
	{
		timeToCollision -= Time.deltaTime;
		if (timeToCollision > 12.0)
		{
			collisionText.text = "Cleaning up after previous collision...";
		}
		else
		{
			collisionText.text = "New collision in: " + timeToCollision.ToString("0.000");
		}
		if (timeToCollision < 0)
		{
			collisionText.text = "Colliding!";
			collisionEnergyText.text = "Collision Energy: " + Random.Range(3.0f, 7.0f).ToString("0.00") + " TeV";
			Spawn();
			collisionDuration -= Time.deltaTime;
			if (collisionDuration < 0)
			{
				timeToCollision = 18.0f;
				collisionDuration = 4.0f;
			}
		}
	}

	public void Spawn()
    {
		var particle = Instantiate(this.particle, transform.position, Quaternion.identity);
		particle.GetComponent<Rigidbody>().linearVelocity = new Vector3(
            Random.Range(-velocity, velocity),
			Random.Range(-velocity, velocity),
			Random.Range(-velocity, velocity));
		Destroy(particle, lifetime);  // Destroy particles after a certain time to prevent too many existing
	}
}
