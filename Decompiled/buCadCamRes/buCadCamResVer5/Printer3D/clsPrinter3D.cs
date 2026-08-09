using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buControls.Forms.WinControlForms.Notepad;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms.Printer3D;
using buEyeBaseVer5.buEntities;
using buMW;
using buMW.Variables;
using devDept;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using ns8;

namespace buCadCamResVer5.Printer3D;

public class clsPrinter3D
{
	[CompilerGenerated]
	internal sealed class Class4
	{
		public Entity[] entity_0;

		public Mesh[] mesh_0;

		internal void method_0(int int_0)
		{
			double deviation = entity_0[int_0].BoxSize.Diagonal * 0.001;
			mesh_0[int_0] = ((IFace)entity_0[int_0]).ConvertToMesh(deviation, double.MaxValue, Mesh.natureType.Smooth, weld: true);
		}
	}

	public List<string> cmdExceptionID = new List<string>();

	private int int_0 = -1;

	private int int_1 = -1;

	private int int_2 = -1;

	private int int_3 = -1;

	private int int_4 = -1;

	private int int_5 = -1;

	private string string_0 = "XZ";

	private bool bool_0 = false;

	private System.Windows.Forms.Timer timer_0 = new System.Windows.Forms.Timer();

	internal Slicing slicing_0;

	private Simulation simulation_0;

	private int int_6 = 0;

	public Printer3DJob activeJob = null;

	public void Init()
	{
		buMWPrinter3DVars.Init();
		OpenPrinter3DFile();
		LoadLanguage();
		activeJob = new Printer3DJob();
	}

	public void InitSimulation()
	{
	}

	public void Printer3DTree_AfterSelect(object sender, TreeViewEventArgs e)
	{
		if (ccVars.Pages.Count == 0)
		{
		}
	}

	public void Printer3DTree_AfterCheck(object sender, TreeViewEventArgs e)
	{
		if (ccVars.Pages.Count == 0)
		{
		}
	}

	public void ProfileTreeUpdate()
	{
		clsItem.FrmPrinter3DJob.tree_jobs.Nodes.Clear();
		TreeNodeSettings treeNodeSettings = new TreeNodeSettings("Job")
		{
			ImageIndex = 15,
			SelectedImageIndex = 15,
			Tag = "-1",
			ClassIndex = -1,
			ClassSubIndex = -1,
			ClassSubSubIndex = -1,
			Command = "profilebase",
			Name = "base",
			Info = "base",
			Index = 0,
			Checked = false
		};
		TreeNodeSettings treeNodeSettings2 = null;
		for (int i = 0; i <= activeJob.Layers.Count - 1; i++)
		{
			treeNodeSettings2 = new TreeNodeSettings(buPrinter3D.LayerToString(activeJob.Layers[i]))
			{
				ImageIndex = 1,
				SelectedImageIndex = 1,
				Tag = 0,
				ClassIndex = 0,
				ClassSubIndex = -1,
				ClassSubSubIndex = -1,
				Command = "layer",
				Name = "layer",
				Info = "layer",
				Index = 0,
				Checked = activeJob.Layers[i].Enable
			};
			treeNodeSettings.Nodes.Add(treeNodeSettings2);
		}
		if (treeNodeSettings2 != null)
		{
			treeNodeSettings2.Expand();
			treeNodeSettings.Expand();
		}
		clsItem.FrmPrinter3DJob.tree_jobs.Nodes.Add(treeNodeSettings);
	}

	public void Checked_Checked(object sender, EventArgs e)
	{
		buPrinter3D.varPrinter3DRunSettings.SelectMode = clsItem.FrmPrinter3DJob.chk_selectmode.Checked;
		clsItem.FrmPrinter3DJob.tree_jobs.CheckBoxes = buPrinter3D.varPrinter3DRunSettings.SelectMode;
		if (!buPrinter3D.varPrinter3DRunSettings.SelectMode)
		{
			for (int i = 0; i <= clsItem.FrmPrinter3DJob.tree_jobs.Nodes.Count - 1; i++)
			{
				clsItem.FrmPrinter3DJob.tree_jobs.Nodes[i].Expand();
			}
		}
	}

	public void cmdSlice()
	{
		Class5.smethod_124(this);
	}

	public void cmdShowPattern3D()
	{
		Simulate();
	}

	public void cmdSettings()
	{
		F_Printer3DSettings f_Printer3DSettings = new F_Printer3DSettings();
		f_Printer3DSettings.Settings = new Printer3DSettings(buPrinter3D.varPrinter3DSettings);
		f_Printer3DSettings.Init();
		f_Printer3DSettings.ShowDialog();
		if (f_Printer3DSettings.PropertiesForm.Result == DialogResult.OK)
		{
			buPrinter3D.varPrinter3DSettings = new Printer3DSettings(f_Printer3DSettings.Settings);
			SavePrinter3DFile();
		}
	}

