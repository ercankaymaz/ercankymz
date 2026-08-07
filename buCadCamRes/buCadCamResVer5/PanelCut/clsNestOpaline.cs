// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.PanelCut.clsNestOpaline
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buCadCamResVer5.Nesting;
using buClass;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Apps.PanelCut;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using Opaline2Cs;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buCadCamResVer5.PanelCut;

public class clsNestOpaline
{
  public Opaline _Opaline = new Opaline();
  public Rectangle2D lastAssemblyRectangle = new Rectangle2D();
  public Direction lastAssemblyDirection = Direction.XDirection;
  public int NodeID = 0;

  public event OkCommandWithDataEventHandler CalculationDone;

  public string DllName => Opaline.GetDllName();

  public void Execute()
  {
    this._Opaline = new Opaline();
    this.NodeID = 0;
    clsInit.appPanelCut.activeJob = new NestingPanelJob();
    int userData1 = 0;
    this._Opaline.SetDefaultMargins(clsPanelCut.varPanelCutSettings.GeneralTrimWidth, 0.0, clsPanelCut.varPanelCutSettings.GeneralTrimHeight, 0.0, 0.0, 0.0);
    for (int index = 0; index <= clsNesting.Sheets.Count - 1; ++index)
    {
      if (clsNesting.Sheets[index].Enable)
      {
        double x = clsNesting.Sheets[index].MaterialData.Width - clsPanelCut.varPanelCutSettings.GeneralTrimWidth;
        double y = clsNesting.Sheets[index].MaterialData.Height - clsPanelCut.varPanelCutSettings.GeneralTrimHeight;
        if (clsNesting.Sheets[index].TrimWidth != 0.0)
          x = clsNesting.Sheets[index].MaterialData.Width - clsNesting.Sheets[index].TrimWidth;
        if (clsNesting.Sheets[index].TrimHeight != 0.0)
          y = clsNesting.Sheets[index].MaterialData.Height - clsNesting.Sheets[index].TrimHeight;
        this._Opaline.SetBlockUserData(this._Opaline.CreateBlock(x, y, 1.0, clsNesting.Sheets[index].Cost, (uint) clsNesting.Sheets[index].Remain), userData1);
        clsInit.appPanelCut.activeJob.Sheets.Add(new Rectangle2D(clsNesting.Sheets[index].MaterialData.Width, clsNesting.Sheets[index].MaterialData.Height));
        ++userData1;
      }
    }
    int userData2 = 0;
    List<Rectangle2D> Parts = new List<Rectangle2D>();
    for (int index = 0; index <= clsNesting.Parts.Count - 1; ++index)
    {
      clsNesting.Parts[index].ID = index + 1;
      if (clsNesting.Parts[index].Enable)
      {
        double num1 = clsNesting.Parts[index].PartData.Width + clsNesting.Parts[index].PrecutWidth;
        double num2 = clsNesting.Parts[index].PartData.Height + clsNesting.Parts[index].PrecutHeight;
        if (clsNesting.Parts[index].EdgeLeft)
          num1 -= clsNesting.Parts[index].EdgeLeftThickness;
        if (clsNesting.Parts[index].EdgeRight)
          num1 -= clsNesting.Parts[index].EdgeRightThickness;
        if (clsNesting.Parts[index].EdgeTop)
          num2 -= clsNesting.Parts[index].EdgeTopThickness;
        if (clsNesting.Parts[index].EdgeBottom)
          num2 -= clsNesting.Parts[index].EdgeBottomThickness;
        Part part = this._Opaline.CreatePart((uint) clsNesting.Parts[index].Remain, (uint) clsNesting.Parts[index].Remain, clsNesting.Parts[index].Price);
        this._Opaline.SetModuleUserData(this._Opaline.CreateSimpleModule(part, 1U, num1, num2, 1.0), userData2);
        clsInit.appPanelCut.activeJob.Parts.Add(new Rectangle2D(num1, num2));
        int userData3 = userData2 + 1;
        this._Opaline.SetModuleUserData(this._Opaline.CreateSimpleModule(part, 1U, num2, num1, 1.0), userData3);
        clsInit.appPanelCut.activeJob.Parts.Add(new Rectangle2D(num2, num1));
        clsInit.appPanelCut.activeJob.usedParts.Add(new buNestingPart(clsNesting.Parts[index]));
        userData2 = userData3 + 1;
        Parts.Add(new Rectangle2D(num1, num2));
        Parts.Add(new Rectangle2D(num2, num1));
      }
    }
    if (clsPanelCut.varPanelCutSettings.SawThickness >= 0.0)
      this._Opaline.SetSawingDistance(clsPanelCut.varPanelCutSettings.SawThickness);
    else
      this._Opaline.SetSawingDistance(0.0);
    if (clsPanelCut.varPanelCutSettings.MaxOptimisationDepth >= 0)
      ;
    double maxTime = (double) clsPanelCut.varPanelCutSettings.NestingExecuteTimeSec;
    if (maxTime <= 0.0)
      maxTime = 3.0;
    uint num = this._Opaline.Optimize(maxTime);
    this.lastAssemblyRectangle = (Rectangle2D) null;
    this._Opaline.GetNestingsStatistics(out int _, out double _, out double _);
    uint multiplicity = 0;
    Opaline2Cs.Node root = (Opaline2Cs.Node) null;
    Block block = (Block) null;
    this._Opaline.GetNestingInfo(1U, out multiplicity, out root, out block);
    for (uint index1 = 0; index1 < num; ++index1)
    {
      uint nestingMultiplicity = this._Opaline.GetNestingMultiplicity(index1);
      Block nestingBlock = this._Opaline.GetNestingBlock(index1);
      this._Opaline.GetBlockUserData(nestingBlock);
      double x = 0.0;
      double y = 0.0;
      double z = 0.0;
      double cost = 0.0;
      uint nbBlocks = 0;
      this._Opaline.GetBlock(nestingBlock, out x, out y, out z, out cost, out nbBlocks);
      List<Rectangle2D> RectanglesList = new List<Rectangle2D>();
      clsInit.appPanelCut.cutPanel = new NestingPanel();
      clsInit.appPanelCut.cutPanel.Count = (int) nestingMultiplicity;
      clsInit.appPanelCut.cutPanel.Width = x - clsPanelCut.varPanelCutSettings.SawThickness;
      clsInit.appPanelCut.cutPanel.Height = y - clsPanelCut.varPanelCutSettings.SawThickness;
      clsInit.appPanelCut.cutPanel.PanelArea = x * y;
      this.GetRectangles(index1, ref RectanglesList);
      for (int index2 = 0; index2 <= RectanglesList.Count - 1; ++index2)
      {
        clsInit.appPanelCut.cutPanel.CalculatedRectangles.Add(new Rectangle2D(RectanglesList[index2]));
        List<Point3D> Vertices = new List<Point3D>();
        Rectangle2D.Rectangle3DToVertices(RectanglesList[index2], ref Vertices);
        LinearPath linearPath = new LinearPath((ICollection<Point3D>) Vertices);
        linearPath.ColorMethod = colorMethodType.byEntity;
        linearPath.Color = Color.Red;
        if (index2 == RectanglesList.Count - 1)
        {
          linearPath.ColorMethod = colorMethodType.byEntity;
          linearPath.Color = Color.Blue;
        }
      }
      this.GetCuttingTree(this._Opaline.GetNestingRoot(index1), 0, new clsNestOpaline.Point(clsPanelCut.varPanelCutSettings.GeneralTrimWidth, clsPanelCut.varPanelCutSettings.GeneralTrimHeight));
      clsInit.appPanelCut.cutPanel.PartsArea = 0.0;
      clsInit.cPanelCut.GetPanelPartArea(Parts, clsInit.appPanelCut.cutPanel.Nodes, ref clsInit.appPanelCut.cutPanel.PartsArea);
      if (clsInit.appPanelCut.cutPanel.PanelArea > 0.0)
        clsInit.appPanelCut.cutPanel.Waste = clsInit.appPanelCut.cutPanel.PartsArea / clsInit.appPanelCut.cutPanel.PanelArea * 100.0;
      clsInit.appPanelCut.activeJob.Panels.Add(clsInit.appPanelCut.cutPanel);
    }
    // ISSUE: reference to a compiler-generated field
    if (this.okCommandWithDataEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithDataEventHandler_0((object) null);
    }
    this._Opaline.Dispose();
    this._Opaline = (Opaline) null;
  }

