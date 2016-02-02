using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MessageFunctions : MonoBehaviour {

	[SerializeField] Text text;

	public void ShowMessage(string pMessage){
		text.text = pMessage;
	}
}
