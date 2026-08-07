// Decompiled with JetBrains decompiler
// Type: PowerNest2Cs.PowerNest2
// Assembly: buPowerNest, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: EB8978B5-B2D2-48FE-B448-717DFAAD425B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buPowerNest.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

#nullable disable
namespace PowerNest2Cs;

public class PowerNest2 : IDisposable
{
  internal readonly Session \u0001 = (Session) null;
  private MultiUpdateBest \u0001 = (MultiUpdateBest) null;
  private UpdateBest \u0001 = (UpdateBest) null;
  private StopNesting \u0001 = (StopNesting) null;
  internal readonly IList<GCHandle> \u0001;
  internal bool \u0001 = false;

  public static bool LogFunctionCalls(string file) => \u0005.\u0003.\u0001(file) != 0;

  public static bool LogHostSpecs() => \u0005.\u0003.\u0001() != 0;

  public Shape AddShape(IEnumerable<Point> pointList, Point pivot)
  {
    return Wrappable.Create<Shape>(\u0005.\u0003.\u0001(this.\u0001.__Ptr, this.\u0001<Point>(pointList), pointList.Count<Point>(), pivot), new Shape());
  }

  public Shape AddShape(IEnumerable<Point> pointList)
  {
    return this.AddShape(pointList, pointList.ElementAt<Point>(0));
  }

  public Shape AddComplexShape(
    IEnumerable<Point> pointList,
    IEnumerable<int> nbOutlinePointList,
    Point pivot)
  {
    return Wrappable.Create<Shape>(\u0005.\u0003.\u0001(this.\u0001.__Ptr, this.\u0001<Point>(pointList), this.\u0001<int>(nbOutlinePointList), nbOutlinePointList.Count<int>(), pivot), new Shape());
  }

  public Shape AddComplexShape(IEnumerable<Point> pointList, IEnumerable<int> nbOutlinePointList)
  {
    return this.AddComplexShape(pointList, nbOutlinePointList, pointList.ElementAt<Point>(0));
  }

