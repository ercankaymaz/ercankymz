using System.Collections.Generic;
using System.Globalization;

namespace System.Reflection.Context.Delegation;

internal class DelegatingPropertyInfo : PropertyInfo
{
	public override PropertyAttributes Attributes => UnderlyingProperty.Attributes;

	public override bool CanRead => UnderlyingProperty.CanRead;

	public override bool CanWrite => UnderlyingProperty.CanWrite;

	public override Type DeclaringType => UnderlyingProperty.DeclaringType;

	public override int MetadataToken => UnderlyingProperty.MetadataToken;

	public override Module Module => UnderlyingProperty.Module;

	public override string Name => UnderlyingProperty.Name;

	public override Type PropertyType => UnderlyingProperty.PropertyType;

	public override Type ReflectedType => UnderlyingProperty.ReflectedType;

	public PropertyInfo UnderlyingProperty { get; }

	public DelegatingPropertyInfo(PropertyInfo property)
	{
		UnderlyingProperty = property;
	}

	public override MethodInfo[] GetAccessors(bool nonPublic)
	{
		return UnderlyingProperty.GetAccessors(nonPublic);
	}

	public override MethodInfo GetGetMethod(bool nonPublic)
	{
		return UnderlyingProperty.GetGetMethod(nonPublic);
	}

	public override ParameterInfo[] GetIndexParameters()
	{
		return UnderlyingProperty.GetIndexParameters();
	}

	public override MethodInfo GetSetMethod(bool nonPublic)
	{
		return UnderlyingProperty.GetSetMethod(nonPublic);
	}

	public override object GetValue(object obj, object[] index)
	{
		return UnderlyingProperty.GetValue(obj, index);
	}

	public override object GetValue(object obj, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture)
	{
		return UnderlyingProperty.GetValue(obj, invokeAttr, binder, index, culture);
	}

	public override void SetValue(object obj, object value, object[] index)
	{
		UnderlyingProperty.SetValue(obj, value, index);
	}

	public override void SetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture)
	{
		UnderlyingProperty.SetValue(obj, value, invokeAttr, binder, index, culture);
	}

	public override object[] GetCustomAttributes(Type attributeType, bool inherit)
	{
		return UnderlyingProperty.GetCustomAttributes(attributeType, inherit);
	}

	public override object[] GetCustomAttributes(bool inherit)
	{
		return UnderlyingProperty.GetCustomAttributes(inherit);
	}

	public override IList<CustomAttributeData> GetCustomAttributesData()
	{
		return UnderlyingProperty.GetCustomAttributesData();
	}

	public override object GetConstantValue()
	{
		return UnderlyingProperty.GetConstantValue();
	}

	public override object GetRawConstantValue()
	{
		return UnderlyingProperty.GetRawConstantValue();
	}

	public override Type[] GetOptionalCustomModifiers()
	{
		return UnderlyingProperty.GetOptionalCustomModifiers();
	}

	public override Type[] GetRequiredCustomModifiers()
	{
		return UnderlyingProperty.GetRequiredCustomModifiers();
	}

	public override bool IsDefined(Type attributeType, bool inherit)
	{
		return UnderlyingProperty.IsDefined(attributeType, inherit);
	}

	public override string ToString()
	{
		return UnderlyingProperty.ToString();
	}
}
