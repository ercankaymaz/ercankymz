#define TRACE
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Xceed.Wpf.AvalonDock.Layout;

[Serializable]
[ContentProperty("RootPanel")]
public class LayoutRoot : LayoutElement, ILayoutContainer, ILayoutElement, INotifyPropertyChanged, INotifyPropertyChanging, ILayoutRoot, IXmlSerializable
{
	private LayoutPanel _rootPanel;

	private LayoutAnchorSide _topSide;

	private LayoutAnchorSide _rightSide;

	private LayoutAnchorSide _leftSide;

	private LayoutAnchorSide _bottomSide;

	private ObservableCollection<LayoutFloatingWindow> _floatingWindows;

	private ObservableCollection<LayoutAnchorable> _hiddenAnchorables;

	[NonSerialized]
	private WeakReference _activeContent;

	private bool _activeContentSet;

	[NonSerialized]
	private WeakReference _lastFocusedDocument;

	[NonSerialized]
	private bool _lastFocusedDocumentSet;

	[NonSerialized]
	private DockingManager _manager;

	public LayoutPanel RootPanel
	{
		get
		{
			return _rootPanel;
		}
		set
		{
			if (_rootPanel != value)
			{
				RaisePropertyChanging("RootPanel");
				if (_rootPanel != null && _rootPanel.Parent == this)
				{
					_rootPanel.Parent = null;
				}
				_rootPanel = value;
				if (_rootPanel == null)
				{
					_rootPanel = new LayoutPanel(new LayoutDocumentPane());
				}
				if (_rootPanel != null)
				{
					_rootPanel.Parent = this;
				}
				RaisePropertyChanged("RootPanel");
			}
		}
	}

	public LayoutAnchorSide TopSide
	{
		get
		{
			return _topSide;
		}
		set
		{
			if (_topSide != value)
			{
				RaisePropertyChanging("TopSide");
				_topSide = value;
				if (_topSide != null)
				{
					_topSide.Parent = this;
				}
				RaisePropertyChanged("TopSide");
			}
		}
	}

	public LayoutAnchorSide RightSide
	{
		get
		{
			return _rightSide;
		}
		set
		{
			if (_rightSide != value)
			{
				RaisePropertyChanging("RightSide");
				_rightSide = value;
				if (_rightSide != null)
				{
					_rightSide.Parent = this;
				}
				RaisePropertyChanged("RightSide");
			}
		}
	}

	public LayoutAnchorSide LeftSide
	{
		get
		{
			return _leftSide;
		}
		set
		{
			if (_leftSide != value)
			{
				RaisePropertyChanging("LeftSide");
				_leftSide = value;
				if (_leftSide != null)
				{
					_leftSide.Parent = this;
				}
				RaisePropertyChanged("LeftSide");
			}
		}
	}

	public LayoutAnchorSide BottomSide
	{
		get
		{
			return _bottomSide;
		}
		set
		{
			if (_bottomSide != value)
			{
				RaisePropertyChanging("BottomSide");
				_bottomSide = value;
				if (_bottomSide != null)
				{
					_bottomSide.Parent = this;
				}
				RaisePropertyChanged("BottomSide");
			}
		}
	}

	public ObservableCollection<LayoutFloatingWindow> FloatingWindows
	{
		get
		{
			if (_floatingWindows == null)
			{
				_floatingWindows = new ObservableCollection<LayoutFloatingWindow>();
				_floatingWindows.CollectionChanged += _floatingWindows_CollectionChanged;
			}
			return _floatingWindows;
		}
	}

	public ObservableCollection<LayoutAnchorable> Hidden
	{
		get
		{
			if (_hiddenAnchorables == null)
			{
				_hiddenAnchorables = new ObservableCollection<LayoutAnchorable>();
				_hiddenAnchorables.CollectionChanged += _hiddenAnchorables_CollectionChanged;
			}
			return _hiddenAnchorables;
		}
	}

