using System;
using System.Collections.Generic;

namespace ModuleWorks;

[Serializable]
public class TreeOverallIterator<T> : LinkedList<T>
{
	public struct overallIterationContext
	{
		public LinkedList<TreeNode<T>> contextContainer;

		public LinkedListNode<TreeNode<T>> contextIterator;
	}

	protected overallIterationContext currentContext;

	protected LinkedList<overallIterationContext> hlContext { get; set; }

	public TreeOverallIterator()
	{
	}

	public TreeOverallIterator(LinkedList<TreeNode<T>> list, LinkedListNode<TreeNode<T>> newIt)
	{
		currentContext.contextContainer = list;
		currentContext.contextIterator = newIt;
	}

	public LinkedList<TreeNode<T>> GetContainer()
	{
		return currentContext.contextContainer;
	}

	public LinkedListNode<TreeNode<T>> GetIterator()
	{
		return currentContext.contextIterator;
	}
}
