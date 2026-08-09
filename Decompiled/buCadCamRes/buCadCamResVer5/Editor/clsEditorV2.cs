using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using buClass;
using buControls.DialogBox;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Control.Labels;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;
using ns8;

namespace buCadCamResVer5.Editor;

public class clsEditorV2
{
	internal delegate void Delegate2();

	[CompilerGenerated]
	private sealed class Class6 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		public string string_0;

		public clsEditorV2 clsEditorV2_0;

		private OpenFileDialog openFileDialog_0;

		private bool bool_0;

		private bool bool_1;

		private DialogResult dialogResult_0;

		private int int_1;

		private int int_2;

		private FileInfo fileInfo_0;

		private List<Entity> list_0;

		private int int_3;

		private List<Entity> list_1;

		private List<EntitiesGroup> list_2;

		private int int_4;

		private int int_5;

		private int int_6;

		private int int_7;

		private TaskAwaiter<ReadFileAsync> taskAwaiter_0;

		void IAsyncStateMachine.MoveNext()
		{
			TaskAwaiter<ReadFileAsync> awaiter;
			if (int_0 == 0)
			{
				awaiter = taskAwaiter_0;
				taskAwaiter_0 = default(TaskAwaiter<ReadFileAsync>);
				int num = -1;
				int_0 = -1;
			}
			else
			{
				openFileDialog_0 = new OpenFileDialog();
				openFileDialog_0.InitialDirectory = clsVar.varInterface.pathEditor;
				if (clsItem.frmEditorV2.OpenFileExtension.Count != 0)
				{
					int_2 = 0;
					while (int_2 <= clsItem.frmEditorV2.OpenFileExtension.Count - 1)
					{
						if (int_2 != 0)
						{
							openFileDialog_0.Filter = openFileDialog_0.Filter + "|" + clsItem.frmEditorV2.OpenFileExtension[int_2].ToString();
						}
						else
						{
							openFileDialog_0.Filter = clsItem.frmEditorV2.OpenFileExtension[int_2].ToString();
						}
						int_2++;
					}
				}
				else
				{
					int_1 = 0;
					while (int_1 <= AppExtension.OpenFileExtension.Count - 1)
					{
						if (int_1 != 0)
						{
							openFileDialog_0.Filter = openFileDialog_0.Filter + "|" + AppExtension.OpenFileExtension[int_1].ToString();
						}
						else
						{
							openFileDialog_0.Filter = AppExtension.OpenFileExtension[int_1].ToString();
						}
						int_1++;
					}
				}
				openFileDialog_0.FilterIndex = clsVar.varInterface.indexFileEditor;
				bool_0 = true;
				bool_1 = false;
				dialogResult_0 = DialogResult.None;
				if (string_0.Length > 0)
				{
					fileInfo_0 = new FileInfo(string_0);
					if (fileInfo_0.Exists)
					{
						bool_1 = true;
						bool_0 = false;
						openFileDialog_0.FileName = fileInfo_0.FullName;
					}
					fileInfo_0 = null;
				}
				if (bool_0)
				{
					dialogResult_0 = openFileDialog_0.ShowDialog();
				}
				if (!((dialogResult_0 == DialogResult.OK) | bool_1))
				{
					goto IL_071a;
				}
				clsEditorV2_0.UndoBuffer();
				if (!((buFile5.getFileExtension(openFileDialog_0.FileName).ToLower() == ".dxf") | (buFile5.getFileExtension(openFileDialog_0.FileName).ToLower() == ".dwg")))
				{
					if (!(buFile5.getFileExtension(openFileDialog_0.FileName).ToLower() == ".bucadv5"))
					{
						if (buFile5.getFileExtension(openFileDialog_0.FileName).ToLower() == ".buteach")
						{
							clsItem.frmEditorV2.viewport.Clear();
							list_1 = new List<Entity>();
							list_2 = new List<EntitiesGroup>();
							clsInit.appFiles.OpenBuTeachFile(openFileDialog_0.FileName, ref list_2);
							if (list_2.Count > 0)
							{
								clsItem.frmEditorV2.viewport.Entities.Clear();
							}
							int_4 = 0;
							while (int_4 <= list_2.Count - 1)
							{
								int_5 = 0;
								while (int_5 <= list_2[int_4].Outside.Count - 1)
								{
									clsItem.frmEditorV2.viewport.Entities.Add(list_2[int_4].Outside[int_5]);
									int_5++;
								}
								if (list_2[int_4].Inside != null)
								{
									int_6 = 0;
									while (int_6 <= list_2[int_4].Inside.Count - 1)
									{
										int_7 = 0;
										while (int_7 <= list_2[int_4].Inside[int_6].Count - 1)
										{
											clsItem.frmEditorV2.viewport.Entities.Add(list_2[int_4].Inside[int_6][int_7]);
											int_7++;
										}
										int_6++;
									}
								}
								int_4++;
							}
							clsItem.frmEditorV2.viewport.Invalidate();
							clsItem.frmEditorV2.viewport.SetView(viewType.Top);
							clsItem.frmEditorV2.viewport.ZoomFit(10);
							clsItem.frmEditorV2.viewport.Invalidate();
							list_1 = null;
							list_2 = null;
						}
					}
					else
					{
						clsItem.frmEditorV2.viewport.Clear();
						list_0 = new List<Entity>();
						clsInit.appFiles.OpenBuCadFileVer5(openFileDialog_0.FileName, Clear: true, ref list_0);
						int_3 = 0;
						while (int_3 <= list_0.Count - 1)
						{
							clsItem.frmEditorV2.viewport.Entities.Add(list_0[int_3]);
							int_3++;
						}
						clsItem.frmEditorV2.viewport.Invalidate();
						clsItem.frmEditorV2.viewport.SetView(viewType.Top);
						clsItem.frmEditorV2.viewport.ZoomFit(10);
						clsItem.frmEditorV2.viewport.Invalidate();
						list_0 = null;
					}
					goto IL_0076;
				}
				awaiter = clsInit.cFile5.OpenDxfDwgAsync(clsItem.frmEditorV2.viewport, openFileDialog_0.FileName).GetAwaiter();
				if (!awaiter.IsCompleted)
				{
					int num = 0;
					int_0 = 0;
					taskAwaiter_0 = awaiter;
					Class6 stateMachine = this;
					asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
					return;
				}
			}
			awaiter.GetResult();
			clsItem.frmEditorV2.viewport.Entities.Regen();
			clsItem.frmEditorV2.viewport.Invalidate();
			clsItem.frmEditorV2.viewport.SetView(viewType.Top);
			clsItem.frmEditorV2.viewport.ZoomFit(10);
			goto IL_0076;
			IL_0076:
			clsVar.varInterface.indexFileEditor = openFileDialog_0.FilterIndex;
			clsVar.varInterface.pathEditor = buFile5.GetPath(openFileDialog_0.FileName);
			clsFiles.SaveParameter();
			goto IL_071a;
			IL_071a:
			int_0 = -2;
			openFileDialog_0 = null;
			asyncVoidMethodBuilder_0.SetResult();
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

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

	public readonly SketchEntity.CameraSettings SketchCameraSettings = new SketchEntity.CameraSettings();

	public List<EditorCustomData> OpenCustomData = new List<EditorCustomData>();

	public actionTypeBU action = actionTypeBU.None;

	public int? _filletChamferIndex;

	public VectorClock _clock = null;

	public Tuple<ICurve, ICurve, ICurve>[] _filletsChamfers;

	public int SelectedDrawing = -1;

	public int SelectedConstraint = -1;

	public FileInfo FIZip = null;

	private int int_0 = 0;

	public string ActiveLayerName = "Default";

	public void Init()
	{
		if (timSim == null)
		{
			timSim = new Timer();
			timSim.Tick += Sim_Tick;
			timSim.Interval = 10;
		}
	}

	public void cmdNew()
	{
		UndoBuffer();
		clsItem.frmEditorV2.viewport.Entities.Clear();
		clsItem.frmEditorV2.viewport.Invalidate();
	}

	[AsyncStateMachine(typeof(Class6))]
	[DebuggerStepThrough]
	public void cmdOpen(string FileName = "")
	{
		Class6 stateMachine = new Class6();
		stateMachine.asyncVoidMethodBuilder_0 = AsyncVoidMethodBuilder.Create();
		stateMachine.clsEditorV2_0 = this;
		stateMachine.string_0 = FileName;
		stateMachine.int_0 = -1;
		stateMachine.asyncVoidMethodBuilder_0.Start(ref stateMachine);
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
		buVector5.CopyEntities(clsItem.frmEditorV2.viewport.Entities, ref copiedEnt);
		if (clsItem.frmEditorV2.viewport.CurrentSketch != null && clsItem.frmEditorV2.viewport.CurrentSketch.Editing)
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
			clsInit.cFile5.SaveDxfDwgAsyc(clsItem.frmEditorV2.viewport, saveFileDialog.FileName);
		}
		if (!(buFile5.getFileExtension(saveFileDialog.FileName).ToLower() == ".bucadv5"))
		{
		}
	}

