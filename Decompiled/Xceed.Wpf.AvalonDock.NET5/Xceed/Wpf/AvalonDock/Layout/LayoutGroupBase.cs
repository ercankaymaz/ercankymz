using System;
using System.Xml.Serialization;

namespace Xceed.Wpf.AvalonDock.Layout;

[Serializable]
public abstract class LayoutGroupBase : LayoutElement
{
	[field: NonSerialized]
	[field: XmlIgnore]
	public event EventHandler ChildrenCollectionChanged;

	[field: NonSerialized]
	[field: XmlIgnore]
	public event EventHandler<ChildrenTreeChangedEventArgs> ChildrenTreeChanged;

	protected virtual void OnChildrenCollectionChanged()
	{
		if (this.ChildrenCollectionChanged != null)
		{
			this.ChildrenCollectionChanged(this, EventArgs.Empty);
		}
	}

	protected void NotifyChildrenTreeChanged(ChildrenTreeChange change)
	{
		OnChildrenTreeChanged(change);
		if (base.Parent is LayoutGroupBase layoutGroupBase)
		{
			layoutGroupBase.NotifyChildrenTreeChanged(ChildrenTreeChange.TreeChanged);
		}
	}

	protected virtual void OnChildrenTreeChanged(ChildrenTreeChange change)
	{
		if (this.ChildrenTreeChanged != null)
		{
			this.ChildrenTreeChanged(this, new ChildrenTreeChangedEventArgs(change));
		}
	}
}
