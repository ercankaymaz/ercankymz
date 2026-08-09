using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using Xceed.Wpf.AvalonDock.Commands;
using Xceed.Wpf.AvalonDock.Layout;

namespace Xceed.Wpf.AvalonDock.Controls;

public abstract class LayoutItem : FrameworkElement
{
	private ICommand _defaultCloseCommand;

	private ICommand _defaultFloatCommand;

	private ICommand _defaultDockAsDocumentCommand;

	private ICommand _defaultCloseAllButThisCommand;

	private ICommand _defaultCloseAllCommand;

	private ICommand _defaultActivateCommand;

	private ICommand _defaultNewVerticalTabGroupCommand;

	private ICommand _defaultNewHorizontalTabGroupCommand;

	private ICommand _defaultMoveToNextTabGroupCommand;

	private ICommand _defaultMoveToPreviousTabGroupCommand;

	internal ContentPresenter _view;

	private ReentrantFlag _isSelectedReentrantFlag = new ReentrantFlag();

	private ReentrantFlag _isActiveReentrantFlag = new ReentrantFlag();

	public static readonly DependencyProperty TitleProperty;

	public static readonly DependencyProperty IconSourceProperty;

	public static readonly DependencyProperty ContentIdProperty;

	public static readonly DependencyProperty IsSelectedProperty;

	public static readonly DependencyProperty IsActiveProperty;

	public static readonly DependencyProperty CanCloseProperty;

	public static readonly DependencyProperty CanFloatProperty;

	public static readonly DependencyProperty CloseCommandProperty;

	public static readonly DependencyProperty FloatCommandProperty;

	public static readonly DependencyProperty DockAsDocumentCommandProperty;

	public static readonly DependencyProperty CloseAllButThisCommandProperty;

	public static readonly DependencyProperty CloseAllCommandProperty;

	public static readonly DependencyProperty ActivateCommandProperty;

	public static readonly DependencyProperty NewVerticalTabGroupCommandProperty;

	public static readonly DependencyProperty NewHorizontalTabGroupCommandProperty;

	public static readonly DependencyProperty MoveToNextTabGroupCommandProperty;

	public static readonly DependencyProperty MoveToPreviousTabGroupCommandProperty;

	public LayoutContent LayoutElement { get; private set; }

	public object Model { get; private set; }

	public ContentPresenter View
	{
		get
		{
			if (_view == null)
			{
				_view = new ContentPresenter();
				_view.SetBinding(ContentPresenter.ContentProperty, new Binding("Content")
				{
					Source = LayoutElement
				});
				if (LayoutElement != null && LayoutElement.Root != null)
				{
					_view.SetBinding(ContentPresenter.ContentTemplateProperty, new Binding("LayoutItemTemplate")
					{
						Source = LayoutElement.Root.Manager
					});
					_view.SetBinding(ContentPresenter.ContentTemplateSelectorProperty, new Binding("LayoutItemTemplateSelector")
					{
						Source = LayoutElement.Root.Manager
					});
					if (LayoutElement.Root.Manager != null)
					{
						LayoutElement.Root.Manager.InternalAddLogicalChild(_view);
					}
				}
			}
			return _view;
		}
	}

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

	public ImageSource IconSource
	{
		get
		{
			return (ImageSource)((DependencyObject)this).GetValue(IconSourceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IconSourceProperty, (object)value);
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
			return (bool)((DependencyObject)this).GetValue(IsSelectedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsSelectedProperty, (object)value);
		}
	}

