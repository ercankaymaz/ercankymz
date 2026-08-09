using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using _0001;
using _0005;

namespace PowerNest2Cs;

public class PowerNest2 : IDisposable
{
	internal readonly Session _0001 = null;

	private MultiUpdateBest m__0001 = null;

	private UpdateBest m__0001 = null;

	private StopNesting m__0001 = null;

	internal readonly IList<GCHandle> _0001;

	internal bool _0001 = false;

	public static bool LogFunctionCalls(string file)
	{
		return _0005._0003._0001(file) != 0;
	}

	public static bool LogHostSpecs()
	{
		return _0005._0003._0001() != 0;
	}

	public Shape AddShape(IEnumerable<Point> pointList, Point pivot)
	{
		IntPtr ptr = default(IntPtr);
		while (2u != 0)
		{
			if (0 == 0)
			{
				IntPtr intPtr = _0005._0003._0001(this._0001.__Ptr, _0001<Point>(pointList), pointList.Count(), pivot);
				if (0 == 0)
				{
					ptr = intPtr;
				}
			}
			if (7u != 0)
			{
				return Wrappable.Create(ptr, new Shape());
			}
		}
		Shape result = default(Shape);
		return result;
	}

	public Shape AddShape(IEnumerable<Point> pointList)
	{
		if (true)
		{
			if (false)
			{
			}
			goto IL_0007;
		}
		goto IL_0019;
		IL_0019:
		Shape result;
		if (8u != 0)
		{
			return result;
		}
		goto IL_0007;
		IL_0007:
		if (3u != 0)
		{
			result = AddShape(pointList, pointList.ElementAt(0));
		}
		goto IL_0019;
	}

	public Shape AddComplexShape(IEnumerable<Point> pointList, IEnumerable<int> nbOutlinePointList, Point pivot)
	{
		while (true)
		{
			Shape shape;
			if (0 == 0)
			{
				IntPtr intPtr = this._0001.__Ptr;
				do
				{
					IntPtr intPtr2 = _0005._0003._0001(intPtr, _0001<Point>(pointList), _0001<int>(nbOutlinePointList), nbOutlinePointList.Count(), pivot);
					intPtr = intPtr2;
				}
				while (5 == 0);
				shape = Wrappable.Create(intPtr, new Shape());
			}
			while (true)
			{
				Shape result = shape;
				if (-1 == 0 || 1 == 0)
				{
					break;
				}
				if (0 == 0)
				{
					return result;
				}
			}
		}
	}

	public Shape AddComplexShape(IEnumerable<Point> pointList, IEnumerable<int> nbOutlinePointList)
	{
		while (-1 == 0)
		{
		}
		return AddComplexShape(pointList, nbOutlinePointList, pointList.ElementAt(0));
	}

	public ErrorCode ShapeAddHole(Shape shape, IEnumerable<Point> holePointList)
	{
		if (uint.MaxValue != 0 && 8u != 0 && true && 7u != 0)
		{
			return (ErrorCode)_0005._0003._0001(this._0001.__Ptr, shape.__Ptr, _0001<Point>(holePointList), holePointList.Count());
		}
		ErrorCode result;
		return result;
	}

	public ErrorCode ShapeSetProtectionOffset(Shape shape, double protectionOffset)
	{
		int num2 = default(int);
		ErrorCode result = default(ErrorCode);
		while (4u != 0)
		{
			int num = _0005._0003._0001(this._0001.__Ptr, shape.__Ptr, protectionOffset);
			do
			{
				if (0 == 0)
				{
					if (0 == 0)
					{
						num2 = num;
					}
					num = num2;
				}
			}
			while (6 == 0);
			result = (ErrorCode)num;
			if (0 == 0)
			{
				break;
			}
		}
		return result;
	}

	public ErrorCode ShapeSetProtectionLine(Shape shape, IEnumerable<Point> protection)
	{
		if (false)
		{
			int result;
			return (ErrorCode)result;
		}
		return (ErrorCode)_0005._0003._0001(this._0001.__Ptr, shape.__Ptr, _0001<Point>(protection), protection.Count());
	}

	public ErrorCode HoleSetProtectionLine(Shape shape, IEnumerable<Point> protection)
	{
		if (false)
		{
			int result;
			return (ErrorCode)result;
		}
		return (ErrorCode)_0005._0003._0001(this._0001.__Ptr, shape.__Ptr, _0001<Point>(protection), protection.Count());
	}

	public ErrorCode ComplexShapeSetProtectionLine(Shape shape, IEnumerable<Point> protectionPointList, IEnumerable<int> outlinesNbPointList)
	{
		if (2u != 0 && uint.MaxValue != 0)
		{
			return (ErrorCode)_0005._0003._0001(this._0001.__Ptr, shape.__Ptr, _0001<Point>(protectionPointList), _0001<int>(outlinesNbPointList), outlinesNbPointList.Count());
		}
		ErrorCode result;
		return result;
	}