  public void GetCuttingTree(Opaline2Cs.Node node, int depth, clsNestOpaline.Point lower_left)
  {
    NestingPanelNode nestingPanelNode1 = new NestingPanelNode();
    double Width = 0.0;
    double Height = 0.0;
    this.GetNodeDimensions(node, depth, ref Width, ref Height);
    clsNestOpaline.Point point = new clsNestOpaline.Point(this._Opaline, node);
    switch (this._Opaline.GetNodeType(node))
    {
      case NodeType.ModuleNode:
        nestingPanelNode1.NodeType = nestPanelNodeType.Module;
        OpalineModule moduleNodeModule = this._Opaline.GetModuleNodeModule(node);
        uint moduleNodeQuantity1 = this._Opaline.GetModuleNodeQuantity(node, Direction.XDirection);
        uint moduleNodeQuantity2 = this._Opaline.GetModuleNodeQuantity(node, Direction.YDirection);
        nestingPanelNode1.XQuantity = (int) moduleNodeQuantity1;
        nestingPanelNode1.YQuantity = (int) moduleNodeQuantity2;
        nestingPanelNode1.LowerLeft.X = lower_left.X;
        nestingPanelNode1.LowerLeft.Y = lower_left.Y;
        nestingPanelNode1.DimensionX = point.X;
        nestingPanelNode1.DimensionY = point.Y;
        nestingPanelNode1.Depth = depth;
        nestingPanelNode1.PartID = this._Opaline.GetModuleUserData(moduleNodeModule);
        nestingPanelNode1.Rectangle = new Rectangle2D(nestingPanelNode1.LowerLeft, nestingPanelNode1.DimensionX, nestingPanelNode1.DimensionY);
        nestingPanelNode1.NodeID = this.NodeID;
        int index1 = this._Opaline.GetModuleUserData(moduleNodeModule) % 2;
        if (index1 >= 0 & index1 < clsNesting.Parts.Count - 1)
          nestingPanelNode1.ID = clsNesting.Parts[index1].ID;
        ++this.NodeID;
        if (this.lastAssemblyDirection == Direction.YDirection)
        {
          nestingPanelNode1.CutFeedDistance = nestingPanelNode1.DimensionY;
          nestingPanelNode1.CutSawDistance = nestingPanelNode1.DimensionX;
          nestingPanelNode1.CutOffset = lower_left.X;
        }
        if (this.lastAssemblyDirection == Direction.XDirection)
        {
          nestingPanelNode1.CutFeedDistance = nestingPanelNode1.DimensionY;
          nestingPanelNode1.CutSawDistance = nestingPanelNode1.DimensionX;
          nestingPanelNode1.CutOffset = lower_left.X;
        }
        if (this.lastAssemblyRectangle != null)
          nestingPanelNode1.BaseRectangle = new Rectangle2D(this.lastAssemblyRectangle);
        clsInit.appPanelCut.cutPanel.PartCount += nestingPanelNode1.XQuantity * nestingPanelNode1.YQuantity;
        if (nestingPanelNode1 != null)
        {
          if (clsInit.appPanelCut.cutPanel.Nodes.Count > 0)
          {
            if (depth == 1)
              clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1].Node.Add(nestingPanelNode1);
            if (depth == 2)
            {
              NestingPanelNode node1 = clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1];
              node1.Node[node1.Node.Count - 1].Node.Add(nestingPanelNode1);
            }
            if (depth == 3)
            {
              NestingPanelNode node2 = clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1];
              NestingPanelNode nestingPanelNode2 = node2.Node[node2.Node.Count - 1];
              nestingPanelNode2.Node[nestingPanelNode2.Node.Count - 1].Node.Add(nestingPanelNode1);
            }
            if (depth == 4)
            {
              NestingPanelNode node3 = clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1];
              NestingPanelNode nestingPanelNode3 = node3.Node[node3.Node.Count - 1];
              NestingPanelNode nestingPanelNode4 = nestingPanelNode3.Node[nestingPanelNode3.Node.Count - 1];
              nestingPanelNode4.Node[nestingPanelNode4.Node.Count - 1].Node.Add(nestingPanelNode1);
            }
            if (depth == 5)
            {
              NestingPanelNode node4 = clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1];
              NestingPanelNode nestingPanelNode5 = node4.Node[node4.Node.Count - 1];
              NestingPanelNode nestingPanelNode6 = nestingPanelNode5.Node[nestingPanelNode5.Node.Count - 1];
              NestingPanelNode nestingPanelNode7 = nestingPanelNode6.Node[nestingPanelNode6.Node.Count - 1];
              nestingPanelNode7.Node[nestingPanelNode7.Node.Count - 1].Node.Add(nestingPanelNode1);
            }
            if (depth == 6)
            {
              NestingPanelNode node5 = clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1];
              NestingPanelNode nestingPanelNode8 = node5.Node[node5.Node.Count - 1];
              NestingPanelNode nestingPanelNode9 = nestingPanelNode8.Node[nestingPanelNode8.Node.Count - 1];
              NestingPanelNode nestingPanelNode10 = nestingPanelNode9.Node[nestingPanelNode9.Node.Count - 1];
              NestingPanelNode nestingPanelNode11 = nestingPanelNode10.Node[nestingPanelNode10.Node.Count - 1];
              nestingPanelNode11.Node[nestingPanelNode11.Node.Count - 1].Node.Add(nestingPanelNode1);
            }
            if (depth == 7)
            {
              NestingPanelNode node6 = clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1];
              NestingPanelNode nestingPanelNode12 = node6.Node[node6.Node.Count - 1];
              NestingPanelNode nestingPanelNode13 = nestingPanelNode12.Node[nestingPanelNode12.Node.Count - 1];
              NestingPanelNode nestingPanelNode14 = nestingPanelNode13.Node[nestingPanelNode13.Node.Count - 1];
              NestingPanelNode nestingPanelNode15 = nestingPanelNode14.Node[nestingPanelNode14.Node.Count - 1];
              NestingPanelNode nestingPanelNode16 = nestingPanelNode15.Node[nestingPanelNode15.Node.Count - 1];
              nestingPanelNode16.Node[nestingPanelNode16.Node.Count - 1].Node.Add(nestingPanelNode1);
            }
            if (depth == 8)
            {
              NestingPanelNode node7 = clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1];
              NestingPanelNode nestingPanelNode17 = node7.Node[node7.Node.Count - 1];
              NestingPanelNode nestingPanelNode18 = nestingPanelNode17.Node[nestingPanelNode17.Node.Count - 1];
              NestingPanelNode nestingPanelNode19 = nestingPanelNode18.Node[nestingPanelNode18.Node.Count - 1];
              NestingPanelNode nestingPanelNode20 = nestingPanelNode19.Node[nestingPanelNode19.Node.Count - 1];
              NestingPanelNode nestingPanelNode21 = nestingPanelNode20.Node[nestingPanelNode20.Node.Count - 1];
              NestingPanelNode nestingPanelNode22 = nestingPanelNode21.Node[nestingPanelNode21.Node.Count - 1];
              nestingPanelNode22.Node[nestingPanelNode22.Node.Count - 1].Node.Add(nestingPanelNode1);
            }
            if (depth == 9)
            {
              NestingPanelNode node8 = clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1];
              NestingPanelNode nestingPanelNode23 = node8.Node[node8.Node.Count - 1];
              NestingPanelNode nestingPanelNode24 = nestingPanelNode23.Node[nestingPanelNode23.Node.Count - 1];
              NestingPanelNode nestingPanelNode25 = nestingPanelNode24.Node[nestingPanelNode24.Node.Count - 1];
              NestingPanelNode nestingPanelNode26 = nestingPanelNode25.Node[nestingPanelNode25.Node.Count - 1];
              NestingPanelNode nestingPanelNode27 = nestingPanelNode26.Node[nestingPanelNode26.Node.Count - 1];
              NestingPanelNode nestingPanelNode28 = nestingPanelNode27.Node[nestingPanelNode27.Node.Count - 1];
              NestingPanelNode nestingPanelNode29 = nestingPanelNode28.Node[nestingPanelNode28.Node.Count - 1];
              nestingPanelNode29.Node[nestingPanelNode29.Node.Count - 1].Node.Add(nestingPanelNode1);
            }
          }
          else
            clsInit.appPanelCut.cutPanel.Nodes.Add(nestingPanelNode1);
          Rectangle2D rectangle2D = new Rectangle2D(clsInit.appPanelCut.activeJob.Parts[nestingPanelNode1.PartID]);
          for (int index2 = 1; index2 <= nestingPanelNode1.XQuantity; ++index2)
          {
            NestingPanelNode nestingPanelNode30 = new NestingPanelNode();
            nestingPanelNode30.NodeType = nestPanelNodeType.CutLine;
            nestingPanelNode30.Direction = DirectionXandY.XDirection;
            double sawThickness = clsPanelCut.varPanelCutSettings.SawThickness;
            nestingPanelNode30.LowerLeft.X = lower_left.X;
            nestingPanelNode30.LowerLeft.Y = lower_left.Y;
            nestingPanelNode30.DimensionX = rectangle2D.Width;
            nestingPanelNode30.DimensionY = point.Y;
            nestingPanelNode30.PartID = this._Opaline.GetModuleUserData(moduleNodeModule);
            Point3D startPoint1 = new Point3D(nestingPanelNode30.LowerLeft.X + (double) (index2 - 1) * (rectangle2D.Width + sawThickness), nestingPanelNode30.LowerLeft.Y);
            nestingPanelNode30.Rectangle = new Rectangle2D(startPoint1, rectangle2D.Width, nestingPanelNode1.DimensionY);
            nestingPanelNode30.BaseRectangle = new Rectangle2D(nestingPanelNode1.Rectangle);
            nestingPanelNode30.CutLine = new Line2D(new Point3D(nestingPanelNode30.LowerLeft.X + (double) (index2 - 1) * sawThickness + (double) index2 * rectangle2D.Width + sawThickness / 2.0, 0.0), 0.0, nestingPanelNode1.DimensionY);
            nestingPanelNode30.CutFeedDistance = nestingPanelNode30.LowerLeft.X + (double) (index2 - 1) * sawThickness + (double) index2 * rectangle2D.Width + sawThickness / 2.0;
            nestingPanelNode30.CutSawDistance = nestingPanelNode30.DimensionY;
            nestingPanelNode30.Depth = depth;
            nestingPanelNode30.NodeID = this.NodeID;
            nestingPanelNode30.ID = nestingPanelNode1.ID;
            ++this.NodeID;
            clsInit.appPanelCut.cutPanel.TotalCutLength += Point3D.Distance(nestingPanelNode30.CutLine.StartPoint, nestingPanelNode30.CutLine.EndPoint);
            nestingPanelNode1.Node.Add(nestingPanelNode30);
            if (nestingPanelNode1.YQuantity > 1)
            {
              for (int index3 = 1; index3 <= nestingPanelNode1.YQuantity; ++index3)
              {
                NestingPanelNode nestingPanelNode31 = new NestingPanelNode();
                nestingPanelNode31.Direction = DirectionXandY.YDirection;
                nestingPanelNode31.NodeType = nestPanelNodeType.CutLine;
                nestingPanelNode31.LowerLeft.X = lower_left.X + (double) (index2 - 1) * rectangle2D.Width;
                nestingPanelNode31.LowerLeft.Y = lower_left.Y;
                nestingPanelNode31.DimensionX = rectangle2D.Width;
                nestingPanelNode31.DimensionY = rectangle2D.Height;
                nestingPanelNode31.PartID = this._Opaline.GetModuleUserData(moduleNodeModule);
                Point3D startPoint2 = new Point3D(nestingPanelNode30.LowerLeft.X + (double) (index2 - 1) * rectangle2D.Width + sawThickness, nestingPanelNode30.LowerLeft.Y + (double) (index3 - 1) * rectangle2D.Height + sawThickness);
                nestingPanelNode31.Rectangle = new Rectangle2D(startPoint2, rectangle2D.Width, rectangle2D.Height);
                nestingPanelNode31.BaseRectangle = new Rectangle2D(nestingPanelNode30.Rectangle);
                nestingPanelNode31.CutLine = new Line2D(new Point3D(nestingPanelNode31.LowerLeft.X, (double) (index3 - 1) * sawThickness + (double) index3 * rectangle2D.Height + sawThickness / 2.0), rectangle2D.Width, 0.0);
                nestingPanelNode31.CutFeedDistance = (double) (index3 - 1) * sawThickness + (double) index3 * rectangle2D.Height + sawThickness / 2.0;
                nestingPanelNode31.CutSawDistance = nestingPanelNode31.DimensionX;
                nestingPanelNode31.Depth = depth + 1;
                nestingPanelNode31.ID = nestingPanelNode1.ID;
                clsInit.appPanelCut.cutPanel.TotalCutLength += Point3D.Distance(nestingPanelNode31.CutLine.StartPoint, nestingPanelNode31.CutLine.EndPoint);
                nestingPanelNode31.NodeID = this.NodeID;
                ++this.NodeID;
                nestingPanelNode30.Node.Add(nestingPanelNode31);
              }
            }
          }
          break;
        }
        break;
      case NodeType.OffcutNode:
        nestingPanelNode1.NodeType = nestPanelNodeType.OffCut;
        double x = 0.0;
        double y = 0.0;
        double z = 0.0;
        this._Opaline.GetNodeDimension(node, out x, out y, out z);
        nestingPanelNode1.DimensionX = x;
        nestingPanelNode1.DimensionY = y;
        nestingPanelNode1.Rectangle = new Rectangle2D(new Point3D(lower_left.X, lower_left.Y), x, y);
        nestingPanelNode1.Depth = depth;
        nestingPanelNode1.NodeID = this.NodeID;
        ++this.NodeID;
        if (nestingPanelNode1 != null)
        {
          if (clsInit.appPanelCut.cutPanel.Nodes.Count > 0)
          {
            if (depth == 1)
              clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1].Node.Add(nestingPanelNode1);
            if (depth == 2)
            {
              NestingPanelNode node9 = clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1];
              node9.Node[node9.Node.Count - 1].Node.Add(nestingPanelNode1);
            }
            if (depth == 3)
            {
              NestingPanelNode node10 = clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1];
              NestingPanelNode nestingPanelNode32 = node10.Node[node10.Node.Count - 1];
              nestingPanelNode32.Node[nestingPanelNode32.Node.Count - 1].Node.Add(nestingPanelNode1);
            }
            if (depth == 4)
            {
              NestingPanelNode node11 = clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1];
              NestingPanelNode nestingPanelNode33 = node11.Node[node11.Node.Count - 1];
              NestingPanelNode nestingPanelNode34 = nestingPanelNode33.Node[nestingPanelNode33.Node.Count - 1];
              nestingPanelNode34.Node[nestingPanelNode34.Node.Count - 1].Node.Add(nestingPanelNode1);
            }
            if (depth == 5)
            {
              NestingPanelNode node12 = clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1];
              NestingPanelNode nestingPanelNode35 = node12.Node[node12.Node.Count - 1];
              NestingPanelNode nestingPanelNode36 = nestingPanelNode35.Node[nestingPanelNode35.Node.Count - 1];
              NestingPanelNode nestingPanelNode37 = nestingPanelNode36.Node[nestingPanelNode36.Node.Count - 1];
              nestingPanelNode37.Node[nestingPanelNode37.Node.Count - 1].Node.Add(nestingPanelNode1);
              break;
            }
            break;
          }
          clsInit.appPanelCut.cutPanel.Nodes.Add(nestingPanelNode1);
          break;
        }
        break;
      case NodeType.AssemblyNode:
        nestingPanelNode1.NodeType = nestPanelNodeType.Assembly;
        Direction assemblyDirection = this._Opaline.GetAssemblyDirection(node);
        uint assemblyNbSubNodes = this._Opaline.GetAssemblyNbSubNodes(node);
        nestingPanelNode1.DimensionX = Width;
        nestingPanelNode1.DimensionY = Height;
        nestingPanelNode1.Rectangle = new Rectangle2D(new Point3D(lower_left.X, lower_left.Y), Width, Height);
        nestingPanelNode1.Depth = depth;
        if (this.lastAssemblyRectangle != null)
          nestingPanelNode1.BaseRectangle = new Rectangle2D(this.lastAssemblyRectangle);
        if (assemblyDirection == Direction.XDirection)
        {
          nestingPanelNode1.Direction = DirectionXandY.XDirection;
          nestingPanelNode1.CutFeedDistance = nestingPanelNode1.DimensionX;
          nestingPanelNode1.CutSawDistance = nestingPanelNode1.DimensionY;
          nestingPanelNode1.CutOffset = lower_left.X;
        }
        if (assemblyDirection == Direction.YDirection)
        {
          nestingPanelNode1.Direction = DirectionXandY.YDirection;
          nestingPanelNode1.CutLine = new Line2D(new Point3D(lower_left.X + Width + clsPanelCut.varPanelCutSettings.SawThickness / 2.0, lower_left.Y), new Point3D(lower_left.X + Width + clsPanelCut.varPanelCutSettings.SawThickness / 2.0, lower_left.Y + Height));
          nestingPanelNode1.CutFeedDistance = nestingPanelNode1.DimensionX;
          nestingPanelNode1.CutSawDistance = nestingPanelNode1.DimensionY;
          nestingPanelNode1.CutOffset = lower_left.X;
        }
        nestingPanelNode1.NodeID = this.NodeID;
        ++this.NodeID;
        this.lastAssemblyRectangle = new Rectangle2D(nestingPanelNode1.Rectangle);
        this.lastAssemblyDirection = assemblyDirection;
        if (nestingPanelNode1 != null)
        {
          if (clsInit.appPanelCut.cutPanel.Nodes.Count > 0)
          {
            if (depth == 1)
              clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1].Node.Add(nestingPanelNode1);
            if (depth == 2)
            {
              NestingPanelNode node13 = clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1];
              node13.Node[node13.Node.Count - 1].Node.Add(nestingPanelNode1);
            }
            if (depth == 3)
            {
              NestingPanelNode node14 = clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1];
              NestingPanelNode nestingPanelNode38 = node14.Node[node14.Node.Count - 1];
              nestingPanelNode38.Node[nestingPanelNode38.Node.Count - 1].Node.Add(nestingPanelNode1);
            }
            if (depth == 4)
            {
              NestingPanelNode node15 = clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1];
              NestingPanelNode nestingPanelNode39 = node15.Node[node15.Node.Count - 1];
              NestingPanelNode nestingPanelNode40 = nestingPanelNode39.Node[nestingPanelNode39.Node.Count - 1];
              nestingPanelNode40.Node[nestingPanelNode40.Node.Count - 1].Node.Add(nestingPanelNode1);
            }
            if (depth == 5)
            {
              NestingPanelNode node16 = clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1];
              NestingPanelNode nestingPanelNode41 = node16.Node[node16.Node.Count - 1];
              NestingPanelNode nestingPanelNode42 = nestingPanelNode41.Node[nestingPanelNode41.Node.Count - 1];
              NestingPanelNode nestingPanelNode43 = nestingPanelNode42.Node[nestingPanelNode42.Node.Count - 1];
              nestingPanelNode43.Node[nestingPanelNode43.Node.Count - 1].Node.Add(nestingPanelNode1);
            }
            if (depth == 6)
            {
              NestingPanelNode node17 = clsInit.appPanelCut.cutPanel.Nodes[clsInit.appPanelCut.cutPanel.Nodes.Count - 1];
              NestingPanelNode nestingPanelNode44 = node17.Node[node17.Node.Count - 1];
              NestingPanelNode nestingPanelNode45 = nestingPanelNode44.Node[nestingPanelNode44.Node.Count - 1];
              NestingPanelNode nestingPanelNode46 = nestingPanelNode45.Node[nestingPanelNode45.Node.Count - 1];
              NestingPanelNode nestingPanelNode47 = nestingPanelNode46.Node[nestingPanelNode46.Node.Count - 1];
              nestingPanelNode47.Node[nestingPanelNode47.Node.Count - 1].Node.Add(nestingPanelNode1);
            }
          }
          else
            clsInit.appPanelCut.cutPanel.Nodes.Add(nestingPanelNode1);
        }
        for (uint indexSubNode = 0; indexSubNode < assemblyNbSubNodes; ++indexSubNode)
        {
          Opaline2Cs.Node assemblySubNode = this._Opaline.GetAssemblySubNode(node, indexSubNode);
          this.GetCuttingTree(assemblySubNode, depth + 1, lower_left);
          switch (assemblyDirection)
          {
            case Direction.XDirection:
              lower_left.X += new clsNestOpaline.Point(this._Opaline, assemblySubNode).X;
              break;
            case Direction.YDirection:
              lower_left.Y += new clsNestOpaline.Point(this._Opaline, assemblySubNode).Y;
              break;
          }
        }
        break;
    }
    if (nestingPanelNode1 != null)
      ;
  }

  public void GetRectangles(uint nestingNumber, ref List<Rectangle2D> RectanglesList)
  {
    RectanglesList = new List<Rectangle2D>();
    Rectangles nestingRectangles = this._Opaline.GetNestingRectangles(nestingNumber);
    uint nbRectangles = this._Opaline.GetNbRectangles(nestingRectangles);
    for (uint indexRectangle = 0; indexRectangle < nbRectangles; ++indexRectangle)
    {
      Opaline2Cs.Node node;
      double x;
      double y;
      this._Opaline.GetRectangleInfo(nestingRectangles, indexRectangle, out node, out x, out y, out double _);
      Rectangle2D rectangle2D = new Rectangle2D();
      rectangle2D.StartPoint = new Point3D(x, y);
      this.GetNodeDimensions(node, 1, ref rectangle2D.Width, ref rectangle2D.Height);
      RectanglesList.Add(rectangle2D);
    }
  }

  public void GetNodeDimensions(Opaline2Cs.Node node, int depth, ref double Width, ref double Height)
  {
    double x;
    double y;
    this._Opaline.GetNodeDimension(node, out x, out y, out double _);
    Width = x;
    Height = y;
  }

  public LicenseType CheckLicense() => this._Opaline.GetLicenseType();

  public struct Point
  {
    public double X;
    public double Y;

    public Point(double x, double y)
    {
      this.X = x;
      this.Y = y;
    }

    public Point(Opaline opaline, Opaline2Cs.Node node)
    {
      this.X = opaline.GetNodeDimensionAux(node, Direction.XDirection);
      this.Y = opaline.GetNodeDimensionAux(node, Direction.YDirection);
    }

    public override string ToString() => $"X: {this.X.ToString()}  Y: {this.Y.ToString()}";
  }
}
