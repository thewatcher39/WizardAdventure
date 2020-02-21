using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
	[SerializeField] private float _timeBeforeDestroy = 0;

	private void DestroyObject()
	{
		Destroy(this.gameObject);
	}

	private void Start()
	{
		Invoke("DestroyObject", _timeBeforeDestroy);
	}
}
