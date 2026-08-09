using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
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

namespace buCadCamResVer5.Editor;

public class clsEditor
{
	internal delegate void Delegate3();

	public SortbuSettings ManuelSortSetting = new SortbuSettings();

	public SortPointClickResult ManuelSortClickResult = new SortPointClickResult();

	public List<buEntity> sortRefEntities = new List<buEntity>();

	public List<buEntity> sortedEntities = new List<buEntity>();

	public int sortedEntitiesSimIndex = -1;

	public List<Pnt6DSimMove> sortedEntitiesSimPoints = new List<Pnt6DSimMove>();

	public List<List<Entity>> bufferedEntity = new List<List<Entity>>();

	public bool SimStarted = false;

	public bool DxfImported = false;

	public Timer timSim = null;

	public List<EditorCustomData> OpenCustomData = new List<EditorCustomData>();

	public actionTypeBU action = actionTypeBU.None;

	public int? _filletChamferIndex;

	public VectorClock _clock = null;

	public Tuple<ICurve, ICurve, ICurve>[] _filletsChamfers;

	public int SelectedDrawing = -1;

	public int SelectedConstraint = -1;

	public FileInfo FIZip = null;

	public void Init()
	{
		OpenEditorFile();
		if (timSim == null)
		{
			timSim = new Timer();
			timSim.Tick += Sim_Tick;
			timSim.Interval = 10;
		}
	}

