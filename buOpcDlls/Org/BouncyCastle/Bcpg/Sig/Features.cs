// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.Sig.Features
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Bcpg.Sig;

public class Features(bool critical, bool isLongLength, byte[] data) : SignatureSubpacket(SignatureSubpacketTag.Features, critical, isLongLength, data)
{
  public static readonly byte FEATURE_MODIFICATION_DETECTION = 1;
  public static readonly byte FEATURE_AEAD_ENCRYPTED_DATA = 2;
  public static readonly byte FEATURE_VERSION_5_PUBLIC_KEY = 4;

  private static byte[] FeatureToByteArray(byte feature)
  {
    return new byte[1]{ feature };
  }

  public Features(bool critical, byte features)
    : this(critical, false, Features.FeatureToByteArray(features))
  {
  }

  public Features(bool critical, int features)
    : this(critical, false, Features.FeatureToByteArray((byte) features))
  {
  }

  public bool SupportsModificationDetection
  {
    get => this.SupportsFeature(Features.FEATURE_MODIFICATION_DETECTION);
  }

  public bool SupportsFeature(byte feature) => ((uint) this.data[0] & (uint) feature) > 0U;
}
