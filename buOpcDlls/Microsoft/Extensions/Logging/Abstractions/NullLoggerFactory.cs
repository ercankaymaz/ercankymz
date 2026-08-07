// Decompiled with JetBrains decompiler
// Type: Microsoft.Extensions.Logging.Abstractions.NullLoggerFactory
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.CompilerServices.Microsoft.Extensions.Logging.Abstractions;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.Extensions.Logging.Abstractions;

[ComVisible(true)]
public class NullLoggerFactory : ILoggerFactory, IDisposable
{
  [Nullable(1)]
  public static readonly NullLoggerFactory Instance = new NullLoggerFactory();

  [NullableContext(1)]
  public ILogger CreateLogger(string name) => (ILogger) NullLogger.Instance;

  [NullableContext(1)]
  public void AddProvider(ILoggerProvider provider)
  {
  }

  public void Dispose()
  {
  }
}
