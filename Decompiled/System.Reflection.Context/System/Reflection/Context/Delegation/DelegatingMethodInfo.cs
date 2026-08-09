using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace System.Reflection.Context.Delegation;

internal class DelegatingMethodInfo : MethodInfo
{
	public override MethodAttributes Attributes => UnderlyingMethod.Attributes;

	public override CallingConventions CallingConvention => UnderlyingMethod.CallingConvention;

	public override bool ContainsGenericParameters => UnderlyingMethod.ContainsGenericParameters;

	public override Type DeclaringType => UnderlyingMethod.DeclaringType;

	public override bool IsGenericMethod => UnderlyingMethod.IsGenericMethod;

	public override bool IsGenericMethodDefinition => UnderlyingMethod.IsGenericMethodDefinition;

	public override bool IsSecurityCritical => UnderlyingMethod.IsSecurityCritical;

	public override bool IsSecuritySafeCritical => UnderlyingMethod.IsSecuritySafeCritical;

	public override bool IsSecurityTransparent => UnderlyingMethod.IsSecurityTransparent;

	public override int MetadataToken => UnderlyingMethod.MetadataToken;

	public override RuntimeMethodHandle MethodHandle => UnderlyingMethod.MethodHandle;

	public override Module Module => UnderlyingMethod.Module;

	public override string Name => UnderlyingMethod.Name;

	public override Type ReflectedType => UnderlyingMethod.ReflectedType;

	public override ParameterInfo ReturnParameter => UnderlyingMethod.ReturnParameter;

	public override ICustomAttributeProvider ReturnTypeCustomAttributes => UnderlyingMethod.ReturnTypeCustomAttributes;

	public override Type ReturnType => UnderlyingMethod.ReturnType;

	public MethodInfo UnderlyingMethod { get; }

	public DelegatingMethodInfo(MethodInfo method)
	{
		UnderlyingMethod = method;
	}

	public override MethodInfo GetBaseDefinition()
	{
		return UnderlyingMethod.GetBaseDefinition();
	}

	public override object[] GetCustomAttributes(Type attributeType, bool inherit)
	{
		return UnderlyingMethod.GetCustomAttributes(attributeType, inherit);
	}

	public override object[] GetCustomAttributes(bool inherit)
	{
		return UnderlyingMethod.GetCustomAttributes(inherit);
	}

	public override IList<CustomAttributeData> GetCustomAttributesData()
	{
		return UnderlyingMethod.GetCustomAttributesData();
	}

	public override Type[] GetGenericArguments()
	{
		return UnderlyingMethod.GetGenericArguments();
	}

	public override MethodInfo GetGenericMethodDefinition()
	{
		return UnderlyingMethod.GetGenericMethodDefinition();
	}

	public override MethodBody GetMethodBody()
	{
		return UnderlyingMethod.GetMethodBody();
	}

	public override MethodImplAttributes GetMethodImplementationFlags()
	{
		return UnderlyingMethod.GetMethodImplementationFlags();
	}

	public override ParameterInfo[] GetParameters()
	{
		return UnderlyingMethod.GetParameters();
	}

	public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
	{
		return UnderlyingMethod.Invoke(obj, invokeAttr, binder, parameters, culture);
	}

	public override bool IsDefined(Type attributeType, bool inherit)
	{
		return UnderlyingMethod.IsDefined(attributeType, inherit);
	}

	[RequiresUnreferencedCode("If some of the generic arguments are annotated (either with DynamicallyAccessedMembersAttribute, or generic constraints), trimming can't validate that the requirements of those annotations are met.")]
	public override MethodInfo MakeGenericMethod(params Type[] typeArguments)
	{
		return UnderlyingMethod.MakeGenericMethod(typeArguments);
	}

	public override Delegate CreateDelegate(Type delegateType)
	{
		return UnderlyingMethod.CreateDelegate(delegateType);
	}

	public override Delegate CreateDelegate(Type delegateType, object target)
	{
		return UnderlyingMethod.CreateDelegate(delegateType, target);
	}

	public override string ToString()
	{
		return UnderlyingMethod.ToString();
	}
}