	public IEnumerable<ILayoutElement> Children
	{
		get
		{
			if (RootPanel != null)
			{
				yield return RootPanel;
			}
			if (_floatingWindows != null)
			{
				foreach (LayoutFloatingWindow floatingWindow in _floatingWindows)
				{
					yield return floatingWindow;
				}
			}
			if (TopSide != null)
			{
				yield return TopSide;
			}
			if (RightSide != null)
			{
				yield return RightSide;
			}
			if (BottomSide != null)
			{
				yield return BottomSide;
			}
			if (LeftSide != null)
			{
				yield return LeftSide;
			}
			if (_hiddenAnchorables == null)
			{
				yield break;
			}
			foreach (LayoutAnchorable hiddenAnchorable in _hiddenAnchorables)
			{
				yield return hiddenAnchorable;
			}
		}
	}

	public int ChildrenCount => 5 + ((_floatingWindows != null) ? _floatingWindows.Count : 0) + ((_hiddenAnchorables != null) ? _hiddenAnchorables.Count : 0);

	[XmlIgnore]
	public LayoutContent ActiveContent
	{
		get
		{
			return _activeContent.GetValueOrDefault<LayoutContent>();
		}
		set
		{
			LayoutContent activeContent = ActiveContent;
			if (activeContent != value)
			{
				InternalSetActiveContent(activeContent, value);
			}
		}
	}

	[XmlIgnore]
	public LayoutContent LastFocusedDocument
	{
		get
		{
			return _lastFocusedDocument.GetValueOrDefault<LayoutContent>();
		}
		private set
		{
			LayoutContent lastFocusedDocument = LastFocusedDocument;
			if (lastFocusedDocument != value)
			{
				RaisePropertyChanging("LastFocusedDocument");
				if (lastFocusedDocument != null)
				{
					lastFocusedDocument.IsLastFocusedDocument = false;
				}
				_lastFocusedDocument = new WeakReference(value);
				lastFocusedDocument = LastFocusedDocument;
				if (lastFocusedDocument != null)
				{
					lastFocusedDocument.IsLastFocusedDocument = true;
				}
				_lastFocusedDocumentSet = lastFocusedDocument != null;
				RaisePropertyChanged("LastFocusedDocument");
			}
		}
	}

	[XmlIgnore]
	public DockingManager Manager
	{
		get
		{
			return _manager;
		}
		internal set
		{
			if (_manager != value)
			{
				RaisePropertyChanging("Manager");
				_manager = value;
				RaisePropertyChanged("Manager");
			}
		}
	}

	public event EventHandler Updated;

	public event EventHandler<LayoutElementEventArgs> ElementAdded;

	public event EventHandler<LayoutElementEventArgs> ElementRemoved;

	public LayoutRoot()
	{
		RightSide = new LayoutAnchorSide();
		LeftSide = new LayoutAnchorSide();
		TopSide = new LayoutAnchorSide();
		BottomSide = new LayoutAnchorSide();
		RootPanel = new LayoutPanel(new LayoutDocumentPane());
	}

	public override void ConsoleDump(int tab)
	{
		Trace.Write(new string(' ', tab * 4));
		Trace.WriteLine("RootPanel()");
		RootPanel.ConsoleDump(tab + 1);
		Trace.Write(new string(' ', tab * 4));
		Trace.WriteLine("FloatingWindows()");
		foreach (LayoutFloatingWindow floatingWindow in FloatingWindows)
		{
			floatingWindow.ConsoleDump(tab + 1);
		}
		Trace.Write(new string(' ', tab * 4));
		Trace.WriteLine("Hidden()");
		foreach (LayoutAnchorable item in Hidden)
		{
			item.ConsoleDump(tab + 1);
		}
	}

	public void RemoveChild(ILayoutElement element)
	{
		if (element == RootPanel)
		{
			RootPanel = null;
		}
		else if (_floatingWindows != null && _floatingWindows.Contains(element))
		{
			_floatingWindows.Remove(element as LayoutFloatingWindow);
		}
		else if (_hiddenAnchorables != null && _hiddenAnchorables.Contains(element))
		{
			_hiddenAnchorables.Remove(element as LayoutAnchorable);
		}
		else if (element == TopSide)
		{
			TopSide = null;
		}
		else if (element == RightSide)
		{
			RightSide = null;
		}
		else if (element == BottomSide)
		{
			BottomSide = null;
		}
		else if (element == LeftSide)
		{
			LeftSide = null;
		}
	}

