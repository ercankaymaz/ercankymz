using System.Reflection;

namespace System.ComponentModel.Composition.ReflectionModel;

internal static class ReflectionExtensions
{
	public static ReflectionMember ToReflectionMember(this LazyMemberInfo lazyMember)
	{
		MemberInfo[] accessors = lazyMember.GetAccessors();
		MemberTypes memberType = lazyMember.MemberType;
		switch (memberType)
		{
		case MemberTypes.Field:
			if (accessors.Length != 1)
			{
				throw new Exception(System.SR.Diagnostic_InternalExceptionMessage);
			}
			return ((FieldInfo)accessors[0]).ToReflectionField();
		case MemberTypes.Property:
			if (accessors.Length != 2)
			{
				throw new Exception(System.SR.Diagnostic_InternalExceptionMessage);
			}
			return CreateReflectionProperty((MethodInfo)accessors[0], (MethodInfo)accessors[1]);
		case MemberTypes.TypeInfo:
		case MemberTypes.NestedType:
			return ((Type)accessors[0]).ToReflectionType();
		default:
			if (memberType != MemberTypes.Method)
			{
				throw new Exception(System.SR.Diagnostic_InternalExceptionMessage);
			}
			return ((MethodInfo)accessors[0]).ToReflectionMethod();
		}
	}

	public static LazyMemberInfo ToLazyMember(this MemberInfo member)
	{
		ArgumentNullException.ThrowIfNull(member, "member");
		if (member.MemberType == MemberTypes.Property)
		{
			PropertyInfo propertyInfo = member as PropertyInfo;
			if (propertyInfo == null)
			{
				throw new Exception(System.SR.Diagnostic_InternalExceptionMessage);
			}
			MemberInfo[] accessors = new MemberInfo[2]
			{
				propertyInfo.GetGetMethod(nonPublic: true),
				propertyInfo.GetSetMethod(nonPublic: true)
			};
			return new LazyMemberInfo(MemberTypes.Property, accessors);
		}
		return new LazyMemberInfo(member);
	}

	public static ReflectionWritableMember ToReflectionWriteableMember(this LazyMemberInfo lazyMember)
	{
		if (lazyMember.MemberType != MemberTypes.Field && lazyMember.MemberType != MemberTypes.Property)
		{
			throw new Exception(System.SR.Diagnostic_InternalExceptionMessage);
		}
		if (!(lazyMember.ToReflectionMember() is ReflectionWritableMember result))
		{
			throw new Exception(System.SR.Diagnostic_InternalExceptionMessage);
		}
		return result;
	}

	public static ReflectionProperty ToReflectionProperty(this PropertyInfo property)
	{
		ArgumentNullException.ThrowIfNull(property, "property");
		return CreateReflectionProperty(property.GetGetMethod(nonPublic: true), property.GetSetMethod(nonPublic: true));
	}

	public static ReflectionProperty CreateReflectionProperty(MethodInfo getMethod, MethodInfo setMethod)
	{
		if (getMethod == null && setMethod == null)
		{
			throw new Exception(System.SR.Diagnostic_InternalExceptionMessage);
		}
		return new ReflectionProperty(getMethod, setMethod);
	}

	public static ReflectionParameter ToReflectionParameter(this ParameterInfo parameter)
	{
		ArgumentNullException.ThrowIfNull(parameter, "parameter");
		return new ReflectionParameter(parameter);
	}

	public static ReflectionMethod ToReflectionMethod(this MethodInfo method)
	{
		if (method == null)
		{
			throw new ArgumentNullException("method");
		}
		return new ReflectionMethod(method);
	}

	public static ReflectionField ToReflectionField(this FieldInfo field)
	{
		ArgumentNullException.ThrowIfNull(field, "field");
		return new ReflectionField(field);
	}

	public static ReflectionType ToReflectionType(this Type type)
	{
		ArgumentNullException.ThrowIfNull(type, "type");
		return new ReflectionType(type);
	}

	public static ReflectionWritableMember ToReflectionWritableMember(this MemberInfo member)
	{
		ArgumentNullException.ThrowIfNull(member, "member");
		if (member.MemberType == MemberTypes.Property)
		{
			return ((PropertyInfo)member).ToReflectionProperty();
		}
		return ((FieldInfo)member).ToReflectionField();
	}
}
