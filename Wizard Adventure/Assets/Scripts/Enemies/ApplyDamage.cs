using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyDamage : MonoBehaviour
{
	public GameObject soulPrefab;

	[SerializeField] public int _healthPoint = 0;
	[SerializeField] private int _coinPerKill = 0;

	public void TakeDamage(int damage)
	{
		_healthPoint -= damage;
		if(_healthPoint <= 0)
		{
			Instantiate(soulPrefab, transform.position, Quaternion.Euler(0,0,Random.Range(0,360)));
			GameManager.Instance.coins += _coinPerKill;
			Destroy(this.gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "blast")
			TakeDamage(1);
	}
}
