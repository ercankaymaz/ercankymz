// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Linq.JsonPath.QueryScanFilter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Linq.JsonPath;

[NullableContext(1)]
[Nullable(0)]
internal class QueryScanFilter : PathFilter
{
  internal QueryExpression Expression;

  public QueryScanFilter(QueryExpression expression) => this.Expression = expression;

  public override IEnumerable<JToken> ExecuteFilter(
    JToken root,
    IEnumerable<JToken> current,
    [Nullable(2)] JsonSelectSettings settings)
  {
    foreach (JToken t1 in current)
    {
      if (t1 is JContainer jcontainer)
      {
        foreach (JToken t2 in jcontainer.DescendantsAndSelf())
        {
          if (this.Expression.IsMatch(root, t2, settings))
            yield return t2;
        }
      }
      else if (this.Expression.IsMatch(root, t1, settings))
        yield return t1;
    }
  }
}
