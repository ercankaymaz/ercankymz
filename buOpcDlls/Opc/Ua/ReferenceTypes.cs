// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ReferenceTypes
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
public static class ReferenceTypes
{
  public const uint References = 31 /*0x1F*/;
  public const uint NonHierarchicalReferences = 32 /*0x20*/;
  public const uint HierarchicalReferences = 33;
  public const uint HasChild = 34;
  public const uint Organizes = 35;
  public const uint HasEventSource = 36;
  public const uint HasModellingRule = 37;
  public const uint HasEncoding = 38;
  public const uint HasDescription = 39;
  public const uint HasTypeDefinition = 40;
  public const uint GeneratesEvent = 41;
  public const uint AlwaysGeneratesEvent = 3065;
  public const uint Aggregates = 44;
  public const uint HasSubtype = 45;
  public const uint HasProperty = 46;
  public const uint HasComponent = 47;
  public const uint HasNotifier = 48 /*0x30*/;
  public const uint HasOrderedComponent = 49;
  public const uint FromState = 51;
  public const uint ToState = 52;
  public const uint HasCause = 53;
  public const uint HasEffect = 54;
  public const uint HasSubStateMachine = 117;
  public const uint HasHistoricalConfiguration = 56;
  public const uint HasArgumentDescription = 129;
  public const uint HasOptionalInputArgumentDescription = 131;
  public const uint HasGuard = 15112;
  public const uint HasDictionaryEntry = 17597;
  public const uint HasInterface = 17603;
  public const uint HasAddIn = 17604;
  public const uint HasTrueSubState = 9004;
  public const uint HasFalseSubState = 9005;
  public const uint HasAlarmSuppressionGroup = 16361;
  public const uint AlarmGroupMember = 16362;
  public const uint HasCondition = 9006;
  public const uint HasEffectDisable = 17276;
  public const uint HasEffectEnable = 17983;
  public const uint HasEffectSuppressed = 17984;
  public const uint HasEffectUnsuppressed = 17985;
  public const uint HasPubSubConnection = 14476;
  public const uint DataSetToWriter = 14936;
  public const uint HasDataSetWriter = 15296;
  public const uint HasWriterGroup = 18804;
  public const uint HasDataSetReader = 15297;
  public const uint HasReaderGroup = 18805;
  public const uint AliasFor = 23469;

  public static string GetBrowseName(uint identifier)
  {
    foreach (FieldInfo field in typeof (ReferenceTypes).GetFields(BindingFlags.Static | BindingFlags.Public))
    {
      if ((int) identifier == (int) (uint) field.GetValue((object) typeof (ReferenceTypes)))
        return field.Name;
    }
    return string.Empty;
  }

  public static string[] GetBrowseNames()
  {
    FieldInfo[] fields = typeof (ReferenceTypes).GetFields(BindingFlags.Static | BindingFlags.Public);
    int num = 0;
    string[] browseNames = new string[fields.Length];
    foreach (FieldInfo fieldInfo in fields)
      browseNames[num++] = fieldInfo.Name;
    return browseNames;
  }

  public static uint GetIdentifier(string browseName)
  {
    foreach (FieldInfo field in typeof (ReferenceTypes).GetFields(BindingFlags.Static | BindingFlags.Public))
    {
      if (field.Name == browseName)
        return (uint) field.GetValue((object) typeof (ReferenceTypes));
    }
    return 0;
  }
}
