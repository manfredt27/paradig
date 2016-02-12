using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ChatBoxFunctions : MonoBehaviour
{

	//WebService webService;
	string message = "";
	[SerializeField] RectTransform messageParentPanel; // scroll

	[SerializeField] GameObject UserParentPanelPrefab; // user prefab
	[SerializeField] GameObject FutureParentPanelPrefab; // future prefab

	[SerializeField] Text futureTime; // future time
	[SerializeField] Text userTime; // user time

	List<GameObject> messageList = new List<GameObject>();
	bool isEmptyList = true;
	bool isUserMessage = false;
	private int questionId = 0;
	List<AssemblyCSharp.Question> questionsList = new List<AssemblyCSharp.Question>();

	void Start()
	{
		// here we can add questions
		AssemblyCSharp.Question question = new AssemblyCSharp.Question("¿En qué año está:", new string[] {"1. 2012", "2. 2031", "3. 3016", "4. 2016"},3);
		questionsList.Add (question);
		question = new AssemblyCSharp.Question("En ese año, con cuales países y cuerpos de agua colinda Costa Rica, tomando en cuenta los límites marítimos:", 
			new string[] {
				"1. Nicaragua y Panamá, océano Atlántico y el océano Pacífico", 
				"2. Nicaragua, el río San Juan, el océano Atlántico y el océano Pacífico", 
				"3. Nicaragua, Colombia, Ecuador y Panamá, el mar Caribe y el océano Pacífico", 
				"4. Nicaragua, Panamá, la isla del Coco, el mar Caribe y el océano Pacífico"
			},3);
		questionsList.Add (question);
		question = new AssemblyCSharp.Question("La construcción del Teatro Nacional fue financiada por:", 
			new string[] {
				"1. El pueblo, mediante impuestos", 
				"2. Los productores de café, con fondos privados", 
				"3. La unión de visitantes extranjeros, cafetaleros y sembradores de caña", 
				"4. El gobierno"
			},3);
		questionsList.Add (question);
		this.isUserMessage = false;
		this.ShowMessage ();
	}

	public void SetMessage (string pMesssage)
	{
		this.message = pMesssage;
	}

	private AssemblyCSharp.Question getNextQuestion(){
		if (this.questionsList.Count > 0) {
			AssemblyCSharp.Question question = this.questionsList [0];
			return question;
		}
		return new AssemblyCSharp.Question("No hay más preguntas que mostrar", new string[] {""},0);;
	}

	private bool compareAnswer(string pUserAnswer, string pCorrectAnswer)
	{
		return pUserAnswer == pCorrectAnswer;
	}

	public void ShowMessage()
	{
		if (!this.isUserMessage) 
		{
			this.SetMessage (getNextQuestion ().toString ());
		} else 
		{
			if(this.compareAnswer(this.message,this.getNextQuestion().getAnswer().ToString()))
			{
				this.message = "Respuesta correcta";
				questionsList.RemoveAt(0);
			}
			else
			{
				this.message = "Respuesta incorrecta, vuelve a intentarlo";
			}
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
			this.futureTime.text = System.DateTime.UtcNow.ToLocalTime ().ToString("HH:mm");
			this.userTime.text = System.DateTime.UtcNow.ToLocalTime ().ToString("HH:mm");
			clone.transform.SetParent (messageParentPanel); // set new object to parent object
			clone.transform.SetSiblingIndex (messageParentPanel.childCount - 2);
			clone.GetComponent<MessageFunctions> ().ShowMessage (this.message); // set message to new object to show in GUI
			//
			if (this.isEmptyList)
			{
				if (isUserMessage)
				{
					float contentPanelHeight = messageParentPanel.rect.height;
					float clonePanelHeight = clone.transform.Find ("MessagePanel").GetComponent<RectTransform> ().rect.height;

					float buffer = 27;

					clone.transform.localPosition = new Vector3 (0, clonePanelHeight + buffer, 0);
					//clone.transform.localPosition = new Vector3 (0, 0, 0);
					clone.transform.localScale = new Vector3 (0.6899125F,0.2108072F,0.6640406F);
				} 
				else
				{
					clone.transform.localPosition = new Vector3 (98, -35, 0);	
					isUserMessage = true;
					clone.transform.localScale = new Vector3 (0.6899125F, 0.2108072F, 0.6640406F);
					float clonePanelHeight = clone.transform.Find ("MessagePanel").GetComponent<RectTransform> ().rect.height;
					Debug.Log (clonePanelHeight);
					float contentPanelHeight = messageParentPanel.rect.height;
					Debug.Log (contentPanelHeight);
				}
				this.isEmptyList = false;
			}
			else
			{
				Vector3 vector = messageList [messageList.Count - 1].transform.localPosition;
				if (isUserMessage)
				{
					float contentPanelHeight = messageParentPanel.rect.height;
					float clonePanelHeight = clone.transform.Find ("MessagePanel").GetComponent<RectTransform> ().rect.height;
					messageParentPanel.GetComponent<RectTransform> ().sizeDelta = new Vector2 (5000, 400); //example of how to set height of parent (content of scroll view);

					clone.transform.localPosition = new Vector3 (140, vector.y + -25, 0);
					clone.transform.localScale = new Vector3 (0.6899125F, 0.2108072F, 0.6640406F);
					this.isUserMessage = false;
				}
				else
				{
					float contentPanelHeight = messageParentPanel.rect.height;
					float clonePanelHeight = clone.transform.Find ("MessagePanel").GetComponent<RectTransform> ().rect.height;
					Debug.Log (clonePanelHeight);
					messageParentPanel.GetComponent<RectTransform> ().sizeDelta = new Vector2 (5000, 400); //example of how to set height of parent (content of scroll view);

					clone.transform.localPosition = new Vector3 (98, vector.y + -25, 0);
					clone.transform.localScale = new Vector3 (0.6899125F, 0.2108072F, 0.6640406F);
					this.isUserMessage = true;
				}	
			}
			messageList.Add(clone);
		}
	}
}