using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class Question
	{
		private string question;
		private string[] options;
		private int answer;

		public Question (string question, string[] options, int answer)
		{
			this.question = question;
			this.options = options;
			this.answer = answer;
		}

		override public string ToString()
		{
			string result = this.question;
			foreach (string option in options) 
			{
				result += "\n"+option;
			}
			return result;
		}

		public bool CompareAnswer(string userAnswer)
		{
			return this.answer.ToString() == userAnswer;
		}
	}
}