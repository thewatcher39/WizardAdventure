using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
	public Animation openButton, shopPanel, shopBackground;
	public Sprite activeButton, defaultButton;
	[Space]
	public GameObject[] spellButtons;
	public GameObject[] itemButtons;

	private GameObject _player;

	[Space]
	[SerializeField][Range(1,5)]private int _shopOpenRange = 0;
	private bool _isButtonOpen, _isShopOpen;


	public void SpellsButtonLightingball()
	{
		BuySpell(1);
	}

	public void SpellsButtonRay()
	{
		BuySpell(2);
	}

	public void ItemButtonBottle()
	{
		BuyItem(0, true);
	}

	public void ItemButtonHeart()
	{
		BuyItem(1, false);	
	}

	public void ItemButtonLamp()
	{
		if(!GameManager.Instance.isShieldBought)
		{
			BuyItem(2, false);
			GameManager.Instance.isShieldBought = true;
			itemButtons[2].GetComponentInChildren<Text>().text = "Bought";
			itemButtons[2].GetComponent<Image>().sprite = activeButton;
		}
	}


	private bool GetAccessToOpenShop()
	{
		if(Vector2.Distance(transform.position, _player.transform.position) <= _shopOpenRange)
			return true;
		else
			return false;
	}

	private void BuySpell(int spellID)
	{
		Text priceText = spellButtons[spellID].GetComponentInChildren<Text>();
		int.TryParse(priceText.text, out int price);

		if(GameManager.Instance.coins >= price && !GameManager.Instance.unlockedAmmoID[spellID])
		{
			GameManager.Instance.coins -= price;
			GameManager.Instance.getSoul = true;
			GameManager.Instance.unlockedAmmoID[spellID] = true;
			priceText.text = "Bought";	
		}
	}

	private void BuyItem(int itemID, bool makePrice2x)
	{
		Text priceText = itemButtons[itemID].GetComponentInChildren<Text>();
		int price = int.Parse(priceText.text);

		if(GameManager.Instance.coins >= price)
		{
			GameManager.Instance.itemID = itemID;
			GameManager.Instance.coins -= price;
			GameManager.Instance.getSoul = true;
			if(makePrice2x)
				priceText.text = (price * 2).ToString();
		}
	}

	private void MakeButtonActive()
	{
		int i = 0;

		foreach(GameObject btn in spellButtons)
		{
			if(GameManager.Instance.ammoID == i)
				btn.GetComponent<Image>().sprite = activeButton;
			else
				btn.GetComponent<Image>().sprite = defaultButton;
			i++;
		}
	}

	private void ShopButtonController()
	{
		if(GetAccessToOpenShop() == true && !_isButtonOpen)
			ShopAnimationStateMachine("OpenShopButton", true);
		else if(GetAccessToOpenShop() == false && _isButtonOpen)
			ShopAnimationStateMachine("CloseShopButton", false);
	}

	private void ShopPanelController()
	{
		if(GetAccessToOpenShop() == true && Input.GetKeyDown(KeyCode.F) && !_isShopOpen)
		{
			MakeButtonActive();
			ShopAnimationStateMachine("ShowShopBackground", "OpenShopPanel", true);
		}
		else if(_isShopOpen && Input.GetKeyDown(KeyCode.Escape))
			ShopAnimationStateMachine("HideShopBackground", "CloseShopPanel", false);
		if(_isShopOpen && GetAccessToOpenShop() == false)
			ShopAnimationStateMachine("HideShopBackground", "CloseShopPanel", false);
	}

	private void ShopAnimationStateMachine(string backgroundAnimationName, string shopPanelAnimationName, bool state)
	{
		shopBackground.Play(backgroundAnimationName);
		shopPanel.Play(shopPanelAnimationName);
		_isShopOpen = state;
	}

	private void ShopAnimationStateMachine(string shopButtonAnimationName, bool state)
	{
		openButton.Play(shopButtonAnimationName);
		_isButtonOpen = state;
	}

	private void Start()
	{
		_player = GameObject.FindGameObjectWithTag("MainHero");
	}

	private void Update()
	{
		ShopButtonController();
		ShopPanelController();		
	}
}