	public void ReplaceChild(ILayoutElement oldElement, ILayoutElement newElement)
	{
		if (oldElement == RootPanel)
		{
			RootPanel = (LayoutPanel)newElement;
		}
		else if (_floatingWindows != null && _floatingWindows.Contains(oldElement))
		{
			int index = _floatingWindows.IndexOf(oldElement as LayoutFloatingWindow);
			_floatingWindows.Remove(oldElement as LayoutFloatingWindow);
			_floatingWindows.Insert(index, newElement as LayoutFloatingWindow);
		}
		else if (_hiddenAnchorables != null && _hiddenAnchorables.Contains(oldElement))
		{
			int index2 = _hiddenAnchorables.IndexOf(oldElement as LayoutAnchorable);
			_hiddenAnchorables.Remove(oldElement as LayoutAnchorable);
			_hiddenAnchorables.Insert(index2, newElement as LayoutAnchorable);
		}
		else if (oldElement == TopSide)
		{
			TopSide = (LayoutAnchorSide)newElement;
		}
		else if (oldElement == RightSide)
		{
			RightSide = (LayoutAnchorSide)newElement;
		}
		else if (oldElement == BottomSide)
		{
			BottomSide = (LayoutAnchorSide)newElement;
		}
		else if (oldElement == LeftSide)
		{
			LeftSide = (LayoutAnchorSide)newElement;
		}
	}

