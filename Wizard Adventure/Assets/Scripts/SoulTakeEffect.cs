using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulTakeEffect : MonoBehaviour
{
	private Transform _heroTransform;
	private float _speed = 6;

	private void Awake()
	{
		_heroTransform = GameObject.FindGameObjectWithTag("MainHero").GetComponent<Transform>();
	}

	private void FixedUpdate()
	{
		transform.position = Vector2.MoveTowards(transform.position, _heroTransform.position, _speed * Time.deltaTime);

		if(transform.position == _heroTransform.position)
		{
			GameManager.Instance.getSoul = true;
			Destroy(this.gameObject);
		}
	}
}
