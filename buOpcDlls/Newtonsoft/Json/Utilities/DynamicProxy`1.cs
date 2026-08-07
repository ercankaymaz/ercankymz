// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.DynamicProxy`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Utilities;

[NullableContext(1)]
[Nullable(0)]
internal class DynamicProxy<[Nullable(2)] T>
{
  public virtual IEnumerable<string> GetDynamicMemberNames(T instance)
  {
    return (IEnumerable<string>) CollectionUtils.ArrayEmpty<string>();
  }

  public virtual bool TryBinaryOperation(
    T instance,
    BinaryOperationBinder binder,
    object arg,
    [Nullable(2)] out object result)
  {
    result = (object) null;
    return false;
  }

  public virtual bool TryConvert(T instance, ConvertBinder binder, [Nullable(2)] out object result)
  {
    result = (object) null;
    return false;
  }

  public virtual bool TryCreateInstance(
    T instance,
    CreateInstanceBinder binder,
    object[] args,
    [Nullable(2)] out object result)
  {
    result = (object) null;
    return false;
  }

  public virtual bool TryDeleteIndex(T instance, DeleteIndexBinder binder, object[] indexes)
  {
    return false;
  }

  public virtual bool TryDeleteMember(T instance, DeleteMemberBinder binder) => false;

  public virtual bool TryGetIndex(
    T instance,
    GetIndexBinder binder,
    object[] indexes,
    [Nullable(2)] out object result)
  {
    result = (object) null;
    return false;
  }

  public virtual bool TryGetMember(T instance, GetMemberBinder binder, [Nullable(2)] out object result)
  {
    result = (object) null;
    return false;
  }

  public virtual bool TryInvoke(T instance, InvokeBinder binder, object[] args, [Nullable(2)] out object result)
  {
    result = (object) null;
    return false;
  }

  public virtual bool TryInvokeMember(
    T instance,
    InvokeMemberBinder binder,
    object[] args,
    [Nullable(2)] out object result)
  {
    result = (object) null;
    return false;
  }

  public virtual bool TrySetIndex(
    T instance,
    SetIndexBinder binder,
    object[] indexes,
    object value)
  {
    return false;
  }

  public virtual bool TrySetMember(T instance, SetMemberBinder binder, object value) => false;

  public virtual bool TryUnaryOperation(T instance, UnaryOperationBinder binder, [Nullable(2)] out object result)
  {
    result = (object) null;
    return false;
  }
}
