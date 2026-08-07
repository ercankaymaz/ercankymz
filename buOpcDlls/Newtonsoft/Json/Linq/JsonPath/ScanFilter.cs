// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Linq.JsonPath.ScanFilter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Linq.JsonPath;

[NullableContext(2)]
[Nullable(0)]
internal class ScanFilter : PathFilter
{
  internal string Name;

  public ScanFilter(string name) => this.Name = name;

  [NullableContext(1)]
  public override IEnumerable<JToken> ExecuteFilter(
    JToken root,
    IEnumerable<JToken> current,
    [Nullable(2)] JsonSelectSettings settings)
  {
    foreach (JToken jtoken in current)
    {
      JToken c = jtoken;
      if (this.Name == null)
        goto label_12;
label_4:
      JToken value = c;
      while (true)
      {
        do
        {
          do
          {
            value = PathFilter.GetNextScanValue(c, (JToken) (value as JContainer), value);
            if (value != null)
            {
              if (value is JProperty jproperty)
                goto label_6;
            }
            else
              goto label_1;
          }
          while (this.Name != null);
          goto label_11;
label_6:;
        }
        while (!(jproperty.Name == this.Name));
        yield return jproperty.Value;
        continue;
label_11:
        yield return value;
      }
label_1:
      value = (JToken) null;
      c = (JToken) null;
      continue;
label_12:
      yield return c;
      goto label_4;
    }
  }
}
