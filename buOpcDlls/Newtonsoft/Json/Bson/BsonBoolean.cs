// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Bson.BsonBoolean
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Newtonsoft.Json.Bson;

internal class BsonBoolean : BsonValue
{
  public static readonly BsonBoolean False = new BsonBoolean(false);
  public static readonly BsonBoolean True = new BsonBoolean(true);

  private BsonBoolean(bool value)
    : base((object) value, BsonType.Boolean)
  {
  }
}