	public void cmdShowGcode()
	{
		try
		{
			if (!clsVar.appModes_0.DemoMode)
			{
				if (ccVars.Pages.Count > 0)
				{
					string Lines = "";
					clsInit.cGcodeCreate.CreatGCode(ccVars.Pages[ccVars.PageIndex].Cams, ccVars.PostActive, ref Lines);
					F_Notepad f_Notepad = new F_Notepad();
					f_Notepad.Init(Lines);
					f_Notepad.Show();
					if (clsItem.FrmProgress != null)
					{
						clsItem.FrmProgress.Visible = false;
					}
					Lines = "";
				}
				else
				{
					buString5.MessageBoxWarning(AppLanguage.Messages[9]);
				}
			}
			else
			{
				MessageBox.Show("Not Available in Demo Mode");
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdSaveGcode()
	{
		try
		{
			if (!clsVar.appModes_0.DemoMode)
			{
				if (ccVars.Pages.Count > 0)
				{
					SaveFileDialog saveFileDialog = new SaveFileDialog();
					saveFileDialog.InitialDirectory = clsVar.varInterface.pathGCode;
					saveFileDialog.Filter = ccVars.PostActive.FileExplanation + " (" + ccVars.PostActive.FileExtension + ")|" + ccVars.PostActive.FileExtension;
					saveFileDialog.FilterIndex = 1;
					if (saveFileDialog.ShowDialog() == DialogResult.OK)
					{
						string Lines = "";
						clsInit.cGcodeCreate.CreatGCode(ccVars.Pages[ccVars.PageIndex].Cams, ccVars.PostActive, ref Lines);
						clsVar.varInterface.pathGCode = buFile5.GetPath(saveFileDialog.FileName);
						buFile5.SaveToFile(Lines, saveFileDialog.FileName);
						if (clsItem.FrmProgress != null)
						{
							clsItem.FrmProgress.Visible = false;
						}
						Lines = "";
						clsFiles.SaveParameter();
					}
				}
				else
				{
					buString5.MessageBoxWarning(AppLanguage.Messages[9]);
				}
			}
			else
			{
				MessageBox.Show("Not Available in Demo Mode");
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdCamContour()
	{
		clsMW.CamEntities.Clear();
		camTp camTp2 = new camTp();
		Point3D refPoint = new Point3D();
		int num = 0;
		new List<Point3D>();
		clsInit.appCommand.undoBuffer();
		List<List<Point3D>> list = new List<List<Point3D>>();
		for (int i = 0; i <= activeJob.Layers.Count - 1; i++)
		{
			for (int j = 0; j <= activeJob.Layers[i].entitiesOffsetedSlices.Count - 1; j++)
			{
				buEntity buEntity2 = activeJob.Layers[i].entitiesOffsetedSlices[j];
				buEntity buEntity3 = null;
				if (i < activeJob.Layers.Count - 1)
				{
					buEntity3 = activeJob.Layers[i + 1].entitiesOffsetedSlices[j];
				}
				List<Point3D> List = new List<Point3D>();
				List<Point3D> List2 = new List<Point3D>();
				List<Point3D> filletedPoints = new List<Point3D>();
				if (num != 0)
				{
					int indexClosest = -1;
					int indexClosest2 = -1;
					clsInit.cVector5.FindPointClosestIndexByRefPoint(buEntity2.Vertices, refPoint, ref indexClosest);
					List.AddRange(buEntity2.Vertices);
					if (indexClosest >= 0)
					{
						clsInit.cVector5.ShiftPointList(ref List, -indexClosest);
					}
					if (buEntity3 != null)
					{
						clsInit.cVector5.FindPointClosestIndexByRefPoint(buEntity3.Vertices, List[0], ref indexClosest2);
						List2.AddRange(buEntity3.Vertices);
						clsInit.cVector5.ShiftPointList(ref List2, -indexClosest2);
						_ = List2[0].X - List[List.Count - 1].X;
						_ = List2[0].Y - List[List.Count - 1].Y;
						if (List2.Count > 0)
						{
							num = 1;
							for (int k = List.Count - 5; k <= List.Count - 1; k++)
							{
								num++;
							}
						}
					}
					refPoint = new Point3D(List[0].X, List[0].Y, List[0].Z);
				}
				else
				{
					List.AddRange(buEntity2.Vertices);
					refPoint = new Point3D(List[0].X, List[0].Y, List[0].Z);
				}
				if (!(buPrinter3D.varPrinter3DSettings.FilletRadius > 0.0))
				{
					filletedPoints = new List<Point3D>();
					buVector5.Copy(List, ref filletedPoints);
				}
				else
				{
					clsInit.cVector5.CurvePoints(List, buPrinter3D.varPrinter3DSettings.FilletLimitMinAngle, buPrinter3D.varPrinter3DSettings.FilletLimitMaxAngle, ref filletedPoints);
				}
				clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref filletedPoints);
				ClockDirectionType clockDirection = clsInit.cVector5.GetClockDirection(filletedPoints);
				if (clockDirection == ClockDirectionType.CW)
				{
					filletedPoints.Reverse();
				}
				if (buPrinter3D.varPrinter3DSettings.ZSpiralMove & (i <= activeJob.Layers.Count - 2))
				{
					filletedPoints.RemoveAt(filletedPoints.Count - 1);
					double num2 = clsInit.cVector5.Length3D(filletedPoints);
					double num3 = 0.0;
					double num4 = activeJob.Layers[i + 1].LevelZ - activeJob.Layers[i].LevelZ;
					for (int l = 1; l <= filletedPoints.Count - 1; l++)
					{
						num3 += clsInit.cVector5.Length3D(filletedPoints[l - 1], filletedPoints[l], Plane.XY);
						double num5 = num3 / num2;
						if (!(num5 > 1.0))
						{
						}
						filletedPoints[l].Z = filletedPoints[l].Z + num5 * num4;
					}
				}
				list.Add(filletedPoints);
				new LinearPath(filletedPoints);
				ccVars.UndoDont = true;
				num++;
			}
		}
		if (list.Count > 0)
		{
			int num6 = 0;
			int num7 = 5;
			for (int m = 0; m <= list.Count - 1; m++)
			{
				if (m != 43)
				{
				}
				List<Point3D> Points = new List<Point3D>();
				new List<Point3D>();
				List<Point3D> Points2 = new List<Point3D>();
				List<Point3D> copiedPoint = new List<Point3D>();
				for (int n = num6; n <= list[m].Count - num7; n++)
				{
					Points.Add(new Point3D(list[m][n].X, list[m][n].Y, list[m][n].Z));
				}
				for (int num8 = list[m].Count - num7; num8 <= list[m].Count - 1; num8++)
				{
					Points2.Add(new Point3D(list[m][num8].X, list[m][num8].Y, list[m][num8].Z));
				}
				if (m < list.Count - 1)
				{
					List<Point3D> copiedPoint2 = new List<Point3D>();
					buVector5.Copy(list[m + 1], ref copiedPoint2);
					double num9 = clsInit.cVector5.PointAngle(Points2[Points2.Count - 1], Points2[Points2.Count - 2]);
					clsInit.cVector5.Length2D(Points2[Points2.Count - 1], Points2[Points2.Count - 2], Plane.XY);
					double num10 = clsInit.cVector5.PointAngle(copiedPoint2[0], copiedPoint2[1]);
					_ = 180.0 - Math.Abs(num9 - num10);
					new List<Point3D>();
					for (int num11 = 0; num11 <= num7; num11++)
					{
						Points2.Add(copiedPoint2[num11]);
						num6 = num11;
					}
				}
				Color color = Color.Red;
				clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref Points2);
				if (buPrinter3D.varPrinter3DSettings.SpiralConnection != Printer3DSpiralNextLEvelConnectionType.Linear)
				{
					if (buPrinter3D.varPrinter3DSettings.SpiralConnection != Printer3DSpiralNextLEvelConnectionType.Quadratic)
					{
						if (buPrinter3D.varPrinter3DSettings.SpiralConnection != Printer3DSpiralNextLEvelConnectionType.Cubic)
						{
							clsInit.cVector5.BezeirCurve(Points2, buPrinter3D.varPrinter3DSettings.SpiralConnectionDT, ref copiedPoint);
						}
						else
						{
							clsInit.cVector5.BSplineCubicUniform(Points2, buPrinter3D.varPrinter3DSettings.SpiralConnectionDT, Closed: false, ref copiedPoint);
							color = Color.Green;
						}
					}
					else
					{
						clsInit.cVector5.BSplineQuadraticUniform(Points2, buPrinter3D.varPrinter3DSettings.SpiralConnectionDT, Closed: false, ref copiedPoint);
						color = Color.Blue;
					}
				}
				else
				{
					buVector5.Copy(Points2, ref copiedPoint);
					color = Color.Black;
				}
				if (copiedPoint.Count > 0)
				{
					Points.AddRange(copiedPoint);
					clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref Points);
				}
				LinearPath linearPath = new LinearPath(Points);
				linearPath.LayerName = "OffsetSlice";
				linearPath.Color = color;
				linearPath.ColorMethod = colorMethodType.byEntity;
				ccVars.UndoDont = true;
				clsInit.appCommand.AddEntity(linearPath);
				clsMW.CamEntities.Add(linearPath);
			}
		}
		List<Entity> LayerEntities = new List<Entity>();
		List<Entity> LayerEntities2 = new List<Entity>();
		clsInit.cVector5.GetEntitiesByLayerName(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities, buPrinter3D.varTemps.layerOffsetSliceName, ref LayerEntities2);
		clsInit.cVector5.GetEntitiesByLayerName(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities, buPrinter3D.varTemps.layerInFill, ref LayerEntities);
		for (int num12 = 0; num12 <= LayerEntities2.Count - 1; num12++)
		{
		}
		if (buPrinter3D.varPrinter3DSettings.ZSpiralMove)
		{
			List<Point3D> copiedPoint3 = new List<Point3D>();
			for (int num13 = 0; num13 <= clsMW.CamEntities.Count - 1; num13++)
			{
				for (int num14 = 0; num14 <= clsMW.CamEntities[num13].Vertices.Length - 1; num14++)
				{
					if (copiedPoint3.Count != 0)
					{
						double num15 = Point3D.Distance(copiedPoint3[copiedPoint3.Count - 1], clsMW.CamEntities[num13].Vertices[num14]);
						if (num15 > 0.01)
						{
							copiedPoint3.Add(new Point3D(clsMW.CamEntities[num13].Vertices[num14].X, clsMW.CamEntities[num13].Vertices[num14].Y, clsMW.CamEntities[num13].Vertices[num14].Z));
						}
					}
					else
					{
						copiedPoint3.Add(new Point3D(clsMW.CamEntities[num13].Vertices[num14].X, clsMW.CamEntities[num13].Vertices[num14].Y, clsMW.CamEntities[num13].Vertices[num14].Z));
					}
				}
			}
			if (copiedPoint3.Count > 0)
			{
				if (buPrinter3D.varPrinter3DSettings.UseSpline)
				{
					buCurve buCurve2 = new buCurve(2, copiedPoint3);
					copiedPoint3 = new List<Point3D>();
					buVector5.Copy(buCurve2.Vertices, ref copiedPoint3);
				}
				camTpPoint camTpPoint2 = new camTpPoint();
				for (int num16 = 0; num16 <= copiedPoint3.Count - 1; num16++)
				{
					Pnt6D p = new Pnt6D(copiedPoint3[num16].X, copiedPoint3[num16].Y, copiedPoint3[num16].Z);
					TpPnt9D tpPnt9D = new TpPnt9D(p);
					if (num16 != 0)
					{
						tpPnt9D.Type = 1;
					}
					else
					{
						tpPnt9D.Type = 0;
						tpPnt9D.AfterCodes.Add("M3");
					}
					tpPnt9D.Feed = buPrinter3D.varPrinter3DSettings.FeedSpeed;
					camTpPoint2.Points.Add(tpPnt9D);
				}
				camTp2.CamPoints.Add(camTpPoint2);
				camTp2.EntitiesG1.Clear();
				LinearPath item = new LinearPath(copiedPoint3);
				camTp2.EntitiesG1.Add(item);
			}
		}
		else
		{
			for (int num17 = 0; num17 <= clsMW.CamEntities.Count - 1; num17++)
			{
				camTpPoint camTpPoint3 = new camTpPoint();
				if (num17 > 0 && ((camTp2.CamPoints.Count > 0) & (clsMW.CamEntities[num17].Vertices.Length != 0)))
				{
					double z = clsMW.CamEntities[num17].Vertices[0].Z;
					double z2 = camTp2.CamPoints[camTp2.CamPoints.Count - 1].Points[camTp2.CamPoints[camTp2.CamPoints.Count - 1].Points.Count - 1].P9.Z;
					if (z - z2 > 0.1)
					{
						TpPnt9D tpPnt9D2 = new TpPnt9D(camTp2.CamPoints[camTp2.CamPoints.Count - 1].Points[camTp2.CamPoints[camTp2.CamPoints.Count - 1].Points.Count - 1]);
						tpPnt9D2.PreCodes.Clear();
						tpPnt9D2.AfterCodes.Clear();
						tpPnt9D2.PreCodes.Add("M5");
						tpPnt9D2.P9.Z = z;
						tpPnt9D2.Feed = buPrinter3D.varPrinter3DSettings.PlungeSpeed;
						tpPnt9D2.Type = 1;
						camTpPoint3.Points.Add(tpPnt9D2);
						camTp2.CamPoints.Add(camTpPoint3);
						camTpPoint3 = new camTpPoint();
					}
				}
				for (int num18 = 0; num18 <= clsMW.CamEntities[num17].Vertices.Length - 1; num18++)
				{
					Pnt6D p2 = new Pnt6D(clsMW.CamEntities[num17].Vertices[num18].X, clsMW.CamEntities[num17].Vertices[num18].Y, clsMW.CamEntities[num17].Vertices[num18].Z);
					TpPnt9D tpPnt9D3 = new TpPnt9D(p2);
					if (num18 != 0)
					{
						tpPnt9D3.Type = 1;
					}
					else
					{
						tpPnt9D3.Type = 0;
						tpPnt9D3.AfterCodes.Add("M3");
					}
					if (num18 <= 0)
					{
					}
					tpPnt9D3.Feed = buPrinter3D.varPrinter3DSettings.FeedSpeed;
					camTpPoint3.Points.Add(tpPnt9D3);
				}
				LinearPath item2 = new LinearPath(clsMW.CamEntities[num17].Vertices);
				camTp2.EntitiesG1.Add(item2);
				if (camTpPoint3.Points.Count > 0)
				{
					if (camTp2.CamPoints.Count <= 0)
					{
						camTp2.CamPoints.Add(camTpPoint3);
					}
					else
					{
						Point3D startPoint = new Point3D(camTp2.CamPoints[camTp2.CamPoints.Count - 1].Points[camTp2.CamPoints[camTp2.CamPoints.Count - 1].Points.Count - 1].P9.X, camTp2.CamPoints[camTp2.CamPoints.Count - 1].Points[camTp2.CamPoints[camTp2.CamPoints.Count - 1].Points.Count - 1].P9.Y, camTp2.CamPoints[camTp2.CamPoints.Count - 1].Points[camTp2.CamPoints[camTp2.CamPoints.Count - 1].Points.Count - 1].P9.Z);
						Point3D endPoint = new Point3D(camTpPoint3.Points[0].P9.X, camTpPoint3.Points[0].P9.Y, camTpPoint3.Points[0].P9.Z);
						double num19 = clsInit.cVector5.Length3D(startPoint, endPoint, Plane.XY);
						if (!(num19 > 10.0))
						{
							camTp2.CamPoints.Add(camTpPoint3);
						}
						else
						{
							camTpPoint3.Points[0].AfterCodes.Add("M3");
							if (camTp2.CamPoints[camTp2.CamPoints.Count - 1].Points[camTp2.CamPoints[camTp2.CamPoints.Count - 1].Points.Count - 1].AfterCodes.Count == 0)
							{
								camTp2.CamPoints[camTp2.CamPoints.Count - 1].Points[camTp2.CamPoints[camTp2.CamPoints.Count - 1].Points.Count - 1].AfterCodes.Add("M5");
							}
							camTp2.CamPoints.Add(camTpPoint3);
						}
					}
				}
				camTp2.Tool = new ToolBase5(ccVars.toolActive);
				if ((num17 == clsMW.CamEntities.Count - 1) & (camTp2.CamPoints.Count == 0) & (camTpPoint3.Points.Count > 0))
				{
					camTpPoint3.Points[0].AfterCodes.Add("M3");
					camTpPoint3.Points[camTpPoint3.Points.Count - 1].AfterCodes.Add("M5");
					camTp2.CamPoints.Add(camTpPoint3);
				}
			}
		}
		ccVars.Pages[ccVars.PageIndex].Cams.Clear();
		if (camTp2.CamPoints.Count > 0)
		{
			if (camTp2.CamPoints[0].Points[0].AfterCodes.Count == 0)
			{
				camTp2.CamPoints[0].Points[0].AfterCodes.Add("M3");
			}
			if (camTp2.CamPoints[camTp2.CamPoints.Count - 1].Points[camTp2.CamPoints[camTp2.CamPoints.Count - 1].Points.Count - 1].AfterCodes.Count == 0)
			{
				camTp2.CamPoints[camTp2.CamPoints.Count - 1].Points[camTp2.CamPoints[camTp2.CamPoints.Count - 1].Points.Count - 1].AfterCodes.Add("M5");
			}
			clsInit.appCommand.CamAdd(camTp2, buPrinter3D.varTemps.layerCamName);
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void cmdSimStart()
	{
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.TempEntities.Clear();
		Design viewportcad = ccVars.Pages[ccVars.PageIndex].Form.viewportcad;
		string layerOnlineSimulationName = buPrinter3D.varTemps.layerOnlineSimulationName;
		Class5.smethod_43(layerOnlineSimulationName, viewportcad, this);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
		clsInit.appCommand.simStart();
	}

	public void cmdSimStop()
	{
		clsInit.appCommand.simStop();
		ccVars.SimCamPointIndex = 0;
		ccVars.SimCamBaseIndex = 0;
		clsVar.varInterface.CamSimulationStep = 1;
		int_6 = 0;
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.TempEntities.Clear();
		Design viewportcad = ccVars.Pages[ccVars.PageIndex].Form.viewportcad;
		string layerOnlineSimulationName = buPrinter3D.varTemps.layerOnlineSimulationName;
		Class5.smethod_43(layerOnlineSimulationName, viewportcad, this);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void Sim_Tick(object sender, EventArgs e)
	{
		if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count > 0 && ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1] is Mesh && ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1].EntityData is CustomData)
		{
			CustomData customData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1].EntityData as CustomData;
			if (customData.typeDefination != entityTypeDefination.Simulation)
			{
			}
		}
		if (ccVars.SimCamPointIndex == 0)
		{
			int_6 = 0;
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.TempEntities.Clear();
		Thread.Sleep(5);
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Cams.Count - 1; i++)
		{
			camTp camTp2 = ccVars.Pages[ccVars.PageIndex].Cams[i];
			List<Point3D> list = new List<Point3D>();
			for (int j = int_6; j <= ccVars.SimCamPointIndex - 1; j++)
			{
				list.Add(new Point3D(camTp2.SimilationPoint.SimMove[j].X, camTp2.SimilationPoint.SimMove[j].Y, camTp2.SimilationPoint.SimMove[j].Z));
			}
			if (list.Count > 2)
			{
				if (camTp2.SimilationPoint.SimMove[ccVars.SimCamPointIndex].GCode != 0)
				{
					LinearPath linearPath = new LinearPath(list);
					CustomData customData2 = new CustomData();
					customData2.typeDefination = entityTypeDefination.Simulation;
					Mesh mesh = linearPath.Inflate(20.0, 10.0, 180.0, 10.0);
					mesh.LayerName = buPrinter3D.varTemps.layerOnlineSimulationName;
					mesh.EntityData = customData2;
					mesh.Color = Color.Lime;
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.TempEntities.Add(mesh);
				}
				else
				{
					CustomData customData3 = new CustomData();
					int_6 = ccVars.SimCamPointIndex;
					LinearPath linearPath2 = new LinearPath(list);
					customData3.typeDefination = entityTypeDefination.Simulation;
					Mesh mesh2 = linearPath2.Inflate(20.0, 10.0, 180.0, 10.0);
					mesh2.LayerName = buPrinter3D.varTemps.layerOnlineSimulationName;
					mesh2.EntityData = customData3;
					mesh2.Color = Color.Lime;
					mesh2.ColorMethod = colorMethodType.byEntity;
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(mesh2);
				}
			}
		}
	}

	public void LoadLanguage()
	{
		try
		{
			List<string> list = new List<string>();
			FileInfo fileInfo = null;
			fileInfo = ((!clsVar.appModes_0.DeveloperPCMode) ? new FileInfo(AppPath.Language + "\\buPrinter3D.lng") : new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buPrinter3D.lng"));
			if (!fileInfo.Exists)
			{
				buLog.addLog("Printer3D Language", "Not Ok", MethodBase.GetCurrentMethod().Name);
				buString.MessageBoxError("Printer3D Language File Missing");
			}
			else
			{
				List<string> StringList = new List<string>();
				buFile.OpenFromFile(fileInfo.FullName, ref StringList);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Status>", "</Status>", StringList), clsVar.varRuntime.Language, ref buPrinter3D.LangPrinter3DStatus);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Message>", "</Message>", StringList), clsVar.varRuntime.Language, ref buPrinter3D.LangPrinter3DMessage);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Captions>", "</Captions>", StringList), clsVar.varRuntime.Language, ref buPrinter3D.LangPrinter3DCaptions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Command>", "</Command>", StringList), clsVar.varRuntime.Language, ref buPrinter3D.LangPrinter3DCommands);
				StringList.Clear();
			}
			if (list.Count <= 0)
			{
			}
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[16];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void SavePrinter3DFile()
	{
		try
		{
			string fileName = AppPath.Settings + "\\Printer3D\\Printer3D.prm";
			ArrayList arrayList = new ArrayList();
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Printer3D Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("<buPrinter3D.varPrinter3DSettings>");
			arrayList.AddRange(buPrinter3D.varPrinter3DSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
			arrayList.Add("</buPrinter3D.varPrinter3DSettings>");
			arrayList.Add("<buPrinter3D.varPrinter3DRunSettings>");
			arrayList.AddRange(buPrinter3D.varPrinter3DRunSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
			arrayList.Add("</buPrinter3D.varPrinter3DRunSettings>");
			buFile.SaveToFile(arrayList, fileName);
			buLog.addLog("Foam Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
			buMWPrinter3DVars.varCamContour.mwPar.Serialize(AppPath.Settings + "\\Printer3D\\mwPrinter3DContour.bin");
			buMWPrinter3DVars.varCamRough.mwPar.Serialize(AppPath.Settings + "\\Printer3D\\mwPrinter3DRough.bin");
			string fileName2 = AppPath.Settings + "\\Printer3D\\Printer3DCam.bucamset";
			arrayList = new ArrayList();
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   MW Cam Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("<MwCamSettings>");
			arrayList.AddRange(buMWPrinter3DVars.varCamContour.buPar.ToDefAll("_varCamContour", 2, SerilizationMode5.MultiLine));
			arrayList.AddRange(buMWPrinter3DVars.varCamRough.buPar.ToDefAll("_varCamRough", 2, SerilizationMode5.MultiLine));
			arrayList.Add("</MwCamSettings>");
			buFile.SaveToFile(arrayList, fileName2);
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[17];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void OpenPrinter3DFile()
	{
		try
		{
			ArrayList arrayList = new ArrayList();
			string fileName = AppPath.Settings + "\\Printer3D\\Printer3D.prm";
			FileInfo fileInfo = new FileInfo(fileName);
			if (!fileInfo.Exists)
			{
				if (clsVar.appModes_0.LaserRouterDiamekerMode.Enable)
				{
					buLog.addLog("Printer3D Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buString.MessageBoxError("Drill Settings File Missing");
				}
			}
			else
			{
				arrayList = new ArrayList();
				buFile.OpenFromFile(fileInfo.FullName, ref arrayList);
				try
				{
					ArrayList CalcList = new ArrayList();
					buString.ListToSpecificList("<buPrinter3D.varPrinter3DSettings>", "</buPrinter3D.varPrinter3DSettings>", AddStartEndKey: true, arrayList, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, buPrinter3D.varPrinter3DSettings);
						buLog.addLog("Printer3D Settings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
					}
					CalcList = new ArrayList();
					buString.ListToSpecificList("<buPrinter3D.varPrinter3DRunSettings>", "</buPrinter3D.varPrinter3DRunSettings>", AddStartEndKey: true, arrayList, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, buPrinter3D.varPrinter3DRunSettings);
						buLog.addLog("Printer3D varDrillCNCSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
					}
				}
				catch (Exception mSException)
				{
					buLog.addLog("Printer3D Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Printer3D Settings Decoder Error");
				}
			}
			buLog.addLog("Printer3D Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
			fileInfo = new FileInfo(AppPath.Settings + "\\Printer3D\\mwPrinter3DContour.bin");
			if (fileInfo.Exists)
			{
				buMWPrinter3DVars.varCamContour.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Printer3D\\mwPrinter3DRough.bin");
			if (fileInfo.Exists)
			{
				buMWPrinter3DVars.varCamRough.mwPar.Deserialize(fileInfo.FullName);
			}
			string fileName2 = AppPath.Settings + "\\Printer3D\\Printer3DCam.bucamset";
			fileInfo = new FileInfo(fileName2);
			if (!fileInfo.Exists)
			{
				buLog.addLog("Printer 3D Cam Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
				buString.MessageBoxError("Printer 3D Cam Settings File Missing");
				return;
			}
			arrayList = new ArrayList();
			buFile.OpenFromFile(fileName2, ref arrayList);
			try
			{
				ArrayList CalcList2 = new ArrayList();
				buString.ListToSpecificList("<MwCamSettings>", "</MwCamSettings>", AddStartEndKey: true, arrayList, ref CalcList2);
				if (CalcList2.Count > 0)
				{
					buSerilization.Decode(arrayList, "_varCamContour", SerilizationMode.MultiLine, buMWPrinter3DVars.varCamContour);
					buSerilization.Decode(arrayList, "_varCamRough", SerilizationMode.MultiLine, buMWPrinter3DVars.varCamRough);
				}
			}
			catch (Exception mSException2)
			{
				buLog.addLog("MW Printer 3D Cam Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
				buException.throwException(mSException2, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Printer 3D Settings Decoder Error");
			}
		}
		catch (Exception mSException3)
		{
			_ = cmdExceptionID[18];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException3, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void NewPageExtension()
	{
		activeJob = new Printer3DJob();
		ProfileTreeUpdate();
	}

	public void PageClosed()
	{
		activeJob = new Printer3DJob();
		ProfileTreeUpdate();
	}

	public void Simulate()
	{
		if (slicing_0 == null)
		{
			return;
		}
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
		{
			if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].LayerName == buPrinter3D.varTemps.layerSimulationName)
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Selected = true;
			}
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
		simulation_0 = new Simulation(slicing_0, buPrinter3D.varPrinter3DSettings.InFill, buPrinter3D.varPrinter3DSettings.NozzleDiameter);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.StartWork(simulation_0);
	}

	public void doSlicing(WorkCompletedEventArgs e)
	{
		Slicing slicing = (Slicing)e.WorkUnit;
		Design viewportcad = ccVars.Pages[ccVars.PageIndex].Form.viewportcad;
		string layerSliceName = buPrinter3D.varTemps.layerSliceName;
		Class5.smethod_43(layerSliceName, viewportcad, this);
		viewportcad = ccVars.Pages[ccVars.PageIndex].Form.viewportcad;
		layerSliceName = buPrinter3D.varTemps.layerRegionName;
		Class5.smethod_43(layerSliceName, viewportcad, this);
		viewportcad = ccVars.Pages[ccVars.PageIndex].Form.viewportcad;
		layerSliceName = buPrinter3D.varTemps.layerOffsetSliceName;
		Class5.smethod_43(layerSliceName, viewportcad, this);
		viewportcad = ccVars.Pages[ccVars.PageIndex].Form.viewportcad;
		layerSliceName = buPrinter3D.varTemps.layerSimulationName;
		Class5.smethod_43(layerSliceName, viewportcad, this);
		viewportcad = ccVars.Pages[ccVars.PageIndex].Form.viewportcad;
		layerSliceName = buPrinter3D.varTemps.layerTessellationName;
		Class5.smethod_43(layerSliceName, viewportcad, this);
		viewportcad = ccVars.Pages[ccVars.PageIndex].Form.viewportcad;
		layerSliceName = buPrinter3D.varTemps.layerCamName;
		Class5.smethod_43(layerSliceName, viewportcad, this);
		viewportcad = ccVars.Pages[ccVars.PageIndex].Form.viewportcad;
		layerSliceName = buPrinter3D.varTemps.layerInFill;
		Class5.smethod_43(layerSliceName, viewportcad, this);
		Printer3DLayer printer3DLayer = null;
		activeJob = new Printer3DJob();
		for (int i = 0; i < slicing.NumMeshes; i++)
		{
			for (int j = 0; j <= slicing.OffsetSectionsByMesh[0].Length - 1; j++)
			{
				if (slicing.OffsetSectionsByMesh[0][j].Vertices == null)
				{
					slicing.OffsetSectionsByMesh[0][j].Regen(0.01);
				}
				double z = slicing.OffsetSectionsByMesh[0][j].Vertices[0].Z;
				if (j != 0)
				{
					if (!buCompare5.EQ(activeJob.Layers[activeJob.Layers.Count - 1].LevelZ, z, 0.01))
					{
						printer3DLayer = new Printer3DLayer();
						printer3DLayer.LevelZ = z;
						if ((printer3DLayer.LevelZ > buPrinter3D.varPrinter3DSettings.TopHeight) & (buPrinter3D.varPrinter3DSettings.TopHeight > 0.0))
						{
							printer3DLayer.Enable = false;
						}
						buEntity item = buEntity.Copy(slicing.OffsetSectionsByMesh[0][j]);
						printer3DLayer.entitiesOffsetedSlices.Add(item);
						activeJob.Layers.Add(printer3DLayer);
					}
					else
					{
						if ((activeJob.Layers[activeJob.Layers.Count - 1].LevelZ > buPrinter3D.varPrinter3DSettings.TopHeight) & (buPrinter3D.varPrinter3DSettings.TopHeight > 0.0))
						{
							activeJob.Layers[activeJob.Layers.Count - 1].Enable = false;
						}
						buEntity item2 = buEntity.Copy(slicing.OffsetSectionsByMesh[0][j]);
						activeJob.Layers[activeJob.Layers.Count - 1].entitiesOffsetedSlices.Add(item2);
					}
				}
				else
				{
					printer3DLayer = new Printer3DLayer();
					printer3DLayer.LevelZ = z;
					if ((printer3DLayer.LevelZ > buPrinter3D.varPrinter3DSettings.TopHeight) & (buPrinter3D.varPrinter3DSettings.TopHeight > 0.0))
					{
						printer3DLayer.Enable = false;
					}
					buEntity item3 = buEntity.Copy(slicing.OffsetSectionsByMesh[0][j]);
					printer3DLayer.entitiesOffsetedSlices.Add(item3);
					activeJob.Layers.Add(printer3DLayer);
				}
			}
		}
		for (int k = 0; k < slicing.NumMeshes; k++)
		{
			if (slicing.HatchingByMeshByLayer[0] == null)
			{
				continue;
			}
			for (int l = 0; l <= slicing.HatchingByMeshByLayer[0].Length - 1; l++)
			{
				int num = -1;
				if (buPrinter3D.varPrinter3DSettings.InFillConnect)
				{
					for (int m = 0; m <= activeJob.Layers.Count - 1; m++)
					{
					}
					if (num < 0)
					{
						continue;
					}
					slicing.HatchingByMeshByLayer[0][l][0].Selected = true;
					List<Point3D> list = new List<Point3D>();
					list.Add(buVector5.ToPoint3D(slicing.HatchingByMeshByLayer[0][l][0].StartPoint));
					list.Add(buVector5.ToPoint3D(slicing.HatchingByMeshByLayer[0][l][0].EndPoint));
					for (int n = 0; n <= slicing.HatchingByMeshByLayer[0][l].Length - 1; n++)
					{
						double num2 = double.MaxValue;
						int num3 = -1;
						bool flag = false;
						for (int num4 = 1; num4 <= slicing.HatchingByMeshByLayer[0][l].Length - 1; num4++)
						{
							if (!slicing.HatchingByMeshByLayer[0][l][num4].Selected)
							{
								double num5 = Point3D.Distance(list[list.Count - 1], slicing.HatchingByMeshByLayer[0][l][num4].StartPoint);
								if (num5 < num2)
								{
									num2 = num5;
									flag = true;
									num3 = num4;
								}
								num5 = Point3D.Distance(list[list.Count - 1], slicing.HatchingByMeshByLayer[0][l][num4].EndPoint);
								if (num5 < num2)
								{
									num2 = num5;
									flag = false;
									num3 = num4;
								}
							}
						}
						if (num3 >= 0)
						{
							slicing.HatchingByMeshByLayer[0][l][num3].Selected = true;
							if (!flag)
							{
								list.Add(buVector5.ToPoint3D(slicing.HatchingByMeshByLayer[0][l][num3].EndPoint));
								list.Add(buVector5.ToPoint3D(slicing.HatchingByMeshByLayer[0][l][num3].StartPoint));
							}
							else
							{
								list.Add(buVector5.ToPoint3D(slicing.HatchingByMeshByLayer[0][l][num3].StartPoint));
								list.Add(buVector5.ToPoint3D(slicing.HatchingByMeshByLayer[0][l][num3].EndPoint));
							}
						}
					}
					if (list.Count > 0)
					{
						buLinearPath buLinearPath2 = new buLinearPath(list);
						activeJob.Layers[num].entitiesInfill.Add(buLinearPath2);
						Entity copiedEntity = null;
						buEntity.Copy(buLinearPath2, ref copiedEntity);
					}
					continue;
				}
				for (int num6 = 0; num6 <= slicing.HatchingByMeshByLayer[0][l].Length - 1; num6++)
				{
					for (int num7 = 0; num7 <= activeJob.Layers.Count - 1; num7++)
					{
						double z2 = slicing.HatchingByMeshByLayer[0][l][num6].Vertices[0].Z;
						if (buCompare5.EQ(activeJob.Layers[num7].LevelZ, z2, 0.1))
						{
							num = num7;
							buEntity item4 = buEntity.Copy(slicing.HatchingByMeshByLayer[0][l][num6]);
							activeJob.Layers[num].entitiesInfill.Add(item4);
						}
					}
				}
			}
		}
		ProfileTreeUpdate();
		for (int num8 = 0; num8 <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; num8++)
		{
			if (ccVars.Pages[ccVars.PageIndex].Layers[num8].Name == buPrinter3D.varTemps.layerOnlineSimulationName)
			{
				ccVars.Pages[ccVars.PageIndex].Layers[num8].Enable = false;
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[buPrinter3D.varTemps.layerOnlineSimulationName].Visible = false;
			}
			if (ccVars.Pages[ccVars.PageIndex].Layers[num8].Name == buPrinter3D.varTemps.layerRegionName)
			{
				ccVars.Pages[ccVars.PageIndex].Layers[num8].Enable = false;
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[buPrinter3D.varTemps.layerRegionName].Visible = false;
			}
			if (ccVars.Pages[ccVars.PageIndex].Layers[num8].Name == buPrinter3D.varTemps.layerSliceName)
			{
				ccVars.Pages[ccVars.PageIndex].Layers[num8].Enable = false;
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[buPrinter3D.varTemps.layerSliceName].Visible = false;
			}
			if (ccVars.Pages[ccVars.PageIndex].Layers[num8].Name == buPrinter3D.varTemps.layerTessellationName)
			{
				ccVars.Pages[ccVars.PageIndex].Layers[num8].Enable = false;
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[buPrinter3D.varTemps.layerTessellationName].Visible = false;
			}
		}
		clsInit.appCommand.LayersUpdate(ccVars.Pages[ccVars.PageIndex].Layers, FillLayer: true, -1);
		for (int num9 = 0; num9 < slicing.NumMeshes; num9++)
		{
			if (slicing.HasOffsetSlices(num9))
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.AddRange(slicing.OffsetSectionsByMesh[num9], buPrinter3D.varTemps.layerOffsetSliceName);
			}
			if (slicing.HasHatching(num9))
			{
				Entity[][] array = slicing.CuttingRegionByMeshByLayer[num9];
				foreach (Entity[] collection in array)
				{
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.AddRange(collection, buPrinter3D.varTemps.layerRegionName);
				}
			}
			if (slicing.HasSlices(num9))
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.AddRange(slicing.SectionsByMesh[num9], buPrinter3D.varTemps.layerSliceName);
			}
			Mesh mesh = slicing.TessellatedMeshes[num9];
			if (mesh.IsValid())
			{
				mesh.ColorMethod = colorMethodType.byLayer;
				mesh.LayerName = buPrinter3D.varTemps.layerTessellationName;
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(mesh, buPrinter3D.varTemps.layerTessellationName);
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(mesh);
			}
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.ClearSelection();
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void doSimulation(WorkCompletedEventArgs e)
	{
		Simulation simulation = (Simulation)e.WorkUnit;
		SimulationRender workUnit = new SimulationRender(simulation);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.StartWork(workUnit);
	}

	public void doSimulationRender(WorkCompletedEventArgs e)
	{
		Design viewportcad = ccVars.Pages[ccVars.PageIndex].Form.viewportcad;
		string layerSimulationName = buPrinter3D.varTemps.layerSimulationName;
		Class5.smethod_43(layerSimulationName, viewportcad, this);
		SimulationRender simulationRender = (SimulationRender)e.WorkUnit;
		if (simulationRender.HasContour)
		{
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(simulationRender.ContourMesh, buPrinter3D.varTemps.layerSimulationName);
			if (simulationRender.HasHatching)
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(simulationRender.HatchingMesh, buPrinter3D.varTemps.layerSimulationName, Color.YellowGreen);
			}
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.ClearSelection();
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void doReset()
	{
	}

	public void doWireframeContour(MWCalculationOptions MWCalcoptions, ToolBase5 Tool, ref camTp Cam)
	{
		if (Cam == null)
		{
			Cam = new camTp();
		}
		buMWPrinter3DVars.varCamContour.buPar.Runtime.SimG0DevideLength = 100.0;
		buMWPrinter3DVars.varCamContour.buPar.Runtime.SimG1DevideLength = 40.0;
		buMWPrinter3DVars.varCamContour.buPar.Offsets.OpenContour = CamOpenContourType.Center;
		buMWPrinter3DVars.varCamContour.buPar.Distances.Air = 0.0;
		buMWPrinter3DVars.varCamContour.buPar.Distances.Safe = 0.0;
		buMWPrinter3DVars.varCamContour.buPar.Distances.Rapid = 0.0;
		buMWPrinter3DVars.varCamContour.buPar.Distances.EntryAndExit = 0.0;
		buMWPrinter3DVars.varCamContour.buPar.Distances.EntryAndExit = 0.0;
		buMWPrinter3DVars.varCamContour.buPar.Strategy.TangentFirstAngleGreaterThen180StartMinusAngle = true;
		buMWPrinter3DVars.varCamContour.mwPar = buMWCalcs.ConvertFromBuCamParToMwCamPar(buMWPrinter3DVars.varCamContour.mwPar, buMWPrinter3DVars.varCamContour.buPar);
		clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWPrinter3DVars.varCamContour.mwPar, buMWPrinter3DVars.varCamContour.buPar, out clsMW.varbuCamWFContourPars);
		camResult Result = null;
		int num = clsInit.appMW.doWireframeContour(MWCalcoptions, Tool, ref Cam, ref Result);
		buMWPrinter3DVars.varCamContour.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buMWPrinter3DVars.varCamContour.buPar);
		if (num < 1)
		{
			buString5.MessageBoxError(AppLanguage.CadCamMessages[93]);
			clsInit.appCommand.Reset();
		}
	}

	public void doWireframeRough(MWCalculationOptions MWCalcoptions, ToolBase5 Tool, ref camTp Cam)
	{
		if (Cam == null)
		{
			Cam = new camTp();
		}
		buMWPrinter3DVars.varCamRough.buPar.Runtime.SimG0DevideLength = 100.0;
		buMWPrinter3DVars.varCamRough.buPar.Runtime.SimG1DevideLength = 40.0;
		buMWPrinter3DVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = MWCalcoptions.Height;
		buMWPrinter3DVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = MWCalcoptions.Height;
		buMWPrinter3DVars.varCamRough.buPar.Operations.Height = MWCalcoptions.Height;
		buMWPrinter3DVars.varCamRough.buPar.Offsets.OpenContour = CamOpenContourType.Center;
		buMWPrinter3DVars.varCamRough.buPar.Distances.Air = 0.0;
		buMWPrinter3DVars.varCamRough.buPar.Distances.Safe = 0.0;
		buMWPrinter3DVars.varCamRough.buPar.Distances.Rapid = 0.0;
		buMWPrinter3DVars.varCamRough.buPar.Distances.EntryAndExit = 0.0;
		buMWPrinter3DVars.varCamRough.buPar.Distances.EntryAndExit = 0.0;
		buMWPrinter3DVars.varCamRough.buPar.Strategy.TangentFirstAngleGreaterThen180StartMinusAngle = true;
		buMWPrinter3DVars.varCamRough.mwPar = buMWCalcs.ConvertFromBuCamParToMwCamPar(buMWPrinter3DVars.varCamRough.mwPar, buMWPrinter3DVars.varCamRough.buPar);
		clsMW.varMWCamWFPocketPars = buMWCalcs.CopyCamParameter(buMWPrinter3DVars.varCamRough.mwPar, buMWPrinter3DVars.varCamRough.buPar, out clsMW.varbuCamWFPocketPars);
		camResult Result = null;
		int num = clsInit.appMW.doWireframeContour(MWCalcoptions, Tool, ref Cam, ref Result);
		buMWPrinter3DVars.varCamRough.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFPocketPars, clsMW.varbuCamWFPocketPars, out buMWPrinter3DVars.varCamRough.buPar);
		if (num < 1)
		{
			buString5.MessageBoxError(AppLanguage.CadCamMessages[93]);
			clsInit.appCommand.Reset();
		}
	}
}
