using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using buControls;
using buCore;
using buEyeBaseVer5.Forms;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps;

public class buPipeBendCalc
{
	public static LengthUnit UnitLength = LengthUnit.mm;

	public static SpeedUnit UnitsSpeed = SpeedUnit.mmPerSec;

	public static List<string> LangPipeBendStatus = new List<string>();

	public static List<string> LangPipeBendMessage = new List<string>();

	public static List<string> LangPipeBendCaptions = new List<string>();

	public static List<string> LangPipeBendCommands = new List<string>();

	public static int EntityID = 1;

	public static PipeBendingProgramSettings varPipeBendingProgramSettings = new PipeBendingProgramSettings();

	public static PipeBendTempVars varTemps = new PipeBendTempVars();

	public static PipeBendSettings varPipeBendingSettings = new PipeBendSettings();

	public static PipeBendRuntimeSettings varPipeBendingRunSettings = new PipeBendRuntimeSettings();

	public static List<PipeBendDiskBlocks> DiskBlocks = new List<PipeBendDiskBlocks>();

	public PipeBendJob activeJob = null;

	public static F_BendingRotaryDisk frmDiskBlocks = null;

	private readonly Timer timer_0 = new Timer();

	private readonly Timer timer_1 = new Timer();

	public static string UnlockString = "";

	public buPipeBendCalc()
	{
		if (!buVector5.smethod_0("buPipeBendCalc"))
		{
			throw new RegisterException("buPipeBendCalc");
		}
	}

	public void showDiskBlockPage()
	{
		if (frmDiskBlocks == null)
		{
			frmDiskBlocks = new F_BendingRotaryDisk();
			frmDiskBlocks.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
			frmDiskBlocks.PropertiesForm.FormPosition = FormStartPosition.CenterParent;
		}
		if (frmDiskBlocks.pnl_viewport.Controls.Count == 0)
		{
			frmDiskBlocks.pnl_viewport.Controls.Add(buEyeItems.viewportDialogs);
		}
		frmDiskBlocks.Init();
		frmDiskBlocks.ShowDialog();
		frmDiskBlocks.pnl_viewport.Controls.Clear();
	}

	public TreeView UpdateItems(TreeView Tree)
	{
		Tree.Nodes.Clear();
		buTreeNode buTreeNode2 = new buTreeNode(buLangTranslate.preDef.Bending + " " + buLangTranslate.preDef.Block)
		{
			ImageIndex = 0,
			SelectedImageIndex = 0,
			Tag = "-1",
			ClassIndex = 0,
			ClassSubIndex = -1,
			ClassSubSubIndex = -1,
			Command = "bendbase",
			Name = "base",
			Info = "base",
			NodeIndex = 0,
			Checked = false
		};
		Tree.Nodes.Add(buTreeNode2);
		for (int i = 0; i <= DiskBlocks.Count - 1; i++)
		{
			buTreeNode buTreeNode3 = new buTreeNode(buLangTranslate.preDef.Bending + " " + buLangTranslate.preDef.Block)
			{
				ImageIndex = 0,
				SelectedImageIndex = 0,
				Tag = "-1",
				ClassIndex = 0,
				ClassSubIndex = i,
				ClassSubSubIndex = -1,
				Command = "benddisk",
				Name = "base",
				Info = "base",
				NodeIndex = 0,
				Checked = false
			};
			buTreeNode node = new buTreeNode(buLangTranslate.preDef.Disk)
			{
				ImageIndex = 1,
				SelectedImageIndex = 1,
				Tag = "-1",
				ClassIndex = 0,
				ClassSubIndex = i,
				ClassSubSubIndex = 0,
				Command = "disk",
				Name = "base",
				Info = "base",
				NodeIndex = 1,
				Checked = false
			};
			buTreeNode node2 = new buTreeNode(buLangTranslate.preDef.Block)
			{
				ImageIndex = 2,
				SelectedImageIndex = 2,
				Tag = "-1",
				ClassIndex = 0,
				ClassSubIndex = i,
				ClassSubSubIndex = 1,
				Command = "block",
				Name = "base",
				Info = "base",
				NodeIndex = 2,
				Checked = false
			};
			buTreeNode3.Nodes.Add(node);
			buTreeNode3.Nodes.Add(node2);
			buTreeNode2.Nodes.Add(buTreeNode3);
		}
		return Tree;
	}

