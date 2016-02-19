using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class Metrics
	{
		public bool rightAnswer { get; set; }
		public float totalTime { get; set; }
		private bool isTimerRunning;

		public void StartTimer()
		{
			totalTime += Time.deltaTime;
			isTimerRunning = true;
		}

		public void StopTimer()
		{
			isTimerRunning = false;
		}
	}
}