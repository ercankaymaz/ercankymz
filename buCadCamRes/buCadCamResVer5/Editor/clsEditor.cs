// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Editor.clsEditor
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buControls.DialogBox;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using devDept;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Control.Labels;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;
using devDept.Graphics;
using ns8;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Editor;

public class clsEditor
{
  public SortbuSettings ManuelSortSetting = new SortbuSettings();
  public SortPointClickResult ManuelSortClickResult = new SortPointClickResult();
  public List<buEntity> sortRefEntities = new List<buEntity>();
  public List<buEntity> sortedEntities = new List<buEntity>();
  public int sortedEntitiesSimIndex = -1;
  public List<Pnt6DSimMove> sortedEntitiesSimPoints = new List<Pnt6DSimMove>();
  public List<List<Entity>> bufferedEntity = new List<List<Entity>>();
  public bool SimStarted = false;
  public bool DxfImported = false;
  public Timer timSim = (Timer) null;
  public List<EditorCustomData> OpenCustomData = new List<EditorCustomData>();
  public actionTypeBU action = actionTypeBU.None;
  public int? _filletChamferIndex;
  public VectorClock _clock = (VectorClock) null;
  public Tuple<ICurve, ICurve, ICurve>[] _filletsChamfers;
  public int SelectedDrawing = -1;
  public int SelectedConstraint = -1;
  public FileInfo FIZip = (FileInfo) null;

  public void Init()
  {
    this.OpenEditorFile();
    if (this.timSim != null)
      return;
    this.timSim = new Timer();
    this.timSim.Tick += new EventHandler(this.Sim_Tick);
    this.timSim.Interval = 10;
  }

  public void CreateModelControl(
    ref Sketcher2D viewport,
    string UnlockKey,
    CreateModelProperties Properties)
  {
    viewport = new Sketcher2D();
    viewport.InitializeViewports();
    viewport.CreateControl();
    viewport.CreateGraphics();
    viewport.Dock = DockStyle.Fill;
    if (Properties.Width > 0)
      viewport.Width = Properties.Width;
    if (Properties.Height > 0)
      viewport.Height = Properties.Height;
    BackgroundSettings backgroundSettings = new BackgroundSettings(backgroundStyleType.LinearGradient, Properties.BottomColor, Properties.MiddleColor, Properties.TopColor, 0.75, (Image) null, colorThemeType.Auto, 0.3);
    viewport.Viewports[0].Background = backgroundSettings;
    viewport.ActiveViewport.DisplayMode = Properties.DisplayType;
    viewport.Viewports[0].Pan.MouseButton = new MouseButton(Properties.PanMouseButtons.Button, Properties.PanMouseButtons.ModifierKey);
    viewport.Viewports[0].Rotate.MouseButton = new MouseButton(Properties.RotateMouseButtons.Button, Properties.RotateMouseButtons.ModifierKey);
    viewport.Viewports[0].Zoom.MouseButton = new MouseButton(Properties.ZoomMouseButtons.Button, Properties.ZoomMouseButtons.ModifierKey);
    viewport.Viewports[0].Camera.ProjectionMode = Properties.ProjetionType;
    viewport.Viewports[0].Grid.Visible = Properties.GridVisible;
    viewport.Viewports[0].Grid.Step = Properties.GridStepX;
    viewport.Viewports[0].OriginSymbol.Visible = Properties.OriginSymbolVisible;
    viewport.Viewports[0].Zoom.ReverseMouseWheel = Properties.ReverseMouseWheel;
    viewport.Viewports[0].OriginSymbol.LabelOrigin = "";
    viewport.Viewports[0].OriginSymbol.StyleMode = Properties.OrigineSymbol;
    viewport.Viewports[0].OriginSymbol.Size = Properties.OrigineSize;
    viewport.Viewports[0].OriginSymbol.LabelAxisX = "";
    viewport.Viewports[0].OriginSymbol.LabelAxisY = "";
    viewport.Viewports[0].OriginSymbol.LabelAxisZ = "";
    viewport.Viewports[0].OriginSymbol.EdgeColor = Color.Black;
    viewport.Viewports[0].CoordinateSystemIcon.Visible = Properties.CoordinateSystemIconVisible;
    viewport.Viewports[0].ViewCubeIcon.Visible = Properties.ViewCubeIconVisible;
    viewport.Viewports[0].ToolBar.Visible = Properties.ToolBorVisible;
  }

  public void Desing_WorkCompleted(object sender, WorkCompletedEventArgs e)
  {
    if (e.WorkUnit is ReadFileAsync)
    {
      ReadFileAsync workUnit1 = (ReadFileAsync) e.WorkUnit;
      RegenOptions ro = new RegenOptions();
      ReadFile workUnit2 = e.WorkUnit as ReadFile;
      this.DxfImported = false;
      workUnit1.OpenTo((IDesign) clsItem.frmEditor.viewport, ro);
      if (buFile5.getFileExtension(workUnit1.FilePath).ToLower() == ".dxf" | buFile5.getFileExtension(workUnit1.FilePath).ToLower() == ".dwg")
      {
        for (int index1 = 0; index1 <= clsItem.frmEditor.viewport.Entities.Count - 1; ++index1)
        {
          if (clsItem.frmEditor.viewport.Entities[index1].ColorMethod == colorMethodType.byLayer && buImage5.isColorSimilar(clsItem.frmEditor.viewport.Layers[clsItem.frmEditor.viewport.Entities[index1].LayerName].Color, Color.White, 10.0))
            clsItem.frmEditor.viewport.Layers[clsItem.frmEditor.viewport.Entities[index1].LayerName].Color = Color.Black;
          clsItem.frmEditor.viewport.Entities[index1].ColorMethod = colorMethodType.byEntity;
          if (clsItem.frmEditor.viewport.Entities[index1].ColorMethod == colorMethodType.byEntity)
          {
            clsItem.frmEditor.viewport.Entities[index1].Color = clsVar.varEditorSet.colorEntity;
            clsItem.frmEditor.viewport.Entities[index1].LineWeight = (float) clsVar.varEditorSet.thicknessEntity;
            clsItem.frmEditor.viewport.Entities[index1].LineWeightMethod = colorMethodType.byEntity;
          }
          if (clsVar.varEditorSet.DeleteIfSameEntities)
          {
            for (int index2 = index1 + 1; index2 <= clsItem.frmEditor.viewport.Entities.Count - 1; ++index2)
            {
              if (!clsItem.frmEditor.viewport.Entities[index2].Selected && clsInit.cVector5.isEntitySame(clsItem.frmEditor.viewport.Entities[index1], clsItem.frmEditor.viewport.Entities[index2]))
                clsItem.frmEditor.viewport.Entities[index2].Selected = true;
            }
          }
        }
        clsItem.frmEditor.viewport.Entities.DeleteSelected();
        clsItem.frmEditor.viewport.Entities.RegenAllCurved(0.01);
        if (Math.Abs(clsItem.frmEditor.viewport.Entities.BoxMin.Z) < double.MaxValue)
        {
          clsItem.frmEditor.viewport.Entities.Translate(0.0, 0.0, -clsItem.frmEditor.viewport.Entities.BoxMin.Z);
          clsItem.frmEditor.viewport.Entities.RegenAllCurved(0.01);
        }
        if (clsVar.varEditorSet.BreakArcIfGreat180Degree)
        {
          for (int index = 0; index <= clsItem.frmEditor.viewport.Entities.Count - 1; ++index)
          {
            if (clsItem.frmEditor.viewport.Entities[index].GetType() == typeof (Arc))
            {
              Arc entity = clsItem.frmEditor.viewport.Entities[index] as Arc;
              if (entity.AngleInDegrees > 170.0)
              {
                Entity FirstArc = (Entity) null;
                Entity SecondArc = (Entity) null;
                clsInit.cVector5.SplitArcEntitiesIfGreaterThen180Degree((Entity) entity, ref FirstArc, ref SecondArc);
                if (FirstArc != null & SecondArc != null)
                {
                  clsItem.frmEditor.viewport.Entities[index] = FirstArc;
                  clsItem.frmEditor.viewport.Entities.Add(SecondArc);
                }
              }
            }
            if (clsItem.frmEditor.viewport.Entities[index].GetType() == typeof (Circle))
            {
              Circle entity = clsItem.frmEditor.viewport.Entities[index] as Circle;
              Entity Arc1 = (Entity) null;
              Entity Arc2 = (Entity) null;
              Entity Arc3 = (Entity) null;
              Entity Arc4 = (Entity) null;
              clsInit.cVector5.CircletoFourArc(entity, ref Arc1, ref Arc2, ref Arc3, ref Arc4);
              if (Arc1 != null & Arc2 != null & Arc3 != null & Arc4 != null)
              {
                clsItem.frmEditor.viewport.Entities[index] = Arc1;
                clsItem.frmEditor.viewport.Entities.Add(Arc2);
                clsItem.frmEditor.viewport.Entities.Add(Arc3);
                clsItem.frmEditor.viewport.Entities.Add(Arc1);
              }
            }
          }
        }
        clsItem.frmEditor.viewport.ZoomFit(10);
        if (clsVar.varEditorRuntimeSet.isSewingMode && clsInit.appSewing != null)
        {
          clsInit.appSewing.cmdConvertToSewingData(clsItem.frmEditor.viewport.Entities);
          clsInit.appSewing.DrawSewingData(clsInit.appSewing.SewingBase, clsItem.frmEditor.viewport.Entities);
          clsItem.frmEditor.viewport.Invalidate();
        }
        clsItem.frmEditor.viewport.Entities.RegenAllCurved();
        clsItem.frmEditor.viewport.Invalidate();
        this.DxfImported = true;
      }
      else
        this.FileOpened();
    }
    if (e.WorkUnit is WriteFileAsyncWithTextStyles)
      this.SaveLibraryToZip();
    this.Reset();
    this.sortRefEntities.Clear();
    this.sortedEntities.Clear();
    this.ManuelSortClickResult.ResultType = SortingResultType.None;
    for (int index = 0; index <= clsItem.frmEditor.OpenCommands.Count - 1; ++index)
    {
      if (clsItem.frmEditor.OpenCommands[index].Trim() == "MoveZero")
      {
        clsItem.frmEditor.viewport.Entities.RegenAllCurved();
        if (clsItem.frmEditor.viewport.Entities.Count > 0)
          clsItem.frmEditor.viewport.Entities.Translate(-clsItem.frmEditor.viewport.Entities.BoxMin.X, -clsItem.frmEditor.viewport.Entities.BoxMin.Y, -clsItem.frmEditor.viewport.Entities.BoxMin.Z);
        clsItem.frmEditor.viewport.Entities.RegenAllCurved();
      }
      if (clsItem.frmEditor.OpenCommands[index].Trim() == "ZoomFit")
        clsItem.frmEditor.viewport.ZoomFit(5);
      if (clsItem.frmEditor.OpenCommands[index].Trim() == "SetViewTop")
        clsItem.frmEditor.viewport.SetView(viewType.Top);
      if (clsItem.frmEditor.OpenCommands[index].Trim() == "Invalidate")
        clsItem.frmEditor.viewport.Invalidate();
    }
    clsItem.frmEditor.OpenCommands.Clear();
  }

  public void cmdNew()
  {
    this.UndoBuffer();
    clsItem.frmEditor.viewport.Entities.Clear();
    clsItem.frmEditor.viewport.Invalidate();
  }

  public void cmdOpen(string FileName = "")
  {
    OpenFileDialog openFileDialog = new OpenFileDialog();
    openFileDialog.InitialDirectory = clsVar.varInterface.pathEditor;
    if (clsItem.frmEditor.OpenFileExtension.Count == 0)
    {
      for (int index = 0; index <= AppExtension.OpenFileExtension.Count - 1; ++index)
      {
        if (index == 0)
          openFileDialog.Filter = AppExtension.OpenFileExtension[index].ToString();
        else
          openFileDialog.Filter = $"{openFileDialog.Filter}|{AppExtension.OpenFileExtension[index].ToString()}";
      }
    }
    else
    {
      for (int index = 0; index <= clsItem.frmEditor.OpenFileExtension.Count - 1; ++index)
      {
        if (index == 0)
          openFileDialog.Filter = clsItem.frmEditor.OpenFileExtension[index].ToString();
        else
          openFileDialog.Filter = $"{openFileDialog.Filter}|{clsItem.frmEditor.OpenFileExtension[index].ToString()}";
      }
    }
    openFileDialog.FilterIndex = clsVar.varInterface.indexFileEditor;
    bool flag1 = true;
    bool flag2 = false;
    DialogResult dialogResult = DialogResult.None;
    if (FileName.Length > 0)
    {
      FileInfo fileInfo = new FileInfo(FileName);
      if (fileInfo.Exists)
      {
        flag2 = true;
        flag1 = false;
        openFileDialog.FileName = fileInfo.FullName;
      }
    }
    if (flag1)
      dialogResult = openFileDialog.ShowDialog();
    if (!(dialogResult == DialogResult.OK | flag2))
      return;
    this.UndoBuffer();
    if (buFile5.getFileExtension(openFileDialog.FileName).ToLower() == ".dxf" | buFile5.getFileExtension(openFileDialog.FileName).ToLower() == ".dwg")
    {
      ReadFileAsync readFileAsync = (ReadFileAsync) new ReadAutodesk(openFileDialog.FileName);
      ((ReadAutodesk) readFileAsync).ExtrudeByThickness = clsVar.varFile.ExtrudeByThickness;
      clsItem.frmEditor.viewport.Clear();
      clsItem.frmEditor.viewport.StartWork((WorkUnit) readFileAsync);
    }
    if (buFile5.getFileExtension(openFileDialog.FileName).ToLower() == ".bucadv5")
    {
      clsItem.frmEditor.viewport.Clear();
      List<Entity> refEntities = new List<Entity>();
      clsInit.appFiles.OpenBuCadFileVer5(openFileDialog.FileName, true, ref refEntities);
      for (int index = 0; index <= refEntities.Count - 1; ++index)
        clsItem.frmEditor.viewport.Entities.Add(refEntities[index]);
      clsItem.frmEditor.viewport.SetView(viewType.Top);
      clsItem.frmEditor.viewport.ZoomFit();
      clsItem.frmEditor.viewport.Invalidate();
    }
    clsVar.varInterface.indexFileEditor = openFileDialog.FilterIndex;
    clsVar.varInterface.pathEditor = buFile5.GetPath(openFileDialog.FileName);
    clsFiles.SaveParameter();
  }

  public void cmdSave()
  {
    SaveFileDialog saveFileDialog = new SaveFileDialog();
    saveFileDialog.InitialDirectory = clsVar.varInterface.pathEditor;
    if (AppExtension.SaveFileExtension.Count == 0)
      AppExtension.SaveFileExtension.Add((object) "Autocad Files (*.dxf)|*.dxf");
    for (int index = 0; index <= AppExtension.SaveFileExtension.Count - 1; ++index)
    {
      if (index == 0)
        saveFileDialog.Filter = AppExtension.SaveFileExtension[index].ToString();
      else
        saveFileDialog.Filter = $"{saveFileDialog.Filter}|{AppExtension.SaveFileExtension[index].ToString()}";
    }
    saveFileDialog.FilterIndex = clsVar.varInterface.indexFileEditor;
    if (saveFileDialog.ShowDialog() != DialogResult.OK)
      return;
    List<Entity> copiedEnt = new List<Entity>();
    buVector5.CopyEntities(clsItem.frmEditor.viewport.Entities, ref copiedEnt);
    if (clsItem.frmEditor.viewport.CurrentSketch != null && clsItem.frmEditor.viewport.CurrentSketch.Editing)
    {
      for (int index = copiedEnt.Count - 1; index >= 0; --index)
      {
        if (copiedEnt[index] is SketchEntity)
          copiedEnt.RemoveAt(index);
        else if (copiedEnt[index] is devDept.Eyeshot.Entities.Point)
          copiedEnt.RemoveAt(index);
        else if (copiedEnt[index] is Dimension)
          copiedEnt.RemoveAt(index);
      }
    }
    if (buFile5.getFileExtension(saveFileDialog.FileName).ToLower() == ".dxf" | buFile5.getFileExtension(saveFileDialog.FileName).ToLower() == ".dwg")
      buFile5.SaveDxfDwg(copiedEnt, saveFileDialog.FileName);
    if (buFile5.getFileExtension(saveFileDialog.FileName).ToLower() == ".bucadv5")
      ;
  }

  public void cmdInsert(ref List<Entity> refEntities)
  {
    OpenFileDialog openFileDialog = new OpenFileDialog();
    openFileDialog.InitialDirectory = clsVar.varInterface.pathEditor;
    if (clsItem.frmEditor.OpenFileExtension.Count == 0)
    {
      for (int index = 0; index <= AppExtension.OpenFileExtension.Count - 1; ++index)
      {
        if (index == 0)
          openFileDialog.Filter = AppExtension.OpenFileExtension[index].ToString();
        else
          openFileDialog.Filter = $"{openFileDialog.Filter}|{AppExtension.OpenFileExtension[index].ToString()}";
      }
    }
    else
    {
      for (int index = 0; index <= clsItem.frmEditor.OpenFileExtension.Count - 1; ++index)
      {
        if (index == 0)
          openFileDialog.Filter = clsItem.frmEditor.OpenFileExtension[index].ToString();
        else
          openFileDialog.Filter = $"{openFileDialog.Filter}|{clsItem.frmEditor.OpenFileExtension[index].ToString()}";
      }
    }
    openFileDialog.FilterIndex = clsVar.varInterface.indexFileEditor;
    if (openFileDialog.ShowDialog() != DialogResult.OK)
      return;
    this.UndoBuffer();
    if (buFile5.getFileExtension(openFileDialog.FileName).ToLower() == ".dxf" | buFile5.getFileExtension(openFileDialog.FileName).ToLower() == ".dwg")
    {
      refEntities = new List<Entity>();
      buFile5.OpenDxfDwg(ref refEntities, openFileDialog.FileName);
    }
    if (buFile5.getFileExtension(openFileDialog.FileName).ToLower() == ".bucadv5")
    {
      refEntities = new List<Entity>();
      clsInit.appFiles.OpenBuCadFileVer5(openFileDialog.FileName, true, ref refEntities);
    }
    clsVar.varInterface.indexFileEditor = openFileDialog.FilterIndex;
    clsVar.varInterface.pathEditor = buFile5.GetPath(openFileDialog.FileName);
    clsFiles.SaveParameter();
  }

