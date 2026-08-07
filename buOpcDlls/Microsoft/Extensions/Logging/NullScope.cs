// Decompiled with JetBrains decompiler
// Type: Microsoft.Extensions.Logging.NullScope
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.CompilerServices.Microsoft.Extensions.Logging.Abstractions;

#nullable disable
namespace Microsoft.Extensions.Logging;

internal sealed class NullScope : IDisposable
{
  [Nullable(1)]
  public static NullScope Instance { [NullableContext(1)] get; } = new NullScope();

  private NullScope()
  {
  }

  public void Dispose()
  {
  }
}
