// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.OpenSsl.PemWriter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.IO.Pem;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.OpenSsl;

public class PemWriter(TextWriter writer) : Org.BouncyCastle.Utilities.IO.Pem.PemWriter(writer)
{
  public void WriteObject(object obj)
  {
    this.WriteObject(obj, (string) null, (char[]) null, (SecureRandom) null);
  }

  public void WriteObject(object obj, string algorithm, char[] password, SecureRandom random)
  {
    try
    {
      this.WriteObject((PemObjectGenerator) new MiscPemGenerator(obj, algorithm, password, random));
    }
    catch (PemGenerationException ex)
    {
      if (ex.InnerException is IOException innerException)
        throw innerException;
      throw;
    }
  }
}
