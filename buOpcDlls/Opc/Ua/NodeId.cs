// Decompiled with JetBrains decompiler
// Type: Opc.Ua.NodeId
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
public class NodeId : IComparable, IFormattable, IEquatable<NodeId>, ICloneable
{
  private static readonly NodeId s_Null = new NodeId();
  private ushort m_namespaceIndex;
  private IdType m_identifierType;
  private object m_identifier;

  public NodeId() => this.Initialize();

  public NodeId(NodeId value)
  {
    this.m_namespaceIndex = !(value == (object) null) ? value.m_namespaceIndex : throw new ArgumentNullException(nameof (value));
    this.m_identifierType = value.m_identifierType;
    this.m_identifier = Utils.Clone(value.m_identifier);
  }

  public NodeId(uint value)
  {
    this.m_namespaceIndex = (ushort) 0;
    this.m_identifierType = IdType.Numeric;
    this.m_identifier = (object) value;
  }

  public NodeId(uint value, ushort namespaceIndex)
  {
    this.m_namespaceIndex = namespaceIndex;
    this.m_identifierType = IdType.Numeric;
    this.m_identifier = (object) value;
  }

  public NodeId(string value, ushort namespaceIndex)
  {
    this.m_namespaceIndex = namespaceIndex;
    this.m_identifierType = IdType.String;
    this.m_identifier = (object) value;
  }

  public NodeId(Guid value)
  {
    this.m_namespaceIndex = (ushort) 0;
    this.m_identifierType = IdType.Guid;
    this.m_identifier = (object) value;
  }

  public NodeId(Guid value, ushort namespaceIndex)
  {
    this.m_namespaceIndex = namespaceIndex;
    this.m_identifierType = IdType.Guid;
    this.m_identifier = (object) value;
  }

  public NodeId(byte[] value)
  {
    this.m_namespaceIndex = (ushort) 0;
    this.m_identifierType = IdType.Opaque;
    this.m_identifier = (object) null;
    if (value == null)
      return;
    byte[] destinationArray = new byte[value.Length];
    Array.Copy((Array) value, (Array) destinationArray, value.Length);
    this.m_identifier = (object) destinationArray;
  }

  public NodeId(byte[] value, ushort namespaceIndex)
  {
    this.m_namespaceIndex = namespaceIndex;
    this.m_identifierType = IdType.Opaque;
    this.m_identifier = (object) null;
    if (value == null)
      return;
    byte[] destinationArray = new byte[value.Length];
    Array.Copy((Array) value, (Array) destinationArray, value.Length);
    this.m_identifier = (object) destinationArray;
  }

  public NodeId(string text)
  {
    NodeId nodeId = NodeId.Parse(text);
    this.m_namespaceIndex = nodeId.NamespaceIndex;
    this.m_identifierType = nodeId.IdType;
    this.m_identifier = nodeId.Identifier;
  }

