// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Linq.JsonPath.CompositeExpression
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Linq.JsonPath;

[NullableContext(1)]
[Nullable(0)]
internal class CompositeExpression : QueryExpression
{
  public List<QueryExpression> Expressions { get; set; }

  public CompositeExpression(QueryOperator @operator)
    : base(@operator)
  {
    this.Expressions = new List<QueryExpression>();
  }

  public override bool IsMatch(JToken root, JToken t, [Nullable(2)] JsonSelectSettings settings)
  {
    switch (this.Operator)
    {
      case QueryOperator.And:
        foreach (QueryExpression expression in this.Expressions)
        {
          if (!expression.IsMatch(root, t, settings))
            return false;
        }
        return true;
      case QueryOperator.Or:
        foreach (QueryExpression expression in this.Expressions)
        {
          if (expression.IsMatch(root, t, settings))
            return true;
        }
        return false;
      default:
        throw new ArgumentOutOfRangeException();
    }
  }
}
