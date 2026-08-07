// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.NoThrowSetBinderMember
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Dynamic;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Utilities;

[NullableContext(1)]
[Nullable(0)]
internal class NoThrowSetBinderMember : SetMemberBinder
{
  private readonly SetMemberBinder _innerBinder;

  public NoThrowSetBinderMember(SetMemberBinder innerBinder)
    : base(innerBinder.Name, innerBinder.IgnoreCase)
  {
    this._innerBinder = innerBinder;
  }

  public override DynamicMetaObject FallbackSetMember(
    DynamicMetaObject target,
    DynamicMetaObject value,
    [Nullable(2)] DynamicMetaObject errorSuggestion)
  {
    DynamicMetaObject dynamicMetaObject = this._innerBinder.Bind(target, new DynamicMetaObject[1]
    {
      value
    });
    return new DynamicMetaObject(new NoThrowExpressionVisitor().Visit(dynamicMetaObject.Expression), dynamicMetaObject.Restrictions);
  }
}
