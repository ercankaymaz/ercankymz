using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace ScintillaNET;

internal class FlagsConverter : TypeConverter
{
	public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
	{
		if (!(destinationType == typeof(string)))
		{
			return base.CanConvertTo(context, destinationType);
		}
		return true;
	}

	public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
	{
		if (!(sourceType == typeof(string)))
		{
			return base.CanConvertFrom(context, sourceType);
		}
		return true;
	}

	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (value is Enum obj && destinationType == typeof(string))
		{
			Type type = obj.GetType();
			ulong valueBits = Convert.ToUInt64(obj);
			if (valueBits == 0L)
			{
				return Enum.ToObject(type, 0).ToString();
			}
			ulong bits = 0uL;
			List<Enum> list = new List<Enum>();
			var list2 = (from Enum e in Enum.GetValues(type)
				select new
				{
					@enum = e,
					bits = Convert.ToUInt64(e),
					bitCount = Helpers.PopCount(Convert.ToUInt64(e))
				} into e
				where e.bits != 0L && e.bitCount > 0
				select e).ToList();
			int count = list2.Count;
			for (int num = 0; num < count; num++)
			{
				if (bits == valueBits)
				{
					break;
				}
				if (list2.Count <= 0)
				{
					break;
				}
				int index = list2.Select(e => new
				{
					contrib = Helpers.PopCount(e.bits & valueBits & ~bits),
					item = e
				}).MaxIndex((x, y) => (x.contrib == y.contrib) ? ((x.item.bitCount == y.item.bitCount) ? ((x.item.bits >= y.item.bits) ? ((x.item.bits > y.item.bits) ? 1 : 0) : (-1)) : (y.item.bitCount - x.item.bitCount)) : (x.contrib - y.contrib));
				var anon = list2[index];
				if ((valueBits & anon.bits) == anon.bits && (bits & anon.bits) != anon.bits)
				{
					bits |= anon.bits;
					list2.RemoveAt(index);
					list.Add(anon.@enum);
				}
			}
			list.Sort();
			return string.Join(" | ", list);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		if (value is string text)
		{
			Type propertyType = context.PropertyDescriptor.PropertyType;
			ulong num = 0uL;
			foreach (string item in from x in text.Split('|')
				select x.Trim())
			{
				num |= Convert.ToUInt64(Enum.Parse(propertyType, item));
			}
			return Enum.ToObject(propertyType, num);
		}
		return base.ConvertFrom(context, culture, value);
	}
}
