// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Bson.BsonEmpty
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Newtonsoft.Json.Bson;

internal class BsonEmpty : BsonToken
{
  public static readonly BsonToken Null = (BsonToken) new BsonEmpty(BsonType.Null);
  public static readonly BsonToken Undefined = (BsonToken) new BsonEmpty(BsonType.Undefined);

  private BsonEmpty(BsonType type) => this.Type = type;

  public override BsonType Type { get; }
}
