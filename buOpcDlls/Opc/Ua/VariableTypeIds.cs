// Decompiled with JetBrains decompiler
// Type: Opc.Ua.VariableTypeIds
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public static class VariableTypeIds
{
  public static readonly NodeId BaseVariableType = new NodeId(62U);
  public static readonly NodeId BaseDataVariableType = new NodeId(63U /*0x3F*/);
  public static readonly NodeId PropertyType = new NodeId(68U);
  public static readonly NodeId DataTypeDescriptionType = new NodeId(69U);
  public static readonly NodeId DataTypeDictionaryType = new NodeId(72U);
  public static readonly NodeId ServerVendorCapabilityType = new NodeId(2137U);
  public static readonly NodeId ServerStatusType = new NodeId(2138U);
  public static readonly NodeId BuildInfoType = new NodeId(3051U);
  public static readonly NodeId ServerDiagnosticsSummaryType = new NodeId(2150U);
  public static readonly NodeId SamplingIntervalDiagnosticsArrayType = new NodeId(2164U);
  public static readonly NodeId SamplingIntervalDiagnosticsType = new NodeId(2165U);
  public static readonly NodeId SubscriptionDiagnosticsArrayType = new NodeId(2171U);
  public static readonly NodeId SubscriptionDiagnosticsType = new NodeId(2172U);
  public static readonly NodeId SessionDiagnosticsArrayType = new NodeId(2196U);
  public static readonly NodeId SessionDiagnosticsVariableType = new NodeId(2197U);
  public static readonly NodeId SessionSecurityDiagnosticsArrayType = new NodeId(2243U);
  public static readonly NodeId SessionSecurityDiagnosticsType = new NodeId(2244U);
  public static readonly NodeId OptionSetType = new NodeId(11487U);
  public static readonly NodeId SelectionListType = new NodeId(16309U);
  public static readonly NodeId AudioVariableType = new NodeId(17986U);
  public static readonly NodeId StateVariableType = new NodeId(2755U);
  public static readonly NodeId TransitionVariableType = new NodeId(2762U);
  public static readonly NodeId FiniteStateVariableType = new NodeId(2760U);
  public static readonly NodeId FiniteTransitionVariableType = new NodeId(2767U);
  public static readonly NodeId GuardVariableType = new NodeId(15113U);
  public static readonly NodeId ExpressionGuardVariableType = new NodeId(15128U);
  public static readonly NodeId ElseGuardVariableType = new NodeId(15317U);
  public static readonly NodeId RationalNumberType = new NodeId(17709U);
  public static readonly NodeId VectorType = new NodeId(17714U);
  public static readonly NodeId ThreeDVectorType = new NodeId(17716U);
  public static readonly NodeId CartesianCoordinatesType = new NodeId(18772U);
  public static readonly NodeId ThreeDCartesianCoordinatesType = new NodeId(18774U);
  public static readonly NodeId OrientationType = new NodeId(18779U);
  public static readonly NodeId ThreeDOrientationType = new NodeId(18781U);
  public static readonly NodeId FrameType = new NodeId(18786U);
  public static readonly NodeId ThreeDFrameType = new NodeId(18791U);
  public static readonly NodeId DataItemType = new NodeId(2365U);
  public static readonly NodeId BaseAnalogType = new NodeId(15318U);
  public static readonly NodeId AnalogItemType = new NodeId(2368U);
  public static readonly NodeId AnalogUnitType = new NodeId(17497U);
  public static readonly NodeId AnalogUnitRangeType = new NodeId(17570U);
  public static readonly NodeId DiscreteItemType = new NodeId(2372U);
  public static readonly NodeId TwoStateDiscreteType = new NodeId(2373U);
  public static readonly NodeId MultiStateDiscreteType = new NodeId(2376U);
  public static readonly NodeId MultiStateValueDiscreteType = new NodeId(11238U);
  public static readonly NodeId ArrayItemType = new NodeId(12021U);
  public static readonly NodeId YArrayItemType = new NodeId(12029U);
  public static readonly NodeId XYArrayItemType = new NodeId(12038U);
  public static readonly NodeId ImageItemType = new NodeId(12047U);
  public static readonly NodeId CubeItemType = new NodeId(12057U);
  public static readonly NodeId NDimensionArrayItemType = new NodeId(12068U);
  public static readonly NodeId TwoStateVariableType = new NodeId(8995U);
  public static readonly NodeId ConditionVariableType = new NodeId(9002U);
  public static readonly NodeId AlarmRateVariableType = new NodeId(17277U);
  public static readonly NodeId ProgramDiagnosticType = new NodeId(2380U);
  public static readonly NodeId ProgramDiagnostic2Type = new NodeId(15383U);
  public static readonly NodeId PubSubDiagnosticsCounterType = new NodeId(19725U);
  public static readonly NodeId MultiStateDictionaryEntryDiscreteBaseType = new NodeId(19077U);
  public static readonly NodeId MultiStateDictionaryEntryDiscreteType = new NodeId(19084U);
}
