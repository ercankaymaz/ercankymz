// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Linq.JsonPath.PathFilter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Linq.JsonPath;

[NullableContext(2)]
[Nullable(0)]
internal abstract class PathFilter
{
  [NullableContext(1)]
  public abstract IEnumerable<JToken> ExecuteFilter(
    JToken root,
    IEnumerable<JToken> current,
    [Nullable(2)] JsonSelectSettings settings);

  protected static JToken GetTokenIndex([Nullable(1)] JToken t, JsonSelectSettings settings, int index)
  {
    if (t is JArray jarray)
    {
      if (jarray.Count > index)
        return jarray[index];
      if (settings != null && settings.ErrorWhenNoMatch)
        throw new JsonException("Index {0} outside the bounds of JArray.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) index));
      return (JToken) null;
    }
    if (t is JConstructor jconstructor)
    {
      if (jconstructor.Count > index)
        return jconstructor[(object) index];
      if (settings != null && settings.ErrorWhenNoMatch)
        throw new JsonException("Index {0} outside the bounds of JConstructor.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) index));
      return (JToken) null;
    }
    if (settings != null && settings.ErrorWhenNoMatch)
      throw new JsonException("Index {0} not valid on {1}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) index, (object) t.GetType().Name));
    return (JToken) null;
  }

  protected static JToken GetNextScanValue([Nullable(1)] JToken originalParent, JToken container, JToken value)
  {
    if (container != null && container.HasValues)
    {
      value = container.First;
    }
    else
    {
      while (value != null && value != originalParent && value == value.Parent.Last)
        value = (JToken) value.Parent;
      if (value == null || value == originalParent)
        return (JToken) null;
      value = value.Next;
    }
    return value;
  }
}
