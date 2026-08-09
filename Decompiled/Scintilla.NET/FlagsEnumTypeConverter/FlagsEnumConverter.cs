using System;
using System.ComponentModel;
using System.Reflection;

namespace FlagsEnumTypeConverter;

internal class FlagsEnumConverter : EnumConverter
{
	protected class EnumFieldDescriptor : SimplePropertyDescriptor
	{
		private readonly ITypeDescriptorContext fContext;

		public override AttributeCollection Attributes => new AttributeCollection(RefreshPropertiesAttribute.Repaint);

		public EnumFieldDescriptor(Type componentType, string name, ITypeDescriptorContext context)
			: base(componentType, name, typeof(bool))
		{
			fContext = context;
		}

		public override object GetValue(object component)
		{
			ulong num = Convert.ToUInt64(Enum.Parse(ComponentType, Name));
			return (Convert.ToUInt64(component) & num) == num;
		}

		public override void SetValue(object component, object value)
		{
			ulong num = ((!(bool)value) ? (Convert.ToUInt64(component) & ~Convert.ToUInt64(Enum.Parse(ComponentType, Name))) : (Convert.ToUInt64(component) | Convert.ToUInt64(Enum.Parse(ComponentType, Name))));
			component.GetType().GetField("value__", BindingFlags.Instance | BindingFlags.Public).SetValue(component, Convert.ChangeType(num, Enum.GetUnderlyingType(ComponentType)));
			fContext.PropertyDescriptor.SetValue(fContext.Instance, component);
		}

		public override bool ShouldSerializeValue(object component)
		{
			return (bool)GetValue(component) != GetDefaultValue();
		}

		public override void ResetValue(object component)
		{
			SetValue(component, GetDefaultValue());
		}

		public override bool CanResetValue(object component)
		{
			return ShouldSerializeValue(component);
		}

		private bool GetDefaultValue()
		{
			object obj = null;
			string name = fContext.PropertyDescriptor.Name;
			DefaultValueAttribute defaultValueAttribute = (DefaultValueAttribute)Attribute.GetCustomAttribute(fContext.PropertyDescriptor.ComponentType.GetProperty(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic), typeof(DefaultValueAttribute));
			if (defaultValueAttribute != null)
			{
				obj = defaultValueAttribute.Value;
			}
			if (obj != null)
			{
				return (Convert.ToUInt64(obj) & Convert.ToUInt64(Enum.Parse(ComponentType, Name))) != 0;
			}
			return false;
		}
	}

	public FlagsEnumConverter(Type type)
		: base(type)
	{
	}

	public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
	{
		if (context != null)
		{
			Type type = value.GetType();
			string[] names = Enum.GetNames(type);
			Array values = Enum.GetValues(type);
			if (names != null)
			{
				PropertyDescriptorCollection propertyDescriptorCollection = new PropertyDescriptorCollection(null);
				for (int i = 0; i < names.Length; i++)
				{
					if (Convert.ToUInt64(values.GetValue(i)) != 0L)
					{
						propertyDescriptorCollection.Add(new EnumFieldDescriptor(type, names[i], context));
					}
				}
				return propertyDescriptorCollection;
			}
		}
		return base.GetProperties(context, value, attributes);
	}

	public override bool GetPropertiesSupported(ITypeDescriptorContext context)
	{
		if (context != null)
		{
			return true;
		}
		return base.GetPropertiesSupported(context);
	}

	public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
	{
		return false;
	}
}
