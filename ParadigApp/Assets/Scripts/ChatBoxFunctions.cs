using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChatBoxFunctions : MonoBehaviour {

	//WebService webService;
	string message = "";
	[SerializeField] Transform messageParentPanel;
	[SerializeField] GameObject newMessagePrefab;

	void Start(){
		// Instantiate the webService
		//webService = (WebService)GameObject.Find("_WebServiceManager").GetComponent(typeof(WebService));
	}

	public void SetMessage (string pMesssage){
		this.message = pMesssage;

	}
	public void ShowMessage(){
		if (this.message != "") {
			GameObject clone = (GameObject)Instantiate (newMessagePrefab); // new Object 
			clone.transform.SetParent (messageParentPanel); // set new object to parent object
			clone.transform.SetSiblingIndex (messageParentPanel.childCount - 2);
			clone.GetComponent<MessageFunctions> ().ShowMessage (this.message); // set message to new object to show in GUI
			//webService.sendMessage (this.message); // call web service method (POST method)
		}
	}
}
