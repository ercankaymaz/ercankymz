// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Linq.JsonPath.ScanMultipleFilter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Linq.JsonPath;

[NullableContext(1)]
[Nullable(0)]
internal class ScanMultipleFilter : PathFilter
{
  private List<string> _names;

  public ScanMultipleFilter(List<string> names) => this._names = names;

  public override IEnumerable<JToken> ExecuteFilter(
    JToken root,
    IEnumerable<JToken> current,
    [Nullable(2)] JsonSelectSettings settings)
  {
    foreach (JToken c in current)
    {
      JToken value = c;
      while (true)
      {
        value = PathFilter.GetNextScanValue(c, (JToken) (value as JContainer), value);
        if (value != null)
        {
          if (value is JProperty property)
          {
            foreach (string name in this._names)
            {
              if (property.Name == name)
                yield return property.Value;
            }
          }
          property = (JProperty) null;
        }
        else
          break;
      }
      value = (JToken) null;
    }
  }
}
