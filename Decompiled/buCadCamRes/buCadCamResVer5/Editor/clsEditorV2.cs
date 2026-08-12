// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Editor.clsEditorV2
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buControls.DialogBox;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.buEntities;
using devDept;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Control.Labels;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;
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

public class clsEditorV2
{
  public SortbuSettings ManuelSortSetting = new SortbuSettings();
  public SortPointClickResult ManuelSortClickResult = new SortPointClickResult();
  public List<buEntity> sortRefEntities = new List<buEntity>();
  public List<buEntity> sortedEntities = new List<buEntity>();
  public int sortedEntitiesSimIndex = -1;
  public List<Pnt6DSimMove> sortedEntitiesSimPoints = new List<Pnt6DSimMove>();
  public List<List<Entity>> bufferedEntity = new List<List<Entity>>();
  public List<List<Entity>> bufferedRedoEntity = new List<List<Entity>>();
  public bool SimStarted = false;
  public bool DxfImported = false;
  public Timer timSim = (Timer) null;
  public readonly SketchEntity.CameraSettings SketchCameraSettings = new SketchEntity.CameraSettings();
  public List<EditorCustomData> OpenCustomData = new List<EditorCustomData>();
  public actionTypeBU action = actionTypeBU.None;
  public int? _filletChamferIndex;
  public VectorClock _clock = (VectorClock) null;
  public Tuple<ICurve, ICurve, ICurve>[] _filletsChamfers;
  public int SelectedDrawing = -1;
  public int SelectedConstraint = -1;
  public FileInfo FIZip = (FileInfo) null;
  private int int_0 = 0;
  public string ActiveLayerName = "Default";

  public void Init()
  {
    if (this.timSim != null)
      return;
    this.timSim = new Timer();
    this.timSim.Tick += new EventHandler(this.Sim_Tick);
    this.timSim.Interval = 10;
  }

  public void cmdNew()
  {
    if (clsItem.frmEditorV2 == null || clsItem.frmEditorV2.viewport == null)
      return;
    this.UndoBuffer();
    clsItem.frmEditorV2.viewport.ClearAllPreviousCommandData();
    clsItem.frmEditorV2.viewport.Entities.Clear();
    clsItem.frmEditorV2.viewport.Entities.UpdateBoundingBox();
    clsItem.frmEditorV2.viewport.Invalidate();
    this.JobUpdate();
  }

  public void cmdOpen(string FileName = "")
  {
    try
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.InitialDirectory = clsVar.varInterface.pathEditor;
      for (int index = 0; index < clsItem.frmEditorV2.OpenFileExtension.Count; ++index)
      {
        string filter = clsItem.frmEditorV2.OpenFileExtension[index];
        openFileDialog.Filter = index == 0 ? filter : openFileDialog.Filter + "|" + filter;
      }
      openFileDialog.FilterIndex = clsVar.varInterface.indexFileEditor;
      bool useProvidedFile = !string.IsNullOrWhiteSpace(FileName) && System.IO.File.Exists(FileName);
      if (useProvidedFile)
        openFileDialog.FileName = FileName;
      else if (openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      string selectedFile = openFileDialog.FileName;
      string extension = buFile5.getFileExtension(selectedFile).ToLower();
      List<Entity> openedEntities = new List<Entity>();
      bool supported = false;
      this.UndoBuffer();
      if (extension == ".dxf" || extension == ".dwg")
      {
        buFile5.OpenDxfDwg(ref openedEntities, selectedFile);
        supported = true;
      }
      else if (extension == ".bucadv5")
      {
        clsInit.appFiles.OpenBuCadFileVer5(selectedFile, true, ref openedEntities);
        supported = true;
      }
      else if (extension == ".buteach")
      {
        List<EntitiesGroup> groups = new List<EntitiesGroup>();
        clsInit.appFiles.OpenBuTeachFile(selectedFile, ref groups);
        for (int groupIndex = 0; groupIndex < groups.Count; ++groupIndex)
        {
          if (groups[groupIndex].Outside != null)
            openedEntities.AddRange(groups[groupIndex].Outside);
          if (groups[groupIndex].Inside != null)
          {
            for (int insideIndex = 0; insideIndex < groups[groupIndex].Inside.Count; ++insideIndex)
              openedEntities.AddRange(groups[groupIndex].Inside[insideIndex]);
          }
        }
        supported = true;
      }
      if (!supported)
        throw new NotSupportedException("Unsupported editor file type: " + extension);
      clsItem.frmEditorV2.viewport.ClearAllPreviousCommandData();
      clsItem.frmEditorV2.viewport.Entities.Clear();
      for (int index = 0; index < openedEntities.Count; ++index)
        clsItem.frmEditorV2.viewport.Entities.Add(openedEntities[index]);
      clsItem.frmEditorV2.viewport.Entities.RegenAllCurved();
      clsItem.frmEditorV2.viewport.Entities.UpdateBoundingBox();
      clsItem.frmEditorV2.viewport.SetView(viewType.Top);
      clsItem.frmEditorV2.viewport.ZoomFit();
      clsItem.frmEditorV2.viewport.Invalidate();
      clsVar.varInterface.indexFileEditor = openFileDialog.FilterIndex;
      clsVar.varInterface.pathEditor = buFile5.GetPath(selectedFile);
      clsFiles.SaveParameter();
      this.JobUpdate();
    }
    catch (Exception ex)
    {
      this.StatusUpdate(ex.Message, "Open");
      buLog.addLog("", "Not Ok: " + ex.Message, nameof (cmdOpen));
    }
  }