	public void CollectGarbage()
	{
		bool flag = true;
		do
		{
			flag = true;
			foreach (ILayoutPreviousContainer item in from c in this.Descendents().OfType<ILayoutPreviousContainer>()
				where c.PreviousContainer != null && (c.PreviousContainer.Parent == null || c.PreviousContainer.Parent.Root != this)
				select c)
			{
				item.PreviousContainer = null;
			}
			foreach (ILayoutInitialContainer item2 in from c in this.Descendents().OfType<ILayoutInitialContainer>()
				where c.InitialContainer != null && (c.InitialContainer.Parent == null || c.InitialContainer.Parent.Root != this)
				select c)
			{
				item2.InitialContainer = null;
			}
			ILayoutPane[] array = (from p in this.Descendents().OfType<ILayoutPane>()
				where p.ChildrenCount == 0
				select p).ToArray();
			for (int num = 0; num < array.Count(); num++)
			{
				ILayoutPane emptyPane = array[num];
				foreach (LayoutContent item3 in from c in this.Descendents().OfType<LayoutContent>()
					where ((ILayoutPreviousContainer)c).PreviousContainer == emptyPane && !c.IsFloating
					select c)
				{
					if (!(item3 is LayoutAnchorable) || ((LayoutAnchorable)item3).IsVisible)
					{
						((ILayoutPreviousContainer)item3).PreviousContainer = null;
						item3.PreviousContainerIndex = -1;
					}
				}
				if (emptyPane is LayoutDocumentPane && this.Descendents().OfType<LayoutDocumentPane>().Count((LayoutDocumentPane c) => c != emptyPane) == 0)
				{
					emptyPane = null;
				}
				else if (!this.Descendents().OfType<ILayoutPreviousContainer>().Any((ILayoutPreviousContainer c) => c.PreviousContainer == emptyPane) && !this.Descendents().OfType<ILayoutInitialContainer>().Any((ILayoutInitialContainer c) => c.InitialContainer == emptyPane))
				{
					emptyPane.Parent.RemoveChild(emptyPane);
					flag = false;
					break;
				}
			}
			if (!flag)
			{
				foreach (LayoutAnchorablePaneGroup emptyPaneGroup in from p in this.Descendents().OfType<LayoutAnchorablePaneGroup>()
					where p.ChildrenCount == 0
					select p)
				{
					if (!this.Descendents().OfType<ILayoutPreviousContainer>().Any((ILayoutPreviousContainer c) => c.PreviousContainer == emptyPaneGroup))
					{
						emptyPaneGroup.Parent.RemoveChild(emptyPaneGroup);
						flag = false;
						break;
					}
				}
			}
			if (!flag)
			{
				foreach (LayoutPanel emptyPaneGroup2 in from p in this.Descendents().OfType<LayoutPanel>()
					where p.ChildrenCount == 0
					select p)
				{
					if (!this.Descendents().OfType<ILayoutPreviousContainer>().Any((ILayoutPreviousContainer c) => c.PreviousContainer == emptyPaneGroup2) && !this.Descendents().OfType<ILayoutInitialContainer>().Any((ILayoutInitialContainer c) => c.InitialContainer == emptyPaneGroup2))
					{
						emptyPaneGroup2.Parent.RemoveChild(emptyPaneGroup2);
						flag = false;
						break;
					}
				}
			}
			if (!flag)
			{
				foreach (LayoutFloatingWindow emptyPaneGroup3 in from p in this.Descendents().OfType<LayoutFloatingWindow>()
					where p.ChildrenCount == 0
					select p)
				{
					if (!this.Descendents().OfType<ILayoutPreviousContainer>().Any((ILayoutPreviousContainer c) => c.PreviousContainer == emptyPaneGroup3) && !this.Descendents().OfType<ILayoutInitialContainer>().Any((ILayoutInitialContainer c) => c.InitialContainer == emptyPaneGroup3))
					{
						emptyPaneGroup3.Parent.RemoveChild(emptyPaneGroup3);
						flag = false;
						break;
					}
				}
			}
			if (flag)
			{
				continue;
			}
			foreach (LayoutAnchorGroup emptyPaneGroup4 in from p in this.Descendents().OfType<LayoutAnchorGroup>()
				where p.ChildrenCount == 0
				select p)
			{
				if (!this.Descendents().OfType<ILayoutPreviousContainer>().Any((ILayoutPreviousContainer c) => c.PreviousContainer == emptyPaneGroup4) && !this.Descendents().OfType<ILayoutInitialContainer>().Any((ILayoutInitialContainer c) => c.InitialContainer == emptyPaneGroup4))
				{
					emptyPaneGroup4.Parent.RemoveChild(emptyPaneGroup4);
					flag = false;
					break;
				}
			}
		}
		while (!flag);
		do
		{
			flag = true;
			LayoutAnchorablePaneGroup[] array2 = (from p in this.Descendents().OfType<LayoutAnchorablePaneGroup>()
				where p.ChildrenCount == 1 && p.Children[0] is LayoutAnchorablePaneGroup
				select p).ToArray();
			int num2 = 0;
			if (num2 < array2.Length)
			{
				LayoutAnchorablePaneGroup layoutAnchorablePaneGroup = array2[num2];
				LayoutAnchorablePaneGroup layoutAnchorablePaneGroup2 = layoutAnchorablePaneGroup.Children[0] as LayoutAnchorablePaneGroup;
				layoutAnchorablePaneGroup.Orientation = layoutAnchorablePaneGroup2.Orientation;
				layoutAnchorablePaneGroup.RemoveChild(layoutAnchorablePaneGroup2);
				while (layoutAnchorablePaneGroup2.ChildrenCount > 0)
				{
					layoutAnchorablePaneGroup.InsertChildAt(layoutAnchorablePaneGroup.ChildrenCount, layoutAnchorablePaneGroup2.Children[0]);
				}
				flag = false;
			}
		}
		while (!flag);
		do
		{
			flag = true;
			LayoutDocumentPaneGroup[] array3 = (from p in this.Descendents().OfType<LayoutDocumentPaneGroup>()
				where p.ChildrenCount == 1 && p.Children[0] is LayoutDocumentPaneGroup
				select p).ToArray();
			int num2 = 0;
			if (num2 < array3.Length)
			{
				LayoutDocumentPaneGroup layoutDocumentPaneGroup = array3[num2];
				LayoutDocumentPaneGroup layoutDocumentPaneGroup2 = layoutDocumentPaneGroup.Children[0] as LayoutDocumentPaneGroup;
				layoutDocumentPaneGroup.Orientation = layoutDocumentPaneGroup2.Orientation;
				layoutDocumentPaneGroup.RemoveChild(layoutDocumentPaneGroup2);
				while (layoutDocumentPaneGroup2.ChildrenCount > 0)
				{
					layoutDocumentPaneGroup.InsertChildAt(layoutDocumentPaneGroup.ChildrenCount, layoutDocumentPaneGroup2.Children[0]);
				}
				flag = false;
			}
		}
		while (!flag);
		UpdateActiveContentProperty();
	}

