using UnityEngine;
using System.Collections;

public class Metrics : MonoBehaviour {

	private float totalTime = 0.0f;
	private bool isTimerRunning;

	void Update () 
	{
		if (isTimerRunning) 
		{
			Timer ();
		}
	}

	public void StartTimer()
	{
		totalTime = 0.0f;
		isTimerRunning = true;
	}

	public void StopTimer()
	{
		isTimerRunning = false;
	}

	private void Timer()
	{
		totalTime += Time.deltaTime;
		Debug.Log (totalTime);
	}

	public float getTotalTime()
	{
		Debug.Log (totalTime);
		return totalTime;
	}
}
