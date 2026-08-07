// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ExtensionObject
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

#nullable disable
namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ExtensionObject : IFormattable, ICloneable
{
  private static readonly ExtensionObject s_Null = new ExtensionObject();
  private ExpandedNodeId m_typeId;
  private ExtensionObjectEncoding m_encoding;
  private object m_body;
  private IServiceMessageContext m_context;

  public ExtensionObject()
  {
    this.m_typeId = ExpandedNodeId.Null;
    this.m_encoding = ExtensionObjectEncoding.None;
    this.m_body = (object) null;
    this.m_context = MessageContextExtension.CurrentContext;
  }

  public ExtensionObject(ExtensionObject value)
  {
    this.TypeId = value != null ? value.TypeId : throw new ArgumentNullException(nameof (value));
    this.Body = Utils.Clone(value.Body);
  }

  public ExtensionObject(ExpandedNodeId typeId)
  {
    this.TypeId = typeId;
    this.Body = (object) null;
  }

  public ExtensionObject(object body)
    : this(ExpandedNodeId.Null, body)
  {
  }

  public ExtensionObject(ExpandedNodeId typeId, object body)
  {
    this.TypeId = typeId;
    this.Body = body;
  }

  [OnSerializing]
  private void UpdateContext(StreamingContext context)
  {
    this.m_context = MessageContextExtension.CurrentContext;
  }

  [OnDeserializing]
  private void Initialize(StreamingContext context)
  {
    this.m_typeId = ExpandedNodeId.Null;
    this.m_encoding = ExtensionObjectEncoding.None;
    this.m_body = (object) null;
    this.m_context = MessageContextExtension.CurrentContext;
  }

  public ExpandedNodeId TypeId
  {
    get => this.m_typeId;
    set => this.m_typeId = value;
  }

  public ExtensionObjectEncoding Encoding => this.m_encoding;

  public object Body
  {
    get => this.m_body;
    set
    {
      this.m_body = value;
      if (this.m_body == null)
        this.m_encoding = ExtensionObjectEncoding.None;
      else if (this.m_body is IEncodeable)
        this.m_encoding = ExtensionObjectEncoding.EncodeableObject;
      else if (this.m_body is byte[])
      {
        this.m_encoding = ExtensionObjectEncoding.Binary;
      }
      else
      {
        if (!(this.m_body is XmlElement))
          throw new ServiceResultException(2151481344U /*0x803D0000*/, Utils.Format("Cannot add a object with type '{0}' to an extension object.", (object) this.m_body.GetType().FullName));
        this.m_encoding = ExtensionObjectEncoding.Xml;
      }
    }
  }

  public override bool Equals(object obj)
  {
    if (obj == null)
      return ExtensionObject.IsNull(this);
    if (this == obj)
      return true;
    return obj is ExtensionObject extensionObject && !(this.m_typeId != (object) extensionObject.m_typeId) && Utils.IsEqual(this.m_body, extensionObject.m_body);
  }

  public override int GetHashCode()
  {
    if (this.m_body != null)
      return this.m_body.GetHashCode();
    return this.m_typeId != (object) null ? this.m_typeId.GetHashCode() : 0;
  }

  public override string ToString() => this.ToString((string) null, (IFormatProvider) null);

  public string ToString(string format, IFormatProvider formatProvider)
  {
    if (format == null)
    {
      if (this.m_body is byte[] body1)
        return string.Format(formatProvider, "Byte[{0}]", (object) body1.Length);
      if (this.m_body is XmlElement body2)
        return string.Format(formatProvider, "<{0}>", (object) body2.Name);
      if (this.m_body is IFormattable body3)
        return string.Format(formatProvider, "{0}", (object) body3.ToString((string) null, formatProvider));
      if (this.m_body is IEncodeable)
      {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (PropertyInfo property in this.m_body.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy))
        {
          foreach (object obj in ((IEnumerable<object>) property.GetCustomAttributes(typeof (DataMemberAttribute), true)).ToArray<object>())
          {
            if (obj is DataMemberAttribute)
            {
              if (stringBuilder.Length == 0)
                stringBuilder.Append('{');
              else
                stringBuilder.Append(" | ");
              stringBuilder.AppendFormat("{0}", property.GetGetMethod().Invoke(this.m_body, (object[]) null));
            }
          }
        }
        if (stringBuilder.Length > 0)
          stringBuilder.Append('}');
        return string.Format(formatProvider, "{0}", (object) stringBuilder);
      }
      return !NodeId.IsNull(this.m_typeId) ? string.Format(formatProvider, "{{{0}}}", (object) this.m_typeId) : "(null)";
    }
    throw new FormatException(Utils.Format("Invalid format string: '{0}'.", (object) format));
  }

  public virtual object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone() => (object) new ExtensionObject(this);

  public static bool IsNull(ExtensionObject extension)
  {
    return extension == null || extension.m_body == null;
  }

  public static IEncodeable ToEncodeable(ExtensionObject extension)
  {
    return extension == null ? (IEncodeable) null : extension.Body as IEncodeable;
  }

  public static Array ToArray(object source, Type elementType)
  {
    if (!(source is Array array))
      return (Array) null;
    Array instance = Array.CreateInstance(elementType, array.Length);
    for (int index = 0; index < instance.Length; ++index)
    {
      IEncodeable encodeable = ExtensionObject.ToEncodeable(array.GetValue(index) as ExtensionObject);
      if (elementType.IsInstanceOfType((object) encodeable))
        instance.SetValue((object) encodeable, index);
    }
    return instance;
  }

  public static List<T> ToList<T>(object source) where T : class
  {
    if (!(source is Array array))
      return (List<T>) null;
    List<T> list = new List<T>();
    for (int index = 0; index < array.Length; ++index)
    {
      IEncodeable encodeable = ExtensionObject.ToEncodeable(array.GetValue(index) as ExtensionObject);
      if (typeof (T).IsInstanceOfType((object) encodeable))
        list.Add((T) encodeable);
      else
        list.Add(default (T));
    }
    return list;
  }

  public static ExtensionObject Null => ExtensionObject.s_Null;

  [DataMember(Name = "TypeId", Order = 1, IsRequired = false, EmitDefaultValue = true)]
  private NodeId XmlEncodedTypeId
  {
    get
    {
      if (this.m_body is IEncodeable body)
        return ExpandedNodeId.ToNodeId(body.XmlEncodingId, this.m_context.NamespaceUris);
      return this.m_typeId.IsNull ? NodeId.Null : ExpandedNodeId.ToNodeId(this.m_typeId, this.m_context.NamespaceUris);
    }
    set => this.m_typeId = NodeId.ToExpandedNodeId(value, this.m_context.NamespaceUris);
  }

  [DataMember(Name = "Body", Order = 2, IsRequired = false, EmitDefaultValue = true)]
  private XmlElement XmlEncodedBody
  {
    get
    {
      if (this.m_body == null)
        return (XmlElement) null;
      using (XmlEncoder xmlEncoder = new XmlEncoder(this.m_context))
      {
        xmlEncoder.WriteExtensionObjectBody(this.m_body);
        XmlDocument doc = new XmlDocument();
        doc.LoadInnerXml(xmlEncoder.CloseAndReturnText());
        return doc.DocumentElement;
      }
    }
    set
    {
      if (value == null)
      {
        this.Body = (object) null;
      }
      else
      {
        XmlDecoder xmlDecoder = new XmlDecoder(value, this.m_context);
        this.Body = xmlDecoder.ReadExtensionObjectBody(this.m_typeId);
        if (this.m_body is IEncodeable)
          this.m_typeId = ExpandedNodeId.Null;
        try
        {
          xmlDecoder.Close(true);
        }
        catch (Exception ex)
        {
          throw new ServiceResultException(2147942400U /*0x80070000*/, Utils.Format("Did not read all of a extension object body: '{0}'", (object) this.m_typeId), ex);
        }
      }
    }
  }
}
