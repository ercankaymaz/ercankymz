using System.Collections.Generic;

namespace System.Reflection.Context.Delegation;

internal class DelegatingParameterInfo : ParameterInfo
{
	public override ParameterAttributes Attributes => UnderlyingParameter.Attributes;

	public override object DefaultValue => UnderlyingParameter.DefaultValue;

	public override MemberInfo Member => UnderlyingParameter.Member;

	public override int MetadataToken => UnderlyingParameter.MetadataToken;

	public override string Name => UnderlyingParameter.Name;

	public override Type ParameterType => UnderlyingParameter.ParameterType;

	public override int Position => UnderlyingParameter.Position;

	public override object RawDefaultValue => UnderlyingParameter.RawDefaultValue;

	public ParameterInfo UnderlyingParameter { get; }

	public DelegatingParameterInfo(ParameterInfo parameter)
	{
		UnderlyingParameter = parameter;
	}

	public override object[] GetCustomAttributes(Type attributeType, bool inherit)
	{
		return UnderlyingParameter.GetCustomAttributes(attributeType, inherit);
	}

	public override object[] GetCustomAttributes(bool inherit)
	{
		return UnderlyingParameter.GetCustomAttributes(inherit);
	}

	public override IList<CustomAttributeData> GetCustomAttributesData()
	{
		return UnderlyingParameter.GetCustomAttributesData();
	}

	public override Type[] GetOptionalCustomModifiers()
	{
		return UnderlyingParameter.GetOptionalCustomModifiers();
	}

	public override Type[] GetRequiredCustomModifiers()
	{
		return UnderlyingParameter.GetRequiredCustomModifiers();
	}

	public override bool IsDefined(Type attributeType, bool inherit)
	{
		return UnderlyingParameter.IsDefined(attributeType, inherit);
	}

	public override string ToString()
	{
		return UnderlyingParameter.ToString();
	}
}