	public XmlSchema GetSchema()
	{
		return null;
	}

	public void ReadXml(XmlReader reader)
	{
		reader.MoveToContent();
		if (reader.IsEmptyElement)
		{
			reader.Read();
			return;
		}
		Orientation orientation;
		List<ILayoutPanelElement> list = ReadRootPanel(reader, out orientation);
		if (list != null)
		{
			RootPanel = new LayoutPanel
			{
				Orientation = orientation
			};
			for (int i = 0; i < list.Count; i++)
			{
				RootPanel.Children.Add(list[i]);
			}
		}
		TopSide = new LayoutAnchorSide();
		if (ReadElement(reader) != null)
		{
			FillLayoutAnchorSide(reader, TopSide);
		}
		RightSide = new LayoutAnchorSide();
		if (ReadElement(reader) != null)
		{
			FillLayoutAnchorSide(reader, RightSide);
		}
		LeftSide = new LayoutAnchorSide();
		if (ReadElement(reader) != null)
		{
			FillLayoutAnchorSide(reader, LeftSide);
		}
		BottomSide = new LayoutAnchorSide();
		if (ReadElement(reader) != null)
		{
			FillLayoutAnchorSide(reader, BottomSide);
		}
		FloatingWindows.Clear();
		foreach (object item in ReadElementList(reader, isFloatingWindow: true))
		{
			FloatingWindows.Add((LayoutFloatingWindow)item);
		}
		Hidden.Clear();
		foreach (object item2 in ReadElementList(reader, isFloatingWindow: false))
		{
			Hidden.Add((LayoutAnchorable)item2);
		}
		reader.ReadEndElement();
	}

	public void WriteXml(XmlWriter writer)
	{
		writer.WriteStartElement("RootPanel");
		if (RootPanel != null)
		{
			RootPanel.WriteXml(writer);
		}
		writer.WriteEndElement();
		writer.WriteStartElement("TopSide");
		if (TopSide != null)
		{
			TopSide.WriteXml(writer);
		}
		writer.WriteEndElement();
		writer.WriteStartElement("RightSide");
		if (RightSide != null)
		{
			RightSide.WriteXml(writer);
		}
		writer.WriteEndElement();
		writer.WriteStartElement("LeftSide");
		if (LeftSide != null)
		{
			LeftSide.WriteXml(writer);
		}
		writer.WriteEndElement();
		writer.WriteStartElement("BottomSide");
		if (BottomSide != null)
		{
			BottomSide.WriteXml(writer);
		}
		writer.WriteEndElement();
		writer.WriteStartElement("FloatingWindows");
		foreach (LayoutFloatingWindow floatingWindow in FloatingWindows)
		{
			writer.WriteStartElement(((object)floatingWindow).GetType().Name);
			floatingWindow.WriteXml(writer);
			writer.WriteEndElement();
		}
		writer.WriteEndElement();
		writer.WriteStartElement("Hidden");
		foreach (LayoutAnchorable item in Hidden)
		{
			writer.WriteStartElement(((object)item).GetType().Name);
			item.WriteXml(writer);
			writer.WriteEndElement();
		}
		writer.WriteEndElement();
	}

	internal static Type FindType(string name)
	{
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		for (int i = 0; i < assemblies.Length; i++)
		{
			Type[] types = assemblies[i].GetTypes();
			foreach (Type type in types)
			{
				if (type.Name.Equals(name))
				{
					return type;
				}
			}
		}
		return null;
	}

	internal void FireLayoutUpdated()
	{
		if (this.Updated != null)
		{
			this.Updated(this, EventArgs.Empty);
		}
	}

