using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Utilities;

[Newtonsoft_002EJson_002ENullableContext(1)]
[Newtonsoft_002EJson_002ENullable(0)]
internal class DynamicProxy<[Newtonsoft_002EJson_002ENullable(2)] T>
{
	public virtual IEnumerable<string> GetDynamicMemberNames(T instance)
	{
		return CollectionUtils.ArrayEmpty<string>();
	}

	public virtual bool TryBinaryOperation(T instance, BinaryOperationBinder binder, object arg, [Newtonsoft_002EJson_002ENullable(2)] out object result)
	{
		result = null;
		return false;
	}

	public virtual bool TryConvert(T instance, ConvertBinder binder, [Newtonsoft_002EJson_002ENullable(2)] out object result)
	{
		result = null;
		return false;
	}

	public virtual bool TryCreateInstance(T instance, CreateInstanceBinder binder, object[] args, [Newtonsoft_002EJson_002ENullable(2)] out object result)
	{
		result = null;
		return false;
	}

	public virtual bool TryDeleteIndex(T instance, DeleteIndexBinder binder, object[] indexes)
	{
		return false;
	}

	public virtual bool TryDeleteMember(T instance, DeleteMemberBinder binder)
	{
		return false;
	}

	public virtual bool TryGetIndex(T instance, GetIndexBinder binder, object[] indexes, [Newtonsoft_002EJson_002ENullable(2)] out object result)
	{
		result = null;
		return false;
	}

	public virtual bool TryGetMember(T instance, GetMemberBinder binder, [Newtonsoft_002EJson_002ENullable(2)] out object result)
	{
		result = null;
		return false;
	}

	public virtual bool TryInvoke(T instance, InvokeBinder binder, object[] args, [Newtonsoft_002EJson_002ENullable(2)] out object result)
	{
		result = null;
		return false;
	}

	public virtual bool TryInvokeMember(T instance, InvokeMemberBinder binder, object[] args, [Newtonsoft_002EJson_002ENullable(2)] out object result)
	{
		result = null;
		return false;
	}

	public virtual bool TrySetIndex(T instance, SetIndexBinder binder, object[] indexes, object value)
	{
		return false;
	}

	public virtual bool TrySetMember(T instance, SetMemberBinder binder, object value)
	{
		return false;
	}

	public virtual bool TryUnaryOperation(T instance, UnaryOperationBinder binder, [Newtonsoft_002EJson_002ENullable(2)] out object result)
	{
		result = null;
		return false;
	}
}
