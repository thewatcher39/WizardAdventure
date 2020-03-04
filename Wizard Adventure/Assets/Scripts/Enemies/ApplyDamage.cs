using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyDamage : MonoBehaviour
{
	[SerializeField] private int _healthPoint = 0;
	[SerializeField] private int _coinPerKill = 0;

	private void TakeDamage()
	{
		_healthPoint--;
		if(_healthPoint == 0)
		{
			GameManager.Instance.coins += _coinPerKill;
			Destroy(this.gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "blast")
		{
			TakeDamage();
		}
	}
}
