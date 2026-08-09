using System;
using MS.Internal.PropertyEditing;

namespace Microsoft.Windows.Design.PropertyEditing;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public sealed class NumberFormatAttribute : Attribute, IIndexableAttribute
{
	private string formatString;

	private int? maxPrecision;

	private double? scale;

	private KeyAttributeMap<NumberFormatAttribute> map;

	public string FormatString => formatString;

	public int? MaxPrecision => maxPrecision;

	public double? Scale => scale;

	public Attribute this[string key]
	{
		get
		{
			if (map != null)
			{
				NumberFormatAttribute numberFormatAttribute = map[key];
				if (numberFormatAttribute == null)
				{
					return this;
				}
				return numberFormatAttribute;
			}
			return this;
		}
	}

	public NumberFormatAttribute()
	{
		formatString = null;
		maxPrecision = null;
		scale = null;
		map = null;
	}

	public NumberFormatAttribute(string formatString, int? maxPrecision, double? scale)
	{
		this.formatString = formatString;
		this.maxPrecision = maxPrecision;
		this.scale = scale;
		map = null;
	}

	public NumberFormatAttribute(KeyAttributePair<NumberFormatAttribute>[] mapArray)
	{
		formatString = null;
		maxPrecision = null;
		scale = null;
		map = new KeyAttributeMap<NumberFormatAttribute>(mapArray);
	}

	public NumberFormatAttribute(string formatString, int? maxPrecision, double? scale, KeyAttributePair<NumberFormatAttribute>[] mapArray)
	{
		this.formatString = formatString;
		this.maxPrecision = maxPrecision;
		this.scale = scale;
		map = new KeyAttributeMap<NumberFormatAttribute>(mapArray);
	}

	public override bool Equals(object obj)
	{
		if (obj == this)
		{
			return true;
		}
		if (!(obj is NumberFormatAttribute numberFormatAttribute))
		{
			return false;
		}
		if (map != null && numberFormatAttribute.map != null)
		{
			return map.Equals(numberFormatAttribute.map);
		}
		if (numberFormatAttribute.formatString == formatString && numberFormatAttribute.maxPrecision == maxPrecision)
		{
			return numberFormatAttribute.scale == scale;
		}
		return false;
	}

	public override int GetHashCode()
	{
		if (map != null)
		{
			return map.GetHashCode();
		}
		return ((formatString != null) ? formatString.GetHashCode() : 0) ^ maxPrecision.GetHashCode() ^ scale.GetHashCode();
	}
}
