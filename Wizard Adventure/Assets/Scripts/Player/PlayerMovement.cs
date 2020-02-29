using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] [Range(1,10)] private float _moveSpeed = 5;
	[SerializeField] [Range(0,2)] private float _dashRange = 2f;

	public Sprite[] playerState = new Sprite[3]; 

	private Rigidbody2D _playerRb;
	private Vector2 _movement;
	private SpriteRenderer _playerSprite;

	private float _dash;
	private float _dashTime = 0.1f;

	private void AnimationController()
	{
		if(_movement.x > 0)
		{
			_playerSprite.sprite = playerState[0];
		}
		else if(_movement.x < 0)
		{
			_playerSprite.sprite = playerState[0];
		}
		else if(_movement.y > 0)
			_playerSprite.sprite = playerState[1];
		else if(_movement.y < 0)
			_playerSprite.sprite = playerState[2];
	}

	private void Movement()
	{
		_movement.x = Input.GetAxis("Horizontal");
		_movement.y = Input.GetAxis("Vertical");

		_movement += _movement.normalized * _dash;
		_playerRb.velocity = _movement * _moveSpeed;
	}

	private void Dash()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			if(PlayerShootingSystem.mana >= 1)
			{
				if(_dash == 0)
				{
					StartCoroutine("CanDash");
					PlayerShootingSystem.mana--;
				} 
			}
		}
	}

	private void Start()
	{
		_playerSprite = GetComponent<SpriteRenderer>();
		_playerRb = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		AnimationController();
		Dash();
		Movement();
	}

	IEnumerator CanDash()
	{
		_dash = _dashRange;
		yield return new WaitForSeconds(_dashTime);
		_dash = 0;
	}
}
