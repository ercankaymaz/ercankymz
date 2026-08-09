using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using Xceed.Wpf.Toolkit.Core;

namespace Xceed.Wpf.Toolkit;

public class Wizard : ItemsControl
{
	public delegate void NextRoutedEventHandler(object sender, CancelRoutedEventArgs e);

	public delegate void PreviousRoutedEventHandler(object sender, CancelRoutedEventArgs e);

	private bool? _dialogResult;

	public static readonly DependencyProperty BackButtonContentProperty;

	public static readonly DependencyProperty BackButtonVisibilityProperty;

	public static readonly DependencyProperty CanCancelProperty;

	public static readonly DependencyProperty CancelButtonClosesWindowProperty;

	public static readonly DependencyProperty CancelButtonContentProperty;

	public static readonly DependencyProperty CancelButtonVisibilityProperty;

	public static readonly DependencyProperty CanFinishProperty;

	public static readonly DependencyProperty CanHelpProperty;

	public static readonly DependencyProperty CanSelectNextPageProperty;

	public static readonly DependencyProperty CanSelectPreviousPageProperty;

	public static readonly DependencyProperty CurrentPageProperty;

	public static readonly DependencyProperty ExteriorPanelMinWidthProperty;

	public static readonly DependencyProperty FinishButtonClosesWindowProperty;

	public static readonly DependencyProperty FinishButtonContentProperty;

	public static readonly DependencyProperty FinishButtonVisibilityProperty;

	public static readonly DependencyProperty HelpButtonContentProperty;

	public static readonly DependencyProperty HelpButtonVisibilityProperty;

	public static readonly DependencyProperty NextButtonContentProperty;

	public static readonly DependencyProperty NextButtonVisibilityProperty;

	public static readonly RoutedEvent CancelEvent;

	public static readonly RoutedEvent PageChangedEvent;

	public static readonly RoutedEvent FinishEvent;

	public static readonly RoutedEvent HelpEvent;

	public static readonly RoutedEvent NextEvent;

	public static readonly RoutedEvent PreviousEvent;

	public object BackButtonContent
	{
		get
		{
			return ((DependencyObject)this).GetValue(BackButtonContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BackButtonContentProperty, value);
		}
	}

	public Visibility BackButtonVisibility
	{
		get
		{
			return (Visibility)((DependencyObject)this).GetValue(BackButtonVisibilityProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BackButtonVisibilityProperty, (object)value);
		}
	}

