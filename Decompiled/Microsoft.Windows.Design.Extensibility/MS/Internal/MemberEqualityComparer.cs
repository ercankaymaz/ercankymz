using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace MS.Internal;

internal class MemberEqualityComparer : IEqualityComparer, IEqualityComparer<MemberInfo>
{
	internal static bool Equals(MemberInfo mx, MemberInfo my)
	{
		if (object.ReferenceEquals(mx, my))
		{
			return true;
		}
		if ((object)mx == null || (object)my == null)
		{
			return false;
		}
		if (mx.MetadataToken != my.MetadataToken)
		{
			return false;
		}
		if (!object.Equals(mx.Module, my.Module))
		{
			return false;
		}
		if (mx is Type type && my is Type type2)
		{
			if (type.IsGenericType)
			{
				if (type.IsGenericTypeDefinition != type2.IsGenericTypeDefinition)
				{
					return false;
				}
				if (!type.IsGenericTypeDefinition)
				{
					return TypesEqual(type.GetGenericArguments(), type2.GetGenericArguments());
				}
			}
		}
		else if (mx is MethodInfo methodInfo && my is MethodInfo methodInfo2 && methodInfo.IsGenericMethod)
		{
			if (methodInfo.IsGenericMethodDefinition != methodInfo2.IsGenericMethodDefinition)
			{
				return false;
			}
			if (!methodInfo.IsGenericMethodDefinition)
			{
				return TypesEqual(methodInfo.GetGenericArguments(), methodInfo2.GetGenericArguments());
			}
		}
		return true;
	}

	private static bool TypesEqual(Type[] tx, Type[] ty)
	{
		for (int i = 0; i < tx.Length; i++)
		{
			if (!Equals(tx[i], ty[i]))
			{
				return false;
			}
		}
		return true;
	}

	bool IEqualityComparer.Equals(object x, object y)
	{
		return Equals(x as MemberInfo, y as MemberInfo);
	}

	int IEqualityComparer.GetHashCode(object obj)
	{
		if (obj is MemberInfo memberInfo)
		{
			return memberInfo.MetadataToken;
		}
		return 0;
	}

	bool IEqualityComparer<MemberInfo>.Equals(MemberInfo x, MemberInfo y)
	{
		return Equals(x, y);
	}

	int IEqualityComparer<MemberInfo>.GetHashCode(MemberInfo obj)
	{
		return obj?.MetadataToken ?? 0;
	}
}
