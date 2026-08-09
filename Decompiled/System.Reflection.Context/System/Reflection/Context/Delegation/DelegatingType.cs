using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Reflection.Context.Delegation;

internal abstract class DelegatingType : TypeInfo
{
	private readonly TypeInfo _typeInfo;

	public override Assembly Assembly => _typeInfo.Assembly;

	public override string AssemblyQualifiedName => _typeInfo.AssemblyQualifiedName;

	public override Type BaseType => _typeInfo.BaseType;

	public override bool ContainsGenericParameters => _typeInfo.ContainsGenericParameters;

	public override int GenericParameterPosition => _typeInfo.GenericParameterPosition;

	public override MethodBase DeclaringMethod => _typeInfo.DeclaringMethod;

	public override Type DeclaringType => _typeInfo.DeclaringType;

	public override string FullName => _typeInfo.FullName;

	public override GenericParameterAttributes GenericParameterAttributes => _typeInfo.GenericParameterAttributes;

	public override Guid GUID => _typeInfo.GUID;

	public override bool IsEnum => _typeInfo.IsEnum;

	public override bool IsGenericParameter => _typeInfo.IsGenericParameter;

	public override bool IsGenericType => _typeInfo.IsGenericType;

	public override bool IsGenericTypeDefinition => _typeInfo.IsGenericTypeDefinition;

	public override bool IsSecurityCritical => _typeInfo.IsSecurityCritical;

	public override bool IsSecuritySafeCritical => _typeInfo.IsSecuritySafeCritical;

	public override bool IsSecurityTransparent => _typeInfo.IsSecurityTransparent;

