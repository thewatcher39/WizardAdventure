using UnityEngine;
using SingletonManager;

public class GameManager : Singleton<GameManager>
{
	public int coins;
	public int ammoID = 0;
	public int currentItemID;
	public int healthPoint; 
	public float mana = 10;
	public float manaRegeneration = 0.02f;
	public bool getSoul = false;
	public bool canDie = true;

	private void AmmoSwitch()
	{
		if(Input.GetKeyDown(KeyCode.Q))
		{
			if(ammoID != 0)
				ammoID--;
		}
		if(Input.GetKeyDown(KeyCode.E))
		{
			if(ammoID != 2)
				ammoID++;
		}
	}

	private void FixedUpdate()
	{
		AmmoSwitch();
		if(mana <= 10)
			mana += manaRegeneration;
	}
}