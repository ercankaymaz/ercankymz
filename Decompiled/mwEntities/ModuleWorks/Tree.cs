using System;

namespace ModuleWorks;

[Serializable]
public class Tree<T> : TreeNode<T>
{
	public Tree()
	{
	}

	public Tree(Tree<T> other)
		: base((TreeNode<T>)other)
	{
	}

	public bool Empty()
	{
		return GetChildrenBegin() == GetChildrenEnd();
	}

	public TreeChildrenIterator<T> AddElement(T toAdd)
	{
		return AddChild(new TreeNode<T>(toAdd));
	}

	public TreeChildrenIterator<T> AddElement(T toAdd, TreeNode<T> parentElement)
	{
		return parentElement.AddChild(new TreeNode<T>(toAdd));
	}

	public void RemoveElement(TreeChildrenIterator<T> toRemove)
	{
		if (toRemove.GetIterator().Value.GetParent() == null)
		{
			RemoveChild(toRemove);
		}
		else
		{
			toRemove.GetIterator().Value.RemoveChild(toRemove);
		}
	}

	public void ResetTree()
	{
		Reset();
	}

	public TreeChildrenIterator<T> GetElementsBegin()
	{
		return GetChildrenBegin();
	}

	public TreeChildrenIterator<T> GetElementsEnd()
	{
		return GetChildrenEnd();
	}

	public TreeOverallIterator<T> GetOverallElementsBegin()
	{
		return GetOverallBegin();
	}

	public TreeOverallIterator<T> GetOverallElementsEnd()
	{
		return GetOverallEnd();
	}

	public int GetSizeElements()
	{
		return GetSize();
	}
}