	public void cmdInsert(ref List<Entity> refEntities)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.InitialDirectory = clsVar.varInterface.pathEditor;
		if (clsItem.frmEditorV2.OpenFileExtension.Count != 0)
		{
			for (int i = 0; i <= clsItem.frmEditorV2.OpenFileExtension.Count - 1; i++)
			{
				if (i != 0)
				{
					openFileDialog.Filter = openFileDialog.Filter + "|" + clsItem.frmEditorV2.OpenFileExtension[i].ToString();
				}
				else
				{
					openFileDialog.Filter = clsItem.frmEditorV2.OpenFileExtension[i].ToString();
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
			clsItem.frmEditorV2.viewport.Clear();
			clsItem.frmEditorV2.viewport.StartWork(workUnit);
		}
	}

	public void cmdSaveLib(Design Viewport)
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.InitialDirectory = clsVar.varLibrary.pathLibrary;
		saveFileDialog.Filter = "buCad/Cam Library File (*.bulib5)|*.bulib5";
		saveFileDialog.FilterIndex = 1;
		if (saveFileDialog.ShowDialog(clsItem.frmEditorV2) != DialogResult.OK)
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
		if (clsItem.frmEditorV2.viewport.CurrentSketch.IsSketchEntity())
		{
			clsItem.frmEditorV2.viewport.CurrentSketch.DeleteEntity(Ent);
		}
		else
		{
			clsItem.frmEditorV2.viewport.CurrentSketch.DeleteConstraint(Ent);
		}
		clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
		clsItem.frmEditorV2.viewport.Invalidate();
	}

	public void cmdUndo()
	{
		Class5.smethod_65((Delegate2)clsItem.frmEditorV2.viewport.CurrentSketch.Undo, this);
	}

	public void cmdRedo()
	{
		Class5.smethod_65((Delegate2)clsItem.frmEditorV2.viewport.CurrentSketch.Redo, this);
	}

	public void cmdShowContrraint(bool Show)
	{
		foreach (devDept.Eyeshot.Control.Labels.Label label in clsItem.frmEditorV2.viewport.ActiveViewport.Labels)
		{
			if (label is StackedLabel)
			{
				StackedLabel stackedLabel = label as StackedLabel;
				stackedLabel.Visible = Show;
			}
		}
		clsItem.frmEditorV2.viewport.Invalidate();
	}