	public bool CanCancel
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanCancelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanCancelProperty, (object)value);
		}
	}

	public bool CancelButtonClosesWindow
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CancelButtonClosesWindowProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CancelButtonClosesWindowProperty, (object)value);
		}
	}

	public object CancelButtonContent
	{
		get
		{
			return ((DependencyObject)this).GetValue(CancelButtonContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CancelButtonContentProperty, value);
		}
	}

	public Visibility CancelButtonVisibility
	{
		get
		{
			return (Visibility)((DependencyObject)this).GetValue(CancelButtonVisibilityProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CancelButtonVisibilityProperty, (object)value);
		}
	}

	public bool CanFinish
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanFinishProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanFinishProperty, (object)value);
		}
	}

	public bool CanHelp
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanHelpProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanHelpProperty, (object)value);
		}
	}

	public bool CanSelectNextPage
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanSelectNextPageProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanSelectNextPageProperty, (object)value);
		}
	}

	public bool CanSelectPreviousPage
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanSelectPreviousPageProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanSelectPreviousPageProperty, (object)value);
		}
	}

	public WizardPage CurrentPage
	{
		get
		{
			return (WizardPage)((DependencyObject)this).GetValue(CurrentPageProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CurrentPageProperty, (object)value);
		}
	}

	public double ExteriorPanelMinWidth
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ExteriorPanelMinWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ExteriorPanelMinWidthProperty, (object)value);
		}
	}

	public bool FinishButtonClosesWindow
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(FinishButtonClosesWindowProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FinishButtonClosesWindowProperty, (object)value);
		}
	}

	public object FinishButtonContent
	{
		get
		{
			return ((DependencyObject)this).GetValue(FinishButtonContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FinishButtonContentProperty, value);
		}
	}

	public Visibility FinishButtonVisibility
	{
		get
		{
			return (Visibility)((DependencyObject)this).GetValue(FinishButtonVisibilityProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FinishButtonVisibilityProperty, (object)value);
		}
	}

	public object HelpButtonContent
	{
		get
		{
			return ((DependencyObject)this).GetValue(HelpButtonContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HelpButtonContentProperty, value);
		}
	}

	public Visibility HelpButtonVisibility
	{
		get
		{
			return (Visibility)((DependencyObject)this).GetValue(HelpButtonVisibilityProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HelpButtonVisibilityProperty, (object)value);
		}
	}

	public object NextButtonContent
	{
		get
		{
			return ((DependencyObject)this).GetValue(NextButtonContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(NextButtonContentProperty, value);
		}
	}

	public Visibility NextButtonVisibility
	{
		get
		{
			return (Visibility)((DependencyObject)this).GetValue(NextButtonVisibilityProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(NextButtonVisibilityProperty, (object)value);
		}
	}

	public event RoutedEventHandler Cancel
	{
		add
		{
			AddHandler(CancelEvent, value);
		}
		remove
		{
			RemoveHandler(CancelEvent, value);
		}
	}

	public event RoutedEventHandler PageChanged
	{
		add
		{
			AddHandler(PageChangedEvent, value);
		}
		remove
		{
			RemoveHandler(PageChangedEvent, value);
		}
	}

	public event CancelRoutedEventHandler Finish
	{
		add
		{
			AddHandler(FinishEvent, value);
		}
		remove
		{
			RemoveHandler(FinishEvent, value);
		}
	}

	public event RoutedEventHandler Help
	{
		add
		{
			AddHandler(HelpEvent, value);
		}
		remove
		{
			RemoveHandler(HelpEvent, value);
		}
	}

	public event NextRoutedEventHandler Next
	{
		add
		{
			AddHandler(NextEvent, value);
		}
		remove
		{
			RemoveHandler(NextEvent, value);
		}
	}

	public event PreviousRoutedEventHandler Previous
	{
		add
		{
			AddHandler(PreviousEvent, value);
		}
		remove
		{
			RemoveHandler(PreviousEvent, value);
		}
	}

	private static void OnCurrentPageChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is Wizard wizard)
		{
			wizard.OnCurrentPageChanged((WizardPage)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (WizardPage)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnCurrentPageChanged(WizardPage oldValue, WizardPage newValue)
	{
		RaiseRoutedEvent(PageChangedEvent);
	}

	static Wizard()
	{
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Expected O, but got Unknown
		BackButtonContentProperty = DependencyProperty.Register("BackButtonContent", typeof(object), typeof(Wizard), (PropertyMetadata)(object)new UIPropertyMetadata((object)"< Back"));
		BackButtonVisibilityProperty = DependencyProperty.Register("BackButtonVisibility", typeof(Visibility), typeof(Wizard), (PropertyMetadata)(object)new UIPropertyMetadata((object)Visibility.Visible));
		CanCancelProperty = DependencyProperty.Register("CanCancel", typeof(bool), typeof(Wizard), (PropertyMetadata)(object)new UIPropertyMetadata((object)true));
		CancelButtonClosesWindowProperty = DependencyProperty.Register("CancelButtonClosesWindow", typeof(bool), typeof(Wizard), (PropertyMetadata)(object)new UIPropertyMetadata((object)true));
		CancelButtonContentProperty = DependencyProperty.Register("CancelButtonContent", typeof(object), typeof(Wizard), (PropertyMetadata)(object)new UIPropertyMetadata((object)"Cancel"));
		CancelButtonVisibilityProperty = DependencyProperty.Register("CancelButtonVisibility", typeof(Visibility), typeof(Wizard), (PropertyMetadata)(object)new UIPropertyMetadata((object)Visibility.Visible));
		CanFinishProperty = DependencyProperty.Register("CanFinish", typeof(bool), typeof(Wizard), (PropertyMetadata)(object)new UIPropertyMetadata((object)false));
		CanHelpProperty = DependencyProperty.Register("CanHelp", typeof(bool), typeof(Wizard), (PropertyMetadata)(object)new UIPropertyMetadata((object)true));
		CanSelectNextPageProperty = DependencyProperty.Register("CanSelectNextPage", typeof(bool), typeof(Wizard), (PropertyMetadata)(object)new UIPropertyMetadata((object)true));
		CanSelectPreviousPageProperty = DependencyProperty.Register("CanSelectPreviousPage", typeof(bool), typeof(Wizard), (PropertyMetadata)(object)new UIPropertyMetadata((object)true));
		CurrentPageProperty = DependencyProperty.Register("CurrentPage", typeof(WizardPage), typeof(Wizard), (PropertyMetadata)(object)new UIPropertyMetadata(null, new PropertyChangedCallback(OnCurrentPageChanged)));
		ExteriorPanelMinWidthProperty = DependencyProperty.Register("ExteriorPanelMinWidth", typeof(double), typeof(Wizard), (PropertyMetadata)(object)new UIPropertyMetadata((object)165.0));
		FinishButtonClosesWindowProperty = DependencyProperty.Register("FinishButtonClosesWindow", typeof(bool), typeof(Wizard), (PropertyMetadata)(object)new UIPropertyMetadata((object)true));
		FinishButtonContentProperty = DependencyProperty.Register("FinishButtonContent", typeof(object), typeof(Wizard), (PropertyMetadata)(object)new UIPropertyMetadata((object)"Finish"));
		FinishButtonVisibilityProperty = DependencyProperty.Register("FinishButtonVisibility", typeof(Visibility), typeof(Wizard), (PropertyMetadata)(object)new UIPropertyMetadata((object)Visibility.Collapsed));
		HelpButtonContentProperty = DependencyProperty.Register("HelpButtonContent", typeof(object), typeof(Wizard), (PropertyMetadata)(object)new UIPropertyMetadata((object)"Help"));
		HelpButtonVisibilityProperty = DependencyProperty.Register("HelpButtonVisibility", typeof(Visibility), typeof(Wizard), (PropertyMetadata)(object)new UIPropertyMetadata((object)Visibility.Visible));
		NextButtonContentProperty = DependencyProperty.Register("NextButtonContent", typeof(object), typeof(Wizard), (PropertyMetadata)(object)new UIPropertyMetadata((object)"Next >"));
		NextButtonVisibilityProperty = DependencyProperty.Register("NextButtonVisibility", typeof(Visibility), typeof(Wizard), (PropertyMetadata)(object)new UIPropertyMetadata((object)Visibility.Visible));
		CancelEvent = EventManager.RegisterRoutedEvent("Cancel", RoutingStrategy.Bubble, typeof(EventHandler), typeof(Wizard));
		PageChangedEvent = EventManager.RegisterRoutedEvent("PageChanged", RoutingStrategy.Bubble, typeof(EventHandler), typeof(Wizard));
		FinishEvent = EventManager.RegisterRoutedEvent("Finish", RoutingStrategy.Bubble, typeof(CancelRoutedEventHandler), typeof(Wizard));
		HelpEvent = EventManager.RegisterRoutedEvent("Help", RoutingStrategy.Bubble, typeof(EventHandler), typeof(Wizard));
		NextEvent = EventManager.RegisterRoutedEvent("Next", RoutingStrategy.Bubble, typeof(NextRoutedEventHandler), typeof(Wizard));
		PreviousEvent = EventManager.RegisterRoutedEvent("Previous", RoutingStrategy.Bubble, typeof(PreviousRoutedEventHandler), typeof(Wizard));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(Wizard), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(Wizard)));
	}

	public Wizard()
	{
		base.CommandBindings.Add(new CommandBinding(WizardCommands.Cancel, ExecuteCancelWizard, CanExecuteCancelWizard));
		base.CommandBindings.Add(new CommandBinding(WizardCommands.Finish, ExecuteFinishWizard, CanExecuteFinishWizard));
		base.CommandBindings.Add(new CommandBinding(WizardCommands.Help, ExecuteRequestHelp, CanExecuteRequestHelp));
		base.CommandBindings.Add(new CommandBinding(WizardCommands.NextPage, ExecuteSelectNextPage, CanExecuteSelectNextPage));
		base.CommandBindings.Add(new CommandBinding(WizardCommands.PreviousPage, ExecuteSelectPreviousPage, CanExecuteSelectPreviousPage));
	}

	protected override DependencyObject GetContainerForItemOverride()
	{
		return (DependencyObject)(object)new WizardPage();
	}

	protected override bool IsItemItsOwnContainerOverride(object item)
	{
		return item is WizardPage;
	}

	protected override void OnInitialized(EventArgs e)
	{
		base.OnInitialized(e);
		if (base.Items.Count > 0 && CurrentPage == null)
		{
			CurrentPage = base.Items[0] as WizardPage;
		}
	}

	protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
	{
		base.OnItemsChanged(e);
		foreach (object item in (IEnumerable)base.Items)
		{
			if (!(item is WizardPage))
			{
				throw new NotSupportedException("Wizard should only contain WizardPages.");
			}
		}
		if (base.Items.Count > 0 && CurrentPage == null)
		{
			CurrentPage = base.Items[0] as WizardPage;
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

	private void ExecuteCancelWizard(object sender, ExecutedRoutedEventArgs e)
	{
		RaiseRoutedEvent(CancelEvent);
		if (CancelButtonClosesWindow)
		{
			CloseParentWindow(dialogResult: false);
		}
	}

	private void CanExecuteCancelWizard(object sender, CanExecuteRoutedEventArgs e)
	{
		if (CurrentPage != null)
		{
			if (CurrentPage.CanCancel.HasValue)
			{
				e.CanExecute = CurrentPage.CanCancel.Value;
			}
			else
			{
				e.CanExecute = CanCancel;
			}
		}
	}

	private void ExecuteFinishWizard(object sender, ExecutedRoutedEventArgs e)
	{
		CancelRoutedEventArgs e2 = new CancelRoutedEventArgs(FinishEvent);
		RaiseEvent(e2);
		if (!e2.Cancel && FinishButtonClosesWindow)
		{
			CloseParentWindow(dialogResult: true);
		}
	}

	private void CanExecuteFinishWizard(object sender, CanExecuteRoutedEventArgs e)
	{
		if (CurrentPage != null)
		{
			if (CurrentPage.CanFinish.HasValue)
			{
				e.CanExecute = CurrentPage.CanFinish.Value;
			}
			else
			{
				e.CanExecute = CanFinish;
			}
		}
	}

	private void ExecuteRequestHelp(object sender, ExecutedRoutedEventArgs e)
	{
		RaiseRoutedEvent(HelpEvent);
	}

	private void CanExecuteRequestHelp(object sender, CanExecuteRoutedEventArgs e)
	{
		if (CurrentPage != null)
		{
			if (CurrentPage.CanHelp.HasValue)
			{
				e.CanExecute = CurrentPage.CanHelp.Value;
			}
			else
			{
				e.CanExecute = CanHelp;
			}
		}
	}

	private void ExecuteSelectNextPage(object sender, ExecutedRoutedEventArgs e)
	{
		WizardPage currentPage = null;
		if (CurrentPage != null)
		{
			CancelRoutedEventArgs e2 = new CancelRoutedEventArgs(NextEvent);
			RaiseEvent(e2);
			if (e2.Cancel)
			{
				return;
			}
			if (CurrentPage.NextPage != null)
			{
				currentPage = CurrentPage.NextPage;
			}
			else
			{
				int num = base.Items.IndexOf(CurrentPage) + 1;
				if (num < base.Items.Count)
				{
					currentPage = base.Items[num] as WizardPage;
				}
			}
		}
		CurrentPage = currentPage;
	}

	private void CanExecuteSelectNextPage(object sender, CanExecuteRoutedEventArgs e)
	{
		if (CurrentPage == null)
		{
			return;
		}
		if (CurrentPage.CanSelectNextPage.HasValue)
		{
			if (CurrentPage.CanSelectNextPage.Value)
			{
				e.CanExecute = NextPageExists();
			}
		}
		else if (CanSelectNextPage)
		{
			e.CanExecute = NextPageExists();
		}
	}

	private void ExecuteSelectPreviousPage(object sender, ExecutedRoutedEventArgs e)
	{
		WizardPage currentPage = null;
		if (CurrentPage != null)
		{
			CancelRoutedEventArgs e2 = new CancelRoutedEventArgs(PreviousEvent);
			RaiseEvent(e2);
			if (e2.Cancel)
			{
				return;
			}
			if (CurrentPage.PreviousPage != null)
			{
				currentPage = CurrentPage.PreviousPage;
			}
			else
			{
				int num = base.Items.IndexOf(CurrentPage) - 1;
				if (num >= 0 && num < base.Items.Count)
				{
					currentPage = base.Items[num] as WizardPage;
				}
			}
		}
		CurrentPage = currentPage;
	}

	private void CanExecuteSelectPreviousPage(object sender, CanExecuteRoutedEventArgs e)
	{
		if (CurrentPage == null)
		{
			return;
		}
		if (CurrentPage.CanSelectPreviousPage.HasValue)
		{
			if (CurrentPage.CanSelectPreviousPage.Value)
			{
				e.CanExecute = PreviousPageExists();
			}
		}
		else if (CanSelectPreviousPage)
		{
			e.CanExecute = PreviousPageExists();
		}
	}

	private void CloseParentWindow(bool dialogResult)
	{
		Window window = Window.GetWindow((DependencyObject)(object)this);
		if (window != null)
		{
			if (ComponentDispatcher.IsThreadModal)
			{
				_dialogResult = dialogResult;
				window.Closing += Window_Closing;
			}
			window.Close();
		}
	}

	private void Window_Closing(object sender, CancelEventArgs e)
	{
		if (sender is Window window)
		{
			if (!e.Cancel)
			{
				window.DialogResult = _dialogResult;
			}
			_dialogResult = null;
			window.Closing -= Window_Closing;
		}
	}

	private bool NextPageExists()
	{
		bool result = false;
		if (CurrentPage.NextPage != null)
		{
			result = true;
		}
		else if (base.Items.IndexOf(CurrentPage) + 1 < base.Items.Count)
		{
			result = true;
		}
		return result;
	}

	private bool PreviousPageExists()
	{
		bool result = false;
		if (CurrentPage.PreviousPage != null)
		{
			result = true;
		}
		else
		{
			int num = base.Items.IndexOf(CurrentPage) - 1;
			if (num >= 0 && num < base.Items.Count)
			{
				result = true;
			}
		}
		return result;
	}

	private void RaiseRoutedEvent(RoutedEvent routedEvent)
	{
		RoutedEventArgs e = new RoutedEventArgs(routedEvent, this);
		RaiseEvent(e);
	}
}
