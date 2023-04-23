using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAddAlpidePixels
{
	/// <summary>
	/// Number of layers of ALPIDEs to render.
	/// </summary>
	public abstract int NumberOfAlpideLayers { get; }
	/// <summary>
	/// The distance from the closest ALPIDE to the point the particle is instantiated from.
	/// </summary>
	public abstract float DistanceBetweenColliderAndAlpide { get; }
	/// <summary>
	/// Distance between the layers of the ALPIDEs.
	/// </summary>
    public abstract float DistanceBetweenAlpideLayers { get; set; }
	/// <summary>
	/// Spawn the ALPIDEs and pixels.
	/// </summary>
    public abstract void Spawn();
}
