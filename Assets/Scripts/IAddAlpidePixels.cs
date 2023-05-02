using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public interface IAddAlpidePixels
{
	/// <summary>
	/// Number of layers of ALPIDEs to add to the scene.
	/// </summary>
	public abstract int NumberOfAlpideLayers { get; }
	/// <summary>
	/// Distance between the layers of the ALPIDEs.
	/// </summary>
    public abstract float DistanceBetweenAlpideLayers { get; set; }
	/// <summary>
	/// Spawn the ALPIDEs and pixels.
	/// </summary>
    public abstract void Spawn();
}
