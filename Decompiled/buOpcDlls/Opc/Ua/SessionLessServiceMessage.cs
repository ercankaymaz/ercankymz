using System;
using System.Runtime.InteropServices;

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
		encoder.WriteUInt32("UriVersion", UriVersion);
		if (NamespaceUris != null && NamespaceUris.Count > 1)
		{
			string[] array = new string[NamespaceUris.Count - 1];
			for (int i = 1; i < NamespaceUris.Count; i++)
			{
				array[i - 1] = NamespaceUris.GetString((uint)i);
			}
			encoder.WriteStringArray("NamespaceUris", array);
		}
		else
		{
			encoder.WriteStringArray("NamespaceUris", Array.Empty<string>());
		}
		if (ServerUris != null && ServerUris.Count > 1)
		{
			string[] array2 = new string[ServerUris.Count - 1];
			for (int j = 1; j < ServerUris.Count; j++)
			{
				array2[j - 1] = ServerUris.GetString((uint)j);
			}
			encoder.WriteStringArray("ServerUris", array2);
		}
		else
		{
			encoder.WriteStringArray("ServerUris", Array.Empty<string>());
		}
		if (LocaleIds != null && LocaleIds.Count > 1)
		{
			encoder.WriteStringArray("LocaleIds", LocaleIds.ToArray());
		}
		else
		{
			encoder.WriteStringArray("LocaleIds", Array.Empty<string>());
		}
		if (Message != null)
		{
			encoder.SetMappingTables(NamespaceUris, ServerUris);
			if (Message.TypeId == null || Message.TypeId.IdType != IdType.Numeric)
			{
				throw ServiceResultException.Create(2147876864u, "SessionLessServiceMessage message body must have a numeric TypeId defined. ({0})", Message.TypeId);
			}
			encoder.WriteUInt32("ServiceId", (uint)Message.TypeId.Identifier);
			encoder.WriteEncodeable("Body", Message, null);
		}
		else
		{
			encoder.WriteUInt32("TypeId", 0u);
		}
	}

	public void Decode(IDecoder decoder)
	{
		UriVersion = decoder.ReadUInt32("UriVersion");
		NamespaceUris = new NamespaceTable();
		StringCollection stringCollection = decoder.ReadStringArray("NamespaceUris");
		if (stringCollection != null && stringCollection.Count > 0)
		{
			foreach (string item in stringCollection)
			{
				NamespaceUris.Append(item);
			}
		}
		ServerUris = new StringTable();
		stringCollection = decoder.ReadStringArray("ServerUris");
		if (stringCollection != null && stringCollection.Count > 0)
		{
			foreach (string item2 in stringCollection)
			{
				ServerUris.Append(item2);
			}
		}
		LocaleIds = new StringTable();
		stringCollection = decoder.ReadStringArray("LocaleIds");
		if (stringCollection != null && stringCollection.Count > 0)
		{
			foreach (string item3 in stringCollection)
			{
				LocaleIds.Append(item3);
			}
		}
		decoder.SetMappingTables(NamespaceUris, ServerUris);
		uint num = decoder.ReadUInt32("ServiceId");
		if (num != 0)
		{
			Type systemType = decoder.Context.Factory.GetSystemType(new ExpandedNodeId(num, 0));
			if (systemType == null)
			{
				throw ServiceResultException.Create(2147942400u, "SessionLessServiceMessage message body has an unknown TypeId. {0}", num);
			}
			Message = decoder.ReadEncodeable("Body", systemType);
		}
	}
}
