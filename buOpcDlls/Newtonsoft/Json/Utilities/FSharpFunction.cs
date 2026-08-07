// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.FSharpFunction
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Utilities;

[NullableContext(2)]
[Nullable(0)]
internal class FSharpFunction
{
  private readonly object _instance;
  [Nullable(new byte[] {1, 2, 1})]
  private readonly MethodCall<object, object> _invoker;

  public FSharpFunction(object instance, [Nullable(new byte[] {1, 2, 1})] MethodCall<object, object> invoker)
  {
    this._instance = instance;
    this._invoker = invoker;
  }

  [NullableContext(1)]
  public object Invoke(params object[] args) => this._invoker(this._instance, args);
}