  public void cmdOpenLib()
  {
    OpenFileDialog openFileDialog = new OpenFileDialog();
    openFileDialog.InitialDirectory = clsVar.varLibrary.pathLibrary;
    openFileDialog.Filter = "buCad/Cam Library File (*.bulib5)|*.bulib5";
    openFileDialog.FilterIndex = 1;
    if (openFileDialog.ShowDialog() != DialogResult.OK)
      return;
    buFile5.ExtractToFolder(AppPath.Base + "\\L", openFileDialog.FileName);
    List<string> Files = new List<string>();
    buFile5.getFiles(AppPath.Base + "\\L", ref Files);
    string filePath = "";
    this.OpenCustomData = new List<EditorCustomData>();
    for (int index = 0; index <= Files.Count - 1; ++index)
    {
      FileInfo fileInfo = new FileInfo(Files[index]);
      if (fileInfo.Exists)
      {
        if (fileInfo.Extension == ".buLibEye")
          filePath = fileInfo.FullName;
        if (fileInfo.Extension == ".buLibSet")
          this.OpenEditorCustomDataToFile(fileInfo.FullName, ref this.OpenCustomData);
      }
    }
    if (filePath.Length <= 0)
      return;
    ReadFile readFile = new ReadFile(filePath);
    clsItem.frmEditor.viewport.Clear();
    clsItem.frmEditor.viewport.StartWork((WorkUnit) readFile);
  }

  public void cmdSaveLib(Design Viewport)
  {
    SaveFileDialog saveFileDialog = new SaveFileDialog();
    saveFileDialog.InitialDirectory = clsVar.varLibrary.pathLibrary;
    saveFileDialog.Filter = "buCad/Cam Library File (*.bulib5)|*.bulib5";
    saveFileDialog.FilterIndex = 1;
    if (saveFileDialog.ShowDialog((IWin32Window) clsItem.frmEditor) != DialogResult.OK)
      return;
    for (int index = 0; index <= Viewport.Entities.Count - 1; ++index)
    {
      if (Viewport.Entities[index] is SketchEntity)
      {
        (Viewport.Entities[index] as SketchEntity).Exit();
        Viewport.Entities.Regen();
        Viewport.Invalidate();
        FileInfo fileInfo1 = new FileInfo(saveFileDialog.FileName);
        string withoutExtension = buFile5.getFileNameWithoutExtension(saveFileDialog.FileName);
        DirectoryInfo directoryInfo = new DirectoryInfo($"{fileInfo1.DirectoryName}\\{withoutExtension}");
        if (directoryInfo.Exists)
          directoryInfo.Delete(true);
        Directory.CreateDirectory(directoryInfo.FullName);
        FileInfo fileInfo2 = new FileInfo($"{directoryInfo.FullName}\\{withoutExtension}.buLibEye");
        FileInfo fileInfo3 = new FileInfo($"{directoryInfo.FullName}\\{withoutExtension}.buLibSet");
        this.FIZip = new FileInfo(saveFileDialog.FileName);
        this.SaveEditorCustomDataToFile(Viewport, fileInfo3.FullName);
        WriteFile writeFile = new WriteFile(new WriteFileParams(Viewport.Document), fileInfo2.FullName);
        Viewport.StartWork((WorkUnit) writeFile);
      }
    }
  }

  public void cmdDeleteEntity(Entity Ent)
  {
    if (!clsItem.frmEditor.viewport.CurrentSketch.IsSketchEntity())
      clsItem.frmEditor.viewport.CurrentSketch.DeleteConstraint(Ent);
    else
      clsItem.frmEditor.viewport.CurrentSketch.DeleteEntity(Ent);
    clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
    clsItem.frmEditor.viewport.Invalidate();
  }

  public void cmdUndo()
  {
    Class5.smethod_219(new clsEditor.Delegate3(clsItem.frmEditor.viewport.CurrentSketch.Undo), this);
  }

  public void cmdRedo()
  {
    Class5.smethod_219(new clsEditor.Delegate3(clsItem.frmEditor.viewport.CurrentSketch.Redo), this);
  }

  public void cmdShowContrraint(bool Show)
  {
    foreach (devDept.Eyeshot.Control.Labels.Label label in (EyeshotCollection<devDept.Eyeshot.Control.Labels.Label>) clsItem.frmEditor.viewport.ActiveViewport.Labels)
    {
      if (label is StackedLabel)
        (label as StackedLabel).Visible = Show;
    }
    clsItem.frmEditor.viewport.Invalidate();
  }

  public void cmdShowDimension(bool Show)
  {
    foreach (Entity entity in (EyeshotCollection<Entity>) clsItem.frmEditor.viewport.Entities)
    {
      if (entity is Dimension)
        entity.Visible = Show;
    }
    clsItem.frmEditor.viewport.Invalidate();
  }

