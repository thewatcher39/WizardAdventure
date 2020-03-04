using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
	public Slider manaPool;
	public RectTransform ammoImage;

	private float _changeSpeed = 0.2f;

	private void AmmoSwitch()
	{
		if(GameManager.Instance.ammoID == 0)
			ammoImage.localPosition = Vector3.Lerp(ammoImage.localPosition, new Vector3(0,0,0), _changeSpeed);
		else if(GameManager.Instance.ammoID == 1)
			ammoImage.localPosition = Vector3.Lerp(ammoImage.localPosition, new Vector3(-85,0,0), _changeSpeed);
	}  

	private void Update()
	{
		AmmoSwitch();
		manaPool.value = GameManager.Instance.mana;
	}
}
