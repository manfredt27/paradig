using UnityEngine;
using System.Collections;

public class Login : MonoBehaviour 
{
	public string userName { get; set; }
	public string password { get; set; }

	public void validateUser()
	{
		// here make a call to web service and verify if user is valid
		Debug.Log (this.userName);
		Debug.Log (this.password);
	}
}