  public void cmdSave()
  {
    try
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.InitialDirectory = clsVar.varInterface.pathEditor;
      saveFileDialog.Filter = "Autocad DXF (*.dxf)|*.dxf|Autocad DWG (*.dwg)|*.dwg|buCadCam V5 (*.bucadv5)|*.bucadv5";
      saveFileDialog.FilterIndex = Math.Max(1, Math.Min(3, clsVar.varInterface.indexFileEditor));
      if (saveFileDialog.ShowDialog() != DialogResult.OK)
        return;
      List<Entity> copiedEnt = new List<Entity>();
      buVector5.CopyEntities(clsItem.frmEditorV2.viewport.Entities, ref copiedEnt);
      if (clsItem.frmEditorV2.viewport.CurrentSketch != null && clsItem.frmEditorV2.viewport.CurrentSketch.Editing)
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
      string extension = buFile5.getFileExtension(saveFileDialog.FileName).ToLower();
      if (extension == ".dxf" || extension == ".dwg")
        buFile5.SaveDxfDwg(copiedEnt, saveFileDialog.FileName);
      else if (extension == ".bucadv5")
        this.SaveBuCadEditorFile(saveFileDialog.FileName);
      else
        throw new NotSupportedException("Unsupported editor file type: " + extension);
      clsVar.varInterface.indexFileEditor = saveFileDialog.FilterIndex;
      clsVar.varInterface.pathEditor = buFile5.GetPath(saveFileDialog.FileName);
      clsFiles.SaveParameter();
    }
    catch (Exception ex)
    {
      this.StatusUpdate(ex.Message, "Save");
      buLog.addLog("", "Not Ok: " + ex.Message, nameof (cmdSave));
    }
  }

  private void SaveBuCadEditorFile(string FileName)
  {
    string tempDirectoryPath = Path.Combine(Path.GetTempPath(), "buCadEditor_" + Guid.NewGuid().ToString("N"));
    string tempArchivePath = Path.Combine(Path.GetTempPath(), "buCadEditor_" + Guid.NewGuid().ToString("N") + ".tmp");
    DirectoryInfo tempDirectory = Directory.CreateDirectory(tempDirectoryPath);
    try
    {
      string pageName = buFile5.getFileNameWithoutExtension(FileName) + ".bupage";
      WriteFileParams writeFileParams = new WriteFileParams(clsItem.frmEditorV2.viewport.Document);
      writeFileParams.Content = contentType.GeometryAndTessellation;
      writeFileParams.SerializationMode = serializationType.Uncompressed;
      writeFileParams.SelectedOnly = false;
      writeFileParams.Purge = false;
      writeFileParams.Tag = MyFileSerializer.CustomTag;
      new WriteFile(writeFileParams, Path.Combine(tempDirectory.FullName, pageName), (FileSerializer) new MyFileSerializer()).DoWork();
      buFile.ZipFolderToFile(tempDirectory.FullName, tempArchivePath);
      FileInfo archive = new FileInfo(tempArchivePath);
      if (!archive.Exists || archive.Length == 0L)
        throw new IOException("The editor archive could not be created.");
      System.IO.File.Copy(tempArchivePath, FileName, true);
    }
    finally
    {
      if (tempDirectory.Exists)
        tempDirectory.Delete(true);
      if (System.IO.File.Exists(tempArchivePath))
        System.IO.File.Delete(tempArchivePath);
    }
  }

  public void cmdInsert(ref List<Entity> refEntities)
  {
    OpenFileDialog openFileDialog = new OpenFileDialog();
    openFileDialog.InitialDirectory = clsVar.varInterface.pathEditor;
    if (clsItem.frmEditorV2.OpenFileExtension.Count == 0)
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
      for (int index = 0; index <= clsItem.frmEditorV2.OpenFileExtension.Count - 1; ++index)
      {
        if (index == 0)
          openFileDialog.Filter = clsItem.frmEditorV2.OpenFileExtension[index].ToString();
        else
          openFileDialog.Filter = $"{openFileDialog.Filter}|{clsItem.frmEditorV2.OpenFileExtension[index].ToString()}";
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
    try
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.InitialDirectory = clsVar.varLibrary.pathLibrary;
      openFileDialog.Filter = "buCad/Cam Library File (*.bulib5)|*.bulib5";
      openFileDialog.FilterIndex = 1;
      if (openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      string extractionPath = AppPath.Base + "\\L";
      DirectoryInfo extractionDirectory = new DirectoryInfo(extractionPath);
      if (extractionDirectory.Exists)
        extractionDirectory.Delete(true);
      Directory.CreateDirectory(extractionPath);
      buFile5.ExtractToFolder(extractionPath, openFileDialog.FileName);
      List<string> Files = new List<string>();
      buFile5.getFiles(extractionPath, ref Files);
      string filePath = "";
      this.OpenCustomData = new List<EditorCustomData>();
      for (int index = 0; index <= Files.Count - 1; ++index)
      {
        FileInfo fileInfo = new FileInfo(Files[index]);
        if (!fileInfo.Exists)
          continue;
        if (string.Equals(fileInfo.Extension, ".buLibEye", StringComparison.OrdinalIgnoreCase))
        {
          if (filePath.Length > 0)
            throw new InvalidDataException("The library contains more than one geometry document.");
          filePath = fileInfo.FullName;
        }
        if (string.Equals(fileInfo.Extension, ".buLibSet", StringComparison.OrdinalIgnoreCase))
          this.OpenEditorCustomDataToFile(fileInfo.FullName, ref this.OpenCustomData);
      }
      if (filePath.Length <= 0)
        throw new InvalidDataException("The library does not contain a geometry document.");
      this.UndoBuffer();
      ReadFile readFile = new ReadFile(filePath);
      clsItem.frmEditorV2.viewport.Clear();
      clsItem.frmEditorV2.viewport.StartWork((WorkUnit) readFile);
      clsVar.varLibrary.pathLibrary = buFile5.GetPath(openFileDialog.FileName);
      clsFiles.SaveParameter();
    }
    catch (Exception ex)
    {
      this.ReportCommandError(ex, nameof (cmdOpenLib));
    }
  }

  public void cmdSaveLib(Design Viewport)
  {
    if (Viewport == null)
      return;
    SketchEntity sketch = Viewport.CurrentSketch;
    bool wasEditing = sketch != null && sketch.Editing;
    string tempDirectoryPath = Path.Combine(Path.GetTempPath(), "buCadLibrary_" + Guid.NewGuid().ToString("N"));
    string tempArchivePath = Path.Combine(Path.GetTempPath(), "buCadLibrary_" + Guid.NewGuid().ToString("N") + ".tmp");
    DirectoryInfo tempDirectory = null;
    try
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.InitialDirectory = clsVar.varLibrary.pathLibrary;
      saveFileDialog.Filter = "buCad/Cam Library File (*.bulib5)|*.bulib5";
      saveFileDialog.FilterIndex = 1;
      if (saveFileDialog.ShowDialog((IWin32Window) clsItem.frmEditorV2) != DialogResult.OK)
        return;
      if (sketch == null)
      {
        for (int index = 0; index < Viewport.Entities.Count; ++index)
        {
          if (Viewport.Entities[index] is SketchEntity)
          {
            sketch = (SketchEntity) Viewport.Entities[index];
            wasEditing = sketch.Editing;
            break;
          }
        }
      }
      if (sketch == null)
        throw new InvalidOperationException("No sketch is available to save as a library.");
      if (sketch.Editing)
        sketch.Exit();
      Viewport.Entities.Regen();
      Viewport.Invalidate();
      tempDirectory = Directory.CreateDirectory(tempDirectoryPath);
      string withoutExtension = buFile5.getFileNameWithoutExtension(saveFileDialog.FileName);
      string eyePath = Path.Combine(tempDirectory.FullName, withoutExtension + ".buLibEye");
      string settingsPath = Path.Combine(tempDirectory.FullName, withoutExtension + ".buLibSet");
      this.SaveEditorCustomDataToFile(Viewport, settingsPath);
      new WriteFile(new WriteFileParams(Viewport.Document), eyePath).DoWork();
      buFile5.ZipFolderToFile(tempDirectory.FullName, tempArchivePath);
      FileInfo archive = new FileInfo(tempArchivePath);
      if (!archive.Exists || archive.Length == 0L)
        throw new IOException("The library archive could not be created.");
      System.IO.File.Copy(tempArchivePath, saveFileDialog.FileName, true);
      clsVar.varLibrary.pathLibrary = buFile5.GetPath(saveFileDialog.FileName);
      clsFiles.SaveParameter();
    }
    catch (Exception ex)
    {
      this.ReportCommandError(ex, nameof (cmdSaveLib));
    }
    finally
    {
      if (tempDirectory != null && tempDirectory.Exists)
        tempDirectory.Delete(true);
      if (System.IO.File.Exists(tempArchivePath))
        System.IO.File.Delete(tempArchivePath);
      if (sketch != null && wasEditing && !sketch.Editing)
      {
        sketch.Edit((IDesign) Viewport);
        Viewport.Entities.Regen();
        Viewport.Invalidate();
        this.JobUpdate();
      }
    }
  }

  public void cmdDeleteEntity(Entity Ent)
  {
    if (Ent == null || clsItem.frmEditorV2.viewport.CurrentSketch == null)
      return;
    clsItem.frmEditorV2.viewport.CurrentSketch.DeleteEntity(Ent);
    clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
    clsItem.frmEditorV2.viewport.Invalidate();
    this.JobUpdate();
  }

  public void cmdUndo()
  {
    if (clsItem.frmEditorV2.viewport.CurrentSketch != null)
      Class5.smethod_65(new clsEditorV2.Delegate2(clsItem.frmEditorV2.viewport.CurrentSketch.Undo), this);
    else
      this.UndoGetBack();
  }

  public void cmdRedo()
  {
    if (clsItem.frmEditorV2.viewport.CurrentSketch != null)
      Class5.smethod_65(new clsEditorV2.Delegate2(clsItem.frmEditorV2.viewport.CurrentSketch.Redo), this);
    else
      this.RedoGetBack();
  }

  public void cmdShowContrraint(bool Show)
  {
    foreach (devDept.Eyeshot.Control.Labels.Label label in (EyeshotCollection<devDept.Eyeshot.Control.Labels.Label>) clsItem.frmEditorV2.viewport.ActiveViewport.Labels)
    {
      if (label is StackedLabel)
        (label as StackedLabel).Visible = Show;
    }
    clsItem.frmEditorV2.viewport.Invalidate();
  }

  public void cmdShowDimension(bool Show)
  {
    foreach (Entity entity in (EyeshotCollection<Entity>) clsItem.frmEditorV2.viewport.Entities)
    {
      if (entity is Dimension)
        entity.Visible = Show;
    }
    clsItem.frmEditorV2.viewport.Invalidate();
  }

  public void cmdEventsOk()
  {
    try
    {
      if (clsInit.appEditor2.action == actionTypeBU.eventScale)
      {
        clsInit.cVector5.BoxSizeCalculateSelected(clsItem.frmEditorV2.viewport.Entities, ref Drafting2D.boxMin, ref Drafting2D.boxMid, ref Drafting2D.boxMax);
        clsVar.varEditorRuntimeSet.ScaleRatio = clsItem.frmEditorV2.spn_scaleratio.Value;
        clsItem.frmEditorV2.viewport.EventScale(true, clsVar.varEditorRuntimeSet.ScaleRatio);
      }
      else if (clsInit.appEditor2.action == actionTypeBU.eventExplode)
      {
        clsItem.frmEditorV2.viewport.EventExplode();
      }
    }
    catch (Exception ex)
    {
      this.ReportCommandError(ex, nameof (cmdEventsOk));
    }
  }

  public void cmdEventsMove()
  {
    try
    {
      Drafting2D.points.Clear();
      clsInit.appEditor2.action = actionTypeBU.eventMove;
      Drafting2D.entitiesSelected.Clear();
      clsInit.cVector5.getSelectedEntitiesCount(clsItem.frmEditorV2.viewport.Entities, ref this.int_0);
      if (this.int_0 == 0)
      {
        clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.SelectEntities, buLangTranslate.preDef.Move);
        Drafting2D.selectionProcess = true;
      }
      else
      {
        clsItem.frmEditorV2.viewport.EventCopyToSelected();
        clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineReferancePoint, buLangTranslate.preDef.Move);
        Drafting2D.selectionProcess = false;
      }
    }
    catch (Exception ex)
    {
      this.ReportCommandError(ex, nameof (cmdEventsMove));
    }
  }

  public void cmdEventsCopy()
  {
    try
    {
      Drafting2D.points.Clear();
      clsInit.appEditor2.action = actionTypeBU.eventCopy;
      Drafting2D.entitiesSelected.Clear();
      clsInit.cVector5.getSelectedEntitiesCount(clsItem.frmEditorV2.viewport.Entities, ref this.int_0);
      if (this.int_0 == 0)
      {
        clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.SelectEntities, buLangTranslate.preDef.Copy);
        Drafting2D.selectionProcess = true;
      }
      else
      {
        clsItem.frmEditorV2.viewport.EventCopyToSelected();
        clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineReferancePoint, buLangTranslate.preDef.Copy);
        Drafting2D.selectionProcess = false;
      }
    }
    catch (Exception ex)
    {
      this.ReportCommandError(ex, nameof (cmdEventsCopy));
    }
  }

  public void cmdEventsMirror()
  {
    try
    {
      Drafting2D.points.Clear();
      clsInit.appEditor2.action = actionTypeBU.eventMirror;
      Drafting2D.entitiesSelected.Clear();
      clsInit.cVector5.getSelectedEntitiesCount(clsItem.frmEditorV2.viewport.Entities, ref this.int_0);
      if (this.int_0 == 0)
      {
        clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.SelectEntities, buLangTranslate.preDef.Mirror);
        Drafting2D.selectionProcess = true;
      }
      else
      {
        clsItem.frmEditorV2.viewport.EventCopyToSelected();
        clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineReferancePoint, buLangTranslate.preDef.Mirror);
        Drafting2D.selectionProcess = false;
      }
    }
    catch (Exception ex)
    {
      this.ReportCommandError(ex, nameof (cmdEventsMirror));
    }
  }

  public void cmdEventsOffset()
  {
    try
    {
      this.ShowValueArea(actionTypeBU.eventOffset, true, 260, 110, buLangTranslate.preDef.Offset, clsVar.varEditorRuntimeSet.OffsetValue, -10000000.0);
      Drafting2D.points.Clear();
      clsInit.appEditor2.action = actionTypeBU.eventOffset;
      Drafting2D.entitiesSelected.Clear();
      clsInit.cVector5.getSelectedEntitiesCount(clsItem.frmEditorV2.viewport.Entities, ref this.int_0);
      if (this.int_0 == 0)
      {
        clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.SelectEntities, buLangTranslate.preDef.Offset);
        Drafting2D.selectionProcess = true;
      }
      else
      {
        clsItem.frmEditorV2.viewport.EventCopyToSelected();
        clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineOffsetPoint, buLangTranslate.preDef.Offset);
        Drafting2D.selectionProcess = false;
      }
    }
    catch (Exception ex)
    {
      this.ReportCommandError(ex, nameof (cmdEventsOffset));
    }
  }

  public void cmdEventsRotate()
  {
    try
    {
      Drafting2D.points.Clear();
      clsInit.appEditor2.action = actionTypeBU.eventRotate;
      Drafting2D.entitiesSelected.Clear();
      clsInit.cVector5.getSelectedEntitiesCount(clsItem.frmEditorV2.viewport.Entities, ref this.int_0);
      if (this.int_0 == 0)
      {
        clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.SelectEntities, buLangTranslate.preDef.Rotate);
        Drafting2D.selectionProcess = true;
      }
      else
      {
        clsItem.frmEditorV2.viewport.EventCopyToSelected();
        clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineCenterPoint, buLangTranslate.preDef.Rotate);
        Drafting2D.selectionProcess = false;
      }
    }
    catch (Exception ex)
    {
      this.ReportCommandError(ex, nameof (cmdEventsRotate));
    }
  }

  public void cmdEventsBreak()
  {
    try
    {
      Drafting2D.points.Clear();
      clsInit.appEditor2.action = actionTypeBU.eventBreak;
      Drafting2D.entitiesSelected.Clear();
      clsInit.cVector5.getSelectedEntitiesCount(clsItem.frmEditorV2.viewport.Entities, ref this.int_0);
      clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineBreakPoint, buLangTranslate.preDef.Break);
      Drafting2D.selectionProcess = false;
    }
    catch (Exception ex)
    {
      this.ReportCommandError(ex, nameof (cmdEventsBreak));
    }
  }

  public void cmdEventsScale()
  {
    try
    {
      this.ShowValueArea(actionTypeBU.eventScale, true, 260, 90, buLangTranslate.preDef.Scale, clsVar.varEditorRuntimeSet.ScaleRatio, 0.0, ButtonShow: true);
      Drafting2D.points.Clear();
      clsInit.appEditor2.action = actionTypeBU.eventScale;
      Drafting2D.entitiesSelected.Clear();
      clsInit.cVector5.getSelectedEntitiesCount(clsItem.frmEditorV2.viewport.Entities, ref this.int_0);
      if (this.int_0 == 0)
      {
        clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.SelectEntities, buLangTranslate.preDef.Scale);
        Drafting2D.selectionProcess = true;
      }
      else
      {
        clsItem.frmEditorV2.viewport.EventCopyToSelected();
        clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineFirstPoint, buLangTranslate.preDef.Scale);
        Drafting2D.selectionProcess = false;
      }
    }
    catch (Exception ex)
    {
      this.ReportCommandError(ex, nameof (cmdEventsScale));
    }
  }

  public void cmdEventsLinearArray()
  {
    try
    {
      this.ShowValueArea(false);
      Drafting2D.points.Clear();
      clsInit.appEditor2.action = actionTypeBU.eventLineerArray;
      Drafting2D.entitiesSelected.Clear();
      clsInit.cVector5.getSelectedEntitiesCount(clsItem.frmEditorV2.viewport.Entities, ref this.int_0);
      if (this.int_0 == 0)
      {
        clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.SelectEntities, buLangTranslate.preDef.Array);
        Drafting2D.selectionProcess = true;
      }
      else
      {
        clsItem.frmEditorV2.viewport.EventCopyToSelected();
        clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineFirstPoint, buLangTranslate.preDef.Array);
        Drafting2D.selectionProcess = false;
      }
    }
    catch (Exception ex)
    {
      this.ReportCommandError(ex, nameof (cmdEventsLinearArray));
    }
  }

  public void cmdEventsExplode()
  {
    try
    {
      this.ShowValueArea(actionTypeBU.eventExplode, true, 330, 260, "Explode / Ungroup", ButtonShow: true);
      Drafting2D.points.Clear();
      clsInit.appEditor2.action = actionTypeBU.eventExplode;
      Drafting2D.entitiesSelected.Clear();
      clsInit.cVector5.getSelectedEntitiesCount(clsItem.frmEditorV2.viewport.Entities, ref this.int_0);
      if (this.int_0 == 0)
      {
        clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.SelectEntities, "Explode");
        Drafting2D.selectionProcess = true;
      }
      else
      {
        clsItem.frmEditorV2.viewport.EventCopyToSelected();
        Drafting2D.selectionProcess = false;
      }
    }
    catch (Exception ex)
    {
      this.ReportCommandError(ex, nameof (cmdEventsExplode));
    }
  }

  public void cmdEventsExtend()
  {
    try
    {
      this.ShowValueArea(actionTypeBU.eventExtend, true, 260, 90, buLangTranslate.preDef.Extend, clsVar.varEditorRuntimeSet.ExtendLength, MaxVal: 1000000.0);
      Drafting2D.points.Clear();
      clsInit.appEditor2.action = actionTypeBU.eventExtend;
      Drafting2D.entitiesSelected.Clear();
      clsInit.cVector5.getSelectedEntitiesCount(clsItem.frmEditorV2.viewport.Entities, ref this.int_0);
      clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineExtendPoint, buLangTranslate.preDef.Extend);
      Drafting2D.selectionProcess = false;
    }
    catch (Exception ex)
    {
      this.ReportCommandError(ex, nameof (cmdEventsExtend));
    }
  }

  public void cmdEventsTrim()
  {
    try
    {
      Drafting2D.entToTrim = (Entity) null;
      Drafting2D.leftOvers = new List<Entity>();
      Drafting2D.points.Clear();
      clsInit.appEditor2.action = actionTypeBU.eventTrim;
      Drafting2D.entitiesSelected.Clear();
      clsInit.cVector5.getSelectedEntitiesCount(clsItem.frmEditorV2.viewport.Entities, ref this.int_0);
      clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineTrimPoint, buLangTranslate.preDef.Trim);
      Drafting2D.selectionProcess = false;
    }
    catch (Exception ex)
    {
      this.ReportCommandError(ex, nameof (cmdEventsTrim));
    }
  }

  public void cmdEventsFillet()
  {
    try
    {
      this.ShowValueArea(actionTypeBU.eventFillet, true, 260, 90, buLangTranslate.preDef.Fillet, clsVar.varEditorRuntimeSet.FilletRadius, 0.0, 1000000.0);
      Drafting2D.NoRectangleSelection = true;
      Drafting2D.points.Clear();
      clsInit.appEditor2.action = actionTypeBU.eventFillet;
      Drafting2D.entitiesSelected.Clear();
      clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.SelectFirstEntity, buLangTranslate.preDef.Fillet);
      Drafting2D.selectionProcess = true;
    }
    catch (Exception ex)
    {
      this.ReportCommandError(ex, nameof (cmdEventsFillet));
    }
  }

  public void cmdEventsChamfer()
  {
    this.ShowValueArea(actionTypeBU.eventChamfer, true, 260, 90, buLangTranslate.preDef.Chamfer, clsVar.varEditorRuntimeSet.ChamferLength, 0.0, 1000000.0);
    Drafting2D.NoRectangleSelection = true;
    Drafting2D.points.Clear();
    clsInit.appEditor2.action = actionTypeBU.eventChamfer;
    Drafting2D.entitiesSelected.Clear();
    clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.SelectFirstEntity, buLangTranslate.preDef.Chamfer);
    Drafting2D.selectionProcess = true;
  }

  public void cmdEventsDelete()
  {
    Drafting2D.points.Clear();
    clsInit.cVector5.getSelectedEntitiesCount(clsItem.frmEditorV2.viewport.Entities, ref this.int_0);
    if (this.int_0 == 0)
    {
      clsInit.appEditor2.action = actionTypeBU.eventDelete;
      clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.SelectEntities, buLangTranslate.preDef.Delete);
      Drafting2D.selectionProcess = true;
    }
    else
      clsItem.frmEditorV2.viewport.EventDelete();
  }

  public void cmdEventsAlingLeft(AlignmentEvent Type)
  {
    this.ShowValueArea(false);
    if (Type == AlignmentEvent.Left)
      clsInit.appEditor2.action = actionTypeBU.eventAlingLeft;
    if (Type == AlignmentEvent.Right)
      clsInit.appEditor2.action = actionTypeBU.eventAlingRight;
    if (Type == AlignmentEvent.Top)
      clsInit.appEditor2.action = actionTypeBU.eventAlingTop;
    if (Type == AlignmentEvent.Bottom)
      clsInit.appEditor2.action = actionTypeBU.eventAlingBottom;
    if (Type == AlignmentEvent.HorizontalCenter)
      clsInit.appEditor2.action = actionTypeBU.eventAlingHorizontal;
    if (Type == AlignmentEvent.VerticalCenter)
      clsInit.appEditor2.action = actionTypeBU.eventAlingVertical;
    Sketcher2D.isAreaSelection = true;
    Sketcher2D.Clicks.Clear();
    Sketcher2D.entitiesSelected.Clear();
    Sketcher2D.selectedIndex.Clear();
    clsInit.appEditor2.StatusUpdate(AppLanguage.CadCamStatus[10], buLangTranslate.preDef.Move);
    Sketcher2D.selectionProcess = true;
  }

  public void cmdEventsEqualDistance(EqualDistance Type)
  {
    this.ShowValueArea(true, buLangTranslate.preDef.Distance, clsVar.varEditorRuntimeSet.EqualDistance);
    if (Type == EqualDistance.Horizontal)
      clsInit.appEditor2.action = actionTypeBU.eventEqualHorizontal;
    if (Type == EqualDistance.Vertical)
      clsInit.appEditor2.action = actionTypeBU.eventEqualVertical;
    Sketcher2D.isAreaSelection = true;
    Sketcher2D.Clicks.Clear();
    Sketcher2D.entitiesSelected.Clear();
    Sketcher2D.selectedIndex.Clear();
    clsInit.appEditor2.StatusUpdate(AppLanguage.CadCamStatus[10], buLangTranslate.preDef.Move);
    Sketcher2D.selectionProcess = true;
  }

  public void cmdEventsRotateValue(double Degree)
  {
    clsVar.varEditorRuntimeSet.LastRotateAngle = Degree;
    Sketcher2D.Clicks.Clear();
    clsInit.appEditor2.action = actionTypeBU.eventRotateValue;
    Sketcher2D.entitiesSelected.Clear();
    clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditorV2.viewport.Entities, false, ref Sketcher2D.entitiesSelected);
    if (Sketcher2D.entitiesSelected.Count == 0)
    {
      clsInit.appEditor2.StatusUpdate(AppLanguage.CadCamStatus[10], buLangTranslate.preDef.Rotate);
      Sketcher2D.selectionProcess = true;
    }
    else
      this.Rotate(Degree);
  }

  public void cmdEventsMirrorValue(HorizontalVertical Value)
  {
    clsVar.varEditorRuntimeSet.LastMirrorType = Value;
    Sketcher2D.Clicks.Clear();
    clsInit.appEditor2.action = actionTypeBU.eventMirrorValue;
    Sketcher2D.entitiesSelected.Clear();
    clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditorV2.viewport.Entities, false, ref Sketcher2D.entitiesSelected);
    if (Sketcher2D.entitiesSelected.Count == 0)
    {
      clsInit.appEditor2.StatusUpdate(AppLanguage.CadCamStatus[10], buLangTranslate.preDef.Mirror);
      Sketcher2D.selectionProcess = true;
    }
    else
      this.Mirror(Value);
  }

  public void StatusUpdate(string Message, string Command, string Args = "")
  {
    string str = "";
    if (Command.Length > 0)
      str = Command + " : ";
    clsItem.frmEditorV2.lbl_status.Text = $"{str}{Message} {Args}";
  }

  public void cmdSimStart()
  {
    this.CreateSimPointsFromSortedEntities();
    if (this.sortedEntitiesSimPoints.Count == 0)
    {
      this.SimStarted = false;
      this.timSim.Enabled = false;
      this.StatusUpdate("No valid simulation path", "Simulation");
      return;
    }
    this.SimStarted = true;
    if (this.sortedEntitiesSimIndex < 0 || this.sortedEntitiesSimIndex >= this.sortedEntitiesSimPoints.Count)
      this.sortedEntitiesSimIndex = 0;
    this.timSim.Enabled = true;
  }

  public void cmdSimStop()
  {
    this.timSim.Enabled = false;
    this.SimStarted = false;
    this.sortedEntitiesSimIndex = -1;
    this.RemoveSimArrow();
  }

  public void cmdSimFwd() => this.Sim_Tick((object) null, (EventArgs) null);

  public void cmdSimBwd()
  {
    int step = Math.Max(1, clsVar.varEditorSet.SimulationStep);
    this.sortedEntitiesSimIndex = Math.Max(0, this.sortedEntitiesSimIndex - step * 2);
    this.Sim_Tick((object) null, (EventArgs) null);
  }

  public void Sim_Tick(object sender, EventArgs e)
  {
    if (this.sortedEntitiesSimPoints.Count > 0 && this.sortedEntitiesSimIndex >= 0 && this.sortedEntitiesSimIndex <= this.sortedEntitiesSimPoints.Count - 1)
    {
        this.RemoveSimArrow();
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
        clsItem.frmEditorV2.viewport.Entities.Add((Entity) mesh);
        Text text = new Text(Plane.XY, new Point3D(entitiesSimPoint.X, entitiesSimPoint.Y - 6.0, entitiesSimPoint.Z), entitiesSimPoint.C.ToString("f1"), 20.0);
        text.EntityData = (object) new CustomData()
        {
          typeDefination = entityTypeDefination.Tool
        };
        text.Color = Color.Red;
        text.ColorMethod = colorMethodType.byEntity;
        clsItem.frmEditorV2.viewport.Entities.Add((Entity) text);
        if (clsVar.varEditorSet.SimulationStep <= 0)
          clsVar.varEditorSet.SimulationStep = 1;
        this.sortedEntitiesSimIndex += clsVar.varEditorSet.SimulationStep;
    }
    else
    {
      this.sortedEntitiesSimIndex = 0;
      this.timSim.Enabled = false;
      this.RemoveSimArrow();
    }
    clsItem.frmEditorV2.viewport.Invalidate();
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
    if (point3DList.Count < 2)
      return;
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
    for (int index = 0; index < 2 && clsItem.frmEditorV2.viewport.Entities.Count > 0; ++index)
    {
      Entity entity = clsItem.frmEditorV2.viewport.Entities[clsItem.frmEditorV2.viewport.Entities.Count - 1];
      CustomData customData = entity.EntityData as CustomData;
      if (customData == null || customData.typeDefination != entityTypeDefination.Tool)
        break;
      clsItem.frmEditorV2.viewport.Entities.RemoveAt(clsItem.frmEditorV2.viewport.Entities.Count - 1);
    }
    clsItem.frmEditorV2.viewport.Invalidate();
  }

  private void ReportCommandError(Exception ex, string command)
  {
    string message = ex == null ? "Unknown editor error" : ex.Message;
    this.StatusUpdate(message, command);
    buLog.addLog("", "Not Ok: " + message, command);
  }

  public void AddPoint(UClick start)
  {
    if (start == null)
      return;
    if (clsVar.varEditorRuntimeSet.isSketchMode)
    {
      devDept.Eyeshot.Entities.Point point = clsItem.frmEditorV2.viewport.CurrentSketch.AddPoint(start.Position);
      if (start.Entity != null)
      {
        double t = 0.0;
        ((ICurve) start.Entity).ClosestPointTo(new Point3D(start.Position.X, start.Position.Y), out t);
        clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintPointAt(point, start.Entity, 0.5);
        clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintPointOn(point, start.Entity);
      }
      clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
      this.JobUpdate();
    }
    else
    {
      this.UndoBuffer();
      devDept.Eyeshot.Entities.Point entity_0 = new devDept.Eyeshot.Entities.Point(new Point3D(start.Position.X, start.Position.Y));
      clsItem.frmEditorV2.viewport.method_18((Entity) entity_0, this.ActiveLayerName, true, true);
    }
  }

  public Line AddLine(UClick start, UClick end)
  {
    if (start == null || end == null || Point2D.Distance(start.Position, end.Position) <= 1E-09)
      return null;
    Line line;
    if (clsVar.varEditorRuntimeSet.isSketchMode)
    {
      Line line_0 = clsItem.frmEditorV2.viewport.CurrentSketch.AddLine(start.Position, end.Position);
      if (start.Entity != null)
        clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditorV2.viewport.CurrentSketch.StartPoint((ICurve) line_0), start.Entity);
      if (end.Entity != null)
        clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditorV2.viewport.CurrentSketch.EndPoint((ICurve) line_0), end.Entity);
      if ((start.Entity == null ? 1 : (end.Entity == null ? 1 : 0)) != 0)
        Class5.smethod_177(this, line_0);
      clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
      this.JobUpdate();
      line = line_0;
    }
    else
    {
      this.UndoBuffer();
      Line entity_0 = new Line(new Point3D(start.Position.X, start.Position.Y), new Point3D(end.Position.X, end.Position.Y));
      clsItem.frmEditorV2.viewport.method_18((Entity) entity_0, this.ActiveLayerName, false, true);
      line = entity_0;
    }
    return line;
  }

  public LinearPath AddPolyLine(List<UClick> refPoints)
  {
    if (refPoints == null || refPoints.Count < 2)
      return null;
    List<Point3D> points = new List<Point3D>();
    for (int index = 0; index <= refPoints.Count - 1; ++index)
      points.Add(new Point3D(refPoints[index].Position.X, refPoints[index].Position.Y));
    if (points.Distinct<Point3D>().Count<Point3D>() < 2)
      return null;
    this.UndoBuffer();
    LinearPath entity_0 = new LinearPath((ICollection<Point3D>) points);
    clsItem.frmEditorV2.viewport.method_18((Entity) entity_0, this.ActiveLayerName, true, true);
    return entity_0;
  }

  public void AddRectangle(UClick start, UClick end)
  {
    if (start == null || end == null || Math.Abs(start.Position.X - end.Position.X) <= 1E-09 || Math.Abs(start.Position.Y - end.Position.Y) <= 1E-09)
      return;
    if (clsVar.varEditorRuntimeSet.isSketchMode)
    {
      Point2D position1 = start.Position;
      Point2D position2 = end.Position;
      double width = Math.Abs(position1.X - position2.X);
      double height = Math.Abs(position1.Y - position2.Y);
      double x = Math.Min(position1.X, position2.X);
      double y = Math.Min(position1.Y, position2.Y);
      Entity[] entity_1 = clsItem.frmEditorV2.viewport.CurrentSketch.AddRectangle(x, y, width, height, lengthConstraints: false);
      int int_0;
      int int_1;
      Class5.smethod_116(position1, position2, out int_0, this, ref int_1);
      Class5.smethod_145(int_0, this, start.Entity, entity_1);
      Class5.smethod_145(int_1, this, end.Entity, entity_1);
      clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
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
      clsItem.frmEditorV2.viewport.method_18((Entity) rectangle, this.ActiveLayerName, true, true);
    }
  }

  public void AddEllipse(UClick start, UClick end)
  {
    if (start == null || end == null)
      return;
    double ellipseRadiusX = Math.Abs(start.Position.X - end.Position.X);
    double ellipseRadiusY = Math.Abs(start.Position.Y - end.Position.Y);
    if (ellipseRadiusX <= 0.001 || ellipseRadiusY <= 0.001)
      return;
    if (clsVar.varEditorRuntimeSet.isSketchMode)
    {
      UClick uclick = start;
      Point2D position = uclick.Position;
      double radiusX = position.DistanceTo(new Point2D(end.Position.X, position.Y));
      double radiusY = position.DistanceTo(new Point2D(position.X, end.Position.Y));
      if ((radiusX <= 0.001 ? 0 : (radiusY > 0.001 ? 1 : 0)) != 0)
      {
        Ellipse ellipse = clsItem.frmEditorV2.viewport.CurrentSketch.AddEllipse(position, radiusX, radiusY);
        if (uclick.Entity != null)
          clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditorV2.viewport.CurrentSketch.CenterPoint(ellipse), uclick.Entity);
      }
      clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
      this.Reset();
      this.JobUpdate();
    }
    else
    {
      this.UndoBuffer();
      Ellipse ellipse = new Ellipse(Plane.XY, start.Position, ellipseRadiusX, ellipseRadiusY);
      clsItem.frmEditorV2.viewport.method_18((Entity) ellipse, this.ActiveLayerName, true, true);
    }
  }

  public void AddEllipse(Ellipse Ent)
  {
    if (Ent == null)
      return;
    this.UndoBuffer();
    clsItem.frmEditorV2.viewport.method_18((Entity) Ent, this.ActiveLayerName, true, true);
  }

  public void AddPolygon(UClick start, UClick end)
  {
    if (start == null || end == null || clsVar.varEditorRuntimeSet.PolygonSide < 3 || Point2D.Distance(start.Position, end.Position) <= 1E-09)
      return;
    if (clsVar.varEditorRuntimeSet.isSketchMode)
    {
      Vector2D asVector1 = (end.Position - start.Position).AsVector;
      Vector2D asVector2 = (Vector2D.AxisX - start.Position).AsVector;
      asVector1.Normalize();
      asVector2.Normalize();
      double angle = Vector2D.SignedAngleBetween(Vector2D.AxisX, asVector1);
      devDept.Eyeshot.Entities.Point polygonCenter;
      devDept.Eyeshot.Entities.Point firstPolygonVertex;
      clsItem.frmEditorV2.viewport.CurrentSketch.AddPolygon(start.Position, start.Position.DistanceTo(end.Position), clsVar.varEditorRuntimeSet.PolygonSide, out polygonCenter, out firstPolygonVertex, angle);
      if (start.Entity != null)
        clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintJoin(polygonCenter, start.Entity);
      if (end.Entity != null)
        clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintJoin(firstPolygonVertex, end.Entity);
      clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
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
      CompositeCurve entity_0 = new CompositeCurve((ICurve) new LinearPath((ICollection<Point3D>) CopiedPnt));
      clsItem.frmEditorV2.viewport.method_18((Entity) entity_0, this.ActiveLayerName, true, true);
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
        clsItem.frmEditorV2.viewport.Entities.Add(copiedEntity);
      }
      this.Reset();
    }
  }

  public void AddSlot(UClick first, UClick second, UClick third)
  {
    if (first == null || second == null || third == null || Point2D.Distance(first.Position, second.Position) <= 1E-09)
      return;
    double slotRadius = this.SlotRad(first.Position, second.Position, third.Position);
    if (slotRadius <= 1E-09)
      return;
    if (clsVar.varEditorRuntimeSet.isSketchMode)
    {
      Point2D position1 = first.Position;
      Point2D position2 = second.Position;
      Point2D position3 = third.Position;
      Entity[] entityArray = clsItem.frmEditorV2.viewport.CurrentSketch.AddSlot(position1.X, position1.Y, position1.DistanceTo(position2), slotRadius, (position2 - position1).AsVector.Angle);
      Circle circle1 = entityArray[3] as Circle;
      Circle circle2 = entityArray[1] as Circle;
      if (first.Entity != null)
        clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditorV2.viewport.CurrentSketch.CenterPoint(circle1), first.Entity);
      if (second.Entity != null)
        clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditorV2.viewport.CurrentSketch.CenterPoint(circle2), second.Entity);
      clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
      this.Reset();
      this.JobUpdate();
    }
    else
    {
      this.UndoBuffer();
      Entity entity_0 = clsInit.cVector5.Slot3Point(first.Position, second.Position, third.Position);
      if (entity_0 != null)
        clsItem.frmEditorV2.viewport.method_18(entity_0, this.ActiveLayerName, true, true);
    }
  }

  public void AddCurve(List<UClick> Clicks)
  {
    if (Clicks == null || Clicks.Count <= 2)
      return;
    if (clsVar.varEditorRuntimeSet.isSketchMode)
    {
      if (clsItem.frmEditorV2.viewport.CurrentSketch == null)
        return;
      Curve[] curves = clsItem.frmEditorV2.viewport.CurrentSketch.AddSpline((IList<Point2D>) Clicks.Select<UClick, Point2D>((Func<UClick, Point2D>) (click => click.Position)).ToList<Point2D>());
      if (curves == null || curves.Length == 0)
        return;
      for (int index = 0; index < curves.Length && index < Clicks.Count; ++index)
      {
        devDept.Eyeshot.Entities.Point startPoint = clsItem.frmEditorV2.viewport.CurrentSketch.StartPoint((ICurve) curves[index]);
        if (Clicks[index].Entity != null)
          clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintJoin(startPoint, Clicks[index].Entity);
      }
      UClick lastClick = Clicks.Last<UClick>();
      if (lastClick.Entity != null)
      {
        devDept.Eyeshot.Entities.Point endPoint = clsItem.frmEditorV2.viewport.CurrentSketch.EndPoint((ICurve) curves.Last<Curve>());
        clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintJoin(endPoint, lastClick.Entity);
      }
      clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
      this.Reset();
      this.JobUpdate();
      return;
    }
    this.UndoBuffer();
    List<Point3D> Q = new List<Point3D>();
    for (int index = 0; index <= Clicks.Count - 1; ++index)
      Q.Add(new Point3D(Clicks[index].Position.X, Clicks[index].Position.Y));
    Curve entity_0 = Curve.CubicSplineInterpolation<Point3D>((IList<Point3D>) Q);
    clsItem.frmEditorV2.viewport.method_18((Entity) entity_0, this.ActiveLayerName, true, true);
  }

  public Line ExtendLine(Line other, UClick end)
  {
    Line line;
    if (clsVar.varEditorRuntimeSet.isSketchMode)
    {
      Line line_0 = clsItem.frmEditorV2.viewport.CurrentSketch.AddLine(clsItem.frmEditorV2.viewport.CurrentSketch.Plane.Project(other.EndPoint), end.Position);
      clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditorV2.viewport.CurrentSketch.EndPoint((ICurve) other), (Entity) clsItem.frmEditorV2.viewport.CurrentSketch.StartPoint((ICurve) line_0));
      if (end.Entity != null)
        clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditorV2.viewport.CurrentSketch.EndPoint((ICurve) line_0), end.Entity);
      Class5.smethod_177(this, line_0);
      clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
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
      Circle circle2 = clsItem.frmEditorV2.viewport.CurrentSketch.AddCircle(start.Position, end.Position);
      clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
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
        Circle entity_0 = new Circle(Plane.XY, new Point3D(start.Position.X, start.Position.Y), radius);
        clsItem.frmEditorV2.viewport.method_18((Entity) entity_0, this.ActiveLayerName, true, true);
      }
      this.Reset();
      circle1 = (Circle) null;
    }
    return circle1;
  }

  public Circle AddCircle(UClick first, UClick second, UClick third)
  {
    Circle circle1;
    if (clsVar.varEditorRuntimeSet.isSketchMode)
    {
      Circle circle2 = new Circle(new Point3D(first.Position.X, first.Position.Y), new Point3D(second.Position.X, second.Position.Y), new Point3D(third.Position.X, third.Position.Y));
      Circle circle3 = clsItem.frmEditorV2.viewport.CurrentSketch.AddCircle((Point2D) circle2.Center, circle2.Radius);
      clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
      this.action = actionTypeBU.None;
      this.JobUpdate();
      circle1 = circle3;
    }
    else
    {
      this.UndoBuffer();
      Circle entity_0 = new Circle(new Point3D(first.Position.X, first.Position.Y), new Point3D(second.Position.X, second.Position.Y), new Point3D(third.Position.X, third.Position.Y));
      clsItem.frmEditorV2.viewport.method_18((Entity) entity_0, this.ActiveLayerName, true, true);
      this.Reset();
      circle1 = (Circle) null;
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
        Arc arc2 = new Arc(clsItem.frmEditorV2.viewport.CurrentSketch.Plane, first.Position, second.Position, third.Position, flip);
        clsItem.frmEditorV2.viewport.CurrentSketch.AddArc(arc2);
        if (first.Entity != null)
        {
          if (!flip)
            clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditorV2.viewport.CurrentSketch.StartPoint((ICurve) arc2), first.Entity);
          else
            clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditorV2.viewport.CurrentSketch.EndPoint((ICurve) arc2), first.Entity);
        }
        if (third.Entity != null)
        {
          if (!flip)
            clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditorV2.viewport.CurrentSketch.EndPoint((ICurve) arc2), third.Entity);
          else
            clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditorV2.viewport.CurrentSketch.StartPoint((ICurve) arc2), third.Entity);
        }
        clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
        this.JobUpdate();
        arc1 = arc2;
      }
    }
    else
    {
      bool flip;
      if (!this.EvaluateArc(first.Position, second.Position, third.Position, out flip))
      {
        arc1 = (Arc) null;
      }
      else
      {
        this.UndoBuffer();
        Arc entity_0 = new Arc(Plane.XY, (Point2D) new Point3D(first.Position.X, first.Position.Y), (Point2D) new Point3D(second.Position.X, second.Position.Y), (Point2D) new Point3D(third.Position.X, third.Position.Y), flip);
        clsItem.frmEditorV2.viewport.method_18((Entity) entity_0, this.ActiveLayerName, true, true);
        arc1 = entity_0;
      }
    }
    return arc1;
  }

  public Arc AddArc(Plane drawPlane, Point3D center, double radius, double SA, double EA)
  {
    Arc arc;
    if (clsVar.varEditorRuntimeSet.isSketchMode)
    {
      arc = (Arc) null;
    }
    else
    {
      this.UndoBuffer();
      Arc entity_0 = new Arc(drawPlane, center, radius, SA, EA);
      clsItem.frmEditorV2.viewport.method_18((Entity) entity_0, this.ActiveLayerName, true, true);
      arc = entity_0;
    }
    return arc;
  }

  public void AddFilletChamfer(bool isFillet, ICurve C1, ICurve C2)
  {
    if (!this._filletChamferIndex.HasValue)
      return;
    Tuple<bool, bool> tuple = Class5.smethod_147(this._filletChamferIndex.Value, this);
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
        clsItem.frmEditorV2.viewport.CurrentSketch.AddFillet(C1, C2, tuple.Item1, tuple.Item2, clsVar.varEditorRuntimeSet.FilletRadius);
      else
        clsItem.frmEditorV2.viewport.CurrentSketch.AddChamfer(C1, C2, tuple.Item1, tuple.Item2, clsVar.varEditorRuntimeSet.ChamferLength);
      clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
      if (isFillet && clsItem.frmEditorV2 != null)
        clsItem.frmEditorV2.btn_lib_Click((object) clsItem.frmEditorV2.btn_lib_fillet, (EventArgs) null);
    }
    else
      clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
    for (int index = 0; index <= clsItem.frmEditorV2.viewport.Entities.Count - 1; ++index)
      clsItem.frmEditorV2.viewport.Entities[index].Selected = false;
    clsItem.frmEditorV2.viewport.Invalidate();
    this.JobUpdate();
  }

  public void NewSketch()
  {
    SketchEntity sketchEntity = new SketchEntity(Plane.XY);
    clsItem.frmEditorV2.viewport.Entities.Clear();
    clsItem.frmEditorV2.viewport.Entities.Add((Entity) sketchEntity);
    sketchEntity.Edit((IDesign) clsItem.frmEditorV2.viewport);
    clsItem.frmEditorV2.viewport.CurrentSketch.ClearHistory();
    clsItem.frmEditorV2.viewport.Entities.UpdateBoundingBox();
    clsItem.frmEditorV2.viewport.UpdateBoundingBox();
    clsItem.frmEditorV2.viewport.Invalidate();
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
      clsItem.frmEditorV2.viewport.CurrentSketch.Move(clsItem.frmEditorV2.viewport.CurrentSketch.StartPoint((ICurve) L1), newLocation);
      Tuple<Segment2D, Segment2D> segments2 = this.GetSegments(L1, L2);
      Segment2D segment2D3 = segments2.Item1;
      segment2D1 = segments2.Item2;
    }
    this._clock = new VectorClock((Vector2D) segment2D1, (Vector2D) segment2D2);
  }

  public Tuple<Segment2D, Segment2D> GetSegments(Line L1, Line L2)
  {
    return new Tuple<Segment2D, Segment2D>(new Segment2D(clsItem.frmEditorV2.viewport.CurrentSketch.Plane.Project(L1.StartPoint), clsItem.frmEditorV2.viewport.CurrentSketch.Plane.Project(L1.EndPoint)), new Segment2D(clsItem.frmEditorV2.viewport.CurrentSketch.Plane.Project(L2.StartPoint), clsItem.frmEditorV2.viewport.CurrentSketch.Plane.Project(L2.EndPoint)));
  }

  public void FilletChamferCalculation(bool isFillet)
  {
    ICurve curve1 = (ICurve) Sketcher2D.entitiesSelected[0];
    ICurve curve2 = (ICurve) Sketcher2D.entitiesSelected[1];
    Point3D point3D = ((IEnumerable<Point3D>) Utility.Intersection(curve1, curve2)).LastOrDefault<Point3D>();
    if (point3D == (Point3D) null)
    {
      buString5.MessageBoxWarning(AppLanguage.CadCamMessages[111]);
      if (clsItem.frmEditorV2 == null)
        return;
      clsItem.frmEditorV2.btn_lib_Click((object) clsItem.frmEditorV2.btn_lib_fillet, (EventArgs) null);
    }
    else
    {
      point3D.TransformBy((Transformation) new Align3D(Plane.XY, clsItem.frmEditorV2.viewport.CurrentSketch.DrawingPlane));
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
      Tuple<bool, bool> tuple = Class5.smethod_147(int_0, this);
      if (isFillet)
      {
        Arc fillet;
        Curve.Fillet((ICurve) C1, (ICurve) C2, Radius, tuple.Item1, tuple.Item2, C1 is Arc || C1 is Line, C2 is Arc || C2 is Line, out fillet);
        if ((fillet == null ? 1 : (fillet.AngleInRadians < 0.001 ? 1 : 0)) == 0)
        {
          fillet.TransformBy(Transformation.CreateAlignment(clsItem.frmEditorV2.viewport.CurrentSketch.Plane, clsItem.frmEditorV2.viewport.CurrentSketch.DrawingPlane));
          C1.TransformBy(Transformation.CreateAlignment(clsItem.frmEditorV2.viewport.CurrentSketch.Plane, clsItem.frmEditorV2.viewport.CurrentSketch.DrawingPlane));
          C2.TransformBy(Transformation.CreateAlignment(clsItem.frmEditorV2.viewport.CurrentSketch.Plane, clsItem.frmEditorV2.viewport.CurrentSketch.DrawingPlane));
          this._filletsChamfers[int_0] = new Tuple<ICurve, ICurve, ICurve>((ICurve) fillet, (ICurve) C1, (ICurve) C2);
        }
      }
      else
      {
        Line chamfer;
        Curve.Chamfer((ICurve) C1, (ICurve) C2, Radius, tuple.Item1, tuple.Item2, C1 is Arc || C1 is Line, C2 is Arc || C2 is Line, out chamfer);
        if ((chamfer == null ? 1 : (chamfer.Length() < 0.001 ? 1 : 0)) == 0)
        {
          chamfer.TransformBy(Transformation.CreateAlignment(clsItem.frmEditorV2.viewport.CurrentSketch.Plane, clsItem.frmEditorV2.viewport.CurrentSketch.DrawingPlane));
          C1.TransformBy(Transformation.CreateAlignment(clsItem.frmEditorV2.viewport.CurrentSketch.Plane, clsItem.frmEditorV2.viewport.CurrentSketch.DrawingPlane));
          C2.TransformBy(Transformation.CreateAlignment(clsItem.frmEditorV2.viewport.CurrentSketch.Plane, clsItem.frmEditorV2.viewport.CurrentSketch.DrawingPlane));
          this._filletsChamfers[int_0] = new Tuple<ICurve, ICurve, ICurve>((ICurve) chamfer, (ICurve) C1, (ICurve) C2);
        }
      }
    }
  }

  public void DrawPolygon(Point2D center, Point2D startPoint, ref LinearPath lp)
  {
    if (center.DistanceTo(startPoint) <= 0.0)
      return;
    Circle circle = new Circle(clsItem.frmEditorV2.viewport.CurrentSketch.DrawingPlane, center, center.DistanceTo(startPoint));
    Point3D[] point3DArray = new Point3D[clsVar.varEditorRuntimeSet.PolygonSide + 1];
    for (int index = 0; index < clsVar.varEditorRuntimeSet.PolygonSide; ++index)
      point3DArray[index] = circle.PointAt(2.0 * Math.PI * (double) index / (double) clsVar.varEditorRuntimeSet.PolygonSide);
    point3DArray[clsVar.varEditorRuntimeSet.PolygonSide] = circle.PointAt(0.0);
    lp = new LinearPath(point3DArray);
    Vector2D asVector1 = (startPoint - center).AsVector;
    Vector2D asVector2 = (clsItem.frmEditorV2.viewport.CurrentSketch.DrawingPlane.Project(circle.StartPoint) - center).AsVector;
    asVector1.Normalize();
    asVector2.Normalize();
    double angleInRadians = Vector2D.SignedAngleBetween(asVector2, asVector1);
    lp.Rotate(angleInRadians, clsItem.frmEditorV2.viewport.CurrentSketch.DrawingPlane.AxisZ, circle.Center);
    lp.Regen(clsItem.frmEditorV2.viewport.GetVisualRefinement());
  }

  public CompositeCurve ThreePointsSlot(Point2D start, Point2D end, Point2D radial)
  {
    double radius = this.SlotRad(start, end, radial);
    if (radius <= 0.0)
      radius = 0.1;
    return CompositeCurve.CreateSlot(clsItem.frmEditorV2.viewport.CurrentSketch.DrawingPlane, start.X, start.Y, start.DistanceTo(end), radius, (end - start).AsVector.Angle);
  }

  public double SlotRad(Point2D start, Point2D end, Point2D radial)
  {
    Segment2D segment2D = new Segment2D(start, end);
    Point2D b = segment2D.PointAt(segment2D.ClosestPointTo(radial));
    return radial.DistanceTo(b);
  }

  public Curve InterpolateTwoPoints(UClick first, UClick second)
  {
    Point3D point3D1 = clsItem.frmEditorV2.viewport.CurrentSketch.DrawingPlane.PointAt(first.Position);
    Point3D point3D2 = clsItem.frmEditorV2.viewport.CurrentSketch.DrawingPlane.PointAt(second.Position);
    Vector3D asVector = (point3D2 - point3D1).AsVector;
    Vector3D vector3D = Vector3D.Cross(clsItem.frmEditorV2.viewport.CurrentSketch.DrawingPlane.AxisZ, asVector);
    return Curve.LocalInterpolation((IList<PointTangent>) new PointTangent[3]
    {
      new PointTangent(point3D1.X, point3D1.Y, point3D1.Z, asVector.X, asVector.Y, asVector.Z),
      new PointTangent(point3D2.X, point3D2.Y, point3D2.Z, vector3D.X, vector3D.Y, vector3D.Z),
      new PointTangent(point3D1.X, point3D1.Y, point3D1.Z, -asVector.X, -asVector.Y, -asVector.Z)
    });
  }

  public void CreateConstraintPointOn(devDept.Eyeshot.Entities.Point pnt, Entity ent)
  {
    clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintPointOn(pnt, ent);
    clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
    this.JobUpdate();
  }

  public void CreateConstraintJoinEntities(Entity firstEntity, Entity secondEntity)
  {
    if (firstEntity == null || secondEntity == null || clsItem.frmEditorV2.viewport.CurrentSketch == null)
      return;
    List<devDept.Eyeshot.Entities.Point> firstPoints = new List<devDept.Eyeshot.Entities.Point>();
    List<devDept.Eyeshot.Entities.Point> secondPoints = new List<devDept.Eyeshot.Entities.Point>();
    if (firstEntity is ICurve)
    {
      firstPoints.Add(clsItem.frmEditorV2.viewport.CurrentSketch.StartPoint((ICurve) firstEntity));
      firstPoints.Add(clsItem.frmEditorV2.viewport.CurrentSketch.EndPoint((ICurve) firstEntity));
    }
    else if (firstEntity is devDept.Eyeshot.Entities.Point)
      firstPoints.Add((devDept.Eyeshot.Entities.Point) firstEntity);
    if (secondEntity is ICurve)
    {
      secondPoints.Add(clsItem.frmEditorV2.viewport.CurrentSketch.StartPoint((ICurve) secondEntity));
      secondPoints.Add(clsItem.frmEditorV2.viewport.CurrentSketch.EndPoint((ICurve) secondEntity));
    }
    else if (secondEntity is devDept.Eyeshot.Entities.Point)
      secondPoints.Add((devDept.Eyeshot.Entities.Point) secondEntity);
    devDept.Eyeshot.Entities.Point firstPoint = null;
    devDept.Eyeshot.Entities.Point secondPoint = null;
    double shortestDistance = double.MaxValue;
    for (int firstIndex = 0; firstIndex < firstPoints.Count; ++firstIndex)
    {
      for (int secondIndex = 0; secondIndex < secondPoints.Count; ++secondIndex)
      {
        double distance = Point3D.Distance(firstPoints[firstIndex].Position, secondPoints[secondIndex].Position);
        if (distance >= shortestDistance)
          continue;
        shortestDistance = distance;
        firstPoint = firstPoints[firstIndex];
        secondPoint = secondPoints[secondIndex];
      }
    }
    if (firstPoint == null || secondPoint == null)
      return;
    clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintJoin(firstPoint, (Entity) secondPoint);
    clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
    clsItem.frmEditorV2.viewport.Invalidate();
    this.JobUpdate();
  }

  public void CreateConstraintVertical(Line line)
  {
    clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintVertical(line);
    clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
    this.JobUpdate();
  }

  public void CreateConstraintHorizontal(Line line)
  {
    clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintHorizontal(line);
    clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
    this.JobUpdate();
  }

  public void CreateConstraintLength(Line line, Point2D refPoint)
  {
    clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintLength(line, dimLinePos: refPoint);
    clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
    clsItem.frmEditorV2.viewport.Invalidate();
    this.JobUpdate();
  }

  public void CreateConstraintLineLineDistance(Line L1, Line L2, Point2D refPoint)
  {
    clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintLinesDistance(L1, L2, dimLinePos: refPoint);
    clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
    clsItem.frmEditorV2.viewport.Invalidate();
    this.Reset();
    this.JobUpdate();
  }

  public void CreateConstraintLinePointDistance(devDept.Eyeshot.Entities.Point P1, Line L1, Point2D refPoint)
  {
    clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintPointLineDistance(P1, L1, dimLinePos: refPoint);
    clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
    clsItem.frmEditorV2.viewport.Invalidate();
    this.Reset();
    this.JobUpdate();
  }

  public void CreateConstraintPointPointAlignedDistance(devDept.Eyeshot.Entities.Point P1, devDept.Eyeshot.Entities.Point P2, Point2D refPoint)
  {
    clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintAlignedPointsDistance(P1, P2, dimLinePos: refPoint);
    clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
    clsItem.frmEditorV2.viewport.Invalidate();
    this.Reset();
    this.JobUpdate();
  }

  public void CreateConstraintPointPointHorizontalDistance(devDept.Eyeshot.Entities.Point P1, devDept.Eyeshot.Entities.Point P2, Point2D refPoint)
  {
    clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintHorizontalPointsDistance(P1, P2, dimLinePos: refPoint);
    clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
    clsItem.frmEditorV2.viewport.Invalidate();
    this.Reset();
    this.JobUpdate();
  }

  public void CreateConstraintPointPointVerticalDistance(devDept.Eyeshot.Entities.Point P1, devDept.Eyeshot.Entities.Point P2, Point2D refPoint)
  {
    clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintVerticalPointsDistance(P1, P2, dimLinePos: refPoint);
    clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
    clsItem.frmEditorV2.viewport.Invalidate();
    this.Reset();
    this.JobUpdate();
  }

  public void CreateConstraintCollinear(Line L1, Line L2)
  {
    clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintCollinear(L1, L2);
    clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
    for (int index = 0; index <= clsItem.frmEditorV2.viewport.Entities.Count - 1; ++index)
      clsItem.frmEditorV2.viewport.Entities[index].Selected = false;
    clsItem.frmEditorV2.viewport.Invalidate();
    this.Reset();
    this.JobUpdate();
  }

  public void CreateConstraintParallel(Line L1, Line L2)
  {
    clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintParallelLines(L1, L2);
    clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
    for (int index = 0; index <= clsItem.frmEditorV2.viewport.Entities.Count - 1; ++index)
      clsItem.frmEditorV2.viewport.Entities[index].Selected = false;
    clsItem.frmEditorV2.viewport.Invalidate();
    this.Reset();
    this.JobUpdate();
  }

  public void CreateConstraintPerpendicular(Line L1, Line L2)
  {
    clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintPerpendicular(L1, L2);
    clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
    for (int index = 0; index <= clsItem.frmEditorV2.viewport.Entities.Count - 1; ++index)
      clsItem.frmEditorV2.viewport.Entities[index].Selected = false;
    clsItem.frmEditorV2.viewport.Invalidate();
    this.Reset();
    this.JobUpdate();
  }

  public void CreateConstraintTangent(Entity E1, Entity E2)
  {
    clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintTangent(E1, E2);
    clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
    for (int index = 0; index <= clsItem.frmEditorV2.viewport.Entities.Count - 1; ++index)
      clsItem.frmEditorV2.viewport.Entities[index].Selected = false;
    clsItem.frmEditorV2.viewport.Invalidate();
    this.Reset();
    this.JobUpdate();
  }

  public void CreateConstraintAngle(Arc arc, Point2D refPoint)
  {
    clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintAngle(arc, dimLinePos: refPoint);
    clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
    for (int index = 0; index <= clsItem.frmEditorV2.viewport.Entities.Count - 1; ++index)
      clsItem.frmEditorV2.viewport.Entities[index].Selected = false;
    clsItem.frmEditorV2.viewport.Invalidate();
    clsItem.frmEditorV2.viewport.Invalidate();
    this.Reset();
    this.JobUpdate();
  }

  public void CreateConstraintAngle(Line L1, Line L2, Point2D refPoint)
  {
    Tuple<Segment2D, Segment2D> segments = this.GetSegments(L1, L2);
    Point2D i0;
    Segment2D.IntersectionLine(segments.Item1, segments.Item2, out i0);
    double rad = Utility.DegToRad(Utility.RadToDeg(this._clock.Locate(Sketcher2D.mousePlnLoc - i0, out int _).Length));
    clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintAngle(L1, L2, refPoint, rad);
    clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
    for (int index = 0; index <= clsItem.frmEditorV2.viewport.Entities.Count - 1; ++index)
      clsItem.frmEditorV2.viewport.Entities[index].Selected = false;
    clsItem.frmEditorV2.viewport.Invalidate();
    this.Reset();
    this.JobUpdate();
  }

  public void CreateConstraintDiameter(Circle line)
  {
    clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintDiameter(line);
    clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
    clsItem.frmEditorV2.viewport.Invalidate();
    this.JobUpdate();
  }

  public void CreateConstraintFixPoint(Entity Ent, Point3D refPoint)
  {
    StartEndCenterType startEndCenterType;
    if ((Ent is Circle && !(Ent is Arc)) || (Ent is Ellipse && !(Ent is EllipticalArc)))
    {
      startEndCenterType = StartEndCenterType.Center;
    }
    else if (Ent is Line | Ent is Arc | Ent is Curve | Ent is EllipticalArc)
    {
      startEndCenterType = Point3D.Distance(((ICurve) Ent).StartPoint, refPoint) >= Point3D.Distance(((ICurve) Ent).EndPoint, refPoint) ? StartEndCenterType.End : StartEndCenterType.Start;
    }
    else
    {
      return;
    }
    if (startEndCenterType == StartEndCenterType.End)
    {
      if (Ent is Line)
        clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditorV2.viewport.CurrentSketch.EndPoint((ICurve) Ent));
      if (Ent is Curve)
        clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditorV2.viewport.CurrentSketch.EndPoint((ICurve) Ent));
      if (Ent is Arc)
        clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditorV2.viewport.CurrentSketch.EndPoint((ICurve) Ent));
      if (Ent is EllipticalArc)
        clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditorV2.viewport.CurrentSketch.EndPoint((ICurve) Ent));
    }
    if (startEndCenterType == StartEndCenterType.Start)
    {
      if (Ent is Line)
        clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditorV2.viewport.CurrentSketch.StartPoint((ICurve) Ent));
      if (Ent is Curve)
        clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditorV2.viewport.CurrentSketch.StartPoint((ICurve) Ent));
      if (Ent is Arc)
        clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditorV2.viewport.CurrentSketch.StartPoint((ICurve) Ent));
      if (Ent is EllipticalArc)
        clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditorV2.viewport.CurrentSketch.StartPoint((ICurve) Ent));
    }
    if (startEndCenterType == StartEndCenterType.Center)
    {
      if (Ent is Circle)
        clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditorV2.viewport.CurrentSketch.CenterPoint((Circle) Ent));
      if (Ent is Ellipse)
        clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditorV2.viewport.CurrentSketch.CenterPoint((Ellipse) Ent));
    }
    clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
    clsItem.frmEditorV2.viewport.Invalidate();
    this.JobUpdate();
  }

  public void CreateConstraintEqualLength(Entity FirstEntity, Entity SecondEntity, bool Radius)
  {
    clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintEqual(FirstEntity, SecondEntity, Radius);
    clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
    for (int index = 0; index <= clsItem.frmEditorV2.viewport.Entities.Count - 1; ++index)
      clsItem.frmEditorV2.viewport.Entities[index].Selected = false;
    clsItem.frmEditorV2.viewport.Invalidate();
    this.JobUpdate();
  }

  public void ShowValueArea(
    actionTypeBU Command,
    bool Show,
    int Width,
    int Height,
    string Caption = "",
    double Value = 0.0,
    double MinVal = -1000000.0,
    double MaxVal = 10000000.0,
    int Decimal = 2,
    bool ButtonShow = false)
  {
    switch (Command)
    {
      case actionTypeBU.eventScale:
        clsItem.frmEditorV2.buTab_EventVals.SelectedIndex = 3;
        clsItem.frmEditorV2.spn_scaleratio.MinValue = MinVal;
        clsItem.frmEditorV2.spn_scaleratio.MaxValue = MaxVal;
        clsItem.frmEditorV2.spn_scaleratio.DecimalPoint = Decimal;
        clsItem.frmEditorV2.spn_scaleratio.Value = Value;
        break;
      case actionTypeBU.eventOffset:
        clsItem.frmEditorV2.buTab_EventVals.SelectedIndex = 5;
        clsItem.frmEditorV2.chk_offsetbymouse.Check = clsVar.varEditorSet.OffsetByMouse;
        clsItem.frmEditorV2.spn_offset.MinValue = MinVal;
        clsItem.frmEditorV2.spn_offset.MaxValue = MaxVal;
        clsItem.frmEditorV2.spn_offset.DecimalPoint = Decimal;
        clsItem.frmEditorV2.spn_offset.Value = Value;
        break;
      case actionTypeBU.eventExtend:
        clsItem.frmEditorV2.buTab_EventVals.SelectedIndex = 4;
        clsItem.frmEditorV2.spn_extndlen.MinValue = MinVal;
        clsItem.frmEditorV2.spn_extndlen.MaxValue = MaxVal;
        clsItem.frmEditorV2.spn_extndlen.DecimalPoint = Decimal;
        clsItem.frmEditorV2.spn_extndlen.Value = Value;
        break;
      case actionTypeBU.eventChamfer:
        clsItem.frmEditorV2.buTab_EventVals.SelectedIndex = 1;
        clsItem.frmEditorV2.spn_chamgerlen.MinValue = MinVal;
        clsItem.frmEditorV2.spn_chamgerlen.MaxValue = MaxVal;
        clsItem.frmEditorV2.spn_chamgerlen.DecimalPoint = Decimal;
        clsItem.frmEditorV2.spn_chamgerlen.Value = Value;
        break;
      case actionTypeBU.eventFillet:
        clsItem.frmEditorV2.buTab_EventVals.SelectedIndex = 0;
        clsItem.frmEditorV2.spn_filletrad.MinValue = MinVal;
        clsItem.frmEditorV2.spn_filletrad.MaxValue = MaxVal;
        clsItem.frmEditorV2.spn_filletrad.DecimalPoint = Decimal;
        clsItem.frmEditorV2.spn_filletrad.Value = Value;
        break;
      case actionTypeBU.eventExplode:
        clsItem.frmEditorV2.buTab_EventVals.SelectedIndex = 2;
        break;
    }
    clsItem.frmEditorV2.btn_eventok.Visible = ButtonShow;
    clsItem.frmEditorV2.grp_events.BringToFront();
    clsItem.frmEditorV2.grp_events.Text = Caption;
    clsItem.frmEditorV2.grp_events.Visible = Show;
    if (Width > 10)
      clsItem.frmEditorV2.grp_events.Width = Width;
    if (Height > 10)
      clsItem.frmEditorV2.grp_events.Height = Height;
    clsItem.frmEditorV2.grp_events.Top = clsItem.frmEditorV2.Height - clsItem.frmEditorV2.grp_events.Height - (clsItem.frmEditorV2.buTab_menu.Top + clsItem.frmEditorV2.buTab_menu.Height) - clsItem.frmEditorV2.buGround1.Ground.BottomHeight - 10;
    clsItem.frmEditorV2.grp_events.Left = 10;
  }

  public void ShowValueArea(
    bool Show,
    string Caption = "",
    double Value = 0.0,
    double MinVal = -1000000.0,
    double MaxVal = 10000000.0,
    int Decimal = 2)
  {
    if (clsItem.frmEditorV2 == null)
      return;
    clsItem.frmEditorV2.grp_events.Text = Caption;
    clsItem.frmEditorV2.grp_events.Visible = Show;
    if (Show)
    {
      clsItem.frmEditorV2.spn_filletrad.MinValue = MinVal;
      clsItem.frmEditorV2.spn_filletrad.MaxValue = MaxVal;
      clsItem.frmEditorV2.spn_filletrad.DecimalPoint = Decimal;
      clsItem.frmEditorV2.spn_filletrad.Value = Value;
    }
  }

  public void ShowCheckArea(bool Show, bool Checked, string Caption = "")
  {
  }

  public void GridUpdate()
  {
    clsItem.frmEditorV2.viewport.ActiveViewport.Grid.Visible = clsVar.varEditorRuntimeSet.GridEnable;
    clsItem.frmEditorV2.viewport.ActiveViewport.Grid.AlwaysBehind = true;
    clsItem.frmEditorV2.viewport.ActiveViewport.Grid.AutoSize = false;
    clsItem.frmEditorV2.viewport.ActiveViewport.Grid.MajorLinesEvery = clsVar.varEditorSet.GridMajorLineCount;
    clsItem.frmEditorV2.viewport.ActiveViewport.Grid.Min.X = clsVar.varEditorSet.GridMinValue;
    clsItem.frmEditorV2.viewport.ActiveViewport.Grid.Min.Y = clsVar.varEditorSet.GridMinValue;
    clsItem.frmEditorV2.viewport.ActiveViewport.Grid.Max.X = clsVar.varEditorSet.GridMaxValue;
    clsItem.frmEditorV2.viewport.ActiveViewport.Grid.Max.Y = clsVar.varEditorSet.GridMaxValue;
    clsItem.frmEditorV2.viewport.ActiveViewport.Grid.ColorAxisX = clsVar.varEditorSet.colorGridMajorLine;
    clsItem.frmEditorV2.viewport.ActiveViewport.Grid.ColorAxisY = clsVar.varEditorSet.colorGridMajorLine;
    clsItem.frmEditorV2.viewport.ActiveViewport.Grid.BorderColor = Color.Transparent;
    clsItem.frmEditorV2.viewport.ActiveViewport.Grid.FillColor = Color.Transparent;
    clsItem.frmEditorV2.viewport.ActiveViewport.Grid.LineColor = clsVar.varEditorSet.colorGridLine;
    clsItem.frmEditorV2.viewport.ActiveViewport.Grid.MajorLineColor = clsVar.varEditorSet.colorGridMajorLine;
    clsItem.frmEditorV2.viewport.ActiveViewport.Grid.Lighting = true;
    clsItem.frmEditorV2.viewport.ActiveViewport.Grid.Step = clsVar.varEditorSet.GridStep;
    clsItem.frmEditorV2.viewport.ActiveViewport.CompileUserInterfaceElements();
    clsItem.frmEditorV2.viewport.CompileUserInterfaceElements();
    clsItem.frmEditorV2.viewport.Invalidate();
  }

  public void Rotate(double Degree)
  {
    Point3D MinPoint = new Point3D();
    Point3D MidPoint = new Point3D();
    Point3D MaxPoint = new Point3D();
    if (Sketcher2D.entitiesSelected.Count == 0)
      clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditorV2.viewport.Entities, false, ref Sketcher2D.entitiesSelected);
    if (Sketcher2D.entitiesSelected.Count > 0)
    {
      this.UndoBuffer();
      clsInit.cVector5.BoxSizeCalculate(Sketcher2D.entitiesSelected, ref MinPoint, ref MidPoint, ref MaxPoint);
      for (int index = 0; index <= clsItem.frmEditorV2.viewport.Entities.Count - 1; ++index)
      {
        Entity entity = clsItem.frmEditorV2.viewport.Entities[index];
        if (entity.Selected)
          entity.Rotate(buConversion5.DegreeToRadian(Degree), Vector3D.AxisZ, MidPoint);
      }
      clsItem.frmEditorV2.viewport.Entities.RegenAllCurved(0.02);
    }
    clsItem.frmEditorV2.viewport.Invalidate();
    this.Reset();
  }

  public void Mirror(HorizontalVertical Value)
  {
    Point3D MinPoint = new Point3D();
    Point3D MidPoint = new Point3D();
    Point3D MaxPoint = new Point3D();
    if (Sketcher2D.entitiesSelected.Count == 0)
      clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditorV2.viewport.Entities, false, ref Sketcher2D.entitiesSelected);
    clsInit.cVector5.BoxSizeCalculate(Sketcher2D.entitiesSelected, ref MinPoint, ref MidPoint, ref MaxPoint);
    if (Sketcher2D.entitiesSelected.Count > 0)
    {
      this.UndoBuffer();
      Vector3D X = Value != HorizontalVertical.Vertical ? new Vector3D(MidPoint, new Point3D(MidPoint.X, MidPoint.Y + 10.0, MidPoint.Z)) : new Vector3D(MidPoint, new Point3D(MidPoint.X + 10.0, MidPoint.Y, MidPoint.Z));
      devDept.Geometry.Mirror xform = new devDept.Geometry.Mirror(new Plane(MidPoint, X, Vector3D.AxisZ));
      for (int index = 0; index <= clsItem.frmEditorV2.viewport.Entities.Count - 1; ++index)
      {
        Entity entity = clsItem.frmEditorV2.viewport.Entities[index];
        if (entity.Selected)
          entity.TransformBy((Transformation) xform);
      }
      clsItem.frmEditorV2.viewport.Entities.RegenAllCurved();
    }
    clsItem.frmEditorV2.viewport.Invalidate();
    this.Reset();
  }

  public void TurnOver()
  {
    clsInit.appEditor2.UndoBuffer();
    Point3D MinPoint = new Point3D();
    Point3D MidPoint = new Point3D();
    Point3D MaxPoint = new Point3D();
    if (Sketcher2D.entitiesSelected.Count == 0)
      clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditorV2.viewport.Entities, false, ref Sketcher2D.entitiesSelected);
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
      clsItem.frmEditorV2.viewport.Entities.Add(refEntities[index]);
    clsItem.frmEditorV2.viewport.Entities.RegenAllCurved(0.01);
    this.Reset();
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

  public List<Point3D> ClicksToPoints(List<UClick> Clicks)
  {
    List<Point3D> points = new List<Point3D>();
    for (int index = 0; index <= Clicks.Count - 1; ++index)
      points.Add(new Point3D(Clicks[index].Position.X, Clicks[index].Position.Y, 0.0));
    return points;
  }

  public double XyCross(Vector2D vec1, Vector2D vec2) => vec1.X * vec2.Y - vec1.Y * vec2.X;

  public void UndoGetBack()
  {
    if (this.bufferedEntity.Count <= 0)
      return;
    this.bufferedRedoEntity.Add(this.CaptureEditorSnapshot());
    int lastIndex = this.bufferedEntity.Count - 1;
    List<Entity> snapshot = this.bufferedEntity[lastIndex];
    this.bufferedEntity.RemoveAt(lastIndex);
    this.RestoreEditorSnapshot(snapshot);
  }

  public void UndoBuffer()
  {
    if (clsItem.frmEditorV2 == null || clsItem.frmEditorV2.viewport == null)
      return;
    if (this.bufferedEntity.Count >= 100)
      this.bufferedEntity.RemoveAt(0);
    this.bufferedEntity.Add(this.CaptureEditorSnapshot());
    this.bufferedRedoEntity.Clear();
  }

  public void RedoGetBack()
  {
    if (this.bufferedRedoEntity.Count <= 0)
      return;
    if (this.bufferedEntity.Count >= 100)
      this.bufferedEntity.RemoveAt(0);
    this.bufferedEntity.Add(this.CaptureEditorSnapshot());
    int lastIndex = this.bufferedRedoEntity.Count - 1;
    List<Entity> snapshot = this.bufferedRedoEntity[lastIndex];
    this.bufferedRedoEntity.RemoveAt(lastIndex);
    this.RestoreEditorSnapshot(snapshot);
  }

  private List<Entity> CaptureEditorSnapshot()
  {
    List<Entity> snapshot = new List<Entity>();
    if (clsItem.frmEditorV2 == null || clsItem.frmEditorV2.viewport == null)
      return snapshot;
    for (int index = 0; index < clsItem.frmEditorV2.viewport.Entities.Count; ++index)
    {
      Entity entity = clsItem.frmEditorV2.viewport.Entities[index].Clone() as Entity;
      if (entity != null)
        snapshot.Add(entity);
    }
    return snapshot;
  }

  private void RestoreEditorSnapshot(List<Entity> snapshot)
  {
    if (clsItem.frmEditorV2 == null || clsItem.frmEditorV2.viewport == null || snapshot == null)
      return;
    clsItem.frmEditorV2.viewport.Entities.Clear();
    for (int index = 0; index < snapshot.Count; ++index)
    {
      Entity entity = snapshot[index].Clone() as Entity;
      if (entity != null)
        clsItem.frmEditorV2.viewport.Entities.Add(entity);
    }
    clsItem.frmEditorV2.viewport.Entities.RegenAllCurved();
    clsItem.frmEditorV2.viewport.Entities.UpdateBoundingBox();
    clsItem.frmEditorV2.viewport.ClearAllPreviousCommandData();
    clsItem.frmEditorV2.viewport.Invalidate();
    this.JobUpdate();
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
    clsItem.frmEditorV2.viewport.Entities.ClearSelection();
    if (this.SelectedConstraint >= 0)
    {
      VisualConstraint constraint = clsItem.frmEditorV2.viewport.CurrentSketch.Constraints[this.SelectedConstraint];
      if (constraint.ConstraintDimension != null)
        constraint.ConstraintDimension.Selected = true;
      this.UpdateCommandInfo(new EditorCustomData());
    }
    if (this.SelectedDrawing >= 0)
    {
      clsItem.frmEditorV2.viewport.Entities[this.SelectedDrawing].Selected = true;
      if (clsItem.frmEditorV2.viewport.Entities[this.SelectedDrawing].EntityData != null && clsItem.frmEditorV2.viewport.Entities[this.SelectedDrawing].EntityData is EditorCustomData)
        this.UpdateCommandInfo(clsItem.frmEditorV2.viewport.Entities[this.SelectedDrawing].EntityData as EditorCustomData);
    }
    clsItem.frmEditorV2.viewport.Invalidate();
  }

  public void JobUpdate()
  {
  }

  public void UpdateCommandInfo(EditorCustomData CD)
  {
  }

  public void AddCommandToDrawing(string Command, int indexDrawing)
  {
    if (clsItem.frmEditorV2.viewport.ActionMode == devDept.Eyeshot.actionType.SelectByBox)
    {
      for (int index = 0; index <= clsItem.frmEditorV2.viewport.Entities.Count - 1; ++index)
      {
        if (clsItem.frmEditorV2.viewport.Entities[index].Selected & clsItem.frmEditorV2.viewport.Entities[index] is ICurve & clsItem.frmEditorV2.viewport.Entities[index].GetType() != typeof (devDept.Eyeshot.Entities.Point))
        {
          if (clsItem.frmEditorV2.viewport.Entities[index].EntityData != null)
          {
            if (clsItem.frmEditorV2.viewport.Entities[index].EntityData is EditorCustomData)
            {
              EditorCustomData entityData = clsItem.frmEditorV2.viewport.Entities[index].EntityData as EditorCustomData;
              entityData.Commands.Add(Command);
              this.UpdateCommandInfo(entityData);
            }
            else
            {
              EditorCustomData CD = new EditorCustomData();
              CD.Commands.Add(Command);
              clsItem.frmEditorV2.viewport.Entities[index].EntityData = (object) CD;
              this.UpdateCommandInfo(CD);
            }
          }
          else
          {
            EditorCustomData CD = new EditorCustomData();
            CD.Commands.Add(Command);
            clsItem.frmEditorV2.viewport.Entities[index].EntityData = (object) CD;
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
      if (clsItem.frmEditorV2.viewport.Entities[indexDrawing].EntityData != null)
      {
        if (clsItem.frmEditorV2.viewport.Entities[indexDrawing].EntityData is EditorCustomData)
        {
          EditorCustomData entityData = clsItem.frmEditorV2.viewport.Entities[indexDrawing].EntityData as EditorCustomData;
          entityData.Commands.Add(Command);
          this.UpdateCommandInfo(entityData);
        }
        else
        {
          EditorCustomData CD = new EditorCustomData();
          CD.Commands.Add(Command);
          clsItem.frmEditorV2.viewport.Entities[indexDrawing].EntityData = (object) CD;
          this.UpdateCommandInfo(CD);
        }
      }
      else
      {
        EditorCustomData CD = new EditorCustomData();
        CD.Commands.Add(Command);
        clsItem.frmEditorV2.viewport.Entities[indexDrawing].EntityData = (object) CD;
        this.UpdateCommandInfo(CD);
      }
    }
  }

  public void RemoveCommandFromDrawing(int indexCommand, int indexDrawing)
  {
    if (!(indexDrawing >= 0 & indexCommand >= 0) || clsItem.frmEditorV2.viewport.Entities[indexDrawing].EntityData == null || !(clsItem.frmEditorV2.viewport.Entities[indexDrawing].EntityData is EditorCustomData))
      return;
    EditorCustomData entityData = clsItem.frmEditorV2.viewport.Entities[indexDrawing].EntityData as EditorCustomData;
    entityData.Commands.RemoveAt(indexCommand);
    this.UpdateCommandInfo(entityData);
  }

  public void FileOpened()
  {
    if (clsItem.frmEditorV2.viewport.Entities.Count > 0)
    {
      if (clsItem.frmEditorV2.viewport.Entities[0] is SketchEntity)
      {
        SketchEntity entity = clsItem.frmEditorV2.viewport.Entities[0] as SketchEntity;
        if (this.OpenCustomData.Count > 0)
        {
          for (int index = 0; index <= this.OpenCustomData.Count - 1; ++index)
          {
            if (this.OpenCustomData[index].EntityIndex >= 0 & this.OpenCustomData[index].EntityIndex <= entity.CurveList.Count - 1)
              ((Entity) entity.CurveList[this.OpenCustomData[index].EntityIndex]).EntityData = (object) this.OpenCustomData[index];
          }
        }
        entity.Edit((IDesign) clsItem.frmEditorV2.viewport);
        clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
      }
      Class5.smethod_199(this);
      Class5.smethod_44(this);
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

  public void SaveEditorFile(string FileName)
  {
    try
    {
      string directory = Path.GetDirectoryName(FileName);
      if (!string.IsNullOrWhiteSpace(directory) && !Directory.Exists(directory))
        Directory.CreateDirectory(directory);
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

  public void OpenEditorFile(string FileName)
  {
    try
    {
      ArrayList arrayList = new ArrayList();
      FileInfo fileInfo = new FileInfo(FileName);
      if (fileInfo.Exists)
      {
        ArrayList StringList = new ArrayList();
        buFile.OpenFromFile(fileInfo.FullName, ref StringList);
        try
        {
          ArrayList CalcList1 = new ArrayList();
          buString.ListToSpecificList("<clsVar.varEditorSet>", "</clsVar.varEditorSet>", true, StringList, ref CalcList1);
          if (CalcList1.Count > 0)
          {
            buSerilization5.Decode(CalcList1, "", SerilizationMode5.MultiLine, (object) clsVar.varEditorSet);
            buLog.addLog("clsVar.varEditorSet Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
          ArrayList CalcList2 = new ArrayList();
          buString.ListToSpecificList("<clsVar.varEditorRuntimeSet>", "</clsVar.varEditorRuntimeSet>", true, StringList, ref CalcList2);
          if (CalcList2.Count > 0)
          {
            buSerilization5.Decode(CalcList2, "", SerilizationMode5.MultiLine, (object) clsVar.varEditorRuntimeSet);
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
    for (int index = 0; index <= clsItem.frmEditorV2.viewport.Entities.Count - 1; ++index)
    {
      buEntity copiedEntity = (buEntity) null;
      buEntity.Copy(clsItem.frmEditorV2.viewport.Entities[index], ref copiedEntity);
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
    Drafting2D.selectedIndex.Clear();
    clsItem.frmEditorV2.viewport.Entities.UpdateBoundingBox();
    clsItem.frmEditorV2.viewport.Entities.ClearSelection();
    for (int index = 0; index <= clsItem.frmEditorV2.viewport.Entities.Count - 1; ++index)
      clsItem.frmEditorV2.viewport.Entities[index].Selectable = true;
    clsItem.frmEditorV2.viewport.Invalidate();
    Drafting2D.selectionProcess = true;
    Drafting2D.points.Clear();
    Drafting2D.entitySelected = (Entity) null;
    if (Drafting2D.entitiesSelected != null)
      Drafting2D.entitiesSelected.Clear();
    clsInit.appEditor2.action = actionTypeBU.None;
    this.StatusUpdate("", "");
    this.ShowCheckArea(false, false);
    this.ShowValueArea(false);
    clsItem.frmEditorV2.viewport.Invalidate();
  }

  internal delegate void Delegate2();
}
