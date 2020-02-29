using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWizardBehavior : MonoBehaviour
{
	public GameObject blastPrefab;

	[SerializeField] private float _shotInterval = 1;
	[SerializeField] private int _seeDistance = 15;
	[SerializeField] private int _stopDistance = 5;
	[SerializeField] private int _runAwayDistance = 3;
	[SerializeField] private float _speed = 3;

	private Transform _playerTransform;


	private void Movement()
	{
		if(_playerTransform != null)
		{
			if(Vector2.Distance(transform.position, _playerTransform.position) < _seeDistance && Vector2.Distance(transform.position, _playerTransform.position) > _stopDistance)
				transform.position = Vector2.MoveTowards(transform.position, _playerTransform.transform.position, _speed * Time.deltaTime);
			if(Vector2.Distance(transform.position, _playerTransform.position) < _runAwayDistance)
				transform.position = Vector2.MoveTowards(transform.position, _playerTransform.transform.position, -_speed * Time.deltaTime);
		}
	}

	private void Shot()
	{
		if(_playerTransform != null)
		{
			var heading = _playerTransform.position - transform.position;
			var distance = heading.magnitude;
			var direction = heading / distance;
			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
			GameObject blast = Instantiate(blastPrefab, transform.position, Quaternion.Euler(0, 0, angle));
			blast.GetComponent<Rigidbody2D>().AddForce(direction * 5, ForceMode2D.Impulse);
		}
	}

	private void Start()
	{
		_playerTransform = GameObject.FindGameObjectWithTag("MainHero").GetComponent<Transform>();
		StartCoroutine("ShotInterval");
	}

	private void FixedUpdate()
	{
		if(_playerTransform != null)
			Movement();	
	}

	IEnumerator ShotInterval()
	{
		while(true)
		{
			yield return new WaitForSeconds(_shotInterval);
			Shot();
		}
	}
}
