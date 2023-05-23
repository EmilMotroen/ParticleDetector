using UnityEngine;

/// <summary>
/// Add the ALPIDEs around a collision point so they get hit by particles.
/// </summary>
public class AddAlpides : MonoBehaviour
{
	[SerializeField]
	private GameObject _alpide;
	private Vector3 center = Vector3.zero;

	private const int _numberOfAlpidesToTheSide = 5;
	private const float _distanceBetweenAlpides = 1.5f;

	void Start()
	{
		center = transform.position;
		for (int i = 0; i <  _numberOfAlpidesToTheSide; i++)
		{
			float distance = _distanceBetweenAlpides;
			center.z += distance;
			var alpide = Instantiate(_alpide, center, Quaternion.identity);
			alpide.transform.Rotate(0, 90, 90);
		}
	}
}

