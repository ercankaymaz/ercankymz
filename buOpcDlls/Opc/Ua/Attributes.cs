// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Attributes
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Reflection;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public static class Attributes
{
  public const uint NodeId = 1;
  public const uint NodeClass = 2;
  public const uint BrowseName = 3;
  public const uint DisplayName = 4;
  public const uint Description = 5;
  public const uint WriteMask = 6;
  public const uint UserWriteMask = 7;
  public const uint IsAbstract = 8;
  public const uint Symmetric = 9;
  public const uint InverseName = 10;
  public const uint ContainsNoLoops = 11;
  public const uint EventNotifier = 12;
  public const uint Value = 13;
  public const uint DataType = 14;
  public const uint ValueRank = 15;
  public const uint ArrayDimensions = 16 /*0x10*/;
  public const uint AccessLevel = 17;
  public const uint UserAccessLevel = 18;
  public const uint MinimumSamplingInterval = 19;
  public const uint Historizing = 20;
  public const uint Executable = 21;
  public const uint UserExecutable = 22;
  public const uint DataTypeDefinition = 23;
  public const uint RolePermissions = 24;
  public const uint UserRolePermissions = 25;
  public const uint AccessRestrictions = 26;
  public const uint AccessLevelEx = 27;

  public static bool IsValid(uint attributeId) => attributeId >= 1U && attributeId <= 27U;

  public static string GetBrowseName(uint identifier)
  {
    foreach (FieldInfo field in typeof (Attributes).GetFields(BindingFlags.Static | BindingFlags.Public))
    {
      if ((int) identifier == (int) (uint) field.GetValue((object) typeof (Attributes)))
        return field.Name;
    }
    return string.Empty;
  }

  public static string[] GetBrowseNames()
  {
    FieldInfo[] fields = typeof (Attributes).GetFields(BindingFlags.Static | BindingFlags.Public);
    int num = 0;
    string[] browseNames = new string[fields.Length];
    foreach (FieldInfo fieldInfo in fields)
      browseNames[num++] = fieldInfo.Name;
    return browseNames;
  }

  public static uint GetIdentifier(string browseName)
  {
    foreach (FieldInfo field in typeof (Attributes).GetFields(BindingFlags.Static | BindingFlags.Public))
    {
      if (field.Name == browseName)
        return (uint) field.GetValue((object) typeof (Attributes));
    }
    return 0;
  }

  public static uint[] GetIdentifiers()
  {
    FieldInfo[] fields = typeof (Attributes).GetFields(BindingFlags.Static | BindingFlags.Public);
    int num = 0;
    uint[] identifiers = new uint[fields.Length];
    foreach (FieldInfo fieldInfo in fields)
      identifiers[num++] = (uint) fieldInfo.GetValue((object) typeof (Attributes));
    return identifiers;
  }

  public static UInt32Collection GetIdentifiers(Opc.Ua.NodeClass nodeClass)
  {
    FieldInfo[] fields = typeof (Attributes).GetFields(BindingFlags.Static | BindingFlags.Public);
    UInt32Collection identifiers = new UInt32Collection(fields.Length);
    foreach (FieldInfo fieldInfo in fields)
    {
      uint attributeId = (uint) fieldInfo.GetValue((object) typeof (Attributes));
      if (Attributes.IsValid(nodeClass, attributeId))
        identifiers.Add(attributeId);
    }
    return identifiers;
  }

  public static BuiltInType GetBuiltInType(uint attributeId)
  {
    switch (attributeId)
    {
      case 1:
        return BuiltInType.NodeId;
      case 2:
        return BuiltInType.Int32;
      case 3:
        return BuiltInType.QualifiedName;
      case 4:
        return BuiltInType.LocalizedText;
      case 5:
        return BuiltInType.LocalizedText;
      case 6:
        return BuiltInType.UInt32;
      case 7:
        return BuiltInType.UInt32;
      case 8:
        return BuiltInType.Boolean;
      case 9:
        return BuiltInType.Boolean;
      case 10:
        return BuiltInType.LocalizedText;
      case 11:
        return BuiltInType.Boolean;
      case 12:
        return BuiltInType.Byte;
      case 13:
        return BuiltInType.Variant;
      case 14:
        return BuiltInType.NodeId;
      case 15:
        return BuiltInType.Int32;
      case 16 /*0x10*/:
        return BuiltInType.UInt32;
      case 17:
        return BuiltInType.Byte;
      case 18:
        return BuiltInType.Byte;
      case 19:
        return BuiltInType.Double;
      case 20:
        return BuiltInType.Boolean;
      case 21:
        return BuiltInType.Boolean;
      case 22:
        return BuiltInType.Boolean;
      case 23:
        return BuiltInType.ExtensionObject;
      case 24:
        return BuiltInType.Variant;
      case 25:
        return BuiltInType.Variant;
      case 26:
        return BuiltInType.UInt16;
      case 27:
        return BuiltInType.UInt32;
      default:
        return BuiltInType.Null;
    }
  }

  public static Opc.Ua.NodeId GetDataTypeId(uint attributeId)
  {
    switch (attributeId)
    {
      case 1:
        return (Opc.Ua.NodeId) 17U;
      case 2:
        return (Opc.Ua.NodeId) 29U;
      case 3:
        return (Opc.Ua.NodeId) 20U;
      case 4:
        return (Opc.Ua.NodeId) 21U;
      case 5:
        return (Opc.Ua.NodeId) 21U;
      case 6:
        return (Opc.Ua.NodeId) 7U;
      case 7:
        return (Opc.Ua.NodeId) 7U;
      case 8:
        return (Opc.Ua.NodeId) 1U;
      case 9:
        return (Opc.Ua.NodeId) 1U;
      case 10:
        return (Opc.Ua.NodeId) 21U;
      case 11:
        return (Opc.Ua.NodeId) 1U;
      case 12:
        return (Opc.Ua.NodeId) 3U;
      case 13:
        return (Opc.Ua.NodeId) 24U;
      case 14:
        return (Opc.Ua.NodeId) 17U;
      case 15:
        return (Opc.Ua.NodeId) 6U;
      case 16 /*0x10*/:
        return (Opc.Ua.NodeId) 7U;
      case 17:
        return (Opc.Ua.NodeId) 3U;
      case 18:
        return (Opc.Ua.NodeId) 3U;
      case 19:
        return (Opc.Ua.NodeId) 290U;
      case 20:
        return (Opc.Ua.NodeId) 1U;
      case 21:
        return (Opc.Ua.NodeId) 1U;
      case 22:
        return (Opc.Ua.NodeId) 1U;
      case 23:
        return (Opc.Ua.NodeId) 22U;
      case 24:
        return (Opc.Ua.NodeId) 96U /*0x60*/;
      case 25:
        return (Opc.Ua.NodeId) 96U /*0x60*/;
      case 26:
        return (Opc.Ua.NodeId) 5U;
      case 27:
        return (Opc.Ua.NodeId) 7U;
      default:
        return (Opc.Ua.NodeId) null;
    }
  }

  public static bool IsWriteable(uint attributeId, uint writeMask)
  {
    switch (attributeId)
    {
      case 1:
        return (writeMask & 16384U /*0x4000*/) > 0U;
      case 2:
        return (writeMask & 8192U /*0x2000*/) > 0U;
      case 3:
        return (writeMask & 4U) > 0U;
      case 4:
        return (writeMask & 64U /*0x40*/) > 0U;
      case 5:
        return (writeMask & 32U /*0x20*/) > 0U;
      case 6:
        return (writeMask & 1048576U /*0x100000*/) > 0U;
      case 7:
        return (writeMask & 262144U /*0x040000*/) > 0U;
      case 8:
        return (writeMask & 2048U /*0x0800*/) > 0U;
      case 9:
        return (writeMask & 32768U /*0x8000*/) > 0U;
      case 10:
        return (writeMask & 1024U /*0x0400*/) > 0U;
      case 11:
        return (writeMask & 8U) > 0U;
      case 12:
        return (writeMask & 128U /*0x80*/) > 0U;
      case 13:
        return (writeMask & 2097152U /*0x200000*/) > 0U;
      case 14:
        return (writeMask & 16U /*0x10*/) > 0U;
      case 15:
        return (writeMask & 524288U /*0x080000*/) > 0U;
      case 16 /*0x10*/:
        return (writeMask & 2U) > 0U;
      case 17:
        return (writeMask & 1U) > 0U;
      case 18:
        return (writeMask & 65536U /*0x010000*/) > 0U;
      case 19:
        return (writeMask & 4096U /*0x1000*/) > 0U;
      case 20:
        return (writeMask & 512U /*0x0200*/) > 0U;
      case 21:
        return (writeMask & 256U /*0x0100*/) > 0U;
      case 22:
        return (writeMask & 131072U /*0x020000*/) > 0U;
      case 23:
        return (writeMask & 4194304U /*0x400000*/) > 0U;
      case 24:
        return (writeMask & 8388608U /*0x800000*/) > 0U;
      case 26:
        return (writeMask & 16777216U /*0x01000000*/) > 0U;
      case 27:
        return (writeMask & 33554432U /*0x02000000*/) > 0U;
      default:
        return false;
    }
  }

  public static uint SetWriteable(uint attributeId, uint writeMask)
  {
    switch (attributeId)
    {
      case 1:
        return writeMask | 16384U /*0x4000*/;
      case 2:
        return writeMask | 8192U /*0x2000*/;
      case 3:
        return writeMask | 4U;
      case 4:
        return writeMask | 64U /*0x40*/;
      case 5:
        return writeMask | 32U /*0x20*/;
      case 6:
        return writeMask | 1048576U /*0x100000*/;
      case 7:
        return writeMask | 262144U /*0x040000*/;
      case 8:
        return writeMask | 2048U /*0x0800*/;
      case 9:
        return writeMask | 32768U /*0x8000*/;
      case 10:
        return writeMask | 1024U /*0x0400*/;
      case 11:
        return writeMask | 8U;
      case 12:
        return writeMask | 128U /*0x80*/;
      case 13:
        return writeMask | 2097152U /*0x200000*/;
      case 14:
        return writeMask | 16U /*0x10*/;
      case 15:
        return writeMask | 524288U /*0x080000*/;
      case 16 /*0x10*/:
        return writeMask | 2U;
      case 17:
        return writeMask | 1U;
      case 18:
        return writeMask | 65536U /*0x010000*/;
      case 19:
        return writeMask | 4096U /*0x1000*/;
      case 20:
        return writeMask | 512U /*0x0200*/;
      case 21:
        return writeMask | 256U /*0x0100*/;
      case 22:
        return writeMask | 131072U /*0x020000*/;
      case 23:
        return writeMask | 4194304U /*0x400000*/;
      case 24:
        return writeMask | 8388608U /*0x800000*/;
      case 26:
        return writeMask | 16777216U /*0x01000000*/;
      case 27:
        return writeMask | 33554432U /*0x02000000*/;
      default:
        return writeMask;
    }
  }

  public static int GetValueRank(uint attributeId)
  {
    if (attributeId == 13U)
      return -2;
    return attributeId == 16U /*0x10*/ ? 1 : -1;
  }

  public static bool IsValid(Opc.Ua.NodeClass nodeClass, uint attributeId)
  {
    switch (attributeId)
    {
      case 1:
      case 2:
      case 3:
      case 4:
      case 5:
      case 6:
      case 7:
      case 24:
      case 25:
      case 26:
        return true;
      case 8:
        return (nodeClass & (Opc.Ua.NodeClass.ObjectType | Opc.Ua.NodeClass.VariableType | Opc.Ua.NodeClass.ReferenceType | Opc.Ua.NodeClass.DataType)) != 0;
      case 9:
      case 10:
        return (nodeClass & Opc.Ua.NodeClass.ReferenceType) != 0;
      case 11:
        return (nodeClass & Opc.Ua.NodeClass.View) != 0;
      case 12:
        return (nodeClass & (Opc.Ua.NodeClass.Object | Opc.Ua.NodeClass.View)) != 0;
      case 13:
      case 14:
      case 15:
      case 16 /*0x10*/:
        return (nodeClass & (Opc.Ua.NodeClass.Variable | Opc.Ua.NodeClass.VariableType)) != 0;
      case 17:
      case 18:
      case 19:
      case 20:
      case 27:
        return (nodeClass & Opc.Ua.NodeClass.Variable) != 0;
      case 21:
      case 22:
        return (nodeClass & Opc.Ua.NodeClass.Method) != 0;
      case 23:
        return (nodeClass & Opc.Ua.NodeClass.DataType) != 0;
      default:
        return false;
    }
  }

  public static AttributeWriteMask GetMask(uint attributeId)
  {
    switch (attributeId)
    {
      case 1:
        return AttributeWriteMask.NodeId;
      case 2:
        return AttributeWriteMask.NodeClass;
      case 3:
        return AttributeWriteMask.BrowseName;
      case 4:
        return AttributeWriteMask.DisplayName;
      case 5:
        return AttributeWriteMask.Description;
      case 6:
        return AttributeWriteMask.WriteMask;
      case 7:
        return AttributeWriteMask.UserWriteMask;
      case 8:
        return AttributeWriteMask.IsAbstract;
      case 9:
        return AttributeWriteMask.Symmetric;
      case 10:
        return AttributeWriteMask.InverseName;
      case 11:
        return AttributeWriteMask.ContainsNoLoops;
      case 12:
        return AttributeWriteMask.EventNotifier;
      case 14:
        return AttributeWriteMask.DataType;
      case 15:
        return AttributeWriteMask.ValueRank;
      case 16 /*0x10*/:
        return AttributeWriteMask.ArrayDimensions;
      case 17:
        return AttributeWriteMask.AccessLevel;
      case 18:
        return AttributeWriteMask.UserAccessLevel;
      case 19:
        return AttributeWriteMask.MinimumSamplingInterval;
      case 20:
        return AttributeWriteMask.Historizing;
      case 21:
        return AttributeWriteMask.Executable;
      case 22:
        return AttributeWriteMask.UserExecutable;
      case 23:
        return AttributeWriteMask.DataTypeDefinition;
      case 24:
        return AttributeWriteMask.RolePermissions;
      case 26:
        return AttributeWriteMask.AccessRestrictions;
      case 27:
        return AttributeWriteMask.AccessLevelEx;
      default:
        return AttributeWriteMask.None;
    }
  }
}
