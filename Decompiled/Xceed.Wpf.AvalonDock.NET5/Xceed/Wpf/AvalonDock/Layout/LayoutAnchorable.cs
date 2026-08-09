#define TRACE
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using System.Xml.Serialization;

namespace Xceed.Wpf.AvalonDock.Layout;

[Serializable]
public class LayoutAnchorable : LayoutContent
{
	private double _autohideWidth;

	private double _autohideMinWidth = 100.0;

	private double _autohideHeight;

	private double _autohideMinHeight = 100.0;

	private bool _canHide = true;

	private bool _canAutoHide = true;

	private bool _canDockAsTabbedDocument = true;

	private bool _canCloseValueBeforeInternalSet;

	public double AutoHideWidth
	{
		get
		{
			return _autohideWidth;
		}
		set
		{
			if (_autohideWidth != value)
			{
				RaisePropertyChanging("AutoHideWidth");
				value = Math.Max(value, _autohideMinWidth);
				_autohideWidth = value;
				RaisePropertyChanged("AutoHideWidth");
			}
		}
	}

	public double AutoHideMinWidth
	{
		get
		{
			return _autohideMinWidth;
		}
		set
		{
			if (_autohideMinWidth != value)
			{
				RaisePropertyChanging("AutoHideMinWidth");
				if (value < 0.0)
				{
					throw new ArgumentException("value");
				}
				_autohideMinWidth = value;
				RaisePropertyChanged("AutoHideMinWidth");
			}
		}
	}

	public double AutoHideHeight
	{
		get
		{
			return _autohideHeight;
		}
		set
		{
			if (_autohideHeight != value)
			{
				RaisePropertyChanging("AutoHideHeight");
				value = Math.Max(value, _autohideMinHeight);
				_autohideHeight = value;
				RaisePropertyChanged("AutoHideHeight");
			}
		}
	}

	public double AutoHideMinHeight
	{
		get
		{
			return _autohideMinHeight;
		}
		set
		{
			if (_autohideMinHeight != value)
			{
				RaisePropertyChanging("AutoHideMinHeight");
				if (value < 0.0)
				{
					throw new ArgumentException("value");
				}
				_autohideMinHeight = value;
				RaisePropertyChanged("AutoHideMinHeight");
			}
		}
	}

	public bool CanHide
	{
		get
		{
			return _canHide;
		}
		set
		{
			if (_canHide != value)
			{
				_canHide = value;
				RaisePropertyChanged("CanHide");
			}
		}
	}

	public bool CanAutoHide
	{
		get
		{
			return _canAutoHide;
		}
		set
		{
			if (_canAutoHide != value)
			{
				_canAutoHide = value;
				RaisePropertyChanged("CanAutoHide");
			}
		}
	}

	public bool CanDockAsTabbedDocument
	{
		get
		{
			return _canDockAsTabbedDocument;
		}
		set
		{
			if (_canDockAsTabbedDocument != value)
			{
				_canDockAsTabbedDocument = value;
				RaisePropertyChanged("CanDockAsTabbedDocument");
			}
		}
	}

	public bool IsAutoHidden
	{
		get
		{
			if (base.Parent != null)
			{
				return base.Parent is LayoutAnchorGroup;
			}
			return false;
		}
	}

	[XmlIgnore]
	public bool IsHidden => base.Parent is LayoutRoot;

	[XmlIgnore]
	public bool IsVisible
	{
		get
		{
			if (base.Parent != null)
			{
				return !(base.Parent is LayoutRoot);
			}
			return false;
		}
		set
		{
			if (value)
			{
				Show();
			}
			else
			{
				Hide();
			}
		}
	}

	public event EventHandler IsVisibleChanged;

	public event EventHandler<CancelEventArgs> Hiding;

	public event EventHandler Hidden;

	public LayoutAnchorable()
	{
		_canClose = false;
	}

	protected override void OnParentChanged(ILayoutContainer oldValue, ILayoutContainer newValue)
	{
		UpdateParentVisibility();
		RaisePropertyChanged("IsVisible");
		NotifyIsVisibleChanged();
		RaisePropertyChanged("IsHidden");
		RaisePropertyChanged("IsAutoHidden");
		base.OnParentChanged(oldValue, newValue);
	}

