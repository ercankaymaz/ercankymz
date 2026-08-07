// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.X509NameTokenizer
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Text;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class X509NameTokenizer
{
  private string value;
  private int index;
  private char separator;
  private StringBuilder buffer = new StringBuilder();

  public X509NameTokenizer(string oid)
    : this(oid, ',')
  {
  }

  public X509NameTokenizer(string oid, char separator)
  {
    this.value = oid;
    this.index = -1;
    this.separator = separator;
  }

  public bool HasMoreTokens() => this.index != this.value.Length;

  public string NextToken()
  {
    if (this.index == this.value.Length)
      return (string) null;
    int index = this.index + 1;
    bool flag1 = false;
    bool flag2 = false;
    this.buffer.Remove(0, this.buffer.Length);
    for (; index != this.value.Length; ++index)
    {
      char ch = this.value[index];
      if (ch == '"')
      {
        if (!flag2)
        {
          flag1 = !flag1;
        }
        else
        {
          this.buffer.Append(ch);
          flag2 = false;
        }
      }
      else if (flag2 | flag1)
      {
        if (ch == '#' && this.buffer[this.buffer.Length - 1] == '=')
          this.buffer.Append('\\');
        else if (ch == '+' && this.separator != '+')
          this.buffer.Append('\\');
        this.buffer.Append(ch);
        flag2 = false;
      }
      else if (ch == '\\')
        flag2 = true;
      else if ((int) ch != (int) this.separator)
        this.buffer.Append(ch);
      else
        break;
    }
    this.index = index;
    return this.buffer.ToString().Trim();
  }
}
