using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Serialization;

namespace Newtonsoft.Json.Utilities;

[Newtonsoft_002EJson_002ENullableContext(1)]
[Newtonsoft_002EJson_002ENullable(0)]
internal class LateBoundReflectionDelegateFactory : ReflectionDelegateFactory
{
	private static readonly LateBoundReflectionDelegateFactory _instance = new LateBoundReflectionDelegateFactory();

	internal static ReflectionDelegateFactory Instance => _instance;

	public override ObjectConstructor<object> CreateParameterizedConstructor(MethodBase method)
	{
		ValidationUtils.ArgumentNotNull(method, "method");
		ConstructorInfo c = method as ConstructorInfo;
		if ((object)c != null)
		{
			return ([Newtonsoft_002EJson_002ENullable(new byte[] { 1, 2 })] object[] a) => c.Invoke(a);
		}
		return ([Newtonsoft_002EJson_002ENullable(new byte[] { 1, 2 })] object[] a) => method.Invoke(null, a);
	}

	[return: Newtonsoft_002EJson_002ENullable(new byte[] { 1, 1, 2 })]
	public override MethodCall<T, object> CreateMethodCall<[Newtonsoft_002EJson_002ENullable(2)] T>(MethodBase method)
	{
		ValidationUtils.ArgumentNotNull(method, "method");
		ConstructorInfo c = method as ConstructorInfo;
		if ((object)c != null)
		{
			return [Newtonsoft_002EJson_002ENullableContext(0)] [return: Newtonsoft_002EJson_002ENullable(2)] (T o, [Newtonsoft_002EJson_002ENullable(new byte[] { 1, 2 })] object[] a) => c.Invoke(a);
		}
		return [Newtonsoft_002EJson_002ENullableContext(0)] [return: Newtonsoft_002EJson_002ENullable(2)] (T o, [Newtonsoft_002EJson_002ENullable(new byte[] { 1, 2 })] object[] a) => method.Invoke(o, a);
	}

	public override Func<T> CreateDefaultConstructor<[Newtonsoft_002EJson_002ENullable(2)] T>(Type type)
	{
		ValidationUtils.ArgumentNotNull(type, "type");
		if (type.IsValueType())
		{
			return [Newtonsoft_002EJson_002ENullableContext(0)] () => (T)Activator.CreateInstance(type);
		}
		ConstructorInfo constructorInfo = ReflectionUtils.GetDefaultConstructor(type, nonPublic: true);
		if (constructorInfo == null)
		{
			throw new InvalidOperationException("Unable to find default constructor for " + type.FullName);
		}
		return [Newtonsoft_002EJson_002ENullableContext(0)] () => (T)constructorInfo.Invoke(null);
	}

	[return: Newtonsoft_002EJson_002ENullable(new byte[] { 1, 1, 2 })]
	public override Func<T, object> CreateGet<[Newtonsoft_002EJson_002ENullable(2)] T>(PropertyInfo propertyInfo)
	{
		ValidationUtils.ArgumentNotNull(propertyInfo, "propertyInfo");
		return [Newtonsoft_002EJson_002ENullableContext(0)] [return: Newtonsoft_002EJson_002ENullable(2)] (T o) => propertyInfo.GetValue(o, null);
	}

	[return: Newtonsoft_002EJson_002ENullable(new byte[] { 1, 1, 2 })]
	public override Func<T, object> CreateGet<[Newtonsoft_002EJson_002ENullable(2)] T>(FieldInfo fieldInfo)
	{
		ValidationUtils.ArgumentNotNull(fieldInfo, "fieldInfo");
		return [Newtonsoft_002EJson_002ENullableContext(0)] [return: Newtonsoft_002EJson_002ENullable(2)] (T o) => fieldInfo.GetValue(o);
	}

	[return: Newtonsoft_002EJson_002ENullable(new byte[] { 1, 1, 2 })]
	public override Action<T, object> CreateSet<[Newtonsoft_002EJson_002ENullable(2)] T>(FieldInfo fieldInfo)
	{
		ValidationUtils.ArgumentNotNull(fieldInfo, "fieldInfo");
		return [Newtonsoft_002EJson_002ENullableContext(0)] (T o, [Newtonsoft_002EJson_002ENullable(2)] object v) =>
		{
			fieldInfo.SetValue(o, v);
		};
	}

	[return: Newtonsoft_002EJson_002ENullable(new byte[] { 1, 1, 2 })]
	public override Action<T, object> CreateSet<[Newtonsoft_002EJson_002ENullable(2)] T>(PropertyInfo propertyInfo)
	{
		ValidationUtils.ArgumentNotNull(propertyInfo, "propertyInfo");
		return [Newtonsoft_002EJson_002ENullableContext(0)] (T o, [Newtonsoft_002EJson_002ENullable(2)] object v) =>
		{
			propertyInfo.SetValue(o, v, null);
		};
	}
}
