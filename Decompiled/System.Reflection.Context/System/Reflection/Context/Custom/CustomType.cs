using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Context.Projection;
using System.Reflection.Context.Virtual;

namespace System.Reflection.Context.Custom;

internal sealed class CustomType : ProjectingType
{
	private IEnumerable<PropertyInfo> _newProperties;

	public CustomReflectionContext ReflectionContext { get; }

	private IEnumerable<PropertyInfo> NewProperties => _newProperties ?? (_newProperties = ReflectionContext.GetNewPropertiesForType(this));

	public CustomType(Type template, CustomReflectionContext context)
		: base(template, context.Projector)
	{
		ReflectionContext = context;
	}

	public override object[] GetCustomAttributes(bool inherit)
	{
		return GetCustomAttributes(typeof(object), inherit);
	}

	public override object[] GetCustomAttributes(Type attributeType, bool inherit)
	{
		return AttributeUtils.GetCustomAttributes(ReflectionContext, this, attributeType, inherit);
	}

	public override bool IsDefined(Type attributeType, bool inherit)
	{
		return AttributeUtils.IsDefined(this, attributeType, inherit);
	}

	public override bool IsInstanceOfType([NotNullWhen(true)] object o)
	{
		Type typeForObject = ReflectionContext.GetTypeForObject(o);
		return IsAssignableFrom(typeForObject);
	}

	public override PropertyInfo[] GetProperties(BindingFlags bindingAttr)
	{
		PropertyInfo[] properties = base.GetProperties(bindingAttr);
		bool flag = (bindingAttr & BindingFlags.DeclaredOnly) == BindingFlags.DeclaredOnly;
		bool flag2 = (bindingAttr & BindingFlags.Instance) == BindingFlags.Instance;
		if ((bindingAttr & BindingFlags.Public) != BindingFlags.Public || !flag2)
		{
			return properties;
		}
		List<PropertyInfo> list = new List<PropertyInfo>(properties);
		list.AddRange(NewProperties);
		if (!flag)
		{
			CustomType customType = BaseType as CustomType;
			while (customType != null)
			{
				IEnumerable<PropertyInfo> newProperties = customType.NewProperties;
				foreach (PropertyInfo item in newProperties)
				{
					list.Add(new InheritedPropertyInfo(item, this));
				}
				customType = customType.BaseType as CustomType;
			}
		}
		return list.ToArray();
	}

