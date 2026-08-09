using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using Xceed.Wpf.AvalonDock.Layout;
using Xceed.Wpf.AvalonDock.Themes;

namespace Xceed.Wpf.AvalonDock.Controls;

[TemplatePart(Name = "PART_AnchorableListBox", Type = typeof(ListBox))]
[TemplatePart(Name = "PART_DocumentListBox", Type = typeof(ListBox))]
public class NavigatorWindow : Window
{
	private const string PART_AnchorableListBox = "PART_AnchorableListBox";

	private const string PART_DocumentListBox = "PART_DocumentListBox";

	private ResourceDictionary currentThemeResourceDictionary;

	private DockingManager _manager;

	private bool _isSelectingDocument;

	private ListBox _anchorableListBox;

	private ListBox _documentListBox;

	private bool _internalSetSelectedDocument;

	private bool _internalSetSelectedAnchorable;

	private static readonly DependencyPropertyKey DocumentsPropertyKey;

	public static readonly DependencyProperty DocumentsProperty;

	private static readonly DependencyPropertyKey AnchorablesPropertyKey;

	public static readonly DependencyProperty AnchorablesProperty;

	public static readonly DependencyProperty SelectedDocumentProperty;

	public static readonly DependencyProperty SelectedAnchorableProperty;

	public static readonly DependencyProperty LayoutDocumentsLabelProperty;

	public static readonly DependencyProperty LayoutAnchorablesLabelProperty;

	public LayoutDocumentItem[] Documents => (LayoutDocumentItem[])((DependencyObject)this).GetValue(DocumentsProperty);

	public IEnumerable<LayoutAnchorableItem> Anchorables => (IEnumerable<LayoutAnchorableItem>)((DependencyObject)this).GetValue(AnchorablesProperty);

	public LayoutDocumentItem SelectedDocument
	{
		get
		{
			return (LayoutDocumentItem)((DependencyObject)this).GetValue(SelectedDocumentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedDocumentProperty, (object)value);
		}
	}

	public LayoutAnchorableItem SelectedAnchorable
	{
		get
		{
			return (LayoutAnchorableItem)((DependencyObject)this).GetValue(SelectedAnchorableProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedAnchorableProperty, (object)value);
		}
	}

