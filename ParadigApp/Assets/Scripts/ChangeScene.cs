using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class ChangeScene : MonoBehaviour {

	static List<string> scenes = new List<string> ();

	public void changeToScene(string pScene)
	{
		scenes.Add(Application.loadedLevelName);
		Debug.Log (Application.loadedLevelName);
		Debug.Log (pScene);
		SceneManager.LoadScene (pScene);
	}

	public static void LoadLastScene() 
	{
		string lastScene = scenes [scenes.Count - 1];
		SceneManager.LoadScene (lastScene);
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			LoadLastScene ();
		}
	}
}
