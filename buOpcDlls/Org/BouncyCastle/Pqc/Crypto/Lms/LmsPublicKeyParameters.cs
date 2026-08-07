// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Lms.LmsPublicKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Lms;

public sealed class LmsPublicKeyParameters : LmsKeyParameters, ILmsContextBasedVerifier
{
  private LMSigParameters parameterSet;
  private LMOtsParameters lmOtsType;
  private byte[] I;
  private byte[] T1;

  public LmsPublicKeyParameters(
    LMSigParameters parameterSet,
    LMOtsParameters lmOtsType,
    byte[] T1,
    byte[] I)
    : base(false)
  {
    this.parameterSet = parameterSet;
    this.lmOtsType = lmOtsType;
    this.I = Arrays.Clone(I);
    this.T1 = Arrays.Clone(T1);
  }

  public static LmsPublicKeyParameters GetInstance(object src)
  {
    switch (src)
    {
      case LmsPublicKeyParameters instance:
        return instance;
      case BinaryReader binaryReader:
        LMSigParameters parametersById1 = LMSigParameters.GetParametersByID(BinaryReaders.ReadInt32BigEndian(binaryReader));
        LMOtsParameters parametersById2 = LMOtsParameters.GetParametersByID(BinaryReaders.ReadInt32BigEndian(binaryReader));
        byte[] I = BinaryReaders.ReadBytesFully(binaryReader, 16 /*0x10*/);
        byte[] T1 = BinaryReaders.ReadBytesFully(binaryReader, parametersById1.M);
        return new LmsPublicKeyParameters(parametersById1, parametersById2, T1, I);
      case byte[] buffer:
        BinaryReader src1 = (BinaryReader) null;
        try
        {
          src1 = new BinaryReader((Stream) new MemoryStream(buffer, false));
          return LmsPublicKeyParameters.GetInstance((object) src1);
        }
        finally
        {
          src1?.Close();
        }
      case MemoryStream inStr:
        return LmsPublicKeyParameters.GetInstance((object) Streams.ReadAll(inStr));
      default:
        throw new Exception($"cannot parse {src}");
    }
  }

  public override byte[] GetEncoded() => this.ToByteArray();

  public LMSigParameters GetSigParameters() => this.parameterSet;

  public LMOtsParameters GetOtsParameters() => this.lmOtsType;

  public LmsParameters GetLmsParameters()
  {
    return new LmsParameters(this.GetSigParameters(), this.GetOtsParameters());
  }

  public byte[] GetT1() => Arrays.Clone(this.T1);

  internal bool MatchesT1(byte[] sig) => Arrays.FixedTimeEquals(this.T1, sig);

  public byte[] GetI() => Arrays.Clone(this.I);

  private byte[] RefI() => this.I;

  public override bool Equals(object o)
  {
    if (this == o)
      return true;
    if (o == null || this.GetType() != o.GetType())
      return false;
    LmsPublicKeyParameters publicKeyParameters = (LmsPublicKeyParameters) o;
    return this.parameterSet.Equals((object) publicKeyParameters.parameterSet) && this.lmOtsType.Equals((object) publicKeyParameters.lmOtsType) && Arrays.AreEqual(this.I, publicKeyParameters.I) && Arrays.AreEqual(this.T1, publicKeyParameters.T1);
  }

  public override int GetHashCode()
  {
    return 31 /*0x1F*/ * (31 /*0x1F*/ * (31 /*0x1F*/ * this.parameterSet.GetHashCode() + this.lmOtsType.GetHashCode()) + Arrays.GetHashCode(this.I)) + Arrays.GetHashCode(this.T1);
  }

  internal byte[] ToByteArray()
  {
    return Composer.Compose().U32Str(this.parameterSet.ID).U32Str(this.lmOtsType.ID).Bytes(this.I).Bytes(this.T1).Build();
  }

  public LmsContext GenerateLmsContext(byte[] signature)
  {
    try
    {
      return this.GenerateOtsContext(LmsSignature.GetInstance((object) signature));
    }
    catch (IOException ex)
    {
      throw new IOException("cannot parse signature: " + ex.Message);
    }
  }

  internal LmsContext GenerateOtsContext(LmsSignature S)
  {
    int id = this.GetOtsParameters().ID;
    if (S.OtsSignature.ParamType.ID != id)
      throw new ArgumentException("ots type from lsm signature does not match ots signature type from embedded ots signature");
    return new LMOtsPublicKey(LMOtsParameters.GetParametersByID(id), this.I, S.Q, (byte[]) null).CreateOtsContext(S);
  }

  public bool Verify(LmsContext context) => Org.BouncyCastle.Pqc.Crypto.Lms.Lms.VerifySignature(this, context);
}
