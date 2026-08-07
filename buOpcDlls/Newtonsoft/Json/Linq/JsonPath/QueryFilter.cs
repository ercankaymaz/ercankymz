// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Linq.JsonPath.QueryFilter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Linq.JsonPath;

[NullableContext(1)]
[Nullable(0)]
internal class QueryFilter : PathFilter
{
  internal QueryExpression Expression;

  public QueryFilter(QueryExpression expression) => this.Expression = expression;

  public override IEnumerable<JToken> ExecuteFilter(
    JToken root,
    IEnumerable<JToken> current,
    [Nullable(2)] JsonSelectSettings settings)
  {
    foreach (IEnumerable<JToken> jtokens in current)
    {
      foreach (JToken t in jtokens)
      {
        if (this.Expression.IsMatch(root, t, settings))
          yield return t;
      }
    }
  }
}
