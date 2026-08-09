using System;
using System.Collections.Generic;

namespace ModuleWorks;

[Serializable]
public class TreeChildrenIterator<T> : LinkedList<T>
{
	protected bool isNull { get; set; }

	protected LinkedListNode<TreeNode<T>> it { get; }

	public TreeChildrenIterator()
	{
		isNull = true;
	}

	public TreeChildrenIterator(LinkedListNode<TreeNode<T>> ri)
	{
		isNull = false;
		it = ri;
	}

	public LinkedListNode<TreeNode<T>> GetIterator()
	{
		return it;
	}
}
