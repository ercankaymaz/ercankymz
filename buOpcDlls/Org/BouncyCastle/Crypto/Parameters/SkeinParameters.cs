// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.SkeinParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class SkeinParameters : ICipherParameters
{
  public const int PARAM_TYPE_KEY = 0;
  public const int PARAM_TYPE_CONFIG = 4;
  public const int PARAM_TYPE_PERSONALISATION = 8;
  public const int PARAM_TYPE_PUBLIC_KEY = 12;
  public const int PARAM_TYPE_KEY_IDENTIFIER = 16 /*0x10*/;
  public const int PARAM_TYPE_NONCE = 20;
  public const int PARAM_TYPE_MESSAGE = 48 /*0x30*/;
  public const int PARAM_TYPE_OUTPUT = 63 /*0x3F*/;
  private IDictionary<int, byte[]> m_parameters;

  public SkeinParameters()
    : this((IDictionary<int, byte[]>) new Dictionary<int, byte[]>())
  {
  }

  private SkeinParameters(IDictionary<int, byte[]> parameters) => this.m_parameters = parameters;

  public IDictionary<int, byte[]> GetParameters() => this.m_parameters;

  public byte[] GetKey() => CollectionUtilities.GetValueOrNull<int, byte[]>(this.m_parameters, 0);

  public byte[] GetPersonalisation()
  {
    return CollectionUtilities.GetValueOrNull<int, byte[]>(this.m_parameters, 8);
  }

  public byte[] GetPublicKey()
  {
    return CollectionUtilities.GetValueOrNull<int, byte[]>(this.m_parameters, 12);
  }

  public byte[] GetKeyIdentifier()
  {
    return CollectionUtilities.GetValueOrNull<int, byte[]>(this.m_parameters, 16 /*0x10*/);
  }

  public byte[] GetNonce()
  {
    return CollectionUtilities.GetValueOrNull<int, byte[]>(this.m_parameters, 20);
  }

  public class Builder
  {
    private Dictionary<int, byte[]> m_parameters;

    public Builder() => this.m_parameters = new Dictionary<int, byte[]>();

    public Builder(IDictionary<int, byte[]> paramsMap)
    {
      this.m_parameters = new Dictionary<int, byte[]>(paramsMap);
    }

    public Builder(SkeinParameters parameters)
      : this(parameters.m_parameters)
    {
    }

    public SkeinParameters.Builder Set(int type, byte[] value)
    {
      if (value == null)
        throw new ArgumentException("Parameter value must not be null.");
      if (type != 0 && (type <= 4 || type >= 63 /*0x3F*/ || type == 48 /*0x30*/))
        throw new ArgumentException("Parameter types must be in the range 0,5..47,49..62.");
      if (type == 4)
        throw new ArgumentException($"Parameter type {4.ToString()} is reserved for internal use.");
      this.m_parameters.Add(type, value);
      return this;
    }

    public SkeinParameters.Builder SetKey(byte[] key) => this.Set(0, key);

    public SkeinParameters.Builder SetPersonalisation(byte[] personalisation)
    {
      return this.Set(8, personalisation);
    }

    public SkeinParameters.Builder SetPersonalisation(
      DateTime date,
      string emailAddress,
      string distinguisher)
    {
      try
      {
        MemoryStream memoryStream = new MemoryStream();
        using (StreamWriter streamWriter = new StreamWriter((Stream) memoryStream, Encoding.UTF8))
        {
          streamWriter.Write(date.ToString("YYYYMMDD", (IFormatProvider) CultureInfo.InvariantCulture));
          streamWriter.Write(" ");
          streamWriter.Write(emailAddress);
          streamWriter.Write(" ");
          streamWriter.Write(distinguisher);
        }
        return this.Set(8, memoryStream.ToArray());
      }
      catch (IOException ex)
      {
        throw new InvalidOperationException("Byte I/O failed.", (Exception) ex);
      }
    }

    public SkeinParameters.Builder SetPublicKey(byte[] publicKey) => this.Set(12, publicKey);

    public SkeinParameters.Builder SetKeyIdentifier(byte[] keyIdentifier)
    {
      return this.Set(16 /*0x10*/, keyIdentifier);
    }

    public SkeinParameters.Builder SetNonce(byte[] nonce) => this.Set(20, nonce);

    public SkeinParameters Build()
    {
      return new SkeinParameters((IDictionary<int, byte[]>) this.m_parameters);
    }
  }
}