	[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#309")]
	public static extern Orientation CreateOrientation(double angle);

	[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#10")]
	public static extern Orientation CreateRangeOrientation(double angle, double tolerance);

	[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#11")]
	public static extern Orientation CreateXFlippedOrientation(double angle);

	[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#12")]
	public static extern Orientation CreateXFlippedRangeOrientation(double angle, double tolerance);

	public Orientation CreateFreeOrientation(bool flip)
	{
		int num;
		while (true)
		{
			if (8 == 0)
			{
				continue;
			}
			num = (flip ? 1 : 0);
			if (8 == 0)
			{
				break;
			}
			if (num == 0)
			{
				if (0 == 0)
				{
					num = 0;
					break;
				}
			}
			else if (0 == 0)
			{
				num = 1;
				break;
			}
		}
		return _0005._0003._0001(num);
	}

	public Part AddPart(Shape shape, IEnumerable<Orientation> orientationList)
	{
		while (true)
		{
			IntPtr intPtr = this._0001.__Ptr;
			if (0 == 0)
			{
				intPtr = _0005._0003._0001(intPtr, shape.__Ptr, _0001<Orientation>(orientationList), orientationList.Count());
			}
			while (true)
			{
				IntPtr intPtr2 = intPtr;
				if (6 == 0)
				{
					break;
				}
				intPtr = intPtr2;
				if (3 == 0)
				{
					continue;
				}
				Part result = Wrappable.Create(intPtr, new Part());
				if (0 == 0)
				{
					return result;
				}
				Part result2;
				return result2;
			}
		}
	}

	public ErrorCode AddSeveralParts(Shape shape, IEnumerable<Orientation> orientationList, int quantity, out IEnumerable<Part> partList)
	{
		int result;
		while (true)
		{
			IntPtr[] array = new IntPtr[quantity];
			int num;
			if (0 == 0)
			{
				num = _0005._0003._0001(this._0001.__Ptr, shape.__Ptr, _0001<Orientation>(orientationList), orientationList.Count(), quantity, array);
				if (false)
				{
					goto IL_008c;
				}
				result = num;
			}
			IList<Part> list = new List<Part>();
			int num2 = 0;
			if (num2 != 0)
			{
				goto IL_007e;
			}
			int num3 = num2;
			goto IL_0081;
			IL_0081:
			num = ((num3 < quantity) ? 1 : 0);
			goto IL_0085;
			IL_0085:
			bool flag = (byte)num != 0;
			if (false)
			{
				break;
			}
			num = (flag ? 1 : 0);
			goto IL_008c;
			IL_007e:
			num3 = num2 + 1;
			goto IL_0081;
			IL_008c:
			if (8u != 0)
			{
				if (num != 0)
				{
					Part item = Wrappable.Create(array[num3], new Part());
					list.Add(item);
					if (7 == 0)
					{
						continue;
					}
					num2 = num3;
					goto IL_007e;
				}
				partList = list;
				break;
			}
			goto IL_0085;
		}
		return (ErrorCode)result;
	}

	public ErrorCode PartSetPriority(Part part, int priority)
	{
		int num2 = default(int);
		ErrorCode result = default(ErrorCode);
		while (4u != 0)
		{
			int num = _0005._0003._0001(this._0001.__Ptr, part.__Ptr, priority);
			do
			{
				if (0 == 0)
				{
					if (0 == 0)
					{
						num2 = num;
					}
					num = num2;
				}
			}
			while (6 == 0);
			result = (ErrorCode)num;
			if (0 == 0)
			{
				break;
			}
		}
		return result;
	}

	public Sheet AddSheet(double width, double length)
	{
		IntPtr ptr = _0005._0003._0001(this._0001.__Ptr, width, length);
		return Wrappable.Create(ptr, new Sheet());
	}

	public ErrorCode SheetAddBorderGaps(Sheet sheet, double leftGap, double rightGap, double bottomGap, double topGap)
	{
		ErrorCode result = default(ErrorCode);
		while (true)
		{
			if (6 == 0)
			{
				goto IL_0029;
			}
			int num = _0005._0003._0001(this._0001.__Ptr, sheet.__Ptr, leftGap, rightGap, bottomGap, topGap);
			goto IL_004e;
			IL_0051:
			int num2;
			num = num2;
			if (false)
			{
				goto IL_004e;
			}
			result = (ErrorCode)num;
			goto IL_0029;
			IL_0029:
			if (false)
			{
				goto IL_0051;
			}
			if (0 == 0)
			{
				break;
			}
			continue;
			IL_004e:
			num2 = num;
			goto IL_0051;
		}
		return result;
	}

	public ErrorCode SheetAddDefect(Sheet sheet, IEnumerable<Point> defectPointList)
	{
		if (uint.MaxValue != 0 && 8u != 0 && true && 7u != 0)
		{
			return (ErrorCode)_0005._0003._0001(this._0001.__Ptr, sheet.__Ptr, _0001<Point>(defectPointList), defectPointList.Count());
		}
		ErrorCode result;
		return result;
	}

	public ErrorCode SheetAddDefectWithOffset(Sheet sheet, IEnumerable<Point> defectPointList, double offset)
	{
		return (ErrorCode)_0005._0003._0001(this._0001.__Ptr, sheet.__Ptr, _0001<Point>(defectPointList), defectPointList.Count(), offset);
	}

	public Sheet AddPolygonalSheet(IEnumerable<Point> pointList)
	{
		IntPtr ptr = _0005._0003._0001(this._0001.__Ptr, _0001<Point>(pointList), pointList.Count());
		return Wrappable.Create(ptr, new Sheet());
	}

	public Sheet AddPolygonalSheetWithBorderGap(IEnumerable<Point> pointList, double borderGap)
	{
		IntPtr ptr = default(IntPtr);
		while (2u != 0)
		{
			if (0 == 0)
			{
				IntPtr intPtr = _0005._0003._0001(this._0001.__Ptr, _0001<Point>(pointList), pointList.Count(), borderGap);
				if (0 == 0)
				{
					ptr = intPtr;
				}
			}
			if (7u != 0)
			{
				return Wrappable.Create(ptr, new Sheet());
			}
		}
		Sheet result = default(Sheet);
		return result;
	}

	public Result Nest(Sheet sheet, IEnumerable<Part> partList, double time)
	{
		IntPtr intPtr = this._0001.__Ptr;
		do
		{
			intPtr = _0005._0003._0001(intPtr, sheet.__Ptr, _0001<Part>(partList), partList.Count(), time);
			if (0 == 0)
			{
				IntPtr intPtr2 = intPtr;
				intPtr = intPtr2;
			}
		}
		while (7 == 0);
		return Wrappable.Create(intPtr, new Result());
	}

	public Result PreNest(Sheet sheet, IEnumerable<Part> partList, IEnumerable<Orientation> orientationList, IEnumerable<Point> positionList)
	{
		if (7 == 0)
		{
			goto IL_003b;
		}
		if (false)
		{
			goto IL_0047;
		}
		goto IL_0050;
		IL_0047:
		Result result2;
		Result result = result2;
		if (-1 == 0)
		{
			goto IL_0050;
		}
		return result;
		IL_0050:
		IntPtr ptr = _0005._0003._0001(this._0001.__Ptr, sheet.__Ptr, _0001<Part>(partList), _0001<Orientation>(orientationList), _0001<Point>(positionList), partList.Count());
		goto IL_003b;
		IL_003b:
		result2 = Wrappable.Create(ptr, new Result());
		goto IL_0047;
	}

	public Result NestMore(Result result, IEnumerable<Part> partList, double time)
	{
		IntPtr intPtr = this._0001.__Ptr;
		do
		{
			intPtr = _0005._0003._0001(intPtr, result.__Ptr, _0001<Part>(partList), partList.Count(), time);
			if (0 == 0)
			{
				IntPtr intPtr2 = intPtr;
				intPtr = intPtr2;
			}
		}
		while (7 == 0);
		return Wrappable.Create(intPtr, new Result());
	}

	public ErrorCode GetResultInfos(Result result, out double length, out int nbNested)
	{
		int num = _0005._0003._0001(this._0001.__Ptr, result.__Ptr, out length, out nbNested);
		do
		{
			int num2 = num;
			num = num2;
		}
		while (5 == 0);
		ErrorCode result2 = (ErrorCode)num;
		if (0 == 0)
		{
		}
		return result2;
	}

	public ErrorCode GetKthNestedPart(Result result, int index, out Part part_result, out Point position, out Orientation orientation)
	{
		ErrorCode result2 = default(ErrorCode);
		int num = default(int);
		while (true)
		{
			if (4 == 0)
			{
				goto IL_0040;
			}
			IntPtr intPtr = IntPtr.Zero;
			IntPtr ptr;
			while (true)
			{
				if (0 == 0)
				{
					ptr = intPtr;
				}
				if (-1 == 0)
				{
					break;
				}
				intPtr = this._0001.__Ptr;
				if (6 == 0)
				{
					continue;
				}
				goto IL_0052;
			}
			goto IL_0044;
			IL_0040:
			result2 = (ErrorCode)num;
			goto IL_0044;
			IL_0044:
			while (true)
			{
				if (false)
				{
					continue;
				}
				return result2;
			}
			continue;
			IL_0052:
			num = _0005._0003._0001(intPtr, result.__Ptr, index, out ptr, out position, out orientation);
			part_result = Wrappable.Create(ptr, new Part());
			goto IL_0040;
		}
	}

	public bool GetNestedPart(Result result, Part part, out Point position, out Orientation orientation)
	{
		while (true)
		{
			int num = _0005._0003._0001(this._0001.__Ptr, result.__Ptr, part.__Ptr, out position, out orientation);
			while (true)
			{
				int num2 = num;
				if (false)
				{
					break;
				}
				int num3 = num2;
				if (0 == 0)
				{
					num3 = ((num3 == 1) ? 1 : 0);
				}
				bool flag = (byte)num3 != 0;
				if (0 == 0)
				{
				}
				num = (flag ? 1 : 0);
				if (0 == 0)
				{
					return (byte)num != 0;
				}
			}
		}
	}

	public ErrorCode DrawSvg(Result result, string fileName)
	{
		int num2 = default(int);
		ErrorCode result2 = default(ErrorCode);
		while (4u != 0)
		{
			int num = _0005._0003._0001(this._0001.__Ptr, result.__Ptr, fileName);
			do
			{
				if (0 == 0)
				{
					if (0 == 0)
					{
						num2 = num;
					}
					num = num2;
				}
			}
			while (6 == 0);
			result2 = (ErrorCode)num;
			if (0 == 0)
			{
				break;
			}
		}
		return result2;
	}

	public static string ErrorMessage(int error_code)
	{
		string result = default(string);
		while (true)
		{
			string text2;
			if (5u != 0)
			{
				if (false)
				{
					continue;
				}
				IntPtr intPtr = _0005._0003._0001(error_code);
				IntPtr intPtr2;
				if (4u != 0)
				{
					intPtr2 = intPtr;
				}
				string text = _0012._0016(intPtr2);
				if (5u != 0)
				{
					text2 = text;
				}
				goto IL_001c;
			}
			goto IL_0025;
			IL_0025:
			if (5u != 0)
			{
				break;
			}
			goto IL_001c;
			IL_001c:
			if (0 == 0)
			{
				result = text2;
			}
			goto IL_0025;
		}
		return result;
	}

	public ErrorCode SetSessionCallbacks(StopNesting fStop, IUserData stopData, UpdateBest fUpdate, IUserData updateData)
	{
		if (3u != 0)
		{
		}
		this.m__0001 = fStop;
		this.m__0001 = fUpdate;
		_0005._0003._0001(this);
		IntPtr intPtr;
		if (uint.MaxValue != 0)
		{
			intPtr = _0005._0003._0001(stopData, this);
			goto IL_003c;
		}
		goto IL_004c;
		IL_004c:
		intPtr = this._0001.__Ptr;
		goto IL_0057;
		IL_0057:
		IntPtr intPtr2 = default(IntPtr);
		IntPtr intPtr3 = default(IntPtr);
		if (7u != 0)
		{
			return (ErrorCode)_0005._0003._0001(intPtr, (global::_0001._0003)_0001, intPtr2, (global::_0001._0002)_0001, intPtr3);
		}
		goto IL_003c;
		IL_003c:
		if (0 == 0)
		{
			if (0 == 0)
			{
				intPtr2 = intPtr;
				intPtr = _0005._0003._0001(updateData, this);
			}
			intPtr3 = intPtr;
			goto IL_004c;
		}
		goto IL_0057;
	}

	private void _0001(IntPtr P_0, IntPtr P_1, IntPtr P_2)
	{
		while (true)
		{
			Result result = Wrappable.Create(P_2, new Result());
			if (2 == 0)
			{
				continue;
			}
			IUserData userData = _0005._0003._0001(P_0);
			while (0 == 0)
			{
				this.m__0001(userData, result);
				if (8u != 0)
				{
					return;
				}
			}
		}
	}

	private int _0001(IntPtr P_0)
	{
		while (true)
		{
			IUserData userData = _0005._0003._0001(P_0);
			bool flag = this.m__0001(userData);
			if (8 == 0)
			{
				continue;
			}
			bool flag2;
			if (4u != 0)
			{
				flag2 = flag;
			}
			int num = (flag2 ? 1 : 0);
			while (true)
			{
				int num2;
				if (num != 0)
				{
					num = 1;
					if (num == 0)
					{
						goto IL_002f;
					}
					num2 = num;
				}
				else
				{
					num2 = 0;
					if (false)
					{
						break;
					}
				}
				num = num2;
				goto IL_002f;
				IL_002f:
				if (0 == 0)
				{
					return num;
				}
			}
		}
	}

	public ErrorCode SetSessionNbThreads(int nbThreads)
	{
		while (0 == 0)
		{
			if (-1 == 0)
			{
				continue;
			}
			int num = _0005._0003._0001(this._0001.__Ptr, nbThreads);
			do
			{
				int num2;
				if (7u != 0)
				{
					num2 = num;
				}
				num = num2;
			}
			while (7 == 0 || 8 == 0);
			return (ErrorCode)num;
		}
		ErrorCode result;
		return result;
	}

	public ErrorCode SetOutputReportFile(Session s, string reportFile)
	{
		while (true)
		{
			if (0 == 0)
			{
			}
			while (8u != 0)
			{
				int num = _0005._0003._0001(s.__Ptr, reportFile);
				if (0 == 0)
				{
					int num2 = num;
					num = num2;
				}
				ErrorCode result = (ErrorCode)num;
				if (8u != 0)
				{
					return result;
				}
			}
		}
	}

	public bool CheckDetectedExe()
	{
		while (8 == 0)
		{
		}
		int num = _0005._0003._0001((StringBuilder)null);
		do
		{
			if (0 == 0)
			{
				int num2 = num;
				num = num2;
			}
		}
		while (false);
		bool num3 = num != 0;
		if (0 == 0)
		{
			bool flag = num3;
			num3 = flag;
		}
		return num3;
	}

	public bool CheckDetectedExe(out string detectedExe)
	{
		StringBuilder stringBuilder = new StringBuilder(1024);
		while (true)
		{
			int num = _0005._0003._0001(stringBuilder);
			while (true)
			{
				IL_0046:
				int num2 = num;
				bool result;
				if (0 == 0)
				{
					detectedExe = _0013._007E_0017(stringBuilder);
					while (0 == 0)
					{
						num = num2;
						if (false)
						{
							goto IL_0046;
						}
						result = num != 0;
						if (false)
						{
							continue;
						}
						goto IL_0030;
					}
					break;
				}
				goto IL_0030;
				IL_0030:
				return result;
			}
		}
	}

	[DllImport("anpn2key.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "#60")]
	public static extern int GetVersion();

	public Result Shake(Result result, double time)
	{
		IntPtr ptr;
		do
		{
			if (false)
			{
				continue;
			}
			IntPtr intPtr = this._0001.__Ptr;
			do
			{
				if (0 == 0)
				{
					intPtr = _0005._0003._0001(intPtr, result.__Ptr, time);
				}
			}
			while (4 == 0);
			ptr = intPtr;
		}
		while (5 == 0);
		return Wrappable.Create(ptr, new Result());
	}

	public ErrorCode SetPreNestedGlueMode(Part part, PreNestedGlueMode glue_mode)
	{
		int num2 = default(int);
		ErrorCode result = default(ErrorCode);
		while (4u != 0)
		{
			int num = _0005._0003._0001(this._0001.__Ptr, part.__Ptr, (int)glue_mode);
			do
			{
				if (0 == 0)
				{
					if (0 == 0)
					{
						num2 = num;
					}
					num = num2;
				}
			}
			while (6 == 0);
			result = (ErrorCode)num;
			if (0 == 0)
			{
				break;
			}
		}
		return result;
	}

	public Contour CreateContourFromPoints(IEnumerable<Point> points)
	{
		IntPtr ptr = _0005._0003._0001(this._0001.__Ptr, _0001<Point>(points), points.Count());
		return Wrappable.Create(ptr, new Contour());
	}

	public Contour CreateContourFromArcsSagittas(IEnumerable<Point> points, IEnumerable<double> sagittas)
	{
		IntPtr intPtr = this._0001.__Ptr;
		do
		{
			intPtr = _0005._0003._0001(intPtr, _0001<Point>(points), _0001<double>(sagittas), points.Count());
			if (0 == 0)
			{
				IntPtr intPtr2 = intPtr;
				intPtr = intPtr2;
			}
		}
		while (7 == 0);
		return Wrappable.Create(intPtr, new Contour());
	}

	public Contour CreateContourFromArcsCenters(IEnumerable<Point> points, IEnumerable<Point> arcsCenters, IEnumerable<bool> arcsDirs)
	{
		Contour result;
		do
		{
			IntPtr ptr = _0005._0003._0001(this._0001.__Ptr, _0001<Point>(points), _0001<Point>(arcsCenters), _0001<bool>(arcsDirs), points.Count());
			Contour contour = Wrappable.Create(ptr, new Contour());
			result = contour;
		}
		while (2 == 0);
		return result;
	}

	public Shape AddShapeFromContour(Contour contour, Point pivot)
	{
		IntPtr ptr;
		do
		{
			if (false)
			{
				continue;
			}
			IntPtr intPtr = this._0001.__Ptr;
			do
			{
				if (0 == 0)
				{
					intPtr = _0005._0003._0001(intPtr, contour.__Ptr, pivot);
				}
			}
			while (4 == 0);
			ptr = intPtr;
		}
		while (5 == 0);
		return Wrappable.Create(ptr, new Shape());
	}

	public ErrorCode ShapeAddHoleFromContour(Shape shape, Contour holeContour)
	{
		int num = _0005._0003._0001(this._0001.__Ptr, shape.__Ptr, holeContour.__Ptr);
		do
		{
			int num2 = num;
			num = num2;
		}
		while (5 == 0);
		ErrorCode result = (ErrorCode)num;
		if (0 == 0)
		{
		}
		return result;
	}

	public Shape AddComplexShapeFromContours(IEnumerable<Contour> contours, Point pivot)
	{
		IntPtr ptr = default(IntPtr);
		while (2u != 0)
		{
			if (0 == 0)
			{
				IntPtr intPtr = _0005._0003._0001(this._0001.__Ptr, _0001<Contour>(contours), contours.Count(), pivot);
				if (0 == 0)
				{
					ptr = intPtr;
				}
			}
			if (7u != 0)
			{
				return Wrappable.Create(ptr, new Shape());
			}
		}
		Shape result = default(Shape);
		return result;
	}

	public ErrorCode SheetAddDefectFromContour(Sheet sheet, Contour contour)
	{
		int num = _0005._0003._0001(this._0001.__Ptr, sheet.__Ptr, contour.__Ptr);
		do
		{
			int num2 = num;
			num = num2;
		}
		while (5 == 0);
		ErrorCode result = (ErrorCode)num;
		if (0 == 0)
		{
		}
		return result;
	}

	public ErrorCode SheetAddDefectFromContourWithOffset(Sheet sheet, Contour contour, double offset)
	{
		if (uint.MaxValue != 0 && 8u != 0)
		{
			int result;
			if (true)
			{
				if (7 == 0)
				{
					goto IL_0052;
				}
				result = _0005._0003._0001(this._0001.__Ptr, sheet.__Ptr, contour.__Ptr, offset);
			}
			return (ErrorCode)result;
		}
		goto IL_0052;
		IL_0052:
		ErrorCode result2 = default(ErrorCode);
		return result2;
	}

	public Sheet AddSheetFromContour(Contour contour)
	{
		IntPtr ptr = _0005._0003._0001(this._0001.__Ptr, contour.__Ptr);
		return Wrappable.Create(ptr, new Sheet());
	}

	public Sheet AddSheetFromContourWithBorderGap(Contour contour, double borderGap)
	{
		IntPtr ptr;
		do
		{
			if (false)
			{
				continue;
			}
			IntPtr intPtr = this._0001.__Ptr;
			do
			{
				if (0 == 0)
				{
					intPtr = _0005._0003._0001(intPtr, contour.__Ptr, borderGap);
				}
			}
			while (4 == 0);
			ptr = intPtr;
		}
		while (5 == 0);
		return Wrappable.Create(ptr, new Sheet());
	}

	public ErrorCode ShapeSetProtectionLineFromContour(Shape shape, Contour protection)
	{
		int num = _0005._0003._0001(this._0001.__Ptr, shape.__Ptr, protection.__Ptr);
		do
		{
			int num2 = num;
			num = num2;
		}
		while (5 == 0);
		ErrorCode result = (ErrorCode)num;
		if (0 == 0)
		{
		}
		return result;
	}

	public ErrorCode HoleSetProtectionLineFromContour(Shape shape, Contour protection)
	{
		int num = _0005._0003._0001(this._0001.__Ptr, shape.__Ptr, protection.__Ptr);
		do
		{
			int num2 = num;
			num = num2;
		}
		while (5 == 0);
		ErrorCode result = (ErrorCode)num;
		if (0 == 0)
		{
		}
		return result;
	}

	public ErrorCode ComplexShapeSetProtectionLineFromContours(Shape shape, IEnumerable<Contour> protections)
	{
		if (false)
		{
			int result;
			return (ErrorCode)result;
		}
		return (ErrorCode)_0005._0003._0001(this._0001.__Ptr, shape.__Ptr, _0001<Contour>(protections), protections.Count());
	}

	public Contour CreateContourFromArcsBulges(IEnumerable<Point> points, IEnumerable<double> bulges)
	{
		IntPtr intPtr = this._0001.__Ptr;
		do
		{
			intPtr = _0005._0003._0001(intPtr, _0001<Point>(points), _0001<double>(bulges), points.Count());
			if (0 == 0)
			{
				IntPtr intPtr2 = intPtr;
				intPtr = intPtr2;
			}
		}
		while (7 == 0);
		return Wrappable.Create(intPtr, new Contour());
	}

	public PowerNest2()
	{
		this._0001 = _0005._0003._0001(this);
		this._0001 = new List<GCHandle>();
	}

	public void Dispose()
	{
		_0005._0003._0001(this, true);
		_0010._0014(this);
	}

	~PowerNest2()
	{
		if (8 == 0)
		{
			return;
		}
		try
		{
			do
			{
				_0005._0003._0001(this, false);
			}
			while (2 == 0);
		}
		finally
		{
			if (5u != 0 && 0 == 0)
			{
				global::_0006._0007(this);
			}
		}
	}

	public ErrorCode GetErrorCode(Wrappable obj)
	{
		if (uint.MaxValue != 0)
		{
			bool num = _0014._0018(obj.__Ptr) < 0;
			bool flag;
			if (4u != 0)
			{
				flag = num;
			}
			int result;
			if (0 == 0 && flag)
			{
				result = _0014._0018(obj.__Ptr);
				if (0 == 0 && 0 == 0)
				{
					return (ErrorCode)result;
				}
			}
			else
			{
				result = 0;
			}
			if (0 == 0)
			{
				return (ErrorCode)result;
			}
		}
		ErrorCode result2 = default(ErrorCode);
		return result2;
	}

	private _0001[] _0001<_0001>(IEnumerable<_0001> P_0)
	{
		int num = 0;
		while (true)
		{
			int num2 = num;
			while (true)
			{
				num = P_0.Count();
				if (false)
				{
					break;
				}
				_0001[] array = new _0001[num];
				IEnumerator<_0001> enumerator = P_0.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						_0001 current = enumerator.Current;
						array[num2++] = current;
					}
				}
				finally
				{
					do
					{
						if (enumerator == null)
						{
							continue;
						}
						while (6u != 0)
						{
							enumerator.Dispose();
							if (uint.MaxValue != 0)
							{
								break;
							}
						}
					}
					while (false);
				}
				_0001[] result = array;
				if (3 == 0)
				{
					continue;
				}
				return result;
			}
		}
	}

	private IntPtr[] _0001<_0001>(IEnumerable<_0001> P_0) where _0001 : Wrappable
	{
		IntPtr[] array;
		if (0 == 0)
		{
			int num = 0;
			int num2;
			do
			{
				num2 = num;
				num = P_0.Count();
			}
			while (-1 == 0);
			array = new IntPtr[num];
			IEnumerator<_0001> enumerator = P_0.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					_0001 current = enumerator.Current;
					array[num2++] = current.__Ptr;
				}
			}
			finally
			{
				if (false || enumerator != null)
				{
					while (true)
					{
						enumerator.Dispose();
						if (uint.MaxValue != 0)
						{
							break;
						}
					}
				}
			}
		}
		return array;
	}

	public ErrorCode SetCommonCutDistance(double common_cut_distance, double minInterPartCuttingDistance)
	{
		ErrorCode result = default(ErrorCode);
		while (true)
		{
			int num2;
			if (5u != 0)
			{
				if (false)
				{
					continue;
				}
				int num = _0005._0003._0001(this._0001.__Ptr, common_cut_distance, minInterPartCuttingDistance);
				if (4u != 0)
				{
					num2 = num;
				}
				goto IL_001d;
			}
			goto IL_0028;
			IL_001d:
			if (0 == 0)
			{
				int num3 = num2;
				if (5u != 0)
				{
					result = (ErrorCode)num3;
				}
			}
			goto IL_0028;
			IL_0028:
			if (5u != 0)
			{
				break;
			}
			goto IL_001d;
		}
		return result;
	}

	public ErrorCode ShapeSetCommonCutType(Shape shape, CommonCutType type2)
	{
		int num2 = default(int);
		ErrorCode result = default(ErrorCode);
		while (4u != 0)
		{
			int num = _0005._0003._0001(this._0001.__Ptr, shape.__Ptr, type2);
			do
			{
				if (0 == 0)
				{
					if (0 == 0)
					{
						num2 = num;
					}
					num = num2;
				}
			}
			while (6 == 0);
			result = (ErrorCode)num;
			if (0 == 0)
			{
				break;
			}
		}
		return result;
	}

	public ErrorCode ShapeSetCommonCutMatching(Shape shape, int perfect_only)
	{
		int num2 = default(int);
		ErrorCode result = default(ErrorCode);
		while (4u != 0)
		{
			int num = _0005._0003._0001(this._0001.__Ptr, shape.__Ptr, perfect_only);
			do
			{
				if (0 == 0)
				{
					if (0 == 0)
					{
						num2 = num;
					}
					num = num2;
				}
			}
			while (6 == 0);
			result = (ErrorCode)num;
			if (0 == 0)
			{
				break;
			}
		}
		return result;
	}

	public ErrorCode ShapeSetMinimumAngleForCommonCut(Shape shape, double angle)
	{
		int num2 = default(int);
		ErrorCode result = default(ErrorCode);
		while (4u != 0)
		{
			int num = _0005._0003._0001(this._0001.__Ptr, shape.__Ptr, angle);
			do
			{
				if (0 == 0)
				{
					if (0 == 0)
					{
						num2 = num;
					}
					num = num2;
				}
			}
			while (6 == 0);
			result = (ErrorCode)num;
			if (0 == 0)
			{
				break;
			}
		}
		return result;
	}

	public ErrorCode ShapeSetMaximumRadiusForCommonCut(Shape shape, double radius)
	{
		int num2 = default(int);
		ErrorCode result = default(ErrorCode);
		while (4u != 0)
		{
			int num = _0005._0003._0001(this._0001.__Ptr, shape.__Ptr, radius);
			do
			{
				if (0 == 0)
				{
					if (0 == 0)
					{
						num2 = num;
					}
					num = num2;
				}
			}
			while (6 == 0);
			result = (ErrorCode)num;
			if (0 == 0)
			{
				break;
			}
		}
		return result;
	}

	public ErrorCode ShapeSetMinimumHoleAreaForCommonCut(Shape shape, double area)
	{
		int num2 = default(int);
		ErrorCode result = default(ErrorCode);
		while (4u != 0)
		{
			int num = _0005._0003._0001(this._0001.__Ptr, shape.__Ptr, area);
			do
			{
				if (0 == 0)
				{
					if (0 == 0)
					{
						num2 = num;
					}
					num = num2;
				}
			}
			while (6 == 0);
			result = (ErrorCode)num;
			if (0 == 0)
			{
				break;
			}
		}
		return result;
	}

	public ErrorCode ShapeSetMinimumCommonCutLength(Shape shape, double minCommonCutLength)
	{
		int num2 = default(int);
		ErrorCode result = default(ErrorCode);
		while (4u != 0)
		{
			int num = _0005._0003._0001(this._0001.__Ptr, shape.__Ptr, minCommonCutLength);
			do
			{
				if (0 == 0)
				{
					if (0 == 0)
					{
						num2 = num;
					}
					num = num2;
				}
			}
			while (6 == 0);
			result = (ErrorCode)num;
			if (0 == 0)
			{
				break;
			}
		}
		return result;
	}

	public ErrorCode ShapeSetMaxNbPartsInCommonCut(Shape shape, int maxNumber)
	{
		int num2 = default(int);
		ErrorCode result = default(ErrorCode);
		while (4u != 0)
		{
			int num = _0005._0003._0001(this._0001.__Ptr, shape.__Ptr, maxNumber);
			do
			{
				if (0 == 0)
				{
					if (0 == 0)
					{
						num2 = num;
					}
					num = num2;
				}
			}
			while (6 == 0);
			result = (ErrorCode)num;
			if (0 == 0)
			{
				break;
			}
		}
		return result;
	}

	public ErrorCode ShapeSetMaxCommonCutClusterDimension(Shape shape, double maxDimension)
	{
		int num2 = default(int);
		ErrorCode result = default(ErrorCode);
		while (4u != 0)
		{
			int num = _0005._0003._0001(this._0001.__Ptr, shape.__Ptr, maxDimension);
			do
			{
				if (0 == 0)
				{
					if (0 == 0)
					{
						num2 = num;
					}
					num = num2;
				}
			}
			while (6 == 0);
			result = (ErrorCode)num;
			if (0 == 0)
			{
				break;
			}
		}
		return result;
	}

	public ErrorCode ShapeSetSingleCommonCut(Shape shape, bool singleCCOnly)
	{
		int num2;
		if (0 == 0)
		{
			IntPtr _Ptr = this._0001.__Ptr;
			IntPtr _Ptr2 = shape.__Ptr;
			while (true)
			{
				int num = (singleCCOnly ? 1 : 0);
				while (true)
				{
					if (num == 0)
					{
						if (4 == 0)
						{
							break;
						}
						num = 0;
						if (num != 0)
						{
							continue;
						}
					}
					else
					{
						num = 1;
					}
					num2 = _0005._0003._0001(_Ptr, _Ptr2, num);
					goto end_IL_003b;
				}
				continue;
				end_IL_003b:
				break;
			}
		}
		ErrorCode result;
		do
		{
			result = (ErrorCode)num2;
		}
		while (false);
		return result;
	}

	public ErrorCode ShapeSetClusterConstraintsForCommonCut(Shape shape, CommonCutClusterConstraint verticalCommonCut, CommonCutClusterConstraint horizontalCommonCut)
	{
		int num = _0005._0003._0001(this._0001.__Ptr, shape.__Ptr, verticalCommonCut, horizontalCommonCut);
		do
		{
			int num2 = num;
			num = num2;
		}
		while (5 == 0);
		ErrorCode result = (ErrorCode)num;
		if (0 == 0)
		{
		}
		return result;
	}

	public ErrorCode IsPartInCommonCut(Result result, Part part, out bool inCommonCut)
	{
		int num = default(int);
		int num2 = default(int);
		ErrorCode result2;
		do
		{
			if (2 == 0)
			{
				goto IL_0027;
			}
			num = 0;
			goto IL_0045;
			IL_0045:
			num2 = _0005._0003._0001(this._0001.__Ptr, result.__Ptr, part.__Ptr, out num);
			goto IL_0027;
			IL_0027:
			if (0 == 0)
			{
				inCommonCut = num != 0;
				if (0 == 0)
				{
					result2 = (ErrorCode)num2;
				}
				if (-1 == 0)
				{
					goto IL_0045;
				}
			}
		}
		while (8 == 0);
		return result2;
	}

	public ErrorCode SetSentinelDongleInfos(out byte vendor_code, int vendor_code_size, uint offset, uint feature_id)
	{
		return (ErrorCode)_0005._0003._0001(out vendor_code, vendor_code_size, offset, feature_id);
	}

	public ErrorCode GetDongleId(out uint dongle_id)
	{
		return (ErrorCode)_0005._0003._0001(out dongle_id);
	}

	public Sheet AddMetalSheet(double width, double length)
	{
		IntPtr ptr = _0005._0003._0001(this._0001.__Ptr, width, length);
		return Wrappable.Create(ptr, new Sheet());
	}

	public Result PricedNest(Sheet sheet, IEnumerable<Part> partList, IEnumerable<int> priceList, double time)
	{
		Result result2;
		do
		{
			IntPtr ptr = _0005._0003._0001(this._0001.__Ptr, sheet.__Ptr, _0001<Part>(partList), _0001<int>(priceList), partList.Count(), time);
			Result result = Wrappable.Create(ptr, new Result());
			result2 = result;
		}
		while (2 == 0);
		return result2;
	}

	public MultiResult MultiNest(IEnumerable<Sheet> sheetList, IEnumerable<int> sheetQuantityList, IEnumerable<Part> partList, double time)
	{
		MultiResult result;
		if (0 == 0)
		{
			IntPtr intPtr = this._0001.__Ptr;
			do
			{
				if (4u != 0)
				{
					intPtr = _0005._0003._0001(intPtr, _0001<Sheet>(sheetList), sheetList.Count(), _0001<int>(sheetQuantityList), _0001<Part>(partList), partList.Count(), time);
				}
			}
			while (5 == 0);
			if (true)
			{
				IntPtr intPtr2 = intPtr;
				intPtr = intPtr2;
			}
			MultiResult multiResult = Wrappable.Create(intPtr, new MultiResult());
			result = multiResult;
		}
		if (8u != 0)
		{
		}
		return result;
	}

	public ErrorCode GetMultiResultInfos(MultiResult multiResult, out int nbSheets)
	{
		int num2 = default(int);
		ErrorCode result = default(ErrorCode);
		while (4u != 0)
		{
			int num = _0005._0003._0001(this._0001.__Ptr, multiResult.__Ptr, out nbSheets);
			do
			{
				if (0 == 0)
				{
					if (0 == 0)
					{
						num2 = num;
					}
					num = num2;
				}
			}
			while (6 == 0);
			result = (ErrorCode)num;
			if (0 == 0)
			{
				break;
			}
		}
		return result;
	}

	public Result GetResult(MultiResult multiResult, int multiIndex, out Sheet sheet_result)
	{
		while (true)
		{
			IntPtr intPtr = IntPtr.Zero;
			IntPtr ptr;
			if (0 == 0)
			{
				ptr = intPtr;
				if (false)
				{
					continue;
				}
				intPtr = _0005._0003._0001(this._0001.__Ptr, multiResult.__Ptr, multiIndex, out ptr);
			}
			while (true)
			{
				if (0 == 0)
				{
					IntPtr intPtr2 = intPtr;
					if (4 == 0)
					{
						break;
					}
					intPtr = intPtr2;
				}
				if (0 == 0)
				{
					Result result = Wrappable.Create(intPtr, new Result());
					sheet_result = Wrappable.Create(ptr, new Sheet());
					return result;
				}
			}
		}
	}

	public ErrorCode DrawMultiSvg(MultiResult result, string file_name)
	{
		int num2 = default(int);
		ErrorCode result2 = default(ErrorCode);
		while (4u != 0)
		{
			int num = _0005._0003._0001(this._0001.__Ptr, result.__Ptr, file_name);
			do
			{
				if (0 == 0)
				{
					if (0 == 0)
					{
						num2 = num;
					}
					num = num2;
				}
			}
			while (6 == 0);
			result2 = (ErrorCode)num;
			if (0 == 0)
			{
				break;
			}
		}
		return result2;
	}

	public ErrorCode SetSessionMultiCallbacks(StopNesting fStop, IUserData stopData, MultiUpdateBest fUpdate, IUserData updateData)
	{
		if (3u != 0)
		{
		}
		this.m__0001 = fStop;
		this.m__0001 = fUpdate;
		_0005._0003._0001(this);
		IntPtr intPtr;
		if (uint.MaxValue != 0)
		{
			intPtr = _0005._0003._0001(stopData, this);
			goto IL_003c;
		}
		goto IL_004c;
		IL_004c:
		intPtr = this._0001.__Ptr;
		goto IL_0057;
		IL_0057:
		IntPtr intPtr2 = default(IntPtr);
		IntPtr intPtr3 = default(IntPtr);
		if (7u != 0)
		{
			return (ErrorCode)_0005._0003._0001(intPtr, (global::_0001._0003)_0001, intPtr2, (_0005._0001)_0002, intPtr3);
		}
		goto IL_003c;
		IL_003c:
		if (0 == 0)
		{
			if (0 == 0)
			{
				intPtr2 = intPtr;
				intPtr = _0005._0003._0001(updateData, this);
			}
			intPtr3 = intPtr;
			goto IL_004c;
		}
		goto IL_0057;
	}

	private void _0002(IntPtr P_0, IntPtr P_1, IntPtr P_2)
	{
		while (true)
		{
			if (uint.MaxValue != 0)
			{
				goto IL_0004;
			}
			goto IL_003a;
			IL_003a:
			MultiResult multiResult;
			while (true)
			{
				this.m__0001(_0005._0003._0001(P_0), multiResult);
				if (false)
				{
					break;
				}
				if (false)
				{
					continue;
				}
				return;
			}
			goto IL_0004;
			IL_0004:
			if (false)
			{
				continue;
			}
			multiResult = Wrappable.Create(P_2, new MultiResult());
			goto IL_003a;
		}
	}

	public bool IsSameNesting(Result r1, Result r2)
	{
		bool result = default(bool);
		while (true)
		{
			int num;
			if (6u != 0)
			{
				num = _0005._0003._0001(this._0001.__Ptr, r1.__Ptr, r2.__Ptr);
				goto IL_0022;
			}
			goto IL_002c;
			IL_0022:
			if (1 == 0)
			{
				break;
			}
			result = num != 0;
			goto IL_002c;
			IL_002c:
			if (8 == 0)
			{
				continue;
			}
			if (0 == 0)
			{
				break;
			}
			goto IL_0022;
		}
		return result;
	}

	public MultiResult PWSMultiNest(IEnumerable<Sheet> sheetList, IEnumerable<int> sheetQuantityList, IEnumerable<Part> partList, double time, string login, out string errorMessage)
	{
		StringBuilder stringBuilder = new StringBuilder(1024);
		MultiResult result;
		do
		{
			IntPtr ptr = _0005._0003._0001(this._0001.__Ptr, _0001<Sheet>(sheetList), sheetList.Count(), _0001<int>(sheetQuantityList), _0001<Part>(partList), partList.Count(), time, login, stringBuilder);
			errorMessage = stringBuilder.ToString();
			if (6u != 0)
			{
				MultiResult multiResult = Wrappable.Create(ptr, new MultiResult());
				result = multiResult;
			}
		}
		while (3 == 0);
		return result;
	}

	public MultiResult MultiPreNest(IEnumerable<Sheet> sheetList, IEnumerable<int> nbPartsOnSheetList, IEnumerable<Part> partList, IEnumerable<Orientation> orientationList, IEnumerable<Point> positionList)
	{
		MultiResult result;
		do
		{
			IntPtr ptr;
			if (4u != 0)
			{
				IntPtr intPtr = this._0001.__Ptr;
				do
				{
					if (4u != 0)
					{
						intPtr = _0005._0003._0001(intPtr, sheetList.Count(), _0001<Sheet>(sheetList), _0001<int>(nbPartsOnSheetList), _0001<Part>(partList), _0001<Orientation>(orientationList), _0001<Point>(positionList));
					}
				}
				while (3 == 0);
				ptr = intPtr;
			}
			MultiResult multiResult = Wrappable.Create(ptr, new MultiResult());
			result = multiResult;
		}
		while (4 == 0);
		return result;
	}

	public MultiResult MultiNestMore(MultiResult multiResult, IEnumerable<Sheet> sheetList, IEnumerable<int> sheetQuantityList, IEnumerable<Part> partList, double time)
	{
		IntPtr ptr = _0005._0003._0001(this._0001.__Ptr, multiResult.__Ptr, _0001<Sheet>(sheetList), sheetList.Count(), _0001<int>(sheetQuantityList), _0001<Part>(partList), partList.Count(), time);
		MultiResult multiResult2 = Wrappable.Create(ptr, new MultiResult());
		MultiResult result = multiResult2;
		if (0 == 0)
		{
		}
		return result;
	}

	public MultiResult CompleteMultiResultWithFillerParts(MultiResult multiResult, IEnumerable<Part> partList, double time)
	{
		IntPtr intPtr = this._0001.__Ptr;
		do
		{
			intPtr = _0005._0003._0001(intPtr, multiResult.__Ptr, _0001<Part>(partList), partList.Count(), time);
			if (0 == 0)
			{
				IntPtr intPtr2 = intPtr;
				intPtr = intPtr2;
			}
		}
		while (7 == 0);
		return Wrappable.Create(intPtr, new MultiResult());
	}

	public Result Spread(Result result, bool spreadUntilSheetLength, double time)
	{
		IntPtr intPtr = this._0001.__Ptr;
		do
		{
			IntPtr _Ptr = result.__Ptr;
			int num;
			while (true)
			{
				if (4u != 0)
				{
					num = (spreadUntilSheetLength ? 1 : 0);
					goto IL_0019;
				}
				goto IL_001b;
				IL_0019:
				if (num != 0)
				{
					if (0 == 0)
					{
						num = 1;
						break;
					}
					continue;
				}
				goto IL_001b;
				IL_001b:
				num = 0;
				if (num == 0)
				{
					break;
				}
				goto IL_0019;
			}
			intPtr = _0005._0003._0001(intPtr, _Ptr, num, time);
			if (0 == 0)
			{
				IntPtr intPtr2 = intPtr;
				intPtr = intPtr2;
			}
		}
		while (7 == 0);
		return Wrappable.Create(intPtr, new Result());
	}

	public Result SpreadIgnoreBorders(Result result, bool spreadUntilSheetLength, double time)
	{
		IntPtr intPtr = this._0001.__Ptr;
		do
		{
			IntPtr _Ptr = result.__Ptr;
			int num;
			while (true)
			{
				if (4u != 0)
				{
					num = (spreadUntilSheetLength ? 1 : 0);
					goto IL_0019;
				}
				goto IL_001b;
				IL_0019:
				if (num != 0)
				{
					if (0 == 0)
					{
						num = 1;
						break;
					}
					continue;
				}
				goto IL_001b;
				IL_001b:
				num = 0;
				if (num == 0)
				{
					break;
				}
				goto IL_0019;
			}
			intPtr = _0005._0003._0001(intPtr, _Ptr, num, time);
			if (0 == 0)
			{
				IntPtr intPtr2 = intPtr;
				intPtr = intPtr2;
			}
		}
		while (7 == 0);
		return Wrappable.Create(intPtr, new Result());
	}

	public Result Compact(Result result, DirectionType type2, double time)
	{
		Result result2;
		if (1 == 0)
		{
			return result2;
		}
		IntPtr ptr = _0005._0003._0001(this._0001.__Ptr, result.__Ptr, (int)type2, time);
		return Wrappable.Create(ptr, new Result());
	}

	public ErrorCode ShapeSetNestingWindows(Shape shape, IEnumerable<Sheet> sheetList, IEnumerable<Point> windowBottomLeftList, IEnumerable<Point> windowUpperRightList)
	{
		while (true)
		{
			int num;
			if (0 == 0)
			{
				num = _0005._0003._0001(this._0001.__Ptr, shape.__Ptr, _0001<Sheet>(sheetList), _0001<Point>(windowBottomLeftList), _0001<Point>(windowUpperRightList), sheetList.Count());
				goto IL_0037;
			}
			goto IL_0038;
			IL_0037:
			int num2 = num;
			goto IL_0038;
			IL_0038:
			num = num2;
			if (uint.MaxValue != 0)
			{
				ErrorCode result = (ErrorCode)num;
				while ((uint.MaxValue != 0) ? true : false)
				{
					if (0 == 0)
					{
						return result;
					}
				}
				continue;
			}
			goto IL_0037;
		}
	}

	public ErrorCode PartSetOrderGroup(Part part, int orderGroup)
	{
		int num2 = default(int);
		ErrorCode result = default(ErrorCode);
		while (4u != 0)
		{
			int num = _0005._0003._0001(this._0001.__Ptr, part.__Ptr, orderGroup);
			do
			{
				if (0 == 0)
				{
					if (0 == 0)
					{
						num2 = num;
					}
					num = num2;
				}
			}
			while (6 == 0);
			result = (ErrorCode)num;
			if (0 == 0)
			{
				break;
			}
		}
		return result;
	}

	public ErrorCode SetMaximumInterleavedGroups(int maximumInterleavedGroups)
	{
		while (0 == 0)
		{
			if (-1 == 0)
			{
				continue;
			}
			int num = _0005._0003._0001(this._0001.__Ptr, maximumInterleavedGroups);
			do
			{
				int num2;
				if (7u != 0)
				{
					num2 = num;
				}
				num = num2;
			}
			while (7 == 0 || 8 == 0);
			return (ErrorCode)num;
		}
		ErrorCode result;
		return result;
	}

	public MultiResult ConcatenateResults(IEnumerable<Result> resultList)
	{
		IntPtr ptr = _0005._0003._0001(this._0001.__Ptr, _0001<Result>(resultList), resultList.Count());
		return Wrappable.Create(ptr, new MultiResult());
	}

	public ErrorCode AssociatePartToSheets(Part part, IEnumerable<Sheet> sheetList)
	{
		if (false)
		{
			int result;
			return (ErrorCode)result;
		}
		return (ErrorCode)_0005._0003._0001(this._0001.__Ptr, part.__Ptr, _0001<Sheet>(sheetList), sheetList.Count());
	}

	public ErrorCode SetCuttingHeadsNumber(int headsNumber)
	{
		while (0 == 0)
		{
			if (-1 == 0)
			{
				continue;
			}
			int num = _0005._0003._0001(this._0001.__Ptr, headsNumber);
			do
			{
				int num2;
				if (7u != 0)
				{
					num2 = num;
				}
				num = num2;
			}
			while (7 == 0 || 8 == 0);
			return (ErrorCode)num;
		}
		ErrorCode result;
		return result;
	}

	public ErrorCode SetCuttingHeadsMinimumGap(double minimum_gap)
	{
		while (0 == 0)
		{
			if (-1 == 0)
			{
				continue;
			}
			int num = _0005._0003._0001(this._0001.__Ptr, minimum_gap);
			do
			{
				int num2;
				if (7u != 0)
				{
					num2 = num;
				}
				num = num2;
			}
			while (7 == 0 || 8 == 0);
			return (ErrorCode)num;
		}
		ErrorCode result;
		return result;
	}

	public ErrorCode SetAdditionnalHeadCuttingUnitCost(double cost)
	{
		while (0 == 0)
		{
			if (-1 == 0)
			{
				continue;
			}
			int num = _0005._0003._0001(this._0001.__Ptr, cost);
			do
			{
				int num2;
				if (7u != 0)
				{
					num2 = num;
				}
				num = num2;
			}
			while (7 == 0 || 8 == 0);
			return (ErrorCode)num;
		}
		ErrorCode result;
		return result;
	}

	public ErrorCode GetPartMultipleHeadsNumber(Result result, Part part, out int headsNumber)
	{
		if (uint.MaxValue != 0 && 8u != 0)
		{
			int result2;
			if (true)
			{
				if (7 == 0)
				{
					goto IL_0052;
				}
				result2 = _0005._0003._0001(this._0001.__Ptr, result.__Ptr, part.__Ptr, out headsNumber);
			}
			return (ErrorCode)result2;
		}
		goto IL_0052;
		IL_0052:
		ErrorCode result3 = default(ErrorCode);
		return result3;
	}

	public ErrorCode GetPartMultipleHeadsLinkedPart(Result result, Part part, int index, out Part linkedPart)
	{
		ErrorCode result2 = default(ErrorCode);
		int num = default(int);
		while (true)
		{
			if (4 == 0)
			{
				goto IL_0044;
			}
			IntPtr intPtr = IntPtr.Zero;
			IntPtr ptr;
			while (true)
			{
				if (0 == 0)
				{
					ptr = intPtr;
				}
				if (-1 == 0)
				{
					break;
				}
				intPtr = this._0001.__Ptr;
				if (6 == 0)
				{
					continue;
				}
				goto IL_0056;
			}
			goto IL_0048;
			IL_0044:
			result2 = (ErrorCode)num;
			goto IL_0048;
			IL_0048:
			while (true)
			{
				if (false)
				{
					continue;
				}
				return result2;
			}
			continue;
			IL_0056:
			num = _0005._0003._0001(intPtr, result.__Ptr, part.__Ptr, index, out ptr);
			linkedPart = Wrappable.Create(ptr, new Part());
			goto IL_0044;
		}
	}

	public ErrorCode SetMaterialUnitCost(double cost)
	{
		while (0 == 0)
		{
			if (-1 == 0)
			{
				continue;
			}
			int num = _0005._0003._0001(this._0001.__Ptr, cost);
			do
			{
				int num2;
				if (7u != 0)
				{
					num2 = num;
				}
				num = num2;
			}
			while (7 == 0 || 8 == 0);
			return (ErrorCode)num;
		}
		ErrorCode result;
		return result;
	}

	public ErrorCode SetCuttingUnitCost(double cost)
	{
		while (0 == 0)
		{
			if (-1 == 0)
			{
				continue;
			}
			int num = _0005._0003._0001(this._0001.__Ptr, cost);
			do
			{
				int num2;
				if (7u != 0)
				{
					num2 = num;
				}
				num = num2;
			}
			while (7 == 0 || 8 == 0);
			return (ErrorCode)num;
		}
		ErrorCode result;
		return result;
	}

	public ErrorCode EnableLayeredCutting(int layers_max_number)
	{
		while (0 == 0)
		{
			if (-1 == 0)
			{
				continue;
			}
			int num = _0005._0003._0001(this._0001.__Ptr, layers_max_number);
			do
			{
				int num2;
				if (7u != 0)
				{
					num2 = num;
				}
				num = num2;
			}
			while (7 == 0 || 8 == 0);
			return (ErrorCode)num;
		}
		ErrorCode result;
		return result;
	}

	public ErrorCode SetSheetLayoutCost(double cost)
	{
		while (0 == 0)
		{
			if (-1 == 0)
			{
				continue;
			}
			int num = _0005._0003._0001(this._0001.__Ptr, cost);
			do
			{
				int num2;
				if (7u != 0)
				{
					num2 = num;
				}
				num = num2;
			}
			while (7 == 0 || 8 == 0);
			return (ErrorCode)num;
		}
		ErrorCode result;
		return result;
	}

	public ErrorCode SetSessionOffcutSides(Side offcut_side, Side second_offcut_side)
	{
		ErrorCode result = default(ErrorCode);
		while (true)
		{
			int num2;
			if (5u != 0)
			{
				if (false)
				{
					continue;
				}
				int num = _0005._0003._0001(this._0001.__Ptr, offcut_side, second_offcut_side);
				if (4u != 0)
				{
					num2 = num;
				}
				goto IL_001d;
			}
			goto IL_0028;
			IL_001d:
			if (0 == 0)
			{
				int num3 = num2;
				if (5u != 0)
				{
					result = (ErrorCode)num3;
				}
			}
			goto IL_0028;
			IL_0028:
			if (5u != 0)
			{
				break;
			}
			goto IL_001d;
		}
		return result;
	}
}