	protected override void InternalDock()
	{
		LayoutRoot layoutRoot = base.Root as LayoutRoot;
		ILayoutPane layoutPane = null;
		if (layoutRoot.ActiveContent != null && layoutRoot.ActiveContent != this)
		{
			layoutPane = layoutRoot.ActiveContent.Parent as LayoutAnchorablePane;
		}
		if (layoutPane == null)
		{
			layoutPane = (from pane in layoutRoot.Descendents().OfType<LayoutAnchorablePane>()
				where !pane.IsHostedInFloatingWindow && pane.GetSide() == AnchorSide.Right
				select pane).FirstOrDefault();
		}
		if (layoutPane == null)
		{
			layoutPane = (from pane in layoutRoot.Descendents().OfType<LayoutAnchorablePane>()
				where !pane.IsHostedInFloatingWindow
				select pane).FirstOrDefault();
		}
		if (layoutPane == null)
		{
			layoutPane = layoutRoot.Descendents().OfType<LayoutDocumentPane>().FirstOrDefault();
		}
		bool flag = false;
		if (layoutRoot.Manager.LayoutUpdateStrategy != null)
		{
			flag = layoutRoot.Manager.LayoutUpdateStrategy.BeforeInsertAnchorable(layoutRoot, this, layoutPane);
		}
		if (!flag)
		{
			if (layoutPane == null)
			{
				LayoutPanel layoutPanel = new LayoutPanel
				{
					Orientation = Orientation.Horizontal
				};
				if (layoutRoot.RootPanel != null)
				{
					layoutPanel.Children.Add(layoutRoot.RootPanel);
				}
				layoutRoot.RootPanel = layoutPanel;
				layoutPane = new LayoutAnchorablePane
				{
					DockWidth = new GridLength(200.0, GridUnitType.Pixel)
				};
				layoutPanel.Children.Add((ILayoutPanelElement)layoutPane);
			}
			if (layoutPane is LayoutAnchorablePane)
			{
				(layoutPane as LayoutAnchorablePane).Children.Add(this);
			}
			else
			{
				(layoutPane as LayoutDocumentPane).Children.Add(this);
			}
			flag = true;
		}
		if (layoutRoot.Manager.LayoutUpdateStrategy != null)
		{
			layoutRoot.Manager.LayoutUpdateStrategy.AfterInsertAnchorable(layoutRoot, this);
		}
		base.InternalDock();
	}

	public override void ReadXml(XmlReader reader)
	{
		if (reader.MoveToAttribute("CanHide"))
		{
			CanHide = bool.Parse(reader.Value);
		}
		if (reader.MoveToAttribute("CanAutoHide"))
		{
			CanAutoHide = bool.Parse(reader.Value);
		}
		if (reader.MoveToAttribute("AutoHideWidth"))
		{
			AutoHideWidth = double.Parse(reader.Value, CultureInfo.InvariantCulture);
		}
		if (reader.MoveToAttribute("AutoHideHeight"))
		{
			AutoHideHeight = double.Parse(reader.Value, CultureInfo.InvariantCulture);
		}
		if (reader.MoveToAttribute("AutoHideMinWidth"))
		{
			AutoHideMinWidth = double.Parse(reader.Value, CultureInfo.InvariantCulture);
		}
		if (reader.MoveToAttribute("AutoHideMinHeight"))
		{
			AutoHideMinHeight = double.Parse(reader.Value, CultureInfo.InvariantCulture);
		}
		if (reader.MoveToAttribute("CanDockAsTabbedDocument"))
		{
			CanDockAsTabbedDocument = bool.Parse(reader.Value);
		}
		base.ReadXml(reader);
	}

	public override void WriteXml(XmlWriter writer)
	{
		if (!CanHide)
		{
			writer.WriteAttributeString("CanHide", CanHide.ToString());
		}
		if (!CanAutoHide)
		{
			writer.WriteAttributeString("CanAutoHide", CanAutoHide.ToString(CultureInfo.InvariantCulture));
		}
		if (AutoHideWidth > 0.0)
		{
			writer.WriteAttributeString("AutoHideWidth", AutoHideWidth.ToString(CultureInfo.InvariantCulture));
		}
		if (AutoHideHeight > 0.0)
		{
			writer.WriteAttributeString("AutoHideHeight", AutoHideHeight.ToString(CultureInfo.InvariantCulture));
		}
		if (AutoHideMinWidth != 25.0)
		{
			writer.WriteAttributeString("AutoHideMinWidth", AutoHideMinWidth.ToString(CultureInfo.InvariantCulture));
		}
		if (AutoHideMinHeight != 25.0)
		{
			writer.WriteAttributeString("AutoHideMinHeight", AutoHideMinHeight.ToString(CultureInfo.InvariantCulture));
		}
		if (!CanDockAsTabbedDocument)
		{
			writer.WriteAttributeString("CanDockAsTabbedDocument", CanDockAsTabbedDocument.ToString(CultureInfo.InvariantCulture));
		}
		base.WriteXml(writer);
	}

