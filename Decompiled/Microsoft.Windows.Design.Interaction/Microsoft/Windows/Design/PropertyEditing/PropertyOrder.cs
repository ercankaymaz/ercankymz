using System;

namespace Microsoft.Windows.Design.PropertyEditing;

public sealed class PropertyOrder : OrderToken
{
	private static PropertyOrder _early;

	private static PropertyOrder _default;

	private static PropertyOrder _late;

	public static PropertyOrder Early
	{
		get
		{
			if (_early == null)
			{
				_early = new PropertyOrder(OrderTokenPrecedence.Before, Default, OrderTokenConflictResolution.Win);
			}
			return _early;
		}
	}

	public static PropertyOrder Default
	{
		get
		{
			if (_default == null)
			{
				_default = new PropertyOrder(OrderTokenPrecedence.After, null, OrderTokenConflictResolution.Win);
			}
			return _default;
		}
	}

	public static PropertyOrder Late
	{
		get
		{
			if (_late == null)
			{
				_late = new PropertyOrder(OrderTokenPrecedence.After, Default, OrderTokenConflictResolution.Win);
			}
			return _late;
		}
	}

	private PropertyOrder(OrderTokenPrecedence precedence, OrderToken reference, OrderTokenConflictResolution conflictResolution)
		: base(precedence, reference, conflictResolution)
	{
	}

	public static PropertyOrder CreateBefore(PropertyOrder reference)
	{
		if (reference == null)
		{
			throw new ArgumentNullException("reference");
		}
		return new PropertyOrder(OrderTokenPrecedence.Before, reference, OrderTokenConflictResolution.Lose);
	}

	public static PropertyOrder CreateAfter(PropertyOrder reference)
	{
		if (reference == null)
		{
			throw new ArgumentNullException("reference");
		}
		return new PropertyOrder(OrderTokenPrecedence.After, reference, OrderTokenConflictResolution.Lose);
	}

	protected override int ResolveConflict(OrderToken left, OrderToken right)
	{
		return 0;
	}
}
