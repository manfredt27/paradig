using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;


public class Register : MonoBehaviour 
{
	public Dropdown ddlGender;
	public string userName { get; set; }
	public string password { get; set; }
	public string age { get; set; }
	public string gender { get; set; }

	public void ValidateUser()
	{
		Debug.Log (this.userName);
		Debug.Log (this.password);
		Debug.Log (this.age);
		Debug.Log (this.ddlGender.options[ddlGender.value].text);
	}
}
