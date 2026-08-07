// Decompiled with JetBrains decompiler
// Type: Opc.Ua.QualifiedName
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;

#nullable disable
namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class QualifiedName : ICloneable, IFormattable, IComparable
{
  private static readonly QualifiedName s_Null = new QualifiedName();
  private ushort m_namespaceIndex;
  private string m_name;

  internal QualifiedName()
  {
    this.m_namespaceIndex = (ushort) 0;
    this.m_name = (string) null;
  }

  public QualifiedName(QualifiedName value)
  {
    this.m_name = !(value == (QualifiedName) null) ? value.m_name : throw new ArgumentNullException(nameof (value));
    this.m_namespaceIndex = value.m_namespaceIndex;
  }

  public QualifiedName(string name)
  {
    this.m_namespaceIndex = (ushort) 0;
    this.m_name = name;
  }

  public QualifiedName(string name, ushort namespaceIndex)
  {
    this.m_namespaceIndex = namespaceIndex;
    this.m_name = name;
  }

  public ushort NamespaceIndex => this.m_namespaceIndex;

  [DataMember(Name = "NamespaceIndex", Order = 1)]
  internal ushort XmlEncodedNamespaceIndex
  {
    get => this.m_namespaceIndex;
    set => this.m_namespaceIndex = value;
  }

  public string Name => this.m_name;

  [DataMember(Name = "Name", Order = 2)]
  internal string XmlEncodedName
  {
    get => this.m_name;
    set => this.m_name = value;
  }

  public int CompareTo(object obj)
  {
    if (obj == null)
      return -1;
    if ((object) this == obj)
      return 0;
    QualifiedName qualifiedName = obj as QualifiedName;
    if (qualifiedName == (QualifiedName) null)
      return typeof (QualifiedName).GetTypeInfo().GUID.CompareTo(obj.GetType().GetTypeInfo().GUID);
    if ((int) qualifiedName.m_namespaceIndex != (int) this.m_namespaceIndex)
      return this.m_namespaceIndex.CompareTo(qualifiedName.m_namespaceIndex);
    return this.m_name != null ? string.CompareOrdinal(this.m_name, qualifiedName.m_name) : 0;
  }

  public static bool operator >(QualifiedName value1, QualifiedName value2)
  {
    return (object) value1 != null && value1.CompareTo((object) value2) > 0;
  }

  public static bool operator <(QualifiedName value1, QualifiedName value2)
  {
    return (object) value1 == null || value1.CompareTo((object) value2) < 0;
  }

  public override int GetHashCode()
  {
    HashCode hashCode = new HashCode();
    if (this.m_name != null)
      hashCode.Add<string>(this.m_name);
    hashCode.Add<ushort>(this.m_namespaceIndex);
    return hashCode.ToHashCode();
  }

  public override bool Equals(object obj)
  {
    if (obj == null)
      return false;
    if ((object) this == obj)
      return true;
    QualifiedName qualifiedName = obj as QualifiedName;
    return !(qualifiedName == (QualifiedName) null) && (int) qualifiedName.m_namespaceIndex == (int) this.m_namespaceIndex && qualifiedName.m_name == this.m_name;
  }

  public static bool operator ==(QualifiedName value1, QualifiedName value2)
  {
    return (object) value1 != null ? value1.Equals((object) value2) : (object) value2 == null;
  }

  public static bool operator !=(QualifiedName value1, QualifiedName value2)
  {
    return (object) value1 != null ? !value1.Equals((object) value2) : value2 != null;
  }

  public override string ToString() => this.ToString((string) null, (IFormatProvider) null);

  public string ToString(string format, IFormatProvider formatProvider)
  {
    if (format == null)
    {
      StringBuilder stringBuilder = new StringBuilder((this.m_name != null ? this.m_name.Length : 0) + 10);
      if (this.m_namespaceIndex == (ushort) 0)
      {
        if (this.m_name != null && this.m_name.IndexOf(':') != -1)
          stringBuilder.Append("0:");
      }
      else
      {
        stringBuilder.Append(this.m_namespaceIndex);
        stringBuilder.Append(':');
      }
      if (this.m_name != null)
        stringBuilder.Append(this.m_name);
      return stringBuilder.ToString();
    }
    throw new FormatException(Utils.Format("Invalid format string: '{0}'.", (object) format));
  }

  public virtual object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone() => (object) this;

  public static QualifiedName Create(
    string name,
    string namespaceUri,
    NamespaceTable namespaceTable)
  {
    if (string.IsNullOrEmpty(name))
      return QualifiedName.Null;
    if (string.IsNullOrEmpty(namespaceUri))
      return new QualifiedName(name);
    int namespaceIndex = -1;
    if (namespaceTable != null)
      namespaceIndex = namespaceTable.GetIndex(namespaceUri);
    return namespaceIndex >= 0 ? new QualifiedName(name, (ushort) namespaceIndex) : throw ServiceResultException.Create(2153775104U /*0x80600000*/, "NamespaceUri ({0}) is not in the NamespaceTable.", (object) namespaceUri);
  }

  public static bool IsValid(QualifiedName value, NamespaceTable namespaceUris)
  {
    return !(value == (QualifiedName) null) && !string.IsNullOrEmpty(value.m_name) && (namespaceUris == null || namespaceUris.GetString((uint) value.m_namespaceIndex) != null);
  }

  public static QualifiedName Parse(string text)
  {
    if (string.IsNullOrEmpty(text))
      return QualifiedName.Null;
    ushort namespaceIndex = 0;
    int startIndex = -1;
    for (int index = 0; index < text.Length; ++index)
    {
      char c = text[index];
      if (c != ':')
      {
        if (char.IsDigit(c))
          namespaceIndex = (ushort) ((uint) (ushort) ((uint) namespaceIndex * 10U) + (uint) (ushort) ((uint) c - 48U /*0x30*/));
      }
      else
      {
        startIndex = index + 1;
        break;
      }
    }
    return startIndex == -1 ? new QualifiedName(text) : new QualifiedName(text.Substring(startIndex), namespaceIndex);
  }

  public static bool IsNull(QualifiedName value)
  {
    return !(value != (QualifiedName) null) || value.m_namespaceIndex == (ushort) 0 && string.IsNullOrEmpty(value.m_name);
  }

  public static QualifiedName ToQualifiedName(string value) => new QualifiedName(value);

  public static implicit operator QualifiedName(string value) => new QualifiedName(value);

  public static QualifiedName Null => QualifiedName.s_Null;
}
