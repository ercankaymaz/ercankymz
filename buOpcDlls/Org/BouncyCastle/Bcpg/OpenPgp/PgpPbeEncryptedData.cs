// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.PgpPbeEncryptedData
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.IO;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

public class PgpPbeEncryptedData : PgpEncryptedData
{
  private readonly SymmetricKeyEncSessionPacket keyData;

  internal PgpPbeEncryptedData(SymmetricKeyEncSessionPacket keyData, InputStreamPacket encData)
    : base(encData)
  {
    this.keyData = keyData;
  }

  public override Stream GetInputStream() => (Stream) this.encData.GetInputStream();

  public Stream GetDataStream(char[] passPhrase)
  {
    return this.DoGetDataStream(PgpUtilities.EncodePassPhrase(passPhrase, false), true);
  }

  public Stream GetDataStreamUtf8(char[] passPhrase)
  {
    return this.DoGetDataStream(PgpUtilities.EncodePassPhrase(passPhrase, true), true);
  }

  public Stream GetDataStreamRaw(byte[] rawPassPhrase)
  {
    return this.DoGetDataStream(rawPassPhrase, false);
  }

  internal Stream DoGetDataStream(byte[] rawPassPhrase, bool clearPassPhrase)
  {
    try
    {
      SymmetricKeyAlgorithmTag encAlgorithm = this.keyData.EncAlgorithm;
      KeyParameter parameters = PgpUtilities.DoMakeKeyFromPassPhrase(encAlgorithm, this.keyData.S2k, rawPassPhrase, clearPassPhrase);
      byte[] secKeyData = this.keyData.GetSecKeyData();
      if (secKeyData != null && secKeyData.Length != 0)
      {
        IBufferedCipher cipher = CipherUtilities.GetCipher(PgpUtilities.GetSymmetricCipherName(encAlgorithm) + "/CFB/NoPadding");
        cipher.Init(false, (ICipherParameters) new ParametersWithIV((ICipherParameters) parameters, new byte[cipher.GetBlockSize()]));
        byte[] keyBytes = cipher.DoFinal(secKeyData);
        encAlgorithm = (SymmetricKeyAlgorithmTag) keyBytes[0];
        parameters = ParameterUtilities.CreateKeyParameter(PgpUtilities.GetSymmetricCipherName(encAlgorithm), keyBytes, 1, keyBytes.Length - 1);
      }
      IBufferedCipher streamCipher = this.CreateStreamCipher(encAlgorithm);
      byte[] numArray = new byte[streamCipher.GetBlockSize()];
      streamCipher.Init(false, (ICipherParameters) new ParametersWithIV((ICipherParameters) parameters, numArray));
      this.encStream = (Stream) BcpgInputStream.Wrap((Stream) new CipherStream((Stream) this.encData.GetInputStream(), streamCipher, (IBufferedCipher) null));
      if (this.encData is SymmetricEncIntegrityPacket)
      {
        this.truncStream = new PgpEncryptedData.TruncatedStream(this.encStream);
        this.encStream = (Stream) new DigestStream((Stream) this.truncStream, PgpUtilities.CreateDigest(HashAlgorithmTag.Sha1), (IDigest) null);
      }
      if (Streams.ReadFully(this.encStream, numArray, 0, numArray.Length) < numArray.Length)
        throw new EndOfStreamException("unexpected end of stream.");
      int num1 = this.encStream.ReadByte();
      int num2 = this.encStream.ReadByte();
      if (num1 < 0 || num2 < 0)
        throw new EndOfStreamException("unexpected end of stream.");
      int num3 = (int) numArray[numArray.Length - 2] != (int) (byte) num1 ? 0 : ((int) numArray[numArray.Length - 1] == (int) (byte) num2 ? 1 : 0);
      bool flag = num1 == 0 && num2 == 0;
      if (num3 == 0 && !flag)
        throw new PgpDataValidationException("quick check failed.");
      return this.encStream;
    }
    catch (PgpException ex)
    {
      throw;
    }
    catch (Exception ex)
    {
      throw new PgpException("Exception creating cipher", ex);
    }
  }

  private IBufferedCipher CreateStreamCipher(SymmetricKeyAlgorithmTag keyAlgorithm)
  {
    string str = this.encData is SymmetricEncIntegrityPacket ? "CFB" : "OpenPGPCFB";
    return CipherUtilities.GetCipher($"{PgpUtilities.GetSymmetricCipherName(keyAlgorithm)}/{str}/NoPadding");
  }
}
