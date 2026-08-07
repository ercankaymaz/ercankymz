// Decompiled with JetBrains decompiler
// Type: Opc.Ua.EncodeableObject
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml;

#nullable disable
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

  public static ServiceResult ApplyDataEncoding(
    IServiceMessageContext context,
    QualifiedName dataEncoding,
    ref object value)
  {
    if (QualifiedName.IsNull(dataEncoding) || value == null)
      return ServiceResult.Good;
    if (dataEncoding.NamespaceIndex != (ushort) 0)
      return (ServiceResult) 2151219200U /*0x80390000*/;
    bool useXml;
    if (!(useXml = dataEncoding.Name == "Default XML") && dataEncoding.Name != "Default Binary")
      return (ServiceResult) 2151153664U /*0x80380000*/;
    try
    {
      if (!(value is IList<IEncodeable> encodeableList) && value is IList<ExtensionObject> extensionObjectList)
      {
        encodeableList = (IList<IEncodeable>) new IEncodeable[extensionObjectList.Count];
        for (int index = 0; index < encodeableList.Count; ++index)
        {
          if (ExtensionObject.IsNull(extensionObjectList[index]))
          {
            encodeableList[index] = (IEncodeable) null;
          }
          else
          {
            if (!(extensionObjectList[index].Body is IEncodeable body))
              return (ServiceResult) 2155085824U /*0x80740000*/;
            encodeableList[index] = body;
          }
        }
      }
      if (encodeableList != null)
      {
        ExtensionObject[] extensionObjectArray = new ExtensionObject[encodeableList.Count];
        for (int index = 0; index < extensionObjectArray.Length; ++index)
          extensionObjectArray[index] = EncodeableObject.Encode(context, encodeableList[index], useXml);
        value = (object) extensionObjectArray;
        return ServiceResult.Good;
      }
      if (!(value is IEncodeable encodeable))
      {
        if (!(value is ExtensionObject extensionObject))
          return (ServiceResult) 2151219200U /*0x80390000*/;
        encodeable = extensionObject.Body as IEncodeable;
      }
      if (encodeable == null)
        return (ServiceResult) 2151219200U /*0x80390000*/;
      value = (object) EncodeableObject.Encode(context, encodeable, useXml);
      return ServiceResult.Good;
    }
    catch (Exception ex)
    {
      object[] objArray = Array.Empty<object>();
      return ServiceResult.Create(ex, 2155085824U /*0x80740000*/, "Could not convert value to requested format.", objArray);
    }
  }

  public static ExtensionObject Encode(
    IServiceMessageContext context,
    IEncodeable encodeable,
    bool useXml)
  {
    if (useXml)
    {
      XmlElement body = EncodeableObject.EncodeXml(encodeable, context);
      return new ExtensionObject(encodeable.XmlEncodingId, (object) body);
    }
    byte[] body1 = EncodeableObject.EncodeBinary(encodeable, context);
    return new ExtensionObject(encodeable.BinaryEncodingId, (object) body1);
  }

  public static XmlElement EncodeXml(IEncodeable encodeable, IServiceMessageContext context)
  {
    using (XmlEncoder xmlEncoder = new XmlEncoder(context))
    {
      xmlEncoder.WriteExtensionObjectBody((object) encodeable);
      XmlDocument doc = new XmlDocument();
      doc.LoadInnerXml(xmlEncoder.CloseAndReturnText());
      return doc.DocumentElement;
    }
  }

  public static byte[] EncodeBinary(IEncodeable encodeable, IServiceMessageContext context)
  {
    using (BinaryEncoder binaryEncoder = new BinaryEncoder(context))
    {
      binaryEncoder.WriteEncodeable((string) null, encodeable, (Type) null);
      return binaryEncoder.CloseAndReturnBuffer();
    }
  }

  public virtual object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone() => base.MemberwiseClone();
}
