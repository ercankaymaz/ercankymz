using System.Linq.Expressions;
using System.Reflection;
using Microsoft.Internal;

namespace System.ComponentModel.Composition.Primitives;

public class ExportedDelegate
{
	private readonly object _instance;

	private readonly MethodInfo _method;

	protected ExportedDelegate()
	{
	}

	public ExportedDelegate(object? instance, MethodInfo method)
	{
		Requires.NotNull(method, "method");
		_instance = instance;
		_method = method;
	}

	public virtual Delegate? CreateDelegate(Type delegateType)
	{
		Requires.NotNull(delegateType, "delegateType");
		if (delegateType == typeof(Delegate) || delegateType == typeof(MulticastDelegate))
		{
			delegateType = CreateStandardDelegateType();
		}
		try
		{
			return _method.CreateDelegate(delegateType, _instance);
		}
		catch (ArgumentException)
		{
			return null;
		}
	}

	private Type CreateStandardDelegateType()
	{
		ParameterInfo[] parameters = _method.GetParameters();
		Type[] array = new Type[parameters.Length + 1];
		array[parameters.Length] = _method.ReturnType;
		for (int i = 0; i < parameters.Length; i++)
		{
			array[i] = parameters[i].ParameterType;
		}
		return Expression.GetDelegateType(array);
	}
}