	public override void Close()
	{
		CloseAnchorable();
	}

	public override void ConsoleDump(int tab)
	{
		Trace.Write(new string(' ', tab * 4));
		Trace.WriteLine("Anchorable()");
	}

	public void Hide(bool cancelable = true)
	{
		if (!IsVisible)
		{
			base.IsSelected = true;
			base.IsActive = true;
			return;
		}
		if (cancelable)
		{
			CancelEventArgs e = new CancelEventArgs();
			OnHiding(e);
			if (e.Cancel)
			{
				return;
			}
		}
		RaisePropertyChanging("IsHidden");
		RaisePropertyChanging("IsVisible");
		base.InitialContainer = base.PreviousContainer as ILayoutPane;
		base.InitialContainerIndex = base.PreviousContainerIndex;
		base.InitialContainerId = base.PreviousContainerId;
		ILayoutGroup layoutGroup = (ILayoutGroup)(base.PreviousContainer = base.Parent as ILayoutGroup);
		if (layoutGroup != null)
		{
			base.PreviousContainerIndex = layoutGroup.IndexOfChild(this);
		}
		if (base.Root != null)
		{
			base.Root.Hidden.Add(this);
		}
		RaisePropertyChanged("IsVisible");
		RaisePropertyChanged("IsHidden");
		NotifyIsVisibleChanged();
		OnHidden();
	}

	public void Show()
	{
		if (IsVisible)
		{
			return;
		}
		if (!IsHidden)
		{
			throw new InvalidOperationException();
		}
		RaisePropertyChanging("IsHidden");
		RaisePropertyChanging("IsVisible");
		bool flag = false;
		ILayoutRoot root = base.Root;
		if (root != null && root.Manager != null && root.Manager.LayoutUpdateStrategy != null)
		{
			flag = root.Manager.LayoutUpdateStrategy.BeforeInsertAnchorable(root as LayoutRoot, this, base.PreviousContainer);
		}
		if (!flag && base.PreviousContainer != null)
		{
			ILayoutGroup layoutGroup = base.PreviousContainer as ILayoutGroup;
			if (base.PreviousContainerIndex < layoutGroup.ChildrenCount)
			{
				layoutGroup.InsertChildAt(base.PreviousContainerIndex, this);
			}
			else
			{
				layoutGroup.InsertChildAt(layoutGroup.ChildrenCount, this);
			}
			base.IsSelected = true;
			base.IsActive = true;
		}
		if (root != null && root.Manager != null && root.Manager.LayoutUpdateStrategy != null)
		{
			root.Manager.LayoutUpdateStrategy.AfterInsertAnchorable(root as LayoutRoot, this);
		}
		base.PreviousContainer = ((base.InitialContainer != null) ? base.InitialContainer : null);
		base.PreviousContainerIndex = ((base.InitialContainerIndex != -1) ? base.InitialContainerIndex : (-1));
		base.InitialContainer = null;
		base.InitialContainerIndex = -1;
		base.InitialContainerId = null;
		RaisePropertyChanged("IsVisible");
		RaisePropertyChanged("IsHidden");
		NotifyIsVisibleChanged();
	}

