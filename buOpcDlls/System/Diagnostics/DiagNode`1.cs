// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.DiagNode`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace System.Diagnostics;

internal sealed class DiagNode<T>
{
  public T Value;
  public DiagNode<T> Next;

  public DiagNode(T value) => this.Value = value;
}
