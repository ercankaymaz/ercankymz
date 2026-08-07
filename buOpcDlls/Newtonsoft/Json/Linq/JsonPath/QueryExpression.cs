// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Linq.JsonPath.QueryExpression
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Linq.JsonPath;

[NullableContext(1)]
[Nullable(0)]
internal abstract class QueryExpression
{
  internal QueryOperator Operator;

  public QueryExpression(QueryOperator @operator) => this.Operator = @operator;

  public bool IsMatch(JToken root, JToken t) => this.IsMatch(root, t, (JsonSelectSettings) null);

  public abstract bool IsMatch(JToken root, JToken t, [Nullable(2)] JsonSelectSettings settings);
}
