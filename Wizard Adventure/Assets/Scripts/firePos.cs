using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firePos : MonoBehaviour
{
	public Transform target;

	private Transform t;

	private void Start()
	{
		t = GetComponent<Transform>();
	}

	private void FixedUpdate()
	{
		t.position = new Vector3(target.position.x, target.position.y, -10);
	}
}
