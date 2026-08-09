using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Markup;

namespace MS.Internal.Interaction;

[TypeConverter(typeof(AdornerResourceKeyConverter))]
internal sealed class AdornerResourceKey : ResourceKey, ISerializable
{
	private class AdornerResourceKeyConverter : TypeConverter
	{
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if ((object)destinationType == typeof(MarkupExtension) && context is IValueSerializerContext)
			{
				return true;
			}
			return base.CanConvertTo(context, destinationType);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Expected O, but got Unknown
			if ((object)destinationType == typeof(MarkupExtension))
			{
				AdornerResourceKey adornerResourceKey = value as AdornerResourceKey;
				IValueSerializerContext val = (IValueSerializerContext)((context is IValueSerializerContext) ? context : null);
				if (adornerResourceKey != null && val != null)
				{
					ValueSerializer valueSerializerFor = val.GetValueSerializerFor(typeof(Type));
					if (valueSerializerFor != null)
					{
						string text = valueSerializerFor.ConvertToString((object)adornerResourceKey._type, val);
						return (object)new StaticExtension(text + "." + adornerResourceKey._member);
					}
				}
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}
	}

	private Type _type;

	private string _member;

	public override Assembly Assembly => typeof(AdornerResourceKey).Assembly;

	private AdornerResourceKey(SerializationInfo info, StreamingContext cxt)
	{
		_type = (Type)info.GetValue("Type", typeof(Type));
		_member = info.GetString("Member");
	}

	internal AdornerResourceKey(Type type, string member)
	{
		_type = type;
		_member = member;
	}

	public override string ToString()
	{
		return _type.FullName + "." + _member;
	}

	void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("Type", _type);
		info.AddValue("Member", _member);
	}
}
