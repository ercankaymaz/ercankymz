using System;
using System.Collections.Generic;

namespace ModuleWorks;

[Serializable]
public class TreeSiblingIterator<T> : LinkedList<T>
{
	protected TreeChildrenIterator<T> it { get; }

	protected TreeChildrenIterator<T> thisNode { get; }

	public TreeSiblingIterator()
	{
	}

	public TreeSiblingIterator(TreeChildrenIterator<T> ri, TreeChildrenIterator<T> tn)
	{
		it = ri;
		thisNode = tn;
	}

	public TreeChildrenIterator<T> GetIterator()
	{
		return it;
	}

	public TreeChildrenIterator<T> GetNode()
	{
		return thisNode;
	}
}
