using System;
using System.Linq;

namespace Xceed.Wpf.AvalonDock.Layout.Serialization;

public abstract class LayoutSerializer
{
	private DockingManager _manager;

	private LayoutAnchorable[] _previousAnchorables;

	private LayoutDocument[] _previousDocuments;

	public DockingManager Manager => _manager;

	public event EventHandler<LayoutSerializationCallbackEventArgs> LayoutSerializationCallback;

	public LayoutSerializer(DockingManager manager)
	{
		if (manager == null)
		{
			throw new ArgumentNullException("manager");
		}
		_manager = manager;
		_previousAnchorables = _manager.Layout.Descendents().OfType<LayoutAnchorable>().ToArray();
		_previousDocuments = _manager.Layout.Descendents().OfType<LayoutDocument>().ToArray();
	}

	protected virtual void FixupLayout(LayoutRoot layout)
	{
		foreach (ILayoutPreviousContainer lcToAttach in from lc in layout.Descendents().OfType<ILayoutPreviousContainer>()
			where lc.PreviousContainerId != null
			select lc)
		{
			ILayoutPaneSerializable layoutPaneSerializable = layout.Descendents().OfType<ILayoutPaneSerializable>().FirstOrDefault((ILayoutPaneSerializable lps) => lps.Id == lcToAttach.PreviousContainerId);
			if (layoutPaneSerializable == null)
			{
				throw new ArgumentException($"Unable to find a pane with id ='{lcToAttach.PreviousContainerId}'");
			}
			lcToAttach.PreviousContainer = layoutPaneSerializable as ILayoutContainer;
		}
		foreach (ILayoutInitialContainer lcToAttach2 in from lc in layout.Descendents().OfType<ILayoutInitialContainer>()
			where lc.InitialContainerId != null
			select lc)
		{
			ILayoutPaneSerializable layoutPaneSerializable2 = layout.Descendents().OfType<ILayoutPaneSerializable>().FirstOrDefault((ILayoutPaneSerializable lps) => lps.Id == lcToAttach2.InitialContainerId);
			if (layoutPaneSerializable2 == null)
			{
				throw new ArgumentException($"Unable to find a pane with id ='{lcToAttach2.InitialContainerId}'");
			}
			lcToAttach2.InitialContainer = layoutPaneSerializable2 as ILayoutContainer;
		}
		LayoutAnchorable[] array = (from lc in layout.Descendents().OfType<LayoutAnchorable>()
			where lc.Content == null
			select lc).ToArray();
		foreach (LayoutAnchorable lcToFix in array)
		{
			LayoutAnchorable layoutAnchorable = null;
			if (lcToFix.ContentId != null)
			{
				layoutAnchorable = _previousAnchorables.FirstOrDefault((LayoutAnchorable a) => a.ContentId == lcToFix.ContentId);
			}
			if (this.LayoutSerializationCallback != null)
			{
				LayoutSerializationCallbackEventArgs e = new LayoutSerializationCallbackEventArgs(lcToFix, layoutAnchorable?.Content);
				this.LayoutSerializationCallback(this, e);
				if (e.Cancel)
				{
					lcToFix.Close();
				}
				else if (e.Content != null)
				{
					lcToFix.Content = e.Content;
				}
				else if (e.Model.Content != null)
				{
					lcToFix.Hide(cancelable: false);
				}
			}
			else if (layoutAnchorable == null)
			{
				lcToFix.Hide(cancelable: false);
			}
			else
			{
				lcToFix.Content = layoutAnchorable.Content;
				lcToFix.IconSource = layoutAnchorable.IconSource;
			}
		}
		LayoutDocument[] array2 = (from lc in layout.Descendents().OfType<LayoutDocument>()
			where lc.Content == null
			select lc).ToArray();
		foreach (LayoutDocument lcToFix2 in array2)
		{
			LayoutDocument layoutDocument = null;
			if (lcToFix2.ContentId != null)
			{
				layoutDocument = _previousDocuments.FirstOrDefault((LayoutDocument a) => a.ContentId == lcToFix2.ContentId);
			}
			if (this.LayoutSerializationCallback != null)
			{
				LayoutSerializationCallbackEventArgs e2 = new LayoutSerializationCallbackEventArgs(lcToFix2, layoutDocument?.Content);
				this.LayoutSerializationCallback(this, e2);
				if (e2.Cancel)
				{
					lcToFix2.Close();
				}
				else if (e2.Content != null)
				{
					lcToFix2.Content = e2.Content;
				}
				else if (e2.Model.Content != null)
				{
					lcToFix2.Close();
				}
			}
			else if (layoutDocument == null)
			{
				lcToFix2.Close();
			}
			else
			{
				lcToFix2.Content = layoutDocument.Content;
				lcToFix2.IconSource = layoutDocument.IconSource;
			}
		}
		layout.CollectGarbage();
	}

	protected void StartDeserialization()
	{
		Manager.SuspendDocumentsSourceBinding = true;
		Manager.SuspendAnchorablesSourceBinding = true;
	}

	protected void EndDeserialization()
	{
		Manager.SuspendDocumentsSourceBinding = false;
		Manager.SuspendAnchorablesSourceBinding = false;
	}
}
