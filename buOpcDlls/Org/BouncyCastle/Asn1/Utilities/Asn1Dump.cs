// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Utilities.Asn1Dump
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.IO;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.Asn1.Utilities;

public static class Asn1Dump
{
  private const string Tab = "    ";
  private const int SampleSize = 32 /*0x20*/;

  private static void AsString(string indent, bool verbose, Asn1Object obj, StringBuilder buf)
  {
    switch (obj)
    {
      case Asn1Null _:
        buf.Append(indent);
        buf.AppendLine("NULL");
        break;
      case Asn1Sequence asn1Sequence:
        buf.Append(indent);
        switch (asn1Sequence)
        {
          case BerSequence _:
            buf.AppendLine("BER Sequence");
            break;
          case DLSequence _:
            buf.AppendLine("Sequence");
            break;
          default:
            buf.AppendLine("DER Sequence");
            break;
        }
        string indent1 = indent + "    ";
        int index1 = 0;
        for (int count = asn1Sequence.Count; index1 < count; ++index1)
          Asn1Dump.AsString(indent1, verbose, asn1Sequence[index1].ToAsn1Object(), buf);
        break;
      case Asn1Set asn1Set:
        buf.Append(indent);
        switch (asn1Set)
        {
          case BerSet _:
            buf.AppendLine("BER Set");
            break;
          case DLSet _:
            buf.AppendLine("Set");
            break;
          default:
            buf.AppendLine("DER Set");
            break;
        }
        string indent2 = indent + "    ";
        int index2 = 0;
        for (int count = asn1Set.Count; index2 < count; ++index2)
          Asn1Dump.AsString(indent2, verbose, asn1Set[index2].ToAsn1Object(), buf);
        break;
      case Asn1TaggedObject taggedObject:
        buf.Append(indent);
        switch (taggedObject)
        {
          case BerTaggedObject _:
            buf.Append("BER Tagged ");
            break;
          case DLTaggedObject _:
            buf.Append("Tagged ");
            break;
          default:
            buf.Append("DER Tagged ");
            break;
        }
        buf.Append(Asn1Utilities.GetTagText(taggedObject));
        if (!taggedObject.IsExplicit())
          buf.Append(" IMPLICIT ");
        buf.AppendLine();
        Asn1Dump.AsString(indent + "    ", verbose, taggedObject.GetBaseObject().ToAsn1Object(), buf);
        break;
      case DerObjectIdentifier objectIdentifier:
        buf.Append(indent);
        buf.AppendLine($"ObjectIdentifier({objectIdentifier.Id})");
        break;
      case Asn1RelativeOid asn1RelativeOid:
        buf.Append(indent);
        buf.AppendLine($"RelativeOID({asn1RelativeOid.Id})");
        break;
      case DerBoolean derBoolean:
        buf.Append(indent);
        buf.AppendLine($"Boolean({derBoolean.IsTrue.ToString()})");
        break;
      case DerInteger derInteger:
        buf.Append(indent);
        buf.AppendLine($"Integer({derInteger.Value?.ToString()})");
        break;
      case Asn1OctetString asn1OctetString:
        byte[] octets = asn1OctetString.GetOctets();
        buf.Append(indent);
        if (obj is BerOctetString)
          buf.AppendLine($"BER Octet String[{octets.Length.ToString()}]");
        else
          buf.AppendLine($"DER Octet String[{octets.Length.ToString()}]");
        if (!verbose)
          break;
        Asn1Dump.DumpBinaryDataAsString(buf, indent, octets);
        break;
      case DerBitString derBitString:
        byte[] bytes = derBitString.GetBytes();
        int padBits = derBitString.PadBits;
        buf.Append(indent);
        switch (derBitString)
        {
          case BerBitString _:
            buf.AppendLine($"BER Bit String[{bytes.Length.ToString()}, {padBits.ToString()}]");
            break;
          case DLBitString _:
            buf.AppendLine($"DL Bit String[{bytes.Length.ToString()}, {padBits.ToString()}]");
            break;
          default:
            buf.AppendLine($"DER Bit String[{bytes.Length.ToString()}, {padBits.ToString()}]");
            break;
        }
        if (!verbose)
          break;
        Asn1Dump.DumpBinaryDataAsString(buf, indent, bytes);
        break;
      case DerIA5String derIa5String:
        buf.Append(indent);
        buf.AppendLine($"IA5String({derIa5String.GetString()})");
        break;
      case DerUtf8String derUtf8String:
        buf.Append(indent);
        buf.AppendLine($"UTF8String({derUtf8String.GetString()})");
        break;
      case DerPrintableString derPrintableString:
        buf.Append(indent);
        buf.AppendLine($"PrintableString({derPrintableString.GetString()})");
        break;
      case DerVisibleString derVisibleString:
        buf.Append(indent);
        buf.AppendLine($"VisibleString({derVisibleString.GetString()})");
        break;
      case DerBmpString derBmpString:
        buf.Append(indent);
        buf.AppendLine($"BMPString({derBmpString.GetString()})");
        break;
      case DerT61String derT61String:
        buf.Append(indent);
        buf.AppendLine($"T61String({derT61String.GetString()})");
        break;
      case DerGraphicString derGraphicString:
        buf.Append(indent);
        buf.AppendLine($"GraphicString({derGraphicString.GetString()})");
        break;
      case DerVideotexString derVideotexString:
        buf.Append(indent);
        buf.AppendLine($"VideotexString({derVideotexString.GetString()})");
        break;
      case Asn1UtcTime asn1UtcTime:
        buf.Append(indent);
        buf.AppendLine($"UTCTime({asn1UtcTime.TimeString})");
        break;
      case Asn1GeneralizedTime asn1GeneralizedTime:
        buf.Append(indent);
        buf.AppendLine($"GeneralizedTime({asn1GeneralizedTime.TimeString})");
        break;
      case DerEnumerated derEnumerated:
        buf.Append(indent);
        buf.AppendLine($"DER Enumerated({derEnumerated.Value?.ToString()})");
        break;
      case DerExternal derExternal:
        buf.Append(indent);
        buf.AppendLine("External ");
        string indent3 = indent + "    ";
        if (derExternal.DirectReference != null)
        {
          buf.Append(indent3);
          buf.AppendLine("Direct Reference: " + derExternal.DirectReference.Id);
        }
        if (derExternal.IndirectReference != null)
        {
          buf.Append(indent3);
          buf.AppendLine("Indirect Reference: " + derExternal.IndirectReference.ToString());
        }
        if (derExternal.DataValueDescriptor != null)
          Asn1Dump.AsString(indent3, verbose, (Asn1Object) derExternal.DataValueDescriptor, buf);
        buf.Append(indent3);
        buf.AppendLine("Encoding: " + derExternal.Encoding.ToString());
        Asn1Dump.AsString(indent3, verbose, derExternal.ExternalContent, buf);
        break;
      default:
        buf.Append(indent);
        buf.Append((object) obj);
        buf.AppendLine();
        break;
    }
  }

