using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Microsoft.Windows.Design.PropertyEditing;

public class EditModeSwitchButton : Button
{
	private class EditModeSwitchButtonAutomationPeer : ButtonAutomationPeer, IInvokeProvider, IToggleProvider
	{
		private delegate void VoidInvoker();

		public ToggleState ToggleState
		{
			get
			{
				EditModeSwitchButton editModeSwitchButton = (EditModeSwitchButton)(object)((UIElementAutomationPeer)this).Owner;
				PropertyContainer owningContainer = editModeSwitchButton._owningContainer;
				if (owningContainer == null)
				{
					return (ToggleState)2;
				}
				return (ToggleState)(owningContainer.ActiveEditMode switch
				{
					PropertyContainerEditMode.ExtendedPinned => 1, 
					PropertyContainerEditMode.Inline => 0, 
					_ => 2, 
				});
			}
		}

		public EditModeSwitchButtonAutomationPeer(EditModeSwitchButton owner)
			: base((Button)(object)owner)
		{
		}

		public override object GetPattern(PatternInterface patternInterface)
		{
			//IL_000a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			string name = Enum.GetName(typeof(PatternInterface), patternInterface);
			if ((int)patternInterface == 0 || name == "Toggle")
			{
				return this;
			}
			return ((ButtonAutomationPeer)this).GetPattern(patternInterface);
		}

		public void Toggle()
		{
			Invoke();
		}

		public void Invoke()
		{
			EditModeSwitchButton button = (EditModeSwitchButton)(object)((UIElementAutomationPeer)this).Owner;
			((DispatcherObject)button).Dispatcher.BeginInvoke((Delegate)(VoidInvoker)delegate
			{
				button.InvokePropertyValueEditorCommand();
			}, new object[0]);
		}
	}

	private PropertyContainer _owningContainer;

	private bool _attachedToContainerEvents;

	public static readonly DependencyProperty TargetEditModeProperty = DependencyProperty.Register("TargetEditMode", typeof(PropertyContainerEditMode), typeof(EditModeSwitchButton), (PropertyMetadata)new FrameworkPropertyMetadata((object)PropertyContainerEditMode.Inline, (PropertyChangedCallback)null, new CoerceValueCallback(OnCoerceEditModeProperty)));

	public static readonly DependencyProperty SyncModeToOwningContainerProperty = DependencyProperty.Register("SyncModeToOwningContainer", typeof(bool), typeof(EditModeSwitchButton), (PropertyMetadata)new FrameworkPropertyMetadata((object)true, new PropertyChangedCallback(OnSyncModeToOwningContainerChanged)));

	public PropertyContainerEditMode TargetEditMode
	{
		get
		{
			return (PropertyContainerEditMode)((DependencyObject)this).GetValue(TargetEditModeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TargetEditModeProperty, (object)value);
		}
	}

