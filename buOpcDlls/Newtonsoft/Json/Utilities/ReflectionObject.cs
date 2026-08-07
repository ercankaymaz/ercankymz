// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.ReflectionObject
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Utilities;

[NullableContext(1)]
[Nullable(0)]
internal class ReflectionObject
{
  [field: Nullable(new byte[] {2, 1})]
  [Nullable(new byte[] {2, 1})]
  public ObjectConstructor<object> Creator { [return: Nullable(new byte[] {2, 1})] get; }

  public IDictionary<string, ReflectionMember> Members { get; }

  private ReflectionObject([Nullable(new byte[] {2, 1})] ObjectConstructor<object> creator)
  {
    this.Members = (IDictionary<string, ReflectionMember>) new Dictionary<string, ReflectionMember>();
    this.Creator = creator;
  }

  [return: Nullable(2)]
  public object GetValue(object target, string member) => this.Members[member].Getter(target);

  public void SetValue(object target, string member, [Nullable(2)] object value)
  {
    this.Members[member].Setter(target, value);
  }

  public Type GetType(string member) => this.Members[member].MemberType;

  public static ReflectionObject Create(Type t, params string[] memberNames)
  {
    return ReflectionObject.Create(t, (MethodBase) null, memberNames);
  }

  public static ReflectionObject Create(Type t, [Nullable(2)] MethodBase creator, params string[] memberNames)
  {
    ReflectionDelegateFactory reflectionDelegateFactory = JsonTypeReflector.ReflectionDelegateFactory;
    ObjectConstructor<object> creator1 = (ObjectConstructor<object>) null;
    if (creator != (MethodBase) null)
      creator1 = reflectionDelegateFactory.CreateParameterizedConstructor(creator);
    else if (ReflectionUtils.HasDefaultConstructor(t, false))
    {
      Func<object> ctor = reflectionDelegateFactory.CreateDefaultConstructor<object>(t);
      creator1 = (ObjectConstructor<object>) (([Nullable(new byte[] {1, 2})] args) => ctor());
    }
    ReflectionObject reflectionObject = new ReflectionObject(creator1);
    foreach (string memberName in memberNames)
    {
      MemberInfo[] member = t.GetMember(memberName, BindingFlags.Instance | BindingFlags.Public);
      MemberInfo memberInfo = member.Length == 1 ? ((IEnumerable<MemberInfo>) member).Single<MemberInfo>() : throw new ArgumentException("Expected a single member with the name '{0}'.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) memberName));
      ReflectionMember reflectionMember = new ReflectionMember();
      switch (memberInfo.MemberType())
      {
        case MemberTypes.Field:
        case MemberTypes.Property:
          if (ReflectionUtils.CanReadMemberValue(memberInfo, false))
            reflectionMember.Getter = reflectionDelegateFactory.CreateGet<object>(memberInfo);
          if (ReflectionUtils.CanSetMemberValue(memberInfo, false, false))
          {
            reflectionMember.Setter = reflectionDelegateFactory.CreateSet<object>(memberInfo);
            break;
          }
          break;
        case MemberTypes.Method:
          MethodInfo method = (MethodInfo) memberInfo;
          if (method.IsPublic)
          {
            ParameterInfo[] parameters = method.GetParameters();
            if (parameters.Length == 0 && method.ReturnType != typeof (void))
            {
              MethodCall<object, object> call = reflectionDelegateFactory.CreateMethodCall<object>((MethodBase) method);
              reflectionMember.Getter = (Func<object, object>) ([return: Nullable(2)] (target) => call(target));
              break;
            }
            if (parameters.Length == 1 && method.ReturnType == typeof (void))
            {
              MethodCall<object, object> call = reflectionDelegateFactory.CreateMethodCall<object>((MethodBase) method);
              object obj;
              reflectionMember.Setter = (Action<object, object>) ((target, [Nullable(2)] arg) => obj = call(target, arg));
              break;
            }
            break;
          }
          break;
        default:
          throw new ArgumentException("Unexpected member type '{0}' for member '{1}'.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) memberInfo.MemberType(), (object) memberInfo.Name));
      }
      reflectionMember.MemberType = ReflectionUtils.GetMemberUnderlyingType(memberInfo);
      reflectionObject.Members[memberName] = reflectionMember;
    }
    return reflectionObject;
  }
}
