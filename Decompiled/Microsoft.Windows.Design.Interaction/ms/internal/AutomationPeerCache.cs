using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Data;

namespace MS.Internal;

internal static class AutomationPeerCache
{
	private static DependencyObject _objThatIsBinding;

	public static readonly DependencyProperty AutomationPeerProperty = DependencyProperty.RegisterAttached("AutomationPeer", typeof(AutomationPeer), typeof(AutomationPeerCache), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));

	public static readonly DependencyProperty IsAutomationFocusedProperty = DependencyProperty.RegisterAttached("IsAutomationFocused", typeof(bool), typeof(AutomationPeerCache), (PropertyMetadata)new UIPropertyMetadata((object)false, new PropertyChangedCallback(OnIsAutomationFocusedChanged)));

	public static AutomationPeer GetAutomationPeer(DependencyObject obj)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		return (AutomationPeer)obj.GetValue(AutomationPeerProperty);
	}

	public static void SetAutomationPeer(DependencyObject obj, AutomationPeer value)
	{
		obj.SetValue(AutomationPeerProperty, (object)value);
	}

	public static void RegisterFocusEvents(DependencyObject obj)
	{
		if (!GetIsAutomationFocused(obj))
		{
			RegisterFocusEvents(obj, "IsKeyboardFocused");
		}
	}

	public static void RegisterFocusEvents(DependencyObject obj, AutomationPeer associatedPeer)
	{
		if (!GetIsAutomationFocused(obj))
		{
			if (GetAutomationPeer(obj) == null && UIElementAutomationPeer.FromElement((UIElement)(object)((obj is UIElement) ? obj : null)) == null)
			{
				SetAutomationPeer(obj, associatedPeer);
			}
			RegisterFocusEvents(obj, "IsKeyboardFocused");
		}
	}

	public static void RegisterFocusEvents(DependencyObject obj, string propertyName)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		UIElement val = (UIElement)(object)((obj is UIElement) ? obj : null);
		if (val != null)
		{
			try
			{
				_objThatIsBinding = obj;
				Binding val2 = new Binding(propertyName);
				val2.RelativeSource = RelativeSource.Self;
				BindingOperations.SetBinding(obj, IsAutomationFocusedProperty, (BindingBase)(object)val2);
			}
			finally
			{
				_objThatIsBinding = null;
			}
		}
	}

	public static bool GetIsAutomationFocused(DependencyObject obj)
	{
		return (bool)obj.GetValue(IsAutomationFocusedProperty);
	}

	public static void SetIsAutomationFocused(DependencyObject obj, bool value)
	{
		obj.SetValue(IsAutomationFocusedProperty, (object)value);
	}

	private static void OnIsAutomationFocusedChanged(DependencyObject dobj, DependencyPropertyChangedEventArgs e)
	{
		if (_objThatIsBinding == dobj)
		{
			return;
		}
		AutomationPeer val = GetAutomationPeer(dobj);
		if (val == null)
		{
			val = UIElementAutomationPeer.FromElement((UIElement)(object)((dobj is UIElement) ? dobj : null));
		}
		if (val != null)
		{
			if (AutomationPeer.ListenerExists((AutomationEvents)13))
			{
				val.RaisePropertyChangedEvent(SelectionItemPatternIdentifiers.IsSelectedProperty, ((DependencyPropertyChangedEventArgs)(ref e)).OldValue, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
				val.RaisePropertyChangedEvent(AutomationElementIdentifiers.HasKeyboardFocusProperty, ((DependencyPropertyChangedEventArgs)(ref e)).OldValue, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
			}
			if (AutomationPeer.ListenerExists((AutomationEvents)4))
			{
				val.RaiseAutomationEvent((AutomationEvents)4);
			}
			if (val is ItemAutomationPeer && AutomationPeer.ListenerExists((AutomationEvents)8))
			{
				val.RaiseAutomationEvent((AutomationEvents)8);
			}
		}
	}

	public static T Create<T>(UIElement element, params object[] args) where T : AutomationPeer
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		AutomationPeer val = GetAutomationPeer((DependencyObject)(object)element);
		if (val == null)
		{
			val = ((args.Length != 0) ? ((AutomationPeer)Activator.CreateInstance(typeof(T), args)) : ((AutomationPeer)Activator.CreateInstance(typeof(T), element)));
			if (val != null)
			{
				SetAutomationPeer((DependencyObject)(object)element, val);
				RegisterFocusEvents((DependencyObject)(object)element);
			}
		}
		return (T)(object)((val is T) ? val : null);
	}
}
