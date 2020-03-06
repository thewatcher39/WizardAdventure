using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	public Animation fade;

	public void PlayButton()
	{
		fade.Play("fadeOn");
		StartCoroutine("ChangeScene");
	}

	private IEnumerator ChangeScene()
	{
		yield return new WaitForSeconds(0.3f);
		SceneManager.LoadScene(1);
	}
}
