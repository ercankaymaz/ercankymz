// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Linq.JsonPath.FieldMultipleFilter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Linq.JsonPath;

[NullableContext(1)]
[Nullable(0)]
internal class FieldMultipleFilter : PathFilter
{
  internal List<string> Names;

  public FieldMultipleFilter(List<string> names) => this.Names = names;

  public override IEnumerable<JToken> ExecuteFilter(
    JToken root,
    IEnumerable<JToken> current,
    [Nullable(2)] JsonSelectSettings settings)
  {
    foreach (JToken jtoken1 in current)
    {
      if (jtoken1 is JObject o)
      {
        foreach (string name1 in this.Names)
        {
          string name = name1;
          JToken jtoken2 = o[name];
          if (jtoken2 != null)
            goto label_18;
label_4:
          JsonSelectSettings jsonSelectSettings = settings;
          if ((jsonSelectSettings != null ? (jsonSelectSettings.ErrorWhenNoMatch ? 1 : 0) : 0) != 0)
            throw new JsonException("Property '{0}' does not exist on JObject.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) name));
          name = (string) null;
          continue;
label_18:
          yield return jtoken2;
          goto label_4;
        }
      }
      else
      {
        JsonSelectSettings jsonSelectSettings = settings;
        if ((jsonSelectSettings != null ? (jsonSelectSettings.ErrorWhenNoMatch ? 1 : 0) : 0) != 0)
          throw new JsonException("Properties {0} not valid on {1}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) string.Join(", ", this.Names.Select<string, string>((Func<string, string>) ([NullableContext(0)] (n) => $"'{n}'"))), (object) jtoken1.GetType().Name));
      }
      o = (JObject) null;
    }
  }
}
