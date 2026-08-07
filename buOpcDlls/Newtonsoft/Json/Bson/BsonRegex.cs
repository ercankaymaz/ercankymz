// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Bson.BsonRegex
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Newtonsoft.Json.Bson;

internal class BsonRegex : BsonToken
{
  public BsonString Pattern { get; set; }

  public BsonString Options { get; set; }

  public BsonRegex(string pattern, string options)
  {
    this.Pattern = new BsonString((object) pattern, false);
    this.Options = new BsonString((object) options, false);
  }

  public override BsonType Type => BsonType.Regex;
}
