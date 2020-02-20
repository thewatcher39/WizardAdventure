using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

	public GameObject explosionEffectPrefab;
	

	private void SpawnExplosionParticles(GameObject ef)
	{
		Transform t = GetComponent<Transform>();
		Instantiate (ef, t.position, Quaternion.identity);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag != "MainHero" && other.gameObject.tag != "blast")
		{
			SpawnExplosionParticles(explosionEffectPrefab);
			Destroy(this.gameObject);
		}
	}
}