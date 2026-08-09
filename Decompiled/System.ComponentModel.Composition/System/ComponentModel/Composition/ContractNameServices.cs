using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.Internal;

namespace System.ComponentModel.Composition;

internal static class ContractNameServices
{
	private const char NamespaceSeparator = '.';

	private const char ArrayOpeningBracket = '[';

	private const char ArrayClosingBracket = ']';

	private const char ArraySeparator = ',';

	private const char PointerSymbol = '*';

	private const char ReferenceSymbol = '&';

	private const char GenericArityBackQuote = '`';

	private const char NestedClassSeparator = '+';

	private const char ContractNameGenericOpeningBracket = '(';

	private const char ContractNameGenericClosingBracket = ')';

	private const char ContractNameGenericArgumentSeparator = ',';

	private const char CustomModifiersSeparator = ' ';

	private const char GenericFormatOpeningBracket = '{';

	private const char GenericFormatClosingBracket = '}';

	[ThreadStatic]
	private static Dictionary<Type, string> typeIdentityCache;

	private static Dictionary<Type, string> TypeIdentityCache => typeIdentityCache ?? (typeIdentityCache = new Dictionary<Type, string>());

	internal static string GetTypeIdentity(Type type)
	{
		return GetTypeIdentity(type, formatGenericName: true);
	}

	internal static string GetTypeIdentity(Type type, bool formatGenericName)
	{
		ArgumentNullException.ThrowIfNull(type, "type");
		if (!TypeIdentityCache.TryGetValue(type, out string value))
		{
			if (!type.IsAbstract && type.HasBaseclassOf(typeof(Delegate)))
			{
				MethodInfo method = type.GetMethod("Invoke");
				value = GetTypeIdentityFromMethod(method);
			}
			else if (type.IsGenericParameter)
			{
				StringBuilder stringBuilder = new StringBuilder();
				WriteTypeArgument(stringBuilder, isDefinition: false, type, formatGenericName);
				stringBuilder.Remove(stringBuilder.Length - 1, 1);
				value = stringBuilder.ToString();
			}
			else
			{
				StringBuilder stringBuilder2 = new StringBuilder();
				WriteTypeWithNamespace(stringBuilder2, type, formatGenericName);
				value = stringBuilder2.ToString();
			}
			if (string.IsNullOrEmpty(value))
			{
				throw new Exception(System.SR.Diagnostic_InternalExceptionMessage);
			}
			TypeIdentityCache.Add(type, value);
		}
		return value;
	}

	internal static string GetTypeIdentityFromMethod(MethodInfo method)
	{
		return GetTypeIdentityFromMethod(method, formatGenericName: true);
	}

	internal static string GetTypeIdentityFromMethod(MethodInfo method, bool formatGenericName)
	{
		StringBuilder stringBuilder = new StringBuilder();
		WriteTypeWithNamespace(stringBuilder, method.ReturnType, formatGenericName);
		stringBuilder.Append('(');
		ParameterInfo[] parameters = method.GetParameters();
		for (int i = 0; i < parameters.Length; i++)
		{
			if (i != 0)
			{
				stringBuilder.Append(',');
			}
			WriteTypeWithNamespace(stringBuilder, parameters[i].ParameterType, formatGenericName);
		}
		stringBuilder.Append(')');
		return stringBuilder.ToString();
	}

	private static void WriteTypeWithNamespace(StringBuilder typeName, Type type, bool formatGenericName)
	{
		if (!string.IsNullOrEmpty(type.Namespace))
		{
			typeName.Append(type.Namespace);
			typeName.Append('.');
		}
		WriteType(typeName, type, formatGenericName);
	}

	private static void WriteType(StringBuilder typeName, Type type, bool formatGenericName)
	{
		if (type.IsGenericType)
		{
			Queue<Type> queue = new Queue<Type>(type.GetGenericArguments());
			WriteGenericType(typeName, type, type.IsGenericTypeDefinition, queue, formatGenericName);
			if (queue.Count != 0)
			{
				throw new Exception(System.SR.Expecting_Empty_Queue);
			}
		}
		else
		{
			WriteNonGenericType(typeName, type, formatGenericName);
		}
	}

	private static void WriteNonGenericType(StringBuilder typeName, Type type, bool formatGenericName)
	{
		if (type.DeclaringType != null)
		{
			WriteType(typeName, type.DeclaringType, formatGenericName);
			typeName.Append('+');
		}
		if (type.IsArray)
		{
			WriteArrayType(typeName, type, formatGenericName);
		}
		else if (type.IsPointer)
		{
			WritePointerType(typeName, type, formatGenericName);
		}
		else if (type.IsByRef)
		{
			WriteByRefType(typeName, type, formatGenericName);
		}
		else
		{
			typeName.Append(type.Name);
		}
	}

