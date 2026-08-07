// Decompiled with JetBrains decompiler
// Type: System.Formats.Asn1.AsnReaderOptions
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.CompilerServices.System.Formats.Asn1;
using System.Runtime.InteropServices;

#nullable disable
namespace System.Formats.Asn1;

[ComVisible(true)]
public struct AsnReaderOptions
{
  private const int DefaultTwoDigitMax = 2049;
  private ushort _twoDigitYearMax;

  public int UtcTimeTwoDigitYearMax
  {
    get => this._twoDigitYearMax == (ushort) 0 ? 2049 : (int) this._twoDigitYearMax;
    set
    {
      this._twoDigitYearMax = value >= 1 && value <= 9999 ? (ushort) value : throw new ArgumentOutOfRangeException(nameof (value));
    }
  }

  public bool SkipSetSortOrderVerification { [IsReadOnly] get; set; }
}
