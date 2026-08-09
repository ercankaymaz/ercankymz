using System.Collections.Generic;

namespace System.Reflection.Context.Custom;

internal static class AttributeUtils
{
	public static object[] GetCustomAttributes(CustomReflectionContext context, CustomType type, Type attributeFilterType, bool inherit)
	{
		IEnumerable<object> filteredAttributes = GetFilteredAttributes(context, type.UnderlyingType, attributeFilterType);
		if (!inherit)
		{
			return CollectionServices.IEnumerableToArray(filteredAttributes, attributeFilterType);
		}
		CustomType customType = type.BaseType as CustomType;
		if (customType == null)
		{
			return CollectionServices.IEnumerableToArray(filteredAttributes, attributeFilterType);
		}
		bool isSealed = attributeFilterType.IsSealed;
		GetAttributeUsage(attributeFilterType, out var inherited, out var allowMultiple);
		if (isSealed && !inherited)
		{
			return CollectionServices.IEnumerableToArray(filteredAttributes, attributeFilterType);
		}
		List<object> list = new List<object>(filteredAttributes);
		while (!isSealed || list.Count <= 0 || allowMultiple)
		{
			type = customType;
			IEnumerable<object> filteredAttributes2 = GetFilteredAttributes(context, type.UnderlyingType, attributeFilterType);
			CombineCustomAttributes(list, filteredAttributes2, attributeFilterType, inherited, allowMultiple);
			customType = type.BaseType as CustomType;
			if (!(customType != null))
			{
				break;
			}
		}
		return CollectionServices.ConvertListToArray(list, attributeFilterType);
	}

	public static object[] GetCustomAttributes(CustomReflectionContext context, CustomMethodInfo method, Type attributeFilterType, bool inherit)
	{
		IEnumerable<object> filteredAttributes = GetFilteredAttributes(context, method.UnderlyingMethod, attributeFilterType);
		if (!inherit)
		{
			return CollectionServices.IEnumerableToArray(filteredAttributes, attributeFilterType);
		}
		CustomMethodInfo customMethodInfo = method.GetBaseDefinition() as CustomMethodInfo;
		if (customMethodInfo == null || customMethodInfo.Equals(method))
		{
			return CollectionServices.IEnumerableToArray(filteredAttributes, attributeFilterType);
		}
		bool isSealed = attributeFilterType.IsSealed;
		GetAttributeUsage(attributeFilterType, out var inherited, out var allowMultiple);
		if (isSealed && !inherited)
		{
			return CollectionServices.IEnumerableToArray(filteredAttributes, attributeFilterType);
		}
		List<object> list = new List<object>(filteredAttributes);
		while (!isSealed || list.Count <= 0 || allowMultiple)
		{
			method = customMethodInfo;
			IEnumerable<object> filteredAttributes2 = GetFilteredAttributes(context, method.UnderlyingMethod, attributeFilterType);
			CombineCustomAttributes(list, filteredAttributes2, attributeFilterType, inherited, allowMultiple);
			customMethodInfo = method.GetBaseDefinition() as CustomMethodInfo;
			if (!(customMethodInfo != null) || customMethodInfo.Equals(method))
			{
				break;
			}
		}
		return CollectionServices.ConvertListToArray(list, attributeFilterType);
	}

	public static object[] GetCustomAttributes(CustomReflectionContext context, CustomConstructorInfo constructor, Type attributeFilterType)
	{
		ConstructorInfo underlyingConstructor = constructor.UnderlyingConstructor;
		IEnumerable<object> filteredAttributes = GetFilteredAttributes(context, underlyingConstructor, attributeFilterType);
		return CollectionServices.IEnumerableToArray(filteredAttributes, attributeFilterType);
	}

	public static object[] GetCustomAttributes(CustomReflectionContext context, CustomPropertyInfo property, Type attributeFilterType)
	{
		PropertyInfo underlyingProperty = property.UnderlyingProperty;
		IEnumerable<object> filteredAttributes = GetFilteredAttributes(context, underlyingProperty, attributeFilterType);
		return CollectionServices.IEnumerableToArray(filteredAttributes, attributeFilterType);
	}

