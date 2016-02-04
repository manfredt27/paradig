using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ChatBoxFunctions : MonoBehaviour {

	//WebService webService;
	string message = "";
	[SerializeField] Transform messageParentPanel; // scroll

	[SerializeField] GameObject UserParentPanelPrefab; // user prefab
	[SerializeField] GameObject FutureParentPanelPrefab; // future prefab

	[SerializeField] Text futureTime; // future time
	[SerializeField] Text userTime; // user time

	List<GameObject> messageList = new List<GameObject>();
	bool isEmptyList = true;
	bool isUserMessage = false;
	private int questionId = 0;
	AssemblyCSharp.Questions question = new AssemblyCSharp.Questions ();

	void Start(){
		question.createQuestion ("¿En qué año está?", "2012", "2031", "3016", "2016", "2016");
		question.addQuestion (question);
		AssemblyCSharp.Questions question2 = new AssemblyCSharp.Questions ();
		question2.createQuestion ("En ese año, con cuales países y cuerpos de agua colinda Costa Rica, tomando en cuenta los límites marítimos:", 
			"Nicaragua y Panamá, océano Atlántico y el océano Pacífico", 
			"Nicaragua, el río San Juan, el océano Atlántico y el océano Pacífico", 
			"Nicaragua, Colombia, Ecuador y Panamá, el mar Caribe y el océano Pacífico", 
			"Nicaragua, Panamá, la isla del Coco, el mar Caribe y el océano Pacífico",
			"Nicaragua, Panamá, la isla del Coco, el mar Caribe y el océano Pacífico");
		question.addQuestion (question2);
		this.isUserMessage = false;
		this.ShowMessage ();
	}

	void Update()
	{
	}

	public void SetMessage (string pMesssage){
		this.message = pMesssage;
	}

	public void ShowMessage(){
		if (!this.isUserMessage)
		{
			this.SetMessage (question.getQuestion (this.questionId).question);
			//this.questionId++;
		}
		if (this.message != "")
		{
			GameObject clone;
			if (this.isUserMessage)
			{
				clone = (GameObject)Instantiate (UserParentPanelPrefab); // new Object 
			}
			else
			{
				clone = (GameObject)Instantiate (FutureParentPanelPrefab); // new Object 

			}
			this.futureTime.text = System.DateTime.UtcNow.ToString ("HH:mm");
			this.userTime.text = System.DateTime.UtcNow.ToString ("HH:mm");
			clone.transform.SetParent (messageParentPanel); // set new object to parent object
			clone.transform.SetSiblingIndex (messageParentPanel.childCount - 2);

			clone.GetComponent<MessageFunctions> ().ShowMessage (this.message); // set message to new object to show in GUI
			if (this.isEmptyList)
			{
				if (isUserMessage)
				{
					clone.transform.localPosition = new Vector3 (100, 415, 0);		
				} 
				else
				{
					clone.transform.localPosition = new Vector3 (0, 450, 0);				
				}
				this.isEmptyList = false;
			}
			else
			{
				Vector3 vector = messageList [messageList.Count - 1].transform.localPosition;
				if (isUserMessage)
				{
					clone.transform.localPosition = new Vector3 (180, vector.y - 90, 0);
					this.isUserMessage = false;
				}
				else
				{
					clone.transform.localPosition = new Vector3 (0, vector.y - 90, 0);
					this.isUserMessage = true;
				}	
			}
			messageList.Add(clone);
		}
	}
}