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

	public int NumberOfAlpideLayers { get { return 2; } }
	public float DistanceBetweenColliderAndAlpide { get { return 5.0f; } }
	public float DistanceBetweenAlpideLayers { get { return 0.1f; } set { } }

	private readonly int _numberOfPixelsX = 10;
    private readonly int _numberOfPixelsY = 5;
	private float _sizeOfBoxZ;
	private float _sizeOfBoxY;

	private Vector3 _positionOfParticleLaunch;

	private void Start()
	{
		_sizeOfBoxZ = _pixel.GetComponent<MeshRenderer>().bounds.size.z / 10;  // Planes are 10x10 and not 1x1 by default
		_sizeOfBoxY = _pixel.GetComponent<MeshRenderer>().bounds.size.y / 10;
		Debug.Log($"x: {_sizeOfBoxZ}, y: {_sizeOfBoxY}");
		_positionOfParticleLaunch = Vector3.zero;
		Spawn();
	}

    public void Spawn()
    {
		for (int layer = 0; layer < NumberOfAlpideLayers; layer++)
		{
			for (int pixelsZ = 0;  pixelsZ < _numberOfPixelsX; pixelsZ++)
			{
				for (int pixelsY = 0;pixelsY < _numberOfPixelsY; pixelsY++)
				{
					var pixelPos = new Vector3(pixelsZ + _sizeOfBoxZ, pixelsY + _sizeOfBoxY, DistanceBetweenAlpideLayers - layer);
					var pixelCopy = Instantiate(_pixel, pixelPos, Quaternion.identity);
					pixelCopy.transform.Rotate(-90, 0, 0);
					pixelCopy.name = $"pixel_{pixelsZ}_{pixelsY}_{layer}";

				}
			}
		}
    }
}
