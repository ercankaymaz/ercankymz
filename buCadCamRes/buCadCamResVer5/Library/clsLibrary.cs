// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Library.clsLibrary
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buControls.DialogBox;
using buEyeBaseVer5;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.Library;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Library;

public class clsLibrary
{
  public bool SketchEnabled = false;
  private Sketch sketch_0 = new Sketch();
  private SketchEntity sketchEntity_0 = (SketchEntity) null;
  public LibraryManager LibManager = (LibraryManager) null;
  public List<Entity> LoadedEntities = (List<Entity>) null;
  public List<VisualConstraint> Constraints = (List<VisualConstraint>) null;
  public static List<buEntity> LibraryEntities;

  public void Init() => this.LibManager = new LibraryManager();

  public void cmdAddChar()
  {
    try
    {
      if (clsVar.appModes_0.DemoMode)
      {
        int num = (int) MessageBox.Show("Not Available in Demo Mode");
      }
      else
      {
        clsInit.appCommand.Reset(false);
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = devDept.Eyeshot.actionType.None;
        ccVars.Action = actionTypeBU.libCharCreat;
        dynamicInfo.Command = AppLanguage.CadCamCommand[108];
        ccVars.selectionProcess = true;
        if (ccVars.SelectionOP.Selections.Count == 0)
        {
          ccVars.stpDrawing = 1;
          ccVars.selectionProcess = true;
          clsInit.appCommand.cmdMainFormStatusUpdate($"{AppLanguage.CadCamStatus[107]} [ {dynamicInfo.Command} ]");
        }
        else
          this.doAddChar();
      }
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void cmdShowCharList()
  {
    F_CharList fCharList = new F_CharList();
    CharLibrary5.Copy(ccVars.CharLibList, ref fCharList.Chars);
    fCharList.Init();
    int num = (int) fCharList.ShowDialog((IWin32Window) clsItem.FrmMain);
    if (fCharList.Properties.Result != DialogResult.OK)
      return;
    CharLibrary5.Copy(fCharList.Chars, ref ccVars.CharLibList);
  }

  public void cmdOpenCharList()
  {
    OpenFileDialog openFileDialog = new OpenFileDialog();
    openFileDialog.Filter = "Char File (*.buchar)|*.buchar";
    openFileDialog.InitialDirectory = clsVar.varInterface.pathChar;
    openFileDialog.FilterIndex = 1;
    if (openFileDialog.ShowDialog() != DialogResult.OK)
      return;
    for (int index = 0; index <= ccVars.CharLibList.Count - 1; ++index)
    {
      Point3D MinPoint = new Point3D();
      Point3D MaxPoint = new Point3D();
      clsInit.cVector5.BoxSizeCalculate(ccVars.CharLibList[index].CharEntities, ref MinPoint, ref MaxPoint);
      clsInit.cVector5.Move(-MinPoint.X, -MinPoint.Y, 0.0, ref ccVars.CharLibList[index].CharEntities);
    }
    clsVar.varInterface.pathChar = buFile5.GetPath(openFileDialog.FileName);
    ArrayList StringList = new ArrayList();
    buFile5.OpenFromFile(openFileDialog.FileName, ref StringList);
    ccVars.CharLibList.Clear();
    CharLibrary5.Decode(StringList, ref ccVars.CharLibList);
    clsFiles.SaveParameter();
  }

  public void cmdSaveCharList()
  {
    SaveFileDialog saveFileDialog = new SaveFileDialog();
    saveFileDialog.Filter = "Char File (*.buchar)|*.buchar";
    saveFileDialog.InitialDirectory = clsVar.varInterface.pathChar;
    saveFileDialog.FilterIndex = 1;
    if (saveFileDialog.ShowDialog() != DialogResult.OK)
      return;
    for (int index = 0; index <= ccVars.CharLibList.Count - 1; ++index)
    {
      Point3D MinPoint = new Point3D();
      Point3D MaxPoint = new Point3D();
      clsInit.cVector5.BoxSizeCalculate(ccVars.CharLibList[index].CharEntities, ref MinPoint, ref MaxPoint);
      clsInit.cVector5.Move(-MinPoint.X, -MinPoint.Y, 0.0, ref ccVars.CharLibList[index].CharEntities);
    }
    clsVar.varInterface.pathChar = buFile5.GetPath(saveFileDialog.FileName);
    ArrayList arrayList = new ArrayList();
    buFile5.SaveToFile(CharLibrary5.ToDef(ccVars.CharLibList, 2), saveFileDialog.FileName);
    clsFiles.SaveParameter();
  }

  public void cmdEnableSketcher()
  {
    this.Constraints = new List<VisualConstraint>();
    this.LoadedEntities = new List<Entity>();
    this.LibManager = new LibraryManager();
  }

  public void cmdLibFix()
  {
    clsInit.appCommand.Reset();
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = devDept.Eyeshot.actionType.None;
    ccVars.Action = actionTypeBU.libraryFixPoint;
    ccVars.stpDrawing = 1;
    ccVars.selectionProcess = true;
  }

  public void cmdLibHorizontal()
  {
    if (ccVars.SelectionOP.Selections.Count == 0)
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = devDept.Eyeshot.actionType.None;
      ccVars.Action = actionTypeBU.libraryHorizontal;
      ccVars.stpDrawing = 1;
      ccVars.selectionProcess = true;
    }
    else
    {
      ccVars.Action = actionTypeBU.libraryHorizontal;
      this.doAddConstraints(new Point3D());
    }
  }

  public void cmdLibVertical()
  {
    if (ccVars.SelectionOP.Selections.Count == 0)
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = devDept.Eyeshot.actionType.None;
      ccVars.Action = actionTypeBU.libraryVertical;
      ccVars.stpDrawing = 1;
      ccVars.selectionProcess = true;
    }
    else
    {
      ccVars.Action = actionTypeBU.libraryVertical;
      this.doAddConstraints(new Point3D());
    }
  }

