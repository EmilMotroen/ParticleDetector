using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public interface ISpawnParticle
{
	/// <summary>
	/// In seconds.
	/// </summary>
	public abstract float ParticleLifetime { get; }

	/// <summary>
	/// Unity units/second.
	/// </summary>
	public abstract float ParticleVelocity { get; }

	/// <summary>
	/// Spawn and destroy new particles.
	/// </summary>
	public abstract void Spawn();
}
