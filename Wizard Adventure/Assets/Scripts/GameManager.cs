using UnityEngine;
using SingletonManager;

public class GameManager : Singleton<GameManager>
{
	public int coins = 999;
	public int ammoID = 0;
	public int itemID = 20;
	public int healthPoint; 
	public float mana = 10;
	public float manaRegeneration = 0.02f;
	public bool isShieldBought = false;
	public bool getSoul = false;
	public bool canDie = true;
	public bool[] unlockedAmmoID = new bool[3]; 


	private void AmmoSwitch()
	{
		if(Input.GetKeyDown(KeyCode.Q))
		{
			if(ammoID != 0)
				ammoID--;
		}
		if(Input.GetKeyDown(KeyCode.E))
		{
			if(ammoID != 2 && unlockedAmmoID[ammoID + 1])
				ammoID++;
		}
	}

	private void Start()
	{
		unlockedAmmoID[0] = true;
	}

	private void FixedUpdate()
	{
		AmmoSwitch();
		if(mana <= 10)
			mana += manaRegeneration;
	}
}