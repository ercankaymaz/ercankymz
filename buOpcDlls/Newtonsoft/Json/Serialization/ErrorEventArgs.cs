// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Serialization.ErrorEventArgs
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Serialization;

[NullableContext(1)]
[Nullable(0)]
public class ErrorEventArgs : EventArgs
{
  [field: Nullable(2)]
  [Nullable(2)]
  public object CurrentObject { [NullableContext(2)] get; }

  public ErrorContext ErrorContext { get; }

  public ErrorEventArgs([Nullable(2)] object currentObject, ErrorContext errorContext)
  {
    this.CurrentObject = currentObject;
    this.ErrorContext = errorContext;
  }
}
