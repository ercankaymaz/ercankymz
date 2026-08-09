using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buControls.DialogBox;
using buEyeBaseVer5;
using buEyeBaseVer5.Forms.Library;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;

namespace buCadCamResVer5.Library;

public class clsLibrary
{
	public bool SketchEnabled = false;

	private Sketch sketch_0 = new Sketch();

	private SketchEntity sketchEntity_0 = null;

	public LibraryManager LibManager = null;

	public List<Entity> LoadedEntities = null;

	public List<VisualConstraint> Constraints = null;

	public static List<buEntity> LibraryEntities;

	public void Init()
	{
		LibManager = new LibraryManager();
	}

	public void cmdAddChar()
	{
		try
		{
			if (!clsVar.appModes_0.DemoMode)
			{
				clsInit.appCommand.Reset(ClearSelection: false);
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
				ccVars.Action = actionTypeBU.libCharCreat;
				dynamicInfo.Command = AppLanguage.CadCamCommand[108];
				ccVars.selectionProcess = true;
				if (ccVars.SelectionOP.Selections.Count != 0)
				{
					doAddChar();
					return;
				}
				ccVars.stpDrawing = 1;
				ccVars.selectionProcess = true;
				clsInit.appCommand.cmdMainFormStatusUpdate(AppLanguage.CadCamStatus[107] + " [ " + dynamicInfo.Command + " ]");
			}
			else
			{
				MessageBox.Show("Not Available in Demo Mode");
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public void cmdShowCharList()
	{
		F_CharList f_CharList = new F_CharList();
		CharLibrary5.Copy(ccVars.CharLibList, ref f_CharList.Chars);
		f_CharList.Init();
		f_CharList.ShowDialog(clsItem.FrmMain);
		if (f_CharList.Properties.Result == DialogResult.OK)
		{
			CharLibrary5.Copy(f_CharList.Chars, ref ccVars.CharLibList);
		}
	}

	public void cmdOpenCharList()
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = "Char File (*.buchar)|*.buchar";
		openFileDialog.InitialDirectory = clsVar.varInterface.pathChar;
		openFileDialog.FilterIndex = 1;
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			for (int i = 0; i <= ccVars.CharLibList.Count - 1; i++)
			{
				Point3D MinPoint = new Point3D();
				Point3D MaxPoint = new Point3D();
				clsInit.cVector5.BoxSizeCalculate(ccVars.CharLibList[i].CharEntities, ref MinPoint, ref MaxPoint);
				clsInit.cVector5.Move(0.0 - MinPoint.X, 0.0 - MinPoint.Y, 0.0, ref ccVars.CharLibList[i].CharEntities);
			}
			clsVar.varInterface.pathChar = buFile5.GetPath(openFileDialog.FileName);
			ArrayList StringList = new ArrayList();
			buFile5.OpenFromFile(openFileDialog.FileName, ref StringList);
			ccVars.CharLibList.Clear();
			CharLibrary5.Decode(StringList, ref ccVars.CharLibList);
			clsFiles.SaveParameter();
		}
	}

	public void cmdSaveCharList()
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.Filter = "Char File (*.buchar)|*.buchar";
		saveFileDialog.InitialDirectory = clsVar.varInterface.pathChar;
		saveFileDialog.FilterIndex = 1;
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			for (int i = 0; i <= ccVars.CharLibList.Count - 1; i++)
			{
				Point3D MinPoint = new Point3D();
				Point3D MaxPoint = new Point3D();
				clsInit.cVector5.BoxSizeCalculate(ccVars.CharLibList[i].CharEntities, ref MinPoint, ref MaxPoint);
				clsInit.cVector5.Move(0.0 - MinPoint.X, 0.0 - MinPoint.Y, 0.0, ref ccVars.CharLibList[i].CharEntities);
			}
			clsVar.varInterface.pathChar = buFile5.GetPath(saveFileDialog.FileName);
			ArrayList arrayList = new ArrayList();
			arrayList = CharLibrary5.ToDef(ccVars.CharLibList, 2);
			buFile5.SaveToFile(arrayList, saveFileDialog.FileName);
			clsFiles.SaveParameter();
		}
	}

	public void cmdEnableSketcher()
	{
		Constraints = new List<VisualConstraint>();
		LoadedEntities = new List<Entity>();
		LibManager = new LibraryManager();
	}

	public void cmdLibFix()
	{
		clsInit.appCommand.Reset();
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
		ccVars.Action = actionTypeBU.libraryFixPoint;
		ccVars.stpDrawing = 1;
		ccVars.selectionProcess = true;
	}

	public void cmdLibHorizontal()
	{
		if (ccVars.SelectionOP.Selections.Count != 0)
		{
			ccVars.Action = actionTypeBU.libraryHorizontal;
			doAddConstraints(new Point3D());
			return;
		}
		clsInit.appCommand.Reset(ClearSelection: false);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
		ccVars.Action = actionTypeBU.libraryHorizontal;
		ccVars.stpDrawing = 1;
		ccVars.selectionProcess = true;
	}

	public void cmdLibVertical()
	{
		if (ccVars.SelectionOP.Selections.Count != 0)
		{
			ccVars.Action = actionTypeBU.libraryVertical;
			doAddConstraints(new Point3D());
			return;
		}
		clsInit.appCommand.Reset(ClearSelection: false);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
		ccVars.Action = actionTypeBU.libraryVertical;
		ccVars.stpDrawing = 1;
		ccVars.selectionProcess = true;
	}

	public void cmdLibEqualLen()
	{
		if (ccVars.SelectionOP.Selections.Count >= 2)
		{
			ccVars.Action = actionTypeBU.libraryEqualLength;
			doAddConstraints(new Point3D());
			return;
		}
		clsInit.appCommand.Reset(ClearSelection: false);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
		ccVars.Action = actionTypeBU.libraryEqualLength;
		ccVars.stpDrawing = 1;
		ccVars.selectionProcess = true;
	}

	public void cmdLibParalel()
	{
		if (ccVars.SelectionOP.Selections.Count >= 2)
		{
			ccVars.Action = actionTypeBU.libraryParalel;
			doAddConstraints(new Point3D());
			return;
		}
		clsInit.appCommand.Reset(ClearSelection: false);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
		ccVars.Action = actionTypeBU.libraryParalel;
		ccVars.stpDrawing = 1;
		ccVars.selectionProcess = true;
	}

	public void cmdLibPerpendicular()
	{
		if (ccVars.SelectionOP.Selections.Count >= 2)
		{
			ccVars.Action = actionTypeBU.libraryPerpendiculat;
			doAddConstraints(new Point3D());
			return;
		}
		clsInit.appCommand.Reset(ClearSelection: false);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
		ccVars.Action = actionTypeBU.libraryPerpendiculat;
		ccVars.stpDrawing = 1;
		ccVars.selectionProcess = true;
	}

	public void cmdLibCollinear()
	{
		if (ccVars.SelectionOP.Selections.Count >= 2)
		{
			ccVars.Action = actionTypeBU.libraryCollinear;
			doAddConstraints(new Point3D());
			return;
		}
		clsInit.appCommand.Reset(ClearSelection: false);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
		ccVars.Action = actionTypeBU.libraryCollinear;
		ccVars.stpDrawing = 1;
		ccVars.selectionProcess = true;
	}

	public void cmdLibTangent()
	{
		if (ccVars.SelectionOP.Selections.Count >= 2)
		{
			ccVars.Action = actionTypeBU.libraryTangent;
			doAddConstraints(new Point3D());
			return;
		}
		clsInit.appCommand.Reset(ClearSelection: false);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
		ccVars.Action = actionTypeBU.libraryTangent;
		ccVars.stpDrawing = 1;
		ccVars.selectionProcess = true;
	}

	public void cmdLibEqualRad()
	{
		if (ccVars.SelectionOP.Selections.Count >= 2)
		{
			ccVars.Action = actionTypeBU.libraryEqualRadius;
			doAddConstraints(new Point3D());
			return;
		}
		clsInit.appCommand.Reset(ClearSelection: false);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
		ccVars.Action = actionTypeBU.libraryEqualRadius;
		ccVars.stpDrawing = 1;
		ccVars.selectionProcess = true;
	}

	public void cmdLibLength()
	{
		if (ccVars.SelectionOP.Selections.Count != 0)
		{
			ccVars.Action = actionTypeBU.libraryLength;
			doAddConstraints(new Point3D());
			return;
		}
		clsInit.appCommand.Reset(ClearSelection: false);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
		ccVars.Action = actionTypeBU.libraryLength;
		ccVars.stpDrawing = 1;
		ccVars.selectionProcess = true;
	}

	public void cmdLibRadius()
	{
		if (ccVars.SelectionOP.Selections.Count != 0)
		{
			ccVars.Action = actionTypeBU.libraryRadius;
			doAddConstraints(new Point3D());
			return;
		}
		clsInit.appCommand.Reset(ClearSelection: false);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
		ccVars.Action = actionTypeBU.libraryRadius;
		ccVars.stpDrawing = 1;
		ccVars.selectionProcess = true;
	}

	public void cmdLibAngle()
	{
		if (ccVars.SelectionOP.Selections.Count >= 2)
		{
			ccVars.Action = actionTypeBU.libraryAngle;
			doAddConstraints(new Point3D());
			return;
		}
		clsInit.appCommand.Reset(ClearSelection: false);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
		ccVars.Action = actionTypeBU.libraryAngle;
		ccVars.stpDrawing = 1;
		ccVars.selectionProcess = true;
	}

	public void cmdLibLineLine()
	{
		if (ccVars.SelectionOP.Selections.Count >= 2)
		{
			ccVars.Action = actionTypeBU.libraryLineLine;
			doAddConstraints(new Point3D());
			return;
		}
		clsInit.appCommand.Reset(ClearSelection: false);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
		ccVars.Action = actionTypeBU.libraryLineLine;
		ccVars.stpDrawing = 1;
		ccVars.selectionProcess = true;
	}

	public void cmdLibLinePoint()
	{
		if (ccVars.SelectionOP.Selections.Count >= 2)
		{
			ccVars.Action = actionTypeBU.libraryLinePoint;
			doAddConstraints(new Point3D());
			return;
		}
		clsInit.appCommand.Reset(ClearSelection: false);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
		ccVars.Action = actionTypeBU.libraryLinePoint;
		ccVars.stpDrawing = 1;
		ccVars.selectionProcess = true;
	}

	public void cmdLibPointPoint()
	{
		if (ccVars.SelectionOP.Selections.Count >= 2)
		{
			ccVars.Action = actionTypeBU.libraryPointPoint;
			doAddConstraints(new Point3D());
			return;
		}
		clsInit.appCommand.Reset(ClearSelection: false);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
		ccVars.Action = actionTypeBU.libraryPointPoint;
		ccVars.stpDrawing = 1;
		ccVars.selectionProcess = true;
	}

	public void cmdLibSaveFile(Design Viewport)
	{
		if (!clsVar.appModes_0.DemoMode)
		{
			if (ccVars.Pages.Count <= 0)
			{
				return;
			}
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.InitialDirectory = clsVar.varLibrary.pathLibrary;
			saveFileDialog.Filter = "buCad/Cam Library File (*.bulib5)|*.bulib5";
			saveFileDialog.FilterIndex = 1;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				List<buEntity> copiedEntities = new List<buEntity>();
				if (Viewport.CurrentSketch.Editing)
				{
					Viewport.CurrentSketch.Exit();
				}
				buEntity.Copy(Viewport.Entities.ToList(), ref copiedEntities);
				SaveLibraryFile(saveFileDialog.FileName, copiedEntities, LibManager);
				clsVar.varLibrary.pathLibrary = buFile5.GetPath(saveFileDialog.FileName);
				clsFiles.SaveParameter();
			}
		}
		else
		{
			MessageBox.Show("You can't save in Demo Mode");
		}
	}

	public void cmdLibSaveFile()
	{
		if (!clsVar.appModes_0.DemoMode)
		{
			if (ccVars.Pages.Count > 0)
			{
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.InitialDirectory = clsVar.varLibrary.pathLibrary;
				saveFileDialog.Filter = "buCad/Cam Library File (*.bulib5)|*.bulib5";
				saveFileDialog.FilterIndex = 1;
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					List<buEntity> copiedEntities = new List<buEntity>();
					buEntity.Copy(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.ToList(), ref copiedEntities);
					SaveLibraryFile(saveFileDialog.FileName, copiedEntities, LibManager);
					clsVar.varLibrary.pathLibrary = buFile5.GetPath(saveFileDialog.FileName);
					clsFiles.SaveParameter();
				}
			}
		}
		else
		{
			MessageBox.Show("You can't save in Demo Mode");
		}
	}

	public void OpenLibraryFile(string FileName, ref LibraryManager Manager)
	{
		ArrayList StringList = new ArrayList();
		List<string> CalcList = new List<string>();
		List<List<string>> CalcList2 = new List<List<string>>();
		buFile5.OpenFromFile(FileName, ref StringList);
		buString5.ListToSpecificList("<LibraryEntities>", "</LibraryEntities>", AddStartEndKey: true, StringList, ref CalcList);
		LibManager = new LibraryManager();
		buStatics.ListToSpecificList("<buEntity>", "</buEntity>", AddStartEndKey: false, CalcList, ref CalcList2);
		for (int i = 0; i <= CalcList2.Count - 1; i++)
		{
			buEntity buEntity2 = buEntity.Decode(CalcList2[i]);
			if (buEntity2 != null)
			{
				LibManager.Entities.Add(buEntity2);
			}
		}
		CalcList = new List<string>();
		buString5.ListToSpecificList("<LibraryManager>", "</LibraryManager>", AddStartEndKey: true, StringList, ref CalcList);
		LibraryManager.Decode(CalcList, ref LibManager);
	}

	public void SaveLibraryFile(string FileName, List<buEntity> Entities, LibraryManager Manager)
	{
		FileInfo fileInfo = new FileInfo(FileName);
		if (fileInfo.Extension.ToLower() == ".bulib5")
		{
			ArrayList arrayList = new ArrayList();
			arrayList.Add("<LibraryEntities>");
			arrayList.AddRange(buEntity.ToDefEntity(Entities, 2));
			arrayList.Add("</LibraryEntities>");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Library Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("<LibraryManager>");
			arrayList.AddRange(LibraryManager.ToDef(Manager));
			arrayList.Add("</LibraryManager>");
			buFile5.SaveToFile(arrayList, FileName);
		}
	}

	public bool doFindReleatedPoint(List<buEntity> refEntities, Point3D refPoint, ref int indexFound, ref StartEndCenterType foundPointType)
	{
		for (int i = 0; i <= refEntities.Count - 1; i++)
		{
			if ((refEntities[i] is buLine) | (refEntities[i] is buArc) | (refEntities[i] is buCurve))
			{
				if (buCompare5.EQ(refPoint, refEntities[i].EndPoint))
				{
					foundPointType = StartEndCenterType.End;
					indexFound = i;
					return true;
				}
				if (buCompare5.EQ(refPoint, refEntities[i].StartPoint))
				{
					foundPointType = StartEndCenterType.End;
					indexFound = i;
					return true;
				}
			}
			if (!(refEntities[i] is buCircle) || !buCompare5.EQ(refPoint, ((buCircle)refEntities[i]).Center))
			{
				if (!(refEntities[i] is buArc) || !buCompare5.EQ(refPoint, ((buArc)refEntities[i]).Center))
				{
					if (refEntities[i] is buEllipse && buCompare5.EQ(refPoint, ((buEllipse)refEntities[i]).Center))
					{
						foundPointType = StartEndCenterType.Center;
						indexFound = i;
						return true;
					}
					continue;
				}
				foundPointType = StartEndCenterType.Center;
				indexFound = i;
				return true;
			}
			foundPointType = StartEndCenterType.Center;
			indexFound = i;
			return true;
		}
		return false;
	}

	public void doAddConstraints(Point3D firstPoint, Point3D secondPoint = null)
	{
		if (ccVars.Action == actionTypeBU.libraryHorizontal)
		{
			for (int i = 0; i <= ccVars.SelectionOP.Selections.Count - 1; i++)
			{
				LibraryConstraints libraryConstraints = new LibraryConstraints();
				libraryConstraints.Type = ConstraintsType.Horizontal;
				libraryConstraints.FirstIndex = ccVars.SelectionOP.Selections[i].Index;
				LibManager.ConstraintList.Add(libraryConstraints);
			}
		}
		if (ccVars.Action == actionTypeBU.libraryVertical)
		{
			for (int j = 0; j <= ccVars.SelectionOP.Selections.Count - 1; j++)
			{
				LibraryConstraints libraryConstraints2 = new LibraryConstraints();
				libraryConstraints2.Type = ConstraintsType.Vertical;
				libraryConstraints2.FirstIndex = ccVars.SelectionOP.Selections[j].Index;
				LibManager.ConstraintList.Add(libraryConstraints2);
			}
		}
		if (ccVars.Action == actionTypeBU.libraryLength)
		{
			for (int k = 0; k <= ccVars.SelectionOP.Selections.Count - 1; k++)
			{
				LibraryConstraints libraryConstraints3 = new LibraryConstraints();
				libraryConstraints3.Type = ConstraintsType.Length;
				libraryConstraints3.FirstIndex = ccVars.SelectionOP.Selections[k].Index;
				LibManager.ConstraintList.Add(libraryConstraints3);
			}
		}
		if (ccVars.Action == actionTypeBU.libraryRadius)
		{
			for (int l = 0; l <= ccVars.SelectionOP.Selections.Count - 1; l++)
			{
				LibraryConstraints libraryConstraints4 = new LibraryConstraints();
				libraryConstraints4.Type = ConstraintsType.Radius;
				libraryConstraints4.FirstIndex = ccVars.SelectionOP.Selections[l].Index;
				LibManager.ConstraintList.Add(libraryConstraints4);
			}
		}
		if (ccVars.Action == actionTypeBU.libraryLineLine && ccVars.SelectionOP.Selections.Count >= 2)
		{
			LibraryConstraints libraryConstraints5 = new LibraryConstraints();
			libraryConstraints5.Type = ConstraintsType.LineLine;
			libraryConstraints5.FirstIndex = ccVars.SelectionOP.Selections[0].Index;
			libraryConstraints5.SecondIndex = ccVars.SelectionOP.Selections[1].Index;
			LibManager.ConstraintList.Add(libraryConstraints5);
		}
		if (ccVars.Action == actionTypeBU.libraryLinePoint && ccVars.SelectionOP.Selections.Count >= 1)
		{
			LibraryConstraints libraryConstraints6 = new LibraryConstraints();
			libraryConstraints6.Type = ConstraintsType.LinePoint;
			libraryConstraints6.FirstIndex = ccVars.SelectionOP.Selections[0].Index;
			libraryConstraints6.refPoint = new Point3D(firstPoint.X, firstPoint.Y, firstPoint.Z);
			LibManager.ConstraintList.Add(libraryConstraints6);
		}
		if (ccVars.Action == actionTypeBU.libraryLinePoint && ccVars.SelectionOP.Selections.Count >= 1)
		{
			LibraryConstraints libraryConstraints7 = new LibraryConstraints();
			libraryConstraints7.Type = ConstraintsType.LinePoint;
			libraryConstraints7.FirstIndex = ccVars.SelectionOP.Selections[0].Index;
			libraryConstraints7.refPoint = new Point3D(firstPoint.X, firstPoint.Y, firstPoint.Z);
			LibManager.ConstraintList.Add(libraryConstraints7);
		}
		if (ccVars.Action == actionTypeBU.libraryEqualLength && ccVars.SelectionOP.Selections.Count >= 2)
		{
			LibraryConstraints libraryConstraints8 = new LibraryConstraints();
			libraryConstraints8.Type = ConstraintsType.EqualLength;
			libraryConstraints8.FirstIndex = ccVars.SelectionOP.Selections[0].Index;
			libraryConstraints8.SecondIndex = ccVars.SelectionOP.Selections[1].Index;
			LibManager.ConstraintList.Add(libraryConstraints8);
		}
		if (ccVars.Action == actionTypeBU.libraryFixPoint)
		{
			LibraryConstraints libraryConstraints9 = new LibraryConstraints();
			libraryConstraints9.Type = ConstraintsType.FixPoint;
			libraryConstraints9.refPoint = new Point3D(firstPoint.X, firstPoint.Y, firstPoint.Z);
			if (ccVars.SelectionOP.Selections.Count >= 1)
			{
				libraryConstraints9.FirstIndex = ccVars.SelectionOP.Selections[0].Index;
			}
			if (ccVars.SelectionOP.Selections.Count >= 2)
			{
				libraryConstraints9.SecondIndex = ccVars.SelectionOP.Selections[1].Index;
			}
			LibManager.ConstraintList.Add(libraryConstraints9);
		}
		clsInit.appCommand.Reset();
	}

	public void doAddLine(Point3D pntStart, Point3D pntEnd)
	{
		Line line = new Line(Plane.XY, new Point2D(pntStart.X, pntStart.Y), new Point2D(pntEnd.X, pntEnd.Y));
		line.LayerName = "General";
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.CurrentSketch.AddLine(line);
		Point2D point2D = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.CurrentSketch.Plane.Project(pntStart);
		Point2D point2D2 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.CurrentSketch.Plane.Project(pntEnd);
		if (Math.Abs(point2D.X - point2D2.X) < 1E-09 && Math.Abs(point2D.Y - point2D2.Y) < 1E-09)
		{
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.CurrentSketch.UpdateAndInvalidate();
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.UpdateBoundingBox();
		_ = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count;
	}

	public void doCreateEntitiesFromCustomText(string Text, double CharSpace, double SpaceValue, double CharHeight, ref List<buEntity> TextEntities)
	{
		try
		{
			TextEntities.Clear();
			TextEntities = new List<buEntity>();
			double num = 1.0;
			if (Text.Length <= 0)
			{
				return;
			}
			char[] array = Text.ToCharArray();
			double num2 = 0.0;
			if (array == null)
			{
				return;
			}
			for (int i = 0; i <= array.Length - 1; i++)
			{
				bool flag = false;
				List<buEntity> copiedEntities = new List<buEntity>();
				for (int j = 0; j <= ccVars.CharLibList.Count - 1; j++)
				{
					string text = array[i].ToString();
					if (text == ccVars.CharLibList[j].Char)
					{
						buEntity.Copy(ccVars.CharLibList[j].CharEntities, ref copiedEntities);
						j = 2147483645;
					}
					if (text == " ")
					{
						flag = true;
					}
				}
				if (!flag)
				{
					if (copiedEntities.Count <= 0)
					{
						num2 += SpaceValue;
						continue;
					}
					Point3D MinPoint = new Point3D();
					Point3D MaxPoint = new Point3D();
					clsInit.cVector5.BoxSizeCalculate(copiedEntities, ref MinPoint, ref MaxPoint);
					double num3 = MaxPoint.Y - MinPoint.Y;
					if ((num3 > 0.0 && CharHeight > 0.0) & (TextEntities.Count == 0))
					{
						num = CharHeight / num3;
					}
					clsInit.cVector5.Scale(MinPoint, num, num, 1.0, ref copiedEntities);
					clsInit.cVector5.Move(num2 - MinPoint.X, 0.0 - MinPoint.Y, 0.0 - MinPoint.Z, ref copiedEntities);
					clsInit.cVector5.BoxSizeCalculate(copiedEntities, ref MinPoint, ref MaxPoint);
					SortbuSettings sortbuSettings = new SortbuSettings();
					sortbuSettings.Option.NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
					List<buEntity> SortedEntities = new List<buEntity>();
					clsInit.cVector5.SortEntitiesByRefPoint(copiedEntities[0].Vertices[0], ref copiedEntities, sortbuSettings, ref SortedEntities);
					List<List<buEntity>> SplitedEntitites = new List<List<buEntity>>();
					clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites);
					for (int k = 0; k <= SplitedEntitites.Count - 1; k++)
					{
						List<Point3D> Points = new List<Point3D>();
						clsInit.cVector5.EntitiesToPointsWithCamDirection(SplitedEntitites[k], 0.01, ref Points);
						if (Points.Count != 2)
						{
							if (Points.Count > 2)
							{
								TextEntities.Add(new buLinearPath(Points));
							}
						}
						else
						{
							TextEntities.Add(new buLine(Points[0], Points[1]));
						}
					}
					num2 = MaxPoint.X + CharSpace;
				}
				else
				{
					num2 += SpaceValue;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void doDimensionEntities(ref List<buEntity> DrawEntities, buEntity DimEntities, double NewValue)
	{
		int num = -1;
		int num2 = -1;
		int indexEntity = -1;
		double num3 = 0.0;
		double num4 = 0.0;
		buEntity copiedEntity = null;
		Point3D point3D = null;
		Point3D point3D2 = null;
		if (DimEntities.Dimension != null)
		{
			num = DimEntities.Dimension.ReSizedEntityIndex;
			buVector5.ToPoint3D(DimEntities.Dimension.BasePoint);
		}
		if (num < 0)
		{
			return;
		}
		if ((num >= 0) & (num <= DrawEntities.Count - 1))
		{
			buEntity.Copy(DrawEntities[num], ref copiedEntity);
		}
		buEntity buEntity2 = null;
		buEntity buEntity3 = null;
		if (DimEntities.Dimension.Type == DimensionType.Length)
		{
			for (int i = 0; i <= DrawEntities.Count - 1; i++)
			{
				if (i != num)
				{
					if (buCompare5.EQ(DrawEntities[i].StartPoint, DimEntities.Dimension.CatchPoint))
					{
						buEntity2 = DrawEntities[i];
						num2 = i;
						buVector5.ToPoint3D(DrawEntities[i].StartPoint);
						point3D = buVector5.ToPoint3D(DrawEntities[i].EndPoint);
						break;
					}
					if (buCompare5.EQ(DrawEntities[i].EndPoint, DimEntities.Dimension.CatchPoint))
					{
						buEntity2 = DrawEntities[i];
						num2 = i;
						buVector5.ToPoint3D(DrawEntities[i].EndPoint);
						point3D = buVector5.ToPoint3D(DrawEntities[i].StartPoint);
						break;
					}
				}
			}
			if (point3D != null)
			{
				for (int j = 0; j <= DrawEntities.Count - 1; j++)
				{
					if (j != num && j != num2)
					{
						if (buCompare5.EQ(DrawEntities[j].StartPoint, point3D))
						{
							buEntity3 = DrawEntities[j];
							indexEntity = j;
							point3D2 = buVector5.ToPoint3D(DrawEntities[j].StartPoint);
							break;
						}
						if (buCompare5.EQ(DrawEntities[j].EndPoint, point3D))
						{
							buEntity3 = DrawEntities[j];
							indexEntity = j;
							point3D2 = buVector5.ToPoint3D(DrawEntities[j].EndPoint);
							break;
						}
					}
				}
			}
			if (!buCompare5.EQ(DrawEntities[num].StartPoint, DimEntities.Dimension.CatchPoint, 0.1))
			{
				if (buCompare5.EQ(DrawEntities[num].EndPoint, DimEntities.Dimension.CatchPoint, 0.1))
				{
					Point3D EndPnt = new Point3D();
					double angle = clsInit.cVector5.PointAngle(DrawEntities[num].EndPoint, DrawEntities[num].StartPoint);
					clsInit.cVector5.LineWithLengthAndAngle(DrawEntities[num].StartPoint, NewValue, angle, ref EndPnt);
					num3 = EndPnt.X - DrawEntities[num].EndPoint.X;
					num4 = EndPnt.Y - DrawEntities[num].EndPoint.Y;
					DrawEntities[num].EndPoint.X = DrawEntities[num].EndPoint.X + num3;
					DrawEntities[num].EndPoint.Y = DrawEntities[num].EndPoint.Y + num4;
					DrawEntities[num].Update(buEntityUpdateType.Line);
					MoveDimensionEntitiesByIndex(ref DrawEntities, num, DimEntities.Dimension.CatchPoint, num3, num4);
				}
			}
			else
			{
				Point3D EndPnt2 = new Point3D();
				double angle2 = clsInit.cVector5.PointAngle(DrawEntities[num].StartPoint, DrawEntities[num].EndPoint);
				clsInit.cVector5.LineWithLengthAndAngle(DrawEntities[num].EndPoint, NewValue, angle2, ref EndPnt2);
				num3 = EndPnt2.X - DrawEntities[num].StartPoint.X;
				num4 = EndPnt2.Y - DrawEntities[num].StartPoint.Y;
				DrawEntities[num].StartPoint.X = DrawEntities[num].StartPoint.X + num3;
				DrawEntities[num].StartPoint.Y = DrawEntities[num].StartPoint.Y + num4;
				DrawEntities[num].Update(buEntityUpdateType.Line);
				MoveDimensionEntitiesByIndex(ref DrawEntities, num, DimEntities.Dimension.CatchPoint, num3, num4);
			}
			if (buEntity2 != null)
			{
				MoveDimensionEntitiesByIndex(ref DrawEntities, num2, buEntity2.StartPoint, num3, num4);
				MoveDimensionEntitiesByIndex(ref DrawEntities, num2, buEntity2.EndPoint, num3, num4);
				buEntity2.StartPoint.X = buEntity2.StartPoint.X + num3;
				buEntity2.EndPoint.X = buEntity2.EndPoint.X + num3;
				buEntity2.StartPoint.Y = buEntity2.StartPoint.Y + num4;
				buEntity2.EndPoint.Y = buEntity2.EndPoint.Y + num4;
				buEntity2.Update(buEntityUpdateType.Line);
				if (!buCompare5.EQ(buEntity2.StartPoint, DimEntities.Dimension.CatchPoint, 0.1) && !buCompare5.EQ(buEntity2.EndPoint, DimEntities.Dimension.CatchPoint, 0.1))
				{
				}
			}
			if (buEntity3 != null)
			{
				if (!buCompare5.EQ(buEntity3.StartPoint, point3D2, 0.1))
				{
					if (buCompare5.EQ(buEntity3.EndPoint, point3D2, 0.1))
					{
						MoveDimensionEntitiesByIndex(ref DrawEntities, indexEntity, point3D2, num3, num4);
						buEntity3.EndPoint.X = buEntity3.EndPoint.X + num3;
						buEntity3.EndPoint.Y = buEntity3.EndPoint.Y + num4;
					}
				}
				else
				{
					MoveDimensionEntitiesByIndex(ref DrawEntities, indexEntity, point3D2, num3, num4);
					buEntity3.StartPoint.X = buEntity3.StartPoint.X + num3;
					buEntity3.StartPoint.Y = buEntity3.StartPoint.Y + num4;
				}
				buEntity3.Update(buEntityUpdateType.Line);
			}
		}
		if (DimEntities.Dimension.Type == DimensionType.Horizontal)
		{
			SortbuSettings sortbuSettings = new SortbuSettings();
			SortbuResult Result = new SortbuResult();
			sortbuSettings.Option.NextGroupRules = SortingNextGroupFindRulesType.NoNextGroup;
			List<buEntity> SortedEntities = new List<buEntity>();
			clsInit.cVector5.SortEntitiesByRefPoint(copiedEntity.StartPoint, ref DrawEntities, sortbuSettings, ref SortedEntities, ref Result);
			if (SortedEntities.Count > 0)
			{
				num3 = NewValue - DimEntities.Dimension.Distance;
				for (int k = 0; k <= SortedEntities.Count - 1; k++)
				{
					int originalEntityIndex = SortedEntities[k].Info.OriginalEntityIndex;
					if ((originalEntityIndex >= 0) & (originalEntityIndex <= DrawEntities.Count - 1))
					{
						DrawEntities[originalEntityIndex].StartPoint.X = DrawEntities[originalEntityIndex].StartPoint.X + num3;
						DrawEntities[originalEntityIndex].EndPoint.X = DrawEntities[originalEntityIndex].EndPoint.X + num3;
						DrawEntities[originalEntityIndex].Update(buEntityUpdateType.Line);
					}
				}
				MoveDimensionEntitiesByIndex(ref DrawEntities, num, ((buLinearDim)DimEntities).ExtLine2, num3, num4);
			}
		}
		if (DimEntities.Dimension.Type != DimensionType.Vertical)
		{
			return;
		}
		SortbuSettings sortbuSettings2 = new SortbuSettings();
		SortbuResult Result2 = new SortbuResult();
		sortbuSettings2.Option.NextGroupRules = SortingNextGroupFindRulesType.NoNextGroup;
		List<buEntity> SortedEntities2 = new List<buEntity>();
		clsInit.cVector5.SortEntitiesByRefPoint(copiedEntity.StartPoint, ref DrawEntities, sortbuSettings2, ref SortedEntities2, ref Result2);
		if (SortedEntities2.Count <= 0)
		{
			return;
		}
		num4 = NewValue - DimEntities.Dimension.Distance;
		for (int l = 0; l <= SortedEntities2.Count - 1; l++)
		{
			int originalEntityIndex2 = SortedEntities2[l].Info.OriginalEntityIndex;
			if ((originalEntityIndex2 >= 0) & (originalEntityIndex2 <= DrawEntities.Count - 1))
			{
				DrawEntities[originalEntityIndex2].StartPoint.Y = DrawEntities[originalEntityIndex2].StartPoint.Y + num4;
				DrawEntities[originalEntityIndex2].EndPoint.Y = DrawEntities[originalEntityIndex2].EndPoint.Y + num4;
				DrawEntities[originalEntityIndex2].Update(buEntityUpdateType.Line);
			}
		}
		MoveDimensionEntitiesByIndex(ref DrawEntities, num, ((buLinearDim)DimEntities).ExtLine2, num3, num4);
	}

	public void doAddChar()
	{
		new List<eEntities>();
		new List<eEntities>();
		new SortingFilter();
		new SortingOptions();
		new SortingCamData();
		new SortingResult();
		DialogBoxText dialogBoxText = new DialogBoxText();
		dialogBoxText.Text = AppLanguage.CadCamStatus[108];
		dialogBoxText.Caption = AppLanguage.CadCamStatus[108];
		dialogBoxText.Init("");
		dialogBoxText.ShowDialog();
		if (dialogBoxText.Result == DialogResult.OK)
		{
			string text = dialogBoxText.Value.Trim();
			if (text.Length == 1)
			{
				int num = -1;
				int num2 = 0;
				for (int i = 0; i <= ccVars.CharLibList.Count - 1; i++)
				{
					if (!(ccVars.CharLibList[i].Char == text))
					{
						continue;
					}
					if (clsVar.varChar.AddEvenCharAvailable)
					{
						num2++;
						continue;
					}
					if (buString5.MessageBoxQuestion(AppLanguage.CadCamMessages[61] + " - " + text) == DialogResult.Yes)
					{
						i = ccVars.CharLibList.Count;
						num = i;
						continue;
					}
					clsInit.appCommand.Reset();
					return;
				}
				CharLibrary5 charLibrary = new CharLibrary5();
				charLibrary.Char = dialogBoxText.Value;
				charLibrary.Index = num2;
				for (int j = 0; j <= ccVars.SelectionOP.Selections.Count - 1; j++)
				{
					Entity refEntity = buVector5.CopyEntities(ccVars.SelectionOP.Selections[j].SelectedEntity);
					ccVars.UndoDont = true;
					buEntity copiedEntity = null;
					buEntity.Copy(refEntity, ref copiedEntity);
					if (copiedEntity != null)
					{
						charLibrary.CharEntities.Add(copiedEntity);
					}
				}
				if (charLibrary.CharEntities.Count <= 0)
				{
					buString5.MessageBoxWarning(AppLanguage.CadCamMessages[7]);
					clsInit.appCommand.Reset();
					return;
				}
				if (num != -1)
				{
					ccVars.CharLibList[num] = charLibrary;
				}
				else
				{
					ccVars.CharLibList.Add(charLibrary);
				}
				clsInit.appCommand.Delete(applyReset: false);
				clsFiles.SaveParameter();
				clsInit.appCommand.Reset();
				cmdAddChar();
			}
			else
			{
				buString5.MessageBoxWarning(AppLanguage.CadCamMessages[60] + " - " + text);
				clsInit.appCommand.Reset();
			}
		}
		else
		{
			clsInit.appCommand.Reset();
		}
	}

	public void MoveDimensionEntitiesByIndex(ref List<buEntity> DrawEntities, int indexEntity, Point3D CatchPoint, double moveDX, double moveDY)
	{
		for (int i = 0; i <= DrawEntities.Count - 1; i++)
		{
			if (!(DrawEntities[i] is buLinearDim))
			{
				continue;
			}
			buLinearDim buLinearDim2 = DrawEntities[i] as buLinearDim;
			if (buLinearDim2.Dimension.ReSizedEntityIndex != indexEntity)
			{
				continue;
			}
			if (!buCompare5.EQ(buLinearDim2.ExtLine1, CatchPoint, 0.1))
			{
				if (buCompare5.EQ(buLinearDim2.ExtLine2, CatchPoint, 0.1))
				{
					buLinearDim2.ExtLine2.X = buLinearDim2.ExtLine2.X + moveDX;
					buLinearDim2.ExtLine2.Y = buLinearDim2.ExtLine2.Y + moveDY;
					buLinearDim2.Update(buEntityUpdateType.LinearDim);
				}
			}
			else
			{
				buLinearDim2.ExtLine1.X = buLinearDim2.ExtLine1.X + moveDX;
				buLinearDim2.ExtLine1.Y = buLinearDim2.ExtLine1.Y + moveDY;
				buLinearDim2.Update(buEntityUpdateType.LinearDim);
			}
			buLinearDim2.DimLinePosition.X = buLinearDim2.DimLinePosition.X + moveDX / 2.0;
			buLinearDim2.DimLinePosition.Y = buLinearDim2.DimLinePosition.Y + moveDY / 2.0;
			double value = Point3D.Distance(buLinearDim2.ExtLine1, buLinearDim2.ExtLine2);
			if (buLinearDim2.Dimension.Type == DimensionType.Horizontal)
			{
				value = clsInit.cVector5.DeltaX(buLinearDim2.ExtLine1, buLinearDim2.ExtLine2);
			}
			if (buLinearDim2.Dimension.Type == DimensionType.Vertical)
			{
				value = clsInit.cVector5.DeltaY(buLinearDim2.ExtLine1, buLinearDim2.ExtLine2);
			}
			buLinearDim2.Dimension.Distance = Math.Round(value, 5);
			if (buCompare5.EQ(buLinearDim2.Dimension.CatchPoint, CatchPoint, 0.1))
			{
				buLinearDim2.Dimension.CatchPoint.X = buLinearDim2.Dimension.CatchPoint.X + moveDX;
				buLinearDim2.Dimension.CatchPoint.Y = buLinearDim2.Dimension.CatchPoint.Y + moveDY;
			}
			if (buCompare5.EQ(buLinearDim2.Dimension.BasePoint, CatchPoint, 0.1))
			{
				buLinearDim2.Dimension.BasePoint.X = buLinearDim2.Dimension.BasePoint.X + moveDX;
				buLinearDim2.Dimension.BasePoint.Y = buLinearDim2.Dimension.BasePoint.Y + moveDY;
			}
		}
	}
}
