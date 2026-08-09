using System;
using MS.Internal.Features;
using Microsoft.Windows.Design.Features;
using Microsoft.Windows.Design.Model;

namespace Microsoft.Windows.Design.Interaction;

[FeatureConnector(typeof(ParentAdapterFeatureConnector))]
public abstract class ParentAdapter : Adapter
{
	public override Type AdapterType => typeof(ParentAdapter);

	public virtual bool CanParent(ModelItem parent, Type childType)
	{
		if (parent == null)
		{
			throw new ArgumentNullException("parent");
		}
		if ((object)childType == null)
		{
			throw new ArgumentNullException("childType");
		}
		return true;
	}

	public virtual bool IsParent(ModelItem parent, ModelItem child)
	{
		if (parent == null)
		{
			throw new ArgumentNullException("parent");
		}
		if (child == null)
		{
			throw new ArgumentNullException("child");
		}
		return child.Parent == parent;
	}

	public virtual ModelItem RedirectParent(ModelItem parent, Type childType)
	{
		if (parent == null)
		{
			throw new ArgumentNullException("parent");
		}
		if ((object)childType == null)
		{
			throw new ArgumentNullException("childType");
		}
		return parent;
	}

	public virtual void Parent(ModelItem newParent, ModelItem child, int insertionIndex)
	{
		Parent(newParent, child);
	}

	public abstract void Parent(ModelItem newParent, ModelItem child);

	public abstract void RemoveParent(ModelItem currentParent, ModelItem newParent, ModelItem child);
}
