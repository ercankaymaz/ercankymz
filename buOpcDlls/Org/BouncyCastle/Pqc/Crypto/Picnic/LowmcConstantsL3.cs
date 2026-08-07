// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Picnic.LowmcConstantsL3
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.IO.Compression;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Picnic;

internal class LowmcConstantsL3 : LowmcConstants
{
  public LowmcConstantsL3()
  {
    this._matrixToHex = new Dictionary<string, string>();
    using (Stream manifestResourceStream = typeof (LowmcConstants).Assembly.GetManifestResourceStream("Org.BouncyCastle.pqc.crypto.picnic.lowmcL3.bz2"))
    {
      using (StreamReader streamReader = new StreamReader(Bzip2.DecompressInput(manifestResourceStream)))
      {
        for (string str1 = streamReader.ReadLine(); str1 != null; str1 = streamReader.ReadLine())
        {
          string str2 = str1;
          if (str2 != "")
          {
            string str3 = str2.Replace(",", "");
            int length = str3.IndexOf('=');
            this._matrixToHex.Add(str3.Substring(0, length).Trim(), str3.Substring(length + 1).Trim());
          }
        }
      }
    }
    this.linearMatrices = LowmcConstants.ReadFromProperty(this._matrixToHex["linearMatrices"], 138240);
    this.roundConstants = LowmcConstants.ReadFromProperty(this._matrixToHex["roundConstants"], 720);
    this.keyMatrices = LowmcConstants.ReadFromProperty(this._matrixToHex["keyMatrices"], 142848);
    this._LMatrix = new KMatrices(30, 192 /*0xC0*/, 6, this.linearMatrices);
    this._KMatrix = new KMatrices(31 /*0x1F*/, 192 /*0xC0*/, 6, this.keyMatrices);
    this.RConstants = new KMatrices(30, 1, 6, this.roundConstants);
    this.linearMatrices_full = LowmcConstants.ReadFromProperty(this._matrixToHex["linearMatrices_full"], 18432);
    this.linearMatrices_inv = LowmcConstants.ReadFromProperty(this._matrixToHex["linearMatrices_inv"], 18432);
    this.roundConstants_full = LowmcConstants.ReadFromProperty(this._matrixToHex["roundConstants_full"], 96 /*0x60*/);
    this.keyMatrices_full = LowmcConstants.ReadFromProperty(this._matrixToHex["keyMatrices_full"], 23040);
    this.keyMatrices_inv = LowmcConstants.ReadFromProperty(this._matrixToHex["keyMatrices_inv"], 4608);
    this.LMatrix_full = new KMatrices(4, 192 /*0xC0*/, 6, this.linearMatrices_full);
    this.LMatrix_inv = new KMatrices(4, 192 /*0xC0*/, 6, this.linearMatrices_inv);
    this.KMatrix_full = new KMatrices(5, 192 /*0xC0*/, 6, this.keyMatrices_full);
    this.KMatrix_inv = new KMatrices(1, 192 /*0xC0*/, 6, this.keyMatrices_inv);
    this.RConstants_full = new KMatrices(4, 1, 6, this.roundConstants_full);
  }
}
