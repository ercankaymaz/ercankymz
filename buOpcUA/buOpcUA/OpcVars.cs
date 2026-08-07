// Decompiled with JetBrains decompiler
// Type: buOpcUA.OpcVars
// Assembly: buOpcUA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF9DFBD0-0B81-4B3D-BD5F-1E30872BDC2B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcUA.dll

#nullable disable
namespace buOpcUA;

public class OpcVars
{
  public static string OpcName = "Test";
  public static string OpcUrl = "opc.tcp://CNCPC:4840";
  public static string FirstNode = "ns=4;s=|var|CODESYS Softmotion RTE V3 x64.Application.gvlGlobal";
  public static string OPCRootName = "ns=4;s=|var|CODESYS Softmotion RTE x64 .Application";
  public static OpcClient opcClient;
  public static OpcClient opcClient2;
  public static string pathCodesysGvl = "ns=4;s=|var|CODESYS Softmotion RTE x64.Application.gvlGlobal.";
  public static string pathCodesysPersistent = "ns=4;s=|var|CODESYS Softmotion RTE x64.Application.PersistentVars.";
  public static string pathCodesysIO = "ns=4;s=|var|CODESYS Softmotion RTE x64.Application.gvlIO.";
  public static string pathCodesysCNC = "ns=4;s=|var|CODESYS Softmotion RTE x64.Application.gvlCNC.";
  public static int Interval = 1000;
  public static int ReadCycleCount = 2;
  public static int ReadCounter = 0;
  public static int ErrorCount = 0;
}