	public void AddToLayout(DockingManager manager, AnchorableShowStrategy strategy)
	{
		if (IsVisible || IsHidden)
		{
			throw new InvalidOperationException();
		}
		bool flag = (strategy & AnchorableShowStrategy.Most) == AnchorableShowStrategy.Most;
		bool flag2 = (strategy & AnchorableShowStrategy.Left) == AnchorableShowStrategy.Left;
		bool flag3 = (strategy & AnchorableShowStrategy.Right) == AnchorableShowStrategy.Right;
		bool flag4 = (strategy & AnchorableShowStrategy.Top) == AnchorableShowStrategy.Top;
		bool flag5 = (strategy & AnchorableShowStrategy.Bottom) == AnchorableShowStrategy.Bottom;
		if (!flag)
		{
			AnchorSide side = AnchorSide.Left;
			if (flag2)
			{
				side = AnchorSide.Left;
			}
			if (flag3)
			{
				side = AnchorSide.Right;
			}
			if (flag4)
			{
				side = AnchorSide.Top;
			}
			if (flag5)
			{
				side = AnchorSide.Bottom;
			}
			LayoutAnchorablePane layoutAnchorablePane = manager.Layout.Descendents().OfType<LayoutAnchorablePane>().FirstOrDefault((LayoutAnchorablePane p) => p.GetSide() == side);
			if (layoutAnchorablePane != null)
			{
				layoutAnchorablePane.Children.Add(this);
			}
			else
			{
				flag = true;
			}
		}
		if (!flag)
		{
			return;
		}
		if (manager.Layout.RootPanel == null)
		{
			manager.Layout.RootPanel = new LayoutPanel
			{
				Orientation = ((!(flag2 || flag3)) ? Orientation.Vertical : Orientation.Horizontal)
			};
		}
		if (flag2 || flag3)
		{
			if (manager.Layout.RootPanel.Orientation == Orientation.Vertical && manager.Layout.RootPanel.ChildrenCount > 1)
			{
				manager.Layout.RootPanel = new LayoutPanel(manager.Layout.RootPanel);
			}
			manager.Layout.RootPanel.Orientation = Orientation.Horizontal;
			if (flag2)
			{
				manager.Layout.RootPanel.Children.Insert(0, new LayoutAnchorablePane(this));
			}
			else
			{
				manager.Layout.RootPanel.Children.Add(new LayoutAnchorablePane(this));
			}
		}
		else
		{
			if (manager.Layout.RootPanel.Orientation == Orientation.Horizontal && manager.Layout.RootPanel.ChildrenCount > 1)
			{
				manager.Layout.RootPanel = new LayoutPanel(manager.Layout.RootPanel);
			}
			manager.Layout.RootPanel.Orientation = Orientation.Vertical;
			if (flag4)
			{
				manager.Layout.RootPanel.Children.Insert(0, new LayoutAnchorablePane(this));
			}
			else
			{
				manager.Layout.RootPanel.Children.Add(new LayoutAnchorablePane(this));
			}
		}
	}

