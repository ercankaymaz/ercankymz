using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Xceed.Wpf.Toolkit;

public class WizardPage : ContentControl
{
	public static readonly DependencyProperty BackButtonVisibilityProperty;

	public static readonly DependencyProperty CanCancelProperty;

	public static readonly DependencyProperty CancelButtonVisibilityProperty;

	public static readonly DependencyProperty CanFinishProperty;

	public static readonly DependencyProperty CanHelpProperty;

	public static readonly DependencyProperty CanSelectNextPageProperty;

	public static readonly DependencyProperty CanSelectPreviousPageProperty;

	public static readonly DependencyProperty DescriptionProperty;

	public static readonly DependencyProperty ExteriorPanelBackgroundProperty;

	public static readonly DependencyProperty ExteriorPanelContentProperty;

	public static readonly DependencyProperty FinishButtonVisibilityProperty;

	public static readonly DependencyProperty HeaderBackgroundProperty;

	public static readonly DependencyProperty HeaderImageProperty;

	public static readonly DependencyProperty HelpButtonVisibilityProperty;

	public static readonly DependencyProperty NextButtonVisibilityProperty;

	public static readonly DependencyProperty NextPageProperty;

	public static readonly DependencyProperty PageTypeProperty;

	public static readonly DependencyProperty PreviousPageProperty;

	public static readonly DependencyProperty TitleProperty;

	public static readonly RoutedEvent EnterEvent;

	public static readonly RoutedEvent LeaveEvent;

	public WizardPageButtonVisibility BackButtonVisibility
	{
		get
		{
			return (WizardPageButtonVisibility)((DependencyObject)this).GetValue(BackButtonVisibilityProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BackButtonVisibilityProperty, (object)value);
		}
	}

	public bool? CanCancel
	{
		get
		{
			return (bool?)((DependencyObject)this).GetValue(CanCancelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanCancelProperty, (object)value);
		}
	}

	public WizardPageButtonVisibility CancelButtonVisibility
	{
		get
		{
			return (WizardPageButtonVisibility)((DependencyObject)this).GetValue(CancelButtonVisibilityProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CancelButtonVisibilityProperty, (object)value);
		}
	}

	public bool? CanFinish
	{
		get
		{
			return (bool?)((DependencyObject)this).GetValue(CanFinishProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanFinishProperty, (object)value);
		}
	}

	public bool? CanHelp
	{
		get
		{
			return (bool?)((DependencyObject)this).GetValue(CanHelpProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanHelpProperty, (object)value);
		}
	}

	public bool? CanSelectNextPage
	{
		get
		{
			return (bool?)((DependencyObject)this).GetValue(CanSelectNextPageProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanSelectNextPageProperty, (object)value);
		}
	}

	public bool? CanSelectPreviousPage
	{
		get
		{
			return (bool?)((DependencyObject)this).GetValue(CanSelectPreviousPageProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanSelectPreviousPageProperty, (object)value);
		}
	}