	public void cmdShowDimension(bool Show)
	{
		foreach (Entity entity in clsItem.frmEditorV2.viewport.Entities)
		{
			if (entity is Dimension)
			{
				entity.Visible = Show;
			}
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
				clsItem.frmEditorV2.viewport.EventScale(Override: true, clsVar.varEditorRuntimeSet.ScaleRatio);
			}
		}
		catch (Exception)
		{
		}
	}

	public void cmdEventsMove()
	{
		try
		{
			Drafting2D.points.Clear();
			clsInit.appEditor2.action = actionTypeBU.eventMove;
			Drafting2D.entitiesSelected.Clear();
			clsInit.cVector5.getSelectedEntitiesCount(clsItem.frmEditorV2.viewport.Entities, ref int_0);
			if (int_0 != 0)
			{
				clsItem.frmEditorV2.viewport.EventCopyToSelected();
				clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineReferancePoint, buLangTranslate.preDef.Move);
				Drafting2D.selectionProcess = false;
			}
			else
			{
				clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.SelectEntities, buLangTranslate.preDef.Move);
				Drafting2D.selectionProcess = true;
			}
		}
		catch (Exception)
		{
		}
	}

	public void cmdEventsCopy()
	{
		try
		{
			Drafting2D.points.Clear();
			clsInit.appEditor2.action = actionTypeBU.eventCopy;
			Drafting2D.entitiesSelected.Clear();
			clsInit.cVector5.getSelectedEntitiesCount(clsItem.frmEditorV2.viewport.Entities, ref int_0);
			if (int_0 != 0)
			{
				clsItem.frmEditorV2.viewport.EventCopyToSelected();
				clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineReferancePoint, buLangTranslate.preDef.Copy);
				Drafting2D.selectionProcess = false;
			}
			else
			{
				clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.SelectEntities, buLangTranslate.preDef.Copy);
				Drafting2D.selectionProcess = true;
			}
		}
		catch (Exception)
		{
		}
	}

	public void cmdEventsMirror()
	{
		try
		{
			Drafting2D.points.Clear();
			clsInit.appEditor2.action = actionTypeBU.eventMirror;
			Drafting2D.entitiesSelected.Clear();
			clsInit.cVector5.getSelectedEntitiesCount(clsItem.frmEditorV2.viewport.Entities, ref int_0);
			if (int_0 != 0)
			{
				clsItem.frmEditorV2.viewport.EventCopyToSelected();
				clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineReferancePoint, buLangTranslate.preDef.Mirror);
				Drafting2D.selectionProcess = false;
			}
			else
			{
				clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.SelectEntities, buLangTranslate.preDef.Mirror);
				Drafting2D.selectionProcess = true;
			}
		}
		catch (Exception)
		{
		}
	}

	public void cmdEventsOffset()
	{
		try
		{
			ShowValueArea(actionTypeBU.eventOffset, Show: true, 260, 110, buLangTranslate.preDef.Offset, clsVar.varEditorRuntimeSet.OffsetValue, -10000000.0);
			Drafting2D.points.Clear();
			clsInit.appEditor2.action = actionTypeBU.eventOffset;
			Drafting2D.entitiesSelected.Clear();
			clsInit.cVector5.getSelectedEntitiesCount(clsItem.frmEditorV2.viewport.Entities, ref int_0);
			if (int_0 != 0)
			{
				clsItem.frmEditorV2.viewport.EventCopyToSelected();
				clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineOffsetPoint, buLangTranslate.preDef.Offset);
				Drafting2D.selectionProcess = false;
			}
			else
			{
				clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.SelectEntities, buLangTranslate.preDef.Offset);
				Drafting2D.selectionProcess = true;
			}
		}
		catch (Exception)
		{
		}
	}

	public void cmdEventsRotate()
	{
		try
		{
			Drafting2D.points.Clear();
			clsInit.appEditor2.action = actionTypeBU.eventRotate;
			Drafting2D.entitiesSelected.Clear();
			clsInit.cVector5.getSelectedEntitiesCount(clsItem.frmEditorV2.viewport.Entities, ref int_0);
			if (int_0 != 0)
			{
				clsItem.frmEditorV2.viewport.EventCopyToSelected();
				clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineCenterPoint, buLangTranslate.preDef.Rotate);
				Drafting2D.selectionProcess = false;
			}
			else
			{
				clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.SelectEntities, buLangTranslate.preDef.Rotate);
				Drafting2D.selectionProcess = true;
			}
		}
		catch (Exception)
		{
		}
	}

	public void cmdEventsBreak()
	{
		try
		{
			Drafting2D.points.Clear();
			clsInit.appEditor2.action = actionTypeBU.eventBreak;
			Drafting2D.entitiesSelected.Clear();
			clsInit.cVector5.getSelectedEntitiesCount(clsItem.frmEditorV2.viewport.Entities, ref int_0);
			clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineBreakPoint, buLangTranslate.preDef.Break);
			Drafting2D.selectionProcess = false;
		}
		catch (Exception)
		{
		}
	}

	public void cmdEventsScale()
	{
		try
		{
			ShowValueArea(actionTypeBU.eventScale, Show: true, 260, 90, buLangTranslate.preDef.Scale, clsVar.varEditorRuntimeSet.ScaleRatio, 0.0, 10000000.0, 2, ButtonShow: true);
			Drafting2D.points.Clear();
			clsInit.appEditor2.action = actionTypeBU.eventScale;
			Drafting2D.entitiesSelected.Clear();
			clsInit.cVector5.getSelectedEntitiesCount(clsItem.frmEditorV2.viewport.Entities, ref int_0);
			if (int_0 != 0)
			{
				clsItem.frmEditorV2.viewport.EventCopyToSelected();
				clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineFirstPoint, buLangTranslate.preDef.Scale);
				Drafting2D.selectionProcess = false;
			}
			else
			{
				clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.SelectEntities, buLangTranslate.preDef.Scale);
				Drafting2D.selectionProcess = true;
			}
		}
		catch (Exception)
		{
		}
	}

	public void cmdEventsLinearArray()
	{
		try
		{
			ShowValueArea(Show: false);
			Drafting2D.points.Clear();
			clsInit.appEditor2.action = actionTypeBU.eventLineerArray;
			Drafting2D.entitiesSelected.Clear();
			clsInit.cVector5.getSelectedEntitiesCount(clsItem.frmEditorV2.viewport.Entities, ref int_0);
			if (int_0 != 0)
			{
				clsItem.frmEditorV2.viewport.EventCopyToSelected();
				clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineFirstPoint, buLangTranslate.preDef.Array);
				Drafting2D.selectionProcess = false;
			}
			else
			{
				clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.SelectEntities, buLangTranslate.preDef.Array);
				Drafting2D.selectionProcess = true;
			}
		}
		catch (Exception)
		{
		}
	}

	public void cmdEventsExtend()
	{
		try
		{
			ShowValueArea(actionTypeBU.eventExtend, Show: true, 260, 90, buLangTranslate.preDef.Extend, clsVar.varEditorRuntimeSet.ExtendLength, -1000000.0, 1000000.0);
			Drafting2D.points.Clear();
			clsInit.appEditor2.action = actionTypeBU.eventExtend;
			Drafting2D.entitiesSelected.Clear();
			clsInit.cVector5.getSelectedEntitiesCount(clsItem.frmEditorV2.viewport.Entities, ref int_0);
			clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineExtendPoint, buLangTranslate.preDef.Extend);
			Drafting2D.selectionProcess = false;
		}
		catch (Exception)
		{
		}
	}

	public void cmdEventsTrim()
	{
		try
		{
			Drafting2D.entToTrim = null;
			Drafting2D.leftOvers = new List<Entity>();
			Drafting2D.points.Clear();
			clsInit.appEditor2.action = actionTypeBU.eventTrim;
			Drafting2D.entitiesSelected.Clear();
			clsInit.cVector5.getSelectedEntitiesCount(clsItem.frmEditorV2.viewport.Entities, ref int_0);
			clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineTrimPoint, buLangTranslate.preDef.Trim);
			Drafting2D.selectionProcess = false;
		}
		catch (Exception)
		{
		}
	}

	public void cmdEventsFillet()
	{
		try
		{
			ShowValueArea(actionTypeBU.eventFillet, Show: true, 260, 90, buLangTranslate.preDef.Fillet, clsVar.varEditorRuntimeSet.FilletRadius, 0.0, 1000000.0);
			Drafting2D.NoRectangleSelection = true;
			Drafting2D.points.Clear();
			clsInit.appEditor2.action = actionTypeBU.eventFillet;
			Drafting2D.entitiesSelected.Clear();
			clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.SelectFirstEntity, buLangTranslate.preDef.Fillet);
			Drafting2D.selectionProcess = true;
		}
		catch (Exception)
		{
		}
	}

	public void cmdEventsChamfer()
	{
		ShowValueArea(actionTypeBU.eventChamfer, Show: true, 260, 90, buLangTranslate.preDef.Chamfer, clsVar.varEditorRuntimeSet.ChamferLength, 0.0, 1000000.0);
		Drafting2D.NoRectangleSelection = true;
		Drafting2D.points.Clear();
		clsInit.appEditor2.action = actionTypeBU.eventChamfer;
		Drafting2D.entitiesSelected.Clear();
		clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.SelectFirstEntity, buLangTranslate.preDef.Chamfer);
	}

	public void cmdEventsDelete()
	{
		Drafting2D.points.Clear();
		clsInit.cVector5.getSelectedEntitiesCount(clsItem.frmEditorV2.viewport.Entities, ref int_0);
		if (int_0 != 0)
		{
			clsItem.frmEditorV2.viewport.EventDelete();
			return;
		}
		clsInit.appEditor2.action = actionTypeBU.eventDelete;
		clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.SelectEntities, buLangTranslate.preDef.Delete);
		Drafting2D.selectionProcess = true;
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
		clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditorV2.viewport.Entities, Clone: false, ref Sketcher2D.entitiesSelected);
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
		clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditorV2.viewport.Entities, Clone: false, ref Sketcher2D.entitiesSelected);
		if (Sketcher2D.entitiesSelected.Count != 0)
		{
			Mirror(Value);
			return;
		}
		clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[10], buLangTranslate.preDef.Mirror);
		Sketcher2D.selectionProcess = true;
	}

	public void StatusUpdate(string Message, string Command, string Args = "")
	{
		string text = "";
		if (Command.Length > 0)
		{
			text = Command + " : ";
		}
		clsItem.frmEditorV2.lbl_status.Text = text + Message + " " + Args;
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
		else if (clsItem.frmEditorV2.viewport.Entities.Count > 0)
		{
			Entity entity = clsItem.frmEditorV2.viewport.Entities[clsItem.frmEditorV2.viewport.Entities.Count - 1];
			if ((entity.EntityData != null) & (entity.EntityData is CustomData))
			{
				CustomData customData = entity.EntityData as CustomData;
				if (customData.typeDefination == entityTypeDefination.Tool)
				{
					clsItem.frmEditorV2.viewport.Entities.RemoveAt(clsItem.frmEditorV2.viewport.Entities.Count - 1);
				}
			}
			entity = clsItem.frmEditorV2.viewport.Entities[clsItem.frmEditorV2.viewport.Entities.Count - 1];
			if ((entity.EntityData != null) & (entity.EntityData is CustomData))
			{
				CustomData customData2 = entity.EntityData as CustomData;
				if (customData2.typeDefination == entityTypeDefination.Tool)
				{
					clsItem.frmEditorV2.viewport.Entities.RemoveAt(clsItem.frmEditorV2.viewport.Entities.Count - 1);
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
			clsItem.frmEditorV2.viewport.Entities.Add(mesh);
			Text text = new Text(Plane.XY, new Point3D(pnt6DSimMove.X, pnt6DSimMove.Y - 6.0, pnt6DSimMove.Z), pnt6DSimMove.C.ToString("f1"), 20.0);
			CustomData customData4 = new CustomData();
			customData4.typeDefination = entityTypeDefination.Tool;
			text.EntityData = customData4;
			text.Color = Color.Red;
			text.ColorMethod = colorMethodType.byEntity;
			clsItem.frmEditorV2.viewport.Entities.Add(text);
			if (clsVar.varEditorSet.SimulationStep <= 0)
			{
				clsVar.varEditorSet.SimulationStep = 1;
			}
			sortedEntitiesSimIndex += clsVar.varEditorSet.SimulationStep;
		}
		clsItem.frmEditorV2.viewport.Invalidate();
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
		Entity entity = clsItem.frmEditorV2.viewport.Entities[clsItem.frmEditorV2.viewport.Entities.Count - 1];
		if ((entity.EntityData != null) & (entity.EntityData is CustomData))
		{
			CustomData customData = entity.EntityData as CustomData;
			if (customData.typeDefination == entityTypeDefination.Tool)
			{
				clsItem.frmEditorV2.viewport.Entities.RemoveAt(clsItem.frmEditorV2.viewport.Entities.Count - 1);
			}
		}
		entity = clsItem.frmEditorV2.viewport.Entities[clsItem.frmEditorV2.viewport.Entities.Count - 1];
		if ((entity.EntityData != null) & (entity.EntityData is CustomData))
		{
			CustomData customData2 = entity.EntityData as CustomData;
			if (customData2.typeDefination == entityTypeDefination.Tool)
			{
				clsItem.frmEditorV2.viewport.Entities.RemoveAt(clsItem.frmEditorV2.viewport.Entities.Count - 1);
			}
		}
		clsItem.frmEditorV2.viewport.Invalidate();
	}

	public void AddPoint(UClick start)
	{
		if (!clsVar.varEditorRuntimeSet.isSketchMode)
		{
			UndoBuffer();
			devDept.Eyeshot.Entities.Point entity_ = new devDept.Eyeshot.Entities.Point(new Point3D(start.Position.X, start.Position.Y));
			clsItem.frmEditorV2.viewport.method_18(entity_, ActiveLayerName, bool_0: true, bool_1: true);
			return;
		}
		devDept.Eyeshot.Entities.Point point = clsItem.frmEditorV2.viewport.CurrentSketch.AddPoint(start.Position);
		if (start.Entity != null)
		{
			double t = 0.0;
			((ICurve)start.Entity).ClosestPointTo(new Point3D(start.Position.X, start.Position.Y), out t);
			clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintPointAt(point, start.Entity, 0.5);
			clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintPointOn(point, start.Entity);
		}
		clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
		JobUpdate();
	}

	public Line AddLine(UClick start, UClick end)
	{
		if (!clsVar.varEditorRuntimeSet.isSketchMode)
		{
			UndoBuffer();
			Line line = new Line(new Point3D(start.Position.X, start.Position.Y), new Point3D(end.Position.X, end.Position.Y));
			clsItem.frmEditorV2.viewport.method_18(line, ActiveLayerName, bool_0: true, bool_1: true);
			return line;
		}
		Line line2 = clsItem.frmEditorV2.viewport.CurrentSketch.AddLine(start.Position, end.Position);
		if (start.Entity != null)
		{
			clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditorV2.viewport.CurrentSketch.StartPoint(line2), start.Entity);
		}
		if (end.Entity != null)
		{
			clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditorV2.viewport.CurrentSketch.EndPoint(line2), end.Entity);
		}
		if (start.Entity == null || end.Entity == null)
		{
			Class5.smethod_177(this, line2);
		}
		clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
		JobUpdate();
		return line2;
	}

	public LinearPath AddPolyLine(List<UClick> refPoints)
	{
		UndoBuffer();
		List<Point3D> list = new List<Point3D>();
		for (int i = 0; i <= refPoints.Count - 1; i++)
		{
			list.Add(new Point3D(refPoints[i].Position.X, refPoints[i].Position.Y));
		}
		LinearPath linearPath = new LinearPath(list);
		clsItem.frmEditorV2.viewport.method_18(linearPath, ActiveLayerName, bool_0: true, bool_1: true);
		return linearPath;
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
			CompositeCurve entity_ = CompositeCurve.CreateRectangle(x, y, width, height);
			clsItem.frmEditorV2.viewport.method_18(entity_, ActiveLayerName, bool_0: true, bool_1: true);
		}
		else
		{
			Point2D position3 = start.Position;
			Point2D position4 = end.Position;
			double width2 = Math.Abs(position3.X - position4.X);
			double height2 = Math.Abs(position3.Y - position4.Y);
			double x2 = Math.Min(position3.X, position4.X);
			double y2 = Math.Min(position3.Y, position4.Y);
			Entity[] entity_2 = clsItem.frmEditorV2.viewport.CurrentSketch.AddRectangle(x2, y2, width2, height2, 0.0, lengthConstraints: false);
			int int_ = default(int);
			Class5.smethod_116(position3, position4, out int num, this, ref int_);
			Class5.smethod_145(num, this, start.Entity, entity_2);
			Class5.smethod_145(int_, this, end.Entity, entity_2);
			clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
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
				clsItem.frmEditorV2.viewport.Entities.Add(ellipse);
			}
			Reset();
			return;
		}
		Point2D position2 = start.Position;
		double num3 = position2.DistanceTo(new Point2D(end.Position.X, position2.Y));
		double num4 = position2.DistanceTo(new Point2D(position2.X, end.Position.Y));
		if (!(num3 <= 0.001) && num4 > 0.001)
		{
			Ellipse ellipse2 = clsItem.frmEditorV2.viewport.CurrentSketch.AddEllipse(position2, num3, num4);
			if (start.Entity != null)
			{
				clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditorV2.viewport.CurrentSketch.CenterPoint(ellipse2), start.Entity);
			}
		}
		clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
		Reset();
		JobUpdate();
	}

	public void AddEllipse(Ellipse Ent)
	{
		clsItem.frmEditorV2.viewport.method_18(Ent, ActiveLayerName, bool_0: true, bool_1: true);
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
			CompositeCurve entity_ = new CompositeCurve(curve);
			clsItem.frmEditorV2.viewport.method_18(entity_, ActiveLayerName, bool_0: true, bool_1: true);
			return;
		}
		Vector2D asVector = (end.Position - start.Position).AsVector;
		Vector2D asVector2 = (Vector2D.AxisX - start.Position).AsVector;
		asVector.Normalize();
		asVector2.Normalize();
		double angle = Vector2D.SignedAngleBetween(Vector2D.AxisX, asVector);
		clsItem.frmEditorV2.viewport.CurrentSketch.AddPolygon(start.Position, start.Position.DistanceTo(end.Position), clsVar.varEditorRuntimeSet.PolygonSide, out var polygonCenter, out var firstPolygonVertex, angle);
		if (start.Entity != null)
		{
			clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintJoin(polygonCenter, start.Entity);
		}
		if (end.Entity != null)
		{
			clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintJoin(firstPolygonVertex, end.Entity);
		}
		clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
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
				clsItem.frmEditorV2.viewport.Entities.Add(copiedEntity);
			}
			Reset();
		}
		else
		{
			Reset();
			JobUpdate();
		}
	}

	public void AddSlot(UClick first, UClick second, UClick third)
	{
		if (!clsVar.varEditorRuntimeSet.isSketchMode)
		{
			UndoBuffer();
			Entity entity_ = clsInit.cVector5.Slot3Point(first.Position, second.Position, third.Position);
			clsItem.frmEditorV2.viewport.method_18(entity_, ActiveLayerName, bool_0: true, bool_1: true);
			return;
		}
		Point2D position = first.Position;
		Point2D position2 = second.Position;
		Point2D position3 = third.Position;
		Entity[] array = clsItem.frmEditorV2.viewport.CurrentSketch.AddSlot(position.X, position.Y, position.DistanceTo(position2), SlotRad(position, position2, position3), (position2 - position).AsVector.Angle);
		Circle circle = array[3] as Circle;
		Circle circle2 = array[1] as Circle;
		if (first.Entity != null)
		{
			clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditorV2.viewport.CurrentSketch.CenterPoint(circle), first.Entity);
		}
		if (second.Entity != null)
		{
			clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditorV2.viewport.CurrentSketch.CenterPoint(circle2), second.Entity);
		}
		clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
		Reset();
		JobUpdate();
	}

	public void AddCurve(List<UClick> Clicks)
	{
		if (!clsVar.varEditorRuntimeSet.isSketchMode && Clicks.Count > 2)
		{
			UndoBuffer();
			List<Point3D> list = new List<Point3D>();
			for (int i = 0; i <= Clicks.Count - 1; i++)
			{
				list.Add(new Point3D(Clicks[i].Position.X, Clicks[i].Position.Y));
			}
			Curve entity_ = Curve.CubicSplineInterpolation(list);
			clsItem.frmEditorV2.viewport.method_18(entity_, ActiveLayerName, bool_0: true, bool_1: true);
		}
	}

	public Line ExtendLine(Line other, UClick end)
	{
		if (!clsVar.varEditorRuntimeSet.isSketchMode)
		{
			return new Line(new Point3D(), new Point3D());
		}
		Line line = clsItem.frmEditorV2.viewport.CurrentSketch.AddLine(clsItem.frmEditorV2.viewport.CurrentSketch.Plane.Project(other.EndPoint), end.Position);
		clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditorV2.viewport.CurrentSketch.EndPoint(other), clsItem.frmEditorV2.viewport.CurrentSketch.StartPoint(line));
		if (end.Entity != null)
		{
			clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditorV2.viewport.CurrentSketch.EndPoint(line), end.Entity);
		}
		Class5.smethod_177(this, line);
		clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
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
				Circle entity_ = new Circle(Plane.XY, new Point3D(start.Position.X, start.Position.Y), num);
				clsItem.frmEditorV2.viewport.method_18(entity_, ActiveLayerName, bool_0: true, bool_1: true);
			}
			Reset();
			return null;
		}
		Circle result = clsItem.frmEditorV2.viewport.CurrentSketch.AddCircle(start.Position, end.Position);
		clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
		action = actionTypeBU.None;
		JobUpdate();
		return result;
	}

	public Circle AddCircle(UClick first, UClick second, UClick third)
	{
		if (!clsVar.varEditorRuntimeSet.isSketchMode)
		{
			UndoBuffer();
			Circle entity_ = new Circle(new Point3D(first.Position.X, first.Position.Y), new Point3D(second.Position.X, second.Position.Y), new Point3D(third.Position.X, third.Position.Y));
			clsItem.frmEditorV2.viewport.method_18(entity_, ActiveLayerName, bool_0: true, bool_1: true);
			Reset();
			return null;
		}
		Circle circle = new Circle(new Point3D(first.Position.X, first.Position.Y), new Point3D(second.Position.X, second.Position.Y), new Point3D(third.Position.X, third.Position.Y));
		Circle result = clsItem.frmEditorV2.viewport.CurrentSketch.AddCircle(circle.Center, circle.Radius);
		clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
		action = actionTypeBU.None;
		JobUpdate();
		return result;
	}

	public Arc AddArc(UClick first, UClick second, UClick third)
	{
		if (!clsVar.varEditorRuntimeSet.isSketchMode)
		{
			if (EvaluateArc(first.Position, second.Position, third.Position, out var flip))
			{
				UndoBuffer();
				Arc arc = new Arc(Plane.XY, new Point3D(first.Position.X, first.Position.Y), new Point3D(second.Position.X, second.Position.Y), new Point3D(third.Position.X, third.Position.Y), flip);
				clsItem.frmEditorV2.viewport.method_18(arc, ActiveLayerName, bool_0: true, bool_1: true);
				return arc;
			}
			return null;
		}
		if (EvaluateArc(first.Position, second.Position, third.Position, out var flip2))
		{
			Arc arc2 = new Arc(clsItem.frmEditorV2.viewport.CurrentSketch.Plane, first.Position, second.Position, third.Position, flip2);
			clsItem.frmEditorV2.viewport.CurrentSketch.AddArc(arc2);
			if (first.Entity != null)
			{
				if (flip2)
				{
					clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditorV2.viewport.CurrentSketch.EndPoint(arc2), first.Entity);
				}
				else
				{
					clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditorV2.viewport.CurrentSketch.StartPoint(arc2), first.Entity);
				}
			}
			if (third.Entity != null)
			{
				if (flip2)
				{
					clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditorV2.viewport.CurrentSketch.StartPoint(arc2), third.Entity);
				}
				else
				{
					clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintJoin(clsItem.frmEditorV2.viewport.CurrentSketch.EndPoint(arc2), third.Entity);
				}
			}
			clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
			JobUpdate();
			return arc2;
		}
		return null;
	}

	public Arc AddArc(Plane drawPlane, Point3D center, double radius, double SA, double EA)
	{
		if (!clsVar.varEditorRuntimeSet.isSketchMode)
		{
			UndoBuffer();
			Arc arc = new Arc(drawPlane, center, radius, SA, EA);
			clsItem.frmEditorV2.viewport.method_18(arc, ActiveLayerName, bool_0: true, bool_1: true);
			return arc;
		}
		return null;
	}

	public void AddFilletChamfer(bool isFillet, ICurve C1, ICurve C2)
	{
		if (!_filletChamferIndex.HasValue)
		{
			return;
		}
		Tuple<bool, bool> tuple = Class5.smethod_147(_filletChamferIndex.Value, this);
		DialogBoxInput dialogBoxInput = new DialogBoxInput();
		dialogBoxInput.Value = clsVar.varEditorRuntimeSet.FilletRadius;
		dialogBoxInput.StartPosition = FormStartPosition.CenterParent;
		dialogBoxInput.Init();
		dialogBoxInput.ShowDialog();
		if (dialogBoxInput.Result != DialogResult.OK)
		{
			clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
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
				clsItem.frmEditorV2.viewport.CurrentSketch.AddChamfer(C1, C2, tuple.Item1, tuple.Item2, clsVar.varEditorRuntimeSet.ChamferLength);
			}
			else
			{
				clsItem.frmEditorV2.viewport.CurrentSketch.AddFillet(C1, C2, tuple.Item1, tuple.Item2, clsVar.varEditorRuntimeSet.FilletRadius);
			}
			clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
			if (isFillet && clsItem.frmEditorV2 != null)
			{
				clsItem.frmEditorV2.btn_lib_Click(clsItem.frmEditorV2.btn_lib_fillet, null);
			}
		}
		for (int i = 0; i <= clsItem.frmEditorV2.viewport.Entities.Count - 1; i++)
		{
			clsItem.frmEditorV2.viewport.Entities[i].Selected = false;
		}
		clsItem.frmEditorV2.viewport.Invalidate();
		JobUpdate();
	}

	public void NewSketch()
	{
		SketchEntity sketchEntity = new SketchEntity(Plane.XY);
		clsItem.frmEditorV2.viewport.Entities.Clear();
		clsItem.frmEditorV2.viewport.Entities.Add(sketchEntity);
		sketchEntity.Edit(clsItem.frmEditorV2.viewport);
		clsItem.frmEditorV2.viewport.CurrentSketch.ClearHistory();
		clsItem.frmEditorV2.viewport.Entities.UpdateBoundingBox();
		clsItem.frmEditorV2.viewport.UpdateBoundingBox();
		clsItem.frmEditorV2.viewport.Invalidate();
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
			clsItem.frmEditorV2.viewport.CurrentSketch.Move(clsItem.frmEditorV2.viewport.CurrentSketch.StartPoint(L1), point3D);
			segments = GetSegments(L1, L2);
			segment2D = segments.Item1;
			segment2D = segments.Item2;
		}
		_clock = new VectorClock(segment2D, item);
	}

	public Tuple<Segment2D, Segment2D> GetSegments(Line L1, Line L2)
	{
		return new Tuple<Segment2D, Segment2D>(new Segment2D(clsItem.frmEditorV2.viewport.CurrentSketch.Plane.Project(L1.StartPoint), clsItem.frmEditorV2.viewport.CurrentSketch.Plane.Project(L1.EndPoint)), new Segment2D(clsItem.frmEditorV2.viewport.CurrentSketch.Plane.Project(L2.StartPoint), clsItem.frmEditorV2.viewport.CurrentSketch.Plane.Project(L2.EndPoint)));
	}

	public void FilletChamferCalculation(bool isFillet)
	{
		ICurve c = (ICurve)Sketcher2D.entitiesSelected[0];
		ICurve c2 = (ICurve)Sketcher2D.entitiesSelected[1];
		Point3D[] source = Utility.Intersection(c, c2);
		Point3D point3D = source.LastOrDefault();
		if (!(point3D == null))
		{
			point3D.TransformBy(new Align3D(Plane.XY, clsItem.frmEditorV2.viewport.CurrentSketch.DrawingPlane));
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
			if (clsItem.frmEditorV2 != null)
			{
				clsItem.frmEditorV2.btn_lib_Click(clsItem.frmEditorV2.btn_lib_fillet, null);
			}
		}
	}

	public void ComputeFilletsChamfers(bool isFillet, double Radius, ICurve _c1, ICurve _c2)
	{
		for (int i = 0; i < 4; i++)
		{
			Entity entity = (Entity)((Entity)_c1).Clone();
			Entity entity2 = (Entity)((Entity)_c2).Clone();
			Tuple<bool, bool> tuple = Class5.smethod_147(i, this);
			if (!isFillet)
			{
				Curve.Chamfer((ICurve)entity, (ICurve)entity2, Radius, tuple.Item1, tuple.Item2, entity is Arc || entity is Line, entity2 is Arc || entity2 is Line, out var chamfer);
				if (chamfer != null && !(chamfer.Length() < 0.001))
				{
					chamfer.TransformBy(Transformation.CreateAlignment(clsItem.frmEditorV2.viewport.CurrentSketch.Plane, clsItem.frmEditorV2.viewport.CurrentSketch.DrawingPlane));
					entity.TransformBy(Transformation.CreateAlignment(clsItem.frmEditorV2.viewport.CurrentSketch.Plane, clsItem.frmEditorV2.viewport.CurrentSketch.DrawingPlane));
					entity2.TransformBy(Transformation.CreateAlignment(clsItem.frmEditorV2.viewport.CurrentSketch.Plane, clsItem.frmEditorV2.viewport.CurrentSketch.DrawingPlane));
					_filletsChamfers[i] = new Tuple<ICurve, ICurve, ICurve>(chamfer, (ICurve)entity, (ICurve)entity2);
				}
			}
			else
			{
				Curve.Fillet((ICurve)entity, (ICurve)entity2, Radius, tuple.Item1, tuple.Item2, entity is Arc || entity is Line, entity2 is Arc || entity2 is Line, out var fillet);
				if (fillet != null && !(fillet.AngleInRadians < 0.001))
				{
					fillet.TransformBy(Transformation.CreateAlignment(clsItem.frmEditorV2.viewport.CurrentSketch.Plane, clsItem.frmEditorV2.viewport.CurrentSketch.DrawingPlane));
					entity.TransformBy(Transformation.CreateAlignment(clsItem.frmEditorV2.viewport.CurrentSketch.Plane, clsItem.frmEditorV2.viewport.CurrentSketch.DrawingPlane));
					entity2.TransformBy(Transformation.CreateAlignment(clsItem.frmEditorV2.viewport.CurrentSketch.Plane, clsItem.frmEditorV2.viewport.CurrentSketch.DrawingPlane));
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
			Circle circle = new Circle(clsItem.frmEditorV2.viewport.CurrentSketch.DrawingPlane, center, center.DistanceTo(startPoint));
			Point3D[] array = new Point3D[clsVar.varEditorRuntimeSet.PolygonSide + 1];
			for (int i = 0; i < clsVar.varEditorRuntimeSet.PolygonSide; i++)
			{
				array[i] = circle.PointAt(Math.PI * 2.0 * (double)i / (double)clsVar.varEditorRuntimeSet.PolygonSide);
			}
			array[clsVar.varEditorRuntimeSet.PolygonSide] = circle.PointAt(0.0);
			lp = new LinearPath(array);
			Vector2D asVector = (startPoint - center).AsVector;
			Vector2D asVector2 = (clsItem.frmEditorV2.viewport.CurrentSketch.DrawingPlane.Project(circle.StartPoint) - center).AsVector;
			asVector.Normalize();
			asVector2.Normalize();
			double angleInRadians = Vector2D.SignedAngleBetween(asVector2, asVector);
			lp.Rotate(angleInRadians, clsItem.frmEditorV2.viewport.CurrentSketch.DrawingPlane.AxisZ, circle.Center);
			lp.Regen(clsItem.frmEditorV2.viewport.GetVisualRefinement());
		}
	}

	public CompositeCurve ThreePointsSlot(Point2D start, Point2D end, Point2D radial)
	{
		double num = SlotRad(start, end, radial);
		if (num <= 0.0)
		{
			num = 0.1;
		}
		return CompositeCurve.CreateSlot(clsItem.frmEditorV2.viewport.CurrentSketch.DrawingPlane, start.X, start.Y, start.DistanceTo(end), num, (end - start).AsVector.Angle);
	}

	public double SlotRad(Point2D start, Point2D end, Point2D radial)
	{
		Segment2D segment2D = new Segment2D(start, end);
		Point2D b = segment2D.PointAt(segment2D.ClosestPointTo(radial));
		return radial.DistanceTo(b);
	}

	public Curve InterpolateTwoPoints(UClick first, UClick second)
	{
		Point3D point3D = clsItem.frmEditorV2.viewport.CurrentSketch.DrawingPlane.PointAt(first.Position);
		Point3D point3D2 = clsItem.frmEditorV2.viewport.CurrentSketch.DrawingPlane.PointAt(second.Position);
		Vector3D asVector = (point3D2 - point3D).AsVector;
		Vector3D vector3D = Vector3D.Cross(clsItem.frmEditorV2.viewport.CurrentSketch.DrawingPlane.AxisZ, asVector);
		return Curve.LocalInterpolation(new PointTangent[3]
		{
			new PointTangent(point3D.X, point3D.Y, point3D.Z, asVector.X, asVector.Y, asVector.Z),
			new PointTangent(point3D2.X, point3D2.Y, point3D2.Z, vector3D.X, vector3D.Y, vector3D.Z),
			new PointTangent(point3D.X, point3D.Y, point3D.Z, 0.0 - asVector.X, 0.0 - asVector.Y, 0.0 - asVector.Z)
		});
	}

	public void CreateConstraintPointOn(devDept.Eyeshot.Entities.Point pnt, Entity ent)
	{
		clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintPointOn(pnt, ent);
		clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
		JobUpdate();
	}

	public void CreateConstraintVertical(Line line)
	{
		clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintVertical(line);
		clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
		JobUpdate();
	}

	public void CreateConstraintHorizontal(Line line)
	{
		clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintHorizontal(line);
		clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
		JobUpdate();
	}

	public void CreateConstraintLength(Line line, Point2D refPoint)
	{
		clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintLength(line, -1.0, reference: false, refPoint);
		clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
		clsItem.frmEditorV2.viewport.Invalidate();
		JobUpdate();
	}

	public void CreateConstraintLineLineDistance(Line L1, Line L2, Point2D refPoint)
	{
		clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintLinesDistance(L1, L2, -1.0, reference: false, refPoint);
		clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
		clsItem.frmEditorV2.viewport.Invalidate();
		Reset();
		JobUpdate();
	}

	public void CreateConstraintLinePointDistance(devDept.Eyeshot.Entities.Point P1, Line L1, Point2D refPoint)
	{
		clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintPointLineDistance(P1, L1, -1.0, reference: false, refPoint);
		clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
		clsItem.frmEditorV2.viewport.Invalidate();
		Reset();
		JobUpdate();
	}

	public void CreateConstraintPointPointAlignedDistance(devDept.Eyeshot.Entities.Point P1, devDept.Eyeshot.Entities.Point P2, Point2D refPoint)
	{
		clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintAlignedPointsDistance(P1, P2, -1.0, reference: false, refPoint);
		clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
		clsItem.frmEditorV2.viewport.Invalidate();
		Reset();
		JobUpdate();
	}

	public void CreateConstraintPointPointHorizontalDistance(devDept.Eyeshot.Entities.Point P1, devDept.Eyeshot.Entities.Point P2, Point2D refPoint)
	{
		clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintHorizontalPointsDistance(P1, P2, -1.0, reference: false, refPoint);
		clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
		clsItem.frmEditorV2.viewport.Invalidate();
		Reset();
		JobUpdate();
	}

	public void CreateConstraintPointPointVerticalDistance(devDept.Eyeshot.Entities.Point P1, devDept.Eyeshot.Entities.Point P2, Point2D refPoint)
	{
		clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintVerticalPointsDistance(P1, P2, -1.0, reference: false, refPoint);
		clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
		clsItem.frmEditorV2.viewport.Invalidate();
		Reset();
		JobUpdate();
	}

	public void CreateConstraintCollinear(Line L1, Line L2)
	{
		clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintCollinear(L1, L2);
		clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
		for (int i = 0; i <= clsItem.frmEditorV2.viewport.Entities.Count - 1; i++)
		{
			clsItem.frmEditorV2.viewport.Entities[i].Selected = false;
		}
		clsItem.frmEditorV2.viewport.Invalidate();
		Reset();
		JobUpdate();
	}

	public void CreateConstraintParallel(Line L1, Line L2)
	{
		clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintParallelLines(L1, L2);
		clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
		for (int i = 0; i <= clsItem.frmEditorV2.viewport.Entities.Count - 1; i++)
		{
			clsItem.frmEditorV2.viewport.Entities[i].Selected = false;
		}
		clsItem.frmEditorV2.viewport.Invalidate();
		Reset();
		JobUpdate();
	}

	public void CreateConstraintPerpendicular(Line L1, Line L2)
	{
		clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintPerpendicular(L1, L2);
		clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
		for (int i = 0; i <= clsItem.frmEditorV2.viewport.Entities.Count - 1; i++)
		{
			clsItem.frmEditorV2.viewport.Entities[i].Selected = false;
		}
		clsItem.frmEditorV2.viewport.Invalidate();
		Reset();
		JobUpdate();
	}

	public void CreateConstraintTangent(Entity E1, Entity E2)
	{
		clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintTangent(E1, E2);
		clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
		for (int i = 0; i <= clsItem.frmEditorV2.viewport.Entities.Count - 1; i++)
		{
			clsItem.frmEditorV2.viewport.Entities[i].Selected = false;
		}
		clsItem.frmEditorV2.viewport.Invalidate();
		Reset();
		JobUpdate();
	}

	public void CreateConstraintAngle(Arc arc, Point2D refPoint)
	{
		clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintAngle(arc, -1.0, reference: false, refPoint);
		clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
		for (int i = 0; i <= clsItem.frmEditorV2.viewport.Entities.Count - 1; i++)
		{
			clsItem.frmEditorV2.viewport.Entities[i].Selected = false;
		}
		clsItem.frmEditorV2.viewport.Invalidate();
		clsItem.frmEditorV2.viewport.Invalidate();
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
		clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintAngle(L1, L2, refPoint, value);
		clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
		for (int j = 0; j <= clsItem.frmEditorV2.viewport.Entities.Count - 1; j++)
		{
			clsItem.frmEditorV2.viewport.Entities[j].Selected = false;
		}
		clsItem.frmEditorV2.viewport.Invalidate();
		Reset();
		JobUpdate();
	}

	public void CreateConstraintDiameter(Circle line)
	{
		clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintDiameter(line);
		clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
		clsItem.frmEditorV2.viewport.Invalidate();
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
				clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditorV2.viewport.CurrentSketch.EndPoint((Line)Ent));
			}
			if (Ent is Curve)
			{
				clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditorV2.viewport.CurrentSketch.EndPoint((Curve)Ent));
			}
			if (Ent is Arc)
			{
				clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditorV2.viewport.CurrentSketch.EndPoint((Arc)Ent));
			}
			if (Ent is EllipticalArc)
			{
				clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditorV2.viewport.CurrentSketch.EndPoint((EllipticalArc)Ent));
			}
		}
		if (startEndCenterType == StartEndCenterType.Start)
		{
			if (Ent is Line)
			{
				clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditorV2.viewport.CurrentSketch.StartPoint((Line)Ent));
			}
			if (Ent is Curve)
			{
				clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditorV2.viewport.CurrentSketch.StartPoint((Curve)Ent));
			}
			if (Ent is Arc)
			{
				clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditorV2.viewport.CurrentSketch.StartPoint((Arc)Ent));
			}
			if (Ent is EllipticalArc)
			{
				clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditorV2.viewport.CurrentSketch.StartPoint((EllipticalArc)Ent));
			}
		}
		if (startEndCenterType == StartEndCenterType.Center)
		{
			if (Ent is Circle)
			{
				clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditorV2.viewport.CurrentSketch.CenterPoint((Circle)Ent));
			}
			if (Ent is Arc)
			{
				clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditorV2.viewport.CurrentSketch.CenterPoint((Arc)Ent));
			}
			if (Ent is Ellipse)
			{
				clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintPointFixed(clsItem.frmEditorV2.viewport.CurrentSketch.CenterPoint((Ellipse)Ent));
			}
		}
		clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
		clsItem.frmEditorV2.viewport.Invalidate();
		JobUpdate();
	}

	public void CreateConstraintEqualLength(Entity FirstEntity, Entity SecondEntity, bool Radius)
	{
		clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintEqual(FirstEntity, SecondEntity, Radius);
		clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
		for (int i = 0; i <= clsItem.frmEditorV2.viewport.Entities.Count - 1; i++)
		{
			clsItem.frmEditorV2.viewport.Entities[i].Selected = false;
		}
		clsItem.frmEditorV2.viewport.Invalidate();
		JobUpdate();
	}

	public void ShowValueArea(actionTypeBU Command, bool Show, int Width, int Height, string Caption = "", double Value = 0.0, double MinVal = -1000000.0, double MaxVal = 10000000.0, int Decimal = 2, bool ButtonShow = false)
	{
		if (Command != actionTypeBU.eventFillet)
		{
			if (Command != actionTypeBU.eventChamfer)
			{
				if (Command != actionTypeBU.eventExplode)
				{
					if (Command != actionTypeBU.eventScale)
					{
						if (Command != actionTypeBU.eventExtend)
						{
							if (Command == actionTypeBU.eventOffset)
							{
								clsItem.frmEditorV2.buTab_EventVals.SelectedIndex = 5;
								clsItem.frmEditorV2.chk_offsetbymouse.Check = clsVar.varEditorSet.OffsetByMouse;
							}
						}
						else
						{
							clsItem.frmEditorV2.buTab_EventVals.SelectedIndex = 4;
						}
					}
					else
					{
						clsItem.frmEditorV2.buTab_EventVals.SelectedIndex = 3;
					}
				}
				else
				{
					clsItem.frmEditorV2.buTab_EventVals.SelectedIndex = 2;
				}
			}
			else
			{
				clsItem.frmEditorV2.buTab_EventVals.SelectedIndex = 1;
			}
		}
		else
		{
			clsItem.frmEditorV2.buTab_EventVals.SelectedIndex = 0;
		}
		clsItem.frmEditorV2.btn_eventok.Visible = ButtonShow;
		clsItem.frmEditorV2.grp_events.BringToFront();
		clsItem.frmEditorV2.grp_events.Text = Caption;
		clsItem.frmEditorV2.grp_events.Visible = Show;
		clsItem.frmEditorV2.spn_filletrad.MinValue = MinVal;
		clsItem.frmEditorV2.spn_filletrad.MaxValue = MaxVal;
		clsItem.frmEditorV2.spn_filletrad.DecimalPoint = Decimal;
		clsItem.frmEditorV2.spn_filletrad.Value = Value;
		if (Width > 10)
		{
			clsItem.frmEditorV2.grp_events.Width = Width;
		}
		if (Height > 10)
		{
			clsItem.frmEditorV2.grp_events.Height = Height;
		}
		clsItem.frmEditorV2.grp_events.Top = clsItem.frmEditorV2.Height - clsItem.frmEditorV2.grp_events.Height - (clsItem.frmEditorV2.buTab_menu.Top + clsItem.frmEditorV2.buTab_menu.Height) - clsItem.frmEditorV2.buGround1.Ground.BottomHeight - 10;
		clsItem.frmEditorV2.grp_events.Left = 10;
	}

	public void ShowValueArea(bool Show, string Caption = "", double Value = 0.0, double MinVal = -1000000.0, double MaxVal = 10000000.0, int Decimal = 2)
	{
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
		{
			clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditorV2.viewport.Entities, Clone: false, ref Sketcher2D.entitiesSelected);
		}
		if (Sketcher2D.entitiesSelected.Count > 0)
		{
			UndoBuffer();
			clsInit.cVector5.BoxSizeCalculate(Sketcher2D.entitiesSelected, ref MinPoint, ref MidPoint, ref MaxPoint);
			for (int i = 0; i <= clsItem.frmEditorV2.viewport.Entities.Count - 1; i++)
			{
				Entity entity = clsItem.frmEditorV2.viewport.Entities[i];
				if (entity.Selected)
				{
					entity.Rotate(buConversion5.DegreeToRadian(Degree), Vector3D.AxisZ, MidPoint);
				}
			}
			clsItem.frmEditorV2.viewport.Entities.RegenAllCurved(0.02);
		}
		clsItem.frmEditorV2.viewport.Invalidate();
		Reset();
	}

	public void Mirror(HorizontalVertical Value)
	{
		Point3D MinPoint = new Point3D();
		Point3D MidPoint = new Point3D();
		Point3D MaxPoint = new Point3D();
		if (Sketcher2D.entitiesSelected.Count == 0)
		{
			clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditorV2.viewport.Entities, Clone: false, ref Sketcher2D.entitiesSelected);
		}
		clsInit.cVector5.BoxSizeCalculate(Sketcher2D.entitiesSelected, ref MinPoint, ref MidPoint, ref MaxPoint);
		if (Sketcher2D.entitiesSelected.Count > 0)
		{
			UndoBuffer();
			Vector3D vector3D = null;
			Plane plane = new Plane(X: (Value == HorizontalVertical.Vertical) ? new Vector3D(MidPoint, new Point3D(MidPoint.X + 10.0, MidPoint.Y, MidPoint.Z)) : new Vector3D(MidPoint, new Point3D(MidPoint.X, MidPoint.Y + 10.0, MidPoint.Z)), P: MidPoint, Y: Vector3D.AxisZ);
			Mirror xform = new Mirror(plane);
			for (int i = 0; i <= clsItem.frmEditorV2.viewport.Entities.Count - 1; i++)
			{
				Entity entity = clsItem.frmEditorV2.viewport.Entities[i];
				if (entity.Selected)
				{
					entity.TransformBy(xform);
				}
			}
			clsItem.frmEditorV2.viewport.Entities.RegenAllCurved();
		}
		clsItem.frmEditorV2.viewport.Invalidate();
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
			clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditorV2.viewport.Entities, Clone: false, ref Sketcher2D.entitiesSelected);
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
			clsItem.frmEditorV2.viewport.Entities.Add(refEntities[j]);
		}
		clsItem.frmEditorV2.viewport.Entities.RegenAllCurved(0.01);
		Reset();
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

	public List<Point3D> ClicksToPoints(List<UClick> Clicks)
	{
		List<Point3D> list = new List<Point3D>();
		for (int i = 0; i <= Clicks.Count - 1; i++)
		{
			list.Add(new Point3D(Clicks[i].Position.X, Clicks[i].Position.Y, 0.0));
		}
		return list;
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
		clsItem.frmEditorV2.viewport.Entities.Clear();
		for (int i = 0; i <= bufferedEntity.Count - 1; i++)
		{
			for (int j = 0; j <= bufferedEntity[i].Count - 1; j++)
			{
				Entity copiedEntity = null;
				buEntity.Copy(bufferedEntity[i][j], ref copiedEntity);
				if (copiedEntity != null)
				{
					clsItem.frmEditorV2.viewport.Entities.Add(copiedEntity);
				}
			}
		}
		clsItem.frmEditorV2.viewport.Entities.RegenAllCurved();
		clsItem.frmEditorV2.viewport.Invalidate();
		bufferedEntity.RemoveAt(bufferedEntity.Count - 1);
	}

	public void UndoBuffer()
	{
		if (bufferedEntity.Count > 100)
		{
			bufferedEntity.RemoveAt(bufferedEntity.Count - 1);
		}
		List<Entity> list = new List<Entity>();
		for (int i = 0; i <= clsItem.frmEditorV2.viewport.Entities.Count - 1; i++)
		{
			Entity entity = (Entity)clsItem.frmEditorV2.viewport.Entities[i].Clone();
			if (entity != null)
			{
				list.Add(entity);
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
		clsItem.frmEditorV2.viewport.Entities.ClearSelection();
		if (SelectedConstraint >= 0)
		{
			VisualConstraint visualConstraint = clsItem.frmEditorV2.viewport.CurrentSketch.Constraints[SelectedConstraint];
			if (visualConstraint.ConstraintDimension != null)
			{
				visualConstraint.ConstraintDimension.Selected = true;
			}
			UpdateCommandInfo(new EditorCustomData());
		}
		if (SelectedDrawing >= 0)
		{
			clsItem.frmEditorV2.viewport.Entities[SelectedDrawing].Selected = true;
			if (clsItem.frmEditorV2.viewport.Entities[SelectedDrawing].EntityData != null && clsItem.frmEditorV2.viewport.Entities[SelectedDrawing].EntityData is EditorCustomData)
			{
				EditorCustomData cD = clsItem.frmEditorV2.viewport.Entities[SelectedDrawing].EntityData as EditorCustomData;
				UpdateCommandInfo(cD);
			}
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
		if (clsItem.frmEditorV2.viewport.ActionMode != actionType.SelectByBox)
		{
			if (indexDrawing >= 0)
			{
				if (clsItem.frmEditorV2.viewport.Entities[indexDrawing].EntityData == null)
				{
					EditorCustomData editorCustomData = new EditorCustomData();
					editorCustomData.Commands.Add(Command);
					clsItem.frmEditorV2.viewport.Entities[indexDrawing].EntityData = editorCustomData;
					UpdateCommandInfo(editorCustomData);
				}
				else if (!(clsItem.frmEditorV2.viewport.Entities[indexDrawing].EntityData is EditorCustomData))
				{
					EditorCustomData editorCustomData2 = new EditorCustomData();
					editorCustomData2.Commands.Add(Command);
					clsItem.frmEditorV2.viewport.Entities[indexDrawing].EntityData = editorCustomData2;
					UpdateCommandInfo(editorCustomData2);
				}
				else
				{
					EditorCustomData editorCustomData3 = clsItem.frmEditorV2.viewport.Entities[indexDrawing].EntityData as EditorCustomData;
					editorCustomData3.Commands.Add(Command);
					UpdateCommandInfo(editorCustomData3);
				}
			}
			return;
		}
		for (int i = 0; i <= clsItem.frmEditorV2.viewport.Entities.Count - 1; i++)
		{
			if (clsItem.frmEditorV2.viewport.Entities[i].Selected & (clsItem.frmEditorV2.viewport.Entities[i] is ICurve) & (clsItem.frmEditorV2.viewport.Entities[i].GetType() != typeof(devDept.Eyeshot.Entities.Point)))
			{
				if (clsItem.frmEditorV2.viewport.Entities[i].EntityData == null)
				{
					EditorCustomData editorCustomData4 = new EditorCustomData();
					editorCustomData4.Commands.Add(Command);
					clsItem.frmEditorV2.viewport.Entities[i].EntityData = editorCustomData4;
					UpdateCommandInfo(editorCustomData4);
				}
				else if (!(clsItem.frmEditorV2.viewport.Entities[i].EntityData is EditorCustomData))
				{
					EditorCustomData editorCustomData5 = new EditorCustomData();
					editorCustomData5.Commands.Add(Command);
					clsItem.frmEditorV2.viewport.Entities[i].EntityData = editorCustomData5;
					UpdateCommandInfo(editorCustomData5);
				}
				else
				{
					EditorCustomData editorCustomData6 = clsItem.frmEditorV2.viewport.Entities[i].EntityData as EditorCustomData;
					editorCustomData6.Commands.Add(Command);
					UpdateCommandInfo(editorCustomData6);
				}
			}
		}
		JobUpdate();
	}

	public void RemoveCommandFromDrawing(int indexCommand, int indexDrawing)
	{
		if (indexDrawing >= 0 && indexCommand >= 0 && clsItem.frmEditorV2.viewport.Entities[indexDrawing].EntityData != null && clsItem.frmEditorV2.viewport.Entities[indexDrawing].EntityData is EditorCustomData)
		{
			EditorCustomData editorCustomData = clsItem.frmEditorV2.viewport.Entities[indexDrawing].EntityData as EditorCustomData;
			editorCustomData.Commands.RemoveAt(indexCommand);
			UpdateCommandInfo(editorCustomData);
		}
	}

	public void FileOpened()
	{
		if (clsItem.frmEditorV2.viewport.Entities.Count > 0)
		{
			if (clsItem.frmEditorV2.viewport.Entities[0] is SketchEntity)
			{
				SketchEntity sketchEntity = clsItem.frmEditorV2.viewport.Entities[0] as SketchEntity;
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
				sketchEntity.Edit(clsItem.frmEditorV2.viewport);
				clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
			}
			Class5.smethod_199(this);
			Class5.smethod_44(this);
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

	public void SaveEditorFile(string FileName)
	{
		try
		{
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
			buFile.SaveToFile(arrayList, FileName);
			buLog.addLog("Editor Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void OpenEditorFile(string FileName)
	{
		try
		{
			ArrayList arrayList = new ArrayList();
			FileInfo fileInfo = new FileInfo(FileName);
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
		for (int i = 0; i <= clsItem.frmEditorV2.viewport.Entities.Count - 1; i++)
		{
			buEntity copiedEntity = null;
			buEntity.Copy(clsItem.frmEditorV2.viewport.Entities[i], ref copiedEntity);
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
		Drafting2D.selectedIndex.Clear();
		clsItem.frmEditorV2.viewport.Entities.UpdateBoundingBox();
		clsItem.frmEditorV2.viewport.Entities.ClearSelection();
		for (int i = 0; i <= clsItem.frmEditorV2.viewport.Entities.Count - 1; i++)
		{
			clsItem.frmEditorV2.viewport.Entities[i].Selectable = true;
		}
		clsItem.frmEditorV2.viewport.Invalidate();
		Drafting2D.selectionProcess = true;
		Drafting2D.points.Clear();
		Drafting2D.entitySelected = null;
		if (Drafting2D.entitiesSelected != null)
		{
			Drafting2D.entitiesSelected.Clear();
		}
		clsInit.appEditor2.action = actionTypeBU.None;
		StatusUpdate("", "");
		ShowCheckArea(Show: false, Checked: false);
		ShowValueArea(Show: false);
		clsItem.frmEditorV2.viewport.Invalidate();
	}
}
