using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlazerBehavior : MonoBehaviour
{
	public GameObject fireballPrefab;
	public Vector2[] fireballDirection;

	[SerializeField] private int _shotInterval = 3;
	[SerializeField] private float _fireballSpeed = 2;

	private GameObject[] _spawnedFireballs = new GameObject[8];
	private Rigidbody2D[] _fireballsRb = new Rigidbody2D[8];

	private void Shot()
	{
		int _rotateAngle = 0;

		for(int i = 0; i < fireballDirection.Length; i++)
		{
			_spawnedFireballs[i] = Instantiate(fireballPrefab, transform.position, Quaternion.Euler(0, 0, _rotateAngle));
			_fireballsRb[i] = _spawnedFireballs[i].GetComponent<Rigidbody2D>();
			_rotateAngle -= 45;
		}
		for(int i = 0; i < fireballDirection.Length; i++)
		{
			_fireballsRb[i].AddForce(fireballDirection[i] * _fireballSpeed, ForceMode2D.Impulse);
		}
	}

	private void Start()
	{
		StartCoroutine("SpawnBullets");
	}

	IEnumerator SpawnBullets()
	{
		while(true)
		{
			yield return new WaitForSeconds(_shotInterval);
			Shot();
		}
	}
}
