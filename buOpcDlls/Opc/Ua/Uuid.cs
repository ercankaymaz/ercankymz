// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Uuid
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[DataContract(Name = "Guid", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public struct Uuid : IComparable, IFormattable, IEquatable<Uuid>
{
  public static readonly Uuid Empty;
  private Guid m_guid;

  public Uuid(string text) => this.m_guid = new Guid(text);

  public Uuid(Guid guid) => this.m_guid = guid;

  [DataMember(Name = "String", Order = 1)]
  public string GuidString
  {
    get => this.m_guid.ToString();
    set
    {
      if (string.IsNullOrEmpty(value))
        this.m_guid = Guid.Empty;
      else
        this.m_guid = new Guid(value);
    }
  }

  public static implicit operator Guid(Uuid guid) => guid.m_guid;

  public static explicit operator Uuid(Guid guid) => new Uuid(guid);

  public static bool operator ==(Uuid a, Uuid b) => a.Equals(b);

  public static bool operator !=(Uuid a, Uuid b) => !a.Equals(b);

  public static bool operator ==(Uuid a, Guid b) => a.Equals((object) b);

  public static bool operator !=(Uuid a, Guid b) => !a.Equals((object) b);

  public static bool operator <(Uuid a, Uuid b) => a.CompareTo((object) b) < 0;

  public static bool operator >(Uuid a, Uuid b) => a.CompareTo((object) b) > 0;

  public override bool Equals(object obj) => this.CompareTo(obj) == 0;

  public bool Equals(Uuid other) => this.CompareTo((object) other) == 0;

  public override int GetHashCode() => this.m_guid.GetHashCode();

  public override string ToString() => this.m_guid.ToString();

  public int CompareTo(object obj)
  {
    switch (obj)
    {
      case Uuid uuid:
        return uuid.m_guid.CompareTo(this.m_guid);
      case Guid guid:
        return this.m_guid.CompareTo(guid);
      default:
        return 1;
    }
  }

  public string ToString(string format, IFormatProvider formatProvider)
  {
    return this.m_guid.ToString(format);
  }
}
