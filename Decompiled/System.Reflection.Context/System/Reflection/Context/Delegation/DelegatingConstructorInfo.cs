using System.Collections.Generic;
using System.Globalization;

namespace System.Reflection.Context.Delegation;

internal class DelegatingConstructorInfo : ConstructorInfo
{
	public override MethodAttributes Attributes => UnderlyingConstructor.Attributes;

	public override CallingConventions CallingConvention => UnderlyingConstructor.CallingConvention;

	public override bool ContainsGenericParameters => UnderlyingConstructor.ContainsGenericParameters;

	public override Type DeclaringType => UnderlyingConstructor.DeclaringType;

	public override bool IsGenericMethod => UnderlyingConstructor.IsGenericMethod;

	public override bool IsGenericMethodDefinition => UnderlyingConstructor.IsGenericMethodDefinition;

	public override bool IsSecurityCritical => UnderlyingConstructor.IsSecurityCritical;

	public override bool IsSecuritySafeCritical => UnderlyingConstructor.IsSecuritySafeCritical;

	public override bool IsSecurityTransparent => UnderlyingConstructor.IsSecurityTransparent;

	public override int MetadataToken => UnderlyingConstructor.MetadataToken;

	public override RuntimeMethodHandle MethodHandle => UnderlyingConstructor.MethodHandle;

	public override Module Module => UnderlyingConstructor.Module;

	public override string Name => UnderlyingConstructor.Name;

	public override Type ReflectedType => UnderlyingConstructor.ReflectedType;

	public ConstructorInfo UnderlyingConstructor { get; }

	public DelegatingConstructorInfo(ConstructorInfo constructor)
	{
		UnderlyingConstructor = constructor;
	}

	public override object[] GetCustomAttributes(Type attributeType, bool inherit)
	{
		return UnderlyingConstructor.GetCustomAttributes(attributeType, inherit);
	}

	public override object[] GetCustomAttributes(bool inherit)
	{
		return UnderlyingConstructor.GetCustomAttributes(inherit);
	}

	public override IList<CustomAttributeData> GetCustomAttributesData()
	{
		return UnderlyingConstructor.GetCustomAttributesData();
	}

	public override Type[] GetGenericArguments()
	{
		return UnderlyingConstructor.GetGenericArguments();
	}

	public override MethodBody GetMethodBody()
	{
		return UnderlyingConstructor.GetMethodBody();
	}

	public override MethodImplAttributes GetMethodImplementationFlags()
	{
		return UnderlyingConstructor.GetMethodImplementationFlags();
	}

	public override ParameterInfo[] GetParameters()
	{
		return UnderlyingConstructor.GetParameters();
	}

	public override object Invoke(BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
	{
		return UnderlyingConstructor.Invoke(invokeAttr, binder, parameters, culture);
	}

	public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
	{
		return UnderlyingConstructor.Invoke(obj, invokeAttr, binder, parameters, culture);
	}

	public override bool IsDefined(Type attributeType, bool inherit)
	{
		return UnderlyingConstructor.IsDefined(attributeType, inherit);
	}

	public override string ToString()
	{
		return UnderlyingConstructor.ToString();
	}
}