  public NodeId(object value, ushort namespaceIndex)
  {
    this.m_namespaceIndex = namespaceIndex;
    switch (value)
    {
      case uint _:
        this.SetIdentifier(IdType.Numeric, value);
        break;
      case null:
      case string _:
        this.SetIdentifier(IdType.String, value);
        break;
      case Guid _:
        this.SetIdentifier(IdType.Guid, value);
        break;
      case Uuid _:
        this.SetIdentifier(IdType.Guid, value);
        break;
      case byte[] _:
        this.SetIdentifier(IdType.Opaque, value);
        break;
      default:
        throw new ArgumentException("Identifier type not supported.", nameof (value));
    }
  }

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_namespaceIndex = (ushort) 0;
    this.m_identifierType = IdType.Numeric;
    this.m_identifier = (object) null;
  }

  public static NodeId Create(
    object identifier,
    string namespaceUri,
    NamespaceTable namespaceTable)
  {
    int namespaceIndex = -1;
    if (namespaceTable != null)
      namespaceIndex = namespaceTable.GetIndex(namespaceUri);
    return namespaceIndex >= 0 ? new NodeId(identifier, (ushort) namespaceIndex) : throw ServiceResultException.Create(2150825984U /*0x80330000*/, "NamespaceUri ({0}) is not in the namespace table.", (object) namespaceUri);
  }

  public static implicit operator NodeId(uint value) => new NodeId(value);

  public static implicit operator NodeId(Guid value) => new NodeId(value);

  public static implicit operator NodeId(byte[] value) => new NodeId(value);

  public static implicit operator NodeId(string text) => NodeId.Parse(text);

  public static bool IsNull(NodeId nodeId) => nodeId == (object) null || nodeId.IsNullNodeId;

  public static bool IsNull(ExpandedNodeId nodeId) => nodeId == (object) null || nodeId.IsNull;

  public static NodeId Parse(string text) => NodeId.InternalParse(text, false);

  internal static NodeId InternalParse(string text, bool namespaceSet)
  {
    ArgumentException argumentException;
    try
    {
      if (string.IsNullOrEmpty(text))
        return NodeId.Null;
      ushort namespaceIndex = 0;
      if (text.StartsWith("ns=", StringComparison.Ordinal))
      {
        int num = text.IndexOf(';');
        if (num == -1)
          throw new ServiceResultException(2150825984U /*0x80330000*/, "Invalid namespace index.");
        namespaceIndex = Convert.ToUInt16(text.Substring(3, num - 3), (IFormatProvider) CultureInfo.InvariantCulture);
        namespaceSet = true;
        text = text.Substring(num + 1);
      }
      if (text.StartsWith("i=", StringComparison.Ordinal))
        return new NodeId(Convert.ToUInt32(text.Substring(2), (IFormatProvider) CultureInfo.InvariantCulture), namespaceIndex);
      if (text.StartsWith("s=", StringComparison.Ordinal))
        return new NodeId(text.Substring(2), namespaceIndex);
      if (text.StartsWith("g=", StringComparison.Ordinal))
        return new NodeId(new Guid(text.Substring(2)), namespaceIndex);
      if (text.StartsWith("b=", StringComparison.Ordinal))
        return new NodeId(Convert.FromBase64String(text.Substring(2)), namespaceIndex);
      if (text.StartsWith("nsu=", StringComparison.Ordinal))
      {
        argumentException = new ArgumentException("Invalid namespace Uri ('nsu=') for a NodeId.");
      }
      else
      {
        if (namespaceSet)
          return new NodeId(text, namespaceIndex);
        argumentException = new ArgumentException("Invalid string NodeId without namespace index ('ns=').");
      }
    }
    catch (Exception ex)
    {
      throw new ServiceResultException(2150825984U /*0x80330000*/, Utils.Format("Cannot parse node id text: '{0}'", (object) text), ex);
    }
    throw argumentException;
  }

  public static NodeId Null => NodeId.s_Null;

  public string Format()
  {
    StringBuilder buffer = new StringBuilder();
    this.Format(buffer);
    return buffer.ToString();
  }

  public void Format(StringBuilder buffer)
  {
    NodeId.Format(buffer, this.m_identifier, this.m_identifierType, this.m_namespaceIndex);
  }

  public static void Format(
    StringBuilder buffer,
    object identifier,
    IdType identifierType,
    ushort namespaceIndex)
  {
    if (namespaceIndex != (ushort) 0)
      buffer.AppendFormat((IFormatProvider) CultureInfo.InvariantCulture, "ns={0};", (object) namespaceIndex);
    switch (identifierType)
    {
      case IdType.Numeric:
        buffer.Append("i=");
        break;
      case IdType.String:
        buffer.Append("s=");
        break;
      case IdType.Guid:
        buffer.Append("g=");
        break;
      case IdType.Opaque:
        buffer.Append("b=");
        break;
    }
    NodeId.FormatIdentifier(buffer, identifier, identifierType);
  }

  public override string ToString() => this.ToString((string) null, (IFormatProvider) null);

  public static ExpandedNodeId ToExpandedNodeId(NodeId nodeId, NamespaceTable namespaceTable)
  {
    if (nodeId == (object) null)
      return (ExpandedNodeId) null;
    ExpandedNodeId expandedNodeId = new ExpandedNodeId(nodeId);
    if (nodeId.NamespaceIndex > (ushort) 0)
    {
      string uri = namespaceTable.GetString((uint) nodeId.NamespaceIndex);
      if (uri != null)
        expandedNodeId.SetNamespaceUri(uri);
    }
    return expandedNodeId;
  }

  internal void SetNamespaceIndex(ushort value) => this.m_namespaceIndex = value;

  internal void SetIdentifier(IdType idType, object value)
  {
    this.m_identifierType = idType;
    if (idType == IdType.Opaque)
      this.m_identifier = Utils.Clone(value);
    else
      this.m_identifier = value;
  }

  internal void SetIdentifier(string value, IdType idType)
  {
    this.m_identifierType = idType;
    this.SetIdentifier(IdType.String, (object) value);
  }

  public int CompareTo(object obj)
  {
    if (obj == null)
      return -1;
    if ((object) this == obj)
      return 0;
    ushort namespaceIndex = this.m_namespaceIndex;
    IdType idType = this.m_identifierType;
    object id = (object) null;
    NodeId nodeId = obj as NodeId;
    if ((object) nodeId != null)
    {
      if (this.IsNullNodeId && nodeId.IsNullNodeId)
        return 0;
      namespaceIndex = nodeId.NamespaceIndex;
      idType = nodeId.IdType;
      id = nodeId.Identifier;
    }
    else
    {
      uint? nullable1 = obj as uint?;
      int? nullable2 = obj as int?;
      if (!nullable1.HasValue && !nullable2.HasValue)
      {
        ExpandedNodeId expandedNodeId = obj as ExpandedNodeId;
        if ((object) expandedNodeId != null)
        {
          if (expandedNodeId.IsAbsolute)
            return -1;
          if (this.IsNullNodeId && expandedNodeId.InnerNodeId != (object) null && expandedNodeId.InnerNodeId.IsNullNodeId)
            return 0;
          namespaceIndex = expandedNodeId.NamespaceIndex;
          idType = expandedNodeId.IdType;
          id = expandedNodeId.Identifier;
        }
        else if (obj != null)
        {
          Guid? nullable3 = obj as Guid?;
          Uuid? nullable4 = obj as Uuid?;
          if (!nullable3.HasValue && !nullable4.HasValue || namespaceIndex != (ushort) 0 || idType != IdType.Guid)
            return -1;
          idType = IdType.Guid;
          id = this.m_identifier;
        }
      }
      else
      {
        if (namespaceIndex != (ushort) 0 || idType != IdType.Numeric)
          return -1;
        uint num;
        if (nullable2.HasValue && !nullable1.HasValue)
        {
          if (nullable2.Value < 0)
            return 1;
          num = (uint) nullable2.Value;
        }
        else
          num = nullable1.Value;
        uint valueOrDefault = (this.m_identifier as uint?).GetValueOrDefault();
        if ((int) valueOrDefault == (int) num)
          return 0;
        return valueOrDefault >= num ? 1 : -1;
      }
    }
    if ((int) namespaceIndex != (int) this.m_namespaceIndex)
      return (int) this.m_namespaceIndex >= (int) namespaceIndex ? 1 : -1;
    if (idType != this.m_identifierType)
      return this.m_identifierType >= idType ? 1 : -1;
    if (this.m_identifier == null && id == null)
      return 0;
    if (this.m_identifier == null && id != null)
    {
      switch (idType)
      {
        case IdType.Numeric:
          if ((id as uint?).Value == 0U)
            return 0;
          break;
        case IdType.String:
          if ((id as string).Length == 0)
            return 0;
          break;
        case IdType.Opaque:
          if ((id as byte[]).Length == 0)
            return 0;
          break;
      }
      return -1;
    }
    if (this.m_identifier == null || id != null)
      return this.CompareTo(idType, id);
    switch (idType)
    {
      case IdType.Numeric:
        if ((this.m_identifier as uint?).Value == 0U)
          return 0;
        break;
      case IdType.String:
        if ((this.m_identifier as string).Length == 0)
          return 0;
        break;
      case IdType.Opaque:
        if ((this.m_identifier as byte[]).Length == 0)
          return 0;
        break;
    }
    return 1;
  }

  public static bool operator >(NodeId value1, NodeId value2)
  {
    return (object) value1 != null && value1.CompareTo((object) value2) > 0;
  }

  public static bool operator <(NodeId value1, NodeId value2)
  {
    return (object) value1 == null || value1.CompareTo((object) value2) < 0;
  }

  public string ToString(string format, IFormatProvider formatProvider)
  {
    if (format != null)
      throw new FormatException(Utils.Format("Invalid format string: '{0}'.", (object) format));
    return string.Format(formatProvider, "{0}", (object) this.Format());
  }

  public virtual object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone() => (object) this;

  public override bool Equals(object obj) => this.CompareTo(obj) == 0;

  public bool Equals(NodeId other)
  {
    if ((object) this == (object) other || this.IsNullNodeId && (other == (object) null || other.IsNullNodeId))
      return true;
    return (int) other.NamespaceIndex == (int) this.m_namespaceIndex && other.IdType == this.m_identifierType && this.CompareTo(other.IdType, other.Identifier) == 0;
  }

  public override int GetHashCode()
  {
    if (this.m_identifier == null || this.IsNullNodeId)
      return 0;
    HashCode hashCode = new HashCode();
    hashCode.Add<ushort>(this.m_namespaceIndex);
    hashCode.Add<IdType>(this.m_identifierType);
    switch (this.m_identifierType)
    {
      case IdType.Numeric:
        hashCode.Add<uint>((uint) this.m_identifier);
        break;
      case IdType.String:
        hashCode.Add<string>((string) this.m_identifier);
        break;
      case IdType.Guid:
        hashCode.Add<Guid>((Guid) this.m_identifier);
        break;
      case IdType.Opaque:
        foreach (byte num in (byte[]) this.m_identifier)
          hashCode.Add<byte>(num);
        break;
      default:
        hashCode.Add<object>(this.m_identifier);
        break;
    }
    return hashCode.ToHashCode();
  }

  public static bool operator ==(NodeId value1, object value2)
  {
    return (object) value1 == null ? value2 == null : value1.CompareTo(value2) == 0;
  }

  public static bool operator !=(NodeId value1, object value2)
  {
    return (object) value1 == null ? value2 != null : value1.CompareTo(value2) != 0;
  }

  [DataMember(Name = "Identifier", Order = 1)]
  internal string IdentifierText
  {
    get => this.Format();
    set
    {
      NodeId nodeId = NodeId.Parse(value);
      this.m_namespaceIndex = nodeId.NamespaceIndex;
      this.m_identifierType = nodeId.IdType;
      this.m_identifier = nodeId.Identifier;
    }
  }

  public ushort NamespaceIndex => this.m_namespaceIndex;

  public IdType IdType => this.m_identifierType;

  public object Identifier
  {
    get
    {
      if (this.m_identifier == null)
      {
        switch (this.m_identifierType)
        {
          case IdType.Numeric:
            return (object) 0U;
          case IdType.Guid:
            return (object) Guid.Empty;
        }
      }
      return this.m_identifier;
    }
  }

  public bool IsNullNodeId
  {
    get
    {
      if (this.m_namespaceIndex != (ushort) 0)
        return false;
      if (this.m_identifier != null)
      {
        switch (this.m_identifierType)
        {
          case IdType.Numeric:
            if (!this.m_identifier.Equals((object) 0U))
              return false;
            break;
          case IdType.String:
            if (!string.IsNullOrEmpty((string) this.m_identifier))
              return false;
            break;
          case IdType.Guid:
            if (!this.m_identifier.Equals((object) Guid.Empty))
              return false;
            break;
          case IdType.Opaque:
            if (this.m_identifier != null && ((byte[]) this.m_identifier).Length != 0)
              return false;
            break;
        }
      }
      return true;
    }
  }

  private static int CompareIdentifiers(IdType idType1, object id1, IdType idType2, object id2)
  {
    if (id1 == null && id2 == null)
      return 0;
    if (idType1 != idType2)
      return idType1.CompareTo((object) idType2);
    if (id1 != null && id2 != null)
    {
      switch (id1)
      {
        case byte[] numArray2:
          if (!(id2 is byte[] numArray1))
            return 1;
          if (numArray2.Length != numArray1.Length)
            return numArray2.Length.CompareTo(numArray1.Length);
          for (int index = 0; index < numArray2.Length; ++index)
          {
            int num = numArray2[index].CompareTo(numArray1[index]);
            if (num != 0)
              return num;
          }
          return 0;
        case IComparable comparable:
          return comparable.CompareTo(id2);
        default:
          return string.CompareOrdinal(id1.ToString(), id2.ToString());
      }
    }
    else
    {
      object obj = id1;
      if (id1 == null)
        obj = id2;
      switch (idType1)
      {
        case IdType.Numeric:
          if (obj is 0U)
            return 0;
          break;
        case IdType.String:
          if (obj is string str && str.Length == 0)
            return 0;
          break;
        case IdType.Guid:
          if (obj is Guid guid && guid == Guid.Empty)
            return 0;
          break;
        case IdType.Opaque:
          if (obj is byte[] numArray3 && numArray3.Length == 0)
            return 0;
          break;
      }
      return id1 != null ? 1 : -1;
    }
  }

  private int CompareTo(IdType idType, object id)
  {
    switch (idType)
    {
      case IdType.Numeric:
        uint identifier1 = (uint) this.m_identifier;
        uint num = (uint) id;
        if ((int) identifier1 == (int) num)
          return 0;
        return identifier1 >= num ? 1 : -1;
      case IdType.String:
        return string.CompareOrdinal((string) this.m_identifier, (string) id);
      case IdType.Guid:
        Guid identifier2 = (Guid) this.m_identifier;
        return id is Uuid uuid ? identifier2.CompareTo((Guid) uuid) : identifier2.CompareTo((Guid) id);
      case IdType.Opaque:
        byte[] identifier3 = (byte[]) this.m_identifier;
        byte[] numArray = (byte[]) id;
        if (identifier3.Length == numArray.Length)
        {
          for (int index = 0; index < identifier3.Length; ++index)
          {
            if ((int) identifier3[index] != (int) numArray[index])
              return (int) identifier3[index] >= (int) numArray[index] ? 1 : -1;
          }
          return 0;
        }
        return identifier3.Length >= numArray.Length ? 1 : -1;
      default:
        return 1;
    }
  }

  private static void FormatIdentifier(
    StringBuilder buffer,
    object identifier,
    IdType identifierType)
  {
    switch (identifierType)
    {
      case IdType.Numeric:
        if (identifier == null)
        {
          buffer.Append('0');
          break;
        }
        buffer.AppendFormat((IFormatProvider) CultureInfo.InvariantCulture, "{0}", identifier);
        break;
      case IdType.String:
        buffer.AppendFormat((IFormatProvider) CultureInfo.InvariantCulture, "{0}", identifier);
        break;
      case IdType.Guid:
        if (identifier == null)
        {
          buffer.Append((object) Guid.Empty);
          break;
        }
        buffer.AppendFormat((IFormatProvider) CultureInfo.InvariantCulture, "{0}", identifier);
        break;
      case IdType.Opaque:
        if (identifier == null)
          break;
        buffer.AppendFormat((IFormatProvider) CultureInfo.InvariantCulture, "{0}", (object) Convert.ToBase64String((byte[]) identifier));
        break;
    }
  }
}