  public ErrorCode ShapeAddHole(Shape shape, IEnumerable<Point> holePointList)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, shape.__Ptr, this.\u0001<Point>(holePointList), holePointList.Count<Point>());
  }

  public ErrorCode ShapeSetProtectionOffset(Shape shape, double protectionOffset)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, shape.__Ptr, protectionOffset);
  }

  public ErrorCode ShapeSetProtectionLine(Shape shape, IEnumerable<Point> protection)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, shape.__Ptr, this.\u0001<Point>(protection), protection.Count<Point>());
  }

  public ErrorCode HoleSetProtectionLine(Shape shape, IEnumerable<Point> protection)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, shape.__Ptr, this.\u0001<Point>(protection), protection.Count<Point>());
  }

  public ErrorCode ComplexShapeSetProtectionLine(
    Shape shape,
    IEnumerable<Point> protectionPointList,
    IEnumerable<int> outlinesNbPointList)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, shape.__Ptr, this.\u0001<Point>(protectionPointList), this.\u0001<int>(outlinesNbPointList), outlinesNbPointList.Count<int>());
  }

  [DllImport("anpn2key.dll", EntryPoint = "#309", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  public static extern Orientation CreateOrientation(double angle);

  [DllImport("anpn2key.dll", EntryPoint = "#10", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  public static extern Orientation CreateRangeOrientation(double angle, double tolerance);

  [DllImport("anpn2key.dll", EntryPoint = "#11", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  public static extern Orientation CreateXFlippedOrientation(double angle);

  [DllImport("anpn2key.dll", EntryPoint = "#12", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  public static extern Orientation CreateXFlippedRangeOrientation(double angle, double tolerance);

  public Orientation CreateFreeOrientation(bool flip) => \u0005.\u0003.\u0001(flip ? 1 : 0);

  public Part AddPart(Shape shape, IEnumerable<Orientation> orientationList)
  {
    return Wrappable.Create<Part>(\u0005.\u0003.\u0001(this.\u0001.__Ptr, shape.__Ptr, this.\u0001<Orientation>(orientationList), orientationList.Count<Orientation>()), new Part());
  }

  public ErrorCode AddSeveralParts(
    Shape shape,
    IEnumerable<Orientation> orientationList,
    int quantity,
    out IEnumerable<Part> partList)
  {
    IntPtr[] numArray = new IntPtr[quantity];
    int num = \u0005.\u0003.\u0001(this.\u0001.__Ptr, shape.__Ptr, this.\u0001<Orientation>(orientationList), orientationList.Count<Orientation>(), quantity, numArray);
    IList<Part> partList1 = (IList<Part>) new List<Part>();
    for (int index = 0; index < quantity; ++index)
    {
      Part part = Wrappable.Create<Part>(numArray[index], new Part());
      partList1.Add(part);
    }
    partList = (IEnumerable<Part>) partList1;
    return (ErrorCode) num;
  }

  public ErrorCode PartSetPriority(Part part, int priority)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, part.__Ptr, priority);
  }

  public Sheet AddSheet(double width, double length)
  {
    return Wrappable.Create<Sheet>(\u0005.\u0003.\u0001(this.\u0001.__Ptr, width, length), new Sheet());
  }

  public ErrorCode SheetAddBorderGaps(
    Sheet sheet,
    double leftGap,
    double rightGap,
    double bottomGap,
    double topGap)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, sheet.__Ptr, leftGap, rightGap, bottomGap, topGap);
  }

  public ErrorCode SheetAddDefect(Sheet sheet, IEnumerable<Point> defectPointList)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, sheet.__Ptr, this.\u0001<Point>(defectPointList), defectPointList.Count<Point>());
  }

  public ErrorCode SheetAddDefectWithOffset(
    Sheet sheet,
    IEnumerable<Point> defectPointList,
    double offset)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, sheet.__Ptr, this.\u0001<Point>(defectPointList), defectPointList.Count<Point>(), offset);
  }

  public Sheet AddPolygonalSheet(IEnumerable<Point> pointList)
  {
    return Wrappable.Create<Sheet>(\u0005.\u0003.\u0001(this.\u0001.__Ptr, this.\u0001<Point>(pointList), pointList.Count<Point>()), new Sheet());
  }

  public Sheet AddPolygonalSheetWithBorderGap(IEnumerable<Point> pointList, double borderGap)
  {
    return Wrappable.Create<Sheet>(\u0005.\u0003.\u0001(this.\u0001.__Ptr, this.\u0001<Point>(pointList), pointList.Count<Point>(), borderGap), new Sheet());
  }

  public Result Nest(Sheet sheet, IEnumerable<Part> partList, double time)
  {
    return Wrappable.Create<Result>(\u0005.\u0003.\u0001(this.\u0001.__Ptr, sheet.__Ptr, this.\u0001<Part>(partList), partList.Count<Part>(), time), new Result());
  }

  public Result PreNest(
    Sheet sheet,
    IEnumerable<Part> partList,
    IEnumerable<Orientation> orientationList,
    IEnumerable<Point> positionList)
  {
    return Wrappable.Create<Result>(\u0005.\u0003.\u0001(this.\u0001.__Ptr, sheet.__Ptr, this.\u0001<Part>(partList), this.\u0001<Orientation>(orientationList), this.\u0001<Point>(positionList), partList.Count<Part>()), new Result());
  }

  public Result NestMore(Result result, IEnumerable<Part> partList, double time)
  {
    return Wrappable.Create<Result>(\u0005.\u0003.\u0001(this.\u0001.__Ptr, result.__Ptr, this.\u0001<Part>(partList), partList.Count<Part>(), time), new Result());
  }

  public ErrorCode GetResultInfos(Result result, out double length, out int nbNested)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, result.__Ptr, out length, out nbNested);
  }

  public ErrorCode GetKthNestedPart(
    Result result,
    int index,
    out Part part_result,
    out Point position,
    out Orientation orientation)
  {
    IntPtr zero = IntPtr.Zero;
    int kthNestedPart = \u0005.\u0003.\u0001(this.\u0001.__Ptr, result.__Ptr, index, out zero, out position, out orientation);
    part_result = Wrappable.Create<Part>(zero, new Part());
    return (ErrorCode) kthNestedPart;
  }

  public bool GetNestedPart(
    Result result,
    Part part,
    out Point position,
    out Orientation orientation)
  {
    return \u0005.\u0003.\u0001(this.\u0001.__Ptr, result.__Ptr, part.__Ptr, out position, out orientation) == 1;
  }

  public ErrorCode DrawSvg(Result result, string fileName)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, result.__Ptr, fileName);
  }

  public static string ErrorMessage(int error_code)
  {
    return Marshal.PtrToStringAnsi(\u0005.\u0003.\u0001(error_code));
  }

  public ErrorCode SetSessionCallbacks(
    StopNesting fStop,
    IUserData stopData,
    UpdateBest fUpdate,
    IUserData updateData)
  {
    this.\u0001 = fStop;
    this.\u0001 = fUpdate;
    \u0005.\u0003.\u0001(this);
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, new \u0001.\u0003(this.\u0001), \u0005.\u0003.\u0001(stopData, this), new \u0001.\u0002(this.\u0001), \u0005.\u0003.\u0001(updateData, this));
  }

  private void \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] IntPtr obj2)
  {
    Result result = Wrappable.Create<Result>(obj2, new Result());
    this.\u0001(\u0005.\u0003.\u0001(obj0), result);
  }

  private int \u0001([In] IntPtr obj0) => !this.\u0001(\u0005.\u0003.\u0001(obj0)) ? 0 : 1;

  public ErrorCode SetSessionNbThreads(int nbThreads)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, nbThreads);
  }

  public ErrorCode SetOutputReportFile(Session s, string reportFile)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(s.__Ptr, reportFile);
  }

  public bool CheckDetectedExe() => \u0005.\u0003.\u0001((StringBuilder) null) != 0;

  public bool CheckDetectedExe(out string detectedExe)
  {
    StringBuilder stringBuilder = new StringBuilder(1024 /*0x0400*/);
    int num = \u0005.\u0003.\u0001(stringBuilder);
    detectedExe = stringBuilder.ToString();
    return num != 0;
  }

  [DllImport("anpn2key.dll", EntryPoint = "#60", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  public static extern int GetVersion();

  public Result Shake(Result result, double time)
  {
    return Wrappable.Create<Result>(\u0005.\u0003.\u0001(this.\u0001.__Ptr, result.__Ptr, time), new Result());
  }

  public ErrorCode SetPreNestedGlueMode(Part part, PreNestedGlueMode glue_mode)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, part.__Ptr, (int) glue_mode);
  }

  public Contour CreateContourFromPoints(IEnumerable<Point> points)
  {
    return Wrappable.Create<Contour>(\u0005.\u0003.\u0001(this.\u0001.__Ptr, this.\u0001<Point>(points), points.Count<Point>()), new Contour());
  }

  public Contour CreateContourFromArcsSagittas(
    IEnumerable<Point> points,
    IEnumerable<double> sagittas)
  {
    return Wrappable.Create<Contour>(\u0005.\u0003.\u0001(this.\u0001.__Ptr, this.\u0001<Point>(points), this.\u0001<double>(sagittas), points.Count<Point>()), new Contour());
  }

  public Contour CreateContourFromArcsCenters(
    IEnumerable<Point> points,
    IEnumerable<Point> arcsCenters,
    IEnumerable<bool> arcsDirs)
  {
    return Wrappable.Create<Contour>(\u0005.\u0003.\u0001(this.\u0001.__Ptr, this.\u0001<Point>(points), this.\u0001<Point>(arcsCenters), this.\u0001<bool>(arcsDirs), points.Count<Point>()), new Contour());
  }

  public Shape AddShapeFromContour(Contour contour, Point pivot)
  {
    return Wrappable.Create<Shape>(\u0005.\u0003.\u0001(this.\u0001.__Ptr, contour.__Ptr, pivot), new Shape());
  }

  public ErrorCode ShapeAddHoleFromContour(Shape shape, Contour holeContour)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, shape.__Ptr, holeContour.__Ptr);
  }

  public Shape AddComplexShapeFromContours(IEnumerable<Contour> contours, Point pivot)
  {
    return Wrappable.Create<Shape>(\u0005.\u0003.\u0001(this.\u0001.__Ptr, this.\u0001<Contour>(contours), contours.Count<Contour>(), pivot), new Shape());
  }

  public ErrorCode SheetAddDefectFromContour(Sheet sheet, Contour contour)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, sheet.__Ptr, contour.__Ptr);
  }

  public ErrorCode SheetAddDefectFromContourWithOffset(Sheet sheet, Contour contour, double offset)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, sheet.__Ptr, contour.__Ptr, offset);
  }

  public Sheet AddSheetFromContour(Contour contour)
  {
    return Wrappable.Create<Sheet>(\u0005.\u0003.\u0001(this.\u0001.__Ptr, contour.__Ptr), new Sheet());
  }

  public Sheet AddSheetFromContourWithBorderGap(Contour contour, double borderGap)
  {
    return Wrappable.Create<Sheet>(\u0005.\u0003.\u0001(this.\u0001.__Ptr, contour.__Ptr, borderGap), new Sheet());
  }

  public ErrorCode ShapeSetProtectionLineFromContour(Shape shape, Contour protection)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, shape.__Ptr, protection.__Ptr);
  }

  public ErrorCode HoleSetProtectionLineFromContour(Shape shape, Contour protection)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, shape.__Ptr, protection.__Ptr);
  }

  public ErrorCode ComplexShapeSetProtectionLineFromContours(
    Shape shape,
    IEnumerable<Contour> protections)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, shape.__Ptr, this.\u0001<Contour>(protections), protections.Count<Contour>());
  }

  public Contour CreateContourFromArcsBulges(IEnumerable<Point> points, IEnumerable<double> bulges)
  {
    return Wrappable.Create<Contour>(\u0005.\u0003.\u0001(this.\u0001.__Ptr, this.\u0001<Point>(points), this.\u0001<double>(bulges), points.Count<Point>()), new Contour());
  }

  public PowerNest2()
  {
    this.\u0001 = \u0005.\u0003.\u0001(this);
    this.\u0001 = (IList<GCHandle>) new List<GCHandle>();
  }

  public void Dispose()
  {
    \u0005.\u0003.\u0001(this, true);
    GC.SuppressFinalize((object) this);
  }

  ~PowerNest2() => \u0005.\u0003.\u0001(this, false);

  public ErrorCode GetErrorCode(Wrappable obj)
  {
    return (int) obj.__Ptr >= 0 ? ErrorCode.OK : (ErrorCode) (int) obj.__Ptr;
  }

  private \u0001[] \u0001<\u0001>([In] IEnumerable<\u0001> obj0)
  {
    int num = 0;
    \u0001[] objArray = new \u0001[obj0.Count<\u0001>()];
    foreach (\u0001 obj in obj0)
      objArray[num++] = obj;
    return objArray;
  }

  private IntPtr[] \u0001<\u0001>([In] IEnumerable<\u0001> obj0) where \u0001 : Wrappable
  {
    int num = 0;
    IntPtr[] numArray = new IntPtr[obj0.Count<\u0001>()];
    foreach (\u0001 obj in obj0)
      numArray[num++] = obj.__Ptr;
    return numArray;
  }

  public ErrorCode SetCommonCutDistance(
    double common_cut_distance,
    double minInterPartCuttingDistance)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, common_cut_distance, minInterPartCuttingDistance);
  }

  public ErrorCode ShapeSetCommonCutType(Shape shape, CommonCutType type2)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, shape.__Ptr, type2);
  }

  public ErrorCode ShapeSetCommonCutMatching(Shape shape, int perfect_only)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, shape.__Ptr, perfect_only);
  }

  public ErrorCode ShapeSetMinimumAngleForCommonCut(Shape shape, double angle)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, shape.__Ptr, angle);
  }

  public ErrorCode ShapeSetMaximumRadiusForCommonCut(Shape shape, double radius)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, shape.__Ptr, radius);
  }

  public ErrorCode ShapeSetMinimumHoleAreaForCommonCut(Shape shape, double area)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, shape.__Ptr, area);
  }

  public ErrorCode ShapeSetMinimumCommonCutLength(Shape shape, double minCommonCutLength)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, shape.__Ptr, minCommonCutLength);
  }

  public ErrorCode ShapeSetMaxNbPartsInCommonCut(Shape shape, int maxNumber)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, shape.__Ptr, maxNumber);
  }

  public ErrorCode ShapeSetMaxCommonCutClusterDimension(Shape shape, double maxDimension)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, shape.__Ptr, maxDimension);
  }

  public ErrorCode ShapeSetSingleCommonCut(Shape shape, bool singleCCOnly)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, shape.__Ptr, singleCCOnly ? 1 : 0);
  }

  public ErrorCode ShapeSetClusterConstraintsForCommonCut(
    Shape shape,
    CommonCutClusterConstraint verticalCommonCut,
    CommonCutClusterConstraint horizontalCommonCut)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, shape.__Ptr, verticalCommonCut, horizontalCommonCut);
  }

  public ErrorCode IsPartInCommonCut(Result result, Part part, out bool inCommonCut)
  {
    int num1 = 0;
    int num2 = \u0005.\u0003.\u0001(this.\u0001.__Ptr, result.__Ptr, part.__Ptr, out num1);
    inCommonCut = num1 != 0;
    return (ErrorCode) num2;
  }

  public ErrorCode SetSentinelDongleInfos(
    out byte vendor_code,
    int vendor_code_size,
    uint offset,
    uint feature_id)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(out vendor_code, vendor_code_size, offset, feature_id);
  }

  public ErrorCode GetDongleId(out uint dongle_id) => (ErrorCode) \u0005.\u0003.\u0001(out dongle_id);

  public Sheet AddMetalSheet(double width, double length)
  {
    return Wrappable.Create<Sheet>(\u0005.\u0003.\u0001(this.\u0001.__Ptr, width, length), new Sheet());
  }

  public Result PricedNest(
    Sheet sheet,
    IEnumerable<Part> partList,
    IEnumerable<int> priceList,
    double time)
  {
    return Wrappable.Create<Result>(\u0005.\u0003.\u0001(this.\u0001.__Ptr, sheet.__Ptr, this.\u0001<Part>(partList), this.\u0001<int>(priceList), partList.Count<Part>(), time), new Result());
  }

  public MultiResult MultiNest(
    IEnumerable<Sheet> sheetList,
    IEnumerable<int> sheetQuantityList,
    IEnumerable<Part> partList,
    double time)
  {
    return Wrappable.Create<MultiResult>(\u0005.\u0003.\u0001(this.\u0001.__Ptr, this.\u0001<Sheet>(sheetList), sheetList.Count<Sheet>(), this.\u0001<int>(sheetQuantityList), this.\u0001<Part>(partList), partList.Count<Part>(), time), new MultiResult());
  }

  public ErrorCode GetMultiResultInfos(MultiResult multiResult, out int nbSheets)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, multiResult.__Ptr, out nbSheets);
  }

  public Result GetResult(MultiResult multiResult, int multiIndex, out Sheet sheet_result)
  {
    IntPtr zero = IntPtr.Zero;
    Result result = Wrappable.Create<Result>(\u0005.\u0003.\u0001(this.\u0001.__Ptr, multiResult.__Ptr, multiIndex, out zero), new Result());
    sheet_result = Wrappable.Create<Sheet>(zero, new Sheet());
    return result;
  }

  public ErrorCode DrawMultiSvg(MultiResult result, string file_name)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, result.__Ptr, file_name);
  }

  public ErrorCode SetSessionMultiCallbacks(
    StopNesting fStop,
    IUserData stopData,
    MultiUpdateBest fUpdate,
    IUserData updateData)
  {
    this.\u0001 = fStop;
    this.\u0001 = fUpdate;
    \u0005.\u0003.\u0001(this);
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, new \u0001.\u0003(this.\u0001), \u0005.\u0003.\u0001(stopData, this), new \u0005.\u0001(this.\u0002), \u0005.\u0003.\u0001(updateData, this));
  }

  private void \u0002([In] IntPtr obj0, [In] IntPtr obj1, [In] IntPtr obj2)
  {
    MultiResult multiResult = Wrappable.Create<MultiResult>(obj2, new MultiResult());
    this.\u0001(\u0005.\u0003.\u0001(obj0), multiResult);
  }

  public bool IsSameNesting(Result r1, Result r2)
  {
    return \u0005.\u0003.\u0001(this.\u0001.__Ptr, r1.__Ptr, r2.__Ptr) != 0;
  }

  public MultiResult PWSMultiNest(
    IEnumerable<Sheet> sheetList,
    IEnumerable<int> sheetQuantityList,
    IEnumerable<Part> partList,
    double time,
    string login,
    out string errorMessage)
  {
    StringBuilder stringBuilder = new StringBuilder(1024 /*0x0400*/);
    IntPtr ptr = \u0005.\u0003.\u0001(this.\u0001.__Ptr, this.\u0001<Sheet>(sheetList), sheetList.Count<Sheet>(), this.\u0001<int>(sheetQuantityList), this.\u0001<Part>(partList), partList.Count<Part>(), time, login, stringBuilder);
    errorMessage = stringBuilder.ToString();
    return Wrappable.Create<MultiResult>(ptr, new MultiResult());
  }

  public MultiResult MultiPreNest(
    IEnumerable<Sheet> sheetList,
    IEnumerable<int> nbPartsOnSheetList,
    IEnumerable<Part> partList,
    IEnumerable<Orientation> orientationList,
    IEnumerable<Point> positionList)
  {
    return Wrappable.Create<MultiResult>(\u0005.\u0003.\u0001(this.\u0001.__Ptr, sheetList.Count<Sheet>(), this.\u0001<Sheet>(sheetList), this.\u0001<int>(nbPartsOnSheetList), this.\u0001<Part>(partList), this.\u0001<Orientation>(orientationList), this.\u0001<Point>(positionList)), new MultiResult());
  }

  public MultiResult MultiNestMore(
    MultiResult multiResult,
    IEnumerable<Sheet> sheetList,
    IEnumerable<int> sheetQuantityList,
    IEnumerable<Part> partList,
    double time)
  {
    return Wrappable.Create<MultiResult>(\u0005.\u0003.\u0001(this.\u0001.__Ptr, multiResult.__Ptr, this.\u0001<Sheet>(sheetList), sheetList.Count<Sheet>(), this.\u0001<int>(sheetQuantityList), this.\u0001<Part>(partList), partList.Count<Part>(), time), new MultiResult());
  }

  public MultiResult CompleteMultiResultWithFillerParts(
    MultiResult multiResult,
    IEnumerable<Part> partList,
    double time)
  {
    return Wrappable.Create<MultiResult>(\u0005.\u0003.\u0001(this.\u0001.__Ptr, multiResult.__Ptr, this.\u0001<Part>(partList), partList.Count<Part>(), time), new MultiResult());
  }

  public Result Spread(Result result, bool spreadUntilSheetLength, double time)
  {
    return Wrappable.Create<Result>(\u0005.\u0003.\u0001(this.\u0001.__Ptr, result.__Ptr, spreadUntilSheetLength ? 1 : 0, time), new Result());
  }

  public Result SpreadIgnoreBorders(Result result, bool spreadUntilSheetLength, double time)
  {
    return Wrappable.Create<Result>(\u0005.\u0003.\u0001(this.\u0001.__Ptr, result.__Ptr, spreadUntilSheetLength ? 1 : 0, time), new Result());
  }

  public Result Compact(Result result, DirectionType type2, double time)
  {
    return Wrappable.Create<Result>(\u0005.\u0003.\u0001(this.\u0001.__Ptr, result.__Ptr, (int) type2, time), new Result());
  }

  public ErrorCode ShapeSetNestingWindows(
    Shape shape,
    IEnumerable<Sheet> sheetList,
    IEnumerable<Point> windowBottomLeftList,
    IEnumerable<Point> windowUpperRightList)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, shape.__Ptr, this.\u0001<Sheet>(sheetList), this.\u0001<Point>(windowBottomLeftList), this.\u0001<Point>(windowUpperRightList), sheetList.Count<Sheet>());
  }

  public ErrorCode PartSetOrderGroup(Part part, int orderGroup)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, part.__Ptr, orderGroup);
  }

  public ErrorCode SetMaximumInterleavedGroups(int maximumInterleavedGroups)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, maximumInterleavedGroups);
  }

  public MultiResult ConcatenateResults(IEnumerable<Result> resultList)
  {
    return Wrappable.Create<MultiResult>(\u0005.\u0003.\u0001(this.\u0001.__Ptr, this.\u0001<Result>(resultList), resultList.Count<Result>()), new MultiResult());
  }

  public ErrorCode AssociatePartToSheets(Part part, IEnumerable<Sheet> sheetList)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, part.__Ptr, this.\u0001<Sheet>(sheetList), sheetList.Count<Sheet>());
  }

  public ErrorCode SetCuttingHeadsNumber(int headsNumber)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, headsNumber);
  }

  public ErrorCode SetCuttingHeadsMinimumGap(double minimum_gap)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, minimum_gap);
  }

  public ErrorCode SetAdditionnalHeadCuttingUnitCost(double cost)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, cost);
  }

  public ErrorCode GetPartMultipleHeadsNumber(Result result, Part part, out int headsNumber)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, result.__Ptr, part.__Ptr, out headsNumber);
  }

  public ErrorCode GetPartMultipleHeadsLinkedPart(
    Result result,
    Part part,
    int index,
    out Part linkedPart)
  {
    IntPtr zero = IntPtr.Zero;
    int multipleHeadsLinkedPart = \u0005.\u0003.\u0001(this.\u0001.__Ptr, result.__Ptr, part.__Ptr, index, out zero);
    linkedPart = Wrappable.Create<Part>(zero, new Part());
    return (ErrorCode) multipleHeadsLinkedPart;
  }

  public ErrorCode SetMaterialUnitCost(double cost)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, cost);
  }

  public ErrorCode SetCuttingUnitCost(double cost)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, cost);
  }

  public ErrorCode EnableLayeredCutting(int layers_max_number)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, layers_max_number);
  }

  public ErrorCode SetSheetLayoutCost(double cost)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, cost);
  }

  public ErrorCode SetSessionOffcutSides(Side offcut_side, Side second_offcut_side)
  {
    return (ErrorCode) \u0005.\u0003.\u0001(this.\u0001.__Ptr, offcut_side, second_offcut_side);
  }
}
