using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Context.Custom;

namespace System.Reflection.Context.Virtual;

internal sealed class VirtualPropertyInfo : VirtualPropertyBase
{
	private sealed class PropertyGetter : PropertyGetterBase
	{
		private readonly Func<object, object> _getter;

		private readonly IEnumerable<Attribute> _attributes;

		public PropertyGetter(VirtualPropertyBase property, Func<object, object> getter, IEnumerable<Attribute> getterAttributes)
			: base(property)
		{
			_getter = getter;
			_attributes = getterAttributes ?? CollectionServices.Empty<Attribute>();
		}

		public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
		{
			if (parameters != null && parameters.Length != 0)
			{
				throw new TargetParameterCountException();
			}
			if (!ReflectedType.IsInstanceOfType(obj))
			{
				throw new ArgumentException();
			}
			return _getter(obj);
		}

		public override object[] GetCustomAttributes(Type attributeType, bool inherit)
		{
			return CollectionServices.IEnumerableToArray(AttributeUtils.FilterCustomAttributes(_attributes, attributeType), attributeType);
		}

		public override object[] GetCustomAttributes(bool inherit)
		{
			return CollectionServices.IEnumerableToArray(_attributes, typeof(Attribute));
		}

		public override IList<CustomAttributeData> GetCustomAttributesData()
		{
			return CollectionServices.Empty<CustomAttributeData>();
		}

		public override bool IsDefined(Type attributeType, bool inherit)
		{
			return GetCustomAttributes(attributeType, inherit).Length != 0;
		}
	}

	private sealed class PropertySetter : PropertySetterBase
	{
		private readonly Action<object, object> _setter;

		private readonly ParameterInfo _valueParameter;

		private readonly IEnumerable<Attribute> _attributes;

		public PropertySetter(VirtualPropertyBase property, Action<object, object> setter, IEnumerable<Attribute> setterAttributes)
			: base(property)
		{
			_setter = setter;
			_valueParameter = new VirtualParameter(this, property.PropertyType, "value", 0);
			_attributes = setterAttributes ?? CollectionServices.Empty<Attribute>();
		}

		public override ParameterInfo[] GetParameters()
		{
			return new ParameterInfo[1] { _valueParameter };
		}

		public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
		{
			if (parameters == null || parameters.Length != 1)
			{
				throw new TargetParameterCountException();
			}
			object obj2 = parameters[0];
			if (obj == null)
			{
				throw new TargetException(System.SR.Target_InstanceMethodRequiresTarget);
			}
			if (!ReflectedType.IsInstanceOfType(obj))
			{
				throw new TargetException(System.SR.Target_ObjectTargetMismatch);
			}
			if (ReturnType.IsInstanceOfType(obj2))
			{
				throw new ArgumentException(System.SR.Format(System.SR.Argument_ObjectArgumentMismatch, obj2.GetType(), ReturnType));
			}
			_setter(obj, obj2);
			return null;
		}

		public override object[] GetCustomAttributes(Type attributeType, bool inherit)
		{
			return CollectionServices.IEnumerableToArray(AttributeUtils.FilterCustomAttributes(_attributes, attributeType), attributeType);
		}

		public override object[] GetCustomAttributes(bool inherit)
		{
			return CollectionServices.IEnumerableToArray(_attributes, typeof(Attribute));
		}

		public override IList<CustomAttributeData> GetCustomAttributesData()
		{
			return CollectionServices.Empty<CustomAttributeData>();
		}

		public override bool IsDefined(Type attributeType, bool inherit)
		{
			return GetCustomAttributes(attributeType, inherit).Length != 0;
		}
	}

	private readonly PropertyGetter _getter;

	private readonly PropertySetter _setter;

	private readonly IEnumerable<Attribute> _attributes;

	public VirtualPropertyInfo(string name, Type propertyType, Func<object, object> getter, Action<object, object> setter, IEnumerable<Attribute> propertyAttributes, IEnumerable<Attribute> getterAttributes, IEnumerable<Attribute> setterAttributes, CustomReflectionContext context)
		: base(propertyType, name, context)
	{
		if (getter == null && setter == null)
		{
			throw new ArgumentException(System.SR.ArgumentNull_GetterOrSetterMustBeSpecified);
		}
		CustomType customType = propertyType as CustomType;
		if (customType == null || customType.ReflectionContext != context)
		{
			throw new ArgumentException(System.SR.Argument_PropertyTypeFromDifferentContext);
		}
		if (getter != null)
		{
			_getter = new PropertyGetter(this, getter, getterAttributes);
		}
		if (setter != null)
		{
			_setter = new PropertySetter(this, setter, setterAttributes);
		}
		_attributes = propertyAttributes ?? CollectionServices.Empty<Attribute>();
	}

	public override MethodInfo GetGetMethod(bool nonPublic)
	{
		return _getter;
	}

	public override MethodInfo GetSetMethod(bool nonPublic)
	{
		return _setter;
	}

	public override object[] GetCustomAttributes(Type attributeType, bool inherit)
	{
		return CollectionServices.IEnumerableToArray(AttributeUtils.FilterCustomAttributes(_attributes, attributeType), attributeType);
	}

	public override object[] GetCustomAttributes(bool inherit)
	{
		return CollectionServices.IEnumerableToArray(_attributes, typeof(Attribute));
	}

	public override IList<CustomAttributeData> GetCustomAttributesData()
	{
		return CollectionServices.Empty<CustomAttributeData>();
	}

	public override bool IsDefined(Type attributeType, bool inherit)
	{
		return GetCustomAttributes(attributeType, inherit).Length != 0;
	}

	public override string ToString()
	{
		return PropertyType.ToString() + " " + Name;
	}
}
