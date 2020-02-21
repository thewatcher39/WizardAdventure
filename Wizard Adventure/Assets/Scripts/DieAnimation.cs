using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieAnimation : MonoBehaviour
{
	private void Start()
	{
		Invoke("Destroy", 4);
	}

	private void Update()
	{
		transform.position += Vector3.up * Time.deltaTime;
	}

	private void Destroy()
	{
		Destroy(this.gameObject);
	}
}
