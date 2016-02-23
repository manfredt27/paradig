using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ChatBoxFunctions : MonoBehaviour
{ 
	[SerializeField] RectTransform messageParentPanel; // scroll
	[SerializeField] ScrollRect scrollRect;
	[SerializeField] GameObject UserParentPanelPrefab; // user prefab
	[SerializeField] GameObject FutureParentPanelPrefab; // future prefab
	[SerializeField] GameObject BadgeParentPanelPrefab;
	[SerializeField] Text futureTime; // future time
	[SerializeField] Text userTime; // user time


	private string message = string.Empty;
	private List<GameObject> messageList = new List<GameObject>();
	private bool isUserMessage = false;
	private float lastHeight = 0;
	private List<AssemblyCSharp.Question> questionsList = new List<AssemblyCSharp.Question>();
	private AssemblyCSharp.Metrics metrics = new AssemblyCSharp.Metrics();
	private AssemblyCSharp.ChangeScene changeScene = new AssemblyCSharp.ChangeScene ();
	private WebService webService;
	private int rightAnswers = 0;

	void Start()
	{
		messageParentPanel.GetComponent<RectTransform> ().sizeDelta = new Vector2 (400, 100);
		this.metrics.rightAnswer = true;
		webService = gameObject.AddComponent (typeof(WebService)) as WebService;
		// here we can add questions
		// question #1
		AssemblyCSharp.Question question = new AssemblyCSharp.Question("¿En qué año está:", new string[] {"1. 2012", "2. 2031", "3. 3016", "4. 2016"},3);
		questionsList.Add (question);

		// question #2
		question = new AssemblyCSharp.Question("En ese año, con cuales países y cuerpos de agua colinda Costa Rica, tomando en cuenta los límites marítimos:", 
			new string[] {
				"1. Nicaragua y Panamá, océano Atlántico y el océano Pacífico", 
				"2. Nicaragua, el río San Juan, el océano Atlántico y el océano Pacífico", 
				"3. Nicaragua, Colombia, Ecuador y Panamá, el mar Caribe y el océano Pacífico", 
				"4. Nicaragua, Panamá, la isla del Coco, el mar Caribe y el océano Pacífico"
			},3);
		questionsList.Add (question);

		// question #3
		question = new AssemblyCSharp.Question("La construcción del Teatro Nacional fue financiada por:", 
			new string[] {
				"1. El pueblo, mediante impuestos", 
				"2. Los productores de café, con fondos privados", 
				"3. La unión de visitantes extranjeros, cafetaleros y sembradores de caña", 
				"4. El gobierno"
			},3);
		questionsList.Add (question);
		this.CreateMessage (this.GetNextQuestion().ToString()); // to show the first question
	}

	private void ScrollToBottom()
	{
		scrollRect.normalizedPosition = new Vector2 (0, 0); // 0,0 means bottom
	}

	public void SetMessage (string messsage)
	{
		this.message = messsage;
	}

	private AssemblyCSharp.Question GetNextQuestion(){
		if (this.questionsList.Count > 0)
		{
			this.metrics.StartTimer ();
			return this.questionsList [0];
		}
		Debug.Log ("TERMINA cantidad de respuestas correctas " + this.rightAnswers.ToString());
		if (this.rightAnswers == 3) {
			GameObject clone;
			clone = (GameObject)Instantiate (BadgeParentPanelPrefab); // new Object 
			clone.transform.SetParent (messageParentPanel); // set new object to parent object
			clone.transform.SetSiblingIndex (messageParentPanel.childCount - 2);
			DrawClone (this.isUserMessage, clone, 200, this.GetLastYPosition() + -45);
			clone.transform.localScale = new Vector3 (1F, 1F, 1F);
			this.ScrollToBottom ();
		}
		this.webService.Send ("userNameSample", this.rightAnswers.ToString(), this.metrics.totalTime.ToString()); // send info to webservice
		//this.changeScene.ChangeToScene("Congratulations");
		return new AssemblyCSharp.Question("No hay más preguntas que mostrar", new string[] {string.Empty},0);;
	}

	private void IncreaseRightAnswer()
	{
		if (this.metrics.rightAnswer)
			this.rightAnswers++;
	}

	public void ShowMessage()
	{
		if (this.message != string.Empty)
		{
			this.CreateMessage (this.message);
			if (this.GetNextQuestion ().CompareAnswer (this.message))
			{
				this.metrics.StopTimer ();
				Debug.Log ("timer despues de respuesta correcta" + (this.metrics.totalTime).ToString ());
				//this.metrics.totalTime = 0; // clear timer
				Debug.Log ("la respuesta estuvo " + this.metrics.rightAnswer.ToString ());
				IncreaseRightAnswer ();
				this.metrics.rightAnswer = true;

				this.isUserMessage = false;
				this.CreateMessage ("Respuesta correcta");
				questionsList.RemoveAt (0);// delete question of list
				this.isUserMessage = false;
				this.CreateMessage (this.GetNextQuestion().ToString());
			} else
			{
				this.metrics.rightAnswer = false;
				Debug.Log ("timer en respuesta incorrecta" + this.metrics.totalTime.ToString ());
				this.isUserMessage = false;
				this.CreateMessage ("Respuesta incorrecta, vuelve a intentarlo");
			}
		}
	}

	private void CreateMessage(string message)
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
		this.futureTime.text = System.DateTime.UtcNow.ToLocalTime ().ToString("HH:mm"); //set time
		this.userTime.text = System.DateTime.UtcNow.ToLocalTime ().ToString("HH:mm");
		clone.transform.SetParent (messageParentPanel); // set new object to parent object
		clone.transform.SetSiblingIndex (messageParentPanel.childCount - 2);
		clone.GetComponent<MessageFunctions> ().ShowMessage (message); // set message to new object to show in GUI
		if (isUserMessage)
		{
			DrawClone (this.isUserMessage, clone, 140, this.GetLastYPosition() - 15);
		}
		else
		{
			DrawClone (this.isUserMessage, clone, 98, this.GetLastYPosition() + -25);
		}	
		this.messageList.Add(clone);
		this.ScrollToBottom ();
	}

	private float GetLastYPosition()
	{
		if (messageList.Count > 0)
		{
			this.lastHeight = messageList [messageList.Count - 1].transform.FindChild ("MessagePanel").transform.GetComponent<RectTransform>().rect.height / 8;
			return messageList [messageList.Count - 1].transform.localPosition.y;
		}
		return -10; // static position to show the first future message
	}

	private void DrawClone(bool isUserMessage, GameObject clone, float x, float y)
	{
		messageParentPanel.GetComponent<RectTransform> ().sizeDelta = new Vector2 (400, messageParentPanel.GetComponent<RectTransform> ().sizeDelta.y + this.lastHeight + 20);
		clone.transform.localPosition = new Vector3 (x, y - this.lastHeight, 0);
		clone.transform.localScale = new Vector3 (0.6899125F, 0.2108072F, 0.6640406F);
		this.isUserMessage = !isUserMessage;
	}
}