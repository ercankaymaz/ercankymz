// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Test.DataGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

#nullable disable
namespace Opc.Ua.Test;

[ComVisible(true)]
public class DataGenerator
{
  private static readonly DataGenerator.BoundaryValues[] s_AvailableBoundaryValues = new DataGenerator.BoundaryValues[22]
  {
    new DataGenerator.BoundaryValues(typeof (sbyte), new object[3]
    {
      (object) sbyte.MinValue,
      (object) (sbyte) 0,
      (object) sbyte.MaxValue
    }),
    new DataGenerator.BoundaryValues(typeof (byte), new object[2]
    {
      (object) (byte) 0,
      (object) byte.MaxValue
    }),
    new DataGenerator.BoundaryValues(typeof (short), new object[3]
    {
      (object) short.MinValue,
      (object) (short) 0,
      (object) short.MaxValue
    }),
    new DataGenerator.BoundaryValues(typeof (ushort), new object[2]
    {
      (object) (ushort) 0,
      (object) ushort.MaxValue
    }),
    new DataGenerator.BoundaryValues(typeof (int), new object[3]
    {
      (object) int.MinValue,
      (object) 0,
      (object) int.MaxValue
    }),
    new DataGenerator.BoundaryValues(typeof (uint), new object[2]
    {
      (object) 0U,
      (object) uint.MaxValue
    }),
    new DataGenerator.BoundaryValues(typeof (long), new object[3]
    {
      (object) long.MinValue,
      (object) 0L,
      (object) long.MaxValue
    }),
    new DataGenerator.BoundaryValues(typeof (ulong), new object[2]
    {
      (object) 0UL,
      (object) ulong.MaxValue
    }),
    new DataGenerator.BoundaryValues(typeof (float), new object[7]
    {
      (object) float.Epsilon,
      (object) float.MaxValue,
      (object) float.MinValue,
      (object) float.NaN,
      (object) float.NegativeInfinity,
      (object) float.PositiveInfinity,
      (object) 0.0f
    }),
    new DataGenerator.BoundaryValues(typeof (double), new object[7]
    {
      (object) double.Epsilon,
      (object) double.MaxValue,
      (object) double.MinValue,
      (object) double.NaN,
      (object) double.NegativeInfinity,
      (object) double.PositiveInfinity,
      (object) 0.0
    }),
    new DataGenerator.BoundaryValues(typeof (string), new object[2]
    {
      null,
      (object) string.Empty
    }),
    new DataGenerator.BoundaryValues(typeof (DateTime), new object[6]
    {
      (object) DateTime.MinValue,
      (object) DateTime.MaxValue,
      (object) new DateTime(1099, 1, 1),
      (object) Utils.TimeBase,
      (object) new DateTime(2039, 4, 4),
      (object) new DateTime(2001, 9, 11, 9, 15, 0, DateTimeKind.Local)
    }),
    new DataGenerator.BoundaryValues(typeof (Guid), new object[1]
    {
      (object) Guid.Empty
    }),
    new DataGenerator.BoundaryValues(typeof (Uuid), new object[1]
    {
      (object) Uuid.Empty
    }),
    new DataGenerator.BoundaryValues(typeof (byte[]), new object[2]
    {
      null,
      (object) Array.Empty<byte>()
    }),
    new DataGenerator.BoundaryValues(typeof (XmlElement), (object[]) null),
    new DataGenerator.BoundaryValues(typeof (NodeId), new object[5]
    {
      null,
      (object) NodeId.Null,
      (object) new NodeId(Guid.Empty),
      (object) new NodeId(string.Empty),
      (object) new NodeId(Array.Empty<byte>())
    }),
    new DataGenerator.BoundaryValues(typeof (ExpandedNodeId), new object[5]
    {
      null,
      (object) ExpandedNodeId.Null,
      (object) new ExpandedNodeId(Guid.Empty),
      (object) new ExpandedNodeId(string.Empty),
      (object) new ExpandedNodeId(Array.Empty<byte>())
    }),
    new DataGenerator.BoundaryValues(typeof (QualifiedName), new object[2]
    {
      null,
      (object) QualifiedName.Null
    }),
    new DataGenerator.BoundaryValues(typeof (LocalizedText), new object[2]
    {
      null,
      (object) LocalizedText.Null
    }),
    new DataGenerator.BoundaryValues(typeof (StatusCode), new object[3]
    {
      (object) 0U,
      (object) 1073741824U /*0x40000000*/,
      (object) 2147483648U /*0x80000000*/
    }),
    new DataGenerator.BoundaryValues(typeof (ExtensionObject), new object[1]
    {
      (object) ExtensionObject.Null
    })
  };
  private IRandomSource m_random;
  private int m_maxArrayLength;
  private int m_maxStringLength;
  private DateTime m_minDateTimeValue;
  private DateTime m_maxDateTimeValue;
  private int m_boundaryValueFrequency;
  private int m_maxXmlAttributeCount;
  private int m_maxXmlElementCount;
  private NamespaceTable m_namespaceUris;
  private StringTable m_serverUris;
  private SortedDictionary<string, object[]> m_boundaryValues;
  private string[] m_availableLocales;
  private SortedDictionary<string, string[]> m_tokenValues;
  private const string kPunctuation = "`~!@#$%^&*()_-+={}[]:\"';?><,./";