	public bool IsActive
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsActiveProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsActiveProperty, (object)value);
		}
	}

	public bool CanClose
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanCloseProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanCloseProperty, (object)value);
		}
	}

	public bool CanFloat
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanFloatProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanFloatProperty, (object)value);
		}
	}

	public ICommand CloseCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(CloseCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CloseCommandProperty, (object)value);
		}
	}

	public ICommand FloatCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(FloatCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FloatCommandProperty, (object)value);
		}
	}

	public ICommand DockAsDocumentCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(DockAsDocumentCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DockAsDocumentCommandProperty, (object)value);
		}
	}

	public ICommand CloseAllButThisCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(CloseAllButThisCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CloseAllButThisCommandProperty, (object)value);
		}
	}

	public ICommand CloseAllCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(CloseAllCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CloseAllCommandProperty, (object)value);
		}
	}

	public ICommand ActivateCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(ActivateCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActivateCommandProperty, (object)value);
		}
	}

	public ICommand NewVerticalTabGroupCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(NewVerticalTabGroupCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(NewVerticalTabGroupCommandProperty, (object)value);
		}
	}

	public ICommand NewHorizontalTabGroupCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(NewHorizontalTabGroupCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(NewHorizontalTabGroupCommandProperty, (object)value);
		}
	}

	public ICommand MoveToNextTabGroupCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(MoveToNextTabGroupCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MoveToNextTabGroupCommandProperty, (object)value);
		}
	}

	public ICommand MoveToPreviousTabGroupCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(MoveToPreviousTabGroupCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MoveToPreviousTabGroupCommandProperty, (object)value);
		}
	}

	static LayoutItem()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected O, but got Unknown
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Expected O, but got Unknown
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		//IL_01be: Expected O, but got Unknown
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Expected O, but got Unknown
		//IL_01ff: Expected O, but got Unknown
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Expected O, but got Unknown
		//IL_0240: Expected O, but got Unknown
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Expected O, but got Unknown
		//IL_0281: Expected O, but got Unknown
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Expected O, but got Unknown
		//IL_02c2: Expected O, but got Unknown
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0303: Expected O, but got Unknown
		//IL_0303: Expected O, but got Unknown
		//IL_032e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0338: Expected O, but got Unknown
		//IL_0363: Unknown result type (might be due to invalid IL or missing references)
		//IL_036d: Expected O, but got Unknown
		//IL_0398: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a2: Expected O, but got Unknown
		//IL_03cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d7: Expected O, but got Unknown
		//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0406: Expected O, but got Unknown
		//IL_042b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0435: Expected O, but got Unknown
		TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(LayoutItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnTitleChanged)));
		IconSourceProperty = DependencyProperty.Register("IconSource", typeof(ImageSource), typeof(LayoutItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnIconSourceChanged)));
		ContentIdProperty = DependencyProperty.Register("ContentId", typeof(string), typeof(LayoutItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnContentIdChanged)));
		IsSelectedProperty = DependencyProperty.Register("IsSelected", typeof(bool), typeof(LayoutItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, new PropertyChangedCallback(OnIsSelectedChanged)));
		IsActiveProperty = DependencyProperty.Register("IsActive", typeof(bool), typeof(LayoutItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, new PropertyChangedCallback(OnIsActiveChanged)));
		CanCloseProperty = DependencyProperty.Register("CanClose", typeof(bool), typeof(LayoutItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true, new PropertyChangedCallback(OnCanCloseChanged)));
		CanFloatProperty = DependencyProperty.Register("CanFloat", typeof(bool), typeof(LayoutItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true, new PropertyChangedCallback(OnCanFloatChanged)));
		CloseCommandProperty = DependencyProperty.Register("CloseCommand", typeof(ICommand), typeof(LayoutItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnCloseCommandChanged), new CoerceValueCallback(CoerceCloseCommandValue)));
		FloatCommandProperty = DependencyProperty.Register("FloatCommand", typeof(ICommand), typeof(LayoutItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnFloatCommandChanged), new CoerceValueCallback(CoerceFloatCommandValue)));
		DockAsDocumentCommandProperty = DependencyProperty.Register("DockAsDocumentCommand", typeof(ICommand), typeof(LayoutItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnDockAsDocumentCommandChanged), new CoerceValueCallback(CoerceDockAsDocumentCommandValue)));
		CloseAllButThisCommandProperty = DependencyProperty.Register("CloseAllButThisCommand", typeof(ICommand), typeof(LayoutItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnCloseAllButThisCommandChanged), new CoerceValueCallback(CoerceCloseAllButThisCommandValue)));
		CloseAllCommandProperty = DependencyProperty.Register("CloseAllCommand", typeof(ICommand), typeof(LayoutItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnCloseAllCommandChanged), new CoerceValueCallback(CoerceCloseAllCommandValue)));
		ActivateCommandProperty = DependencyProperty.Register("ActivateCommand", typeof(ICommand), typeof(LayoutItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnActivateCommandChanged), new CoerceValueCallback(CoerceActivateCommandValue)));
		NewVerticalTabGroupCommandProperty = DependencyProperty.Register("NewVerticalTabGroupCommand", typeof(ICommand), typeof(LayoutItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnNewVerticalTabGroupCommandChanged)));
		NewHorizontalTabGroupCommandProperty = DependencyProperty.Register("NewHorizontalTabGroupCommand", typeof(ICommand), typeof(LayoutItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnNewHorizontalTabGroupCommandChanged)));
		MoveToNextTabGroupCommandProperty = DependencyProperty.Register("MoveToNextTabGroupCommand", typeof(ICommand), typeof(LayoutItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnMoveToNextTabGroupCommandChanged)));
		MoveToPreviousTabGroupCommandProperty = DependencyProperty.Register("MoveToPreviousTabGroupCommand", typeof(ICommand), typeof(LayoutItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnMoveToPreviousTabGroupCommandChanged)));
		FrameworkElement.ToolTipProperty.OverrideMetadata(typeof(LayoutItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, (PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			OnToolTipChanged(s, e);
		}));
		UIElement.VisibilityProperty.OverrideMetadata(typeof(LayoutItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Visibility.Visible, (PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			OnVisibilityChanged(s, e);
		}));
	}

	internal LayoutItem()
	{
	}

	private static void OnTitleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((LayoutItem)(object)d).OnTitleChanged(e);
	}

	protected virtual void OnTitleChanged(DependencyPropertyChangedEventArgs e)
	{
		if (LayoutElement != null)
		{
			LayoutElement.Title = (string)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}
	}

	private static void OnIconSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((LayoutItem)(object)d).OnIconSourceChanged(e);
	}

	protected virtual void OnIconSourceChanged(DependencyPropertyChangedEventArgs e)
	{
		if (LayoutElement != null)
		{
			LayoutElement.IconSource = IconSource;
		}
	}

	private static void OnContentIdChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((LayoutItem)(object)d).OnContentIdChanged(e);
	}

	protected virtual void OnContentIdChanged(DependencyPropertyChangedEventArgs e)
	{
		if (LayoutElement != null)
		{
			LayoutElement.ContentId = (string)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}
	}

	private static void OnIsSelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((LayoutItem)(object)d).OnIsSelectedChanged(e);
	}

	protected virtual void OnIsSelectedChanged(DependencyPropertyChangedEventArgs e)
	{
		if (!_isSelectedReentrantFlag.CanEnter)
		{
			return;
		}
		using (_isSelectedReentrantFlag.Enter())
		{
			if (LayoutElement != null)
			{
				LayoutElement.IsSelected = (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
			}
		}
	}

	private static void OnIsActiveChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((LayoutItem)(object)d).OnIsActiveChanged(e);
	}

	protected virtual void OnIsActiveChanged(DependencyPropertyChangedEventArgs e)
	{
		if (!_isActiveReentrantFlag.CanEnter)
		{
			return;
		}
		using (_isActiveReentrantFlag.Enter())
		{
			if (LayoutElement != null)
			{
				LayoutElement.IsActive = (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
			}
		}
	}

	private static void OnCanCloseChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((LayoutItem)(object)d).OnCanCloseChanged(e);
	}

	protected virtual void OnCanCloseChanged(DependencyPropertyChangedEventArgs e)
	{
		if (LayoutElement != null)
		{
			LayoutElement.CanClose = (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}
	}

	private static void OnCanFloatChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((LayoutItem)(object)d).OnCanFloatChanged(e);
	}

	protected virtual void OnCanFloatChanged(DependencyPropertyChangedEventArgs e)
	{
		if (LayoutElement != null)
		{
			LayoutElement.CanFloat = (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}
	}

	private static void OnCloseCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((LayoutItem)(object)d).OnCloseCommandChanged(e);
	}

	protected virtual void OnCloseCommandChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private static object CoerceCloseCommandValue(DependencyObject d, object value)
	{
		return value;
	}

	private bool CanExecuteCloseCommand(object parameter)
	{
		if (LayoutElement != null)
		{
			return LayoutElement.CanClose;
		}
		return false;
	}

	private void ExecuteCloseCommand(object parameter)
	{
		Close();
	}

	protected abstract void Close();

	private static void OnFloatCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((LayoutItem)(object)d).OnFloatCommandChanged(e);
	}

	protected virtual void OnFloatCommandChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private static object CoerceFloatCommandValue(DependencyObject d, object value)
	{
		return value;
	}

	private bool CanExecuteFloatCommand(object anchorable)
	{
		if (LayoutElement != null && LayoutElement.CanFloat)
		{
			return LayoutElement.FindParent<LayoutFloatingWindow>() == null;
		}
		return false;
	}

	private void ExecuteFloatCommand(object parameter)
	{
		LayoutElement.Root.Manager._ExecuteFloatCommand(LayoutElement);
	}

	protected virtual void Float()
	{
	}

	private static void OnDockAsDocumentCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((LayoutItem)(object)d).OnDockAsDocumentCommandChanged(e);
	}

	protected virtual void OnDockAsDocumentCommandChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private static object CoerceDockAsDocumentCommandValue(DependencyObject d, object value)
	{
		return value;
	}

	protected virtual bool CanExecuteDockAsDocumentCommand()
	{
		if (LayoutElement != null)
		{
			return LayoutElement.FindParent<LayoutDocumentPane>() == null;
		}
		return false;
	}

	private bool CanExecuteDockAsDocumentCommand(object parameter)
	{
		return CanExecuteDockAsDocumentCommand();
	}

	private void ExecuteDockAsDocumentCommand(object parameter)
	{
		LayoutElement.Root.Manager._ExecuteDockAsDocumentCommand(LayoutElement);
	}

	private static void OnCloseAllButThisCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((LayoutItem)(object)d).OnCloseAllButThisCommandChanged(e);
	}

	protected virtual void OnCloseAllButThisCommandChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private static object CoerceCloseAllButThisCommandValue(DependencyObject d, object value)
	{
		return value;
	}

	private bool CanExecuteCloseAllButThisCommand(object parameter)
	{
		if (LayoutElement == null)
		{
			return false;
		}
		if (LayoutElement.Root == null)
		{
			return false;
		}
		return (from d in LayoutElement.Root.Manager.Layout.Descendents().OfType<LayoutContent>()
			where d != LayoutElement && (d.Parent is LayoutDocumentPane || d.Parent is LayoutDocumentFloatingWindow)
			select d).Any();
	}

	private void ExecuteCloseAllButThisCommand(object parameter)
	{
		LayoutElement.Root.Manager._ExecuteCloseAllButThisCommand(LayoutElement);
	}

	private static void OnCloseAllCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((LayoutItem)(object)d).OnCloseAllCommandChanged(e);
	}

	protected virtual void OnCloseAllCommandChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private static object CoerceCloseAllCommandValue(DependencyObject d, object value)
	{
		return value;
	}

	private bool CanExecuteCloseAllCommand(object parameter)
	{
		if (LayoutElement == null)
		{
			return false;
		}
		if (LayoutElement.Root == null)
		{
			return false;
		}
		return (from d in LayoutElement.Root.Manager.Layout.Descendents().OfType<LayoutContent>()
			where d.Parent is LayoutDocumentPane || d.Parent is LayoutDocumentFloatingWindow
			select d).Any();
	}

	private void ExecuteCloseAllCommand(object parameter)
	{
		LayoutElement.Root.Manager._ExecuteCloseAllCommand(LayoutElement);
	}

	private static void OnActivateCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((LayoutItem)(object)d).OnActivateCommandChanged(e);
	}

	protected virtual void OnActivateCommandChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private static object CoerceActivateCommandValue(DependencyObject d, object value)
	{
		return value;
	}

	private bool CanExecuteActivateCommand(object parameter)
	{
		return LayoutElement != null;
	}

	private void ExecuteActivateCommand(object parameter)
	{
		LayoutElement.Root.Manager._ExecuteContentActivateCommand(LayoutElement);
	}

	private static void OnNewVerticalTabGroupCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((LayoutItem)(object)d).OnNewVerticalTabGroupCommandChanged(e);
	}

	protected virtual void OnNewVerticalTabGroupCommandChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private bool CanExecuteNewVerticalTabGroupCommand(object parameter)
	{
		if (LayoutElement == null)
		{
			return false;
		}
		if (LayoutElement is LayoutDocument { CanMove: false })
		{
			return false;
		}
		LayoutDocumentPaneGroup layoutDocumentPaneGroup = LayoutElement.FindParent<LayoutDocumentPaneGroup>();
		LayoutDocumentPane layoutDocumentPane = LayoutElement.Parent as LayoutDocumentPane;
		if ((layoutDocumentPaneGroup == null || layoutDocumentPaneGroup.ChildrenCount == 1 || layoutDocumentPaneGroup.Root.Manager.AllowMixedOrientation || layoutDocumentPaneGroup.Orientation == Orientation.Horizontal) && layoutDocumentPane != null)
		{
			return layoutDocumentPane.ChildrenCount > 1;
		}
		return false;
	}

	private void ExecuteNewVerticalTabGroupCommand(object parameter)
	{
		LayoutContent layoutElement = LayoutElement;
		LayoutDocumentPaneGroup layoutDocumentPaneGroup = layoutElement.FindParent<LayoutDocumentPaneGroup>();
		LayoutDocumentPane layoutDocumentPane = layoutElement.Parent as LayoutDocumentPane;
		if (layoutDocumentPaneGroup == null)
		{
			ILayoutContainer parent = layoutDocumentPane.Parent;
			layoutDocumentPaneGroup = new LayoutDocumentPaneGroup
			{
				Orientation = Orientation.Horizontal
			};
			parent.ReplaceChild(layoutDocumentPane, layoutDocumentPaneGroup);
			layoutDocumentPaneGroup.Children.Add(layoutDocumentPane);
		}
		layoutDocumentPaneGroup.Orientation = Orientation.Horizontal;
		int num = layoutDocumentPaneGroup.IndexOfChild(layoutDocumentPane);
		layoutDocumentPaneGroup.InsertChildAt(num + 1, new LayoutDocumentPane(layoutElement));
		layoutElement.IsActive = true;
		layoutElement.Root.CollectGarbage();
	}

	private static void OnNewHorizontalTabGroupCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((LayoutItem)(object)d).OnNewHorizontalTabGroupCommandChanged(e);
	}

	protected virtual void OnNewHorizontalTabGroupCommandChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private bool CanExecuteNewHorizontalTabGroupCommand(object parameter)
	{
		if (LayoutElement == null)
		{
			return false;
		}
		if (LayoutElement is LayoutDocument { CanMove: false })
		{
			return false;
		}
		LayoutDocumentPaneGroup layoutDocumentPaneGroup = LayoutElement.FindParent<LayoutDocumentPaneGroup>();
		LayoutDocumentPane layoutDocumentPane = LayoutElement.Parent as LayoutDocumentPane;
		if ((layoutDocumentPaneGroup == null || layoutDocumentPaneGroup.ChildrenCount == 1 || layoutDocumentPaneGroup.Root.Manager.AllowMixedOrientation || layoutDocumentPaneGroup.Orientation == Orientation.Vertical) && layoutDocumentPane != null)
		{
			return layoutDocumentPane.ChildrenCount > 1;
		}
		return false;
	}

	private void ExecuteNewHorizontalTabGroupCommand(object parameter)
	{
		LayoutContent layoutElement = LayoutElement;
		LayoutDocumentPaneGroup layoutDocumentPaneGroup = layoutElement.FindParent<LayoutDocumentPaneGroup>();
		LayoutDocumentPane layoutDocumentPane = layoutElement.Parent as LayoutDocumentPane;
		if (layoutDocumentPaneGroup == null)
		{
			ILayoutContainer parent = layoutDocumentPane.Parent;
			layoutDocumentPaneGroup = new LayoutDocumentPaneGroup
			{
				Orientation = Orientation.Vertical
			};
			parent.ReplaceChild(layoutDocumentPane, layoutDocumentPaneGroup);
			layoutDocumentPaneGroup.Children.Add(layoutDocumentPane);
		}
		layoutDocumentPaneGroup.Orientation = Orientation.Vertical;
		int num = layoutDocumentPaneGroup.IndexOfChild(layoutDocumentPane);
		layoutDocumentPaneGroup.InsertChildAt(num + 1, new LayoutDocumentPane(layoutElement));
		layoutElement.IsActive = true;
		layoutElement.Root.CollectGarbage();
	}

	private static void OnMoveToNextTabGroupCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((LayoutItem)(object)d).OnMoveToNextTabGroupCommandChanged(e);
	}

	protected virtual void OnMoveToNextTabGroupCommandChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private bool CanExecuteMoveToNextTabGroupCommand(object parameter)
	{
		if (LayoutElement == null)
		{
			return false;
		}
		LayoutDocumentPaneGroup layoutDocumentPaneGroup = LayoutElement.FindParent<LayoutDocumentPaneGroup>();
		LayoutDocumentPane layoutDocumentPane = LayoutElement.Parent as LayoutDocumentPane;
		if (layoutDocumentPaneGroup != null && layoutDocumentPane != null && layoutDocumentPaneGroup.ChildrenCount > 1 && layoutDocumentPaneGroup.IndexOfChild(layoutDocumentPane) < layoutDocumentPaneGroup.ChildrenCount - 1)
		{
			return layoutDocumentPaneGroup.Children[layoutDocumentPaneGroup.IndexOfChild(layoutDocumentPane) + 1] is LayoutDocumentPane;
		}
		return false;
	}

	private void ExecuteMoveToNextTabGroupCommand(object parameter)
	{
		LayoutContent layoutElement = LayoutElement;
		LayoutDocumentPaneGroup layoutDocumentPaneGroup = layoutElement.FindParent<LayoutDocumentPaneGroup>();
		LayoutDocumentPane element = layoutElement.Parent as LayoutDocumentPane;
		int num = layoutDocumentPaneGroup.IndexOfChild(element);
		(layoutDocumentPaneGroup.Children[num + 1] as LayoutDocumentPane).InsertChildAt(0, layoutElement);
		layoutElement.IsActive = true;
		layoutElement.Root.CollectGarbage();
	}

	private static void OnMoveToPreviousTabGroupCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((LayoutItem)(object)d).OnMoveToPreviousTabGroupCommandChanged(e);
	}

	protected virtual void OnMoveToPreviousTabGroupCommandChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private bool CanExecuteMoveToPreviousTabGroupCommand(object parameter)
	{
		if (LayoutElement == null)
		{
			return false;
		}
		LayoutDocumentPaneGroup layoutDocumentPaneGroup = LayoutElement.FindParent<LayoutDocumentPaneGroup>();
		LayoutDocumentPane layoutDocumentPane = LayoutElement.Parent as LayoutDocumentPane;
		if (layoutDocumentPaneGroup != null && layoutDocumentPane != null && layoutDocumentPaneGroup.ChildrenCount > 1 && layoutDocumentPaneGroup.IndexOfChild(layoutDocumentPane) > 0)
		{
			return layoutDocumentPaneGroup.Children[layoutDocumentPaneGroup.IndexOfChild(layoutDocumentPane) - 1] is LayoutDocumentPane;
		}
		return false;
	}

	private void ExecuteMoveToPreviousTabGroupCommand(object parameter)
	{
		LayoutContent layoutElement = LayoutElement;
		LayoutDocumentPaneGroup layoutDocumentPaneGroup = layoutElement.FindParent<LayoutDocumentPaneGroup>();
		LayoutDocumentPane element = layoutElement.Parent as LayoutDocumentPane;
		int num = layoutDocumentPaneGroup.IndexOfChild(element);
		(layoutDocumentPaneGroup.Children[num - 1] as LayoutDocumentPane).InsertChildAt(0, layoutElement);
		layoutElement.IsActive = true;
		layoutElement.Root.CollectGarbage();
	}

	protected virtual void InitDefaultCommands()
	{
		_defaultCloseCommand = new RelayCommand(delegate(object p)
		{
			ExecuteCloseCommand(p);
		}, (object p) => CanExecuteCloseCommand(p));
		_defaultFloatCommand = new RelayCommand(delegate(object p)
		{
			ExecuteFloatCommand(p);
		}, (object p) => CanExecuteFloatCommand(p));
		_defaultDockAsDocumentCommand = new RelayCommand(delegate(object p)
		{
			ExecuteDockAsDocumentCommand(p);
		}, (object p) => CanExecuteDockAsDocumentCommand(p));
		_defaultCloseAllButThisCommand = new RelayCommand(delegate(object p)
		{
			ExecuteCloseAllButThisCommand(p);
		}, (object p) => CanExecuteCloseAllButThisCommand(p));
		_defaultCloseAllCommand = new RelayCommand(delegate(object p)
		{
			ExecuteCloseAllCommand(p);
		}, (object p) => CanExecuteCloseAllCommand(p));
		_defaultActivateCommand = new RelayCommand(delegate(object p)
		{
			ExecuteActivateCommand(p);
		}, (object p) => CanExecuteActivateCommand(p));
		_defaultNewVerticalTabGroupCommand = new RelayCommand(delegate(object p)
		{
			ExecuteNewVerticalTabGroupCommand(p);
		}, (object p) => CanExecuteNewVerticalTabGroupCommand(p));
		_defaultNewHorizontalTabGroupCommand = new RelayCommand(delegate(object p)
		{
			ExecuteNewHorizontalTabGroupCommand(p);
		}, (object p) => CanExecuteNewHorizontalTabGroupCommand(p));
		_defaultMoveToNextTabGroupCommand = new RelayCommand(delegate(object p)
		{
			ExecuteMoveToNextTabGroupCommand(p);
		}, (object p) => CanExecuteMoveToNextTabGroupCommand(p));
		_defaultMoveToPreviousTabGroupCommand = new RelayCommand(delegate(object p)
		{
			ExecuteMoveToPreviousTabGroupCommand(p);
		}, (object p) => CanExecuteMoveToPreviousTabGroupCommand(p));
	}

	protected virtual void ClearDefaultCommands()
	{
		_defaultCloseCommand = null;
		_defaultFloatCommand = null;
		_defaultDockAsDocumentCommand = null;
		_defaultCloseAllButThisCommand = null;
		_defaultCloseAllCommand = null;
		_defaultActivateCommand = null;
		_defaultNewVerticalTabGroupCommand = null;
		_defaultNewHorizontalTabGroupCommand = null;
		_defaultMoveToNextTabGroupCommand = null;
		_defaultMoveToPreviousTabGroupCommand = null;
	}

	protected virtual void ClearDefaultBindings()
	{
		if (CloseCommand == _defaultCloseCommand)
		{
			BindingOperations.ClearBinding((DependencyObject)(object)this, CloseCommandProperty);
			CloseCommand = null;
		}
		if (FloatCommand == _defaultFloatCommand)
		{
			BindingOperations.ClearBinding((DependencyObject)(object)this, FloatCommandProperty);
			FloatCommand = null;
		}
		if (DockAsDocumentCommand == _defaultDockAsDocumentCommand)
		{
			BindingOperations.ClearBinding((DependencyObject)(object)this, DockAsDocumentCommandProperty);
			DockAsDocumentCommand = null;
		}
		if (CloseAllButThisCommand == _defaultCloseAllButThisCommand)
		{
			BindingOperations.ClearBinding((DependencyObject)(object)this, CloseAllButThisCommandProperty);
			CloseAllButThisCommand = null;
		}
		if (CloseAllCommand == _defaultCloseAllCommand)
		{
			BindingOperations.ClearBinding((DependencyObject)(object)this, CloseAllCommandProperty);
			CloseAllCommand = null;
		}
		if (ActivateCommand == _defaultActivateCommand)
		{
			BindingOperations.ClearBinding((DependencyObject)(object)this, ActivateCommandProperty);
			ActivateCommand = null;
		}
		if (NewVerticalTabGroupCommand == _defaultNewVerticalTabGroupCommand)
		{
			BindingOperations.ClearBinding((DependencyObject)(object)this, NewVerticalTabGroupCommandProperty);
			NewVerticalTabGroupCommand = null;
		}
		if (NewHorizontalTabGroupCommand == _defaultNewHorizontalTabGroupCommand)
		{
			BindingOperations.ClearBinding((DependencyObject)(object)this, NewHorizontalTabGroupCommandProperty);
			NewHorizontalTabGroupCommand = null;
		}
		if (MoveToNextTabGroupCommand == _defaultMoveToNextTabGroupCommand)
		{
			BindingOperations.ClearBinding((DependencyObject)(object)this, MoveToNextTabGroupCommandProperty);
			MoveToNextTabGroupCommand = null;
		}
		if (MoveToPreviousTabGroupCommand == _defaultMoveToPreviousTabGroupCommand)
		{
			BindingOperations.ClearBinding((DependencyObject)(object)this, MoveToPreviousTabGroupCommandProperty);
			MoveToPreviousTabGroupCommand = null;
		}
	}

	protected virtual void SetDefaultBindings()
	{
		if (CloseCommand == null)
		{
			((DependencyObject)this).SetCurrentValue(CloseCommandProperty, (object)_defaultCloseCommand);
		}
		if (FloatCommand == null)
		{
			((DependencyObject)this).SetCurrentValue(FloatCommandProperty, (object)_defaultFloatCommand);
		}
		if (DockAsDocumentCommand == null)
		{
			((DependencyObject)this).SetCurrentValue(DockAsDocumentCommandProperty, (object)_defaultDockAsDocumentCommand);
		}
		if (CloseAllButThisCommand == null)
		{
			((DependencyObject)this).SetCurrentValue(CloseAllButThisCommandProperty, (object)_defaultCloseAllButThisCommand);
		}
		if (CloseAllCommand == null)
		{
			((DependencyObject)this).SetCurrentValue(CloseAllCommandProperty, (object)_defaultCloseAllCommand);
		}
		if (ActivateCommand == null)
		{
			((DependencyObject)this).SetCurrentValue(ActivateCommandProperty, (object)_defaultActivateCommand);
		}
		if (NewVerticalTabGroupCommand == null)
		{
			((DependencyObject)this).SetCurrentValue(NewVerticalTabGroupCommandProperty, (object)_defaultNewVerticalTabGroupCommand);
		}
		if (NewHorizontalTabGroupCommand == null)
		{
			((DependencyObject)this).SetCurrentValue(NewHorizontalTabGroupCommandProperty, (object)_defaultNewHorizontalTabGroupCommand);
		}
		if (MoveToNextTabGroupCommand == null)
		{
			((DependencyObject)this).SetCurrentValue(MoveToNextTabGroupCommandProperty, (object)_defaultMoveToNextTabGroupCommand);
		}
		if (MoveToPreviousTabGroupCommand == null)
		{
			((DependencyObject)this).SetCurrentValue(MoveToPreviousTabGroupCommandProperty, (object)_defaultMoveToPreviousTabGroupCommand);
		}
		((DependencyObject)this).SetCurrentValue(IsSelectedProperty, (object)LayoutElement.IsSelected);
		((DependencyObject)this).SetCurrentValue(IsActiveProperty, (object)LayoutElement.IsActive);
		((DependencyObject)this).SetCurrentValue(CanCloseProperty, (object)LayoutElement.CanClose);
	}

	protected virtual void OnVisibilityChanged()
	{
		if (LayoutElement != null && base.Visibility == Visibility.Collapsed)
		{
			LayoutElement.Close();
		}
	}

	internal virtual void Attach(LayoutContent model)
	{
		LayoutElement = model;
		Model = model.Content;
		InitDefaultCommands();
		LayoutElement.IsSelectedChanged += LayoutElement_IsSelectedChanged;
		LayoutElement.IsActiveChanged += LayoutElement_IsActiveChanged;
		base.DataContext = this;
	}

	internal virtual void Detach()
	{
		ClearDefaultCommands();
		LayoutElement.IsSelectedChanged -= LayoutElement_IsSelectedChanged;
		LayoutElement.IsActiveChanged -= LayoutElement_IsActiveChanged;
		LayoutElement = null;
		Model = null;
		base.DataContext = null;
	}

	internal void _ClearDefaultBindings()
	{
		ClearDefaultBindings();
	}

	internal void _SetDefaultBindings()
	{
		SetDefaultBindings();
	}

	internal bool IsViewExists()
	{
		return _view != null;
	}

	private void LayoutElement_IsActiveChanged(object sender, EventArgs e)
	{
		if (_isActiveReentrantFlag.CanEnter)
		{
			using (_isActiveReentrantFlag.Enter())
			{
				IsActive = LayoutElement.IsActive;
			}
		}
	}

	private void LayoutElement_IsSelectedChanged(object sender, EventArgs e)
	{
		if (_isSelectedReentrantFlag.CanEnter)
		{
			using (_isSelectedReentrantFlag.Enter())
			{
				IsSelected = LayoutElement.IsSelected;
			}
		}
	}

	private static void OnToolTipChanged(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((LayoutItem)(object)s).OnToolTipChanged();
	}

	private void OnToolTipChanged()
	{
		if (LayoutElement != null)
		{
			LayoutElement.ToolTip = base.ToolTip;
		}
	}

	private static void OnVisibilityChanged(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((LayoutItem)(object)s).OnVisibilityChanged();
	}
}
