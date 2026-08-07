// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.Sig.EmbeddedSignature
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Bcpg.Sig;

public class EmbeddedSignature(bool critical, bool isLongLength, byte[] data) : SignatureSubpacket(SignatureSubpacketTag.EmbeddedSignature, critical, isLongLength, data)
{
}
