using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class ChangeScene : MonoBehaviour 
{
	private static List<string> scenes = new List<string> ();

	public void ChangeToScene(string scene)
	{
		scenes.Add(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
		SceneManager.LoadScene (scene);
	}

	public static void LoadLastScene() 
	{
		string lastScene = scenes [scenes.Count - 1];
		SceneManager.LoadScene (lastScene);
	}

	public void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			LoadLastScene ();
		}
	}
}