using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boosts : MonoBehaviour
{
	public int _itemID;  

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "MainHero")
		{
			GameManager.Instance.currentItemID = _itemID;
			Destroy(this.gameObject);
		}
	}
}
