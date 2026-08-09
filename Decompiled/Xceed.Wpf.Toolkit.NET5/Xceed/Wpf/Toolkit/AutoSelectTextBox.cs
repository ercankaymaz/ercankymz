using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit;

public class AutoSelectTextBox : TextBox
{
	public static readonly DependencyProperty AutoSelectBehaviorProperty = DependencyProperty.Register("AutoSelectBehavior", typeof(AutoSelectBehavior), typeof(AutoSelectTextBox), (PropertyMetadata)(object)new UIPropertyMetadata((object)AutoSelectBehavior.Never));

	public static readonly DependencyProperty AutoMoveFocusProperty = DependencyProperty.Register("AutoMoveFocus", typeof(bool), typeof(AutoSelectTextBox), (PropertyMetadata)(object)new UIPropertyMetadata((object)false));

	public static readonly RoutedEvent QueryMoveFocusEvent = EventManager.RegisterRoutedEvent("QueryMoveFocus", RoutingStrategy.Bubble, typeof(QueryMoveFocusEventHandler), typeof(AutoSelectTextBox));

	public AutoSelectBehavior AutoSelectBehavior
	{
		get
		{
			return (AutoSelectBehavior)((DependencyObject)this).GetValue(AutoSelectBehaviorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AutoSelectBehaviorProperty, (object)value);
		}
	}

	public bool AutoMoveFocus
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AutoMoveFocusProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AutoMoveFocusProperty, (object)value);
		}
	}

	protected override void OnPreviewKeyDown(KeyEventArgs e)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Invalid comparison between Unknown and I4
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Invalid comparison between Unknown and I4
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Invalid comparison between Unknown and I4
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Invalid comparison between Unknown and I4
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Invalid comparison between Unknown and I4
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Invalid comparison between Unknown and I4
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Invalid comparison between Unknown and I4
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Invalid comparison between Unknown and I4
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Invalid comparison between Unknown and I4
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Invalid comparison between Unknown and I4
		if (!AutoMoveFocus)
		{
			base.OnPreviewKeyDown(e);
			return;
		}
		if ((int)e.Key == 23 && ((int)Keyboard.Modifiers == 0 || (int)Keyboard.Modifiers == 2))
		{
			e.Handled = MoveFocusLeft();
		}
		if ((int)e.Key == 25 && ((int)Keyboard.Modifiers == 0 || (int)Keyboard.Modifiers == 2))
		{
			e.Handled = MoveFocusRight();
		}
		if (((int)e.Key == 24 || (int)e.Key == 19) && ((int)Keyboard.Modifiers == 0 || (int)Keyboard.Modifiers == 2))
		{
			e.Handled = MoveFocusUp();
		}
		if (((int)e.Key == 26 || (int)e.Key == 20) && ((int)Keyboard.Modifiers == 0 || (int)Keyboard.Modifiers == 2))
		{
			e.Handled = MoveFocusDown();
		}
		base.OnPreviewKeyDown(e);
	}

	protected override void OnPreviewGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
	{
		base.OnPreviewGotKeyboardFocus(e);
		if (AutoSelectBehavior == AutoSelectBehavior.OnFocus)
		{
			IInputElement oldFocus = e.OldFocus;
			if (!TreeHelper.IsDescendantOf((DependencyObject)((oldFocus is DependencyObject) ? oldFocus : null), (DependencyObject)(object)this))
			{
				SelectAll();
			}
		}
	}

	protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		base.OnPreviewMouseLeftButtonDown(e);
		if (AutoSelectBehavior != AutoSelectBehavior.Never && !base.IsKeyboardFocusWithin)
		{
			Focus();
			e.Handled = true;
		}
	}

	protected override void OnTextChanged(TextChangedEventArgs e)
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		base.OnTextChanged(e);
		if (AutoMoveFocus && base.Text.Length != 0 && base.Text.Length == base.MaxLength && base.CaretIndex == base.MaxLength && CanMoveFocus((FocusNavigationDirection)5, reachedMax: true))
		{
			FocusNavigationDirection val = (FocusNavigationDirection)((base.FlowDirection == FlowDirection.LeftToRight) ? 5 : 4);
			MoveFocus(new TraversalRequest(val));
		}
	}

	private bool CanMoveFocus(FocusNavigationDirection direction, bool reachedMax)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		QueryMoveFocusEventArgs e = new QueryMoveFocusEventArgs(direction, reachedMax);
		RaiseEvent(e);
		return e.CanMoveFocus;
	}

	private bool MoveFocusLeft()
	{
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		if (base.FlowDirection == FlowDirection.LeftToRight)
		{
			if (base.CaretIndex == 0 && base.SelectionLength == 0)
			{
				if (ComponentCommands.MoveFocusBack.CanExecute(null, this))
				{
					ComponentCommands.MoveFocusBack.Execute(null, this);
					return true;
				}
				if (CanMoveFocus((FocusNavigationDirection)4, reachedMax: false))
				{
					MoveFocus(new TraversalRequest((FocusNavigationDirection)4));
					return true;
				}
			}
		}
		else if (base.CaretIndex == base.Text.Length && base.SelectionLength == 0)
		{
			if (ComponentCommands.MoveFocusBack.CanExecute(null, this))
			{
				ComponentCommands.MoveFocusBack.Execute(null, this);
				return true;
			}
			if (CanMoveFocus((FocusNavigationDirection)4, reachedMax: false))
			{
				MoveFocus(new TraversalRequest((FocusNavigationDirection)4));
				return true;
			}
		}
		return false;
	}

	private bool MoveFocusRight()
	{
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		if (base.FlowDirection == FlowDirection.LeftToRight)
		{
			if (base.CaretIndex == base.Text.Length && base.SelectionLength == 0)
			{
				if (ComponentCommands.MoveFocusForward.CanExecute(null, this))
				{
					ComponentCommands.MoveFocusForward.Execute(null, this);
					return true;
				}
				if (CanMoveFocus((FocusNavigationDirection)5, reachedMax: false))
				{
					MoveFocus(new TraversalRequest((FocusNavigationDirection)5));
					return true;
				}
			}
		}
		else if (base.CaretIndex == 0 && base.SelectionLength == 0)
		{
			if (ComponentCommands.MoveFocusForward.CanExecute(null, this))
			{
				ComponentCommands.MoveFocusForward.Execute(null, this);
				return true;
			}
			if (CanMoveFocus((FocusNavigationDirection)5, reachedMax: false))
			{
				MoveFocus(new TraversalRequest((FocusNavigationDirection)5));
				return true;
			}
		}
		return false;
	}

	private bool MoveFocusUp()
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		if (GetLineIndexFromCharacterIndex(base.SelectionStart) == 0)
		{
			if (ComponentCommands.MoveFocusUp.CanExecute(null, this))
			{
				ComponentCommands.MoveFocusUp.Execute(null, this);
				return true;
			}
			if (CanMoveFocus((FocusNavigationDirection)6, reachedMax: false))
			{
				MoveFocus(new TraversalRequest((FocusNavigationDirection)6));
				return true;
			}
		}
		return false;
	}

	private bool MoveFocusDown()
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		if (GetLineIndexFromCharacterIndex(base.SelectionStart) == base.LineCount - 1)
		{
			if (ComponentCommands.MoveFocusDown.CanExecute(null, this))
			{
				ComponentCommands.MoveFocusDown.Execute(null, this);
				return true;
			}
			if (CanMoveFocus((FocusNavigationDirection)7, reachedMax: false))
			{
				MoveFocus(new TraversalRequest((FocusNavigationDirection)7));
				return true;
			}
		}
		return false;
	}
}
