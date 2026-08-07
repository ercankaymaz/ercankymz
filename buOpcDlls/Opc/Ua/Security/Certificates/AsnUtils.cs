// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Security.Certificates.AsnUtils
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Formats.Asn1;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

#nullable disable
namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public static class AsnUtils
{
  internal static string ToHexString(this byte[] buffer, bool invertEndian = false)
  {
    if (buffer == null || buffer.Length == 0)
      return string.Empty;
    StringBuilder stringBuilder = new StringBuilder(buffer.Length * 2);
    if (invertEndian)
    {
      for (int index = buffer.Length - 1; index >= 0; --index)
        stringBuilder.AppendFormat("{0:X2}", (object) buffer[index]);
    }
    else
    {
      for (int index = 0; index < buffer.Length; ++index)
        stringBuilder.AppendFormat("{0:X2}", (object) buffer[index]);
    }
    return stringBuilder.ToString();
  }

  internal static byte[] FromHexString(this string buffer)
  {
    switch (buffer)
    {
      case null:
        return (byte[]) null;
      case "":
        return Array.Empty<byte>();
      default:
        byte[] numArray = new byte[buffer.Length / 2 + buffer.Length % 2];
        for (int index = 0; index < numArray.Length * 2; index += 2)
        {
          int num1 = "0123456789ABCDEF".IndexOf(buffer[index]);
          if (num1 != -1)
          {
            byte num2 = (byte) ((uint) (byte) num1 << 4);
            if (index < buffer.Length - 1)
            {
              int num3 = "0123456789ABCDEF".IndexOf(buffer[index + 1]);
              if (num3 != -1)
                num2 += (byte) num3;
              else
                break;
            }
            numArray[index / 2] = num2;
          }
          else
            break;
        }
        return numArray;
    }
  }

  internal static void WriteKeyParameterInteger(this AsnWriter writer, ReadOnlySpan<byte> integer)
  {
    if (integer[0] == (byte) 0)
    {
      int num;
      for (num = 1; num < integer.Length; ++num)
      {
        if (integer[num] < (byte) 128 /*0x80*/)
        {
          if (integer[num] != (byte) 0)
            break;
        }
        else
        {
          --num;
          break;
        }
      }
      if (num == integer.Length)
        --num;
      integer = integer.Slice(num);
    }
    writer.WriteIntegerUnsigned(integer);
  }

  public static byte[] ParseX509Blob(byte[] blob)
  {
    try
    {
      AsnReader asnReader1 = new AsnReader((ReadOnlyMemory<byte>) blob, AsnEncodingRules.DER);
      byte[] array = blob.AsSpan<byte>(0, asnReader1.PeekContentBytes().Length + 4).ToArray();
      AsnReader asnReader2 = asnReader1.ReadSequence(new Asn1Tag?(Asn1Tag.Sequence));
      if (asnReader2 != null)
      {
        asnReader2.ReadEncodedValue();
        Oids.GetHashAlgorithmName(asnReader2.ReadSequence().ReadObjectIdentifier());
        int unusedBitCount;
        asnReader2.ReadBitString(out unusedBitCount);
        if (unusedBitCount != 0)
          throw new AsnContentException("Unexpected data in signature.");
        asnReader2.ThrowIfNotEmpty();
        return array;
      }
    }
    catch (AsnContentException ex)
    {
      throw new CryptographicException("Failed to decode the X509 sequence.", (Exception) ex);
    }
    throw new CryptographicException("Invalid ASN encoding for the X509 sequence.");
  }
}
