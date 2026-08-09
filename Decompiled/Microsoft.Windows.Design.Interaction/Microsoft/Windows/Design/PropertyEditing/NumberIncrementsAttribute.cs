using System;
using MS.Internal.PropertyEditing;

namespace Microsoft.Windows.Design.PropertyEditing;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public sealed class NumberIncrementsAttribute : Attribute, IIndexableAttribute
{
	private double? smallChange;

	private double? defaultChange;

	private double? largeChange;

	private KeyAttributeMap<NumberIncrementsAttribute> map;

	public double? SmallChange => smallChange;

	public double? DefaultChange => defaultChange;

	public double? LargeChange => largeChange;

	public Attribute this[string key]
	{
		get
		{
			if (map != null)
			{
				NumberIncrementsAttribute numberIncrementsAttribute = map[key];
				if (numberIncrementsAttribute == null)
				{
					return this;
				}
				return numberIncrementsAttribute;
			}
			return this;
		}
	}

	public NumberIncrementsAttribute()
	{
		smallChange = null;
		defaultChange = null;
		largeChange = null;
		map = null;
	}

	public NumberIncrementsAttribute(double? smallChange, double? defaultChange, double? largeChange)
	{
		this.smallChange = smallChange;
		this.defaultChange = defaultChange;
		this.largeChange = largeChange;
		map = null;
	}

	public NumberIncrementsAttribute(KeyAttributePair<NumberIncrementsAttribute>[] mapArray)
	{
		smallChange = null;
		defaultChange = null;
		largeChange = null;
		map = new KeyAttributeMap<NumberIncrementsAttribute>(mapArray);
	}

	public NumberIncrementsAttribute(double? smallChange, double? defaultChange, double? largeChange, KeyAttributePair<NumberIncrementsAttribute>[] mapArray)
	{
		this.smallChange = smallChange;
		this.defaultChange = defaultChange;
		this.largeChange = largeChange;
		map = new KeyAttributeMap<NumberIncrementsAttribute>(mapArray);
	}

	public override bool Equals(object obj)
	{
		if (obj == this)
		{
			return true;
		}
		if (!(obj is NumberIncrementsAttribute numberIncrementsAttribute))
		{
			return false;
		}
		if (map != null && numberIncrementsAttribute.map != null)
		{
			return map.Equals(numberIncrementsAttribute.map);
		}
		double? num = numberIncrementsAttribute.smallChange;
		double? num2 = smallChange;
		if (num.GetValueOrDefault() == num2.GetValueOrDefault() && num.HasValue == num2.HasValue && numberIncrementsAttribute.defaultChange == defaultChange)
		{
			return numberIncrementsAttribute.largeChange == largeChange;
		}
		return false;
	}

	public override int GetHashCode()
	{
		if (map != null)
		{
			return map.GetHashCode();
		}
		return smallChange.GetHashCode() ^ defaultChange.GetHashCode() ^ largeChange.GetHashCode();
	}
}
