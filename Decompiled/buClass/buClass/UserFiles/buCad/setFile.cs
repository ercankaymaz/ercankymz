using System.Reflection;

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
		buSerilization.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
		{
			FieldInfo[] fields = GetType().GetFields();
			if (fields != null)
			{
				for (int i = 0; i <= fields.Length - 1; i++)
				{
					string name = fields[i].Name;
					object value = fields[i].GetValue(CopiedClass);
					fields[i].SetValue(this, value);
				}
			}
		}
		FileOpenMode = new FileOpenModes(data.FileOpenMode);
	}
}
