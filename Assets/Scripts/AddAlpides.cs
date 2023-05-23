using UnityEngine;

/// <summary>
/// Add the ALPIDEs around a collision point so they get hit by particles.
/// </summary>
public class AddAlpides : MonoBehaviour
{
	[SerializeField]
	private GameObject _alpide;
	private Vector3 center = Vector3.zero;

	private const int _numberOfAlpidesToTheSide = 23;
	private const float _distanceBetweenAlpides = 1.5f;

	void Start()
	{
		AddAdditionalAlpides();
	}

	/// <summary>
	/// Adds more stacks next to the original circle of stacks
	/// </summary>
	private void AddAdditionalAlpides()
	{
		center = _alpide.transform.position;
		for (int i = 0; i < _numberOfAlpidesToTheSide; i++)
		{
			float distance = _distanceBetweenAlpides;
			center.z += distance;
			var alpide = Instantiate(_alpide, center, Quaternion.identity);
			alpide.transform.Rotate(0, 90, 90); // TODO: Rotate in Blender so we don't need to do it in code
		}
	}
}

