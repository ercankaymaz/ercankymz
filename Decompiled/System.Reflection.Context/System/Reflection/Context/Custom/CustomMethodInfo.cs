using System.Reflection.Context.Projection;

namespace System.Reflection.Context.Custom;

internal sealed class CustomMethodInfo : ProjectingMethodInfo
{
	public CustomReflectionContext ReflectionContext { get; }

	public CustomMethodInfo(MethodInfo template, CustomReflectionContext context)
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
		return AttributeUtils.GetCustomAttributes(ReflectionContext, this, attributeType, inherit);
	}

	public override bool IsDefined(Type attributeType, bool inherit)
	{
		return AttributeUtils.IsDefined(this, attributeType, inherit);
	}
}