	public string Description
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(DescriptionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DescriptionProperty, (object)value);
		}
	}

	public Brush ExteriorPanelBackground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(ExteriorPanelBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ExteriorPanelBackgroundProperty, (object)value);
		}
	}

	public object ExteriorPanelContent
	{
		get
		{
			return ((DependencyObject)this).GetValue(ExteriorPanelContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ExteriorPanelContentProperty, value);
		}
	}

	public WizardPageButtonVisibility FinishButtonVisibility
	{
		get
		{
			return (WizardPageButtonVisibility)((DependencyObject)this).GetValue(FinishButtonVisibilityProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FinishButtonVisibilityProperty, (object)value);
		}
	}

	public Brush HeaderBackground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(HeaderBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HeaderBackgroundProperty, (object)value);
		}
	}

	public ImageSource HeaderImage
	{
		get
		{
			return (ImageSource)((DependencyObject)this).GetValue(HeaderImageProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HeaderImageProperty, (object)value);
		}
	}

	public WizardPageButtonVisibility HelpButtonVisibility
	{
		get
		{
			return (WizardPageButtonVisibility)((DependencyObject)this).GetValue(HelpButtonVisibilityProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HelpButtonVisibilityProperty, (object)value);
		}
	}

	public WizardPageButtonVisibility NextButtonVisibility
	{
		get
		{
			return (WizardPageButtonVisibility)((DependencyObject)this).GetValue(NextButtonVisibilityProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(NextButtonVisibilityProperty, (object)value);
		}
	}

	public WizardPage NextPage
	{
		get
		{
			return (WizardPage)((DependencyObject)this).GetValue(NextPageProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(NextPageProperty, (object)value);
		}
	}

	public WizardPageType PageType
	{
		get
		{
			return (WizardPageType)((DependencyObject)this).GetValue(PageTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PageTypeProperty, (object)value);
		}
	}

	public WizardPage PreviousPage
	{
		get
		{
			return (WizardPage)((DependencyObject)this).GetValue(PreviousPageProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PreviousPageProperty, (object)value);
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

	public event RoutedEventHandler Enter
	{
		add
		{
			AddHandler(EnterEvent, value);
		}
		remove
		{
			RemoveHandler(EnterEvent, value);
		}
	}

	public event RoutedEventHandler Leave
	{
		add
		{
			AddHandler(LeaveEvent, value);
		}
		remove
		{
			RemoveHandler(LeaveEvent, value);
		}
	}

	static WizardPage()
	{
		BackButtonVisibilityProperty = DependencyProperty.Register("BackButtonVisibility", typeof(WizardPageButtonVisibility), typeof(WizardPage), (PropertyMetadata)(object)new UIPropertyMetadata((object)WizardPageButtonVisibility.Inherit));
		CanCancelProperty = DependencyProperty.Register("CanCancel", typeof(bool?), typeof(WizardPage), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		CancelButtonVisibilityProperty = DependencyProperty.Register("CancelButtonVisibility", typeof(WizardPageButtonVisibility), typeof(WizardPage), (PropertyMetadata)(object)new UIPropertyMetadata((object)WizardPageButtonVisibility.Inherit));
		CanFinishProperty = DependencyProperty.Register("CanFinish", typeof(bool?), typeof(WizardPage), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		CanHelpProperty = DependencyProperty.Register("CanHelp", typeof(bool?), typeof(WizardPage), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		CanSelectNextPageProperty = DependencyProperty.Register("CanSelectNextPage", typeof(bool?), typeof(WizardPage), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		CanSelectPreviousPageProperty = DependencyProperty.Register("CanSelectPreviousPage", typeof(bool?), typeof(WizardPage), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		DescriptionProperty = DependencyProperty.Register("Description", typeof(string), typeof(WizardPage));
		ExteriorPanelBackgroundProperty = DependencyProperty.Register("ExteriorPanelBackground", typeof(Brush), typeof(WizardPage), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		ExteriorPanelContentProperty = DependencyProperty.Register("ExteriorPanelContent", typeof(object), typeof(WizardPage), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		FinishButtonVisibilityProperty = DependencyProperty.Register("FinishButtonVisibility", typeof(WizardPageButtonVisibility), typeof(WizardPage), (PropertyMetadata)(object)new UIPropertyMetadata((object)WizardPageButtonVisibility.Inherit));
		HeaderBackgroundProperty = DependencyProperty.Register("HeaderBackground", typeof(Brush), typeof(WizardPage), (PropertyMetadata)(object)new UIPropertyMetadata((object)Brushes.White));
		HeaderImageProperty = DependencyProperty.Register("HeaderImage", typeof(ImageSource), typeof(WizardPage), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		HelpButtonVisibilityProperty = DependencyProperty.Register("HelpButtonVisibility", typeof(WizardPageButtonVisibility), typeof(WizardPage), (PropertyMetadata)(object)new UIPropertyMetadata((object)WizardPageButtonVisibility.Inherit));
		NextButtonVisibilityProperty = DependencyProperty.Register("NextButtonVisibility", typeof(WizardPageButtonVisibility), typeof(WizardPage), (PropertyMetadata)(object)new UIPropertyMetadata((object)WizardPageButtonVisibility.Inherit));
		NextPageProperty = DependencyProperty.Register("NextPage", typeof(WizardPage), typeof(WizardPage), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		PageTypeProperty = DependencyProperty.Register("PageType", typeof(WizardPageType), typeof(WizardPage), (PropertyMetadata)(object)new UIPropertyMetadata((object)WizardPageType.Exterior));
		PreviousPageProperty = DependencyProperty.Register("PreviousPage", typeof(WizardPage), typeof(WizardPage), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(WizardPage));
		EnterEvent = EventManager.RegisterRoutedEvent("Enter", RoutingStrategy.Bubble, typeof(EventHandler), typeof(WizardPage));
		LeaveEvent = EventManager.RegisterRoutedEvent("Leave", RoutingStrategy.Bubble, typeof(EventHandler), typeof(WizardPage));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(WizardPage), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(WizardPage)));
	}

	public WizardPage()
	{
		base.Loaded += WizardPage_Loaded;
		base.Unloaded += WizardPage_Unloaded;
	}

	private void WizardPage_Unloaded(object sender, RoutedEventArgs e)
	{
		RaiseEvent(new RoutedEventArgs(LeaveEvent, this));
	}

	private void WizardPage_Loaded(object sender, RoutedEventArgs e)
	{
		if (base.IsVisible)
		{
			RaiseEvent(new RoutedEventArgs(EnterEvent, this));
		}
	}

	protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		base.OnPropertyChanged(e);
		if (((DependencyPropertyChangedEventArgs)(ref e)).Property.Name == "CanSelectNextPage" || ((DependencyPropertyChangedEventArgs)(ref e)).Property.Name == "CanHelp" || ((DependencyPropertyChangedEventArgs)(ref e)).Property.Name == "CanFinish" || ((DependencyPropertyChangedEventArgs)(ref e)).Property.Name == "CanCancel" || ((DependencyPropertyChangedEventArgs)(ref e)).Property.Name == "CanSelectPreviousPage")
		{
			CommandManager.InvalidateRequerySuggested();
		}
	}
}
