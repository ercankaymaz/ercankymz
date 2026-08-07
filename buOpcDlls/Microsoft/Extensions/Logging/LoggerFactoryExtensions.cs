// Decompiled with JetBrains decompiler
// Type: Microsoft.Extensions.Logging.LoggerFactoryExtensions
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Microsoft.Extensions.Internal;
using System;
using System.Runtime.CompilerServices.Microsoft.Extensions.Logging.Abstractions;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.Extensions.Logging;

[NullableContext(1)]
[Nullable(0)]
[ComVisible(true)]
public static class LoggerFactoryExtensions
{
  public static ILogger<T> CreateLogger<[Nullable(2)] T>(this ILoggerFactory factory)
  {
    return factory != null ? (ILogger<T>) new Logger<T>(factory) : throw new ArgumentNullException(nameof (factory));
  }

  public static ILogger CreateLogger(this ILoggerFactory factory, Type type)
  {
    if (factory == null)
      throw new ArgumentNullException(nameof (factory));
    return !(type == (Type) null) ? factory.CreateLogger(TypeNameHelper.GetTypeDisplayName(type, includeGenericParameters: false, nestedTypeDelimiter: '.')) : throw new ArgumentNullException(nameof (type));
  }
}