	public bool SyncModeToOwningContainer
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(SyncModeToOwningContainerProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SyncModeToOwningContainerProperty, (object)value);
		}
	}

	public EditModeSwitchButton()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += new RoutedEventHandler(OnLoaded);
		((FrameworkElement)this).Unloaded += new RoutedEventHandler(OnUnloaded);
	}

	private static object OnCoerceEditModeProperty(DependencyObject obj, object value)
	{
		EditModeSwitchButton editModeSwitchButton = (EditModeSwitchButton)(object)obj;
		if (!editModeSwitchButton.SyncModeToOwningContainer)
		{
			return value;
		}
		if (editModeSwitchButton._owningContainer == null)
		{
			return value;
		}
		PropertyContainer owningContainer = editModeSwitchButton._owningContainer;
		return owningContainer.ActiveEditMode switch
		{
			PropertyContainerEditMode.Inline => (!owningContainer.SupportsEditMode(PropertyContainerEditMode.Dialog)) ? (owningContainer.SupportsEditMode(PropertyContainerEditMode.ExtendedPopup) ? PropertyContainerEditMode.ExtendedPopup : PropertyContainerEditMode.Inline) : PropertyContainerEditMode.Dialog, 
			PropertyContainerEditMode.ExtendedPopup => PropertyContainerEditMode.ExtendedPinned, 
			PropertyContainerEditMode.ExtendedPinned => PropertyContainerEditMode.Inline, 
			PropertyContainerEditMode.Dialog => editModeSwitchButton.TargetEditMode, 
			_ => (PropertyContainerEditMode)value, 
		};
	}

	private static void OnSyncModeToOwningContainerChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
	{
		EditModeSwitchButton editModeSwitchButton = (EditModeSwitchButton)(object)obj;
		((DependencyObject)editModeSwitchButton).CoerceValue(TargetEditModeProperty);
	}

	protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		if (((DependencyPropertyChangedEventArgs)(ref e)).Property == PropertyContainer.OwningPropertyContainerProperty)
		{
			PropertyContainer propertyContainer = (PropertyContainer)((DependencyPropertyChangedEventArgs)(ref e)).OldValue;
			PropertyContainer propertyContainer2 = (_owningContainer = (PropertyContainer)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
			if (propertyContainer != null)
			{
				DisassociateContainerEventHandlers(propertyContainer);
			}
			if (propertyContainer2 != null)
			{
				AssociateContainerEventHandlers(propertyContainer2);
			}
			((DependencyObject)this).CoerceValue(TargetEditModeProperty);
		}
		((FrameworkElement)this).OnPropertyChanged(e);
	}

	private void OnPropertyContainerDependencyPropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
	{
		if (((DependencyPropertyChangedEventArgs)(ref e)).Property == PropertyContainer.ActiveEditModeProperty || ((DependencyPropertyChangedEventArgs)(ref e)).Property == PropertyContainer.PropertyEntryProperty || ((DependencyPropertyChangedEventArgs)(ref e)).Property == PropertyContainer.DefaultStandardValuesPropertyValueEditorProperty || ((DependencyPropertyChangedEventArgs)(ref e)).Property == PropertyContainer.DefaultPropertyValueEditorProperty)
		{
			((DependencyObject)this).CoerceValue(TargetEditModeProperty);
		}
	}

	private void AssociateContainerEventHandlers(PropertyContainer container)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		if (!_attachedToContainerEvents)
		{
			container.DependencyPropertyChanged += new DependencyPropertyChangedEventHandler(OnPropertyContainerDependencyPropertyChanged);
			_attachedToContainerEvents = true;
		}
	}

	private void DisassociateContainerEventHandlers(PropertyContainer container)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		if (_attachedToContainerEvents)
		{
			container.DependencyPropertyChanged -= new DependencyPropertyChangedEventHandler(OnPropertyContainerDependencyPropertyChanged);
			_attachedToContainerEvents = false;
		}
	}

	private void OnUnloaded(object sender, RoutedEventArgs e)
	{
		if (_owningContainer != null)
		{
			DisassociateContainerEventHandlers(_owningContainer);
		}
	}

	private void OnLoaded(object sender, RoutedEventArgs e)
	{
		if (_owningContainer != null)
		{
			AssociateContainerEventHandlers(_owningContainer);
		}
	}

	protected override void OnMouseDown(MouseButtonEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		if ((int)((MouseEventArgs)e).LeftButton == 1)
		{
			InvokePropertyValueEditorCommand();
		}
		((UIElement)this).OnMouseDown(e);
	}

	private void InvokePropertyValueEditorCommand()
	{
		switch (TargetEditMode)
		{
		case PropertyContainerEditMode.Inline:
			PropertyValueEditorCommands.ShowInlineEditor.Execute((object)null, (IInputElement)(object)this);
			break;
		case PropertyContainerEditMode.ExtendedPopup:
			PropertyValueEditorCommands.ShowExtendedPopupEditor.Execute((object)null, (IInputElement)(object)this);
			break;
		case PropertyContainerEditMode.ExtendedPinned:
			PropertyValueEditorCommands.ShowExtendedPinnedEditor.Execute((object)null, (IInputElement)(object)this);
			break;
		case PropertyContainerEditMode.Dialog:
			PropertyValueEditorCommands.ShowDialogEditor.Execute((object)null, (IInputElement)(object)this);
			break;
		}
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return (AutomationPeer)(object)new EditModeSwitchButtonAutomationPeer(this);
	}
}
