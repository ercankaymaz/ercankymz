using System.Diagnostics.CodeAnalysis;

namespace System.Reflection;

internal static class NetstandardHelpers
{
	public static void ThrowIfNull(object argument, string paramName)
	{
		if (argument == null)
		{
			Throw(paramName);
		}
		static void Throw(string paramName2)
		{
			throw new ArgumentNullException(paramName2);
		}
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2070:UnrecognizedReflectionPattern", Justification = "This is finding the MemberInfo with the same MetadataToken as specified MemberInfo. If the specified MemberInfo exists and wasn't trimmed, then the current Type's MemberInfo couldn't have been trimmed.")]
	public static MemberInfo GetMemberWithSameMetadataDefinitionAs(this Type type, MemberInfo member)
	{
		ThrowIfNull(member, "member");
		MemberInfo[] members = type.GetMembers(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		foreach (MemberInfo memberInfo in members)
		{
			if (memberInfo.HasSameMetadataDefinitionAs(member))
			{
				return memberInfo;
			}
		}
		throw new MissingMemberException(type.FullName, member.Name);
	}

	private static bool HasSameMetadataDefinitionAs(this MemberInfo info, MemberInfo other)
	{
		if (info.MetadataToken != other.MetadataToken)
		{
			return false;
		}
		if (!info.Module.Equals(other.Module))
		{
			return false;
		}
		return true;
	}

	public static bool IsGenericMethodParameter(this Type type)
	{
		if (type.IsGenericParameter)
		{
			return (object)type.DeclaringMethod != null;
		}
		return false;
	}

	public static ReadOnlySpan<ParameterInfo> GetParametersAsSpan(this MethodBase metaMethod)
	{
		return metaMethod.GetParameters();
	}
}