	protected override PropertyInfo GetPropertyImpl(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
	{
		PropertyInfo propertyImpl = base.GetPropertyImpl(name, bindingAttr, binder, returnType, types, modifiers);
		bool flag = (bindingAttr & BindingFlags.IgnoreCase) == BindingFlags.IgnoreCase;
		bool flag2 = (bindingAttr & BindingFlags.DeclaredOnly) == BindingFlags.DeclaredOnly;
		bool flag3 = (bindingAttr & BindingFlags.Instance) == BindingFlags.Instance;
		if ((bindingAttr & BindingFlags.Public) != BindingFlags.Public || !flag3)
		{
			return propertyImpl;
		}
		if (types != null && types.Length != 0)
		{
			return propertyImpl;
		}
		List<PropertyInfo> list = new List<PropertyInfo>();
		if (propertyImpl != null)
		{
			list.Add(propertyImpl);
		}
		StringComparison comparisonType = (flag ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
		CustomType customType = this;
		foreach (PropertyInfo newProperty in customType.NewProperties)
		{
			if (string.Equals(newProperty.Name, name, comparisonType))
			{
				list.Add(newProperty);
			}
		}
		if (!flag2)
		{
			while ((customType = customType.BaseType as CustomType) != null)
			{
				foreach (PropertyInfo newProperty2 in customType.NewProperties)
				{
					if (string.Equals(newProperty2.Name, name, comparisonType))
					{
						list.Add(new InheritedPropertyInfo(newProperty2, this));
					}
				}
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		if (binder == null)
		{
			binder = Type.DefaultBinder;
		}
		return binder.SelectProperty(bindingAttr, list.ToArray(), returnType, types, modifiers);
	}

	public override MethodInfo[] GetMethods(BindingFlags bindingAttr)
	{
		MethodInfo[] methods = base.GetMethods(bindingAttr);
		bool flag = (bindingAttr & BindingFlags.DeclaredOnly) == BindingFlags.DeclaredOnly;
		bool flag2 = (bindingAttr & BindingFlags.Instance) == BindingFlags.Instance;
		if ((bindingAttr & BindingFlags.Public) != BindingFlags.Public || !flag2)
		{
			return methods;
		}
		List<MethodInfo> list = new List<MethodInfo>(methods);
		foreach (PropertyInfo newProperty in NewProperties)
		{
			list.AddRange(newProperty.GetAccessors());
		}
		if (!flag)
		{
			CustomType customType = BaseType as CustomType;
			while (customType != null)
			{
				foreach (PropertyInfo newProperty2 in customType.NewProperties)
				{
					PropertyInfo propertyInfo = new InheritedPropertyInfo(newProperty2, this);
					list.AddRange(propertyInfo.GetAccessors());
				}
				customType = customType.BaseType as CustomType;
			}
		}
		return list.ToArray();
	}

	protected override MethodInfo GetMethodImpl(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
	{
		MethodInfo methodImpl = base.GetMethodImpl(name, bindingAttr, binder, callConvention, types, modifiers);
		bool flag = (bindingAttr & BindingFlags.IgnoreCase) == BindingFlags.IgnoreCase;
		bool flag2 = (bindingAttr & BindingFlags.DeclaredOnly) == BindingFlags.DeclaredOnly;
		bool flag3 = (bindingAttr & BindingFlags.Instance) == BindingFlags.Instance;
		if ((bindingAttr & BindingFlags.Public) != BindingFlags.Public || !flag3)
		{
			return methodImpl;
		}
		bool flag4 = false;
		bool flag5 = false;
		StringComparison comparisonType = (flag ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
		if (name.Length > 4)
		{
			flag4 = (types == null || types.Length == 0) && name.StartsWith("get_", comparisonType);
			if (!flag4)
			{
				flag5 = (types == null || types.Length == 1) && name.StartsWith("set_", comparisonType);
			}
		}
		if (!flag4 && !flag5)
		{
			return methodImpl;
		}
		string b = name.Substring(4);
		List<MethodInfo> list = new List<MethodInfo>();
		if (methodImpl != null)
		{
			list.Add(methodImpl);
		}
		foreach (PropertyInfo newProperty in NewProperties)
		{
			if (string.Equals(newProperty.Name, b, comparisonType))
			{
				MethodInfo methodInfo = (flag4 ? newProperty.GetGetMethod() : newProperty.GetSetMethod());
				if (methodInfo != null)
				{
					list.Add(methodInfo);
				}
			}
		}
		if (!flag2)
		{
			CustomType customType = BaseType as CustomType;
			while (customType != null)
			{
				foreach (PropertyInfo newProperty2 in customType.NewProperties)
				{
					if (string.Equals(newProperty2.Name, b, comparisonType))
					{
						PropertyInfo propertyInfo = new InheritedPropertyInfo(newProperty2, this);
						MethodInfo methodInfo2 = (flag4 ? propertyInfo.GetGetMethod() : propertyInfo.GetSetMethod());
						if (methodInfo2 != null)
						{
							list.Add(methodInfo2);
						}
					}
				}
				customType = customType.BaseType as CustomType;
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		if (types == null || flag4)
		{
			MethodInfo methodInfo3 = list[0];
			if (list.Count == 1)
			{
				return methodInfo3;
			}
			Type declaringType = methodInfo3.DeclaringType;
			throw new AmbiguousMatchException(System.SR.Format(System.SR.Arg_AmbiguousMatchException_MemberInfo, declaringType, methodInfo3));
		}
		if (binder == null)
		{
			binder = Type.DefaultBinder;
		}
		Binder binder2 = binder;
		MethodBase[] match = list.ToArray();
		return (MethodInfo)binder2.SelectMethod(bindingAttr, match, types, modifiers);
	}
}