  public void cmdLibEqualLen()
  {
    if (ccVars.SelectionOP.Selections.Count < 2)
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = devDept.Eyeshot.actionType.None;
      ccVars.Action = actionTypeBU.libraryEqualLength;
      ccVars.stpDrawing = 1;
      ccVars.selectionProcess = true;
    }
    else
    {
      ccVars.Action = actionTypeBU.libraryEqualLength;
      this.doAddConstraints(new Point3D());
    }
  }

  public void cmdLibParalel()
  {
    if (ccVars.SelectionOP.Selections.Count < 2)
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = devDept.Eyeshot.actionType.None;
      ccVars.Action = actionTypeBU.libraryParalel;
      ccVars.stpDrawing = 1;
      ccVars.selectionProcess = true;
    }
    else
    {
      ccVars.Action = actionTypeBU.libraryParalel;
      this.doAddConstraints(new Point3D());
    }
  }

  public void cmdLibPerpendicular()
  {
    if (ccVars.SelectionOP.Selections.Count < 2)
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = devDept.Eyeshot.actionType.None;
      ccVars.Action = actionTypeBU.libraryPerpendiculat;
      ccVars.stpDrawing = 1;
      ccVars.selectionProcess = true;
    }
    else
    {
      ccVars.Action = actionTypeBU.libraryPerpendiculat;
      this.doAddConstraints(new Point3D());
    }
  }

  public void cmdLibCollinear()
  {
    if (ccVars.SelectionOP.Selections.Count < 2)
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = devDept.Eyeshot.actionType.None;
      ccVars.Action = actionTypeBU.libraryCollinear;
      ccVars.stpDrawing = 1;
      ccVars.selectionProcess = true;
    }
    else
    {
      ccVars.Action = actionTypeBU.libraryCollinear;
      this.doAddConstraints(new Point3D());
    }
  }

  public void cmdLibTangent()
  {
    if (ccVars.SelectionOP.Selections.Count < 2)
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = devDept.Eyeshot.actionType.None;
      ccVars.Action = actionTypeBU.libraryTangent;
      ccVars.stpDrawing = 1;
      ccVars.selectionProcess = true;
    }
    else
    {
      ccVars.Action = actionTypeBU.libraryTangent;
      this.doAddConstraints(new Point3D());
    }
  }

  public void cmdLibEqualRad()
  {
    if (ccVars.SelectionOP.Selections.Count < 2)
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = devDept.Eyeshot.actionType.None;
      ccVars.Action = actionTypeBU.libraryEqualRadius;
      ccVars.stpDrawing = 1;
      ccVars.selectionProcess = true;
    }
    else
    {
      ccVars.Action = actionTypeBU.libraryEqualRadius;
      this.doAddConstraints(new Point3D());
    }
  }

  public void cmdLibLength()
  {
    if (ccVars.SelectionOP.Selections.Count == 0)
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = devDept.Eyeshot.actionType.None;
      ccVars.Action = actionTypeBU.libraryLength;
      ccVars.stpDrawing = 1;
      ccVars.selectionProcess = true;
    }
    else
    {
      ccVars.Action = actionTypeBU.libraryLength;
      this.doAddConstraints(new Point3D());
    }
  }

  public void cmdLibRadius()
  {
    if (ccVars.SelectionOP.Selections.Count == 0)
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = devDept.Eyeshot.actionType.None;
      ccVars.Action = actionTypeBU.libraryRadius;
      ccVars.stpDrawing = 1;
      ccVars.selectionProcess = true;
    }
    else
    {
      ccVars.Action = actionTypeBU.libraryRadius;
      this.doAddConstraints(new Point3D());
    }
  }

  public void cmdLibAngle()
  {
    if (ccVars.SelectionOP.Selections.Count < 2)
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = devDept.Eyeshot.actionType.None;
      ccVars.Action = actionTypeBU.libraryAngle;
      ccVars.stpDrawing = 1;
      ccVars.selectionProcess = true;
    }
    else
    {
      ccVars.Action = actionTypeBU.libraryAngle;
      this.doAddConstraints(new Point3D());
    }
  }

  public void cmdLibLineLine()
  {
    if (ccVars.SelectionOP.Selections.Count < 2)
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = devDept.Eyeshot.actionType.None;
      ccVars.Action = actionTypeBU.libraryLineLine;
      ccVars.stpDrawing = 1;
      ccVars.selectionProcess = true;
    }
    else
    {
      ccVars.Action = actionTypeBU.libraryLineLine;
      this.doAddConstraints(new Point3D());
    }
  }

  public void cmdLibLinePoint()
  {
    if (ccVars.SelectionOP.Selections.Count < 2)
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = devDept.Eyeshot.actionType.None;
      ccVars.Action = actionTypeBU.libraryLinePoint;
      ccVars.stpDrawing = 1;
      ccVars.selectionProcess = true;
    }
    else
    {
      ccVars.Action = actionTypeBU.libraryLinePoint;
      this.doAddConstraints(new Point3D());
    }
  }

  public void cmdLibPointPoint()
  {
    if (ccVars.SelectionOP.Selections.Count < 2)
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = devDept.Eyeshot.actionType.None;
      ccVars.Action = actionTypeBU.libraryPointPoint;
      ccVars.stpDrawing = 1;
      ccVars.selectionProcess = true;
    }
    else
    {
      ccVars.Action = actionTypeBU.libraryPointPoint;
      this.doAddConstraints(new Point3D());
    }
  }

  public void cmdLibSaveFile(Design Viewport)
  {
    if (clsVar.appModes_0.DemoMode)
    {
      int num = (int) MessageBox.Show("You can't save in Demo Mode");
    }
    else
    {
      if (ccVars.Pages.Count <= 0)
        return;
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.InitialDirectory = clsVar.varLibrary.pathLibrary;
      saveFileDialog.Filter = "buCad/Cam Library File (*.bulib5)|*.bulib5";
      saveFileDialog.FilterIndex = 1;
      if (saveFileDialog.ShowDialog() != DialogResult.OK)
        return;
      List<buEntity> copiedEntities = new List<buEntity>();
      if (Viewport.CurrentSketch.Editing)
        Viewport.CurrentSketch.Exit();
      buEntity.Copy(Viewport.Entities.ToList<Entity>(), ref copiedEntities);
      this.SaveLibraryFile(saveFileDialog.FileName, copiedEntities, this.LibManager);
      clsVar.varLibrary.pathLibrary = buFile5.GetPath(saveFileDialog.FileName);
      clsFiles.SaveParameter();
    }
  }

  public void cmdLibSaveFile()
  {
    if (clsVar.appModes_0.DemoMode)
    {
      int num = (int) MessageBox.Show("You can't save in Demo Mode");
    }
    else
    {
      if (ccVars.Pages.Count <= 0)
        return;
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.InitialDirectory = clsVar.varLibrary.pathLibrary;
      saveFileDialog.Filter = "buCad/Cam Library File (*.bulib5)|*.bulib5";
      saveFileDialog.FilterIndex = 1;
      if (saveFileDialog.ShowDialog() != DialogResult.OK)
        return;
      List<buEntity> copiedEntities = new List<buEntity>();
      buEntity.Copy(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.ToList<Entity>(), ref copiedEntities);
      this.SaveLibraryFile(saveFileDialog.FileName, copiedEntities, this.LibManager);
      clsVar.varLibrary.pathLibrary = buFile5.GetPath(saveFileDialog.FileName);
      clsFiles.SaveParameter();
    }
  }

  public void OpenLibraryFile(string FileName, ref LibraryManager Manager)
  {
    ArrayList StringList = new ArrayList();
    List<string> CalcList1 = new List<string>();
    List<List<string>> CalcList2 = new List<List<string>>();
    buFile5.OpenFromFile(FileName, ref StringList);
    buString5.ListToSpecificList("<LibraryEntities>", "</LibraryEntities>", true, StringList, ref CalcList1);
    this.LibManager = new LibraryManager();
    buStatics.ListToSpecificList("<buEntity>", "</buEntity>", false, CalcList1, ref CalcList2);
    for (int index = 0; index <= CalcList2.Count - 1; ++index)
    {
      buEntity buEntity = buEntity.Decode(CalcList2[index]);
      if (buEntity != null)
        this.LibManager.Entities.Add(buEntity);
    }
    List<string> CalcList3 = new List<string>();
    buString5.ListToSpecificList("<LibraryManager>", "</LibraryManager>", true, StringList, ref CalcList3);
    LibraryManager.Decode(CalcList3, ref this.LibManager);
  }

  public void SaveLibraryFile(string FileName, List<buEntity> Entities, LibraryManager Manager)
  {
    if (!(new FileInfo(FileName).Extension.ToLower() == ".bulib5"))
      return;
    ArrayList StringList = new ArrayList();
    StringList.Add((object) "<LibraryEntities>");
    StringList.AddRange((ICollection) buEntity.ToDefEntity(Entities, 2));
    StringList.Add((object) "</LibraryEntities>");
    StringList.Add((object) "------------------------------------------------------------------------");
    StringList.Add((object) "   Library Settings");
    StringList.Add((object) "------------------------------------------------------------------------");
    StringList.Add((object) "<LibraryManager>");
    StringList.AddRange((ICollection) LibraryManager.ToDef(Manager));
    StringList.Add((object) "</LibraryManager>");
    buFile5.SaveToFile(StringList, FileName);
  }

  public bool doFindReleatedPoint(
    List<buEntity> refEntities,
    Point3D refPoint,
    ref int indexFound,
    ref StartEndCenterType foundPointType)
  {
    bool releatedPoint;
    for (int index = 0; index <= refEntities.Count - 1; ++index)
    {
      if (refEntities[index] is buLine | refEntities[index] is buArc | refEntities[index] is buCurve)
      {
        if (!buCompare5.EQ(refPoint, refEntities[index].EndPoint))
        {
          if (buCompare5.EQ(refPoint, refEntities[index].StartPoint))
          {
            foundPointType = StartEndCenterType.End;
            indexFound = index;
            releatedPoint = true;
            goto label_15;
          }
        }
        else
        {
          foundPointType = StartEndCenterType.End;
          indexFound = index;
          releatedPoint = true;
          goto label_15;
        }
      }
      if (!(refEntities[index] is buCircle) || !buCompare5.EQ(refPoint, ((buCircle) refEntities[index]).Center))
      {
        if (!(refEntities[index] is buArc) || !buCompare5.EQ(refPoint, ((buArc) refEntities[index]).Center))
        {
          if (refEntities[index] is buEllipse && buCompare5.EQ(refPoint, ((buEllipse) refEntities[index]).Center))
          {
            foundPointType = StartEndCenterType.Center;
            indexFound = index;
            releatedPoint = true;
            goto label_15;
          }
        }
        else
        {
          foundPointType = StartEndCenterType.Center;
          indexFound = index;
          releatedPoint = true;
          goto label_15;
        }
      }
      else
      {
        foundPointType = StartEndCenterType.Center;
        indexFound = index;
        releatedPoint = true;
        goto label_15;
      }
    }
    releatedPoint = false;
label_15:
    return releatedPoint;
  }

  public void doAddConstraints(Point3D firstPoint, Point3D secondPoint = null)
  {
    if (ccVars.Action == actionTypeBU.libraryHorizontal)
    {
      for (int index = 0; index <= ccVars.SelectionOP.Selections.Count - 1; ++index)
        this.LibManager.ConstraintList.Add(new LibraryConstraints()
        {
          Type = ConstraintsType.Horizontal,
          FirstIndex = ccVars.SelectionOP.Selections[index].Index
        });
    }
    if (ccVars.Action == actionTypeBU.libraryVertical)
    {
      for (int index = 0; index <= ccVars.SelectionOP.Selections.Count - 1; ++index)
        this.LibManager.ConstraintList.Add(new LibraryConstraints()
        {
          Type = ConstraintsType.Vertical,
          FirstIndex = ccVars.SelectionOP.Selections[index].Index
        });
    }
    if (ccVars.Action == actionTypeBU.libraryLength)
    {
      for (int index = 0; index <= ccVars.SelectionOP.Selections.Count - 1; ++index)
        this.LibManager.ConstraintList.Add(new LibraryConstraints()
        {
          Type = ConstraintsType.Length,
          FirstIndex = ccVars.SelectionOP.Selections[index].Index
        });
    }
    if (ccVars.Action == actionTypeBU.libraryRadius)
    {
      for (int index = 0; index <= ccVars.SelectionOP.Selections.Count - 1; ++index)
        this.LibManager.ConstraintList.Add(new LibraryConstraints()
        {
          Type = ConstraintsType.Radius,
          FirstIndex = ccVars.SelectionOP.Selections[index].Index
        });
    }
    if (ccVars.Action == actionTypeBU.libraryLineLine && ccVars.SelectionOP.Selections.Count >= 2)
      this.LibManager.ConstraintList.Add(new LibraryConstraints()
      {
        Type = ConstraintsType.LineLine,
        FirstIndex = ccVars.SelectionOP.Selections[0].Index,
        SecondIndex = ccVars.SelectionOP.Selections[1].Index
      });
    if (ccVars.Action == actionTypeBU.libraryLinePoint && ccVars.SelectionOP.Selections.Count >= 1)
      this.LibManager.ConstraintList.Add(new LibraryConstraints()
      {
        Type = ConstraintsType.LinePoint,
        FirstIndex = ccVars.SelectionOP.Selections[0].Index,
        refPoint = new Point3D(firstPoint.X, firstPoint.Y, firstPoint.Z)
      });
    if (ccVars.Action == actionTypeBU.libraryLinePoint && ccVars.SelectionOP.Selections.Count >= 1)
      this.LibManager.ConstraintList.Add(new LibraryConstraints()
      {
        Type = ConstraintsType.LinePoint,
        FirstIndex = ccVars.SelectionOP.Selections[0].Index,
        refPoint = new Point3D(firstPoint.X, firstPoint.Y, firstPoint.Z)
      });
    if (ccVars.Action == actionTypeBU.libraryEqualLength && ccVars.SelectionOP.Selections.Count >= 2)
      this.LibManager.ConstraintList.Add(new LibraryConstraints()
      {
        Type = ConstraintsType.EqualLength,
        FirstIndex = ccVars.SelectionOP.Selections[0].Index,
        SecondIndex = ccVars.SelectionOP.Selections[1].Index
      });
    if (ccVars.Action == actionTypeBU.libraryFixPoint)
    {
      LibraryConstraints libraryConstraints = new LibraryConstraints();
      libraryConstraints.Type = ConstraintsType.FixPoint;
      libraryConstraints.refPoint = new Point3D(firstPoint.X, firstPoint.Y, firstPoint.Z);
      if (ccVars.SelectionOP.Selections.Count >= 1)
        libraryConstraints.FirstIndex = ccVars.SelectionOP.Selections[0].Index;
      if (ccVars.SelectionOP.Selections.Count >= 2)
        libraryConstraints.SecondIndex = ccVars.SelectionOP.Selections[1].Index;
      this.LibManager.ConstraintList.Add(libraryConstraints);
    }
    clsInit.appCommand.Reset();
  }

  public void doAddLine(Point3D pntStart, Point3D pntEnd)
  {
    Line line = new Line(Plane.XY, new Point2D(pntStart.X, pntStart.Y), new Point2D(pntEnd.X, pntEnd.Y));
    line.LayerName = "General";
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.CurrentSketch.AddLine(line);
    Point2D point2D1 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.CurrentSketch.Plane.Project(pntStart);
    Point2D point2D2 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.CurrentSketch.Plane.Project(pntEnd);
    if (Math.Abs(point2D1.X - point2D2.X) < 1E-09 && Math.Abs(point2D1.Y - point2D2.Y) < 1E-09)
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.CurrentSketch.UpdateAndInvalidate();
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.UpdateBoundingBox();
    int count = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count;
  }

  public void doCreateEntitiesFromCustomText(
    string Text,
    double CharSpace,
    double SpaceValue,
    double CharHeight,
    ref List<buEntity> TextEntities)
  {
    try
    {
      TextEntities.Clear();
      TextEntities = new List<buEntity>();
      double num1 = 1.0;
      if (Text.Length <= 0)
        return;
      char[] charArray = Text.ToCharArray();
      double num2 = 0.0;
      if (charArray == null)
        return;
      for (int index1 = 0; index1 <= charArray.Length - 1; ++index1)
      {
        bool flag = false;
        List<buEntity> refEntities = new List<buEntity>();
        for (int index2 = 0; index2 <= ccVars.CharLibList.Count - 1; ++index2)
        {
          string str = charArray[index1].ToString();
          if (str == ccVars.CharLibList[index2].Char)
          {
            buEntity.Copy(ccVars.CharLibList[index2].CharEntities, ref refEntities);
            index2 = 2147483645;
          }
          if (str == " ")
            flag = true;
        }
        if (flag)
          num2 += SpaceValue;
        else if (refEntities.Count > 0)
        {
          Point3D MinPoint = new Point3D();
          Point3D MaxPoint = new Point3D();
          clsInit.cVector5.BoxSizeCalculate(refEntities, ref MinPoint, ref MaxPoint);
          double num3 = MaxPoint.Y - MinPoint.Y;
          if (num3 > 0.0 & CharHeight > 0.0 & TextEntities.Count == 0)
            num1 = CharHeight / num3;
          clsInit.cVector5.Scale(MinPoint, num1, num1, 1.0, ref refEntities);
          clsInit.cVector5.Move(num2 - MinPoint.X, -MinPoint.Y, -MinPoint.Z, ref refEntities);
          clsInit.cVector5.BoxSizeCalculate(refEntities, ref MinPoint, ref MaxPoint);
          SortbuSettings Settings = new SortbuSettings();
          Settings.Option.NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
          List<buEntity> SortedEntities = new List<buEntity>();
          clsInit.cVector5.SortEntitiesByRefPoint(refEntities[0].Vertices[0], ref refEntities, Settings, ref SortedEntities);
          List<List<buEntity>> SplitedEntitites = new List<List<buEntity>>();
          clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites);
          for (int index3 = 0; index3 <= SplitedEntitites.Count - 1; ++index3)
          {
            List<Point3D> Points = new List<Point3D>();
            clsInit.cVector5.EntitiesToPointsWithCamDirection(SplitedEntitites[index3], 0.01, ref Points);
            if (Points.Count == 2)
              TextEntities.Add((buEntity) new buLine(Points[0], Points[1]));
            else if (Points.Count > 2)
              TextEntities.Add((buEntity) new buLinearPath(Points));
          }
          num2 = MaxPoint.X + CharSpace;
        }
        else
          num2 += SpaceValue;
      }
    }
    catch (Exception ex)
    {
    }
  }

  public void doDimensionEntities(
    ref List<buEntity> DrawEntities,
    buEntity DimEntities,
    double NewValue)
  {
    int num = -1;
    int indexEntity1 = -1;
    int indexEntity2 = -1;
    double moveDX = 0.0;
    double moveDY1 = 0.0;
    buEntity copiedEntity = (buEntity) null;
    Point3D point3D = (Point3D) null;
    Point3D CatchPoint = (Point3D) null;
    if (DimEntities.Dimension != null)
    {
      num = DimEntities.Dimension.ReSizedEntityIndex;
      buVector5.ToPoint3D(DimEntities.Dimension.BasePoint);
    }
    if (num < 0)
      return;
    if (num >= 0 & num <= DrawEntities.Count - 1)
      buEntity.Copy(DrawEntities[num], ref copiedEntity);
    buEntity buEntity1 = (buEntity) null;
    buEntity buEntity2 = (buEntity) null;
    if (DimEntities.Dimension.Type == DimensionType.Length)
    {
      for (int index = 0; index <= DrawEntities.Count - 1; ++index)
      {
        if (index != num)
        {
          if (!buCompare5.EQ(DrawEntities[index].StartPoint, DimEntities.Dimension.CatchPoint))
          {
            if (buCompare5.EQ(DrawEntities[index].EndPoint, DimEntities.Dimension.CatchPoint))
            {
              buEntity1 = DrawEntities[index];
              indexEntity1 = index;
              buVector5.ToPoint3D(DrawEntities[index].EndPoint);
              point3D = buVector5.ToPoint3D(DrawEntities[index].StartPoint);
              break;
            }
          }
          else
          {
            buEntity1 = DrawEntities[index];
            indexEntity1 = index;
            buVector5.ToPoint3D(DrawEntities[index].StartPoint);
            point3D = buVector5.ToPoint3D(DrawEntities[index].EndPoint);
            break;
          }
        }
      }
      if (point3D != (Point3D) null)
      {
        for (int index = 0; index <= DrawEntities.Count - 1; ++index)
        {
          if (index != num & index != indexEntity1)
          {
            if (!buCompare5.EQ(DrawEntities[index].StartPoint, point3D))
            {
              if (buCompare5.EQ(DrawEntities[index].EndPoint, point3D))
              {
                buEntity2 = DrawEntities[index];
                indexEntity2 = index;
                CatchPoint = buVector5.ToPoint3D(DrawEntities[index].EndPoint);
                break;
              }
            }
            else
            {
              buEntity2 = DrawEntities[index];
              indexEntity2 = index;
              CatchPoint = buVector5.ToPoint3D(DrawEntities[index].StartPoint);
              break;
            }
          }
        }
      }
      if (buCompare5.EQ(DrawEntities[num].StartPoint, DimEntities.Dimension.CatchPoint, 0.1))
      {
        Point3D EndPnt = new Point3D();
        double Angle = clsInit.cVector5.PointAngle(DrawEntities[num].StartPoint, DrawEntities[num].EndPoint);
        clsInit.cVector5.LineWithLengthAndAngle(DrawEntities[num].EndPoint, NewValue, Angle, ref EndPnt);
        moveDX = EndPnt.X - DrawEntities[num].StartPoint.X;
        moveDY1 = EndPnt.Y - DrawEntities[num].StartPoint.Y;
        DrawEntities[num].StartPoint.X += moveDX;
        DrawEntities[num].StartPoint.Y += moveDY1;
        DrawEntities[num].Update(buEntityUpdateType.Line);
        this.MoveDimensionEntitiesByIndex(ref DrawEntities, num, DimEntities.Dimension.CatchPoint, moveDX, moveDY1);
      }
      else if (buCompare5.EQ(DrawEntities[num].EndPoint, DimEntities.Dimension.CatchPoint, 0.1))
      {
        Point3D EndPnt = new Point3D();
        double Angle = clsInit.cVector5.PointAngle(DrawEntities[num].EndPoint, DrawEntities[num].StartPoint);
        clsInit.cVector5.LineWithLengthAndAngle(DrawEntities[num].StartPoint, NewValue, Angle, ref EndPnt);
        moveDX = EndPnt.X - DrawEntities[num].EndPoint.X;
        moveDY1 = EndPnt.Y - DrawEntities[num].EndPoint.Y;
        DrawEntities[num].EndPoint.X += moveDX;
        DrawEntities[num].EndPoint.Y += moveDY1;
        DrawEntities[num].Update(buEntityUpdateType.Line);
        this.MoveDimensionEntitiesByIndex(ref DrawEntities, num, DimEntities.Dimension.CatchPoint, moveDX, moveDY1);
      }
      if (buEntity1 != null)
      {
        this.MoveDimensionEntitiesByIndex(ref DrawEntities, indexEntity1, buEntity1.StartPoint, moveDX, moveDY1);
        this.MoveDimensionEntitiesByIndex(ref DrawEntities, indexEntity1, buEntity1.EndPoint, moveDX, moveDY1);
        buEntity1.StartPoint.X += moveDX;
        buEntity1.EndPoint.X += moveDX;
        buEntity1.StartPoint.Y += moveDY1;
        buEntity1.EndPoint.Y += moveDY1;
        buEntity1.Update(buEntityUpdateType.Line);
        if (buCompare5.EQ(buEntity1.StartPoint, DimEntities.Dimension.CatchPoint, 0.1) || buCompare5.EQ(buEntity1.EndPoint, DimEntities.Dimension.CatchPoint, 0.1))
          ;
      }
      if (buEntity2 != null)
      {
        if (buCompare5.EQ(buEntity2.StartPoint, CatchPoint, 0.1))
        {
          this.MoveDimensionEntitiesByIndex(ref DrawEntities, indexEntity2, CatchPoint, moveDX, moveDY1);
          buEntity2.StartPoint.X += moveDX;
          buEntity2.StartPoint.Y += moveDY1;
        }
        else if (buCompare5.EQ(buEntity2.EndPoint, CatchPoint, 0.1))
        {
          this.MoveDimensionEntitiesByIndex(ref DrawEntities, indexEntity2, CatchPoint, moveDX, moveDY1);
          buEntity2.EndPoint.X += moveDX;
          buEntity2.EndPoint.Y += moveDY1;
        }
        buEntity2.Update(buEntityUpdateType.Line);
      }
    }
    if (DimEntities.Dimension.Type == DimensionType.Horizontal)
    {
      SortbuSettings Settings = new SortbuSettings();
      SortbuResult Result = new SortbuResult();
      Settings.Option.NextGroupRules = SortingNextGroupFindRulesType.NoNextGroup;
      List<buEntity> SortedEntities = new List<buEntity>();
      clsInit.cVector5.SortEntitiesByRefPoint(copiedEntity.StartPoint, ref DrawEntities, Settings, ref SortedEntities, ref Result);
      if (SortedEntities.Count > 0)
      {
        moveDX = NewValue - DimEntities.Dimension.Distance;
        for (int index = 0; index <= SortedEntities.Count - 1; ++index)
        {
          int originalEntityIndex = SortedEntities[index].Info.OriginalEntityIndex;
          if (originalEntityIndex >= 0 & originalEntityIndex <= DrawEntities.Count - 1)
          {
            DrawEntities[originalEntityIndex].StartPoint.X += moveDX;
            DrawEntities[originalEntityIndex].EndPoint.X += moveDX;
            DrawEntities[originalEntityIndex].Update(buEntityUpdateType.Line);
          }
        }
        this.MoveDimensionEntitiesByIndex(ref DrawEntities, num, ((buLinearDim) DimEntities).ExtLine2, moveDX, moveDY1);
      }
    }
    if (DimEntities.Dimension.Type != DimensionType.Vertical)
      return;
    SortbuSettings Settings1 = new SortbuSettings();
    SortbuResult Result1 = new SortbuResult();
    Settings1.Option.NextGroupRules = SortingNextGroupFindRulesType.NoNextGroup;
    List<buEntity> SortedEntities1 = new List<buEntity>();
    clsInit.cVector5.SortEntitiesByRefPoint(copiedEntity.StartPoint, ref DrawEntities, Settings1, ref SortedEntities1, ref Result1);
    if (SortedEntities1.Count <= 0)
      return;
    double moveDY2 = NewValue - DimEntities.Dimension.Distance;
    for (int index = 0; index <= SortedEntities1.Count - 1; ++index)
    {
      int originalEntityIndex = SortedEntities1[index].Info.OriginalEntityIndex;
      if (originalEntityIndex >= 0 & originalEntityIndex <= DrawEntities.Count - 1)
      {
        DrawEntities[originalEntityIndex].StartPoint.Y += moveDY2;
        DrawEntities[originalEntityIndex].EndPoint.Y += moveDY2;
        DrawEntities[originalEntityIndex].Update(buEntityUpdateType.Line);
      }
    }
    this.MoveDimensionEntitiesByIndex(ref DrawEntities, num, ((buLinearDim) DimEntities).ExtLine2, moveDX, moveDY2);
  }

  public void doAddChar()
  {
    List<eEntities> eEntitiesList1 = new List<eEntities>();
    List<eEntities> eEntitiesList2 = new List<eEntities>();
    SortingFilter sortingFilter = new SortingFilter();
    SortingOptions sortingOptions = new SortingOptions();
    SortingCamData sortingCamData = new SortingCamData();
    SortingResult sortingResult = new SortingResult();
    DialogBoxText dialogBoxText = new DialogBoxText();
    dialogBoxText.Text = AppLanguage.CadCamStatus[108];
    dialogBoxText.Caption = AppLanguage.CadCamStatus[108];
    dialogBoxText.Init("");
    int num1 = (int) dialogBoxText.ShowDialog();
    if (dialogBoxText.Result != DialogResult.OK)
    {
      clsInit.appCommand.Reset();
    }
    else
    {
      string str = dialogBoxText.Value.Trim();
      if (str.Length != 1)
      {
        buString5.MessageBoxWarning($"{AppLanguage.CadCamMessages[60]} - {str}");
        clsInit.appCommand.Reset();
      }
      else
      {
        int index1 = -1;
        int num2 = 0;
        for (int index2 = 0; index2 <= ccVars.CharLibList.Count - 1; ++index2)
        {
          if (ccVars.CharLibList[index2].Char == str)
          {
            if (!clsVar.varChar.AddEvenCharAvailable)
            {
              if (buString5.MessageBoxQuestion($"{AppLanguage.CadCamMessages[61]} - {str}") == DialogResult.Yes)
              {
                index2 = ccVars.CharLibList.Count;
                index1 = index2;
              }
              else
              {
                clsInit.appCommand.Reset();
                return;
              }
            }
            else
              ++num2;
          }
        }
        CharLibrary5 charLibrary5 = new CharLibrary5();
        charLibrary5.Char = dialogBoxText.Value;
        charLibrary5.Index = num2;
        for (int index3 = 0; index3 <= ccVars.SelectionOP.Selections.Count - 1; ++index3)
        {
          Entity refEntity = buVector5.CopyEntities(ccVars.SelectionOP.Selections[index3].SelectedEntity);
          ccVars.UndoDont = true;
          buEntity copiedEntity = (buEntity) null;
          buEntity.Copy(refEntity, ref copiedEntity);
          if (copiedEntity != null)
            charLibrary5.CharEntities.Add(copiedEntity);
        }
        if (charLibrary5.CharEntities.Count > 0)
        {
          if (index1 == -1)
            ccVars.CharLibList.Add(charLibrary5);
          else
            ccVars.CharLibList[index1] = charLibrary5;
          clsInit.appCommand.Delete(false);
          clsFiles.SaveParameter();
          clsInit.appCommand.Reset();
          this.cmdAddChar();
        }
        else
        {
          buString5.MessageBoxWarning(AppLanguage.CadCamMessages[7]);
          clsInit.appCommand.Reset();
        }
      }
    }
  }

  public void MoveDimensionEntitiesByIndex(
    ref List<buEntity> DrawEntities,
    int indexEntity,
    Point3D CatchPoint,
    double moveDX,
    double moveDY)
  {
    for (int index = 0; index <= DrawEntities.Count - 1; ++index)
    {
      if (DrawEntities[index] is buLinearDim)
      {
        buLinearDim buLinearDim = DrawEntities[index] as buLinearDim;
        if (buLinearDim.Dimension.ReSizedEntityIndex == indexEntity)
        {
          if (buCompare5.EQ(buLinearDim.ExtLine1, CatchPoint, 0.1))
          {
            buLinearDim.ExtLine1.X += moveDX;
            buLinearDim.ExtLine1.Y += moveDY;
            buLinearDim.Update(buEntityUpdateType.LinearDim);
          }
          else if (buCompare5.EQ(buLinearDim.ExtLine2, CatchPoint, 0.1))
          {
            buLinearDim.ExtLine2.X += moveDX;
            buLinearDim.ExtLine2.Y += moveDY;
            buLinearDim.Update(buEntityUpdateType.LinearDim);
          }
          buLinearDim.DimLinePosition.X += moveDX / 2.0;
          buLinearDim.DimLinePosition.Y += moveDY / 2.0;
          double num = Point3D.Distance(buLinearDim.ExtLine1, buLinearDim.ExtLine2);
          if (buLinearDim.Dimension.Type == DimensionType.Horizontal)
            num = clsInit.cVector5.DeltaX(buLinearDim.ExtLine1, buLinearDim.ExtLine2);
          if (buLinearDim.Dimension.Type == DimensionType.Vertical)
            num = clsInit.cVector5.DeltaY(buLinearDim.ExtLine1, buLinearDim.ExtLine2);
          buLinearDim.Dimension.Distance = Math.Round(num, 5);
          if (buCompare5.EQ(buLinearDim.Dimension.CatchPoint, CatchPoint, 0.1))
          {
            buLinearDim.Dimension.CatchPoint.X += moveDX;
            buLinearDim.Dimension.CatchPoint.Y += moveDY;
          }
          if (buCompare5.EQ(buLinearDim.Dimension.BasePoint, CatchPoint, 0.1))
          {
            buLinearDim.Dimension.BasePoint.X += moveDX;
            buLinearDim.Dimension.BasePoint.Y += moveDY;
          }
        }
      }
    }
  }
}
