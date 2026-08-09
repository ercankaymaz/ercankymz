using System;
using System.Collections.Generic;
using System.Reflection;
using MS.Internal.Metadata;

namespace Microsoft.Windows.Design.Metadata;

public class AttributeTableContainer
{
	private List<AttributeTable> _tables;

	private AttributeTable[] _tableArray;

	private Dictionary<Type, object> _seenAttributes;

	private List<object> _compiledAttributes;

	private object _syncLock = new object();

	public IEnumerable<AttributeTable> AttributeTables => Tables;

	private AttributeTable[] AttributeTableArray
	{
		get
		{
			AttributeTable[] array = _tableArray;
			if (array == null)
			{
				lock (_syncLock)
				{
					array = (_tableArray = Tables.ToArray());
				}
			}
			return array;
		}
	}

	private List<AttributeTable> Tables
	{
		get
		{
			if (_tables == null)
			{
				lock (_syncLock)
				{
					if (_tables == null)
					{
						_tables = new List<AttributeTable>();
					}
				}
			}
			return _tables;
		}
	}

	public void AddAttributeTable(AttributeTable table)
	{
		if (table == null)
		{
			throw new ArgumentNullException("table");
		}
		lock (_syncLock)
		{
			Tables.Add(table);
			_tableArray = null;
		}
	}

	private void FillAttributes(Type type, MemberInfo member, Type attributeType, Func<object, object> reflectionMapper, List<object> compiledAttributes, Dictionary<Type, object> seenAttributes)
	{
		Type type2 = type;
		MemberInfo memberInfo = member;
		bool firstIteration = true;
		bool flag = member is Type;
		bool includeClrAttributes = flag || (object)memberInfo.DeclaringType == type2;
		Type type3 = attributeType;
		if (reflectionMapper != null)
		{
			type3 = (Type)reflectionMapper(attributeType);
		}
		if ((object)type3 == null && (object)attributeType != null)
		{
			return;
		}
		while ((object)type2 != null && (object)memberInfo != null)
		{
			FillAttributesHelper(attributeType, reflectionMapper, compiledAttributes, seenAttributes, type2, memberInfo, firstIteration, includeClrAttributes, type3);
			firstIteration = false;
			if (flag && type2.IsGenericType)
			{
				Type genericTypeDefinition = type2.GetGenericTypeDefinition();
				FillAttributesHelper(attributeType, reflectionMapper, compiledAttributes, seenAttributes, genericTypeDefinition, genericTypeDefinition, firstIteration, includeClrAttributes, type3);
			}
			if (flag || (object)memberInfo.DeclaringType == type2)
			{
				memberInfo = AttributeDataCache.GetBaseMemberInfo(memberInfo);
			}
			type2 = type2.BaseType;
			includeClrAttributes = ((flag || (object)memberInfo == null || (object)memberInfo.DeclaringType == type2) ? true : false);
		}
	}

	private void FillAttributesHelper(Type attributeType, Func<object, object> reflectionMapper, List<object> compiledAttributes, Dictionary<Type, object> seenAttributes, Type currentType, MemberInfo currentMember, bool firstIteration, bool includeClrAttributes, Type runtimeAttributeType)
	{
		Type type = ((reflectionMapper == null) ? currentType : ((Type)reflectionMapper(currentType)));
		if ((object)type == null && (object)currentType != null)
		{
			return;
		}
		foreach (object item in MergeAttributesIterator(currentType, currentMember, attributeType, type, runtimeAttributeType, includeClrAttributes))
		{
			AttributeData attributeData = AttributeDataCache.GetAttributeData(item.GetType());
			if ((!seenAttributes.ContainsKey(attributeData.AttributeType) || attributeData.AllowsMultiple) && (firstIteration || attributeData.IsInheritable))
			{
				compiledAttributes.Add(item);
				seenAttributes[attributeData.AttributeType] = item;
			}
		}
	}

	public IEnumerable<object> GetAttributes(Assembly assembly, Type attributeType)
	{
		return GetAttributes(assembly, attributeType, null);
	}

	public IEnumerable<object> GetAttributes(Assembly assembly, Type attributeType, Func<object, object> reflectionMapper)
	{
		if ((object)assembly == null)
		{
			throw new ArgumentNullException("assembly");
		}
		List<object> list;
		Dictionary<Type, object> dictionary;
		lock (_syncLock)
		{
			list = _compiledAttributes;
			dictionary = _seenAttributes;
			_compiledAttributes = null;
			_seenAttributes = null;
		}
		if (list == null)
		{
			list = new List<object>();
		}
		else
		{
			list.Clear();
		}
		if (dictionary == null)
		{
			dictionary = new Dictionary<Type, object>();
		}
		else
		{
			dictionary.Clear();
		}
		foreach (object item in MergeAttributesIterator(assembly, attributeType, includeClrAttributes: true, reflectionMapper))
		{
			AttributeData attributeData = AttributeDataCache.GetAttributeData(item.GetType());
			if (!dictionary.ContainsKey(attributeData.AttributeType) || attributeData.AllowsMultiple)
			{
				list.Add(item);
				dictionary[attributeData.AttributeType] = item;
			}
		}
		object[] result = list.ToArray();
		lock (_syncLock)
		{
			_compiledAttributes = list;
			_seenAttributes = dictionary;
			return result;
		}
	}

