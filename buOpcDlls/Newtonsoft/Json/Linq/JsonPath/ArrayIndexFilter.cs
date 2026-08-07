// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Linq.JsonPath.ArrayIndexFilter
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

internal class ArrayIndexFilter : PathFilter
{
  public int? Index { get; set; }

  [NullableContext(1)]
  public override IEnumerable<JToken> ExecuteFilter(
    JToken root,
    IEnumerable<JToken> current,
    [Nullable(2)] JsonSelectSettings settings)
  {
    foreach (JToken jtoken1 in current)
    {
      int? index = this.Index;
      if (index.HasValue)
      {
        JToken t = jtoken1;
        JsonSelectSettings settings1 = settings;
        index = this.Index;
        int valueOrDefault = index.GetValueOrDefault();
        JToken tokenIndex = PathFilter.GetTokenIndex(t, settings1, valueOrDefault);
        if (tokenIndex != null)
          yield return tokenIndex;
      }
      else
      {
        switch (jtoken1)
        {
          case JArray _:
          case JConstructor _:
            foreach (JToken jtoken2 in (IEnumerable<JToken>) jtoken1)
              yield return jtoken2;
            continue;
          default:
            JsonSelectSettings jsonSelectSettings = settings;
            if ((jsonSelectSettings != null ? (jsonSelectSettings.ErrorWhenNoMatch ? 1 : 0) : 0) != 0)
              throw new JsonException("Index * not valid on {0}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) jtoken1.GetType().Name));
            continue;
        }
      }
    }
  }
}
