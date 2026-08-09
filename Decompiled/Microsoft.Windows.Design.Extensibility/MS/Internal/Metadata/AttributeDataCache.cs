using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Windows.Design.Metadata;

namespace MS.Internal.Metadata;

internal static class AttributeDataCache
{
	private delegate MemberInfo GetBaseMemberCallback(MemberInfo member, Type targetType);

	private struct AttributeKey : IEquatable<AttributeKey>
	{
		private Assembly _assembly;

		private MemberInfo _member;

		private Type _attributeType;

		private int _hashCode;

		internal AttributeKey(Assembly assembly, MemberInfo member, Type attributeType)
		{
			_assembly = assembly;
			_member = member;
			_attributeType = attributeType;
			_hashCode = assembly?.GetHashCode() ?? member.GetHashCode();
			if ((object)_attributeType != null)
			{
				_hashCode += _attributeType.GetHashCode();
			}
		}

		public override int GetHashCode()
		{
			return _hashCode;
		}

		public override bool Equals(object obj)
		{
			if (obj is AttributeKey other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(AttributeKey other)
		{
			if ((!object.ReferenceEquals(_assembly, other._assembly) || (object)_assembly == null) && !MemberEqualityComparer.Equals(_member, other._member))
			{
				return false;
			}
			return MemberEqualityComparer.Equals(_attributeType, other._attributeType);
		}
	}

	private static Hashtable _baseMemberMap;

	private static Hashtable _attributeDataCache;

	private static Dictionary<AttributeKey, object[]> _attributeCache;

	private static object _noMemberInfo;

	private static object _syncObject;

	private static Dictionary<MemberTypes, GetBaseMemberCallback> _baseMemberFinders;

	private static readonly BindingFlags _getInfoBindingFlags;

	static AttributeDataCache()
	{
		_baseMemberMap = new Hashtable(new MemberEqualityComparer());
		_attributeDataCache = new Hashtable();
		_noMemberInfo = new object();
		_syncObject = new object();
		_getInfoBindingFlags = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
		_baseMemberFinders = new Dictionary<MemberTypes, GetBaseMemberCallback>();
		_baseMemberFinders[MemberTypes.Constructor] = GetBaseConstructorInfo;
		_baseMemberFinders[MemberTypes.Method] = GetBaseMethodInfo;
		_baseMemberFinders[MemberTypes.Property] = GetBasePropertyInfo;
		_baseMemberFinders[MemberTypes.Event] = GetBaseEventInfo;
	}

	internal static MemberInfo GetBaseMemberInfo(MemberInfo member)
	{
		object obj = _baseMemberMap[member];
		if (obj == _noMemberInfo)
		{
			return null;
		}
		if (obj == null)
		{
			obj = CalculateBaseMemberInfo(member);
			lock (_syncObject)
			{
				_baseMemberMap[member] = obj ?? _noMemberInfo;
			}
		}
		return (MemberInfo)obj;
	}

	internal static IEnumerable<object> GetAttributeTableAttributes(Assembly assembly, Type type, string memberName, AttributeTable[] tables)
	{
		if (tables == null || tables.Length == 0)
		{
			yield break;
		}
		Identifier memberIdentifier = Identifier.For(memberName);
		for (int idx = tables.Length - 1; idx >= 0; idx--)
		{
			AttributeTable table = tables[idx];
			IEnumerable attrEnum;
			if ((object)assembly != null)
			{
				attrEnum = table.GetCustomAttributes(assembly);
			}
			else
			{
				if (!table.ContainsAttributes(type))
				{
					continue;
				}
				attrEnum = ((memberName != null) ? table.GetCustomAttributes(type, memberIdentifier) : table.GetCustomAttributes(type));
			}
			foreach (object item in attrEnum)
			{
				yield return item;
			}
		}
	}

	internal static IEnumerable<object> GetClrAttributes(Assembly assembly, MemberInfo member, Type attributeType)
	{
		AttributeKey key = new AttributeKey(assembly, member, attributeType);
		bool flag;
		object[] value;
		lock (_syncObject)
		{
			if (_attributeCache == null)
			{
				_attributeCache = new Dictionary<AttributeKey, object[]>();
			}
			flag = _attributeCache.TryGetValue(key, out value);
		}
		if (!flag)
		{
			try
			{
				value = (((object)assembly != null) ? (((object)attributeType == null) ? assembly.GetCustomAttributes(inherit: false) : assembly.GetCustomAttributes(attributeType, inherit: false)) : (((object)attributeType == null) ? member.GetCustomAttributes(inherit: false) : member.GetCustomAttributes(attributeType, inherit: false)));
			}
			catch
			{
				value = null;
			}
			lock (_syncObject)
			{
				_attributeCache[key] = value;
			}
		}
		return value;
	}

	internal static AttributeData GetAttributeData(Type attributeType)
	{
		AttributeData attributeData = _attributeDataCache[attributeType] as AttributeData;
		if (attributeData == null)
		{
			attributeData = new AttributeData(attributeType);
			lock (_syncObject)
			{
				_attributeDataCache[attributeType] = attributeData;
			}
		}
		return attributeData;
	}

	private static MemberInfo CalculateBaseMemberInfo(MemberInfo member)
	{
		if (member is Type type)
		{
			return type.BaseType;
		}
		Type baseType = member.DeclaringType.BaseType;
		MemberInfo memberInfo = null;
		while ((object)baseType != null && (object)memberInfo == null)
		{
			memberInfo = _baseMemberFinders[member.MemberType](member, baseType);
			baseType = baseType.BaseType;
		}
		return memberInfo;
	}

	private static MemberInfo GetBaseConstructorInfo(MemberInfo info, Type targetType)
	{
		return null;
	}

	private static MemberInfo GetBaseMethodInfo(MemberInfo info, Type targetType)
	{
		MethodInfo methodInfo = info as MethodInfo;
		if (methodInfo.IsStatic)
		{
			return null;
		}
		return targetType.GetMethod(methodInfo.Name, _getInfoBindingFlags, null, ToTypeArray(methodInfo.GetParameters()), null);
	}

	private static MemberInfo GetBasePropertyInfo(MemberInfo info, Type targetType)
	{
		PropertyInfo propertyInfo = info as PropertyInfo;
		return targetType.GetProperty(propertyInfo.Name, _getInfoBindingFlags, null, propertyInfo.PropertyType, ToTypeArray(propertyInfo.GetIndexParameters()), null);
	}

	private static MemberInfo GetBaseEventInfo(MemberInfo info, Type targetType)
	{
		EventInfo eventInfo = info as EventInfo;
		return targetType.GetEvent(eventInfo.Name, _getInfoBindingFlags);
	}

	private static Type[] ToTypeArray(ParameterInfo[] parameterInfo)
	{
		if (parameterInfo == null)
		{
			return null;
		}
		Type[] array = new Type[parameterInfo.Length];
		for (int i = 0; i < parameterInfo.Length; i++)
		{
			array[i] = parameterInfo[i].ParameterType;
		}
		return array;
	}
}
