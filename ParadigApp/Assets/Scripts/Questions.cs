using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class Questions
	{
		private List<Questions> questionsList = new List<Questions>();
		public string question;
		public string optionA;
		public string optionB;
		public string optionC;
		public string optionD;
		public string answer;

		public Questions ()
		{
		}

		public void createQuestion (string pQuestion, string pOptionA, string pOptionB, string pOptionC, string pOptionD, string pAnswer)
		{
			this.question = pQuestion;
			this.optionA = pOptionA;
			this.optionB = pOptionB;
			this.optionC = pOptionC;
			this.optionD = pOptionD;
			this.answer = pAnswer;
		}

		public void addQuestion(Questions pQuestion)
		{
			questionsList.Add (pQuestion);
		}

		public List<Questions> getQuestions()
		{
			return questionsList;
		}

		public Questions getQuestion(int pId)
		{
			return questionsList [pId];
		}
			
	}
}

