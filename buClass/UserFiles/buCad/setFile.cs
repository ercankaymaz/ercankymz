// Decompiled with JetBrains decompiler
// Type: buClass.UserFiles.buCad.setFile
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Reflection;

#nullable disable
namespace buClass.UserFiles.buCad;

public class setFile : buSerilization
{
  public int DxfReadMode = 0;
  public double MinAllowedEntityLength = 0.0;
  public bool ExplodeBlockReferanceWhenOpenFile = true;
  public bool RemoveBlockWhileImport = true;
  public bool RemoveTextStylesWhileImport = true;
  public bool ExtrudeByThickness = false;
  public bool MoveOpenEntitiesToZeroPointAuto = false;
  public bool BreakCurveEntitiesByConnection = false;
  public bool DontAddPointFromDxfFile = false;
  public bool DontAddTextFromDxfFile = false;
  public bool ConvertDxfTextToVector = false;
  public bool DeleteIfDublicatedEntityAvailable = true;
  public bool AnalyseEntitiesAfterImport = false;
  public bool IfSelectedAvailableSaveOnlySelected = false;
  public bool SaveOnlyCurveEntities = false;
  public bool SaveOnlyCurveAndTextEntities = false;
  public bool UseOurColorListForDxf = false;
  public bool ConvertDxfLayerOverrideValues = false;
  public bool DontAskSaveToFileMesssafeWhileClosing = false;
  public bool DragDropInsertMode = true;
  public bool MoveEntititesLayerFromColors = false;
  public FileSaveModes FileSaveMode = new FileSaveModes();
  public FileSaveModes FileExportMode = new FileSaveModes();
  public FileOpenModes FileOpenMode = new FileOpenModes();
  public FileOpenModes FileImportMode = new FileOpenModes();
  public FileOpenModes FileAddMode = new FileOpenModes();
  public FileOpenModes FileInsertMode = new FileOpenModes();
  public HPGLFileProperties HPGLFileProperties = new HPGLFileProperties();

  public setFile()
  {
  }

  public setFile(setFile data)
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
    this.FileOpenMode = new FileOpenModes(data.FileOpenMode);
  }
}
