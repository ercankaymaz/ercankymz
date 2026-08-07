// Decompiled with JetBrains decompiler
// Type: buClass.CodesysAxTest
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class CodesysAxTest : buSerilization
{
  public double testJogVelocity = 20.0;
  public double testMoveVelocity = 20.0;
  public double testWaitTime = 20.0;
  public double testPosition1 = 0.0;
  public double testPosition2 = 0.0;
  public double testIncrementalPosition = 0.0;
  public static List<string> Captions = new List<string>();

  public CodesysAxTest()
  {
  }

  public CodesysAxTest(CodesysAxTest data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields != null)
    {
      for (int index = 0; index <= fields.Length - 1; ++index)
      {
        string name = fields[index].Name;
        object obj = fields[index].GetValue(CopiedClass);
        fields[index].SetValue((object) this, obj);
      }
    }
  }

  public override string ToString()
  {
    return $"testPosition1 : {this.testPosition1.ToString()} , testPosition2: {this.testPosition2.ToString()} , testJogVelocity: {this.testJogVelocity.ToString()} , testMoveVelocity: {this.testMoveVelocity.ToString()}";
  }

  public string ToFileString(int Version)
  {
    return $"{$"{this.testJogVelocity.ToString()};{this.testMoveVelocity.ToString()};{this.testWaitTime.ToString()}"};{this.testPosition1.ToString()};{this.testPosition2.ToString()};{this.testIncrementalPosition.ToString()}";
  }
}
