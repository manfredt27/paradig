using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MessageFunctions : MonoBehaviour 
{
	[SerializeField] GameObject PanelPrefab;

	public void ShowMessage(string pMessage)
	{
		PanelPrefab.transform.GetChild (0).GetComponent<Text> ().text = pMessage;
	}
}