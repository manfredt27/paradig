using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WebService : MonoBehaviour 
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

	// Wait for response method
	// Param: pWwww -> url with data predefine
	IEnumerator WaitForResponse(WWW www)
	{
		yield return www;

		// check for errors
		if (www.error == null) {
			// Here we can do whatever we want :)
			Debug.Log ("WebService Response: " + www.text);
		} else {
			Debug.Log ("Error: " + www.error);
		}
	}

	public void Send(string userName, string rightAnswers, string time)
	{
		// Set url of web service
		string urlPOST = "http://jsonplaceholder.typicode.com/posts";
		// create a form and set data to send
		WWWForm formPOST = new WWWForm ();
		formPOST.AddField ("totalTime", time);
		formPOST.AddField ("rightAnswers", rightAnswers);
		formPOST.AddField ("userName", userName);
		WWW wwwPOST = new WWW (urlPOST, formPOST);

		// Start coroutine to make a post to web service
		StartCoroutine(WaitForResponse(wwwPOST));
	}
}