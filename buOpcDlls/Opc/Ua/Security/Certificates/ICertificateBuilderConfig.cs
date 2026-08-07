// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Security.Certificates.ICertificateBuilderConfig
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

#nullable disable
namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public interface ICertificateBuilderConfig
{
  ICertificateBuilder SetSerialNumberLength(int length);

  ICertificateBuilder SetSerialNumber(byte[] serialNumber);

  ICertificateBuilder CreateSerialNumber();

  ICertificateBuilder SetNotBefore(DateTime notBefore);

  ICertificateBuilder SetNotAfter(DateTime notAfter);

  ICertificateBuilder SetLifeTime(TimeSpan lifeTime);

  ICertificateBuilder SetLifeTime(ushort months);

  ICertificateBuilder SetHashAlgorithm(HashAlgorithmName hashAlgorithmName);

  ICertificateBuilder SetCAConstraint(int pathLengthConstraint = -1);

  ICertificateBuilder AddExtension(X509Extension extension);
}
