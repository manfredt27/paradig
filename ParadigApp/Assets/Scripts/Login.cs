using UnityEngine;
using System.Collections;

public class Login : MonoBehaviour 
{


	string userName;
	string password;

	public void setUserName(string pUserName)
	{
		this.userName = pUserName; 
	}

	public void getUserName()
	{
		Debug.Log (this.userName);
		//return this.userName;
	}

	public void setPassword(string pPassword)
	{
		this.password = pPassword; 
	}

	public string getPassword()
	{
		Debug.Log (this.password);
		return this.password;
	}
		
	public void validateUser()
	{
		// here make a call to web service and verify if user is valid
		Debug.Log (this.userName);
		Debug.Log (this.password);
	}
}
