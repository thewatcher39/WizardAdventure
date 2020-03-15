using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayBehaviour : MonoBehaviour
{
	public GameObject rayEffectPrefab;

	private PlayerShootingSystem shootingSystem;

	private void Start()
	{
		shootingSystem = GameObject.FindGameObjectWithTag("MainHero").GetComponent<PlayerShootingSystem>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag != "soul" && other.gameObject.tag != "MainHero")
		{
			Instantiate(rayEffectPrefab, transform.position, Quaternion.identity);
			Destroy(this.gameObject);
		}
		if(other.gameObject.tag == "enemy")
		{
			if(other.gameObject.GetComponent<ApplyDamage>() != null)
				other.gameObject.GetComponent<ApplyDamage>().TakeDamage(shootingSystem.rayDamage);
		}
	}

	private void FixedUpdate()
	{
		transform.position = Vector3.MoveTowards(transform.position ,shootingSystem.hit.transform.position, 0.5f);
	}
}
