using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using Xbim.Common;
using Xbim.Common.Metadata;
using Xbim.IO.Xml.BsConf;

namespace Xbim.IO.Xml;

internal class XmlMetaProperty
{
	public bool IsAttributeValue => AttributeSetter != null;

	public XmlAttributeSetter AttributeSetter { get; private set; }

	public ExpressMetaProperty MetaProperty { get; private set; }

	public string Name => MetaProperty.PropertyInfo.Name;

	public XmlMetaProperty(ExpressMetaProperty metaProperty)
	{
		MetaProperty = metaProperty;
	}

	public static List<XmlMetaProperty> GetProperties(ExpressType expressType, configuration configuration)
	{
		List<entity> typeConfs = configuration.GetEntities(expressType).ToList();
		List<ExpressMetaProperty> list;
		if (typeConfs.Any())
		{
			list = (from p in expressType.Properties.Values
				where !p.EntityAttribute.IsDerived
				where typeConfs.All((entity conf) => conf.IgnoredAttributes.All((attribute ia) => string.Compare(ia.@select, p.PropertyInfo.Name, StringComparison.OrdinalIgnoreCase) != 0))
				select p).ToList();
			IEnumerable<ExpressMetaProperty> collection = expressType.Inverses.Where((ExpressMetaProperty i) => typeConfs.Any((entity conf) => conf.ChangedInverses.Any((inverse ci) => string.Compare(ci.select, i.PropertyInfo.Name, StringComparison.OrdinalIgnoreCase) == 0)));
			list.AddRange(collection);
		}
		else
		{
			list = expressType.Properties.Values.Where((ExpressMetaProperty p) => !p.EntityAttribute.IsDerived).ToList();
		}
		List<XmlMetaProperty> list2 = list.Select((ExpressMetaProperty p) => new XmlMetaProperty(p)).ToList();
		foreach (XmlMetaProperty item in list2)
		{
			SetAttributeValueHandler(item, typeConfs);
		}
		IEnumerable<XmlMetaProperty> first = list2.Where((XmlMetaProperty p) => p.IsAttributeValue);
		IOrderedEnumerable<XmlMetaProperty> second = from p in list2
			where !p.IsAttributeValue
			orderby p.MetaProperty.EntityAttribute.GlobalOrder
			select p;
		return first.Concat(second).ToList();
	}

	public static Type GetNonNullableType(Type type)
	{
		if (!type.GetTypeInfo().IsValueType)
		{
			return type;
		}
		if (!type.GetTypeInfo().IsGenericType)
		{
			return type;
		}
		if (type.GetGenericTypeDefinition() != typeof(Nullable<>))
		{
			return type;
		}
		return type.GetTypeInfo().GetGenericArguments()[0];
	}

	private static void SetAttributeValueHandler(XmlMetaProperty metaProperty, List<entity> typeConfigurarions)
	{
		Type type2 = metaProperty.MetaProperty.PropertyInfo.PropertyType;
		type2 = GetNonNullableType(type2);
		string propName = metaProperty.MetaProperty.PropertyInfo.Name;
		if (type2.GetTypeInfo().IsValueType || type2 == typeof(string))
		{
			if (typeof(IExpressComplexType).GetTypeInfo().IsAssignableFrom(type2))
			{
				metaProperty.AttributeSetter = delegate(object value, XmlWriter writer)
				{
					if (value != null)
					{
						writer.WriteAttributeString(propName, string.Join(" ", ((IExpressComplexType)value).Properties));
					}
				};
				return;
			}
			if (type2.GetTypeInfo().IsEnum)
			{
				metaProperty.AttributeSetter = delegate(object value, XmlWriter writer)
				{
					if (value != null)
					{
						writer.WriteAttributeString(propName, (Enum.GetName(type2, value) ?? "").ToLowerInvariant());
					}
				};
				return;
			}
			metaProperty.AttributeSetter = delegate(object value, XmlWriter writer)
			{
				if (value != null)
				{
					writer.WriteAttributeString(propName, value.ToString());
				}
			};
		}
		else
		{
			if (!typeof(IEnumerable).GetTypeInfo().IsAssignableFrom(type2) || !type2.GetTypeInfo().IsGenericType)
			{
				return;
			}
			Type type3 = type2.GetTypeInfo().GetGenericArguments()[0];
			if (type3.GetTypeInfo().IsValueType || type3 == typeof(string))
			{
				if (IsStringCompatible(type3))
				{
					if (typeConfigurarions == null || !typeConfigurarions.Any((entity conf) => conf.TaggLessAttributes.Any((attribute a) => a.select == propName)))
					{
						return;
					}
					metaProperty.AttributeSetter = delegate(object value, XmlWriter writer)
					{
						if (value != null)
						{
							writer.WriteAttributeString(propName, string.Join(" ", ((IEnumerable)value).Cast<object>()));
						}
					};
					return;
				}
				metaProperty.AttributeSetter = delegate(object value, XmlWriter writer)
				{
					if (value != null)
					{
						writer.WriteAttributeString(propName, string.Join(" ", ((IEnumerable)value).Cast<object>()));
					}
				};
			}
			else
			{
				if (!typeof(IEnumerable).GetTypeInfo().IsAssignableFrom(type3) || typeConfigurarions == null || !typeConfigurarions.Any((entity conf) => conf.TaggLessAttributes.Any((attribute a) => a.select == propName)))
				{
					return;
				}
				metaProperty.AttributeSetter = delegate(object value, XmlWriter writer)
				{
					if (value != null)
					{
						IEnumerable<object> values = ((IEnumerable)value).Cast<IEnumerable>().SelectMany((IEnumerable o) => o.Cast<object>());
						writer.WriteAttributeString(propName, string.Join(" ", values));
					}
				};
			}
		}
	}

	public static bool IsStringCompatible(Type type)
	{
		if (type == typeof(string))
		{
			return true;
		}
		if (type.GetTypeInfo().GetCustomAttributes(typeof(DefinedTypeAttribute), inherit: false).FirstOrDefault() is DefinedTypeAttribute definedTypeAttribute && definedTypeAttribute.UnderlyingType == typeof(string))
		{
			return true;
		}
		return false;
	}
}
