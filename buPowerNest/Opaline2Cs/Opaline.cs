// Decompiled with JetBrains decompiler
// Type: Opaline2Cs.Opaline
// Assembly: buPowerNest, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: EB8978B5-B2D2-48FE-B448-717DFAAD425B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buPowerNest.dll

using \u0005;
using System;

#nullable disable
namespace Opaline2Cs;

public class Opaline : IDisposable
{
  internal readonly Session \u0001 = (Session) null;
  private UpdateFunction \u0001 = (UpdateFunction) null;
  internal bool \u0001 = false;

  public static string GetDllName() => "opaline3.dll";

  public void SetSoftwareLicenseFile(string license_key_filepath)
  {
    \u0003.\u0001(this.\u0001.__Ptr, license_key_filepath);
  }

  public LicenseType GetLicenseType() => (LicenseType) \u0003.\u0001(this.\u0001.__Ptr);

  public void SetLogFile(string file) => \u0003.\u0001(file);

  public Block CreateBlock(double x, double y, double z, double cost, uint nbBlocks)
  {
    return Wrappable.Create<Block>(\u0003.\u0001(this.\u0001.__Ptr, x, y, z, cost, nbBlocks), new Block());
  }

  public void SetBlockPriority(Block block, int priority)
  {
    \u0003.\u0001(this.\u0001.__Ptr, block.__Ptr, priority);
  }

  public Part CreatePart(uint minQuantity, uint maxQuantity, double price)
  {
    return Wrappable.Create<Part>(\u0003.\u0001(this.\u0001.__Ptr, minQuantity, maxQuantity, price), new Part());
  }

  public void SetPartPriority(Part part, int priority)
  {
    \u0003.\u0001(this.\u0001.__Ptr, part.__Ptr, priority);
  }

  public OpalineModule CreateSimpleModule(Part part, uint nbParts, double x, double y, double z)
  {
    return Wrappable.Create<OpalineModule>(\u0003.\u0001(this.\u0001.__Ptr, part.__Ptr, nbParts, x, y, z), new OpalineModule());
  }

  public OpalineModule CreateMonoModule(
    Part part,
    uint nbParts,
    double lx,
    double dx,
    uint minx,
    uint maxx,
    double ly,
    double dy,
    uint miny,
    uint maxy,
    double lz,
    double dz,
    uint minz,
    uint maxz)
  {
    return Wrappable.Create<OpalineModule>(\u0003.\u0001(this.\u0001.__Ptr, part.__Ptr, nbParts, lx, dx, minx, maxx, ly, dy, miny, maxy, lz, dz, minz, maxz), new OpalineModule());
  }

  public void GetBlock(
    Block block,
    out double x,
    out double y,
    out double z,
    out double cost,
    out uint nbBlocks)
  {
    \u0003.\u0001(this.\u0001.__Ptr, block.__Ptr, out x, out y, out z, out cost, out nbBlocks);
  }

  public void GetPart(Part part, out uint minQuantity, out uint maxQuantity, out double price)
  {
    \u0003.\u0001(this.\u0001.__Ptr, part.__Ptr, out minQuantity, out maxQuantity, out price);
  }

  public uint GetNbPavementElement(OpalineModule module)
  {
    return \u0003.\u0001(this.\u0001.__Ptr, module.__Ptr);
  }

  public void GetPavementElement(
    OpalineModule module,
    uint index,
    Part part,
    out double px,
    out double py,
    out double pz,
    out double sx,
    out double sy,
    out double sz)
  {
    \u0003.\u0001(this.\u0001.__Ptr, module.__Ptr, index, part.__Ptr, out px, out py, out pz, out sx, out sy, out sz);
  }

  public void GetModuleInfo(
    OpalineModule module,
    out double lx,
    out double dx,
    out uint minx,
    out uint maxx,
    out double ly,
    out double dy,
    out uint miny,
    out uint maxy,
    out double lz,
    out double dz,
    out uint minz,
    out uint maxz)
  {
    \u0003.\u0001(this.\u0001.__Ptr, module.__Ptr, out lx, out dx, out minx, out maxx, out ly, out dy, out miny, out maxy, out lz, out dz, out minz, out maxz);
  }

