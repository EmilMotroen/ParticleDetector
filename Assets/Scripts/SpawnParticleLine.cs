using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawn particles from a gameobject. 
/// Used by particles spawned in a line on tracking simulation.
/// </summary>
public class SpawnParticleLine : MonoBehaviour, ISpawnParticle
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
		throw new System.NotImplementedException();
	}
}
