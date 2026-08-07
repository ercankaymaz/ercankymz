// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.JsonExtensionDataAttribute
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Newtonsoft.Json;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class JsonExtensionDataAttribute : Attribute
{
  public bool WriteData { get; set; }

  public bool ReadData { get; set; }

  public JsonExtensionDataAttribute()
  {
    this.WriteData = true;
    this.ReadData = true;
  }
}
