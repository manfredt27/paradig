using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;


public class Register : MonoBehaviour 
{

	public Dropdown ddlGender;
	string userName;
	string password;
	string age;
	string gender;

	public void SetUserName(string pUserName)
	{
		this.userName = pUserName; 
	}

	public void GetUserName()
	{
		Debug.Log (this.userName);
	}

	public void SetPassword(string pPassword)
	{
		this.password = pPassword; 
	}

	public string GetPassword()
	{
		Debug.Log (this.password);
		return this.password;
	}

	public void SetAge(string pAge)
	{
		this.age = pAge; 
	}

	public string GetAge()
	{
		Debug.Log (this.age);
		return this.age;
	}

	public void ValidateUser()
	{
		Debug.Log (this.userName);
		Debug.Log (this.password);
		Debug.Log (this.age);
		Debug.Log (this.ddlGender.options[ddlGender.value].text);
	}
}