	public string LayoutDocumentsLabel
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(LayoutDocumentsLabelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LayoutDocumentsLabelProperty, (object)value);
		}
	}

	public string LayoutAnchorablesLabel
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(LayoutAnchorablesLabelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LayoutAnchorablesLabelProperty, (object)value);
		}
	}

	static NavigatorWindow()
	{
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		DocumentsPropertyKey = DependencyProperty.RegisterReadOnly("Documents", typeof(IEnumerable<LayoutDocumentItem>), typeof(NavigatorWindow), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null));
		DocumentsProperty = DocumentsPropertyKey.DependencyProperty;
		AnchorablesPropertyKey = DependencyProperty.RegisterReadOnly("Anchorables", typeof(IEnumerable<LayoutAnchorableItem>), typeof(NavigatorWindow), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null));
		AnchorablesProperty = AnchorablesPropertyKey.DependencyProperty;
		SelectedDocumentProperty = DependencyProperty.Register("SelectedDocument", typeof(LayoutDocumentItem), typeof(NavigatorWindow), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnSelectedDocumentChanged)));
		SelectedAnchorableProperty = DependencyProperty.Register("SelectedAnchorable", typeof(LayoutAnchorableItem), typeof(NavigatorWindow), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnSelectedAnchorableChanged)));
		LayoutDocumentsLabelProperty = DependencyProperty.Register("LayoutDocumentsLabel", typeof(string), typeof(NavigatorWindow), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)"Active Files"));
		LayoutAnchorablesLabelProperty = DependencyProperty.Register("LayoutAnchorablesLabel", typeof(string), typeof(NavigatorWindow), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)"Active Tool Windows"));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(NavigatorWindow), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(NavigatorWindow)));
		Window.ShowActivatedProperty.OverrideMetadata(typeof(NavigatorWindow), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));
		Window.ShowInTaskbarProperty.OverrideMetadata(typeof(NavigatorWindow), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));
	}

	public NavigatorWindow(DockingManager manager)
	{
		_manager = manager;
		_internalSetSelectedDocument = true;
		SetAnchorables((from d in _manager.Layout.Descendents().OfType<LayoutAnchorable>()
			where d.IsVisible && d.IsEnabled
			select (LayoutAnchorableItem)_manager.GetLayoutItemFromModel(d)).ToArray());
		SetDocuments((from d in _manager.Layout.Descendents().OfType<LayoutDocument>()
			where d.IsEnabled
			orderby d.LastActivationTimeStamp.GetValueOrDefault() descending
			select (LayoutDocumentItem)_manager.GetLayoutItemFromModel(d)).ToArray());
		_internalSetSelectedDocument = false;
		if (Documents != null && Documents.Length > 1)
		{
			InternalSetSelectedDocument(Documents[1]);
			_isSelectingDocument = true;
		}
		else if (Anchorables != null && Anchorables.Count() > 1)
		{
			InternalSetSelectedAnchorable(Anchorables.ToArray()[1]);
			_isSelectingDocument = false;
		}
		base.DataContext = this;
		base.Loaded += OnLoaded;
		base.Unloaded += OnUnloaded;
		UpdateThemeResources();
	}

	private static void OnSelectedDocumentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((NavigatorWindow)(object)d).OnSelectedDocumentChanged(e);
	}

	protected virtual void OnSelectedDocumentChanged(DependencyPropertyChangedEventArgs e)
	{
		if (!_internalSetSelectedDocument && SelectedDocument != null && SelectedDocument.ActivateCommand.CanExecute(null))
		{
			Hide();
			SelectedDocument.ActivateCommand.Execute(null);
		}
	}

	private static void OnSelectedAnchorableChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((NavigatorWindow)(object)d).OnSelectedAnchorableChanged(e);
	}

	protected virtual void OnSelectedAnchorableChanged(DependencyPropertyChangedEventArgs e)
	{
		if (!_internalSetSelectedAnchorable)
		{
			_ = ((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
			if (SelectedAnchorable != null && SelectedAnchorable.ActivateCommand.CanExecute(null))
			{
				Close();
				SelectedAnchorable.ActivateCommand.Execute(null);
			}
		}
	}

	public override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		_anchorableListBox = GetTemplateChild("PART_AnchorableListBox") as ListBox;
		_documentListBox = GetTemplateChild("PART_DocumentListBox") as ListBox;
	}

	protected override void OnPreviewKeyDown(KeyEventArgs e)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Invalid comparison between Unknown and I4
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Invalid comparison between Unknown and I4
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Invalid comparison between Unknown and I4
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Invalid comparison between Unknown and I4
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Invalid comparison between Unknown and I4
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Invalid comparison between Unknown and I4
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Invalid comparison between Unknown and I4
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Invalid comparison between Unknown and I4
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Invalid comparison between Unknown and I4
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Invalid comparison between Unknown and I4
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Invalid comparison between Unknown and I4
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Invalid comparison between Unknown and I4
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Invalid comparison between Unknown and I4
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Invalid comparison between Unknown and I4
		bool flag = false;
		if ((int)e.Key == 3 || (int)e.Key == 23 || (int)e.Key == 25 || (int)e.Key == 24 || (int)e.Key == 26)
		{
			if (_isSelectingDocument)
			{
				if (SelectedDocument != null && Documents != null)
				{
					int num = Documents.IndexOf(SelectedDocument);
					if ((int)e.Key == 3)
					{
						if (num < Documents.Length - 1 || Anchorables == null || Anchorables.Count() == 0)
						{
							SelectNextDocument();
							flag = true;
						}
						else if (Anchorables.Count() > 0)
						{
							_isSelectingDocument = false;
							InternalSetSelectedDocument(null);
							InternalSetSelectedAnchorable(Anchorables.First());
							flag = true;
						}
					}
					else if ((int)e.Key == 26)
					{
						SelectNextDocument();
						flag = true;
					}
					else if ((int)e.Key == 24)
					{
						SelectPreviousDocument();
						flag = true;
					}
					else if ((int)e.Key == 23 || (int)e.Key == 25)
					{
						if (Anchorables != null && Anchorables.Count() > 0)
						{
							_isSelectingDocument = false;
							InternalSetSelectedDocument(null);
							if (num < Anchorables.Count())
							{
								LayoutAnchorableItem[] array = Anchorables.ToArray();
								InternalSetSelectedAnchorable(array[num]);
							}
							else
							{
								InternalSetSelectedAnchorable(Anchorables.Last());
							}
						}
						flag = true;
					}
				}
				else if (Documents != null && Documents.Length != 0)
				{
					InternalSetSelectedDocument(Documents[0]);
					flag = true;
				}
			}
			else if (SelectedAnchorable != null)
			{
				int num2 = ((Anchorables != null) ? Anchorables.ToArray().IndexOf(SelectedAnchorable) : (-1));
				if ((int)e.Key == 3)
				{
					if ((Anchorables != null && num2 < Anchorables.Count() - 1) || (Documents != null && Documents.Length == 0))
					{
						SelectNextAnchorable();
						flag = true;
					}
					else if (Documents != null && Documents.Length != 0)
					{
						_isSelectingDocument = true;
						InternalSetSelectedAnchorable(null);
						InternalSetSelectedDocument(Documents[0]);
						flag = true;
					}
				}
				else if ((int)e.Key == 26)
				{
					SelectNextAnchorable();
					flag = true;
				}
				else if ((int)e.Key == 24)
				{
					SelectPreviousAnchorable();
					flag = true;
				}
				else if ((int)e.Key == 23 || (int)e.Key == 25)
				{
					if (Documents != null && Documents.Count() > 0)
					{
						_isSelectingDocument = true;
						InternalSetSelectedAnchorable(null);
						if (num2 < Documents.Count())
						{
							InternalSetSelectedDocument(Documents[num2]);
						}
						else
						{
							InternalSetSelectedDocument(Documents.Last());
						}
					}
					flag = true;
				}
			}
			else if (Anchorables != null && Anchorables.Count() > 0)
			{
				InternalSetSelectedAnchorable(Anchorables.ToArray()[0]);
				flag = true;
			}
		}
		if (flag)
		{
			e.Handled = true;
		}
		base.OnPreviewKeyDown(e);
	}

	protected override void OnPreviewKeyUp(KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Invalid comparison between Unknown and I4
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Invalid comparison between Unknown and I4
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Invalid comparison between Unknown and I4
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Invalid comparison between Unknown and I4
		if ((int)e.Key != 3 && (int)e.Key != 23 && (int)e.Key != 25 && (int)e.Key != 24 && (int)e.Key != 26)
		{
			Close();
			if (SelectedDocument != null && SelectedDocument.ActivateCommand.CanExecute(null))
			{
				SelectedDocument.ActivateCommand.Execute(null);
				FocusContent(SelectedDocument);
			}
			if (SelectedDocument == null && SelectedAnchorable != null && SelectedAnchorable.ActivateCommand.CanExecute(null))
			{
				SelectedAnchorable.ActivateCommand.Execute(null);
				FocusContent(SelectedAnchorable);
			}
			e.Handled = true;
		}
		base.OnPreviewKeyUp(e);
	}

	protected void SetAnchorables(IEnumerable<LayoutAnchorableItem> value)
	{
		((DependencyObject)this).SetValue(AnchorablesPropertyKey, (object)value);
	}

	protected void SetDocuments(LayoutDocumentItem[] value)
	{
		((DependencyObject)this).SetValue(DocumentsPropertyKey, (object)value);
	}

	internal void UpdateThemeResources(Theme oldTheme = null)
	{
		if (oldTheme != null)
		{
			if (oldTheme is DictionaryTheme)
			{
				if (currentThemeResourceDictionary != null)
				{
					base.Resources.MergedDictionaries.Remove(currentThemeResourceDictionary);
					currentThemeResourceDictionary = null;
				}
			}
			else
			{
				ResourceDictionary resourceDictionary = base.Resources.MergedDictionaries.FirstOrDefault((ResourceDictionary r) => r.Source == oldTheme.GetResourceUri());
				if (resourceDictionary != null)
				{
					base.Resources.MergedDictionaries.Remove(resourceDictionary);
				}
			}
		}
		if (_manager.Theme != null)
		{
			if (_manager.Theme is DictionaryTheme)
			{
				currentThemeResourceDictionary = ((DictionaryTheme)_manager.Theme).ThemeResourceDictionary;
				base.Resources.MergedDictionaries.Add(currentThemeResourceDictionary);
			}
			else
			{
				base.Resources.MergedDictionaries.Add(new ResourceDictionary
				{
					Source = _manager.Theme.GetResourceUri()
				});
			}
		}
	}

	internal void SelectNextDocument()
	{
		if (SelectedDocument != null && Documents != null)
		{
			int num = Documents.IndexOf(SelectedDocument);
			num++;
			if (num == Documents.Length)
			{
				num = 0;
			}
			InternalSetSelectedDocument(Documents[num]);
		}
	}

	internal void SelectPreviousDocument()
	{
		if (SelectedDocument != null && Documents != null)
		{
			int num = Documents.IndexOf(SelectedDocument);
			num--;
			if (num == -1)
			{
				num = Documents.Length - 1;
			}
			InternalSetSelectedDocument(Documents[num]);
		}
	}

	internal void SelectNextAnchorable()
	{
		if (SelectedAnchorable != null && Anchorables != null)
		{
			LayoutAnchorableItem[] array = Anchorables.ToArray();
			int num = array.IndexOf(SelectedAnchorable);
			num++;
			if (num == Anchorables.Count())
			{
				num = 0;
			}
			InternalSetSelectedAnchorable(array[num]);
		}
	}

	internal void SelectPreviousAnchorable()
	{
		if (SelectedAnchorable != null && Anchorables != null)
		{
			LayoutAnchorableItem[] array = Anchorables.ToArray();
			int num = array.IndexOf(SelectedAnchorable);
			num--;
			if (num == -1)
			{
				num = Anchorables.Count() - 1;
			}
			InternalSetSelectedAnchorable(array[num]);
		}
	}

	private void InternalSetSelectedAnchorable(LayoutAnchorableItem anchorableToSelect)
	{
		_internalSetSelectedAnchorable = true;
		SelectedAnchorable = anchorableToSelect;
		_internalSetSelectedAnchorable = false;
		if (_anchorableListBox != null)
		{
			_anchorableListBox.Focus();
		}
	}

	private void InternalSetSelectedDocument(LayoutDocumentItem documentToSelect)
	{
		_internalSetSelectedDocument = true;
		SelectedDocument = documentToSelect;
		_internalSetSelectedDocument = false;
		if (_documentListBox != null && documentToSelect != null)
		{
			_documentListBox.Focus();
		}
	}

	private void FocusContent(LayoutItem layoutItem)
	{
		if (layoutItem == null || layoutItem.LayoutElement == null)
		{
			return;
		}
		UIElement content = layoutItem.LayoutElement.Content as UIElement;
		if (content == null)
		{
			return;
		}
		((DispatcherObject)this).Dispatcher.BeginInvoke((DispatcherPriority)5, (Delegate)(Action)delegate
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Expected O, but got Unknown
			if (content.Focusable)
			{
				content.Focus();
			}
			else
			{
				content.MoveFocus(new TraversalRequest((FocusNavigationDirection)0));
			}
		});
	}

	private void OnLoaded(object sender, RoutedEventArgs e)
	{
		base.Loaded -= OnLoaded;
		if (_documentListBox != null && SelectedDocument != null)
		{
			_documentListBox.Focus();
		}
		else if (_anchorableListBox != null && SelectedAnchorable != null)
		{
			_anchorableListBox.Focus();
		}
		base.WindowStartupLocation = WindowStartupLocation.CenterOwner;
	}

	private void OnUnloaded(object sender, RoutedEventArgs e)
	{
		base.Unloaded -= OnUnloaded;
	}
}