  public DataGenerator(IRandomSource random)
  {
    this.m_maxArrayLength = 100;
    this.m_maxStringLength = 100;
    this.m_maxXmlAttributeCount = 10;
    this.m_maxXmlElementCount = 10;
    this.m_minDateTimeValue = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    this.m_maxDateTimeValue = new DateTime(2100, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    this.m_random = random;
    this.m_boundaryValueFrequency = 20;
    this.m_namespaceUris = new NamespaceTable();
    this.m_serverUris = new StringTable();
    if (this.m_random == null)
      this.m_random = (IRandomSource) new RandomSource();
    this.m_boundaryValues = new SortedDictionary<string, object[]>();
    for (int index = 0; index < DataGenerator.s_AvailableBoundaryValues.Length; ++index)
      this.m_boundaryValues[DataGenerator.s_AvailableBoundaryValues[index].SystemType.Name] = DataGenerator.s_AvailableBoundaryValues[index].Values.ToArray();
    this.m_tokenValues = DataGenerator.LoadStringData("Opc.Ua.Types.Utils.LocalizedData.txt");
    if (this.m_tokenValues.Count == 0)
      this.m_tokenValues = DataGenerator.LoadStringData("Opc.Ua.Utils.LocalizedData.txt");
    this.m_availableLocales = new string[this.m_tokenValues.Count];
    int num = 0;
    foreach (string key in this.m_tokenValues.Keys)
      this.m_availableLocales[num++] = key;
  }

  public int MaxArrayLength
  {
    get => this.m_maxArrayLength;
    set => this.m_maxArrayLength = value;
  }

  public int MaxStringLength
  {
    get => this.m_maxStringLength;
    set => this.m_maxStringLength = value;
  }

  public DateTime MinDateTimeValue
  {
    get => this.m_minDateTimeValue;
    set => this.m_minDateTimeValue = value;
  }

  public DateTime MaxDateTimeValue
  {
    get => this.m_maxDateTimeValue;
    set => this.m_maxDateTimeValue = value;
  }

  public int MaxXmlAttributeCount
  {
    get => this.m_maxXmlAttributeCount;
    set => this.m_maxXmlAttributeCount = value;
  }

  public int MaxXmlElementCount
  {
    get => this.m_maxXmlElementCount;
    set => this.m_maxXmlElementCount = value;
  }

  public NamespaceTable NamespaceUris
  {
    get => this.m_namespaceUris;
    set => this.m_namespaceUris = value;
  }

  public StringTable ServerUris
  {
    get => this.m_serverUris;
    set => this.m_serverUris = value;
  }

  public int BoundaryValueFrequency
  {
    get => this.m_boundaryValueFrequency;
    set => this.m_boundaryValueFrequency = value;
  }

  private bool UseBoundaryValue() => this.m_random.NextInt32(99) < this.m_boundaryValueFrequency;

  public object GetRandom(
    NodeId dataType,
    int valueRank,
    IList<uint> arrayDimensions,
    ITypeTable typeTree)
  {
    BuiltInType builtInType1 = Opc.Ua.TypeInfo.GetBuiltInType(dataType, typeTree);
    int length1;
    switch (valueRank)
    {
      case -3:
        length1 = this.GetRandomRange(0, 1);
        break;
      case -2:
        length1 = arrayDimensions == null || arrayDimensions.Count <= 0 ? this.GetRandomRange(0, 1) : arrayDimensions.Count;
        break;
      case -1:
        length1 = 0;
        break;
      case 0:
        length1 = arrayDimensions == null || arrayDimensions.Count <= 0 ? this.GetRandomRange(1, 1) : arrayDimensions.Count;
        break;
      default:
        length1 = valueRank;
        break;
    }
    if (length1 == 0)
    {
      if (builtInType1 != BuiltInType.Variant)
        return this.GetRandom(builtInType1);
      BuiltInType builtInType2 = BuiltInType.Variant;
      while (builtInType2 == BuiltInType.Variant || builtInType2 == BuiltInType.DataValue)
        builtInType2 = (BuiltInType) this.m_random.NextInt32(24);
      return (object) this.GetRandomVariant(builtInType2, false);
    }
    int[] numArray1 = new int[length1];
    for (int index = 0; index < length1; ++index)
    {
      if (arrayDimensions != null && arrayDimensions.Count > index)
        numArray1[index] = (int) arrayDimensions[index];
      while (numArray1[index] == 0)
        numArray1[index] = this.m_random.NextInt32(this.m_maxArrayLength);
    }
    Array array = Opc.Ua.TypeInfo.CreateArray(builtInType1, numArray1);
    int length2 = array.Length;
    int[] numArray2 = new int[numArray1.Length];
    for (int index1 = 0; index1 < length2; ++index1)
    {
      int length3 = array.Length;
      for (int index2 = 0; index2 < numArray2.Length; ++index2)
      {
        length3 /= numArray1[index2];
        numArray2[index2] = index1 / length3 % numArray1[index2];
      }
      object obj = this.GetRandom(dataType, -1, (IList<uint>) null, typeTree);
      if (obj != null)
      {
        if (builtInType1 == BuiltInType.Guid && obj is Guid)
          obj = (object) new Uuid((Guid) obj);
        array.SetValue(obj, numArray2);
      }
    }
    return (object) array;
  }

  public object GetRandom(BuiltInType expectedType)
  {
    switch (expectedType)
    {
      case BuiltInType.Boolean:
        return (object) this.GetRandomBoolean();
      case BuiltInType.SByte:
        return (object) this.GetRandomSByte();
      case BuiltInType.Byte:
        return (object) this.GetRandomByte();
      case BuiltInType.Int16:
        return (object) this.GetRandomInt16();
      case BuiltInType.UInt16:
        return (object) this.GetRandomUInt16();
      case BuiltInType.Int32:
        return (object) this.GetRandomInt32();
      case BuiltInType.UInt32:
        return (object) this.GetRandomUInt32();
      case BuiltInType.Int64:
        return (object) this.GetRandomInt64();
      case BuiltInType.UInt64:
        return (object) this.GetRandomUInt64();
      case BuiltInType.Float:
        return (object) this.GetRandomFloat();
      case BuiltInType.Double:
        return (object) this.GetRandomDouble();
      case BuiltInType.String:
        return (object) this.GetRandomString();
      case BuiltInType.DateTime:
        return (object) this.GetRandomDateTime();
      case BuiltInType.Guid:
        return (object) this.GetRandomUuid();
      case BuiltInType.ByteString:
        return (object) this.GetRandomByteString();
      case BuiltInType.XmlElement:
        return (object) this.GetRandomXmlElement();
      case BuiltInType.NodeId:
        return (object) this.GetRandomNodeId();
      case BuiltInType.ExpandedNodeId:
        return (object) this.GetRandomExpandedNodeId();
      case BuiltInType.StatusCode:
        return (object) this.GetRandomStatusCode();
      case BuiltInType.QualifiedName:
        return (object) this.GetRandomQualifiedName();
      case BuiltInType.LocalizedText:
        return (object) this.GetRandomLocalizedText();
      case BuiltInType.ExtensionObject:
        return (object) this.GetRandomExtensionObject();
      case BuiltInType.DataValue:
        return (object) this.GetRandomDataValue();
      case BuiltInType.Variant:
        return (object) this.GetRandomVariant();
      case BuiltInType.DiagnosticInfo:
        return (object) this.GetRandomDiagnosticInfo();
      case BuiltInType.Number:
        return (object) this.GetRandomVariant((BuiltInType) (this.m_random.NextInt32(9) + 2), false);
      case BuiltInType.Integer:
        return (object) this.GetRandomVariant((BuiltInType) (this.m_random.NextInt32(3) * 2 + 2), false);
      case BuiltInType.UInteger:
        return (object) this.GetRandomVariant((BuiltInType) (this.m_random.NextInt32(3) * 2 + 3), false);
      case BuiltInType.Enumeration:
        return (object) this.GetRandomInt32();
      default:
        return (object) null;
    }
  }

  public Array GetRandomArray(
    BuiltInType expectedType,
    bool useBoundaryValues,
    int length,
    bool fixedLength)
  {
    switch (expectedType)
    {
      case BuiltInType.Null:
        return (Array) this.GetNullArray<object>(length, fixedLength);
      case BuiltInType.Boolean:
        return (Array) this.GetRandomArray<bool>(useBoundaryValues, length, fixedLength);
      case BuiltInType.SByte:
        return (Array) this.GetRandomArray<sbyte>(useBoundaryValues, length, fixedLength);
      case BuiltInType.Byte:
        return (Array) this.GetRandomArray<byte>(useBoundaryValues, length, fixedLength);
      case BuiltInType.Int16:
        return (Array) this.GetRandomArray<short>(useBoundaryValues, length, fixedLength);
      case BuiltInType.UInt16:
        return (Array) this.GetRandomArray<ushort>(useBoundaryValues, length, fixedLength);
      case BuiltInType.Int32:
        return (Array) this.GetRandomArray<int>(useBoundaryValues, length, fixedLength);
      case BuiltInType.UInt32:
        return (Array) this.GetRandomArray<uint>(useBoundaryValues, length, fixedLength);
      case BuiltInType.Int64:
        return (Array) this.GetRandomArray<long>(useBoundaryValues, length, fixedLength);
      case BuiltInType.UInt64:
        return (Array) this.GetRandomArray<ulong>(useBoundaryValues, length, fixedLength);
      case BuiltInType.Float:
        return (Array) this.GetRandomArray<float>(useBoundaryValues, length, fixedLength);
      case BuiltInType.Double:
        return (Array) this.GetRandomArray<double>(useBoundaryValues, length, fixedLength);
      case BuiltInType.String:
        return (Array) this.GetRandomArray<string>(useBoundaryValues, length, fixedLength);
      case BuiltInType.DateTime:
        return (Array) this.GetRandomArray<DateTime>(useBoundaryValues, length, fixedLength);
      case BuiltInType.Guid:
        return (Array) this.GetRandomArray<Uuid>(useBoundaryValues, length, fixedLength);
      case BuiltInType.ByteString:
        return (Array) this.GetRandomArray<byte[]>(useBoundaryValues, length, fixedLength);
      case BuiltInType.XmlElement:
        return (Array) this.GetRandomArray<XmlElement>(useBoundaryValues, length, fixedLength);
      case BuiltInType.NodeId:
        return (Array) this.GetRandomArray<NodeId>(useBoundaryValues, length, fixedLength);
      case BuiltInType.ExpandedNodeId:
        return (Array) this.GetRandomArray<ExpandedNodeId>(useBoundaryValues, length, fixedLength);
      case BuiltInType.StatusCode:
        return (Array) this.GetRandomArray<StatusCode>(useBoundaryValues, length, fixedLength);
      case BuiltInType.QualifiedName:
        return (Array) this.GetRandomArray<QualifiedName>(useBoundaryValues, length, fixedLength);
      case BuiltInType.LocalizedText:
        return (Array) this.GetRandomArray<LocalizedText>(useBoundaryValues, length, fixedLength);
      case BuiltInType.ExtensionObject:
        return (Array) this.GetRandomArray<ExtensionObject>(useBoundaryValues, length, fixedLength);
      case BuiltInType.Variant:
        return (Array) this.GetRandomArray<Opc.Ua.Variant>(useBoundaryValues, length, fixedLength);
      case BuiltInType.Number:
        return (Array) this.GetRandomArrayInVariant((BuiltInType) (this.m_random.NextInt32(9) + 2), useBoundaryValues, length, fixedLength);
      case BuiltInType.Integer:
        return (Array) this.GetRandomArrayInVariant((BuiltInType) (this.m_random.NextInt32(3) * 2 + 2), useBoundaryValues, length, fixedLength);
      case BuiltInType.UInteger:
        return (Array) this.GetRandomArrayInVariant((BuiltInType) (this.m_random.NextInt32(3) * 2 + 3), useBoundaryValues, length, fixedLength);
      case BuiltInType.Enumeration:
        return (Array) this.GetRandomArray<int>(useBoundaryValues, length, fixedLength);
      default:
        return (Array) null;
    }
  }

  private Opc.Ua.Variant[] GetRandomArrayInVariant(
    BuiltInType builtInType,
    bool useBoundaryValues,
    int length,
    bool fixedLength)
  {
    Array randomArray = this.GetRandomArray(builtInType, useBoundaryValues, length, fixedLength);
    Opc.Ua.Variant[] randomArrayInVariant = new Opc.Ua.Variant[randomArray.Length];
    Opc.Ua.TypeInfo typeInfo = new Opc.Ua.TypeInfo(builtInType, -1);
    for (int index = 0; index < randomArrayInVariant.Length; ++index)
      randomArrayInVariant[index] = new Opc.Ua.Variant(randomArray.GetValue(index), typeInfo);
    return randomArrayInVariant;
  }

  public T GetRandom<T>(bool useBoundaryValues)
  {
    if (useBoundaryValues && this.UseBoundaryValue())
    {
      object boundaryValue = this.GetBoundaryValue(typeof (T));
      if (boundaryValue != null || !typeof (T).GetTypeInfo().IsValueType)
        return (T) boundaryValue;
    }
    return (T) this.GetRandom(typeof (T));
  }

  public T[] GetNullArray<T>(int length, bool fixedLength)
  {
    if (length < 0)
      return (T[]) null;
    if (!fixedLength)
      length = this.m_random.NextInt32(length);
    T[] nullArray = new T[length];
    for (int index = 0; index < nullArray.Length; ++index)
      nullArray[index] = default (T);
    return nullArray;
  }

  public T[] GetRandomArray<T>(bool useBoundaryValues, int length, bool fixedLength)
  {
    if (length < 0)
      return (T[]) null;
    if (!fixedLength)
      length = this.m_random.NextInt32(length);
    T[] randomArray = new T[length];
    for (int index = 0; index < randomArray.Length; ++index)
    {
      object obj = !useBoundaryValues || !this.UseBoundaryValue() ? this.GetRandom(typeof (T)) : this.GetBoundaryValue(typeof (T));
      if (obj == null)
      {
        obj = (object) default (T);
        if (obj == null)
        {
          Type type = typeof (T);
          if (type == typeof (ExpandedNodeId))
            obj = (object) ExpandedNodeId.Null;
          else if (type == typeof (NodeId))
            obj = (object) NodeId.Null;
          else if (type == typeof (LocalizedText))
            obj = (object) LocalizedText.Null;
          else if (type == typeof (QualifiedName))
            obj = (object) QualifiedName.Null;
        }
      }
      randomArray[index] = (T) obj;
    }
    return randomArray;
  }

  public bool GetRandomBoolean() => this.m_random.NextInt32(1) != 0;

  public sbyte GetRandomSByte()
  {
    int num = this.m_random.NextInt32((int) byte.MaxValue);
    return num > (int) sbyte.MaxValue ? (sbyte) (num - (int) sbyte.MaxValue - 128 /*0x80*/ - 1) : (sbyte) num;
  }

  public byte GetRandomByte() => (byte) this.m_random.NextInt32((int) byte.MaxValue);

  public short GetRandomInt16()
  {
    int num = this.m_random.NextInt32((int) ushort.MaxValue);
    return num > (int) short.MaxValue ? (short) (num - (int) short.MaxValue - 32768 /*0x8000*/ - 1) : (short) num;
  }

  public ushort GetRandomUInt16() => (ushort) this.m_random.NextInt32((int) ushort.MaxValue);

  public int GetRandomInt32() => this.m_random.NextInt32(int.MaxValue);

  public uint GetRandomUInt32()
  {
    byte[] bytes = new byte[4];
    this.m_random.NextBytes(bytes, 0, bytes.Length);
    return BitConverter.ToUInt32(bytes, 0);
  }

  public long GetRandomInt64()
  {
    byte[] bytes = new byte[8];
    this.m_random.NextBytes(bytes, 0, bytes.Length);
    return BitConverter.ToInt64(bytes, 0);
  }

  public ulong GetRandomUInt64()
  {
    byte[] bytes = new byte[8];
    this.m_random.NextBytes(bytes, 0, bytes.Length);
    return BitConverter.ToUInt64(bytes, 0);
  }

  public float GetRandomFloat()
  {
    byte[] bytes = new byte[4];
    this.m_random.NextBytes(bytes, 0, bytes.Length);
    return BitConverter.ToSingle(bytes, 0);
  }

  public double GetRandomDouble()
  {
    byte[] bytes = new byte[8];
    this.m_random.NextBytes(bytes, 0, bytes.Length);
    return (double) BitConverter.ToSingle(bytes, 0);
  }

  public string GetRandomString() => this.CreateString(this.GetRandomLocale(), false);

  public string GetRandomString(string locale) => this.CreateString(locale, false);

  public string GetRandomSymbol() => this.CreateString(this.GetRandomLocale(), true);

  public string GetRandomSymbol(string locale) => this.CreateString(locale, false);

  public DateTime GetRandomDateTime()
  {
    return new DateTime(((long) this.GetRandomRange((int) (this.m_minDateTimeValue.Ticks >> 32 /*0x20*/), (int) (this.m_maxDateTimeValue.Ticks >> 32 /*0x20*/)) << 32 /*0x20*/) + (long) this.GetRandomUInt32(), DateTimeKind.Utc);
  }

  public Guid GetRandomGuid()
  {
    byte[] numArray = new byte[16 /*0x10*/];
    this.m_random.NextBytes(numArray, 0, numArray.Length);
    return new Guid(numArray);
  }

  public Uuid GetRandomUuid()
  {
    byte[] numArray = new byte[16 /*0x10*/];
    this.m_random.NextBytes(numArray, 0, numArray.Length);
    return new Uuid(new Guid(numArray));
  }

  public byte[] GetRandomByteString()
  {
    byte[] bytes = new byte[this.m_random.NextInt32(this.m_maxStringLength)];
    this.m_random.NextBytes(bytes, 0, bytes.Length);
    return bytes;
  }

  public XmlElement GetRandomXmlElement()
  {
    string randomLocale1 = this.GetRandomLocale();
    string randomLocale2 = this.GetRandomLocale();
    XmlDocument xmlDocument = new XmlDocument();
    XmlElement element1 = xmlDocument.CreateElement("n0", this.CreateString(randomLocale1, true), Utils.Format("http://{0}", (object) this.CreateString(randomLocale1, true)));
    xmlDocument.AppendChild((XmlNode) element1);
    int num1 = this.m_random.NextInt32(this.m_maxXmlAttributeCount);
    for (int index = 0; index < num1; ++index)
    {
      string name = this.CreateString(randomLocale1, true);
      XmlAttribute attribute = xmlDocument.CreateAttribute(name);
      attribute.Value = this.CreateString(randomLocale2, true);
      element1.SetAttributeNode(attribute);
    }
    int num2 = this.m_random.NextInt32(this.m_maxXmlElementCount);
    for (int index = 0; index < num2; ++index)
    {
      string localName = this.CreateString(randomLocale1, true);
      XmlElement element2 = xmlDocument.CreateElement(element1.Prefix, localName, element1.NamespaceURI);
      element2.InnerText = this.CreateString(randomLocale2, false);
      element1.AppendChild((XmlNode) element2);
    }
    return element1;
  }

  public NodeId GetRandomNodeId()
  {
    ushort namespaceIndex = (ushort) this.m_random.NextInt32(this.m_namespaceUris.Count - 1);
    switch (this.m_random.NextInt32(4))
    {
      case 1:
        return new NodeId(this.CreateString(this.GetRandomLocale(), true), namespaceIndex);
      case 2:
        return new NodeId(this.GetRandomGuid(), namespaceIndex);
      case 3:
        return new NodeId(this.GetRandomByteString(), namespaceIndex);
      default:
        return new NodeId(this.GetRandomUInt32(), namespaceIndex);
    }
  }

  public ExpandedNodeId GetRandomExpandedNodeId()
  {
    NodeId randomNodeId = this.GetRandomNodeId();
    ushort serverIndex = this.m_serverUris.Count == 0 ? (ushort) 0 : (ushort) this.m_random.NextInt32(this.m_serverUris.Count - 1);
    return new ExpandedNodeId(randomNodeId, this.m_namespaceUris.GetString((uint) randomNodeId.NamespaceIndex), (uint) serverIndex);
  }

  public QualifiedName GetRandomQualifiedName()
  {
    ushort namespaceIndex = (ushort) this.m_random.NextInt32(this.m_namespaceUris.Count - 1);
    return new QualifiedName(this.CreateString(this.GetRandomLocale(), true), namespaceIndex);
  }

  public LocalizedText GetRandomLocalizedText()
  {
    string randomLocale = this.GetRandomLocale();
    return new LocalizedText(randomLocale, this.CreateString(randomLocale, false));
  }

  public StatusCode GetRandomStatusCode()
  {
    return (StatusCode) (uint) (2147549184UL /*0x80010000*/ + (ulong) (this.GetRandomRange(32769, 32951) << 16 /*0x10*/));
  }

  public Opc.Ua.Variant GetRandomVariant() => this.GetRandomVariant(true);

  public Opc.Ua.Variant GetRandomVariant(bool allowArrays)
  {
    BuiltInType builtInType = BuiltInType.Variant;
    while (builtInType == BuiltInType.Variant || builtInType == BuiltInType.DataValue)
      builtInType = (BuiltInType) this.m_random.NextInt32(24);
    return this.GetRandomVariant(builtInType, allowArrays && this.m_random.NextInt32(1) == 1);
  }

  private Opc.Ua.Variant GetRandomVariant(BuiltInType builtInType, bool isArray)
  {
    if (builtInType == BuiltInType.Null)
      return Opc.Ua.Variant.Null;
    int length = -1;
    if (isArray)
      length = this.m_random.NextInt32(this.m_maxArrayLength - 1);
    else if (builtInType == BuiltInType.Variant)
      length = 1;
    if (length >= 0)
    {
      switch (builtInType)
      {
        case BuiltInType.Boolean:
          return new Opc.Ua.Variant(this.GetRandomArray<bool>(true, length, true));
        case BuiltInType.SByte:
          return new Opc.Ua.Variant(this.GetRandomArray<sbyte>(true, length, true));
        case BuiltInType.Byte:
          return new Opc.Ua.Variant(this.GetRandomArray<byte>(true, length, true));
        case BuiltInType.Int16:
          return new Opc.Ua.Variant(this.GetRandomArray<short>(true, length, true));
        case BuiltInType.UInt16:
          return new Opc.Ua.Variant(this.GetRandomArray<ushort>(true, length, true));
        case BuiltInType.Int32:
          return new Opc.Ua.Variant(this.GetRandomArray<int>(true, length, true));
        case BuiltInType.UInt32:
          return new Opc.Ua.Variant(this.GetRandomArray<uint>(true, length, true));
        case BuiltInType.Int64:
          return new Opc.Ua.Variant(this.GetRandomArray<long>(true, length, true));
        case BuiltInType.UInt64:
          return new Opc.Ua.Variant(this.GetRandomArray<ulong>(true, length, true));
        case BuiltInType.Float:
          return new Opc.Ua.Variant(this.GetRandomArray<float>(true, length, true));
        case BuiltInType.Double:
          return new Opc.Ua.Variant(this.GetRandomArray<double>(true, length, true));
        case BuiltInType.String:
          return new Opc.Ua.Variant(this.GetRandomArray<string>(true, length, true));
        case BuiltInType.DateTime:
          return new Opc.Ua.Variant(this.GetRandomArray<DateTime>(true, length, true));
        case BuiltInType.Guid:
          return new Opc.Ua.Variant(this.GetRandomArray<Uuid>(true, length, true));
        case BuiltInType.ByteString:
          return new Opc.Ua.Variant(this.GetRandomArray<byte[]>(true, length, true));
        case BuiltInType.XmlElement:
          return new Opc.Ua.Variant(this.GetRandomArray<XmlElement>(true, length, true));
        case BuiltInType.NodeId:
          return new Opc.Ua.Variant(this.GetRandomArray<NodeId>(true, length, true));
        case BuiltInType.ExpandedNodeId:
          return new Opc.Ua.Variant(this.GetRandomArray<ExpandedNodeId>(true, length, true));
        case BuiltInType.StatusCode:
          return new Opc.Ua.Variant(this.GetRandomArray<StatusCode>(true, length, true));
        case BuiltInType.QualifiedName:
          return new Opc.Ua.Variant(this.GetRandomArray<QualifiedName>(true, length, true));
        case BuiltInType.LocalizedText:
          return new Opc.Ua.Variant(this.GetRandomArray<LocalizedText>(true, length, true));
        case BuiltInType.Variant:
          return new Opc.Ua.Variant(this.GetRandomArray<Opc.Ua.Variant>(true, length, true));
      }
    }
    return new Opc.Ua.Variant(this.GetRandom(builtInType));
  }

  public ExtensionObject GetRandomExtensionObject()
  {
    NodeId randomNodeId = this.GetRandomNodeId();
    if (NodeId.IsNull(randomNodeId))
      return ExtensionObject.Null;
    object body = this.m_random.NextInt32(1) == 0 ? (object) this.GetRandomXmlElement() : (object) this.GetRandomByteString();
    return new ExtensionObject((ExpandedNodeId) randomNodeId, body);
  }

  public DataValue GetRandomDataValue()
  {
    Opc.Ua.Variant randomVariant = this.GetRandomVariant();
    StatusCode randomStatusCode = this.GetRandomStatusCode();
    DateTime randomDateTime = this.GetRandomDateTime();
    this.GetRandomDateTime();
    StatusCode statusCode = randomStatusCode;
    DateTime sourceTimestamp = randomDateTime;
    DateTime utcNow = DateTime.UtcNow;
    return new DataValue(randomVariant, statusCode, sourceTimestamp, utcNow);
  }

  public DiagnosticInfo GetRandomDiagnosticInfo()
  {
    return new DiagnosticInfo(ServiceResult.Good, DiagnosticsMasks.NoInnerStatus, true, new StringTable());
  }

  public object GetRandomNumber()
  {
    switch (this.m_random.NextInt32(5))
    {
      case 0:
      case 1:
        return this.GetRandomInteger();
      case 2:
      case 3:
        return this.GetRandomUInteger();
      case 4:
        return (object) this.GetRandomFloat();
      default:
        return (object) this.GetRandomDouble();
    }
  }

  public object GetRandomInteger()
  {
    switch (this.m_random.NextInt32(3))
    {
      case 0:
        return (object) this.GetRandomSByte();
      case 1:
        return (object) this.GetRandomInt16();
      case 2:
        return (object) this.GetRandomInt32();
      default:
        return (object) this.GetRandomInt64();
    }
  }

  public object GetRandomUInteger()
  {
    switch (this.m_random.NextInt32(3))
    {
      case 0:
        return (object) this.GetRandomByte();
      case 1:
        return (object) this.GetRandomUInt16();
      case 2:
        return (object) this.GetRandomUInt32();
      default:
        return (object) this.GetRandomUInt64();
    }
  }

  private static SortedDictionary<string, string[]> LoadStringData(string resourceName)
  {
    SortedDictionary<string, string[]> sortedDictionary = new SortedDictionary<string, string[]>();
    try
    {
      string key = (string) null;
      List<string> stringList = (List<string>) null;
      using (StreamReader streamReader = new StreamReader(typeof (DataGenerator).GetTypeInfo().Assembly.GetManifestResourceStream(resourceName) ?? (Stream) new FileInfo(resourceName).OpenRead()))
      {
        for (string str1 = streamReader.ReadLine(); str1 != null; str1 = streamReader.ReadLine())
        {
          string str2 = str1.Trim();
          if (!string.IsNullOrEmpty(str2))
          {
            if (str2.StartsWith("=", StringComparison.Ordinal))
            {
              if (key != null)
                sortedDictionary.Add(key, stringList.ToArray());
              key = str2.Substring(1);
              stringList = new List<string>();
            }
            else
              stringList.Add(str2);
          }
        }
      }
      return sortedDictionary;
    }
    catch (Exception ex)
    {
      return sortedDictionary;
    }
  }

  private object GetBoundaryValue(Type type)
  {
    if (type == (Type) null)
      return (object) null;
    object[] objArray = (object[]) null;
    if (!this.m_boundaryValues.TryGetValue(type.Name, out objArray))
      return (object) null;
    if (objArray == null || objArray.Length == 0)
      return (object) null;
    int index = this.m_random.NextInt32(objArray.Length - 1);
    return type.IsInstanceOfType(objArray[index]) ? objArray[index] : (object) null;
  }

  private int GetRandomRange(int min, int max)
  {
    if (min < 0)
      min = 0;
    if (max < 0)
      max = 0;
    return min >= max ? min : this.m_random.NextInt32(max - min) + min;
  }

  private object GetRandom(Type expectedType)
  {
    BuiltInType builtInType = Opc.Ua.TypeInfo.Construct(expectedType).BuiltInType;
    object random = this.GetRandom(builtInType);
    return builtInType == BuiltInType.Guid && expectedType == typeof (Guid) ? (object) (Guid) (Uuid) random : random;
  }

  private string GetRandomLocale()
  {
    return this.m_availableLocales[this.m_random.NextInt32(this.m_availableLocales.Length - 1)];
  }

  private string CreateString(string locale, bool isSymbol)
  {
    string[] strArray = (string[]) null;
    if (!this.m_tokenValues.TryGetValue(locale, out strArray))
      strArray = this.m_tokenValues["en-US"];
    int num = !isSymbol ? this.m_random.NextInt32(this.m_maxStringLength) + 1 : this.m_random.NextInt32(2) + 1;
    StringBuilder stringBuilder = new StringBuilder();
    while (stringBuilder.Length < num)
    {
      if (!isSymbol && stringBuilder.Length > 0)
        stringBuilder.Append(' ');
      int index1 = this.m_random.NextInt32(strArray.Length - 1);
      stringBuilder.Append(strArray[index1]);
      if (!isSymbol && this.m_random.NextInt32(1) != 0)
      {
        int index2 = this.m_random.NextInt32("`~!@#$%^&*()_-+={}[]:\"';?><,./".Length - 1);
        stringBuilder.Append("`~!@#$%^&*()_-+={}[]:\"';?><,./"[index2]);
      }
    }
    return stringBuilder.ToString();
  }

  private class BoundaryValues
  {
    public Type SystemType;
    public List<object> Values;

    public BoundaryValues(Type systemType, params object[] values)
    {
      this.SystemType = systemType;
      if (values != null)
        this.Values = new List<object>((IEnumerable<object>) values);
      else
        this.Values = new List<object>();
    }
  }
}
