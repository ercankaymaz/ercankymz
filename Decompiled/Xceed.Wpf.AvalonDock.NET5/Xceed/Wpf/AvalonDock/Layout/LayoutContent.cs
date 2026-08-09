using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Xceed.Wpf.AvalonDock.Controls;

namespace Xceed.Wpf.AvalonDock.Layout;

[Serializable]
[ContentProperty("Content")]
public abstract class LayoutContent : LayoutElement, IXmlSerializable, ILayoutElementForFloatingWindow, IComparable<LayoutContent>, ILayoutPreviousContainer, ILayoutInitialContainer
{
	public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(LayoutContent), (PropertyMetadata)(object)new UIPropertyMetadata(null, new PropertyChangedCallback(OnTitlePropertyChanged), new CoerceValueCallback(CoerceTitleValue)));

	[NonSerialized]
	private object _content;

	public static readonly DependencyProperty ContentIdProperty = DependencyProperty.Register("ContentId", typeof(string), typeof(LayoutContent), (PropertyMetadata)(object)new UIPropertyMetadata(null, new PropertyChangedCallback(OnContentIdPropertyChanged)));

	private bool _isSelected;

	[NonSerialized]
	private bool _isActive;

	private bool _isLastFocusedDocument;

	[NonSerialized]
	private ILayoutContainer _previousContainer;

	[NonSerialized]
	private ILayoutContainer _initialContainer;

	[NonSerialized]
	private int _previousContainerIndex = -1;

	[NonSerialized]
	private int _initialContainerIndex = -1;

	private DateTime? _lastActivationTimeStamp;

	private double _floatingWidth;

	private double _floatingHeight;

	private double _floatingLeft;

	private double _floatingTop;

	private bool _isMaximized;

	private object _toolTip;

	private bool _isFloating;

	private ImageSource _iconSource;

	internal bool _canClose = true;

	private bool _canFloat = true;

	private bool _isEnabled = true;

	public string Title
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(TitleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TitleProperty, (object)value);
		}
	}

	[XmlIgnore]
	public object Content
	{
		get
		{
			return _content;
		}
		set
		{
			if (_content != value)
			{
				RaisePropertyChanging("Content");
				_content = value;
				RaisePropertyChanged("Content");
				if (ContentId == null && _content is FrameworkElement frameworkElement && !string.IsNullOrWhiteSpace(frameworkElement.Name))
				{
					((DependencyObject)this).SetCurrentValue(ContentIdProperty, (object)frameworkElement.Name);
				}
			}
		}
	}

	public string ContentId
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(ContentIdProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ContentIdProperty, (object)value);
		}
	}

	public bool IsSelected
	{
		get
		{
			return _isSelected;
		}
		set
		{
			if (_isSelected != value)
			{
				bool isSelected = _isSelected;
				RaisePropertyChanging("IsSelected");
				_isSelected = value;
				if (base.Parent is ILayoutContentSelector layoutContentSelector)
				{
					layoutContentSelector.SelectedContentIndex = (_isSelected ? layoutContentSelector.IndexOf(this) : (-1));
				}
				OnIsSelectedChanged(isSelected, value);
				RaisePropertyChanged("IsSelected");
			}
		}
	}

	[XmlIgnore]
	public bool IsActive
	{
		get
		{
			return _isActive;
		}
		set
		{
			if (_isActive != value)
			{
				RaisePropertyChanging("IsActive");
				bool isActive = _isActive;
				_isActive = value;
				ILayoutRoot root = base.Root;
				if (root != null && _isActive)
				{
					root.ActiveContent = this;
				}
				if (_isActive)
				{
					IsSelected = true;
				}
				OnIsActiveChanged(isActive, value);
				RaisePropertyChanged("IsActive");
			}
		}
	}

	public bool IsLastFocusedDocument
	{
		get
		{
			return _isLastFocusedDocument;
		}
		internal set
		{
			if (_isLastFocusedDocument != value)
			{
				RaisePropertyChanging("IsLastFocusedDocument");
				_isLastFocusedDocument = value;
				RaisePropertyChanged("IsLastFocusedDocument");
			}
		}
	}

	[XmlIgnore]
	ILayoutContainer ILayoutPreviousContainer.PreviousContainer
	{
		get
		{
			return _previousContainer;
		}
		set
		{
			if (_previousContainer != value)
			{
				_previousContainer = value;
				RaisePropertyChanged("PreviousContainer");
				if (_previousContainer is ILayoutPaneSerializable { Id: null } layoutPaneSerializable)
				{
					layoutPaneSerializable.Id = Guid.NewGuid().ToString();
				}
			}
		}
	}

	public ILayoutContainer PreviousContainer
	{
		get
		{
			return ((ILayoutPreviousContainer)this).PreviousContainer;
		}
		protected set
		{
			((ILayoutPreviousContainer)this).PreviousContainer = value;
		}
	}

	[XmlIgnore]
	string ILayoutPreviousContainer.PreviousContainerId { get; set; }

	public string PreviousContainerId
	{
		get
		{
			return ((ILayoutPreviousContainer)this).PreviousContainerId;
		}
		protected set
		{
			((ILayoutPreviousContainer)this).PreviousContainerId = value;
		}
	}

	[XmlIgnore]
	ILayoutContainer ILayoutInitialContainer.InitialContainer
	{
		get
		{
			return _initialContainer;
		}
		set
		{
			if (_initialContainer != value)
			{
				_initialContainer = value;
				RaisePropertyChanged("InitialContainer");
				if (_initialContainer is ILayoutPaneSerializable { Id: null } layoutPaneSerializable)
				{
					layoutPaneSerializable.Id = Guid.NewGuid().ToString();
				}
			}
		}
	}

	internal ILayoutContainer InitialContainer
	{
		get
		{
			return ((ILayoutInitialContainer)this).InitialContainer;
		}
		set
		{
			((ILayoutInitialContainer)this).InitialContainer = value;
		}
	}

	[XmlIgnore]
	string ILayoutInitialContainer.InitialContainerId { get; set; }

	internal string InitialContainerId
	{
		get
		{
			return ((ILayoutInitialContainer)this).InitialContainerId;
		}
		set
		{
			((ILayoutInitialContainer)this).InitialContainerId = value;
		}
	}

	[XmlIgnore]
	public int PreviousContainerIndex
	{
		get
		{
			return _previousContainerIndex;
		}
		set
		{
			if (_previousContainerIndex != value)
			{
				_previousContainerIndex = value;
				RaisePropertyChanged("PreviousContainerIndex");
			}
		}
	}

	[XmlIgnore]
	internal int InitialContainerIndex
	{
		get
		{
			return _initialContainerIndex;
		}
		set
		{
			if (_initialContainerIndex != value)
			{
				_initialContainerIndex = value;
				RaisePropertyChanged("InitialContainerIndex");
			}
		}
	}

	public DateTime? LastActivationTimeStamp
	{
		get
		{
			return _lastActivationTimeStamp;
		}
		set
		{
			if (_lastActivationTimeStamp != value)
			{
				_lastActivationTimeStamp = value;
				RaisePropertyChanged("LastActivationTimeStamp");
			}
		}
	}

	public double FloatingWidth
	{
		get
		{
			return _floatingWidth;
		}
		set
		{
			if (_floatingWidth != value)
			{
				RaisePropertyChanging("FloatingWidth");
				_floatingWidth = value;
				RaisePropertyChanged("FloatingWidth");
			}
		}
	}

	public double FloatingHeight
	{
		get
		{
			return _floatingHeight;
		}
		set
		{
			if (_floatingHeight != value)
			{
				RaisePropertyChanging("FloatingHeight");
				_floatingHeight = value;
				RaisePropertyChanged("FloatingHeight");
			}
		}
	}

	public double FloatingLeft
	{
		get
		{
			return _floatingLeft;
		}
		set
		{
			if (_floatingLeft != value)
			{
				RaisePropertyChanging("FloatingLeft");
				_floatingLeft = value;
				RaisePropertyChanged("FloatingLeft");
			}
		}
	}

	public double FloatingTop
	{
		get
		{
			return _floatingTop;
		}
		set
		{
			if (_floatingTop != value)
			{
				RaisePropertyChanging("FloatingTop");
				_floatingTop = value;
				RaisePropertyChanged("FloatingTop");
			}
		}
	}

	public bool IsMaximized
	{
		get
		{
			return _isMaximized;
		}
		set
		{
			if (_isMaximized != value)
			{
				RaisePropertyChanging("IsMaximized");
				_isMaximized = value;
				RaisePropertyChanged("IsMaximized");
			}
		}
	}

	public object ToolTip
	{
		get
		{
			return _toolTip;
		}
		set
		{
			if (_toolTip != value)
			{
				_toolTip = value;
				RaisePropertyChanged("ToolTip");
			}
		}
	}

	public bool IsFloating
	{
		get
		{
			return _isFloating;
		}
		internal set
		{
			if (_isFloating != value)
			{
				_isFloating = value;
				RaisePropertyChanged("IsFloating");
			}
		}
	}

	public ImageSource IconSource
	{
		get
		{
			return _iconSource;
		}
		set
		{
			if (_iconSource != value)
			{
				_iconSource = value;
				RaisePropertyChanged("IconSource");
			}
		}
	}

	public bool CanClose
	{
		get
		{
			return _canClose;
		}
		set
		{
			if (_canClose != value)
			{
				_canClose = value;
				RaisePropertyChanged("CanClose");
			}
		}
	}

	public bool CanFloat
	{
		get
		{
			return _canFloat;
		}
		set
		{
			if (_canFloat != value)
			{
				_canFloat = value;
				RaisePropertyChanged("CanFloat");
			}
		}
	}

	public bool IsEnabled
	{
		get
		{
			return _isEnabled;
		}
		set
		{
			if (_isEnabled != value)
			{
				_isEnabled = value;
				RaisePropertyChanged("IsEnabled");
			}
		}
	}

	public event EventHandler IsSelectedChanged;

	public event EventHandler IsActiveChanged;

	public event EventHandler Closed;

	public event EventHandler<CancelEventArgs> Closing;

	internal LayoutContent()
	{
	}

	private static object CoerceTitleValue(DependencyObject obj, object value)
	{
		LayoutContent layoutContent = (LayoutContent)(object)obj;
		if ((string)value != layoutContent.Title)
		{
			layoutContent.RaisePropertyChanging(TitleProperty.Name);
		}
		return value;
	}

	private static void OnTitlePropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
	{
		((LayoutContent)(object)obj).RaisePropertyChanged(TitleProperty.Name);
	}

	private static void OnContentIdPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
	{
		if (obj is LayoutContent layoutContent)
		{
			layoutContent.OnContentIdPropertyChanged((string)((DependencyPropertyChangedEventArgs)(ref args)).OldValue, (string)((DependencyPropertyChangedEventArgs)(ref args)).NewValue);
		}
	}

	private void OnContentIdPropertyChanged(string oldValue, string newValue)
	{
		if (oldValue != newValue)
		{
			RaisePropertyChanged("ContentId");
		}
	}

	protected virtual void OnIsSelectedChanged(bool oldValue, bool newValue)
	{
		UpdateContainedFloatingWindowTaskbarTitle(newValue);
		if (this.IsSelectedChanged != null)
		{
			this.IsSelectedChanged(this, EventArgs.Empty);
		}
	}

	protected virtual void OnIsActiveChanged(bool oldValue, bool newValue)
	{
		if (newValue)
		{
			LastActivationTimeStamp = DateTime.Now;
		}
		if (this.IsActiveChanged != null)
		{
			this.IsActiveChanged(this, EventArgs.Empty);
		}
	}

	protected override void OnParentChanging(ILayoutContainer oldValue, ILayoutContainer newValue)
	{
		_ = base.Root;
		if (oldValue != null)
		{
			IsSelected = false;
		}
		base.OnParentChanging(oldValue, newValue);
	}

	protected override void OnParentChanged(ILayoutContainer oldValue, ILayoutContainer newValue)
	{
		if (IsSelected && base.Parent != null && base.Parent is ILayoutContentSelector)
		{
			ILayoutContentSelector obj = base.Parent as ILayoutContentSelector;
			obj.SelectedContentIndex = obj.IndexOf(this);
		}
		base.OnParentChanged(oldValue, newValue);
	}

	public abstract void Close();

	public XmlSchema GetSchema()
	{
		return null;
	}

	public virtual void ReadXml(XmlReader reader)
	{
		if (reader.MoveToAttribute("Title"))
		{
			Title = reader.Value;
		}
		if (reader.MoveToAttribute("IsSelected"))
		{
			IsSelected = bool.Parse(reader.Value);
		}
		if (reader.MoveToAttribute("ContentId"))
		{
			ContentId = reader.Value;
		}
		if (reader.MoveToAttribute("IsLastFocusedDocument"))
		{
			IsLastFocusedDocument = bool.Parse(reader.Value);
		}
		if (reader.MoveToAttribute("PreviousContainerId"))
		{
			PreviousContainerId = reader.Value;
		}
		if (reader.MoveToAttribute("PreviousContainerIndex"))
		{
			PreviousContainerIndex = int.Parse(reader.Value);
		}
		if (reader.MoveToAttribute("InitialContainerId"))
		{
			InitialContainerId = reader.Value;
		}
		if (reader.MoveToAttribute("InitialContainerIndex"))
		{
			InitialContainerIndex = int.Parse(reader.Value);
		}
		if (reader.MoveToAttribute("FloatingLeft"))
		{
			FloatingLeft = double.Parse(reader.Value, CultureInfo.InvariantCulture);
		}
		if (reader.MoveToAttribute("FloatingTop"))
		{
			FloatingTop = double.Parse(reader.Value, CultureInfo.InvariantCulture);
		}
		if (reader.MoveToAttribute("FloatingWidth"))
		{
			FloatingWidth = double.Parse(reader.Value, CultureInfo.InvariantCulture);
		}
		if (reader.MoveToAttribute("FloatingHeight"))
		{
			FloatingHeight = double.Parse(reader.Value, CultureInfo.InvariantCulture);
		}
		if (reader.MoveToAttribute("IsFloating"))
		{
			IsFloating = bool.Parse(reader.Value);
		}
		if (reader.MoveToAttribute("IsMaximized"))
		{
			IsMaximized = bool.Parse(reader.Value);
		}
		if (reader.MoveToAttribute("CanClose"))
		{
			CanClose = bool.Parse(reader.Value);
		}
		if (reader.MoveToAttribute("CanFloat"))
		{
			CanFloat = bool.Parse(reader.Value);
		}
		if (reader.MoveToAttribute("LastActivationTimeStamp"))
		{
			LastActivationTimeStamp = DateTime.Parse(reader.Value, CultureInfo.InvariantCulture);
		}
		reader.Read();
	}

	public virtual void WriteXml(XmlWriter writer)
	{
		if (!string.IsNullOrWhiteSpace(Title))
		{
			writer.WriteAttributeString("Title", Title);
		}
		if (IsSelected)
		{
			writer.WriteAttributeString("IsSelected", IsSelected.ToString());
		}
		if (IsLastFocusedDocument)
		{
			writer.WriteAttributeString("IsLastFocusedDocument", IsLastFocusedDocument.ToString());
		}
		if (!string.IsNullOrWhiteSpace(ContentId))
		{
			writer.WriteAttributeString("ContentId", ContentId);
		}
		if (ToolTip != null && ToolTip is string && !string.IsNullOrWhiteSpace((string)ToolTip))
		{
			writer.WriteAttributeString("ToolTip", (string)ToolTip);
		}
		if (FloatingLeft != 0.0)
		{
			writer.WriteAttributeString("FloatingLeft", FloatingLeft.ToString(CultureInfo.InvariantCulture));
		}
		if (FloatingTop != 0.0)
		{
			writer.WriteAttributeString("FloatingTop", FloatingTop.ToString(CultureInfo.InvariantCulture));
		}
		if (FloatingWidth != 0.0)
		{
			writer.WriteAttributeString("FloatingWidth", FloatingWidth.ToString(CultureInfo.InvariantCulture));
		}
		if (FloatingHeight != 0.0)
		{
			writer.WriteAttributeString("FloatingHeight", FloatingHeight.ToString(CultureInfo.InvariantCulture));
		}
		if (IsFloating)
		{
			writer.WriteAttributeString("IsFloating", IsFloating.ToString());
		}
		if (IsMaximized)
		{
			writer.WriteAttributeString("IsMaximized", IsMaximized.ToString());
		}
		writer.WriteAttributeString("CanClose", CanClose.ToString());
		if (!CanFloat)
		{
			writer.WriteAttributeString("CanFloat", CanFloat.ToString());
		}
		if (LastActivationTimeStamp.HasValue)
		{
			writer.WriteAttributeString("LastActivationTimeStamp", LastActivationTimeStamp.Value.ToString(CultureInfo.InvariantCulture));
		}
		if (_previousContainer != null && _previousContainer is ILayoutPaneSerializable layoutPaneSerializable)
		{
			writer.WriteAttributeString("PreviousContainerId", layoutPaneSerializable.Id);
			writer.WriteAttributeString("PreviousContainerIndex", _previousContainerIndex.ToString());
		}
		if (_initialContainer != null && _initialContainer is ILayoutPaneSerializable layoutPaneSerializable2)
		{
			writer.WriteAttributeString("InitialContainerId", layoutPaneSerializable2.Id);
			writer.WriteAttributeString("InitialContainerIndex", _initialContainerIndex.ToString());
		}
	}

	public int CompareTo(LayoutContent other)
	{
		if (Content is IComparable comparable)
		{
			return comparable.CompareTo(other.Content);
		}
		return string.Compare(Title, other.Title);
	}

	public void Float()
	{
		if (PreviousContainer != null && PreviousContainer.FindParent<LayoutFloatingWindow>() != null)
		{
			ILayoutPane layoutPane = base.Parent as ILayoutPane;
			int previousContainerIndex = (layoutPane as ILayoutGroup).IndexOfChild(this);
			ILayoutGroup layoutGroup = PreviousContainer as ILayoutGroup;
			if (PreviousContainerIndex < layoutGroup.ChildrenCount)
			{
				layoutGroup.InsertChildAt(PreviousContainerIndex, this);
			}
			else
			{
				layoutGroup.InsertChildAt(layoutGroup.ChildrenCount, this);
			}
			PreviousContainer = layoutPane;
			PreviousContainerIndex = previousContainerIndex;
			IsSelected = true;
			IsActive = true;
		}
		else
		{
			base.Root.Manager.StartDraggingFloatingWindowForContent(this, startDrag: false);
			IsSelected = true;
			IsActive = true;
		}
		base.Root.CollectGarbage();
	}

	public void DockAsDocument()
	{
		if (!(base.Root is LayoutRoot layoutRoot))
		{
			throw new InvalidOperationException();
		}
		if (base.Parent is LayoutDocumentPane)
		{
			return;
		}
		if (this is LayoutAnchorable && ((LayoutAnchorable)this).CanClose)
		{
			((LayoutAnchorable)this).SetCanCloseInternal(canClose: true);
		}
		if (PreviousContainer is LayoutDocumentPane)
		{
			Dock();
			return;
		}
		LayoutDocumentPane layoutDocumentPane = ((layoutRoot.LastFocusedDocument == null) ? layoutRoot.Descendents().OfType<LayoutDocumentPane>().FirstOrDefault() : (layoutRoot.LastFocusedDocument.Parent as LayoutDocumentPane));
		if (layoutDocumentPane != null)
		{
			base.Root.Manager.RaisePreviewDockEvent(this);
			layoutDocumentPane.Children.Add(this);
			base.Root.Manager.RaiseDockedEvent(this);
		}
		else
		{
			base.Root.Manager.RaisePreviewDockEvent(this);
			LayoutPanel layoutPanel = new LayoutPanel
			{
				Orientation = Orientation.Horizontal
			};
			if (layoutRoot.RootPanel != null)
			{
				layoutPanel.Children.Add(layoutRoot.RootPanel);
			}
			layoutRoot.RootPanel = layoutPanel;
			layoutDocumentPane = new LayoutDocumentPane();
			layoutPanel.Children.Add(layoutDocumentPane);
			layoutDocumentPane.Children.Add(this);
			base.Root.Manager.RaiseDockedEvent(this);
		}
		layoutRoot.CollectGarbage();
		IsFloating = false;
		IsSelected = true;
		IsActive = true;
	}

	public void Dock()
	{
		base.Root.Manager.RaisePreviewDockEvent(this);
		if (PreviousContainer != null)
		{
			ILayoutContainer parent = base.Parent;
			int num = ((parent is ILayoutGroup) ? (parent as ILayoutGroup).IndexOfChild(this) : (-1));
			ILayoutGroup layoutGroup = PreviousContainer as ILayoutGroup;
			if (PreviousContainerIndex < layoutGroup.ChildrenCount)
			{
				layoutGroup.InsertChildAt(PreviousContainerIndex, this);
			}
			else
			{
				layoutGroup.InsertChildAt(layoutGroup.ChildrenCount, this);
			}
			if (num > -1)
			{
				PreviousContainer = parent;
				PreviousContainerIndex = num;
			}
			else
			{
				PreviousContainer = null;
				PreviousContainerIndex = 0;
			}
			IsSelected = true;
			IsActive = true;
		}
		else
		{
			InternalDock();
		}
		base.Root.Manager.RaiseDockedEvent(this);
		IsFloating = false;
		if (base.Root != null)
		{
			base.Root.CollectGarbage();
		}
	}

	internal bool TestCanClose()
	{
		CancelEventArgs e = new CancelEventArgs();
		OnClosing(e);
		if (e.Cancel)
		{
			return false;
		}
		return true;
	}

	internal void CloseInternal()
	{
		ILayoutRoot root = base.Root;
		base.Parent.RemoveChild(this);
		root?.CollectGarbage();
		OnClosed();
	}

	protected virtual void OnClosed()
	{
		if (this.Closed != null)
		{
			this.Closed(this, EventArgs.Empty);
		}
	}

	protected virtual void OnClosing(CancelEventArgs args)
	{
		if (this.Closing != null)
		{
			this.Closing(this, args);
		}
	}

	protected virtual void InternalDock()
	{
	}

	private void UpdateContainedFloatingWindowTaskbarTitle(bool newValue)
	{
		if (newValue)
		{
			return;
		}
		ILayoutRoot root = base.Root;
		if (root == null)
		{
			return;
		}
		LayoutFloatingWindowControl layoutFloatingWindowControl = root.Manager.FloatingWindows.FirstOrDefault((LayoutFloatingWindowControl f) => (from l in f.Model.Descendents().OfType<LayoutContent>()
			where l.ContentId == ContentId
			select l).FirstOrDefault() != null);
		if (layoutFloatingWindowControl != null)
		{
			LayoutContent layoutContent = (from l in layoutFloatingWindowControl.Model.Descendents().OfType<LayoutContent>()
				where l.IsSelected
				select l).FirstOrDefault();
			if (layoutContent != null && layoutFloatingWindowControl.Title != layoutContent.Title)
			{
				layoutFloatingWindowControl.Title = layoutContent.Title;
			}
		}
	}
}
