using System;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc.Extensions;

public static class StringExtensions
{
	public static string Truncate(this string value, int maxLength)
	{
		if (string.IsNullOrEmpty(value))
		{
			return value;
		}
		if (value.Length > maxLength)
		{
			return value.Substring(0, maxLength);
		}
		return value;
	}

	public static string IfEmptyThen(this IfcLabel thisOne, IfcLabel then)
	{
		if (!string.IsNullOrWhiteSpace(thisOne))
		{
			return thisOne;
		}
		if (!string.IsNullOrWhiteSpace(then))
		{
			return then;
		}
		return string.Empty;
	}

	public static string IfEmptyThen(this IfcLabel thisOne, IfcLabel? then)
	{
		if (!string.IsNullOrWhiteSpace(thisOne))
		{
			return thisOne;
		}
		IfcLabel? ifcLabel = then;
		if (!string.IsNullOrWhiteSpace(ifcLabel.HasValue ? ((string)ifcLabel.GetValueOrDefault()) : null))
		{
			ifcLabel = then;
			if (!ifcLabel.HasValue)
			{
				return null;
			}
			return ifcLabel.GetValueOrDefault();
		}
		return string.Empty;
	}

	public static string IfEmptyThen(this IfcLabel? thisOne, IfcLabel? then)
	{
		IfcLabel? ifcLabel = thisOne;
		if (!string.IsNullOrWhiteSpace(ifcLabel.HasValue ? ((string)ifcLabel.GetValueOrDefault()) : null))
		{
			ifcLabel = thisOne;
			if (!ifcLabel.HasValue)
			{
				return null;
			}
			return ifcLabel.GetValueOrDefault();
		}
		ifcLabel = then;
		if (!string.IsNullOrWhiteSpace(ifcLabel.HasValue ? ((string)ifcLabel.GetValueOrDefault()) : null))
		{
			ifcLabel = then;
			if (!ifcLabel.HasValue)
			{
				return null;
			}
			return ifcLabel.GetValueOrDefault();
		}
		return string.Empty;
	}

	public static string IfEmptyThen(this string thisOne, string then)
	{
		if (!string.IsNullOrWhiteSpace(thisOne))
		{
			return thisOne;
		}
		if (string.IsNullOrWhiteSpace(then))
		{
			return string.Empty;
		}
		return then;
	}

	public static bool IsSame(this string str, string compare)
	{
		return string.Compare(str, compare, StringComparison.OrdinalIgnoreCase) == 0;
	}

	public static bool IsSame(this IfcLabel label, string compare)
	{
		return string.Compare(label, compare, StringComparison.OrdinalIgnoreCase) == 0;
	}

	public static bool IsSame(this IfcLabel label, IfcLabel compare)
	{
		return string.Compare(label, compare, StringComparison.OrdinalIgnoreCase) == 0;
	}

	public static bool IsSame(this IfcLabel? label, string compare)
	{
		if (!label.HasValue)
		{
			return compare == null;
		}
		return string.Compare(label.Value, compare, StringComparison.OrdinalIgnoreCase) == 0;
	}

	public static bool IsSame(this IfcLabel? label, IfcLabel? compare)
	{
		if (!label.HasValue && !compare.HasValue)
		{
			return true;
		}
		if (!label.HasValue || !compare.HasValue)
		{
			return false;
		}
		return string.Compare(label.Value, compare.Value, StringComparison.OrdinalIgnoreCase) == 0;
	}

	public static bool IsSame(this IfcIdentifier label, string compare)
	{
		return string.Compare(label, compare, StringComparison.OrdinalIgnoreCase) == 0;
	}

	public static bool IsSame(this IfcIdentifier label, IfcIdentifier compare)
	{
		return string.Compare(label, compare, StringComparison.OrdinalIgnoreCase) == 0;
	}

	public static bool IsSame(this IfcIdentifier? label, string compare)
	{
		if (!label.HasValue)
		{
			return compare == null;
		}
		return string.Compare(label.Value, compare, StringComparison.OrdinalIgnoreCase) == 0;
	}

	public static bool IsSame(this IfcIdentifier? label, IfcIdentifier? compare)
	{
		if (!label.HasValue && !compare.HasValue)
		{
			return true;
		}
		if (!label.HasValue || !compare.HasValue)
		{
			return false;
		}
		return string.Compare(label.Value, compare.Value, StringComparison.OrdinalIgnoreCase) == 0;
	}

	public static bool IsEmpty(this IfcLabel label)
	{
		return string.IsNullOrWhiteSpace(label);
	}

	public static bool IsEmpty(this IfcLabel? label)
	{
		IfcLabel? ifcLabel = label;
		return string.IsNullOrWhiteSpace(ifcLabel.HasValue ? ((string)ifcLabel.GetValueOrDefault()) : null);
	}

	public static bool IsEmpty(this string label)
	{
		return string.IsNullOrWhiteSpace(label);
	}

	public static bool IsEmpty(this IfcText label)
	{
		return string.IsNullOrWhiteSpace(label);
	}

	public static bool IsEmpty(this IfcText? label)
	{
		IfcText? ifcText = label;
		return string.IsNullOrWhiteSpace(ifcText.HasValue ? ((string)ifcText.GetValueOrDefault()) : null);
	}
}
