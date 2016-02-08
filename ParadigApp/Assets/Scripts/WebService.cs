using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WebService : MonoBehaviour 
{
	string message;
	// Use this for initialization
	void Start () 
	{

		// 	THIS CODE IS AN EXAMPLE OF HOW TO CONSUME WS (DO NOT ERASE by the moment)
//		// Set url of web service (for GET example)
//		string urlGET = "http://jsonplaceholder.typicode.com/posts/1"; // url what I found in google (json web service online for test)
//		WWW wwwGET = new WWW (urlGET);
//
//		// Start coroutine to make a get from web service
//		StartCoroutine(waitForResponse(wwwGET));
//
//
//
//		// Set url of web service (for POST example)
//		string urlPOST = "http://jsonplaceholder.typicode.com/posts";
//
//		// create a form and set data to send
//		WWWForm formPOST = new WWWForm ();
//		formPOST.AddField ("title", "testPost");
//		formPOST.AddField ("body", "test from unity");
//		formPOST.AddField ("userId", 1);
//		WWW wwwPOST = new WWW (urlPOST, formPOST);
//
//		// Start coroutine to make a post to web service
//		StartCoroutine(waitForResponse(wwwPOST));
//
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	// Wait for response method
	// Param: pWwww -> url with data predefine
	IEnumerator waitForResponse(WWW pWww)
	{
		yield return pWww;

		// check for errors
		if (pWww.error == null) {
			// Here we can do whatever we want :)
			Debug.Log ("WWW OK: " + pWww.data);
		} else {
			Debug.Log ("Error: " + pWww.error);
		}
	}
		
	public void SetMessage (string pMesssage)
	{
		this.message = pMesssage;
	}

	public void sendMessage()
	{
		// Set url of web service
		string urlPOST = "http://jsonplaceholder.typicode.com/posts"; // mejorar
		// create a form and set data to send
		WWWForm formPOST = new WWWForm ();
		formPOST.AddField ("title", "testPost");
		formPOST.AddField ("body", this.message);
		formPOST.AddField ("userId", 1);
		WWW wwwPOST = new WWW (urlPOST, formPOST);

		// Start coroutine to make a post to web service
		StartCoroutine(waitForResponse(wwwPOST));
	}
}
