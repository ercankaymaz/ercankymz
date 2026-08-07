// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ExpandedNodeId
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;

#nullable disable
namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ExpandedNodeId : ICloneable, IComparable, IEquatable<ExpandedNodeId>, IFormattable
{
  private const string kHexDigits = "0123456789ABCDEF";
  private static readonly ExpandedNodeId s_Null = new ExpandedNodeId();
  private NodeId m_nodeId;
  private string m_namespaceUri;
  private uint m_serverIndex;

  internal ExpandedNodeId() => this.Initialize();

  public ExpandedNodeId(ExpandedNodeId value)
  {
    this.m_namespaceUri = !(value == (object) null) ? value.m_namespaceUri : throw new ArgumentNullException(nameof (value));
    if (!(value.m_nodeId != (object) null))
      return;
    this.m_nodeId = new NodeId(value.m_nodeId);
  }

  public ExpandedNodeId(NodeId nodeId)
  {
    this.Initialize();
    if (!(nodeId != (object) null))
      return;
    this.m_nodeId = new NodeId(nodeId);
  }

  public ExpandedNodeId(
    object identifier,
    ushort namespaceIndex,
    string namespaceUri,
    uint serverIndex)
  {
    this.m_nodeId = new NodeId(identifier, namespaceIndex);
    this.m_namespaceUri = namespaceUri;
    this.m_serverIndex = serverIndex;
  }

  public ExpandedNodeId(NodeId nodeId, string namespaceUri)
  {
    this.Initialize();
    if (nodeId != (object) null)
      this.m_nodeId = new NodeId(nodeId);
    if (string.IsNullOrEmpty(namespaceUri))
      return;
    this.SetNamespaceUri(namespaceUri);
  }

  public ExpandedNodeId(NodeId nodeId, string namespaceUri, uint serverIndex)
  {
    this.Initialize();
    if (nodeId != (object) null)
      this.m_nodeId = new NodeId(nodeId);
    if (!string.IsNullOrEmpty(namespaceUri))
      this.SetNamespaceUri(namespaceUri);
    this.m_serverIndex = serverIndex;
  }

  public ExpandedNodeId(uint value)
  {
    this.Initialize();
    this.m_nodeId = new NodeId(value);
  }

  public ExpandedNodeId(uint value, ushort namespaceIndex)
  {
    this.Initialize();
    this.m_nodeId = new NodeId(value, namespaceIndex);
  }

  public ExpandedNodeId(uint value, string namespaceUri)
  {
    this.Initialize();
    this.m_nodeId = new NodeId(value);
    this.SetNamespaceUri(namespaceUri);
  }

  public ExpandedNodeId(string value, ushort namespaceIndex)
  {
    this.Initialize();
    this.m_nodeId = new NodeId(value, namespaceIndex);
  }

  public ExpandedNodeId(string value, string namespaceUri)
  {
    this.Initialize();
    this.m_nodeId = new NodeId(value, (ushort) 0);
    this.SetNamespaceUri(namespaceUri);
  }

  public ExpandedNodeId(Guid value)
  {
    this.Initialize();
    this.m_nodeId = new NodeId(value);
  }

  public ExpandedNodeId(Guid value, ushort namespaceIndex)
  {
    this.Initialize();
    this.m_nodeId = new NodeId(value, namespaceIndex);
  }

  public ExpandedNodeId(Guid value, string namespaceUri)
  {
    this.Initialize();
    this.m_nodeId = new NodeId(value);
    this.SetNamespaceUri(namespaceUri);
  }

  public ExpandedNodeId(byte[] value)
  {
    this.Initialize();
    this.m_nodeId = new NodeId(value);
  }

  public ExpandedNodeId(byte[] value, ushort namespaceIndex)
  {
    this.Initialize();
    this.m_nodeId = new NodeId(value, namespaceIndex);
  }

  public ExpandedNodeId(byte[] value, string namespaceUri)
  {
    this.Initialize();
    this.m_nodeId = new NodeId(value);
    this.SetNamespaceUri(namespaceUri);
  }

  public ExpandedNodeId(string text)
  {
    this.Initialize();
    this.InternalParse(text);
  }

  private void Initialize()
  {
    this.m_nodeId = (NodeId) null;
    this.m_namespaceUri = (string) null;
    this.m_serverIndex = 0U;
  }

  public virtual ushort NamespaceIndex
  {
    get => this.m_nodeId != (object) null ? this.m_nodeId.NamespaceIndex : (ushort) 0;
  }

  public IdType IdType => this.m_nodeId != (object) null ? this.m_nodeId.IdType : IdType.Numeric;

  public object Identifier
  {
    get => this.m_nodeId != (object) null ? this.m_nodeId.Identifier : (object) null;
  }

  public string NamespaceUri => this.m_namespaceUri;

  public uint ServerIndex => this.m_serverIndex;

  public bool IsNull
  {
    get
    {
      return string.IsNullOrEmpty(this.m_namespaceUri) && this.m_serverIndex <= 0U && NodeId.IsNull(this.m_nodeId);
    }
  }

  public bool IsAbsolute => !string.IsNullOrEmpty(this.m_namespaceUri) || this.m_serverIndex > 0U;

  internal NodeId InnerNodeId
  {
    get => this.m_nodeId;
    set => this.m_nodeId = value;
  }

  [DataMember(Name = "Identifier", Order = 1)]
  internal string IdentifierText
  {
    get => this.Format();
    set
    {
      ExpandedNodeId expandedNodeId = ExpandedNodeId.Parse(value);
      this.m_nodeId = expandedNodeId.m_nodeId;
      this.m_namespaceUri = expandedNodeId.m_namespaceUri;
      this.m_serverIndex = expandedNodeId.m_serverIndex;
    }
  }

  public string Format()
  {
    StringBuilder buffer = new StringBuilder();
    this.Format(buffer);
    return buffer.ToString();
  }

  public void Format(StringBuilder buffer)
  {
    if (this.m_nodeId != (object) null)
      ExpandedNodeId.Format(buffer, this.m_nodeId.Identifier, this.m_nodeId.IdType, this.m_nodeId.NamespaceIndex, this.m_namespaceUri, this.m_serverIndex);
    else
      ExpandedNodeId.Format(buffer, (object) null, IdType.Numeric, (ushort) 0, this.m_namespaceUri, this.m_serverIndex);
  }

  public static void Format(
    StringBuilder buffer,
    object identifier,
    IdType identifierType,
    ushort namespaceIndex,
    string namespaceUri,
    uint serverIndex)
  {
    if (serverIndex != 0U)
      buffer.AppendFormat((IFormatProvider) CultureInfo.InvariantCulture, "svr={0};", (object) serverIndex);
    if (!string.IsNullOrEmpty(namespaceUri))
    {
      buffer.Append("nsu=");
      for (int index = 0; index < namespaceUri.Length; ++index)
      {
        char ch = namespaceUri[index];
        switch (ch)
        {
          case '%':
          case ';':
            buffer.AppendFormat((IFormatProvider) CultureInfo.InvariantCulture, "%{0:X2}", (object) Convert.ToInt16(ch));
            break;
          default:
            buffer.Append(ch);
            break;
        }
      }
      buffer.Append(';');
    }
    NodeId.Format(buffer, identifier, identifierType, namespaceIndex);
  }

  public static ExpandedNodeId Parse(
    string text,
    NamespaceTable currentNamespaces,
    NamespaceTable targetNamespaces)
  {
    ExpandedNodeId expandedNodeId = ExpandedNodeId.Parse(text);
    string namespaceUri = expandedNodeId.m_namespaceUri;
    if (expandedNodeId.m_nodeId.NamespaceIndex != (ushort) 0)
      namespaceUri = currentNamespaces.GetString((uint) expandedNodeId.m_nodeId.NamespaceIndex);
    ushort namespaceIndex = 0;
    if (!string.IsNullOrEmpty(namespaceUri))
    {
      int index = targetNamespaces.GetIndex(namespaceUri);
      namespaceIndex = index != -1 ? (ushort) index : throw ServiceResultException.Create(2150825984U /*0x80330000*/, "Cannot map namespace URI onto an index in the target namespace table: {0}", (object) namespaceUri);
    }
    if (expandedNodeId.ServerIndex != 0U)
    {
      expandedNodeId.m_nodeId = new NodeId(expandedNodeId.m_nodeId.Identifier, (ushort) 0);
      expandedNodeId.m_namespaceUri = namespaceUri;
      return expandedNodeId;
    }
    expandedNodeId.m_nodeId = new NodeId(expandedNodeId.m_nodeId.Identifier, namespaceIndex);
    expandedNodeId.m_namespaceUri = (string) null;
    return expandedNodeId;
  }

  public static ExpandedNodeId Parse(string text)
  {
    try
    {
      return string.IsNullOrEmpty(text) ? ExpandedNodeId.Null : new ExpandedNodeId(text);
    }
    catch (Exception ex)
    {
      throw new ServiceResultException(2150825984U /*0x80330000*/, Utils.Format("Cannot parse expanded node id text: '{0}'", (object) text), ex);
    }
  }

  internal static void UnescapeUri(string text, int start, int index, StringBuilder buffer)
  {
    for (int index1 = start; index1 < index; ++index1)
    {
      char ch1 = text[index1];
      if (ch1 == '%')
      {
        int num1;
        int num2 = index1 + 2 < index ? "0123456789ABCDEF".IndexOf(char.ToUpperInvariant(text[num1 = index1 + 1])) : throw new ServiceResultException(2150825984U /*0x80330000*/, "Invalid escaped character in namespace uri.");
        if (num2 == -1)
          throw new ServiceResultException(2150825984U /*0x80330000*/, "Invalid escaped character in namespace uri.");
        int num3 = (int) (ushort) ((uint) (ushort) (0 + (int) (ushort) num2) << 4);
        int num4 = "0123456789ABCDEF".IndexOf(char.ToUpperInvariant(text[index1 = num1 + 1]));
        int num5 = num4 != -1 ? (int) (ushort) num4 : throw new ServiceResultException(2150825984U /*0x80330000*/, "Invalid escaped character in namespace uri.");
        char ch2 = Convert.ToChar((ushort) (num3 + num5));
        buffer.Append(ch2);
      }
      else
        buffer.Append(ch1);
    }
  }

  public int CompareTo(object obj)
  {
    if (obj == null)
      return -1;
    if ((object) this == obj)
      return 0;
    if (!this.IsAbsolute && this.m_nodeId != (object) null)
      return this.m_nodeId.CompareTo(obj);
    NodeId nodeId = obj as NodeId;
    ExpandedNodeId expandedNodeId = obj as ExpandedNodeId;
    if (expandedNodeId != (object) null)
    {
      if (this.IsNull && expandedNodeId.IsNull)
        return 0;
      if ((int) this.ServerIndex != (int) expandedNodeId.ServerIndex)
        return this.ServerIndex.CompareTo(expandedNodeId.ServerIndex);
      if (this.NamespaceUri != expandedNodeId.NamespaceUri)
        return this.NamespaceUri != null ? string.CompareOrdinal(this.NamespaceUri, expandedNodeId.NamespaceUri) : -1;
      nodeId = expandedNodeId.m_nodeId;
    }
    if (this.m_nodeId != (object) null)
      return this.m_nodeId.CompareTo((object) nodeId);
    return !(nodeId == (object) null) ? -1 : 0;
  }

  public static bool operator >(ExpandedNodeId value1, object value2)
  {
    return (object) value1 != null && value1.CompareTo(value2) > 0;
  }

  public static bool operator <(ExpandedNodeId value1, object value2)
  {
    return (object) value1 == null || value1.CompareTo(value2) < 0;
  }

  public override bool Equals(object obj) => this.CompareTo(obj) == 0;

  public override int GetHashCode()
  {
    if (this.m_nodeId == (object) null || this.m_nodeId.IsNullNodeId)
      return 0;
    if (!this.IsAbsolute)
      return this.m_nodeId.GetHashCode();
    HashCode hashCode = new HashCode();
    if (this.ServerIndex != 0U)
      hashCode.Add<uint>(this.ServerIndex);
    if (this.NamespaceUri != null)
      hashCode.Add<string>(this.NamespaceUri);
    hashCode.Add<NodeId>(this.m_nodeId);
    return hashCode.ToHashCode();
  }

  public static bool operator ==(ExpandedNodeId value1, object value2)
  {
    return (object) value1 == null ? value2 == null : value1.CompareTo(value2) == 0;
  }

  public static bool operator !=(ExpandedNodeId value1, object value2)
  {
    return (object) value1 == null ? value2 != null : value1.CompareTo(value2) != 0;
  }

  public bool Equals(ExpandedNodeId other) => this.CompareTo((object) other) == 0;

  public string ToString(string format, IFormatProvider formatProvider)
  {
    if (format != null)
      throw new FormatException(Utils.Format("Invalid format string: '{0}'.", (object) format));
    return this.Format();
  }

  public virtual object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone() => (object) this;

  public override string ToString() => this.ToString((string) null, (IFormatProvider) null);

  public static NodeId ToNodeId(ExpandedNodeId nodeId, NamespaceTable namespaceTable)
  {
    if (nodeId == (object) null)
      return (NodeId) null;
    if (string.IsNullOrEmpty(nodeId.m_namespaceUri) && nodeId.m_serverIndex == 0U)
      return nodeId.m_nodeId;
    NodeId nodeId1 = new NodeId(nodeId.m_nodeId);
    int num = -1;
    if (namespaceTable != null)
      num = namespaceTable.GetIndex(nodeId.NamespaceUri);
    if (num < 0)
      return (NodeId) null;
    nodeId1.SetNamespaceIndex((ushort) num);
    return nodeId1;
  }

  internal void SetNamespaceIndex(ushort namespaceIndex)
  {
    this.m_nodeId.SetNamespaceIndex(namespaceIndex);
    this.m_namespaceUri = (string) null;
  }

  internal void SetNamespaceUri(string uri)
  {
    this.m_nodeId.SetNamespaceIndex((ushort) 0);
    this.m_namespaceUri = uri;
  }

  internal void SetServerIndex(uint serverIndex) => this.m_serverIndex = serverIndex;

  public static NodeId Parse(string text, NamespaceTable namespaceUris)
  {
    ExpandedNodeId nodeId1 = ExpandedNodeId.Parse(text);
    if (!nodeId1.IsAbsolute)
      return nodeId1.InnerNodeId;
    NodeId nodeId2 = ExpandedNodeId.ToNodeId(nodeId1, namespaceUris);
    return !(nodeId2 == (object) null) ? nodeId2 : throw ServiceResultException.Create(2150825984U /*0x80330000*/, "NamespaceUri ({0}) is not in the namespace table.", (object) nodeId1.NamespaceUri);
  }

  public static explicit operator NodeId(ExpandedNodeId value)
  {
    if (value == (object) null)
      return (NodeId) null;
    return !value.IsAbsolute ? value.InnerNodeId : throw new InvalidCastException("Cannot cast an absolute ExpandedNodeId to a NodeId. Use ExpandedNodeId.ToNodeId instead.");
  }

  public static implicit operator ExpandedNodeId(uint value) => new ExpandedNodeId(value);

  public static implicit operator ExpandedNodeId(Guid value) => new ExpandedNodeId(value);

  public static implicit operator ExpandedNodeId(byte[] value) => new ExpandedNodeId(value);

  public static implicit operator ExpandedNodeId(string text) => new ExpandedNodeId(text);

  public static implicit operator ExpandedNodeId(NodeId nodeId) => new ExpandedNodeId(nodeId);

  public static ExpandedNodeId Null => ExpandedNodeId.s_Null;

  private void InternalParse(string text)
  {
    uint num1 = 0;
    string str = (string) null;
    try
    {
      if (text.StartsWith("svr=", StringComparison.Ordinal))
      {
        int num2 = text.IndexOf(';');
        if (num2 == -1)
          throw new ServiceResultException(2150825984U /*0x80330000*/, "Invalid server index.");
        num1 = Convert.ToUInt32(text.Substring(4, num2 - 4), (IFormatProvider) CultureInfo.InvariantCulture);
        text = text.Substring(num2 + 1);
      }
      if (text.StartsWith("nsu=", StringComparison.Ordinal))
      {
        int index = text.IndexOf(';');
        if (index == -1)
          throw new ServiceResultException(2150825984U /*0x80330000*/, "Invalid namespace uri.");
        StringBuilder buffer = new StringBuilder();
        ExpandedNodeId.UnescapeUri(text, 4, index, buffer);
        str = buffer.ToString();
        text = text.Substring(index + 1);
      }
    }
    catch (Exception ex)
    {
      throw new ServiceResultException(2150825984U /*0x80330000*/, Utils.Format("Cannot parse expanded node id text: '{0}'", (object) text), ex);
    }
    this.m_nodeId = NodeId.InternalParse(text, num1 != 0U || !string.IsNullOrEmpty(str));
    this.m_namespaceUri = str;
    this.m_serverIndex = num1;
  }
}
