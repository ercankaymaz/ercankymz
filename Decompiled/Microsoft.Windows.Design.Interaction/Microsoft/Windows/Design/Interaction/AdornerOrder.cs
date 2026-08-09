using System;

namespace Microsoft.Windows.Design.Interaction;

public sealed class AdornerOrder : OrderToken
{
	private static AdornerOrder _foreground;

	private static AdornerOrder _content;

	private static AdornerOrder _background;

	public static AdornerOrder Background
	{
		get
		{
			if (_background == null)
			{
				_background = new AdornerOrder(OrderTokenPrecedence.After, Content, OrderTokenConflictResolution.Win);
			}
			return _background;
		}
	}

	public static AdornerOrder Content
	{
		get
		{
			if (_content == null)
			{
				_content = new AdornerOrder(OrderTokenPrecedence.After, null, OrderTokenConflictResolution.Win);
			}
			return _content;
		}
	}

	public static AdornerOrder Foreground
	{
		get
		{
			if (_foreground == null)
			{
				_foreground = new AdornerOrder(OrderTokenPrecedence.Before, Content, OrderTokenConflictResolution.Win);
			}
			return _foreground;
		}
	}

	private AdornerOrder(OrderTokenPrecedence precedence, OrderToken reference, OrderTokenConflictResolution conflictResolution)
		: base(precedence, reference, conflictResolution)
	{
	}

	public static AdornerOrder CreateAbove(AdornerOrder reference)
	{
		if (reference == null)
		{
			throw new ArgumentNullException("reference");
		}
		return new AdornerOrder(OrderTokenPrecedence.Before, reference, OrderTokenConflictResolution.Lose);
	}

	public static AdornerOrder CreateBelow(AdornerOrder reference)
	{
		if (reference == null)
		{
			throw new ArgumentNullException("reference");
		}
		return new AdornerOrder(OrderTokenPrecedence.After, reference, OrderTokenConflictResolution.Lose);
	}
}
