using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
	public GameObject dieAnim, deathScreen;

	private GameObject _spawnedAnim;

	private void Death()
	{
		if(GameManager.Instance.canDie && GameManager.Instance.healthPoint <= 0)
		{
			_spawnedAnim = Instantiate(dieAnim, transform.position, Quaternion.identity);
			Destroy(this.gameObject);
			deathScreen.SetActive(true);
		}
		else if(GameManager.Instance.healthPoint >= 1)
			GameManager.Instance.healthPoint--;
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "enemy")	
			Death();	
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "enemy")	
			Death();
	}

}
