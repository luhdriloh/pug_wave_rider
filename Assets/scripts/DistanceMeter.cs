using System;
using UnityEngine;

public class DistanceMeter : MonoBehaviour
{
	public Transform other = null;
	public bool arrowEnabled = false;

	public void Update ()
	{
		if (!arrowEnabled)
		{
			return;
		}

		float distance = other.position.y - transform.position.y;

		if (distance <= .2)
		{
			MoveArrowToPool ();
			arrowEnabled = false;
		}
	}

	public void SetMeter(Transform otherTransform)
	{
		other = otherTransform;
		arrowEnabled = true;
	}

	private void MoveArrowToPool()
	{
		transform.position = GameConstants.poolStartPosition;
	}
}


