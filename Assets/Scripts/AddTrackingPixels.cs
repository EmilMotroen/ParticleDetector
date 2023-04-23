using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Add pixels in a grid for a particle to pass through for tracking.
/// The tracking is a particle goes through the pixels, then those pixels are saved to a file/database,
/// then fetched from that file/database and put back on the pixels to add tracking of the particle.
/// </summary>
public class AddTrackingPixels : MonoBehaviour
{
    [SerializeField]
    private GameObject _pixel;

    private int _numberOfLayers = 2;
    private int _numberOfPixelsX = 10;
    private int _numberOfPixelsY = 5;

	private void Start()
	{
		
	}

    public void Spawn()
    {

    }
}
