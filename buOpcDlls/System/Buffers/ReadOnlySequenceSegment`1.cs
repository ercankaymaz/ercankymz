// Decompiled with JetBrains decompiler
// Type: System.Buffers.ReadOnlySequenceSegment`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;

#nullable disable
namespace System.Buffers;

[ComVisible(true)]
public abstract class ReadOnlySequenceSegment<T>
{
  public ReadOnlyMemory<T> Memory { get; protected set; }

  public ReadOnlySequenceSegment<T> Next { get; protected set; }

  public long RunningIndex { get; protected set; }
}
