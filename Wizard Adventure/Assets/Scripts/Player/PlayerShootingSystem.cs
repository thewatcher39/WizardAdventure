using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingSystem : MonoBehaviour
{
	[HideInInspector]public RaycastHit2D hit;
	public GameObject[] bulletPrefab;
	public GameObject staff, rayPrefab;
	public Transform firePoint;
	public Sprite[] staffSprites;
	[Header("Damages")]
	[Space]
	[Range(1,5)]public int rayDamage;
	[Range(1,5)]public int fireballDamage;
	[Range(1,5)]public int lightningballDamage;

	private Transform _playerPos;
	private GameObject _bullet, _ray;
	private Vector3 _mousePos;
	private SpriteRenderer _staffRenderer;

	private float _shootPower = 10;
	private bool _canShoot = true;


	private void Shoot()
	{
		if(Input.GetKeyDown(KeyCode.Mouse0) && _canShoot)
		{
			if(GameManager.Instance.mana >= 1 && GameManager.Instance.ammoID != 2)
				BallShoot();
			else if(GameManager.Instance.mana >= 1 && GameManager.Instance.ammoID == 2)
				RayShoot();
		}
	}

	private void BallShoot()
	{
		StartCoroutine("coolDown");
		_bullet = Instantiate(bulletPrefab[GameManager.Instance.ammoID], firePoint.transform.position, firePoint.rotation);
		_bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * _shootPower, ForceMode2D.Impulse);
		_canShoot = false;
		GameManager.Instance.mana--;
	}

	private void RayShoot()
	{
		hit = Physics2D.Raycast(firePoint.position, firePoint.up);
		_ray = Instantiate(rayPrefab, firePoint.position, Quaternion.identity);
		GameManager.Instance.mana -= 2;
	}

	private void SetFirePos()
	{
		_mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 lookDir = _mousePos - _playerPos.position;
		float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;
		firePoint.transform.rotation = Quaternion.Euler(0, 0, angle);
		staff.transform.rotation = Quaternion.Euler(0, 0, angle + 45);
	}

	private void ChangeStaffSprite()
	{
		_staffRenderer.sprite = staffSprites[GameManager.Instance.ammoID];
	}

	private void Start()
	{
		_staffRenderer = staff.GetComponent<SpriteRenderer>();
		_playerPos = GetComponent<Transform>();
	}

	private void FixedUpdate()
	{		
		ChangeStaffSprite();
		SetFirePos();
		Shoot();
	}

	IEnumerator coolDown()
	{
		yield return new WaitForSeconds(0.05f);
		_canShoot = true; 
	} 
}
