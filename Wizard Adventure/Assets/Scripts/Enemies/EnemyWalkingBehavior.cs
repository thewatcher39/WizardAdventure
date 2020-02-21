using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkingBehavior : MonoBehaviour
{
	[SerializeField] private float _seeDistance = 15;
	[SerializeField] private float _speed = 3;

	private Transform _playerTransform;


	private void Catch()
	{
		if(Vector2.Distance(transform.position, _playerTransform.position) < _seeDistance)
			transform.position = Vector2.MoveTowards(transform.position, _playerTransform.transform.position, _speed * Time.deltaTime);
	}

	private void Start()
	{
		_playerTransform = GameObject.FindGameObjectWithTag("MainHero").GetComponent<Transform>();
	}

	private void FixedUpdate()
	{
		if(_playerTransform != null)
			Catch();	
	}

}
