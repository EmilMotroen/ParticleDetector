/// <summary>
/// An interface detailing the common features needed by the different particle spawners.
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
	/// TODO: Look into using some kind of timer to destroy particles instead of doing 
	/// it in this method.
	/// </summary>
	public abstract void Spawn();
}
