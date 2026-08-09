using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using MS.Internal.Properties;
using Microsoft.Windows.Design.Metadata;

namespace MS.Internal.Metadata;

internal class MutableAttributeTable
{
	private class TypeMetadata
	{
		internal AttributeList TypeAttributes;

		internal Dictionary<string, AttributeList> MemberAttributes;
	}

	private class AttributeList : List<object>
	{
		private bool _isExpanded;

		internal bool IsExpanded
		{
			get
			{
				return _isExpanded;
			}
			set
			{
				_isExpanded = value;
			}
		}
	}

	private delegate AttributeList GetAttributesCallback(Type type, object callbackParam);

	private Dictionary<Assembly, AttributeList> _assemblyAttributes;

	private Dictionary<Type, TypeMetadata> _metadata;

	private object _syncLock = new object();

	private static object[] _empty = new object[0];

	internal IEnumerable<Type> AttributedTypes => _metadata.Keys;

	internal MutableAttributeTable()
	{
		_assemblyAttributes = new Dictionary<Assembly, AttributeList>();
		_metadata = new Dictionary<Type, TypeMetadata>();
	}

	private static void AddAttributeMetadata(TypeMetadata newMd, TypeMetadata existingMd)
	{
		if (newMd.TypeAttributes != null)
		{
			if (existingMd.TypeAttributes != null)
			{
				existingMd.TypeAttributes.AddRange(newMd.TypeAttributes);
			}
			else
			{
				existingMd.TypeAttributes = newMd.TypeAttributes;
			}
		}
	}

	private static void AddAttributes(AttributeList list, IEnumerable<object> attributes)
	{
		list.AddRange(attributes);
	}

	internal void AddCallback(Type type, AttributeCallback callback)
	{
		AttributeList typeList = GetTypeList(type);
		typeList.Add(callback);
	}

	internal void AddCustomAttributes(Assembly assembly, IEnumerable<object> attributes)
	{
		AddAttributes(GetAssemblyList(assembly), attributes);
	}

	internal void AddCustomAttributes(Type type, IEnumerable<object> attributes)
	{
		AddAttributes(GetTypeList(type), attributes);
	}

	internal void AddCustomAttributes(Type ownerType, string memberName, IEnumerable<object> attributes)
	{
		AddAttributes(GetMemberList(ownerType, memberName), attributes);
	}

	private static void AddMemberMetadata(TypeMetadata newMd, TypeMetadata existingMd)
	{
		if (newMd.MemberAttributes == null)
		{
			return;
		}
		if (existingMd.MemberAttributes != null)
		{
			foreach (KeyValuePair<string, AttributeList> memberAttribute in newMd.MemberAttributes)
			{
				if (existingMd.MemberAttributes.TryGetValue(memberAttribute.Key, out var value))
				{
					value.AddRange(memberAttribute.Value);
				}
				else
				{
					existingMd.MemberAttributes.Add(memberAttribute.Key, memberAttribute.Value);
				}
			}
			return;
		}
		existingMd.MemberAttributes = newMd.MemberAttributes;
	}

	internal void AddTable(MutableAttributeTable table)
	{
		foreach (KeyValuePair<Type, TypeMetadata> item in table._metadata)
		{
			AddTypeMetadata(item.Key, item.Value);
		}
		foreach (KeyValuePair<Assembly, AttributeList> assemblyAttribute in table._assemblyAttributes)
		{
			AddAssemblyMetadata(assemblyAttribute.Key, assemblyAttribute.Value);
		}
	}

	private void AddTypeMetadata(Type type, TypeMetadata md)
	{
		if (_metadata.TryGetValue(type, out var value))
		{
			AddAttributeMetadata(md, value);
			AddMemberMetadata(md, value);
		}
		else
		{
			_metadata.Add(type, md);
		}
	}

	private void AddAssemblyMetadata(Assembly assembly, AttributeList attributes)
	{
		if (_assemblyAttributes.TryGetValue(assembly, out var value))
		{
			if (!attributes.IsExpanded)
			{
				value.IsExpanded = false;
			}
			value.AddRange(attributes);
		}
		else
		{
			_assemblyAttributes.Add(assembly, attributes);
		}
	}

	internal bool ContainsAttributes(Type type)
	{
		return _metadata.ContainsKey(type);
	}

	private void ExpandAttributes(Type type, AttributeList attributes)
	{
		if (attributes.IsExpanded)
		{
			return;
		}
		for (int i = 0; i < attributes.Count; i++)
		{
			for (AttributeCallback attributeCallback = attributes[i] as AttributeCallback; attributeCallback != null; attributeCallback = ((i >= attributes.Count) ? null : (attributes[i] as AttributeCallback)))
			{
				attributes.RemoveAt(i);
				AttributeCallbackBuilder builder = new AttributeCallbackBuilder(this, type);
				attributeCallback(builder);
			}
		}
	}

