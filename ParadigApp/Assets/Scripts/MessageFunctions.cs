using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MessageFunctions : MonoBehaviour 
{

	[SerializeField] GameObject FutureParentPanelPrefab; // future prefab
	[SerializeField] GameObject UserParentPanelPrefab; // user prefab

	public void ShowMessage(string pMessage)
	{
		if (FutureParentPanelPrefab != null) 
		{
			FutureParentPanelPrefab.transform.GetChild (0).GetComponent<Text> ().text = pMessage;
		}
		if (UserParentPanelPrefab != null) 
		{
			UserParentPanelPrefab.transform.GetChild (0).GetComponent<Text> ().text = pMessage;
		}

	}
}
