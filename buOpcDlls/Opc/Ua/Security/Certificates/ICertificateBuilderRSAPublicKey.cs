// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Security.Certificates.ICertificateBuilderRSAPublicKey
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;
using System.Security.Cryptography;

#nullable disable
namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public interface ICertificateBuilderRSAPublicKey
{
  ICertificateBuilderCreateForRSAAny SetRSAPublicKey(byte[] publicKey);

  ICertificateBuilderCreateForRSAAny SetRSAPublicKey(RSA publicKey);
}
