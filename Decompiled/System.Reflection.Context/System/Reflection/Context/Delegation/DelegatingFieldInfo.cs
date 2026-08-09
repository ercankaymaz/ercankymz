using System.Collections.Generic;
using System.Globalization;

namespace System.Reflection.Context.Delegation;

internal class DelegatingFieldInfo : FieldInfo
{
	public override FieldAttributes Attributes => UnderlyingField.Attributes;

	public override Type DeclaringType => UnderlyingField.DeclaringType;

	public override RuntimeFieldHandle FieldHandle => UnderlyingField.FieldHandle;

	public override Type FieldType => UnderlyingField.FieldType;

	public override bool IsSecurityCritical => UnderlyingField.IsSecurityCritical;

	public override bool IsSecuritySafeCritical => UnderlyingField.IsSecuritySafeCritical;

	public override bool IsSecurityTransparent => UnderlyingField.IsSecurityTransparent;

	public override int MetadataToken => UnderlyingField.MetadataToken;

	public override Module Module => UnderlyingField.Module;

	public override string Name => UnderlyingField.Name;

	public override Type ReflectedType => UnderlyingField.ReflectedType;

	public FieldInfo UnderlyingField { get; }

	public DelegatingFieldInfo(FieldInfo field)
	{
		UnderlyingField = field;
	}

	public override object[] GetCustomAttributes(Type attributeType, bool inherit)
	{
		return UnderlyingField.GetCustomAttributes(attributeType, inherit);
	}

	public override object[] GetCustomAttributes(bool inherit)
	{
		return UnderlyingField.GetCustomAttributes(inherit);
	}

	public override IList<CustomAttributeData> GetCustomAttributesData()
	{
		return UnderlyingField.GetCustomAttributesData();
	}

	public override Type[] GetOptionalCustomModifiers()
	{
		return UnderlyingField.GetOptionalCustomModifiers();
	}

	public override object GetRawConstantValue()
	{
		return UnderlyingField.GetRawConstantValue();
	}

	public override Type[] GetRequiredCustomModifiers()
	{
		return UnderlyingField.GetRequiredCustomModifiers();
	}

	public override object GetValue(object obj)
	{
		return UnderlyingField.GetValue(obj);
	}

	public override object GetValueDirect(TypedReference obj)
	{
		return UnderlyingField.GetValueDirect(obj);
	}

	public override bool IsDefined(Type attributeType, bool inherit)
	{
		return UnderlyingField.IsDefined(attributeType, inherit);
	}

	public override void SetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, CultureInfo culture)
	{
		UnderlyingField.SetValue(obj, value, invokeAttr, binder, culture);
	}

	public override void SetValueDirect(TypedReference obj, object value)
	{
		UnderlyingField.SetValueDirect(obj, value);
	}

	public override string ToString()
	{
		return UnderlyingField.ToString();
	}
}
