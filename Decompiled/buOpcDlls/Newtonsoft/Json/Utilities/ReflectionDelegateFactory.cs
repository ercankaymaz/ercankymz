using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Serialization;

namespace Newtonsoft.Json.Utilities;

[Newtonsoft_002EJson_002ENullableContext(1)]
[Newtonsoft_002EJson_002ENullable(0)]
internal abstract class ReflectionDelegateFactory
{
	[return: Newtonsoft_002EJson_002ENullable(new byte[] { 1, 1, 2 })]
	public Func<T, object> CreateGet<[Newtonsoft_002EJson_002ENullable(2)] T>(MemberInfo memberInfo)
	{
		if (memberInfo is PropertyInfo propertyInfo)
		{
			if (propertyInfo.PropertyType.IsByRef)
			{
				throw new InvalidOperationException("Could not create getter for {0}. ByRef return values are not supported.".FormatWith(CultureInfo.InvariantCulture, propertyInfo));
			}
			return CreateGet<T>(propertyInfo);
		}
		if (memberInfo is FieldInfo fieldInfo)
		{
			return CreateGet<T>(fieldInfo);
		}
		throw new Exception("Could not create getter for {0}.".FormatWith(CultureInfo.InvariantCulture, memberInfo));
	}

	[return: Newtonsoft_002EJson_002ENullable(new byte[] { 1, 1, 2 })]
	public Action<T, object> CreateSet<[Newtonsoft_002EJson_002ENullable(2)] T>(MemberInfo memberInfo)
	{
		if (memberInfo is PropertyInfo propertyInfo)
		{
			return CreateSet<T>(propertyInfo);
		}
		if (memberInfo is FieldInfo fieldInfo)
		{
			return CreateSet<T>(fieldInfo);
		}
		throw new Exception("Could not create setter for {0}.".FormatWith(CultureInfo.InvariantCulture, memberInfo));
	}

	[return: Newtonsoft_002EJson_002ENullable(new byte[] { 1, 1, 2 })]
	public abstract MethodCall<T, object> CreateMethodCall<[Newtonsoft_002EJson_002ENullable(2)] T>(MethodBase method);

	public abstract ObjectConstructor<object> CreateParameterizedConstructor(MethodBase method);

	public abstract Func<T> CreateDefaultConstructor<[Newtonsoft_002EJson_002ENullable(2)] T>(Type type);

	[return: Newtonsoft_002EJson_002ENullable(new byte[] { 1, 1, 2 })]
	public abstract Func<T, object> CreateGet<[Newtonsoft_002EJson_002ENullable(2)] T>(PropertyInfo propertyInfo);

	[return: Newtonsoft_002EJson_002ENullable(new byte[] { 1, 1, 2 })]
	public abstract Func<T, object> CreateGet<[Newtonsoft_002EJson_002ENullable(2)] T>(FieldInfo fieldInfo);

	[return: Newtonsoft_002EJson_002ENullable(new byte[] { 1, 1, 2 })]
	public abstract Action<T, object> CreateSet<[Newtonsoft_002EJson_002ENullable(2)] T>(FieldInfo fieldInfo);

	[return: Newtonsoft_002EJson_002ENullable(new byte[] { 1, 1, 2 })]
	public abstract Action<T, object> CreateSet<[Newtonsoft_002EJson_002ENullable(2)] T>(PropertyInfo propertyInfo);
}
