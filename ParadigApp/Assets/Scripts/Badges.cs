using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Badges : MonoBehaviour
{
	[SerializeField] RectTransform badgesParentPanel; // scroll
	[SerializeField] GameObject badgePrefab; 

	public Texture aTexture;

	// Use this for initialization
	void Start () {
		badgesParentPanel.GetComponent<RectTransform> ().sizeDelta = new Vector2 (400, 100);

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void createBagde()
	{
		GameObject clone;
		clone = (GameObject)Instantiate (badgePrefab); // new Object 
		clone.transform.SetParent (badgesParentPanel); // set new object to parent object
		clone.transform.SetSiblingIndex (badgesParentPanel.childCount - 2);
		DrawClone (clone, 98, 85);
	}

	private void DrawClone(GameObject clone, float x, float y)
	{
		badgesParentPanel.GetComponent<RectTransform> ().sizeDelta = new Vector2 (400, badgesParentPanel.GetComponent<RectTransform> ().sizeDelta.y + 20);
		clone.transform.localPosition = new Vector3 (x, y, 0);
		clone.transform.localScale = new Vector3 (1F, 1F,1F);
	}
}
