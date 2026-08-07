// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Variant
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

#nullable disable
namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public struct Variant : ICloneable, IFormattable, IEquatable<Variant>
{
  public static readonly Variant Null;
  private object m_value;
  private TypeInfo m_typeInfo;

  public Variant(Variant value)
  {
    this.m_value = Utils.Clone(value.m_value);
    this.m_typeInfo = value.m_typeInfo;
  }

  public Variant(object value, TypeInfo typeInfo)
  {
    this.m_value = (object) null;
    this.m_typeInfo = typeInfo;
    this.Set(value, typeInfo);
  }

  public Variant(object value)
  {
    this.m_value = (object) null;
    this.m_typeInfo = TypeInfo.Construct(value);
    this.Set(value, this.m_typeInfo);
  }

  public Variant(Matrix value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = value.TypeInfo;
  }

  public Variant(bool value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.Boolean;
  }

  public Variant(sbyte value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.SByte;
  }

  public Variant(byte value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.Byte;
  }

  public Variant(short value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.Int16;
  }

  public Variant(ushort value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.UInt16;
  }

  public Variant(int value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.Int32;
  }

  public Variant(uint value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.UInt32;
  }

  public Variant(long value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.Int64;
  }

  public Variant(ulong value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.UInt64;
  }

  public Variant(float value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.Float;
  }

  public Variant(double value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.Double;
  }

  public Variant(string value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.String;
  }

  public Variant(DateTime value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.DateTime;
  }

  public Variant(Guid value)
  {
    this.m_value = (object) new Uuid(value);
    this.m_typeInfo = TypeInfo.Scalars.Guid;
  }

  public Variant(Uuid value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.Guid;
  }

  public Variant(byte[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.ByteString;
  }

  public Variant(XmlElement value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.XmlElement;
  }

  public Variant(NodeId value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.NodeId;
  }

  public Variant(ExpandedNodeId value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.ExpandedNodeId;
  }

  public Variant(StatusCode value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.StatusCode;
  }

  public Variant(QualifiedName value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.QualifiedName;
  }

  public Variant(LocalizedText value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.LocalizedText;
  }

  public Variant(ExtensionObject value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.ExtensionObject;
  }

  public Variant(DataValue value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.DataValue;
  }

  public Variant(bool[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.Boolean;
  }

  public Variant(sbyte[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.SByte;
  }

  public Variant(short[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.Int16;
  }

  public Variant(ushort[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.UInt16;
  }

  public Variant(int[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.Int32;
  }

  public Variant(uint[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.UInt32;
  }

  public Variant(long[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.Int64;
  }

  public Variant(ulong[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.UInt64;
  }

  public Variant(float[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.Float;
  }

  public Variant(double[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.Double;
  }

  public Variant(string[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.String;
  }

  public Variant(DateTime[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.DateTime;
  }

  public Variant(Guid[] value)
  {
    this.m_value = (object) null;
    this.m_typeInfo = TypeInfo.Arrays.Guid;
    this.Set(value);
  }

  public Variant(Uuid[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.Guid;
  }

  public Variant(byte[][] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.ByteString;
  }

  public Variant(XmlElement[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.XmlElement;
  }

  public Variant(NodeId[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.NodeId;
  }

  public Variant(ExpandedNodeId[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.ExpandedNodeId;
  }

  public Variant(StatusCode[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.StatusCode;
  }

  public Variant(QualifiedName[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.QualifiedName;
  }

  public Variant(LocalizedText[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.LocalizedText;
  }

  public Variant(ExtensionObject[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.ExtensionObject;
  }

  public Variant(DataValue[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.DataValue;
  }

  public Variant(Variant[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.Variant;
  }

  public Variant(object[] value)
  {
    this.m_value = (object) null;
    this.m_typeInfo = TypeInfo.Arrays.Variant;
    this.Set(value);
  }

  [DataMember(Name = "Value", Order = 1)]
  private XmlElement XmlEncodedValue
  {
    get
    {
      using (XmlEncoder xmlEncoder = new XmlEncoder(MessageContextExtension.CurrentContext))
      {
        xmlEncoder.WriteVariantContents(this.m_value, this.m_typeInfo);
        XmlDocument doc = new XmlDocument();
        doc.LoadInnerXml(xmlEncoder.CloseAndReturnText());
        return doc.DocumentElement;
      }
    }
    set
    {
      if (value == null)
      {
        this.m_value = (object) null;
      }
      else
      {
        TypeInfo typeInfo = (TypeInfo) null;
        XmlDecoder xmlDecoder = new XmlDecoder(value, MessageContextExtension.CurrentContext);
        try
        {
          this.Set(xmlDecoder.ReadVariantContents(out typeInfo), typeInfo);
        }
        catch (Exception ex)
        {
          throw ServiceResultException.Create(2147942400U /*0x80070000*/, ex, "Error decoding Variant value.");
        }
        finally
        {
          xmlDecoder.Close();
        }
      }
    }
  }

  public object Value
  {
    get => this.m_value;
    set => this.Set(value, TypeInfo.Construct(value));
  }

  public TypeInfo TypeInfo => this.m_typeInfo;

  public string ToString(string format, IFormatProvider formatProvider)
  {
    if (format != null)
      throw new FormatException(Utils.Format("Invalid format string: '{0}'.", (object) format));
    StringBuilder buffer = new StringBuilder();
    this.AppendFormat(buffer, this.m_value, formatProvider);
    return buffer.ToString();
  }

  private void AppendByteString(StringBuilder buffer, byte[] bytes, IFormatProvider formatProvider)
  {
    if (bytes != null)
    {
      for (int index = 0; index < bytes.Length; ++index)
        buffer.AppendFormat(formatProvider, "{0:X2}", (object) bytes[index]);
    }
    else
      buffer.Append("(null)");
  }

  private void AppendFormat(StringBuilder buffer, object value, IFormatProvider formatProvider)
  {
    if (value != null && this.m_typeInfo != null)
    {
      if (this.m_typeInfo.BuiltInType == BuiltInType.ByteString && this.m_typeInfo.ValueRank < 0)
      {
        byte[] bytes = (byte[]) value;
        this.AppendByteString(buffer, bytes, formatProvider);
      }
      else if (this.m_typeInfo.BuiltInType == BuiltInType.XmlElement && this.m_typeInfo.ValueRank < 0)
      {
        XmlElement xmlElement = (XmlElement) value;
        buffer.AppendFormat(formatProvider, "{0}", (object) xmlElement.OuterXml);
      }
      else if (value is Array array && this.m_typeInfo.ValueRank <= 1)
      {
        buffer.Append('{');
        if (this.m_typeInfo.BuiltInType == BuiltInType.ByteString)
        {
          if (array.Length > 0)
          {
            byte[] bytes = (byte[]) array.GetValue(0);
            this.AppendByteString(buffer, bytes, formatProvider);
          }
          for (int index = 1; index < array.Length; ++index)
          {
            buffer.Append('|');
            byte[] bytes = (byte[]) array.GetValue(index);
            this.AppendByteString(buffer, bytes, formatProvider);
          }
        }
        else
        {
          if (array.Length > 0)
            this.AppendFormat(buffer, array.GetValue(0), formatProvider);
          for (int index = 1; index < array.Length; ++index)
          {
            buffer.Append('|');
            this.AppendFormat(buffer, array.GetValue(index), formatProvider);
          }
        }
        buffer.Append('}');
      }
      else
        buffer.AppendFormat(formatProvider, "{0}", value);
    }
    else
      buffer.Append("(null)");
  }

  public object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone() => (object) new Variant(Utils.Clone(this.Value));

  public static bool operator ==(Variant a, Variant b) => a.Equals(b);

  public static bool operator !=(Variant a, Variant b) => !a.Equals(b);

  public static implicit operator Variant(bool value) => new Variant(value);

  public static implicit operator Variant(sbyte value) => new Variant(value);

  public static implicit operator Variant(byte value) => new Variant(value);

  public static implicit operator Variant(short value) => new Variant(value);

  public static implicit operator Variant(ushort value) => new Variant(value);

  public static implicit operator Variant(int value) => new Variant(value);

  public static implicit operator Variant(uint value) => new Variant(value);

  public static implicit operator Variant(long value) => new Variant(value);

  public static implicit operator Variant(ulong value) => new Variant(value);

  public static implicit operator Variant(float value) => new Variant(value);

  public static implicit operator Variant(double value) => new Variant(value);

  public static implicit operator Variant(string value) => new Variant(value);

  public static implicit operator Variant(DateTime value) => new Variant(value);

  public static implicit operator Variant(Guid value) => new Variant(value);

  public static implicit operator Variant(Uuid value) => new Variant(value);

  public static implicit operator Variant(byte[] value) => new Variant(value);

  public static implicit operator Variant(XmlElement value) => new Variant(value);

  public static implicit operator Variant(NodeId value) => new Variant(value);

  public static implicit operator Variant(ExpandedNodeId value) => new Variant(value);

  public static implicit operator Variant(StatusCode value) => new Variant(value);

  public static implicit operator Variant(QualifiedName value) => new Variant(value);

  public static implicit operator Variant(LocalizedText value) => new Variant(value);

  public static implicit operator Variant(ExtensionObject value) => new Variant(value);

  public static implicit operator Variant(DataValue value) => new Variant(value);

  public static implicit operator Variant(bool[] value) => new Variant(value);

  public static implicit operator Variant(sbyte[] value) => new Variant(value);

  public static implicit operator Variant(short[] value) => new Variant(value);

  public static implicit operator Variant(ushort[] value) => new Variant(value);

  public static implicit operator Variant(int[] value) => new Variant(value);

  public static implicit operator Variant(uint[] value) => new Variant(value);

  public static implicit operator Variant(long[] value) => new Variant(value);

  public static implicit operator Variant(ulong[] value) => new Variant(value);

  public static implicit operator Variant(float[] value) => new Variant(value);

  public static implicit operator Variant(double[] value) => new Variant(value);

  public static implicit operator Variant(string[] value) => new Variant(value);

  public static implicit operator Variant(DateTime[] value) => new Variant(value);

  public static implicit operator Variant(Guid[] value) => new Variant(value);

  public static implicit operator Variant(Uuid[] value) => new Variant(value);

  public static implicit operator Variant(byte[][] value) => new Variant(value);

  public static implicit operator Variant(XmlElement[] value) => new Variant(value);

  public static implicit operator Variant(NodeId[] value) => new Variant(value);

  public static implicit operator Variant(ExpandedNodeId[] value) => new Variant(value);

  public static implicit operator Variant(StatusCode[] value) => new Variant(value);

  public static implicit operator Variant(QualifiedName[] value) => new Variant(value);

  public static implicit operator Variant(LocalizedText[] value) => new Variant(value);

  public static implicit operator Variant(ExtensionObject[] value) => new Variant(value);

  public static implicit operator Variant(DataValue[] value) => new Variant(value);

  public static implicit operator Variant(Variant[] value) => new Variant(value);

  public static implicit operator Variant(object[] value) => new Variant(value);

  public bool Equals(Variant other)
  {
    Variant? nullable = new Variant?(other);
    return nullable.HasValue && Utils.IsEqual(this.m_value, nullable.Value.m_value);
  }

  public override bool Equals(object obj)
  {
    Variant? nullable = obj as Variant?;
    return nullable.HasValue && Utils.IsEqual(this.m_value, nullable.Value.m_value);
  }

  public override int GetHashCode() => this.m_value != null ? this.m_value.GetHashCode() : 0;

  public override string ToString() => this.ToString((string) null, (IFormatProvider) null);

  public void Set(bool value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.Boolean;
  }

  public void Set(sbyte value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.SByte;
  }

  public void Set(byte value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.Byte;
  }

  public void Set(short value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.Int16;
  }

  public void Set(ushort value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.UInt16;
  }

  public void Set(int value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.Int32;
  }

  public void Set(uint value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.UInt32;
  }

  public void Set(long value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.Int64;
  }

  public void Set(ulong value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.UInt64;
  }

  public void Set(float value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.Float;
  }

  public void Set(double value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.Double;
  }

  public void Set(string value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.String;
  }

  public void Set(DateTime value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.DateTime;
  }

  public void Set(Guid value)
  {
    this.m_value = (object) new Uuid(value);
    this.m_typeInfo = TypeInfo.Scalars.Guid;
  }

  public void Set(Uuid value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.Guid;
  }

  public void Set(byte[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.ByteString;
  }

  public void Set(XmlElement value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.XmlElement;
  }

  public void Set(NodeId value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.NodeId;
  }

  public void Set(ExpandedNodeId value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.ExpandedNodeId;
  }

  public void Set(StatusCode value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.StatusCode;
  }

  public void Set(QualifiedName value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.QualifiedName;
  }

  public void Set(LocalizedText value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.LocalizedText;
  }

  public void Set(ExtensionObject value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.ExtensionObject;
  }

  public void Set(DataValue value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Scalars.DataValue;
  }

  public void Set(bool[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.Boolean;
  }

  public void Set(sbyte[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.SByte;
  }

  public void Set(short[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.Int16;
  }

  public void Set(ushort[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.UInt16;
  }

  public void Set(int[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.Int32;
  }

  public void Set(uint[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.UInt32;
  }

  public void Set(long[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.Int64;
  }

  public void Set(ulong[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.UInt64;
  }

  public void Set(float[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.Float;
  }

  public void Set(double[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.Double;
  }

  public void Set(string[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.String;
  }

  public void Set(DateTime[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.DateTime;
  }

  public void Set(Guid[] value)
  {
    this.m_value = (object) null;
    if (value != null)
    {
      Uuid[] uuidArray = new Uuid[value.Length];
      for (int index = 0; index < value.Length; ++index)
        uuidArray[index] = new Uuid(value[index]);
      this.m_value = (object) uuidArray;
    }
    this.m_typeInfo = TypeInfo.Arrays.Guid;
  }

  public void Set(Uuid[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.Guid;
  }

  public void Set(byte[][] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.ByteString;
  }

  public void Set(XmlElement[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.XmlElement;
  }

  public void Set(NodeId[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.NodeId;
  }

  public void Set(ExpandedNodeId[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.ExpandedNodeId;
  }

  public void Set(StatusCode[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.StatusCode;
  }

  public void Set(QualifiedName[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.QualifiedName;
  }

  public void Set(LocalizedText[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.LocalizedText;
  }

  public void Set(ExtensionObject[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.ExtensionObject;
  }

  public void Set(DataValue[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.DataValue;
  }

  public void Set(Variant[] value)
  {
    this.m_value = (object) value;
    this.m_typeInfo = TypeInfo.Arrays.Variant;
  }

  public void Set(object[] value)
  {
    this.m_value = (object) null;
    if (value != null)
    {
      Variant[] variantArray = new Variant[value.Length];
      for (int index = 0; index < value.Length; ++index)
        variantArray[index] = new Variant(value[index]);
      this.m_value = (object) variantArray;
    }
    this.m_typeInfo = TypeInfo.Arrays.Variant;
  }

  private void SetScalar(object value, TypeInfo typeInfo)
  {
    this.m_typeInfo = typeInfo;
    switch (typeInfo.BuiltInType)
    {
      case BuiltInType.Null:
        if (value.GetType().GetTypeInfo().IsEnum)
        {
          this.Set(Convert.ToInt32(value, (IFormatProvider) CultureInfo.InvariantCulture));
          break;
        }
        this.m_value = value is Matrix matrix ? (object) matrix : throw new ServiceResultException(2151481344U /*0x803D0000*/, Utils.Format("The type '{0}' cannot be stored in a Variant object.", (object) value.GetType().FullName));
        break;
      case BuiltInType.Guid:
        Guid? nullable = value as Guid?;
        if (nullable.HasValue)
        {
          this.m_value = (object) new Uuid(nullable.Value);
          break;
        }
        this.m_value = value;
        break;
      case BuiltInType.ExtensionObject:
        if (value is IEncodeable body)
        {
          this.m_value = (object) new ExtensionObject((object) body);
          break;
        }
        this.m_value = value;
        break;
      case BuiltInType.Variant:
        this.m_value = ((Variant) value).Value;
        this.m_typeInfo = TypeInfo.Construct(this.m_value);
        break;
      default:
        this.m_value = value;
        break;
    }
  }

  private void SetArray(Array array, TypeInfo typeInfo)
  {
    this.m_typeInfo = typeInfo;
    switch (typeInfo.BuiltInType)
    {
      case BuiltInType.Null:
        int[] numArray = array.GetType().GetElementType().GetTypeInfo().IsEnum ? new int[array.Length] : throw new ServiceResultException(2151481344U /*0x803D0000*/, Utils.Format("The type '{0}' cannot be stored in a Variant object.", (object) array.GetType().FullName));
        for (int index = 0; index < array.Length; ++index)
          numArray[index] = Convert.ToInt32(array.GetValue(index), (IFormatProvider) CultureInfo.InvariantCulture);
        this.m_value = (object) numArray;
        break;
      case BuiltInType.Guid:
        if (array is Guid[] guidArray)
        {
          this.Set(guidArray);
          break;
        }
        this.m_value = (object) array;
        break;
      case BuiltInType.ExtensionObject:
        if (array is IEncodeable[] encodeableArray)
        {
          ExtensionObject[] extensionObjectArray = new ExtensionObject[encodeableArray.Length];
          for (int index = 0; index < encodeableArray.Length; ++index)
            extensionObjectArray[index] = new ExtensionObject((object) encodeableArray[index]);
          this.m_value = (object) extensionObjectArray;
          break;
        }
        this.m_value = (object) array;
        break;
      case BuiltInType.Variant:
        if (array is object[] objArray)
        {
          Variant[] variantArray = new Variant[objArray.Length];
          for (int index = 0; index < objArray.Length; ++index)
            variantArray[index] = new Variant(objArray[index]);
          this.m_value = (object) variantArray;
          break;
        }
        this.m_value = (object) array;
        break;
      default:
        this.m_value = (object) array;
        break;
    }
  }

  private void SetList(IList value, TypeInfo typeInfo)
  {
    this.m_typeInfo = typeInfo;
    Array array = TypeInfo.CreateArray(typeInfo.BuiltInType, value.Count);
    for (int index = 0; index < value.Count; ++index)
    {
      if (typeInfo.BuiltInType == BuiltInType.ExtensionObject && value[index] is IEncodeable body)
        array.SetValue((object) new ExtensionObject((object) body), index);
      else
        array.SetValue(value[index], index);
    }
    this.SetArray(array, typeInfo);
  }

  private void Set(object value, TypeInfo typeInfo)
  {
    if (value == null)
    {
      this.m_value = (object) null;
      this.m_typeInfo = typeInfo;
    }
    else if (typeInfo.ValueRank < 0)
    {
      this.SetScalar(value, typeInfo);
    }
    else
    {
      Array array = value as Array;
      if (typeInfo.ValueRank <= 1)
      {
        if (array != null)
        {
          this.SetArray(array, typeInfo);
          return;
        }
        if (value is IList list)
        {
          this.SetList(list, typeInfo);
          return;
        }
      }
      if (array != null)
      {
        this.m_value = (object) new Matrix(array, typeInfo.BuiltInType);
        this.m_typeInfo = typeInfo;
      }
      else
      {
        this.m_value = value is Matrix matrix ? (object) matrix : throw new ServiceResultException(2151481344U /*0x803D0000*/, Utils.Format("Arrays of the type '{0}' cannot be stored in a Variant object.", (object) value.GetType().FullName));
        this.m_typeInfo = matrix.TypeInfo;
      }
    }
  }
}
