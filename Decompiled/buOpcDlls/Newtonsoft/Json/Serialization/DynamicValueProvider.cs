using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Serialization;

[Newtonsoft_002EJson_002ENullableContext(1)]
[Newtonsoft_002EJson_002ENullable(0)]
public class DynamicValueProvider : IValueProvider
{
	private readonly MemberInfo _memberInfo;

	[Newtonsoft_002EJson_002ENullable(new byte[] { 2, 1, 2 })]
	private Func<object, object> _getter;

	[Newtonsoft_002EJson_002ENullable(new byte[] { 2, 1, 2 })]
	private Action<object, object> _setter;

	public DynamicValueProvider(MemberInfo memberInfo)
	{
		ValidationUtils.ArgumentNotNull(memberInfo, "memberInfo");
		_memberInfo = memberInfo;
	}

	public void SetValue(object target, [Newtonsoft_002EJson_002ENullable(2)] object value)
	{
		try
		{
			if (_setter == null)
			{
				_setter = DynamicReflectionDelegateFactory.Instance.CreateSet<object>(_memberInfo);
			}
			_setter(target, value);
		}
		catch (Exception innerException)
		{
			throw new JsonSerializationException("Error setting value to '{0}' on '{1}'.".FormatWith(CultureInfo.InvariantCulture, _memberInfo.Name, target.GetType()), innerException);
		}
	}

	[return: Newtonsoft_002EJson_002ENullable(2)]
	public object GetValue(object target)
	{
		try
		{
			if (_getter == null)
			{
				_getter = DynamicReflectionDelegateFactory.Instance.CreateGet<object>(_memberInfo);
			}
			return _getter(target);
		}
		catch (Exception innerException)
		{
			throw new JsonSerializationException("Error getting value from '{0}' on '{1}'.".FormatWith(CultureInfo.InvariantCulture, _memberInfo.Name, target.GetType()), innerException);
		}
	}
}