	public static object[] GetCustomAttributes(CustomReflectionContext context, CustomEventInfo evnt, Type attributeFilterType)
	{
		EventInfo underlyingEvent = evnt.UnderlyingEvent;
		IEnumerable<object> filteredAttributes = GetFilteredAttributes(context, underlyingEvent, attributeFilterType);
		return CollectionServices.IEnumerableToArray(filteredAttributes, attributeFilterType);
	}

	public static object[] GetCustomAttributes(CustomReflectionContext context, CustomFieldInfo field, Type attributeFilterType)
	{
		FieldInfo underlyingField = field.UnderlyingField;
		IEnumerable<object> filteredAttributes = GetFilteredAttributes(context, underlyingField, attributeFilterType);
		return CollectionServices.IEnumerableToArray(filteredAttributes, attributeFilterType);
	}

	public static object[] GetCustomAttributes(CustomReflectionContext context, CustomParameterInfo parameter, Type attributeFilterType)
	{
		ParameterInfo underlyingParameter = parameter.UnderlyingParameter;
		IEnumerable<object> filteredAttributes = GetFilteredAttributes(context, underlyingParameter, attributeFilterType);
		return CollectionServices.IEnumerableToArray(filteredAttributes, attributeFilterType);
	}

	public static bool IsDefined(ICustomAttributeProvider provider, Type attributeType, bool inherit)
	{
		object[] customAttributes = provider.GetCustomAttributes(attributeType, inherit);
		if (customAttributes != null)
		{
			return customAttributes.Length != 0;
		}
		return false;
	}

	private static IEnumerable<object> GetFilteredAttributes(CustomReflectionContext context, MemberInfo member, Type attributeFilterType)
	{
		object[] customAttributes = member.GetCustomAttributes(attributeFilterType, inherit: false);
		return context.GetCustomAttributesOnMember(member, customAttributes, attributeFilterType);
	}

	private static IEnumerable<object> GetFilteredAttributes(CustomReflectionContext context, ParameterInfo parameter, Type attributeFilterType)
	{
		object[] customAttributes = parameter.GetCustomAttributes(attributeFilterType, inherit: false);
		return context.GetCustomAttributesOnParameter(parameter, customAttributes, attributeFilterType);
	}

	private static void CombineCustomAttributes(List<object> declaredAttributes, IEnumerable<object> inheritedAttributes, Type attributeFilterType, bool inherited, bool allowMultiple)
	{
		foreach (object inheritedAttribute in inheritedAttributes)
		{
			Type attributeType = inheritedAttribute.GetType();
			if (attributeType != attributeFilterType)
			{
				GetAttributeUsage(attributeType, out inherited, out allowMultiple);
			}
			if (inherited && (allowMultiple || declaredAttributes.FindIndex((object obj) => obj.GetType() == attributeType) < 0))
			{
				declaredAttributes.Add(inheritedAttribute);
			}
		}
	}

	private static void GetAttributeUsage(Type attributeFilterType, out bool inherited, out bool allowMultiple)
	{
		AttributeUsageAttribute[] array = (AttributeUsageAttribute[])attributeFilterType.GetCustomAttributes(typeof(AttributeUsageAttribute), inherit: false);
		if (array == null || array.Length == 0)
		{
			inherited = true;
			allowMultiple = false;
			return;
		}
		if (array.Length == 1)
		{
			AttributeUsageAttribute attributeUsageAttribute = array[0];
			inherited = attributeUsageAttribute.Inherited;
			allowMultiple = attributeUsageAttribute.AllowMultiple;
			return;
		}
		throw new FormatException(System.SR.Format(System.SR.Format_AttributeUsage, attributeFilterType));
	}

	internal static IEnumerable<object> FilterCustomAttributes(IEnumerable<object> attributes, Type attributeFilterType)
	{
		foreach (object attribute in attributes)
		{
			if (attribute == null)
			{
				throw new InvalidOperationException(System.SR.InvalidOperation_NullAttribute);
			}
			if (attributeFilterType.IsInstanceOfType(attribute))
			{
				yield return attribute;
			}
		}
	}
}
