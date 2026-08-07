// Decompiled with JetBrains decompiler
// Type: buHandler.buHandleVariableType
// Assembly: buComm, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: F368091B-602E-4A5D-88CB-765F3FC3A1DE
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buComm.dll

using buComm.UdpNetworkVars;
using System;

#nullable disable
namespace buHandler;

public class buHandleVariableType
{
  public static byte f00000C;
  public string VarName;
  public Type VarType;

  public buHandleVariableType()
  {
    ((CDataTypeCollection) this).VarValue = (object) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public buHandleVariableType(string Name, Type type)
  {
    ((CDataTypeCollection) this).VarValue = (object) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    this.VarName = Name;
    this.VarType = type;
  }
}
