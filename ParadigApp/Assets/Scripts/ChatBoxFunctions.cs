using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ChatBoxFunctions : MonoBehaviour {

	//WebService webService;
	string message = "";
	[SerializeField] Transform messageParentPanel;
	[SerializeField] GameObject newMessagePrefab;
	[SerializeField] GameObject newFutureMessagePrefab;
	List<GameObject> messageList = new List<GameObject>();
	bool isEmptyList = true;
	bool isUserMessage = true;
	void Start(){
		// Instantiate the webService
		//webService = (WebService)GameObject.Find("_WebServiceManager").GetComponent(typeof(WebService));
	}

	public void SetMessage (string pMesssage){
		this.message = pMesssage;

	}
	public void ShowMessage(){
		if (this.message != "") {
			GameObject clone;
			if (this.isUserMessage) {
				clone = (GameObject)Instantiate (newMessagePrefab); // new Object 

			} else {
				clone = (GameObject)Instantiate (newFutureMessagePrefab); // new Object 

			} 

			clone.transform.SetParent (messageParentPanel); // set new object to parent object
			clone.transform.SetSiblingIndex (messageParentPanel.childCount - 2);
			clone.GetComponent<MessageFunctions> ().ShowMessage (this.message); // set message to new object to show in GUI

			if (this.isEmptyList) {
				// 125, -45, 0 -> WS
				// 300, -45, 0 -> user
				if (isUserMessage) {
					clone.transform.localPosition = new Vector3 (300, -45, 0);		
				} 
				else {
					clone.transform.localPosition = new Vector3 (125, -45, 0);				
				}
				this.isEmptyList = false;
			} else {
				Vector3 vector = messageList [messageList.Count - 1].transform.position;
				if (isUserMessage) {
					clone.transform.position = new Vector3 (615, vector.y - 70, vector.z);
					this.isUserMessage = false;
				} else {
					clone.transform.position = new Vector3 (450, vector.y - 70, vector.z);
					this.isUserMessage = true;
				}	

			}
			messageList.Add(clone);
			//webService.sendMessage (this.message); // call web service method (POST method)
		}
	}
}
