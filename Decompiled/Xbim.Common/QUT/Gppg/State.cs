using System.Collections.Generic;

namespace QUT.Gppg;

public class State
{
	public int number;

	internal Dictionary<int, int> ParserTable;

	internal Dictionary<int, int> Goto;

	internal int defaultAction;

	public State(int[] actions, int[] goToList)
		: this(actions)
	{
		Goto = new Dictionary<int, int>();
		for (int i = 0; i < goToList.Length; i += 2)
		{
			Goto.Add(goToList[i], goToList[i + 1]);
		}
	}

	public State(int[] actions)
	{
		ParserTable = new Dictionary<int, int>();
		for (int i = 0; i < actions.Length; i += 2)
		{
			ParserTable.Add(actions[i], actions[i + 1]);
		}
	}

	public State(int defaultAction)
	{
		this.defaultAction = defaultAction;
	}

	public State(int defaultAction, int[] goToList)
		: this(defaultAction)
	{
		Goto = new Dictionary<int, int>();
		for (int i = 0; i < goToList.Length; i += 2)
		{
			Goto.Add(goToList[i], goToList[i + 1]);
		}
	}
}
