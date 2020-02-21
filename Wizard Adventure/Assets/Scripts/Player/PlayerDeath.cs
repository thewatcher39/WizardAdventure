using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
	public GameObject dieAnim;

	private GameObject _spawnedAnim;

	private void Death()
	{
		_spawnedAnim = Instantiate(dieAnim, transform.position, Quaternion.identity);
		Destroy(this.gameObject);
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "enemy")
		{
			Death();
		}
	}

}
