using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Utilities;

[Newtonsoft_002EJson_002ENullableContext(2)]
[Newtonsoft_002EJson_002ENullable(0)]
internal class FSharpFunction
{
	private readonly object _instance;

	[Newtonsoft_002EJson_002ENullable(new byte[] { 1, 2, 1 })]
	private readonly MethodCall<object, object> _invoker;

	public FSharpFunction(object instance, [Newtonsoft_002EJson_002ENullable(new byte[] { 1, 2, 1 })] MethodCall<object, object> invoker)
	{
		_instance = instance;
		_invoker = invoker;
	}

	[Newtonsoft_002EJson_002ENullableContext(1)]
	public object Invoke(params object[] args)
	{
		return _invoker(_instance, args);
	}
}
