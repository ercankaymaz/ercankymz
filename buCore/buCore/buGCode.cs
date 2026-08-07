// Decompiled with JetBrains decompiler
// Type: buCore.buGCode
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using buClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buCore;

public class buGCode
{
  public List<eEntities> GCodeEntities = new List<eEntities>();
  public List<Pnt9D> PointListVersusGCodeLines = new List<Pnt9D>();
  public Vec3D MoveDistance = new Vec3D();
  public bool UsePointListForGCodeLines = false;
  private string string_0 = "";
  private double double_0 = 0.0;
  private bool bool_0 = false;
  private PostProcessor postProcessor_0 = new PostProcessor();

  public buGCode()
  {
    if (!buVector.smethod_0(nameof (buGCode)))
      throw new RegisterException(nameof (buGCode));
    // ISSUE: reference to a compiler-generated field
    if (this.calculationEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.calculationEventHandler_0(new CalculationEventArg(0.0, 0.0, 0, "", ""));
    }
    // ISSUE: reference to a compiler-generated field
    if (this.calculationEventHandler_1 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.calculationEventHandler_1(new CalculationEventArg(0.0, 0.0, 0, "", ""));
    }
    // ISSUE: reference to a compiler-generated field
    if (this.calculationEventHandler_2 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.calculationEventHandler_2(new CalculationEventArg(0.0, 0.0, 0, "", ""));
    }
    // ISSUE: reference to a compiler-generated field
    if (this.calculationEventHandler_3 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.calculationEventHandler_3(new CalculationEventArg(0.0, 0.0, 0, "", ""));
    }
    // ISSUE: reference to a compiler-generated field
    if (this.calculationErrorEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.calculationErrorEventHandler_0(new CalculationErrorEventArg("", "", "", 0));
  }

  public event CalculationEventHandler CalculationInProgress;

  public event CalculationEventHandler CalculationStarted;

  public event CalculationEventHandler CalculationEnded;

  public event CalculationEventHandler CalculationCanceled;

  public event CalculationErrorEventHandler CalculationError;

  public void CreatGCode(camBase Cam, PostProcessor Post, ref string Lines)
  {
    this.CreatGCode(new List<camBase>() { Cam }, Post, ref Lines);
  }

  public void CreatGCode(List<camBase> Cams, PostProcessor Post, ref string Lines)
  {
    try
    {
      this.PointListVersusGCodeLines.Clear();
      string str1 = "";
      string str2 = "";
      string str3 = "";
      string str4 = "";
      string str5 = "";
      Pnt9D Position = new Pnt9D();
      string Codes1 = "";
      this.string_0 = "";
      ArrayList AL = new ArrayList();
      this.postProcessor_0 = new PostProcessor(Post);
      bool flag1 = this.postProcessor_0.AxesUsing.U | this.postProcessor_0.AxesUsing.V | this.postProcessor_0.AxesUsing.W;
      this.double_0 = this.postProcessor_0.NumberDef.Start;
      int num1 = 0;
      int num2 = 0;
      bool flag2 = false;
      bool flag3 = false;
      bool flag4 = false;
      bool flag5 = false;
      if (Cams[0].UseCreatedGCode)
      {
        for (int index = 0; index <= Cams[0].CreatedGCodes.Count - 1; ++index)
        {
          string NewCommand = Cams[0].CreatedGCodes[index].ToString();
          this.AddCode(ref Codes1, NewCommand, Post, Position);
        }
        Lines = Codes1;
      }
      else
      {
        for (int index1 = 0; index1 <= Cams.Count - 1; ++index1)
        {
          for (int index2 = 0; index2 <= Cams[index1].CamPoints.Count - 1; ++index2)
            num1 += Cams[index1].CamPoints[index2].Points.Count;
        }
        int int32 = Convert.ToInt32((double) num1 / 100.0);
        if (Cams.Count > 0 && Cams[0].CamPoints.Count > 0 && Cams[0].CamPoints[0].Points.Count > 0)
          Position = new Pnt9D(Cams[0].CamPoints[0].Points[0].P9);
        if (this.postProcessor_0.PostVariables.Count > 0)
        {
          ArrayList c = new ArrayList();
          for (int index3 = 0; index3 <= this.postProcessor_0.StartLines.Count - 1; ++index3)
          {
            string str6 = this.postProcessor_0.StartLines[index3].ToString();
            bool flag6 = false;
            ArrayList Lines1 = new ArrayList();
            for (int index4 = 0; index4 <= this.postProcessor_0.PostVariables.Count - 1; ++index4)
            {
              if (this.postProcessor_0.PostVariables[index4].VariableName.Trim().ToLower() == str6.Trim().ToLower())
              {
                buString.StringToArrayListByNewLine(this.postProcessor_0.PostVariables[index4].Value, ref Lines1);
                flag6 = true;
                if (this.postProcessor_0.PostVariables[index4].ValueList.Count > 0)
                {
                  for (int index5 = 0; index5 <= this.postProcessor_0.PostVariables[index4].ValueList.Count - 1; ++index5)
                    Lines1.Add((object) this.postProcessor_0.PostVariables[index4].ValueList[index5]);
                }
              }
            }
            if (Lines1.Count == 0)
            {
              if (!flag6)
                c.Add((object) str6);
            }
            else
            {
              for (int index6 = 0; index6 <= Lines1.Count - 1; ++index6)
              {
                if (Lines1[index6].ToString().Trim().Length > 0)
                  c.Add(Lines1[index6]);
              }
            }
          }
          this.postProcessor_0.StartLines.Clear();
          this.postProcessor_0.StartLines.AddRange((ICollection) c);
        }
        for (int index = 0; index <= this.postProcessor_0.StartLines.Count - 1; ++index)
        {
          string NewCommand = this.postProcessor_0.StartLines[index].ToString();
          this.AddCode(ref Codes1, NewCommand, this.postProcessor_0, Position);
        }
        AL.Add((object) Codes1);
        string Codes2 = "";
        for (int index7 = 0; index7 <= Cams.Count - 1; ++index7)
        {
          if (Cams[index7].Enable)
          {
            if (Cams[index7].UsedCamPost)
            {
              this.postProcessor_0 = new PostProcessor(Cams[index7].Post);
              this.postProcessor_0.AxesUsing.X = Cams[index7].Post.AxesUsing.X & Post.AxesUsing.X;
              this.postProcessor_0.AxesUsing.Y = Cams[index7].Post.AxesUsing.Y & Post.AxesUsing.Y;
              this.postProcessor_0.AxesUsing.Z = Cams[index7].Post.AxesUsing.Z & Post.AxesUsing.Z;
              this.postProcessor_0.AxesUsing.A = Cams[index7].Post.AxesUsing.A & Post.AxesUsing.A;
              this.postProcessor_0.AxesUsing.B = Cams[index7].Post.AxesUsing.B & Post.AxesUsing.B;
              this.postProcessor_0.AxesUsing.C = Cams[index7].Post.AxesUsing.C & Post.AxesUsing.C;
              if (Cams[index7].RegionIndex > 0)
              {
                if (Cams[index7].RegionIndex == 1)
                {
                  this.postProcessor_0.ToolDef = new ToolPost(Cams[index7].Post.Region1.RegionToolDef);
                  this.postProcessor_0.SpindleDef = new SpindlePost(Cams[index7].Post.Region1.RegionSpindleDef);
                  this.postProcessor_0.TDef = new CharDefinitions(Cams[index7].Post.Region1.RegionTDef);
                  this.postProcessor_0.SDef = new CharDefinitions(Cams[index7].Post.Region1.RegionSDef);
                  this.postProcessor_0.XDef = new CharDefinitions(Cams[index7].Post.Region1.RegionXDef);
                  this.postProcessor_0.YDef = new CharDefinitions(Cams[index7].Post.Region1.RegionYDef);
                  this.postProcessor_0.ZDef = new CharDefinitions(Cams[index7].Post.Region1.RegionZDef);
                  this.postProcessor_0.ADef = new CharDefinitions(Cams[index7].Post.Region1.RegionADef);
                  this.postProcessor_0.BDef = new CharDefinitions(Cams[index7].Post.Region1.RegionBDef);
                  this.postProcessor_0.CDef = new CharDefinitions(Cams[index7].Post.Region1.RegionCDef);
                }
                if (Cams[index7].RegionIndex == 2)
                {
                  this.postProcessor_0.ToolDef = new ToolPost(Cams[index7].Post.Region2.RegionToolDef);
                  this.postProcessor_0.SpindleDef = new SpindlePost(Cams[index7].Post.Region2.RegionSpindleDef);
                  this.postProcessor_0.TDef = new CharDefinitions(Cams[index7].Post.Region2.RegionTDef);
                  this.postProcessor_0.SDef = new CharDefinitions(Cams[index7].Post.Region2.RegionSDef);
                  this.postProcessor_0.XDef = new CharDefinitions(Cams[index7].Post.Region2.RegionXDef);
                  this.postProcessor_0.YDef = new CharDefinitions(Cams[index7].Post.Region2.RegionYDef);
                  this.postProcessor_0.ZDef = new CharDefinitions(Cams[index7].Post.Region2.RegionZDef);
                  this.postProcessor_0.ADef = new CharDefinitions(Cams[index7].Post.Region2.RegionADef);
                  this.postProcessor_0.BDef = new CharDefinitions(Cams[index7].Post.Region2.RegionBDef);
                  this.postProcessor_0.CDef = new CharDefinitions(Cams[index7].Post.Region2.RegionCDef);
                }
                if (Cams[index7].RegionIndex == 3)
                {
                  this.postProcessor_0.ToolDef = new ToolPost(Cams[index7].Post.Region3.RegionToolDef);
                  this.postProcessor_0.SpindleDef = new SpindlePost(Cams[index7].Post.Region3.RegionSpindleDef);
                  this.postProcessor_0.TDef = new CharDefinitions(Cams[index7].Post.Region3.RegionTDef);
                  this.postProcessor_0.SDef = new CharDefinitions(Cams[index7].Post.Region3.RegionSDef);
                  this.postProcessor_0.XDef = new CharDefinitions(Cams[index7].Post.Region3.RegionXDef);
                  this.postProcessor_0.YDef = new CharDefinitions(Cams[index7].Post.Region3.RegionYDef);
                  this.postProcessor_0.ZDef = new CharDefinitions(Cams[index7].Post.Region3.RegionZDef);
                  this.postProcessor_0.ADef = new CharDefinitions(Cams[index7].Post.Region3.RegionADef);
                  this.postProcessor_0.BDef = new CharDefinitions(Cams[index7].Post.Region3.RegionBDef);
                  this.postProcessor_0.CDef = new CharDefinitions(Cams[index7].Post.Region3.RegionCDef);
                }
                if (Cams[index7].RegionIndex == 4)
                {
                  this.postProcessor_0.ToolDef = new ToolPost(Cams[index7].Post.Region4.RegionToolDef);
                  this.postProcessor_0.SpindleDef = new SpindlePost(Cams[index7].Post.Region4.RegionSpindleDef);
                  this.postProcessor_0.TDef = new CharDefinitions(Cams[index7].Post.Region4.RegionTDef);
                  this.postProcessor_0.SDef = new CharDefinitions(Cams[index7].Post.Region4.RegionSDef);
                  this.postProcessor_0.XDef = new CharDefinitions(Cams[index7].Post.Region4.RegionXDef);
                  this.postProcessor_0.YDef = new CharDefinitions(Cams[index7].Post.Region4.RegionYDef);
                  this.postProcessor_0.ZDef = new CharDefinitions(Cams[index7].Post.Region4.RegionZDef);
                  this.postProcessor_0.ADef = new CharDefinitions(Cams[index7].Post.Region4.RegionADef);
                  this.postProcessor_0.BDef = new CharDefinitions(Cams[index7].Post.Region4.RegionBDef);
                  this.postProcessor_0.CDef = new CharDefinitions(Cams[index7].Post.Region4.RegionCDef);
                }
                if (Cams[index7].RegionIndex == 5)
                {
                  this.postProcessor_0.ToolDef = new ToolPost(Cams[index7].Post.Region5.RegionToolDef);
                  this.postProcessor_0.SpindleDef = new SpindlePost(Cams[index7].Post.Region5.RegionSpindleDef);
                  this.postProcessor_0.TDef = new CharDefinitions(Cams[index7].Post.Region5.RegionTDef);
                  this.postProcessor_0.SDef = new CharDefinitions(Cams[index7].Post.Region5.RegionSDef);
                  this.postProcessor_0.XDef = new CharDefinitions(Cams[index7].Post.Region5.RegionXDef);
                  this.postProcessor_0.YDef = new CharDefinitions(Cams[index7].Post.Region5.RegionYDef);
                  this.postProcessor_0.ZDef = new CharDefinitions(Cams[index7].Post.Region5.RegionZDef);
                  this.postProcessor_0.ADef = new CharDefinitions(Cams[index7].Post.Region5.RegionADef);
                  this.postProcessor_0.BDef = new CharDefinitions(Cams[index7].Post.Region5.RegionBDef);
                  this.postProcessor_0.CDef = new CharDefinitions(Cams[index7].Post.Region5.RegionCDef);
                }
                if (Cams[index7].RegionIndex == 6)
                {
                  this.postProcessor_0.ToolDef = new ToolPost(Cams[index7].Post.Region6.RegionToolDef);
                  this.postProcessor_0.SpindleDef = new SpindlePost(Cams[index7].Post.Region6.RegionSpindleDef);
                  this.postProcessor_0.TDef = new CharDefinitions(Cams[index7].Post.Region6.RegionTDef);
                  this.postProcessor_0.SDef = new CharDefinitions(Cams[index7].Post.Region6.RegionSDef);
                  this.postProcessor_0.XDef = new CharDefinitions(Cams[index7].Post.Region6.RegionXDef);
                  this.postProcessor_0.YDef = new CharDefinitions(Cams[index7].Post.Region6.RegionYDef);
                  this.postProcessor_0.ZDef = new CharDefinitions(Cams[index7].Post.Region6.RegionZDef);
                  this.postProcessor_0.ADef = new CharDefinitions(Cams[index7].Post.Region6.RegionADef);
                  this.postProcessor_0.BDef = new CharDefinitions(Cams[index7].Post.Region6.RegionBDef);
                  this.postProcessor_0.CDef = new CharDefinitions(Cams[index7].Post.Region6.RegionCDef);
                }
              }
            }
            else
            {
              this.postProcessor_0 = new PostProcessor(Post);
              if (Cams[index7].RegionIndex > 0)
              {
                if (Cams[index7].RegionIndex == 1)
                {
                  this.postProcessor_0.ToolDef = new ToolPost(Post.Region1.RegionToolDef);
                  this.postProcessor_0.SpindleDef = new SpindlePost(Post.Region1.RegionSpindleDef);
                  this.postProcessor_0.TDef = new CharDefinitions(Post.Region1.RegionTDef);
                  this.postProcessor_0.SDef = new CharDefinitions(Post.Region1.RegionSDef);
                  this.postProcessor_0.XDef = new CharDefinitions(Post.Region1.RegionXDef);
                  this.postProcessor_0.YDef = new CharDefinitions(Post.Region1.RegionYDef);
                  this.postProcessor_0.ZDef = new CharDefinitions(Post.Region1.RegionZDef);
                  this.postProcessor_0.ADef = new CharDefinitions(Post.Region1.RegionADef);
                  this.postProcessor_0.BDef = new CharDefinitions(Post.Region1.RegionBDef);
                  this.postProcessor_0.CDef = new CharDefinitions(Post.Region1.RegionCDef);
                }
                if (Cams[index7].RegionIndex == 2)
                {
                  this.postProcessor_0.ToolDef = new ToolPost(Post.Region2.RegionToolDef);
                  this.postProcessor_0.SpindleDef = new SpindlePost(Post.Region2.RegionSpindleDef);
                  this.postProcessor_0.TDef = new CharDefinitions(Post.Region2.RegionTDef);
                  this.postProcessor_0.SDef = new CharDefinitions(Post.Region2.RegionSDef);
                  this.postProcessor_0.XDef = new CharDefinitions(Post.Region2.RegionXDef);
                  this.postProcessor_0.YDef = new CharDefinitions(Post.Region2.RegionYDef);
                  this.postProcessor_0.ZDef = new CharDefinitions(Post.Region2.RegionZDef);
                  this.postProcessor_0.ADef = new CharDefinitions(Post.Region2.RegionADef);
                  this.postProcessor_0.BDef = new CharDefinitions(Post.Region2.RegionBDef);
                  this.postProcessor_0.CDef = new CharDefinitions(Post.Region2.RegionCDef);
                }
                if (Cams[index7].RegionIndex == 3)
                {
                  this.postProcessor_0.ToolDef = new ToolPost(Post.Region3.RegionToolDef);
                  this.postProcessor_0.SpindleDef = new SpindlePost(Post.Region3.RegionSpindleDef);
                  this.postProcessor_0.TDef = new CharDefinitions(Post.Region3.RegionTDef);
                  this.postProcessor_0.SDef = new CharDefinitions(Post.Region3.RegionSDef);
                  this.postProcessor_0.XDef = new CharDefinitions(Post.Region3.RegionXDef);
                  this.postProcessor_0.YDef = new CharDefinitions(Post.Region3.RegionYDef);
                  this.postProcessor_0.ZDef = new CharDefinitions(Post.Region3.RegionZDef);
                  this.postProcessor_0.ADef = new CharDefinitions(Post.Region3.RegionADef);
                  this.postProcessor_0.BDef = new CharDefinitions(Post.Region3.RegionBDef);
                  this.postProcessor_0.CDef = new CharDefinitions(Post.Region3.RegionCDef);
                }
                if (Cams[index7].RegionIndex == 4)
                {
                  this.postProcessor_0.ToolDef = new ToolPost(Post.Region4.RegionToolDef);
                  this.postProcessor_0.SpindleDef = new SpindlePost(Post.Region4.RegionSpindleDef);
                  this.postProcessor_0.TDef = new CharDefinitions(Post.Region4.RegionTDef);
                  this.postProcessor_0.SDef = new CharDefinitions(Post.Region4.RegionSDef);
                  this.postProcessor_0.XDef = new CharDefinitions(Post.Region4.RegionXDef);
                  this.postProcessor_0.YDef = new CharDefinitions(Post.Region4.RegionYDef);
                  this.postProcessor_0.ZDef = new CharDefinitions(Post.Region4.RegionZDef);
                  this.postProcessor_0.ADef = new CharDefinitions(Post.Region4.RegionADef);
                  this.postProcessor_0.BDef = new CharDefinitions(Post.Region4.RegionBDef);
                  this.postProcessor_0.CDef = new CharDefinitions(Post.Region4.RegionCDef);
                }
                if (Cams[index7].RegionIndex == 5)
                {
                  this.postProcessor_0.ToolDef = new ToolPost(Post.Region5.RegionToolDef);
                  this.postProcessor_0.SpindleDef = new SpindlePost(Post.Region5.RegionSpindleDef);
                  this.postProcessor_0.TDef = new CharDefinitions(Post.Region5.RegionTDef);
                  this.postProcessor_0.SDef = new CharDefinitions(Post.Region5.RegionSDef);
                  this.postProcessor_0.XDef = new CharDefinitions(Post.Region5.RegionXDef);
                  this.postProcessor_0.YDef = new CharDefinitions(Post.Region5.RegionYDef);
                  this.postProcessor_0.ZDef = new CharDefinitions(Post.Region5.RegionZDef);
                  this.postProcessor_0.ADef = new CharDefinitions(Post.Region5.RegionADef);
                  this.postProcessor_0.BDef = new CharDefinitions(Post.Region5.RegionBDef);
                  this.postProcessor_0.CDef = new CharDefinitions(Post.Region5.RegionCDef);
                }
                if (Cams[index7].RegionIndex == 6)
                {
                  this.postProcessor_0.ToolDef = new ToolPost(Post.Region6.RegionToolDef);
                  this.postProcessor_0.SpindleDef = new SpindlePost(Post.Region6.RegionSpindleDef);
                  this.postProcessor_0.TDef = new CharDefinitions(Post.Region6.RegionTDef);
                  this.postProcessor_0.SDef = new CharDefinitions(Post.Region6.RegionSDef);
                  this.postProcessor_0.XDef = new CharDefinitions(Post.Region6.RegionXDef);
                  this.postProcessor_0.YDef = new CharDefinitions(Post.Region6.RegionYDef);
                  this.postProcessor_0.ZDef = new CharDefinitions(Post.Region6.RegionZDef);
                  this.postProcessor_0.ADef = new CharDefinitions(Post.Region6.RegionADef);
                  this.postProcessor_0.BDef = new CharDefinitions(Post.Region6.RegionBDef);
                  this.postProcessor_0.CDef = new CharDefinitions(Post.Region6.RegionCDef);
                }
              }
            }
            for (int index8 = 0; index8 <= this.postProcessor_0.StartLinesEachBlock.Count - 1; ++index8)
            {
              string NewCommand = this.postProcessor_0.StartLinesEachBlock[index8].ToString().Trim();
              if (NewCommand.Length > 0)
                this.AddCode(ref Codes2, NewCommand, this.postProcessor_0, Position);
            }
            if (Cams[index7].PreCodes.Count > 0)
            {
              for (int index9 = 0; index9 <= Cams[index7].PreCodes.Count - 1; ++index9)
              {
                string NewCommand = Cams[index7].PreCodes[index9].ToString().Trim();
                if (NewCommand.Length > 0)
                  this.AddCode(ref Codes2, NewCommand, this.postProcessor_0, Position);
              }
            }
            string NewCommand1;
            if (this.postProcessor_0.SpindleDef.UseSpindle)
            {
              string str7 = this.ValueFormat(this.postProcessor_0, this.postProcessor_0.SDef.Char, Cams[index7].Tool.CamData.SpindleSpeed, 0.0, 0, Cams[index7]);
              NewCommand1 = this.postProcessor_0.SpindleDef.SpindleMCommandFirst ? (Cams[index7].Tool.CamData.SpindleDirection != ClockDirectionType.CW ? $"{this.postProcessor_0.SpindleDef.SpindleCCWCode} {str7}" : $"{this.postProcessor_0.SpindleDef.SpindleCWCode} {str7}") : (Cams[index7].Tool.CamData.SpindleDirection != ClockDirectionType.CW ? str7 + this.postProcessor_0.SpindleDef.SpindleCCWCode : str7 + this.postProcessor_0.SpindleDef.SpindleCWCode);
            }
            else
              NewCommand1 = "";
            if (index7 == 0 | index7 > 0 & !this.postProcessor_0.ToolNextDef.ToolData.Enable)
            {
              if (this.postProcessor_0.ToolDef.ToolData.Enable)
              {
                bool flag7 = true;
                string str8 = "";
                if (this.postProcessor_0.ToolDef.UseToolWithComment)
                  str8 = this.postProcessor_0.CommentChar;
                if (index7 > 0 & !this.postProcessor_0.RepetitionDef.Tool && Cams[index7 - 1].Tool.Data.No == Cams[index7].Tool.Data.No)
                  flag7 = false;
                if (flag7)
                {
                  if (this.postProcessor_0.ToolDef.UseToolInfo)
                  {
                    string NewCommand2 = $"{this.postProcessor_0.CommentChar} Name : {Cams[index7].Tool.Data.Name} , Diameter : {Cams[index7].Tool.Geometry.Diameter.ToString()} , Length: {Cams[index7].Tool.Geometry.Length.ToString()}";
                    this.AddCode(ref Codes2, NewCommand2, this.postProcessor_0, Position);
                  }
                  if (index7 > 0 & this.postProcessor_0.ToolDef.MoveSafeBeforeToolChange)
                  {
                    string str9 = !this.postProcessor_0.AxesUsing.Z ? "" : this.ValueFormat(this.postProcessor_0, "Z", Cams[index7 - 1].ZSafeDistance, this.MoveDistance.Z + Cams[index7 - 1].MoveOffset.Z, Cams[index7 - 1].ZAxisIndex, Cams[index7 - 1]);
                    if (Cams[index7 - 1].Tool.Data.No != Cams[index7].Tool.Data.No)
                    {
                      string NewCommand3 = "G0 " + str9;
                      this.AddCode(ref Codes2, NewCommand3, this.postProcessor_0, Position);
                    }
                  }
                  for (int index10 = 0; index10 <= this.postProcessor_0.ToolDef.ToolData.PreCode.Count - 1; ++index10)
                  {
                    string NewCommand4 = this.postProcessor_0.ToolDef.ToolData.PreCode[index10].ToString().Trim();
                    if (NewCommand4.Length > 0)
                      this.AddCode(ref Codes2, NewCommand4, this.postProcessor_0, Position);
                  }
                }
                string str10 = this.ValueFormat(this.postProcessor_0, "T", Cams[index7].Tool.Data.No);
                if (this.postProcessor_0.ToolDef.UseToolSector)
                {
                  string str11 = str10.TrimEnd();
                  if (!this.postProcessor_0.ToolDef.ToolSectorDataNextLine)
                    str10 = $"{str11}{this.postProcessor_0.ToolDef.ToolSectorSeperateChar}{Cams[index7].Tool.Data.Sector.ToString()} ";
                  else
                    str10 = $"{str11}{Environment.NewLine}{this.postProcessor_0.ToolDef.ToolSectorSeperateChar}{Cams[index7].Tool.Data.Sector.ToString()} ";
                }
                if (this.postProcessor_0.ToolDef.ToolChangeCode.Trim().Length > 0)
                  str10 = this.postProcessor_0.ToolDef.ToolChangeMCommandFirst ? $"{this.postProcessor_0.ToolDef.ToolChangeCode} {str10}" : $"{str10}{this.postProcessor_0.ToolDef.ToolChangeCode} ";
                if (this.postProcessor_0.ToolDef.UseToolDChar)
                  str10 = $"{str10}D{Cams[index7].Tool.Data.No.ToString()} ";
                string str12 = str10 + this.postProcessor_0.ToolDef.ToolAdditionalString;
                if (flag7)
                {
                  if (this.postProcessor_0.SpindleDef.SpindleAtToolLine)
                  {
                    if (str12.Trim().Length > 0)
                      this.AddCode(ref Codes2, str8 + str12 + NewCommand1, this.postProcessor_0, Position);
                    if (this.postProcessor_0.ToolDef.UseToolLengthCompensation)
                    {
                      string NewCommand5 = this.postProcessor_0.ToolDef.ToolLengthCompensationChar;
                      if (this.postProcessor_0.ToolDef.UseToolLengthCompensationHeight)
                        NewCommand5 = $"{NewCommand5} {this.postProcessor_0.ToolDef.ToolLengthCompensationHeightChar}{Cams[index7].Tool.Data.HeightOffsetIndex.ToString()} {this.postProcessor_0.ToolDef.ToolLengthCompensationZChar}";
                      this.AddCode(ref Codes2, NewCommand5, this.postProcessor_0, Position);
                    }
                    if (!this.postProcessor_0.ToolDef.UseToolLengthCompensation & this.postProcessor_0.ToolDef.UseToolLengthCompensationHeight)
                    {
                      string NewCommand6 = $"{this.postProcessor_0.ToolDef.ToolLengthCompensationHeightChar}{Cams[index7].Tool.Data.HeightOffsetIndex.ToString()} {this.postProcessor_0.ToolDef.ToolLengthCompensationZChar}";
                      this.AddCode(ref Codes2, NewCommand6, this.postProcessor_0, Position);
                    }
                    if (flag7)
                    {
                      for (int index11 = 0; index11 <= this.postProcessor_0.ToolDef.ToolData.AfterCode.Count - 1; ++index11)
                      {
                        string NewCommand7 = this.postProcessor_0.ToolDef.ToolData.AfterCode[index11].ToString().Trim();
                        if (NewCommand7.Length > 0)
                          this.AddCode(ref Codes2, NewCommand7, this.postProcessor_0, Position);
                      }
                    }
                  }
                  else
                  {
                    if (str12.Trim().Length > 0)
                      this.AddCode(ref Codes2, str8 + str12, this.postProcessor_0, Position);
                    if (this.postProcessor_0.ToolDef.UseToolLengthCompensation)
                    {
                      string NewCommand8 = this.postProcessor_0.ToolDef.ToolLengthCompensationChar;
                      if (this.postProcessor_0.ToolDef.UseToolLengthCompensationHeight)
                        NewCommand8 = $"{NewCommand8} {this.postProcessor_0.ToolDef.ToolLengthCompensationHeightChar}{Cams[index7].Tool.Data.HeightOffsetIndex.ToString()} {this.postProcessor_0.ToolDef.ToolLengthCompensationZChar}";
                      this.AddCode(ref Codes2, NewCommand8, this.postProcessor_0, Position);
                    }
                    if (!this.postProcessor_0.ToolDef.UseToolLengthCompensation & this.postProcessor_0.ToolDef.UseToolLengthCompensationHeight)
                    {
                      string NewCommand9 = $"{this.postProcessor_0.ToolDef.ToolLengthCompensationHeightChar}{Cams[index7].Tool.Data.HeightOffsetIndex.ToString()} {this.postProcessor_0.ToolDef.ToolLengthCompensationZChar}";
                      this.AddCode(ref Codes2, NewCommand9, this.postProcessor_0, Position);
                    }
                    if (flag7)
                    {
                      for (int index12 = 0; index12 <= this.postProcessor_0.ToolDef.ToolData.AfterCode.Count - 1; ++index12)
                      {
                        string NewCommand10 = this.postProcessor_0.ToolDef.ToolData.AfterCode[index12].ToString().Trim();
                        if (NewCommand10.Length > 0)
                          this.AddCode(ref Codes2, NewCommand10, this.postProcessor_0, Position);
                      }
                    }
                    if (this.postProcessor_0.SpindleDef.PreCode.Count > 0)
                    {
                      for (int index13 = 0; index13 <= this.postProcessor_0.SpindleDef.PreCode.Count - 1; ++index13)
                      {
                        string NewCommand11 = this.postProcessor_0.SpindleDef.PreCode[index13].ToString().Trim();
                        if (NewCommand11.Length > 0)
                          this.AddCode(ref Codes2, NewCommand11, this.postProcessor_0, Position);
                      }
                    }
                    if (NewCommand1.Length > 0)
                      this.AddCode(ref Codes2, NewCommand1, this.postProcessor_0, Position);
                    if (this.postProcessor_0.SpindleDef.AfterCode.Count > 0)
                    {
                      for (int index14 = 0; index14 <= this.postProcessor_0.SpindleDef.AfterCode.Count - 1; ++index14)
                      {
                        string NewCommand12 = this.postProcessor_0.SpindleDef.AfterCode[index14].ToString().Trim();
                        if (NewCommand12.Length > 0)
                          this.AddCode(ref Codes2, NewCommand12, this.postProcessor_0, Position);
                      }
                    }
                  }
                  if (this.postProcessor_0.ToolDef.UseToolAuxCodes && Cams[index7].Tool.Aux.Count > 0)
                  {
                    for (int index15 = 0; index15 <= Cams[index7].Tool.Aux.Count - 1; ++index15)
                    {
                      if (Cams[index7].Tool.Aux[index15].ToString().Length > 0)
                        this.AddCode(ref Codes2, Cams[index7].Tool.Aux[index15].ToString(), this.postProcessor_0, Position);
                    }
                  }
                }
              }
              else
              {
                str4 = "";
                if (this.postProcessor_0.SpindleDef.UseSpindle & !this.postProcessor_0.Tool1.ToolData.Enable & !this.postProcessor_0.Tool2.ToolData.Enable & !this.postProcessor_0.Tool3.ToolData.Enable & !this.postProcessor_0.Tool4.ToolData.Enable & !this.postProcessor_0.Tool5.ToolData.Enable)
                {
                  if (this.postProcessor_0.SpindleDef.PreCode.Count > 0)
                  {
                    for (int index16 = 0; index16 <= this.postProcessor_0.SpindleDef.PreCode.Count - 1; ++index16)
                    {
                      string NewCommand13 = this.postProcessor_0.SpindleDef.PreCode[index16].ToString().Trim();
                      if (NewCommand13.Length > 0)
                        this.AddCode(ref Codes2, NewCommand13, this.postProcessor_0, Position);
                    }
                  }
                  this.AddCode(ref Codes2, NewCommand1, this.postProcessor_0, Position);
                  if (this.postProcessor_0.SpindleDef.AfterCode.Count > 0)
                  {
                    for (int index17 = 0; index17 <= this.postProcessor_0.SpindleDef.AfterCode.Count - 1; ++index17)
                    {
                      string NewCommand14 = this.postProcessor_0.SpindleDef.AfterCode[index17].ToString().Trim();
                      if (NewCommand14.Length > 0)
                        this.AddCode(ref Codes2, NewCommand14, this.postProcessor_0, Position);
                    }
                  }
                }
              }
            }
            Pnt9DCam pnt9Dcam = new Pnt9DCam(double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue);
            pnt9Dcam.Type = -1;
            int num3 = 0;
            double Resolution1 = buSystem.resolutionCompare;
            double Resolution2 = buSystem.resolutionCompare;
            double Resolution3 = buSystem.resolutionCompare;
            double Resolution4 = buSystem.resolutionCompare;
            double Resolution5 = buSystem.resolutionCompare;
            double Resolution6 = buSystem.resolutionCompare;
            double Resolution7 = buSystem.resolutionCompare;
            double Resolution8 = buSystem.resolutionCompare;
            double Resolution9 = buSystem.resolutionCompare;
            if (this.postProcessor_0.XDef.Decimal > 0)
              Resolution1 = 1.0 / Math.Pow(10.0, (double) this.postProcessor_0.XDef.Decimal);
            if (this.postProcessor_0.YDef.Decimal > 0)
              Resolution2 = 1.0 / Math.Pow(10.0, (double) this.postProcessor_0.YDef.Decimal);
            if (this.postProcessor_0.ZDef.Decimal > 0)
              Resolution3 = 1.0 / Math.Pow(10.0, (double) this.postProcessor_0.ZDef.Decimal);
            if (this.postProcessor_0.ADef.Decimal > 0)
              Resolution4 = 1.0 / Math.Pow(10.0, (double) this.postProcessor_0.ADef.Decimal);
            if (this.postProcessor_0.BDef.Decimal > 0)
              Resolution5 = 1.0 / Math.Pow(10.0, (double) this.postProcessor_0.BDef.Decimal);
            if (this.postProcessor_0.CDef.Decimal > 0)
              Resolution6 = 1.0 / Math.Pow(10.0, (double) this.postProcessor_0.CDef.Decimal);
            if (this.postProcessor_0.UDef.Decimal > 0)
              Resolution7 = 1.0 / Math.Pow(10.0, (double) this.postProcessor_0.UDef.Decimal);
            if (this.postProcessor_0.VDef.Decimal > 0)
              Resolution8 = 1.0 / Math.Pow(10.0, (double) this.postProcessor_0.VDef.Decimal);
            if (this.postProcessor_0.WDef.Decimal > 0)
              Resolution9 = 1.0 / Math.Pow(10.0, (double) this.postProcessor_0.WDef.Decimal);
            for (int index18 = 0; index18 <= Cams[index7].CamPoints.Count - 1; ++index18)
            {
              int num4 = 0;
              int num5 = 0;
              double feed = Cams[index7].CamPoints[index18].Feed;
              for (int index19 = 0; index19 <= Cams[index7].CamPoints[index18].PreCodes.Count - 1; ++index19)
              {
                string NewCommand15 = Cams[index7].CamPoints[index18].PreCodes[index19].ToString().Trim();
                if (NewCommand15.Length > 0)
                  this.AddCode(ref Codes2, NewCommand15, this.postProcessor_0, Position);
              }
              string str13 = "";
              string str14 = "";
              string str15 = "";
              string str16 = "";
              string str17 = this.ValueFormat(this.postProcessor_0, "F", feed, 0.0, 0, Cams[index7]);
              if (Cams[index7].CamPoints[index18].IsRapid && !this.postProcessor_0.G0Propery.UseFeedSpeed)
                str17 = "";
              eEntities GCodeEntity = new eEntities();
              for (int index20 = 0; index20 <= Cams[index7].CamPoints[index18].Points.Count - 1; ++index20)
              {
                Position = new Pnt9D(Cams[index7].CamPoints[index18].Points[index20].P9);
                int count = Cams[index7].CamPoints[index18].Points[index20].PreCodes.Count;
                ++num2;
                if (Cams[index7].CamPoints[index18].Points[index20].Type == 0)
                  str5 = this.ValueFormat(this.postProcessor_0, "G", Cams[index7].CamPoints[index18].Points[index20].Type);
                if (Cams[index7].CamPoints[index18].Points[index20].Type == 1)
                  str5 = this.ValueFormat(this.postProcessor_0, "G", Cams[index7].CamPoints[index18].Points[index20].Type);
                if ((Cams[index7].CamPoints[index18].Points[index20].Type == 2 | Cams[index7].CamPoints[index18].Points[index20].Type == 3) & this.postProcessor_0.CircularDef.Type == CircularPostType.DevidedLine)
                  str5 = this.ValueFormat(this.postProcessor_0, "G", 1);
                if ((Cams[index7].CamPoints[index18].Points[index20].Type == 2 | Cams[index7].CamPoints[index18].Points[index20].Type == 3) & this.postProcessor_0.CircularDef.Type == CircularPostType.Arc)
                {
                  str5 = this.ValueFormat(this.postProcessor_0, "G", Cams[index7].CamPoints[index18].Points[index20].Type);
                  if (this.postProcessor_0.CircularDef.Mode == CircularMode.R)
                  {
                    str13 = this.ValueFormat(this.postProcessor_0, "R", Cams[index7].CamPoints[index18].Points[index20].ArcData.Radius, 0.0, 0, Cams[index7]);
                    if (this.postProcessor_0.RDef.AdditionalData.Length > 0 & !Cams[index7].CamPoints[index18].Points[index20].DontUseAdditionalCommand)
                    {
                      string str18 = new string(' ', this.postProcessor_0.RDef.SpaceWithAdditionalData);
                      string additionalData = this.postProcessor_0.RDef.AdditionalData;
                      this.GetPostParameter(ref additionalData, Cams[index7].CamPoints[index18].Points[index20]);
                      str13 = str13 + additionalData + str18;
                    }
                  }
                  if (this.postProcessor_0.CircularDef.Mode == CircularMode.IJK)
                  {
                    double num6 = 0.0;
                    double num7 = 0.0;
                    double num8 = 0.0;
                    if (this.postProcessor_0.CircularDef.IJKMode == CircularIJKMode.OffsetFromStartToCenter)
                    {
                      num6 = Cams[index7].CamPoints[index18].Points[index20].ArcData.CenterPoint.X - Cams[index7].CamPoints[index18].Points[0].P9.X;
                      num7 = Cams[index7].CamPoints[index18].Points[index20].ArcData.CenterPoint.Y - Cams[index7].CamPoints[index18].Points[0].P9.Y;
                      num8 = Cams[index7].CamPoints[index18].Points[index20].ArcData.CenterPoint.Z - Cams[index7].CamPoints[index18].Points[0].P9.Z;
                    }
                    if (this.postProcessor_0.CircularDef.IJKMode == CircularIJKMode.Center)
                    {
                      num6 = Cams[index7].CamPoints[index18].Points[index20].ArcData.CenterPoint.X;
                      num7 = Cams[index7].CamPoints[index18].Points[index20].ArcData.CenterPoint.Y;
                      num8 = Cams[index7].CamPoints[index18].Points[index20].ArcData.CenterPoint.Z;
                    }
                    str14 = this.ValueFormat(this.postProcessor_0, "I", num6, 0.0, 0, Cams[index7]);
                    str15 = this.ValueFormat(this.postProcessor_0, "J", num7, 0.0, 0, Cams[index7]);
                    str16 = this.ValueFormat(this.postProcessor_0, "K", num8, 0.0, 0, Cams[index7]);
                    if (Cams[index7].Plane.PlaneType == planeType.XY)
                      str16 = "";
                    if (Cams[index7].Plane.PlaneType == planeType.XZ)
                      str15 = "";
                    if (Cams[index7].Plane.PlaneType == planeType.YZ)
                      str14 = "";
                  }
                }
                for (int index21 = 0; index21 <= Cams[index7].CamPoints[index18].Points[index20].PreCodes.Count - 1; ++index21)
                {
                  string NewCommand16 = Cams[index7].CamPoints[index18].Points[index20].PreCodes[index21].ToString().Trim();
                  if (NewCommand16.Length > 0)
                    this.AddCode(ref Codes2, NewCommand16, this.postProcessor_0, Position);
                }
                if (Cams[index7].CamPoints[index18].Points[index20].Feed > 0.0)
                {
                  feed = Cams[index7].CamPoints[index18].Points[index20].Feed;
                  str17 = this.ValueFormat(this.postProcessor_0, "F", feed, 0.0, 0, Cams[index7]);
                }
                string str19;
                if (this.postProcessor_0.AxesUsing.X)
                {
                  str19 = this.ValueFormat(this.postProcessor_0, "X", Cams[index7].CamPoints[index18].Points[index20].P9.X + Cams[index7].CamPoints[index18].GCodeOffset.X, this.MoveDistance.X + Cams[index7].MoveOffset.X, 0, Cams[index7]);
                  if (this.postProcessor_0.XDef.AdditionalData.Length > 0 & !Cams[index7].CamPoints[index18].Points[index20].DontUseAdditionalCommand)
                  {
                    string str20 = new string(' ', this.postProcessor_0.XDef.SpaceWithAdditionalData);
                    string additionalData = this.postProcessor_0.XDef.AdditionalData;
                    this.GetPostParameter(ref additionalData, Cams[index7].CamPoints[index18].Points[index20]);
                    str19 = str19 + additionalData + str20;
                  }
                }
                else
                {
                  str19 = "";
                  pnt9Dcam.P9.X = 0.0;
                }
                string str21;
                if (this.postProcessor_0.AxesUsing.Y)
                {
                  str21 = this.ValueFormat(this.postProcessor_0, "Y", Cams[index7].CamPoints[index18].Points[index20].P9.Y + Cams[index7].CamPoints[index18].GCodeOffset.Y, this.MoveDistance.Y + Cams[index7].MoveOffset.Y, 0, Cams[index7]);
                  if (this.postProcessor_0.YDef.AdditionalData.Length > 0 & !Cams[index7].CamPoints[index18].Points[index20].DontUseAdditionalCommand)
                  {
                    string str22 = new string(' ', this.postProcessor_0.YDef.SpaceWithAdditionalData);
                    string additionalData = this.postProcessor_0.YDef.AdditionalData;
                    this.GetPostParameter(ref additionalData, Cams[index7].CamPoints[index18].Points[index20]);
                    str21 = str21 + additionalData + str22;
                  }
                }
                else
                {
                  str21 = "";
                  pnt9Dcam.P9.Y = 0.0;
                }
                string str23;
                if (this.postProcessor_0.AxesUsing.Z)
                {
                  str23 = this.ValueFormat(this.postProcessor_0, "Z", Cams[index7].CamPoints[index18].Points[index20].P9.Z + Cams[index7].CamPoints[index18].GCodeOffset.Z, this.MoveDistance.Z + Cams[index7].MoveOffset.Z, Cams[index7].ZAxisIndex, Cams[index7]);
                  if (this.postProcessor_0.ZDef.AdditionalData.Length > 0 & !Cams[index7].CamPoints[index18].Points[index20].DontUseAdditionalCommand)
                  {
                    string str24 = new string(' ', this.postProcessor_0.ZDef.SpaceWithAdditionalData);
                    string additionalData = this.postProcessor_0.ZDef.AdditionalData;
                    this.GetPostParameter(ref additionalData, Cams[index7].CamPoints[index18].Points[index20]);
                    str23 = str23 + additionalData + str24;
                  }
                }
                else
                {
                  str23 = "";
                  pnt9Dcam.P9.Z = 0.0;
                }
                string str25;
                if (this.postProcessor_0.AxesUsing.A)
                {
                  str25 = this.ValueFormat(this.postProcessor_0, "A", Cams[index7].CamPoints[index18].Points[index20].P9.A + Cams[index7].CamPoints[index18].GCodeOffset.A, 0.0, 0, Cams[index7]);
                  if (this.postProcessor_0.ADef.AdditionalData.Length > 0 & !Cams[index7].CamPoints[index18].Points[index20].DontUseAdditionalCommand)
                  {
                    string str26 = new string(' ', this.postProcessor_0.ADef.SpaceWithAdditionalData);
                    string additionalData = this.postProcessor_0.ADef.AdditionalData;
                    this.GetPostParameter(ref additionalData, Cams[index7].CamPoints[index18].Points[index20]);
                    str25 = str25 + additionalData + str26;
                  }
                }
                else
                {
                  str25 = "";
                  pnt9Dcam.P9.A = 0.0;
                }
                string str27;
                if (this.postProcessor_0.AxesUsing.B)
                {
                  str27 = this.ValueFormat(this.postProcessor_0, "B", Cams[index7].CamPoints[index18].Points[index20].P9.B + Cams[index7].CamPoints[index18].GCodeOffset.B, 0.0, 0, Cams[index7]);
                  if (this.postProcessor_0.BDef.AdditionalData.Length > 0 & !Cams[index7].CamPoints[index18].Points[index20].DontUseAdditionalCommand)
                  {
                    string str28 = new string(' ', this.postProcessor_0.BDef.SpaceWithAdditionalData);
                    string additionalData = this.postProcessor_0.BDef.AdditionalData;
                    this.GetPostParameter(ref additionalData, Cams[index7].CamPoints[index18].Points[index20]);
                    str27 = str27 + additionalData + str28;
                  }
                }
                else
                {
                  str27 = "";
                  pnt9Dcam.P9.B = 0.0;
                }
                string str29;
                if (this.postProcessor_0.AxesUsing.C)
                {
                  str29 = this.ValueFormat(this.postProcessor_0, "C", Cams[index7].CamPoints[index18].Points[index20].P9.C + Cams[index7].CamPoints[index18].GCodeOffset.C, 0.0, 0, Cams[index7]);
                  if (this.postProcessor_0.CDef.AdditionalData.Length > 0 & !Cams[index7].CamPoints[index18].Points[index20].DontUseAdditionalCommand)
                  {
                    string str30 = new string(' ', this.postProcessor_0.CDef.SpaceWithAdditionalData);
                    string additionalData = this.postProcessor_0.CDef.AdditionalData;
                    this.GetPostParameter(ref additionalData, Cams[index7].CamPoints[index18].Points[index20]);
                    str29 = str29 + additionalData + str30;
                  }
                }
                else
                {
                  str29 = "";
                  pnt9Dcam.P9.C = 0.0;
                }
                if (flag1)
                {
                  if (this.postProcessor_0.AxesUsing.U)
                  {
                    str1 = this.ValueFormat(this.postProcessor_0, "U", Cams[index7].CamPoints[index18].Points[index20].P9.U + Cams[index7].CamPoints[index18].GCodeOffset.U, 0.0, 0, Cams[index7]);
                    if (this.postProcessor_0.UDef.AdditionalData.Length > 0 & !Cams[index7].CamPoints[index18].Points[index20].DontUseAdditionalCommand)
                    {
                      string str31 = new string(' ', this.postProcessor_0.UDef.SpaceWithAdditionalData);
                      string additionalData = this.postProcessor_0.UDef.AdditionalData;
                      this.GetPostParameter(ref additionalData, Cams[index7].CamPoints[index18].Points[index20]);
                      str1 = str1 + additionalData + str31;
                    }
                  }
                  else
                  {
                    str1 = "";
                    pnt9Dcam.P9.U = 0.0;
                  }
                  if (this.postProcessor_0.AxesUsing.V)
                  {
                    str2 = this.ValueFormat(this.postProcessor_0, "V", Cams[index7].CamPoints[index18].Points[index20].P9.V + Cams[index7].CamPoints[index18].GCodeOffset.V, 0.0, 0, Cams[index7]);
                    if (this.postProcessor_0.VDef.AdditionalData.Length > 0 & !Cams[index7].CamPoints[index18].Points[index20].DontUseAdditionalCommand)
                    {
                      string str32 = new string(' ', this.postProcessor_0.VDef.SpaceWithAdditionalData);
                      string additionalData = this.postProcessor_0.VDef.AdditionalData;
                      this.GetPostParameter(ref additionalData, Cams[index7].CamPoints[index18].Points[index20]);
                      str2 = str2 + additionalData + str32;
                    }
                  }
                  else
                  {
                    str2 = "";
                    pnt9Dcam.P9.V = 0.0;
                  }
                  if (this.postProcessor_0.AxesUsing.W)
                  {
                    str3 = this.ValueFormat(this.postProcessor_0, "W", Cams[index7].CamPoints[index18].Points[index20].P9.W + Cams[index7].CamPoints[index18].GCodeOffset.W, 0.0, 0, Cams[index7]);
                    if (this.postProcessor_0.WDef.AdditionalData.Length > 0 & !Cams[index7].CamPoints[index18].Points[index20].DontUseAdditionalCommand)
                    {
                      string str33 = new string(' ', this.postProcessor_0.WDef.SpaceWithAdditionalData);
                      string additionalData = this.postProcessor_0.WDef.AdditionalData;
                      this.GetPostParameter(ref additionalData, Cams[index7].CamPoints[index18].Points[index20]);
                      str3 = str3 + additionalData + str33;
                    }
                  }
                  else
                  {
                    str3 = "";
                    pnt9Dcam.P9.W = 0.0;
                  }
                }
                if (!Cams[index7].CamPoints[index18].Points[index20].EnableAxes.X)
                {
                  str19 = "";
                  pnt9Dcam.P9.X = 0.0;
                }
                if (!Cams[index7].CamPoints[index18].Points[index20].EnableAxes.Y)
                {
                  str21 = "";
                  pnt9Dcam.P9.Y = 0.0;
                }
                if (!Cams[index7].CamPoints[index18].Points[index20].EnableAxes.Z)
                {
                  str23 = "";
                  pnt9Dcam.P9.Z = 0.0;
                }
                if (!Cams[index7].CamPoints[index18].Points[index20].EnableAxes.A)
                {
                  str25 = "";
                  pnt9Dcam.P9.A = 0.0;
                }
                if (!Cams[index7].CamPoints[index18].Points[index20].EnableAxes.B)
                {
                  str27 = "";
                  pnt9Dcam.P9.B = 0.0;
                }
                if (!Cams[index7].CamPoints[index18].Points[index20].EnableAxes.C)
                {
                  str29 = "";
                  pnt9Dcam.P9.C = 0.0;
                }
                if (!Cams[index7].CamPoints[index18].Points[index20].EnableAxes.U)
                {
                  str1 = "";
                  pnt9Dcam.P9.U = 0.0;
                }
                if (!Cams[index7].CamPoints[index18].Points[index20].EnableAxes.V)
                {
                  str2 = "";
                  pnt9Dcam.P9.V = 0.0;
                }
                if (!Cams[index7].CamPoints[index18].Points[index20].EnableAxes.W)
                {
                  str3 = "";
                  pnt9Dcam.P9.W = 0.0;
                }
                if (pnt9Dcam != null)
                {
                  if (!this.postProcessor_0.RepetitionDef.Command && Cams[index7].CamPoints[index18].Points[index20].Type == pnt9Dcam.Type)
                  {
                    if (Cams[index7].CamPoints[index18].Points[index20].Type != 2)
                    {
                      if (num3 == 0 & count == 0)
                        str5 = "";
                    }
                    else if (Cams[index7].CamPoints[index18].Points[index20].ArcType == pnt9Dcam.ArcType && num3 == 0 & count == 0)
                      str5 = "";
                  }
                  if (!this.postProcessor_0.RepetitionDef.Feed && feed == pnt9Dcam.Feed & Cams[index7].CamPoints[index18].Points[index20].Type == pnt9Dcam.Type)
                    str17 = "";
                  if (!this.postProcessor_0.G0Propery.UseFeedSpeed && Cams[index7].CamPoints[index18].Points[index20].Type == 0)
                    str17 = "";
                  if (!this.postProcessor_0.RepetitionDef.Coordinate & !Cams[index7].CamPoints[index18].ForceWriteAllCoordinate)
                  {
                    if (buCompare.EQ(Cams[index7].CamPoints[index18].Points[index20].P9.X, pnt9Dcam.P9.X, Resolution1) & !this.postProcessor_0.RepetitionDef.AxesRepetation.X)
                      str19 = "";
                    if (buCompare.EQ(Cams[index7].CamPoints[index18].Points[index20].P9.Y, pnt9Dcam.P9.Y, Resolution2) & !this.postProcessor_0.RepetitionDef.AxesRepetation.Y)
                      str21 = "";
                    if (buCompare.EQ(Cams[index7].CamPoints[index18].Points[index20].P9.Z, pnt9Dcam.P9.Z, Resolution3) & !this.postProcessor_0.RepetitionDef.AxesRepetation.Z)
                      str23 = "";
                    if (buCompare.EQ(Cams[index7].CamPoints[index18].Points[index20].P9.A, pnt9Dcam.P9.A, Resolution4) & !this.postProcessor_0.RepetitionDef.AxesRepetation.A)
                      str25 = "";
                    if (buCompare.EQ(Cams[index7].CamPoints[index18].Points[index20].P9.B, pnt9Dcam.P9.B, Resolution5) & !this.postProcessor_0.RepetitionDef.AxesRepetation.B)
                      str27 = "";
                    if (buCompare.EQ(Cams[index7].CamPoints[index18].Points[index20].P9.C, pnt9Dcam.P9.C, Resolution6) & !this.postProcessor_0.RepetitionDef.AxesRepetation.C)
                      str29 = "";
                    if (flag1)
                    {
                      if (buCompare.EQ(Cams[index7].CamPoints[index18].Points[index20].P9.U, pnt9Dcam.P9.U, Resolution7) & !this.postProcessor_0.RepetitionDef.AxesRepetation.U)
                        str1 = "";
                      if (buCompare.EQ(Cams[index7].CamPoints[index18].Points[index20].P9.V, pnt9Dcam.P9.V, Resolution8) & !this.postProcessor_0.RepetitionDef.AxesRepetation.V)
                        str2 = "";
                      if (buCompare.EQ(Cams[index7].CamPoints[index18].Points[index20].P9.W, pnt9Dcam.P9.W, Resolution9) & !this.postProcessor_0.RepetitionDef.AxesRepetation.W)
                        str3 = "";
                    }
                  }
                }
                if (flag1)
                {
                  if (buCompare.EQ(Cams[index7].CamPoints[index18].Points[index20].P9, pnt9Dcam.P9))
                  {
                    str19 = "";
                    str21 = "";
                    str23 = "";
                    str25 = "";
                    str27 = "";
                    str29 = "";
                    str1 = "";
                    str2 = "";
                    str3 = "";
                  }
                }
                else if (buCompare.EQ(new Pnt6D(Cams[index7].CamPoints[index18].Points[index20].P9), new Pnt6D(pnt9Dcam.P9)))
                {
                  str19 = "";
                  str21 = "";
                  str23 = "";
                  str25 = "";
                  str27 = "";
                  str29 = "";
                  str1 = "";
                  str2 = "";
                  str3 = "";
                }
                if (!this.postProcessor_0.UseFCode)
                  str17 = "";
                if (Cams[index7].CamPoints[index18].Points[index20].Type != 2 & Cams[index7].CamPoints[index18].Points[index20].Type != 3)
                {
                  str13 = "";
                  str14 = "";
                  str15 = "";
                  str16 = "";
                }
                if (Cams[index7].CamPoints[index18].Points[index20].PlungeAxisMovement)
                {
                  if (Cams[index7].CamPoints[index18].Points[index20].PlungeAxis == "Z")
                  {
                    str19 = "";
                    str21 = "";
                    str25 = "";
                    str27 = "";
                    str29 = "";
                    str1 = "";
                    str2 = "";
                    str3 = "";
                  }
                  if (Cams[index7].CamPoints[index18].Points[index20].PlungeAxis == "X")
                  {
                    str23 = "";
                    str21 = "";
                    str25 = "";
                    str27 = "";
                    str29 = "";
                    str1 = "";
                    str2 = "";
                    str3 = "";
                  }
                  if (Cams[index7].CamPoints[index18].Points[index20].PlungeAxis == "Y")
                  {
                    str19 = "";
                    str23 = "";
                    str25 = "";
                    str27 = "";
                    str29 = "";
                    str1 = "";
                    str2 = "";
                    str3 = "";
                  }
                  ++num4;
                }
                if (Cams[index7].CamPoints[index18].Points[index20].LeaveAxisMovement)
                {
                  if (Cams[index7].CamPoints[index18].Points[index20].PlungeAxis == "Z")
                  {
                    str19 = "";
                    str21 = "";
                    str25 = "";
                    str27 = "";
                    str29 = "";
                    str1 = "";
                    str2 = "";
                    str3 = "";
                  }
                  if (Cams[index7].CamPoints[index18].Points[index20].PlungeAxis == "X")
                  {
                    str23 = "";
                    str21 = "";
                    str25 = "";
                    str27 = "";
                    str29 = "";
                    str1 = "";
                    str2 = "";
                    str3 = "";
                  }
                  if (Cams[index7].CamPoints[index18].Points[index20].PlungeAxis == "Y")
                  {
                    str19 = "";
                    str23 = "";
                    str25 = "";
                    str27 = "";
                    str29 = "";
                    str1 = "";
                    str2 = "";
                    str3 = "";
                  }
                  ++num5;
                }
                string str34 = str19 + str21 + str23 + str25 + str27 + str29 + str1 + str2 + str3;
                string NewCommand17 = str5 + str34 + str13 + str14 + str15 + str16 + str17;
                if (num4 == 1 & !flag2)
                {
                  for (int index22 = 0; index22 <= this.postProcessor_0.FirstPlungePreCodes.Count - 1; ++index22)
                  {
                    string NewCommand18 = this.postProcessor_0.FirstPlungePreCodes[index22].ToString().Trim();
                    if (NewCommand18.Length > 0)
                    {
                      this.AddCode(ref Codes2, NewCommand18, this.postProcessor_0, Position);
                      flag2 = true;
                    }
                  }
                }
                if (num5 == Cams[index7].CamPoints[index18].NumberOfLeaveMovement & !flag4)
                {
                  for (int index23 = 0; index23 <= this.postProcessor_0.LastLeavePreCodes.Count - 1; ++index23)
                  {
                    string NewCommand19 = this.postProcessor_0.LastLeavePreCodes[index23].ToString().Trim();
                    if (NewCommand19.Length > 0)
                    {
                      this.AddCode(ref Codes2, NewCommand19, this.postProcessor_0, Position);
                      flag4 = true;
                    }
                  }
                }
                if (str19.Length > 0)
                  pnt9Dcam.P9.X = Cams[index7].CamPoints[index18].Points[index20].P9.X;
                if (str21.Length > 0)
                  pnt9Dcam.P9.Y = Cams[index7].CamPoints[index18].Points[index20].P9.Y;
                if (str23.Length > 0)
                  pnt9Dcam.P9.Z = Cams[index7].CamPoints[index18].Points[index20].P9.Z;
                if (str25.Length > 0)
                  pnt9Dcam.P9.A = Cams[index7].CamPoints[index18].Points[index20].P9.A;
                if (str27.Length > 0)
                  pnt9Dcam.P9.B = Cams[index7].CamPoints[index18].Points[index20].P9.B;
                if (str29.Length > 0)
                  pnt9Dcam.P9.C = Cams[index7].CamPoints[index18].Points[index20].P9.C;
                if (flag1)
                {
                  if (str1.Length > 0)
                    pnt9Dcam.P9.U = Cams[index7].CamPoints[index18].Points[index20].P9.U;
                  if (str2.Length > 0)
                    pnt9Dcam.P9.V = Cams[index7].CamPoints[index18].Points[index20].P9.V;
                  if (str3.Length > 0)
                    pnt9Dcam.P9.W = Cams[index7].CamPoints[index18].Points[index20].P9.W;
                }
                if (str34.Length > 0)
                {
                  if (pnt9Dcam != null)
                  {
                    if (index20 > 0 && Cams[index7].CamPoints[index18].Points[index20].Type != 0 & pnt9Dcam.Type == 0 & this.postProcessor_0.G0Propery.AuxCodeForLastFallingG0.Enable & this.postProcessor_0.G0Propery.AuxCodeForLastFallingG0.PreCode.Count > 0)
                    {
                      for (int index24 = 0; index24 <= this.postProcessor_0.G0Propery.AuxCodeForLastFallingG0.PreCode.Count - 1; ++index24)
                      {
                        string NewCommand20 = this.postProcessor_0.G0Propery.AuxCodeForLastFallingG0.PreCode[index24].ToString().Trim();
                        if (NewCommand20.Length > 0)
                          this.AddCode(ref Codes2, NewCommand20, this.postProcessor_0, Position);
                      }
                    }
                    if (Cams[index7].CamPoints[index18].Points[index20].Type == 0 & pnt9Dcam.Type != 0 & this.postProcessor_0.G0Propery.AuxCodeForFirstRisingG0.Enable & this.postProcessor_0.G0Propery.AuxCodeForFirstRisingG0.PreCode.Count > 0)
                    {
                      for (int index25 = 0; index25 <= this.postProcessor_0.G0Propery.AuxCodeForFirstRisingG0.PreCode.Count - 1; ++index25)
                      {
                        string NewCommand21 = this.postProcessor_0.G0Propery.AuxCodeForFirstRisingG0.PreCode[index25].ToString().Trim();
                        if (NewCommand21.Length > 0)
                          this.AddCode(ref Codes2, NewCommand21, this.postProcessor_0, Position);
                      }
                    }
                    if (Cams[index7].CamPoints[index18].Points[index20].Type == 0 & this.postProcessor_0.G0Propery.AuxCodeForAllG0.Enable & this.postProcessor_0.G0Propery.AuxCodeForAllG0.PreCode.Count > 0)
                    {
                      for (int index26 = 0; index26 <= this.postProcessor_0.G0Propery.AuxCodeForAllG0.PreCode.Count - 1; ++index26)
                      {
                        string NewCommand22 = this.postProcessor_0.G0Propery.AuxCodeForAllG0.PreCode[index26].ToString().Trim();
                        if (NewCommand22.Length > 0)
                          this.AddCode(ref Codes2, NewCommand22, this.postProcessor_0, Position);
                      }
                    }
                    if ((Cams[index7].CamPoints[index18].Points[index20].Type == 1 | Cams[index7].CamPoints[index18].Points[index20].Type == 2 | Cams[index7].CamPoints[index18].Points[index20].Type == 3) & pnt9Dcam.Type != 1 & pnt9Dcam.Type != 2 & pnt9Dcam.Type != 3 & this.postProcessor_0.G1G2G3Propery.AuxCodeForFirstRisingG1G2G3.Enable & this.postProcessor_0.G1G2G3Propery.AuxCodeForFirstRisingG1G2G3.PreCode.Count > 0)
                    {
                      for (int index27 = 0; index27 <= this.postProcessor_0.G1G2G3Propery.AuxCodeForFirstRisingG1G2G3.PreCode.Count - 1; ++index27)
                      {
                        string NewCommand23 = this.postProcessor_0.G1G2G3Propery.AuxCodeForFirstRisingG1G2G3.PreCode[index27].ToString().Trim();
                        if (NewCommand23.Length > 0)
                          this.AddCode(ref Codes2, NewCommand23, this.postProcessor_0, Position);
                      }
                    }
                    if ((Cams[index7].CamPoints[index18].Points[index20].Type == 1 | Cams[index7].CamPoints[index18].Points[index20].Type == 2 | Cams[index7].CamPoints[index18].Points[index20].Type == 3) & this.postProcessor_0.G1G2G3Propery.AuxCodeForAllG1G2G3.Enable & this.postProcessor_0.G1G2G3Propery.AuxCodeForAllG1G2G3.PreCode.Count > 0)
                    {
                      for (int index28 = 0; index28 <= this.postProcessor_0.G1G2G3Propery.AuxCodeForAllG1G2G3.PreCode.Count - 1; ++index28)
                      {
                        string NewCommand24 = this.postProcessor_0.G1G2G3Propery.AuxCodeForAllG1G2G3.PreCode[index28].ToString().Trim();
                        if (NewCommand24.Length > 0)
                          this.AddCode(ref Codes2, NewCommand24, this.postProcessor_0, Position);
                      }
                    }
                    if (Cams[index7].CamPoints[index18].Points[index20].Type == 1 & pnt9Dcam.Type != 1 & this.postProcessor_0.G1Propery.AuxCodeForFirstRisingG1.Enable & this.postProcessor_0.G1Propery.AuxCodeForFirstRisingG1.PreCode.Count > 0)
                    {
                      for (int index29 = 0; index29 <= this.postProcessor_0.G1Propery.AuxCodeForFirstRisingG1.PreCode.Count - 1; ++index29)
                      {
                        string NewCommand25 = this.postProcessor_0.G1Propery.AuxCodeForFirstRisingG1.PreCode[index29].ToString().Trim();
                        if (NewCommand25.Length > 0)
                          this.AddCode(ref Codes2, NewCommand25, this.postProcessor_0, Position);
                      }
                    }
                    if (Cams[index7].CamPoints[index18].Points[index20].Type == 1 & this.postProcessor_0.G1Propery.AuxCodeForAllG1.Enable & this.postProcessor_0.G1Propery.AuxCodeForAllG1.PreCode.Count > 0)
                    {
                      for (int index30 = 0; index30 <= this.postProcessor_0.G1Propery.AuxCodeForAllG1.PreCode.Count - 1; ++index30)
                      {
                        string NewCommand26 = this.postProcessor_0.G1Propery.AuxCodeForAllG1.PreCode[index30].ToString().Trim();
                        if (NewCommand26.Length > 0)
                          this.AddCode(ref Codes2, NewCommand26, this.postProcessor_0, Position);
                      }
                    }
                    if (Cams[index7].CamPoints[index18].Points[index20].Type == 2 & pnt9Dcam.Type != 2 & this.postProcessor_0.G2Propery.AuxCodeForFirstRisingG2.Enable & this.postProcessor_0.G2Propery.AuxCodeForFirstRisingG2.PreCode.Count > 0)
                    {
                      for (int index31 = 0; index31 <= this.postProcessor_0.G2Propery.AuxCodeForFirstRisingG2.PreCode.Count - 1; ++index31)
                      {
                        string NewCommand27 = this.postProcessor_0.G2Propery.AuxCodeForFirstRisingG2.PreCode[index31].ToString().Trim();
                        if (NewCommand27.Length > 0)
                          this.AddCode(ref Codes2, NewCommand27, this.postProcessor_0, Position);
                      }
                    }
                    if (Cams[index7].CamPoints[index18].Points[index20].Type == 2 & this.postProcessor_0.G2Propery.AuxCodeForAllG2.Enable & this.postProcessor_0.G2Propery.AuxCodeForAllG2.PreCode.Count > 0)
                    {
                      for (int index32 = 0; index32 <= this.postProcessor_0.G2Propery.AuxCodeForAllG2.PreCode.Count - 1; ++index32)
                      {
                        string NewCommand28 = this.postProcessor_0.G2Propery.AuxCodeForAllG2.PreCode[index32].ToString().Trim();
                        if (NewCommand28.Length > 0)
                          this.AddCode(ref Codes2, NewCommand28, this.postProcessor_0, Position);
                      }
                    }
                    if (Cams[index7].CamPoints[index18].Points[index20].Type == 3 & pnt9Dcam.Type != 3 & this.postProcessor_0.G3Propery.AuxCodeForFirstRisingG3.Enable & this.postProcessor_0.G3Propery.AuxCodeForFirstRisingG3.PreCode.Count > 0)
                    {
                      for (int index33 = 0; index33 <= this.postProcessor_0.G3Propery.AuxCodeForFirstRisingG3.PreCode.Count - 1; ++index33)
                      {
                        string NewCommand29 = this.postProcessor_0.G3Propery.AuxCodeForFirstRisingG3.PreCode[index33].ToString().Trim();
                        if (NewCommand29.Length > 0)
                          this.AddCode(ref Codes2, NewCommand29, this.postProcessor_0, Position);
                      }
                    }
                    if (Cams[index7].CamPoints[index18].Points[index20].Type == 3 & this.postProcessor_0.G3Propery.AuxCodeForAllG3.Enable & this.postProcessor_0.G3Propery.AuxCodeForAllG3.PreCode.Count > 0)
                    {
                      for (int index34 = 0; index34 <= this.postProcessor_0.G3Propery.AuxCodeForAllG3.PreCode.Count - 1; ++index34)
                      {
                        string NewCommand30 = this.postProcessor_0.G3Propery.AuxCodeForAllG3.PreCode[index34].ToString().Trim();
                        if (NewCommand30.Length > 0)
                          this.AddCode(ref Codes2, NewCommand30, this.postProcessor_0, Position);
                      }
                    }
                  }
                  this.AddCode(ref Codes2, NewCommand17, this.postProcessor_0, GCodeEntity, Position);
                  if (str23.Length > 0 && this.postProcessor_0.UseToolHeightOffsetAfterZMove)
                  {
                    if (index18 < Cams[index7].CamPoints.Count - 1)
                      this.AddCode(ref Codes2, "M75", this.postProcessor_0, Position);
                    this.AddCode(ref Codes2, $"G43 H{Cams[index7].Tool.Data.HeightOffsetIndex.ToString()} {str23}", this.postProcessor_0, Position);
                  }
                  if (pnt9Dcam == null)
                    pnt9Dcam = new Pnt9DCam();
                  if (pnt9Dcam != null)
                  {
                    if (Cams[index7].CamPoints[index18].Points[index20].Type == 0 & pnt9Dcam.Type != 0 & this.postProcessor_0.G0Propery.AuxCodeForFirstRisingG0.Enable & this.postProcessor_0.G0Propery.AuxCodeForFirstRisingG0.AfterCode.Count > 0)
                    {
                      for (int index35 = 0; index35 <= this.postProcessor_0.G0Propery.AuxCodeForFirstRisingG0.AfterCode.Count - 1; ++index35)
                      {
                        string NewCommand31 = this.postProcessor_0.G0Propery.AuxCodeForFirstRisingG0.AfterCode[index35].ToString().Trim();
                        if (NewCommand31.Length > 0)
                          this.AddCode(ref Codes2, NewCommand31, this.postProcessor_0, Position);
                      }
                    }
                    if (Cams[index7].CamPoints[index18].Points[index20].Type != 0 & pnt9Dcam.Type == 0 & this.postProcessor_0.G0Propery.AuxCodeForLastFallingG0.Enable & this.postProcessor_0.G0Propery.AuxCodeForLastFallingG0.AfterCode.Count > 0)
                    {
                      for (int index36 = 0; index36 <= this.postProcessor_0.G0Propery.AuxCodeForLastFallingG0.AfterCode.Count - 1; ++index36)
                      {
                        string NewCommand32 = this.postProcessor_0.G0Propery.AuxCodeForLastFallingG0.AfterCode[index36].ToString().Trim();
                        if (NewCommand32.Length > 0)
                          this.AddCode(ref Codes2, NewCommand32, this.postProcessor_0, Position);
                      }
                    }
                    if (Cams[index7].CamPoints[index18].Points[index20].Type == 0 & this.postProcessor_0.G0Propery.AuxCodeForAllG0.Enable & this.postProcessor_0.G0Propery.AuxCodeForAllG0.AfterCode.Count > 0)
                    {
                      for (int index37 = 0; index37 <= this.postProcessor_0.G0Propery.AuxCodeForAllG0.AfterCode.Count - 1; ++index37)
                      {
                        string NewCommand33 = this.postProcessor_0.G0Propery.AuxCodeForAllG0.AfterCode[index37].ToString().Trim();
                        if (NewCommand33.Length > 0)
                          this.AddCode(ref Codes2, NewCommand33, this.postProcessor_0, Position);
                      }
                    }
                    if ((Cams[index7].CamPoints[index18].Points[index20].Type == 1 | Cams[index7].CamPoints[index18].Points[index20].Type == 2 | Cams[index7].CamPoints[index18].Points[index20].Type == 3) & pnt9Dcam.Type != 1 & pnt9Dcam.Type != 2 & pnt9Dcam.Type != 3 & this.postProcessor_0.G1G2G3Propery.AuxCodeForFirstRisingG1G2G3.Enable & this.postProcessor_0.G1G2G3Propery.AuxCodeForFirstRisingG1G2G3.AfterCode.Count > 0)
                    {
                      for (int index38 = 0; index38 <= this.postProcessor_0.G1G2G3Propery.AuxCodeForFirstRisingG1G2G3.AfterCode.Count - 1; ++index38)
                      {
                        string NewCommand34 = this.postProcessor_0.G1G2G3Propery.AuxCodeForFirstRisingG1G2G3.AfterCode[index38].ToString().Trim();
                        if (NewCommand34.Length > 0)
                          this.AddCode(ref Codes2, NewCommand34, this.postProcessor_0, Position);
                      }
                    }
                    if ((Cams[index7].CamPoints[index18].Points[index20].Type == 1 | Cams[index7].CamPoints[index18].Points[index20].Type == 2 | Cams[index7].CamPoints[index18].Points[index20].Type == 3) & this.postProcessor_0.G1G2G3Propery.AuxCodeForAllG1G2G3.Enable & this.postProcessor_0.G1G2G3Propery.AuxCodeForAllG1G2G3.AfterCode.Count > 0)
                    {
                      for (int index39 = 0; index39 <= this.postProcessor_0.G1G2G3Propery.AuxCodeForAllG1G2G3.AfterCode.Count - 1; ++index39)
                      {
                        string NewCommand35 = this.postProcessor_0.G1G2G3Propery.AuxCodeForAllG1G2G3.AfterCode[index39].ToString().Trim();
                        if (NewCommand35.Length > 0)
                          this.AddCode(ref Codes2, NewCommand35, this.postProcessor_0, Position);
                      }
                    }
                    if (Cams[index7].CamPoints[index18].Points[index20].Type == 1 & pnt9Dcam.Type != 1 & this.postProcessor_0.G1Propery.AuxCodeForFirstRisingG1.Enable & this.postProcessor_0.G1Propery.AuxCodeForFirstRisingG1.AfterCode.Count > 0)
                    {
                      for (int index40 = 0; index40 <= this.postProcessor_0.G1Propery.AuxCodeForFirstRisingG1.AfterCode.Count - 1; ++index40)
                      {
                        string NewCommand36 = this.postProcessor_0.G1Propery.AuxCodeForFirstRisingG1.AfterCode[index40].ToString().Trim();
                        if (NewCommand36.Length > 0)
                          this.AddCode(ref Codes2, NewCommand36, this.postProcessor_0, Position);
                      }
                    }
                    if (Cams[index7].CamPoints[index18].Points[index20].Type == 1 & this.postProcessor_0.G1Propery.AuxCodeForAllG1.Enable & this.postProcessor_0.G1Propery.AuxCodeForAllG1.AfterCode.Count > 0)
                    {
                      for (int index41 = 0; index41 <= this.postProcessor_0.G1Propery.AuxCodeForAllG1.AfterCode.Count - 1; ++index41)
                      {
                        string NewCommand37 = this.postProcessor_0.G1Propery.AuxCodeForAllG1.AfterCode[index41].ToString().Trim();
                        if (NewCommand37.Length > 0)
                          this.AddCode(ref Codes2, NewCommand37, this.postProcessor_0, Position);
                      }
                    }
                    if (Cams[index7].CamPoints[index18].Points[index20].Type == 2 & pnt9Dcam.Type != 2 & this.postProcessor_0.G2Propery.AuxCodeForFirstRisingG2.Enable & this.postProcessor_0.G2Propery.AuxCodeForFirstRisingG2.AfterCode.Count > 0)
                    {
                      for (int index42 = 0; index42 <= this.postProcessor_0.G2Propery.AuxCodeForFirstRisingG2.AfterCode.Count - 1; ++index42)
                      {
                        string NewCommand38 = this.postProcessor_0.G2Propery.AuxCodeForFirstRisingG2.AfterCode[index42].ToString().Trim();
                        if (NewCommand38.Length > 0)
                          this.AddCode(ref Codes2, NewCommand38, this.postProcessor_0, Position);
                      }
                    }
                    if (Cams[index7].CamPoints[index18].Points[index20].Type == 2 & this.postProcessor_0.G2Propery.AuxCodeForAllG2.Enable & this.postProcessor_0.G2Propery.AuxCodeForAllG2.AfterCode.Count > 0)
                    {
                      for (int index43 = 0; index43 <= this.postProcessor_0.G2Propery.AuxCodeForAllG2.AfterCode.Count - 1; ++index43)
                      {
                        string NewCommand39 = this.postProcessor_0.G2Propery.AuxCodeForAllG2.AfterCode[index43].ToString().Trim();
                        if (NewCommand39.Length > 0)
                          this.AddCode(ref Codes2, NewCommand39, this.postProcessor_0, Position);
                      }
                    }
                    if (Cams[index7].CamPoints[index18].Points[index20].Type == 3 & pnt9Dcam.Type != 3 & this.postProcessor_0.G3Propery.AuxCodeForFirstRisingG3.Enable & this.postProcessor_0.G3Propery.AuxCodeForFirstRisingG3.AfterCode.Count > 0)
                    {
                      for (int index44 = 0; index44 <= this.postProcessor_0.G3Propery.AuxCodeForFirstRisingG3.AfterCode.Count - 1; ++index44)
                      {
                        string NewCommand40 = this.postProcessor_0.G3Propery.AuxCodeForFirstRisingG3.AfterCode[index44].ToString().Trim();
                        if (NewCommand40.Length > 0)
                          this.AddCode(ref Codes2, NewCommand40, this.postProcessor_0, Position);
                      }
                    }
                    if (Cams[index7].CamPoints[index18].Points[index20].Type == 3 & this.postProcessor_0.G3Propery.AuxCodeForAllG3.Enable & this.postProcessor_0.G3Propery.AuxCodeForAllG3.AfterCode.Count > 0)
                    {
                      for (int index45 = 0; index45 <= this.postProcessor_0.G3Propery.AuxCodeForAllG3.AfterCode.Count - 1; ++index45)
                      {
                        string NewCommand41 = this.postProcessor_0.G3Propery.AuxCodeForAllG3.AfterCode[index45].ToString().Trim();
                        if (NewCommand41.Length > 0)
                          this.AddCode(ref Codes2, NewCommand41, this.postProcessor_0, Position);
                      }
                    }
                  }
                  pnt9Dcam.Type = Cams[index7].CamPoints[index18].Points[index20].Type;
                  pnt9Dcam.ArcType = Cams[index7].CamPoints[index18].Points[index20].ArcType;
                  pnt9Dcam.Feed = feed;
                }
                for (int index46 = 0; index46 <= Cams[index7].CamPoints[index18].Points[index20].AfterCodes.Count - 1; ++index46)
                {
                  string NewCommand42 = Cams[index7].CamPoints[index18].Points[index20].AfterCodes[index46].ToString().Trim();
                  if (NewCommand42.Length > 0)
                    this.AddCode(ref Codes2, NewCommand42, this.postProcessor_0, Position);
                }
                if (num4 == 1 & !flag3)
                {
                  for (int index47 = 0; index47 <= this.postProcessor_0.FirstPlungeAfterCodes.Count - 1; ++index47)
                  {
                    string NewCommand43 = this.postProcessor_0.FirstPlungeAfterCodes[index47].ToString().Trim();
                    if (NewCommand43.Length > 0)
                    {
                      this.AddCode(ref Codes2, NewCommand43, this.postProcessor_0, Position);
                      flag3 = true;
                    }
                  }
                }
                if (num5 == Cams[index7].CamPoints[index18].NumberOfLeaveMovement & !flag5)
                {
                  for (int index48 = 0; index48 <= this.postProcessor_0.LastLeaveAfterCodes.Count - 1; ++index48)
                  {
                    string NewCommand44 = this.postProcessor_0.LastLeaveAfterCodes[index48].ToString().Trim();
                    if (NewCommand44.Length > 0)
                    {
                      this.AddCode(ref Codes2, NewCommand44, this.postProcessor_0, Position);
                      flag5 = true;
                    }
                  }
                }
                if (Codes2.Length > 1000)
                {
                  AL.Add((object) Codes2);
                  Codes2 = "";
                }
                if (buSystem.DoEventEnable & int32 > 0 & num2 > 0 && num2 % int32 == 0)
                {
                  Application.DoEvents();
                  // ISSUE: reference to a compiler-generated field
                  if (buSystem.ProgressControlEnable && this.calculationEventHandler_0 != null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    this.calculationEventHandler_0(new CalculationEventArg(100.0, Convert.ToDouble((double) num2 / (double) num1) * 100.0, 0, "", ""));
                  }
                }
                if (!buSystem.Cancel)
                {
                  num3 = Cams[index7].CamPoints[index18].Points[index20].AfterCodes.Count;
                }
                else
                {
                  buSystem.Cancel = false;
                  buSystem.Canceled = true;
                  // ISSUE: reference to a compiler-generated field
                  if (this.calculationEventHandler_0 != null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    this.calculationEventHandler_0(new CalculationEventArg(100.0, 100.0, 0, "", "", true));
                  }
                  buLog.addLog("G Code Creat", "Canceled", MethodBase.GetCurrentMethod().Name);
                  return;
                }
              }
              for (int index49 = 0; index49 <= Cams[index7].CamPoints[index18].AfterCodes.Count - 1; ++index49)
              {
                string NewCommand45 = Cams[index7].CamPoints[index18].AfterCodes[index49].ToString().Trim();
                if (NewCommand45.Length > 0)
                  this.AddCode(ref Codes2, NewCommand45, this.postProcessor_0, Position);
              }
              AL.Add((object) Codes2);
              Codes2 = "";
            }
            if (Cams[index7].AfterCodes.Count > 0)
            {
              for (int index50 = 0; index50 <= Cams[index7].AfterCodes.Count - 1; ++index50)
              {
                string NewCommand46 = Cams[index7].AfterCodes[index50].ToString().Trim();
                if (NewCommand46.Length > 0)
                  this.AddCode(ref Codes2, NewCommand46, this.postProcessor_0, Position);
              }
            }
            for (int index51 = 0; index51 <= this.postProcessor_0.EndLinesEachBlock.Count - 1; ++index51)
            {
              string NewCommand47 = this.postProcessor_0.EndLinesEachBlock[index51].ToString().Trim();
              if (NewCommand47.Length > 0)
                this.AddCode(ref Codes2, NewCommand47, this.postProcessor_0, Position);
            }
          }
        }
        for (int index = 0; index <= this.postProcessor_0.EndLines.Count - 1; ++index)
          this.AddCode(ref Codes2, this.postProcessor_0.EndLines[index].ToString(), this.postProcessor_0, Position);
        AL.Add((object) Codes2);
        Codes2 = "";
        Lines = buString.ArrayListToString(AL);
        if (!this.bool_0 || AppLanguage.SystemMessages.Count <= 9)
          return;
        buString.MessageBoxWarning(AppLanguage.SystemMessages[9]);
      }
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public string ValueFormat(
    PostProcessor P,
    string Code,
    double Value,
    double MoveDistance,
    int AxisDefIndex,
    camBase Cam)
  {
    try
    {
      string str1 = "";
      if (Code == "X" | Code == "x")
      {
        if (AxisDefIndex == 0)
        {
          double num = Math.Round(Value * P.XDef.Multiply + MoveDistance, P.XDef.RoundCount);
          string str2 = new string(' ', P.XDef.SpaceWithCharAndValue);
          string str3 = new string(' ', P.XDef.SpaceWithNextCommandAndValue);
          str1 = P.XDef.Char + str2 + num.ToString("f" + P.XDef.Decimal.ToString(), (IFormatProvider) buSystem.CI) + str3;
        }
        if (AxisDefIndex == 1)
        {
          double num = Math.Round(Value * P.X2Def.Multiply + MoveDistance, P.XDef.RoundCount);
          string str4 = new string(' ', P.X2Def.SpaceWithCharAndValue);
          string str5 = new string(' ', P.X2Def.SpaceWithNextCommandAndValue);
          str1 = P.X2Def.Char + str4 + num.ToString("f" + P.X2Def.Decimal.ToString(), (IFormatProvider) buSystem.CI) + str5;
        }
        if (AxisDefIndex == 2)
        {
          double num = Math.Round(Value * P.X3Def.Multiply + MoveDistance, P.XDef.RoundCount);
          string str6 = new string(' ', P.X3Def.SpaceWithCharAndValue);
          string str7 = new string(' ', P.X3Def.SpaceWithNextCommandAndValue);
          str1 = P.X3Def.Char + str6 + num.ToString("f" + P.X3Def.Decimal.ToString(), (IFormatProvider) buSystem.CI) + str7;
        }
        if (AxisDefIndex == 3)
        {
          double num = Math.Round(Value * P.X4Def.Multiply + MoveDistance, P.XDef.RoundCount);
          string str8 = new string(' ', P.X4Def.SpaceWithCharAndValue);
          string str9 = new string(' ', P.X4Def.SpaceWithNextCommandAndValue);
          str1 = P.X4Def.Char + str8 + num.ToString("f" + P.X4Def.Decimal.ToString(), (IFormatProvider) buSystem.CI) + str9;
        }
        return str1;
      }
      if (Code == "Y" | Code == "y")
      {
        if (AxisDefIndex == 0)
        {
          double num = Math.Round(Value * P.YDef.Multiply + MoveDistance, P.YDef.RoundCount);
          string str10 = new string(' ', P.YDef.SpaceWithCharAndValue);
          string str11 = new string(' ', P.YDef.SpaceWithNextCommandAndValue);
          str1 = P.YDef.Char + str10 + num.ToString("f" + P.YDef.Decimal.ToString(), (IFormatProvider) buSystem.CI) + str11;
        }
        if (AxisDefIndex == 1)
        {
          double num = Math.Round(Value * P.Y2Def.Multiply + MoveDistance, P.YDef.RoundCount);
          string str12 = new string(' ', P.Y2Def.SpaceWithCharAndValue);
          string str13 = new string(' ', P.Y2Def.SpaceWithNextCommandAndValue);
          str1 = P.Y2Def.Char + str12 + num.ToString("f" + P.Y2Def.Decimal.ToString(), (IFormatProvider) buSystem.CI) + str13;
        }
        if (AxisDefIndex == 2)
        {
          double num = Math.Round(Value * P.Y3Def.Multiply + MoveDistance, P.YDef.RoundCount);
          string str14 = new string(' ', P.Y3Def.SpaceWithCharAndValue);
          string str15 = new string(' ', P.Y3Def.SpaceWithNextCommandAndValue);
          str1 = P.Y3Def.Char + str14 + num.ToString("f" + P.Y3Def.Decimal.ToString(), (IFormatProvider) buSystem.CI) + str15;
        }
        if (AxisDefIndex == 3)
        {
          double num = Math.Round(Value * P.Y4Def.Multiply + MoveDistance, P.YDef.RoundCount);
          string str16 = new string(' ', P.Y4Def.SpaceWithCharAndValue);
          string str17 = new string(' ', P.Y4Def.SpaceWithNextCommandAndValue);
          str1 = P.Y4Def.Char + str16 + num.ToString("f" + P.Y4Def.Decimal.ToString(), (IFormatProvider) buSystem.CI) + str17;
        }
        return str1;
      }
      if (Code == "Z" | Code == "z")
      {
        string z = P.ZDef.Char;
        if (Cam != null && Cam.ForceAxisString.Z.Length > 0)
          z = Cam.ForceAxisString.Z;
        if (AxisDefIndex == 0)
        {
          double num = Math.Round(Value * P.ZDef.Multiply + MoveDistance, P.ZDef.RoundCount);
          string str18 = new string(' ', P.ZDef.SpaceWithCharAndValue);
          string str19 = new string(' ', P.ZDef.SpaceWithNextCommandAndValue);
          str1 = z + str18 + num.ToString("f" + P.ZDef.Decimal.ToString(), (IFormatProvider) buSystem.CI) + str19;
        }
        if (AxisDefIndex == 1)
        {
          double num = Math.Round(Value * P.Z2Def.Multiply + MoveDistance, P.ZDef.RoundCount);
          string str20 = new string(' ', P.Z2Def.SpaceWithCharAndValue);
          string str21 = new string(' ', P.Z2Def.SpaceWithNextCommandAndValue);
          str1 = P.Z2Def.Char + str20 + num.ToString("f" + P.Z2Def.Decimal.ToString(), (IFormatProvider) buSystem.CI) + str21;
        }
        if (AxisDefIndex == 2)
        {
          double num = Math.Round(Value * P.Z3Def.Multiply + MoveDistance, P.ZDef.RoundCount);
          string str22 = new string(' ', P.Z3Def.SpaceWithCharAndValue);
          string str23 = new string(' ', P.Z3Def.SpaceWithNextCommandAndValue);
          str1 = P.Z3Def.Char + str22 + num.ToString("f" + P.Z3Def.Decimal.ToString(), (IFormatProvider) buSystem.CI) + str23;
        }
        if (AxisDefIndex == 3)
        {
          double num = Math.Round(Value * P.Z4Def.Multiply + MoveDistance, P.ZDef.RoundCount);
          string str24 = new string(' ', P.Z4Def.SpaceWithCharAndValue);
          string str25 = new string(' ', P.Z4Def.SpaceWithNextCommandAndValue);
          str1 = P.Z4Def.Char + str24 + num.ToString("f" + P.Z4Def.Decimal.ToString(), (IFormatProvider) buSystem.CI) + str25;
        }
        return str1;
      }
      if (Code == "A" | Code == "a")
      {
        double num = Math.Round(Value * P.ADef.Multiply + MoveDistance, P.ADef.RoundCount);
        string str26 = new string(' ', P.ADef.SpaceWithCharAndValue);
        string str27 = new string(' ', P.ADef.SpaceWithNextCommandAndValue);
        return P.ADef.Char + str26 + num.ToString("f" + P.ADef.Decimal.ToString(), (IFormatProvider) buSystem.CI) + str27;
      }
      if (Code == "B" | Code == "b")
      {
        double num = Math.Round(Value * P.BDef.Multiply + MoveDistance, P.BDef.RoundCount);
        string str28 = new string(' ', P.BDef.SpaceWithCharAndValue);
        string str29 = new string(' ', P.BDef.SpaceWithNextCommandAndValue);
        return P.BDef.Char + str28 + num.ToString("f" + P.BDef.Decimal.ToString(), (IFormatProvider) buSystem.CI) + str29;
      }
      if (Code == "C" | Code == "c")
      {
        double num = Math.Round(Value * P.CDef.Multiply + MoveDistance, P.CDef.RoundCount);
        string str30 = new string(' ', P.CDef.SpaceWithCharAndValue);
        string str31 = new string(' ', P.CDef.SpaceWithNextCommandAndValue);
        return P.CDef.Char + str30 + num.ToString("f" + P.CDef.Decimal.ToString(), (IFormatProvider) buSystem.CI) + str31;
      }
      if (Code == "U" | Code == "u")
      {
        double num = Math.Round(Value * P.UDef.Multiply + MoveDistance, P.UDef.RoundCount);
        string str32 = new string(' ', P.UDef.SpaceWithCharAndValue);
        string str33 = new string(' ', P.UDef.SpaceWithNextCommandAndValue);
        return P.UDef.Char + str32 + num.ToString("f" + P.UDef.Decimal.ToString(), (IFormatProvider) buSystem.CI) + str33;
      }
      if (Code == "V" | Code == "v")
      {
        double num = Math.Round(Value * P.VDef.Multiply + MoveDistance, P.VDef.RoundCount);
        string str34 = new string(' ', P.VDef.SpaceWithCharAndValue);
        string str35 = new string(' ', P.VDef.SpaceWithNextCommandAndValue);
        return P.VDef.Char + str34 + num.ToString("f" + P.VDef.Decimal.ToString(), (IFormatProvider) buSystem.CI) + str35;
      }
      if (Code == "W" | Code == "w")
      {
        double num = Math.Round(Value * P.WDef.Multiply + MoveDistance, P.WDef.RoundCount);
        string str36 = new string(' ', P.WDef.SpaceWithCharAndValue);
        string str37 = new string(' ', P.WDef.SpaceWithNextCommandAndValue);
        return P.WDef.Char + str36 + num.ToString("f" + P.WDef.Decimal.ToString(), (IFormatProvider) buSystem.CI) + str37;
      }
      if (Code == "F" | Code == "f" | Code.ToLower() == P.FDef.Char.ToLower())
      {
        double num = Value * P.FDef.Multiply;
        string str38 = new string(' ', P.FDef.SpaceWithCharAndValue);
        string str39 = new string(' ', P.FDef.SpaceWithNextCommandAndValue);
        return P.FDef.Char + str38 + num.ToString("f" + P.FDef.Decimal.ToString(), (IFormatProvider) buSystem.CI) + str39;
      }
      if (Code == "R" | Code == "r" | Code.ToLower() == P.RDef.Char.ToLower())
      {
        double num = Math.Round(Value, P.RDef.RoundCount);
        string str40 = new string(' ', P.RDef.SpaceWithCharAndValue);
        string str41 = new string(' ', P.RDef.SpaceWithNextCommandAndValue);
        return P.RDef.Char + str40 + num.ToString("f" + P.RDef.Decimal.ToString(), (IFormatProvider) buSystem.CI) + str41;
      }
      if (Code == "I" | Code == "ı" | Code.ToLower() == P.IDef.Char.ToLower())
      {
        double num = Math.Round(Value, P.IDef.RoundCount);
        string str42 = new string(' ', P.IDef.SpaceWithCharAndValue);
        string str43 = new string(' ', P.IDef.SpaceWithNextCommandAndValue);
        return P.IDef.Char + str42 + num.ToString("f" + P.IDef.Decimal.ToString(), (IFormatProvider) buSystem.CI) + str43;
      }
      if (Code == "J" | Code == "j" | Code.ToLower() == P.JDef.Char.ToLower())
      {
        double num = Math.Round(Value, P.JDef.RoundCount);
        string str44 = new string(' ', P.JDef.SpaceWithCharAndValue);
        string str45 = new string(' ', P.JDef.SpaceWithNextCommandAndValue);
        return P.JDef.Char + str44 + num.ToString("f" + P.JDef.Decimal.ToString(), (IFormatProvider) buSystem.CI) + str45;
      }
      if (Code == "K" | Code == "k" | Code.ToLower() == P.KDef.Char.ToLower())
      {
        double num = Math.Round(Value, P.KDef.RoundCount);
        string str46 = new string(' ', P.KDef.SpaceWithCharAndValue);
        string str47 = new string(' ', P.KDef.SpaceWithNextCommandAndValue);
        return P.KDef.Char + str46 + num.ToString("f" + P.KDef.Decimal.ToString(), (IFormatProvider) buSystem.CI) + str47;
      }
      if (Code == "S" | Code == "s" | Code.ToLower() == P.SDef.Char.ToLower())
      {
        double num = Math.Round(Value * P.SDef.Multiply, P.SDef.RoundCount);
        string str48 = new string(' ', P.SDef.SpaceWithCharAndValue);
        string str49 = new string(' ', P.SDef.SpaceWithNextCommandAndValue);
        return P.SDef.Char + str48 + num.ToString("f" + P.SDef.Decimal.ToString(), (IFormatProvider) buSystem.CI) + str49;
      }
      if (!(Code == "N" | Code == "n" | Code.ToLower() == P.NDef.Char.ToLower()))
        return str1;
      double num1 = Value;
      string str50 = new string(' ', P.NDef.SpaceWithCharAndValue);
      string str51 = new string(' ', P.NDef.SpaceWithNextCommandAndValue);
      return P.NDef.Char + str50 + num1.ToString() + str51;
    }
    catch (Exception ex)
    {
      string str = $"Post: {P.ToString()} - Code: {Code.ToString()} - Value: {Value.ToString()} - MoveDistance: {MoveDistance.ToString()} - AxisDefIndex: {AxisDefIndex.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return "";
    }
  }

  public string ValueFormat(PostProcessor P, string Code, int Value)
  {
    try
    {
      string str1 = "";
      if (Code == "G" | Code == "g")
      {
        int num = Value;
        string str2 = new string(' ', P.GDef.SpaceWithCharAndValue);
        string str3 = new string(' ', P.GDef.SpaceWithNextCommandAndValue);
        str1 = P.GDef.Char + str2 + num.ToString() + str3;
      }
      if (Code == "M" | Code == "m")
      {
        int num = Value;
        string str4 = new string(' ', P.MDef.SpaceWithCharAndValue);
        string str5 = new string(' ', P.MDef.SpaceWithNextCommandAndValue);
        str1 = P.MDef.Char + str4 + num.ToString() + str5;
      }
      if (Code == "N" | Code == "n")
      {
        int num = Value;
        string str6 = new string(' ', P.NDef.SpaceWithCharAndValue);
        string str7 = new string(' ', P.NDef.SpaceWithNextCommandAndValue);
        str1 = P.NDef.Char + str6 + num.ToString() + str7;
      }
      if (Code == "T" | Code == "t")
      {
        double num = (double) Value;
        string str8 = new string(' ', P.TDef.SpaceWithCharAndValue);
        string str9 = new string(' ', P.TDef.SpaceWithNextCommandAndValue);
        str1 = P.TDef.Char + str8 + num.ToString() + str9;
      }
      return str1;
    }
    catch (Exception ex)
    {
      string str = $"Post: {P.ToString()} - Code: {Code.ToString()} - Value: {Value.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return "";
    }
  }

  public void AddCode(ref string Codes, string NewCommand, PostProcessor Post, Pnt9D Position)
  {
    try
    {
      string str = "";
      if (this.UsePointListForGCodeLines)
        this.PointListVersusGCodeLines.Add(new Pnt9D(Position));
      if (this.string_0.Length > 0 && this.string_0.Trim().ToLower() == NewCommand.Trim().ToLower())
        return;
      if (Post.NumberDef.Max > 0.0 & Post.NumberDef.Enable & this.double_0 >= Post.NumberDef.Max)
      {
        this.bool_0 = true;
      }
      else
      {
        this.GCodeEntities.Add((eEntities) new ePoint(new Pnt3D()));
        if (Post.NumberDef.Enable)
          str = this.ValueFormat(Post, "N", this.double_0, 0.0, 0, (camBase) null);
        Codes = Codes + str + NewCommand + Environment.NewLine;
        this.double_0 += Post.NumberDef.Step;
        this.string_0 = NewCommand;
      }
    }
    catch (Exception ex)
    {
      if (this.UsePointListForGCodeLines)
        this.PointListVersusGCodeLines.Add(new Pnt9D(Position));
      string str = $"Post: {Post.ToString()} - NewCommand: {NewCommand.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void AddCode(
    ref string Codes,
    string NewCommand,
    PostProcessor Post,
    eEntities GCodeEntity,
    Pnt9D Position)
  {
    try
    {
      string str = "";
      if (this.UsePointListForGCodeLines)
        this.PointListVersusGCodeLines.Add(new Pnt9D(Position));
      if (this.string_0.Length > 0 && this.string_0.Trim().ToLower() == NewCommand.Trim().ToLower())
        return;
      if (Post.NumberDef.Max > 0.0 & Post.NumberDef.Enable & this.double_0 >= Post.NumberDef.Max)
      {
        this.bool_0 = true;
      }
      else
      {
        this.GCodeEntities.Add(eEntities.CopyEntity(GCodeEntity));
        if (Post.NumberDef.Enable)
          str = this.ValueFormat(Post, "N", this.double_0, 0.0, 0, (camBase) null);
        Codes = Codes + str + NewCommand + Environment.NewLine;
        this.double_0 += Post.NumberDef.Step;
        this.string_0 = NewCommand;
      }
    }
    catch (Exception ex)
    {
      if (this.UsePointListForGCodeLines)
        this.PointListVersusGCodeLines.Add(new Pnt9D(Position));
      string str = $"Post: {Post.ToString()} - NewCommand: {NewCommand.ToString()} - GCodeEntity: {GCodeEntity.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void GCodeConverter(GCodeConverterArgs Options, string RefCode, ref string ConvertedCode)
  {
    try
    {
      string[] Lines = (string[]) null;
      ConvertedCode = "";
      buString.StringToArrayByNewLine(RefCode, ref Lines);
      double num1 = 0.0;
      double num2 = 0.0;
      int num3 = 10;
      if (Lines == null)
        return;
      for (int index = 0; index <= Lines.Length - 1; ++index)
      {
        string FullLine = Lines[index];
        bool flag = false;
        buString.ReadCharValue(FullLine, "N", ref num2);
        int num4;
        if (num2 > 0.0)
        {
          string str = FullLine;
          num4 = Convert.ToInt32(num2);
          string oldValue = "N" + num4.ToString();
          FullLine = str.Replace(oldValue, "").Trim();
        }
        if (Options.ConvertG54)
        {
          if (FullLine.IndexOf("G54") >= 0)
          {
            if (num1 <= 0.0)
              ;
            if (FullLine.IndexOf("$") == -1)
            {
              string[] strArray = new string[20];
              strArray[0] = "N";
              strArray[1] = num3.ToString();
              strArray[2] = " G53";
              strArray[3] = Environment.NewLine;
              strArray[4] = "N";
              num4 = num3 + 10;
              strArray[5] = num4.ToString();
              strArray[6] = " G75";
              strArray[7] = Environment.NewLine;
              strArray[8] = "N";
              num4 = num3 + 20;
              strArray[9] = num4.ToString();
              strArray[10] = " ";
              strArray[11] = FullLine.Replace("G54", "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
              strArray[12] = Environment.NewLine;
              strArray[13] = "N";
              num4 = num3 + 30;
              strArray[14] = num4.ToString();
              strArray[15] = " G75";
              strArray[16 /*0x10*/] = Environment.NewLine;
              strArray[17] = "N";
              num4 = num3 + 40;
              strArray[18] = num4.ToString();
              strArray[19] = " M154 K0";
              FullLine = string.Concat(strArray);
              num3 += 50;
              flag = true;
            }
          }
          if (FullLine.IndexOf("G55") >= 0)
          {
            string[] strArray = new string[20];
            strArray[0] = "N";
            strArray[1] = num3.ToString();
            strArray[2] = " G53";
            strArray[3] = Environment.NewLine;
            strArray[4] = "N";
            num4 = num3 + 10;
            strArray[5] = num4.ToString();
            strArray[6] = " G75";
            strArray[7] = Environment.NewLine;
            strArray[8] = "N";
            num4 = num3 + 20;
            strArray[9] = num4.ToString();
            strArray[10] = " ";
            strArray[11] = FullLine.Replace("G55", "G54 X$G55.X$ Y$G55.Y$ Z$G55.Z$");
            strArray[12] = Environment.NewLine;
            strArray[13] = "N";
            num4 = num3 + 30;
            strArray[14] = num4.ToString();
            strArray[15] = " G75";
            strArray[16 /*0x10*/] = Environment.NewLine;
            strArray[17] = "N";
            num4 = num3 + 40;
            strArray[18] = num4.ToString();
            strArray[19] = " M154 K1";
            FullLine = string.Concat(strArray);
            num3 += 50;
            flag = true;
          }
          if (FullLine.IndexOf("G56") >= 0)
          {
            string[] strArray = new string[20];
            strArray[0] = "N";
            strArray[1] = num3.ToString();
            strArray[2] = " G53";
            strArray[3] = Environment.NewLine;
            strArray[4] = "N";
            num4 = num3 + 10;
            strArray[5] = num4.ToString();
            strArray[6] = " G75";
            strArray[7] = Environment.NewLine;
            strArray[8] = "N";
            num4 = num3 + 20;
            strArray[9] = num4.ToString();
            strArray[10] = " ";
            strArray[11] = FullLine.Replace("G56", "G54 X$G56.X$ Y$G56.Y$ Z$G56.Z$");
            strArray[12] = Environment.NewLine;
            strArray[13] = "N";
            num4 = num3 + 30;
            strArray[14] = num4.ToString();
            strArray[15] = " G75";
            strArray[16 /*0x10*/] = Environment.NewLine;
            strArray[17] = "N";
            num4 = num3 + 40;
            strArray[18] = num4.ToString();
            strArray[19] = " M154 K2";
            FullLine = string.Concat(strArray);
            num3 += 50;
            flag = true;
          }
          if (FullLine.IndexOf("G57") >= 0)
          {
            string[] strArray = new string[20];
            strArray[0] = "N";
            strArray[1] = num3.ToString();
            strArray[2] = " G53";
            strArray[3] = Environment.NewLine;
            strArray[4] = "N";
            num4 = num3 + 10;
            strArray[5] = num4.ToString();
            strArray[6] = " G75";
            strArray[7] = Environment.NewLine;
            strArray[8] = "N";
            num4 = num3 + 20;
            strArray[9] = num4.ToString();
            strArray[10] = " ";
            strArray[11] = FullLine.Replace("G57", "G54 X$G57.X$ Y$G57.Y$ Z$G57.Z$");
            strArray[12] = Environment.NewLine;
            strArray[13] = "N";
            num4 = num3 + 30;
            strArray[14] = num4.ToString();
            strArray[15] = " G75";
            strArray[16 /*0x10*/] = Environment.NewLine;
            strArray[17] = "N";
            num4 = num3 + 40;
            strArray[18] = num4.ToString();
            strArray[19] = " M154 K3";
            FullLine = string.Concat(strArray);
            num3 += 50;
            flag = true;
          }
          if (FullLine.IndexOf("G58") >= 0)
          {
            string[] strArray = new string[20];
            strArray[0] = "N";
            strArray[1] = num3.ToString();
            strArray[2] = " G53";
            strArray[3] = Environment.NewLine;
            strArray[4] = "N";
            num4 = num3 + 10;
            strArray[5] = num4.ToString();
            strArray[6] = " G75";
            strArray[7] = Environment.NewLine;
            strArray[8] = "N";
            num4 = num3 + 20;
            strArray[9] = num4.ToString();
            strArray[10] = " ";
            strArray[11] = FullLine.Replace("G58", "G54 X$G58.X$ Y$G58.Y$ Z$G58.Z$");
            strArray[12] = Environment.NewLine;
            strArray[13] = "N";
            num4 = num3 + 30;
            strArray[14] = num4.ToString();
            strArray[15] = " G75";
            strArray[16 /*0x10*/] = Environment.NewLine;
            strArray[17] = "N";
            num4 = num3 + 40;
            strArray[18] = num4.ToString();
            strArray[19] = " M154 K4";
            FullLine = string.Concat(strArray);
            num3 += 50;
            flag = true;
          }
        }
        if (Options.ConvertM6TCode && FullLine.IndexOf("M6") >= 0 && FullLine.IndexOf("T") >= 0)
        {
          FullLine = $"N{num3.ToString()} {FullLine.Replace("T", "K")}";
          flag = true;
          num3 += 10;
        }
        if (Options.ConvertM6TCode)
        {
          if (FullLine.IndexOf("M3") >= 0 && FullLine.IndexOf("S") >= 0)
          {
            FullLine = $"N{num3.ToString()} {FullLine.Replace("S", "K")}";
            flag = true;
            num3 += 10;
          }
          if (FullLine.IndexOf("M4") >= 0 && FullLine.IndexOf("S") >= 0)
          {
            FullLine = $"N{num3.ToString()} {FullLine.Replace("S", "K")}";
            flag = true;
            num3 += 10;
          }
        }
        if (!flag)
          FullLine = $"N{num3.ToString()} {FullLine}";
        ConvertedCode = ConvertedCode + FullLine + Environment.NewLine;
        num1 = num2;
        num3 += 10;
      }
    }
    catch (Exception ex)
    {
      string str = $"Options : {Options.ToString()}- RefCode : {RefCode.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void GetPostParameter(ref string AddtionalString, Pnt9DCam CamPoint)
  {
    if (AddtionalString.IndexOf("{") < 0)
      return;
    string stringBetweenTwoChar = buString.FindStringBetweenTwoChar(AddtionalString, "{", "}");
    if (stringBetweenTwoChar.IndexOf("$") < 0)
      return;
    AddtionalString = AddtionalString.Replace("{", "");
    AddtionalString = AddtionalString.Replace("}", "");
    switch (stringBetweenTwoChar.Trim())
    {
      case "$XPos":
        AddtionalString = AddtionalString.Replace("$XPos", CamPoint.P9.X.ToString("f3"));
        break;
      case "$YPos":
        AddtionalString = AddtionalString.Replace("$YPos", CamPoint.P9.Y.ToString("f3"));
        break;
      case "$ZPos":
        AddtionalString = AddtionalString.Replace("$ZPos", CamPoint.P9.Z.ToString("f3"));
        break;
      case "$APos":
        AddtionalString = AddtionalString.Replace("$APos", CamPoint.P9.A.ToString("f3"));
        break;
      case "$BPos":
        AddtionalString = AddtionalString.Replace("$BPos", CamPoint.P9.B.ToString("f3"));
        break;
      case "$CPos":
        AddtionalString = AddtionalString.Replace("$CPos", CamPoint.P9.C.ToString("f3"));
        break;
    }
  }
}
