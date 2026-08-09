using System;
using System.Collections.Generic;

namespace ModuleWorks;

[Serializable]
public class TreeNode<T>
{
	protected LinkedList<TreeNode<T>> children { get; set; }

	protected T element { get; set; }

	protected TreeNode<T> parent { get; set; }

	protected LinkedListNode<TreeNode<T>> thisNode { get; set; }

	public TreeNode()
	{
		children = new LinkedList<TreeNode<T>>();
		parent = null;
		thisNode = new LinkedListNode<TreeNode<T>>(this);
	}

	public TreeNode(T element)
	{
		children = new LinkedList<TreeNode<T>>();
		this.element = element;
		parent = null;
		thisNode = new LinkedListNode<TreeNode<T>>(this);
	}

	public TreeNode(TreeNode<T> other)
	{
		children = other.children;
		element = other.element;
		parent = other.parent;
		thisNode = other.thisNode;
	}

	public TreeChildrenIterator<T> GetChildrenBegin()
	{
		if (children != null)
		{
			return new TreeChildrenIterator<T>(children.First);
		}
		return new TreeChildrenIterator<T>();
	}

	public TreeChildrenIterator<T> GetChildrenEnd()
	{
		if (children != null)
		{
			return new TreeChildrenIterator<T>(children.Last);
		}
		return new TreeChildrenIterator<T>();
	}

	public LinkedList<TreeNode<T>> GetChildren()
	{
		return children;
	}

	public TreeSiblingIterator<T> GetSiblingsBegin()
	{
		if (parent != null)
		{
			return new TreeSiblingIterator<T>(parent.GetChildrenBegin(), new TreeChildrenIterator<T>(thisNode));
		}
		return new TreeSiblingIterator<T>();
	}

	public TreeSiblingIterator<T> GetSiblingsEnd()
	{
		if (parent != null)
		{
			return new TreeSiblingIterator<T>(parent.GetChildrenEnd(), new TreeChildrenIterator<T>(thisNode));
		}
		return new TreeSiblingIterator<T>();
	}

	public TreeOverallIterator<T> GetOverallBegin()
	{
		return new TreeOverallIterator<T>(children, children.First);
	}

	public TreeOverallIterator<T> GetOverallEnd()
	{
		return new TreeOverallIterator<T>(children, children.Last);
	}

	public TreeChildrenIterator<T> AddChild(TreeNode<T> child)
	{
		LinkedListNode<TreeNode<T>> ri = new LinkedListNode<TreeNode<T>>(child);
		if (children != null)
		{
			ri = children.AddLast(child);
		}
		child.parent = this;
		child.thisNode = ri;
		return new TreeChildrenIterator<T>(ri);
	}

	public void RemoveChild(TreeChildrenIterator<T> toRemove)
	{
		children.Remove(toRemove.GetIterator());
	}

	public bool EmptyNode()
	{
		return GetChildrenBegin() == GetChildrenEnd();
	}

	public void Reset()
	{
		if (children != null)
		{
			children.Clear();
		}
	}

	public int GetSize()
	{
		return children.Count;
	}

	public T GetElement()
	{
		return element;
	}

	public void SetElement(T element)
	{
		this.element = element;
	}

	public TreeNode<T> GetParent()
	{
		return parent;
	}

	public void SetParent(TreeNode<T> parent)
	{
		this.parent = parent;
	}

	public LinkedListNode<TreeNode<T>> GetThisNode()
	{
		return thisNode;
	}

	public void SetThisNode(LinkedListNode<TreeNode<T>> thisNode)
	{
		this.thisNode = thisNode;
	}
}
