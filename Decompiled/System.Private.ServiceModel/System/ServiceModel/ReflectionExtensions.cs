using System.Globalization;
using System.Linq;
using System.Reflection;

namespace System.ServiceModel;

internal static class ReflectionExtensions
{
	public static Assembly Assembly(this Type type)
	{
		return type.GetTypeInfo().Assembly;
	}

	public static Type BaseType(this Type type)
	{
		return type.GetTypeInfo().BaseType;
	}

	public static bool ContainsGenericParameters(this Type type)
	{
		return type.GetTypeInfo().ContainsGenericParameters;
	}

	public static ConstructorInfo GetConstructor(this Type type, Type[] types)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	public static ConstructorInfo GetConstructor(this Type type, BindingFlags bindingAttr, object binder, Type[] types, object[] modifiers)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	public static PropertyInfo GetProperty(this Type type, string name, BindingFlags bindingAttr)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	public static Type[] GetGenericArguments(this Type type)
	{
		return type.GetTypeInfo().GenericTypeArguments;
	}

	public static Type[] GetInterfaces(this Type type)
	{
		return type.GetTypeInfo().ImplementedInterfaces.ToArray();
	}

	public static bool IsAbstract(this Type type)
	{
		return type.GetTypeInfo().IsAbstract;
	}

	public static bool IsAssignableFrom(this Type type, Type otherType)
	{
		return type.GetTypeInfo().IsAssignableFrom(otherType.GetTypeInfo());
	}

	public static bool IsClass(this Type type)
	{
		return type.GetTypeInfo().IsClass;
	}

	public static bool IsDefined(this Type type, Type attributeType, bool inherit)
	{
		return type.GetTypeInfo().IsDefined(attributeType, inherit);
	}

	public static bool IsEnum(this Type type)
	{
		return type.GetTypeInfo().IsEnum;
	}

	public static bool IsGenericType(this Type type)
	{
		return type.GetTypeInfo().IsGenericType;
	}

	public static bool IsInterface(this Type type)
	{
		return type.GetTypeInfo().IsInterface;
	}

	public static bool IsInstanceOfType(this Type type, object o)
	{
		if (o != null)
		{
			return type.GetTypeInfo().IsAssignableFrom(o.GetType().GetTypeInfo());
		}
		return false;
	}

	public static bool IsMarshalByRef(this Type type)
	{
		return type.GetTypeInfo().IsMarshalByRef;
	}

	public static bool IsNotPublic(this Type type)
	{
		return type.GetTypeInfo().IsNotPublic;
	}

	public static bool IsSealed(this Type type)
	{
		return type.GetTypeInfo().IsSealed;
	}

	public static bool IsValueType(this Type type)
	{
		return type.GetTypeInfo().IsValueType;
	}

	public static InterfaceMapping GetInterfaceMap(this Type type, Type interfaceType)
	{
		return type.GetTypeInfo().GetRuntimeInterfaceMap(interfaceType);
	}

	public static MemberInfo[] GetMember(this Type type, string name, BindingFlags bindingAttr)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	public static MemberInfo[] GetMembers(this Type type, BindingFlags bindingAttr)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	public static MethodInfo GetMethod(this Type type, string name)
	{
		return type.GetTypeInfo().GetDeclaredMethod(name);
	}

	public static MethodInfo GetMethod(this Type type, string name, Type[] types)
	{
		return type.GetRuntimeMethod(name, types);
	}

	public static TypeCode GetTypeCode(this Type type)
	{
		if (type == null)
		{
			return TypeCode.Empty;
		}
		if (type == typeof(bool))
		{
			return TypeCode.Boolean;
		}
		if (type == typeof(char))
		{
			return TypeCode.Char;
		}
		if (type == typeof(sbyte))
		{
			return TypeCode.SByte;
		}
		if (type == typeof(byte))
		{
			return TypeCode.Byte;
		}
		if (type == typeof(short))
		{
			return TypeCode.Int16;
		}
		if (type == typeof(ushort))
		{
			return TypeCode.UInt16;
		}
		if (type == typeof(int))
		{
			return TypeCode.Int32;
		}
		if (type == typeof(uint))
		{
			return TypeCode.UInt32;
		}
		if (type == typeof(long))
		{
			return TypeCode.Int64;
		}
		if (type == typeof(ulong))
		{
			return TypeCode.UInt64;
		}
		if (type == typeof(float))
		{
			return TypeCode.Single;
		}
		if (type == typeof(double))
		{
			return TypeCode.Double;
		}
		if (type == typeof(decimal))
		{
			return TypeCode.Decimal;
		}
		if (type == typeof(DateTime))
		{
			return TypeCode.DateTime;
		}
		if (type == typeof(string))
		{
			return TypeCode.String;
		}
		if (type.GetTypeInfo().IsEnum)
		{
			return Enum.GetUnderlyingType(type).GetTypeCode();
		}
		return TypeCode.Object;
	}

	public static bool IsPublic(this ConstructorInfo ci)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	public static object Invoke(this ConstructorInfo ci, BindingFlags invokeAttr, object binder, object[] parameters, CultureInfo culture)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	public static RuntimeMethodHandle MethodHandle(this MethodBase mb)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	public static RuntimeMethodHandle MethodHandle(this MethodInfo mi)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	public static Type ReflectedType(this MethodInfo mi)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}
}