	internal IEnumerable GetCustomAttributes(Assembly assembly)
	{
		if (_assemblyAttributes.TryGetValue(assembly, out var value))
		{
			return value.AsReadOnly();
		}
		return _empty;
	}

	internal IEnumerable GetCustomAttributes(Type type)
	{
		AttributeList expandedAttributes = GetExpandedAttributes(type, null, (Type typeToGet, object callbackParam) => _metadata.TryGetValue(typeToGet, out var value) ? value.TypeAttributes : null);
		if (expandedAttributes != null)
		{
			return expandedAttributes.AsReadOnly();
		}
		return _empty;
	}

	internal IEnumerable GetCustomAttributes(Type ownerType, string memberName)
	{
		AttributeList expandedAttributes = GetExpandedAttributes(ownerType, memberName, delegate(Type typeToGet, object callbackParam)
		{
			string key = (string)callbackParam;
			if (_metadata.TryGetValue(typeToGet, out var value))
			{
				if (value.MemberAttributes == null && value.TypeAttributes != null && !value.TypeAttributes.IsExpanded)
				{
					lock (_syncLock)
					{
						ExpandAttributes(ownerType, value.TypeAttributes);
						value.TypeAttributes.IsExpanded = true;
					}
				}
				if (value.MemberAttributes != null && value.MemberAttributes.TryGetValue(key, out var value2))
				{
					return value2;
				}
			}
			return (AttributeList)null;
		});
		if (expandedAttributes != null)
		{
			return expandedAttributes.AsReadOnly();
		}
		return _empty;
	}

	private AttributeList GetMemberList(Type ownerType, string memberName)
	{
		TypeMetadata typeMetadata = GetTypeMetadata(ownerType);
		if (typeMetadata.MemberAttributes == null)
		{
			typeMetadata.MemberAttributes = new Dictionary<string, AttributeList>();
		}
		if (!typeMetadata.MemberAttributes.TryGetValue(memberName, out var value))
		{
			value = new AttributeList();
			typeMetadata.MemberAttributes.Add(memberName, value);
		}
		return value;
	}

	private AttributeList GetAssemblyList(Assembly assembly)
	{
		if (!_assemblyAttributes.TryGetValue(assembly, out var value))
		{
			value = new AttributeList();
			_assemblyAttributes.Add(assembly, value);
		}
		return value;
	}

	private AttributeList GetExpandedAttributes(Type type, object callbackParam, GetAttributesCallback callback)
	{
		AttributeList attributeList = callback(type, callbackParam);
		if (attributeList != null && !attributeList.IsExpanded)
		{
			lock (attributeList)
			{
				if (!attributeList.IsExpanded)
				{
					lock (_syncLock)
					{
						ExpandAttributes(type, attributeList);
						attributeList.IsExpanded = true;
					}
				}
			}
		}
		return attributeList;
	}

	private AttributeList GetTypeList(Type type)
	{
		TypeMetadata typeMetadata = GetTypeMetadata(type);
		if (typeMetadata.TypeAttributes == null)
		{
			typeMetadata.TypeAttributes = new AttributeList();
		}
		return typeMetadata.TypeAttributes;
	}

	private TypeMetadata GetTypeMetadata(Type type)
	{
		if (!_metadata.TryGetValue(type, out var value))
		{
			value = new TypeMetadata();
			_metadata.Add(type, value);
		}
		return value;
	}

	public void ValidateTable()
	{
		List<string> list = null;
		foreach (KeyValuePair<Type, TypeMetadata> item in _metadata)
		{
			GetCustomAttributes(item.Key);
			if (item.Value.MemberAttributes == null)
			{
				continue;
			}
			foreach (KeyValuePair<string, AttributeList> memberAttribute in item.Value.MemberAttributes)
			{
				GetCustomAttributes(item.Key, memberAttribute.Key);
				MemberInfo[] member = item.Key.GetMember(memberAttribute.Key, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetProperty);
				string text = null;
				if (member == null || member.Length == 0)
				{
					text = string.Format(CultureInfo.CurrentCulture, Resources.Error_ValidationNoMatchingMember, new object[2]
					{
						memberAttribute.Key,
						item.Key.FullName
					});
				}
				if (text != null)
				{
					if (list == null)
					{
						list = new List<string>();
					}
					list.Add(text);
				}
			}
		}
		if (list != null)
		{
			throw new AttributeTableValidationException(Resources.Error_TableValidationFailed, list);
		}
	}
}
