// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Serialization.ErrorContext
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Serialization;

[NullableContext(1)]
[Nullable(0)]
public class ErrorContext
{
  internal ErrorContext([Nullable(2)] object originalObject, [Nullable(2)] object member, string path, Exception error)
  {
    this.OriginalObject = originalObject;
    this.Member = member;
    this.Error = error;
    this.Path = path;
  }

  internal bool Traced { get; set; }

  public Exception Error { get; }

  [field: Nullable(2)]
  [Nullable(2)]
  public object OriginalObject { [NullableContext(2)] get; }

  [field: Nullable(2)]
  [Nullable(2)]
  public object Member { [NullableContext(2)] get; }

  public string Path { get; }

  public bool Handled { get; set; }
}
