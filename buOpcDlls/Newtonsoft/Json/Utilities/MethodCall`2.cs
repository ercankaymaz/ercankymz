// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.MethodCall`2
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Utilities;

internal delegate TResult MethodCall<[Nullable(2)] T, [Nullable(2)] TResult>(
  T target,
  [Nullable(new byte[] {1, 2})] params object[] args);
