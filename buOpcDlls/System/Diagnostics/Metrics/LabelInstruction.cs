// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Metrics.LabelInstruction
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource;

#nullable disable
namespace System.Diagnostics.Metrics;

internal struct LabelInstruction(int sourceIndex, string labelName)
{
  public int SourceIndex { [IsReadOnly] get; } = sourceIndex;

  public string LabelName { [IsReadOnly] get; } = labelName;
}