	private static void WriteArrayType(StringBuilder typeName, Type type, bool formatGenericName)
	{
		Type type2 = FindArrayElementType(type);
		WriteType(typeName, type2, formatGenericName);
		Type type3 = type;
		do
		{
			WriteArrayTypeDimensions(typeName, type3);
		}
		while ((type3 = type3.GetElementType()) != null && type3.IsArray);
	}

	private static void WritePointerType(StringBuilder typeName, Type type, bool formatGenericName)
	{
		WriteType(typeName, type.GetElementType(), formatGenericName);
		typeName.Append('*');
	}

	private static void WriteByRefType(StringBuilder typeName, Type type, bool formatGenericName)
	{
		WriteType(typeName, type.GetElementType(), formatGenericName);
		typeName.Append('&');
	}

	private static void WriteArrayTypeDimensions(StringBuilder typeName, Type type)
	{
		typeName.Append('[');
		int arrayRank = type.GetArrayRank();
		for (int i = 1; i < arrayRank; i++)
		{
			typeName.Append(',');
		}
		typeName.Append(']');
	}

	private static void WriteGenericType(StringBuilder typeName, Type type, bool isDefinition, Queue<Type> genericTypeArguments, bool formatGenericName)
	{
		if (type.DeclaringType != null)
		{
			if (type.DeclaringType.IsGenericType)
			{
				WriteGenericType(typeName, type.DeclaringType, isDefinition, genericTypeArguments, formatGenericName);
			}
			else
			{
				WriteNonGenericType(typeName, type.DeclaringType, formatGenericName);
			}
			typeName.Append('+');
		}
		WriteGenericTypeName(typeName, type, isDefinition, genericTypeArguments, formatGenericName);
	}

	private static void WriteGenericTypeName(StringBuilder typeName, Type type, bool isDefinition, Queue<Type> genericTypeArguments, bool formatGenericName)
	{
		if (!type.IsGenericType)
		{
			throw new Exception(System.SR.Expecting_Generic_Type);
		}
		int genericArity = GetGenericArity(type);
		string value = FindGenericTypeName(type.GetGenericTypeDefinition().Name);
		typeName.Append(value);
		WriteTypeArgumentsString(typeName, genericArity, isDefinition, genericTypeArguments, formatGenericName);
	}

	private static void WriteTypeArgumentsString(StringBuilder typeName, int argumentsCount, bool isDefinition, Queue<Type> genericTypeArguments, bool formatGenericName)
	{
		if (argumentsCount == 0)
		{
			return;
		}
		typeName.Append('(');
		for (int i = 0; i < argumentsCount; i++)
		{
			if (genericTypeArguments.Count == 0)
			{
				throw new Exception(System.SR.Expecting_AtleastOne_Type);
			}
			Type genericTypeArgument = genericTypeArguments.Dequeue();
			WriteTypeArgument(typeName, isDefinition, genericTypeArgument, formatGenericName);
		}
		typeName.Remove(typeName.Length - 1, 1);
		typeName.Append(')');
	}

	private static void WriteTypeArgument(StringBuilder typeName, bool isDefinition, Type genericTypeArgument, bool formatGenericName)
	{
		if (!isDefinition && !genericTypeArgument.IsGenericParameter)
		{
			WriteTypeWithNamespace(typeName, genericTypeArgument, formatGenericName);
		}
		if (formatGenericName && genericTypeArgument.IsGenericParameter)
		{
			typeName.Append('{');
			typeName.Append(genericTypeArgument.GenericParameterPosition);
			typeName.Append('}');
		}
		typeName.Append(',');
	}

	internal static void WriteCustomModifiers(StringBuilder typeName, string customKeyword, Type[] types, bool formatGenericName)
	{
		typeName.Append(' ');
		typeName.Append(customKeyword);
		Queue<Type> queue = new Queue<Type>(types);
		WriteTypeArgumentsString(typeName, types.Length, isDefinition: false, queue, formatGenericName);
		if (queue.Count != 0)
		{
			throw new Exception(System.SR.Expecting_Empty_Queue);
		}
	}

	private static Type FindArrayElementType(Type type)
	{
		Type type2 = type;
		while ((type2 = type2.GetElementType()) != null && type2.IsArray)
		{
		}
		return type2;
	}

	private static string FindGenericTypeName(string genericName)
	{
		int num = genericName.IndexOf('`');
		if (num > -1)
		{
			genericName = genericName.Substring(0, num);
		}
		return genericName;
	}

	private static int GetGenericArity(Type type)
	{
		if (type.DeclaringType == null)
		{
			return type.GetGenericArguments().Length;
		}
		int num = type.DeclaringType.GetGenericArguments().Length;
		int num2 = type.GetGenericArguments().Length;
		if (num2 < num)
		{
			throw new Exception(System.SR.Diagnostic_InternalExceptionMessage);
		}
		return num2 - num;
	}
}
