using System.Diagnostics.CodeAnalysis;
using System.Reflection.Context.Delegation;

namespace System.Reflection.Context.Virtual;

internal sealed class InheritedMethodInfo : DelegatingMethodInfo
{
	private readonly Type _reflectedType;

	public override Type ReflectedType => _reflectedType;

	public InheritedMethodInfo(MethodInfo baseMethod, Type reflectedType)
		: base(baseMethod)
	{
		_reflectedType = reflectedType;
	}

	public override bool Equals([NotNullWhen(true)] object o)
	{
		if (o is InheritedMethodInfo inheritedMethodInfo && base.UnderlyingMethod.Equals(inheritedMethodInfo.UnderlyingMethod))
		{
			return ReflectedType.Equals(inheritedMethodInfo.ReflectedType);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.UnderlyingMethod.GetHashCode() ^ ReflectedType.GetHashCode();
	}
}
