using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml;

namespace Opc.Ua;

[DataContract(Name = "EncodeableObject", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public abstract class EncodeableObject : IEncodeable, ICloneable
{
	public abstract ExpandedNodeId TypeId { get; }

	public abstract ExpandedNodeId BinaryEncodingId { get; }

	public abstract ExpandedNodeId XmlEncodingId { get; }

	public virtual void Encode(IEncoder encoder)
	{
	}

	public virtual void Decode(IDecoder decoder)
	{
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		throw new NotImplementedException("Subclass must implement this method.");
	}

	public static ServiceResult ApplyDataEncoding(IServiceMessageContext context, QualifiedName dataEncoding, ref object value)
	{
		if (QualifiedName.IsNull(dataEncoding) || value == null)
		{
			return ServiceResult.Good;
		}
		if (dataEncoding.NamespaceIndex != 0)
		{
			return 2151219200u;
		}
		bool flag = dataEncoding.Name == "Default XML";
		if (!flag && dataEncoding.Name != "Default Binary")
		{
			return 2151153664u;
		}
		try
		{
			IList<IEncodeable> list = value as IList<IEncodeable>;
			if (list == null && value is IList<ExtensionObject> list2)
			{
				list = new IEncodeable[list2.Count];
				for (int i = 0; i < list.Count; i++)
				{
					if (ExtensionObject.IsNull(list2[i]))
					{
						list[i] = null;
						continue;
					}
					if (!(list2[i].Body is IEncodeable value2))
					{
						return 2155085824u;
					}
					list[i] = value2;
				}
			}
			if (list != null)
			{
				ExtensionObject[] array = new ExtensionObject[list.Count];
				for (int j = 0; j < array.Length; j++)
				{
					array[j] = Encode(context, list[j], flag);
				}
				value = array;
				return ServiceResult.Good;
			}
			IEncodeable encodeable = value as IEncodeable;
			if (encodeable == null)
			{
				if (!(value is ExtensionObject extensionObject))
				{
					return 2151219200u;
				}
				encodeable = extensionObject.Body as IEncodeable;
			}
			if (encodeable == null)
			{
				return 2151219200u;
			}
			value = Encode(context, encodeable, flag);
			return ServiceResult.Good;
		}
		catch (Exception e)
		{
			return ServiceResult.Create(e, 2155085824u, "Could not convert value to requested format.");
		}
	}

	public static ExtensionObject Encode(IServiceMessageContext context, IEncodeable encodeable, bool useXml)
	{
		if (useXml)
		{
			XmlElement body = EncodeXml(encodeable, context);
			return new ExtensionObject(encodeable.XmlEncodingId, body);
		}
		byte[] body2 = EncodeBinary(encodeable, context);
		return new ExtensionObject(encodeable.BinaryEncodingId, body2);
	}

	public static XmlElement EncodeXml(IEncodeable encodeable, IServiceMessageContext context)
	{
		using XmlEncoder xmlEncoder = new XmlEncoder(context);
		xmlEncoder.WriteExtensionObjectBody(encodeable);
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadInnerXml(xmlEncoder.CloseAndReturnText());
		return xmlDocument.DocumentElement;
	}

	public static byte[] EncodeBinary(IEncodeable encodeable, IServiceMessageContext context)
	{
		using BinaryEncoder binaryEncoder = new BinaryEncoder(context);
		binaryEncoder.WriteEncodeable(null, encodeable, null);
		return binaryEncoder.CloseAndReturnBuffer();
	}

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		return base.MemberwiseClone();
	}
}
