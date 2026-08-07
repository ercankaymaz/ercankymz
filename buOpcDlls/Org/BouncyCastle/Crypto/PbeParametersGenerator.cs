// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.PbeParametersGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.Crypto;

public abstract class PbeParametersGenerator
{
  protected byte[] mPassword;
  protected byte[] mSalt;
  protected int mIterationCount;

  public virtual void Init(byte[] password, byte[] salt, int iterationCount)
  {
    if (password == null)
      throw new ArgumentNullException(nameof (password));
    if (salt == null)
      throw new ArgumentNullException(nameof (salt));
    this.mPassword = Arrays.Clone(password);
    this.mSalt = Arrays.Clone(salt);
    this.mIterationCount = iterationCount;
  }

  public virtual byte[] Password => Arrays.Clone(this.mPassword);

  public virtual byte[] Salt => Arrays.Clone(this.mSalt);

  public virtual int IterationCount => this.mIterationCount;

  public abstract ICipherParameters GenerateDerivedParameters(string algorithm, int keySize);

  public abstract ICipherParameters GenerateDerivedParameters(
    string algorithm,
    int keySize,
    int ivSize);

  public abstract ICipherParameters GenerateDerivedMacParameters(int keySize);

  public static byte[] Pkcs5PasswordToBytes(char[] password)
  {
    return password == null ? new byte[0] : Strings.ToByteArray(password);
  }

  public static byte[] Pkcs5PasswordToUtf8Bytes(char[] password)
  {
    return password == null ? new byte[0] : Strings.ToUtf8ByteArray(password);
  }

  public static byte[] Pkcs12PasswordToBytes(char[] password)
  {
    return PbeParametersGenerator.Pkcs12PasswordToBytes(password, false);
  }

  public static byte[] Pkcs12PasswordToBytes(char[] password, bool wrongPkcs12Zero)
  {
    if (password == null || password.Length < 1)
      return new byte[wrongPkcs12Zero ? 2 : 0];
    byte[] bytes = new byte[(password.Length + 1) * 2];
    Encoding.BigEndianUnicode.GetBytes(password, 0, password.Length, bytes, 0);
    return bytes;
  }
}