  public void SetSessionUserData(int userData) => \u0003.\u0001(this.\u0001.__Ptr, userData);

  public void SetBlockUserData(Block block, int userData)
  {
    \u0003.\u0001(this.\u0001.__Ptr, block.__Ptr, userData);
  }

  public void SetPartUserData(Part part, int userData)
  {
    \u0003.\u0001(this.\u0001.__Ptr, part.__Ptr, userData);
  }

  public void SetModuleUserData(OpalineModule module, int userData)
  {
    \u0003.\u0001(this.\u0001.__Ptr, module.__Ptr, userData);
  }

  public int GetSessionUserData() => \u0003.\u0001(this.\u0001.__Ptr);

  public int GetBlockUserData(Block block) => \u0003.\u0001(this.\u0001.__Ptr, block.__Ptr);

  public int GetPartUserData(Part part) => \u0003.\u0001(this.\u0001.__Ptr, part.__Ptr);

  public int GetModuleUserData(OpalineModule module)
  {
    return \u0003.\u0001(this.\u0001.__Ptr, module.__Ptr);
  }

  public void SetDefaultMargins(
    double x1,
    double x2,
    double y1,
    double y2,
    double z1,
    double z2)
  {
    \u0003.\u0001(this.\u0001.__Ptr, x1, x2, y1, y2, z1, z2);
  }

  public void SetSpecificMargins(
    Block block,
    double x1,
    double x2,
    double y1,
    double y2,
    double z1,
    double z2)
  {
    \u0003.\u0001(this.\u0001.__Ptr, block.__Ptr, x1, x2, y1, y2, z1, z2);
  }

  public void SetCuttingLimits(double xMax, double yMax, double zMax)
  {
    \u0003.\u0001(this.\u0001.__Ptr, xMax, yMax, zMax);
  }

  public void SetSawingDistance(double distance) => \u0003.\u0001(this.\u0001.__Ptr, distance);

  public void SetMinInterSawingDistance(double distance)
  {
    \u0003.\u0001(this.\u0001.__Ptr, distance);
  }

  public void SetMaximumDepth(int maxDepth) => \u0003.\u0001(this.\u0001.__Ptr, maxDepth);

  public Node MonoOptimize(Block block, double maxTime, UpdateFunction updateFunction = null)
  {
    this.\u0001 = updateFunction;
    return Wrappable.Create<Node>(\u0003.\u0001(this.\u0001.__Ptr, block.__Ptr, maxTime, (\u0006.\u0001) null), new Node());
  }

  public uint Optimize(double maxTime, UpdateFunction updateFunction = null)
  {
    this.\u0001 = updateFunction;
    return \u0003.\u0001(this.\u0001.__Ptr, maxTime, (\u0006.\u0001) null);
  }

  public OptimizationStatus GetOptimizationStatus()
  {
    return (OptimizationStatus) \u0003.\u0001(this.\u0001.__Ptr);
  }

  public int GetOptimizationDimension() => \u0003.\u0001(this.\u0001.__Ptr);

  public void GetNestingInfo(
    uint indexNesting,
    out uint multiplicity,
    out Node root,
    out Block block)
  {
    IntPtr ptr1;
    IntPtr ptr2;
    \u0003.\u0001(this.\u0001.__Ptr, indexNesting, out multiplicity, out ptr1, out ptr2);
    root = Wrappable.Create<Node>(ptr1, new Node());
    block = Wrappable.Create<Block>(ptr2, new Block());
  }

  public void GetNestingsStatistics(out int final, out double fillRatio, out double profitability)
  {
    \u0003.\u0001(this.\u0001.__Ptr, out final, out fillRatio, out profitability);
  }

  public uint GetNestingMultiplicity(uint indexNesting)
  {
    return \u0003.\u0001(this.\u0001.__Ptr, indexNesting);
  }

  public Node GetNestingRoot(uint indexNesting)
  {
    return Wrappable.Create<Node>(\u0003.\u0001(this.\u0001.__Ptr, indexNesting), new Node());
  }

  public Block GetNestingBlock(uint indexNesting)
  {
    return Wrappable.Create<Block>(\u0003.\u0001(this.\u0001.__Ptr, indexNesting), new Block());
  }

