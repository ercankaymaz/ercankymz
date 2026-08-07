// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.OidTokenizer
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class OidTokenizer
{
  private string oid;
  private int index;

  public OidTokenizer(string oid) => this.oid = oid;

  public bool HasMoreTokens => this.index != -1;

  public string NextToken()
  {
    if (this.index == -1)
      return (string) null;
    int num = this.oid.IndexOf('.', this.index);
    if (num == -1)
    {
      string str = this.oid.Substring(this.index);
      this.index = -1;
      return str;
    }
    string str1 = this.oid.Substring(this.index, num - this.index);
    this.index = num + 1;
    return str1;
  }
}
