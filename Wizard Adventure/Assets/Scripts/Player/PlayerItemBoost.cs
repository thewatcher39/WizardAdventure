using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemBoost : MonoBehaviour
{
	public GameObject shield;

	private void BootleBoost()
	{
		GameManager.Instance.manaRegeneration = GameManager.Instance.manaRegeneration * 2;
		GameManager.Instance.currentItemID = 0;
	}

	private void HeartBoost()
	{
		GameManager.Instance.healthPoint += 1;
		GameManager.Instance.currentItemID = 0;
	}

	private void LampBoost()
	{
		if(GameManager.Instance.mana >= 0.1f)
		{
			if(Input.GetKeyDown(KeyCode.Mouse1))
			{
				if(GameManager.Instance.canDie == false)
				{
					shield.SetActive(false);
					GameManager.Instance.canDie = true;				
				}
				else
					GameManager.Instance.canDie = false;
			}

			if(GameManager.Instance.canDie == false)
			{
				shield.SetActive(true);
				GameManager.Instance.mana -= 0.1f;
			}
		}
		else
			GameManager.Instance.canDie = true;
	}


	private void Update()
	{
		if(GameManager.Instance.currentItemID == 1)
			BootleBoost();
		else if(GameManager.Instance.currentItemID == 2)
			HeartBoost();
		else if(GameManager.Instance.currentItemID == 3)
			LampBoost();
	}

}