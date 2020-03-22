using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemBoost : MonoBehaviour
{
	private Animation _shieldAnimation;

	private int _nullNumber = 39;
	private bool _isShieldOpen;

	public void BottleBoost()
	{
		GameManager.Instance.manaRegeneration = GameManager.Instance.manaRegeneration * 1.5f;
		GameManager.Instance.itemID = _nullNumber;
	}

	private void HeartBoost()
	{
		GameManager.Instance.healthPoint += 1;
		GameManager.Instance.itemID = _nullNumber;
		print(GameManager.Instance.healthPoint);
	}

	private void LampBoost()
	{
		if(GameManager.Instance.mana >= 0.1f)
		{
			if(Input.GetKeyDown(KeyCode.Mouse1))
			{
				if(GameManager.Instance.canDie == false)
				{
					GameManager.Instance.canDie = true;				
					_shieldAnimation.Play("PlayerShieldOff");
					_isShieldOpen = false;
				}
				else
					GameManager.Instance.canDie = false;
			}

			if(GameManager.Instance.canDie == false)
			{
				if(!_isShieldOpen)
					_shieldAnimation.Play("PlayerShieldOn");
				_isShieldOpen = true;
				GameManager.Instance.mana -= 0.1f;
			}
		}
		else
		{
			_shieldAnimation.Play("PlayerShieldOff");
			_isShieldOpen = false;
			GameManager.Instance.canDie = true;
		}
	}

	private void Start()
	{
		_shieldAnimation = GetComponentInChildren<Animation>();
	}

	private void Update()
	{
		if(GameManager.Instance.itemID == 0)
			BottleBoost();
		else if(GameManager.Instance.itemID == 1)
			HeartBoost();

		if(GameManager.Instance.isShieldBought)
			LampBoost();
	}

}