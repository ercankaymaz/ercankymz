using System.Reflection.Context.Projection;

namespace System.Reflection.Context.Custom;

internal sealed class CustomModule : ProjectingModule
{
	public CustomReflectionContext ReflectionContext { get; }

	public CustomModule(Module template, CustomReflectionContext context)
		: base(template, context.Projector)
	{
		ReflectionContext = context;
	}
}
