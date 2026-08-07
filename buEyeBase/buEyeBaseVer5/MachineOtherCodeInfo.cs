// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.MachineOtherCodeInfo
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class MachineOtherCodeInfo : buSerilization5
{
  public const buFile5.PLYToSchematic.\u0001 \u0001 = ; // Unable to render the field
  public const buFile5.PLYToSchematic.\u0001 \u0002 = ; // Unable to render the field
  public const buFile5.PLYToSchematic.\u0001 \u0003 = ; // Unable to render the field
  public const buFile5.PLYToSchematic.\u0001 \u0004 = ; // Unable to render the field

  public void CreateCamHeightPlane(
    double Height,
    planeBoxNames refPlane,
    Point3D pntMin,
    Point3D pntMax,
    Color color,
    int Transparent,
    string TextString,
    CamPlaneHeightType HeightType,
    ref Entity calcEntity,
    ref Entity textEntity)
  {
    if (refPlane == planeBoxNames.Top | refPlane == planeBoxNames.Bottom && !buConversion5.EQ(pntMax.X, pntMin.X) & !buConversion5.EQ(pntMax.Y, pntMin.Y))
    {
      CompositeCurve rectangle = CompositeCurve.CreateRectangle(Plane.XY, pntMax.X - pntMin.X, pntMax.Y - pntMin.Y);
      rectangle.Translate(pntMin.X, pntMin.Y);
      Mesh mesh = new devDept.Eyeshot.Entities.Region((ICurve) rectangle).ExtrudeAsMesh(0.01, 0.01, Mesh.natureType.RichSmooth);
      mesh.Color = Color.FromArgb(Transparent, color);
      mesh.ColorMethod = colorMethodType.byEntity;
      mesh.Translate(0.0, 0.0, Height);
      calcEntity = (Entity) mesh;
      double height = (pntMax.Y - pntMin.Y) / 20.0;
      if (height < 1.0)
        height = 1.0;
      Text text = (Text) null;
      if (HeightType == CamPlaneHeightType.Bottom)
      {
        text = new Text(Plane.XY, TextString, height, Text.alignmentType.BottomLeft);
        text.Translate(pntMin.X, pntMin.Y, Height);
      }
      if (HeightType == CamPlaneHeightType.Top)
      {
        text = new Text(Plane.XY, TextString, height, Text.alignmentType.BottomCenter);
        text.Translate((pntMin.X + pntMax.X) / 2.0, pntMin.Y, Height);
      }
      if (HeightType == CamPlaneHeightType.Retract)
      {
        text = new Text(Plane.XY, TextString, height, Text.alignmentType.BottomRight);
        text.Translate(pntMax.X, pntMin.Y, Height);
      }
      if (HeightType == CamPlaneHeightType.Clearance)
      {
        text = new Text(Plane.XY, TextString, height, Text.alignmentType.BottomCenter);
        text.Translate((pntMin.X + pntMax.X) / 2.0, pntMin.Y, Height);
      }
      text.Color = Color.FromArgb(Transparent, color);
      text.ColorMethod = colorMethodType.byEntity;
      textEntity = (Entity) text;
    }
    if (refPlane == planeBoxNames.Left | refPlane == planeBoxNames.Right)
      buNumeric5.MessageBoxInfo("Not Ready");
    if (!(refPlane == planeBoxNames.Front | refPlane == planeBoxNames.Bottom))
      return;
    buNumeric5.MessageBoxInfo("Not Ready");
  }

  public void CamStepHeightCalculation(camStep5 Step, ref List<double> Heights)
  {
    Heights.Clear();
    if (((camSpeeds5) Step).DepthStepMode == CamStepDepthMode.ConstantDepthStep)
    {
      double num1 = Step.StartValue - Step.EndValue;
      int num2 = (int) Math.Ceiling(num1 / Step.DepthStep);
      double num3 = num1 / (double) num2;
      double startValue = Step.StartValue;
      for (int index = 1; index <= num2; ++index)
      {
        startValue -= num3;
        Heights.Add(startValue);
      }
    }
    else
    {
      if (((camSpeeds5) Step).DepthStepMode != CamStepDepthMode.NumberOfSlices)
        return;
      double num = (Step.StartValue - Step.EndValue) / (double) Step.NumberOfSlice;
      double startValue = Step.StartValue;
      for (int index = 1; index <= Step.NumberOfSlice; ++index)
      {
        startValue -= num;
        Heights.Add(startValue);
      }
    }
  }

  public void CamTangentCalculation(
    ref double RefAngle,
    double PreviousAngle,
    camParameters5 camPars)
  {
    double num1 = RefAngle - PreviousAngle;
    double num2 = Math.Round(Math.Abs(num1) / 360.0, 0);
    if (Math.Abs(num1) >= 715.0)
      ;
    if (num2 <= 0.0)
      num2 = 1.0;
    if (Math.Abs(num1) > 170.0 & Math.Abs(num1) < 210.0)
    {
      if (num1 <= 0.0)
        ;
    }
    else if (Math.Abs(num1) >= 210.0)
    {
      if (num1 > 0.0)
        RefAngle -= 360.0 * num2;
      else
        RefAngle += 360.0 * num2;
    }
    if (camPars.Strategy.MinTangentValue == camPars.Strategy.MaxTangentValue)
      return;
    if (RefAngle > camPars.Strategy.MaxTangentValue)
    {
      if (camPars.Strategy.MaxTangentValue - camPars.Strategy.MinTangentValue >= 360.0)
        RefAngle -= 360.0;
      else
        RefAngle -= camPars.Strategy.MaxTangentValue - camPars.Strategy.MinTangentValue;
    }
    if (RefAngle >= camPars.Strategy.MinTangentValue)
      return;
    if (camPars.Strategy.MaxTangentValue - camPars.Strategy.MinTangentValue >= 360.0)
      RefAngle += 360.0;
    else
      RefAngle += camPars.Strategy.MaxTangentValue - camPars.Strategy.MinTangentValue;
  }

  public void CamAddtoOtherCam(camTp AddingCam, ref camTp AddedCam)
  {
    if (AddingCam.CamPoints.Count > 0)
    {
      for (int index = 0; index <= AddingCam.CamPoints.Count - 1; ++index)
      {
        camTpPoint camTpPoint = (camTpPoint) new TpPnt9D(AddingCam.CamPoints[index]);
        AddedCam.CamPoints.Add(camTpPoint);
      }
    }
    List<Entity> CopiedEntity = new List<Entity>();
    ((MachineGCodeExecutionResult) this).CopyCamEntities(AddingCam.EntitiesG1, ref CopiedEntity);
    CopiedEntity = new List<Entity>();
    ((MachineGCodeExecutionResult) this).CopyCamEntities(AddingCam.EntitiesG0, ref AddedCam.EntitiesG0);
    CopiedEntity = new List<Entity>();
    ((MachineGCodeExecutionResult) this).CopyCamEntities(AddingCam.EntitiesLeadIn, ref AddedCam.EntitiesLeadIn);
    ((MachineGCodeExecutionResult) this).CopyCamEntities(AddingCam.EntitiesLeadOut, ref AddedCam.EntitiesLeadOut);
    ((MachineGCodeExecutionResult) this).CopyCamEntities(AddingCam.EntitiesLeave, ref AddedCam.EntitiesLeave);
    ((MachineGCodeExecutionResult) this).CopyCamEntities(AddingCam.EntitiesMark, ref AddedCam.EntitiesMark);
    ((MachineGCodeExecutionResult) this).CopyCamEntities(AddingCam.EntitiesOther, ref AddedCam.EntitiesOther);
    ((MachineGCodeExecutionResult) this).CopyCamEntities(AddingCam.EntitiesPlunge, ref AddedCam.EntitiesPlunge);
    ((MachineGCodeExecutionResult) this).CopyCamEntities(AddingCam.EntitiesG1, ref AddedCam.EntitiesG1);
    if (((camParameters5) AddingCam.SimilationPoint).SimMove.Count <= 0)
      return;
    ContourPoints5.Add(((camParameters5) AddingCam.SimilationPoint).SimMove, ref ((camParameters5) AddedCam.SimilationPoint).SimMove);
  }
}
