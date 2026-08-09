using System.Reflection.Context.Projection;

namespace System.Reflection.Context.Custom;

internal sealed class CustomParameterInfo : ProjectingParameterInfo
{
	public CustomReflectionContext ReflectionContext { get; }

	public CustomParameterInfo(ParameterInfo template, CustomReflectionContext context)
		: base(template, context.Projector)
	{
		ReflectionContext = context;
	}

	public override object[] GetCustomAttributes(bool inherit)
	{
		return GetCustomAttributes(typeof(object), inherit);
	}

	public override object[] GetCustomAttributes(Type attributeType, bool inherit)
	{
		return AttributeUtils.GetCustomAttributes(ReflectionContext, this, attributeType);
	}

	public override bool IsDefined(Type attributeType, bool inherit)
	{
		return AttributeUtils.IsDefined(this, attributeType, inherit);
	}
}
