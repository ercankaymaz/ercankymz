// Decompiled with JetBrains decompiler
// Type: System.Formats.Asn1.SetOfValueComparer
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;

#nullable disable
namespace System.Formats.Asn1;

internal sealed class SetOfValueComparer : IComparer<ReadOnlyMemory<byte>>
{
  internal static SetOfValueComparer Instance { get; } = new SetOfValueComparer();

  public int Compare(ReadOnlyMemory<byte> x, ReadOnlyMemory<byte> y)
  {
    return SetOfValueComparer.Compare(x.Span, y.Span);
  }

  internal static int Compare(ReadOnlySpan<byte> x, ReadOnlySpan<byte> y)
  {
    int num1 = Math.Min(x.Length, y.Length);
    for (int index = 0; index < num1; ++index)
    {
      int num2 = (int) x[index] - (int) y[index];
      if (num2 != 0)
        return num2;
    }
    return x.Length - y.Length;
  }
}
