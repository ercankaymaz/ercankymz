// Decompiled with JetBrains decompiler
// Type: PowerNest2Cs.ErrorCode
// Assembly: buPowerNest, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: EB8978B5-B2D2-48FE-B448-717DFAAD425B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buPowerNest.dll

#nullable disable
namespace PowerNest2Cs;

public enum ErrorCode
{
  UnexpectedError = -1000, // 0xFFFFFC18
  InvalidSession = -997, // 0xFFFFFC1B
  InvalidShape = -996, // 0xFFFFFC1C
  InvalidPart = -995, // 0xFFFFFC1D
  InvalidSheet = -994, // 0xFFFFFC1E
  InvalidResult = -993, // 0xFFFFFC1F
  InvalidConstraint = -992, // 0xFFFFFC20
  InvalidMultiResult = -991, // 0xFFFFFC21
  InvalidMultiResultIndex = -990, // 0xFFFFFC22
  InvalidOrientation = -989, // 0xFFFFFC23
  ConstraintCycle = -988, // 0xFFFFFC24
  MultipleConstraintSet = -987, // 0xFFFFFC25
  MultipleAbsoluteConstraints = -986, // 0xFFFFFC26
  IllegalShift = -985, // 0xFFFFFC27
  CantOpenFile = -984, // 0xFFFFFC28
  StripConstraintIllegalGap = -983, // 0xFFFFFC29
  BadVariableSheet = -982, // 0xFFFFFC2A
  InvalidHole = -981, // 0xFFFFFC2B
  OutlineDoublePoint = -980, // 0xFFFFFC2C
  OutlineIntersectPoint = -979, // 0xFFFFFC2D
  HttpPutError = -978, // 0xFFFFFC2E
  HttpGetError = -977, // 0xFFFFFC2F
  HttpTooLong = -976, // 0xFFFFFC30
  HttpMissingLogin = -975, // 0xFFFFFC31
  HttpInvalidLogin = -974, // 0xFFFFFC32
  BadUserInput = -973, // 0xFFFFFC33
  PipeBroken = -972, // 0xFFFFFC34
  InvalidContour = -971, // 0xFFFFFC35
  AdminRightsNeeded = -970, // 0xFFFFFC36
  VirtualMachineDetected = -969, // 0xFFFFFC37
  ProtectionMachineInfoError = -968, // 0xFFFFFC38
  ConnectionError = -967, // 0xFFFFFC39
  LicenseNonRevocable = -966, // 0xFFFFFC3A
  LicenseNonInstallable = -965, // 0xFFFFFC3B
  OrientationGroupError = -964, // 0xFFFFFC3C
  FreeOrientationAndMotifConstraintForbidden = -963, // 0xFFFFFC3D
  InconsistentMotifOrder = -962, // 0xFFFFFC3E
  CantComputeProtectionInfo = -961, // 0xFFFFFC3F
  CannotFindValidLicense = -960, // 0xFFFFFC40
  NoTokenAvailable = -959, // 0xFFFFFC41
  OK = 0,
}
