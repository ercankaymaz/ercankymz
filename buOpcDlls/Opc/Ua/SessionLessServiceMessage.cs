// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SessionLessServiceMessage
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class SessionLessServiceMessage
{
  public uint UriVersion;
  public NamespaceTable NamespaceUris;
  public StringTable ServerUris;
  public StringTable LocaleIds;
  public IEncodeable Message;

  public void Encode(IEncoder encoder)
  {
    encoder.WriteUInt32("UriVersion", this.UriVersion);
    if (this.NamespaceUris != null && this.NamespaceUris.Count > 1)
    {
      string[] values = new string[this.NamespaceUris.Count - 1];
      for (int index = 1; index < this.NamespaceUris.Count; ++index)
        values[index - 1] = this.NamespaceUris.GetString((uint) index);
      encoder.WriteStringArray("NamespaceUris", (IList<string>) values);
    }
    else
      encoder.WriteStringArray("NamespaceUris", (IList<string>) Array.Empty<string>());
    if (this.ServerUris != null && this.ServerUris.Count > 1)
    {
      string[] values = new string[this.ServerUris.Count - 1];
      for (int index = 1; index < this.ServerUris.Count; ++index)
        values[index - 1] = this.ServerUris.GetString((uint) index);
      encoder.WriteStringArray("ServerUris", (IList<string>) values);
    }
    else
      encoder.WriteStringArray("ServerUris", (IList<string>) Array.Empty<string>());
    if (this.LocaleIds != null && this.LocaleIds.Count > 1)
      encoder.WriteStringArray("LocaleIds", (IList<string>) this.LocaleIds.ToArray());
    else
      encoder.WriteStringArray("LocaleIds", (IList<string>) Array.Empty<string>());
    if (this.Message != null)
    {
      encoder.SetMappingTables(this.NamespaceUris, this.ServerUris);
      if (!(this.Message.TypeId == (object) null) && this.Message.TypeId.IdType == IdType.Numeric)
      {
        encoder.WriteUInt32("ServiceId", (uint) this.Message.TypeId.Identifier);
        encoder.WriteEncodeable("Body", this.Message, (Type) null);
      }
      else
        throw ServiceResultException.Create(2147876864U /*0x80060000*/, "SessionLessServiceMessage message body must have a numeric TypeId defined. ({0})", (object) this.Message.TypeId);
    }
    else
      encoder.WriteUInt32("TypeId", 0U);
  }

  public void Decode(IDecoder decoder)
  {
    this.UriVersion = decoder.ReadUInt32("UriVersion");
    this.NamespaceUris = new NamespaceTable();
    StringCollection stringCollection1 = decoder.ReadStringArray("NamespaceUris");
    if (stringCollection1 != null && stringCollection1.Count > 0)
    {
      foreach (string str in (List<string>) stringCollection1)
        this.NamespaceUris.Append(str);
    }
    this.ServerUris = new StringTable();
    StringCollection stringCollection2 = decoder.ReadStringArray("ServerUris");
    if (stringCollection2 != null && stringCollection2.Count > 0)
    {
      foreach (string str in (List<string>) stringCollection2)
        this.ServerUris.Append(str);
    }
    this.LocaleIds = new StringTable();
    StringCollection stringCollection3 = decoder.ReadStringArray("LocaleIds");
    if (stringCollection3 != null && stringCollection3.Count > 0)
    {
      foreach (string str in (List<string>) stringCollection3)
        this.LocaleIds.Append(str);
    }
    decoder.SetMappingTables(this.NamespaceUris, this.ServerUris);
    uint num = decoder.ReadUInt32("ServiceId");
    if (num <= 0U)
      return;
    Type systemType = decoder.Context.Factory.GetSystemType(new ExpandedNodeId(num, (ushort) 0));
    this.Message = !(systemType == (Type) null) ? decoder.ReadEncodeable("Body", systemType) : throw ServiceResultException.Create(2147942400U /*0x80070000*/, "SessionLessServiceMessage message body has an unknown TypeId. {0}", (object) num);
  }
}
