namespace System.Reflection.Context.Virtual;

internal sealed class VirtualReturnParameter : VirtualParameter
{
	public VirtualReturnParameter(MethodInfo method)
		: base(method, method.ReturnType, null, -1)
	{
	}
}
