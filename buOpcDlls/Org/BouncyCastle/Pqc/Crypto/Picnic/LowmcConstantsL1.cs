// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Picnic.LowmcConstantsL1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.IO.Compression;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Picnic;

internal class LowmcConstantsL1 : LowmcConstants
{
  public LowmcConstantsL1()
  {
    this._matrixToHex = new Dictionary<string, string>();
    using (Stream manifestResourceStream = typeof (LowmcConstants).Assembly.GetManifestResourceStream("Org.BouncyCastle.pqc.crypto.picnic.lowmcL1.bz2"))
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
    this.linearMatrices = LowmcConstants.ReadFromProperty(this._matrixToHex["linearMatrices"], 40960 /*0xA000*/);
    this.roundConstants = LowmcConstants.ReadFromProperty(this._matrixToHex["roundConstants"], 320);
    this.keyMatrices = LowmcConstants.ReadFromProperty(this._matrixToHex["keyMatrices"], 43008);
    this._LMatrix = new KMatrices(20, 128 /*0x80*/, 4, this.linearMatrices);
    this._KMatrix = new KMatrices(21, 128 /*0x80*/, 4, this.keyMatrices);
    this.RConstants = new KMatrices(0, 1, 4, this.roundConstants);
    this.linearMatrices_full = LowmcConstants.ReadFromProperty(this._matrixToHex["linearMatrices_full"], 12800);
    this.keyMatrices_full = LowmcConstants.ReadFromProperty(this._matrixToHex["keyMatrices_full"], 12900);
    this.keyMatrices_inv = LowmcConstants.ReadFromProperty(this._matrixToHex["keyMatrices_inv"], 2850);
    this.linearMatrices_inv = LowmcConstants.ReadFromProperty(this._matrixToHex["linearMatrices_inv"], 12800);
    this.roundConstants_full = LowmcConstants.ReadFromProperty(this._matrixToHex["roundConstants_full"], 80 /*0x50*/);
    this.LMatrix_full = new KMatrices(4, 129, 5, this.linearMatrices_full);
    this.LMatrix_inv = new KMatrices(4, 129, 5, this.linearMatrices_inv);
    this.KMatrix_full = new KMatrices(5, 129, 5, this.keyMatrices_full);
    this.KMatrix_inv = new KMatrices(1, 129, 5, this.keyMatrices_inv);
    this.RConstants_full = new KMatrices(4, 1, 5, this.roundConstants_full);
  }
}