	public void CreateDiskBlocks(PipeBendDiskBlocks DiskData, ref Entity entDisk, ref Entity entBlock)
	{
		Circle c = new Circle(Plane.XY, new Point3D(), DiskData.DiskDiameter / 2.0);
		CompositeCurve compositeCurve = CompositeCurve.CreateRectangle(DiskData.DiskBlockWidth, DiskData.DiskBlockLength);
		compositeCurve.Translate((0.0 - DiskData.DiskDiameter) / 2.0, 0.0);
		Line line = new Line(new Point3D(DiskData.DiskBlockWidth - DiskData.DiskDiameter / 2.0, 0.0, 0.0), new Point3D(DiskData.DiskBlockWidth - DiskData.DiskDiameter / 2.0, DiskData.DiskDiameter / 2.0, 0.0));
		Point3D[] array = line.IntersectWith(c);
		List<Point3D> Points = new List<Point3D>();
		double degrees = buCall.buVector5_0.PointAngle(array[0], new Point3D());
		Arc arc = new Arc(Plane.XY, new Point3D((0.0 - DiskData.DiskDiameter) / 2.0, 0.0, 0.0), new Point3D(0.0, (0.0 - DiskData.DiskDiameter) / 2.0, 0.0), array[0], flip: false);
		arc = new Arc(Plane.XY, new Point3D(0.0, 0.0, 0.0), DiskData.DiskDiameter / 2.0, Utility.DegToRad(-180.0), Utility.DegToRad(degrees));
		arc.Regen(0.1);
		Points.Add(new Point3D(array[0].X, array[0].Y, array[0].Z));
		Points.Add(new Point3D(array[0].X, DiskData.DiskBlockLength, array[0].Z));
		Points.Add(new Point3D((0.0 - DiskData.DiskDiameter) / 2.0, DiskData.DiskBlockLength, array[0].Z));
		Points.Add(new Point3D((0.0 - DiskData.DiskDiameter) / 2.0, 0.0, array[0].Z));
		buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref Points);
		new LinearPath(Points);
		List<ICurve> list = new List<ICurve>();
		list.Add(arc);
		list.Add(new Line(Points[0], Points[1]));
		list.Add(new Line(Points[1], Points[2]));
		list.Add(new Line(Points[2], Points[3]));
		CompositeCurve compositeCurve2 = new CompositeCurve(list);
		compositeCurve2.Regen(0.1);
		devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(compositeCurve2);
		region.Regen(0.1);
		Brep brep = region.ExtrudeAsBrep(DiskData.DiskHeight);
		Circle circle = new Circle(Plane.XZ, new Point3D((0.0 - DiskData.DiskDiameter) / 2.0, 0.0, DiskData.DiskHeight / 2.0), DiskData.BlockPipeDiameter / 2.0);
		circle.Regen(0.1);
		new LinearPath(circle.Vertices);
		List<ICurve> list2 = new List<ICurve>();
		list2.Add(circle);
		devDept.Eyeshot.Entities.Region region2 = new devDept.Eyeshot.Entities.Region(list2);
		region2.Regen(0.1);
		brep.ExtrudeRemove(region2, -150.0);
		brep.RevolveRemove(region2, Utility.DegToRad(360.0), Vector3D.AxisZ, Point3D.Origin);
		if (brep != null)
		{
			brep.ColorMethod = colorMethodType.byEntity;
			brep.Color = Color.FromArgb(100, Color.Green);
			entDisk = brep;
		}
		CompositeCurve outer = CompositeCurve.CreateRectangle(DiskData.BlockWidth, DiskData.BlockDepth);
		devDept.Eyeshot.Entities.Region region3 = new devDept.Eyeshot.Entities.Region(outer);
		Brep brep2 = region3.ExtrudeAsBrep(new Vector3D(0.0, 0.0, DiskData.BlockHeight));
		Circle outer2 = new Circle(Plane.YZ, new Point3D(0.0, 0.0, DiskData.DiskHeight / 2.0), DiskData.BlockPipeDiameter / 2.0);
		devDept.Eyeshot.Entities.Region reg = new devDept.Eyeshot.Entities.Region(outer2);
		brep2.ExtrudeRemove(reg, DiskData.BlockWidth);
		if (brep2 != null)
		{
			brep2.ColorMethod = colorMethodType.byEntity;
			brep2.Color = Color.FromArgb(100, Color.GreenYellow);
			entBlock = brep2;
		}
	}

	public void SimulationPointDevide(PipeBendSimulationMove P0, PipeBendSimulationMove P1, double Length, int Count, double LastExecuteX, ref List<PipeBendSimulationMove> devidedPoints)
	{
		devidedPoints.Clear();
		if (Count <= 0)
		{
			buString5.MessageBoxError("Not Ready SimulationPointDevide");
			return;
		}
		double num = P1.YPos - P0.YPos;
		double num2 = P1.ZPos - P0.ZPos;
		double num3 = P1.CPos - P0.CPos;
		double length = P1.Length;
		double num4 = P1.YPreasurePos - P0.YPreasurePos;
		double num5 = num / (double)Count;
		double num6 = num2 / (double)Count;
		double num7 = num3 / (double)Count;
		double num8 = num4 / (double)Count;
		double num9 = Math.Round(length / (double)Count, 5);
		if (!buCompare.EQ(num3, 0.0))
		{
			num9 = Math.Abs(Math.Round(Math.PI * P1.Radius * 2.0 * Math.Abs(P1.CPos) / 360.0 / (double)Count, 5));
		}
		if (!(num != 0.0 || num2 != 0.0 || num3 != 0.0 || num4 != 0.0 || length != 0.0))
		{
			PipeBendSimulationMove pipeBendSimulationMove = new PipeBendSimulationMove(P1);
			pipeBendSimulationMove.ExecutedPipe = LastExecuteX;
			devidedPoints.Add(pipeBendSimulationMove);
			return;
		}
		for (double num10 = 1.0; num10 <= (double)Count; num10 += 1.0)
		{
			PipeBendSimulationMove pipeBendSimulationMove2 = new PipeBendSimulationMove(P0);
			pipeBendSimulationMove2.Length += num10 * num9;
			pipeBendSimulationMove2.BendPos = P1.BendPos;
			pipeBendSimulationMove2.RotatePos = P1.RotatePos;
			pipeBendSimulationMove2.IndexMove = P1.IndexMove;
			pipeBendSimulationMove2.MovePipe = P1.MovePipe;
			pipeBendSimulationMove2.YPos += num10 * num5;
			pipeBendSimulationMove2.ZPos += num10 * num6;
			pipeBendSimulationMove2.CPos += num10 * num7;
			pipeBendSimulationMove2.YPreasurePos += num10 * num8;
			pipeBendSimulationMove2.ExecutedPipe = num10 * Math.Abs(num9) + LastExecuteX;
			pipeBendSimulationMove2.ExecutedStep = num9;
			devidedPoints.Add(pipeBendSimulationMove2);
		}
	}

	public Design AddStraight(double dx, Design design1)
	{
		try
		{
			Surface surface = PipeBendTempVars._c1.ExtrudeAsSurface(0.0 - dx, 0.0, 0.0)[0];
			surface.ColorMethod = colorMethodType.byEntity;
			surface.Color = PipeBendTempVars._pipeColor;
			PlanarSurface planarSurface = devDept.Eyeshot.Entities.Region.CreateCircle(Plane.YZ, Point2D.Origin, PipeBendTempVars._pipeDiameter / 2.0).ConvertToSurface();
			planarSurface.ColorMethod = colorMethodType.byEntity;
			planarSurface.Color = PipeBendTempVars._pipeColor;
			PipeBendTempVars._straightPartCounter++;
			string name = PipeBendTempVars.StraightBlockName + PipeBendTempVars._straightPartCounter;
			Block block = new Block(name);
			block.Entities.Add(surface);
			block.Entities.Add(planarSurface);
			design1.Blocks.Add(block);
			PipeBendTempVars._surfList.Add(surface);
			PipeBendTempVars._surfList.Add(planarSurface);
			Translate(dx);
			return design1;
		}
		catch (Exception)
		{
			return design1;
		}
	}

	public Design AddStraightBack(double dx, Design design1)
	{
		Surface surface = PipeBendTempVars._c1.ExtrudeAsSurface(0.0 - dx, 0.0, 0.0)[0];
		surface.ColorMethod = colorMethodType.byEntity;
		surface.Color = PipeBendTempVars._pipeColor;
		Block block = new Block(PipeBendTempVars.StraightbackBlockName);
		block.Entities.Add(surface);
		design1.Blocks.Add(block);
		PipeBendTempVars._surfList.Add(surface);
		return design1;
	}

	public Design AddTurn(double angle, Vector3D axis, Point3D center, Design design1)
	{
		Surface surface = PipeBendTempVars._c1.RevolveAsSurface(0.0, Math.Abs(angle), axis, center)[0];
		if (angle < 0.0)
		{
			surface.Rotate(Math.PI, new Vector3D(1.0, 0.0, 0.0));
		}
		surface.ColorMethod = colorMethodType.byEntity;
		surface.Color = PipeBendTempVars._pipeColor;
		if (!(angle > 0.0))
		{
			RotatePipe(angle, axis, new Point3D(center.X, 0.0 - center.Y, center.Z));
		}
		else
		{
			RotatePipe(angle, axis, new Point3D(center.X, center.Y, center.Z));
		}
		PipeBendTempVars._bendPartCounter++;
		string name = PipeBendTempVars.BendBlockName + PipeBendTempVars._bendPartCounter;
		Block block = new Block(name);
		block.Entities.Add(surface);
		design1.Blocks.Add(block);
		PipeBendTempVars._surfList.Add(surface);
		return design1;
	}

	public void Translate(double dx)
	{
		foreach (Entity surf in PipeBendTempVars._surfList)
		{
			surf.Translate(dx, 0.0);
		}
	}

	public void RotatePipe(double angle, Vector3D axis, Point3D cen)
	{
		foreach (Entity surf in PipeBendTempVars._surfList)
		{
			surf.Rotate(angle, axis, cen);
		}
	}

	public double GetPipeLength(List<BendingLRAMaterialData> BendingList)
	{
		double num = 0.0;
		for (int i = 0; i <= BendingList.Count - 1; i++)
		{
			num += BendingList[i].Length;
			num += 2.0 * BendingList[i].Radius * Math.PI / 360.0 * BendingList[i].Angle;
		}
		return num;
	}

	public double CurveUnbending(int i, List<BendingLRAMaterialData> BendingList)
	{
		return 2.0 * BendingList[i].Radius * Math.PI / 360.0 * BendingList[i].Angle;
	}

	public double AnglePortion(double mm, int i, List<BendingLRAMaterialData> BendingList)
	{
		return mm * BendingList[i].Angle / CurveUnbending(i, BendingList);
	}

	public int GetCollisionIndex(Design design1)
	{
		for (int i = 0; i <= design1.Entities.Count - 1; i++)
		{
			BlockReference blockReference = (BlockReference)design1.Entities[i];
			for (int j = 0; j <= PipeBendTempVars._cd.Result.Length - 1; j++)
			{
				BlockReference[] array = PipeBendTempVars._cd.Result[j].CollidedEntities.Item1.Parents.ToArray();
				for (int k = 0; k <= PipeBendTempVars._cd.Result[j].CollidedEntities.Item1.Parents.Count - 1; k++)
				{
					if (FindBlockRef(PipeBendTempVars._cd.Result[j].CollidedEntities.Item1.ParentName, array) & (array[k].BlockName == blockReference.BlockName) & (array[k].InsertionPoint == blockReference.InsertionPoint))
					{
						return i;
					}
				}
				array = PipeBendTempVars._cd.Result[j].CollidedEntities.Item2.Parents.ToArray();
				for (int l = 0; l <= PipeBendTempVars._cd.Result[j].CollidedEntities.Item2.Parents.Count - 1; l++)
				{
					if (FindBlockRef(PipeBendTempVars._cd.Result[j].CollidedEntities.Item2.ParentName, array) & (array[l].BlockName == blockReference.BlockName) & (array[l].InsertionPoint == blockReference.InsertionPoint))
					{
						return i;
					}
				}
			}
		}
		return 0;
	}

	public bool FindBlockRef(string blockName, BlockReference[] parents)
	{
		for (int i = 0; i < parents.Length; i++)
		{
			if (blockName == parents[i].BlockName)
			{
				return true;
			}
		}
		return false;
	}

	public Design Highlight(Entity e, Color c, Design design1)
	{
		if (!PipeBendTempVars.originalColors.ContainsKey(e))
		{
			PipeBendTempVars.originalColors.Add(e, e.Color);
		}
		e.Color = c;
		if (e is BlockReference blockReference)
		{
			Block block = design1.Blocks[blockReference.BlockName];
			if (block != null)
			{
				foreach (Entity entity in block.Entities)
				{
					Highlight(entity, c, design1);
				}
			}
		}
		return design1;
	}

	public Design DoNotHighlight(Entity e, Design design1)
	{
		e.Color = PipeBendTempVars.originalColors[e];
		if (e is BlockReference blockReference)
		{
			Block block = design1.Blocks[blockReference.BlockName];
			if (block != null)
			{
				foreach (Entity entity in block.Entities)
				{
					DoNotHighlight(entity, design1);
				}
			}
		}
		return design1;
	}

	public Design PipeProgressAll(Design design1, List<BendingLRAMaterialData> BendingList)
	{
		PipeBendTempVars._sw.Start();
		int num = 0;
		PipeBendTempVars.doneZSteps++;
		PipeBendTempVars._numOfFileBlocks = 1;
		if (design1.Blocks.Count > 1)
		{
			while (design1.Blocks.Count > PipeBendTempVars._numOfFileBlocks)
			{
				if (design1.Blocks.Count > 1)
				{
					design1.Blocks.RemoveAt(design1.Blocks.Count - 1);
				}
			}
		}
		while ((design1.Entities.Count > PipeBendTempVars._numOfFileEntities) & (design1.Entities.Count > 0))
		{
			design1.Entities.RemoveAt(design1.Entities.Count - 1);
		}
		PipeBendTempVars._surfList.Clear();
		PipeBendTempVars._straightPartCounter = 0;
		PipeBendTempVars._bendPartCounter = 0;
		for (int i = 0; i <= BendingList.Count - 1; i++)
		{
			if (BendingList[i].Length > 0.0)
			{
				design1 = AddStraight(BendingList[i].Length, design1);
			}
			if (BendingList[i].Rotation != 0.0)
			{
				RotatePipe(BendingList[i].Rotation / 180.0 * Math.PI, Vector3D.AxisX, Point3D.Origin);
			}
			if (BendingList[i].Angle != 0.0)
			{
				design1 = ((BendingList[i].Angle > 0.0) ? AddTurn(BendingList[i].Angle / 180.0 * Math.PI, Vector3D.AxisZ, new Point3D(0.0, BendingList[i].Radius, 0.0), design1) : AddTurn(BendingList[i].Angle / 180.0 * Math.PI, Vector3D.AxisZ, new Point3D(0.0, BendingList[i].Radius, 0.0), design1));
			}
		}
		if (PipeBendTempVars._pipeTotalLength > PipeBendTempVars._excecutionPipe && num == BendingList.Count - 1)
		{
			PipeBendTempVars._excecutionPipe = PipeBendTempVars._pipeTotalLength;
		}
		foreach (Entity surf in PipeBendTempVars._surfList)
		{
			surf.Rotate(Math.PI, Vector3D.AxisX, Point3D.Origin);
			surf.Translate(PipeBendTempVars.OffsetX, PipeBendTempVars.OffsetY);
		}
		Block block = new Block("pipe");
		BlockReference item;
		for (int j = 1; j <= PipeBendTempVars._straightPartCounter; j++)
		{
			string blockName = PipeBendTempVars.StraightBlockName + j;
			item = new BlockReference(blockName);
			block.Entities.Add(item);
		}
		for (int j = 1; j <= PipeBendTempVars._bendPartCounter; j++)
		{
			string blockName = PipeBendTempVars.BendBlockName + j;
			item = new BlockReference(blockName);
			block.Entities.Add(item);
		}
		design1.Blocks.Add(block);
		item = new BlockReference("pipe");
		design1.Entities.Add(item);
		PipeBendTempVars._sw.Stop();
		design1.Entities.Regen();
		design1.ZoomFit();
		design1.Invalidate();
		return design1;
	}

	public Design PipeProgress1(Design design1, ref int rowIndex, List<BendingLRAMaterialData> BendingList)
	{
		PipeBendTempVars._sw.Start();
		double num = 0.0;
		PipeBendTempVars.doneZSteps++;
		while (design1.Blocks.Count > PipeBendTempVars._numOfFileBlocks)
		{
			design1.Blocks.RemoveAt(design1.Blocks.Count - 1);
		}
		while ((design1.Entities.Count > PipeBendTempVars._numOfFileEntities) & (design1.Entities.Count > 0))
		{
			design1.Entities.RemoveAt(design1.Entities.Count - 1);
		}
		PipeBendTempVars._surfList.Clear();
		PipeBendTempVars._straightPartCounter = 0;
		PipeBendTempVars._bendPartCounter = 0;
		while (num < PipeBendTempVars._excecutionPipe)
		{
			if (!(PipeBendTempVars._excecutionPipe >= num + BendingList[rowIndex].Length))
			{
				design1 = AddStraight(PipeBendTempVars._excecutionPipe - num, design1);
				num += PipeBendTempVars._excecutionPipe - num;
				break;
			}
			design1 = AddStraight(BendingList[rowIndex].Length, design1);
			num += BendingList[rowIndex].Length;
			if (PipeBendTempVars._excecutionPipe - num < (double)PipeBendTempVars.PipeExecStep)
			{
				PipeBendTempVars._excecutionPipe = num;
			}
			if (!(PipeBendTempVars._excecutionPipe > num))
			{
				if (!(BendingList[rowIndex].Rotation < 0.0))
				{
					PipeBendTempVars.doneZSteps++;
				}
				else
				{
					PipeBendTempVars.doneZSteps--;
				}
				double num2 = PipeBendTempVars.doneZSteps * PipeBendTempVars.StepZ;
				if (!((num2 >= BendingList[rowIndex].Rotation && num2 > 0.0) | (num2 <= BendingList[rowIndex].Rotation && num2 < 0.0)))
				{
					PipeBendTempVars._excecutionPipe -= PipeBendTempVars.PipeExecStep;
				}
				else
				{
					num2 = BendingList[rowIndex].Rotation;
					PipeBendTempVars.doneZSteps = 0;
				}
				RotatePipe(num2 / 180.0 * Math.PI, Vector3D.AxisX, Point3D.Origin);
			}
			else
			{
				RotatePipe(BendingList[rowIndex].Rotation / 180.0 * Math.PI, Vector3D.AxisX, Point3D.Origin);
			}
			if (!(PipeBendTempVars._excecutionPipe >= num + CurveUnbending(rowIndex, BendingList)))
			{
				double num3 = PipeBendTempVars._excecutionPipe - num;
				if (num3 > 0.0)
				{
					design1 = AddTurn(AnglePortion(num3, rowIndex, BendingList) / 180.0 * Math.PI, Vector3D.AxisZ, new Point3D(0.0, BendingList[rowIndex].Radius, 0.0), design1);
					num += num3;
				}
				continue;
			}
			if (BendingList[rowIndex].Angle > 0.0)
			{
				design1 = AddTurn(BendingList[rowIndex].Angle / 180.0 * Math.PI, Vector3D.AxisZ, new Point3D(0.0, BendingList[rowIndex].Radius, 0.0), design1);
				num += CurveUnbending(rowIndex, BendingList);
			}
			if (rowIndex != PipeBendTempVars._pipeRowQuantity - 1)
			{
				continue;
			}
			break;
		}
		if (PipeBendTempVars._pipeTotalLength > PipeBendTempVars._excecutionPipe)
		{
			design1 = AddStraightBack(PipeBendTempVars._pipeTotalLength - PipeBendTempVars._excecutionPipe, design1);
			if (rowIndex == PipeBendTempVars._pipeRowQuantity - 1)
			{
				PipeBendTempVars._excecutionPipe = PipeBendTempVars._pipeTotalLength;
			}
		}
		foreach (Entity surf in PipeBendTempVars._surfList)
		{
			surf.Rotate(Math.PI, Vector3D.AxisX, Point3D.Origin);
			surf.Translate(PipeBendTempVars.OffsetX, PipeBendTempVars.OffsetY);
		}
		Block block = new Block("pipe");
		BlockReference item;
		for (int i = 1; i <= PipeBendTempVars._straightPartCounter; i++)
		{
			string blockName = PipeBendTempVars.StraightBlockName + i;
			item = new BlockReference(blockName);
			block.Entities.Add(item);
		}
		for (int i = 1; i <= PipeBendTempVars._bendPartCounter; i++)
		{
			string blockName = PipeBendTempVars.BendBlockName + i;
			item = new BlockReference(blockName);
			block.Entities.Add(item);
		}
		design1.Blocks.Add(block);
		item = new BlockReference("pipe");
		design1.Entities.Add(item);
		try
		{
			item = new BlockReference(PipeBendTempVars.StraightbackBlockName);
			block.Entities.Add(item);
		}
		catch
		{
		}
		if (PipeBendTempVars._excecutionPipe != PipeBendTempVars._pipeTotalLength)
		{
			timer_0.Enabled = true;
		}
		else
		{
			timer_0.Enabled = false;
			PipeBendTempVars._sw.Stop();
		}
		List<Entity> list = new List<Entity>();
		Block block2 = new Block(PipeBendTempVars.MachineBlockName);
		int[] machineCollisionEntities = PipeBendTempVars.machineCollisionEntities;
		foreach (int index in machineCollisionEntities)
		{
			block2.Entities.Add(design1.Entities[index]);
		}
		item = new BlockReference(PipeBendTempVars.MachineBlockName);
		design1.Blocks.Add(block2);
		list.Add(item);
		list.Add(design1.Entities[design1.Entities.Count - 1]);
		if (varPipeBendingProgramSettings.CollisionCheck)
		{
			PipeBendTempVars._cd = new CollisionDetection(list, design1.Blocks, PipeBendTempVars._firstOnly, PipeBendTempVars._checkMethod);
			PipeBendTempVars._cd.DoWork();
			if (PipeBendTempVars._cd.Result != null && PipeBendTempVars._cd.Result.Length != 0)
			{
				PipeBendTempVars._entityCollisionIndex = GetCollisionIndex(design1);
				PipeBendTempVars.collidedEntities.Add(design1.Entities[PipeBendTempVars._entityCollisionIndex]);
				design1.Entities[PipeBendTempVars._entityCollisionIndex].ColorMethod = colorMethodType.byEntity;
				Highlight(design1.Entities[PipeBendTempVars._entityCollisionIndex], PipeBendTempVars.collisionColor, design1);
				timer_0.Enabled = false;
				timer_1.Enabled = true;
				PipeBendTempVars._sw.Stop();
			}
		}
		PipeBendTempVars._sw.Stop();
		design1.Entities.Regen();
		design1.Invalidate();
		return design1;
	}
}
