using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Add pixels in a grid for a particle to pass through for tracking.
/// The tracking is a particle goes through the pixels, then those pixels are saved to a file/database,
/// then fetched from that file/database and put back on the pixels to add tracking of the particle.
/// </summary>
public class AddTrackingPixels : MonoBehaviour, IAddAlpidePixels
{
    [SerializeField]
    private GameObject _pixel;

	public int NumberOfAlpideLayers { get { return 3; } }
	public float DistanceBetweenAlpideLayers { get { return 0.1f; } set { } }

	private readonly int _numberOfPixelsX = 10;
    private readonly int _numberOfPixelsY = 5;
	private float _sizeOfBoxX;
	private float _sizeOfBoxZ;


	private void Start()
	{
		_sizeOfBoxX = _pixel.GetComponent<MeshRenderer>().bounds.size.x / 10;  // Planes are 10x10 and not 1x1 by default
		_sizeOfBoxZ = _pixel.GetComponent<MeshRenderer>().bounds.size.z / 10;
		Spawn();
	}

    public void Spawn()
    {
		for (int layer = 0; layer < NumberOfAlpideLayers; layer++)
		{
			for (int pixelsX = 0;  pixelsX < _numberOfPixelsX; pixelsX++)
			{
				for (int pixelsZ = 0;pixelsZ < _numberOfPixelsY; pixelsZ++)
				{
					var pixelPos = new Vector3(pixelsX + _sizeOfBoxX, DistanceBetweenAlpideLayers - layer, pixelsZ + _sizeOfBoxZ);
					var pixelCopy = Instantiate(_pixel, pixelPos, Quaternion.identity);
					pixelCopy.name = $"{pixelsX}_{pixelsZ}_{layer}"; 

				}
			}
		}
    }
}
