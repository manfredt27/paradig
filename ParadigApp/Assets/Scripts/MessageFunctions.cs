using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MessageFunctions : MonoBehaviour {

	[SerializeField] GameObject FutureParentPanelPrefab; // future prefab
	[SerializeField] GameObject UserParentPanelPrefab; // future prefab

	public void ShowMessage(string pMessage){
		if (FutureParentPanelPrefab != null) 
		{
			// get text from panel
			FutureParentPanelPrefab.transform.GetChild (0).GetComponent<Text> ().text = pMessage;
		}
		if (UserParentPanelPrefab) 
		{
			// get text from panel
			UserParentPanelPrefab.transform.GetChild (0).GetComponent<Text> ().text = pMessage;
		}

	}
}
