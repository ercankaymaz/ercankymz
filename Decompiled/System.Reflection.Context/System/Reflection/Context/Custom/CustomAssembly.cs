using System.Reflection.Context.Projection;

namespace System.Reflection.Context.Custom;

internal sealed class CustomAssembly : ProjectingAssembly
{
	public CustomReflectionContext ReflectionContext { get; }

	public CustomAssembly(Assembly template, CustomReflectionContext context)
		: base(template, context.Projector)
	{
		ReflectionContext = context;
	}
}