  public static void Dump(Stream input, TextWriter output)
  {
    using (Asn1InputStream asn1InputStream = new Asn1InputStream(input, int.MaxValue, true))
    {
      Asn1Object asn1Object;
      while ((asn1Object = asn1InputStream.ReadObject()) != null)
        output.Write(Asn1Dump.DumpAsString((Asn1Encodable) asn1Object));
    }
  }

  public static string DumpAsString(Asn1Encodable obj) => Asn1Dump.DumpAsString(obj, false);

  public static string DumpAsString(Asn1Encodable obj, bool verbose)
  {
    StringBuilder buf = new StringBuilder();
    Asn1Dump.AsString("", verbose, obj.ToAsn1Object(), buf);
    return buf.ToString();
  }

  private static void DumpBinaryDataAsString(StringBuilder buf, string indent, byte[] bytes)
  {
    if (bytes.Length < 1)
      return;
    indent += "    ";
    for (int off = 0; off < bytes.Length; off += 32 /*0x20*/)
    {
      int num = Math.Min(bytes.Length - off, 32 /*0x20*/);
      buf.Append(indent);
      buf.Append(Hex.ToHexString(bytes, off, num));
      for (int index = num; index < 32 /*0x20*/; ++index)
        buf.Append("  ");
      buf.Append("    ");
      Asn1Dump.AppendAscString(buf, bytes, off, num);
      buf.AppendLine();
    }
  }

  private static void AppendAscString(StringBuilder buf, byte[] bytes, int off, int len)
  {
    for (int index = off; index != off + len; ++index)
    {
      char ch = (char) bytes[index];
      if (ch >= ' ' && ch <= '~')
        buf.Append(ch);
    }
  }
}
