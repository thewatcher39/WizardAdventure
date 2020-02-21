using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

	public Transform target;

	private void Update()
	{
		if(target)
			transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x ,target.position.y ,-10), 0.1f);
	}

}