	[Obsolete("Formatter-based serialization is obsolete and should not be used.", DiagnosticId = "SYSLIB0050", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	public override bool IsSerializable => _typeInfo.IsSerializable;

	public override int MetadataToken => _typeInfo.MetadataToken;

	public override Module Module => _typeInfo.Module;

	public override string Name => _typeInfo.Name;

	public override string Namespace => _typeInfo.Namespace;

	public override Type ReflectedType => _typeInfo.ReflectedType;

	public override StructLayoutAttribute StructLayoutAttribute => _typeInfo.StructLayoutAttribute;

	public override RuntimeTypeHandle TypeHandle => _typeInfo.TypeHandle;

	public override Type UnderlyingSystemType => _typeInfo.UnderlyingSystemType;

	public Type UnderlyingType => _typeInfo;

	internal object Delegate => UnderlyingType;

	public DelegatingType(Type type)
	{
		_typeInfo = type.GetTypeInfo();
		if (_typeInfo == null)
		{
			throw new InvalidOperationException(System.SR.Format(System.SR.InvalidOperation_NoTypeInfoForThisType, type.FullName));
		}
	}

	public override int GetArrayRank()
	{
		return _typeInfo.GetArrayRank();
	}

	public override MemberInfo[] GetDefaultMembers()
	{
		return _typeInfo.GetDefaultMembers();
	}

	public override string GetEnumName(object value)
	{
		return _typeInfo.GetEnumName(value);
	}

	public override string[] GetEnumNames()
	{
		return _typeInfo.GetEnumNames();
	}

	public override Array GetEnumValues()
	{
		return _typeInfo.GetEnumValues();
	}

	public override Type GetEnumUnderlyingType()
	{
		return _typeInfo.GetEnumUnderlyingType();
	}

	public override object[] GetCustomAttributes(Type attributeType, bool inherit)
	{
		return _typeInfo.GetCustomAttributes(attributeType, inherit);
	}

	public override object[] GetCustomAttributes(bool inherit)
	{
		return _typeInfo.GetCustomAttributes(inherit);
	}

	public override IList<CustomAttributeData> GetCustomAttributesData()
	{
		return _typeInfo.GetCustomAttributesData();
	}

	public override EventInfo[] GetEvents()
	{
		return _typeInfo.GetEvents();
	}

	public override Type[] GetGenericArguments()
	{
		return _typeInfo.GetGenericArguments();
	}

	public override Type[] GetGenericParameterConstraints()
	{
		return _typeInfo.GetGenericParameterConstraints();
	}

	public override Type GetGenericTypeDefinition()
	{
		return _typeInfo.GetGenericTypeDefinition();
	}

	public override InterfaceMapping GetInterfaceMap(Type interfaceType)
	{
		return _typeInfo.GetInterfaceMap(interfaceType);
	}

	public override MemberInfo[] GetMember(string name, MemberTypes type, BindingFlags bindingAttr)
	{
		return _typeInfo.GetMember(name, type, bindingAttr);
	}

	protected override TypeCode GetTypeCodeImpl()
	{
		return Type.GetTypeCode(_typeInfo);
	}

	public override bool IsAssignableFrom([NotNullWhen(true)] Type c)
	{
		return _typeInfo.IsAssignableFrom(c);
	}

	protected override bool IsContextfulImpl()
	{
		return _typeInfo.IsContextful;
	}

	public override bool IsDefined(Type attributeType, bool inherit)
	{
		return _typeInfo.IsDefined(attributeType, inherit);
	}

	public override bool IsEnumDefined(object value)
	{
		return _typeInfo.IsEnumDefined(value);
	}

	public override bool IsEquivalentTo([NotNullWhen(true)] Type other)
	{
		return _typeInfo.IsEquivalentTo(other);
	}

	public override bool IsInstanceOfType([NotNullWhen(true)] object o)
	{
		return _typeInfo.IsInstanceOfType(o);
	}

	protected override bool IsMarshalByRefImpl()
	{
		return _typeInfo.IsMarshalByRef;
	}

	public override bool IsSubclassOf(Type c)
	{
		return _typeInfo.IsSubclassOf(c);
	}

	protected override bool IsValueTypeImpl()
	{
		return _typeInfo.IsValueType;
	}

	protected override TypeAttributes GetAttributeFlagsImpl()
	{
		return _typeInfo.Attributes;
	}

	protected override ConstructorInfo GetConstructorImpl(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
	{
		return _typeInfo.GetConstructor(bindingAttr, binder, callConvention, types, modifiers);
	}

	public override ConstructorInfo[] GetConstructors(BindingFlags bindingAttr)
	{
		return _typeInfo.GetConstructors(bindingAttr);
	}

	public override Type GetElementType()
	{
		return _typeInfo.GetElementType();
	}

	public override EventInfo GetEvent(string name, BindingFlags bindingAttr)
	{
		return _typeInfo.GetEvent(name, bindingAttr);
	}

	public override EventInfo[] GetEvents(BindingFlags bindingAttr)
	{
		return _typeInfo.GetEvents(bindingAttr);
	}

	public override FieldInfo GetField(string name, BindingFlags bindingAttr)
	{
		return _typeInfo.GetField(name, bindingAttr);
	}

	public override FieldInfo[] GetFields(BindingFlags bindingAttr)
	{
		return _typeInfo.GetFields(bindingAttr);
	}

	public override Type GetInterface(string name, bool ignoreCase)
	{
		return _typeInfo.GetInterface(name, ignoreCase);
	}

	public override Type[] GetInterfaces()
	{
		return _typeInfo.GetInterfaces();
	}

	public override MemberInfo[] GetMembers(BindingFlags bindingAttr)
	{
		return _typeInfo.GetMembers(bindingAttr);
	}

	protected override MethodInfo GetMethodImpl(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
	{
		if (types != null)
		{
			return _typeInfo.GetMethod(name, bindingAttr, binder, callConvention, types, modifiers);
		}
		return _typeInfo.GetMethod(name, bindingAttr);
	}

	public override MethodInfo[] GetMethods(BindingFlags bindingAttr)
	{
		return _typeInfo.GetMethods(bindingAttr);
	}

	public override Type GetNestedType(string name, BindingFlags bindingAttr)
	{
		return _typeInfo.GetNestedType(name, bindingAttr);
	}

	public override Type[] GetNestedTypes(BindingFlags bindingAttr)
	{
		return _typeInfo.GetNestedTypes(bindingAttr);
	}

	public override PropertyInfo[] GetProperties(BindingFlags bindingAttr)
	{
		return _typeInfo.GetProperties(bindingAttr);
	}

	protected override PropertyInfo GetPropertyImpl(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
	{
		if (types == null)
		{
			if (returnType == null)
			{
				return _typeInfo.GetProperty(name, bindingAttr);
			}
			return _typeInfo.GetProperty(name, returnType);
		}
		return _typeInfo.GetProperty(name, bindingAttr, binder, returnType, types, modifiers);
	}

	protected override bool HasElementTypeImpl()
	{
		return _typeInfo.HasElementType;
	}

	public override object InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, CultureInfo culture, string[] namedParameters)
	{
		return _typeInfo.InvokeMember(name, invokeAttr, binder, target, args, modifiers, culture, namedParameters);
	}

	protected override bool IsArrayImpl()
	{
		return _typeInfo.IsArray;
	}

	protected override bool IsByRefImpl()
	{
		return _typeInfo.IsByRef;
	}

	protected override bool IsCOMObjectImpl()
	{
		return _typeInfo.IsCOMObject;
	}

	protected override bool IsPointerImpl()
	{
		return _typeInfo.IsPointer;
	}

	protected override bool IsPrimitiveImpl()
	{
		return _typeInfo.IsPrimitive;
	}

	public override Type MakeArrayType()
	{
		return _typeInfo.MakeArrayType();
	}

	public override Type MakeArrayType(int rank)
	{
		return _typeInfo.MakeArrayType(rank);
	}

	public override Type MakePointerType()
	{
		return _typeInfo.MakePointerType();
	}

	[RequiresUnreferencedCode("If some of the generic arguments are annotated (either with DynamicallyAccessedMembersAttribute, or generic constraints), trimming can't validate that the requirements of those annotations are met.")]
	public override Type MakeGenericType(params Type[] typeArguments)
	{
		return _typeInfo.MakeGenericType(typeArguments);
	}

	public override Type MakeByRefType()
	{
		return _typeInfo.MakeByRefType();
	}

	public override string ToString()
	{
		return _typeInfo.ToString();
	}
}
