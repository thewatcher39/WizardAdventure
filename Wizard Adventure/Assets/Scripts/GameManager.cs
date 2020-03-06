using UnityEngine;
using SingletonManager;

public class GameManager : Singleton<GameManager>
{
	public int coins;
	public float mana = 10;
	public int ammoID = 0;
	public bool getSoul = false; 

	private void AmmoSwitch()
	{
		if(Input.GetKeyDown(KeyCode.Q))
		{
			if(ammoID != 0)
				ammoID--;
		}
		if(Input.GetKeyDown(KeyCode.E))
		{
			if(ammoID != 1)
				ammoID++;
		}
	}

	private void FixedUpdate()
	{
		AmmoSwitch();
		if(mana <= 10)
			mana += 0.02f;
	}
}