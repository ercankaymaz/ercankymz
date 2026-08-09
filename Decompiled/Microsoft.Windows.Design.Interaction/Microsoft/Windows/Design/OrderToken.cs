using System;

namespace Microsoft.Windows.Design;

public abstract class OrderToken : IComparable<OrderToken>
{
	private readonly OrderToken _reference;

	private readonly OrderTokenPrecedence _precedence;

	private readonly OrderTokenConflictResolution _conflictResolution;

	private readonly int _depth;

	private readonly int _index;

	private int _nextChildIndex;

	protected OrderToken(OrderTokenPrecedence precedence, OrderToken reference, OrderTokenConflictResolution conflictResolution)
	{
		if (!EnumValidator.IsValid(precedence))
		{
			throw new ArgumentOutOfRangeException("precedence");
		}
		if (!EnumValidator.IsValid(conflictResolution))
		{
			throw new ArgumentOutOfRangeException("conflictResolution");
		}
		_reference = reference;
		_precedence = precedence;
		_conflictResolution = conflictResolution;
		_depth = ((!(reference == null)) ? (reference._depth + 1) : 0);
		_index = ((reference == null) ? (-1) : reference._nextChildIndex++);
	}

	public virtual int CompareTo(OrderToken other)
	{
		if (object.ReferenceEquals(other, null))
		{
			throw new ArgumentNullException("other");
		}
		if (object.ReferenceEquals(other, this))
		{
			return 0;
		}
		OrderToken orderToken = this;
		while (orderToken._reference != other._reference)
		{
			if (orderToken._depth == other._depth)
			{
				orderToken = orderToken._reference;
				other = other._reference;
				continue;
			}
			if (orderToken._depth > other._depth)
			{
				if (orderToken._reference == other)
				{
					if (orderToken._precedence != OrderTokenPrecedence.After)
					{
						return -1;
					}
					return 1;
				}
				orderToken = orderToken._reference;
				continue;
			}
			if (other._reference == orderToken)
			{
				if (other._precedence != OrderTokenPrecedence.After)
				{
					return 1;
				}
				return -1;
			}
			other = other._reference;
		}
		if (orderToken._precedence != other._precedence)
		{
			if (orderToken._precedence != OrderTokenPrecedence.Before)
			{
				return 1;
			}
			return -1;
		}
		if (orderToken._precedence == OrderTokenPrecedence.Before)
		{
			if (orderToken._conflictResolution == OrderTokenConflictResolution.Win)
			{
				return -1;
			}
			if (other._conflictResolution == OrderTokenConflictResolution.Win)
			{
				return 1;
			}
			return ResolveConflict(orderToken, other);
		}
		if (orderToken._conflictResolution == OrderTokenConflictResolution.Win)
		{
			return 1;
		}
		if (other._conflictResolution == OrderTokenConflictResolution.Win)
		{
			return -1;
		}
		return ResolveConflict(orderToken, other);
	}

	public override bool Equals(object obj)
	{
		if (!(obj is OrderToken))
		{
			return false;
		}
		return CompareTo((OrderToken)obj) == 0;
	}

	public override int GetHashCode()
	{
		return _reference.GetHashCode() ^ _precedence.GetHashCode() ^ _conflictResolution.GetHashCode();
	}

	public static bool operator ==(OrderToken first, OrderToken second)
	{
		if (object.ReferenceEquals(first, second))
		{
			return true;
		}
		if (object.ReferenceEquals(first, null))
		{
			return false;
		}
		if (object.ReferenceEquals(second, null))
		{
			return false;
		}
		return first.CompareTo(second) == 0;
	}

	public static bool operator !=(OrderToken first, OrderToken second)
	{
		return !(first == second);
	}

	public static bool operator <(OrderToken first, OrderToken second)
	{
		return first.CompareTo(second) < 0;
	}

	public static bool operator >(OrderToken first, OrderToken second)
	{
		return first.CompareTo(second) > 0;
	}

	protected virtual int ResolveConflict(OrderToken left, OrderToken right)
	{
		return left._index.CompareTo(right._index);
	}
}
