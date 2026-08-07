// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Serialization.SerializationCallback
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.Serialization;

#nullable disable
namespace Newtonsoft.Json.Serialization;

public delegate void SerializationCallback(object o, StreamingContext context);
