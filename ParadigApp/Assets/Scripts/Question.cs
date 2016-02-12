using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class Question
	{
		private string question;
		private string[] options;
		private int answer;

		public Question (string pQuestion, string[] pOptions, int pAnswer)
		{
			this.question = pQuestion;
			this.options = pOptions;
			this.answer = pAnswer;
		}

		public string getQuestion()
		{
			return this.question;
		}

		public void setQuestion(string pQuestion)
		{
			this.question = pQuestion;
		}

		public string[] getOptions()
		{
			return this.options;
		}

		public void setOptions(string[] pOptions)
		{
			this.options = pOptions;
		}

		public int getAnswer()
		{
			return this.answer;
		}

		public void setAnswer(int pAnswer)
		{
			this.answer = pAnswer;
		}

		public string toString(){
			string result = this.question;
			foreach (string option in options) 
			{
				result += "\n"+option;
			}
			return result;
		}
	}
}