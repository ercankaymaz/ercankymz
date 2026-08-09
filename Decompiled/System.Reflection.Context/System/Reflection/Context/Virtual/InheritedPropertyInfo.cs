using System.Diagnostics.CodeAnalysis;
using System.Reflection.Context.Delegation;

namespace System.Reflection.Context.Virtual;

internal sealed class InheritedPropertyInfo : DelegatingPropertyInfo
{
	private readonly Type _reflectedType;

	public override Type ReflectedType => _reflectedType;

	public InheritedPropertyInfo(PropertyInfo baseProperty, Type reflectedType)
		: base(baseProperty)
	{
		_reflectedType = reflectedType;
	}

	public override MethodInfo GetGetMethod(bool nonPublic)
	{
		MethodInfo getMethod = base.UnderlyingProperty.GetGetMethod(nonPublic);
		if (getMethod == null)
		{
			return null;
		}
		return new InheritedMethodInfo(getMethod, _reflectedType);
	}

	public override MethodInfo GetSetMethod(bool nonPublic)
	{
		MethodInfo setMethod = base.UnderlyingProperty.GetSetMethod(nonPublic);
		if (setMethod == null)
		{
			return null;
		}
		return new InheritedMethodInfo(setMethod, _reflectedType);
	}

	public override bool Equals([NotNullWhen(true)] object o)
	{
		if (o is InheritedPropertyInfo inheritedPropertyInfo && base.UnderlyingProperty.Equals(inheritedPropertyInfo.UnderlyingProperty))
		{
			return ReflectedType.Equals(inheritedPropertyInfo.ReflectedType);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.UnderlyingProperty.GetHashCode() ^ ReflectedType.GetHashCode();
	}
}
