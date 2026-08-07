// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Multiplier.ValidityPreCompInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Math.EC.Multiplier;

internal class ValidityPreCompInfo : PreCompInfo
{
  internal static readonly string PRECOMP_NAME = "bc_validity";
  private bool failed;
  private bool curveEquationPassed;
  private bool orderPassed;

  internal bool HasFailed() => this.failed;

  internal void ReportFailed() => this.failed = true;

  internal bool HasCurveEquationPassed() => this.curveEquationPassed;

  internal void ReportCurveEquationPassed() => this.curveEquationPassed = true;

  internal bool HasOrderPassed() => this.orderPassed;

  internal void ReportOrderPassed() => this.orderPassed = true;
}
