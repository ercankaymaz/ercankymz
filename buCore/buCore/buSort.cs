// Decompiled with JetBrains decompiler
// Type: buCore.buSort
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using buClass;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buCore;

public class buSort
{
  public SortingAskMe AskMe = new SortingAskMe();
  private List<eEntities> list_0 = new List<eEntities>();

  public event CalculationEventHandler CalculationInProgress;

  public event CalculationEventHandler CalculationStarted;

  public event CalculationEventHandler CalculationEnded;

  public event CalculationEventHandler CalculationCanceled;

  public event CalculationErrorEventHandler CalculationError;

  public buSort()
  {
    if (!buVector.smethod_0(nameof (buSort)))
      throw new RegisterException(nameof (buSort));
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

  public void PrepareEntites(
    SortingFilter Filters,
    SortingOptions Options,
    List<eEntities> RefEntities,
    ref List<eEntities> CalculatedEntities)
  {
    try
    {
      if (RefEntities == null)
        return;
      CalculatedEntities = new List<eEntities>();
      for (int index1 = 0; index1 <= RefEntities.Count - 1; ++index1)
      {
        bool flag1 = false;
        bool flag2 = true;
        if (Filters != null)
        {
          if (Filters.SelectableEntities != null && Filters.SelectableEntities.Count > 0)
          {
            flag2 = false;
            for (int index2 = 0; index2 <= Filters.SelectableEntities.Count - 1; ++index2)
            {
              if (Filters.SelectableEntities[index2].GetType() == RefEntities[index1].GetType())
              {
                flag2 = true;
                index2 = Filters.SelectableEntities.Count;
              }
            }
          }
          if (Filters.SelectableIndex != null && Filters.SelectableIndex.Count > 0)
          {
            flag2 = false;
            for (int index3 = 0; index3 <= Filters.SelectableIndex.Count - 1; ++index3)
            {
              if (Filters.SelectableIndex[index3] == RefEntities[index1].EntityIndex)
              {
                flag2 = true;
                index3 = Filters.SelectableIndex.Count;
              }
            }
          }
          if (Filters.SelectableColor != null && Filters.SelectableColor.Count > 0)
          {
            flag2 = false;
            for (int index4 = 0; index4 <= Filters.SelectableColor.Count - 1; ++index4)
            {
              if (RefEntities[index1].dispColor == Filters.SelectableColor[index4])
              {
                flag2 = true;
                index4 = Filters.SelectableColor.Count;
              }
            }
          }
        }
        if (RefEntities[index1].GetType() == typeof (eCircle) & RefEntities[index1].bSelectable & flag2)
        {
          List<eEntities> DevidedEntities = new List<eEntities>();
          buAppCalc.cVector.CircleDevide(RefEntities[index1], new DevideData(1.0, DevideType.QuadraticArc), ((ePlaneEntities) RefEntities[index1]).Plane, ref DevidedEntities);
          for (int index5 = 0; index5 <= DevidedEntities.Count - 1; ++index5)
            CalculatedEntities.Add(DevidedEntities[index5]);
          flag1 = true;
        }
        if (RefEntities[index1].GetType() == typeof (eBSpline) & RefEntities[index1].bSelectable & flag2)
        {
          eBSpline eBspline = new eBSpline(eEntities.CopyEntity(RefEntities[index1]));
          CalculatedEntities.Add((eEntities) eBspline);
          flag1 = true;
        }
        if (RefEntities[index1].GetType() == typeof (eBezeir) & RefEntities[index1].bSelectable & flag2)
        {
          eBezeir eBezeir = new eBezeir(eEntities.CopyEntity(RefEntities[index1]));
          CalculatedEntities.Add((eEntities) eBezeir);
          flag1 = true;
        }
        if (RefEntities[index1].GetType() == typeof (eArc) & RefEntities[index1].bSelectable & flag2)
        {
          eArc eArc = new eArc(eEntities.CopyEntity(RefEntities[index1]));
          CalculatedEntities.Add((eEntities) eArc);
          flag1 = true;
        }
        if (RefEntities[index1].GetType() == typeof (eEllipse) & RefEntities[index1].bSelectable & flag2)
        {
          eEllipse eEllipse = new eEllipse(eEntities.CopyEntity(RefEntities[index1]));
          CalculatedEntities.Add((eEntities) eEllipse);
          flag1 = true;
        }
        if (RefEntities[index1].GetType() == typeof (eEllipseArc) & RefEntities[index1].bSelectable & flag2)
        {
          eEllipseArc eEllipseArc = new eEllipseArc(eEntities.CopyEntity(RefEntities[index1]));
          CalculatedEntities.Add((eEntities) eEllipseArc);
          flag1 = true;
        }
        if (RefEntities[index1].GetType() == typeof (eLine) & RefEntities[index1].bSelectable & flag2)
        {
          eLine eLine = new eLine(eEntities.CopyEntity(RefEntities[index1]));
          CalculatedEntities.Add((eEntities) eLine);
          flag1 = true;
        }
        if (RefEntities[index1].GetType() == typeof (ePolyline) & RefEntities[index1].bSelectable & flag2)
        {
          ePolyline ePolyline = new ePolyline(eEntities.CopyEntity(RefEntities[index1]));
          CalculatedEntities.Add((eEntities) ePolyline);
          flag1 = true;
        }
        if (!flag1 & flag2 & RefEntities[index1].bSelectable)
          CalculatedEntities.Add(eEntities.CopyEntity(RefEntities[index1]));
      }
    }
    catch (Exception ex)
    {
      string str = $"Filters: {Filters.ToString()} - Options: {Options.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void SortEntitiesByRefPoint(
    Pnt3D RefPoint,
    ref List<eEntities> BaseRefEntities,
    SortingOptions Options,
    ref List<eEntities> SortedEntities)
  {
    SortingResult Result = new SortingResult();
    this.SortEntitiesByRefPoint(RefPoint, ref BaseRefEntities, new WorkPlane(), new SortingFilter(), Options, new SortingCamData(), ref SortedEntities, ref Result);
  }

  public void SortEntitiesByRefPoint(
    Pnt3D RefPoint,
    ref List<eEntities> BaseRefEntities,
    WorkPlane Plane,
    SortingFilter Filter,
    SortingOptions Options,
    SortingCamData CamData,
    ref List<eEntities> SortedEntities,
    ref SortingResult Result)
  {
    List<eEntities> ExtraRefLines = new List<eEntities>();
    this.SortEntitiesByRefPoint(RefPoint, ref BaseRefEntities, ExtraRefLines, Plane, Filter, Options, CamData, ref SortedEntities, ref Result);
  }

  public void SortEntitiesByRefPoint(
    Pnt3D RefPoint,
    ref List<eEntities> BaseRefEntities,
    List<eEntities> ExtraRefLines,
    WorkPlane Plane,
    SortingFilter Filter,
    SortingOptions Options,
    SortingCamData CamData,
    ref List<eEntities> SortedEntities,
    ref SortingResult Result)
  {
    try
    {
      List<SortingFoundItems> Founds = new List<SortingFoundItems>();
      bool flag1 = false;
      int num1 = 0;
      Pnt3D Pnt1 = new Pnt3D(RefPoint);
      Result.LastCalculatedEntities.Clear();
      Result.LastSelectedEntitiesIndex.Clear();
label_231:
      ++num1;
      Pnt3D Pnt2 = new Pnt3D(RefPoint);
      int Sequence = 0;
      RefPoint = !Options.UsePlane ? new Pnt3D(buAppCalc.cVector.MostClosestPoint(RefPoint, MostClosestPointType.OnlyNotCamSelectedEntities, new WorkPlane(), BaseRefEntities, ref Sequence)) : (Plane == null ? new Pnt3D(buAppCalc.cVector.MostClosestPoint(RefPoint, MostClosestPointType.OnlyNotCamSelectedEntities, new WorkPlane(), BaseRefEntities, ref Sequence)) : new Pnt3D(buAppCalc.cVector.MostClosestPoint(RefPoint, MostClosestPointType.OnlyNotCamSelectedEntities, Plane, BaseRefEntities, ref Sequence)));
      if (!this.AskMe.Return)
      {
        this.list_0.Clear();
        if (Sequence > 0)
        {
          Pnt3D pnt3D1 = new Pnt3D(BaseRefEntities[Sequence].Vertice[0]);
          Pnt3D pnt3D2 = new Pnt3D(BaseRefEntities[Sequence].Vertice[BaseRefEntities[Sequence].Vertice.Count - 1]);
          if (buCompare.EQ(RefPoint, pnt3D1, Options.Resolution))
          {
            for (int index = Sequence; index <= BaseRefEntities.Count - 1; ++index)
              this.list_0.Add(eEntities.CopyEntity(BaseRefEntities[index]));
            for (int index = 0; index <= Sequence - 1; ++index)
              this.list_0.Add(eEntities.CopyEntity(BaseRefEntities[index]));
          }
          else if (buCompare.EQ(RefPoint, pnt3D2, Options.Resolution))
          {
            for (int index = Sequence; index >= 0; --index)
              this.list_0.Add(eEntities.CopyEntity(BaseRefEntities[index]));
            for (int index = BaseRefEntities.Count - 1; index >= Sequence + 1; --index)
              this.list_0.Add(eEntities.CopyEntity(BaseRefEntities[index]));
          }
          else
            eEntities.CopyEntities(BaseRefEntities, ref this.list_0);
        }
        else
          eEntities.CopyEntities(BaseRefEntities, ref this.list_0);
      }
      int int32 = Convert.ToInt32((double) BaseRefEntities.Count / 100.0);
      int num2 = 0;
      bool flag2 = false;
      ClockDirectionType clockDirectionType1 = ClockDirectionType.CW;
      if (this.AskMe.Return && this.AskMe.SelectedIndex >= 0 & this.AskMe.SelectedIndex <= this.AskMe.Entities.Count - 1)
      {
        SortingFoundItems sortingFoundItems = new SortingFoundItems();
        sortingFoundItems.RefPoint = new Pnt3D(this.AskMe.RefPoint);
        sortingFoundItems.Index = this.AskMe.EntitiesIndex[this.AskMe.SelectedIndex];
        sortingFoundItems.Direction = camPathDirectionType.Normal;
        sortingFoundItems.Entity = eEntities.CopyEntity(this.AskMe.Entities[this.AskMe.SelectedIndex]);
        buAppCalc.cVector.CamDirectionSet(sortingFoundItems.RefPoint, ref sortingFoundItems.Entity);
        buAppCalc.cVector.GetOtherPointOfEntity(this.AskMe.RefPoint, sortingFoundItems.Entity, ref sortingFoundItems.RefPoint);
        Founds.Add(sortingFoundItems);
      }
      if (this.AskMe.ReturnNextGroup)
      {
        eUpperLine eUpperLine = new eUpperLine(this.AskMe.RefPoint, RefPoint);
        SortedEntities.Add((eEntities) eUpperLine);
        SortedEntities[SortedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
        this.AskMe.ReturnNextGroup = false;
      }
      for (int index1 = 0; index1 <= BaseRefEntities.Count - 1; ++index1)
      {
        if (!this.AskMe.Return)
        {
label_41:
          Founds.Clear();
          if (ExtraRefLines.Count > 0)
          {
            int ConnectionCount = 0;
            List<int> ConnectionIndex = new List<int>();
            this.HowManyConnectionAtRefPoint(ExtraRefLines, RefPoint, Options.Resolution, ref ConnectionCount, ref ConnectionIndex);
            for (int index2 = 0; index2 <= ConnectionIndex.Count - 1; ++index2)
            {
              int index3 = ConnectionIndex[index2];
              if (ExtraRefLines[index3].Vertice.Count > 0)
              {
                Pnt3D pnt3D = new Pnt3D(ExtraRefLines[index3].Vertice[0]);
                bool flag3 = false;
                if (!(buCompare.EQ(pnt3D, RefPoint, Options.Resolution) & !ExtraRefLines[index3].bCamSelected))
                {
                  if (!flag3 && buCompare.EQ(new Pnt3D(ExtraRefLines[index3].Vertice[ExtraRefLines[index3].Vertice.Count - 1]), RefPoint, Options.Resolution) & !ExtraRefLines[index3].bCamSelected)
                  {
                    if (SortedEntities[0].camDirections == camPathDirectionType.Reverse)
                      Options.IntersectionRules = SortingIntersectionRulesType.HigherIndex;
                    SortedEntities.Add(eEntities.CopyEntity(ExtraRefLines[index3]));
                    SortedEntities[SortedEntities.Count - 1].camDirections = camPathDirectionType.Reverse;
                    RefPoint = new Pnt3D(ExtraRefLines[index3].Vertice[0]);
                    ExtraRefLines.RemoveAt(index3);
                    flag2 = true;
                    List<Pnt3D> Points = new List<Pnt3D>();
                    buAppCalc.cVector.EntityToPoint(SortedEntities, new EntityResolution(), ref Points);
                    if (!buAppCalc.cVector.IsClosed(Points))
                      Points.Add(new Pnt3D(Points[0]));
                    clockDirectionType1 = buAppCalc.cVector.PolygonDirection(Points, Plane);
                    goto label_41;
                  }
                }
                else
                {
                  if (SortedEntities[0].camDirections == camPathDirectionType.Reverse)
                    Options.IntersectionRules = SortingIntersectionRulesType.HigherIndex;
                  SortedEntities.Add(eEntities.CopyEntity(ExtraRefLines[index3]));
                  RefPoint = new Pnt3D(ExtraRefLines[index3].Vertice[ExtraRefLines[index3].Vertice.Count - 1]);
                  ExtraRefLines.RemoveAt(index3);
                  flag2 = true;
                  List<Pnt3D> Points = new List<Pnt3D>();
                  buAppCalc.cVector.EntityToPoint(SortedEntities, new EntityResolution(), ref Points);
                  if (!buAppCalc.cVector.IsClosed(Points))
                    Points.Add(new Pnt3D(Points[0]));
                  clockDirectionType1 = buAppCalc.cVector.PolygonDirection(Points, Plane);
                  goto label_41;
                }
              }
            }
          }
          if (Founds.Count == 0)
          {
            for (int index4 = 0; index4 <= this.list_0.Count - 1; ++index4)
            {
              if (this.list_0[index4].Vertice.Count > 0)
              {
                bool flag4 = false;
                if (!Filter.UsePointEntities & this.list_0[index4].GetType() == typeof (ePoint))
                  flag4 = true;
                if (!flag4)
                {
                  Pnt3D PntCenter1 = new Pnt3D(this.list_0[index4].Vertice[0]);
                  Pnt3D PntEnd = new Pnt3D();
                  if (this.list_0[index4].Vertice.Count >= 2)
                    PntEnd = new Pnt3D(this.list_0[index4].Vertice[1]);
                  bool flag5 = false;
                  SortingFoundItems sortingFoundItems = new SortingFoundItems();
                  if (buCompare.EQ(PntCenter1, RefPoint, Options.Resolution) & !this.list_0[index4].bCamSelected)
                  {
                    sortingFoundItems.RefPoint = new Pnt3D(this.list_0[index4].Vertice[this.list_0[index4].Vertice.Count - 1]);
                    sortingFoundItems.Direction = camPathDirectionType.Normal;
                    sortingFoundItems.Entity = eEntities.CopyEntity(this.list_0[index4]);
                    sortingFoundItems.Entity.camDirections = camPathDirectionType.Normal;
                    sortingFoundItems.Index = index4;
                    if (Options.AngleLimitation)
                    {
                      double num3 = buAppCalc.cVector.PointAngle(PntEnd, PntCenter1);
                      if (num3 > Options.AngleMaxLimit | num3 < Options.AngleMinLimit)
                      {
                        sortingFoundItems.RefPoint = new Pnt3D(this.list_0[index4].Vertice[0]);
                        sortingFoundItems.Direction = camPathDirectionType.Reverse;
                        sortingFoundItems.Entity.camDirections = camPathDirectionType.Reverse;
                      }
                    }
                    Founds.Add(sortingFoundItems);
                    flag5 = true;
                  }
                  Pnt3D PntCenter2 = new Pnt3D(this.list_0[index4].Vertice[this.list_0[index4].Vertice.Count - 1]);
                  if (this.list_0[index4].Vertice.Count >= 2)
                    PntEnd = new Pnt3D(this.list_0[index4].Vertice[this.list_0[index4].Vertice.Count - 2]);
                  if (buCompare.EQ(PntCenter2, RefPoint, Options.Resolution) & !this.list_0[index4].bCamSelected & !flag5)
                  {
                    sortingFoundItems.RefPoint = new Pnt3D(this.list_0[index4].Vertice[0]);
                    sortingFoundItems.Direction = camPathDirectionType.Reverse;
                    sortingFoundItems.Entity = eEntities.CopyEntity(this.list_0[index4]);
                    sortingFoundItems.Entity.camDirections = camPathDirectionType.Reverse;
                    sortingFoundItems.Index = index4;
                    if (Options.AngleLimitation)
                    {
                      double num4 = buAppCalc.cVector.PointAngle(PntEnd, PntCenter2);
                      if (num4 > Options.AngleMaxLimit | num4 < Options.AngleMinLimit)
                      {
                        sortingFoundItems.RefPoint = new Pnt3D(this.list_0[index4].Vertice[this.list_0[index4].Vertice.Count - 1]);
                        sortingFoundItems.Direction = camPathDirectionType.Normal;
                        sortingFoundItems.Entity.camDirections = camPathDirectionType.Normal;
                      }
                    }
                    Founds.Add(sortingFoundItems);
                  }
                }
              }
              if (Founds.Count >= 1 & !flag2 & (Options.IntersectionRules == SortingIntersectionRulesType.LowerIndex | Options.IntersectionRules == SortingIntersectionRulesType.FromDrawing))
                index4 = this.list_0.Count;
            }
          }
        }
        if (Founds.Count == 0)
        {
          if (num1 > 2)
            return;
          if (Options.IntersectionRules != SortingIntersectionRulesType.With2Point)
          {
            if (SortedEntities.Count > 0)
            {
              int num5 = 0;
              for (int index5 = 0; index5 <= SortedEntities.Count - 1; ++index5)
              {
                if (SortedEntities[index5].GetType() != typeof (eUpperLine))
                  ++num5;
              }
              if (num5 < BaseRefEntities.Count)
              {
                if (!(SortedEntities[SortedEntities.Count - 1].GetType() == typeof (eUpperLine)))
                {
                  RefPoint = SortedEntities[SortedEntities.Count - 1].camDirections != camPathDirectionType.Normal ? new Pnt3D(SortedEntities[SortedEntities.Count - 1].Vertice[0]) : new Pnt3D(SortedEntities[SortedEntities.Count - 1].Vertice[SortedEntities[SortedEntities.Count - 1].Vertice.Count - 1]);
                }
                else
                {
                  SortedEntities.RemoveAt(SortedEntities.Count - 1);
                  Result.SelectedEntitiesIndex.Add(-1);
                  return;
                }
              }
              else
              {
                Result.FirstPoint = new Pnt3D(Pnt2);
                Result.LastPoint = new Pnt3D(RefPoint);
                Result.ResultType = SortingResultType.Done;
                return;
              }
            }
            if (index1 <= BaseRefEntities.Count - 1)
            {
              if (Options.NextGroupRules == SortingNextGroupFindRulesType.MinYMinX | Options.NextGroupRules == SortingNextGroupFindRulesType.MinYMaxX)
              {
                Pnt3D pnt3D = new Pnt3D();
                List<Pnt3D> SortingPoints = new List<Pnt3D>();
                List<Pnt3D> pnt3DList = new List<Pnt3D>();
                double num6 = double.MaxValue;
                int num7 = -1;
                for (int index6 = 0; index6 <= this.list_0.Count - 1; ++index6)
                {
                  double y1 = this.list_0[index6].Vertice[0].Y;
                  if (y1 < num6 & this.list_0[index6].bSelectable & !this.list_0[index6].bSelected & !this.list_0[index6].bCamSelected)
                  {
                    num6 = y1;
                    pnt3D = new Pnt3D(this.list_0[index6].Vertice[0]);
                    num7 = index6;
                  }
                  double y2 = this.list_0[index6].Vertice[this.list_0[index6].Vertice.Count - 1].Y;
                  if (y2 < num6 & this.list_0[index6].bSelectable & !this.list_0[index6].bSelected & !this.list_0[index6].bCamSelected)
                  {
                    num6 = y2;
                    pnt3D = new Pnt3D(this.list_0[index6].Vertice[this.list_0[index6].Vertice.Count - 1]);
                    num7 = index6;
                  }
                }
                SortingPoints.Add(new Pnt3D(pnt3D));
                for (int index7 = 0; index7 <= this.list_0.Count - 1; ++index7)
                {
                  double y3 = this.list_0[index7].Vertice[0].Y;
                  if ((y3 < num6 | buCompare.EQ(y3, num6, 0.01)) & index7 != num7 & this.list_0[index7].bSelectable & !this.list_0[index7].bSelected & !this.list_0[index7].bCamSelected)
                  {
                    pnt3D = new Pnt3D(this.list_0[index7].Vertice[0]);
                    SortingPoints.Add(pnt3D);
                    num7 = index7;
                  }
                  double y4 = this.list_0[index7].Vertice[this.list_0[index7].Vertice.Count - 1].Y;
                  if ((y4 < num6 | buCompare.EQ(y4, num6, 0.01)) & index7 != num7 & this.list_0[index7].bSelectable & !this.list_0[index7].bSelected & !this.list_0[index7].bCamSelected)
                  {
                    pnt3D = new Pnt3D(this.list_0[index7].Vertice[this.list_0[index7].Vertice.Count - 1]);
                    SortingPoints.Add(pnt3D);
                    num7 = index7;
                  }
                }
                if (SortingPoints.Count > 1)
                {
                  double MinX = 0.0;
                  double MinY = 0.0;
                  double MinZ = 0.0;
                  buNumeric.GetMinXYZFromPointList(SortingPoints, ref MinX, ref MinY, ref MinZ);
                  buAppCalc.cVector.SortDeltaX(new Pnt3D(MinX, 0.0), SortDirectionType.Lower, ref SortingPoints);
                  if (Options.NextGroupRules == SortingNextGroupFindRulesType.MinYMaxX)
                    SortingPoints.Reverse();
                  pnt3D = new Pnt3D(SortingPoints[0]);
                }
                eUpperLine eUpperLine = new eUpperLine(RefPoint, pnt3D);
                SortedEntities.Add((eEntities) eUpperLine);
                SortedEntities[SortedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
                RefPoint = new Pnt3D(pnt3D);
                --index1;
              }
              if (Options.NextGroupRules == SortingNextGroupFindRulesType.MaxYMinX | Options.NextGroupRules == SortingNextGroupFindRulesType.MaxYMaxX)
              {
                Pnt3D pnt3D = new Pnt3D();
                List<Pnt3D> SortingPoints = new List<Pnt3D>();
                double num8 = double.MinValue;
                int num9 = -1;
                for (int index8 = 0; index8 <= this.list_0.Count - 1; ++index8)
                {
                  double y5 = this.list_0[index8].Vertice[0].Y;
                  if (y5 > num8 & this.list_0[index8].bSelectable & !this.list_0[index8].bSelected & !this.list_0[index8].bCamSelected)
                  {
                    num8 = y5;
                    pnt3D = new Pnt3D(this.list_0[index8].Vertice[0]);
                    num9 = index8;
                  }
                  double y6 = this.list_0[index8].Vertice[this.list_0[index8].Vertice.Count - 1].Y;
                  if (y6 > num8 & this.list_0[index8].bSelectable & !this.list_0[index8].bSelected & !this.list_0[index8].bCamSelected)
                  {
                    num8 = y6;
                    pnt3D = new Pnt3D(this.list_0[index8].Vertice[this.list_0[index8].Vertice.Count - 1]);
                    num9 = index8;
                  }
                }
                SortingPoints.Add(new Pnt3D(pnt3D));
                for (int index9 = 0; index9 <= this.list_0.Count - 1; ++index9)
                {
                  double y7 = this.list_0[index9].Vertice[0].Y;
                  if ((y7 > num8 | buCompare.EQ(y7, num8, 0.01)) & index9 != num9 & this.list_0[index9].bSelectable & !this.list_0[index9].bSelected & !this.list_0[index9].bCamSelected)
                  {
                    pnt3D = new Pnt3D(this.list_0[index9].Vertice[0]);
                    SortingPoints.Add(pnt3D);
                    num9 = index9;
                  }
                  double y8 = this.list_0[index9].Vertice[this.list_0[index9].Vertice.Count - 1].Y;
                  if ((y8 > num8 | buCompare.EQ(y8, num8, 0.01)) & index9 != num9 & this.list_0[index9].bSelectable & !this.list_0[index9].bSelected & !this.list_0[index9].bCamSelected)
                  {
                    pnt3D = new Pnt3D(this.list_0[index9].Vertice[this.list_0[index9].Vertice.Count - 1]);
                    SortingPoints.Add(pnt3D);
                    num9 = index9;
                  }
                }
                if (SortingPoints.Count > 1)
                {
                  double MinX = 0.0;
                  double MinY = 0.0;
                  double MinZ = 0.0;
                  buNumeric.GetMinXYZFromPointList(SortingPoints, ref MinX, ref MinY, ref MinZ);
                  buAppCalc.cVector.SortDeltaX(new Pnt3D(MinX, 0.0), SortDirectionType.Lower, ref SortingPoints);
                  if (Options.NextGroupRules == SortingNextGroupFindRulesType.MaxYMaxX)
                    SortingPoints.Reverse();
                  pnt3D = new Pnt3D(SortingPoints[0]);
                }
                eUpperLine eUpperLine = new eUpperLine(RefPoint, pnt3D);
                SortedEntities.Add((eEntities) eUpperLine);
                SortedEntities[SortedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
                RefPoint = new Pnt3D(pnt3D);
                --index1;
              }
              if (Options.NextGroupRules == SortingNextGroupFindRulesType.MinXMinY | Options.NextGroupRules == SortingNextGroupFindRulesType.MinXMaxY)
              {
                Pnt3D pnt3D = new Pnt3D();
                List<Pnt3D> SortingPoints = new List<Pnt3D>();
                double num10 = double.MaxValue;
                int num11 = -1;
                for (int index10 = 0; index10 <= this.list_0.Count - 1; ++index10)
                {
                  double x1 = this.list_0[index10].Vertice[0].X;
                  if (x1 < num10 & this.list_0[index10].bSelectable & !this.list_0[index10].bSelected & !this.list_0[index10].bCamSelected)
                  {
                    num10 = x1;
                    pnt3D = new Pnt3D(this.list_0[index10].Vertice[0]);
                    num11 = index10;
                  }
                  double x2 = this.list_0[index10].Vertice[this.list_0[index10].Vertice.Count - 1].X;
                  if (x2 < num10 & this.list_0[index10].bSelectable & !this.list_0[index10].bSelected & !this.list_0[index10].bCamSelected)
                  {
                    num10 = x2;
                    pnt3D = new Pnt3D(this.list_0[index10].Vertice[this.list_0[index10].Vertice.Count - 1]);
                    num11 = index10;
                  }
                }
                SortingPoints.Add(new Pnt3D(pnt3D));
                for (int index11 = 0; index11 <= this.list_0.Count - 1; ++index11)
                {
                  double x3 = this.list_0[index11].Vertice[0].X;
                  if ((x3 < num10 | buCompare.EQ(x3, num10, 0.01)) & index11 != num11 & this.list_0[index11].bSelectable & !this.list_0[index11].bSelected & !this.list_0[index11].bCamSelected)
                  {
                    pnt3D = new Pnt3D(this.list_0[index11].Vertice[0]);
                    SortingPoints.Add(pnt3D);
                    num11 = index11;
                  }
                  double x4 = this.list_0[index11].Vertice[this.list_0[index11].Vertice.Count - 1].X;
                  if ((x4 < num10 | buCompare.EQ(x4, num10, 0.01)) & index11 != num11 & this.list_0[index11].bSelectable & !this.list_0[index11].bSelected & !this.list_0[index11].bCamSelected)
                  {
                    pnt3D = new Pnt3D(this.list_0[index11].Vertice[this.list_0[index11].Vertice.Count - 1]);
                    SortingPoints.Add(pnt3D);
                    num11 = index11;
                  }
                }
                if (SortingPoints.Count > 1)
                {
                  double MinX = 0.0;
                  double MinY = 0.0;
                  double MinZ = 0.0;
                  buNumeric.GetMinXYZFromPointList(SortingPoints, ref MinX, ref MinY, ref MinZ);
                  buAppCalc.cVector.SortDeltaY(new Pnt3D(0.0, MinY), SortDirectionType.Lower, ref SortingPoints);
                  if (Options.NextGroupRules == SortingNextGroupFindRulesType.MinXMaxY)
                    SortingPoints.Reverse();
                  pnt3D = new Pnt3D(SortingPoints[0]);
                }
                eUpperLine eUpperLine = new eUpperLine(RefPoint, pnt3D);
                SortedEntities.Add((eEntities) eUpperLine);
                SortedEntities[SortedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
                RefPoint = new Pnt3D(pnt3D);
                --index1;
              }
              if (Options.NextGroupRules == SortingNextGroupFindRulesType.MaxXMinY | Options.NextGroupRules == SortingNextGroupFindRulesType.MaxXMaxY)
              {
                Pnt3D pnt3D = new Pnt3D();
                List<Pnt3D> SortingPoints = new List<Pnt3D>();
                double num12 = double.MinValue;
                int num13 = -1;
                for (int index12 = 0; index12 <= this.list_0.Count - 1; ++index12)
                {
                  double x5 = this.list_0[index12].Vertice[0].X;
                  if (x5 > num12 & this.list_0[index12].bSelectable & !this.list_0[index12].bSelected & !this.list_0[index12].bCamSelected)
                  {
                    num12 = x5;
                    pnt3D = new Pnt3D(this.list_0[index12].Vertice[0]);
                    num13 = index12;
                  }
                  double x6 = this.list_0[index12].Vertice[this.list_0[index12].Vertice.Count - 1].X;
                  if (x6 > num12 & this.list_0[index12].bSelectable & !this.list_0[index12].bSelected & !this.list_0[index12].bCamSelected)
                  {
                    num12 = x6;
                    pnt3D = new Pnt3D(this.list_0[index12].Vertice[this.list_0[index12].Vertice.Count - 1]);
                    num13 = index12;
                  }
                }
                SortingPoints.Add(new Pnt3D(pnt3D));
                for (int index13 = 0; index13 <= this.list_0.Count - 1; ++index13)
                {
                  double x7 = this.list_0[index13].Vertice[0].X;
                  if ((x7 > num12 | buCompare.EQ(x7, num12, 0.01)) & index13 != num13 & this.list_0[index13].bSelectable & !this.list_0[index13].bSelected & !this.list_0[index13].bCamSelected)
                  {
                    pnt3D = new Pnt3D(this.list_0[index13].Vertice[0]);
                    SortingPoints.Add(pnt3D);
                    num13 = index13;
                  }
                  double x8 = this.list_0[index13].Vertice[this.list_0[index13].Vertice.Count - 1].X;
                  if ((x8 > num12 | buCompare.EQ(x8, num12, 0.01)) & index13 != num13 & this.list_0[index13].bSelectable & !this.list_0[index13].bSelected & !this.list_0[index13].bCamSelected)
                  {
                    pnt3D = new Pnt3D(this.list_0[index13].Vertice[this.list_0[index13].Vertice.Count - 1]);
                    SortingPoints.Add(pnt3D);
                    num13 = index13;
                  }
                }
                if (SortingPoints.Count > 1)
                {
                  double MinX = 0.0;
                  double MinY = 0.0;
                  double MinZ = 0.0;
                  buNumeric.GetMinXYZFromPointList(SortingPoints, ref MinX, ref MinY, ref MinZ);
                  buAppCalc.cVector.SortDeltaY(new Pnt3D(0.0, MinY), SortDirectionType.Lower, ref SortingPoints);
                  if (Options.NextGroupRules == SortingNextGroupFindRulesType.MaxXMaxY)
                    SortingPoints.Reverse();
                  pnt3D = new Pnt3D(SortingPoints[0]);
                }
                eUpperLine eUpperLine = new eUpperLine(RefPoint, pnt3D);
                SortedEntities.Add((eEntities) eUpperLine);
                SortedEntities[SortedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
                RefPoint = new Pnt3D(pnt3D);
                --index1;
              }
              if (Options.NextGroupRules == SortingNextGroupFindRulesType.ClosestLength)
              {
                Pnt3D pnt3D3 = new Pnt3D();
                Pnt3D StartPoint = new Pnt3D(RefPoint);
                if (Options.AlwaysUseZeroPointAfterJump)
                  RefPoint = new Pnt3D();
                Pnt3D pnt3D4 = !Options.UsePlane ? buAppCalc.cVector.MostClosestPoint(RefPoint, Filter.MostClosestType, new WorkPlane(), this.list_0) : (Plane == null ? buAppCalc.cVector.MostClosestPoint(RefPoint, Filter.MostClosestType, new WorkPlane(), this.list_0) : buAppCalc.cVector.MostClosestPoint(RefPoint, Filter.MostClosestType, Plane, this.list_0));
                eUpperLine eUpperLine = new eUpperLine(StartPoint, pnt3D4);
                SortedEntities.Add((eEntities) eUpperLine);
                SortedEntities[SortedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
                RefPoint = new Pnt3D(pnt3D4);
                --index1;
              }
              if (Options.NextGroupRules == SortingNextGroupFindRulesType.DrawingSequence)
              {
                Pnt3D pnt3D = new Pnt3D();
                int FoundIndex = -1;
                buAppCalc.cVector.FindLowerAvailableIndexOfEntities(BaseRefEntities, ref FoundIndex);
                if (FoundIndex >= 0)
                  pnt3D = buAppCalc.cVector.Length3D(RefPoint, BaseRefEntities[FoundIndex].Vertice[0]) >= buAppCalc.cVector.Length3D(RefPoint, BaseRefEntities[FoundIndex].Vertice[BaseRefEntities[FoundIndex].Vertice.Count - 1]) ? new Pnt3D(BaseRefEntities[FoundIndex].Vertice[BaseRefEntities[FoundIndex].Vertice.Count - 1]) : new Pnt3D(BaseRefEntities[FoundIndex].Vertice[0]);
                eUpperLine eUpperLine = new eUpperLine(RefPoint, pnt3D);
                SortedEntities.Add((eEntities) eUpperLine);
                SortedEntities[SortedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
                RefPoint = new Pnt3D(pnt3D);
                --index1;
              }
              if (Options.NextGroupRules != SortingNextGroupFindRulesType.AskMe)
              {
                if (Options.NextGroupRules == SortingNextGroupFindRulesType.NoNextGroup)
                {
                  Result.ResultType = SortingResultType.Done;
                  return;
                }
              }
              else
              {
                for (int index14 = 0; index14 <= SortedEntities.Count - 1; ++index14)
                {
                  if (SortedEntities[index14].GetType() != typeof (eUpperLine))
                  {
                    eEntities copiedEnt = new eEntities();
                    eEntities.CopyEntity(SortedEntities[index14], ref copiedEnt);
                    this.AskMe.SortedEntities.Add(copiedEnt);
                  }
                  else
                  {
                    eEntities copiedEnt = new eEntities();
                    eEntities.CopyEntity(SortedEntities[index14], ref copiedEnt);
                    this.AskMe.UpperEntities.Add(copiedEnt);
                  }
                }
                this.AskMe.RefPoint = new Pnt3D();
                Result.LastPoint = new Pnt3D(RefPoint);
                Result.ResultType = SortingResultType.SelectNextGroup;
                return;
              }
            }
            this.AskMe.Return = false;
          }
          else
          {
            if (!flag1)
            {
              if (!(RefPoint == Options.EndPoint))
              {
                SortedEntities = new List<eEntities>();
                flag1 = true;
                RefPoint = new Pnt3D(Pnt1);
                goto label_231;
              }
              Result.ResultType = SortingResultType.Done;
              return;
            }
            if (!(RefPoint == Options.EndPoint))
            {
              flag1 = true;
              goto label_231;
            }
            Result.ResultType = SortingResultType.Done;
            return;
          }
        }
        if (Founds.Count > 0)
        {
          if (Founds.Count == 1)
          {
            RefPoint = new Pnt3D(Founds[0].RefPoint);
            int ListIndex = -1;
            buAppCalc.cVector.FindEntityListIndexByEntityIndex(BaseRefEntities, this.list_0[Founds[0].Index].EntityIndex, ref ListIndex);
            if (ListIndex >= 0 & ListIndex <= BaseRefEntities.Count - 1 & Options.UseCamSelectedProps)
              BaseRefEntities[ListIndex].bCamSelected = true;
            this.SortAddFoundToList(Founds[0], ref SortedEntities, ref this.list_0, CamData, ref Result);
            this.AskMe = new SortingAskMe();
            RefPoint = new Pnt3D(Founds[0].RefPoint);
            if (!Options.UseStopPoint || !buCompare.EQ(RefPoint, Options.StopPoint))
            {
              if (Options.IntersectionRules == SortingIntersectionRulesType.With2Point && RefPoint == Options.EndPoint)
              {
                Result.ResultType = SortingResultType.Done;
                return;
              }
            }
            else
            {
              Result.ResultType = SortingResultType.Done;
              return;
            }
          }
          if (Founds.Count > 1)
          {
            bool FoundUsed = false;
            if (flag2)
            {
              int index15 = -1;
              for (int index16 = 0; index16 <= Founds.Count - 1; ++index16)
              {
                List<eEntities> CopiedEnt = new List<eEntities>();
                eEntities.CopyEntities(SortedEntities, ref CopiedEnt);
                CopiedEnt.Add(Founds[index16].Entity);
                List<Pnt3D> Points = new List<Pnt3D>();
                buAppCalc.cVector.EntityToPoint(CopiedEnt, new EntityResolution(), ref Points);
                if (!buAppCalc.cVector.IsClosed(Points))
                  Points.Add(new Pnt3D(Points[0]));
                double TotalArea = 0.0;
                ClockDirectionType clockDirectionType2 = buAppCalc.cVector.PolygonDirection(Points, Plane, ref TotalArea);
                bool flag6 = buAppCalc.cVector.PolygonIsConvex(Points);
                if (clockDirectionType2 == clockDirectionType1 & flag6)
                  index15 = index16;
              }
              if (index15 >= 0)
              {
                RefPoint = new Pnt3D(Founds[index15].RefPoint);
                SortedEntities.Add(eEntities.CopyEntity(this.list_0[Founds[index15].Index]));
                Result.LastCalculatedEntities.Add(eEntities.CopyEntity(this.list_0[Founds[index15].Index]));
                if (!buAppCalc.cVector.IsIndexNumberAvailableAtList(Result.SelectedEntitiesIndex, this.list_0[Founds[index15].Index].EntityIndex))
                  Result.SelectedEntitiesIndex.Add(this.list_0[Founds[index15].Index].EntityIndex);
                if (!buAppCalc.cVector.IsIndexNumberAvailableAtList(Result.LastSelectedEntitiesIndex, this.list_0[Founds[index15].Index].EntityIndex))
                  Result.LastSelectedEntitiesIndex.Add(this.list_0[Founds[index15].Index].EntityIndex);
                this.list_0.RemoveAt(Founds[index15].Index);
                SortedEntities[SortedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
                SortedEntities[SortedEntities.Count - 1].bCamSelected = true;
                SortedEntities[SortedEntities.Count - 1].camDirections = Founds[index15].Direction;
                Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
                Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].bCamSelected = true;
                Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].camDirections = Founds[index15].Direction;
                FoundUsed = true;
              }
            }
            if (Options.IntersectionRules == SortingIntersectionRulesType.With2Point & !FoundUsed)
            {
              int index17 = 0;
              if (flag1)
                index17 = Founds.Count - 1;
              RefPoint = new Pnt3D(Founds[index17].RefPoint);
              SortedEntities.Add(eEntities.CopyEntity(this.list_0[Founds[index17].Index]));
              Result.LastCalculatedEntities.Add(eEntities.CopyEntity(this.list_0[Founds[index17].Index]));
              if (!buAppCalc.cVector.IsIndexNumberAvailableAtList(Result.SelectedEntitiesIndex, this.list_0[Founds[index17].Index].EntityIndex))
                Result.SelectedEntitiesIndex.Add(this.list_0[Founds[index17].Index].EntityIndex);
              if (!buAppCalc.cVector.IsIndexNumberAvailableAtList(Result.LastSelectedEntitiesIndex, this.list_0[Founds[index17].Index].EntityIndex))
                Result.LastSelectedEntitiesIndex.Add(this.list_0[Founds[index17].Index].EntityIndex);
              this.list_0.RemoveAt(Founds[index17].Index);
              SortedEntities[SortedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
              SortedEntities[SortedEntities.Count - 1].bCamSelected = true;
              SortedEntities[SortedEntities.Count - 1].camDirections = Founds[index17].Direction;
              Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
              Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].bCamSelected = true;
              Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].camDirections = Founds[index17].Direction;
              FoundUsed = true;
            }
            if ((Options.IntersectionRules == SortingIntersectionRulesType.LowerIndex | Options.IntersectionRules == SortingIntersectionRulesType.HigherIndex | Options.IntersectionRules == SortingIntersectionRulesType.FromDrawing) & !FoundUsed & !this.AskMe.Return)
            {
              int index18 = 0;
              if (Options.IntersectionRules == SortingIntersectionRulesType.LowerIndex | Options.IntersectionRules == SortingIntersectionRulesType.FromDrawing)
                index18 = 0;
              if (Options.IntersectionRules == SortingIntersectionRulesType.HigherIndex)
                index18 = Founds.Count - 1;
              if (SortedEntities.Count == 0 & Options.If2PointAtFirstPointUseSecondOne)
                index18 = 1;
              RefPoint = new Pnt3D(Founds[index18].RefPoint);
              SortedEntities.Add(eEntities.CopyEntity(this.list_0[Founds[index18].Index]));
              Result.LastCalculatedEntities.Add(eEntities.CopyEntity(this.list_0[Founds[index18].Index]));
              if (!buAppCalc.cVector.IsIndexNumberAvailableAtList(Result.SelectedEntitiesIndex, this.list_0[Founds[index18].Index].EntityIndex))
                Result.SelectedEntitiesIndex.Add(this.list_0[Founds[index18].Index].EntityIndex);
              if (!buAppCalc.cVector.IsIndexNumberAvailableAtList(Result.LastSelectedEntitiesIndex, this.list_0[Founds[index18].Index].EntityIndex))
                Result.LastSelectedEntitiesIndex.Add(this.list_0[Founds[index18].Index].EntityIndex);
              this.list_0.RemoveAt(Founds[index18].Index);
              SortedEntities[SortedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
              SortedEntities[SortedEntities.Count - 1].bCamSelected = true;
              SortedEntities[SortedEntities.Count - 1].camDirections = Founds[index18].Direction;
              Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
              Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].bCamSelected = true;
              Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].camDirections = Founds[index18].Direction;
              FoundUsed = true;
            }
            if ((Options.IntersectionRules == SortingIntersectionRulesType.LowerAngle | Options.IntersectionRules == SortingIntersectionRulesType.HighAngle) & !FoundUsed & !this.AskMe.Return)
              this.SortHighOrLowerAngle(ref RefPoint, ref FoundUsed, ref SortedEntities, ref Founds, ref this.list_0, Options, CamData, ref Result);
            if (Options.IntersectionRules == SortingIntersectionRulesType.AskMe)
            {
              if (this.AskMe.Return)
              {
                if (this.AskMe.Return)
                {
                  if (this.AskMe.SelectedIndex > Founds.Count - 1)
                    this.AskMe.SelectedIndex = 0;
                  int selectedIndex = this.AskMe.SelectedIndex;
                  RefPoint = new Pnt3D(Founds[selectedIndex].RefPoint);
                  this.SortAddFoundToList(Founds[selectedIndex], ref SortedEntities, ref this.list_0, CamData, ref Result);
                  this.AskMe.Return = false;
                }
              }
              else
              {
                this.AskMe.Entities = new List<eEntities>();
                for (int index19 = 0; index19 <= Founds.Count - 1; ++index19)
                {
                  this.AskMe.Entities.Add(eEntities.CopyEntity(this.list_0[Founds[index19].Index]));
                  this.AskMe.EntitiesIndex.Add(Founds[index19].Index);
                }
                this.AskMe.Return = true;
                this.AskMe.RefPoint = new Pnt3D(RefPoint);
                this.AskMe.SelectedIndex = 0;
                Result.ResultType = SortingResultType.MultipleEntities;
                return;
              }
            }
          }
        }
        flag2 = false;
        // ISSUE: reference to a compiler-generated field
        if (buSystem.ProgressControlEnable && this.calculationEventHandler_0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.calculationEventHandler_0(new CalculationEventArg(50.0, Convert.ToDouble((double) index1 / (double) (BaseRefEntities.Count - 1)) * 100.0, 0, "Sorting Entities", ""));
        }
        if (buSystem.DoEventEnable & int32 > 0 & num2 > 0 && num2 % int32 == 0)
          Application.DoEvents();
        if (!buSystem.Cancel)
        {
          ++num2;
        }
        else
        {
          buSystem.Cancel = false;
          buSystem.Canceled = true;
          // ISSUE: reference to a compiler-generated field
          if (this.calculationEventHandler_2 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.calculationEventHandler_2(new CalculationEventArg());
          }
          // ISSUE: reference to a compiler-generated field
          if (this.calculationEventHandler_3 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.calculationEventHandler_3(new CalculationEventArg(0.0, 0.0, 0, "Soring Entities", ""));
          }
          buLog.addLog("Soring Entities", "Canceled", MethodBase.GetCurrentMethod().Name);
          return;
        }
      }
      if (SortedEntities.Count <= 0)
        return;
      int num14 = 0;
      for (int index = 0; index <= SortedEntities.Count - 1; ++index)
      {
        if (SortedEntities[index].GetType() != typeof (eUpperLine))
          ++num14;
      }
      if (num14 >= BaseRefEntities.Count)
      {
        Result.FirstPoint = new Pnt3D(Pnt2);
        Result.LastPoint = new Pnt3D(RefPoint);
        Result.ResultType = SortingResultType.Done;
      }
      else if (SortedEntities[SortedEntities.Count - 1].GetType() == typeof (eUpperLine))
      {
        SortedEntities.RemoveAt(SortedEntities.Count - 1);
        Result.SelectedEntitiesIndex.Add(-1);
      }
      else if (SortedEntities[SortedEntities.Count - 1].camDirections == camPathDirectionType.Normal)
        RefPoint = new Pnt3D(SortedEntities[SortedEntities.Count - 1].Vertice[SortedEntities[SortedEntities.Count - 1].Vertice.Count - 1]);
      else
        RefPoint = new Pnt3D(SortedEntities[SortedEntities.Count - 1].Vertice[0]);
    }
    catch (Exception ex)
    {
      string str = $"Filters: {Filter.ToString()} - Options: {Options.ToString()} - RefPoint: {RefPoint.ToString()} - Plane: {Plane.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void SortPointsByRefPoint(
    Pnt3D RefPoint,
    ref List<Pnt3D> BaseRefPoints,
    WorkPlane Plane,
    SortingFilter Filter,
    SortingOptions Options,
    SortingCamData CamData,
    ref List<List<Pnt3D>> SortedPoints,
    ref SortingResult Result)
  {
    try
    {
    }
    catch (Exception ex)
    {
      string str = $"Filters: {Filter.ToString()} - Options: {Options.ToString()} - RefPoint: {RefPoint.ToString()} - Plane: {Plane.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void SortHighOrLowerAngle(
    ref Pnt3D RefPoint,
    ref bool FoundUsed,
    ref List<eEntities> SortedEntities,
    ref List<SortingFoundItems> Founds,
    ref List<eEntities> tempCircularEntities,
    SortingOptions Options,
    SortingCamData CamData,
    ref SortingResult Result)
  {
    if (SortedEntities.Count > 0)
    {
      if (SortedEntities[SortedEntities.Count - 1].Vertice.Count > 1)
      {
        Pnt3D pnt3D1 = new Pnt3D();
        Pnt3D pnt3D2 = new Pnt3D();
        Pnt3D FirstLineStart;
        Pnt3D FirstLineEnd;
        if (SortedEntities[SortedEntities.Count - 1].camDirections == camPathDirectionType.Normal)
        {
          FirstLineStart = new Pnt3D(SortedEntities[SortedEntities.Count - 1].Vertice[SortedEntities[SortedEntities.Count - 1].Vertice.Count - 1]);
          FirstLineEnd = new Pnt3D(SortedEntities[SortedEntities.Count - 1].Vertice[SortedEntities[SortedEntities.Count - 1].Vertice.Count - 2]);
        }
        else
        {
          FirstLineStart = new Pnt3D(SortedEntities[SortedEntities.Count - 1].Vertice[0]);
          FirstLineEnd = new Pnt3D(SortedEntities[SortedEntities.Count - 1].Vertice[1]);
        }
        Pnt3D SecondLineStart = new Pnt3D();
        Pnt3D SecondLineEnd = new Pnt3D();
        double num1 = -9999999.0;
        double num2 = 9999999.0;
        int num3 = 0;
        int num4 = 0;
        for (int index = 0; index <= Founds.Count - 1; ++index)
        {
          Pnt3D pnt3D3 = new Pnt3D(tempCircularEntities[Founds[index].Index].Vertice[0]);
          Pnt3D pnt3D4 = new Pnt3D(tempCircularEntities[Founds[index].Index].Vertice[tempCircularEntities[Founds[index].Index].Vertice.Count - 1]);
          if (buCompare.EQ(FirstLineStart, pnt3D3, Options.Resolution))
          {
            SecondLineStart = new Pnt3D(tempCircularEntities[Founds[index].Index].Vertice[0]);
            SecondLineEnd = new Pnt3D(tempCircularEntities[Founds[index].Index].Vertice[1]);
          }
          if (buCompare.EQ(FirstLineStart, pnt3D4, Options.Resolution))
          {
            SecondLineStart = new Pnt3D(tempCircularEntities[Founds[index].Index].Vertice[tempCircularEntities[Founds[index].Index].Vertice.Count - 1]);
            SecondLineEnd = new Pnt3D(tempCircularEntities[Founds[index].Index].Vertice[tempCircularEntities[Founds[index].Index].Vertice.Count - 2]);
          }
          double num5 = buAppCalc.cVector.AngleOfTwoLines(FirstLineStart, FirstLineEnd, SecondLineStart, SecondLineEnd, new WorkPlane());
          if (num5 > num1)
          {
            num1 = num5;
            num3 = index;
          }
          if (num5 < num2)
          {
            num2 = num5;
            num4 = index;
          }
        }
        if (Options.IntersectionRules == SortingIntersectionRulesType.HighAngle)
        {
          int index = num3;
          RefPoint = new Pnt3D(Founds[index].RefPoint);
          SortedEntities.Add(eEntities.CopyEntity(tempCircularEntities[Founds[index].Index]));
          Result.LastCalculatedEntities.Add(eEntities.CopyEntity(tempCircularEntities[Founds[index].Index]));
          if (!buAppCalc.cVector.IsIndexNumberAvailableAtList(Result.SelectedEntitiesIndex, tempCircularEntities[Founds[index].Index].EntityIndex))
            Result.SelectedEntitiesIndex.Add(tempCircularEntities[Founds[index].Index].EntityIndex);
          if (!buAppCalc.cVector.IsIndexNumberAvailableAtList(Result.LastSelectedEntitiesIndex, tempCircularEntities[Founds[index].Index].EntityIndex))
            Result.LastSelectedEntitiesIndex.Add(tempCircularEntities[Founds[index].Index].EntityIndex);
          tempCircularEntities.RemoveAt(Founds[index].Index);
          SortedEntities[SortedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
          SortedEntities[SortedEntities.Count - 1].bCamSelected = true;
          SortedEntities[SortedEntities.Count - 1].camDirections = Founds[index].Direction;
          Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
          Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].bCamSelected = true;
          Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].camDirections = Founds[index].Direction;
          FoundUsed = true;
        }
        if (Options.IntersectionRules != SortingIntersectionRulesType.LowerAngle)
          return;
        int index1 = num4;
        RefPoint = new Pnt3D(Founds[index1].RefPoint);
        SortedEntities.Add(eEntities.CopyEntity(tempCircularEntities[Founds[index1].Index]));
        Result.LastCalculatedEntities.Add(eEntities.CopyEntity(tempCircularEntities[Founds[index1].Index]));
        tempCircularEntities.RemoveAt(Founds[index1].Index);
        if (!buAppCalc.cVector.IsIndexNumberAvailableAtList(Result.SelectedEntitiesIndex, tempCircularEntities[Founds[index1].Index].EntityIndex))
          Result.SelectedEntitiesIndex.Add(tempCircularEntities[Founds[index1].Index].EntityIndex);
        if (!buAppCalc.cVector.IsIndexNumberAvailableAtList(Result.LastSelectedEntitiesIndex, tempCircularEntities[Founds[index1].Index].EntityIndex))
          Result.LastSelectedEntitiesIndex.Add(tempCircularEntities[Founds[index1].Index].EntityIndex);
        SortedEntities[SortedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
        SortedEntities[SortedEntities.Count - 1].bCamSelected = true;
        SortedEntities[SortedEntities.Count - 1].camDirections = Founds[index1].Direction;
        Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
        Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].bCamSelected = true;
        Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].camDirections = Founds[index1].Direction;
        FoundUsed = true;
      }
      else
      {
        int index = 0;
        RefPoint = new Pnt3D(Founds[0].RefPoint);
        SortedEntities.Add(eEntities.CopyEntity(tempCircularEntities[Founds[0].Index]));
        Result.LastCalculatedEntities.Add(eEntities.CopyEntity(tempCircularEntities[Founds[0].Index]));
        tempCircularEntities.RemoveAt(Founds[0].Index);
        if (!buAppCalc.cVector.IsIndexNumberAvailableAtList(Result.SelectedEntitiesIndex, tempCircularEntities[Founds[0].Index].EntityIndex))
          Result.SelectedEntitiesIndex.Add(tempCircularEntities[Founds[index].Index].EntityIndex);
        if (!buAppCalc.cVector.IsIndexNumberAvailableAtList(Result.LastSelectedEntitiesIndex, tempCircularEntities[Founds[index].Index].EntityIndex))
          Result.LastSelectedEntitiesIndex.Add(tempCircularEntities[Founds[index].Index].EntityIndex);
        SortedEntities[SortedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
        SortedEntities[SortedEntities.Count - 1].bCamSelected = true;
        SortedEntities[SortedEntities.Count - 1].camDirections = Founds[index].Direction;
        Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
        Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].bCamSelected = true;
        Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].camDirections = Founds[index].Direction;
        FoundUsed = true;
      }
    }
    else
    {
      int index = 0;
      RefPoint = new Pnt3D(Founds[0].RefPoint);
      SortedEntities.Add(eEntities.CopyEntity(tempCircularEntities[Founds[0].Index]));
      Result.LastCalculatedEntities.Add(eEntities.CopyEntity(tempCircularEntities[Founds[0].Index]));
      tempCircularEntities.RemoveAt(Founds[0].Index);
      if (!buAppCalc.cVector.IsIndexNumberAvailableAtList(Result.SelectedEntitiesIndex, tempCircularEntities[Founds[0].Index].EntityIndex))
        Result.SelectedEntitiesIndex.Add(tempCircularEntities[Founds[index].Index].EntityIndex);
      if (!buAppCalc.cVector.IsIndexNumberAvailableAtList(Result.LastSelectedEntitiesIndex, tempCircularEntities[Founds[index].Index].EntityIndex))
        Result.LastSelectedEntitiesIndex.Add(tempCircularEntities[Founds[index].Index].EntityIndex);
      SortedEntities[SortedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
      SortedEntities[SortedEntities.Count - 1].bCamSelected = true;
      SortedEntities[SortedEntities.Count - 1].camDirections = Founds[index].Direction;
      Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
      Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].bCamSelected = true;
      Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].camDirections = Founds[index].Direction;
      FoundUsed = true;
    }
  }

  public void SortAddFoundToList(
    SortingFoundItems FoundItem,
    ref List<eEntities> SortedEntities,
    ref List<eEntities> tempCircularEntities,
    SortingCamData CamData,
    ref SortingResult Result)
  {
    SortedEntities.Add(FoundItem.Entity);
    Result.LastCalculatedEntities.Add(eEntities.CopyEntity(FoundItem.Entity));
    if (!buAppCalc.cVector.IsIndexNumberAvailableAtList(Result.SelectedEntitiesIndex, tempCircularEntities[FoundItem.Index].EntityIndex))
      Result.SelectedEntitiesIndex.Add(tempCircularEntities[FoundItem.Index].EntityIndex);
    if (!buAppCalc.cVector.IsIndexNumberAvailableAtList(Result.LastSelectedEntitiesIndex, tempCircularEntities[FoundItem.Index].EntityIndex))
      Result.LastSelectedEntitiesIndex.Add(tempCircularEntities[FoundItem.Index].EntityIndex);
    tempCircularEntities.RemoveAt(FoundItem.Index);
    SortedEntities[SortedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
    SortedEntities[SortedEntities.Count - 1].bCamSelected = true;
    Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
    Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].bCamSelected = true;
    Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].camDirections = FoundItem.Direction;
  }

  public void HowManyConnectionAtRefPoint(
    List<eEntities> RefEntities,
    Pnt3D RefPoint,
    double Resolution,
    ref int ConnectionCount)
  {
    List<int> ConnectionIndex = new List<int>();
    this.HowManyConnectionAtRefPoint(RefEntities, RefPoint, Resolution, ref ConnectionCount, ref ConnectionIndex);
  }

  public void HowManyConnectionAtRefPoint(
    List<eEntities> RefEntities,
    Pnt3D RefPoint,
    double Resolution,
    ref int ConnectionCount,
    ref List<int> ConnectionIndex)
  {
    try
    {
      ConnectionCount = 0;
      ConnectionIndex.Clear();
      for (int index = 0; index <= RefEntities.Count - 1; ++index)
      {
        if (RefEntities[index].Vertice.Count > 0)
        {
          Pnt3D pnt3D = new Pnt3D(RefEntities[index].Vertice[0]);
          bool flag = false;
          if (buCompare.EQ(pnt3D, RefPoint, Resolution) & !RefEntities[index].bCamSelected)
          {
            ++ConnectionCount;
            ConnectionIndex.Add(index);
            flag = true;
          }
          if (!flag && buCompare.EQ(new Pnt3D(RefEntities[index].Vertice[RefEntities[index].Vertice.Count - 1]), RefPoint, Resolution) & !RefEntities[index].bCamSelected)
          {
            ++ConnectionCount;
            ConnectionIndex.Add(index);
          }
        }
      }
    }
    catch (Exception ex)
    {
      string str = $"RefEntities: {RefEntities.Count.ToString()} - RefPoint: {RefPoint.ToString()} - Resolution: {Resolution.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void FindInternalEntitiesAtClosedContour(
    List<Pnt3D> ClosedContour,
    List<eEntities> Entities,
    WorkPlane Plane,
    ref List<List<eEntities>> ClosedEntities,
    ref List<List<eEntities>> NotClosedEntities)
  {
    try
    {
      List<eEntities> BaseRefEntities = new List<eEntities>();
      List<eEntities> SortedEntities = new List<eEntities>();
      List<List<eEntities>> SplitedEntitites = new List<List<eEntities>>();
      SortingOptions Options = new SortingOptions();
      Pnt3D MinPoint = new Pnt3D();
      Pnt3D MaxPoint = new Pnt3D();
      buAppCalc.cVector.BoxSizeCalculate(ClosedContour, ref MinPoint, ref MaxPoint);
      Options.NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
      Options.IntersectionRules = SortingIntersectionRulesType.LowerIndex;
      for (int index1 = 0; index1 <= Entities.Count - 1; ++index1)
      {
        if (Entities[index1].bVisible)
        {
          bool flag1 = buAppCalc.cVector.IsPointInsideWindow(MinPoint, MaxPoint, Entities[index1].geoMinPoint, Plane, false);
          bool flag2 = buAppCalc.cVector.IsPointInsideWindow(MinPoint, MaxPoint, Entities[index1].geoMaxPoint, Plane, false);
          bool flag3 = flag1 & flag2;
          if (flag1 & flag2)
          {
            for (int index2 = 0; index2 <= Entities[index1].Vertice.Count - 1; ++index2)
            {
              bool flag4 = buAppCalc.cVector.IsPointInsidePolygon(ClosedContour, Entities[index1].Vertice[index2]);
              flag3 &= flag4;
            }
          }
          if (flag3)
            BaseRefEntities.Add(eEntities.CopyEntity(Entities[index1]));
        }
      }
      if (BaseRefEntities.Count > 0)
        this.SortEntitiesByRefPoint(BaseRefEntities[0].Vertice[0], ref BaseRefEntities, Options, ref SortedEntities);
      buAppCalc.cVector.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites);
      for (int index = 0; index <= SplitedEntitites.Count - 1; ++index)
      {
        if (buAppCalc.cVector.IsEntitiesClosedPath(SplitedEntitites[index]))
        {
          List<eEntities> CopiedEnt = new List<eEntities>();
          eEntities.CopyEntities(SplitedEntitites[index], ref CopiedEnt);
          ClosedEntities.Add(CopiedEnt);
        }
        else
        {
          List<eEntities> CopiedEnt = new List<eEntities>();
          eEntities.CopyEntities(SplitedEntitites[index], ref CopiedEnt);
          NotClosedEntities.Add(CopiedEnt);
        }
      }
    }
    catch (Exception ex)
    {
      string[] strArray = new string[6];
      strArray[0] = "ClosedContour: ";
      int count = ClosedContour.Count;
      strArray[1] = count.ToString();
      strArray[2] = " - Entities: ";
      count = Entities.Count;
      strArray[3] = count.ToString();
      strArray[4] = " - Plane: ";
      strArray[5] = Plane.ToString();
      string str = string.Concat(strArray);
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void FindOutsideEntitiesFromAllEntities(
    Pnt3D RefPoint,
    List<eEntities> AllEntities,
    WorkPlane Plane,
    ref List<eEntities> OutsideEntities,
    ref List<Pnt3D> OutsidePoints)
  {
    try
    {
      SortingFilter Filter = new SortingFilter();
      SortingOptions Options = new SortingOptions();
      SortingResult Result = new SortingResult();
      Options.UseCamSelectedProps = false;
      Options.IntersectionRules = SortingIntersectionRulesType.LowerIndex;
      Options.NextGroupRules = SortingNextGroupFindRulesType.NoNextGroup;
      OutsideEntities = new List<eEntities>();
      this.SortEntitiesByRefPoint(RefPoint, ref AllEntities, Plane, Filter, Options, new SortingCamData(), ref OutsideEntities, ref Result);
      OutsidePoints.Clear();
      buAppCalc.cVector.EntityToPoint(OutsideEntities, buSystem.EntitiesResolution, ref OutsidePoints);
      buAppCalc.cVector.CheckDuplicatedPointsWithPrevious(ref OutsidePoints, 0.01);
    }
    catch (Exception ex)
    {
      string str = $"AllEntities: {AllEntities.Count.ToString()} - RefPoint: {RefPoint.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }
}