  public Rectangles GetNestingRectangles(uint indexNesting)
  {
    return Wrappable.Create<Rectangles>(\u0003.\u0001(this.\u0001.__Ptr, indexNesting), new Rectangles());
  }

  public uint GetNbRectangles(Rectangles rectangles)
  {
    return \u0003.\u0001(this.\u0001.__Ptr, rectangles.__Ptr);
  }

  public void GetRectangleInfo(
    Rectangles rectangles,
    uint indexRectangle,
    out Node node,
    out double x,
    out double y,
    out double z)
  {
    IntPtr ptr;
    \u0003.\u0001(this.\u0001.__Ptr, rectangles.__Ptr, indexRectangle, out ptr, out x, out y, out z);
    node = Wrappable.Create<Node>(ptr, new Node());
  }

  public double GetRectanglePosition(
    Rectangles rectangles,
    uint indexRectangle,
    Direction direction)
  {
    return \u0003.\u0001(this.\u0001.__Ptr, rectangles.__Ptr, indexRectangle, (int) direction);
  }

  public Node GetRectangleNode(Rectangles rectangles, uint indexRectangle)
  {
    return Wrappable.Create<Node>(\u0003.\u0001(this.\u0001.__Ptr, rectangles.__Ptr, indexRectangle), new Node());
  }

  public void GetNodeDimension(Node node, out double x, out double y, out double z)
  {
    \u0003.\u0001(this.\u0001.__Ptr, node.__Ptr, out x, out y, out z);
  }

  public double GetNodeDimensionAux(Node node, Direction direction)
  {
    return \u0003.\u0001(this.\u0001.__Ptr, node.__Ptr, (int) direction);
  }

  public NodeType GetNodeType(Node node) => (NodeType) \u0003.\u0001(this.\u0001.__Ptr, node.__Ptr);

  public void GetAssemblyInfo(Node node, out Direction direction, out uint nbSubNodes)
  {
    int num;
    \u0003.\u0001(this.\u0001.__Ptr, node.__Ptr, out num, out nbSubNodes);
    direction = (Direction) num;
  }

  public Direction GetAssemblyDirection(Node node)
  {
    return (Direction) \u0003.\u0001(this.\u0001.__Ptr, node.__Ptr);
  }

  public uint GetAssemblyNbSubNodes(Node node) => \u0003.\u0001(this.\u0001.__Ptr, node.__Ptr);

  public Node GetAssemblySubNode(Node node, uint indexSubNode)
  {
    return Wrappable.Create<Node>(\u0003.\u0001(this.\u0001.__Ptr, node.__Ptr, indexSubNode), new Node());
  }

  public void GetModuleNodeInfo(
    Node node,
    out OpalineModule module,
    out uint nx,
    out uint ny,
    out uint nz)
  {
    IntPtr ptr;
    \u0003.\u0001(this.\u0001.__Ptr, node.__Ptr, out ptr, out nx, out ny, out nz);
    module = Wrappable.Create<OpalineModule>(ptr, new OpalineModule());
  }

  public OpalineModule GetModuleNodeModule(Node node)
  {
    return Wrappable.Create<OpalineModule>(\u0003.\u0001(this.\u0001.__Ptr, node.__Ptr), new OpalineModule());
  }

  public uint GetModuleNodeQuantity(Node node, Direction direction)
  {
    return \u0003.\u0001(this.\u0001.__Ptr, node.__Ptr, (int) direction);
  }

  public void SetMaximumDepthIncludingTrim(int maximum_depth)
  {
    \u0003.\u0001(this.\u0001.__Ptr, maximum_depth);
  }

  public Opaline() => this.\u0001 = \u0003.\u0001(this);

  public Opaline(int seed) => this.\u0001 = \u0003.\u0001(seed, this);

  public Opaline(string logFile)
  {
    this.SetLogFile(logFile);
    this.\u0001 = \u0003.\u0001(this);
  }

  public Opaline(int seed, string logFile)
  {
    this.SetLogFile(logFile);
    this.\u0001 = \u0003.\u0001(seed, this);
  }

  public void Dispose()
  {
    \u0003.\u0001(this, true);
    GC.SuppressFinalize((object) this);
  }

  ~Opaline() => \u0003.\u0001(this, false);
}