  public void cmdEventsMove()
  {
    this.ShowValueArea(false);
    Sketcher2D.Clicks.Clear();
    clsInit.appEditor.action = actionTypeBU.eventMove;
    Sketcher2D.entitiesSelected.Clear();
    clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, false, ref Sketcher2D.entitiesSelected);
    if (Sketcher2D.entitiesSelected.Count == 0)
    {
      clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[10], buLangTranslate.preDef.Move);
      Sketcher2D.selectionProcess = true;
    }
    else
    {
      clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[0], buLangTranslate.preDef.Move);
      Sketcher2D.selectionProcess = false;
    }
  }

  public void cmdEventsCopy()
  {
    this.ShowValueArea(false);
    Sketcher2D.Clicks.Clear();
    clsInit.appEditor.action = actionTypeBU.eventCopy;
    Sketcher2D.entitiesSelected.Clear();
    clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, false, ref Sketcher2D.entitiesSelected);
    if (Sketcher2D.entitiesSelected.Count == 0)
    {
      clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[10], buLangTranslate.preDef.Copy);
      Sketcher2D.selectionProcess = true;
    }
    else
    {
      clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[0], buLangTranslate.preDef.Copy);
      Sketcher2D.selectionProcess = false;
    }
  }

  public void cmdEventsMirror()
  {
    this.ShowValueArea(false);
    Sketcher2D.Clicks.Clear();
    clsInit.appEditor.action = actionTypeBU.eventMirror;
    Sketcher2D.entitiesSelected.Clear();
    clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, false, ref Sketcher2D.entitiesSelected);
    if (Sketcher2D.entitiesSelected.Count == 0)
    {
      clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[10], buLangTranslate.preDef.Mirror);
      Sketcher2D.selectionProcess = true;
    }
    else
    {
      clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[122], buLangTranslate.preDef.Mirror);
      Sketcher2D.selectionProcess = false;
    }
  }

  public void cmdEventsOffset()
  {
    this.ShowValueArea(true, buLangTranslate.preDef.Offset, clsVar.varEditorRuntimeSet.OffsetValue);
    Sketcher2D.Clicks.Clear();
    clsInit.appEditor.action = actionTypeBU.eventOffset;
    Sketcher2D.entitiesSelected.Clear();
    clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, false, ref Sketcher2D.entitiesSelected);
    if (Sketcher2D.entitiesSelected.Count == 0)
    {
      clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[10], buLangTranslate.preDef.Offset);
      Sketcher2D.selectionProcess = true;
    }
    else
    {
      clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[33], buLangTranslate.preDef.Offset);
      Sketcher2D.selectionProcess = false;
    }
  }

  public void cmdEventsRotate()
  {
    this.ShowValueArea(false);
    Sketcher2D.Clicks.Clear();
    clsInit.appEditor.action = actionTypeBU.eventRotate;
    Sketcher2D.entitiesSelected.Clear();
    clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, false, ref Sketcher2D.entitiesSelected);
    if (Sketcher2D.entitiesSelected.Count == 0)
    {
      clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[10], buLangTranslate.preDef.Rotate);
      Sketcher2D.selectionProcess = true;
    }
    else
    {
      clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[20], buLangTranslate.preDef.Rotate);
      Sketcher2D.selectionProcess = false;
    }
  }

  public void cmdEventsBreak()
  {
    this.ShowValueArea(false);
    Sketcher2D.Clicks.Clear();
    clsInit.appEditor.action = actionTypeBU.eventBreak;
    Sketcher2D.entitiesSelected.Clear();
    clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[36], buLangTranslate.preDef.Break);
    Sketcher2D.selectionProcess = false;
  }

  public void cmdEventsScale()
  {
    this.ShowValueArea(true, buLangTranslate.preDef.Scale, clsVar.varEditorRuntimeSet.ScaleRatio);
    Sketcher2D.Clicks.Clear();
    clsInit.appEditor.action = actionTypeBU.eventScale;
    Sketcher2D.entitiesSelected.Clear();
    clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, false, ref Sketcher2D.entitiesSelected);
    if (Sketcher2D.entitiesSelected.Count == 0)
    {
      clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[10], buLangTranslate.preDef.Scale);
      Sketcher2D.selectionProcess = true;
    }
    else
    {
      clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[31 /*0x1F*/], buLangTranslate.preDef.Scale);
      Sketcher2D.selectionProcess = false;
    }
  }

  public void cmdEventsExtend()
  {
    this.ShowValueArea(true, buLangTranslate.preDef.Offset, clsVar.varEditorRuntimeSet.ExtendLength, -10000000.0);
    Sketcher2D.Clicks.Clear();
    clsInit.appEditor.action = actionTypeBU.eventExtend;
    Sketcher2D.entitiesSelected.Clear();
    clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[34], buLangTranslate.preDef.Extend);
    Sketcher2D.selectionProcess = false;
  }

  public void cmdEventsTrim()
  {
    this.ShowValueArea(false);
    Sketcher2D.Clicks.Clear();
    clsInit.appEditor.action = actionTypeBU.eventTrim;
    Sketcher2D.entitiesSelected.Clear();
    clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[35], buLangTranslate.preDef.Trim);
    Sketcher2D.selectionProcess = false;
  }

  public void cmdEventsFillet()
  {
    this.ShowValueArea(true, buLangTranslate.preDef.Fillet, clsVar.varEditorRuntimeSet.FilletRadius);
    Sketcher2D.Clicks.Clear();
    clsInit.appEditor.action = actionTypeBU.eventFillet;
    Sketcher2D.entitiesSelected.Clear();
    clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[124], buLangTranslate.preDef.Fillet);
    Sketcher2D.selectionProcess = false;
  }

  public void cmdEventsChamfer()
  {
    this.ShowValueArea(true, buLangTranslate.preDef.Chamfer, clsVar.varEditorRuntimeSet.ChamferLength);
    Sketcher2D.Clicks.Clear();
    clsInit.appEditor.action = actionTypeBU.eventChamfer;
    Sketcher2D.entitiesSelected.Clear();
    clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[124], buLangTranslate.preDef.Chamfer);
    Sketcher2D.selectionProcess = false;
  }

  public void cmdEventsDelete()
  {
    this.ShowValueArea(false);
    Sketcher2D.Clicks.Clear();
    clsInit.appEditor.action = actionTypeBU.eventDelete;
    Sketcher2D.entitiesSelected.Clear();
    clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, false, ref Sketcher2D.entitiesSelected);
    if (Sketcher2D.entitiesSelected.Count == 0)
    {
      clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[10], buLangTranslate.preDef.Move);
      Sketcher2D.selectionProcess = true;
    }
    else
    {
      clsItem.frmEditor.viewport.Entities.DeleteSelected();
      clsItem.frmEditor.viewport.Invalidate();
      clsInit.appEditor.Reset();
    }
  }

  public void cmdEventsAlingLeft(AlignmentEvent Type)
  {
    this.ShowValueArea(false);
    if (Type == AlignmentEvent.Left)
      clsInit.appEditor.action = actionTypeBU.eventAlingLeft;
    if (Type == AlignmentEvent.Right)
      clsInit.appEditor.action = actionTypeBU.eventAlingRight;
    if (Type == AlignmentEvent.Top)
      clsInit.appEditor.action = actionTypeBU.eventAlingTop;
    if (Type == AlignmentEvent.Bottom)
      clsInit.appEditor.action = actionTypeBU.eventAlingBottom;
    if (Type == AlignmentEvent.HorizontalCenter)
      clsInit.appEditor.action = actionTypeBU.eventAlingHorizontal;
    if (Type == AlignmentEvent.VerticalCenter)
      clsInit.appEditor.action = actionTypeBU.eventAlingVertical;
    Sketcher2D.isAreaSelection = true;
    Sketcher2D.Clicks.Clear();
    Sketcher2D.entitiesSelected.Clear();
    Sketcher2D.selectedIndex.Clear();
    clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[10], buLangTranslate.preDef.Move);
    Sketcher2D.selectionProcess = true;
  }

  public void cmdEventsEqualDistance(EqualDistance Type)
  {
    this.ShowValueArea(true, buLangTranslate.preDef.Distance, clsVar.varEditorRuntimeSet.EqualDistance);
    if (Type == EqualDistance.Horizontal)
      clsInit.appEditor.action = actionTypeBU.eventEqualHorizontal;
    if (Type == EqualDistance.Vertical)
      clsInit.appEditor.action = actionTypeBU.eventEqualVertical;
    Sketcher2D.isAreaSelection = true;
    Sketcher2D.Clicks.Clear();
    Sketcher2D.entitiesSelected.Clear();
    Sketcher2D.selectedIndex.Clear();
    clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[10], buLangTranslate.preDef.Move);
    Sketcher2D.selectionProcess = true;
  }

  public void cmdEventsRotateValue(double Degree)
  {
    clsVar.varEditorRuntimeSet.LastRotateAngle = Degree;
    Sketcher2D.Clicks.Clear();
    clsInit.appEditor.action = actionTypeBU.eventRotateValue;
    Sketcher2D.entitiesSelected.Clear();
    clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, false, ref Sketcher2D.entitiesSelected);
    if (Sketcher2D.entitiesSelected.Count == 0)
    {
      clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[10], buLangTranslate.preDef.Rotate);
      Sketcher2D.selectionProcess = true;
    }
    else
      this.Rotate(Degree);
  }

  public void cmdEventsMirrorValue(HorizontalVertical Value)
  {
    clsVar.varEditorRuntimeSet.LastMirrorType = Value;
    Sketcher2D.Clicks.Clear();
    clsInit.appEditor.action = actionTypeBU.eventMirrorValue;
    Sketcher2D.entitiesSelected.Clear();
    clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, false, ref Sketcher2D.entitiesSelected);
    if (Sketcher2D.entitiesSelected.Count == 0)
    {
      clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[10], buLangTranslate.preDef.Mirror);
      Sketcher2D.selectionProcess = true;
    }
    else
      this.Mirror(Value);
  }

  public void cmdEventsTurnOver()
  {
    this.ShowCheckArea(true, clsVar.varEditorRuntimeSet.TurnOverCenter, buLangTranslate.preDef.Center);
    this.ShowValueArea(true, buLangTranslate.preDef.Distance, clsVar.varEditorRuntimeSet.TurnOverDistance);
    Sketcher2D.Clicks.Clear();
    clsInit.appEditor.action = actionTypeBU.eventTurnOver;
    Sketcher2D.entitiesSelected.Clear();
    clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, false, ref Sketcher2D.entitiesSelected);
    if (Sketcher2D.entitiesSelected.Count == 0)
    {
      clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[10], buLangTranslate.preDef.TurnOver);
      Sketcher2D.selectionProcess = true;
    }
    else
      this.TurnOver();
  }

  public void StatusUpdate(string Message, string Command, string Args = "")
  {
    string str = "";
    if (Command.Length > 0)
      str = Command + " : ";
    clsItem.frmEditor.status_message.Text = $"{str}{Message} {Args}";
  }

  public void cmdSimStart()
  {
    this.SimStarted = true;
    this.CreateSimPointsFromSortedEntities();
    if (clsInit.appEditor.sortedEntitiesSimIndex == -1)
      clsInit.appEditor.sortedEntitiesSimIndex = 0;
    this.timSim.Enabled = true;
  }

  public void cmdSimStop()
  {
    if (this.SimStarted)
    {
      this.timSim.Enabled = false;
      this.SimStarted = false;
    }
    else
    {
      this.sortedEntitiesSimIndex = -1;
      this.RemoveSimArrow();
    }
  }

  public void cmdSimFwd() => this.Sim_Tick((object) null, (EventArgs) null);

  public void cmdSimBwd()
  {
    this.sortedEntitiesSimIndex -= clsVar.varEditorSet.SimulationStep;
    this.sortedEntitiesSimIndex -= clsVar.varEditorSet.SimulationStep;
    this.Sim_Tick((object) null, (EventArgs) null);
  }

  public void Sim_Tick(object sender, EventArgs e)
  {
    if (this.sortedEntitiesSimIndex >= 0 & this.sortedEntitiesSimIndex <= this.sortedEntitiesSimPoints.Count - 1)
    {
      if (clsItem.frmEditor.viewport.Entities.Count > 0)
      {
        Entity entity1 = clsItem.frmEditor.viewport.Entities[clsItem.frmEditor.viewport.Entities.Count - 1];
        if (entity1.EntityData != null & entity1.EntityData is CustomData && (entity1.EntityData as CustomData).typeDefination == entityTypeDefination.Tool)
          clsItem.frmEditor.viewport.Entities.RemoveAt(clsItem.frmEditor.viewport.Entities.Count - 1);
        Entity entity2 = clsItem.frmEditor.viewport.Entities[clsItem.frmEditor.viewport.Entities.Count - 1];
        if (entity2.EntityData != null & entity2.EntityData is CustomData && (entity2.EntityData as CustomData).typeDefination == entityTypeDefination.Tool)
          clsItem.frmEditor.viewport.Entities.RemoveAt(clsItem.frmEditor.viewport.Entities.Count - 1);
        Pnt6DSimMove entitiesSimPoint = this.sortedEntitiesSimPoints[this.sortedEntitiesSimIndex];
        LinearPath outer = new LinearPath((ICollection<Point3D>) new List<Point3D>()
        {
          new Point3D(entitiesSimPoint.X, entitiesSimPoint.Y, 0.0),
          new Point3D(entitiesSimPoint.X + 80.0, entitiesSimPoint.Y + 20.0, 0.0),
          new Point3D(entitiesSimPoint.X + 80.0, entitiesSimPoint.Y - 20.0, 0.0),
          new Point3D(entitiesSimPoint.X, entitiesSimPoint.Y, 0.0)
        });
        outer.Rotate(buConversion5.DegreeToRadian(entitiesSimPoint.C + 180.0), Vector3D.AxisZ, new Point3D(entitiesSimPoint.X, entitiesSimPoint.Y, 0.0));
        Mesh mesh = new devDept.Eyeshot.Entities.Region((ICurve) outer, Plane.XY, true).ExtrudeAsMesh(5.0, 0.1, Mesh.natureType.RichSmooth);
        mesh.EntityData = (object) new CustomData()
        {
          typeDefination = entityTypeDefination.Tool
        };
        clsItem.frmEditor.viewport.Entities.Add((Entity) mesh);
        Text text = new Text(Plane.XY, new Point3D(entitiesSimPoint.X, entitiesSimPoint.Y - 6.0, entitiesSimPoint.Z), entitiesSimPoint.C.ToString("f1"), 20.0);
        text.EntityData = (object) new CustomData()
        {
          typeDefination = entityTypeDefination.Tool
        };
        text.Color = Color.Red;
        text.ColorMethod = colorMethodType.byEntity;
        clsItem.frmEditor.viewport.Entities.Add((Entity) text);
        if (clsVar.varEditorSet.SimulationStep <= 0)
          clsVar.varEditorSet.SimulationStep = 1;
        this.sortedEntitiesSimIndex += clsVar.varEditorSet.SimulationStep;
      }
    }
    else
    {
      this.sortedEntitiesSimIndex = 0;
      this.timSim.Enabled = false;
      this.RemoveSimArrow();
    }
    clsItem.frmEditor.viewport.Invalidate();
  }

  public void CreateSimPointsFromSortedEntities()
  {
    if (clsVar.varEditorSet.SimulationDevideLength <= 0.1)
      clsVar.varEditorSet.SimulationDevideLength = 5.0;
    List<Point3D> Points = new List<Point3D>();
    List<Point3D> point3DList = new List<Point3D>();
    this.sortedEntitiesSimPoints.Clear();
    clsInit.cVector5.EntitiesToPointsWithCamDirection(this.sortedEntities, 0.01, ref Points);
    clsInit.cVector5.DevidePointsByLength(Points, clsVar.varEditorSet.SimulationDevideLength, ref point3DList);
    clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref point3DList);
    for (int index = 0; index <= point3DList.Count - 1; ++index)
    {
      if (index == 0)
      {
        double c = clsInit.cVector5.PointAngle(point3DList[1], point3DList[0]);
        this.sortedEntitiesSimPoints.Add(new Pnt6DSimMove(point3DList[0].X, point3DList[0].Y, point3DList[0].Z, 0.0, 0.0, c));
      }
      else
      {
        double c1 = this.sortedEntitiesSimPoints[this.sortedEntitiesSimPoints.Count - 1].C;
        double c2 = clsInit.cVector5.PointAngle(point3DList[index], point3DList[index - 1]);
        double num = c2 - c1;
        if (num < -180.0)
          c2 += 360.0;
        else if (num > 180.0)
          c2 -= 360.0;
        if (Math.Abs(c2 - c1) > 20.0)
          this.sortedEntitiesSimPoints.Add(new Pnt6DSimMove(point3DList[index - 1].X, point3DList[index - 1].Y, point3DList[index - 1].Z, 0.0, 0.0, c2));
        this.sortedEntitiesSimPoints.Add(new Pnt6DSimMove(point3DList[index].X, point3DList[index].Y, point3DList[index].Z, 0.0, 0.0, c2));
      }
    }
  }

  public void RemoveSimArrow()
  {
    Entity entity1 = clsItem.frmEditor.viewport.Entities[clsItem.frmEditor.viewport.Entities.Count - 1];
    if (entity1.EntityData != null & entity1.EntityData is CustomData && (entity1.EntityData as CustomData).typeDefination == entityTypeDefination.Tool)
      clsItem.frmEditor.viewport.Entities.RemoveAt(clsItem.frmEditor.viewport.Entities.Count - 1);
    Entity entity2 = clsItem.frmEditor.viewport.Entities[clsItem.frmEditor.viewport.Entities.Count - 1];
    if (entity2.EntityData != null & entity2.EntityData is CustomData && (entity2.EntityData as CustomData).typeDefination == entityTypeDefination.Tool)
      clsItem.frmEditor.viewport.Entities.RemoveAt(clsItem.frmEditor.viewport.Entities.Count - 1);
    clsItem.frmEditor.viewport.Invalidate();
  }

  public void AddPoint(UClick start)
  {
    if (clsVar.varEditorRuntimeSet.isSketchMode)
    {
      devDept.Eyeshot.Entities.Point point = clsItem.frmEditor.viewport.CurrentSketch.AddPoint(start.Position);
      if (start.Entity != null)
      {
        double t = 0.0;
        ((ICurve) start.Entity).ClosestPointTo(new Point3D(start.Position.X, start.Position.Y), out t);
        clsItem.frmEditor.viewport.CurrentSketch.AddConstraintPointAt(point, start.Entity, 0.5);
        clsItem.frmEditor.viewport.CurrentSketch.AddConstraintPointOn(point, start.Entity);
      }
      clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
      this.JobUpdate();
    }
    else
    {
      this.UndoBuffer();
      devDept.Eyeshot.Entities.Point point = new devDept.Eyeshot.Entities.Point(new Point3D(start.Position.X, start.Position.Y));
      point.ColorMethod = colorMethodType.byEntity;
      point.Color = clsVar.varEditorSet.colorEntity;
      point.LineWeight = (float) clsVar.varEditorSet.thicknessEntityPoint;
      point.LineWeightMethod = colorMethodType.byEntity;
      clsItem.frmEditor.viewport.Entities.Add((Entity) point);
    }
  }

  public Line AddLine(UClick start, UClick end)
  {
    Line line1;
    if (clsVar.varEditorRuntimeSet.isSketchMode)
    {
      Line line_0 = clsItem.frmEditor.viewport.CurrentSketch.AddLine(start.Position, end.Position);
      if (start.Entity != null)
        clsItem.frmEditor.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditor.viewport.CurrentSketch.StartPoint((ICurve) line_0), start.Entity);
      if (end.Entity != null)
        clsItem.frmEditor.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditor.viewport.CurrentSketch.EndPoint((ICurve) line_0), end.Entity);
      if ((start.Entity == null ? 1 : (end.Entity == null ? 1 : 0)) != 0)
        Class5.smethod_126(this, line_0);
      clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
      this.JobUpdate();
      line1 = line_0;
    }
    else
    {
      switch (SewingTempVars.DrawCommand)
      {
        case SewingDrawCommand.LineJump:
          if (clsInit.appSewing != null)
          {
            clsInit.appSewing.AddLineJump(new Point3D(start.Position.X, start.Position.Y), new Point3D(end.Position.X, end.Position.Y));
            clsInit.appSewing.DrawSewingData(clsInit.appSewing.SewingBase, clsItem.frmEditor.viewport.Entities);
            this.Reset();
          }
          line1 = (Line) null;
          break;
        case SewingDrawCommand.LineStitched:
          if (clsInit.appSewing != null)
          {
            clsInit.appSewing.AddLineStitch(new Point3D(start.Position.X, start.Position.Y), new Point3D(end.Position.X, end.Position.Y));
            clsInit.appSewing.DrawSewingData(clsInit.appSewing.SewingBase, clsItem.frmEditor.viewport.Entities);
            this.Reset();
          }
          line1 = (Line) null;
          break;
        default:
          this.UndoBuffer();
          Line line2 = new Line(new Point3D(start.Position.X, start.Position.Y), new Point3D(end.Position.X, end.Position.Y));
          line2.ColorMethod = colorMethodType.byEntity;
          line2.Color = clsVar.varEditorSet.colorEntity;
          line2.LineWeight = (float) clsVar.varEditorSet.thicknessEntity;
          line2.LineWeightMethod = colorMethodType.byEntity;
          clsItem.frmEditor.viewport.Entities.Add((Entity) line2);
          line1 = line2;
          break;
      }
    }
    return line1;
  }

  public void AddRectangle(UClick start, UClick end)
  {
    if (clsVar.varEditorRuntimeSet.isSketchMode)
    {
      Point2D position1 = start.Position;
      Point2D position2 = end.Position;
      double width = Math.Abs(position1.X - position2.X);
      double height = Math.Abs(position1.Y - position2.Y);
      double x = Math.Min(position1.X, position2.X);
      double y = Math.Min(position1.Y, position2.Y);
      Entity[] entity_1 = clsItem.frmEditor.viewport.CurrentSketch.AddRectangle(x, y, width, height, lengthConstraints: false);
      int int_0;
      int int_1;
      Class5.smethod_72(ref int_0, position2, position1, out int_1, this);
      Class5.smethod_17(start.Entity, entity_1, int_1, this);
      Class5.smethod_17(end.Entity, entity_1, int_0, this);
      clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
      this.Reset();
      this.JobUpdate();
    }
    else
    {
      this.UndoBuffer();
      Point2D position3 = start.Position;
      Point2D position4 = end.Position;
      double width = Math.Abs(position3.X - position4.X);
      double height = Math.Abs(position3.Y - position4.Y);
      CompositeCurve rectangle = CompositeCurve.CreateRectangle(Math.Min(position3.X, position4.X), Math.Min(position3.Y, position4.Y), width, height);
      rectangle.ColorMethod = colorMethodType.byEntity;
      rectangle.Color = clsVar.varEditorSet.colorEntity;
      rectangle.LineWeight = (float) clsVar.varEditorSet.thicknessEntity;
      rectangle.LineWeightMethod = colorMethodType.byEntity;
      clsItem.frmEditor.viewport.Entities.Add((Entity) rectangle);
      this.Reset();
    }
  }

  public void AddEllipse(UClick start, UClick end)
  {
    if (clsVar.varEditorRuntimeSet.isSketchMode)
    {
      UClick uclick = start;
      Point2D position = uclick.Position;
      double radiusX = position.DistanceTo(new Point2D(end.Position.X, position.Y));
      double radiusY = position.DistanceTo(new Point2D(position.X, end.Position.Y));
      if ((radiusX <= 0.001 ? 0 : (radiusY > 0.001 ? 1 : 0)) != 0)
      {
        Ellipse ellipse = clsItem.frmEditor.viewport.CurrentSketch.AddEllipse(position, radiusX, radiusY);
        if (uclick.Entity != null)
          clsItem.frmEditor.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditor.viewport.CurrentSketch.CenterPoint(ellipse), uclick.Entity);
      }
      clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
      this.Reset();
      this.JobUpdate();
    }
    else
    {
      this.UndoBuffer();
      Point2D position = start.Position;
      double rx = position.DistanceTo(new Point2D(end.Position.X, position.Y));
      double ry = position.DistanceTo(new Point2D(position.X, end.Position.Y));
      if ((rx <= 0.001 ? 0 : (ry > 0.001 ? 1 : 0)) != 0)
      {
        Ellipse ellipse = new Ellipse(Plane.XY, position, rx, ry);
        ellipse.ColorMethod = colorMethodType.byEntity;
        ellipse.Color = clsVar.varEditorSet.colorEntity;
        ellipse.LineWeight = (float) clsVar.varEditorSet.thicknessEntity;
        ellipse.LineWeightMethod = colorMethodType.byEntity;
        clsItem.frmEditor.viewport.Entities.Add((Entity) ellipse);
      }
      this.Reset();
    }
  }

  public void AddPolygon(UClick start, UClick end)
  {
    if (clsVar.varEditorRuntimeSet.isSketchMode)
    {
      Vector2D asVector1 = (end.Position - start.Position).AsVector;
      Vector2D asVector2 = (Vector2D.AxisX - start.Position).AsVector;
      asVector1.Normalize();
      asVector2.Normalize();
      double angle = Vector2D.SignedAngleBetween(Vector2D.AxisX, asVector1);
      devDept.Eyeshot.Entities.Point polygonCenter;
      devDept.Eyeshot.Entities.Point firstPolygonVertex;
      clsItem.frmEditor.viewport.CurrentSketch.AddPolygon(start.Position, start.Position.DistanceTo(end.Position), clsVar.varEditorRuntimeSet.PolygonSide, out polygonCenter, out firstPolygonVertex, angle);
      if (start.Entity != null)
        clsItem.frmEditor.viewport.CurrentSketch.AddConstraintJoin(polygonCenter, start.Entity);
      if (end.Entity != null)
        clsItem.frmEditor.viewport.CurrentSketch.AddConstraintJoin(firstPolygonVertex, end.Entity);
      clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
      this.Reset();
      this.JobUpdate();
    }
    else
    {
      this.UndoBuffer();
      List<Pnt3D> Vertices = new List<Pnt3D>();
      clsInit.cVector.PolygonCenter(new Pnt3D(start.Position.X, start.Position.Y), new Pnt3D(end.Position.X, end.Position.Y), clsVar.varEditorRuntimeSet.PolygonSide, new WorkPlane(planeType.XY, 1), ref Vertices);
      List<Point3D> CopiedPnt = new List<Point3D>();
      buConversion5.Pnt3DToPoint3D(Vertices, ref CopiedPnt);
      CompositeCurve compositeCurve = new CompositeCurve((ICurve) new LinearPath((ICollection<Point3D>) CopiedPnt));
      compositeCurve.ColorMethod = colorMethodType.byEntity;
      compositeCurve.Color = clsVar.varEditorSet.colorEntity;
      compositeCurve.LineWeightMethod = colorMethodType.byEntity;
      compositeCurve.LineWeight = (float) clsVar.varEditorSet.thicknessEntity;
      clsItem.frmEditor.viewport.Entities.Add((Entity) compositeCurve);
      this.Reset();
    }
  }

  public void AddKeyHole(UClick start)
  {
    if (clsVar.varEditorRuntimeSet.isSketchMode)
    {
      this.Reset();
      this.JobUpdate();
    }
    else
    {
      this.UndoBuffer();
      buArc HeadArc = new buArc();
      buArc TaleArc = new buArc();
      buLine FirstLine = new buLine();
      buLine SecondLine = new buLine();
      clsInit.cVector5.KeyHole(new Point3D(start.Position.X, start.Position.Y), clsVar.varEditorRuntimeSet.KeyHoleHeadDiameter / 2.0, clsVar.varEditorRuntimeSet.KeyHoleWidth / 2.0, clsVar.varEditorRuntimeSet.KeyHoleLength, clsVar.varEditorRuntimeSet.KeyHoleAngle, false, Plane.XY, ref HeadArc, ref TaleArc, ref FirstLine, ref SecondLine);
      List<buEntity> RefEntities = new List<buEntity>();
      if (HeadArc.Vertices.Count > 0)
        RefEntities.Add((buEntity) HeadArc);
      if (FirstLine.Vertices.Count > 0)
        RefEntities.Add((buEntity) FirstLine);
      if (TaleArc.Vertices.Count > 0)
        RefEntities.Add((buEntity) TaleArc);
      if (SecondLine.Vertices.Count > 0)
        RefEntities.Add((buEntity) SecondLine);
      clsInit.cVector5.SplitArcEntitiesIfGreaterThen180Degree(ref RefEntities, 150.0);
      buCompositeCurve calcCompositeCurve = (buCompositeCurve) null;
      clsInit.cVector5.CreateCompositeCurveFromEntities(RefEntities, ref calcCompositeCurve);
      Entity copiedEntity = (Entity) null;
      buEntity.Copy((buEntity) calcCompositeCurve, ref copiedEntity);
      if (copiedEntity != null)
      {
        copiedEntity.ColorMethod = colorMethodType.byEntity;
        copiedEntity.Color = clsVar.varEditorSet.colorEntity;
        copiedEntity.LineWeightMethod = colorMethodType.byEntity;
        copiedEntity.LineWeight = (float) clsVar.varEditorSet.thicknessEntity;
        clsItem.frmEditor.viewport.Entities.Add(copiedEntity);
      }
      this.Reset();
    }
  }

  public void AddSLot(UClick first, UClick second, UClick third)
  {
    if (clsVar.varEditorRuntimeSet.isSketchMode)
    {
      Point2D position1 = first.Position;
      Point2D position2 = second.Position;
      Point2D position3 = third.Position;
      Entity[] entityArray = clsItem.frmEditor.viewport.CurrentSketch.AddSlot(position1.X, position1.Y, position1.DistanceTo(position2), this.SlotRad(position1, position2, position3), (position2 - position1).AsVector.Angle);
      Circle circle1 = entityArray[3] as Circle;
      Circle circle2 = entityArray[1] as Circle;
      if (first.Entity != null)
        clsItem.frmEditor.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditor.viewport.CurrentSketch.CenterPoint(circle1), first.Entity);
      if (second.Entity != null)
        clsItem.frmEditor.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditor.viewport.CurrentSketch.CenterPoint(circle2), second.Entity);
      clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
      this.Reset();
      this.JobUpdate();
    }
    else
    {
      this.UndoBuffer();
      Point2D position4 = first.Position;
      Point2D position5 = second.Position;
      Point2D position6 = third.Position;
      CompositeCurve slot = CompositeCurve.CreateSlot(position4.X, position4.Y, position4.DistanceTo(position5), this.SlotRad(position4, position5, position6), (position5 - position4).AsVector.Angle);
      slot.ColorMethod = colorMethodType.byEntity;
      slot.Color = clsVar.varEditorSet.colorEntity;
      slot.LineWeight = (float) clsVar.varEditorSet.thicknessEntity;
      slot.LineWeightMethod = colorMethodType.byEntity;
      clsItem.frmEditor.viewport.Entities.Add((Entity) slot);
    }
  }

  public void AddSpline(devDept.Eyeshot.Entities.Point _firstPoint, List<UClick> Clicks)
  {
    if (clsVar.varEditorRuntimeSet.isSketchMode)
    {
      if ((_firstPoint == null ? 0 : (_firstPoint != Clicks[0].Entity ? 1 : 0)) != 0)
        clsItem.frmEditor.viewport.CurrentSketch.DeleteEntity((Entity) _firstPoint);
      if (Clicks.Count <= 2)
        return;
      Curve[] source = clsItem.frmEditor.viewport.CurrentSketch.AddSpline((IList<Point2D>) Clicks.Select<UClick, Point2D>((Func<UClick, Point2D>) (uclick_0 => uclick_0.Position)).ToList<Point2D>());
      for (int index = 0; index < source.Length; ++index)
      {
        devDept.Eyeshot.Entities.Point p = clsItem.frmEditor.viewport.CurrentSketch.StartPoint((ICurve) source[index]);
        if (Clicks[index].Entity != null)
          clsItem.frmEditor.viewport.CurrentSketch.AddConstraintJoin(p, Clicks[index].Entity);
      }
      UClick uclick = Clicks.Last<UClick>();
      if ((uclick.Entity == null ? 0 : (uclick.Entity != _firstPoint ? 1 : 0)) != 0)
      {
        devDept.Eyeshot.Entities.Point p = clsItem.frmEditor.viewport.CurrentSketch.EndPoint((ICurve) ((IEnumerable<Curve>) source).Last<Curve>());
        clsItem.frmEditor.viewport.CurrentSketch.AddConstraintJoin(p, uclick.Entity);
      }
      clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
      this.Reset();
      this.JobUpdate();
    }
    else
    {
      if (Clicks.Count <= 2)
        return;
      this.UndoBuffer();
      List<Point3D> Q = new List<Point3D>();
      for (int index = 0; index <= Clicks.Count - 1; ++index)
        Q.Add(new Point3D(Clicks[index].Position.X, Clicks[index].Position.Y));
      Curve curve = Curve.CubicSplineInterpolation<Point3D>((IList<Point3D>) Q);
      curve.ColorMethod = colorMethodType.byEntity;
      curve.Color = clsVar.varEditorSet.colorEntity;
      curve.LineWeight = (float) clsVar.varEditorSet.thicknessEntity;
      curve.LineWeightMethod = colorMethodType.byEntity;
      clsItem.frmEditor.viewport.Entities.Add((Entity) curve);
      this.Reset();
    }
  }

  public Line ExtendLine(Line other, UClick end)
  {
    Line line;
    if (clsVar.varEditorRuntimeSet.isSketchMode)
    {
      Line line_0 = clsItem.frmEditor.viewport.CurrentSketch.AddLine(clsItem.frmEditor.viewport.CurrentSketch.Plane.Project(other.EndPoint), end.Position);
      clsItem.frmEditor.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditor.viewport.CurrentSketch.EndPoint((ICurve) other), (Entity) clsItem.frmEditor.viewport.CurrentSketch.StartPoint((ICurve) line_0));
      if (end.Entity != null)
        clsItem.frmEditor.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditor.viewport.CurrentSketch.EndPoint((ICurve) line_0), end.Entity);
      Class5.smethod_126(this, line_0);
      clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
      this.JobUpdate();
      line = line_0;
    }
    else
      line = new Line(new Point3D(), new Point3D());
    return line;
  }

  public Circle AddCircle(UClick start, UClick end)
  {
    Circle circle1;
    if (clsVar.varEditorRuntimeSet.isSketchMode)
    {
      Circle circle2 = clsItem.frmEditor.viewport.CurrentSketch.AddCircle(start.Position, end.Position);
      clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
      this.action = actionTypeBU.None;
      this.JobUpdate();
      circle1 = circle2;
    }
    else
    {
      double radius = Point2D.Distance(start.Position, end.Position);
      if (radius > 0.0)
      {
        this.UndoBuffer();
        Circle circle3 = new Circle(Plane.XY, new Point3D(start.Position.X, start.Position.Y), radius);
        circle3.ColorMethod = colorMethodType.byEntity;
        circle3.Color = clsVar.varEditorSet.colorEntity;
        circle3.LineWeight = (float) clsVar.varEditorSet.thicknessEntity;
        circle3.LineWeightMethod = colorMethodType.byEntity;
        clsItem.frmEditor.viewport.Entities.Add((Entity) circle3);
      }
      this.Reset();
      circle1 = (Circle) null;
    }
    return circle1;
  }

  public Circle AddCircle(UClick first, UClick second, UClick third)
  {
    Circle circle1;
    if (SewingTempVars.DrawCommand == SewingDrawCommand.ArcStitched)
    {
      if (clsInit.appSewing != null)
      {
        clsInit.appSewing.AddCircleStitch(new Point3D(first.Position.X, first.Position.Y), new Point3D(second.Position.X, second.Position.Y), new Point3D(third.Position.X, third.Position.Y));
        clsInit.appSewing.DrawSewingData(clsInit.appSewing.SewingBase, clsItem.frmEditor.viewport.Entities);
        this.Reset();
      }
      circle1 = (Circle) null;
    }
    else
    {
      this.UndoBuffer();
      Circle circle2 = new Circle(new Point3D(first.Position.X, first.Position.Y), new Point3D(second.Position.X, second.Position.Y), new Point3D(third.Position.X, third.Position.Y));
      circle2.ColorMethod = colorMethodType.byEntity;
      circle2.Color = clsVar.varEditorSet.colorEntity;
      circle2.LineWeight = (float) clsVar.varEditorSet.thicknessEntity;
      circle2.LineWeightMethod = colorMethodType.byEntity;
      clsItem.frmEditor.viewport.Entities.Add((Entity) circle2);
      this.Reset();
      circle1 = circle2;
    }
    return circle1;
  }

  public Arc AddArc(UClick first, UClick second, UClick third)
  {
    Arc arc1;
    if (clsVar.varEditorRuntimeSet.isSketchMode)
    {
      bool flip;
      if (!this.EvaluateArc(first.Position, second.Position, third.Position, out flip))
      {
        arc1 = (Arc) null;
      }
      else
      {
        Arc arc2 = new Arc(clsItem.frmEditor.viewport.CurrentSketch.Plane, first.Position, second.Position, third.Position, flip);
        clsItem.frmEditor.viewport.CurrentSketch.AddArc(arc2);
        if (first.Entity != null)
        {
          if (!flip)
            clsItem.frmEditor.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditor.viewport.CurrentSketch.StartPoint((ICurve) arc2), first.Entity);
          else
            clsItem.frmEditor.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditor.viewport.CurrentSketch.EndPoint((ICurve) arc2), first.Entity);
        }
        if (third.Entity != null)
        {
          if (!flip)
            clsItem.frmEditor.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditor.viewport.CurrentSketch.EndPoint((ICurve) arc2), third.Entity);
          else
            clsItem.frmEditor.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditor.viewport.CurrentSketch.StartPoint((ICurve) arc2), third.Entity);
        }
        clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
        this.JobUpdate();
        arc1 = arc2;
      }
    }
    else
    {
      bool flip;
      if (!this.EvaluateArc(first.Position, second.Position, third.Position, out flip))
        arc1 = (Arc) null;
      else if (SewingTempVars.DrawCommand == SewingDrawCommand.ArcStitched)
      {
        if (clsInit.appSewing != null)
        {
          clsInit.appSewing.AddArcStitch(new Point3D(first.Position.X, first.Position.Y), new Point3D(second.Position.X, second.Position.Y), new Point3D(third.Position.X, third.Position.Y), flip);
          clsInit.appSewing.DrawSewingData(clsInit.appSewing.SewingBase, clsItem.frmEditor.viewport.Entities);
          this.Reset();
        }
        arc1 = (Arc) null;
      }
      else
      {
        this.UndoBuffer();
        Arc arc3 = new Arc(Plane.XY, (Point2D) new Point3D(first.Position.X, first.Position.Y), (Point2D) new Point3D(second.Position.X, second.Position.Y), (Point2D) new Point3D(third.Position.X, third.Position.Y), flip);
        arc3.ColorMethod = colorMethodType.byEntity;
        arc3.Color = clsVar.varEditorSet.colorEntity;
        arc3.LineWeight = (float) clsVar.varEditorSet.thicknessEntity;
        arc3.LineWeightMethod = colorMethodType.byEntity;
        clsItem.frmEditor.viewport.Entities.Add((Entity) arc3);
        this.Reset();
        arc1 = arc3;
      }
    }
    return arc1;
  }

  public void AddFilletChamfer(bool isFillet, ICurve C1, ICurve C2)
  {
    if (!this._filletChamferIndex.HasValue)
      return;
    Tuple<bool, bool> tuple = Class5.smethod_138(this._filletChamferIndex.Value, this);
    DialogBoxInput dialogBoxInput = new DialogBoxInput();
    dialogBoxInput.Value = clsVar.varEditorRuntimeSet.FilletRadius;
    dialogBoxInput.StartPosition = FormStartPosition.CenterParent;
    dialogBoxInput.Init();
    int num = (int) dialogBoxInput.ShowDialog();
    if (dialogBoxInput.Result == DialogResult.OK)
    {
      if (isFillet)
        clsVar.varEditorRuntimeSet.FilletRadius = dialogBoxInput.Value;
      else
        clsVar.varEditorRuntimeSet.ChamferLength = dialogBoxInput.Value;
      if (isFillet)
        clsItem.frmEditor.viewport.CurrentSketch.AddFillet(C1, C2, tuple.Item1, tuple.Item2, clsVar.varEditorRuntimeSet.FilletRadius);
      else
        clsItem.frmEditor.viewport.CurrentSketch.AddChamfer(C1, C2, tuple.Item1, tuple.Item2, clsVar.varEditorRuntimeSet.ChamferLength);
      clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
      if (isFillet && clsItem.frmEditor != null)
        clsItem.frmEditor.mnu_lib_Click((object) clsItem.frmEditor.mnu_libfillet, (EventArgs) null);
    }
    else
      clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
    for (int index = 0; index <= clsItem.frmEditor.viewport.Entities.Count - 1; ++index)
      clsItem.frmEditor.viewport.Entities[index].Selected = false;
    clsItem.frmEditor.viewport.Invalidate();
    this.JobUpdate();
  }

  public void CreateConstraintPointOn(devDept.Eyeshot.Entities.Point pnt, Entity ent)
  {
    clsItem.frmEditor.viewport.CurrentSketch.AddConstraintPointOn(pnt, ent);
    clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
    this.JobUpdate();
  }

  public void CreateConstraintVertical(Line line)
  {
    clsItem.frmEditor.viewport.CurrentSketch.AddConstraintVertical(line);
    clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
    this.JobUpdate();
  }

  public void CreateConstraintHorizontal(Line line)
  {
    clsItem.frmEditor.viewport.CurrentSketch.AddConstraintHorizontal(line);
    clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
    this.JobUpdate();
  }

  public void CreateConstraintLength(Line line, Point2D refPoint)
  {
    clsItem.frmEditor.viewport.CurrentSketch.AddConstraintLength(line, dimLinePos: refPoint);
    clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
    clsItem.frmEditor.viewport.Invalidate();
    this.JobUpdate();
  }

  public void CreateConstraintLineLineDistance(Line L1, Line L2, Point2D refPoint)
  {
    clsItem.frmEditor.viewport.CurrentSketch.AddConstraintLinesDistance(L1, L2, dimLinePos: refPoint);
    clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
    clsItem.frmEditor.viewport.Invalidate();
    this.Reset();
    this.JobUpdate();
  }

  public void CreateConstraintLinePointDistance(devDept.Eyeshot.Entities.Point P1, Line L1, Point2D refPoint)
  {
    clsItem.frmEditor.viewport.CurrentSketch.AddConstraintPointLineDistance(P1, L1, dimLinePos: refPoint);
    clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
    clsItem.frmEditor.viewport.Invalidate();
    this.Reset();
    this.JobUpdate();
  }

  public void CreateConstraintPointPointAlignedDistance(devDept.Eyeshot.Entities.Point P1, devDept.Eyeshot.Entities.Point P2, Point2D refPoint)
  {
    clsItem.frmEditor.viewport.CurrentSketch.AddConstraintAlignedPointsDistance(P1, P2, dimLinePos: refPoint);
    clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
    clsItem.frmEditor.viewport.Invalidate();
    this.Reset();
    this.JobUpdate();
  }

  public void CreateConstraintPointPointHorizontalDistance(devDept.Eyeshot.Entities.Point P1, devDept.Eyeshot.Entities.Point P2, Point2D refPoint)
  {
    clsItem.frmEditor.viewport.CurrentSketch.AddConstraintHorizontalPointsDistance(P1, P2, dimLinePos: refPoint);
    clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
    clsItem.frmEditor.viewport.Invalidate();
    this.Reset();
    this.JobUpdate();
  }

  public void CreateConstraintPointPointVerticalDistance(devDept.Eyeshot.Entities.Point P1, devDept.Eyeshot.Entities.Point P2, Point2D refPoint)
  {
    clsItem.frmEditor.viewport.CurrentSketch.AddConstraintVerticalPointsDistance(P1, P2, dimLinePos: refPoint);
    clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
    clsItem.frmEditor.viewport.Invalidate();
    this.Reset();
    this.JobUpdate();
  }

  public void CreateConstraintCollinear(Line L1, Line L2)
  {
    clsItem.frmEditor.viewport.CurrentSketch.AddConstraintCollinear(L1, L2);
    clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
    for (int index = 0; index <= clsItem.frmEditor.viewport.Entities.Count - 1; ++index)
      clsItem.frmEditor.viewport.Entities[index].Selected = false;
    clsItem.frmEditor.viewport.Invalidate();
    this.Reset();
    this.JobUpdate();
  }

  public void CreateConstraintParallel(Line L1, Line L2)
  {
    clsItem.frmEditor.viewport.CurrentSketch.AddConstraintParallelLines(L1, L2);
    clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
    for (int index = 0; index <= clsItem.frmEditor.viewport.Entities.Count - 1; ++index)
      clsItem.frmEditor.viewport.Entities[index].Selected = false;
    clsItem.frmEditor.viewport.Invalidate();
    this.Reset();
    this.JobUpdate();
  }

  public void CreateConstraintPerpendicular(Line L1, Line L2)
  {
    clsItem.frmEditor.viewport.CurrentSketch.AddConstraintPerpendicular(L1, L2);
    clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
    for (int index = 0; index <= clsItem.frmEditor.viewport.Entities.Count - 1; ++index)
      clsItem.frmEditor.viewport.Entities[index].Selected = false;
    clsItem.frmEditor.viewport.Invalidate();
    this.Reset();
    this.JobUpdate();
  }

  public void CreateConstraintTangent(Entity E1, Entity E2)
  {
    clsItem.frmEditor.viewport.CurrentSketch.AddConstraintTangent(E1, E2);
    clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
    for (int index = 0; index <= clsItem.frmEditor.viewport.Entities.Count - 1; ++index)
      clsItem.frmEditor.viewport.Entities[index].Selected = false;
    clsItem.frmEditor.viewport.Invalidate();
    this.Reset();
    this.JobUpdate();
  }

  public void CreateConstraintAngle(Arc arc, Point2D refPoint)
  {
    clsItem.frmEditor.viewport.CurrentSketch.AddConstraintAngle(arc, dimLinePos: refPoint);
    clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
    for (int index = 0; index <= clsItem.frmEditor.viewport.Entities.Count - 1; ++index)
      clsItem.frmEditor.viewport.Entities[index].Selected = false;
    clsItem.frmEditor.viewport.Invalidate();
    clsItem.frmEditor.viewport.Invalidate();
    this.Reset();
    this.JobUpdate();
  }

  public void CreateConstraintAngle(Line L1, Line L2, Point2D refPoint)
  {
    Tuple<Segment2D, Segment2D> segments = this.GetSegments(L1, L2);
    Point2D i0;
    Segment2D.IntersectionLine(segments.Item1, segments.Item2, out i0);
    double rad = Utility.DegToRad(Utility.RadToDeg(this._clock.Locate(Sketcher2D.mousePlnLoc - i0, out int _).Length));
    clsItem.frmEditor.viewport.CurrentSketch.AddConstraintAngle(L1, L2, refPoint, rad);
    clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
    for (int index = 0; index <= clsItem.frmEditor.viewport.Entities.Count - 1; ++index)
      clsItem.frmEditor.viewport.Entities[index].Selected = false;
    clsItem.frmEditor.viewport.Invalidate();
    this.Reset();
    this.JobUpdate();
  }

  public void CreateConstraintDiameter(Circle line)
  {
    clsItem.frmEditor.viewport.CurrentSketch.AddConstraintDiameter(line);
    clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
    clsItem.frmEditor.viewport.Invalidate();
    this.JobUpdate();
  }

  public void CreateConstraintFixPoint(Entity Ent, Point3D refPoint)
  {
    StartEndCenterType startEndCenterType;
    if (Ent is Line | Ent is Arc | Ent is Circle | Ent is Ellipse | Ent is Curve | Ent is EllipticalArc)
    {
      startEndCenterType = Point3D.Distance(((ICurve) Ent).StartPoint, refPoint) >= Point3D.Distance(((ICurve) Ent).EndPoint, refPoint) ? StartEndCenterType.End : StartEndCenterType.Start;
    }
    else
    {
      if (!(Ent is Circle | Ent is Ellipse))
        return;
      startEndCenterType = StartEndCenterType.Center;
    }
    if (startEndCenterType == StartEndCenterType.End)
    {
      if (Ent is Line)
        clsItem.frmEditor.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditor.viewport.CurrentSketch.EndPoint((ICurve) Ent));
      if (Ent is Curve)
        clsItem.frmEditor.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditor.viewport.CurrentSketch.EndPoint((ICurve) Ent));
      if (Ent is Arc)
        clsItem.frmEditor.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditor.viewport.CurrentSketch.EndPoint((ICurve) Ent));
      if (Ent is EllipticalArc)
        clsItem.frmEditor.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditor.viewport.CurrentSketch.EndPoint((ICurve) Ent));
    }
    if (startEndCenterType == StartEndCenterType.Start)
    {
      if (Ent is Line)
        clsItem.frmEditor.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditor.viewport.CurrentSketch.StartPoint((ICurve) Ent));
      if (Ent is Curve)
        clsItem.frmEditor.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditor.viewport.CurrentSketch.StartPoint((ICurve) Ent));
      if (Ent is Arc)
        clsItem.frmEditor.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditor.viewport.CurrentSketch.StartPoint((ICurve) Ent));
      if (Ent is EllipticalArc)
        clsItem.frmEditor.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditor.viewport.CurrentSketch.StartPoint((ICurve) Ent));
    }
    if (startEndCenterType == StartEndCenterType.Center)
    {
      if (Ent is Circle)
        clsItem.frmEditor.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditor.viewport.CurrentSketch.CenterPoint((Circle) Ent));
      if (Ent is Arc)
        clsItem.frmEditor.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditor.viewport.CurrentSketch.CenterPoint((Circle) Ent));
      if (Ent is Ellipse)
        clsItem.frmEditor.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditor.viewport.CurrentSketch.CenterPoint((Ellipse) Ent));
    }
    clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
    clsItem.frmEditor.viewport.Invalidate();
    this.JobUpdate();
  }

  public void CreateConstraintEqualLength(Entity FirstEntity, Entity SecondEntity, bool Radius)
  {
    clsItem.frmEditor.viewport.CurrentSketch.AddConstraintEqual(FirstEntity, SecondEntity, Radius);
    clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
    for (int index = 0; index <= clsItem.frmEditor.viewport.Entities.Count - 1; ++index)
      clsItem.frmEditor.viewport.Entities[index].Selected = false;
    clsItem.frmEditor.viewport.Invalidate();
    this.JobUpdate();
  }

  public void Chk_CheckedChenged(object sender, EventArgs e)
  {
    if (!((sender as System.Windows.Forms.Control).Name == clsItem.frmEditor.chk_check.Name) || clsInit.appEditor.action != actionTypeBU.eventTurnOver)
      return;
    clsVar.varEditorRuntimeSet.TurnOverCenter = clsItem.frmEditor.chk_check.Checked;
  }

  public void Spn_ValueChanged(object sender, EventArgs e)
  {
    if (!((sender as System.Windows.Forms.Control).Name == clsItem.frmEditor.spn_value.Name))
      return;
    if (clsInit.appEditor.action == actionTypeBU.eventOffset)
      clsVar.varEditorRuntimeSet.OffsetValue = (double) clsItem.frmEditor.spn_value.Value;
    if (clsInit.appEditor.action == actionTypeBU.eventExtend)
      clsVar.varEditorRuntimeSet.ExtendLength = (double) clsItem.frmEditor.spn_value.Value;
    if (clsInit.appEditor.action == actionTypeBU.eventFillet)
      clsVar.varEditorRuntimeSet.FilletRadius = (double) clsItem.frmEditor.spn_value.Value;
    if (clsInit.appEditor.action != actionTypeBU.eventChamfer)
      return;
    clsVar.varEditorRuntimeSet.ChamferLength = (double) clsItem.frmEditor.spn_value.Value;
  }

  public void ShowValueArea(
    bool Show,
    string Caption = "",
    double Value = 0.0,
    double MinVal = -1000000.0,
    double MaxVal = 10000000.0,
    int Decimal = 2)
  {
    clsItem.frmEditor.lbl_value.Visible = Show;
    clsItem.frmEditor.lbl_value.Text = Caption;
    clsItem.frmEditor.spn_value.Visible = Show;
    clsItem.frmEditor.spn_value.DecimalPlaces = Decimal;
    clsItem.frmEditor.spn_value.Minimum = (Decimal) MinVal;
    clsItem.frmEditor.spn_value.Maximum = (Decimal) MaxVal;
    clsItem.frmEditor.spn_value.Value = (Decimal) Value;
  }

  public void ShowCheckArea(bool Show, bool Checked, string Caption = "")
  {
    clsItem.frmEditor.chk_check.Visible = Show;
    clsItem.frmEditor.chk_check.Text = Caption;
    clsItem.frmEditor.chk_check.Checked = Checked;
  }

  public void GridUpdate()
  {
    clsItem.frmEditor.viewport.ActiveViewport.Grid.Visible = true;
    clsItem.frmEditor.viewport.ActiveViewport.Grid.AlwaysBehind = true;
    clsItem.frmEditor.viewport.ActiveViewport.Grid.AutoSize = false;
    clsItem.frmEditor.viewport.ActiveViewport.Grid.MajorLinesEvery = clsVar.varEditorSet.GridMajorLineCount;
    clsItem.frmEditor.viewport.ActiveViewport.Grid.Min.X = clsVar.varEditorSet.GridMinValue;
    clsItem.frmEditor.viewport.ActiveViewport.Grid.Min.Y = clsVar.varEditorSet.GridMinValue;
    clsItem.frmEditor.viewport.ActiveViewport.Grid.Max.X = clsVar.varEditorSet.GridMaxValue;
    clsItem.frmEditor.viewport.ActiveViewport.Grid.Max.Y = clsVar.varEditorSet.GridMaxValue;
    clsItem.frmEditor.viewport.ActiveViewport.Grid.ColorAxisX = clsVar.varEditorSet.colorGridMajorLine;
    clsItem.frmEditor.viewport.ActiveViewport.Grid.ColorAxisY = clsVar.varEditorSet.colorGridMajorLine;
    clsItem.frmEditor.viewport.ActiveViewport.Grid.BorderColor = Color.Transparent;
    clsItem.frmEditor.viewport.ActiveViewport.Grid.FillColor = Color.Transparent;
    clsItem.frmEditor.viewport.ActiveViewport.Grid.LineColor = clsVar.varEditorSet.colorGridLine;
    clsItem.frmEditor.viewport.ActiveViewport.Grid.MajorLineColor = clsVar.varEditorSet.colorGridMajorLine;
    clsItem.frmEditor.viewport.ActiveViewport.Grid.Lighting = true;
    clsItem.frmEditor.viewport.ActiveViewport.Grid.Step = clsVar.varEditorSet.GridStep;
    clsItem.frmEditor.viewport.ActiveViewport.Grid.Visible = true;
    clsItem.frmEditor.viewport.CompileUserInterfaceElements();
    clsItem.frmEditor.viewport.Invalidate();
    clsItem.frmEditor.viewport.AskForHardwareAcceleration = false;
  }

  public bool Offset(Entity selEntity, Point3D refPoint, ref Entity entityOffseted)
  {
    ICurve curve1 = selEntity as ICurve;
    double offsetValue = clsVar.varEditorRuntimeSet.OffsetValue;
    bool flag;
    if (clsVar.varEditorRuntimeSet.OffsetValue == 0.0)
    {
      buString5.MessageBoxWarning($"{buLangTranslate.preDef.Offset} {buLangTranslate.preDef.Value} =  0");
      this.Reset();
      flag = false;
    }
    else
    {
      ICurve curve2 = curve1.Offset(offsetValue, Vector3D.AxisZ, true)?[0];
      ICurve curve3 = curve1.Offset(-offsetValue, Vector3D.AxisZ, true)?[0];
      double t1;
      curve2.Project(refPoint, out t1);
      double num1 = curve2.PointAt(t1).DistanceTo(refPoint);
      double t2;
      curve3.Project(refPoint, out t2);
      double num2 = curve3.PointAt(t2).DistanceTo(refPoint);
      entityOffseted = num1 >= num2 ? (Entity) curve3 : (Entity) curve2;
      flag = true;
    }
    return flag;
  }

  public void Break(
    Entity selEntity,
    Point3D refPoint,
    ref Entity entityFirst,
    ref Entity entitySecond)
  {
    ICurve curve = selEntity as ICurve;
    ICurve lower = (ICurve) null;
    ICurve upper = (ICurve) null;
    double t;
    if (curve.Project(refPoint, out t))
      curve.SplitAt(t, out lower, out upper);
    if (!(lower != null & upper != null))
      return;
    entityFirst = (Entity) lower;
    entitySecond = (Entity) upper;
  }

  public void EqualDistanceEvent(double Distance)
  {
    clsVar.varEditorRuntimeSet.EqualDistance = Distance;
    EntityList entityList = (EntityList) null;
    if (clsInit.appEditor.action == actionTypeBU.eventEqualHorizontal)
      entityList = clsInit.cVector5.EqualDistanceEntities(clsItem.frmEditor.viewport.Entities, Sketcher2D.selectedIndex, EqualDistance.Horizontal, clsVar.varEditorRuntimeSet.EqualDistance);
    if (clsInit.appEditor.action == actionTypeBU.eventEqualVertical)
      entityList = clsInit.cVector5.EqualDistanceEntities(clsItem.frmEditor.viewport.Entities, Sketcher2D.selectedIndex, EqualDistance.Vertical, clsVar.varEditorRuntimeSet.EqualDistance);
    if (entityList == null || entityList.Count <= 0)
      return;
    for (int index = 0; index <= entityList.Count - 1; ++index)
      clsItem.frmEditor.viewport.Entities[index] = entityList[index];
    clsItem.frmEditor.viewport.Entities.RegenAllCurved();
    clsItem.frmEditor.viewport.Invalidate();
    clsInit.appEditor.Reset();
  }

  public void Align()
  {
    EntityList entityList = (EntityList) null;
    if (clsInit.appEditor.action == actionTypeBU.eventAlingLeft)
      entityList = clsInit.cVector5.AlingEntities(clsItem.frmEditor.viewport.Entities, Sketcher2D.selectedIndex, AlignmentEvent.Left);
    if (clsInit.appEditor.action == actionTypeBU.eventAlingRight)
      entityList = clsInit.cVector5.AlingEntities(clsItem.frmEditor.viewport.Entities, Sketcher2D.selectedIndex, AlignmentEvent.Right);
    if (clsInit.appEditor.action == actionTypeBU.eventAlingTop)
      entityList = clsInit.cVector5.AlingEntities(clsItem.frmEditor.viewport.Entities, Sketcher2D.selectedIndex, AlignmentEvent.Top);
    if (clsInit.appEditor.action == actionTypeBU.eventAlingBottom)
      entityList = clsInit.cVector5.AlingEntities(clsItem.frmEditor.viewport.Entities, Sketcher2D.selectedIndex, AlignmentEvent.Bottom);
    if (clsInit.appEditor.action == actionTypeBU.eventAlingHorizontal)
      entityList = clsInit.cVector5.AlingEntities(clsItem.frmEditor.viewport.Entities, Sketcher2D.selectedIndex, AlignmentEvent.HorizontalCenter);
    if (clsInit.appEditor.action == actionTypeBU.eventAlingVertical)
      entityList = clsInit.cVector5.AlingEntities(clsItem.frmEditor.viewport.Entities, Sketcher2D.selectedIndex, AlignmentEvent.VerticalCenter);
    if (entityList == null)
      return;
    this.UndoBuffer();
    if (entityList.Count <= 0)
      return;
    for (int index = 0; index <= entityList.Count - 1; ++index)
      clsItem.frmEditor.viewport.Entities[index] = entityList[index];
    clsItem.frmEditor.viewport.Entities.RegenAllCurved();
    clsItem.frmEditor.viewport.Invalidate();
    clsInit.appEditor.Reset();
  }

  public void Rotate(double Degree)
  {
    Point3D MinPoint = new Point3D();
    Point3D MidPoint = new Point3D();
    Point3D MaxPoint = new Point3D();
    if (Sketcher2D.entitiesSelected.Count == 0)
      clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, false, ref Sketcher2D.entitiesSelected);
    if (Sketcher2D.entitiesSelected.Count > 0)
    {
      this.UndoBuffer();
      clsInit.cVector5.BoxSizeCalculate(Sketcher2D.entitiesSelected, ref MinPoint, ref MidPoint, ref MaxPoint);
      for (int index = 0; index <= clsItem.frmEditor.viewport.Entities.Count - 1; ++index)
      {
        Entity entity = clsItem.frmEditor.viewport.Entities[index];
        if (entity.Selected)
          entity.Rotate(buConversion5.DegreeToRadian(Degree), Vector3D.AxisZ, MidPoint);
      }
      clsItem.frmEditor.viewport.Entities.RegenAllCurved(0.02);
    }
    clsItem.frmEditor.viewport.Invalidate();
    this.Reset();
  }

  public void Mirror(HorizontalVertical Value)
  {
    Point3D MinPoint = new Point3D();
    Point3D MidPoint = new Point3D();
    Point3D MaxPoint = new Point3D();
    if (Sketcher2D.entitiesSelected.Count == 0)
      clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, false, ref Sketcher2D.entitiesSelected);
    clsInit.cVector5.BoxSizeCalculate(Sketcher2D.entitiesSelected, ref MinPoint, ref MidPoint, ref MaxPoint);
    if (Sketcher2D.entitiesSelected.Count > 0)
    {
      this.UndoBuffer();
      Vector3D X = Value != HorizontalVertical.Vertical ? new Vector3D(MidPoint, new Point3D(MidPoint.X, MidPoint.Y + 10.0, MidPoint.Z)) : new Vector3D(MidPoint, new Point3D(MidPoint.X + 10.0, MidPoint.Y, MidPoint.Z));
      devDept.Geometry.Mirror xform = new devDept.Geometry.Mirror(new Plane(MidPoint, X, Vector3D.AxisZ));
      for (int index = 0; index <= clsItem.frmEditor.viewport.Entities.Count - 1; ++index)
      {
        Entity entity = clsItem.frmEditor.viewport.Entities[index];
        if (entity.Selected)
          entity.TransformBy((Transformation) xform);
      }
      clsItem.frmEditor.viewport.Entities.RegenAllCurved();
    }
    clsItem.frmEditor.viewport.Invalidate();
    this.Reset();
  }

  public void TurnOver()
  {
    clsInit.appEditor.UndoBuffer();
    Point3D MinPoint = new Point3D();
    Point3D MidPoint = new Point3D();
    Point3D MaxPoint = new Point3D();
    if (Sketcher2D.entitiesSelected.Count == 0)
      clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, false, ref Sketcher2D.entitiesSelected);
    clsInit.cVector5.BoxSizeCalculate(Sketcher2D.entitiesSelected, ref MinPoint, ref MidPoint, ref MaxPoint);
    if (Sketcher2D.entitiesSelected.Count <= 0)
      return;
    List<Entity> refEntities = new List<Entity>();
    for (int index = 0; index <= Sketcher2D.entitiesSelected.Count - 1; ++index)
    {
      Entity copiedEntity = (Entity) null;
      buEntity.Copy(Sketcher2D.entitiesSelected[index], ref copiedEntity);
      if (copiedEntity != null)
      {
        copiedEntity.ColorMethod = colorMethodType.byEntity;
        copiedEntity.Color = clsVar.varEditorSet.colorEntity;
        copiedEntity.LineWeight = (float) clsVar.varEditorSet.thicknessEntity;
        copiedEntity.LineWeightMethod = colorMethodType.byEntity;
        refEntities.Add(copiedEntity);
      }
    }
    clsInit.cVector5.Rotate(MidPoint, 180.0, Vector3D.AxisZ, ref refEntities);
    if (!clsVar.varEditorRuntimeSet.TurnOverCenter)
      clsInit.cVector5.Move(MaxPoint.X - MinPoint.X + clsVar.varEditorRuntimeSet.TurnOverDistance, 0.0, 0.0, ref refEntities);
    for (int index = 0; index <= refEntities.Count - 1; ++index)
      clsItem.frmEditor.viewport.Entities.Add(refEntities[index]);
    clsItem.frmEditor.viewport.Entities.RegenAllCurved(0.01);
    this.Reset();
  }

  public bool EvaluateArc(Point2D p1, Point2D p2, Point2D p3, out bool flip)
  {
    Vector2D asVector1 = (p1 - p2).AsVector;
    Vector2D asVector2 = (p3 - p2).AsVector;
    flip = this.XyCross(asVector1, asVector2) > 0.0;
    bool arc;
    if (asVector2.Length < 1E-06)
    {
      arc = false;
    }
    else
    {
      asVector1.Normalize();
      asVector2.Normalize();
      arc = !Vector2D.AreOpposite(asVector1, asVector2);
    }
    return arc;
  }

  public void AngleCalculation(ref Line L1, ref Line L2)
  {
    Tuple<Segment2D, Segment2D> segments1 = this.GetSegments(L1, L2);
    Segment2D segment2D1 = segments1.Item1;
    Segment2D segment2D2 = segments1.Item2;
    if (!Segment2D.IntersectionLine(segment2D1, segment2D2, out Point2D _))
    {
      Point3D newLocation = L1.StartPoint.DistanceTo(L2.StartPoint) < L1.StartPoint.DistanceTo(L2.EndPoint) ? (Point3D) L2.StartPoint.Clone() : (Point3D) L2.EndPoint.Clone();
      L1.StartPoint = newLocation;
      clsItem.frmEditor.viewport.CurrentSketch.Move(clsItem.frmEditor.viewport.CurrentSketch.StartPoint((ICurve) L1), newLocation);
      Tuple<Segment2D, Segment2D> segments2 = this.GetSegments(L1, L2);
      Segment2D segment2D3 = segments2.Item1;
      segment2D1 = segments2.Item2;
    }
    this._clock = new VectorClock((Vector2D) segment2D1, (Vector2D) segment2D2);
  }

  public Tuple<Segment2D, Segment2D> GetSegments(Line L1, Line L2)
  {
    return new Tuple<Segment2D, Segment2D>(new Segment2D(clsItem.frmEditor.viewport.CurrentSketch.Plane.Project(L1.StartPoint), clsItem.frmEditor.viewport.CurrentSketch.Plane.Project(L1.EndPoint)), new Segment2D(clsItem.frmEditor.viewport.CurrentSketch.Plane.Project(L2.StartPoint), clsItem.frmEditor.viewport.CurrentSketch.Plane.Project(L2.EndPoint)));
  }

  public void FilletChamferCalculation(bool isFillet)
  {
    ICurve curve1 = (ICurve) Sketcher2D.entitiesSelected[0];
    ICurve curve2 = (ICurve) Sketcher2D.entitiesSelected[1];
    Point3D point3D = ((IEnumerable<Point3D>) Utility.Intersection(curve1, curve2)).LastOrDefault<Point3D>();
    if (point3D == (Point3D) null)
    {
      buString5.MessageBoxWarning(AppLanguage.CadCamMessages[111]);
      if (clsItem.frmEditor == null)
        return;
      clsItem.frmEditor.mnu_lib_Click((object) clsItem.frmEditor.mnu_libfillet, (EventArgs) null);
    }
    else
    {
      point3D.TransformBy((Transformation) new Align3D(Plane.XY, clsItem.frmEditor.viewport.CurrentSketch.DrawingPlane));
      this.ComputeFilletsChamfers(isFillet, clsVar.varEditorRuntimeSet.FilletRadius, curve1, curve2);
      List<Tuple<ICurve, ICurve, ICurve>> list = ((IEnumerable<Tuple<ICurve, ICurve, ICurve>>) this._filletsChamfers).Where<Tuple<ICurve, ICurve, ICurve>>((Func<Tuple<ICurve, ICurve, ICurve>, bool>) (tuple_0 => tuple_0 != null && tuple_0.Item1 != null)).ToList<Tuple<ICurve, ICurve, ICurve>>();
      if (!list.Any<Tuple<ICurve, ICurve, ICurve>>())
      {
        buString5.MessageBoxWarning(AppLanguage.CadCamMessages[112 /*0x70*/]);
        this.Reset();
      }
      else
      {
        if (list.Count<Tuple<ICurve, ICurve, ICurve>>() != 1)
          return;
        this._filletChamferIndex = new int?(((IEnumerable<Tuple<ICurve, ICurve, ICurve>>) this._filletsChamfers).ToList<Tuple<ICurve, ICurve, ICurve>>().IndexOf(list.First<Tuple<ICurve, ICurve, ICurve>>()));
        this.AddFilletChamfer(isFillet, curve1, curve2);
      }
    }
  }

  public void ComputeFilletsChamfers(bool isFillet, double Radius, ICurve _c1, ICurve _c2)
  {
    for (int int_0 = 0; int_0 < 4; ++int_0)
    {
      Entity C1 = (Entity) ((Entity) _c1).Clone();
      Entity C2 = (Entity) ((Entity) _c2).Clone();
      Tuple<bool, bool> tuple = Class5.smethod_138(int_0, this);
      if (isFillet)
      {
        Arc fillet;
        Curve.Fillet((ICurve) C1, (ICurve) C2, Radius, tuple.Item1, tuple.Item2, C1 is Arc || C1 is Line, C2 is Arc || C2 is Line, out fillet);
        if ((fillet == null ? 1 : (fillet.AngleInRadians < 0.001 ? 1 : 0)) == 0)
        {
          fillet.TransformBy(Transformation.CreateAlignment(clsItem.frmEditor.viewport.CurrentSketch.Plane, clsItem.frmEditor.viewport.CurrentSketch.DrawingPlane));
          C1.TransformBy(Transformation.CreateAlignment(clsItem.frmEditor.viewport.CurrentSketch.Plane, clsItem.frmEditor.viewport.CurrentSketch.DrawingPlane));
          C2.TransformBy(Transformation.CreateAlignment(clsItem.frmEditor.viewport.CurrentSketch.Plane, clsItem.frmEditor.viewport.CurrentSketch.DrawingPlane));
          this._filletsChamfers[int_0] = new Tuple<ICurve, ICurve, ICurve>((ICurve) fillet, (ICurve) C1, (ICurve) C2);
        }
      }
      else
      {
        Line chamfer;
        Curve.Chamfer((ICurve) C1, (ICurve) C2, Radius, tuple.Item1, tuple.Item2, C1 is Arc || C1 is Line, C2 is Arc || C2 is Line, out chamfer);
        if ((chamfer == null ? 1 : (chamfer.Length() < 0.001 ? 1 : 0)) == 0)
        {
          chamfer.TransformBy(Transformation.CreateAlignment(clsItem.frmEditor.viewport.CurrentSketch.Plane, clsItem.frmEditor.viewport.CurrentSketch.DrawingPlane));
          C1.TransformBy(Transformation.CreateAlignment(clsItem.frmEditor.viewport.CurrentSketch.Plane, clsItem.frmEditor.viewport.CurrentSketch.DrawingPlane));
          C2.TransformBy(Transformation.CreateAlignment(clsItem.frmEditor.viewport.CurrentSketch.Plane, clsItem.frmEditor.viewport.CurrentSketch.DrawingPlane));
          this._filletsChamfers[int_0] = new Tuple<ICurve, ICurve, ICurve>((ICurve) chamfer, (ICurve) C1, (ICurve) C2);
        }
      }
    }
  }

  public void DrawPolygon(Point2D center, Point2D startPoint, ref LinearPath lp)
  {
    if (center.DistanceTo(startPoint) <= 0.0)
      return;
    Circle circle = new Circle(clsItem.frmEditor.viewport.CurrentSketch.DrawingPlane, center, center.DistanceTo(startPoint));
    Point3D[] point3DArray = new Point3D[clsVar.varEditorRuntimeSet.PolygonSide + 1];
    for (int index = 0; index < clsVar.varEditorRuntimeSet.PolygonSide; ++index)
      point3DArray[index] = circle.PointAt(2.0 * Math.PI * (double) index / (double) clsVar.varEditorRuntimeSet.PolygonSide);
    point3DArray[clsVar.varEditorRuntimeSet.PolygonSide] = circle.PointAt(0.0);
    lp = new LinearPath(point3DArray);
    Vector2D asVector1 = (startPoint - center).AsVector;
    Vector2D asVector2 = (clsItem.frmEditor.viewport.CurrentSketch.DrawingPlane.Project(circle.StartPoint) - center).AsVector;
    asVector1.Normalize();
    asVector2.Normalize();
    double angleInRadians = Vector2D.SignedAngleBetween(asVector2, asVector1);
    lp.Rotate(angleInRadians, clsItem.frmEditor.viewport.CurrentSketch.DrawingPlane.AxisZ, circle.Center);
    lp.Regen(clsItem.frmEditor.viewport.GetVisualRefinement());
  }

  public CompositeCurve ThreePointsSlot(Point2D start, Point2D end, Point2D radial)
  {
    try
    {
      double radius = this.SlotRad(start, end, radial);
      Point2D.Distance(end, radial);
      start.DistanceTo(end);
      if (radius <= 0.0)
        radius = 0.1;
      return CompositeCurve.CreateSlot(Plane.XY, start.X, start.Y, start.DistanceTo(end), radius, (end - start).AsVector.Angle);
    }
    catch (Exception ex)
    {
      return (CompositeCurve) null;
    }
  }

  public double SlotRad(Point2D start, Point2D end, Point2D radial)
  {
    Segment2D segment2D = new Segment2D(start, end);
    Point2D b = segment2D.PointAt(segment2D.ClosestPointTo(radial));
    return radial.DistanceTo(b);
  }

  public Curve InterpolateTwoPoints(UClick first, UClick second)
  {
    Point3D point3D1 = clsItem.frmEditor.viewport.CurrentSketch.DrawingPlane.PointAt(first.Position);
    Point3D point3D2 = clsItem.frmEditor.viewport.CurrentSketch.DrawingPlane.PointAt(second.Position);
    Vector3D asVector = (point3D2 - point3D1).AsVector;
    Vector3D vector3D = Vector3D.Cross(clsItem.frmEditor.viewport.CurrentSketch.DrawingPlane.AxisZ, asVector);
    return Curve.LocalInterpolation((IList<PointTangent>) new PointTangent[3]
    {
      new PointTangent(point3D1.X, point3D1.Y, point3D1.Z, asVector.X, asVector.Y, asVector.Z),
      new PointTangent(point3D2.X, point3D2.Y, point3D2.Z, vector3D.X, vector3D.Y, vector3D.Z),
      new PointTangent(point3D1.X, point3D1.Y, point3D1.Z, -asVector.X, -asVector.Y, -asVector.Z)
    });
  }

  public void ManuelSort(Point3D refPoint)
  {
    this.ManuelSortSetting.Option.Jump = false;
    this.ManuelSortSetting.Option.IntersectionRules = SortingIntersectionRulesType.Stop;
    this.ManuelSortSetting.Option.FirstRules = clsVar.varEditorSet.SortFirstCatchRule;
    if (clsVar.varEditorSet.SortFirstCatchRule == SortingFirstCatchRulesType.CW)
      this.ManuelSortSetting.Option.IntersectionRules = SortingIntersectionRulesType.CW;
    else if (clsVar.varEditorSet.SortFirstCatchRule == SortingFirstCatchRulesType.CCW)
      this.ManuelSortSetting.Option.IntersectionRules = SortingIntersectionRulesType.CCW;
    else if (clsVar.varEditorSet.SortFirstCatchRule == SortingFirstCatchRulesType.LowerIndex)
      this.ManuelSortSetting.Option.IntersectionRules = SortingIntersectionRulesType.LowerIndex;
    else if (clsVar.varEditorSet.SortFirstCatchRule == SortingFirstCatchRulesType.HigherIndex)
      this.ManuelSortSetting.Option.IntersectionRules = SortingIntersectionRulesType.HigherIndex;
    else if (clsVar.varEditorSet.SortFirstCatchRule == SortingFirstCatchRulesType.Jump)
      this.ManuelSortSetting.Option.Jump = true;
    else if (clsVar.varEditorSet.SortFirstCatchRule == SortingFirstCatchRulesType.Manuel)
      this.ManuelSortSetting.Option.IntersectionRules = SortingIntersectionRulesType.Stop;
    this.ManuelSortSetting.Option.refPlane = Plane.XY;
    clsInit.cVector5.SortEntitiesByClick(refPoint, ref this.sortRefEntities, this.ManuelSortSetting, ref this.sortedEntities, ref this.ManuelSortClickResult);
    if (this.sortedEntities.Count <= 0)
      return;
    Sketcher2D.OrthoPossible = true;
  }

  public void ClearSortThings()
  {
    this.sortRefEntities.Clear();
    this.sortedEntities.Clear();
    this.ManuelSortClickResult.ResultType = SortingResultType.None;
    buVector5.PointClickData.FoundCount = 0;
    buVector5.PointClickData.SelectedIndex = -1;
    buVector5.PointClickData.isPointOnEntity = false;
    buVector5.PointClickData.CatchPoint = (Point3D) null;
    buVector5.PointClickData.PreCatchPoint = (Point3D) null;
  }

  public double XyCross(Vector2D vec1, Vector2D vec2) => vec1.X * vec2.Y - vec1.Y * vec2.X;

  public void UndoGetBack()
  {
    if (this.bufferedEntity.Count <= 0)
      return;
    clsItem.frmEditor.viewport.Entities.Clear();
    for (int index1 = 0; index1 <= this.bufferedEntity.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= this.bufferedEntity[index1].Count - 1; ++index2)
      {
        Entity copiedEntity = (Entity) null;
        buEntity.Copy(this.bufferedEntity[index1][index2], ref copiedEntity);
        if (copiedEntity != null)
          clsItem.frmEditor.viewport.Entities.Add(copiedEntity);
      }
    }
    clsItem.frmEditor.viewport.Entities.RegenAllCurved();
    clsItem.frmEditor.viewport.Invalidate();
    this.bufferedEntity.RemoveAt(this.bufferedEntity.Count - 1);
  }

  public void UndoBuffer()
  {
    if (this.bufferedEntity.Count > 100)
      this.bufferedEntity.RemoveAt(this.bufferedEntity.Count - 1);
    List<Entity> entityList = new List<Entity>();
    for (int index = 0; index <= clsItem.frmEditor.viewport.Entities.Count - 1; ++index)
    {
      Entity copiedEntity = (Entity) null;
      buEntity.Copy(clsItem.frmEditor.viewport.Entities[index], ref copiedEntity);
      if (copiedEntity != null)
        entityList.Add(copiedEntity);
    }
    this.bufferedEntity.Add(entityList);
  }

  public void JobTree_AfterSelect(object sender, TreeViewEventArgs e)
  {
    TreeNodeSettings selectedNode = (TreeNodeSettings) ((TreeView) sender).SelectedNode;
    switch (selectedNode.Command)
    {
      case "drawbase":
        this.SelectedConstraint = -1;
        this.SelectedDrawing = -1;
        break;
      case "draw":
        this.SelectedConstraint = -1;
        this.SelectedDrawing = selectedNode.ClassSubIndex;
        break;
      case "Constraintbase":
        this.SelectedConstraint = -1;
        this.SelectedDrawing = -1;
        break;
      case "Constraints":
        this.SelectedDrawing = -1;
        this.SelectedConstraint = selectedNode.ClassSubIndex;
        break;
    }
    clsItem.frmEditor.viewport.Entities.ClearSelection();
    if (this.SelectedConstraint >= 0)
    {
      VisualConstraint constraint = clsItem.frmEditor.viewport.CurrentSketch.Constraints[this.SelectedConstraint];
      if (constraint.ConstraintDimension != null)
        constraint.ConstraintDimension.Selected = true;
      this.UpdateCommandInfo(new EditorCustomData());
    }
    clsItem.frmEditor.lst_command.Items.Clear();
    if (this.SelectedDrawing >= 0)
    {
      clsItem.frmEditor.viewport.Entities[this.SelectedDrawing].Selected = true;
      if (clsItem.frmEditor.viewport.Entities[this.SelectedDrawing].EntityData != null && clsItem.frmEditor.viewport.Entities[this.SelectedDrawing].EntityData is EditorCustomData)
        this.UpdateCommandInfo(clsItem.frmEditor.viewport.Entities[this.SelectedDrawing].EntityData as EditorCustomData);
    }
    clsItem.frmEditor.viewport.Invalidate();
  }

  public void JobUpdate()
  {
    clsItem.frmEditor.tree_objects.Nodes.Clear();
    TreeNodeSettings treeNodeSettings1 = new TreeNodeSettings("Draw");
    treeNodeSettings1.ImageIndex = 0;
    treeNodeSettings1.SelectedImageIndex = 0;
    treeNodeSettings1.Tag = (object) "-1";
    treeNodeSettings1.ClassIndex = 0;
    treeNodeSettings1.ClassSubIndex = -1;
    treeNodeSettings1.ClassSubSubIndex = -1;
    treeNodeSettings1.Command = "drawbase";
    treeNodeSettings1.Name = "draw";
    treeNodeSettings1.Info = "draw";
    treeNodeSettings1.Index = 0;
    treeNodeSettings1.Checked = false;
    TreeNodeSettings node1 = treeNodeSettings1;
    for (int index = 0; index <= clsItem.frmEditor.viewport.Entities.Count - 1; ++index)
    {
      bool flag = false;
      TreeNodeSettings treeNodeSettings2 = new TreeNodeSettings("Draw");
      treeNodeSettings2.Tag = (object) "-1";
      treeNodeSettings2.ClassIndex = 0;
      treeNodeSettings2.ClassSubIndex = index;
      treeNodeSettings2.ClassSubSubIndex = -1;
      treeNodeSettings2.Command = "draw";
      treeNodeSettings2.Name = "draw" + index.ToString();
      treeNodeSettings2.Info = "draw" + index.ToString();
      treeNodeSettings2.Index = 0;
      treeNodeSettings2.Checked = false;
      TreeNodeSettings node2 = treeNodeSettings2;
      if (clsItem.frmEditor.viewport.Entities[index].GetType() == typeof (devDept.Eyeshot.Entities.Point) & clsVar.varEditorSet.ShowPointsAtDrawingTreeItem)
      {
        node2.ImageIndex = 1;
        node2.SelectedImageIndex = 1;
        node2.Text = AppLanguage.CadCamDynamic[48 /*0x30*/];
        flag = true;
      }
      else if (clsItem.frmEditor.viewport.Entities[index].GetType() == typeof (Line))
      {
        node2.ImageIndex = 2;
        node2.SelectedImageIndex = 2;
        node2.Text = AppLanguage.CadCamDynamic[44];
        flag = true;
      }
      else if (clsItem.frmEditor.viewport.Entities[index].GetType() == typeof (Arc))
      {
        node2.ImageIndex = 4;
        node2.SelectedImageIndex = 4;
        node2.Text = AppLanguage.CadCamDynamic[49];
        flag = true;
      }
      else if (clsItem.frmEditor.viewport.Entities[index].GetType() == typeof (Circle))
      {
        node2.ImageIndex = 3;
        node2.SelectedImageIndex = 3;
        node2.Text = AppLanguage.CadCamDynamic[51];
        flag = true;
      }
      else if (clsItem.frmEditor.viewport.Entities[index].GetType() == typeof (Ellipse))
      {
        node2.ImageIndex = 5;
        node2.SelectedImageIndex = 5;
        node2.Text = AppLanguage.CadCamDynamic[54];
        flag = true;
      }
      else if (clsItem.frmEditor.viewport.Entities[index].GetType() == typeof (Curve))
      {
        node2.ImageIndex = 6;
        node2.SelectedImageIndex = 6;
        node2.Text = AppLanguage.CadCamDynamic[66];
        flag = true;
      }
      if (flag)
        node1.Nodes.Add((TreeNode) node2);
    }
    TreeNodeSettings treeNodeSettings3 = new TreeNodeSettings("Constraint");
    treeNodeSettings3.ImageIndex = 13;
    treeNodeSettings3.SelectedImageIndex = 13;
    treeNodeSettings3.Tag = (object) "-1";
    treeNodeSettings3.ClassIndex = 1;
    treeNodeSettings3.ClassSubIndex = -1;
    treeNodeSettings3.ClassSubSubIndex = -1;
    treeNodeSettings3.Command = "Constraintbase";
    treeNodeSettings3.Name = "Constraint";
    treeNodeSettings3.Info = "Constraint";
    treeNodeSettings3.Index = 0;
    treeNodeSettings3.Checked = false;
    TreeNodeSettings node3 = treeNodeSettings3;
    for (int index1 = 0; index1 <= clsItem.frmEditor.viewport.Entities.Count - 1; ++index1)
    {
      if (clsItem.frmEditor.viewport.Entities[index1] is SketchEntity)
      {
        SketchEntity entity = clsItem.frmEditor.viewport.Entities[index1] as SketchEntity;
        for (int index2 = 0; index2 <= entity.Constraints.Count - 1; ++index2)
        {
          bool flag = false;
          TreeNodeSettings treeNodeSettings4 = new TreeNodeSettings("Constraints");
          treeNodeSettings4.Tag = (object) "-1";
          treeNodeSettings4.ClassIndex = 1;
          treeNodeSettings4.ClassSubIndex = index2;
          treeNodeSettings4.ClassSubSubIndex = -1;
          treeNodeSettings4.Command = "Constraints";
          treeNodeSettings4.Name = "draw" + index2.ToString();
          treeNodeSettings4.Info = "draw" + index2.ToString();
          treeNodeSettings4.Index = 0;
          treeNodeSettings4.Checked = false;
          TreeNodeSettings node4 = treeNodeSettings4;
          if (entity.Constraints[index2].GetType() == typeof (HvVisualConstraint))
          {
            if (((HVConstraint) entity.Constraints[index2].GConstraint).IsHorizontal)
            {
              node4.ImageIndex = 15;
              node4.SelectedImageIndex = 15;
              node4.Text = AppLanguage.CadCamDynamic[136];
              flag = true;
            }
            if (!((HVConstraint) entity.Constraints[index2].GConstraint).IsHorizontal)
            {
              node4.ImageIndex = 26;
              node4.SelectedImageIndex = 26;
              node4.Text = AppLanguage.CadCamDynamic[137];
              flag = true;
            }
          }
          if (entity.Constraints[index2].GetType() == typeof (AngleVisualConstraint))
          {
            node4.ImageIndex = 8;
            node4.SelectedImageIndex = 8;
            node4.Text = AppLanguage.CadCamDynamic[2];
            flag = true;
          }
          if (entity.Constraints[index2].GetType() == typeof (CoincidentVisualConstraint))
          {
            node4.ImageIndex = 27;
            node4.SelectedImageIndex = 27;
            node4.Text = AppLanguage.CadCamDynamic[138];
            flag = true;
          }
          if (entity.Constraints[index2].GetType() == typeof (CollinearPointsVisualConstraint))
          {
            node4.ImageIndex = 10;
            node4.SelectedImageIndex = 10;
            node4.Text = AppLanguage.CadCamDynamic[0];
            flag = true;
          }
          if (entity.Constraints[index2].GetType() == typeof (CollinearVisualConstraint))
          {
            node4.ImageIndex = 10;
            node4.SelectedImageIndex = 10;
            node4.Text = AppLanguage.CadCamDynamic[0];
            flag = true;
          }
          if (entity.Constraints[index2].GetType() == typeof (ConcentricCirclesDistanceVisualConstraint))
          {
            node4.ImageIndex = 31 /*0x1F*/;
            node4.SelectedImageIndex = 31 /*0x1F*/;
            node4.Text = AppLanguage.CadCamDynamic[0];
            flag = true;
          }
          if (entity.Constraints[index2].GetType() == typeof (DiameterVisualConstraint))
          {
            node4.ImageIndex = 24;
            node4.SelectedImageIndex = 24;
            node4.Text = AppLanguage.CadCamDynamic[57];
            flag = true;
          }
          if (entity.Constraints[index2].GetType() == typeof (EqualVisualConstraint))
          {
            if (((EqualConstraint) entity.Constraints[index2].GConstraint).IsEqualLength())
            {
              node4.ImageIndex = 11;
              node4.SelectedImageIndex = 11;
              node4.Text = $"{AppLanguage.CadCamDynamic[140]} {AppLanguage.CadCamDynamic[0]}";
            }
            else
            {
              node4.ImageIndex = 12;
              node4.SelectedImageIndex = 12;
              node4.Text = $"{AppLanguage.CadCamDynamic[140]} {AppLanguage.CadCamDynamic[19]}";
            }
            flag = true;
          }
          if (entity.Constraints[index2].GetType() == typeof (LengthVisualConstraint))
          {
            node4.ImageIndex = 16 /*0x10*/;
            node4.SelectedImageIndex = 16 /*0x10*/;
            node4.Text = AppLanguage.CadCamDynamic[0];
            flag = true;
          }
          if (entity.Constraints[index2].GetType() == typeof (LinesDistanceVisualConstraint))
          {
            node4.ImageIndex = 17;
            node4.SelectedImageIndex = 17;
            node4.Text = $"{AppLanguage.CadCamDynamic[44]} {AppLanguage.CadCamDynamic[44]}";
            flag = true;
          }
          if (entity.Constraints[index2].GetType() == typeof (MidPointVisualConstraint))
          {
            node4.ImageIndex = 28;
            node4.SelectedImageIndex = 28;
            node4.Text = $"{AppLanguage.CadCamDynamic[141]} {AppLanguage.CadCamDynamic[48 /*0x30*/]}";
            flag = true;
          }
          if (entity.Constraints[index2].GetType() == typeof (MirrorVisualConstraint))
          {
            node4.ImageIndex = 19;
            node4.SelectedImageIndex = 19;
            node4.Text = AppLanguage.CadCamDynamic[142];
            flag = true;
          }
          if (entity.Constraints[index2].GetType() == typeof (ParallelLinesVisualConstraint))
          {
            node4.ImageIndex = 21;
            node4.SelectedImageIndex = 21;
            node4.Text = AppLanguage.CadCamDynamic[143];
            flag = true;
          }
          if (entity.Constraints[index2].GetType() == typeof (PerpendicularVisualConstraint))
          {
            node4.ImageIndex = 22;
            node4.SelectedImageIndex = 22;
            node4.Text = AppLanguage.CadCamDynamic[144 /*0x90*/];
            flag = true;
          }
          if (entity.Constraints[index2].GetType() == typeof (PointAtVisualConstraint))
          {
            node4.ImageIndex = 32 /*0x20*/;
            node4.SelectedImageIndex = 32 /*0x20*/;
            node4.Text = AppLanguage.CadCamDynamic[147];
            flag = true;
          }
          if (entity.Constraints[index2].GetType() == typeof (PointFixedVisualConstraint))
          {
            node4.ImageIndex = 14;
            node4.SelectedImageIndex = 14;
            node4.Text = $"{AppLanguage.CadCamDynamic[146]} {AppLanguage.CadCamDynamic[48 /*0x30*/]}";
            flag = true;
          }
          if (entity.Constraints[index2].GetType() == typeof (PointLineDistanceVisualConstraint))
          {
            node4.ImageIndex = 18;
            node4.SelectedImageIndex = 18;
            node4.Text = $"{AppLanguage.CadCamDynamic[48 /*0x30*/]} {AppLanguage.CadCamDynamic[44]}";
            flag = true;
          }
          if (entity.Constraints[index2].GetType() == typeof (PointOnVisualConstraint))
          {
            node4.ImageIndex = 32 /*0x20*/;
            node4.SelectedImageIndex = 32 /*0x20*/;
            node4.Text = AppLanguage.CadCamDynamic[148];
            flag = true;
          }
          if (entity.Constraints[index2].GetType() == typeof (PointsDistanceVisualConstraint))
          {
            node4.ImageIndex = 23;
            node4.SelectedImageIndex = 23;
            node4.Text = $"{AppLanguage.CadCamDynamic[48 /*0x30*/]} {AppLanguage.CadCamDynamic[48 /*0x30*/]}";
            flag = true;
          }
          if (entity.Constraints[index2].GetType() == typeof (PolygonVisualConstraint))
          {
            node4.ImageIndex = 29;
            node4.SelectedImageIndex = 29;
            node4.Text = AppLanguage.CadCamDynamic[70];
            flag = true;
          }
          if (entity.Constraints[index2].GetType() == typeof (TangentVisualConstraint))
          {
            node4.ImageIndex = 25;
            node4.SelectedImageIndex = 25;
            node4.Text = AppLanguage.CadCamDynamic[145];
            flag = true;
          }
          if (entity.Constraints[index2].GetType() == typeof (ValueVisualConstraint))
          {
            node4.ImageIndex = 30;
            node4.SelectedImageIndex = 30;
            node4.Text = AppLanguage.CadCamDynamic[4];
            flag = true;
          }
          if (flag)
            node3.Nodes.Add((TreeNode) node4);
        }
      }
    }
    clsItem.frmEditor.tree_objects.Nodes.Add((TreeNode) node1);
    if (clsVar.varEditorSet.ShowConstraintTreeItem)
      clsItem.frmEditor.tree_objects.Nodes.Add((TreeNode) node3);
    if (clsVar.varEditorSet.ExpandDrawingTree)
      clsItem.frmEditor.tree_objects.Nodes[0].ExpandAll();
    if (!(clsVar.varEditorSet.ExpandConstraintTree & clsItem.frmEditor.tree_objects.Nodes.Count >= 2))
      return;
    clsItem.frmEditor.tree_objects.Nodes[1].ExpandAll();
  }

  public void UpdateCommandInfo(EditorCustomData CD)
  {
    clsItem.frmEditor.lst_command.Items.Clear();
    for (int index = 0; index <= CD.Commands.Count - 1; ++index)
      clsItem.frmEditor.lst_command.Items.Add((object) CD.Commands[index]);
  }

  public void AddCommandToDrawing(string Command, int indexDrawing)
  {
    if (clsItem.frmEditor.viewport.ActionMode == devDept.Eyeshot.actionType.SelectByBox)
    {
      for (int index = 0; index <= clsItem.frmEditor.viewport.Entities.Count - 1; ++index)
      {
        if (clsItem.frmEditor.viewport.Entities[index].Selected & clsItem.frmEditor.viewport.Entities[index] is ICurve & clsItem.frmEditor.viewport.Entities[index].GetType() != typeof (devDept.Eyeshot.Entities.Point))
        {
          if (clsItem.frmEditor.viewport.Entities[index].EntityData != null)
          {
            if (clsItem.frmEditor.viewport.Entities[index].EntityData is EditorCustomData)
            {
              EditorCustomData entityData = clsItem.frmEditor.viewport.Entities[index].EntityData as EditorCustomData;
              entityData.Commands.Add(Command);
              this.UpdateCommandInfo(entityData);
            }
            else
            {
              EditorCustomData CD = new EditorCustomData();
              CD.Commands.Add(Command);
              clsItem.frmEditor.viewport.Entities[index].EntityData = (object) CD;
              this.UpdateCommandInfo(CD);
            }
          }
          else
          {
            EditorCustomData CD = new EditorCustomData();
            CD.Commands.Add(Command);
            clsItem.frmEditor.viewport.Entities[index].EntityData = (object) CD;
            this.UpdateCommandInfo(CD);
          }
        }
      }
      this.JobUpdate();
    }
    else
    {
      if (indexDrawing < 0)
        return;
      if (clsItem.frmEditor.viewport.Entities[indexDrawing].EntityData != null)
      {
        if (clsItem.frmEditor.viewport.Entities[indexDrawing].EntityData is EditorCustomData)
        {
          EditorCustomData entityData = clsItem.frmEditor.viewport.Entities[indexDrawing].EntityData as EditorCustomData;
          entityData.Commands.Add(Command);
          this.UpdateCommandInfo(entityData);
        }
        else
        {
          EditorCustomData CD = new EditorCustomData();
          CD.Commands.Add(Command);
          clsItem.frmEditor.viewport.Entities[indexDrawing].EntityData = (object) CD;
          this.UpdateCommandInfo(CD);
        }
      }
      else
      {
        EditorCustomData CD = new EditorCustomData();
        CD.Commands.Add(Command);
        clsItem.frmEditor.viewport.Entities[indexDrawing].EntityData = (object) CD;
        this.UpdateCommandInfo(CD);
      }
    }
  }

  public void RemoveCommandFromDrawing(int indexCommand, int indexDrawing)
  {
    if (!(indexDrawing >= 0 & indexCommand >= 0) || clsItem.frmEditor.viewport.Entities[indexDrawing].EntityData == null || !(clsItem.frmEditor.viewport.Entities[indexDrawing].EntityData is EditorCustomData))
      return;
    EditorCustomData entityData = clsItem.frmEditor.viewport.Entities[indexDrawing].EntityData as EditorCustomData;
    entityData.Commands.RemoveAt(indexCommand);
    this.UpdateCommandInfo(entityData);
  }

  public void FileOpened()
  {
    if (clsItem.frmEditor.viewport.Entities.Count > 0)
    {
      if (clsItem.frmEditor.viewport.Entities[0] is SketchEntity)
      {
        SketchEntity entity = clsItem.frmEditor.viewport.Entities[0] as SketchEntity;
        if (this.OpenCustomData.Count > 0)
        {
          for (int index = 0; index <= this.OpenCustomData.Count - 1; ++index)
          {
            if (this.OpenCustomData[index].EntityIndex >= 0 & this.OpenCustomData[index].EntityIndex <= entity.CurveList.Count - 1)
              ((Entity) entity.CurveList[this.OpenCustomData[index].EntityIndex]).EntityData = (object) this.OpenCustomData[index];
          }
        }
        entity.Edit((IDesign) clsItem.frmEditor.viewport);
        clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
      }
      Class5.smethod_48(this);
      Class5.smethod_60(this);
      this.JobUpdate();
    }
    DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.Base + "\\L");
    if (!directoryInfo.Exists)
      return;
    directoryInfo.Delete(true);
  }

  public void OpenEditorCustomDataToFile(string filename, ref List<EditorCustomData> CDs)
  {
    List<string> StringList = new List<string>();
    CDs = new List<EditorCustomData>();
    buFile5.OpenFromFile(filename, ref StringList);
    for (int index1 = 0; index1 <= StringList.Count - 1; ++index1)
    {
      string[] strArray1 = StringList[index1].Split('|');
      if (strArray1 != null && strArray1.Length == 2)
      {
        string[] strArray2 = strArray1[1].Split(';');
        if (strArray2 != null)
        {
          EditorCustomData editorCustomData = new EditorCustomData();
          editorCustomData.EntityIndex = int.Parse(strArray1[0]);
          if (strArray2.Length != 0)
          {
            for (int index2 = 0; index2 <= strArray2.Length - 1; ++index2)
            {
              if (strArray2[index2].Trim().Length > 0)
                editorCustomData.Commands.Add(strArray2[index2].Trim());
            }
          }
          CDs.Add(editorCustomData);
        }
      }
    }
  }

  public void SaveEditorCustomDataToFile(Design Viewport, string filename)
  {
    List<string> StringList = new List<string>();
    for (int index1 = 0; index1 <= Viewport.Entities.Count - 1; ++index1)
    {
      if (Viewport.Entities[index1] is SketchEntity)
      {
        SketchEntity entity = Viewport.Entities[index1] as SketchEntity;
        for (int index2 = 0; index2 <= entity.CurveList.Count - 1; ++index2)
        {
          if (((Entity) entity.CurveList[index2]).EntityData is EditorCustomData)
          {
            EditorCustomData entityData = ((Entity) entity.CurveList[index2]).EntityData as EditorCustomData;
            entityData.EntityIndex = index2;
            if (entityData.EntityIndex >= 0 && entityData.Commands.Count > 0)
            {
              string str1 = entityData.EntityIndex.ToString() + " | ";
              string str2 = "";
              for (int index3 = 0; index3 <= entityData.Commands.Count - 1; ++index3)
              {
                if (index3 > 0)
                  str2 = ";";
                str1 = str1 + str2 + entityData.Commands[index3];
              }
              StringList.Add(str1);
            }
          }
        }
      }
    }
    buFile5.SaveToFile(StringList, filename);
  }

  public void SaveLibraryToZip()
  {
    if (this.FIZip == null)
      return;
    DirectoryInfo directoryInfo = new DirectoryInfo($"{new FileInfo(this.FIZip.FullName).DirectoryName}\\{buFile5.getFileNameWithoutExtension(this.FIZip.FullName)}");
    if (!directoryInfo.Exists)
      return;
    buFile5.ZipFolderToFile(directoryInfo.FullName, this.FIZip.FullName);
    directoryInfo.Delete(true);
  }

  public void AnalyseSketchEntity(
    List<buEntity> SketchEntites,
    SketchAnalyseSetData SetData,
    ref SketchAnalyseData AnalyseData)
  {
    AnalyseData = new SketchAnalyseData();
    List<buEntity> BaseRefEntities = new List<buEntity>();
    bool flag1 = false;
    List<double> RefList = new List<double>();
    for (int index1 = 0; index1 <= SketchEntites.Count - 1; ++index1)
    {
      buEntity copiedEntity = (buEntity) null;
      bool flag2 = true;
      if (SketchEntites[index1].Info.Commands != null)
      {
        for (int index2 = 0; index2 <= SketchEntites[index1].Info.Commands.Count - 1; ++index2)
        {
          if (SketchEntites[index1].Info.Commands[index2].Trim() == "NoCalculationEntity")
            flag2 = false;
          if (SketchEntites[index1].Info.Commands[index2].Trim() == "SecondDrawing")
            flag1 = true;
          if (SketchEntites[index1].Info.Commands[index2].Trim().IndexOf(buLangTranslate.preDef.Depth) >= 0)
          {
            string[] strArray = SketchEntites[index1].Info.Commands[index2].Split('=');
            if ((strArray == null ? 0 : (strArray.Length != 0 ? 1 : 0)) != 0 && strArray.Length == 2)
            {
              double result = 0.0;
              if (double.TryParse(strArray[1], out result) && !buNumeric5.isValueAvailableInList(RefList, result))
                RefList.Add(result);
            }
          }
        }
      }
      if (flag2 && SketchEntites[index1].GetType() != typeof (buPoint))
      {
        buEntity.Copy(SketchEntites[index1], ref copiedEntity);
        BaseRefEntities.Add(copiedEntity);
      }
    }
    if (RefList.Count > 0)
      buNumeric5.SortList(SortDirectionType.Lower, ref RefList);
    List<buEntity> SortedEntities = new List<buEntity>();
    List<List<buEntity>> SplitedEntitites = new List<List<buEntity>>();
    SortbuSettings Settings = new SortbuSettings();
    clsInit.cVector5.SortEntitiesByRefPoint(BaseRefEntities[0].StartPoint, ref BaseRefEntities, Settings, ref SortedEntities);
    clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites);
    for (int index = 0; index <= SplitedEntitites.Count - 1; ++index)
    {
      buCompositeCurve calcCompositeCurve = (buCompositeCurve) null;
      clsInit.cVector5.CreateCompositeCurveFromEntitiesWithCamDirection(SplitedEntitites[index], ref calcCompositeCurve);
      if (SplitedEntitites[index].Count > 0 && SplitedEntitites[index][0].Info.Commands != null)
      {
        calcCompositeCurve.Info.Commands = new List<string>();
        calcCompositeCurve.Info.Commands.AddRange((IEnumerable<string>) SplitedEntitites[index][0].Info.Commands);
      }
      AnalyseData.AnalyseEntities.Add((buEntity) calcCompositeCurve);
    }
    Point3D MinPoint = new Point3D();
    Point3D MaxPoint = new Point3D();
    clsInit.cVector5.BoxSizeCalculate(AnalyseData.AnalyseEntities, ref MinPoint, ref MaxPoint);
    if (AnalyseData.AnalyseEntities.Count <= 1)
      return;
    int index3 = -1;
    for (int index4 = 0; index4 <= AnalyseData.AnalyseEntities.Count - 1; ++index4)
    {
      if (!clsInit.cVector5.isBoxSizeInsideBoxSize(MinPoint, MaxPoint, AnalyseData.AnalyseEntities[index4].BoxMin, AnalyseData.AnalyseEntities[index4].BoxMax, Plane.XY))
        index3 = index4;
      else if (clsInit.cVector5.Length3D(MinPoint, AnalyseData.AnalyseEntities[index4].BoxMin, Plane.XY) < 1.0 | clsInit.cVector5.Length3D(MaxPoint, AnalyseData.AnalyseEntities[index4].BoxMax, Plane.XY) < 1.0)
        index3 = index4;
    }
    if (index3 >= 0)
    {
      List<buEntity> buEntityList1 = new List<buEntity>();
      List<buEntity> buEntityList2 = new List<buEntity>();
      buEntityList1.Add(buEntity.Copy(AnalyseData.AnalyseEntities[index3]));
      for (int index5 = 0; index5 <= index3 - 1; ++index5)
        buEntityList2.Add(buEntity.Copy(AnalyseData.AnalyseEntities[index5]));
      for (int index6 = index3 + 1; index6 <= AnalyseData.AnalyseEntities.Count - 1; ++index6)
        buEntityList2.Add(buEntity.Copy(AnalyseData.AnalyseEntities[index6]));
      AnalyseData.AnalyseEntities = new List<buEntity>();
      AnalyseData.AnalyseEntities.Add(buEntityList1[0]);
      for (int index7 = 0; index7 <= buEntityList2.Count - 1; ++index7)
        AnalyseData.AnalyseEntities.Add(buEntityList2[index7]);
    }
    if (!flag1)
      return;
    if (RefList.Count > 0)
    {
      for (int index8 = 0; index8 <= RefList.Count - 1; ++index8)
        AnalyseData.DepthLevel.Add(RefList[index8]);
    }
    else
    {
      for (int index9 = 0; index9 <= AnalyseData.AnalyseEntities.Count - 1; ++index9)
        AnalyseData.DepthLevel.Add(SetData.DefaultDepth);
    }
  }

  public void SaveEditorFile()
  {
    try
    {
      string FileName = AppPath.Settings + "\\Editor.prm";
      ArrayList StringList = new ArrayList();
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   Editor Settings");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "<clsVar.varEditorSet>");
      StringList.AddRange((ICollection) clsVar.varEditorSet.ToDefAll("", 2, SerilizationMode5.MultiLine));
      StringList.Add((object) "</clsVar.varEditorSet>");
      StringList.Add((object) "<clsVar.varEditorRuntimeSet>");
      StringList.AddRange((ICollection) clsVar.varEditorRuntimeSet.ToDefAll("", 2, SerilizationMode5.MultiLine));
      StringList.Add((object) "</clsVar.varEditorRuntimeSet>");
      buFile.SaveToFile(StringList, FileName);
      buLog.addLog("Editor Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void OpenEditorFile()
  {
    try
    {
      ArrayList arrayList = new ArrayList();
      FileInfo fileInfo = new FileInfo(AppPath.Settings + "\\Editor.prm");
      if (fileInfo.Exists)
      {
        ArrayList StringList = new ArrayList();
        buFile.OpenFromFile(fileInfo.FullName, ref StringList);
        try
        {
          ArrayList CalcList = new ArrayList();
          buString.ListToSpecificList("<clsVar.varEditorSet>", "</clsVar.varEditorSet>", true, StringList, ref CalcList);
          if (CalcList.Count > 0)
          {
            buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, (object) clsVar.varEditorSet);
            buLog.addLog("clsVar.varEditorSet Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
          CalcList = new ArrayList();
          buString.ListToSpecificList("<clsVar.varEditorRuntimeSet>", "</clsVar.varEditorRuntimeSet>", true, StringList, ref CalcList);
          if (CalcList.Count > 0)
          {
            buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, (object) clsVar.varEditorRuntimeSet);
            buLog.addLog("clsVar.varEditorRuntimeSet Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
        }
        catch (Exception ex)
        {
          buLog.addLog("Editor Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
          buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Editor Settings Decoder Error");
        }
      }
      else if (clsVar.appModes_0.LaserRouterDiamekerMode.Enable)
      {
        buLog.addLog("Editor  Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString.MessageBoxError("Door Settings File Missing");
      }
      buLog.addLog("Editor Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void OpenSortedEntities(
    string FileName,
    ref List<Entity> EyeEntities,
    ref List<buEntity> DrawEntities,
    ref List<buEntity> SortedEntities)
  {
    ArrayList StringList = new ArrayList();
    List<string> CalcList1 = new List<string>();
    List<List<string>> CalcList2 = new List<List<string>>();
    buFile5.OpenFromFile(FileName, ref StringList);
    buString5.ListToSpecificList("<DrawEntities>", "</DrawEntities>", false, StringList, ref CalcList1);
    buStatics.ListToSpecificList("<buEntity>", "</buEntity>", false, CalcList1, ref CalcList2);
    if (CalcList2.Count > 0)
    {
      EyeEntities = new List<Entity>();
      DrawEntities = new List<buEntity>();
      for (int index = 0; index <= CalcList2.Count - 1; ++index)
      {
        buEntity refEntity = buEntity.Decode(CalcList2[index]);
        if (refEntity != null)
        {
          DrawEntities.Add(refEntity);
          Entity copiedEntity = (Entity) null;
          buEntity.Copy(refEntity, ref copiedEntity);
          if (copiedEntity != null)
            EyeEntities.Add(copiedEntity);
        }
      }
    }
    List<string> CalcList3 = new List<string>();
    List<List<string>> CalcList4 = new List<List<string>>();
    buString5.ListToSpecificList("<SortEntities>", "</SortEntities>", false, StringList, ref CalcList3);
    buStatics.ListToSpecificList("<buEntity>", "</buEntity>", false, CalcList3, ref CalcList4);
    if (CalcList4.Count <= 0)
      return;
    SortedEntities = new List<buEntity>();
    for (int index = 0; index <= CalcList4.Count - 1; ++index)
    {
      buEntity buEntity = buEntity.Decode(CalcList4[index]);
      if (buEntity != null)
        SortedEntities.Add(buEntity);
    }
  }

  public void OpenSortedEntities(
    string FileName,
    ref List<Entity> EyeEntities,
    ref List<buEntity> SortedEntities)
  {
    List<buEntity> DrawEntities = new List<buEntity>();
    this.OpenSortedEntities(FileName, ref EyeEntities, ref DrawEntities, ref SortedEntities);
  }

  public void OpenSortedEntities(
    string FileName,
    ref List<buEntity> DrawEntities,
    ref List<buEntity> SortedEntities)
  {
    List<Entity> EyeEntities = new List<Entity>();
    this.OpenSortedEntities(FileName, ref EyeEntities, ref DrawEntities, ref SortedEntities);
  }

  public void SaveSortedEntities(string FileName)
  {
    int num = 2;
    ArrayList StringList = new ArrayList();
    List<buEntity> refEntities = new List<buEntity>();
    for (int index = 0; index <= clsItem.frmEditor.viewport.Entities.Count - 1; ++index)
    {
      buEntity copiedEntity = (buEntity) null;
      buEntity.Copy(clsItem.frmEditor.viewport.Entities[index], ref copiedEntity);
      if (copiedEntity != null)
        refEntities.Add(copiedEntity);
    }
    StringList.Add((object) (buString5.SpaceChar(num + 2) + "<DrawEntities>"));
    StringList.AddRange((ICollection) buEntity.ToDefEntity(refEntities, num + 4));
    StringList.Add((object) (buString5.SpaceChar(num + 2) + "</DrawEntities>"));
    StringList.Add((object) (buString5.SpaceChar(num + 2) + "<SortEntities>"));
    StringList.AddRange((ICollection) buEntity.ToDefEntity(this.sortedEntities, num + 4));
    StringList.Add((object) (buString5.SpaceChar(num + 2) + "</SortEntities>"));
    StringList.Add((object) (buString5.SpaceChar(num + 2) + "<ManuelSortClickResult>"));
    this.ManuelSortClickResult.ToDefAll("", num + 4);
    StringList.Add((object) (buString5.SpaceChar(num + 2) + "</ManuelSortClickResult>"));
    buFile5.SaveToFile(StringList, FileName);
  }

  public void Reset()
  {
    Sketcher2D.OrthoPossible = false;
    Sketcher2D.isAreaSelection = true;
    Sketcher2D.selectedIndex.Clear();
    clsItem.frmEditor.viewport.Entities.UpdateBoundingBox();
    clsItem.frmEditor.pnl_foamsort.Visible = false;
    if (clsInit.appSewing != null)
    {
      if (clsInit.appSewing.frmMove != null)
      {
        if (clsInit.appSewing.frmMove.Visible)
          clsInit.appSewing.JobUpdate();
        clsInit.appSewing.frmMove.Visible = false;
      }
      if (clsInit.appSewing.frmRotate != null)
      {
        if (clsInit.appSewing.frmRotate.Visible)
          clsInit.appSewing.JobUpdate();
        clsInit.appSewing.frmRotate.Visible = false;
      }
      if (clsInit.appSewing.frmSelectVertex != null)
      {
        if (clsInit.appSewing.frmSelectVertex.Visible)
          clsInit.appSewing.JobUpdate();
        clsInit.appSewing.frmSelectVertex.Visible = false;
      }
      if (clsVar.varEditorRuntimeSet.isSewingMode)
      {
        for (int index = 0; index <= clsItem.frmEditor.viewport.Entities.Count - 1; ++index)
        {
          if (clsItem.frmEditor.viewport.Entities[index] is Joint)
            clsItem.frmEditor.viewport.Entities[index].Visible = true;
        }
      }
      clsInit.appSewing.baseSelected = (SewingSelectedPoint) null;
      clsInit.appSewing.Selected.Clear();
      SewingTempVars.DrawType = SewingDrawType.None;
      SewingTempVars.DrawCommand = SewingDrawCommand.None;
    }
    clsItem.frmEditor.viewport.Entities.ClearSelection();
    for (int index = 0; index <= clsItem.frmEditor.viewport.Entities.Count - 1; ++index)
      clsItem.frmEditor.viewport.Entities[index].Selectable = true;
    clsItem.frmEditor.viewport.Invalidate();
    clsItem.frmEditor.lbl_value.Visible = false;
    clsItem.frmEditor.spn_value.Visible = false;
    Sketcher2D.selectedCircle.Clear();
    Sketcher2D.selectedPoint.Clear();
    Sketcher2D.isDrawing = false;
    Sketcher2D.isSelectionDone = false;
    Sketcher2D.selectionProcess = true;
    Sketcher2D.rightClickCnt = 0;
    Sketcher2D.firstSelectedEntity = (Entity) null;
    Sketcher2D.secondSelectedEntity = (Entity) null;
    clsVar.varEditorRuntimeSet.OsnapEntityDisable = false;
    clsVar.varEditorRuntimeSet.OsnapGridDisable = false;
    clsVar.varEditorRuntimeSet.OsnapOverDisable = false;
    clsVar.varEditorRuntimeSet.OsnapPointDisable = false;
    Sketcher2D.Clicks.Clear();
    if (Sketcher2D.entitiesSelected != null)
      Sketcher2D.entitiesSelected.Clear();
    clsInit.appEditor.action = actionTypeBU.None;
    this.StatusUpdate("", "");
    this.ShowCheckArea(false, false);
    this.ShowValueArea(false);
    clsItem.frmEditor.viewport.Invalidate();
  }

  internal delegate void Delegate3();
}
