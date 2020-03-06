using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

	public GameObject explosionEffectPrefab;
	public bool enemy;

	private void SpawnExplosionParticles(GameObject ef)
	{
		Transform t = GetComponent<Transform>();
		Instantiate (ef, t.position, Quaternion.identity);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(enemy)
		{
			if(other.gameObject.tag != "enemy")
			{
				SpawnExplosionParticles(explosionEffectPrefab);
				Destroy(this.gameObject);
			}
		}
		else
		{
			if(other.gameObject.tag != "MainHero" && other.gameObject.tag != "blast" && other.gameObject.tag != "soul")
			{
				SpawnExplosionParticles(explosionEffectPrefab);
				Destroy(this.gameObject);
			}
		}
	}
}