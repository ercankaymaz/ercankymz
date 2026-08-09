using System;
using MS.Internal.PropertyEditing;

namespace Microsoft.Windows.Design.PropertyEditing;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public sealed class NumberRangesAttribute : Attribute, IIndexableAttribute
{
	private double? hardMinimum;

	private double? minimum;

	private double? maximum;

	private double? hardMaximum;

	private bool? canBeAuto;

	private KeyAttributeMap<NumberRangesAttribute> map;

	public double? HardMinimum => hardMinimum;

	public double? Minimum => minimum;

	public double? Maximum => maximum;

	public double? HardMaximum => hardMaximum;

	public bool? CanBeAuto => canBeAuto;

	public Attribute this[string key]
	{
		get
		{
			if (map != null)
			{
				NumberRangesAttribute numberRangesAttribute = map[key];
				if (numberRangesAttribute == null)
				{
					return this;
				}
				return numberRangesAttribute;
			}
			return this;
		}
	}

	public NumberRangesAttribute()
	{
		hardMinimum = null;
		minimum = null;
		maximum = null;
		hardMaximum = null;
		canBeAuto = null;
		map = null;
	}

	public NumberRangesAttribute(double? hardMinimum, double? minimum, double? maximum, double? hardMaximum, bool? canBeAuto)
	{
		this.hardMinimum = hardMinimum;
		this.minimum = minimum;
		this.maximum = maximum;
		this.hardMaximum = hardMaximum;
		this.canBeAuto = canBeAuto;
		map = null;
	}

	public NumberRangesAttribute(KeyAttributePair<NumberRangesAttribute>[] mapArray)
	{
		hardMinimum = null;
		minimum = null;
		maximum = null;
		hardMaximum = null;
		canBeAuto = null;
		map = new KeyAttributeMap<NumberRangesAttribute>(mapArray);
	}

	public NumberRangesAttribute(double? hardMinimum, double? minimum, double? maximum, double? hardMaximum, bool? canBeAuto, KeyAttributePair<NumberRangesAttribute>[] mapArray)
	{
		this.hardMinimum = hardMinimum;
		this.minimum = minimum;
		this.maximum = maximum;
		this.hardMaximum = hardMaximum;
		this.canBeAuto = canBeAuto;
		map = new KeyAttributeMap<NumberRangesAttribute>(mapArray);
	}

	public override bool Equals(object obj)
	{
		if (obj == this)
		{
			return true;
		}
		if (!(obj is NumberRangesAttribute numberRangesAttribute))
		{
			return false;
		}
		if (map != null && numberRangesAttribute.map != null)
		{
			return map.Equals(numberRangesAttribute.map);
		}
		double? num = numberRangesAttribute.hardMinimum;
		double? num2 = hardMinimum;
		if (num.GetValueOrDefault() == num2.GetValueOrDefault() && num.HasValue == num2.HasValue && numberRangesAttribute.minimum == minimum)
		{
			double? num3 = numberRangesAttribute.maximum;
			double? num4 = maximum;
			if (num3.GetValueOrDefault() == num4.GetValueOrDefault() && num3.HasValue == num4.HasValue && numberRangesAttribute.hardMaximum == hardMaximum)
			{
				return numberRangesAttribute.canBeAuto == canBeAuto;
			}
		}
		return false;
	}

	public override int GetHashCode()
	{
		if (map != null)
		{
			return map.GetHashCode();
		}
		return hardMinimum.GetHashCode() ^ minimum.GetHashCode() ^ maximum.GetHashCode() ^ hardMaximum.GetHashCode() ^ canBeAuto.GetHashCode();
	}
}