	internal void OnLayoutElementAdded(LayoutElement element)
	{
		if (this.ElementAdded != null)
		{
			this.ElementAdded(this, new LayoutElementEventArgs(element));
		}
	}

	internal void OnLayoutElementRemoved(LayoutElement element)
	{
		if (element.Descendents().OfType<LayoutContent>().Any((LayoutContent c) => c == LastFocusedDocument))
		{
			LastFocusedDocument = null;
		}
		if (element.Descendents().OfType<LayoutContent>().Any((LayoutContent c) => c == ActiveContent))
		{
			ActiveContent = null;
		}
		if (this.ElementRemoved != null)
		{
			this.ElementRemoved(this, new LayoutElementEventArgs(element));
		}
	}

	private void _floatingWindows_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
		if (e.OldItems != null && (e.Action == NotifyCollectionChangedAction.Remove || e.Action == NotifyCollectionChangedAction.Replace))
		{
			foreach (LayoutFloatingWindow oldItem in e.OldItems)
			{
				if (oldItem.Parent == this)
				{
					oldItem.Parent = null;
				}
			}
		}
		if (e.NewItems == null || (e.Action != NotifyCollectionChangedAction.Add && e.Action != NotifyCollectionChangedAction.Replace))
		{
			return;
		}
		foreach (LayoutFloatingWindow newItem in e.NewItems)
		{
			newItem.Parent = this;
		}
	}

	private void _hiddenAnchorables_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
		if ((e.Action == NotifyCollectionChangedAction.Remove || e.Action == NotifyCollectionChangedAction.Replace) && e.OldItems != null)
		{
			foreach (LayoutAnchorable oldItem in e.OldItems)
			{
				if (oldItem.Parent == this)
				{
					oldItem.Parent = null;
				}
			}
		}
		if ((e.Action != NotifyCollectionChangedAction.Add && e.Action != NotifyCollectionChangedAction.Replace) || e.NewItems == null)
		{
			return;
		}
		foreach (LayoutAnchorable newItem in e.NewItems)
		{
			if (newItem.Parent != this)
			{
				if (newItem.Parent != null)
				{
					newItem.Parent.RemoveChild(newItem);
				}
				newItem.Parent = this;
			}
		}
	}

	private void InternalSetActiveContent(LayoutContent currentValue, LayoutContent newActiveContent)
	{
		RaisePropertyChanging("ActiveContent");
		if (currentValue != null)
		{
			currentValue.IsActive = false;
		}
		_activeContent = new WeakReference(newActiveContent);
		currentValue = ActiveContent;
		if (currentValue != null)
		{
			currentValue.IsActive = true;
		}
		RaisePropertyChanged("ActiveContent");
		_activeContentSet = currentValue != null;
		if (currentValue != null)
		{
			if (currentValue.Parent is LayoutDocumentPane || currentValue is LayoutDocument)
			{
				LastFocusedDocument = currentValue;
			}
		}
		else
		{
			LastFocusedDocument = null;
		}
	}

	private void UpdateActiveContentProperty()
	{
		LayoutContent activeContent = ActiveContent;
		if (_activeContentSet && (activeContent == null || activeContent.Root != this))
		{
			_activeContentSet = false;
			InternalSetActiveContent(activeContent, null);
		}
	}

	private void FillLayoutAnchorSide(XmlReader reader, LayoutAnchorSide layoutAnchorSide)
	{
		List<LayoutAnchorGroup> list = new List<LayoutAnchorGroup>();
		while (true)
		{
			if (ReadElement(reader) is LayoutAnchorGroup item)
			{
				list.Add(item);
			}
			else if (reader.NodeType == XmlNodeType.EndElement)
			{
				break;
			}
		}
		reader.ReadEndElement();
		foreach (LayoutAnchorGroup item2 in list)
		{
			layoutAnchorSide.Children.Add(item2);
		}
	}

	private List<ILayoutPanelElement> ReadRootPanel(XmlReader reader, out Orientation orientation)
	{
		orientation = Orientation.Horizontal;
		List<ILayoutPanelElement> list = new List<ILayoutPanelElement>();
		string localName = reader.LocalName;
		reader.Read();
		if (reader.LocalName.Equals(localName) && reader.NodeType == XmlNodeType.EndElement)
		{
			return null;
		}
		while (reader.NodeType == XmlNodeType.Whitespace)
		{
			reader.Read();
		}
		if (reader.LocalName.Equals("RootPanel"))
		{
			orientation = ((reader.GetAttribute("Orientation") == "Vertical") ? Orientation.Vertical : Orientation.Horizontal);
			reader.Read();
			while (true)
			{
				if (ReadElement(reader) is ILayoutPanelElement item)
				{
					list.Add(item);
				}
				else if (reader.NodeType == XmlNodeType.EndElement)
				{
					break;
				}
			}
		}
		reader.ReadEndElement();
		return list;
	}

	private List<object> ReadElementList(XmlReader reader, bool isFloatingWindow)
	{
		List<object> list = new List<object>();
		while (reader.NodeType == XmlNodeType.Whitespace)
		{
			reader.Read();
		}
		if (reader.IsEmptyElement)
		{
			reader.Read();
			return list;
		}
		string localName = reader.LocalName;
		reader.Read();
		if (reader.LocalName.Equals(localName) && reader.NodeType == XmlNodeType.EndElement)
		{
			return null;
		}
		while (reader.NodeType == XmlNodeType.Whitespace)
		{
			reader.Read();
		}
		while (true)
		{
			if (isFloatingWindow)
			{
				if (!(ReadElement(reader) is LayoutFloatingWindow item))
				{
					break;
				}
				list.Add(item);
			}
			else
			{
				if (!(ReadElement(reader) is LayoutAnchorable item2))
				{
					break;
				}
				list.Add(item2);
			}
		}
		reader.ReadEndElement();
		return list;
	}

	private object ReadElement(XmlReader reader)
	{
		while (reader.NodeType == XmlNodeType.Whitespace)
		{
			reader.Read();
		}
		if (reader.NodeType == XmlNodeType.EndElement)
		{
			return null;
		}
		XmlSerializer xmlSerializer;
		switch (reader.LocalName)
		{
		case "LayoutAnchorablePaneGroup":
			xmlSerializer = new XmlSerializer(typeof(LayoutAnchorablePaneGroup));
			break;
		case "LayoutAnchorablePane":
			xmlSerializer = new XmlSerializer(typeof(LayoutAnchorablePane));
			break;
		case "LayoutAnchorable":
			xmlSerializer = new XmlSerializer(typeof(LayoutAnchorable));
			break;
		case "LayoutDocumentPaneGroup":
			xmlSerializer = new XmlSerializer(typeof(LayoutDocumentPaneGroup));
			break;
		case "LayoutDocumentPane":
			xmlSerializer = new XmlSerializer(typeof(LayoutDocumentPane));
			break;
		case "LayoutDocument":
			xmlSerializer = new XmlSerializer(typeof(LayoutDocument));
			break;
		case "LayoutAnchorGroup":
			xmlSerializer = new XmlSerializer(typeof(LayoutAnchorGroup));
			break;
		case "LayoutPanel":
			xmlSerializer = new XmlSerializer(typeof(LayoutPanel));
			break;
		case "LayoutDocumentFloatingWindow":
			xmlSerializer = new XmlSerializer(typeof(LayoutDocumentFloatingWindow));
			break;
		case "LayoutAnchorableFloatingWindow":
			xmlSerializer = new XmlSerializer(typeof(LayoutAnchorableFloatingWindow));
			break;
		case "LeftSide":
		case "RightSide":
		case "TopSide":
		case "BottomSide":
			if (reader.IsEmptyElement)
			{
				reader.Read();
				return null;
			}
			return reader.Read();
		default:
		{
			Type type = FindType(reader.LocalName);
			if (type == null)
			{
				throw new ArgumentException("AvalonDock.LayoutRoot doesn't know how to deserialize " + reader.LocalName);
			}
			xmlSerializer = new XmlSerializer(type);
			break;
		}
		}
		return xmlSerializer.Deserialize(reader);
	}
}