	public void ToggleAutoHide()
	{
		if (IsAutoHidden)
		{
			LayoutAnchorGroup parentGroup = base.Parent as LayoutAnchorGroup;
			LayoutAnchorSide layoutAnchorSide = parentGroup.Parent as LayoutAnchorSide;
			LayoutAnchorablePane layoutAnchorablePane = ((ILayoutPreviousContainer)parentGroup).PreviousContainer as LayoutAnchorablePane;
			LayoutRoot layoutRoot = parentGroup.Root as LayoutRoot;
			if (layoutAnchorablePane == null)
			{
				switch ((parentGroup.Parent as LayoutAnchorSide).Side)
				{
				case AnchorSide.Right:
				{
					if (parentGroup.Root.RootPanel.Orientation == Orientation.Horizontal)
					{
						layoutAnchorablePane = new LayoutAnchorablePane();
						layoutAnchorablePane.DockMinWidth = AutoHideMinWidth;
						parentGroup.Root.RootPanel.Children.Add(layoutAnchorablePane);
						break;
					}
					layoutAnchorablePane = new LayoutAnchorablePane();
					LayoutPanel layoutPanel3 = new LayoutPanel
					{
						Orientation = Orientation.Horizontal
					};
					LayoutPanel rootPanel3 = parentGroup.Root.RootPanel;
					layoutRoot.RootPanel = layoutPanel3;
					layoutPanel3.Children.Add(rootPanel3);
					layoutPanel3.Children.Add(layoutAnchorablePane);
					break;
				}
				case AnchorSide.Left:
				{
					if (parentGroup.Root.RootPanel.Orientation == Orientation.Horizontal)
					{
						layoutAnchorablePane = new LayoutAnchorablePane();
						layoutAnchorablePane.DockMinWidth = AutoHideMinWidth;
						parentGroup.Root.RootPanel.Children.Insert(0, layoutAnchorablePane);
						break;
					}
					layoutAnchorablePane = new LayoutAnchorablePane();
					LayoutPanel layoutPanel2 = new LayoutPanel
					{
						Orientation = Orientation.Horizontal
					};
					LayoutPanel rootPanel2 = parentGroup.Root.RootPanel;
					layoutRoot.RootPanel = layoutPanel2;
					layoutPanel2.Children.Add(layoutAnchorablePane);
					layoutPanel2.Children.Add(rootPanel2);
					break;
				}
				case AnchorSide.Top:
				{
					if (parentGroup.Root.RootPanel.Orientation == Orientation.Vertical)
					{
						layoutAnchorablePane = new LayoutAnchorablePane();
						layoutAnchorablePane.DockMinHeight = AutoHideMinHeight;
						parentGroup.Root.RootPanel.Children.Insert(0, layoutAnchorablePane);
						break;
					}
					layoutAnchorablePane = new LayoutAnchorablePane();
					LayoutPanel layoutPanel4 = new LayoutPanel
					{
						Orientation = Orientation.Vertical
					};
					LayoutPanel rootPanel4 = parentGroup.Root.RootPanel;
					layoutRoot.RootPanel = layoutPanel4;
					layoutPanel4.Children.Add(layoutAnchorablePane);
					layoutPanel4.Children.Add(rootPanel4);
					break;
				}
				case AnchorSide.Bottom:
				{
					if (parentGroup.Root.RootPanel.Orientation == Orientation.Vertical)
					{
						layoutAnchorablePane = new LayoutAnchorablePane();
						layoutAnchorablePane.DockMinHeight = AutoHideMinHeight;
						parentGroup.Root.RootPanel.Children.Add(layoutAnchorablePane);
						break;
					}
					layoutAnchorablePane = new LayoutAnchorablePane();
					LayoutPanel layoutPanel = new LayoutPanel
					{
						Orientation = Orientation.Vertical
					};
					LayoutPanel rootPanel = parentGroup.Root.RootPanel;
					layoutRoot.RootPanel = layoutPanel;
					layoutPanel.Children.Add(rootPanel);
					layoutPanel.Children.Add(layoutAnchorablePane);
					break;
				}
				}
			}
			foreach (ILayoutPreviousContainer item in from c in layoutRoot.Descendents().OfType<ILayoutPreviousContainer>()
				where c.PreviousContainer == parentGroup
				select c)
			{
				item.PreviousContainer = layoutAnchorablePane;
			}
			layoutAnchorablePane.Children.Add(this);
			if (layoutAnchorablePane.Children.Count > 0)
			{
				layoutAnchorablePane.SelectedContentIndex = layoutAnchorablePane.Children.IndexOf(this);
			}
			if (parentGroup.Children.Count == 0)
			{
				layoutAnchorSide.Children.Remove(parentGroup);
			}
			for (LayoutGroupBase layoutGroupBase = layoutAnchorablePane.Parent as LayoutGroupBase; layoutGroupBase != null; layoutGroupBase = layoutGroupBase.Parent as LayoutGroupBase)
			{
				if (layoutGroupBase is LayoutGroup<ILayoutPanelElement>)
				{
					((LayoutGroup<ILayoutPanelElement>)layoutGroupBase).ComputeVisibility();
				}
			}
		}
		else
		{
			if (!(base.Parent is LayoutAnchorablePane))
			{
				return;
			}
			ILayoutRoot root = base.Root;
			LayoutAnchorablePane layoutAnchorablePane2 = base.Parent as LayoutAnchorablePane;
			LayoutAnchorGroup layoutAnchorGroup = new LayoutAnchorGroup();
			((ILayoutPreviousContainer)layoutAnchorGroup).PreviousContainer = layoutAnchorablePane2;
			layoutAnchorGroup.Children.Add(this);
			switch (layoutAnchorablePane2.GetSide())
			{
			case AnchorSide.Right:
				if (root.RightSide != null)
				{
					root.RightSide.Children.Add(layoutAnchorGroup);
				}
				break;
			case AnchorSide.Left:
				if (root.LeftSide != null)
				{
					root.LeftSide.Children.Add(layoutAnchorGroup);
				}
				break;
			case AnchorSide.Top:
				if (root.TopSide != null)
				{
					root.TopSide.Children.Add(layoutAnchorGroup);
				}
				break;
			case AnchorSide.Bottom:
				if (root.BottomSide != null)
				{
					root.BottomSide.Children.Add(layoutAnchorGroup);
				}
				break;
			}
		}
	}

	protected virtual void OnHiding(CancelEventArgs args)
	{
		if (this.Hiding != null)
		{
			this.Hiding(this, args);
		}
	}

	protected virtual void OnHidden()
	{
		if (this.Hidden != null)
		{
			this.Hidden(this, EventArgs.Empty);
		}
	}

	internal bool CloseAnchorable()
	{
		bool num = TestCanClose();
		if (num)
		{
			if (IsAutoHidden)
			{
				ToggleAutoHide();
			}
			CloseInternal();
		}
		return num;
	}

	internal void SetCanCloseInternal(bool canClose)
	{
		_canCloseValueBeforeInternalSet = _canClose;
		_canClose = canClose;
	}

	internal void ResetCanCloseInternal()
	{
		_canClose = _canCloseValueBeforeInternalSet;
	}

	private void NotifyIsVisibleChanged()
	{
		if (this.IsVisibleChanged != null)
		{
			this.IsVisibleChanged(this, EventArgs.Empty);
		}
	}

	private void UpdateParentVisibility()
	{
		if (base.Parent is ILayoutElementWithVisibility layoutElementWithVisibility)
		{
			layoutElementWithVisibility.ComputeVisibility();
		}
	}
}