	public void CreateModelControl(ref Sketcher2D viewport, string UnlockKey, CreateModelProperties Properties)
	{
		viewport = new Sketcher2D();
		viewport.InitializeViewports();
		viewport.CreateControl();
		viewport.CreateGraphics();
		viewport.Dock = DockStyle.Fill;
		if (Properties.Width > 0)
		{
			viewport.Width = Properties.Width;
		}
		if (Properties.Height > 0)
		{
			viewport.Height = Properties.Height;
		}
		BackgroundSettings background = new BackgroundSettings(backgroundStyleType.LinearGradient, Properties.BottomColor, Properties.MiddleColor, Properties.TopColor, 0.75, null, colorThemeType.Auto, 0.3);
		viewport.Viewports[0].Background = background;
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
			ReadFileAsync readFileAsync = (ReadFileAsync)e.WorkUnit;
			RegenOptions ro = new RegenOptions();
			_ = e.WorkUnit is ReadFile;
			DxfImported = false;
			readFileAsync.OpenTo(clsItem.frmEditor.viewport, ro);
			if (!((buFile5.getFileExtension(readFileAsync.FilePath).ToLower() == ".dxf") | (buFile5.getFileExtension(readFileAsync.FilePath).ToLower() == ".dwg")))
			{
				FileOpened();
			}
			else
			{
				for (int i = 0; i <= clsItem.frmEditor.viewport.Entities.Count - 1; i++)
				{
					if (clsItem.frmEditor.viewport.Entities[i].ColorMethod == colorMethodType.byLayer)
					{
						Color color = clsItem.frmEditor.viewport.Layers[clsItem.frmEditor.viewport.Entities[i].LayerName].Color;
						if (buImage5.isColorSimilar(color, Color.White, 10.0))
						{
							clsItem.frmEditor.viewport.Layers[clsItem.frmEditor.viewport.Entities[i].LayerName].Color = Color.Black;
						}
					}
					clsItem.frmEditor.viewport.Entities[i].ColorMethod = colorMethodType.byEntity;
					if (clsItem.frmEditor.viewport.Entities[i].ColorMethod == colorMethodType.byEntity)
					{
						clsItem.frmEditor.viewport.Entities[i].Color = clsVar.varEditorSet.colorEntity;
						clsItem.frmEditor.viewport.Entities[i].LineWeight = (float)clsVar.varEditorSet.thicknessEntity;
						clsItem.frmEditor.viewport.Entities[i].LineWeightMethod = colorMethodType.byEntity;
					}
					if (!clsVar.varEditorSet.DeleteIfSameEntities)
					{
						continue;
					}
					for (int j = i + 1; j <= clsItem.frmEditor.viewport.Entities.Count - 1; j++)
					{
						if (!clsItem.frmEditor.viewport.Entities[j].Selected && clsInit.cVector5.isEntitySame(clsItem.frmEditor.viewport.Entities[i], clsItem.frmEditor.viewport.Entities[j]))
						{
							clsItem.frmEditor.viewport.Entities[j].Selected = true;
						}
					}
				}
				clsItem.frmEditor.viewport.Entities.DeleteSelected();
				clsItem.frmEditor.viewport.Entities.RegenAllCurved(0.01);
				if (Math.Abs(clsItem.frmEditor.viewport.Entities.BoxMin.Z) < double.MaxValue)
				{
					clsItem.frmEditor.viewport.Entities.Translate(0.0, 0.0, 0.0 - clsItem.frmEditor.viewport.Entities.BoxMin.Z);
					clsItem.frmEditor.viewport.Entities.RegenAllCurved(0.01);
				}
				if (clsVar.varEditorSet.BreakArcIfGreat180Degree)
				{
					for (int k = 0; k <= clsItem.frmEditor.viewport.Entities.Count - 1; k++)
					{
						if (clsItem.frmEditor.viewport.Entities[k].GetType() == typeof(Arc))
						{
							Arc arc = clsItem.frmEditor.viewport.Entities[k] as Arc;
							if (arc.AngleInDegrees > 170.0)
							{
								Entity FirstArc = null;
								Entity SecondArc = null;
								clsInit.cVector5.SplitArcEntitiesIfGreaterThen180Degree(arc, ref FirstArc, ref SecondArc);
								if (FirstArc != null && SecondArc != null)
								{
									clsItem.frmEditor.viewport.Entities[k] = FirstArc;
									clsItem.frmEditor.viewport.Entities.Add(SecondArc);
								}
							}
						}
						if (clsItem.frmEditor.viewport.Entities[k].GetType() == typeof(Circle))
						{
							Circle refCircle = clsItem.frmEditor.viewport.Entities[k] as Circle;
							Entity Arc = null;
							Entity Arc2 = null;
							Entity Arc3 = null;
							Entity Arc4 = null;
							clsInit.cVector5.CircletoFourArc(refCircle, ref Arc, ref Arc2, ref Arc3, ref Arc4);
							if (Arc != null && Arc2 != null && Arc3 != null && Arc4 != null)
							{
								clsItem.frmEditor.viewport.Entities[k] = Arc;
								clsItem.frmEditor.viewport.Entities.Add(Arc2);
								clsItem.frmEditor.viewport.Entities.Add(Arc3);
								clsItem.frmEditor.viewport.Entities.Add(Arc);
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
				DxfImported = true;
			}
		}
		if (e.WorkUnit is WriteFileAsyncWithTextStyles)
		{
			SaveLibraryToZip();
		}
		Reset();
		sortRefEntities.Clear();
		sortedEntities.Clear();
		ManuelSortClickResult.ResultType = SortingResultType.None;
		for (int l = 0; l <= clsItem.frmEditor.OpenCommands.Count - 1; l++)
		{
			if (clsItem.frmEditor.OpenCommands[l].Trim() == "MoveZero")
			{
				clsItem.frmEditor.viewport.Entities.RegenAllCurved();
				if (clsItem.frmEditor.viewport.Entities.Count > 0)
				{
					clsItem.frmEditor.viewport.Entities.Translate(0.0 - clsItem.frmEditor.viewport.Entities.BoxMin.X, 0.0 - clsItem.frmEditor.viewport.Entities.BoxMin.Y, 0.0 - clsItem.frmEditor.viewport.Entities.BoxMin.Z);
				}
				clsItem.frmEditor.viewport.Entities.RegenAllCurved();
			}
			if (clsItem.frmEditor.OpenCommands[l].Trim() == "ZoomFit")
			{
				clsItem.frmEditor.viewport.ZoomFit(5);
			}
			if (clsItem.frmEditor.OpenCommands[l].Trim() == "SetViewTop")
			{
				clsItem.frmEditor.viewport.SetView(viewType.Top);
			}
			if (clsItem.frmEditor.OpenCommands[l].Trim() == "Invalidate")
			{
				clsItem.frmEditor.viewport.Invalidate();
			}
		}
		clsItem.frmEditor.OpenCommands.Clear();
	}

	public void cmdNew()
	{
		UndoBuffer();
		clsItem.frmEditor.viewport.Entities.Clear();
		clsItem.frmEditor.viewport.Invalidate();
	}

	public void cmdOpen(string FileName = "")
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.InitialDirectory = clsVar.varInterface.pathEditor;
		if (clsItem.frmEditor.OpenFileExtension.Count != 0)
		{
			for (int i = 0; i <= clsItem.frmEditor.OpenFileExtension.Count - 1; i++)
			{
				if (i != 0)
				{
					openFileDialog.Filter = openFileDialog.Filter + "|" + clsItem.frmEditor.OpenFileExtension[i].ToString();
				}
				else
				{
					openFileDialog.Filter = clsItem.frmEditor.OpenFileExtension[i].ToString();
				}
			}
		}
		else
		{
			for (int j = 0; j <= AppExtension.OpenFileExtension.Count - 1; j++)
			{
				if (j != 0)
				{
					openFileDialog.Filter = openFileDialog.Filter + "|" + AppExtension.OpenFileExtension[j].ToString();
				}
				else
				{
					openFileDialog.Filter = AppExtension.OpenFileExtension[j].ToString();
				}
			}
		}
		openFileDialog.FilterIndex = clsVar.varInterface.indexFileEditor;
		bool flag = true;
		bool flag2 = false;
		DialogResult dialogResult = DialogResult.None;
		if (FileName.Length > 0)
		{
			FileInfo fileInfo = new FileInfo(FileName);
			if (fileInfo.Exists)
			{
				flag2 = true;
				flag = false;
				openFileDialog.FileName = fileInfo.FullName;
			}
		}
		if (flag)
		{
			dialogResult = openFileDialog.ShowDialog();
		}
		if (!(dialogResult == DialogResult.OK || flag2))
		{
			return;
		}
		UndoBuffer();
		if ((buFile5.getFileExtension(openFileDialog.FileName).ToLower() == ".dxf") | (buFile5.getFileExtension(openFileDialog.FileName).ToLower() == ".dwg"))
		{
			ReadFileAsync readFileAsync = new ReadAutodesk(openFileDialog.FileName);
			((ReadAutodesk)readFileAsync).ExtrudeByThickness = clsVar.varFile.ExtrudeByThickness;
			clsItem.frmEditor.viewport.Clear();
			clsItem.frmEditor.viewport.StartWork(readFileAsync);
		}
		if (buFile5.getFileExtension(openFileDialog.FileName).ToLower() == ".bucadv5")
		{
			clsItem.frmEditor.viewport.Clear();
			List<Entity> refEntities = new List<Entity>();
			clsInit.appFiles.OpenBuCadFileVer5(openFileDialog.FileName, Clear: true, ref refEntities);
			for (int k = 0; k <= refEntities.Count - 1; k++)
			{
				clsItem.frmEditor.viewport.Entities.Add(refEntities[k]);
			}
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
		{
			AppExtension.SaveFileExtension.Add("Autocad Files (*.dxf)|*.dxf");
		}
		for (int i = 0; i <= AppExtension.SaveFileExtension.Count - 1; i++)
		{
			if (i != 0)
			{
				saveFileDialog.Filter = saveFileDialog.Filter + "|" + AppExtension.SaveFileExtension[i].ToString();
			}
			else
			{
				saveFileDialog.Filter = AppExtension.SaveFileExtension[i].ToString();
			}
		}
		saveFileDialog.FilterIndex = clsVar.varInterface.indexFileEditor;
		if (saveFileDialog.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		List<Entity> copiedEnt = new List<Entity>();
		buVector5.CopyEntities(clsItem.frmEditor.viewport.Entities, ref copiedEnt);
		if (clsItem.frmEditor.viewport.CurrentSketch != null && clsItem.frmEditor.viewport.CurrentSketch.Editing)
		{
			for (int num = copiedEnt.Count - 1; num >= 0; num--)
			{
				if (!(copiedEnt[num] is SketchEntity))
				{
					if (!(copiedEnt[num] is devDept.Eyeshot.Entities.Point))
					{
						if (copiedEnt[num] is Dimension)
						{
							copiedEnt.RemoveAt(num);
						}
					}
					else
					{
						copiedEnt.RemoveAt(num);
					}
				}
				else
				{
					copiedEnt.RemoveAt(num);
				}
			}
		}
		if ((buFile5.getFileExtension(saveFileDialog.FileName).ToLower() == ".dxf") | (buFile5.getFileExtension(saveFileDialog.FileName).ToLower() == ".dwg"))
		{
			buFile5.SaveDxfDwg(copiedEnt, saveFileDialog.FileName);
		}
		if (!(buFile5.getFileExtension(saveFileDialog.FileName).ToLower() == ".bucadv5"))
		{
		}
	}

	public void cmdInsert(ref List<Entity> refEntities)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.InitialDirectory = clsVar.varInterface.pathEditor;
		if (clsItem.frmEditor.OpenFileExtension.Count != 0)
		{
			for (int i = 0; i <= clsItem.frmEditor.OpenFileExtension.Count - 1; i++)
			{
				if (i != 0)
				{
					openFileDialog.Filter = openFileDialog.Filter + "|" + clsItem.frmEditor.OpenFileExtension[i].ToString();
				}
				else
				{
					openFileDialog.Filter = clsItem.frmEditor.OpenFileExtension[i].ToString();
				}
			}
		}
		else
		{
			for (int j = 0; j <= AppExtension.OpenFileExtension.Count - 1; j++)
			{
				if (j != 0)
				{
					openFileDialog.Filter = openFileDialog.Filter + "|" + AppExtension.OpenFileExtension[j].ToString();
				}
				else
				{
					openFileDialog.Filter = AppExtension.OpenFileExtension[j].ToString();
				}
			}
		}
		openFileDialog.FilterIndex = clsVar.varInterface.indexFileEditor;
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			UndoBuffer();
			if ((buFile5.getFileExtension(openFileDialog.FileName).ToLower() == ".dxf") | (buFile5.getFileExtension(openFileDialog.FileName).ToLower() == ".dwg"))
			{
				refEntities = new List<Entity>();
				buFile5.OpenDxfDwg(ref refEntities, openFileDialog.FileName);
			}
			if (buFile5.getFileExtension(openFileDialog.FileName).ToLower() == ".bucadv5")
			{
				refEntities = new List<Entity>();
				clsInit.appFiles.OpenBuCadFileVer5(openFileDialog.FileName, Clear: true, ref refEntities);
			}
			clsVar.varInterface.indexFileEditor = openFileDialog.FilterIndex;
			clsVar.varInterface.pathEditor = buFile5.GetPath(openFileDialog.FileName);
			clsFiles.SaveParameter();
		}
	}

	public void cmdOpenLib()
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.InitialDirectory = clsVar.varLibrary.pathLibrary;
		openFileDialog.Filter = "buCad/Cam Library File (*.bulib5)|*.bulib5";
		openFileDialog.FilterIndex = 1;
		if (openFileDialog.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		buFile5.ExtractToFolder(AppPath.Base + "\\L", openFileDialog.FileName);
		List<string> Files = new List<string>();
		buFile5.getFiles(AppPath.Base + "\\L", ref Files);
		string text = "";
		OpenCustomData = new List<EditorCustomData>();
		for (int i = 0; i <= Files.Count - 1; i++)
		{
			FileInfo fileInfo = new FileInfo(Files[i]);
			if (fileInfo.Exists)
			{
				if (fileInfo.Extension == ".buLibEye")
				{
					text = fileInfo.FullName;
				}
				if (fileInfo.Extension == ".buLibSet")
				{
					OpenEditorCustomDataToFile(fileInfo.FullName, ref OpenCustomData);
				}
			}
		}
		if (text.Length > 0)
		{
			ReadFile workUnit = new ReadFile(text);
			clsItem.frmEditor.viewport.Clear();
			clsItem.frmEditor.viewport.StartWork(workUnit);
		}
	}

	public void cmdSaveLib(Design Viewport)
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.InitialDirectory = clsVar.varLibrary.pathLibrary;
		saveFileDialog.Filter = "buCad/Cam Library File (*.bulib5)|*.bulib5";
		saveFileDialog.FilterIndex = 1;
		if (saveFileDialog.ShowDialog(clsItem.frmEditor) != DialogResult.OK)
		{
			return;
		}
		for (int i = 0; i <= Viewport.Entities.Count - 1; i++)
		{
			if (Viewport.Entities[i] is SketchEntity)
			{
				SketchEntity sketchEntity = Viewport.Entities[i] as SketchEntity;
				sketchEntity.Exit();
				Viewport.Entities.Regen();
				Viewport.Invalidate();
				FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
				string fileNameWithoutExtension = buFile5.getFileNameWithoutExtension(saveFileDialog.FileName);
				DirectoryInfo directoryInfo = new DirectoryInfo(fileInfo.DirectoryName + "\\" + fileNameWithoutExtension);
				if (directoryInfo.Exists)
				{
					directoryInfo.Delete(recursive: true);
				}
				Directory.CreateDirectory(directoryInfo.FullName);
				FileInfo fileInfo2 = new FileInfo(directoryInfo.FullName + "\\" + fileNameWithoutExtension + ".buLibEye");
				FileInfo fileInfo3 = new FileInfo(directoryInfo.FullName + "\\" + fileNameWithoutExtension + ".buLibSet");
				FIZip = new FileInfo(saveFileDialog.FileName);
				SaveEditorCustomDataToFile(Viewport, fileInfo3.FullName);
				WriteFile writeFile = null;
				WriteFileParams writeFileParams = new WriteFileParams(Viewport.Document);
				writeFile = new WriteFile(writeFileParams, fileInfo2.FullName);
				Viewport.StartWork(writeFile);
			}
		}
	}

	public void cmdDeleteEntity(Entity Ent)
	{
		if (clsItem.frmEditor.viewport.CurrentSketch.IsSketchEntity())
		{
			clsItem.frmEditor.viewport.CurrentSketch.DeleteEntity(Ent);
		}
		else
		{
			clsItem.frmEditor.viewport.CurrentSketch.DeleteConstraint(Ent);
		}
		clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
		clsItem.frmEditor.viewport.Invalidate();
	}

	public void cmdUndo()
	{
		Class5.smethod_219((Delegate3)clsItem.frmEditor.viewport.CurrentSketch.Undo, this);
	}

	public void cmdRedo()
	{
		Class5.smethod_219((Delegate3)clsItem.frmEditor.viewport.CurrentSketch.Redo, this);
	}

	public void cmdShowContrraint(bool Show)
	{
		foreach (devDept.Eyeshot.Control.Labels.Label label in clsItem.frmEditor.viewport.ActiveViewport.Labels)
		{
			if (label is StackedLabel)
			{
				StackedLabel stackedLabel = label as StackedLabel;
				stackedLabel.Visible = Show;
			}
		}
		clsItem.frmEditor.viewport.Invalidate();
	}

	public void cmdShowDimension(bool Show)
	{
		foreach (Entity entity in clsItem.frmEditor.viewport.Entities)
		{
			if (entity is Dimension)
			{
				entity.Visible = Show;
			}
		}
		clsItem.frmEditor.viewport.Invalidate();
	}

	public void cmdEventsMove()
	{
		ShowValueArea(Show: false);
		Sketcher2D.Clicks.Clear();
		clsInit.appEditor.action = actionTypeBU.eventMove;
		Sketcher2D.entitiesSelected.Clear();
		clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, Clone: false, ref Sketcher2D.entitiesSelected);
		if (Sketcher2D.entitiesSelected.Count != 0)
		{
			clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[0], buLangTranslate.preDef.Move);
			Sketcher2D.selectionProcess = false;
		}
		else
		{
			clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[10], buLangTranslate.preDef.Move);
			Sketcher2D.selectionProcess = true;
		}
	}

	public void cmdEventsCopy()
	{
		ShowValueArea(Show: false);
		Sketcher2D.Clicks.Clear();
		clsInit.appEditor.action = actionTypeBU.eventCopy;
		Sketcher2D.entitiesSelected.Clear();
		clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, Clone: false, ref Sketcher2D.entitiesSelected);
		if (Sketcher2D.entitiesSelected.Count != 0)
		{
			clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[0], buLangTranslate.preDef.Copy);
			Sketcher2D.selectionProcess = false;
		}
		else
		{
			clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[10], buLangTranslate.preDef.Copy);
			Sketcher2D.selectionProcess = true;
		}
	}

	public void cmdEventsMirror()
	{
		ShowValueArea(Show: false);
		Sketcher2D.Clicks.Clear();
		clsInit.appEditor.action = actionTypeBU.eventMirror;
		Sketcher2D.entitiesSelected.Clear();
		clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, Clone: false, ref Sketcher2D.entitiesSelected);
		if (Sketcher2D.entitiesSelected.Count != 0)
		{
			clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[122], buLangTranslate.preDef.Mirror);
			Sketcher2D.selectionProcess = false;
		}
		else
		{
			clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[10], buLangTranslate.preDef.Mirror);
			Sketcher2D.selectionProcess = true;
		}
	}

	public void cmdEventsOffset()
	{
		ShowValueArea(Show: true, buLangTranslate.preDef.Offset, clsVar.varEditorRuntimeSet.OffsetValue);
		Sketcher2D.Clicks.Clear();
		clsInit.appEditor.action = actionTypeBU.eventOffset;
		Sketcher2D.entitiesSelected.Clear();
		clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, Clone: false, ref Sketcher2D.entitiesSelected);
		if (Sketcher2D.entitiesSelected.Count != 0)
		{
			clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[33], buLangTranslate.preDef.Offset);
			Sketcher2D.selectionProcess = false;
		}
		else
		{
			clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[10], buLangTranslate.preDef.Offset);
			Sketcher2D.selectionProcess = true;
		}
	}

	public void cmdEventsRotate()
	{
		ShowValueArea(Show: false);
		Sketcher2D.Clicks.Clear();
		clsInit.appEditor.action = actionTypeBU.eventRotate;
		Sketcher2D.entitiesSelected.Clear();
		clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, Clone: false, ref Sketcher2D.entitiesSelected);
		if (Sketcher2D.entitiesSelected.Count != 0)
		{
			clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[20], buLangTranslate.preDef.Rotate);
			Sketcher2D.selectionProcess = false;
		}
		else
		{
			clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[10], buLangTranslate.preDef.Rotate);
			Sketcher2D.selectionProcess = true;
		}
	}

	public void cmdEventsBreak()
	{
		ShowValueArea(Show: false);
		Sketcher2D.Clicks.Clear();
		clsInit.appEditor.action = actionTypeBU.eventBreak;
		Sketcher2D.entitiesSelected.Clear();
		clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[36], buLangTranslate.preDef.Break);
		Sketcher2D.selectionProcess = false;
	}

	public void cmdEventsScale()
	{
		ShowValueArea(Show: true, buLangTranslate.preDef.Scale, clsVar.varEditorRuntimeSet.ScaleRatio);
		Sketcher2D.Clicks.Clear();
		clsInit.appEditor.action = actionTypeBU.eventScale;
		Sketcher2D.entitiesSelected.Clear();
		clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, Clone: false, ref Sketcher2D.entitiesSelected);
		if (Sketcher2D.entitiesSelected.Count != 0)
		{
			clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[31], buLangTranslate.preDef.Scale);
			Sketcher2D.selectionProcess = false;
		}
		else
		{
			clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[10], buLangTranslate.preDef.Scale);
			Sketcher2D.selectionProcess = true;
		}
	}

	public void cmdEventsExtend()
	{
		ShowValueArea(Show: true, buLangTranslate.preDef.Offset, clsVar.varEditorRuntimeSet.ExtendLength, -10000000.0);
		Sketcher2D.Clicks.Clear();
		clsInit.appEditor.action = actionTypeBU.eventExtend;
		Sketcher2D.entitiesSelected.Clear();
		clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[34], buLangTranslate.preDef.Extend);
		Sketcher2D.selectionProcess = false;
	}

	public void cmdEventsTrim()
	{
		ShowValueArea(Show: false);
		Sketcher2D.Clicks.Clear();
		clsInit.appEditor.action = actionTypeBU.eventTrim;
		Sketcher2D.entitiesSelected.Clear();
		clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[35], buLangTranslate.preDef.Trim);
		Sketcher2D.selectionProcess = false;
	}

	public void cmdEventsFillet()
	{
		ShowValueArea(Show: true, buLangTranslate.preDef.Fillet, clsVar.varEditorRuntimeSet.FilletRadius);
		Sketcher2D.Clicks.Clear();
		Sketcher2D.entitiesSelected.Clear();
		Sketcher2D.selectedIndex.Clear();
		_filletChamferIndex = null;
		_filletsChamfers = new Tuple<ICurve, ICurve, ICurve>[4];
		clsInit.appEditor.action = actionTypeBU.eventFillet;
		clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[124], buLangTranslate.preDef.Fillet);
		Sketcher2D.selectionProcess = false;
	}

	public void cmdEventsChamfer()
	{
		ShowValueArea(Show: true, buLangTranslate.preDef.Chamfer, clsVar.varEditorRuntimeSet.ChamferLength);
		Sketcher2D.Clicks.Clear();
		Sketcher2D.entitiesSelected.Clear();
		Sketcher2D.selectedIndex.Clear();
		_filletChamferIndex = null;
		_filletsChamfers = new Tuple<ICurve, ICurve, ICurve>[4];
		clsInit.appEditor.action = actionTypeBU.eventChamfer;
		clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[124], buLangTranslate.preDef.Chamfer);
		Sketcher2D.selectionProcess = false;
	}

	public void cmdEventsDelete()
	{
		ShowValueArea(Show: false);
		Sketcher2D.Clicks.Clear();
		clsInit.appEditor.action = actionTypeBU.eventDelete;
		Sketcher2D.entitiesSelected.Clear();
		clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, Clone: false, ref Sketcher2D.entitiesSelected);
		if (Sketcher2D.entitiesSelected.Count != 0)
		{
			clsItem.frmEditor.viewport.Entities.DeleteSelected();
			clsItem.frmEditor.viewport.Invalidate();
			clsInit.appEditor.Reset();
		}
		else
		{
			clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[10], buLangTranslate.preDef.Move);
			Sketcher2D.selectionProcess = true;
		}
	}

	public void cmdEventsAlingLeft(AlignmentEvent Type)
	{
		ShowValueArea(Show: false);
		if (Type == AlignmentEvent.Left)
		{
			clsInit.appEditor.action = actionTypeBU.eventAlingLeft;
		}
		if (Type == AlignmentEvent.Right)
		{
			clsInit.appEditor.action = actionTypeBU.eventAlingRight;
		}
		if (Type == AlignmentEvent.Top)
		{
			clsInit.appEditor.action = actionTypeBU.eventAlingTop;
		}
		if (Type == AlignmentEvent.Bottom)
		{
			clsInit.appEditor.action = actionTypeBU.eventAlingBottom;
		}
		if (Type == AlignmentEvent.HorizontalCenter)
		{
			clsInit.appEditor.action = actionTypeBU.eventAlingHorizontal;
		}
		if (Type == AlignmentEvent.VerticalCenter)
		{
			clsInit.appEditor.action = actionTypeBU.eventAlingVertical;
		}
		Sketcher2D.isAreaSelection = true;
		Sketcher2D.Clicks.Clear();
		Sketcher2D.entitiesSelected.Clear();
		Sketcher2D.selectedIndex.Clear();
		clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[10], buLangTranslate.preDef.Move);
		Sketcher2D.selectionProcess = true;
	}

	public void cmdEventsEqualDistance(EqualDistance Type)
	{
		ShowValueArea(Show: true, buLangTranslate.preDef.Distance, clsVar.varEditorRuntimeSet.EqualDistance);
		if (Type == EqualDistance.Horizontal)
		{
			clsInit.appEditor.action = actionTypeBU.eventEqualHorizontal;
		}
		if (Type == EqualDistance.Vertical)
		{
			clsInit.appEditor.action = actionTypeBU.eventEqualVertical;
		}
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
		clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, Clone: false, ref Sketcher2D.entitiesSelected);
		if (Sketcher2D.entitiesSelected.Count != 0)
		{
			Rotate(Degree);
			return;
		}
		clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[10], buLangTranslate.preDef.Rotate);
		Sketcher2D.selectionProcess = true;
	}

	public void cmdEventsMirrorValue(HorizontalVertical Value)
	{
		clsVar.varEditorRuntimeSet.LastMirrorType = Value;
		Sketcher2D.Clicks.Clear();
		clsInit.appEditor.action = actionTypeBU.eventMirrorValue;
		Sketcher2D.entitiesSelected.Clear();
		clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, Clone: false, ref Sketcher2D.entitiesSelected);
		if (Sketcher2D.entitiesSelected.Count != 0)
		{
			Mirror(Value);
			return;
		}
		clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[10], buLangTranslate.preDef.Mirror);
		Sketcher2D.selectionProcess = true;
	}

	public void cmdEventsTurnOver()
	{
		ShowCheckArea(Show: true, clsVar.varEditorRuntimeSet.TurnOverCenter, buLangTranslate.preDef.Center);
		ShowValueArea(Show: true, buLangTranslate.preDef.Distance, clsVar.varEditorRuntimeSet.TurnOverDistance);
		Sketcher2D.Clicks.Clear();
		clsInit.appEditor.action = actionTypeBU.eventTurnOver;
		Sketcher2D.entitiesSelected.Clear();
		clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, Clone: false, ref Sketcher2D.entitiesSelected);
		if (Sketcher2D.entitiesSelected.Count != 0)
		{
			TurnOver();
			return;
		}
		clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[10], buLangTranslate.preDef.TurnOver);
		Sketcher2D.selectionProcess = true;
	}

	public void StatusUpdate(string Message, string Command, string Args = "")
	{
		string text = "";
		if (Command.Length > 0)
		{
			text = Command + " : ";
		}
		clsItem.frmEditor.status_message.Text = text + Message + " " + Args;
	}

	public void cmdSimStart()
	{
		SimStarted = true;
		CreateSimPointsFromSortedEntities();
		if (clsInit.appEditor.sortedEntitiesSimIndex == -1)
		{
			clsInit.appEditor.sortedEntitiesSimIndex = 0;
		}
		timSim.Enabled = true;
	}

	public void cmdSimStop()
	{
		if (!SimStarted)
		{
			sortedEntitiesSimIndex = -1;
			RemoveSimArrow();
		}
		else
		{
			timSim.Enabled = false;
			SimStarted = false;
		}
	}

	public void cmdSimFwd()
	{
		Sim_Tick(null, null);
	}

	public void cmdSimBwd()
	{
		sortedEntitiesSimIndex -= clsVar.varEditorSet.SimulationStep;
		sortedEntitiesSimIndex -= clsVar.varEditorSet.SimulationStep;
		Sim_Tick(null, null);
	}

	public void Sim_Tick(object sender, EventArgs e)
	{
		if (!((sortedEntitiesSimIndex >= 0) & (sortedEntitiesSimIndex <= sortedEntitiesSimPoints.Count - 1)))
		{
			sortedEntitiesSimIndex = 0;
			timSim.Enabled = false;
			RemoveSimArrow();
		}
		else if (clsItem.frmEditor.viewport.Entities.Count > 0)
		{
			Entity entity = clsItem.frmEditor.viewport.Entities[clsItem.frmEditor.viewport.Entities.Count - 1];
			if ((entity.EntityData != null) & (entity.EntityData is CustomData))
			{
				CustomData customData = entity.EntityData as CustomData;
				if (customData.typeDefination == entityTypeDefination.Tool)
				{
					clsItem.frmEditor.viewport.Entities.RemoveAt(clsItem.frmEditor.viewport.Entities.Count - 1);
				}
			}
			entity = clsItem.frmEditor.viewport.Entities[clsItem.frmEditor.viewport.Entities.Count - 1];
			if ((entity.EntityData != null) & (entity.EntityData is CustomData))
			{
				CustomData customData2 = entity.EntityData as CustomData;
				if (customData2.typeDefination == entityTypeDefination.Tool)
				{
					clsItem.frmEditor.viewport.Entities.RemoveAt(clsItem.frmEditor.viewport.Entities.Count - 1);
				}
			}
			Pnt6DSimMove pnt6DSimMove = sortedEntitiesSimPoints[sortedEntitiesSimIndex];
			List<Point3D> list = new List<Point3D>();
			list.Add(new Point3D(pnt6DSimMove.X, pnt6DSimMove.Y, 0.0));
			list.Add(new Point3D(pnt6DSimMove.X + 80.0, pnt6DSimMove.Y + 20.0, 0.0));
			list.Add(new Point3D(pnt6DSimMove.X + 80.0, pnt6DSimMove.Y - 20.0, 0.0));
			list.Add(new Point3D(pnt6DSimMove.X, pnt6DSimMove.Y, 0.0));
			LinearPath linearPath = new LinearPath(list);
			linearPath.Rotate(buConversion5.DegreeToRadian(pnt6DSimMove.C + 180.0), Vector3D.AxisZ, new Point3D(pnt6DSimMove.X, pnt6DSimMove.Y, 0.0));
			devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(linearPath, Plane.XY, true);
			Mesh mesh = region.ExtrudeAsMesh(5.0, 0.1, Mesh.natureType.RichSmooth);
			CustomData customData3 = new CustomData();
			customData3.typeDefination = entityTypeDefination.Tool;
			mesh.EntityData = customData3;
			clsItem.frmEditor.viewport.Entities.Add(mesh);
			Text text = new Text(Plane.XY, new Point3D(pnt6DSimMove.X, pnt6DSimMove.Y - 6.0, pnt6DSimMove.Z), pnt6DSimMove.C.ToString("f1"), 20.0);
			CustomData customData4 = new CustomData();
			customData4.typeDefination = entityTypeDefination.Tool;
			text.EntityData = customData4;
			text.Color = Color.Red;
			text.ColorMethod = colorMethodType.byEntity;
			clsItem.frmEditor.viewport.Entities.Add(text);
			if (clsVar.varEditorSet.SimulationStep <= 0)
			{
				clsVar.varEditorSet.SimulationStep = 1;
			}
			sortedEntitiesSimIndex += clsVar.varEditorSet.SimulationStep;
		}
		clsItem.frmEditor.viewport.Invalidate();
	}

	public void CreateSimPointsFromSortedEntities()
	{
		if (clsVar.varEditorSet.SimulationDevideLength <= 0.1)
		{
			clsVar.varEditorSet.SimulationDevideLength = 5.0;
		}
		List<Point3D> Points = new List<Point3D>();
		List<Point3D> PointsDevided = new List<Point3D>();
		sortedEntitiesSimPoints.Clear();
		clsInit.cVector5.EntitiesToPointsWithCamDirection(sortedEntities, 0.01, ref Points);
		clsInit.cVector5.DevidePointsByLength(Points, clsVar.varEditorSet.SimulationDevideLength, ref PointsDevided);
		clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref PointsDevided);
		for (int i = 0; i <= PointsDevided.Count - 1; i++)
		{
			if (i != 0)
			{
				double c = sortedEntitiesSimPoints[sortedEntitiesSimPoints.Count - 1].C;
				double num = clsInit.cVector5.PointAngle(PointsDevided[i], PointsDevided[i - 1]);
				double num2 = num - c;
				if (!(num2 < -180.0))
				{
					if (num2 > 180.0)
					{
						num -= 360.0;
					}
				}
				else
				{
					num += 360.0;
				}
				if (Math.Abs(num - c) > 20.0)
				{
					sortedEntitiesSimPoints.Add(new Pnt6DSimMove(PointsDevided[i - 1].X, PointsDevided[i - 1].Y, PointsDevided[i - 1].Z, 0.0, 0.0, num));
				}
				sortedEntitiesSimPoints.Add(new Pnt6DSimMove(PointsDevided[i].X, PointsDevided[i].Y, PointsDevided[i].Z, 0.0, 0.0, num));
			}
			else
			{
				double c2 = clsInit.cVector5.PointAngle(PointsDevided[1], PointsDevided[0]);
				sortedEntitiesSimPoints.Add(new Pnt6DSimMove(PointsDevided[0].X, PointsDevided[0].Y, PointsDevided[0].Z, 0.0, 0.0, c2));
			}
		}
	}

	public void RemoveSimArrow()
	{
		Entity entity = clsItem.frmEditor.viewport.Entities[clsItem.frmEditor.viewport.Entities.Count - 1];
		if ((entity.EntityData != null) & (entity.EntityData is CustomData))
		{
			CustomData customData = entity.EntityData as CustomData;
			if (customData.typeDefination == entityTypeDefination.Tool)
			{
				clsItem.frmEditor.viewport.Entities.RemoveAt(clsItem.frmEditor.viewport.Entities.Count - 1);
			}
		}
		entity = clsItem.frmEditor.viewport.Entities[clsItem.frmEditor.viewport.Entities.Count - 1];
		if ((entity.EntityData != null) & (entity.EntityData is CustomData))
		{
			CustomData customData2 = entity.EntityData as CustomData;
			if (customData2.typeDefination == entityTypeDefination.Tool)
			{
				clsItem.frmEditor.viewport.Entities.RemoveAt(clsItem.frmEditor.viewport.Entities.Count - 1);
			}
		}
		clsItem.frmEditor.viewport.Invalidate();
	}

	public void AddPoint(UClick start)
	{
		if (!clsVar.varEditorRuntimeSet.isSketchMode)
		{
			UndoBuffer();
			devDept.Eyeshot.Entities.Point point = new devDept.Eyeshot.Entities.Point(new Point3D(start.Position.X, start.Position.Y));
			point.ColorMethod = colorMethodType.byEntity;
			point.Color = clsVar.varEditorSet.colorEntity;
			point.LineWeight = (float)clsVar.varEditorSet.thicknessEntityPoint;
			point.LineWeightMethod = colorMethodType.byEntity;
			clsItem.frmEditor.viewport.Entities.Add(point);
			return;
		}
		devDept.Eyeshot.Entities.Point point2 = clsItem.frmEditor.viewport.CurrentSketch.AddPoint(start.Position);
		if (start.Entity != null)
		{
			double t = 0.0;
			((ICurve)start.Entity).ClosestPointTo(new Point3D(start.Position.X, start.Position.Y), out t);
			clsItem.frmEditor.viewport.CurrentSketch.AddConstraintPointAt(point2, start.Entity, 0.5);
			clsItem.frmEditor.viewport.CurrentSketch.AddConstraintPointOn(point2, start.Entity);
		}
		clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
		JobUpdate();
	}

	public Line AddLine(UClick start, UClick end)
	{
		if (!clsVar.varEditorRuntimeSet.isSketchMode)
		{
			if (SewingTempVars.DrawCommand != SewingDrawCommand.LineJump)
			{
				if (SewingTempVars.DrawCommand != SewingDrawCommand.LineStitched)
				{
					UndoBuffer();
					Line line = new Line(new Point3D(start.Position.X, start.Position.Y), new Point3D(end.Position.X, end.Position.Y));
					line.ColorMethod = colorMethodType.byEntity;
					line.Color = clsVar.varEditorSet.colorEntity;
					line.LineWeight = (float)clsVar.varEditorSet.thicknessEntity;
					line.LineWeightMethod = colorMethodType.byEntity;
					clsItem.frmEditor.viewport.Entities.Add(line);
					return line;
				}
				if (clsInit.appSewing != null)
				{
					clsInit.appSewing.AddLineStitch(new Point3D(start.Position.X, start.Position.Y), new Point3D(end.Position.X, end.Position.Y));
					clsInit.appSewing.DrawSewingData(clsInit.appSewing.SewingBase, clsItem.frmEditor.viewport.Entities);
					Reset();
				}
				return null;
			}
			if (clsInit.appSewing != null)
			{
				clsInit.appSewing.AddLineJump(new Point3D(start.Position.X, start.Position.Y), new Point3D(end.Position.X, end.Position.Y));
				clsInit.appSewing.DrawSewingData(clsInit.appSewing.SewingBase, clsItem.frmEditor.viewport.Entities);
				Reset();
			}
			return null;
		}
		Line line2 = clsItem.frmEditor.viewport.CurrentSketch.AddLine(start.Position, end.Position);
		if (start.Entity != null)
		{
			clsItem.frmEditor.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditor.viewport.CurrentSketch.StartPoint(line2), start.Entity);
		}
		if (end.Entity != null)
		{
			clsItem.frmEditor.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditor.viewport.CurrentSketch.EndPoint(line2), end.Entity);
		}
		if (start.Entity == null || end.Entity == null)
		{
			Class5.smethod_126(this, line2);
		}
		clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
		JobUpdate();
		return line2;
	}

	public void AddRectangle(UClick start, UClick end)
	{
		if (!clsVar.varEditorRuntimeSet.isSketchMode)
		{
			UndoBuffer();
			Point2D position = start.Position;
			Point2D position2 = end.Position;
			double width = Math.Abs(position.X - position2.X);
			double height = Math.Abs(position.Y - position2.Y);
			double x = Math.Min(position.X, position2.X);
			double y = Math.Min(position.Y, position2.Y);
			CompositeCurve compositeCurve = CompositeCurve.CreateRectangle(x, y, width, height);
			compositeCurve.ColorMethod = colorMethodType.byEntity;
			compositeCurve.Color = clsVar.varEditorSet.colorEntity;
			compositeCurve.LineWeight = (float)clsVar.varEditorSet.thicknessEntity;
			compositeCurve.LineWeightMethod = colorMethodType.byEntity;
			clsItem.frmEditor.viewport.Entities.Add(compositeCurve);
			Reset();
		}
		else
		{
			Point2D position3 = start.Position;
			Point2D position4 = end.Position;
			double width2 = Math.Abs(position3.X - position4.X);
			double height2 = Math.Abs(position3.Y - position4.Y);
			double x2 = Math.Min(position3.X, position4.X);
			double y2 = Math.Min(position3.Y, position4.Y);
			Entity[] entity_ = clsItem.frmEditor.viewport.CurrentSketch.AddRectangle(x2, y2, width2, height2, 0.0, lengthConstraints: false);
			int int_ = default(int);
			Class5.smethod_72(ref int_, position4, position3, out int int_2, this);
			Class5.smethod_17(start.Entity, entity_, int_2, this);
			Class5.smethod_17(end.Entity, entity_, int_, this);
			clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
			Reset();
			JobUpdate();
		}
	}

	public void AddEllipse(UClick start, UClick end)
	{
		if (!clsVar.varEditorRuntimeSet.isSketchMode)
		{
			UndoBuffer();
			Point2D position = start.Position;
			double num = position.DistanceTo(new Point2D(end.Position.X, position.Y));
			double num2 = position.DistanceTo(new Point2D(position.X, end.Position.Y));
			if (!(num <= 0.001) && num2 > 0.001)
			{
				Ellipse ellipse = new Ellipse(Plane.XY, position, num, num2);
				ellipse.ColorMethod = colorMethodType.byEntity;
				ellipse.Color = clsVar.varEditorSet.colorEntity;
				ellipse.LineWeight = (float)clsVar.varEditorSet.thicknessEntity;
				ellipse.LineWeightMethod = colorMethodType.byEntity;
				clsItem.frmEditor.viewport.Entities.Add(ellipse);
			}
			Reset();
			return;
		}
		Point2D position2 = start.Position;
		double num3 = position2.DistanceTo(new Point2D(end.Position.X, position2.Y));
		double num4 = position2.DistanceTo(new Point2D(position2.X, end.Position.Y));
		if (!(num3 <= 0.001) && num4 > 0.001)
		{
			Ellipse ellipse2 = clsItem.frmEditor.viewport.CurrentSketch.AddEllipse(position2, num3, num4);
			if (start.Entity != null)
			{
				clsItem.frmEditor.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditor.viewport.CurrentSketch.CenterPoint(ellipse2), start.Entity);
			}
		}
		clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
		Reset();
		JobUpdate();
	}

	public void AddPolygon(UClick start, UClick end)
	{
		if (!clsVar.varEditorRuntimeSet.isSketchMode)
		{
			UndoBuffer();
			List<Pnt3D> Vertices = new List<Pnt3D>();
			clsInit.cVector.PolygonCenter(new Pnt3D(start.Position.X, start.Position.Y), new Pnt3D(end.Position.X, end.Position.Y), clsVar.varEditorRuntimeSet.PolygonSide, new WorkPlane(planeType.XY, 1), ref Vertices);
			List<Point3D> CopiedPnt = new List<Point3D>();
			buConversion5.Pnt3DToPoint3D(Vertices, ref CopiedPnt);
			LinearPath curve = new LinearPath(CopiedPnt);
			CompositeCurve compositeCurve = new CompositeCurve(curve);
			compositeCurve.ColorMethod = colorMethodType.byEntity;
			compositeCurve.Color = clsVar.varEditorSet.colorEntity;
			compositeCurve.LineWeightMethod = colorMethodType.byEntity;
			compositeCurve.LineWeight = (float)clsVar.varEditorSet.thicknessEntity;
			clsItem.frmEditor.viewport.Entities.Add(compositeCurve);
			Reset();
			return;
		}
		Vector2D asVector = (end.Position - start.Position).AsVector;
		Vector2D asVector2 = (Vector2D.AxisX - start.Position).AsVector;
		asVector.Normalize();
		asVector2.Normalize();
		double angle = Vector2D.SignedAngleBetween(Vector2D.AxisX, asVector);
		clsItem.frmEditor.viewport.CurrentSketch.AddPolygon(start.Position, start.Position.DistanceTo(end.Position), clsVar.varEditorRuntimeSet.PolygonSide, out var polygonCenter, out var firstPolygonVertex, angle);
		if (start.Entity != null)
		{
			clsItem.frmEditor.viewport.CurrentSketch.AddConstraintJoin(polygonCenter, start.Entity);
		}
		if (end.Entity != null)
		{
			clsItem.frmEditor.viewport.CurrentSketch.AddConstraintJoin(firstPolygonVertex, end.Entity);
		}
		clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
		Reset();
		JobUpdate();
	}

	public void AddKeyHole(UClick start)
	{
		if (!clsVar.varEditorRuntimeSet.isSketchMode)
		{
			UndoBuffer();
			buArc HeadArc = new buArc();
			buArc TaleArc = new buArc();
			buLine FirstLine = new buLine();
			buLine SecondLine = new buLine();
			clsInit.cVector5.KeyHole(new Point3D(start.Position.X, start.Position.Y), clsVar.varEditorRuntimeSet.KeyHoleHeadDiameter / 2.0, clsVar.varEditorRuntimeSet.KeyHoleWidth / 2.0, clsVar.varEditorRuntimeSet.KeyHoleLength, clsVar.varEditorRuntimeSet.KeyHoleAngle, Reverse: false, Plane.XY, ref HeadArc, ref TaleArc, ref FirstLine, ref SecondLine);
			List<buEntity> RefEntities = new List<buEntity>();
			if (HeadArc.Vertices.Count > 0)
			{
				RefEntities.Add(HeadArc);
			}
			if (FirstLine.Vertices.Count > 0)
			{
				RefEntities.Add(FirstLine);
			}
			if (TaleArc.Vertices.Count > 0)
			{
				RefEntities.Add(TaleArc);
			}
			if (SecondLine.Vertices.Count > 0)
			{
				RefEntities.Add(SecondLine);
			}
			clsInit.cVector5.SplitArcEntitiesIfGreaterThen180Degree(ref RefEntities, 150.0);
			buCompositeCurve calcCompositeCurve = null;
			clsInit.cVector5.CreateCompositeCurveFromEntities(RefEntities, ref calcCompositeCurve);
			Entity copiedEntity = null;
			buEntity.Copy(calcCompositeCurve, ref copiedEntity);
			if (copiedEntity != null)
			{
				copiedEntity.ColorMethod = colorMethodType.byEntity;
				copiedEntity.Color = clsVar.varEditorSet.colorEntity;
				copiedEntity.LineWeightMethod = colorMethodType.byEntity;
				copiedEntity.LineWeight = (float)clsVar.varEditorSet.thicknessEntity;
				clsItem.frmEditor.viewport.Entities.Add(copiedEntity);
			}
			Reset();
		}
		else
		{
			Reset();
			JobUpdate();
		}
	}

	public void AddSLot(UClick first, UClick second, UClick third)
	{
		if (!clsVar.varEditorRuntimeSet.isSketchMode)
		{
			UndoBuffer();
			Point2D position = first.Position;
			Point2D position2 = second.Position;
			Point2D position3 = third.Position;
			CompositeCurve compositeCurve = CompositeCurve.CreateSlot(position.X, position.Y, position.DistanceTo(position2), SlotRad(position, position2, position3), (position2 - position).AsVector.Angle);
			compositeCurve.ColorMethod = colorMethodType.byEntity;
			compositeCurve.Color = clsVar.varEditorSet.colorEntity;
			compositeCurve.LineWeight = (float)clsVar.varEditorSet.thicknessEntity;
			compositeCurve.LineWeightMethod = colorMethodType.byEntity;
			clsItem.frmEditor.viewport.Entities.Add(compositeCurve);
			return;
		}
		Point2D position4 = first.Position;
		Point2D position5 = second.Position;
		Point2D position6 = third.Position;
		Entity[] array = clsItem.frmEditor.viewport.CurrentSketch.AddSlot(position4.X, position4.Y, position4.DistanceTo(position5), SlotRad(position4, position5, position6), (position5 - position4).AsVector.Angle);
		Circle circle = array[3] as Circle;
		Circle circle2 = array[1] as Circle;
		if (first.Entity != null)
		{
			clsItem.frmEditor.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditor.viewport.CurrentSketch.CenterPoint(circle), first.Entity);
		}
		if (second.Entity != null)
		{
			clsItem.frmEditor.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditor.viewport.CurrentSketch.CenterPoint(circle2), second.Entity);
		}
		clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
		Reset();
		JobUpdate();
	}

	public void AddSpline(devDept.Eyeshot.Entities.Point _firstPoint, List<UClick> Clicks)
	{
		if (!clsVar.varEditorRuntimeSet.isSketchMode)
		{
			if (Clicks.Count > 2)
			{
				UndoBuffer();
				List<Point3D> list = new List<Point3D>();
				for (int i = 0; i <= Clicks.Count - 1; i++)
				{
					list.Add(new Point3D(Clicks[i].Position.X, Clicks[i].Position.Y));
				}
				Curve curve = Curve.CubicSplineInterpolation(list);
				curve.ColorMethod = colorMethodType.byEntity;
				curve.Color = clsVar.varEditorSet.colorEntity;
				curve.LineWeight = (float)clsVar.varEditorSet.thicknessEntity;
				curve.LineWeightMethod = colorMethodType.byEntity;
				clsItem.frmEditor.viewport.Entities.Add(curve);
				Reset();
			}
			return;
		}
		if (_firstPoint != null && _firstPoint != Clicks[0].Entity)
		{
			clsItem.frmEditor.viewport.CurrentSketch.DeleteEntity(_firstPoint);
		}
		if (Clicks.Count <= 2)
		{
			return;
		}
		Curve[] array = clsItem.frmEditor.viewport.CurrentSketch.AddSpline(Clicks.Select((UClick uclick_0) => uclick_0.Position).ToList());
		for (int num = 0; num < array.Length; num++)
		{
			devDept.Eyeshot.Entities.Point p = clsItem.frmEditor.viewport.CurrentSketch.StartPoint(array[num]);
			if (Clicks[num].Entity != null)
			{
				clsItem.frmEditor.viewport.CurrentSketch.AddConstraintJoin(p, Clicks[num].Entity);
			}
		}
		UClick uClick = Clicks.Last();
		if (uClick.Entity != null && uClick.Entity != _firstPoint)
		{
			devDept.Eyeshot.Entities.Point p2 = clsItem.frmEditor.viewport.CurrentSketch.EndPoint(array.Last());
			clsItem.frmEditor.viewport.CurrentSketch.AddConstraintJoin(p2, uClick.Entity);
		}
		clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
		Reset();
		JobUpdate();
	}

	public Line ExtendLine(Line other, UClick end)
	{
		if (!clsVar.varEditorRuntimeSet.isSketchMode)
		{
			return new Line(new Point3D(), new Point3D());
		}
		Line line = clsItem.frmEditor.viewport.CurrentSketch.AddLine(clsItem.frmEditor.viewport.CurrentSketch.Plane.Project(other.EndPoint), end.Position);
		clsItem.frmEditor.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditor.viewport.CurrentSketch.EndPoint(other), clsItem.frmEditor.viewport.CurrentSketch.StartPoint(line));
		if (end.Entity != null)
		{
			clsItem.frmEditor.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditor.viewport.CurrentSketch.EndPoint(line), end.Entity);
		}
		Class5.smethod_126(this, line);
		clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
		JobUpdate();
		return line;
	}

	public Circle AddCircle(UClick start, UClick end)
	{
		if (!clsVar.varEditorRuntimeSet.isSketchMode)
		{
			double num = Point2D.Distance(start.Position, end.Position);
			if (num > 0.0)
			{
				UndoBuffer();
				Circle circle = new Circle(Plane.XY, new Point3D(start.Position.X, start.Position.Y), num);
				circle.ColorMethod = colorMethodType.byEntity;
				circle.Color = clsVar.varEditorSet.colorEntity;
				circle.LineWeight = (float)clsVar.varEditorSet.thicknessEntity;
				circle.LineWeightMethod = colorMethodType.byEntity;
				clsItem.frmEditor.viewport.Entities.Add(circle);
			}
			Reset();
			return null;
		}
		Circle result = clsItem.frmEditor.viewport.CurrentSketch.AddCircle(start.Position, end.Position);
		clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
		action = actionTypeBU.None;
		JobUpdate();
		return result;
	}

	public Circle AddCircle(UClick first, UClick second, UClick third)
	{
		if (SewingTempVars.DrawCommand != SewingDrawCommand.ArcStitched)
		{
			UndoBuffer();
			Circle circle = new Circle(new Point3D(first.Position.X, first.Position.Y), new Point3D(second.Position.X, second.Position.Y), new Point3D(third.Position.X, third.Position.Y));
			circle.ColorMethod = colorMethodType.byEntity;
			circle.Color = clsVar.varEditorSet.colorEntity;
			circle.LineWeight = (float)clsVar.varEditorSet.thicknessEntity;
			circle.LineWeightMethod = colorMethodType.byEntity;
			clsItem.frmEditor.viewport.Entities.Add(circle);
			Reset();
			return circle;
		}
		if (clsInit.appSewing != null)
		{
			clsInit.appSewing.AddCircleStitch(new Point3D(first.Position.X, first.Position.Y), new Point3D(second.Position.X, second.Position.Y), new Point3D(third.Position.X, third.Position.Y));
			clsInit.appSewing.DrawSewingData(clsInit.appSewing.SewingBase, clsItem.frmEditor.viewport.Entities);
			Reset();
		}
		return null;
	}

	public Arc AddArc(UClick first, UClick second, UClick third)
	{
		if (!clsVar.varEditorRuntimeSet.isSketchMode)
		{
			if (EvaluateArc(first.Position, second.Position, third.Position, out var flip))
			{
				if (SewingTempVars.DrawCommand != SewingDrawCommand.ArcStitched)
				{
					UndoBuffer();
					Arc arc = new Arc(Plane.XY, new Point3D(first.Position.X, first.Position.Y), new Point3D(second.Position.X, second.Position.Y), new Point3D(third.Position.X, third.Position.Y), flip);
					arc.ColorMethod = colorMethodType.byEntity;
					arc.Color = clsVar.varEditorSet.colorEntity;
					arc.LineWeight = (float)clsVar.varEditorSet.thicknessEntity;
					arc.LineWeightMethod = colorMethodType.byEntity;
					clsItem.frmEditor.viewport.Entities.Add(arc);
					Reset();
					return arc;
				}
				if (clsInit.appSewing != null)
				{
					clsInit.appSewing.AddArcStitch(new Point3D(first.Position.X, first.Position.Y), new Point3D(second.Position.X, second.Position.Y), new Point3D(third.Position.X, third.Position.Y), flip);
					clsInit.appSewing.DrawSewingData(clsInit.appSewing.SewingBase, clsItem.frmEditor.viewport.Entities);
					Reset();
				}
				return null;
			}
			return null;
		}
		if (EvaluateArc(first.Position, second.Position, third.Position, out var flip2))
		{
			Arc arc2 = new Arc(clsItem.frmEditor.viewport.CurrentSketch.Plane, first.Position, second.Position, third.Position, flip2);
			clsItem.frmEditor.viewport.CurrentSketch.AddArc(arc2);
			if (first.Entity != null)
			{
				if (flip2)
				{
					clsItem.frmEditor.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditor.viewport.CurrentSketch.EndPoint(arc2), first.Entity);
				}
				else
				{
					clsItem.frmEditor.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditor.viewport.CurrentSketch.StartPoint(arc2), first.Entity);
				}
			}
			if (third.Entity != null)
			{
				if (flip2)
				{
					clsItem.frmEditor.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditor.viewport.CurrentSketch.StartPoint(arc2), third.Entity);
				}
				else
				{
					clsItem.frmEditor.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditor.viewport.CurrentSketch.EndPoint(arc2), third.Entity);
				}
			}
			clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
			JobUpdate();
			return arc2;
		}
		return null;
	}

	public void AddFilletChamfer(bool isFillet, ICurve C1, ICurve C2)
	{
		if (!_filletChamferIndex.HasValue)
		{
			return;
		}
		Tuple<bool, bool> tuple = Class5.smethod_138(_filletChamferIndex.Value, this);
		DialogBoxInput dialogBoxInput = new DialogBoxInput();
		dialogBoxInput.Value = clsVar.varEditorRuntimeSet.FilletRadius;
		dialogBoxInput.StartPosition = FormStartPosition.CenterParent;
		dialogBoxInput.Init();
		dialogBoxInput.ShowDialog();
		if (dialogBoxInput.Result != DialogResult.OK)
		{
			clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
		}
		else
		{
			if (!isFillet)
			{
				clsVar.varEditorRuntimeSet.ChamferLength = dialogBoxInput.Value;
			}
			else
			{
				clsVar.varEditorRuntimeSet.FilletRadius = dialogBoxInput.Value;
			}
			if (!isFillet)
			{
				clsItem.frmEditor.viewport.CurrentSketch.AddChamfer(C1, C2, tuple.Item1, tuple.Item2, clsVar.varEditorRuntimeSet.ChamferLength);
			}
			else
			{
				clsItem.frmEditor.viewport.CurrentSketch.AddFillet(C1, C2, tuple.Item1, tuple.Item2, clsVar.varEditorRuntimeSet.FilletRadius);
			}
			clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
			if (isFillet && clsItem.frmEditor != null)
			{
				clsItem.frmEditor.mnu_lib_Click(clsItem.frmEditor.mnu_libfillet, null);
			}
		}
		for (int i = 0; i <= clsItem.frmEditor.viewport.Entities.Count - 1; i++)
		{
			clsItem.frmEditor.viewport.Entities[i].Selected = false;
		}
		clsItem.frmEditor.viewport.Invalidate();
		JobUpdate();
	}

	public void CreateConstraintPointOn(devDept.Eyeshot.Entities.Point pnt, Entity ent)
	{
		clsItem.frmEditor.viewport.CurrentSketch.AddConstraintPointOn(pnt, ent);
		clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
		JobUpdate();
	}

	public void CreateConstraintVertical(Line line)
	{
		clsItem.frmEditor.viewport.CurrentSketch.AddConstraintVertical(line);
		clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
		JobUpdate();
	}

	public void CreateConstraintHorizontal(Line line)
	{
		clsItem.frmEditor.viewport.CurrentSketch.AddConstraintHorizontal(line);
		clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
		JobUpdate();
	}

	public void CreateConstraintLength(Line line, Point2D refPoint)
	{
		clsItem.frmEditor.viewport.CurrentSketch.AddConstraintLength(line, -1.0, reference: false, refPoint);
		clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
		clsItem.frmEditor.viewport.Invalidate();
		JobUpdate();
	}

	public void CreateConstraintLineLineDistance(Line L1, Line L2, Point2D refPoint)
	{
		clsItem.frmEditor.viewport.CurrentSketch.AddConstraintLinesDistance(L1, L2, -1.0, reference: false, refPoint);
		clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
		clsItem.frmEditor.viewport.Invalidate();
		Reset();
		JobUpdate();
	}

	public void CreateConstraintLinePointDistance(devDept.Eyeshot.Entities.Point P1, Line L1, Point2D refPoint)
	{
		clsItem.frmEditor.viewport.CurrentSketch.AddConstraintPointLineDistance(P1, L1, -1.0, reference: false, refPoint);
		clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
		clsItem.frmEditor.viewport.Invalidate();
		Reset();
		JobUpdate();
	}

	public void CreateConstraintPointPointAlignedDistance(devDept.Eyeshot.Entities.Point P1, devDept.Eyeshot.Entities.Point P2, Point2D refPoint)
	{
		clsItem.frmEditor.viewport.CurrentSketch.AddConstraintAlignedPointsDistance(P1, P2, -1.0, reference: false, refPoint);
		clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
		clsItem.frmEditor.viewport.Invalidate();
		Reset();
		JobUpdate();
	}

	public void CreateConstraintPointPointHorizontalDistance(devDept.Eyeshot.Entities.Point P1, devDept.Eyeshot.Entities.Point P2, Point2D refPoint)
	{
		clsItem.frmEditor.viewport.CurrentSketch.AddConstraintHorizontalPointsDistance(P1, P2, -1.0, reference: false, refPoint);
		clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
		clsItem.frmEditor.viewport.Invalidate();
		Reset();
		JobUpdate();
	}

	public void CreateConstraintPointPointVerticalDistance(devDept.Eyeshot.Entities.Point P1, devDept.Eyeshot.Entities.Point P2, Point2D refPoint)
	{
		clsItem.frmEditor.viewport.CurrentSketch.AddConstraintVerticalPointsDistance(P1, P2, -1.0, reference: false, refPoint);
		clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
		clsItem.frmEditor.viewport.Invalidate();
		Reset();
		JobUpdate();
	}

	public void CreateConstraintCollinear(Line L1, Line L2)
	{
		clsItem.frmEditor.viewport.CurrentSketch.AddConstraintCollinear(L1, L2);
		clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
		for (int i = 0; i <= clsItem.frmEditor.viewport.Entities.Count - 1; i++)
		{
			clsItem.frmEditor.viewport.Entities[i].Selected = false;
		}
		clsItem.frmEditor.viewport.Invalidate();
		Reset();
		JobUpdate();
	}

	public void CreateConstraintParallel(Line L1, Line L2)
	{
		clsItem.frmEditor.viewport.CurrentSketch.AddConstraintParallelLines(L1, L2);
		clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
		for (int i = 0; i <= clsItem.frmEditor.viewport.Entities.Count - 1; i++)
		{
			clsItem.frmEditor.viewport.Entities[i].Selected = false;
		}
		clsItem.frmEditor.viewport.Invalidate();
		Reset();
		JobUpdate();
	}

	public void CreateConstraintPerpendicular(Line L1, Line L2)
	{
		clsItem.frmEditor.viewport.CurrentSketch.AddConstraintPerpendicular(L1, L2);
		clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
		for (int i = 0; i <= clsItem.frmEditor.viewport.Entities.Count - 1; i++)
		{
			clsItem.frmEditor.viewport.Entities[i].Selected = false;
		}
		clsItem.frmEditor.viewport.Invalidate();
		Reset();
		JobUpdate();
	}

	public void CreateConstraintTangent(Entity E1, Entity E2)
	{
		clsItem.frmEditor.viewport.CurrentSketch.AddConstraintTangent(E1, E2);
		clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
		for (int i = 0; i <= clsItem.frmEditor.viewport.Entities.Count - 1; i++)
		{
			clsItem.frmEditor.viewport.Entities[i].Selected = false;
		}
		clsItem.frmEditor.viewport.Invalidate();
		Reset();
		JobUpdate();
	}

	public void CreateConstraintAngle(Arc arc, Point2D refPoint)
	{
		clsItem.frmEditor.viewport.CurrentSketch.AddConstraintAngle(arc, -1.0, reference: false, refPoint);
		clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
		for (int i = 0; i <= clsItem.frmEditor.viewport.Entities.Count - 1; i++)
		{
			clsItem.frmEditor.viewport.Entities[i].Selected = false;
		}
		clsItem.frmEditor.viewport.Invalidate();
		clsItem.frmEditor.viewport.Invalidate();
		Reset();
		JobUpdate();
	}

	public void CreateConstraintAngle(Line L1, Line L2, Point2D refPoint)
	{
		Tuple<Segment2D, Segment2D> segments = GetSegments(L1, L2);
		Segment2D.IntersectionLine(segments.Item1, segments.Item2, out var i);
		int quadIndex;
		double degrees = Utility.RadToDeg(_clock.Locate(Sketcher2D.mousePlnLoc - i, out quadIndex).Length);
		double value = Utility.DegToRad(degrees);
		clsItem.frmEditor.viewport.CurrentSketch.AddConstraintAngle(L1, L2, refPoint, value);
		clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
		for (int j = 0; j <= clsItem.frmEditor.viewport.Entities.Count - 1; j++)
		{
			clsItem.frmEditor.viewport.Entities[j].Selected = false;
		}
		clsItem.frmEditor.viewport.Invalidate();
		Reset();
		JobUpdate();
	}

	public void CreateConstraintDiameter(Circle line)
	{
		clsItem.frmEditor.viewport.CurrentSketch.AddConstraintDiameter(line);
		clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
		clsItem.frmEditor.viewport.Invalidate();
		JobUpdate();
	}

	public void CreateConstraintFixPoint(Entity Ent, Point3D refPoint)
	{
		StartEndCenterType startEndCenterType = StartEndCenterType.Start;
		if (!(Ent is Line || Ent is Arc || Ent is Circle || Ent is Ellipse || Ent is Curve || Ent is EllipticalArc))
		{
			if (!(Ent is Circle || Ent is Ellipse))
			{
				return;
			}
			startEndCenterType = StartEndCenterType.Center;
		}
		else
		{
			double num = Point3D.Distance(((ICurve)Ent).StartPoint, refPoint);
			double num2 = Point3D.Distance(((ICurve)Ent).EndPoint, refPoint);
			startEndCenterType = ((num < num2) ? StartEndCenterType.Start : StartEndCenterType.End);
		}
		if (startEndCenterType == StartEndCenterType.End)
		{
			if (Ent is Line)
			{
				clsItem.frmEditor.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditor.viewport.CurrentSketch.EndPoint((Line)Ent));
			}
			if (Ent is Curve)
			{
				clsItem.frmEditor.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditor.viewport.CurrentSketch.EndPoint((Curve)Ent));
			}
			if (Ent is Arc)
			{
				clsItem.frmEditor.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditor.viewport.CurrentSketch.EndPoint((Arc)Ent));
			}
			if (Ent is EllipticalArc)
			{
				clsItem.frmEditor.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditor.viewport.CurrentSketch.EndPoint((EllipticalArc)Ent));
			}
		}
		if (startEndCenterType == StartEndCenterType.Start)
		{
			if (Ent is Line)
			{
				clsItem.frmEditor.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditor.viewport.CurrentSketch.StartPoint((Line)Ent));
			}
			if (Ent is Curve)
			{
				clsItem.frmEditor.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditor.viewport.CurrentSketch.StartPoint((Curve)Ent));
			}
			if (Ent is Arc)
			{
				clsItem.frmEditor.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditor.viewport.CurrentSketch.StartPoint((Arc)Ent));
			}
			if (Ent is EllipticalArc)
			{
				clsItem.frmEditor.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditor.viewport.CurrentSketch.StartPoint((EllipticalArc)Ent));
			}
		}
		if (startEndCenterType == StartEndCenterType.Center)
		{
			if (Ent is Circle)
			{
				clsItem.frmEditor.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditor.viewport.CurrentSketch.CenterPoint((Circle)Ent));
			}
			if (Ent is Arc)
			{
				clsItem.frmEditor.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditor.viewport.CurrentSketch.CenterPoint((Arc)Ent));
			}
			if (Ent is Ellipse)
			{
				clsItem.frmEditor.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditor.viewport.CurrentSketch.CenterPoint((Ellipse)Ent));
			}
		}
		clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
		clsItem.frmEditor.viewport.Invalidate();
		JobUpdate();
	}

	public void CreateConstraintEqualLength(Entity FirstEntity, Entity SecondEntity, bool Radius)
	{
		clsItem.frmEditor.viewport.CurrentSketch.AddConstraintEqual(FirstEntity, SecondEntity, Radius);
		clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
		for (int i = 0; i <= clsItem.frmEditor.viewport.Entities.Count - 1; i++)
		{
			clsItem.frmEditor.viewport.Entities[i].Selected = false;
		}
		clsItem.frmEditor.viewport.Invalidate();
		JobUpdate();
	}

	public void Chk_CheckedChenged(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == clsItem.frmEditor.chk_check.Name && clsInit.appEditor.action == actionTypeBU.eventTurnOver)
		{
			clsVar.varEditorRuntimeSet.TurnOverCenter = clsItem.frmEditor.chk_check.Checked;
		}
	}

	public void Spn_ValueChanged(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == clsItem.frmEditor.spn_value.Name)
		{
			if (clsInit.appEditor.action == actionTypeBU.eventOffset)
			{
				clsVar.varEditorRuntimeSet.OffsetValue = (double)clsItem.frmEditor.spn_value.Value;
			}
			if (clsInit.appEditor.action == actionTypeBU.eventExtend)
			{
				clsVar.varEditorRuntimeSet.ExtendLength = (double)clsItem.frmEditor.spn_value.Value;
			}
			if (clsInit.appEditor.action == actionTypeBU.eventFillet)
			{
				clsVar.varEditorRuntimeSet.FilletRadius = (double)clsItem.frmEditor.spn_value.Value;
			}
			if (clsInit.appEditor.action == actionTypeBU.eventChamfer)
			{
				clsVar.varEditorRuntimeSet.ChamferLength = (double)clsItem.frmEditor.spn_value.Value;
			}
		}
	}

	public void ShowValueArea(bool Show, string Caption = "", double Value = 0.0, double MinVal = -1000000.0, double MaxVal = 10000000.0, int Decimal = 2)
	{
		clsItem.frmEditor.lbl_value.Visible = Show;
		clsItem.frmEditor.lbl_value.Text = Caption;
		clsItem.frmEditor.spn_value.Visible = Show;
		clsItem.frmEditor.spn_value.DecimalPlaces = Decimal;
		clsItem.frmEditor.spn_value.Minimum = (decimal)MinVal;
		clsItem.frmEditor.spn_value.Maximum = (decimal)MaxVal;
		clsItem.frmEditor.spn_value.Value = (decimal)Value;
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
		ICurve curve = selEntity as ICurve;
		Point3D point3D = null;
		Point3D point3D2 = null;
		double offsetValue = clsVar.varEditorRuntimeSet.OffsetValue;
		if (clsVar.varEditorRuntimeSet.OffsetValue != 0.0)
		{
			ICurve[] array = curve.Offset(offsetValue, Vector3D.AxisZ, sharp: true);
			ICurve curve2 = ((array == null) ? null : array[0]);
			ICurve[] array2 = curve.Offset(0.0 - offsetValue, Vector3D.AxisZ, sharp: true);
			ICurve curve3 = ((array2 == null) ? null : array2[0]);
			curve2.Project(refPoint, out var t);
			point3D = curve2.PointAt(t);
			double num = point3D.DistanceTo(refPoint);
			curve3.Project(refPoint, out var t2);
			point3D2 = curve3.PointAt(t2);
			double num2 = point3D2.DistanceTo(refPoint);
			if (!(num < num2))
			{
				entityOffseted = (Entity)curve3;
			}
			else
			{
				entityOffseted = (Entity)curve2;
			}
			return true;
		}
		buString5.MessageBoxWarning(buLangTranslate.preDef.Offset + " " + buLangTranslate.preDef.Value + " =  0");
		Reset();
		return false;
	}

	public void Break(Entity selEntity, Point3D refPoint, ref Entity entityFirst, ref Entity entitySecond)
	{
		ICurve curve = selEntity as ICurve;
		ICurve lower = null;
		ICurve upper = null;
		if (curve.Project(refPoint, out var t))
		{
			curve.SplitAt(t, out lower, out upper);
		}
		if (lower != null && upper != null)
		{
			entityFirst = (Entity)lower;
			entitySecond = (Entity)upper;
		}
	}

	public void EqualDistanceEvent(double Distance)
	{
		clsVar.varEditorRuntimeSet.EqualDistance = Distance;
		EntityList entityList = null;
		if (clsInit.appEditor.action == actionTypeBU.eventEqualHorizontal)
		{
			entityList = clsInit.cVector5.EqualDistanceEntities(clsItem.frmEditor.viewport.Entities, Sketcher2D.selectedIndex, EqualDistance.Horizontal, clsVar.varEditorRuntimeSet.EqualDistance);
		}
		if (clsInit.appEditor.action == actionTypeBU.eventEqualVertical)
		{
			entityList = clsInit.cVector5.EqualDistanceEntities(clsItem.frmEditor.viewport.Entities, Sketcher2D.selectedIndex, EqualDistance.Vertical, clsVar.varEditorRuntimeSet.EqualDistance);
		}
		if (entityList != null && entityList.Count > 0)
		{
			for (int i = 0; i <= entityList.Count - 1; i++)
			{
				clsItem.frmEditor.viewport.Entities[i] = entityList[i];
			}
			clsItem.frmEditor.viewport.Entities.RegenAllCurved();
			clsItem.frmEditor.viewport.Invalidate();
			clsInit.appEditor.Reset();
		}
	}

	public void Align()
	{
		EntityList entityList = null;
		if (clsInit.appEditor.action == actionTypeBU.eventAlingLeft)
		{
			entityList = clsInit.cVector5.AlingEntities(clsItem.frmEditor.viewport.Entities, Sketcher2D.selectedIndex, AlignmentEvent.Left);
		}
		if (clsInit.appEditor.action == actionTypeBU.eventAlingRight)
		{
			entityList = clsInit.cVector5.AlingEntities(clsItem.frmEditor.viewport.Entities, Sketcher2D.selectedIndex, AlignmentEvent.Right);
		}
		if (clsInit.appEditor.action == actionTypeBU.eventAlingTop)
		{
			entityList = clsInit.cVector5.AlingEntities(clsItem.frmEditor.viewport.Entities, Sketcher2D.selectedIndex, AlignmentEvent.Top);
		}
		if (clsInit.appEditor.action == actionTypeBU.eventAlingBottom)
		{
			entityList = clsInit.cVector5.AlingEntities(clsItem.frmEditor.viewport.Entities, Sketcher2D.selectedIndex, AlignmentEvent.Bottom);
		}
		if (clsInit.appEditor.action == actionTypeBU.eventAlingHorizontal)
		{
			entityList = clsInit.cVector5.AlingEntities(clsItem.frmEditor.viewport.Entities, Sketcher2D.selectedIndex, AlignmentEvent.HorizontalCenter);
		}
		if (clsInit.appEditor.action == actionTypeBU.eventAlingVertical)
		{
			entityList = clsInit.cVector5.AlingEntities(clsItem.frmEditor.viewport.Entities, Sketcher2D.selectedIndex, AlignmentEvent.VerticalCenter);
		}
		if (entityList == null)
		{
			return;
		}
		UndoBuffer();
		if (entityList.Count > 0)
		{
			for (int i = 0; i <= entityList.Count - 1; i++)
			{
				clsItem.frmEditor.viewport.Entities[i] = entityList[i];
			}
			clsItem.frmEditor.viewport.Entities.RegenAllCurved();
			clsItem.frmEditor.viewport.Invalidate();
			clsInit.appEditor.Reset();
		}
	}

	public void Rotate(double Degree)
	{
		Point3D MinPoint = new Point3D();
		Point3D MidPoint = new Point3D();
		Point3D MaxPoint = new Point3D();
		if (Sketcher2D.entitiesSelected.Count == 0)
		{
			clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, Clone: false, ref Sketcher2D.entitiesSelected);
		}
		if (Sketcher2D.entitiesSelected.Count > 0)
		{
			UndoBuffer();
			clsInit.cVector5.BoxSizeCalculate(Sketcher2D.entitiesSelected, ref MinPoint, ref MidPoint, ref MaxPoint);
			for (int i = 0; i <= clsItem.frmEditor.viewport.Entities.Count - 1; i++)
			{
				Entity entity = clsItem.frmEditor.viewport.Entities[i];
				if (entity.Selected)
				{
					entity.Rotate(buConversion5.DegreeToRadian(Degree), Vector3D.AxisZ, MidPoint);
				}
			}
			clsItem.frmEditor.viewport.Entities.RegenAllCurved(0.02);
		}
		clsItem.frmEditor.viewport.Invalidate();
		Reset();
	}

	public void Mirror(HorizontalVertical Value)
	{
		Point3D MinPoint = new Point3D();
		Point3D MidPoint = new Point3D();
		Point3D MaxPoint = new Point3D();
		if (Sketcher2D.entitiesSelected.Count == 0)
		{
			clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, Clone: false, ref Sketcher2D.entitiesSelected);
		}
		clsInit.cVector5.BoxSizeCalculate(Sketcher2D.entitiesSelected, ref MinPoint, ref MidPoint, ref MaxPoint);
		if (Sketcher2D.entitiesSelected.Count > 0)
		{
			UndoBuffer();
			Vector3D vector3D = null;
			Plane plane = new Plane(X: (Value == HorizontalVertical.Vertical) ? new Vector3D(MidPoint, new Point3D(MidPoint.X + 10.0, MidPoint.Y, MidPoint.Z)) : new Vector3D(MidPoint, new Point3D(MidPoint.X, MidPoint.Y + 10.0, MidPoint.Z)), P: MidPoint, Y: Vector3D.AxisZ);
			Mirror xform = new Mirror(plane);
			for (int i = 0; i <= clsItem.frmEditor.viewport.Entities.Count - 1; i++)
			{
				Entity entity = clsItem.frmEditor.viewport.Entities[i];
				if (entity.Selected)
				{
					entity.TransformBy(xform);
				}
			}
			clsItem.frmEditor.viewport.Entities.RegenAllCurved();
		}
		clsItem.frmEditor.viewport.Invalidate();
		Reset();
	}

	public void TurnOver()
	{
		clsInit.appEditor.UndoBuffer();
		Point3D MinPoint = new Point3D();
		Point3D MidPoint = new Point3D();
		Point3D MaxPoint = new Point3D();
		if (Sketcher2D.entitiesSelected.Count == 0)
		{
			clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, Clone: false, ref Sketcher2D.entitiesSelected);
		}
		clsInit.cVector5.BoxSizeCalculate(Sketcher2D.entitiesSelected, ref MinPoint, ref MidPoint, ref MaxPoint);
		if (Sketcher2D.entitiesSelected.Count <= 0)
		{
			return;
		}
		List<Entity> refEntities = new List<Entity>();
		for (int i = 0; i <= Sketcher2D.entitiesSelected.Count - 1; i++)
		{
			Entity copiedEntity = null;
			buEntity.Copy(Sketcher2D.entitiesSelected[i], ref copiedEntity);
			if (copiedEntity != null)
			{
				copiedEntity.ColorMethod = colorMethodType.byEntity;
				copiedEntity.Color = clsVar.varEditorSet.colorEntity;
				copiedEntity.LineWeight = (float)clsVar.varEditorSet.thicknessEntity;
				copiedEntity.LineWeightMethod = colorMethodType.byEntity;
				refEntities.Add(copiedEntity);
			}
		}
		clsInit.cVector5.Rotate(MidPoint, 180.0, Vector3D.AxisZ, ref refEntities);
		if (!clsVar.varEditorRuntimeSet.TurnOverCenter)
		{
			clsInit.cVector5.Move(MaxPoint.X - MinPoint.X + clsVar.varEditorRuntimeSet.TurnOverDistance, 0.0, 0.0, ref refEntities);
		}
		for (int j = 0; j <= refEntities.Count - 1; j++)
		{
			clsItem.frmEditor.viewport.Entities.Add(refEntities[j]);
		}
		clsItem.frmEditor.viewport.Entities.RegenAllCurved(0.01);
		Reset();
	}

	public bool EvaluateArc(Point2D p1, Point2D p2, Point2D p3, out bool flip)
	{
		Vector2D asVector = (p1 - p2).AsVector;
		Vector2D asVector2 = (p3 - p2).AsVector;
		flip = XyCross(asVector, asVector2) > 0.0;
		if (!(asVector2.Length < 1E-06))
		{
			asVector.Normalize();
			asVector2.Normalize();
			return !Vector2D.AreOpposite(asVector, asVector2);
		}
		return false;
	}

	public void AngleCalculation(ref Line L1, ref Line L2)
	{
		Tuple<Segment2D, Segment2D> segments = GetSegments(L1, L2);
		Segment2D segment2D = segments.Item1;
		Segment2D item = segments.Item2;
		if (!Segment2D.IntersectionLine(segment2D, item, out var _))
		{
			Point3D point3D = ((L1.StartPoint.DistanceTo(L2.StartPoint) >= L1.StartPoint.DistanceTo(L2.EndPoint)) ? ((Point3D)L2.EndPoint.Clone()) : ((Point3D)L2.StartPoint.Clone()));
			L1.StartPoint = point3D;
			clsItem.frmEditor.viewport.CurrentSketch.Move(clsItem.frmEditor.viewport.CurrentSketch.StartPoint(L1), point3D);
			segments = GetSegments(L1, L2);
			segment2D = segments.Item1;
			segment2D = segments.Item2;
		}
		_clock = new VectorClock(segment2D, item);
	}

	public Tuple<Segment2D, Segment2D> GetSegments(Line L1, Line L2)
	{
		return new Tuple<Segment2D, Segment2D>(new Segment2D(clsItem.frmEditor.viewport.CurrentSketch.Plane.Project(L1.StartPoint), clsItem.frmEditor.viewport.CurrentSketch.Plane.Project(L1.EndPoint)), new Segment2D(clsItem.frmEditor.viewport.CurrentSketch.Plane.Project(L2.StartPoint), clsItem.frmEditor.viewport.CurrentSketch.Plane.Project(L2.EndPoint)));
	}

	public void FilletChamferCalculation(bool isFillet)
	{
		ICurve c = (ICurve)Sketcher2D.entitiesSelected[0];
		ICurve c2 = (ICurve)Sketcher2D.entitiesSelected[1];
		Point3D[] source = Utility.Intersection(c, c2);
		Point3D point3D = source.LastOrDefault();
		if (!(point3D == null))
		{
			point3D.TransformBy(new Align3D(Plane.XY, clsItem.frmEditor.viewport.CurrentSketch.DrawingPlane));
			ComputeFilletsChamfers(isFillet, clsVar.varEditorRuntimeSet.FilletRadius, c, c2);
			List<Tuple<ICurve, ICurve, ICurve>> source2 = _filletsChamfers.Where((Tuple<ICurve, ICurve, ICurve> tuple_0) => tuple_0 != null && tuple_0.Item1 != null).ToList();
			if (source2.Any())
			{
				if (source2.Count() == 1)
				{
					_filletChamferIndex = _filletsChamfers.ToList().IndexOf(source2.First());
					AddFilletChamfer(isFillet, c, c2);
				}
			}
			else
			{
				buString5.MessageBoxWarning(AppLanguage.CadCamMessages[112]);
				Reset();
			}
		}
		else
		{
			buString5.MessageBoxWarning(AppLanguage.CadCamMessages[111]);
			if (clsItem.frmEditor != null)
			{
				clsItem.frmEditor.mnu_lib_Click(clsItem.frmEditor.mnu_libfillet, null);
			}
		}
	}

	public void ComputeFilletsChamfers(bool isFillet, double Radius, ICurve _c1, ICurve _c2)
	{
		for (int i = 0; i < 4; i++)
		{
			Entity entity = (Entity)((Entity)_c1).Clone();
			Entity entity2 = (Entity)((Entity)_c2).Clone();
			Tuple<bool, bool> tuple = Class5.smethod_138(i, this);
			if (!isFillet)
			{
				Curve.Chamfer((ICurve)entity, (ICurve)entity2, Radius, tuple.Item1, tuple.Item2, entity is Arc || entity is Line, entity2 is Arc || entity2 is Line, out var chamfer);
				if (chamfer != null && !(chamfer.Length() < 0.001))
				{
					chamfer.TransformBy(Transformation.CreateAlignment(clsItem.frmEditor.viewport.CurrentSketch.Plane, clsItem.frmEditor.viewport.CurrentSketch.DrawingPlane));
					entity.TransformBy(Transformation.CreateAlignment(clsItem.frmEditor.viewport.CurrentSketch.Plane, clsItem.frmEditor.viewport.CurrentSketch.DrawingPlane));
					entity2.TransformBy(Transformation.CreateAlignment(clsItem.frmEditor.viewport.CurrentSketch.Plane, clsItem.frmEditor.viewport.CurrentSketch.DrawingPlane));
					_filletsChamfers[i] = new Tuple<ICurve, ICurve, ICurve>(chamfer, (ICurve)entity, (ICurve)entity2);
				}
			}
			else
			{
				Curve.Fillet((ICurve)entity, (ICurve)entity2, Radius, tuple.Item1, tuple.Item2, entity is Arc || entity is Line, entity2 is Arc || entity2 is Line, out var fillet);
				if (fillet != null && !(fillet.AngleInRadians < 0.001))
				{
					fillet.TransformBy(Transformation.CreateAlignment(clsItem.frmEditor.viewport.CurrentSketch.Plane, clsItem.frmEditor.viewport.CurrentSketch.DrawingPlane));
					entity.TransformBy(Transformation.CreateAlignment(clsItem.frmEditor.viewport.CurrentSketch.Plane, clsItem.frmEditor.viewport.CurrentSketch.DrawingPlane));
					entity2.TransformBy(Transformation.CreateAlignment(clsItem.frmEditor.viewport.CurrentSketch.Plane, clsItem.frmEditor.viewport.CurrentSketch.DrawingPlane));
					_filletsChamfers[i] = new Tuple<ICurve, ICurve, ICurve>(fillet, (ICurve)entity, (ICurve)entity2);
				}
			}
		}
	}

	public void DrawPolygon(Point2D center, Point2D startPoint, ref LinearPath lp)
	{
		double num = center.DistanceTo(startPoint);
		if (!(num <= 0.0))
		{
			Circle circle = new Circle(clsItem.frmEditor.viewport.CurrentSketch.DrawingPlane, center, center.DistanceTo(startPoint));
			Point3D[] array = new Point3D[clsVar.varEditorRuntimeSet.PolygonSide + 1];
			for (int i = 0; i < clsVar.varEditorRuntimeSet.PolygonSide; i++)
			{
				array[i] = circle.PointAt(Math.PI * 2.0 * (double)i / (double)clsVar.varEditorRuntimeSet.PolygonSide);
			}
			array[clsVar.varEditorRuntimeSet.PolygonSide] = circle.PointAt(0.0);
			lp = new LinearPath(array);
			Vector2D asVector = (startPoint - center).AsVector;
			Vector2D asVector2 = (clsItem.frmEditor.viewport.CurrentSketch.DrawingPlane.Project(circle.StartPoint) - center).AsVector;
			asVector.Normalize();
			asVector2.Normalize();
			double angleInRadians = Vector2D.SignedAngleBetween(asVector2, asVector);
			lp.Rotate(angleInRadians, clsItem.frmEditor.viewport.CurrentSketch.DrawingPlane.AxisZ, circle.Center);
			lp.Regen(clsItem.frmEditor.viewport.GetVisualRefinement());
		}
	}

	public CompositeCurve ThreePointsSlot(Point2D start, Point2D end, Point2D radial)
	{
		try
		{
			double num = SlotRad(start, end, radial);
			Point2D.Distance(end, radial);
			start.DistanceTo(end);
			if (num <= 0.0)
			{
				num = 0.1;
			}
			return CompositeCurve.CreateSlot(Plane.XY, start.X, start.Y, start.DistanceTo(end), num, (end - start).AsVector.Angle);
		}
		catch (Exception)
		{
			return null;
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
		Point3D point3D = clsItem.frmEditor.viewport.CurrentSketch.DrawingPlane.PointAt(first.Position);
		Point3D point3D2 = clsItem.frmEditor.viewport.CurrentSketch.DrawingPlane.PointAt(second.Position);
		Vector3D asVector = (point3D2 - point3D).AsVector;
		Vector3D vector3D = Vector3D.Cross(clsItem.frmEditor.viewport.CurrentSketch.DrawingPlane.AxisZ, asVector);
		return Curve.LocalInterpolation(new PointTangent[3]
		{
			new PointTangent(point3D.X, point3D.Y, point3D.Z, asVector.X, asVector.Y, asVector.Z),
			new PointTangent(point3D2.X, point3D2.Y, point3D2.Z, vector3D.X, vector3D.Y, vector3D.Z),
			new PointTangent(point3D.X, point3D.Y, point3D.Z, 0.0 - asVector.X, 0.0 - asVector.Y, 0.0 - asVector.Z)
		});
	}

	public void ManuelSort(Point3D refPoint)
	{
		ManuelSortSetting.Option.Jump = false;
		ManuelSortSetting.Option.IntersectionRules = SortingIntersectionRulesType.Stop;
		ManuelSortSetting.Option.FirstRules = clsVar.varEditorSet.SortFirstCatchRule;
		if (clsVar.varEditorSet.SortFirstCatchRule != SortingFirstCatchRulesType.CW)
		{
			if (clsVar.varEditorSet.SortFirstCatchRule != SortingFirstCatchRulesType.CCW)
			{
				if (clsVar.varEditorSet.SortFirstCatchRule != SortingFirstCatchRulesType.LowerIndex)
				{
					if (clsVar.varEditorSet.SortFirstCatchRule != SortingFirstCatchRulesType.HigherIndex)
					{
						if (clsVar.varEditorSet.SortFirstCatchRule != SortingFirstCatchRulesType.Jump)
						{
							if (clsVar.varEditorSet.SortFirstCatchRule == SortingFirstCatchRulesType.Manuel)
							{
								ManuelSortSetting.Option.IntersectionRules = SortingIntersectionRulesType.Stop;
							}
						}
						else
						{
							ManuelSortSetting.Option.Jump = true;
						}
					}
					else
					{
						ManuelSortSetting.Option.IntersectionRules = SortingIntersectionRulesType.HigherIndex;
					}
				}
				else
				{
					ManuelSortSetting.Option.IntersectionRules = SortingIntersectionRulesType.LowerIndex;
				}
			}
			else
			{
				ManuelSortSetting.Option.IntersectionRules = SortingIntersectionRulesType.CCW;
			}
		}
		else
		{
			ManuelSortSetting.Option.IntersectionRules = SortingIntersectionRulesType.CW;
		}
		ManuelSortSetting.Option.refPlane = Plane.XY;
		clsInit.cVector5.SortEntitiesByClick(refPoint, ref sortRefEntities, ManuelSortSetting, ref sortedEntities, ref ManuelSortClickResult);
		if (sortedEntities.Count > 0)
		{
			Sketcher2D.OrthoPossible = true;
		}
	}

	public void ClearSortThings()
	{
		sortRefEntities.Clear();
		sortedEntities.Clear();
		ManuelSortClickResult.ResultType = SortingResultType.None;
		buVector5.PointClickData.FoundCount = 0;
		buVector5.PointClickData.SelectedIndex = -1;
		buVector5.PointClickData.isPointOnEntity = false;
		buVector5.PointClickData.CatchPoint = null;
		buVector5.PointClickData.PreCatchPoint = null;
	}

	public double XyCross(Vector2D vec1, Vector2D vec2)
	{
		return vec1.X * vec2.Y - vec1.Y * vec2.X;
	}

	public void UndoGetBack()
	{
		if (bufferedEntity.Count <= 0)
		{
			return;
		}
		clsItem.frmEditor.viewport.Entities.Clear();
		for (int i = 0; i <= bufferedEntity.Count - 1; i++)
		{
			for (int j = 0; j <= bufferedEntity[i].Count - 1; j++)
			{
				Entity copiedEntity = null;
				buEntity.Copy(bufferedEntity[i][j], ref copiedEntity);
				if (copiedEntity != null)
				{
					clsItem.frmEditor.viewport.Entities.Add(copiedEntity);
				}
			}
		}
		clsItem.frmEditor.viewport.Entities.RegenAllCurved();
		clsItem.frmEditor.viewport.Invalidate();
		bufferedEntity.RemoveAt(bufferedEntity.Count - 1);
	}

	public void UndoBuffer()
	{
		if (bufferedEntity.Count > 100)
		{
			bufferedEntity.RemoveAt(bufferedEntity.Count - 1);
		}
		List<Entity> list = new List<Entity>();
		for (int i = 0; i <= clsItem.frmEditor.viewport.Entities.Count - 1; i++)
		{
			Entity copiedEntity = null;
			buEntity.Copy(clsItem.frmEditor.viewport.Entities[i], ref copiedEntity);
			if (copiedEntity != null)
			{
				list.Add(copiedEntity);
			}
		}
		bufferedEntity.Add(list);
	}

	public void JobTree_AfterSelect(object sender, TreeViewEventArgs e)
	{
		TreeView treeView = (TreeView)sender;
		TreeNodeSettings treeNodeSettings = (TreeNodeSettings)treeView.SelectedNode;
		switch (treeNodeSettings.Command)
		{
		case "drawbase":
			SelectedConstraint = -1;
			SelectedDrawing = -1;
			break;
		case "draw":
			SelectedConstraint = -1;
			SelectedDrawing = treeNodeSettings.ClassSubIndex;
			break;
		case "Constraintbase":
			SelectedConstraint = -1;
			SelectedDrawing = -1;
			break;
		case "Constraints":
			SelectedDrawing = -1;
			SelectedConstraint = treeNodeSettings.ClassSubIndex;
			break;
		}
		clsItem.frmEditor.viewport.Entities.ClearSelection();
		if (SelectedConstraint >= 0)
		{
			VisualConstraint visualConstraint = clsItem.frmEditor.viewport.CurrentSketch.Constraints[SelectedConstraint];
			if (visualConstraint.ConstraintDimension != null)
			{
				visualConstraint.ConstraintDimension.Selected = true;
			}
			UpdateCommandInfo(new EditorCustomData());
		}
		clsItem.frmEditor.lst_command.Items.Clear();
		if (SelectedDrawing >= 0)
		{
			clsItem.frmEditor.viewport.Entities[SelectedDrawing].Selected = true;
			if (clsItem.frmEditor.viewport.Entities[SelectedDrawing].EntityData != null && clsItem.frmEditor.viewport.Entities[SelectedDrawing].EntityData is EditorCustomData)
			{
				EditorCustomData cD = clsItem.frmEditor.viewport.Entities[SelectedDrawing].EntityData as EditorCustomData;
				UpdateCommandInfo(cD);
			}
		}
		clsItem.frmEditor.viewport.Invalidate();
	}

	public void JobUpdate()
	{
		clsItem.frmEditor.tree_objects.Nodes.Clear();
		TreeNodeSettings treeNodeSettings = new TreeNodeSettings("Draw")
		{
			ImageIndex = 0,
			SelectedImageIndex = 0,
			Tag = "-1",
			ClassIndex = 0,
			ClassSubIndex = -1,
			ClassSubSubIndex = -1,
			Command = "drawbase",
			Name = "draw",
			Info = "draw",
			Index = 0,
			Checked = false
		};
		for (int i = 0; i <= clsItem.frmEditor.viewport.Entities.Count - 1; i++)
		{
			bool flag = false;
			TreeNodeSettings treeNodeSettings2 = new TreeNodeSettings("Draw")
			{
				Tag = "-1",
				ClassIndex = 0,
				ClassSubIndex = i,
				ClassSubSubIndex = -1,
				Command = "draw",
				Name = "draw" + i,
				Info = "draw" + i,
				Index = 0,
				Checked = false
			};
			if (!((clsItem.frmEditor.viewport.Entities[i].GetType() == typeof(devDept.Eyeshot.Entities.Point)) & clsVar.varEditorSet.ShowPointsAtDrawingTreeItem))
			{
				if (!(clsItem.frmEditor.viewport.Entities[i].GetType() == typeof(Line)))
				{
					if (!(clsItem.frmEditor.viewport.Entities[i].GetType() == typeof(Arc)))
					{
						if (!(clsItem.frmEditor.viewport.Entities[i].GetType() == typeof(Circle)))
						{
							if (!(clsItem.frmEditor.viewport.Entities[i].GetType() == typeof(Ellipse)))
							{
								if (clsItem.frmEditor.viewport.Entities[i].GetType() == typeof(Curve))
								{
									treeNodeSettings2.ImageIndex = 6;
									treeNodeSettings2.SelectedImageIndex = 6;
									treeNodeSettings2.Text = AppLanguage.CadCamDynamic[66];
									flag = true;
								}
							}
							else
							{
								treeNodeSettings2.ImageIndex = 5;
								treeNodeSettings2.SelectedImageIndex = 5;
								treeNodeSettings2.Text = AppLanguage.CadCamDynamic[54];
								flag = true;
							}
						}
						else
						{
							treeNodeSettings2.ImageIndex = 3;
							treeNodeSettings2.SelectedImageIndex = 3;
							treeNodeSettings2.Text = AppLanguage.CadCamDynamic[51];
							flag = true;
						}
					}
					else
					{
						treeNodeSettings2.ImageIndex = 4;
						treeNodeSettings2.SelectedImageIndex = 4;
						treeNodeSettings2.Text = AppLanguage.CadCamDynamic[49];
						flag = true;
					}
				}
				else
				{
					treeNodeSettings2.ImageIndex = 2;
					treeNodeSettings2.SelectedImageIndex = 2;
					treeNodeSettings2.Text = AppLanguage.CadCamDynamic[44];
					flag = true;
				}
			}
			else
			{
				treeNodeSettings2.ImageIndex = 1;
				treeNodeSettings2.SelectedImageIndex = 1;
				treeNodeSettings2.Text = AppLanguage.CadCamDynamic[48];
				flag = true;
			}
			if (flag)
			{
				treeNodeSettings.Nodes.Add(treeNodeSettings2);
			}
		}
		TreeNodeSettings treeNodeSettings3 = new TreeNodeSettings("Constraint")
		{
			ImageIndex = 13,
			SelectedImageIndex = 13,
			Tag = "-1",
			ClassIndex = 1,
			ClassSubIndex = -1,
			ClassSubSubIndex = -1,
			Command = "Constraintbase",
			Name = "Constraint",
			Info = "Constraint",
			Index = 0,
			Checked = false
		};
		for (int j = 0; j <= clsItem.frmEditor.viewport.Entities.Count - 1; j++)
		{
			if (!(clsItem.frmEditor.viewport.Entities[j] is SketchEntity))
			{
				continue;
			}
			SketchEntity sketchEntity = clsItem.frmEditor.viewport.Entities[j] as SketchEntity;
			for (int k = 0; k <= sketchEntity.Constraints.Count - 1; k++)
			{
				bool flag2 = false;
				TreeNodeSettings treeNodeSettings4 = new TreeNodeSettings("Constraints")
				{
					Tag = "-1",
					ClassIndex = 1,
					ClassSubIndex = k,
					ClassSubSubIndex = -1,
					Command = "Constraints",
					Name = "draw" + k,
					Info = "draw" + k,
					Index = 0,
					Checked = false
				};
				if (sketchEntity.Constraints[k].GetType() == typeof(HvVisualConstraint))
				{
					if (((HVConstraint)sketchEntity.Constraints[k].GConstraint).IsHorizontal)
					{
						treeNodeSettings4.ImageIndex = 15;
						treeNodeSettings4.SelectedImageIndex = 15;
						treeNodeSettings4.Text = AppLanguage.CadCamDynamic[136];
						flag2 = true;
					}
					if (!((HVConstraint)sketchEntity.Constraints[k].GConstraint).IsHorizontal)
					{
						treeNodeSettings4.ImageIndex = 26;
						treeNodeSettings4.SelectedImageIndex = 26;
						treeNodeSettings4.Text = AppLanguage.CadCamDynamic[137];
						flag2 = true;
					}
				}
				if (sketchEntity.Constraints[k].GetType() == typeof(AngleVisualConstraint))
				{
					treeNodeSettings4.ImageIndex = 8;
					treeNodeSettings4.SelectedImageIndex = 8;
					treeNodeSettings4.Text = AppLanguage.CadCamDynamic[2];
					flag2 = true;
				}
				if (sketchEntity.Constraints[k].GetType() == typeof(CoincidentVisualConstraint))
				{
					treeNodeSettings4.ImageIndex = 27;
					treeNodeSettings4.SelectedImageIndex = 27;
					treeNodeSettings4.Text = AppLanguage.CadCamDynamic[138];
					flag2 = true;
				}
				if (sketchEntity.Constraints[k].GetType() == typeof(CollinearPointsVisualConstraint))
				{
					treeNodeSettings4.ImageIndex = 10;
					treeNodeSettings4.SelectedImageIndex = 10;
					treeNodeSettings4.Text = AppLanguage.CadCamDynamic[0];
					flag2 = true;
				}
				if (sketchEntity.Constraints[k].GetType() == typeof(CollinearVisualConstraint))
				{
					treeNodeSettings4.ImageIndex = 10;
					treeNodeSettings4.SelectedImageIndex = 10;
					treeNodeSettings4.Text = AppLanguage.CadCamDynamic[0];
					flag2 = true;
				}
				if (sketchEntity.Constraints[k].GetType() == typeof(ConcentricCirclesDistanceVisualConstraint))
				{
					treeNodeSettings4.ImageIndex = 31;
					treeNodeSettings4.SelectedImageIndex = 31;
					treeNodeSettings4.Text = AppLanguage.CadCamDynamic[0];
					flag2 = true;
				}
				if (sketchEntity.Constraints[k].GetType() == typeof(DiameterVisualConstraint))
				{
					treeNodeSettings4.ImageIndex = 24;
					treeNodeSettings4.SelectedImageIndex = 24;
					treeNodeSettings4.Text = AppLanguage.CadCamDynamic[57];
					flag2 = true;
				}
				if (sketchEntity.Constraints[k].GetType() == typeof(EqualVisualConstraint))
				{
					if (!((EqualConstraint)sketchEntity.Constraints[k].GConstraint).IsEqualLength())
					{
						treeNodeSettings4.ImageIndex = 12;
						treeNodeSettings4.SelectedImageIndex = 12;
						treeNodeSettings4.Text = AppLanguage.CadCamDynamic[140] + " " + AppLanguage.CadCamDynamic[19];
					}
					else
					{
						treeNodeSettings4.ImageIndex = 11;
						treeNodeSettings4.SelectedImageIndex = 11;
						treeNodeSettings4.Text = AppLanguage.CadCamDynamic[140] + " " + AppLanguage.CadCamDynamic[0];
					}
					flag2 = true;
				}
				if (sketchEntity.Constraints[k].GetType() == typeof(LengthVisualConstraint))
				{
					treeNodeSettings4.ImageIndex = 16;
					treeNodeSettings4.SelectedImageIndex = 16;
					treeNodeSettings4.Text = AppLanguage.CadCamDynamic[0];
					flag2 = true;
				}
				if (sketchEntity.Constraints[k].GetType() == typeof(LinesDistanceVisualConstraint))
				{
					treeNodeSettings4.ImageIndex = 17;
					treeNodeSettings4.SelectedImageIndex = 17;
					treeNodeSettings4.Text = AppLanguage.CadCamDynamic[44] + " " + AppLanguage.CadCamDynamic[44];
					flag2 = true;
				}
				if (sketchEntity.Constraints[k].GetType() == typeof(MidPointVisualConstraint))
				{
					treeNodeSettings4.ImageIndex = 28;
					treeNodeSettings4.SelectedImageIndex = 28;
					treeNodeSettings4.Text = AppLanguage.CadCamDynamic[141] + " " + AppLanguage.CadCamDynamic[48];
					flag2 = true;
				}
				if (sketchEntity.Constraints[k].GetType() == typeof(MirrorVisualConstraint))
				{
					treeNodeSettings4.ImageIndex = 19;
					treeNodeSettings4.SelectedImageIndex = 19;
					treeNodeSettings4.Text = AppLanguage.CadCamDynamic[142];
					flag2 = true;
				}
				if (sketchEntity.Constraints[k].GetType() == typeof(ParallelLinesVisualConstraint))
				{
					treeNodeSettings4.ImageIndex = 21;
					treeNodeSettings4.SelectedImageIndex = 21;
					treeNodeSettings4.Text = AppLanguage.CadCamDynamic[143];
					flag2 = true;
				}
				if (sketchEntity.Constraints[k].GetType() == typeof(PerpendicularVisualConstraint))
				{
					treeNodeSettings4.ImageIndex = 22;
					treeNodeSettings4.SelectedImageIndex = 22;
					treeNodeSettings4.Text = AppLanguage.CadCamDynamic[144];
					flag2 = true;
				}
				if (sketchEntity.Constraints[k].GetType() == typeof(PointAtVisualConstraint))
				{
					treeNodeSettings4.ImageIndex = 32;
					treeNodeSettings4.SelectedImageIndex = 32;
					treeNodeSettings4.Text = AppLanguage.CadCamDynamic[147];
					flag2 = true;
				}
				if (sketchEntity.Constraints[k].GetType() == typeof(PointFixedVisualConstraint))
				{
					treeNodeSettings4.ImageIndex = 14;
					treeNodeSettings4.SelectedImageIndex = 14;
					treeNodeSettings4.Text = AppLanguage.CadCamDynamic[146] + " " + AppLanguage.CadCamDynamic[48];
					flag2 = true;
				}
				if (sketchEntity.Constraints[k].GetType() == typeof(PointLineDistanceVisualConstraint))
				{
					treeNodeSettings4.ImageIndex = 18;
					treeNodeSettings4.SelectedImageIndex = 18;
					treeNodeSettings4.Text = AppLanguage.CadCamDynamic[48] + " " + AppLanguage.CadCamDynamic[44];
					flag2 = true;
				}
				if (sketchEntity.Constraints[k].GetType() == typeof(PointOnVisualConstraint))
				{
					treeNodeSettings4.ImageIndex = 32;
					treeNodeSettings4.SelectedImageIndex = 32;
					treeNodeSettings4.Text = AppLanguage.CadCamDynamic[148];
					flag2 = true;
				}
				if (sketchEntity.Constraints[k].GetType() == typeof(PointsDistanceVisualConstraint))
				{
					treeNodeSettings4.ImageIndex = 23;
					treeNodeSettings4.SelectedImageIndex = 23;
					treeNodeSettings4.Text = AppLanguage.CadCamDynamic[48] + " " + AppLanguage.CadCamDynamic[48];
					flag2 = true;
				}
				if (sketchEntity.Constraints[k].GetType() == typeof(PolygonVisualConstraint))
				{
					treeNodeSettings4.ImageIndex = 29;
					treeNodeSettings4.SelectedImageIndex = 29;
					treeNodeSettings4.Text = AppLanguage.CadCamDynamic[70];
					flag2 = true;
				}
				if (sketchEntity.Constraints[k].GetType() == typeof(TangentVisualConstraint))
				{
					treeNodeSettings4.ImageIndex = 25;
					treeNodeSettings4.SelectedImageIndex = 25;
					treeNodeSettings4.Text = AppLanguage.CadCamDynamic[145];
					flag2 = true;
				}
				if (sketchEntity.Constraints[k].GetType() == typeof(ValueVisualConstraint))
				{
					treeNodeSettings4.ImageIndex = 30;
					treeNodeSettings4.SelectedImageIndex = 30;
					treeNodeSettings4.Text = AppLanguage.CadCamDynamic[4];
					flag2 = true;
				}
				if (flag2)
				{
					treeNodeSettings3.Nodes.Add(treeNodeSettings4);
				}
			}
		}
		clsItem.frmEditor.tree_objects.Nodes.Add(treeNodeSettings);
		if (clsVar.varEditorSet.ShowConstraintTreeItem)
		{
			clsItem.frmEditor.tree_objects.Nodes.Add(treeNodeSettings3);
		}
		if (clsVar.varEditorSet.ExpandDrawingTree)
		{
			clsItem.frmEditor.tree_objects.Nodes[0].ExpandAll();
		}
		if (clsVar.varEditorSet.ExpandConstraintTree & (clsItem.frmEditor.tree_objects.Nodes.Count >= 2))
		{
			clsItem.frmEditor.tree_objects.Nodes[1].ExpandAll();
		}
	}

	public void UpdateCommandInfo(EditorCustomData CD)
	{
		clsItem.frmEditor.lst_command.Items.Clear();
		for (int i = 0; i <= CD.Commands.Count - 1; i++)
		{
			clsItem.frmEditor.lst_command.Items.Add(CD.Commands[i]);
		}
	}

	public void AddCommandToDrawing(string Command, int indexDrawing)
	{
		if (clsItem.frmEditor.viewport.ActionMode != actionType.SelectByBox)
		{
			if (indexDrawing >= 0)
			{
				if (clsItem.frmEditor.viewport.Entities[indexDrawing].EntityData == null)
				{
					EditorCustomData editorCustomData = new EditorCustomData();
					editorCustomData.Commands.Add(Command);
					clsItem.frmEditor.viewport.Entities[indexDrawing].EntityData = editorCustomData;
					UpdateCommandInfo(editorCustomData);
				}
				else if (!(clsItem.frmEditor.viewport.Entities[indexDrawing].EntityData is EditorCustomData))
				{
					EditorCustomData editorCustomData2 = new EditorCustomData();
					editorCustomData2.Commands.Add(Command);
					clsItem.frmEditor.viewport.Entities[indexDrawing].EntityData = editorCustomData2;
					UpdateCommandInfo(editorCustomData2);
				}
				else
				{
					EditorCustomData editorCustomData3 = clsItem.frmEditor.viewport.Entities[indexDrawing].EntityData as EditorCustomData;
					editorCustomData3.Commands.Add(Command);
					UpdateCommandInfo(editorCustomData3);
				}
			}
			return;
		}
		for (int i = 0; i <= clsItem.frmEditor.viewport.Entities.Count - 1; i++)
		{
			if (clsItem.frmEditor.viewport.Entities[i].Selected & (clsItem.frmEditor.viewport.Entities[i] is ICurve) & (clsItem.frmEditor.viewport.Entities[i].GetType() != typeof(devDept.Eyeshot.Entities.Point)))
			{
				if (clsItem.frmEditor.viewport.Entities[i].EntityData == null)
				{
					EditorCustomData editorCustomData4 = new EditorCustomData();
					editorCustomData4.Commands.Add(Command);
					clsItem.frmEditor.viewport.Entities[i].EntityData = editorCustomData4;
					UpdateCommandInfo(editorCustomData4);
				}
				else if (!(clsItem.frmEditor.viewport.Entities[i].EntityData is EditorCustomData))
				{
					EditorCustomData editorCustomData5 = new EditorCustomData();
					editorCustomData5.Commands.Add(Command);
					clsItem.frmEditor.viewport.Entities[i].EntityData = editorCustomData5;
					UpdateCommandInfo(editorCustomData5);
				}
				else
				{
					EditorCustomData editorCustomData6 = clsItem.frmEditor.viewport.Entities[i].EntityData as EditorCustomData;
					editorCustomData6.Commands.Add(Command);
					UpdateCommandInfo(editorCustomData6);
				}
			}
		}
		JobUpdate();
	}

	public void RemoveCommandFromDrawing(int indexCommand, int indexDrawing)
	{
		if (indexDrawing >= 0 && indexCommand >= 0 && clsItem.frmEditor.viewport.Entities[indexDrawing].EntityData != null && clsItem.frmEditor.viewport.Entities[indexDrawing].EntityData is EditorCustomData)
		{
			EditorCustomData editorCustomData = clsItem.frmEditor.viewport.Entities[indexDrawing].EntityData as EditorCustomData;
			editorCustomData.Commands.RemoveAt(indexCommand);
			UpdateCommandInfo(editorCustomData);
		}
	}

	public void FileOpened()
	{
		if (clsItem.frmEditor.viewport.Entities.Count > 0)
		{
			if (clsItem.frmEditor.viewport.Entities[0] is SketchEntity)
			{
				SketchEntity sketchEntity = clsItem.frmEditor.viewport.Entities[0] as SketchEntity;
				if (OpenCustomData.Count > 0)
				{
					for (int i = 0; i <= OpenCustomData.Count - 1; i++)
					{
						if ((OpenCustomData[i].EntityIndex >= 0) & (OpenCustomData[i].EntityIndex <= sketchEntity.CurveList.Count - 1))
						{
							((Entity)sketchEntity.CurveList[OpenCustomData[i].EntityIndex]).EntityData = OpenCustomData[i];
						}
					}
				}
				sketchEntity.Edit(clsItem.frmEditor.viewport);
				clsItem.frmEditor.viewport.CurrentSketch.UpdateAndInvalidate();
			}
			Class5.smethod_48(this);
			Class5.smethod_60(this);
			JobUpdate();
		}
		DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.Base + "\\L");
		if (directoryInfo.Exists)
		{
			directoryInfo.Delete(recursive: true);
		}
	}

	public void OpenEditorCustomDataToFile(string filename, ref List<EditorCustomData> CDs)
	{
		List<string> StringList = new List<string>();
		CDs = new List<EditorCustomData>();
		buFile5.OpenFromFile(filename, ref StringList);
		for (int i = 0; i <= StringList.Count - 1; i++)
		{
			string[] array = StringList[i].Split('|');
			if (array == null || array.Length != 2)
			{
				continue;
			}
			string[] array2 = array[1].Split(';');
			if (array2 == null)
			{
				continue;
			}
			EditorCustomData editorCustomData = new EditorCustomData();
			editorCustomData.EntityIndex = int.Parse(array[0]);
			if (array2.Length != 0)
			{
				for (int j = 0; j <= array2.Length - 1; j++)
				{
					if (array2[j].Trim().Length > 0)
					{
						editorCustomData.Commands.Add(array2[j].Trim());
					}
				}
			}
			CDs.Add(editorCustomData);
		}
	}

	public void SaveEditorCustomDataToFile(Design Viewport, string filename)
	{
		List<string> list = new List<string>();
		for (int i = 0; i <= Viewport.Entities.Count - 1; i++)
		{
			if (!(Viewport.Entities[i] is SketchEntity))
			{
				continue;
			}
			SketchEntity sketchEntity = Viewport.Entities[i] as SketchEntity;
			for (int j = 0; j <= sketchEntity.CurveList.Count - 1; j++)
			{
				if (!(((Entity)sketchEntity.CurveList[j]).EntityData is EditorCustomData))
				{
					continue;
				}
				EditorCustomData editorCustomData = ((Entity)sketchEntity.CurveList[j]).EntityData as EditorCustomData;
				editorCustomData.EntityIndex = j;
				if (editorCustomData.EntityIndex < 0 || editorCustomData.Commands.Count <= 0)
				{
					continue;
				}
				string text = editorCustomData.EntityIndex + " | ";
				string text2 = "";
				for (int k = 0; k <= editorCustomData.Commands.Count - 1; k++)
				{
					if (k > 0)
					{
						text2 = ";";
					}
					text = text + text2 + editorCustomData.Commands[k];
				}
				list.Add(text);
			}
		}
		buFile5.SaveToFile(list, filename);
	}

	public void SaveLibraryToZip()
	{
		if (FIZip != null)
		{
			DirectoryInfo directoryInfo = null;
			FileInfo fileInfo = new FileInfo(FIZip.FullName);
			string fileNameWithoutExtension = buFile5.getFileNameWithoutExtension(FIZip.FullName);
			directoryInfo = new DirectoryInfo(fileInfo.DirectoryName + "\\" + fileNameWithoutExtension);
			if (directoryInfo.Exists)
			{
				buFile5.ZipFolderToFile(directoryInfo.FullName, FIZip.FullName);
				directoryInfo.Delete(recursive: true);
			}
		}
	}

	public void AnalyseSketchEntity(List<buEntity> SketchEntites, SketchAnalyseSetData SetData, ref SketchAnalyseData AnalyseData)
	{
		AnalyseData = new SketchAnalyseData();
		List<buEntity> BaseRefEntities = new List<buEntity>();
		bool flag = false;
		List<double> RefList = new List<double>();
		for (int i = 0; i <= SketchEntites.Count - 1; i++)
		{
			buEntity copiedEntity = null;
			bool flag2 = true;
			if (SketchEntites[i].Info.Commands != null)
			{
				for (int j = 0; j <= SketchEntites[i].Info.Commands.Count - 1; j++)
				{
					if (SketchEntites[i].Info.Commands[j].Trim() == "NoCalculationEntity")
					{
						flag2 = false;
					}
					if (SketchEntites[i].Info.Commands[j].Trim() == "SecondDrawing")
					{
						flag = true;
					}
					if (SketchEntites[i].Info.Commands[j].Trim().IndexOf(buLangTranslate.preDef.Depth) < 0)
					{
						continue;
					}
					string[] array = SketchEntites[i].Info.Commands[j].Split('=');
					if (array != null && array.Length != 0 && array.Length == 2)
					{
						double result = 0.0;
						if (double.TryParse(array[1], out result) && !buNumeric5.isValueAvailableInList(RefList, result))
						{
							RefList.Add(result);
						}
					}
				}
			}
			if (flag2 && SketchEntites[i].GetType() != typeof(buPoint))
			{
				buEntity.Copy(SketchEntites[i], ref copiedEntity);
				BaseRefEntities.Add(copiedEntity);
			}
		}
		if (RefList.Count > 0)
		{
			buNumeric5.SortList(SortDirectionType.Lower, ref RefList);
		}
		List<buEntity> SortedEntities = new List<buEntity>();
		List<List<buEntity>> SplitedEntitites = new List<List<buEntity>>();
		SortbuSettings settings = new SortbuSettings();
		clsInit.cVector5.SortEntitiesByRefPoint(BaseRefEntities[0].StartPoint, ref BaseRefEntities, settings, ref SortedEntities);
		clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites);
		for (int k = 0; k <= SplitedEntitites.Count - 1; k++)
		{
			buCompositeCurve calcCompositeCurve = null;
			clsInit.cVector5.CreateCompositeCurveFromEntitiesWithCamDirection(SplitedEntitites[k], ref calcCompositeCurve);
			if (SplitedEntitites[k].Count > 0 && SplitedEntitites[k][0].Info.Commands != null)
			{
				calcCompositeCurve.Info.Commands = new List<string>();
				calcCompositeCurve.Info.Commands.AddRange(SplitedEntitites[k][0].Info.Commands);
			}
			AnalyseData.AnalyseEntities.Add(calcCompositeCurve);
		}
		Point3D MinPoint = new Point3D();
		Point3D MaxPoint = new Point3D();
		clsInit.cVector5.BoxSizeCalculate(AnalyseData.AnalyseEntities, ref MinPoint, ref MaxPoint);
		if (AnalyseData.AnalyseEntities.Count <= 1)
		{
			return;
		}
		int num = -1;
		for (int l = 0; l <= AnalyseData.AnalyseEntities.Count - 1; l++)
		{
			if (clsInit.cVector5.isBoxSizeInsideBoxSize(MinPoint, MaxPoint, AnalyseData.AnalyseEntities[l].BoxMin, AnalyseData.AnalyseEntities[l].BoxMax, Plane.XY))
			{
				double num2 = clsInit.cVector5.Length3D(MinPoint, AnalyseData.AnalyseEntities[l].BoxMin, Plane.XY);
				double num3 = clsInit.cVector5.Length3D(MaxPoint, AnalyseData.AnalyseEntities[l].BoxMax, Plane.XY);
				if (num2 < 1.0 || num3 < 1.0)
				{
					num = l;
				}
			}
			else
			{
				num = l;
			}
		}
		if (num >= 0)
		{
			List<buEntity> list = new List<buEntity>();
			List<buEntity> list2 = new List<buEntity>();
			list.Add(buEntity.Copy(AnalyseData.AnalyseEntities[num]));
			for (int m = 0; m <= num - 1; m++)
			{
				list2.Add(buEntity.Copy(AnalyseData.AnalyseEntities[m]));
			}
			for (int n = num + 1; n <= AnalyseData.AnalyseEntities.Count - 1; n++)
			{
				list2.Add(buEntity.Copy(AnalyseData.AnalyseEntities[n]));
			}
			AnalyseData.AnalyseEntities = new List<buEntity>();
			AnalyseData.AnalyseEntities.Add(list[0]);
			for (int num4 = 0; num4 <= list2.Count - 1; num4++)
			{
				AnalyseData.AnalyseEntities.Add(list2[num4]);
			}
		}
		if (!flag)
		{
			return;
		}
		if (RefList.Count <= 0)
		{
			for (int num5 = 0; num5 <= AnalyseData.AnalyseEntities.Count - 1; num5++)
			{
				AnalyseData.DepthLevel.Add(SetData.DefaultDepth);
			}
		}
		else
		{
			for (int num6 = 0; num6 <= RefList.Count - 1; num6++)
			{
				AnalyseData.DepthLevel.Add(RefList[num6]);
			}
		}
	}

	public void SaveEditorFile()
	{
		try
		{
			string fileName = AppPath.Settings + "\\Editor.prm";
			ArrayList arrayList = new ArrayList();
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Editor Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("<clsVar.varEditorSet>");
			arrayList.AddRange(clsVar.varEditorSet.ToDefAll("", 2, SerilizationMode5.MultiLine));
			arrayList.Add("</clsVar.varEditorSet>");
			arrayList.Add("<clsVar.varEditorRuntimeSet>");
			arrayList.AddRange(clsVar.varEditorRuntimeSet.ToDefAll("", 2, SerilizationMode5.MultiLine));
			arrayList.Add("</clsVar.varEditorRuntimeSet>");
			buFile.SaveToFile(arrayList, fileName);
			buLog.addLog("Editor Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void OpenEditorFile()
	{
		try
		{
			ArrayList arrayList = new ArrayList();
			string fileName = AppPath.Settings + "\\Editor.prm";
			FileInfo fileInfo = new FileInfo(fileName);
			if (!fileInfo.Exists)
			{
				if (clsVar.appModes_0.LaserRouterDiamekerMode.Enable)
				{
					buLog.addLog("Editor  Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buString.MessageBoxError("Door Settings File Missing");
				}
			}
			else
			{
				arrayList = new ArrayList();
				buFile.OpenFromFile(fileInfo.FullName, ref arrayList);
				try
				{
					ArrayList CalcList = new ArrayList();
					buString.ListToSpecificList("<clsVar.varEditorSet>", "</clsVar.varEditorSet>", AddStartEndKey: true, arrayList, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, clsVar.varEditorSet);
						buLog.addLog("clsVar.varEditorSet Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
					}
					CalcList = new ArrayList();
					buString.ListToSpecificList("<clsVar.varEditorRuntimeSet>", "</clsVar.varEditorRuntimeSet>", AddStartEndKey: true, arrayList, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, clsVar.varEditorRuntimeSet);
						buLog.addLog("clsVar.varEditorRuntimeSet Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
					}
				}
				catch (Exception mSException)
				{
					buLog.addLog("Editor Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Editor Settings Decoder Error");
				}
			}
			buLog.addLog("Editor Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
		}
		catch (Exception mSException2)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException2, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void OpenSortedEntities(string FileName, ref List<Entity> EyeEntities, ref List<buEntity> DrawEntities, ref List<buEntity> SortedEntities)
	{
		ArrayList StringList = new ArrayList();
		List<string> CalcList = new List<string>();
		List<List<string>> CalcList2 = new List<List<string>>();
		buFile5.OpenFromFile(FileName, ref StringList);
		buString5.ListToSpecificList("<DrawEntities>", "</DrawEntities>", AddStartEndKey: false, StringList, ref CalcList);
		buStatics.ListToSpecificList("<buEntity>", "</buEntity>", AddStartEndKey: false, CalcList, ref CalcList2);
		if (CalcList2.Count > 0)
		{
			EyeEntities = new List<Entity>();
			DrawEntities = new List<buEntity>();
			for (int i = 0; i <= CalcList2.Count - 1; i++)
			{
				buEntity buEntity2 = buEntity.Decode(CalcList2[i]);
				if (buEntity2 != null)
				{
					DrawEntities.Add(buEntity2);
					Entity copiedEntity = null;
					buEntity.Copy(buEntity2, ref copiedEntity);
					if (copiedEntity != null)
					{
						EyeEntities.Add(copiedEntity);
					}
				}
			}
		}
		CalcList = new List<string>();
		CalcList2 = new List<List<string>>();
		buString5.ListToSpecificList("<SortEntities>", "</SortEntities>", AddStartEndKey: false, StringList, ref CalcList);
		buStatics.ListToSpecificList("<buEntity>", "</buEntity>", AddStartEndKey: false, CalcList, ref CalcList2);
		if (CalcList2.Count <= 0)
		{
			return;
		}
		SortedEntities = new List<buEntity>();
		for (int j = 0; j <= CalcList2.Count - 1; j++)
		{
			buEntity buEntity3 = buEntity.Decode(CalcList2[j]);
			if (buEntity3 != null)
			{
				SortedEntities.Add(buEntity3);
			}
		}
	}

	public void OpenSortedEntities(string FileName, ref List<Entity> EyeEntities, ref List<buEntity> SortedEntities)
	{
		List<buEntity> DrawEntities = new List<buEntity>();
		OpenSortedEntities(FileName, ref EyeEntities, ref DrawEntities, ref SortedEntities);
	}

	public void OpenSortedEntities(string FileName, ref List<buEntity> DrawEntities, ref List<buEntity> SortedEntities)
	{
		List<Entity> EyeEntities = new List<Entity>();
		OpenSortedEntities(FileName, ref EyeEntities, ref DrawEntities, ref SortedEntities);
	}

	public void SaveSortedEntities(string FileName)
	{
		int num = 2;
		ArrayList arrayList = new ArrayList();
		List<buEntity> list = new List<buEntity>();
		for (int i = 0; i <= clsItem.frmEditor.viewport.Entities.Count - 1; i++)
		{
			buEntity copiedEntity = null;
			buEntity.Copy(clsItem.frmEditor.viewport.Entities[i], ref copiedEntity);
			if (copiedEntity != null)
			{
				list.Add(copiedEntity);
			}
		}
		arrayList.Add(buString5.SpaceChar(num + 2) + "<DrawEntities>");
		arrayList.AddRange(buEntity.ToDefEntity(list, num + 4));
		arrayList.Add(buString5.SpaceChar(num + 2) + "</DrawEntities>");
		arrayList.Add(buString5.SpaceChar(num + 2) + "<SortEntities>");
		arrayList.AddRange(buEntity.ToDefEntity(sortedEntities, num + 4));
		arrayList.Add(buString5.SpaceChar(num + 2) + "</SortEntities>");
		arrayList.Add(buString5.SpaceChar(num + 2) + "<ManuelSortClickResult>");
		ManuelSortClickResult.ToDefAll("", num + 4);
		arrayList.Add(buString5.SpaceChar(num + 2) + "</ManuelSortClickResult>");
		buFile5.SaveToFile(arrayList, FileName);
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
				{
					clsInit.appSewing.JobUpdate();
				}
				clsInit.appSewing.frmMove.Visible = false;
			}
			if (clsInit.appSewing.frmRotate != null)
			{
				if (clsInit.appSewing.frmRotate.Visible)
				{
					clsInit.appSewing.JobUpdate();
				}
				clsInit.appSewing.frmRotate.Visible = false;
			}
			if (clsInit.appSewing.frmSelectVertex != null)
			{
				if (clsInit.appSewing.frmSelectVertex.Visible)
				{
					clsInit.appSewing.JobUpdate();
				}
				clsInit.appSewing.frmSelectVertex.Visible = false;
			}
			if (clsVar.varEditorRuntimeSet.isSewingMode)
			{
				for (int i = 0; i <= clsItem.frmEditor.viewport.Entities.Count - 1; i++)
				{
					if (clsItem.frmEditor.viewport.Entities[i] is Joint)
					{
						clsItem.frmEditor.viewport.Entities[i].Visible = true;
					}
				}
			}
			clsInit.appSewing.baseSelected = null;
			clsInit.appSewing.Selected.Clear();
			SewingTempVars.DrawType = SewingDrawType.None;
			SewingTempVars.DrawCommand = SewingDrawCommand.None;
		}
		clsItem.frmEditor.viewport.Entities.ClearSelection();
		for (int j = 0; j <= clsItem.frmEditor.viewport.Entities.Count - 1; j++)
		{
			clsItem.frmEditor.viewport.Entities[j].Selectable = true;
		}
		clsItem.frmEditor.viewport.Invalidate();
		clsItem.frmEditor.lbl_value.Visible = false;
		clsItem.frmEditor.spn_value.Visible = false;
		Sketcher2D.selectedCircle.Clear();
		Sketcher2D.selectedPoint.Clear();
		Sketcher2D.isDrawing = false;
		Sketcher2D.isSelectionDone = false;
		Sketcher2D.selectionProcess = true;
		Sketcher2D.rightClickCnt = 0;
		Sketcher2D.firstSelectedEntity = null;
		Sketcher2D.secondSelectedEntity = null;
		clsVar.varEditorRuntimeSet.OsnapEntityDisable = false;
		clsVar.varEditorRuntimeSet.OsnapGridDisable = false;
		clsVar.varEditorRuntimeSet.OsnapOverDisable = false;
		clsVar.varEditorRuntimeSet.OsnapPointDisable = false;
		Sketcher2D.Clicks.Clear();
		if (Sketcher2D.entitiesSelected != null)
		{
			Sketcher2D.entitiesSelected.Clear();
		}
		clsInit.appEditor.action = actionTypeBU.None;
		StatusUpdate("", "");
		ShowCheckArea(Show: false, Checked: false);
		ShowValueArea(Show: false);
		clsItem.frmEditor.viewport.Invalidate();
	}
}
