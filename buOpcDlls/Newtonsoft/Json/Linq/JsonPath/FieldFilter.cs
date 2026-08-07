// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Linq.JsonPath.FieldFilter
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
internal class FieldFilter : PathFilter
{
  internal string Name;

  public FieldFilter(string name) => this.Name = name;

  [NullableContext(1)]
  public override IEnumerable<JToken> ExecuteFilter(
    JToken root,
    IEnumerable<JToken> current,
    [Nullable(2)] JsonSelectSettings settings)
  {
    foreach (JToken jtoken1 in current)
    {
      if (jtoken1 is JObject jobject)
      {
        if (this.Name != null)
        {
          JToken jtoken2 = jobject[this.Name];
          if (jtoken2 == null)
          {
            JsonSelectSettings jsonSelectSettings = settings;
            if ((jsonSelectSettings != null ? (jsonSelectSettings.ErrorWhenNoMatch ? 1 : 0) : 0) != 0)
              throw new JsonException("Property '{0}' does not exist on JObject.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) this.Name));
          }
          else
            yield return jtoken2;
        }
        else
        {
          foreach (KeyValuePair<string, JToken> keyValuePair in jobject)
            yield return keyValuePair.Value;
        }
      }
      else
      {
        JsonSelectSettings jsonSelectSettings = settings;
        if ((jsonSelectSettings != null ? (jsonSelectSettings.ErrorWhenNoMatch ? 1 : 0) : 0) != 0)
          throw new JsonException("Property '{0}' not valid on {1}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) (this.Name ?? "*"), (object) jtoken1.GetType().Name));
      }
    }
  }
}
