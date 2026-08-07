// Decompiled with JetBrains decompiler
// Type: System.Formats.Asn1.AsnContentException
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.CompilerServices.System.Formats.Asn1;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace System.Formats.Asn1;

[NullableContext(2)]
[Nullable(0)]
[ComVisible(true)]
[Serializable]
public class AsnContentException : Exception
{
  public AsnContentException()
    : base(System.System.Formats.Asn13538873.SR.ContentException_DefaultMessage)
  {
  }

  public AsnContentException(string message)
    : base(message ?? System.System.Formats.Asn13538873.SR.ContentException_DefaultMessage)
  {
  }

  public AsnContentException(string message, Exception inner)
    : base(message ?? System.System.Formats.Asn13538873.SR.ContentException_DefaultMessage, inner)
  {
  }

  [NullableContext(1)]
  protected AsnContentException(SerializationInfo info, StreamingContext context)
    : base(info, context)
  {
  }
}