	public IEnumerable<object> GetAttributes(MemberInfo member, Type attributeType)
	{
		return GetAttributes(member, attributeType, null);
	}

	public IEnumerable<object> GetAttributes(MemberInfo member, Type attributeType, Func<object, object> reflectionMapper)
	{
		if ((object)member == null)
		{
			throw new ArgumentNullException("member");
		}
		if (member is PropertyInfo propertyInfo)
		{
			return GetAttributes(propertyInfo.ReflectedType, propertyInfo, attributeType, reflectionMapper, propertyInfo.PropertyType);
		}
		if (member is Type type)
		{
			return GetAttributes(type, type, attributeType, reflectionMapper, type.GetInterfaces());
		}
		if (member is EventInfo eventInfo)
		{
			return GetAttributes(eventInfo.ReflectedType, eventInfo, attributeType, reflectionMapper, eventInfo.EventHandlerType);
		}
		if (member is FieldInfo fieldInfo)
		{
			return GetAttributes(fieldInfo.ReflectedType, fieldInfo, attributeType, reflectionMapper, fieldInfo.FieldType);
		}
		return GetAttributes(member.ReflectedType, member, attributeType, reflectionMapper);
	}

	private IEnumerable<object> GetAttributes(Type type, MemberInfo member, Type attributeType, Func<object, object> reflectionMapper, params Type[] mergeTypes)
	{
		List<object> list;
		Dictionary<Type, object> dictionary;
		lock (_syncLock)
		{
			list = _compiledAttributes;
			dictionary = _seenAttributes;
			_compiledAttributes = null;
			_seenAttributes = null;
		}
		if (list == null)
		{
			list = new List<object>();
		}
		else
		{
			list.Clear();
		}
		if (dictionary == null)
		{
			dictionary = new Dictionary<Type, object>();
		}
		else
		{
			dictionary.Clear();
		}
		FillAttributes(type, member, attributeType, reflectionMapper, list, dictionary);
		if (mergeTypes != null)
		{
			foreach (Type type2 in mergeTypes)
			{
				FillAttributes(type2, type2, attributeType, reflectionMapper, list, dictionary);
			}
		}
		object[] result = list.ToArray();
		lock (_syncLock)
		{
			_compiledAttributes = list;
			_seenAttributes = dictionary;
			return result;
		}
	}

	public IEnumerable<object> GetLocalAttributes(MemberInfo member, Type attributeType)
	{
		return GetLocalAttributes(member, attributeType, null);
	}

	public IEnumerable<object> GetLocalAttributes(MemberInfo member, Type attributeType, Func<object, object> reflectionMapper)
	{
		if ((object)member == null)
		{
			throw new ArgumentNullException("member");
		}
		Type type = member as Type;
		if ((object)type == null)
		{
			type = member.ReflectedType;
		}
		return GetAttributes(type, member, attributeType, reflectionMapper);
	}

	private IEnumerable<object> MergeAttributesIterator(Type type, MemberInfo member, Type attributeType, Type runtimeType, Type runtimeAttributeType, bool includeClrAttributes)
	{
		string memberName = ((member is Type) ? null : member.Name);
		AttributeTable[] tables = AttributeTableArray;
		foreach (object attr in AttributeDataCache.GetAttributeTableAttributes(null, runtimeType, memberName, tables))
		{
			if ((object)runtimeAttributeType == null || runtimeAttributeType.IsInstanceOfType(attr))
			{
				yield return attr;
			}
		}
		if (!includeClrAttributes)
		{
			yield break;
		}
		IEnumerable<object> enumerator2 = AttributeDataCache.GetClrAttributes(null, member, attributeType);
		if (enumerator2 == null)
		{
			yield break;
		}
		foreach (object item in enumerator2)
		{
			yield return item;
		}
	}

	private IEnumerable<object> MergeAttributesIterator(Assembly assembly, Type attributeType, bool includeClrAttributes, Func<object, object> reflectionMapper)
	{
		AttributeTable[] tables = AttributeTableArray;
		Assembly runtimeAssembly = assembly;
		Type runtimeAttributeType = attributeType;
		if (reflectionMapper != null)
		{
			runtimeAssembly = (Assembly)reflectionMapper(assembly);
			if ((object)runtimeAttributeType != null)
			{
				runtimeAttributeType = (Type)reflectionMapper(attributeType);
			}
		}
		if (((object)runtimeAssembly == null && (object)assembly != null) || ((object)runtimeAttributeType == null && (object)attributeType != null))
		{
			yield break;
		}
		foreach (object attr in AttributeDataCache.GetAttributeTableAttributes(runtimeAssembly, null, null, tables))
		{
			if ((object)runtimeAttributeType == null || runtimeAttributeType.IsInstanceOfType(attr))
			{
				yield return attr;
			}
		}
		if (!includeClrAttributes)
		{
			yield break;
		}
		IEnumerable<object> enumerator2 = AttributeDataCache.GetClrAttributes(assembly, null, attributeType);
		if (enumerator2 == null)
		{
			yield break;
		}
		foreach (object item in enumerator2)
		{
			yield return item;
		}
	}
}
