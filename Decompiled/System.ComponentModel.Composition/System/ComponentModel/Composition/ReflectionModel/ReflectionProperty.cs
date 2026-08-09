using System.Reflection;
using Microsoft.Internal;

namespace System.ComponentModel.Composition.ReflectionModel;

internal sealed class ReflectionProperty : ReflectionWritableMember
{
	private readonly MethodInfo _getMethod;

	private readonly MethodInfo _setMethod;

	public override MemberInfo UnderlyingMember => UnderlyingGetMethod ?? UnderlyingSetMethod;

	public override bool CanRead => UnderlyingGetMethod != null;

	public override bool CanWrite => UnderlyingSetMethod != null;

	public MethodInfo? UnderlyingGetMethod => _getMethod;

	public MethodInfo? UnderlyingSetMethod => _setMethod;

	public override string Name
	{
		get
		{
			MethodInfo methodInfo = UnderlyingGetMethod ?? UnderlyingSetMethod;
			string name = methodInfo.Name;
			if (name.Length <= 4)
			{
				throw new Exception(System.SR.Diagnostic_InternalExceptionMessage);
			}
			return name.Substring(4);
		}
	}

	public override bool RequiresInstance
	{
		get
		{
			MethodInfo methodInfo = UnderlyingGetMethod ?? UnderlyingSetMethod;
			return !methodInfo.IsStatic;
		}
	}

	public override Type ReturnType
	{
		get
		{
			if (UnderlyingGetMethod != null)
			{
				return UnderlyingGetMethod.ReturnType;
			}
			ParameterInfo[] parameters = UnderlyingSetMethod.GetParameters();
			if (parameters.Length == 0)
			{
				throw new Exception(System.SR.Diagnostic_InternalExceptionMessage);
			}
			return parameters[^1].ParameterType;
		}
	}

	public override ReflectionItemType ItemType => ReflectionItemType.Property;

	public ReflectionProperty(MethodInfo? getMethod, MethodInfo? setMethod)
	{
		if (getMethod == null && setMethod == null)
		{
			throw new Exception(System.SR.Diagnostic_InternalExceptionMessage);
		}
		_getMethod = getMethod;
		_setMethod = setMethod;
	}

	public override string GetDisplayName()
	{
		return ReflectionServices.GetDisplayName(base.DeclaringType, Name);
	}

	public override object? GetValue(object? instance)
	{
		if (_getMethod == null)
		{
			throw new Exception(System.SR.Diagnostic_InternalExceptionMessage);
		}
		return UnderlyingGetMethod.SafeInvoke(instance);
	}

	public override void SetValue(object? instance, object? value)
	{
		if (_setMethod == null)
		{
			throw new Exception(System.SR.Diagnostic_InternalExceptionMessage);
		}
		UnderlyingSetMethod.SafeInvoke(instance, value);
	}
}
