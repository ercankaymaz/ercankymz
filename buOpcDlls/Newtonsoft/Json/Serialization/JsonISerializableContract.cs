// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Serialization.JsonISerializableContract
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Serialization;

public class JsonISerializableContract : JsonContainerContract
{
  [field: Nullable(new byte[] {2, 1})]
  [Nullable(new byte[] {2, 1})]
  public ObjectConstructor<object> ISerializableCreator { [return: Nullable(new byte[] {2, 1})] get; [param: Nullable(new byte[] {2, 1})] set; }

  [NullableContext(1)]
  public JsonISerializableContract(Type underlyingType)
    : base(underlyingType)
  {
    this.ContractType = JsonContractType.Serializable;
  }
}
