using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using Opaline2Cs;
using buCadCamResVer5.Nesting;
using buClass;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Apps.PanelCut;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buCadCamResVer5.PanelCut;

public class clsNestOpaline
{
	public struct Point
	{
		public double X;

		public double Y;

		public Point(double x, double y)
		{
			X = x;
			Y = y;
		}

		public Point(Opaline opaline, Node node)
		{
			X = opaline.GetNodeDimensionAux(node, Direction.XDirection);
			Y = opaline.GetNodeDimensionAux(node, Direction.YDirection);
		}

		public override string ToString()
		{
			return "X: " + X + "  Y: " + Y;
		}
	}

	public Opaline _Opaline = new Opaline();

	public Rectangle2D lastAssemblyRectangle = new Rectangle2D();

	public Direction lastAssemblyDirection = Direction.XDirection;

	[CompilerGenerated]
	private OkCommandWithDataEventHandler okCommandWithDataEventHandler_0;

	public int NodeID = 0;

	public string DllName => Opaline.GetDllName();

	public event OkCommandWithDataEventHandler CalculationDone
	{
		[CompilerGenerated]
		add
		{
			OkCommandWithDataEventHandler okCommandWithDataEventHandler = okCommandWithDataEventHandler_0;
			OkCommandWithDataEventHandler okCommandWithDataEventHandler2;
			do
			{
				okCommandWithDataEventHandler2 = okCommandWithDataEventHandler;
				OkCommandWithDataEventHandler value2 = (OkCommandWithDataEventHandler)Delegate.Combine(okCommandWithDataEventHandler2, value);
				okCommandWithDataEventHandler = Interlocked.CompareExchange(ref okCommandWithDataEventHandler_0, value2, okCommandWithDataEventHandler2);
			}
			while ((object)okCommandWithDataEventHandler != okCommandWithDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandWithDataEventHandler okCommandWithDataEventHandler = okCommandWithDataEventHandler_0;
			OkCommandWithDataEventHandler okCommandWithDataEventHandler2;
			do
			{
				okCommandWithDataEventHandler2 = okCommandWithDataEventHandler;
				OkCommandWithDataEventHandler value2 = (OkCommandWithDataEventHandler)Delegate.Remove(okCommandWithDataEventHandler2, value);
				okCommandWithDataEventHandler = Interlocked.CompareExchange(ref okCommandWithDataEventHandler_0, value2, okCommandWithDataEventHandler2);
			}
			while ((object)okCommandWithDataEventHandler != okCommandWithDataEventHandler2);
		}
	}

	public void Execute()
	{
		_Opaline = new Opaline();
		NodeID = 0;
		clsInit.appPanelCut.activeJob = new NestingPanelJob();
		int num = 0;
		_Opaline.SetDefaultMargins(clsPanelCut.varPanelCutSettings.GeneralTrimWidth, 0.0, clsPanelCut.varPanelCutSettings.GeneralTrimHeight, 0.0, 0.0, 0.0);
		for (int i = 0; i <= clsNesting.Sheets.Count - 1; i++)
		{
			if (clsNesting.Sheets[i].Enable)
			{
				double x = clsNesting.Sheets[i].MaterialData.Width - clsPanelCut.varPanelCutSettings.GeneralTrimWidth;
				double y = clsNesting.Sheets[i].MaterialData.Height - clsPanelCut.varPanelCutSettings.GeneralTrimHeight;
				if (clsNesting.Sheets[i].TrimWidth != 0.0)
				{
					x = clsNesting.Sheets[i].MaterialData.Width - clsNesting.Sheets[i].TrimWidth;
				}
				if (clsNesting.Sheets[i].TrimHeight != 0.0)
				{
					y = clsNesting.Sheets[i].MaterialData.Height - clsNesting.Sheets[i].TrimHeight;
				}
				Block block = _Opaline.CreateBlock(x, y, 1.0, clsNesting.Sheets[i].Cost, (uint)clsNesting.Sheets[i].Remain);
				_Opaline.SetBlockUserData(block, num);
				clsInit.appPanelCut.activeJob.Sheets.Add(new Rectangle2D(clsNesting.Sheets[i].MaterialData.Width, clsNesting.Sheets[i].MaterialData.Height));
				num++;
			}
		}
		int num2 = 0;
		List<Rectangle2D> list = new List<Rectangle2D>();
		for (int j = 0; j <= clsNesting.Parts.Count - 1; j++)
		{
			clsNesting.Parts[j].ID = j + 1;
			if (clsNesting.Parts[j].Enable)
			{
				double num3 = clsNesting.Parts[j].PartData.Width + clsNesting.Parts[j].PrecutWidth;
				double num4 = clsNesting.Parts[j].PartData.Height + clsNesting.Parts[j].PrecutHeight;
				if (clsNesting.Parts[j].EdgeLeft)
				{
					num3 -= clsNesting.Parts[j].EdgeLeftThickness;
				}
				if (clsNesting.Parts[j].EdgeRight)
				{
					num3 -= clsNesting.Parts[j].EdgeRightThickness;
				}
				if (clsNesting.Parts[j].EdgeTop)
				{
					num4 -= clsNesting.Parts[j].EdgeTopThickness;
				}
				if (clsNesting.Parts[j].EdgeBottom)
				{
					num4 -= clsNesting.Parts[j].EdgeBottomThickness;
				}
				Part part = _Opaline.CreatePart((uint)clsNesting.Parts[j].Remain, (uint)clsNesting.Parts[j].Remain, clsNesting.Parts[j].Price);
				OpalineModule module = _Opaline.CreateSimpleModule(part, 1u, num3, num4, 1.0);
				_Opaline.SetModuleUserData(module, num2);
				clsInit.appPanelCut.activeJob.Parts.Add(new Rectangle2D(num3, num4));
				num2++;
				module = _Opaline.CreateSimpleModule(part, 1u, num4, num3, 1.0);
				_Opaline.SetModuleUserData(module, num2);
				clsInit.appPanelCut.activeJob.Parts.Add(new Rectangle2D(num4, num3));
				clsInit.appPanelCut.activeJob.usedParts.Add(new buNestingPart(clsNesting.Parts[j]));
				num2++;
				list.Add(new Rectangle2D(num3, num4));
				list.Add(new Rectangle2D(num4, num3));
			}
		}
		if (!(clsPanelCut.varPanelCutSettings.SawThickness >= 0.0))
		{
			_Opaline.SetSawingDistance(0.0);
		}
		else
		{
			_Opaline.SetSawingDistance(clsPanelCut.varPanelCutSettings.SawThickness);
		}
		if (clsPanelCut.varPanelCutSettings.MaxOptimisationDepth < 0)
		{
		}
		double num5 = clsPanelCut.varPanelCutSettings.NestingExecuteTimeSec;
		if (num5 <= 0.0)
		{
			num5 = 3.0;
		}
		uint num6 = _Opaline.Optimize(num5);
		lastAssemblyRectangle = null;
		_Opaline.GetNestingsStatistics(out var _, out var _, out var _);
		uint multiplicity = 0u;
		Node root = null;
		Block block2 = null;
		_Opaline.GetNestingInfo(1u, out multiplicity, out root, out block2);
		for (uint num7 = 0u; num7 < num6; num7++)
		{
			uint nestingMultiplicity = _Opaline.GetNestingMultiplicity(num7);
			Block nestingBlock = _Opaline.GetNestingBlock(num7);
			_Opaline.GetBlockUserData(nestingBlock);
			double x2 = 0.0;
			double y2 = 0.0;
			double z = 0.0;
			double cost = 0.0;
			uint nbBlocks = 0u;
			_Opaline.GetBlock(nestingBlock, out x2, out y2, out z, out cost, out nbBlocks);
			List<Rectangle2D> RectanglesList = new List<Rectangle2D>();
			clsInit.appPanelCut.cutPanel = new NestingPanel();
			clsInit.appPanelCut.cutPanel.Count = (int)nestingMultiplicity;
			clsInit.appPanelCut.cutPanel.Width = x2 - clsPanelCut.varPanelCutSettings.SawThickness;
			clsInit.appPanelCut.cutPanel.Height = y2 - clsPanelCut.varPanelCutSettings.SawThickness;
			clsInit.appPanelCut.cutPanel.PanelArea = x2 * y2;
			GetRectangles(num7, ref RectanglesList);
			for (int k = 0; k <= RectanglesList.Count - 1; k++)
			{
				clsInit.appPanelCut.cutPanel.CalculatedRectangles.Add(new Rectangle2D(RectanglesList[k]));
				List<Point3D> Vertices = new List<Point3D>();
				Rectangle2D.Rectangle3DToVertices(RectanglesList[k], ref Vertices);
				LinearPath linearPath = new LinearPath(Vertices);
				linearPath.ColorMethod = colorMethodType.byEntity;
				linearPath.Color = Color.Red;
				if (k == RectanglesList.Count - 1)
				{
					linearPath.ColorMethod = colorMethodType.byEntity;
					linearPath.Color = Color.Blue;
				}
			}
			GetCuttingTree(_Opaline.GetNestingRoot(num7), 0, new Point(clsPanelCut.varPanelCutSettings.GeneralTrimWidth, clsPanelCut.varPanelCutSettings.GeneralTrimHeight));
			clsInit.appPanelCut.cutPanel.PartsArea = 0.0;
			clsInit.cPanelCut.GetPanelPartArea(list, clsInit.appPanelCut.cutPanel.Nodes, ref clsInit.appPanelCut.cutPanel.PartsArea);
			if (clsInit.appPanelCut.cutPanel.PanelArea > 0.0)
			{
				clsInit.appPanelCut.cutPanel.Waste = clsInit.appPanelCut.cutPanel.PartsArea / clsInit.appPanelCut.cutPanel.PanelArea * 100.0;
			}
			clsInit.appPanelCut.activeJob.Panels.Add(clsInit.appPanelCut.cutPanel);
		}
		if (okCommandWithDataEventHandler_0 != null)
		{
			okCommandWithDataEventHandler_0(null);
		}
		_Opaline.Dispose();
		_Opaline = null;
	}

	public void GetCuttingTree(Node node, int depth, Point lower_left)
	{
		NestingPanelNode nestingPanelNode = new NestingPanelNode();
		double Width = 0.0;
		double Height = 0.0;
		GetNodeDimensions(node, depth, ref Width, ref Height);
		Point point = new Point(_Opaline, node);
		NodeType nodeType = _Opaline.GetNodeType(node);
		if (nodeType != NodeType.AssemblyNode)
		{
			if (nodeType != NodeType.ModuleNode)
			{
				if (nodeType == NodeType.OffcutNode)
				{
					nestingPanelNode.NodeType = nestPanelNodeType.OffCut;
					double x = 0.0;
					double y = 0.0;
					double z = 0.0;
					_Opaline.GetNodeDimension(node, out x, out y, out z);
					nestingPanelNode.DimensionX = x;
					nestingPanelNode.DimensionY = y;
					nestingPanelNode.Rectangle = new Rectangle2D(new Point3D(lower_left.X, lower_left.Y), x, y);
					nestingPanelNode.Depth = depth;
					nestingPanelNode.NodeID = NodeID;
					NodeID++;
					if (nestingPanelNode != null)
					{
						if (clsInit.appPanelCut.cutPanel.Nodes.Count <= 0)
						{
							clsInit.appPanelCut.cutPanel.Nodes.Add(nestingPanelNode);
						}
						else
						{
							if (depth == 1)
							{
								NestingPanelNode nestingPanelNode2 = clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1];
								nestingPanelNode2.Node.Add(nestingPanelNode);
							}
							if (depth == 2)
							{
								NestingPanelNode nestingPanelNode3 = clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1];
								NestingPanelNode nestingPanelNode4 = nestingPanelNode3.Node[nestingPanelNode3.Node.Count - 1];
								nestingPanelNode4.Node.Add(nestingPanelNode);
							}
							if (depth == 3)
							{
								NestingPanelNode nestingPanelNode5 = clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1];
								NestingPanelNode nestingPanelNode6 = nestingPanelNode5.Node[nestingPanelNode5.Node.Count - 1];
								NestingPanelNode nestingPanelNode7 = nestingPanelNode6.Node[nestingPanelNode6.Node.Count - 1];
								nestingPanelNode7.Node.Add(nestingPanelNode);
							}
							if (depth == 4)
							{
								NestingPanelNode nestingPanelNode8 = clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1];
								NestingPanelNode nestingPanelNode9 = nestingPanelNode8.Node[nestingPanelNode8.Node.Count - 1];
								NestingPanelNode nestingPanelNode10 = nestingPanelNode9.Node[nestingPanelNode9.Node.Count - 1];
								NestingPanelNode nestingPanelNode11 = nestingPanelNode10.Node[nestingPanelNode10.Node.Count - 1];
								nestingPanelNode11.Node.Add(nestingPanelNode);
							}
							if (depth == 5)
							{
								NestingPanelNode nestingPanelNode12 = clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1];
								NestingPanelNode nestingPanelNode13 = nestingPanelNode12.Node[nestingPanelNode12.Node.Count - 1];
								NestingPanelNode nestingPanelNode14 = nestingPanelNode13.Node[nestingPanelNode13.Node.Count - 1];
								NestingPanelNode nestingPanelNode15 = nestingPanelNode14.Node[nestingPanelNode14.Node.Count - 1];
								NestingPanelNode nestingPanelNode16 = nestingPanelNode15.Node[nestingPanelNode15.Node.Count - 1];
								nestingPanelNode16.Node.Add(nestingPanelNode);
							}
						}
					}
				}
			}
			else
			{
				nestingPanelNode.NodeType = nestPanelNodeType.Module;
				OpalineModule moduleNodeModule = _Opaline.GetModuleNodeModule(node);
				uint moduleNodeQuantity = _Opaline.GetModuleNodeQuantity(node, Direction.XDirection);
				uint moduleNodeQuantity2 = _Opaline.GetModuleNodeQuantity(node, Direction.YDirection);
				nestingPanelNode.XQuantity = (int)moduleNodeQuantity;
				nestingPanelNode.YQuantity = (int)moduleNodeQuantity2;
				nestingPanelNode.LowerLeft.X = lower_left.X;
				nestingPanelNode.LowerLeft.Y = lower_left.Y;
				nestingPanelNode.DimensionX = point.X;
				nestingPanelNode.DimensionY = point.Y;
				nestingPanelNode.Depth = depth;
				nestingPanelNode.PartID = _Opaline.GetModuleUserData(moduleNodeModule);
				nestingPanelNode.Rectangle = new Rectangle2D(nestingPanelNode.LowerLeft, nestingPanelNode.DimensionX, nestingPanelNode.DimensionY);
				nestingPanelNode.NodeID = NodeID;
				int moduleUserData = _Opaline.GetModuleUserData(moduleNodeModule);
				int num = moduleUserData % 2;
				if ((num >= 0) & (num < clsNesting.Parts.Count - 1))
				{
					nestingPanelNode.ID = clsNesting.Parts[num].ID;
				}
				NodeID++;
				if (lastAssemblyDirection == Direction.YDirection)
				{
					nestingPanelNode.CutFeedDistance = nestingPanelNode.DimensionY;
					nestingPanelNode.CutSawDistance = nestingPanelNode.DimensionX;
					nestingPanelNode.CutOffset = lower_left.X;
				}
				if (lastAssemblyDirection == Direction.XDirection)
				{
					nestingPanelNode.CutFeedDistance = nestingPanelNode.DimensionY;
					nestingPanelNode.CutSawDistance = nestingPanelNode.DimensionX;
					nestingPanelNode.CutOffset = lower_left.X;
				}
				if (lastAssemblyRectangle != null)
				{
					nestingPanelNode.BaseRectangle = new Rectangle2D(lastAssemblyRectangle);
				}
				clsInit.appPanelCut.cutPanel.PartCount = clsInit.appPanelCut.cutPanel.PartCount + nestingPanelNode.XQuantity * nestingPanelNode.YQuantity;
				if (nestingPanelNode != null)
				{
					if (clsInit.appPanelCut.cutPanel.Nodes.Count <= 0)
					{
						clsInit.appPanelCut.cutPanel.Nodes.Add(nestingPanelNode);
					}
					else
					{
						if (depth == 1)
						{
							NestingPanelNode nestingPanelNode17 = clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1];
							nestingPanelNode17.Node.Add(nestingPanelNode);
						}
						if (depth == 2)
						{
							NestingPanelNode nestingPanelNode18 = clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1];
							NestingPanelNode nestingPanelNode19 = nestingPanelNode18.Node[nestingPanelNode18.Node.Count - 1];
							nestingPanelNode19.Node.Add(nestingPanelNode);
						}
						if (depth == 3)
						{
							NestingPanelNode nestingPanelNode20 = clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1];
							NestingPanelNode nestingPanelNode21 = nestingPanelNode20.Node[nestingPanelNode20.Node.Count - 1];
							NestingPanelNode nestingPanelNode22 = nestingPanelNode21.Node[nestingPanelNode21.Node.Count - 1];
							nestingPanelNode22.Node.Add(nestingPanelNode);
						}
						if (depth == 4)
						{
							NestingPanelNode nestingPanelNode23 = clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1];
							NestingPanelNode nestingPanelNode24 = nestingPanelNode23.Node[nestingPanelNode23.Node.Count - 1];
							NestingPanelNode nestingPanelNode25 = nestingPanelNode24.Node[nestingPanelNode24.Node.Count - 1];
							NestingPanelNode nestingPanelNode26 = nestingPanelNode25.Node[nestingPanelNode25.Node.Count - 1];
							nestingPanelNode26.Node.Add(nestingPanelNode);
						}
						if (depth == 5)
						{
							NestingPanelNode nestingPanelNode27 = clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1];
							NestingPanelNode nestingPanelNode28 = nestingPanelNode27.Node[nestingPanelNode27.Node.Count - 1];
							NestingPanelNode nestingPanelNode29 = nestingPanelNode28.Node[nestingPanelNode28.Node.Count - 1];
							NestingPanelNode nestingPanelNode30 = nestingPanelNode29.Node[nestingPanelNode29.Node.Count - 1];
							NestingPanelNode nestingPanelNode31 = nestingPanelNode30.Node[nestingPanelNode30.Node.Count - 1];
							nestingPanelNode31.Node.Add(nestingPanelNode);
						}
						if (depth == 6)
						{
							NestingPanelNode nestingPanelNode32 = clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1];
							NestingPanelNode nestingPanelNode33 = nestingPanelNode32.Node[nestingPanelNode32.Node.Count - 1];
							NestingPanelNode nestingPanelNode34 = nestingPanelNode33.Node[nestingPanelNode33.Node.Count - 1];
							NestingPanelNode nestingPanelNode35 = nestingPanelNode34.Node[nestingPanelNode34.Node.Count - 1];
							NestingPanelNode nestingPanelNode36 = nestingPanelNode35.Node[nestingPanelNode35.Node.Count - 1];
							NestingPanelNode nestingPanelNode37 = nestingPanelNode36.Node[nestingPanelNode36.Node.Count - 1];
							nestingPanelNode37.Node.Add(nestingPanelNode);
						}
						if (depth == 7)
						{
							NestingPanelNode nestingPanelNode38 = clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1];
							NestingPanelNode nestingPanelNode39 = nestingPanelNode38.Node[nestingPanelNode38.Node.Count - 1];
							NestingPanelNode nestingPanelNode40 = nestingPanelNode39.Node[nestingPanelNode39.Node.Count - 1];
							NestingPanelNode nestingPanelNode41 = nestingPanelNode40.Node[nestingPanelNode40.Node.Count - 1];
							NestingPanelNode nestingPanelNode42 = nestingPanelNode41.Node[nestingPanelNode41.Node.Count - 1];
							NestingPanelNode nestingPanelNode43 = nestingPanelNode42.Node[nestingPanelNode42.Node.Count - 1];
							NestingPanelNode nestingPanelNode44 = nestingPanelNode43.Node[nestingPanelNode43.Node.Count - 1];
							nestingPanelNode44.Node.Add(nestingPanelNode);
						}
						if (depth == 8)
						{
							NestingPanelNode nestingPanelNode45 = clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1];
							NestingPanelNode nestingPanelNode46 = nestingPanelNode45.Node[nestingPanelNode45.Node.Count - 1];
							NestingPanelNode nestingPanelNode47 = nestingPanelNode46.Node[nestingPanelNode46.Node.Count - 1];
							NestingPanelNode nestingPanelNode48 = nestingPanelNode47.Node[nestingPanelNode47.Node.Count - 1];
							NestingPanelNode nestingPanelNode49 = nestingPanelNode48.Node[nestingPanelNode48.Node.Count - 1];
							NestingPanelNode nestingPanelNode50 = nestingPanelNode49.Node[nestingPanelNode49.Node.Count - 1];
							NestingPanelNode nestingPanelNode51 = nestingPanelNode50.Node[nestingPanelNode50.Node.Count - 1];
							NestingPanelNode nestingPanelNode52 = nestingPanelNode51.Node[nestingPanelNode51.Node.Count - 1];
							nestingPanelNode52.Node.Add(nestingPanelNode);
						}
						if (depth == 9)
						{
							NestingPanelNode nestingPanelNode53 = clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1];
							NestingPanelNode nestingPanelNode54 = nestingPanelNode53.Node[nestingPanelNode53.Node.Count - 1];
							NestingPanelNode nestingPanelNode55 = nestingPanelNode54.Node[nestingPanelNode54.Node.Count - 1];
							NestingPanelNode nestingPanelNode56 = nestingPanelNode55.Node[nestingPanelNode55.Node.Count - 1];
							NestingPanelNode nestingPanelNode57 = nestingPanelNode56.Node[nestingPanelNode56.Node.Count - 1];
							NestingPanelNode nestingPanelNode58 = nestingPanelNode57.Node[nestingPanelNode57.Node.Count - 1];
							NestingPanelNode nestingPanelNode59 = nestingPanelNode58.Node[nestingPanelNode58.Node.Count - 1];
							NestingPanelNode nestingPanelNode60 = nestingPanelNode59.Node[nestingPanelNode59.Node.Count - 1];
							NestingPanelNode nestingPanelNode61 = nestingPanelNode60.Node[nestingPanelNode60.Node.Count - 1];
							nestingPanelNode61.Node.Add(nestingPanelNode);
						}
					}
					Rectangle2D rectangle2D = new Rectangle2D(clsInit.appPanelCut.activeJob.Parts[nestingPanelNode.PartID]);
					for (int i = 1; i <= nestingPanelNode.XQuantity; i++)
					{
						NestingPanelNode nestingPanelNode62 = new NestingPanelNode();
						nestingPanelNode62.NodeType = nestPanelNodeType.CutLine;
						nestingPanelNode62.Direction = DirectionXandY.XDirection;
						double sawThickness = clsPanelCut.varPanelCutSettings.SawThickness;
						nestingPanelNode62.LowerLeft.X = lower_left.X;
						nestingPanelNode62.LowerLeft.Y = lower_left.Y;
						nestingPanelNode62.DimensionX = rectangle2D.Width;
						nestingPanelNode62.DimensionY = point.Y;
						nestingPanelNode62.PartID = _Opaline.GetModuleUserData(moduleNodeModule);
						Point3D startPoint = new Point3D(nestingPanelNode62.LowerLeft.X + (double)(i - 1) * (rectangle2D.Width + sawThickness), nestingPanelNode62.LowerLeft.Y);
						nestingPanelNode62.Rectangle = new Rectangle2D(startPoint, rectangle2D.Width, nestingPanelNode.DimensionY);
						nestingPanelNode62.BaseRectangle = new Rectangle2D(nestingPanelNode.Rectangle);
						nestingPanelNode62.CutLine = new Line2D(new Point3D(nestingPanelNode62.LowerLeft.X + (double)(i - 1) * sawThickness + (double)i * rectangle2D.Width + sawThickness / 2.0, 0.0), 0.0, nestingPanelNode.DimensionY);
						nestingPanelNode62.CutFeedDistance = nestingPanelNode62.LowerLeft.X + (double)(i - 1) * sawThickness + (double)i * rectangle2D.Width + sawThickness / 2.0;
						nestingPanelNode62.CutSawDistance = nestingPanelNode62.DimensionY;
						nestingPanelNode62.Depth = depth;
						nestingPanelNode62.NodeID = NodeID;
						nestingPanelNode62.ID = nestingPanelNode.ID;
						NodeID++;
						clsInit.appPanelCut.cutPanel.TotalCutLength = clsInit.appPanelCut.cutPanel.TotalCutLength + Point3D.Distance(nestingPanelNode62.CutLine.StartPoint, nestingPanelNode62.CutLine.EndPoint);
						nestingPanelNode.Node.Add(nestingPanelNode62);
						if (nestingPanelNode.YQuantity > 1)
						{
							for (int j = 1; j <= nestingPanelNode.YQuantity; j++)
							{
								NestingPanelNode nestingPanelNode63 = new NestingPanelNode();
								nestingPanelNode63.Direction = DirectionXandY.YDirection;
								nestingPanelNode63.NodeType = nestPanelNodeType.CutLine;
								nestingPanelNode63.LowerLeft.X = lower_left.X + (double)(i - 1) * rectangle2D.Width;
								nestingPanelNode63.LowerLeft.Y = lower_left.Y;
								nestingPanelNode63.DimensionX = rectangle2D.Width;
								nestingPanelNode63.DimensionY = rectangle2D.Height;
								nestingPanelNode63.PartID = _Opaline.GetModuleUserData(moduleNodeModule);
								startPoint = new Point3D(nestingPanelNode62.LowerLeft.X + (double)(i - 1) * rectangle2D.Width + sawThickness, nestingPanelNode62.LowerLeft.Y + (double)(j - 1) * rectangle2D.Height + sawThickness);
								nestingPanelNode63.Rectangle = new Rectangle2D(startPoint, rectangle2D.Width, rectangle2D.Height);
								nestingPanelNode63.BaseRectangle = new Rectangle2D(nestingPanelNode62.Rectangle);
								nestingPanelNode63.CutLine = new Line2D(new Point3D(nestingPanelNode63.LowerLeft.X, (double)(j - 1) * sawThickness + (double)j * rectangle2D.Height + sawThickness / 2.0), rectangle2D.Width, 0.0);
								nestingPanelNode63.CutFeedDistance = (double)(j - 1) * sawThickness + (double)j * rectangle2D.Height + sawThickness / 2.0;
								nestingPanelNode63.CutSawDistance = nestingPanelNode63.DimensionX;
								nestingPanelNode63.Depth = depth + 1;
								nestingPanelNode63.ID = nestingPanelNode.ID;
								clsInit.appPanelCut.cutPanel.TotalCutLength = clsInit.appPanelCut.cutPanel.TotalCutLength + Point3D.Distance(nestingPanelNode63.CutLine.StartPoint, nestingPanelNode63.CutLine.EndPoint);
								nestingPanelNode63.NodeID = NodeID;
								NodeID++;
								nestingPanelNode62.Node.Add(nestingPanelNode63);
							}
						}
					}
				}
			}
		}
		else
		{
			nestingPanelNode.NodeType = nestPanelNodeType.Assembly;
			Direction assemblyDirection = _Opaline.GetAssemblyDirection(node);
			uint assemblyNbSubNodes = _Opaline.GetAssemblyNbSubNodes(node);
			nestingPanelNode.DimensionX = Width;
			nestingPanelNode.DimensionY = Height;
			nestingPanelNode.Rectangle = new Rectangle2D(new Point3D(lower_left.X, lower_left.Y), Width, Height);
			nestingPanelNode.Depth = depth;
			if (lastAssemblyRectangle != null)
			{
				nestingPanelNode.BaseRectangle = new Rectangle2D(lastAssemblyRectangle);
			}
			if (assemblyDirection == Direction.XDirection)
			{
				nestingPanelNode.Direction = DirectionXandY.XDirection;
				nestingPanelNode.CutFeedDistance = nestingPanelNode.DimensionX;
				nestingPanelNode.CutSawDistance = nestingPanelNode.DimensionY;
				nestingPanelNode.CutOffset = lower_left.X;
			}
			if (assemblyDirection == Direction.YDirection)
			{
				nestingPanelNode.Direction = DirectionXandY.YDirection;
				nestingPanelNode.CutLine = new Line2D(new Point3D(lower_left.X + Width + clsPanelCut.varPanelCutSettings.SawThickness / 2.0, lower_left.Y), new Point3D(lower_left.X + Width + clsPanelCut.varPanelCutSettings.SawThickness / 2.0, lower_left.Y + Height));
				nestingPanelNode.CutFeedDistance = nestingPanelNode.DimensionX;
				nestingPanelNode.CutSawDistance = nestingPanelNode.DimensionY;
				nestingPanelNode.CutOffset = lower_left.X;
			}
			nestingPanelNode.NodeID = NodeID;
			NodeID++;
			lastAssemblyRectangle = new Rectangle2D(nestingPanelNode.Rectangle);
			lastAssemblyDirection = assemblyDirection;
			if (nestingPanelNode != null)
			{
				if (clsInit.appPanelCut.cutPanel.Nodes.Count <= 0)
				{
					clsInit.appPanelCut.cutPanel.Nodes.Add(nestingPanelNode);
				}
				else
				{
					if (depth == 1)
					{
						NestingPanelNode nestingPanelNode64 = clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1];
						nestingPanelNode64.Node.Add(nestingPanelNode);
					}
					if (depth == 2)
					{
						NestingPanelNode nestingPanelNode65 = clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1];
						NestingPanelNode nestingPanelNode66 = nestingPanelNode65.Node[nestingPanelNode65.Node.Count - 1];
						nestingPanelNode66.Node.Add(nestingPanelNode);
					}
					if (depth == 3)
					{
						NestingPanelNode nestingPanelNode67 = clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1];
						NestingPanelNode nestingPanelNode68 = nestingPanelNode67.Node[nestingPanelNode67.Node.Count - 1];
						NestingPanelNode nestingPanelNode69 = nestingPanelNode68.Node[nestingPanelNode68.Node.Count - 1];
						nestingPanelNode69.Node.Add(nestingPanelNode);
					}
					if (depth == 4)
					{
						NestingPanelNode nestingPanelNode70 = clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1];
						NestingPanelNode nestingPanelNode71 = nestingPanelNode70.Node[nestingPanelNode70.Node.Count - 1];
						NestingPanelNode nestingPanelNode72 = nestingPanelNode71.Node[nestingPanelNode71.Node.Count - 1];
						NestingPanelNode nestingPanelNode73 = nestingPanelNode72.Node[nestingPanelNode72.Node.Count - 1];
						nestingPanelNode73.Node.Add(nestingPanelNode);
					}
					if (depth == 5)
					{
						NestingPanelNode nestingPanelNode74 = clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1];
						NestingPanelNode nestingPanelNode75 = nestingPanelNode74.Node[nestingPanelNode74.Node.Count - 1];
						NestingPanelNode nestingPanelNode76 = nestingPanelNode75.Node[nestingPanelNode75.Node.Count - 1];
						NestingPanelNode nestingPanelNode77 = nestingPanelNode76.Node[nestingPanelNode76.Node.Count - 1];
						NestingPanelNode nestingPanelNode78 = nestingPanelNode77.Node[nestingPanelNode77.Node.Count - 1];
						nestingPanelNode78.Node.Add(nestingPanelNode);
					}
					if (depth == 6)
					{
						NestingPanelNode nestingPanelNode79 = clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1];
						NestingPanelNode nestingPanelNode80 = nestingPanelNode79.Node[nestingPanelNode79.Node.Count - 1];
						NestingPanelNode nestingPanelNode81 = nestingPanelNode80.Node[nestingPanelNode80.Node.Count - 1];
						NestingPanelNode nestingPanelNode82 = nestingPanelNode81.Node[nestingPanelNode81.Node.Count - 1];
						NestingPanelNode nestingPanelNode83 = nestingPanelNode82.Node[nestingPanelNode82.Node.Count - 1];
						NestingPanelNode nestingPanelNode84 = nestingPanelNode83.Node[nestingPanelNode83.Node.Count - 1];
						nestingPanelNode84.Node.Add(nestingPanelNode);
					}
				}
			}
			for (uint num2 = 0u; num2 < assemblyNbSubNodes; num2++)
			{
				Node assemblySubNode = _Opaline.GetAssemblySubNode(node, num2);
				GetCuttingTree(assemblySubNode, depth + 1, lower_left);
				switch (assemblyDirection)
				{
				case Direction.XDirection:
					lower_left.X += new Point(_Opaline, assemblySubNode).X;
					break;
				case Direction.YDirection:
					lower_left.Y += new Point(_Opaline, assemblySubNode).Y;
					break;
				}
			}
		}
		if (nestingPanelNode == null)
		{
		}
	}

	public void GetRectangles(uint nestingNumber, ref List<Rectangle2D> RectanglesList)
	{
		RectanglesList = new List<Rectangle2D>();
		Rectangles nestingRectangles = _Opaline.GetNestingRectangles(nestingNumber);
		uint nbRectangles = _Opaline.GetNbRectangles(nestingRectangles);
		for (uint num = 0u; num < nbRectangles; num++)
		{
			_Opaline.GetRectangleInfo(nestingRectangles, num, out var node, out var x, out var y, out var _);
			Rectangle2D rectangle2D = new Rectangle2D();
			rectangle2D.StartPoint = new Point3D(x, y);
			GetNodeDimensions(node, 1, ref rectangle2D.Width, ref rectangle2D.Height);
			RectanglesList.Add(rectangle2D);
		}
	}

	public void GetNodeDimensions(Node node, int depth, ref double Width, ref double Height)
	{
		_Opaline.GetNodeDimension(node, out var x, out var y, out var _);
		Width = x;
		Height = y;
	}

	public LicenseType CheckLicense()
	{
		return _Opaline.GetLicenseType();
	}
}
