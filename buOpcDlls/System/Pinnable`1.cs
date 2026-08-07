// Decompiled with JetBrains decompiler
// Type: System.Pinnable`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;

#nullable disable
namespace System;

[StructLayout(LayoutKind.Sequential)]
internal sealed class Pinnable<T>
{
  public T Data;
}
