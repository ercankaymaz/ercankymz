// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tsp.GenTimeAccuracy
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Tsp;

#nullable disable
namespace Org.BouncyCastle.Tsp;

public class GenTimeAccuracy
{
  private Accuracy accuracy;

  public GenTimeAccuracy(Accuracy accuracy) => this.accuracy = accuracy;

  public int Seconds => this.GetTimeComponent(this.accuracy.Seconds);

  public int Millis => this.GetTimeComponent(this.accuracy.Millis);

  public int Micros => this.GetTimeComponent(this.accuracy.Micros);

  private int GetTimeComponent(DerInteger time) => time != null ? time.IntValueExact : 0;

  public override string ToString()
  {
    int num = this.Seconds;
    string str1 = num.ToString();
    num = this.Millis;
    string str2 = num.ToString("000");
    num = this.Micros;
    string str3 = num.ToString("000");
    return $"{str1}.{str2}{str3}";
  }
}
