using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
	public Animation fadeAnim;

	[Range(-1, 1)] public int scene;
	public bool isVertical;

	private Transform _heroPos;
	private int _offSet = 1;

	private void LoadPosition()
	{
		if(isVertical)
		{
			if(transform.position.y > 0)
				_heroPos.position = new Vector3(transform.position.x, transform.position.y - _offSet);
			else
				_heroPos.position = new Vector3(transform.position.x, transform.position.y + _offSet);
		}
		else
		{
			if(transform.position.x > 0)
				_heroPos.position = new Vector3(transform.position.x - _offSet, transform.position.y);
			else
				_heroPos.position = new Vector3(transform.position.x + _offSet, transform.position.y);
		}
		GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>().position = _heroPos.position;
	}

	private void Awake()
	{
		_heroPos = GameObject.FindGameObjectWithTag("MainHero").GetComponent<Transform>();
		fadeAnim.Play("fadeOff");
		LoadPosition();
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "MainHero")
		{
			fadeAnim.Play("fadeOn");
			StartCoroutine("ChangeScene");
		}
	}

	private IEnumerator ChangeScene()
	{
		yield return new WaitForSeconds(0.3f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + scene);
	}
}
