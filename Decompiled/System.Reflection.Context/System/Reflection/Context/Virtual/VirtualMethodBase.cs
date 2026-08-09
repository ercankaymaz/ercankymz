using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace System.Reflection.Context.Virtual;

internal abstract class VirtualMethodBase : MethodInfo
{
	private ParameterInfo _returnParameter;

	public override MethodAttributes Attributes => MethodAttributes.Public | MethodAttributes.HideBySig;

	public sealed override CallingConventions CallingConvention => CallingConventions.Standard | CallingConventions.HasThis;

	public sealed override bool ContainsGenericParameters => false;

	public sealed override bool IsGenericMethod => false;

	public sealed override bool IsGenericMethodDefinition => false;

	public override RuntimeMethodHandle MethodHandle
	{
		get
		{
			throw new NotSupportedException();
		}
	}

	public sealed override Module Module => DeclaringType.Module;

	public sealed override Type ReflectedType => DeclaringType;

	public sealed override ParameterInfo ReturnParameter => _returnParameter ?? (_returnParameter = new VirtualReturnParameter(this));

	public sealed override ICustomAttributeProvider ReturnTypeCustomAttributes => ReturnParameter;

	protected abstract Type[] GetParameterTypes();

	public sealed override MethodInfo GetBaseDefinition()
	{
		return this;
	}

	public sealed override Type[] GetGenericArguments()
	{
		return CollectionServices.Empty<Type>();
	}

	public sealed override MethodInfo GetGenericMethodDefinition()
	{
		throw new InvalidOperationException();
	}

	public sealed override MethodImplAttributes GetMethodImplementationFlags()
	{
		return MethodImplAttributes.IL;
	}

	public override ParameterInfo[] GetParameters()
	{
		return CollectionServices.Empty<ParameterInfo>();
	}

	[RequiresUnreferencedCode("If some of the generic arguments are annotated (either with DynamicallyAccessedMembersAttribute, or generic constraints), trimming can't validate that the requirements of those annotations are met.")]
	public sealed override MethodInfo MakeGenericMethod(params Type[] typeArguments)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.InvalidOperation_NotGenericMethodDefinition, this));
	}

	public override object[] GetCustomAttributes(Type attributeType, bool inherit)
	{
		return CollectionServices.Empty<object>();
	}

	public override object[] GetCustomAttributes(bool inherit)
	{
		return CollectionServices.Empty<object>();
	}

	public override IList<CustomAttributeData> GetCustomAttributesData()
	{
		return CollectionServices.Empty<CustomAttributeData>();
	}

	public override bool IsDefined(Type attributeType, bool inherit)
	{
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is VirtualMethodBase virtualMethodBase && Name == virtualMethodBase.Name && DeclaringType.Equals(virtualMethodBase.DeclaringType))
		{
			return CollectionServices.CompareArrays(GetParameterTypes(), virtualMethodBase.GetParameterTypes());
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Name.GetHashCode() ^ DeclaringType.GetHashCode() ^ CollectionServices.GetArrayHashCode(GetParameterTypes());
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ReturnType.ToString());
		stringBuilder.Append(' ');
		stringBuilder.Append(Name);
		stringBuilder.Append('(');
		Type[] parameterTypes = GetParameterTypes();
		string value = "";
		Type[] array = parameterTypes;
		foreach (Type type in array)
		{
			stringBuilder.Append(value);
			stringBuilder.Append(type.ToString());
			value = ", ";
		}
		if ((CallingConvention & CallingConventions.VarArgs) == CallingConventions.VarArgs)
		{
			stringBuilder.Append(value);
			stringBuilder.Append("...");
		}
		return stringBuilder.ToString();
	}
}
