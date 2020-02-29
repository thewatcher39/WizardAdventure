using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShootingSystem : MonoBehaviour
{
	public static float mana = 10;

	public Slider manaPool;
	public GameObject bulletPrefab;
	public Rigidbody2D firePointRb;
	public Transform firePoint;

	private Transform _playerPos;
	private GameObject _bullet;
	private Vector3 _mousePos;


	private float _shootPower = 10;
	private bool _canShoot = true;


	private void Shoot()
	{
		if(Input.GetKeyDown(KeyCode.Mouse0) && _canShoot)
		{
			if(mana >= 1)
			{
				StartCoroutine("coolDown");
				_bullet = Instantiate(bulletPrefab, firePointRb.position, firePoint.rotation);
				_bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * _shootPower, ForceMode2D.Impulse);
				_canShoot = false;
				mana--;
			}
		}
	}

	private void SetFirePos()
	{
		firePointRb.position = _playerPos.position;
		_mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 lookDir = _mousePos - _playerPos.position;
		float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;
		firePointRb.rotation = angle;
	}

	private void Start()
	{
		_playerPos = GetComponent<Transform>();
	}

	private void FixedUpdate()
	{
		manaPool.value = mana;
		if(mana <= 10)
			mana += 0.02f;
		SetFirePos();
		Shoot();
	}

	IEnumerator coolDown()
	{
		yield return new WaitForSeconds(0.05f);
		_canShoot = true; 
	} 
}
