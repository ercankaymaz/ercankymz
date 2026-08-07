// Decompiled with JetBrains decompiler
// Type: buClass.ToolPost
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class ToolPost : buSerilization
{
  public CodeUsing ToolData = new CodeUsing();
  public string ToolChangeCode = "M6";
  public string ToolSectorSeperateChar = "";
  public string ToolLengthCompensationChar = "G43";
  public string ToolLengthCompensationHeightChar = "H";
  public string ToolLengthCompensationZChar = "";
  public bool UseToolSector = false;
  public bool ToolSectorDataNextLine = false;
  public bool MoveSafeBeforeToolChange = false;
  public bool UseToolWithComment = false;
  public bool UseToolLengthCompensation = false;
  public bool UseToolLengthCompensationHeight = false;
  public bool UseToolInfo = false;
  public bool UseToolAuxCodes = false;
  public bool UseToolDChar = false;
  public bool ToolChangeMCommandFirst = false;
  public int ToolWriteSequence = 0;
  public string ToolAdditionalString = "";

  public ToolPost()
  {
  }

  public ToolPost(ToolPost data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (this != null & CopiedClass != null && this.GetType() == CopiedClass.GetType())
    {
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
    this.ToolData = new CodeUsing(data.ToolData);
  }

  public override string ToString() => "Use: " + this.ToolData.Enable.ToString();
}
