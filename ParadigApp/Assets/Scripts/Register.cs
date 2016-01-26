using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;


public class Register : MonoBehaviour {

	public Dropdown ddlGender;
	string userName;
	string password;
	string age;
	string gender;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetUserName(string pUserName){
		this.userName = pUserName; 
	}
	public void GetUserName(){
		Debug.Log (this.userName);
		//return this.userName;
	}

	public void SetPassword(string pPassword){
		this.password = pPassword; 
	}
	public string GetPassword(){
		Debug.Log (this.password);
		return this.password;
	}

	public void SetAge(string pAge){
		this.age = pAge; 
	}
	public string GetAge(){
		Debug.Log (this.age);
		return this.age;
	}

	public void ValidateUser(){
		// here make a call to web service and verify if user is valid
		Debug.Log (this.userName);
		Debug.Log (this.password);
		Debug.Log (this.age);
		Debug.Log (this.ddlGender.options[ddlGender.value].text);

	}
}
