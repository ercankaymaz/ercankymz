// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Serialization.ReflectionValueProvider
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Utilities;
using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Serialization;

[NullableContext(1)]
[Nullable(0)]
public class ReflectionValueProvider : IValueProvider
{
  private readonly MemberInfo _memberInfo;

  public ReflectionValueProvider(MemberInfo memberInfo)
  {
    ValidationUtils.ArgumentNotNull((object) memberInfo, nameof (memberInfo));
    this._memberInfo = memberInfo;
  }

  public void SetValue(object target, [Nullable(2)] object value)
  {
    try
    {
      ReflectionUtils.SetMemberValue(this._memberInfo, target, value);
    }
    catch (Exception ex)
    {
      throw new JsonSerializationException("Error setting value to '{0}' on '{1}'.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) this._memberInfo.Name, (object) target.GetType()), ex);
    }
  }

  [return: Nullable(2)]
  public object GetValue(object target)
  {
    try
    {
      PropertyInfo memberInfo = this._memberInfo as PropertyInfo;
      if ((object) memberInfo != null && memberInfo.PropertyType.IsByRef)
        throw new InvalidOperationException("Could not create getter for {0}. ByRef return values are not supported.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) memberInfo));
      return ReflectionUtils.GetMemberValue(this._memberInfo, target);
    }
    catch (Exception ex)
    {
      throw new JsonSerializationException("Error getting value from '{0}' on '{1}'.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) this._memberInfo.Name, (object) target.GetType()), ex);
    }
  }
}
