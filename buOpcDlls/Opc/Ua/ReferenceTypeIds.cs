// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ReferenceTypeIds
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public static class ReferenceTypeIds
{
  public static readonly NodeId References = new NodeId(31U /*0x1F*/);
  public static readonly NodeId NonHierarchicalReferences = new NodeId(32U /*0x20*/);
  public static readonly NodeId HierarchicalReferences = new NodeId(33U);
  public static readonly NodeId HasChild = new NodeId(34U);
  public static readonly NodeId Organizes = new NodeId(35U);
  public static readonly NodeId HasEventSource = new NodeId(36U);
  public static readonly NodeId HasModellingRule = new NodeId(37U);
  public static readonly NodeId HasEncoding = new NodeId(38U);
  public static readonly NodeId HasDescription = new NodeId(39U);
  public static readonly NodeId HasTypeDefinition = new NodeId(40U);
  public static readonly NodeId GeneratesEvent = new NodeId(41U);
  public static readonly NodeId AlwaysGeneratesEvent = new NodeId(3065U);
  public static readonly NodeId Aggregates = new NodeId(44U);
  public static readonly NodeId HasSubtype = new NodeId(45U);
  public static readonly NodeId HasProperty = new NodeId(46U);
  public static readonly NodeId HasComponent = new NodeId(47U);
  public static readonly NodeId HasNotifier = new NodeId(48U /*0x30*/);
  public static readonly NodeId HasOrderedComponent = new NodeId(49U);
  public static readonly NodeId FromState = new NodeId(51U);
  public static readonly NodeId ToState = new NodeId(52U);
  public static readonly NodeId HasCause = new NodeId(53U);
  public static readonly NodeId HasEffect = new NodeId(54U);
  public static readonly NodeId HasSubStateMachine = new NodeId(117U);
  public static readonly NodeId HasHistoricalConfiguration = new NodeId(56U);
  public static readonly NodeId HasArgumentDescription = new NodeId(129U);
  public static readonly NodeId HasOptionalInputArgumentDescription = new NodeId(131U);
  public static readonly NodeId HasGuard = new NodeId(15112U);
  public static readonly NodeId HasDictionaryEntry = new NodeId(17597U);
  public static readonly NodeId HasInterface = new NodeId(17603U);
  public static readonly NodeId HasAddIn = new NodeId(17604U);
  public static readonly NodeId HasTrueSubState = new NodeId(9004U);
  public static readonly NodeId HasFalseSubState = new NodeId(9005U);
  public static readonly NodeId HasAlarmSuppressionGroup = new NodeId(16361U);
  public static readonly NodeId AlarmGroupMember = new NodeId(16362U);
  public static readonly NodeId HasCondition = new NodeId(9006U);
  public static readonly NodeId HasEffectDisable = new NodeId(17276U);
  public static readonly NodeId HasEffectEnable = new NodeId(17983U);
  public static readonly NodeId HasEffectSuppressed = new NodeId(17984U);
  public static readonly NodeId HasEffectUnsuppressed = new NodeId(17985U);
  public static readonly NodeId HasPubSubConnection = new NodeId(14476U);
  public static readonly NodeId DataSetToWriter = new NodeId(14936U);
  public static readonly NodeId HasDataSetWriter = new NodeId(15296U);
  public static readonly NodeId HasWriterGroup = new NodeId(18804U);
  public static readonly NodeId HasDataSetReader = new NodeId(15297U);
  public static readonly NodeId HasReaderGroup = new NodeId(18805U);
  public static readonly NodeId AliasFor = new NodeId(23469U);
}
