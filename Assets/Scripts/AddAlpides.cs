using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Add the ALPIDEs around a collsion point so they get hit by particles.
/// </summary>
public class AddAlpides : MonoBehaviour, IAddAlpidePixels
{
	[SerializeField]
	private GameObject Alpide;
	
	public int NumberOfAlpideLayers {  get { return 4; } }
	public float DistanceBetweenColliderAndAlpide { get { return 5.0f; } }
	public float DistanceBetweenAlpideLayers { get { return 0.1f; } set { } }

	private readonly int _numberOfAlpidesInLayer = 30;
	private readonly int _additionalAlpidesToTheSides = 0;  // Add ALPIDEs to the left and right
	private readonly float _distanceBetweenAlpidesSides = 1.0f;

	private Vector3 positionOfCenterOfCollider;
	private readonly List<(GameObject, Vector3, Quaternion)> _alpidePositions = 
		new List<(GameObject, Vector3, Quaternion)>();

	void Start()
	{
		positionOfCenterOfCollider = new Vector3(0, 0, 0);
		Spawn();
	}

	public void Spawn()
	{
		for (int alpideNumber = 0; alpideNumber < _numberOfAlpidesInLayer; alpideNumber++)
		{
			Vector3 pos = AlpideCircle(positionOfCenterOfCollider, DistanceBetweenColliderAndAlpide);
			Quaternion rot = Quaternion.FromToRotation(Vector3.forward, positionOfCenterOfCollider - pos);
			var alpide = Instantiate(Alpide, pos, rot);
			alpide.name = $"alpide_{alpideNumber}";
			alpide.transform.LookAt(positionOfCenterOfCollider);  // Rotate ALPIDEs to the collision point
			alpide.transform.Rotate(90, 0, 0);  // Add a 90 degree rotation so they face correctly
			_alpidePositions.Add((alpide, pos, rot));
		}

		AddAdditionalLayers();
	}

	/// <summary>
	/// Add more layers of ALPIDEs by taking the current ones and adding behind them.
	/// TODO: Remove distance and use DistanceBetweenAlpideLayers instead.
	/// </summary>
	private void AddAdditionalLayers()
	{
		float distance = DistanceBetweenAlpideLayers;
		for (int layerNumber = 1; layerNumber < NumberOfAlpideLayers; layerNumber++)
		{
			foreach (var alpide in _alpidePositions)
			{
				var nextLayerAlpide = Instantiate(Alpide);
				float x = (alpide.Item2.x > 0.0) ?
					alpide.Item2.x + distance : alpide.Item2.x - distance;
				float y = (alpide.Item2.y > 0.0) ?
					alpide.Item2.y + distance : alpide.Item2.y - distance;
				nextLayerAlpide.transform.position = new Vector3(x, y);
				nextLayerAlpide.transform.LookAt(positionOfCenterOfCollider);
				nextLayerAlpide.transform.Rotate(90, 0, 0);
			}
			distance += DistanceBetweenAlpideLayers;
			Debug.Log($"{distance}");
		}

		_alpidePositions.Clear();
	}

	/// <summary>
	/// Position ALPIDEs around the collision point.
	/// TODO: Position ALPIDEs systematically instead of randomly
	/// </summary>
	/// <param name="center">Center of the collision point.</param>
	/// <param name="radius">Radius to place ALPIDEs.</param>
	/// <returns>The position to place ALPIDEs.</returns>
	Vector3 AlpideCircle(Vector3 center, float radius)
	{
		float angle = Random.value * 360;
		Vector3 pos;
		pos.x = center.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
		pos.y = center.y + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
		pos.z = center.z;

		return pos;
	}
}

