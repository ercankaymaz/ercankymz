using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Poly2Tri.Triangulation;
using Poly2Tri.Triangulation.Delaunay;
using Poly2Tri.Triangulation.Delaunay.Sweep;
using Poly2Tri.Triangulation.Polygon;
using Poly2Tri.Triangulation.Sets;
using Poly2Tri.Triangulation.Util;
using Poly2Tri.Utility;
using buClass;
using buCore;
using buCore.buClipperLib;
using buPop3.Common.Logging;
using buPop3.Mime;
using buPop3.Mime.Decode;
using buPop3.Mime.Header;
using buPop3.Pop3;
using buPop3.Pop3.Exceptions;
using ns47;
using ns48;
using ns49;
using ns50;
using ns53;
using ns55;
using ns56;
using ns57;

namespace ns54;

internal class Class156
{
	static List<byte[]> smethod_0(string string_0, byte[] byte_0)
	{
		if (byte_0 != null)
		{
			List<byte[]> list = new List<byte[]>();
			using (MemoryStream memoryStream = new MemoryStream(byte_0))
			{
				bool bool_;
				int num = smethod_296((Stream)memoryStream, string_0, out bool_) + ("--" + string_0 + "\r\n").Length;
				while (!bool_)
				{
					int num2 = smethod_296((Stream)memoryStream, string_0, out bool_) - "\r\n".Length;
					if (num2 <= -1)
					{
						num2 = (int)memoryStream.Length - "\r\n".Length;
						bool_ = true;
						if (num >= num2)
						{
							break;
						}
					}
					int num3 = num2 - num;
					byte[] array = new byte[num3];
					Array.Copy(byte_0, num, array, 0, num3);
					list.Add(array);
					num = num2 + ("\r\n--" + string_0 + "\r\n").Length;
				}
			}
			return list;
		}
		throw new ArgumentNullException("rawBody");
	}

	static void smethod_1(IntPoint intPoint_0, Class148 class148_0, Class148 class148_1, buClipper buClipper_0)
	{
		smethod_246(buClipper_0, class148_0, intPoint_0);
		if (class148_1.int_0 == 0)
		{
			smethod_246(buClipper_0, class148_1, intPoint_0);
		}
		if (class148_0.int_3 != class148_1.int_3)
		{
			if (class148_0.int_3 >= class148_1.int_3)
			{
				smethod_89(buClipper_0, class148_1, class148_0);
			}
			else
			{
				smethod_89(buClipper_0, class148_0, class148_1);
			}
		}
		else
		{
			class148_0.int_3 = -1;
			class148_1.int_3 = -1;
		}
	}

	static void smethod_2(buClipper buClipper_0, Class152 class152_0)
	{
		Class153 @class = class152_0.class153_0;
		Class153 class153_ = @class.class153_1;
		while (@class != class153_)
		{
			@class = @class.class153_0;
			if (@class.intPoint_0 == @class.class153_1.intPoint_0)
			{
				if (@class == class153_)
				{
					class153_ = @class.class153_1;
				}
				Class153 class153_2 = @class.class153_1;
				class153_2.class153_0 = @class.class153_0;
				@class.class153_0.class153_1 = class153_2;
				@class = class153_2;
			}
		}
		if (@class == @class.class153_1)
		{
			class152_0.class153_0 = null;
		}
	}

	static int smethod_3(byte[] byte_0)
	{
		if (byte_0 != null)
		{
			using (Stream stream = new MemoryStream(byte_0))
			{
				string value;
				do
				{
					value = smethod_106(stream);
				}
				while (!string.IsNullOrEmpty(value));
				return (int)stream.Position;
			}
		}
		throw new ArgumentNullException("messageContent");
	}

	static bool smethod_4(PolyNode polyNode_0)
	{
		bool flag = true;
		for (PolyNode polyNode_1 = polyNode_0.polyNode_0; polyNode_1 != null; polyNode_1 = polyNode_1.polyNode_0)
		{
			flag = !flag;
		}
		return flag;
	}

	static bool smethod_5(double double_0, SplitComplexPolygonNode splitComplexPolygonNode_0, double double_1, double double_2, double double_3)
	{
		if (!(double_1 < 0.0))
		{
			if (double_0 >= 0.0 && !(double_2 <= double_3))
			{
				return true;
			}
			return false;
		}
		if (double_0 <= 0.0 && !(double_2 <= double_3))
		{
			return false;
		}
		return true;
	}

	static int smethod_6(Class160.Class162 class162_0)
	{
		return class162_0.int_1 - class162_0.int_0 + (class162_0.int_2 >> 3);
	}

	static void smethod_7(Class152 class152_0, buClipper buClipper_0)
	{
		Class153 @class = class152_0.class153_0;
		do
		{
			@class.int_0 = class152_0.int_0;
			@class = @class.class153_1;
		}
		while (@class != class152_0.class153_0);
	}

	static void smethod_8(buClipperBase buClipperBase_0, ref Class148 class148_0)
	{
		if (class148_0.class148_2 != null)
		{
			Class148 class148_1 = class148_0.class148_4;
			Class148 class148_2 = class148_0.class148_3;
			class148_0.class148_2.int_3 = class148_0.int_3;
			if (class148_1 == null)
			{
				buClipperBase_0.class148_0 = class148_0.class148_2;
			}
			else
			{
				class148_1.class148_3 = class148_0.class148_2;
			}
			if (class148_2 != null)
			{
				class148_2.class148_4 = class148_0.class148_2;
			}
			class148_0.class148_2.enum11_0 = class148_0.enum11_0;
			class148_0.class148_2.int_0 = class148_0.int_0;
			class148_0.class148_2.int_1 = class148_0.int_1;
			class148_0.class148_2.int_2 = class148_0.int_2;
			class148_0 = class148_0.class148_2;
			class148_0.intPoint_1 = class148_0.intPoint_0;
			class148_0.class148_4 = class148_1;
			class148_0.class148_3 = class148_2;
			if (!smethod_67(class148_0))
			{
				smethod_232(buClipperBase_0, class148_0.intPoint_2.Y);
			}
			return;
		}
		throw new Exception0("UpdateEdgeIntoAEL: invalid call");
	}

	static bool smethod_9(Class148 class148_0, double double_0, buClipper buClipper_0)
	{
		return (double)class148_0.intPoint_2.Y == double_0 && class148_0.class148_2 != null;
	}

	static string smethod_10(string string_0)
	{
		if (string_0 != null)
		{
			if (string_0.Length <= 1 || string_0[0] != '"' || string_0[string_0.Length - 1] != '"')
			{
				return string_0;
			}
			return string_0.Substring(1, string_0.Length - 2);
		}
		throw new ArgumentNullException("text");
	}

	static void smethod_11(buClipper buClipper_0, Class148 class148_0)
	{
		if (buClipper_0.class148_1 != null)
		{
			class148_0.class148_5 = buClipper_0.class148_1;
			class148_0.class148_6 = null;
			buClipper_0.class148_1.class148_6 = class148_0;
			buClipper_0.class148_1 = class148_0;
		}
		else
		{
			buClipper_0.class148_1 = class148_0;
			class148_0.class148_6 = null;
			class148_0.class148_5 = null;
		}
	}

	static void smethod_12(buClipperBase buClipperBase_0, Class148 class148_0)
	{
		Class148 class148_1 = class148_0.class148_4;
		Class148 class148_2 = class148_0.class148_3;
		if (class148_1 != null || class148_2 != null || class148_0 == buClipperBase_0.class148_0)
		{
			if (class148_1 == null)
			{
				buClipperBase_0.class148_0 = class148_2;
			}
			else
			{
				class148_1.class148_3 = class148_2;
			}
			if (class148_2 != null)
			{
				class148_2.class148_4 = class148_1;
			}
			class148_0.class148_3 = null;
			class148_0.class148_4 = null;
		}
	}

	static void smethod_13(int int_0, double double_0, ClipperOffset clipperOffset_0, int int_1)
	{
		double num = clipperOffset_0.double_0 / double_0;
		clipperOffset_0.list_2.Add(new IntPoint(smethod_150((double)clipperOffset_0.list_1[int_1].X + (clipperOffset_0.list_3[int_0].X + clipperOffset_0.list_3[int_1].X) * num), smethod_150((double)clipperOffset_0.list_1[int_1].Y + (clipperOffset_0.list_3[int_0].Y + clipperOffset_0.list_3[int_1].Y) * num)));
	}

	static Dictionary<string, string> smethod_14(string string_0)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		string input = string_0;
		if (string_0.Contains(";"))
		{
			input = string_0.Substring(0, string_0.LastIndexOf(";"));
		}
		input = Regex.Replace(input, "\\s+", " ");
		MatchCollection matchCollection = Regex.Matches(input, "(?<name>[^\\s]+)\\s(?<value>[^\\s]+(\\s\\(.+?\\))*)");
		foreach (Match item in matchCollection)
		{
			string value = item.Groups["name"].Value;
			string value2 = item.Groups["value"].Value;
			if (!value.StartsWith("(") && !dictionary.ContainsKey(value))
			{
				dictionary.Add(value, value2);
			}
		}
		return dictionary;
	}

	static void smethod_15(IntPoint intPoint_0, ref bool bool_0, buClipperBase buClipperBase_0)
	{
		if (!bool_0)
		{
			if (intPoint_0.X > 1073741823L || intPoint_0.Y > 1073741823L || -intPoint_0.X > 1073741823L || -intPoint_0.Y > 1073741823L)
			{
				bool_0 = true;
				smethod_15(intPoint_0, ref bool_0, buClipperBase_0);
			}
		}
		else if (intPoint_0.X > 4611686018427387903L || intPoint_0.Y > 4611686018427387903L || -intPoint_0.X > 4611686018427387903L || -intPoint_0.Y > 4611686018427387903L)
		{
			throw new Exception0("Coordinate outside allowed range");
		}
	}

	static IEnumerable<Point2DList> smethod_16(IEnumerable<Point2D> ienumerable_0)
	{
		List<Point2DList> list = new List<Point2DList>();
		Point2DList point2DList = new Point2DList();
		point2DList.AddRange(ienumerable_0);
		list.Add(point2DList);
		int i = 0;
		for (int num = list.Count; i < num; i++)
		{
			int num2 = list[i].Count;
			for (int j = 0; j < num2; j++)
			{
				for (int k = j + 1; k < num2; k++)
				{
					if (list[i][j].Equals(list[i][k], point2DList.Epsilon))
					{
						int num3 = k - j;
						Point2DList point2DList2 = new Point2DList();
						for (int l = j + 1; l <= k; l++)
						{
							point2DList2.Add(list[i][l]);
						}
						list[i].RemoveRange(j + 1, num3);
						list.Add(point2DList2);
						num++;
						num2 -= num3;
						k = j + 1;
					}
				}
			}
			list[i].Simplify();
		}
		return list;
	}

	static bool smethod_17(buClipperBase buClipperBase_0)
	{
		return buClipperBase_0.class149_1 != null;
	}

	static void smethod_18(Stream stream_0, byte[] byte_0)
	{
		stream_0.Write(byte_0, 0, byte_0.Length);
	}

	static bool smethod_19(Class148 class148_0, Class148 class148_1, buClipper buClipper_0)
	{
		if (class148_1.intPoint_1.X != class148_0.intPoint_1.X)
		{
			return class148_1.intPoint_1.X < class148_0.intPoint_1.X;
		}
		if (class148_1.intPoint_2.Y <= class148_0.intPoint_2.Y)
		{
			return class148_0.intPoint_2.X > smethod_101(class148_1, class148_0.intPoint_2.Y);
		}
		return class148_1.intPoint_2.X < smethod_101(class148_0, class148_1.intPoint_2.Y);
	}

	static void smethod_20(ref double double_0, Pnt3D pnt3D_0, ref Pnt3D pnt3D_1, [Out] Pnt3D pnt3D_2, [Out] Pnt3D pnt3D_3, buVector buVector_0)
	{
		double num = (pnt3D_2.X + pnt3D_0.X) / 2.0;
		double num2 = (pnt3D_2.Y + pnt3D_0.Y) / 2.0;
		double num3 = pnt3D_2.X - pnt3D_0.X;
		double num4 = 0.0 - (pnt3D_2.Y - pnt3D_0.Y);
		double num5 = (pnt3D_3.X + pnt3D_2.X) / 2.0;
		double num6 = (pnt3D_3.Y + pnt3D_2.Y) / 2.0;
		double num7 = pnt3D_3.X - pnt3D_2.X;
		double num8 = 0.0 - (pnt3D_3.Y - pnt3D_2.Y);
		bool IsLineIntersect = false;
		bool IsIntersecPointInsideLines = false;
		Pnt3D IntersectionPoint = new Pnt3D();
		buVector_0.LineLineIntersection(new Pnt3D(num, num2), new Pnt3D(num + num4, num2 + num3), new Pnt3D(num5, num6), new Pnt3D(num5 + num8, num6 + num7), new WorkPlane(), ref IntersectionPoint, ref IsLineIntersect, ref IsIntersecPointInsideLines);
		if (IsLineIntersect)
		{
			pnt3D_1 = IntersectionPoint;
			double num9 = pnt3D_1.X - pnt3D_0.X;
			double num10 = pnt3D_1.Y - pnt3D_0.Y;
			double_0 = Math.Sqrt(num9 * num9 + num10 * num10);
		}
		else
		{
			pnt3D_1 = new Pnt3D(0.0, 0.0);
			double_0 = 0.0;
		}
	}

	static void smethod_21(int int_0)
	{
		if (int_0 <= 0)
		{
			throw new InvalidUseException("The messageNumber argument cannot have a value of zero or less. Valid messageNumber is in the range [1, messageCount]");
		}
	}

	static void smethod_22(IntPoint intPoint_0, Class153 class153_0, Class153 class153_1, buClipper buClipper_0)
	{
		Class154 @class = new Class154();
		@class.class153_0 = class153_1;
		@class.class153_1 = class153_0;
		@class.intPoint_0 = intPoint_0;
		buClipper_0.list_3.Add(@class);
	}

	static bool smethod_23(IntPoint intPoint_0, IntPoint intPoint_1, IntPoint intPoint_2, double double_0)
	{
		if (Math.Abs(intPoint_0.X - intPoint_1.X) <= Math.Abs(intPoint_0.Y - intPoint_1.Y))
		{
			if (intPoint_0.Y > intPoint_1.Y != intPoint_0.Y < intPoint_2.Y)
			{
				if (intPoint_1.Y > intPoint_0.Y != intPoint_1.Y < intPoint_2.Y)
				{
					return smethod_143(intPoint_2, intPoint_0, intPoint_1) < double_0;
				}
				return smethod_143(intPoint_1, intPoint_0, intPoint_2) < double_0;
			}
			return smethod_143(intPoint_0, intPoint_1, intPoint_2) < double_0;
		}
		if (intPoint_0.X > intPoint_1.X != intPoint_0.X < intPoint_2.X)
		{
			if (intPoint_1.X > intPoint_0.X != intPoint_1.X < intPoint_2.X)
			{
				return smethod_143(intPoint_2, intPoint_0, intPoint_1) < double_0;
			}
			return smethod_143(intPoint_1, intPoint_0, intPoint_2) < double_0;
		}
		return smethod_143(intPoint_0, intPoint_1, intPoint_2) < double_0;
	}

	static void smethod_24(DTSweepContext dtsweepContext_0)
	{
		DelaunayTriangle delaunayTriangle = dtsweepContext_0.Front.Head.Next.Triangle;
		TriangulationPoint point = dtsweepContext_0.Front.Head.Next.Point;
		while (!delaunayTriangle.GetConstrainedEdgeCW(point))
		{
			DelaunayTriangle delaunayTriangle2 = delaunayTriangle.NeighborCCWFrom(point);
			if (delaunayTriangle2 == null)
			{
				break;
			}
			delaunayTriangle = delaunayTriangle2;
		}
		dtsweepContext_0.MeshClean(delaunayTriangle);
	}

	static void smethod_25(buClipper buClipper_0)
	{
		for (Class148 @class = (buClipper_0.class148_1 = buClipper_0.class148_0); @class != null; @class = @class.class148_3)
		{
			@class.class148_6 = @class.class148_4;
			@class.class148_5 = @class.class148_3;
		}
	}

	static string smethod_26(string string_0)
	{
		int num = string_0.Length - 1;
		int i;
		for (i = 0; i <= num && string_0[num - i] != ' ' && !smethod_288(string_0[num - i]); i++)
		{
		}
		return string_0.Substring(string_0.Length - i).ToUpperInvariant();
	}

	static int smethod_27(Class160.Stream3 stream3_0)
	{
		return stream3_0.ReadByte() | (stream3_0.ReadByte() << 8);
	}

	static MailPriority smethod_28(string string_0)
	{
		if (string_0 != null)
		{
			switch (string_0.ToUpperInvariant())
			{
			case "5":
			case "HIGH":
				return MailPriority.High;
			case "3":
			case "NORMAL":
				return MailPriority.Normal;
			case "1":
			case "LOW":
				return MailPriority.Low;
			default:
				DefaultLogger.Log.LogDebug("HeaderFieldParser: Unknown importance value: \"" + string_0 + "\". Using default of normal importance.");
				return MailPriority.Normal;
			}
		}
		throw new ArgumentNullException("headerValue");
	}

	static Class160.Class164 smethod_29(Class160.Class165 class165_0)
	{
		byte[] array = new byte[class165_0.int_3];
		Array.Copy(class165_0.byte_1, 0, array, 0, class165_0.int_3);
		return new Class160.Class164(array);
	}

	static string smethod_30(string string_0, Encoding encoding_0)
	{
		if (string_0 != null)
		{
			if (encoding_0 == null)
			{
				throw new ArgumentNullException("encoding");
			}
			return encoding_0.GetString(smethod_87(string_0));
		}
		throw new ArgumentNullException("base64Encoded");
	}

	static void smethod_31(TriangulationConstraint triangulationConstraint_0, AdvancingFrontNode advancingFrontNode_0, DTSweepContext dtsweepContext_0)
	{
		while (advancingFrontNode_0.Next.Point.X < triangulationConstraint_0.P.X)
		{
			if (dtsweepContext_0.IsDebugEnabled)
			{
				dtsweepContext_0.DebugContext.ActiveNode = advancingFrontNode_0;
			}
			Orientation orientation = TriangulationUtil.Orient2d(triangulationConstraint_0.Q, advancingFrontNode_0.Next.Point, triangulationConstraint_0.P);
			if (orientation != Orientation.AntiClockwise)
			{
				advancingFrontNode_0 = advancingFrontNode_0.Next;
			}
			else
			{
				smethod_271(advancingFrontNode_0, dtsweepContext_0, triangulationConstraint_0);
			}
		}
	}

	static bool smethod_32(IntPoint intPoint_0, IntPoint intPoint_1, buClipperBase buClipperBase_0, IntPoint intPoint_2)
	{
		if (!(intPoint_0 == intPoint_2) && !(intPoint_0 == intPoint_1) && !(intPoint_2 == intPoint_1))
		{
			if (intPoint_0.X == intPoint_2.X)
			{
				return intPoint_1.Y > intPoint_0.Y == intPoint_1.Y < intPoint_2.Y;
			}
			return intPoint_1.X > intPoint_0.X == intPoint_1.X < intPoint_2.X;
		}
		return false;
	}

	static void smethod_33(Class160.Class163 class163_0, int int_0, int int_1)
	{
		if ((class163_0.int_1 += int_0) <= 32768)
		{
			int num = (class163_0.int_0 - int_1) & 0x7FFF;
			int num2 = 32768 - int_0;
			if (num > num2 || class163_0.int_0 >= num2)
			{
				smethod_80(class163_0, num, int_0);
			}
			else if (int_0 > int_1)
			{
				while (int_0-- > 0)
				{
					class163_0.byte_0[class163_0.int_0++] = class163_0.byte_0[num++];
				}
			}
			else
			{
				Array.Copy(class163_0.byte_0, num, class163_0.byte_0, class163_0.int_0, int_0);
				class163_0.int_0 += int_0;
			}
			return;
		}
		throw new InvalidOperationException();
	}

	static bool smethod_34(buClipper buClipper_0, Class152 class152_0, Class152 class152_1)
	{
		while (true)
		{
			class152_0 = class152_0.class152_0;
			if (class152_0 != class152_1)
			{
				if (class152_0 == null)
				{
					return false;
				}
				continue;
			}
			break;
		}
		return true;
	}

	static void smethod_35(buClipper buClipper_0, Class148 class148_0, Class148 class148_1)
	{
		if ((class148_0.class148_5 == null && class148_0.class148_6 == null) || (class148_1.class148_5 == null && class148_1.class148_6 == null))
		{
			return;
		}
		if (class148_0.class148_5 != class148_1)
		{
			if (class148_1.class148_5 != class148_0)
			{
				Class148 class148_2 = class148_0.class148_5;
				Class148 class148_3 = class148_0.class148_6;
				class148_0.class148_5 = class148_1.class148_5;
				if (class148_0.class148_5 != null)
				{
					class148_0.class148_5.class148_6 = class148_0;
				}
				class148_0.class148_6 = class148_1.class148_6;
				if (class148_0.class148_6 != null)
				{
					class148_0.class148_6.class148_5 = class148_0;
				}
				class148_1.class148_5 = class148_2;
				if (class148_1.class148_5 != null)
				{
					class148_1.class148_5.class148_6 = class148_1;
				}
				class148_1.class148_6 = class148_3;
				if (class148_1.class148_6 != null)
				{
					class148_1.class148_6.class148_5 = class148_1;
				}
			}
			else
			{
				Class148 class148_4 = class148_0.class148_5;
				if (class148_4 != null)
				{
					class148_4.class148_6 = class148_1;
				}
				Class148 class148_5 = class148_1.class148_6;
				if (class148_5 != null)
				{
					class148_5.class148_5 = class148_0;
				}
				class148_0.class148_6 = class148_5;
				class148_0.class148_5 = class148_1;
				class148_1.class148_6 = class148_0;
				class148_1.class148_5 = class148_4;
			}
		}
		else
		{
			Class148 class148_6 = class148_1.class148_5;
			if (class148_6 != null)
			{
				class148_6.class148_6 = class148_0;
			}
			Class148 class148_7 = class148_0.class148_6;
			if (class148_7 != null)
			{
				class148_7.class148_5 = class148_1;
			}
			class148_1.class148_6 = class148_7;
			class148_1.class148_5 = class148_0;
			class148_0.class148_6 = class148_1;
			class148_0.class148_5 = class148_6;
		}
		if (class148_0.class148_6 != null)
		{
			if (class148_1.class148_6 == null)
			{
				buClipper_0.class148_1 = class148_1;
			}
		}
		else
		{
			buClipper_0.class148_1 = class148_0;
		}
	}

	static void smethod_36(DelaunayTriangle delaunayTriangle_0)
	{
		ref FixedArray3<DelaunayTriangle> neighbors = ref delaunayTriangle_0.Neighbors;
		ref FixedArray3<DelaunayTriangle> neighbors2 = ref delaunayTriangle_0.Neighbors;
		DelaunayTriangle delaunayTriangle = (delaunayTriangle_0.Neighbors[2] = null);
		DelaunayTriangle value = (neighbors2[1] = delaunayTriangle);
		neighbors[0] = value;
	}

	static string smethod_37(Match match_0)
	{
		if (match_0.Success)
		{
			string value = match_0.Value;
			string text = value;
			uint num = smethod_119(text);
			if (num > 3356228888u)
			{
				if (num > 3524005078u)
				{
					if (num > 3591115554u)
					{
						if (num > 3691781268u)
						{
							if (num == 3708558887u)
							{
								if (text == "X")
								{
									return "-1100";
								}
							}
							else if (num == 3742114125u)
							{
								if (text == "Z")
								{
									goto IL_00b2;
								}
							}
							else if (num == 4249934023u && text == "EST")
							{
								return "-0500";
							}
						}
						else if (num == 3607893173u)
						{
							if (text == "R")
							{
								return "-0500";
							}
						}
						else if (num == 3691781268u && text == "Y")
						{
							return "-1200";
						}
					}
					else if (num > 3557560316u)
					{
						if (num == 3574337935u)
						{
							if (text == "P")
							{
								return "-0300";
							}
						}
						else if (num == 3591115554u && text == "S")
						{
							return "-0600";
						}
					}
					else if (num == 3540782697u)
					{
						if (text == "V")
						{
							return "-0900";
						}
					}
					else if (num == 3557560316u && text == "Q")
					{
						return "-0400";
					}
				}
				else if (num > 3423339364u)
				{
					if (num > 3456894602u)
					{
						if (num == 3490449840u)
						{
							if (text == "U")
							{
								return "-0800";
							}
						}
						else if (num == 3507227459u)
						{
							if (text == "T")
							{
								return "-0700";
							}
						}
						else if (num == 3524005078u && text == "W")
						{
							return "-1000";
						}
					}
					else if (num == 3440116983u)
					{
						if (text == "H")
						{
							return "+0800";
						}
					}
					else if (num == 3456894602u && text == "K")
					{
						return "+1000";
					}
				}
				else if (num > 3389784126u)
				{
					if (num == 3406561745u)
					{
						if (text == "N")
						{
							return "-0100";
						}
					}
					else if (num == 3423339364u && text == "I")
					{
						return "+0900";
					}
				}
				else if (num == 3373006507u)
				{
					if (text == "L")
					{
						return "+1100";
					}
				}
				else if (num == 3389784126u && text == "O")
				{
					return "-0200";
				}
			}
			else if (num > 3140198408u)
			{
				if (num > 3272340793u)
				{
					if (num > 3322673650u)
					{
						if (num == 3338310079u)
						{
							if (text == "GMT")
							{
								goto IL_00b2;
							}
						}
						else if (num == 3339451269u)
						{
							if (text == "B")
							{
								return "+0200";
							}
						}
						else if (num == 3356228888u && text == "M")
						{
							return "+1200";
						}
					}
					else if (num == 3289118412u)
					{
						if (text == "A")
						{
							return "+0100";
						}
					}
					else if (num == 3322673650u && text == "C")
					{
						return "+0300";
					}
				}
				else if (num > 3238785555u)
				{
					if (num == 3255563174u)
					{
						if (text == "G")
						{
							return "+0700";
						}
					}
					else if (num == 3272340793u && text == "F")
					{
						return "+0600";
					}
				}
				else if (num == 3222007936u)
				{
					if (text == "E")
					{
						return "+0500";
					}
				}
				else if (num == 3238785555u && text == "D")
				{
					return "+0400";
				}
			}
			else if (num > 1727238636)
			{
				if (num > 2586683136u)
				{
					if (num == 2617531423u)
					{
						if (text == "PDT")
						{
							return "-0700";
						}
					}
					else if (num == 3140198408u && text == "EDT")
					{
						return "-0400";
					}
				}
				else if (num == 2099357029)
				{
					if (text == "CST")
					{
						return "-0600";
					}
				}
				else if (num == 2586683136u && text == "PST")
				{
					return "-0800";
				}
			}
			else if (num > 339145631)
			{
				if (num == 995535842)
				{
					if (text == "CDT")
					{
						return "-0500";
					}
				}
				else if (num == 1727238636 && text == "UT")
				{
					goto IL_00b2;
				}
			}
			else
			{
				switch (num)
				{
				case 308297344u:
					if (text == "MDT")
					{
						return "-0600";
					}
					break;
				case 339145631u:
					if (text == "MST")
					{
						return "-0700";
					}
					break;
				}
			}
			throw new ArgumentException("Unexpected input");
		}
		throw new ArgumentException("Match success are always true");
		IL_00b2:
		return "+0000";
	}

	static void smethod_38(ref List<eEntities> list_0, ref eLine eLine_0, buFile.Cf2 cf2_0, string[] string_0)
	{
		Pnt3D pnt3D = new Pnt3D();
		Pnt3D pnt3D2 = new Pnt3D();
		Pnt3D StartPoint = new Pnt3D();
		Pnt3D EndPoint = new Pnt3D();
		Pnt3D pnt3D3 = new Pnt3D();
		int num = 0;
		Cf2FileProperties cf2FileProperties = new Cf2FileProperties();
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double ruleHeight = 0.0;
		double num6 = 0.0;
		if (buNumeric.IsNumeric(string_0[1]))
		{
			num6 = double.Parse(string_0[1]);
		}
		if (buNumeric.IsNumeric(string_0[2]))
		{
			num5 = double.Parse(string_0[2]);
		}
		if (buNumeric.IsNumeric(string_0[3]))
		{
			ruleHeight = double.Parse(string_0[3]);
		}
		bool flag = false;
		for (int i = 0; i <= cf2_0.FileDefinations.Count - 1; i++)
		{
			if ((cf2_0.FileDefinations[i].Cf2CodeMatchType == num5) & (cf2_0.FileDefinations[i].PtIndex == num6))
			{
				cf2FileProperties = new Cf2FileProperties(cf2_0.FileDefinations[i]);
				if (cf2FileProperties.LayerIndex < 0)
				{
					cf2FileProperties.LayerIndex = i;
				}
				flag = true;
			}
		}
		pnt3D = new Pnt3D(double.Parse(string_0[4], buSystem.CI), double.Parse(string_0[5], buSystem.CI));
		pnt3D2 = new Pnt3D(double.Parse(string_0[6], buSystem.CI), double.Parse(string_0[7], buSystem.CI));
		eLine_0 = new eLine(pnt3D, pnt3D2);
		eLine_0.Diemaker = new DiemakerData();
		eLine_0.Diemaker.Pt = cf2FileProperties.PtRealValue;
		eLine_0.Diemaker.RuleHeight = ruleHeight;
		eLine_0.Diemaker.DiemakerType = cf2FileProperties.CodeType;
		eLine_0.Diemaker.DiemakerTYpeAsInteger = Convert.ToInt32(num5);
		eLine_0.dispColor = cf2FileProperties.Color;
		eLine_0.dispThickness = (float)cf2FileProperties.Thickness;
		if (!flag)
		{
			eLine_0.Diemaker.Pt = num6;
		}
		if (cf2FileProperties.LayerIndex >= 0)
		{
			eLine_0.LayerIndex = cf2FileProperties.LayerIndex;
		}
		if ((cf2_0.Layers.Count > 0) & (cf2FileProperties.LayerIndex >= 0) & (cf2FileProperties.LayerIndex <= cf2_0.Layers.Count - 1))
		{
			eLine_0.LayerIndex = cf2FileProperties.LayerIndex;
		}
		num = int.Parse(string_0[8], buSystem.CI);
		num2 = double.Parse(string_0[9], buSystem.CI);
		List<Pnt3D> Vertices = new List<Pnt3D>();
		if (!((num > 0) & (num2 >= cf2_0.BridgeMinLimit) & (num2 <= cf2_0.BridgeMaxLimit)))
		{
			return;
		}
		num3 = buAppCalc.cVector.Length3D(pnt3D, pnt3D2) / (double)num;
		buAppCalc.cVector.LineerToLineer(pnt3D, pnt3D2, num3, ref Vertices);
		num4 = buAppCalc.cVector.PointAngle(pnt3D2, pnt3D);
		for (int j = 1; j <= Vertices.Count - 1; j++)
		{
			pnt3D3 = buAppCalc.cVector.MiddlePointOfLine(Vertices[j - 1], Vertices[j]);
			buAppCalc.cVector.LineWithCenterPointByLengthAndAngle(pnt3D3, num2 / 2.0, num4, new WorkPlane(), ref StartPoint, ref EndPoint);
			eLine eLine2 = new eLine(StartPoint, EndPoint);
			eLine2.Diemaker = new DiemakerData();
			eLine2.Diemaker.IsBridge = true;
			eLine2.Diemaker.Pt = cf2FileProperties.PtRealValue;
			eLine2.Diemaker.DiemakerType = cf2FileProperties.CodeType;
			eLine2.Diemaker.DiemakerTYpeAsInteger = Convert.ToInt32(DiemakerType.Bridge);
			if (cf2FileProperties.CodeType == DiemakerType.None)
			{
				eLine2.Diemaker.Pt = num6;
			}
			if (cf2_0.FoundBridgeProperties.LayerIndex >= 0)
			{
				eLine2.LayerIndex = cf2_0.FoundBridgeProperties.LayerIndex;
			}
			list_0.Add(eLine2);
		}
	}

	static string smethod_39(string string_0, string string_1, string string_2)
	{
		if (string_1 != null)
		{
			if (string_2 != null)
			{
				if (string_0 == null)
				{
					throw new ArgumentNullException("challenge");
				}
				byte[] byte_ = smethod_86(string_2);
				byte[] byte_2 = Convert.FromBase64String(string_0);
				byte[] byte_3 = smethod_208(Class131.byte_1, byte_);
				byte[] byte_4 = smethod_208(Class131.byte_0, byte_);
				byte[] array = smethod_59(smethod_122(byte_3, smethod_59(smethod_122(byte_4, byte_2))));
				string text = BitConverter.ToString(array).Replace("-", "").ToLowerInvariant();
				return Convert.ToBase64String(Encoding.ASCII.GetBytes(string_1 + " " + text));
			}
			throw new ArgumentNullException("password");
		}
		throw new ArgumentNullException("username");
	}

	static double[,] smethod_40(FIP fip_0, double[,] double_0)
	{
		double[,] array = new double[double_0.GetLength(0), double_0.GetLength(1)];
		for (int i = 0; i < double_0.GetLength(0); i++)
		{
			for (int j = 0; j < double_0.GetLength(1); j++)
			{
				array[i, j] = Math.Pow(-1.0, i + j) * double_0[i, j];
			}
		}
		return array;
	}

	static void smethod_41(TriangulationPoint triangulationPoint_0, DTSweepContext dtsweepContext_0, TriangulationPoint triangulationPoint_1, TriangulationPoint triangulationPoint_2, DelaunayTriangle delaunayTriangle_0)
	{
		DelaunayTriangle delaunayTriangle = delaunayTriangle_0.NeighborAcrossFrom(triangulationPoint_0);
		TriangulationPoint triangulationPoint = delaunayTriangle.OppositePoint(delaunayTriangle_0, triangulationPoint_0);
		if (delaunayTriangle != null)
		{
			if (dtsweepContext_0.IsDebugEnabled)
			{
				dtsweepContext_0.DebugContext.PrimaryTriangle = delaunayTriangle_0;
				dtsweepContext_0.DebugContext.SecondaryTriangle = delaunayTriangle;
			}
			if (!TriangulationUtil.InScanArea(triangulationPoint_0, delaunayTriangle_0.PointCCWFrom(triangulationPoint_0), delaunayTriangle_0.PointCWFrom(triangulationPoint_0), triangulationPoint))
			{
				TriangulationPoint triangulationPoint_3 = default(TriangulationPoint);
				if (smethod_156(ref triangulationPoint_3, (Point2D)triangulationPoint_1, delaunayTriangle, triangulationPoint, (Point2D)triangulationPoint_2))
				{
					smethod_289(delaunayTriangle, (Point2D)triangulationPoint_1, dtsweepContext_0, triangulationPoint_3, delaunayTriangle_0, triangulationPoint_2);
					smethod_49(triangulationPoint_1, triangulationPoint_0, dtsweepContext_0, delaunayTriangle_0, triangulationPoint_2);
				}
				return;
			}
			smethod_65(triangulationPoint, delaunayTriangle, delaunayTriangle_0, triangulationPoint_0);
			dtsweepContext_0.MapTriangleToNodes(delaunayTriangle_0);
			dtsweepContext_0.MapTriangleToNodes(delaunayTriangle);
			if (!triangulationPoint_0.Equals(triangulationPoint_2) || !triangulationPoint.Equals(triangulationPoint_1))
			{
				if (dtsweepContext_0.IsDebugEnabled)
				{
					Console.WriteLine("[FLIP] - flipping and continuing with triangle still crossing edge");
				}
				Orientation orientation_ = TriangulationUtil.Orient2d(triangulationPoint_2, triangulationPoint, triangulationPoint_1);
				delaunayTriangle_0 = smethod_73(triangulationPoint, orientation_, dtsweepContext_0, delaunayTriangle_0, delaunayTriangle, triangulationPoint_0);
				smethod_41(triangulationPoint_0, dtsweepContext_0, triangulationPoint_1, triangulationPoint_2, delaunayTriangle_0);
				return;
			}
			if (!triangulationPoint_2.Equals(dtsweepContext_0.EdgeEvent.ConstrainedEdge.Q) || !triangulationPoint_1.Equals(dtsweepContext_0.EdgeEvent.ConstrainedEdge.P))
			{
				if (dtsweepContext_0.IsDebugEnabled)
				{
					Console.WriteLine("[FLIP] - subedge done");
				}
				return;
			}
			if (dtsweepContext_0.IsDebugEnabled)
			{
				Console.WriteLine("[FLIP] - constrained edge done");
			}
			delaunayTriangle_0.MarkConstrainedEdge(triangulationPoint_1, triangulationPoint_2);
			delaunayTriangle.MarkConstrainedEdge(triangulationPoint_1, triangulationPoint_2);
			smethod_226(dtsweepContext_0, delaunayTriangle_0);
			smethod_226(dtsweepContext_0, delaunayTriangle);
			return;
		}
		throw new InvalidOperationException("[BUG:FIXME] FLIP failed due to missing triangle");
	}

	static bool smethod_42(buClipper buClipper_0)
	{
		buClipper_0.list_2.Sort(buClipper_0.icomparer_0);
		smethod_25(buClipper_0);
		int count = buClipper_0.list_2.Count;
		for (int i = 0; i < count; i++)
		{
			if (!smethod_85(buClipper_0, buClipper_0.list_2[i]))
			{
				int j;
				for (j = i + 1; j < count && !smethod_85(buClipper_0, buClipper_0.list_2[j]); j++)
				{
				}
				if (j == count)
				{
					return false;
				}
				IntersectNode value = buClipper_0.list_2[i];
				buClipper_0.list_2[i] = buClipper_0.list_2[j];
				buClipper_0.list_2[j] = value;
			}
			smethod_35(buClipper_0, buClipper_0.list_2[i].class148_0, buClipper_0.list_2[i].class148_1);
		}
		return true;
	}

	static bool smethod_43(int int_0, ref Color color_0, ref double double_0, buFile.Dxf dxf_0, ref double double_1, ref double double_2, ref string string_0, ref double double_3, ref double double_4, ref double double_5)
	{
		bool flag = true;
		bool result = false;
		int num = 0;
		for (int i = int_0; i <= dxf_0.list_0.Count - 1; i++)
		{
			if (num < 80)
			{
				_ = dxf_0.list_0[i];
				num++;
				if (flag & (dxf_0.list_0[i] == "AcDbEntity"))
				{
					string_0 = dxf_0.list_0[i + 2];
				}
				if (flag & (dxf_0.list_0[i] == "  8"))
				{
					string_0 = dxf_0.list_0[i + 1];
				}
				if (flag & (dxf_0.list_0[i] == " 62"))
				{
					int num2 = Convert.ToInt32(dxf_0.list_0[i + 1]);
					if (num2 >= dxf_0.ColorCode.Length)
					{
						color_0 = Color.Black;
					}
					else
					{
						color_0 = dxf_0.ColorCode[num2];
					}
					if ((color_0.A == 0) & (color_0.R == 0) & (color_0.G == 0) & (color_0.B == 0))
					{
						color_0 = Color.Black;
					}
				}
				if (dxf_0.list_0[i] == "10")
				{
					double_4 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
				}
				if (dxf_0.list_0[i] == "20")
				{
					double_2 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
				}
				if (dxf_0.list_0[i] == "30")
				{
					double_5 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
				}
				if (dxf_0.list_0[i] == "11")
				{
					double_1 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
				}
				if (dxf_0.list_0[i] == "21")
				{
					double_3 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
					if (dxf_0.list_0[i + 2] != "31")
					{
						result = true;
						break;
					}
				}
				if (dxf_0.list_0[i] == "31")
				{
					double_0 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
					result = false;
					break;
				}
				continue;
			}
			result = false;
			break;
		}
		return result;
	}

	static void smethod_44(string string_0, MessageHeader messageHeader_0, string string_1)
	{
		if (string_1 != null)
		{
			if (string_0 != null)
			{
				string text = string_1.ToUpperInvariant();
				string text2 = text;
				switch (smethod_119(text2))
				{
				case 3747899112u:
					if (text2 == "CONTENT-ID")
					{
						messageHeader_0.ContentId = smethod_76(string_0);
						return;
					}
					break;
				case 1418384879u:
					if (text2 == "SUBJECT")
					{
						messageHeader_0.Subject = smethod_179(string_0);
						return;
					}
					break;
				case 905391459u:
					if (text2 == "REPLY-TO")
					{
						messageHeader_0.ReplyTo = smethod_267(string_0);
						return;
					}
					break;
				case 569730020u:
					if (text2 == "TO")
					{
						messageHeader_0.To = smethod_96(string_0);
						return;
					}
					break;
				case 633019157u:
					if (text2 == "KEYWORDS")
					{
						string[] array = string_0.Split(',');
						string[] array2 = array;
						foreach (string text3 in array2)
						{
							messageHeader_0.Keywords.Add(smethod_10(text3.Trim()));
						}
						return;
					}
					break;
				case 963715476u:
					if (text2 == "CONTENT-TRANSFER-ENCODING")
					{
						messageHeader_0.ContentTransferEncoding = smethod_198(string_0.Trim());
						return;
					}
					break;
				case 1349348241u:
					if (text2 == "CONTENT-DESCRIPTION")
					{
						messageHeader_0.ContentDescription = smethod_179(string_0.Trim());
						return;
					}
					break;
				case 1396931398u:
					if (text2 == "MESSAGE-ID")
					{
						messageHeader_0.MessageId = smethod_76(string_0);
						return;
					}
					break;
				case 1411505060u:
					if (text2 == "SENDER")
					{
						messageHeader_0.Sender = smethod_267(string_0);
						return;
					}
					break;
				case 1415727179u:
					if (text2 == "REFERENCES")
					{
						messageHeader_0.References = smethod_295(string_0);
						return;
					}
					break;
				case 1509690621u:
					if (text2 == "RETURN-PATH")
					{
						messageHeader_0.ReturnPath = smethod_267(string_0);
						return;
					}
					break;
				case 1977225635u:
					if (text2 == "CC")
					{
						messageHeader_0.Cc = smethod_96(string_0);
						return;
					}
					break;
				case 2478748789u:
					if (text2 == "FROM")
					{
						messageHeader_0.From = smethod_267(string_0);
						return;
					}
					break;
				case 2438262959u:
					if (text2 == "IMPORTANCE")
					{
						messageHeader_0.Importance = smethod_28(string_0.Trim());
						return;
					}
					break;
				case 2462664700u:
					if (text2 == "MIME-VERSION")
					{
						messageHeader_0.MimeVersion = string_0.Trim();
						return;
					}
					break;
				case 3027495439u:
					if (text2 == "IN-REPLY-TO")
					{
						messageHeader_0.InReplyTo = smethod_295(string_0);
						return;
					}
					break;
				case 3093786662u:
					if (text2 == "DISPOSITION-NOTIFICATION-TO")
					{
						messageHeader_0.DispositionNotificationTo = smethod_96(string_0);
						return;
					}
					break;
				case 3098799004u:
					if (text2 == "CONTENT-DISPOSITION")
					{
						messageHeader_0.ContentDisposition = Class137.smethod_1(string_0);
						return;
					}
					break;
				case 3221746841u:
					if (text2 == "DATE")
					{
						messageHeader_0.Date = string_0.Trim();
						messageHeader_0.DateSent = smethod_236(string_0);
						return;
					}
					break;
				case 3357413298u:
					if (text2 == "RECEIVED")
					{
						messageHeader_0.Received.Add(new Received(string_0.Trim()));
						return;
					}
					break;
				case 3945365109u:
					if (text2 == "CONTENT-TYPE")
					{
						messageHeader_0.ContentType = Class137.smethod_0(string_0);
						return;
					}
					break;
				case 4101178211u:
					if (text2 == "BCC")
					{
						messageHeader_0.Bcc = smethod_96(string_0);
						return;
					}
					break;
				}
				messageHeader_0.UnknownHeaders.Add(string_1, string_0);
				return;
			}
			throw new ArgumentNullException("headerValue");
		}
		throw new ArgumentNullException("headerName");
	}

	static void smethod_45(Class148 class148_0, Class148 class148_1, buClipperBase buClipperBase_0)
	{
		if (class148_1.class148_3 == class148_1.class148_4 || class148_0.class148_3 == class148_0.class148_4)
		{
			return;
		}
		if (class148_1.class148_3 != class148_0)
		{
			if (class148_0.class148_3 != class148_1)
			{
				Class148 class148_2 = class148_1.class148_3;
				Class148 class148_3 = class148_1.class148_4;
				class148_1.class148_3 = class148_0.class148_3;
				if (class148_1.class148_3 != null)
				{
					class148_1.class148_3.class148_4 = class148_1;
				}
				class148_1.class148_4 = class148_0.class148_4;
				if (class148_1.class148_4 != null)
				{
					class148_1.class148_4.class148_3 = class148_1;
				}
				class148_0.class148_3 = class148_2;
				if (class148_0.class148_3 != null)
				{
					class148_0.class148_3.class148_4 = class148_0;
				}
				class148_0.class148_4 = class148_3;
				if (class148_0.class148_4 != null)
				{
					class148_0.class148_4.class148_3 = class148_0;
				}
			}
			else
			{
				Class148 class148_4 = class148_1.class148_3;
				if (class148_4 != null)
				{
					class148_4.class148_4 = class148_0;
				}
				Class148 class148_5 = class148_0.class148_4;
				if (class148_5 != null)
				{
					class148_5.class148_3 = class148_1;
				}
				class148_1.class148_4 = class148_5;
				class148_1.class148_3 = class148_0;
				class148_0.class148_4 = class148_1;
				class148_0.class148_3 = class148_4;
			}
		}
		else
		{
			Class148 class148_6 = class148_0.class148_3;
			if (class148_6 != null)
			{
				class148_6.class148_4 = class148_1;
			}
			Class148 class148_7 = class148_1.class148_4;
			if (class148_7 != null)
			{
				class148_7.class148_3 = class148_0;
			}
			class148_0.class148_4 = class148_7;
			class148_0.class148_3 = class148_1;
			class148_1.class148_4 = class148_0;
			class148_1.class148_3 = class148_6;
		}
		if (class148_1.class148_4 != null)
		{
			if (class148_0.class148_4 == null)
			{
				buClipperBase_0.class148_0 = class148_0;
			}
		}
		else
		{
			buClipperBase_0.class148_0 = class148_1;
		}
	}

	static int smethod_46(byte[] byte_0, int int_0, Class160.Class161 class161_0, int int_1)
	{
		int num = 0;
		while (true)
		{
			if (class161_0.int_4 != 11)
			{
				int num2 = smethod_153(int_0, byte_0, int_1, class161_0.class163_0);
				int_1 += num2;
				num += num2;
				int_0 -= num2;
				if (int_0 == 0)
				{
					break;
				}
			}
			if (!smethod_138(class161_0) && (class161_0.class163_0.int_1 <= 0 || class161_0.int_4 == 11))
			{
				return num;
			}
		}
		return num;
	}

	static void smethod_47(Class148 class148_0, buClipper buClipper_0, Class148 class148_1)
	{
		if (buClipper_0.class148_0 != null)
		{
			if (class148_0 != null || !smethod_19(buClipper_0.class148_0, class148_1, buClipper_0))
			{
				if (class148_0 == null)
				{
					class148_0 = buClipper_0.class148_0;
				}
				while (class148_0.class148_3 != null && !smethod_19(class148_0.class148_3, class148_1, buClipper_0))
				{
					class148_0 = class148_0.class148_3;
				}
				class148_1.class148_3 = class148_0.class148_3;
				if (class148_0.class148_3 != null)
				{
					class148_0.class148_3.class148_4 = class148_1;
				}
				class148_1.class148_4 = class148_0;
				class148_0.class148_3 = class148_1;
			}
			else
			{
				class148_1.class148_4 = null;
				class148_1.class148_3 = buClipper_0.class148_0;
				buClipper_0.class148_0.class148_4 = class148_1;
				buClipper_0.class148_0 = class148_1;
			}
		}
		else
		{
			class148_1.class148_4 = null;
			class148_1.class148_3 = null;
			buClipper_0.class148_0 = class148_1;
		}
	}

	static void smethod_48(Class148 class148_0, buClipperBase buClipperBase_0, Class148 class148_1, Class148 class148_2, IntPoint intPoint_0)
	{
		class148_0.class148_0 = class148_1;
		class148_0.class148_1 = class148_2;
		class148_0.intPoint_1 = intPoint_0;
		class148_0.int_3 = -1;
	}

	static void smethod_49(TriangulationPoint triangulationPoint_0, TriangulationPoint triangulationPoint_1, DTSweepContext dtsweepContext_0, DelaunayTriangle delaunayTriangle_0, TriangulationPoint triangulationPoint_2)
	{
		if (dtsweepContext_0.IsDebugEnabled)
		{
			dtsweepContext_0.DebugContext.PrimaryTriangle = delaunayTriangle_0;
		}
		if (smethod_181(delaunayTriangle_0, triangulationPoint_0, triangulationPoint_2))
		{
			return;
		}
		TriangulationPoint triangulationPoint = delaunayTriangle_0.PointCCWFrom(triangulationPoint_1);
		Orientation orientation = TriangulationUtil.Orient2d(triangulationPoint_2, triangulationPoint, triangulationPoint_0);
		if (orientation != Orientation.Collinear)
		{
			TriangulationPoint triangulationPoint2 = delaunayTriangle_0.PointCWFrom(triangulationPoint_1);
			Orientation orientation2 = TriangulationUtil.Orient2d(triangulationPoint_2, triangulationPoint2, triangulationPoint_0);
			if (orientation2 != Orientation.Collinear)
			{
				if (orientation != orientation2)
				{
					smethod_41(triangulationPoint_1, dtsweepContext_0, triangulationPoint_0, triangulationPoint_2, delaunayTriangle_0);
					return;
				}
				delaunayTriangle_0 = ((orientation != Orientation.Clockwise) ? delaunayTriangle_0.NeighborCWFrom(triangulationPoint_1) : delaunayTriangle_0.NeighborCCWFrom(triangulationPoint_1));
				smethod_49(triangulationPoint_0, triangulationPoint_1, dtsweepContext_0, delaunayTriangle_0, triangulationPoint_2);
				return;
			}
			if (!delaunayTriangle_0.Contains(triangulationPoint_2) || !delaunayTriangle_0.Contains(triangulationPoint2))
			{
				throw new PointOnEdgeException("EdgeEvent - Point on constrained edge not supported yet", triangulationPoint_0, triangulationPoint_2, triangulationPoint2);
			}
			delaunayTriangle_0.MarkConstrainedEdge(triangulationPoint_2, triangulationPoint2);
			dtsweepContext_0.EdgeEvent.ConstrainedEdge.Q = triangulationPoint2;
			delaunayTriangle_0 = delaunayTriangle_0.NeighborAcrossFrom(triangulationPoint_1);
			if (delaunayTriangle_0 != null)
			{
				smethod_49(triangulationPoint_0, triangulationPoint2, dtsweepContext_0, delaunayTriangle_0, triangulationPoint2);
			}
			if (dtsweepContext_0.IsDebugEnabled)
			{
				Console.WriteLine("EdgeEvent - Point on constrained edge");
			}
		}
		else
		{
			if (!delaunayTriangle_0.Contains(triangulationPoint_2) || !delaunayTriangle_0.Contains(triangulationPoint))
			{
				throw new PointOnEdgeException("EdgeEvent - Point on constrained edge not supported yet", triangulationPoint_0, triangulationPoint_2, triangulationPoint);
			}
			delaunayTriangle_0.MarkConstrainedEdge(triangulationPoint_2, triangulationPoint);
			dtsweepContext_0.EdgeEvent.ConstrainedEdge.Q = triangulationPoint;
			delaunayTriangle_0 = delaunayTriangle_0.NeighborAcrossFrom(triangulationPoint_1);
			smethod_49(triangulationPoint_0, triangulationPoint, dtsweepContext_0, delaunayTriangle_0, triangulationPoint);
			if (dtsweepContext_0.IsDebugEnabled)
			{
				Console.WriteLine("EdgeEvent - Point on constrained edge");
			}
		}
	}

	static int smethod_50(buFile.PLYToSchematic.Enum10 enum10_0)
	{
		return enum10_0 switch
		{
			buFile.PLYToSchematic.Enum10.const_18 => 8, 
			buFile.PLYToSchematic.Enum10.const_1 => 1, 
			buFile.PLYToSchematic.Enum10.const_2 => 1, 
			buFile.PLYToSchematic.Enum10.const_3 => 1, 
			buFile.PLYToSchematic.Enum10.const_4 => 1, 
			buFile.PLYToSchematic.Enum10.const_5 => 2, 
			buFile.PLYToSchematic.Enum10.const_6 => 2, 
			buFile.PLYToSchematic.Enum10.const_7 => 2, 
			buFile.PLYToSchematic.Enum10.const_8 => 2, 
			buFile.PLYToSchematic.Enum10.const_9 => 4, 
			buFile.PLYToSchematic.Enum10.const_10 => 4, 
			buFile.PLYToSchematic.Enum10.const_11 => 4, 
			buFile.PLYToSchematic.Enum10.const_12 => 8, 
			buFile.PLYToSchematic.Enum10.const_13 => 8, 
			buFile.PLYToSchematic.Enum10.const_14 => 8, 
			buFile.PLYToSchematic.Enum10.const_15 => 1, 
			buFile.PLYToSchematic.Enum10.const_16 => 2, 
			buFile.PLYToSchematic.Enum10.const_17 => 4, 
			_ => 0, 
		};
	}

	static void smethod_51(DTSweepContext dtsweepContext_0, AdvancingFrontNode advancingFrontNode_0)
	{
		DelaunayTriangle delaunayTriangle = new DelaunayTriangle(advancingFrontNode_0.Prev.Point, advancingFrontNode_0.Point, advancingFrontNode_0.Next.Point);
		delaunayTriangle.MarkNeighbor(advancingFrontNode_0.Prev.Triangle);
		delaunayTriangle.MarkNeighbor(advancingFrontNode_0.Triangle);
		dtsweepContext_0.Triangles.Add(delaunayTriangle);
		advancingFrontNode_0.Prev.Next = advancingFrontNode_0.Next;
		advancingFrontNode_0.Next.Prev = advancingFrontNode_0.Prev;
		if (!smethod_226(dtsweepContext_0, delaunayTriangle))
		{
			dtsweepContext_0.MapTriangleToNodes(delaunayTriangle);
		}
	}

	static DateTime smethod_52(string string_0)
	{
		if (string_0 != null)
		{
			Match match = Regex.Match(string_0, "(\\d\\d? .+ (\\d\\d\\d\\d|\\d\\d) \\d?\\d:\\d?\\d(:\\d?\\d)?)|((\\d\\d\\d\\d|\\d\\d)-\\d?\\d-\\d?\\d \\d?\\d:\\d?\\d(:\\d?\\d)?)|(\\d\\d?-[A-Za-z]{3}-(\\d\\d\\d\\d|\\d\\d) \\d?\\d:\\d?\\d(:\\d?\\d)?)");
			if (!match.Success)
			{
				DefaultLogger.Log.LogError("The given date does not appear to be in a valid format: " + string_0);
				return DateTime.MinValue;
			}
			return Convert.ToDateTime(match.Value, CultureInfo.InvariantCulture);
		}
		throw new ArgumentNullException("dateInput");
	}

	static bool smethod_53(buFile.Dxf dxf_0, double double_0, double double_1, double double_2, double double_3)
	{
		double num = Math.Abs(double_0 - double_1);
		double num2 = Math.Abs(double_2 - double_3);
		if (!((num < dxf_0.double_2) & (num2 < dxf_0.double_2)))
		{
			return false;
		}
		return true;
	}

	static bool smethod_54([Out] buClipperBase buClipperBase_0, ref long long_0)
	{
		if (buClipperBase_0.class150_0 != null)
		{
			long_0 = buClipperBase_0.class150_0.long_0;
			buClipperBase_0.class150_0 = buClipperBase_0.class150_0.class150_0;
			return true;
		}
		long_0 = 0L;
		return false;
	}

	static double[,] smethod_55(Bitmap bitmap_0, FIP fip_0)
	{
		double[,] array = new double[bitmap_0.Width, bitmap_0.Height];
		for (int i = 0; i < bitmap_0.Width; i++)
		{
			for (int j = 0; j < bitmap_0.Height; j++)
			{
				array[i, j] = Math.Pow(-1.0, i + j) * Convert.ToDouble(bitmap_0.GetPixel(i, j).R);
			}
		}
		return array;
	}

	static void smethod_56(ref double double_0, ref string string_0, ref double double_1, ref double double_2, int int_0, ref string string_1, ref double double_3, ref double double_4, buFile.Dxf dxf_0, ref double double_5, ref Color color_0)
	{
		bool flag = true;
		bool flag2 = false;
		for (int i = int_0; i <= dxf_0.list_0.Count - 1; i++)
		{
			if (flag & (dxf_0.list_0[i] == "AcDbEntity"))
			{
				string_0 = dxf_0.list_0[i + 2];
			}
			if (flag & (dxf_0.list_0[i] == "  8"))
			{
				string_0 = dxf_0.list_0[i + 1];
			}
			if (flag & (dxf_0.list_0[i] == "CONTINUOUS"))
			{
				flag2 = true;
			}
			flag2 = true;
			if (flag & (dxf_0.list_0[i] == "  2"))
			{
				string_1 = dxf_0.list_0[i + 1];
			}
			if (flag & (dxf_0.list_0[i] == " 62"))
			{
				int num = Convert.ToInt32(dxf_0.list_0[i + 1]);
				if (num >= dxf_0.ColorCode.Length)
				{
					color_0 = Color.Black;
				}
				else
				{
					color_0 = dxf_0.ColorCode[num];
				}
				if ((color_0.A == 0) & (color_0.R == 0) & (color_0.G == 0) & (color_0.B == 0))
				{
					color_0 = Color.Black;
				}
			}
			if (flag2 & (dxf_0.list_0[i] == " 10"))
			{
				double_1 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
			}
			if (flag2 & (dxf_0.list_0[i] == " 20"))
			{
				double_4 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
			}
			if (flag2 & (dxf_0.list_0[i] == " 30"))
			{
				double_3 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
			}
			if (flag2 & (dxf_0.list_0[i] == " 41"))
			{
				double_2 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
			}
			if (flag2 & (dxf_0.list_0[i] == " 42"))
			{
				double_0 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
			}
			if (!(flag2 & (dxf_0.list_0[i] == " 50")))
			{
				if (dxf_0.list_0[i] == "  0" || dxf_0.list_0[i] == "ENDSEC")
				{
					break;
				}
				continue;
			}
			double_5 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
			break;
		}
	}

	static double smethod_57(AdvancingFrontNode advancingFrontNode_0)
	{
		double x = advancingFrontNode_0.Point.X;
		double y = advancingFrontNode_0.Point.Y;
		double num = advancingFrontNode_0.Next.Point.X - x;
		double num2 = advancingFrontNode_0.Next.Point.Y - y;
		double num3 = advancingFrontNode_0.Prev.Point.X - x;
		double num4 = advancingFrontNode_0.Prev.Point.Y - y;
		return Math.Atan2(num * num4 - num2 * num3, num * num3 + num2 * num4);
	}

	static void smethod_58(Point2D point2D_0, double double_0)
	{
		point2D_0.X *= double_0;
		point2D_0.Y *= double_0;
	}

	static byte[] smethod_59(byte[] byte_0)
	{
		if (byte_0 != null)
		{
			using (MD5 mD = new MD5CryptoServiceProvider())
			{
				return mD.ComputeHash(byte_0);
			}
		}
		throw new ArgumentNullException("toHash");
	}

	static void smethod_60(buClipper buClipper_0)
	{
		for (int i = 0; i < buClipper_0.list_3.Count; i++)
		{
			Class154 @class = buClipper_0.list_3[i];
			Class152 class2 = smethod_272(buClipper_0, @class.class153_0.int_0);
			Class152 class3 = smethod_272(buClipper_0, @class.class153_1.int_0);
			if (class2.class153_0 == null || class3.class153_0 == null || class2.bool_1 || class3.bool_1)
			{
				continue;
			}
			Class152 class4 = ((class2 == class3) ? class2 : (smethod_34(buClipper_0, class2, class3) ? class3 : (smethod_34(buClipper_0, class3, class2) ? class2 : smethod_126(buClipper_0, class2, class3))));
			if (!smethod_293(buClipper_0, @class, class2, class3))
			{
				continue;
			}
			if (class2 != class3)
			{
				class3.class153_0 = null;
				class3.class153_1 = null;
				class3.int_0 = class2.int_0;
				class2.bool_0 = class4.bool_0;
				if (class4 == class3)
				{
					class2.class152_0 = class3.class152_0;
				}
				class3.class152_0 = class2;
				if (buClipper_0.bool_4)
				{
					buClipper_0.method_3(class3, class2);
				}
				continue;
			}
			class2.class153_0 = @class.class153_0;
			class2.class153_1 = null;
			class3 = smethod_185((buClipperBase)buClipper_0);
			class3.class153_0 = @class.class153_1;
			smethod_7(class3, buClipper_0);
			if (!smethod_167(class3.class153_0, class2.class153_0))
			{
				if (!smethod_167(class2.class153_0, class3.class153_0))
				{
					class3.bool_0 = class2.bool_0;
					class3.class152_0 = class2.class152_0;
					if (buClipper_0.bool_4)
					{
						buClipper_0.method_1(class2, class3);
					}
					continue;
				}
				class3.bool_0 = class2.bool_0;
				class2.bool_0 = !class3.bool_0;
				class3.class152_0 = class2.class152_0;
				class2.class152_0 = class3;
				if (buClipper_0.bool_4)
				{
					buClipper_0.method_2(class2, class3);
				}
				if ((class2.bool_0 ^ buClipper_0.ReverseSolution) == smethod_142(buClipper_0, class2) > 0.0)
				{
					smethod_242(class2.class153_0, buClipper_0);
				}
			}
			else
			{
				class3.bool_0 = !class2.bool_0;
				class3.class152_0 = class2;
				if (buClipper_0.bool_4)
				{
					buClipper_0.method_2(class3, class2);
				}
				if ((class3.bool_0 ^ buClipper_0.ReverseSolution) == smethod_142(buClipper_0, class3) > 0.0)
				{
					smethod_242(class3.class153_0, buClipper_0);
				}
			}
		}
	}

	static void smethod_61(Pop3Client pop3Client_0)
	{
		try
		{
			pop3Client_0.method_0().Close();
		}
		finally
		{
			smethod_279(pop3Client_0);
		}
	}

	static void smethod_62(Pop3Client pop3Client_0, string string_0)
	{
		if (string_0 != null)
		{
			Match match = Regex.Match(string_0, "<.+>");
			if (match.Success)
			{
				pop3Client_0.method_5(match.Value);
				pop3Client_0.ApopSupported = true;
			}
			return;
		}
		throw new ArgumentNullException("response");
	}

	static void smethod_63(ref bool bool_0, buFile.Ply ply_0, ref int int_0, ref int int_1, StreamReader streamReader_0)
	{
		int num = 0;
		string text = streamReader_0.ReadLine();
		num = 0 + (text.Length + 1);
		if (!(text != "ply"))
		{
			text = streamReader_0.ReadLine();
			num += text.Length + 1;
			if (text.IndexOf("binary") >= 0)
			{
				bool_0 = true;
			}
			bool flag = false;
			while (true)
			{
				text = streamReader_0.ReadLine();
				num += text.Length + 1;
				if (text == "end_header")
				{
					break;
				}
				string[] array = text.Split();
				if (array[0] == "element")
				{
					if (!(array[1] == "vertex"))
					{
						flag = true;
					}
					else
					{
						int_0 = Convert.ToInt32(array[2]);
						flag = false;
					}
				}
				if (array[0] == "element")
				{
					if (!(array[1] == "face"))
					{
						flag = true;
					}
					else
					{
						int_1 = Convert.ToInt32(array[2]);
						flag = false;
					}
				}
				if (!flag)
				{
				}
			}
			streamReader_0.BaseStream.Position = num;
			return;
		}
		throw new ArgumentException("Magic number ('ply') mismatch.");
	}

	static void smethod_64(string string_0, int int_0)
	{
		try
		{
			lock (Class158.object_0)
			{
				Class158.dictionary_0.Add(int_0, string_0);
			}
		}
		catch
		{
		}
	}

	static void smethod_65(TriangulationPoint triangulationPoint_0, DelaunayTriangle delaunayTriangle_0, DelaunayTriangle delaunayTriangle_1, TriangulationPoint triangulationPoint_1)
	{
		DelaunayTriangle delaunayTriangle = delaunayTriangle_1.NeighborCCWFrom(triangulationPoint_1);
		DelaunayTriangle delaunayTriangle2 = delaunayTriangle_1.NeighborCWFrom(triangulationPoint_1);
		DelaunayTriangle delaunayTriangle3 = delaunayTriangle_0.NeighborCCWFrom(triangulationPoint_0);
		DelaunayTriangle delaunayTriangle4 = delaunayTriangle_0.NeighborCWFrom(triangulationPoint_0);
		bool constrainedEdgeCCW = delaunayTriangle_1.GetConstrainedEdgeCCW(triangulationPoint_1);
		bool constrainedEdgeCW = delaunayTriangle_1.GetConstrainedEdgeCW(triangulationPoint_1);
		bool constrainedEdgeCCW2 = delaunayTriangle_0.GetConstrainedEdgeCCW(triangulationPoint_0);
		bool constrainedEdgeCW2 = delaunayTriangle_0.GetConstrainedEdgeCW(triangulationPoint_0);
		bool delaunayEdgeCCW = delaunayTriangle_1.GetDelaunayEdgeCCW(triangulationPoint_1);
		bool delaunayEdgeCW = delaunayTriangle_1.GetDelaunayEdgeCW(triangulationPoint_1);
		bool delaunayEdgeCCW2 = delaunayTriangle_0.GetDelaunayEdgeCCW(triangulationPoint_0);
		bool delaunayEdgeCW2 = delaunayTriangle_0.GetDelaunayEdgeCW(triangulationPoint_0);
		delaunayTriangle_1.Legalize(triangulationPoint_1, triangulationPoint_0);
		delaunayTriangle_0.Legalize(triangulationPoint_0, triangulationPoint_1);
		delaunayTriangle_0.SetDelaunayEdgeCCW(triangulationPoint_1, delaunayEdgeCCW);
		delaunayTriangle_1.SetDelaunayEdgeCW(triangulationPoint_1, delaunayEdgeCW);
		delaunayTriangle_1.SetDelaunayEdgeCCW(triangulationPoint_0, delaunayEdgeCCW2);
		delaunayTriangle_0.SetDelaunayEdgeCW(triangulationPoint_0, delaunayEdgeCW2);
		delaunayTriangle_0.SetConstrainedEdgeCCW(triangulationPoint_1, constrainedEdgeCCW);
		delaunayTriangle_1.SetConstrainedEdgeCW(triangulationPoint_1, constrainedEdgeCW);
		delaunayTriangle_1.SetConstrainedEdgeCCW(triangulationPoint_0, constrainedEdgeCCW2);
		delaunayTriangle_0.SetConstrainedEdgeCW(triangulationPoint_0, constrainedEdgeCW2);
		delaunayTriangle_1.Neighbors.Clear();
		delaunayTriangle_0.Neighbors.Clear();
		if (delaunayTriangle != null)
		{
			delaunayTriangle_0.MarkNeighbor(delaunayTriangle);
		}
		if (delaunayTriangle2 != null)
		{
			delaunayTriangle_1.MarkNeighbor(delaunayTriangle2);
		}
		if (delaunayTriangle3 != null)
		{
			delaunayTriangle_1.MarkNeighbor(delaunayTriangle3);
		}
		if (delaunayTriangle4 != null)
		{
			delaunayTriangle_0.MarkNeighbor(delaunayTriangle4);
		}
		delaunayTriangle_1.MarkNeighbor(delaunayTriangle_0);
	}

	static bool smethod_66(Class153 class153_0, Class153 class153_1, buClipper buClipper_0, Class153 class153_2, IntPoint intPoint_0, bool bool_0, Class153 class153_3)
	{
		Enum12 @enum = ((class153_1.intPoint_0.X <= class153_2.intPoint_0.X) ? Enum12.const_1 : Enum12.const_0);
		Enum12 enum2 = ((class153_0.intPoint_0.X <= class153_3.intPoint_0.X) ? Enum12.const_1 : Enum12.const_0);
		if (@enum != enum2)
		{
			if (@enum != Enum12.const_1)
			{
				while (class153_1.class153_0.intPoint_0.X >= intPoint_0.X && class153_1.class153_0.intPoint_0.X <= class153_1.intPoint_0.X && class153_1.class153_0.intPoint_0.Y == intPoint_0.Y)
				{
					class153_1 = class153_1.class153_0;
				}
				if (!bool_0 && class153_1.intPoint_0.X != intPoint_0.X)
				{
					class153_1 = class153_1.class153_0;
				}
				class153_2 = smethod_139(buClipper_0, class153_1, bool_0);
				if (class153_2.intPoint_0 != intPoint_0)
				{
					class153_1 = class153_2;
					class153_1.intPoint_0 = intPoint_0;
					class153_2 = smethod_139(buClipper_0, class153_1, bool_0);
				}
			}
			else
			{
				while (class153_1.class153_0.intPoint_0.X <= intPoint_0.X && class153_1.class153_0.intPoint_0.X >= class153_1.intPoint_0.X && class153_1.class153_0.intPoint_0.Y == intPoint_0.Y)
				{
					class153_1 = class153_1.class153_0;
				}
				if (bool_0 && class153_1.intPoint_0.X != intPoint_0.X)
				{
					class153_1 = class153_1.class153_0;
				}
				class153_2 = smethod_139(buClipper_0, class153_1, !bool_0);
				if (class153_2.intPoint_0 != intPoint_0)
				{
					class153_1 = class153_2;
					class153_1.intPoint_0 = intPoint_0;
					class153_2 = smethod_139(buClipper_0, class153_1, !bool_0);
				}
			}
			if (enum2 != Enum12.const_1)
			{
				while (class153_0.class153_0.intPoint_0.X >= intPoint_0.X && class153_0.class153_0.intPoint_0.X <= class153_0.intPoint_0.X && class153_0.class153_0.intPoint_0.Y == intPoint_0.Y)
				{
					class153_0 = class153_0.class153_0;
				}
				if (!bool_0 && class153_0.intPoint_0.X != intPoint_0.X)
				{
					class153_0 = class153_0.class153_0;
				}
				class153_3 = smethod_139(buClipper_0, class153_0, bool_0);
				if (class153_3.intPoint_0 != intPoint_0)
				{
					class153_0 = class153_3;
					class153_0.intPoint_0 = intPoint_0;
					class153_3 = smethod_139(buClipper_0, class153_0, bool_0);
				}
			}
			else
			{
				while (class153_0.class153_0.intPoint_0.X <= intPoint_0.X && class153_0.class153_0.intPoint_0.X >= class153_0.intPoint_0.X && class153_0.class153_0.intPoint_0.Y == intPoint_0.Y)
				{
					class153_0 = class153_0.class153_0;
				}
				if (bool_0 && class153_0.intPoint_0.X != intPoint_0.X)
				{
					class153_0 = class153_0.class153_0;
				}
				class153_3 = smethod_139(buClipper_0, class153_0, !bool_0);
				if (class153_3.intPoint_0 != intPoint_0)
				{
					class153_0 = class153_3;
					class153_0.intPoint_0 = intPoint_0;
					class153_3 = smethod_139(buClipper_0, class153_0, !bool_0);
				}
			}
			if (@enum == Enum12.const_1 != bool_0)
			{
				class153_1.class153_0 = class153_0;
				class153_0.class153_1 = class153_1;
				class153_2.class153_1 = class153_3;
				class153_3.class153_0 = class153_2;
			}
			else
			{
				class153_1.class153_1 = class153_0;
				class153_0.class153_0 = class153_1;
				class153_2.class153_0 = class153_3;
				class153_3.class153_1 = class153_2;
			}
			return true;
		}
		return false;
	}

	static bool smethod_67(Class148 class148_0)
	{
		return class148_0.intPoint_3.Y == 0L;
	}

	static void smethod_68(Pop3Client pop3Client_0, string string_0, string string_1)
	{
		if (!pop3Client_0.ApopSupported)
		{
			throw new NotSupportedException("APOP is not supported on this server");
		}
		smethod_144(pop3Client_0, "APOP " + string_0 + " " + smethod_84(pop3Client_0.method_4(), string_1));
	}

	static bool smethod_69(string string_0)
	{
		if (string_0 != null)
		{
			return string_0.Length == 1 && smethod_225(Encoding.ASCII.GetBytes(string_0));
		}
		throw new ArgumentNullException("lineReceived");
	}

	static bool smethod_70(ref double double_0, ref double double_1, ref string string_0, ref string string_1, ref Color color_0, ref double double_2, ref double double_3, buFile.Dxf dxf_0, ref double double_4, int int_0)
	{
		bool flag = true;
		bool result = false;
		bool flag2 = false;
		bool flag3 = false;
		int num = 0;
		int num2 = int_0;
		while (true)
		{
			if (num2 <= dxf_0.list_0.Count - 1)
			{
				if (num < 80)
				{
					num++;
					if (flag & (dxf_0.list_0[num2] == "AcDbEntity"))
					{
						string_1 = dxf_0.list_0[num2 + 2];
					}
					if (flag & (dxf_0.list_0[num2] == "  8"))
					{
						string_1 = dxf_0.list_0[num2 + 1];
					}
					if (flag & (dxf_0.list_0[num2] == " 62"))
					{
						int num3 = Convert.ToInt32(dxf_0.list_0[num2 + 1]);
						if (num3 != 1)
						{
						}
						if (num3 >= dxf_0.ColorCode.Length)
						{
							color_0 = Color.Black;
						}
						else
						{
							color_0 = dxf_0.ColorCode[num3];
						}
						if ((color_0.A == 0) & (color_0.R == 0) & (color_0.G == 0) & (color_0.B == 0))
						{
							color_0 = Color.Black;
						}
					}
					if (dxf_0.list_0[num2] == " 10")
					{
						double_1 = smethod_256(dxf_0, dxf_0.list_0[num2 + 1]);
						flag2 = true;
					}
					if (dxf_0.list_0[num2] == " 20")
					{
						double_0 = smethod_256(dxf_0, dxf_0.list_0[num2 + 1]);
						flag3 = true;
					}
					if (dxf_0.list_0[num2] == " 30")
					{
						double_3 = smethod_256(dxf_0, dxf_0.list_0[num2 + 1]);
					}
					if (dxf_0.list_0[num2] == " 39")
					{
						string_0 += "39";
						double_4 = smethod_256(dxf_0, dxf_0.list_0[num2 + 1]);
					}
					if (dxf_0.list_0[num2] == " 50")
					{
						string_0 += "50";
						double_2 = smethod_256(dxf_0, dxf_0.list_0[num2 + 1]);
					}
					if (((dxf_0.list_0[num2] == "  0") | (dxf_0.list_0[num2] == "0")) && flag2 && flag3)
					{
						break;
					}
					num2++;
					continue;
				}
				result = false;
			}
			return result;
		}
		return true;
	}

	static string smethod_71(int int_0)
	{
		lock (Class158.object_0)
		{
			Class158.dictionary_0.TryGetValue(int_0, out var value);
			if (value != null)
			{
				return value;
			}
		}
		return smethod_174(int_0);
	}

	static string smethod_72(string string_0, string string_1)
	{
		if (string_1 != null)
		{
			if (string_0 == null)
			{
				throw new ArgumentNullException("encoding");
			}
			string_1 = "=?" + string_0 + "?Q?" + string_1.Replace("%", "=") + "?=";
			return smethod_179(string_1);
		}
		throw new ArgumentNullException("valueToDecode");
	}

	static DelaunayTriangle smethod_73(TriangulationPoint triangulationPoint_0, Orientation orientation_0, DTSweepContext dtsweepContext_0, DelaunayTriangle delaunayTriangle_0, DelaunayTriangle delaunayTriangle_1, TriangulationPoint triangulationPoint_1)
	{
		int index;
		if (orientation_0 != Orientation.AntiClockwise)
		{
			index = delaunayTriangle_0.EdgeIndex(triangulationPoint_1, triangulationPoint_0);
			delaunayTriangle_0.EdgeIsDelaunay[index] = true;
			smethod_226(dtsweepContext_0, delaunayTriangle_0);
			delaunayTriangle_0.EdgeIsDelaunay.Clear();
			return delaunayTriangle_1;
		}
		index = delaunayTriangle_1.EdgeIndex(triangulationPoint_1, triangulationPoint_0);
		delaunayTriangle_1.EdgeIsDelaunay[index] = true;
		smethod_226(dtsweepContext_0, delaunayTriangle_1);
		delaunayTriangle_1.EdgeIsDelaunay.Clear();
		return delaunayTriangle_0;
	}

	static void smethod_74(PolyType polyType_0, Class148 class148_0, buClipperBase buClipperBase_0)
	{
		if (class148_0.intPoint_1.Y < class148_0.class148_0.intPoint_1.Y)
		{
			class148_0.intPoint_2 = class148_0.intPoint_1;
			class148_0.intPoint_0 = class148_0.class148_0.intPoint_1;
		}
		else
		{
			class148_0.intPoint_0 = class148_0.intPoint_1;
			class148_0.intPoint_2 = class148_0.class148_0.intPoint_1;
		}
		smethod_260(buClipperBase_0, class148_0);
		class148_0.polyType_0 = polyType_0;
	}

	static TriangulationContext smethod_75(TriangulationAlgorithm triangulationAlgorithm_0)
	{
		return new DTSweepContext();
	}

	static string smethod_76(string string_0)
	{
		return string_0.Trim().TrimEnd('>').TrimStart('<');
	}

	static PolyNode smethod_77(PolyNode polyNode_0)
	{
		if (polyNode_0.polyNode_0 != null)
		{
			if (polyNode_0.int_0 != polyNode_0.polyNode_0.list_1.Count - 1)
			{
				return polyNode_0.polyNode_0.list_1[polyNode_0.int_0 + 1];
			}
			return smethod_77(polyNode_0.polyNode_0);
		}
		return null;
	}

	static void smethod_78(TriangulationConstraint triangulationConstraint_0, AdvancingFrontNode advancingFrontNode_0, DTSweepContext dtsweepContext_0)
	{
		if (TriangulationUtil.Orient2d(advancingFrontNode_0.Prev.Point, advancingFrontNode_0.Prev.Prev.Point, advancingFrontNode_0.Prev.Prev.Prev.Point) != Orientation.Clockwise)
		{
			if (TriangulationUtil.Orient2d(triangulationConstraint_0.Q, advancingFrontNode_0.Prev.Prev.Point, triangulationConstraint_0.P) == Orientation.Clockwise)
			{
				smethod_78(triangulationConstraint_0, advancingFrontNode_0.Prev, dtsweepContext_0);
			}
		}
		else
		{
			smethod_112(triangulationConstraint_0, advancingFrontNode_0.Prev, dtsweepContext_0);
		}
	}

	static bool smethod_79(ref double double_0, ref double double_1, buFile.Dxf dxf_0, ref double double_2, ref Color color_0, int int_0, ref string string_0, ref double double_3, ref double double_4, ref double double_5)
	{
		bool flag = true;
		bool flag2 = true;
		bool result = false;
		int num = 0;
		for (int i = int_0; i <= dxf_0.list_0.Count - 1; i++)
		{
			if (num < 80)
			{
				num++;
				if (flag & (dxf_0.list_0[i] == "AcDbEntity"))
				{
					string_0 = dxf_0.list_0[i + 2];
				}
				if (flag & (dxf_0.list_0[i] == "  8"))
				{
					string_0 = dxf_0.list_0[i + 1];
				}
				if (flag & (dxf_0.list_0[i] == "AcDbLine"))
				{
					flag2 = true;
				}
				if (flag & (dxf_0.list_0[i] == "CONTINUOUS"))
				{
					flag2 = true;
				}
				if (flag & (dxf_0.list_0[i] == " 62"))
				{
					int num2 = Convert.ToInt32(dxf_0.list_0[i + 1]);
					if (num2 >= dxf_0.ColorCode.Length)
					{
						color_0 = Color.Black;
					}
					else
					{
						color_0 = dxf_0.ColorCode[num2];
					}
					if ((color_0.A == 0) & (color_0.R == 0) & (color_0.G == 0) & (color_0.B == 0))
					{
						color_0 = Color.Black;
					}
				}
				if (flag2 & (dxf_0.list_0[i] == " 10"))
				{
					double_4 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
				}
				if (flag2 & (dxf_0.list_0[i] == " 20"))
				{
					double_1 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
				}
				if (flag2 & (dxf_0.list_0[i] == " 30"))
				{
					double_0 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
				}
				if (flag2 & (dxf_0.list_0[i] == " 11"))
				{
					double_3 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
				}
				if (flag2 & (dxf_0.list_0[i] == " 21"))
				{
					double_5 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
					if (dxf_0.list_0[i + 2] != " 31")
					{
						result = true;
						break;
					}
				}
				if (flag2 & (dxf_0.list_0[i] == " 31"))
				{
					double_2 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
					result = true;
					break;
				}
				continue;
			}
			result = false;
			break;
		}
		return result;
	}

	static void smethod_80(Class160.Class163 class163_0, int int_0, int int_1)
	{
		while (int_1-- > 0)
		{
			class163_0.byte_0[class163_0.int_0++] = class163_0.byte_0[int_0++];
			class163_0.int_0 &= 32767;
			int_0 &= 0x7FFF;
		}
	}

	static bool smethod_81(buClipper buClipper_0, Class148 class148_0)
	{
		if (class148_0.polyType_0 != PolyType.ptSubject)
		{
			return buClipper_0.polyFillType_1 == PolyFillType.pftEvenOdd;
		}
		return buClipper_0.polyFillType_0 == PolyFillType.pftEvenOdd;
	}

	static void smethod_82(ref List<double> list_0, ref List<int> list_1, buFile.Dxf dxf_0, ref List<double> list_2, ref List<double> list_3, ref List<int> list_4, ref List<double> list_5, ref List<double> list_6, ref List<double> list_7, ref List<string> list_8, int int_0, ref List<double> list_9, ref List<double> list_10, ref List<double> list_11)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		double double_ = 0.0;
		double double_2 = 0.0;
		double num6 = 0.0;
		double num7 = 0.0;
		double num8 = 0.0;
		List<double> list = new List<double>();
		List<double> list2 = new List<double>();
		List<double> list3 = new List<double>();
		List<int> list4 = new List<int>();
		string item = "";
		list_4.Clear();
		list_5.Clear();
		list_3.Clear();
		list_0.Clear();
		list_7.Clear();
		list_2.Clear();
		list_10.Clear();
		list_11.Clear();
		list_9.Clear();
		list_6.Clear();
		list_1.Clear();
		list_8.Clear();
		int num9 = int_0;
		while (true)
		{
			if (num9 > dxf_0.list_0.Count - 1)
			{
				return;
			}
			if (dxf_0.list_0[num9] == "POLYLINE")
			{
				num = num9;
				flag = true;
			}
			if (dxf_0.list_0[num9] == "SEQEND" && flag)
			{
				num2 = num9;
				flag = false;
				flag2 = false;
				list.Clear();
				list2.Clear();
				list4.Clear();
				list3.Clear();
				for (int i = num; i <= num2; i++)
				{
					if (dxf_0.list_0[i] == "VERTEX")
					{
						flag3 = true;
					}
					if (dxf_0.list_0[i] == "  8" && !flag4)
					{
						item = dxf_0.list_0[i + 1];
						flag4 = true;
					}
					if (!(dxf_0.list_0[i] == "  6"))
					{
					}
					if ((!flag3 & (dxf_0.list_0[i].Trim() == "70")) && ((Convert.ToInt32(dxf_0.list_0[i + 1]) == 1) | (Convert.ToInt32(dxf_0.list_0[i + 1]) == 129)))
					{
						flag2 = true;
					}
					if (flag3 & (dxf_0.list_0[i].Trim() == "10"))
					{
						num4++;
						list.Add(smethod_256(dxf_0, dxf_0.list_0[i + 1]));
						list2.Add(smethod_256(dxf_0, dxf_0.list_0[i + 3]));
						num5 = ((dxf_0.list_0[i + 4].Trim() == "30") ? 6 : 4);
						if (!(dxf_0.list_0[i + num5].Trim() == "42"))
						{
							list3.Add(0.0);
							list4.Add(1);
						}
						else
						{
							list3.Add(smethod_256(dxf_0, dxf_0.list_0[i + num5 + 1]));
							list4.Add(3);
						}
					}
				}
				num3 = num4;
				if (num4 >= num3)
				{
					break;
				}
			}
			num9++;
		}
		if (((list.Count == 1) & (list2.Count == 1)) && list4[0] == 1)
		{
			list_5.Add(list[0]);
			list_0.Add(list2[0]);
			list_1.Add(0);
			list_8.Add(item);
			list_4.Add(10);
			list_2.Add(0.0);
			list_10.Add(0.0);
			list_11.Add(0.0);
			list_9.Add(0.0);
			list_6.Add(0.0);
		}
		for (int j = 0; j <= list.Count - 2; j++)
		{
			if (list4[j] == 1)
			{
				list_5.Add(list[j]);
				list_0.Add(list2[j]);
				list_3.Add(list[j + 1]);
				list_7.Add(list2[j + 1]);
				list_1.Add(0);
				list_8.Add(item);
				list_4.Add(1);
				list_2.Add(0.0);
				list_10.Add(0.0);
				list_11.Add(0.0);
				list_9.Add(0.0);
				list_6.Add(0.0);
			}
			if (list4[j] != 3)
			{
				continue;
			}
			double num10 = Math.Abs(smethod_193(Math.Atan(Math.Abs(list3[j])), dxf_0) * 4.0);
			double num11 = Math.Abs(smethod_193(Math.Atan(Math.Abs(list3[j])), dxf_0) * 4.0);
			if (Math.Abs(num10) > 180.0)
			{
				num10 = 360.0 - Math.Abs(num10);
			}
			double num12 = Math.Sqrt(Math.Pow(list[j] - list[j + 1], 2.0) + Math.Pow(list2[j] - list2[j + 1], 2.0));
			double x = num12 / Math.Tan(smethod_204(dxf_0, num10 / 2.0)) / 2.0;
			double num13 = (((num11 < 180.0) | smethod_255(dxf_0, num11, 180.0)) ? Math.Sqrt(Math.Pow(x, 2.0) + Math.Pow(num12 / 2.0, 2.0)) : (Math.Sqrt(Math.Pow(x, 2.0) + Math.Pow(num12 / 2.0, 2.0)) * -1.0));
			if (!(list3[j] < 0.0))
			{
				double double_3 = list[j];
				double double_4 = list2[j];
				double double_5 = list[j + 1];
				double double_6 = list2[j + 1];
				smethod_140(double_5, double_3, ref double_2, ref double_, (short)3, double_4, dxf_0, double_6, num13);
			}
			else
			{
				double double_3 = list[j];
				double double_4 = list2[j];
				double double_5 = list[j + 1];
				double double_6 = list2[j + 1];
				smethod_140(double_5, double_3, ref double_2, ref double_, (short)2, double_4, dxf_0, double_6, num13);
			}
			num8 = num13;
			num6 = smethod_149(dxf_0, list[j], list2[j], double_, double_2);
			num7 = smethod_149(dxf_0, list[j + 1], list2[j + 1], double_, double_2);
			if (list3[j] < 0.0)
			{
				if (smethod_255(dxf_0, num11, Math.Abs(num6 - num7)))
				{
					double num14 = num6;
					num6 = num7;
					num7 = num14;
				}
				if (!smethod_255(dxf_0, num11, Math.Abs(num6 - num7)))
				{
					double num14 = num6;
					num6 = num7;
					num7 = num14;
					num7 += 360.0;
				}
			}
			if (list3[j] > 0.0)
			{
				if (!smethod_255(dxf_0, num11, Math.Abs(num6 - num7)))
				{
				}
				if (!smethod_255(dxf_0, num11, Math.Abs(num6 - num7)))
				{
					num7 += 360.0;
				}
			}
			if ((list3[j] == -1.0) & smethod_255(dxf_0, num7, 0.0))
			{
				num6 = 180.0;
				num7 = 360.0;
			}
			if ((list3[j] == -1.0) & smethod_255(dxf_0, num6, 0.0))
			{
				num6 = 0.0;
				num7 = 180.0;
			}
			if ((list3[j] == 1.0) & smethod_255(dxf_0, num7, 0.0))
			{
				num6 = 0.0;
				num7 = 180.0;
			}
			if ((list3[j] == 1.0) & smethod_255(dxf_0, num6, 0.0))
			{
				num6 = 180.0;
				num7 = 360.0;
			}
			if (Math.Abs(num6 - num7) > 360.0)
			{
				num7 -= 360.0;
			}
			list_2.Add(double_);
			list_10.Add(double_2);
			list_11.Add(Math.Abs(num8));
			list_9.Add(num6);
			list_6.Add(num7);
			list_4.Add(3);
			list_1.Add(0);
			list_8.Add(item);
			list_5.Add(0.0);
			list_0.Add(0.0);
			list_3.Add(0.0);
			list_7.Add(0.0);
		}
		if (flag2)
		{
			if (list4[list.Count - 1] == 1 && (!smethod_255(dxf_0, list[list.Count - 1], list[0]) | !smethod_255(dxf_0, list2[list2.Count - 1], list2[0])))
			{
				list_2.Add(0.0);
				list_10.Add(0.0);
				list_11.Add(0.0);
				list_9.Add(0.0);
				list_6.Add(0.0);
				list_4.Add(1);
				list_1.Add(0);
				list_8.Add(item);
				list_5.Add(list[list.Count - 1]);
				list_0.Add(list2[list.Count - 1]);
				list_3.Add(list[0]);
				list_7.Add(list2[0]);
			}
			if (list4[list.Count - 1] == 3)
			{
				double num10 = Math.Abs(smethod_193(Math.Atan(Math.Abs(list3[list.Count - 1])), dxf_0) * 4.0);
				double num11 = Math.Abs(smethod_193(Math.Atan(Math.Abs(list3[list.Count - 1])), dxf_0) * 4.0);
				if (Math.Abs(num10) > 180.0)
				{
					num10 = 360.0 - Math.Abs(num10);
				}
				double num12 = Math.Sqrt(Math.Pow(list[list.Count - 1] - list[0], 2.0) + Math.Pow(list2[list.Count - 1] - list2[0], 2.0));
				double x = num12 / Math.Tan(smethod_204(dxf_0, num10 / 2.0)) / 2.0;
				double num13 = (((num11 < 180.0) | smethod_255(dxf_0, num11, 180.0)) ? Math.Sqrt(Math.Pow(x, 2.0) + Math.Pow(num12 / 2.0, 2.0)) : (Math.Sqrt(Math.Pow(x, 2.0) + Math.Pow(num12 / 2.0, 2.0)) * -1.0));
				if (!(list3[list.Count - 1] < 0.0))
				{
					double double_3 = list[list.Count - 1];
					double double_4 = list2[list.Count - 1];
					double double_5 = list[0];
					double double_6 = list2[0];
					smethod_140(double_5, double_3, ref double_2, ref double_, (short)3, double_4, dxf_0, double_6, num13);
				}
				else
				{
					double double_3 = list[list.Count - 1];
					double double_4 = list2[list.Count - 1];
					double double_5 = list[0];
					double double_6 = list2[0];
					smethod_140(double_5, double_3, ref double_2, ref double_, (short)2, double_4, dxf_0, double_6, num13);
				}
				num8 = num13;
				num6 = smethod_149(dxf_0, list[list.Count - 1], list2[list.Count - 1], double_, double_2);
				num7 = smethod_149(dxf_0, list[0], list2[0], double_, double_2);
				if (list3[list.Count - 1] < 0.0)
				{
					if (smethod_255(dxf_0, num11, Math.Abs(num6 - num7)))
					{
						double num14 = num6;
						num6 = num7;
						num7 = num14;
					}
					if (!smethod_255(dxf_0, num11, Math.Abs(num6 - num7)))
					{
						double num14 = num6;
						num6 = num7;
						num7 = num14;
						num7 += 360.0;
					}
				}
				if (list3[list.Count - 1] > 0.0)
				{
					if (!smethod_255(dxf_0, num11, Math.Abs(num6 - num7)))
					{
					}
					if (!smethod_255(dxf_0, num11, Math.Abs(num6 - num7)))
					{
						num7 += 360.0;
					}
				}
				if ((list3[list.Count - 1] == -1.0) & smethod_255(dxf_0, num7, 0.0))
				{
					num6 = 180.0;
					num7 = 360.0;
				}
				if ((list3[list.Count - 1] == -1.0) & smethod_255(dxf_0, num6, 0.0))
				{
					num6 = 0.0;
					num7 = 180.0;
				}
				if ((list3[list.Count - 1] == 1.0) & smethod_255(dxf_0, num7, 0.0))
				{
					num6 = 0.0;
					num7 = 180.0;
				}
				if ((list3[list.Count - 1] == 1.0) & smethod_255(dxf_0, num6, 0.0))
				{
					num6 = 180.0;
					num7 = 360.0;
				}
				if (Math.Abs(num6 - num7) > 360.0)
				{
					num7 -= 360.0;
				}
				list_2.Add(double_);
				list_10.Add(double_2);
				list_11.Add(num8);
				list_9.Add(num6);
				list_6.Add(num7);
				list_4.Add(3);
				list_1.Add(0);
				list_8.Add(item);
				list_5.Add(0.0);
				list_0.Add(0.0);
				list_3.Add(0.0);
				list_7.Add(0.0);
			}
		}
		num4 = 0;
		flag3 = false;
	}

	static bool smethod_83(Class160.Class165 class165_0, Class160.Class162 class162_0)
	{
		while (true)
		{
			switch (class165_0.int_2)
			{
			case 5:
			{
				int int_ = Class160.Class165.int_1[class165_0.int_7];
				int num3 = smethod_292(class162_0, int_);
				if (num3 >= 0)
				{
					smethod_94(class162_0, int_);
					num3 += Class160.Class165.int_0[class165_0.int_7];
					while (num3-- > 0)
					{
						class165_0.byte_1[class165_0.int_8++] = class165_0.byte_2;
					}
					if (class165_0.int_8 == class165_0.int_6)
					{
						return true;
					}
					goto IL_026d;
				}
				return false;
			}
			case 0:
				class165_0.int_3 = smethod_292(class162_0, 5);
				if (class165_0.int_3 >= 0)
				{
					class165_0.int_3 += 257;
					smethod_94(class162_0, 5);
					class165_0.int_2 = 1;
					goto case 1;
				}
				return false;
			case 1:
				class165_0.int_4 = smethod_292(class162_0, 5);
				if (class165_0.int_4 >= 0)
				{
					class165_0.int_4++;
					smethod_94(class162_0, 5);
					class165_0.int_6 = class165_0.int_3 + class165_0.int_4;
					class165_0.byte_1 = new byte[class165_0.int_6];
					class165_0.int_2 = 2;
					goto case 2;
				}
				return false;
			case 2:
				class165_0.int_5 = smethod_292(class162_0, 4);
				if (class165_0.int_5 >= 0)
				{
					class165_0.int_5 += 4;
					smethod_94(class162_0, 4);
					class165_0.byte_0 = new byte[19];
					class165_0.int_8 = 0;
					class165_0.int_2 = 3;
					goto case 3;
				}
				return false;
			case 3:
				while (class165_0.int_8 < class165_0.int_5)
				{
					int num = smethod_292(class162_0, 3);
					if (num >= 0)
					{
						smethod_94(class162_0, 3);
						class165_0.byte_0[Class160.Class165.int_9[class165_0.int_8]] = (byte)num;
						class165_0.int_8++;
						continue;
					}
					return false;
				}
				class165_0.class164_0 = new Class160.Class164(class165_0.byte_0);
				class165_0.byte_0 = null;
				class165_0.int_8 = 0;
				class165_0.int_2 = 4;
				goto case 4;
			case 4:
			{
				int num2;
				while (((num2 = smethod_266(class165_0.class164_0, class162_0)) & -16) == 0)
				{
					class165_0.byte_1[class165_0.int_8++] = (class165_0.byte_2 = (byte)num2);
					if (class165_0.int_8 == class165_0.int_6)
					{
						return true;
					}
				}
				if (num2 >= 0)
				{
					if (num2 >= 17)
					{
						class165_0.byte_2 = 0;
					}
					class165_0.int_7 = num2 - 16;
					class165_0.int_2 = 5;
					goto case 5;
				}
				return false;
			}
			}
			continue;
			IL_026d:
			class165_0.int_2 = 4;
		}
	}

	static string smethod_84(string string_0, string string_1)
	{
		if (string_1 != null)
		{
			if (string_0 != null)
			{
				byte[] bytes = Encoding.ASCII.GetBytes(string_0 + string_1);
				using MD5 mD = new MD5CryptoServiceProvider();
				byte[] array = mD.ComputeHash(bytes);
				return BitConverter.ToString(array).Replace("-", "").ToLowerInvariant();
			}
			throw new ArgumentNullException("serverTimestamp");
		}
		throw new ArgumentNullException("password");
	}

	static bool smethod_85(buClipper buClipper_0, IntersectNode intersectNode_0)
	{
		return intersectNode_0.class148_0.class148_5 == intersectNode_0.class148_1 || intersectNode_0.class148_0.class148_6 == intersectNode_0.class148_1;
	}

	static byte[] smethod_86(string string_0)
	{
		if (string_0 != null)
		{
			byte[] array = Encoding.ASCII.GetBytes(string_0);
			if (array.Length > 64)
			{
				array = new MD5CryptoServiceProvider().ComputeHash(array);
			}
			if (array.Length == 64)
			{
				return array;
			}
			byte[] array2 = new byte[64];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = array[i];
			}
			return array2;
		}
		throw new ArgumentNullException("password");
	}

	static byte[] smethod_87(string string_0)
	{
		try
		{
			using MemoryStream memoryStream = new MemoryStream();
			string_0 = string_0.Replace("\r\n", "");
			byte[] bytes = Encoding.ASCII.GetBytes(string_0);
			using (FromBase64Transform fromBase64Transform = new FromBase64Transform(FromBase64TransformMode.DoNotIgnoreWhiteSpaces))
			{
				byte[] array = new byte[fromBase64Transform.OutputBlockSize];
				int num = 0;
				while (bytes.Length - num > 4)
				{
					fromBase64Transform.TransformBlock(bytes, num, 4, array, 0);
					num += 4;
					memoryStream.Write(array, 0, fromBase64Transform.OutputBlockSize);
				}
				array = fromBase64Transform.TransformFinalBlock(bytes, num, bytes.Length - num);
				memoryStream.Write(array, 0, array.Length);
			}
			return memoryStream.ToArray();
		}
		catch (FormatException ex)
		{
			DefaultLogger.Log.LogError("Base64: (FormatException) " + ex.Message + "\r\nOn string: " + string_0);
			throw;
		}
	}

	static Class153 smethod_88(Class153 class153_0, buClipper buClipper_0)
	{
		Class153 @class = null;
		Class153 class153_1;
		for (class153_1 = class153_0.class153_0; class153_1 != class153_0; class153_1 = class153_1.class153_0)
		{
			if (class153_1.intPoint_0.Y <= class153_0.intPoint_0.Y)
			{
				if (class153_1.intPoint_0.Y == class153_0.intPoint_0.Y && class153_1.intPoint_0.X <= class153_0.intPoint_0.X)
				{
					if (class153_1.intPoint_0.X >= class153_0.intPoint_0.X)
					{
						if (class153_1.class153_0 != class153_0 && class153_1.class153_1 != class153_0)
						{
							@class = class153_1;
						}
					}
					else
					{
						@class = null;
						class153_0 = class153_1;
					}
				}
			}
			else
			{
				class153_0 = class153_1;
				@class = null;
			}
		}
		if (@class != null)
		{
			while (@class != class153_1)
			{
				if (!smethod_125(buClipper_0, class153_1, @class))
				{
					class153_0 = @class;
				}
				@class = @class.class153_0;
				while (@class.intPoint_0 != class153_0.intPoint_0)
				{
					@class = @class.class153_0;
				}
			}
		}
		return class153_0;
	}

	static void smethod_89(buClipper buClipper_0, Class148 class148_0, Class148 class148_1)
	{
		Class152 @class = buClipper_0.list_1[class148_0.int_3];
		Class152 class2 = buClipper_0.list_1[class148_1.int_3];
		Class152 class3 = (smethod_34(buClipper_0, @class, class2) ? class2 : (smethod_34(buClipper_0, class2, @class) ? @class : smethod_126(buClipper_0, @class, class2)));
		Class153 class153_ = @class.class153_0;
		Class153 class153_2 = class153_.class153_1;
		Class153 class153_3 = class2.class153_0;
		Class153 class153_4 = class153_3.class153_1;
		if (class148_0.enum11_0 != Enum11.const_0)
		{
			if (class148_1.enum11_0 != Enum11.const_1)
			{
				class153_2.class153_0 = class153_3;
				class153_3.class153_1 = class153_2;
				class153_.class153_1 = class153_4;
				class153_4.class153_0 = class153_;
			}
			else
			{
				smethod_242(class153_3, buClipper_0);
				class153_2.class153_0 = class153_4;
				class153_4.class153_1 = class153_2;
				class153_3.class153_0 = class153_;
				class153_.class153_1 = class153_3;
			}
		}
		else if (class148_1.enum11_0 != Enum11.const_0)
		{
			class153_4.class153_0 = class153_;
			class153_.class153_1 = class153_4;
			class153_3.class153_1 = class153_2;
			class153_2.class153_0 = class153_3;
			@class.class153_0 = class153_3;
		}
		else
		{
			smethod_242(class153_3, buClipper_0);
			class153_3.class153_0 = class153_;
			class153_.class153_1 = class153_3;
			class153_2.class153_0 = class153_4;
			class153_4.class153_1 = class153_2;
			@class.class153_0 = class153_4;
		}
		@class.class153_1 = null;
		if (class3 == class2)
		{
			if (class2.class152_0 != @class)
			{
				@class.class152_0 = class2.class152_0;
			}
			@class.bool_0 = class2.bool_0;
		}
		class2.class153_0 = null;
		class2.class153_1 = null;
		class2.class152_0 = @class;
		int int_ = class148_0.int_3;
		int int_2 = class148_1.int_3;
		class148_0.int_3 = -1;
		class148_1.int_3 = -1;
		Class148 class4 = buClipper_0.class148_0;
		while (class4 != null)
		{
			if (class4.int_3 != int_2)
			{
				class4 = class4.class148_3;
				continue;
			}
			class4.int_3 = int_;
			class4.enum11_0 = class148_0.enum11_0;
			break;
		}
		class2.int_0 = @class.int_0;
	}

	static void smethod_90(buClipper buClipper_0, Class152 class152_0)
	{
		Class153 @class = null;
		class152_0.class153_1 = null;
		Class153 class2 = class152_0.class153_0;
		bool flag = buClipper_0.PreserveCollinear || buClipper_0.StrictlySimple;
		while (true)
		{
			if (class2.class153_1 != class2 && class2.class153_1 != class2.class153_0)
			{
				if (!(class2.intPoint_0 == class2.class153_0.intPoint_0) && !(class2.intPoint_0 == class2.class153_1.intPoint_0))
				{
					IntPoint intPoint_ = class2.class153_1.intPoint_0;
					IntPoint intPoint_2 = class2.intPoint_0;
					IntPoint intPoint_3 = class2.class153_0.intPoint_0;
					if (!smethod_103(buClipper_0.bool_0, intPoint_2, intPoint_3, intPoint_))
					{
						goto IL_0043;
					}
					if (flag)
					{
						IntPoint intPoint_4 = class2.class153_1.intPoint_0;
						IntPoint intPoint_5 = class2.intPoint_0;
						IntPoint intPoint_6 = class2.class153_0.intPoint_0;
						if (smethod_32(intPoint_4, intPoint_5, (buClipperBase)buClipper_0, intPoint_6))
						{
							goto IL_0043;
						}
					}
				}
				@class = null;
				class2.class153_1.class153_0 = class2.class153_0;
				class2.class153_0.class153_1 = class2.class153_1;
				class2 = class2.class153_1;
				continue;
			}
			class152_0.class153_0 = null;
			return;
			IL_0043:
			if (class2 == @class)
			{
				break;
			}
			if (@class == null)
			{
				@class = class2;
			}
			class2 = class2.class153_0;
		}
		class152_0.class153_0 = class2;
	}

	static void smethod_91(DTSweepContext dtsweepContext_0, AdvancingFrontNode advancingFrontNode_0)
	{
		AdvancingFrontNode next = advancingFrontNode_0.Next;
		while (next.HasNext)
		{
			double num = smethod_57(next);
			if (!(num <= Math.PI / 2.0) || num < -Math.PI / 2.0)
			{
				break;
			}
			smethod_51(dtsweepContext_0, next);
			next = next.Next;
		}
		next = advancingFrontNode_0.Prev;
		while (next.HasPrev)
		{
			double num = smethod_57(next);
			if (!(num <= Math.PI / 2.0) || num < -Math.PI / 2.0)
			{
				break;
			}
			smethod_51(dtsweepContext_0, next);
			next = next.Prev;
		}
		if (advancingFrontNode_0.HasNext && advancingFrontNode_0.Next.HasNext)
		{
			double num = smethod_218(advancingFrontNode_0);
			if (num < Math.PI * 3.0 / 4.0)
			{
				smethod_205(advancingFrontNode_0, dtsweepContext_0);
			}
		}
	}

	static void smethod_92(buClipperBase buClipperBase_0, Class149 class149_0)
	{
		if (buClipperBase_0.class149_0 != null)
		{
			if (class149_0.long_0 < buClipperBase_0.class149_0.long_0)
			{
				Class149 class149_1 = buClipperBase_0.class149_0;
				while (class149_1.class149_0 != null && class149_0.long_0 < class149_1.class149_0.long_0)
				{
					class149_1 = class149_1.class149_0;
				}
				class149_0.class149_0 = class149_1.class149_0;
				class149_1.class149_0 = class149_0;
			}
			else
			{
				class149_0.class149_0 = buClipperBase_0.class149_0;
				buClipperBase_0.class149_0 = class149_0;
			}
		}
		else
		{
			buClipperBase_0.class149_0 = class149_0;
		}
	}

	static bool smethod_93(ref Color color_0, int int_0, buFile.Dxf dxf_0, ref LayerBase layerBase_0)
	{
		bool result = false;
		int num = 0;
		Color color = Color.Black;
		layerBase_0 = new LayerBase();
		layerBase_0.Name = "";
		for (int i = int_0; i <= int_0 + 100; i++)
		{
			num++;
			if ((dxf_0.list_0[i] == "  2") | (dxf_0.list_0[i] == " 2"))
			{
				layerBase_0.Name = dxf_0.list_0[i + 1];
			}
			if (!((dxf_0.list_0[i] == "  0") | (dxf_0.list_0[i] == " 0")))
			{
				if (dxf_0.list_0[i] == " 62")
				{
					int num2 = Convert.ToInt32(dxf_0.list_0[i + 1]);
					if (num2 != 1)
					{
					}
					color = (((num2 >= 0) & (num2 < dxf_0.ColorCode.Length)) ? dxf_0.ColorCode[num2] : Color.Black);
					if ((color.A == 0) & (color.R == 0) & (color.G == 0) & (color.B == 0))
					{
						color = Color.Black;
					}
				}
				continue;
			}
			result = true;
			break;
		}
		color_0 = color;
		return result;
	}

	static void smethod_94(Class160.Class162 class162_0, int int_0)
	{
		class162_0.uint_0 >>= int_0;
		class162_0.int_2 -= int_0;
	}

	static void smethod_95(buClipper buClipper_0, long long_0)
	{
		Class148 class148_ = buClipper_0.class148_0;
		while (class148_ != null)
		{
			bool flag;
			if (flag = smethod_237((double)long_0, buClipper_0, class148_))
			{
				Class148 @class = smethod_110(class148_, buClipper_0);
				flag = @class == null || !smethod_67(@class);
			}
			if (!flag)
			{
				if (!smethod_9(class148_, (double)long_0, buClipper_0) || !smethod_67(class148_.class148_2))
				{
					class148_.intPoint_1.X = smethod_101(class148_, long_0);
					class148_.intPoint_1.Y = long_0;
					if (class148_.intPoint_2.Y != long_0)
					{
						if (class148_.intPoint_0.Y != long_0)
						{
							class148_.intPoint_1.Z = 0L;
						}
						else
						{
							class148_.intPoint_1.Z = class148_.intPoint_0.Z;
						}
					}
					else
					{
						class148_.intPoint_1.Z = class148_.intPoint_2.Z;
					}
				}
				else
				{
					smethod_8((buClipperBase)buClipper_0, ref class148_);
					if (class148_.int_3 >= 0)
					{
						smethod_246(buClipper_0, class148_, class148_.intPoint_0);
					}
					smethod_11(buClipper_0, class148_);
				}
				if (buClipper_0.StrictlySimple)
				{
					Class148 class148_2 = class148_.class148_4;
					if (class148_.int_3 >= 0 && class148_.int_0 != 0 && class148_2 != null && class148_2.int_3 >= 0 && class148_2.intPoint_1.X == class148_.intPoint_1.X && class148_2.int_0 != 0)
					{
						IntPoint intPoint_ = new IntPoint(class148_.intPoint_1);
						smethod_207(buClipper_0, ref intPoint_, class148_2, class148_);
						Class153 class153_ = smethod_246(buClipper_0, class148_2, intPoint_);
						Class153 class153_2 = smethod_246(buClipper_0, class148_, intPoint_);
						smethod_22(intPoint_, class153_2, class153_, buClipper_0);
					}
				}
				class148_ = class148_.class148_3;
			}
			else
			{
				if (buClipper_0.StrictlySimple)
				{
					smethod_134(buClipper_0, class148_.intPoint_2.X);
				}
				Class148 class148_3 = class148_.class148_4;
				smethod_194(buClipper_0, class148_);
				class148_ = ((class148_3 == null) ? buClipper_0.class148_0 : class148_3.class148_3);
			}
		}
		smethod_163(buClipper_0);
		buClipper_0.class151_0 = null;
		for (class148_ = buClipper_0.class148_0; class148_ != null; class148_ = class148_.class148_3)
		{
			if (!smethod_9(class148_, (double)long_0, buClipper_0))
			{
				continue;
			}
			Class153 class2 = null;
			if (class148_.int_3 >= 0)
			{
				class2 = smethod_246(buClipper_0, class148_, class148_.intPoint_2);
			}
			smethod_8((buClipperBase)buClipper_0, ref class148_);
			Class148 class148_4 = class148_.class148_4;
			Class148 class148_5 = class148_.class148_3;
			if (class148_4 != null && class148_4.intPoint_1.X == class148_.intPoint_0.X && class148_4.intPoint_1.Y == class148_.intPoint_0.Y && class2 != null && class148_4.int_3 >= 0 && class148_4.intPoint_1.Y > class148_4.intPoint_2.Y)
			{
				IntPoint intPoint_2 = class148_.intPoint_1;
				IntPoint intPoint_3 = class148_.intPoint_2;
				IntPoint intPoint_4 = class148_4.intPoint_1;
				IntPoint intPoint_5 = class148_4.intPoint_2;
				bool bool_ = buClipper_0.bool_0;
				if (smethod_132(intPoint_4, intPoint_2, intPoint_3, intPoint_5, bool_) && class148_.int_0 != 0 && class148_4.int_0 != 0)
				{
					Class153 class153_3 = smethod_246(buClipper_0, class148_4, class148_.intPoint_0);
					smethod_22(class148_.intPoint_2, class153_3, class2, buClipper_0);
					continue;
				}
			}
			if (class148_5 != null && class148_5.intPoint_1.X == class148_.intPoint_0.X && class148_5.intPoint_1.Y == class148_.intPoint_0.Y && class2 != null && class148_5.int_3 >= 0 && class148_5.intPoint_1.Y > class148_5.intPoint_2.Y)
			{
				IntPoint intPoint_2 = class148_.intPoint_1;
				IntPoint intPoint_3 = class148_.intPoint_2;
				IntPoint intPoint_4 = class148_5.intPoint_1;
				IntPoint intPoint_5 = class148_5.intPoint_2;
				bool bool_ = buClipper_0.bool_0;
				if (smethod_132(intPoint_4, intPoint_2, intPoint_3, intPoint_5, bool_) && class148_.int_0 != 0 && class148_5.int_0 != 0)
				{
					Class153 class153_4 = smethod_246(buClipper_0, class148_5, class148_.intPoint_0);
					smethod_22(class148_.intPoint_2, class153_4, class2, buClipper_0);
				}
			}
		}
	}

	static List<RfcMailAddress> smethod_96(string string_0)
	{
		if (string_0 != null)
		{
			List<RfcMailAddress> list = new List<RfcMailAddress>();
			IEnumerable<string> enumerable = smethod_189(',', string_0);
			foreach (string item in enumerable)
			{
				list.Add(smethod_267(item));
			}
			return list;
		}
		throw new ArgumentNullException("input");
	}

	static bool smethod_97(long long_0, buClipper buClipper_0, long long_1, long long_2, long long_3)
	{
		if (long_2 > long_1)
		{
			buClipper_0.Swap(ref long_2, ref long_1);
		}
		if (long_3 > long_0)
		{
			buClipper_0.Swap(ref long_3, ref long_0);
		}
		return long_2 < long_0 && long_3 < long_1;
	}

	static void smethod_98(string string_0)
	{
		if (string_0 != null)
		{
			if (!string_0.StartsWith("+", StringComparison.OrdinalIgnoreCase))
			{
				throw new PopServerException("The server did not respond with a + response. The response was: \"" + string_0 + "\"");
			}
			return;
		}
		throw new PopServerException("The stream used to retrieve responses from was closed");
	}

	static Class148 smethod_99(buClipper buClipper_0, Class148 class148_0, Enum12 enum12_0)
	{
		return (enum12_0 != Enum12.const_1) ? class148_0.class148_4 : class148_0.class148_3;
	}

	static void smethod_100(Class148 class148_0, Class148 class148_1)
	{
		int int_ = class148_0.int_3;
		class148_0.int_3 = class148_1.int_3;
		class148_1.int_3 = int_;
	}

	static long smethod_101(Class148 class148_0, long long_0)
	{
		if (long_0 != class148_0.intPoint_2.Y)
		{
			return class148_0.intPoint_0.X + smethod_199(class148_0.double_0 * (double)(long_0 - class148_0.intPoint_0.Y));
		}
		return class148_0.intPoint_2.X;
	}

	static void smethod_102(AdvancingFrontNode advancingFrontNode_0, TriangulationConstraint triangulationConstraint_0, DTSweepContext dtsweepContext_0)
	{
		if (dtsweepContext_0.IsDebugEnabled)
		{
			dtsweepContext_0.DebugContext.ActiveNode = advancingFrontNode_0;
		}
		if (advancingFrontNode_0.Point.X > triangulationConstraint_0.P.X)
		{
			if (TriangulationUtil.Orient2d(advancingFrontNode_0.Point, advancingFrontNode_0.Prev.Point, advancingFrontNode_0.Prev.Prev.Point) != Orientation.Clockwise)
			{
				smethod_78(triangulationConstraint_0, advancingFrontNode_0, dtsweepContext_0);
				smethod_102(advancingFrontNode_0, triangulationConstraint_0, dtsweepContext_0);
			}
			else
			{
				smethod_112(triangulationConstraint_0, advancingFrontNode_0, dtsweepContext_0);
			}
		}
	}

	static bool smethod_103(bool bool_0, IntPoint intPoint_0, IntPoint intPoint_1, IntPoint intPoint_2)
	{
		if (!bool_0)
		{
			return (intPoint_2.Y - intPoint_0.Y) * (intPoint_0.X - intPoint_1.X) - (intPoint_2.X - intPoint_0.X) * (intPoint_0.Y - intPoint_1.Y) == 0L;
		}
		return Struct53.smethod_0(Struct53.smethod_2(intPoint_2.Y - intPoint_0.Y, intPoint_0.X - intPoint_1.X), Struct53.smethod_2(intPoint_2.X - intPoint_0.X, intPoint_0.Y - intPoint_1.Y));
	}

	static void smethod_104(double double_0, double double_1, ref List<Pnt3D> list_0, buFile.Dxf dxf_0, double double_2, double double_3, double double_4, double double_5)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		int num5 = 0;
		Pnt3D pnt3D = new Pnt3D();
		list_0 = new List<Pnt3D>();
		num2 = double_0 - double_4;
		num = Math.PI * 2.0 * double_3 * (double_0 - double_4) / 360.0;
		num5 = (int)(num / double_1);
		num3 = ((num5 != 0) ? (num2 / (double)num5) : 0.0);
		if (!((num3 != 0.0) & (num3 <= num2 / 2.0)))
		{
			pnt3D = new Pnt3D();
			pnt3D.X = double_2 + double_3 * Math.Cos(smethod_204(dxf_0, double_4));
			pnt3D.Y = double_5 + double_3 * Math.Sin(smethod_204(dxf_0, double_4));
			list_0.Add(pnt3D);
			pnt3D = new Pnt3D();
			pnt3D.X = double_2 + double_3 * Math.Cos(smethod_204(dxf_0, double_0));
			pnt3D.Y = double_5 + double_3 * Math.Sin(smethod_204(dxf_0, double_0));
			list_0.Add(pnt3D);
			return;
		}
		pnt3D = new Pnt3D();
		pnt3D.X = double_2 + double_3 * Math.Cos(smethod_204(dxf_0, double_4));
		pnt3D.Y = double_5 + double_3 * Math.Sin(smethod_204(dxf_0, double_4));
		list_0.Add(pnt3D);
		for (double num6 = double_4; num6 <= double_0 - num3; num6 += num3)
		{
			pnt3D = new Pnt3D();
			pnt3D.X = double_2 + double_3 * Math.Cos(smethod_204(dxf_0, num6 + num3));
			pnt3D.Y = double_5 + double_3 * Math.Sin(smethod_204(dxf_0, num6 + num3));
			num4 = num6 + num3;
			list_0.Add(pnt3D);
		}
		if (Math.Abs(num4 - double_0) > 0.01)
		{
			pnt3D = new Pnt3D();
			pnt3D.X = double_2 + double_3 * Math.Cos(smethod_204(dxf_0, double_0));
			pnt3D.Y = double_5 + double_3 * Math.Sin(smethod_204(dxf_0, double_0));
			list_0.Add(pnt3D);
		}
	}

	static Class148 smethod_105(Class148 class148_0, buClipperBase buClipperBase_0)
	{
		while (true)
		{
			if (class148_0.intPoint_0 != class148_0.class148_1.intPoint_0 || class148_0.intPoint_1 == class148_0.intPoint_2)
			{
				class148_0 = class148_0.class148_0;
				continue;
			}
			if (class148_0.double_0 != -3.4E+38 && class148_0.class148_1.double_0 != -3.4E+38)
			{
				break;
			}
			while (class148_0.class148_1.double_0 == -3.4E+38)
			{
				class148_0 = class148_0.class148_1;
			}
			Class148 @class = class148_0;
			while (class148_0.double_0 == -3.4E+38)
			{
				class148_0 = class148_0.class148_0;
			}
			if (class148_0.intPoint_2.Y != class148_0.class148_1.intPoint_0.Y)
			{
				if (@class.class148_1.intPoint_0.X < class148_0.intPoint_0.X)
				{
					class148_0 = @class;
				}
				break;
			}
		}
		return class148_0;
	}

	static string smethod_106(Stream stream_0)
	{
		byte[] array = smethod_113(stream_0);
		return (array == null) ? null : Encoding.ASCII.GetString(array);
	}

	static void smethod_107(AdvancingFrontNode advancingFrontNode_0, TriangulationConstraint triangulationConstraint_0, DTSweepContext dtsweepContext_0)
	{
		while (advancingFrontNode_0.Prev.Point.X > triangulationConstraint_0.P.X)
		{
			if (dtsweepContext_0.IsDebugEnabled)
			{
				dtsweepContext_0.DebugContext.ActiveNode = advancingFrontNode_0;
			}
			if (TriangulationUtil.Orient2d(triangulationConstraint_0.Q, advancingFrontNode_0.Prev.Point, triangulationConstraint_0.P) != Orientation.Clockwise)
			{
				advancingFrontNode_0 = advancingFrontNode_0.Prev;
			}
			else
			{
				smethod_102(advancingFrontNode_0, triangulationConstraint_0, dtsweepContext_0);
			}
		}
	}

	static void smethod_108(ref IntPoint intPoint_0, Class148 class148_0, [Out] Class148 class148_1, buClipper buClipper_0)
	{
		intPoint_0 = default(IntPoint);
		if (class148_0.double_0 != class148_1.double_0)
		{
			if (class148_0.intPoint_3.X != 0L)
			{
				if (class148_1.intPoint_3.X != 0L)
				{
					double num = (double)class148_0.intPoint_0.X - (double)class148_0.intPoint_0.Y * class148_0.double_0;
					double num2 = (double)class148_1.intPoint_0.X - (double)class148_1.intPoint_0.Y * class148_1.double_0;
					double num3 = (num2 - num) / (class148_0.double_0 - class148_1.double_0);
					intPoint_0.Y = smethod_199(num3);
					if (!(Math.Abs(class148_0.double_0) < Math.Abs(class148_1.double_0)))
					{
						intPoint_0.X = smethod_199(class148_1.double_0 * num3 + num2);
					}
					else
					{
						intPoint_0.X = smethod_199(class148_0.double_0 * num3 + num);
					}
				}
				else
				{
					intPoint_0.X = class148_1.intPoint_0.X;
					if (!smethod_67(class148_0))
					{
						double num = (double)class148_0.intPoint_0.Y - (double)class148_0.intPoint_0.X / class148_0.double_0;
						intPoint_0.Y = smethod_199((double)intPoint_0.X / class148_0.double_0 + num);
					}
					else
					{
						intPoint_0.Y = class148_0.intPoint_0.Y;
					}
				}
			}
			else
			{
				intPoint_0.X = class148_0.intPoint_0.X;
				if (!smethod_67(class148_1))
				{
					double num2 = (double)class148_1.intPoint_0.Y - (double)class148_1.intPoint_0.X / class148_1.double_0;
					intPoint_0.Y = smethod_199((double)intPoint_0.X / class148_1.double_0 + num2);
				}
				else
				{
					intPoint_0.Y = class148_1.intPoint_0.Y;
				}
			}
			if (intPoint_0.Y < class148_0.intPoint_2.Y || intPoint_0.Y < class148_1.intPoint_2.Y)
			{
				if (class148_0.intPoint_2.Y <= class148_1.intPoint_2.Y)
				{
					intPoint_0.Y = class148_1.intPoint_2.Y;
				}
				else
				{
					intPoint_0.Y = class148_0.intPoint_2.Y;
				}
				if (!(Math.Abs(class148_0.double_0) < Math.Abs(class148_1.double_0)))
				{
					intPoint_0.X = smethod_101(class148_1, intPoint_0.Y);
				}
				else
				{
					intPoint_0.X = smethod_101(class148_0, intPoint_0.Y);
				}
			}
			if (intPoint_0.Y > class148_0.intPoint_1.Y)
			{
				intPoint_0.Y = class148_0.intPoint_1.Y;
				if (!(Math.Abs(class148_0.double_0) > Math.Abs(class148_1.double_0)))
				{
					intPoint_0.X = smethod_101(class148_0, intPoint_0.Y);
				}
				else
				{
					intPoint_0.X = smethod_101(class148_1, intPoint_0.Y);
				}
			}
		}
		else
		{
			intPoint_0.Y = class148_0.intPoint_1.Y;
			intPoint_0.X = smethod_101(class148_0, intPoint_0.Y);
		}
	}

	static DateTime smethod_109(DateTime dateTime_0, string string_0)
	{
		string[] array = string_0.Split(' ');
		string input = array[array.Length - 1];
		input = Regex.Replace(input, "UT|GMT|EST|EDT|CST|CDT|MST|MDT|PST|PDT|[A-I]|[K-Y]|Z", (MatchEvaluator)Class156.smethod_37);
		Match match = Regex.Match(input, "[\\+-](?<hours>\\d\\d)(?<minutes>\\d\\d)");
		if (!match.Success)
		{
			DefaultLogger.Log.LogDebug("No timezone found in date: " + string_0 + ". Using -0000 as default.");
			return dateTime_0;
		}
		int num = int.Parse(match.Groups["hours"].Value);
		int num2 = int.Parse(match.Groups["minutes"].Value);
		int num3 = ((match.Value[0] != '+') ? 1 : (-1));
		dateTime_0 = dateTime_0.AddHours(num3 * num);
		dateTime_0 = dateTime_0.AddMinutes(num3 * num2);
		return dateTime_0;
	}

	static Class148 smethod_110(Class148 class148_0, buClipper buClipper_0)
	{
		Class148 @class = smethod_146(buClipper_0, class148_0);
		if (@class != null && @class.int_3 != -2 && (@class.class148_3 != @class.class148_4 || smethod_67(@class)))
		{
			return @class;
		}
		return null;
	}

	static void smethod_111(buClipper buClipper_0, [Out] Class148 class148_0, out Enum12 enum12_0, out long long_0, ref long long_1)
	{
		if (class148_0.intPoint_0.X >= class148_0.intPoint_2.X)
		{
			long_0 = class148_0.intPoint_2.X;
			long_1 = class148_0.intPoint_0.X;
			enum12_0 = Enum12.const_0;
		}
		else
		{
			long_0 = class148_0.intPoint_0.X;
			long_1 = class148_0.intPoint_2.X;
			enum12_0 = Enum12.const_1;
		}
	}

	static void smethod_112(TriangulationConstraint triangulationConstraint_0, AdvancingFrontNode advancingFrontNode_0, DTSweepContext dtsweepContext_0)
	{
		smethod_51(dtsweepContext_0, advancingFrontNode_0.Prev);
		if (advancingFrontNode_0.Prev.Point.Equals(triangulationConstraint_0.P) && TriangulationUtil.Orient2d(triangulationConstraint_0.Q, advancingFrontNode_0.Prev.Point, triangulationConstraint_0.P) == Orientation.Clockwise && TriangulationUtil.Orient2d(advancingFrontNode_0.Point, advancingFrontNode_0.Prev.Point, advancingFrontNode_0.Prev.Prev.Point) == Orientation.Clockwise)
		{
			smethod_112(triangulationConstraint_0, advancingFrontNode_0, dtsweepContext_0);
		}
	}

	static byte[] smethod_113(Stream stream_0)
	{
		if (stream_0 != null)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				while (true)
				{
					int num = stream_0.ReadByte();
					if (num != -1 || memoryStream.Length <= 0L)
					{
						if (num == -1 && memoryStream.Length == 0L)
						{
							break;
						}
						char c = (char)num;
						if (c != '\r' && c != '\n')
						{
							memoryStream.WriteByte((byte)num);
						}
						if (c != '\n')
						{
							continue;
						}
					}
					return memoryStream.ToArray();
				}
				return null;
			}
		}
		throw new ArgumentNullException("stream");
	}

	static void smethod_114(DelaunayTriangle delaunayTriangle_0, DelaunayTriangle delaunayTriangle_1)
	{
		if (delaunayTriangle_1.Neighbors[0] != delaunayTriangle_0)
		{
			if (delaunayTriangle_1.Neighbors[1] != delaunayTriangle_0)
			{
				if (delaunayTriangle_1.Neighbors[2] == delaunayTriangle_0)
				{
					delaunayTriangle_1.Neighbors[2] = null;
				}
			}
			else
			{
				delaunayTriangle_1.Neighbors[1] = null;
			}
		}
		else
		{
			delaunayTriangle_1.Neighbors[0] = null;
		}
	}

	static string smethod_115(string string_0)
	{
		if (string_0 != null)
		{
			StringBuilder stringBuilder = new StringBuilder(string_0.Length);
			for (int i = 0; i < string_0.Length; i++)
			{
				if ((string_0[i] != '\r' || (i + 1 < string_0.Length && string_0[i + 1] == '\n')) && (string_0[i] != '\n' || (i - 1 >= 0 && string_0[i - 1] == '\r')))
				{
					stringBuilder.Append(string_0[i]);
				}
			}
			return stringBuilder.ToString();
		}
		throw new ArgumentNullException("input");
	}

	static int smethod_116(Class160.Stream3 stream3_0)
	{
		return smethod_27(stream3_0) | (smethod_27(stream3_0) << 16);
	}

	static void smethod_117(buClipper buClipper_0, Class152 class152_0)
	{
		if (class152_0.class152_0 != null && (class152_0.bool_0 == class152_0.class152_0.bool_0 || class152_0.class152_0.class153_0 == null))
		{
			Class152 class152_1 = class152_0.class152_0;
			while (class152_1 != null && (class152_1.bool_0 == class152_0.bool_0 || class152_1.class153_0 == null))
			{
				class152_1 = class152_1.class152_0;
			}
			class152_0.class152_0 = class152_1;
		}
	}

	static void smethod_118(buClipper buClipper_0, List<List<IntPoint>> list_0)
	{
		list_0.Clear();
		list_0.Capacity = buClipper_0.list_1.Count;
		for (int i = 0; i < buClipper_0.list_1.Count; i++)
		{
			Class152 @class = buClipper_0.list_1[i];
			if (@class.class153_0 == null)
			{
				continue;
			}
			Class153 class153_ = @class.class153_0.class153_1;
			int num = smethod_258(class153_, buClipper_0);
			if (num >= 2)
			{
				List<IntPoint> list = new List<IntPoint>(num);
				for (int j = 0; j < num; j++)
				{
					list.Add(class153_.intPoint_0);
					class153_ = class153_.class153_1;
				}
				list_0.Add(list);
			}
		}
	}

	static uint smethod_119(string string_0)
	{
		uint num = default(uint);
		if (string_0 != null)
		{
			num = 2166136261u;
			for (int i = 0; i < string_0.Length; i++)
			{
				num = (string_0[i] ^ num) * 16777619;
			}
		}
		return num;
	}

	static bool smethod_120(Point2D point2D_0, Contour contour_0)
	{
		Contour.Class129 @class = new Contour.Class129();
		@class.point2D_0 = point2D_0;
		if (!PolygonUtil.PointInPolygon2D(contour_0, @class.point2D_0))
		{
			return false;
		}
		return contour_0.list_0.All(@class.method_0);
	}

	static void smethod_121(ClipperOffset clipperOffset_0, int int_0, ref int int_1, JoinType joinType_0)
	{
		clipperOffset_0.double_1 = clipperOffset_0.list_3[int_1].X * clipperOffset_0.list_3[int_0].Y - clipperOffset_0.list_3[int_0].X * clipperOffset_0.list_3[int_1].Y;
		if (!(Math.Abs(clipperOffset_0.double_1 * clipperOffset_0.double_0) < 1.0))
		{
			if (!(clipperOffset_0.double_1 > 1.0))
			{
				if (clipperOffset_0.double_1 < -1.0)
				{
					clipperOffset_0.double_1 = -1.0;
				}
			}
			else
			{
				clipperOffset_0.double_1 = 1.0;
			}
		}
		else
		{
			double num = clipperOffset_0.list_3[int_1].X * clipperOffset_0.list_3[int_0].X + clipperOffset_0.list_3[int_0].Y * clipperOffset_0.list_3[int_1].Y;
			if (num > 0.0)
			{
				clipperOffset_0.list_2.Add(new IntPoint(smethod_150((double)clipperOffset_0.list_1[int_0].X + clipperOffset_0.list_3[int_1].X * clipperOffset_0.double_0), smethod_150((double)clipperOffset_0.list_1[int_0].Y + clipperOffset_0.list_3[int_1].Y * clipperOffset_0.double_0)));
				return;
			}
		}
		if (!(clipperOffset_0.double_1 * clipperOffset_0.double_0 < 0.0))
		{
			switch (joinType_0)
			{
			case JoinType.jtMiter:
			{
				double num2 = 1.0 + (clipperOffset_0.list_3[int_0].X * clipperOffset_0.list_3[int_1].X + clipperOffset_0.list_3[int_0].Y * clipperOffset_0.list_3[int_1].Y);
				if (!(num2 >= clipperOffset_0.double_4))
				{
					smethod_210(clipperOffset_0, int_0, int_1);
				}
				else
				{
					smethod_13(int_1, num2, clipperOffset_0, int_0);
				}
				break;
			}
			case JoinType.jtSquare:
				smethod_210(clipperOffset_0, int_0, int_1);
				break;
			case JoinType.jtRound:
				smethod_154(clipperOffset_0, int_0, int_1);
				break;
			}
		}
		else
		{
			clipperOffset_0.list_2.Add(new IntPoint(smethod_150((double)clipperOffset_0.list_1[int_0].X + clipperOffset_0.list_3[int_1].X * clipperOffset_0.double_0), smethod_150((double)clipperOffset_0.list_1[int_0].Y + clipperOffset_0.list_3[int_1].Y * clipperOffset_0.double_0)));
			clipperOffset_0.list_2.Add(clipperOffset_0.list_1[int_0]);
			clipperOffset_0.list_2.Add(new IntPoint(smethod_150((double)clipperOffset_0.list_1[int_0].X + clipperOffset_0.list_3[int_0].X * clipperOffset_0.double_0), smethod_150((double)clipperOffset_0.list_1[int_0].Y + clipperOffset_0.list_3[int_0].Y * clipperOffset_0.double_0)));
		}
		int_1 = int_0;
	}

	static byte[] smethod_122(byte[] byte_0, byte[] byte_1)
	{
		if (byte_0 != null)
		{
			if (byte_1 == null)
			{
				throw new ArgumentNullException("two");
			}
			byte[] array = new byte[byte_0.Length + byte_1.Length];
			Buffer.BlockCopy(byte_0, 0, array, 0, byte_0.Length);
			Buffer.BlockCopy(byte_1, 0, array, byte_0.Length, byte_1.Length);
			return array;
		}
		throw new ArgumentNullException("one");
	}

	static void smethod_123(TriangulationConstraint triangulationConstraint_0, AdvancingFrontNode advancingFrontNode_0, DTSweepContext dtsweepContext_0)
	{
		smethod_51(dtsweepContext_0, advancingFrontNode_0.Next);
		if (advancingFrontNode_0.Next.Point.Equals(triangulationConstraint_0.P) && TriangulationUtil.Orient2d(triangulationConstraint_0.Q, advancingFrontNode_0.Next.Point, triangulationConstraint_0.P) == Orientation.AntiClockwise && TriangulationUtil.Orient2d(advancingFrontNode_0.Point, advancingFrontNode_0.Next.Point, advancingFrontNode_0.Next.Next.Point) == Orientation.AntiClockwise)
		{
			smethod_123(triangulationConstraint_0, advancingFrontNode_0, dtsweepContext_0);
		}
	}

	static void smethod_124(DateTime dateTime_0, string string_0)
	{
		if (string_0.Length >= 4 && string_0[3] == ',')
		{
			string text = string_0.Substring(0, 3);
			if ((dateTime_0.DayOfWeek == DayOfWeek.Monday && !text.Equals("Mon")) || (dateTime_0.DayOfWeek == DayOfWeek.Tuesday && !text.Equals("Tue")) || (dateTime_0.DayOfWeek == DayOfWeek.Wednesday && !text.Equals("Wed")) || (dateTime_0.DayOfWeek == DayOfWeek.Thursday && !text.Equals("Thu")) || (dateTime_0.DayOfWeek == DayOfWeek.Friday && !text.Equals("Fri")) || (dateTime_0.DayOfWeek == DayOfWeek.Saturday && !text.Equals("Sat")) || (dateTime_0.DayOfWeek == DayOfWeek.Sunday && !text.Equals("Sun")))
			{
				DefaultLogger.Log.LogDebug("Day-name does not correspond to the weekday of the date: " + string_0);
			}
		}
	}

	static bool smethod_125(buClipper buClipper_0, Class153 class153_0, Class153 class153_1)
	{
		Class153 class153_2 = class153_0.class153_1;
		while (class153_2.intPoint_0 == class153_0.intPoint_0 && class153_2 != class153_0)
		{
			class153_2 = class153_2.class153_1;
		}
		IntPoint intPoint_ = class153_0.intPoint_0;
		IntPoint intPoint_2 = class153_2.intPoint_0;
		double num = Math.Abs(smethod_249(intPoint_2, buClipper_0, intPoint_));
		class153_2 = class153_0.class153_0;
		while (class153_2.intPoint_0 == class153_0.intPoint_0 && class153_2 != class153_0)
		{
			class153_2 = class153_2.class153_0;
		}
		intPoint_ = class153_0.intPoint_0;
		intPoint_2 = class153_2.intPoint_0;
		double num2 = Math.Abs(smethod_249(intPoint_2, buClipper_0, intPoint_));
		class153_2 = class153_1.class153_1;
		while (class153_2.intPoint_0 == class153_1.intPoint_0 && class153_2 != class153_1)
		{
			class153_2 = class153_2.class153_1;
		}
		intPoint_ = class153_1.intPoint_0;
		intPoint_2 = class153_2.intPoint_0;
		double num3 = Math.Abs(smethod_249(intPoint_2, buClipper_0, intPoint_));
		class153_2 = class153_1.class153_0;
		while (class153_2.intPoint_0 == class153_1.intPoint_0 && class153_2 != class153_1)
		{
			class153_2 = class153_2.class153_0;
		}
		intPoint_ = class153_1.intPoint_0;
		intPoint_2 = class153_2.intPoint_0;
		double num4 = Math.Abs(smethod_249(intPoint_2, buClipper_0, intPoint_));
		if (Math.Max(num, num2) != Math.Max(num3, num4) || Math.Min(num, num2) != Math.Min(num3, num4))
		{
			return (!(num < num3) && !(num < num4)) || (!(num2 < num3) && num2 >= num4);
		}
		return smethod_216(class153_0, buClipper_0) > 0.0;
	}

	static Class152 smethod_126(buClipper buClipper_0, Class152 class152_0, Class152 class152_1)
	{
		if (class152_0.class153_1 == null)
		{
			class152_0.class153_1 = smethod_88(class152_0.class153_0, buClipper_0);
		}
		if (class152_1.class153_1 == null)
		{
			class152_1.class153_1 = smethod_88(class152_1.class153_0, buClipper_0);
		}
		Class153 class153_ = class152_0.class153_1;
		Class153 class153_2 = class152_1.class153_1;
		if (class153_.intPoint_0.Y <= class153_2.intPoint_0.Y)
		{
			if (class153_.intPoint_0.Y >= class153_2.intPoint_0.Y)
			{
				if (class153_.intPoint_0.X >= class153_2.intPoint_0.X)
				{
					if (class153_.intPoint_0.X <= class153_2.intPoint_0.X)
					{
						if (class153_.class153_0 != class153_)
						{
							if (class153_2.class153_0 != class153_2)
							{
								if (!smethod_125(buClipper_0, class153_, class153_2))
								{
									return class152_1;
								}
								return class152_0;
							}
							return class152_0;
						}
						return class152_1;
					}
					return class152_1;
				}
				return class152_0;
			}
			return class152_1;
		}
		return class152_0;
	}

	static Contour smethod_127(int int_0, Contour contour_0)
	{
		if (int_0 >= 0 && int_0 < contour_0.list_0.Count)
		{
			return contour_0.list_0[int_0];
		}
		return null;
	}

	static long smethod_128(string string_0)
	{
		string_0 = string_0.ToUpperInvariant();
		if (!Class143.dictionary_0.ContainsKey(string_0))
		{
			throw new ArgumentException("illegal or unknown unit: \"" + string_0 + "\"", "unit");
		}
		return Class143.dictionary_0[string_0];
	}

	static void smethod_129(Class160.Class163 class163_0, int int_0)
	{
		if (class163_0.int_1++ == 32768)
		{
			throw new InvalidOperationException();
		}
		class163_0.byte_0[class163_0.int_0++] = (byte)int_0;
		class163_0.int_0 &= 32767;
	}

	static int smethod_130(Contour contour_0)
	{
		return contour_0.list_0.Count;
	}

	static double smethod_131(double double_0, double double_1, double double_2, buVector buVector_0, double double_3)
	{
		double num = Math.Atan2(double_3, double_1);
		double num2 = Math.Atan2(double_0, double_2);
		double num3;
		for (num3 = num2 - num; num3 > Math.PI; num3 -= Math.PI * 2.0)
		{
		}
		for (; num3 < -Math.PI; num3 += Math.PI * 2.0)
		{
		}
		return num3;
	}

	static bool smethod_132(IntPoint intPoint_0, IntPoint intPoint_1, IntPoint intPoint_2, IntPoint intPoint_3, bool bool_0)
	{
		if (!bool_0)
		{
			return (intPoint_1.Y - intPoint_2.Y) * (intPoint_0.X - intPoint_3.X) - (intPoint_1.X - intPoint_2.X) * (intPoint_0.Y - intPoint_3.Y) == 0L;
		}
		return Struct53.smethod_0(Struct53.smethod_2(intPoint_1.Y - intPoint_2.Y, intPoint_0.X - intPoint_3.X), Struct53.smethod_2(intPoint_1.X - intPoint_2.X, intPoint_0.Y - intPoint_3.Y));
	}

	static void smethod_133(buClipper buClipper_0)
	{
		for (int i = 0; i < buClipper_0.list_1.Count; i++)
		{
			smethod_276((buClipperBase)buClipper_0, i);
		}
		buClipper_0.list_1.Clear();
	}

	static void smethod_134(buClipper buClipper_0, long long_0)
	{
		Class151 @class = new Class151();
		@class.long_0 = long_0;
		if (buClipper_0.class151_0 != null)
		{
			if (long_0 >= buClipper_0.class151_0.long_0)
			{
				Class151 class151_ = buClipper_0.class151_0;
				while (class151_.class151_0 != null && long_0 >= class151_.class151_0.long_0)
				{
					class151_ = class151_.class151_0;
				}
				if (long_0 != class151_.long_0)
				{
					@class.class151_0 = class151_.class151_0;
					@class.class151_1 = class151_;
					if (class151_.class151_0 != null)
					{
						class151_.class151_0.class151_1 = @class;
					}
					class151_.class151_0 = @class;
				}
			}
			else
			{
				@class.class151_0 = buClipper_0.class151_0;
				@class.class151_1 = null;
				buClipper_0.class151_0 = @class;
			}
		}
		else
		{
			buClipper_0.class151_0 = @class;
			buClipper_0.class151_0.class151_0 = null;
			buClipper_0.class151_0.class151_1 = null;
		}
	}

	static void smethod_135(DTSweepContext dtsweepContext_0, DTSweepConstraint dtsweepConstraint_0, AdvancingFrontNode advancingFrontNode_0)
	{
		dtsweepContext_0.EdgeEvent.ConstrainedEdge = dtsweepConstraint_0;
		dtsweepContext_0.EdgeEvent.Right = dtsweepConstraint_0.P.X > dtsweepConstraint_0.Q.X;
		if (dtsweepContext_0.IsDebugEnabled)
		{
			dtsweepContext_0.DebugContext.PrimaryTriangle = advancingFrontNode_0.Triangle;
		}
		if (!smethod_181(advancingFrontNode_0.Triangle, dtsweepConstraint_0.P, dtsweepConstraint_0.Q))
		{
			smethod_227(dtsweepContext_0, (TriangulationConstraint)dtsweepConstraint_0, advancingFrontNode_0);
			TriangulationPoint p = dtsweepConstraint_0.P;
			TriangulationPoint q = dtsweepConstraint_0.Q;
			DelaunayTriangle triangle = advancingFrontNode_0.Triangle;
			TriangulationPoint q2 = dtsweepConstraint_0.Q;
			smethod_49(p, q2, dtsweepContext_0, triangle, q);
		}
	}

	static Dictionary<string, long> smethod_136()
	{
		return new Dictionary<string, long>
		{
			{ "", 1L },
			{ "B", 1L },
			{ "KB", 1024L },
			{ "MB", 1048576L },
			{ "GB", 1073741824L },
			{ "TB", 1099511627776L }
		};
	}

	static Class153 smethod_137(Class148 class148_0, buClipper buClipper_0)
	{
		Class152 @class = buClipper_0.list_1[class148_0.int_3];
		if (class148_0.enum11_0 != Enum11.const_0)
		{
			return @class.class153_0.class153_1;
		}
		return @class.class153_0;
	}

	static bool smethod_138(Class160.Class161 class161_0)
	{
		switch (class161_0.int_4)
		{
		case 12:
			return false;
		case 2:
			if (!class161_0.bool_0)
			{
				int num2 = smethod_292(class161_0.class162_0, 3);
				if (num2 >= 0)
				{
					smethod_94(class161_0.class162_0, 3);
					if ((num2 & 1) != 0)
					{
						class161_0.bool_0 = true;
					}
					switch (num2 >> 1)
					{
					case 2:
						class161_0.class165_0 = new Class160.Class165();
						class161_0.int_4 = 6;
						break;
					case 0:
						smethod_294(class161_0.class162_0);
						class161_0.int_4 = 3;
						break;
					case 1:
						class161_0.class164_0 = Class160.Class164.class164_0;
						class161_0.class164_1 = Class160.Class164.class164_1;
						class161_0.int_4 = 7;
						break;
					}
					return true;
				}
				return false;
			}
			class161_0.int_4 = 12;
			return false;
		case 3:
			if ((class161_0.int_8 = smethod_292(class161_0.class162_0, 16)) >= 0)
			{
				smethod_94(class161_0.class162_0, 16);
				class161_0.int_4 = 4;
				goto case 4;
			}
			return false;
		case 4:
			if (smethod_292(class161_0.class162_0, 16) >= 0)
			{
				smethod_94(class161_0.class162_0, 16);
				class161_0.int_4 = 5;
				goto case 5;
			}
			return false;
		case 5:
		{
			int num = smethod_219(class161_0.class163_0, class161_0.class162_0, class161_0.int_8);
			class161_0.int_8 -= num;
			if (class161_0.int_8 != 0)
			{
				return !smethod_252(class161_0.class162_0);
			}
			class161_0.int_4 = 2;
			return true;
		}
		case 6:
			if (smethod_83(class161_0.class165_0, class161_0.class162_0))
			{
				class161_0.class164_0 = smethod_29(class161_0.class165_0);
				class161_0.class164_1 = smethod_195(class161_0.class165_0);
				class161_0.int_4 = 7;
				goto case 7;
			}
			return false;
		case 7:
		case 8:
		case 9:
		case 10:
			return smethod_158(class161_0);
		default:
			return false;
		}
	}

	static Class153 smethod_139(buClipper buClipper_0, Class153 class153_0, bool bool_0)
	{
		Class153 @class = new Class153();
		@class.intPoint_0 = class153_0.intPoint_0;
		@class.int_0 = class153_0.int_0;
		if (!bool_0)
		{
			@class.class153_1 = class153_0.class153_1;
			@class.class153_0 = class153_0;
			class153_0.class153_1.class153_0 = @class;
			class153_0.class153_1 = @class;
		}
		else
		{
			@class.class153_0 = class153_0.class153_0;
			@class.class153_1 = class153_0;
			class153_0.class153_0.class153_1 = @class;
			class153_0.class153_0 = @class;
		}
		return @class;
	}

	static void smethod_140(double double_0, double double_1, ref double double_2, ref double double_3, short short_0, double double_4, buFile.Dxf dxf_0, double double_5, double double_6)
	{
		double x = 0.0;
		bool flag = false;
		if (double_6 < 0.0)
		{
			flag = true;
		}
		double num = (double_1 + double_0) / 2.0;
		double num2 = (double_4 + double_5) / 2.0;
		double_6 = Math.Abs(double_6);
		double num6;
		double num7;
		double num8;
		double num9;
		if (double_4 == double_5)
		{
			double num3 = Math.Sqrt(Math.Pow(double_5 - num2, 2.0) + Math.Pow(double_0 - num, 2.0));
			double num4 = (smethod_255(dxf_0, double_6, num3) ? 0.0 : Math.Sqrt(Math.Pow(double_6, 2.0) - Math.Pow(num3, 2.0)));
			double num5 = num4 / Math.Sqrt(Math.Pow(x, 2.0) + 1.0);
			num6 = num2 + num5;
			num7 = num2 - num5;
			num8 = num;
			num9 = num;
		}
		else
		{
			x = (double_1 - double_0) / (double_5 - double_4);
			double num3 = Math.Sqrt(Math.Pow(double_5 - num2, 2.0) + Math.Pow(double_0 - num, 2.0));
			double num4 = Math.Sqrt(Math.Pow(double_6, 2.0) - Math.Pow(num3, 2.0));
			double num5 = num4 / Math.Sqrt(Math.Pow(x, 2.0) + 1.0);
			num6 = num2 + x * num5;
			num7 = num2 - x * num5;
			num8 = num + num5;
			num9 = num - num5;
		}
		bool flag2 = false;
		double num10;
		double num11;
		double num12;
		double num13;
		if (short_0 == 2)
		{
			num10 = smethod_149(dxf_0, double_1, double_4, num8, num6);
			num11 = smethod_149(dxf_0, double_0, double_5, num8, num6);
			if (!flag)
			{
				if ((num11 > 180.0) & smethod_255(dxf_0, num10, 0.0))
				{
					num10 = 360.0;
				}
				if ((num10 < 180.0) & smethod_255(dxf_0, num11, 0.0))
				{
					num11 = 0.0;
				}
			}
			if ((!flag && num10 > num11) & ((num10 - num11 < 180.0) | smethod_255(dxf_0, num10 - num11, 180.0)))
			{
				double_3 = num8;
				double_2 = num6;
				dxf_0.double_0 = num10;
				dxf_0.double_1 = num11;
				flag2 = true;
			}
			if (flag && num10 > num11 && num10 - num11 > 180.0)
			{
				double_3 = num8;
				double_2 = num6;
				dxf_0.double_0 = num10;
				dxf_0.double_1 = num11;
				flag2 = true;
			}
			num12 = smethod_149(dxf_0, double_1, double_4, num9, num7);
			num13 = smethod_149(dxf_0, double_0, double_5, num9, num7);
			if (!flag)
			{
				if ((num13 > 180.0) & smethod_255(dxf_0, num12, 0.0))
				{
					num12 = 360.0;
				}
				if ((num12 < 180.0) & smethod_255(dxf_0, num13, 0.0))
				{
					num13 = 0.0;
				}
			}
			if ((!flag && num12 > num13) & ((num12 - num13 < 180.0) | smethod_255(dxf_0, num12 - num13, 180.0)))
			{
				double_3 = num9;
				double_2 = num7;
				dxf_0.double_0 = num12;
				dxf_0.double_1 = num13;
				flag2 = true;
			}
			if (flag && num12 > num13 && num12 - num13 > 180.0)
			{
				double_3 = num9;
				double_2 = num7;
				dxf_0.double_0 = num12;
				dxf_0.double_1 = num13;
				flag2 = true;
			}
			if (((!flag2 && !flag && num11 > num10) & ((num11 - num10 < 180.0) | smethod_255(dxf_0, num11 - num10, 180.0))) && ((num10 + 360.0 - num11 < 180.0) | smethod_255(dxf_0, num10 + 360.0 - num11, 180.0)))
			{
				dxf_0.double_0 = num10 + 360.0;
				dxf_0.double_1 = num11;
				double_3 = num8;
				double_2 = num6;
				flag2 = true;
			}
			if (!flag2 && flag && num11 > num10 && num10 + 360.0 - num11 > 180.0)
			{
				dxf_0.double_0 = num10 + 360.0;
				dxf_0.double_1 = num11;
				double_3 = num8;
				double_2 = num6;
				flag2 = true;
			}
			if (!flag2 && !flag && num13 > num12 && ((num12 + 360.0 - num13 < 180.0) | smethod_255(dxf_0, num12 + 360.0 - num13, 180.0)))
			{
				double_3 = num9;
				double_2 = num7;
				dxf_0.double_0 = num12 + 360.0;
				dxf_0.double_1 = num13;
				flag2 = true;
			}
			if (!flag2 && flag && num13 > num12 && num12 + 360.0 - num13 > 180.0)
			{
				double_3 = num9;
				double_2 = num7;
				dxf_0.double_0 = num12 + 360.0;
				dxf_0.double_1 = num13;
				flag2 = true;
			}
		}
		if (short_0 != 3)
		{
			return;
		}
		num10 = smethod_149(dxf_0, double_1, double_4, num8, num6);
		num11 = smethod_149(dxf_0, double_0, double_5, num8, num6);
		if (!flag)
		{
			if ((num10 > 180.0) & smethod_255(dxf_0, num11, 0.0))
			{
				num11 = 360.0;
			}
			if ((num11 < 180.0) & smethod_255(dxf_0, num10, 0.0))
			{
				num10 = 0.0;
			}
		}
		if ((!flag && num11 > num10) & ((num11 - num10 < 180.0) | smethod_255(dxf_0, num11 - num10, 180.0)))
		{
			double_3 = num8;
			double_2 = num6;
			dxf_0.double_0 = num10;
			dxf_0.double_1 = num11;
			flag2 = true;
		}
		if (flag && num11 > num10 && num11 - num10 > 180.0)
		{
			double_3 = num8;
			double_2 = num6;
			dxf_0.double_0 = num10;
			dxf_0.double_1 = num11;
			flag2 = true;
		}
		num12 = smethod_149(dxf_0, double_1, double_4, num9, num7);
		num13 = smethod_149(dxf_0, double_0, double_5, num9, num7);
		if (!flag)
		{
			if ((num12 > 180.0) & smethod_255(dxf_0, num13, 0.0))
			{
				num13 = 360.0;
			}
			if ((num13 < 180.0) & smethod_255(dxf_0, num12, 0.0))
			{
				num12 = 0.0;
			}
		}
		if ((!flag && num13 > num12) & ((num13 - num12 < 180.0) | smethod_255(dxf_0, num13 - num12, 180.0)))
		{
			double_3 = num9;
			double_2 = num7;
			dxf_0.double_0 = num12;
			dxf_0.double_1 = num13;
			flag2 = true;
		}
		if (flag && num13 > num12 && num13 - num12 > 180.0)
		{
			double_3 = num9;
			double_2 = num7;
			dxf_0.double_0 = num12;
			dxf_0.double_1 = num13;
			flag2 = true;
		}
		if (((!flag2 && !flag && num10 > num11) & ((num10 - num11 < 180.0) | smethod_255(dxf_0, num10 - num11, 180.0))) && ((num11 + 360.0 - num10 < 180.0) | smethod_255(dxf_0, num11 + 360.0 - num10, 180.0)))
		{
			dxf_0.double_0 = num10;
			dxf_0.double_1 = num11 + 360.0;
			double_3 = num8;
			double_2 = num6;
			flag2 = true;
		}
		if (!flag2 && flag && num10 > num11 && num11 + 360.0 - num10 > 180.0)
		{
			dxf_0.double_0 = num10;
			dxf_0.double_1 = num11 + 360.0;
			double_3 = num8;
			double_2 = num6;
			flag2 = true;
		}
		if (!flag2 && !flag && num12 > num13 && ((num13 + 360.0 - num12 < 180.0) | smethod_255(dxf_0, num13 + 360.0 - num12, 180.0)))
		{
			double_3 = num9;
			double_2 = num7;
			dxf_0.double_0 = num12;
			dxf_0.double_1 = num13 + 360.0;
			flag2 = true;
		}
		if (!flag2 && flag && num12 > num13 && num13 + 360.0 - num12 > 180.0)
		{
			double_3 = num9;
			double_2 = num7;
			dxf_0.double_0 = num12;
			dxf_0.double_1 = num13 + 360.0;
			flag2 = true;
		}
	}

	static void smethod_141(ClipperOffset clipperOffset_0, double double_0)
	{
		clipperOffset_0.list_0 = new List<List<IntPoint>>();
		clipperOffset_0.double_0 = double_0;
		if (!smethod_209(double_0))
		{
			if (!(clipperOffset_0.MiterLimit > 2.0))
			{
				clipperOffset_0.double_4 = 0.5;
			}
			else
			{
				clipperOffset_0.double_4 = 2.0 / (clipperOffset_0.MiterLimit * clipperOffset_0.MiterLimit);
			}
			double num = ((clipperOffset_0.ArcTolerance <= 0.0) ? 0.25 : ((clipperOffset_0.ArcTolerance > Math.Abs(double_0) * 0.25) ? (Math.Abs(double_0) * 0.25) : clipperOffset_0.ArcTolerance));
			double num2 = Math.PI / Math.Acos(1.0 - num / Math.Abs(double_0));
			clipperOffset_0.double_2 = Math.Sin(Math.PI * 2.0 / num2);
			clipperOffset_0.double_3 = Math.Cos(Math.PI * 2.0 / num2);
			clipperOffset_0.double_5 = num2 / (Math.PI * 2.0);
			if (double_0 < 0.0)
			{
				clipperOffset_0.double_2 = 0.0 - clipperOffset_0.double_2;
			}
			clipperOffset_0.list_0.Capacity = clipperOffset_0.polyNode_0.ChildCount * 2;
			for (int i = 0; i < clipperOffset_0.polyNode_0.ChildCount; i++)
			{
				PolyNode polyNode = clipperOffset_0.polyNode_0.Childs[i];
				clipperOffset_0.list_1 = polyNode.list_0;
				int count = clipperOffset_0.list_1.Count;
				if (count == 0 || (!(double_0 > 0.0) && (count < 3 || polyNode.endType_0 != EndType.etClosedPolygon)))
				{
					continue;
				}
				clipperOffset_0.list_2 = new List<IntPoint>();
				if (count != 1)
				{
					clipperOffset_0.list_3.Clear();
					clipperOffset_0.list_3.Capacity = count;
					for (int j = 0; j < count - 1; j++)
					{
						clipperOffset_0.list_3.Add(smethod_234(clipperOffset_0.list_1[j], clipperOffset_0.list_1[j + 1]));
					}
					if (polyNode.endType_0 != EndType.etClosedLine && polyNode.endType_0 != EndType.etClosedPolygon)
					{
						clipperOffset_0.list_3.Add(new DoublePoint(clipperOffset_0.list_3[count - 2]));
					}
					else
					{
						clipperOffset_0.list_3.Add(smethod_234(clipperOffset_0.list_1[count - 1], clipperOffset_0.list_1[0]));
					}
					if (polyNode.endType_0 != EndType.etClosedPolygon)
					{
						if (polyNode.endType_0 != EndType.etClosedLine)
						{
							int int_ = 0;
							for (int k = 1; k < count - 1; k++)
							{
								smethod_121(clipperOffset_0, k, ref int_, polyNode.joinType_0);
							}
							if (polyNode.endType_0 != EndType.etOpenButt)
							{
								int num3 = count - 1;
								int_ = count - 2;
								clipperOffset_0.double_1 = 0.0;
								clipperOffset_0.list_3[num3] = new DoublePoint(0.0 - clipperOffset_0.list_3[num3].X, 0.0 - clipperOffset_0.list_3[num3].Y);
								if (polyNode.endType_0 != EndType.etOpenSquare)
								{
									smethod_154(clipperOffset_0, num3, int_);
								}
								else
								{
									smethod_210(clipperOffset_0, num3, int_);
								}
							}
							else
							{
								int index = count - 1;
								IntPoint item = new IntPoint(smethod_150((double)clipperOffset_0.list_1[index].X + clipperOffset_0.list_3[index].X * double_0), smethod_150((double)clipperOffset_0.list_1[index].Y + clipperOffset_0.list_3[index].Y * double_0));
								clipperOffset_0.list_2.Add(item);
								item = new IntPoint(smethod_150((double)clipperOffset_0.list_1[index].X - clipperOffset_0.list_3[index].X * double_0), smethod_150((double)clipperOffset_0.list_1[index].Y - clipperOffset_0.list_3[index].Y * double_0));
								clipperOffset_0.list_2.Add(item);
							}
							for (int num4 = count - 1; num4 > 0; num4--)
							{
								clipperOffset_0.list_3[num4] = new DoublePoint(0.0 - clipperOffset_0.list_3[num4 - 1].X, 0.0 - clipperOffset_0.list_3[num4 - 1].Y);
							}
							clipperOffset_0.list_3[0] = new DoublePoint(0.0 - clipperOffset_0.list_3[1].X, 0.0 - clipperOffset_0.list_3[1].Y);
							int_ = count - 1;
							for (int num5 = int_ - 1; num5 > 0; num5--)
							{
								smethod_121(clipperOffset_0, num5, ref int_, polyNode.joinType_0);
							}
							if (polyNode.endType_0 != EndType.etOpenButt)
							{
								int_ = 1;
								clipperOffset_0.double_1 = 0.0;
								if (polyNode.endType_0 != EndType.etOpenSquare)
								{
									smethod_154(clipperOffset_0, 0, 1);
								}
								else
								{
									smethod_210(clipperOffset_0, 0, 1);
								}
							}
							else
							{
								IntPoint item = new IntPoint(smethod_150((double)clipperOffset_0.list_1[0].X - clipperOffset_0.list_3[0].X * double_0), smethod_150((double)clipperOffset_0.list_1[0].Y - clipperOffset_0.list_3[0].Y * double_0));
								clipperOffset_0.list_2.Add(item);
								item = new IntPoint(smethod_150((double)clipperOffset_0.list_1[0].X + clipperOffset_0.list_3[0].X * double_0), smethod_150((double)clipperOffset_0.list_1[0].Y + clipperOffset_0.list_3[0].Y * double_0));
								clipperOffset_0.list_2.Add(item);
							}
							clipperOffset_0.list_0.Add(clipperOffset_0.list_2);
						}
						else
						{
							int int_2 = count - 1;
							for (int l = 0; l < count; l++)
							{
								smethod_121(clipperOffset_0, l, ref int_2, polyNode.joinType_0);
							}
							clipperOffset_0.list_0.Add(clipperOffset_0.list_2);
							clipperOffset_0.list_2 = new List<IntPoint>();
							DoublePoint doublePoint = clipperOffset_0.list_3[count - 1];
							for (int num6 = count - 1; num6 > 0; num6--)
							{
								clipperOffset_0.list_3[num6] = new DoublePoint(0.0 - clipperOffset_0.list_3[num6 - 1].X, 0.0 - clipperOffset_0.list_3[num6 - 1].Y);
							}
							clipperOffset_0.list_3[0] = new DoublePoint(0.0 - doublePoint.X, 0.0 - doublePoint.Y);
							int_2 = 0;
							for (int num7 = count - 1; num7 >= 0; num7--)
							{
								smethod_121(clipperOffset_0, num7, ref int_2, polyNode.joinType_0);
							}
							clipperOffset_0.list_0.Add(clipperOffset_0.list_2);
						}
					}
					else
					{
						int int_3 = count - 1;
						for (int m = 0; m < count; m++)
						{
							smethod_121(clipperOffset_0, m, ref int_3, polyNode.joinType_0);
						}
						clipperOffset_0.list_0.Add(clipperOffset_0.list_2);
					}
					continue;
				}
				if (polyNode.joinType_0 != JoinType.jtRound)
				{
					double num8 = -1.0;
					double num9 = -1.0;
					for (int n = 0; n < 4; n++)
					{
						clipperOffset_0.list_2.Add(new IntPoint(smethod_150((double)clipperOffset_0.list_1[0].X + num8 * double_0), smethod_150((double)clipperOffset_0.list_1[0].Y + num9 * double_0)));
						if (!(num8 < 0.0))
						{
							if (!(num9 < 0.0))
							{
								num8 = -1.0;
							}
							else
							{
								num9 = 1.0;
							}
						}
						else
						{
							num8 = 1.0;
						}
					}
				}
				else
				{
					double num10 = 1.0;
					double num11 = 0.0;
					for (int num12 = 1; (double)num12 <= num2; num12++)
					{
						clipperOffset_0.list_2.Add(new IntPoint(smethod_150((double)clipperOffset_0.list_1[0].X + num10 * double_0), smethod_150((double)clipperOffset_0.list_1[0].Y + num11 * double_0)));
						double num13 = num10;
						num10 = num10 * clipperOffset_0.double_3 - clipperOffset_0.double_2 * num11;
						num11 = num13 * clipperOffset_0.double_2 + num11 * clipperOffset_0.double_3;
					}
				}
				clipperOffset_0.list_0.Add(clipperOffset_0.list_2);
			}
			return;
		}
		clipperOffset_0.list_0.Capacity = clipperOffset_0.polyNode_0.ChildCount;
		for (int num14 = 0; num14 < clipperOffset_0.polyNode_0.ChildCount; num14++)
		{
			PolyNode polyNode2 = clipperOffset_0.polyNode_0.Childs[num14];
			if (polyNode2.endType_0 == EndType.etClosedPolygon)
			{
				clipperOffset_0.list_0.Add(polyNode2.list_0);
			}
		}
	}

	static double smethod_142(buClipper buClipper_0, Class152 class152_0)
	{
		return smethod_216(class152_0.class153_0, buClipper_0);
	}

	static double smethod_143(IntPoint intPoint_0, IntPoint intPoint_1, IntPoint intPoint_2)
	{
		double num = intPoint_1.Y - intPoint_2.Y;
		double num2 = intPoint_2.X - intPoint_1.X;
		double num3 = num * (double)intPoint_1.X + num2 * (double)intPoint_1.Y;
		num3 = num * (double)intPoint_0.X + num2 * (double)intPoint_0.Y - num3;
		return num3 * num3 / (num * num + num2 * num2);
	}

	static void smethod_144(Pop3Client pop3Client_0, string string_0)
	{
		byte[] bytes = Encoding.ASCII.GetBytes(string_0 + "\r\n");
		pop3Client_0.method_0().Write(bytes, 0, bytes.Length);
		pop3Client_0.method_0().Flush();
		pop3Client_0.method_3(smethod_106(pop3Client_0.method_0()));
		smethod_98(pop3Client_0.method_2());
	}

	static void smethod_145(PolyTree polyTree_0, buClipper buClipper_0)
	{
		polyTree_0.Clear();
		polyTree_0.list_2.Capacity = buClipper_0.list_1.Count;
		for (int i = 0; i < buClipper_0.list_1.Count; i++)
		{
			Class152 @class = buClipper_0.list_1[i];
			int num = smethod_258(@class.class153_0, buClipper_0);
			if ((!@class.bool_1 || num >= 2) && (@class.bool_1 || num >= 3))
			{
				smethod_117(buClipper_0, @class);
				PolyNode polyNode = new PolyNode();
				polyTree_0.list_2.Add(polyNode);
				@class.polyNode_0 = polyNode;
				polyNode.list_0.Capacity = num;
				Class153 class153_ = @class.class153_0.class153_1;
				for (int j = 0; j < num; j++)
				{
					polyNode.list_0.Add(class153_.intPoint_0);
					class153_ = class153_.class153_1;
				}
			}
		}
		polyTree_0.list_1.Capacity = buClipper_0.list_1.Count;
		for (int k = 0; k < buClipper_0.list_1.Count; k++)
		{
			Class152 class2 = buClipper_0.list_1[k];
			if (class2.polyNode_0 == null)
			{
				continue;
			}
			if (!class2.bool_1)
			{
				if (class2.class152_0 == null || class2.class152_0.polyNode_0 == null)
				{
					smethod_212((PolyNode)polyTree_0, class2.polyNode_0);
				}
				else
				{
					smethod_212(class2.class152_0.polyNode_0, class2.polyNode_0);
				}
			}
			else
			{
				class2.polyNode_0.IsOpen = true;
				smethod_212((PolyNode)polyTree_0, class2.polyNode_0);
			}
		}
	}

	static Class148 smethod_146(buClipper buClipper_0, Class148 class148_0)
	{
		if (!(class148_0.class148_0.intPoint_2 == class148_0.intPoint_2) || class148_0.class148_0.class148_2 != null)
		{
			if (!(class148_0.class148_1.intPoint_2 == class148_0.intPoint_2) || class148_0.class148_1.class148_2 != null)
			{
				return null;
			}
			return class148_0.class148_1;
		}
		return class148_0.class148_0;
	}

	static string smethod_147(string string_0, ContentDisposition contentDisposition_0, ContentType contentType_0)
	{
		if (contentType_0 != null)
		{
			if (contentDisposition_0 == null || contentDisposition_0.FileName == null)
			{
				if (contentType_0.Name == null)
				{
					return string_0;
				}
				return contentType_0.Name;
			}
			return contentDisposition_0.FileName;
		}
		throw new ArgumentNullException("contentType");
	}

	static void smethod_148(Class160.Class164 class164_0, byte[] byte_0)
	{
		int[] array = new int[16];
		int[] array2 = new int[16];
		foreach (int num in byte_0)
		{
			if (num > 0)
			{
				array[num]++;
			}
		}
		int num2 = 0;
		int num3 = 512;
		for (int j = 1; j <= 15; j++)
		{
			array2[j] = num2;
			num2 += array[j] << 16 - j;
			if (j >= 10)
			{
				int num4 = array2[j] & 0x1FF80;
				int num5 = num2 & 0x1FF80;
				num3 += num5 - num4 >> 16 - j;
			}
		}
		class164_0.short_0 = new short[num3];
		int num6 = 512;
		for (int num7 = 15; num7 >= 10; num7--)
		{
			int num8 = num2 & 0x1FF80;
			num2 -= array[num7] << 16 - num7;
			for (int k = num2 & 0x1FF80; k < num8; k += 128)
			{
				class164_0.short_0[smethod_176(k)] = (short)((-num6 << 4) | num7);
				num6 += 1 << num7 - 9;
			}
		}
		for (int l = 0; l < byte_0.Length; l++)
		{
			int num9 = byte_0[l];
			if (num9 == 0)
			{
				continue;
			}
			num2 = array2[num9];
			int num10 = smethod_176(num2);
			if (num9 > 9)
			{
				int num11 = class164_0.short_0[num10 & 0x1FF];
				int num12 = 1 << (num11 & 0xF);
				num11 = -(num11 >> 4);
				do
				{
					class164_0.short_0[num11 | (num10 >> 9)] = (short)((l << 4) | num9);
					num10 += 1 << num9;
				}
				while (num10 < num12);
			}
			else
			{
				do
				{
					class164_0.short_0[num10] = (short)((l << 4) | num9);
					num10 += 1 << num9;
				}
				while (num10 < 512);
			}
			array2[num9] = num2 + (1 << 16 - num9);
		}
	}

	static double smethod_149(buFile.Dxf dxf_0, double double_0, double double_1, double double_2, double double_3)
	{
		double double_4 = 0.0;
		double double_5 = 0.0;
		double result = 0.0;
		double num = Math.Sqrt((double_0 - double_2) * (double_0 - double_2) + (double_1 - double_3) * (double_1 - double_3));
		if (num != 0.0)
		{
			double num2 = (double_0 - double_2) / num;
			double num3 = (double_1 - double_3) / num;
			if (!smethod_53(dxf_0, num2, 0.0, num3, 1.0))
			{
				if (!smethod_53(dxf_0, num2, -1.0, num3, 0.0))
				{
					if (!smethod_53(dxf_0, num2, 0.0, num3, -1.0))
					{
						if (!smethod_53(dxf_0, num2, 1.0, num3, 0.0))
						{
							if (num2 != 1.0 && num2 != -1.0)
							{
								double_4 = Math.Atan(num2 / Math.Sqrt(-1.0 * (num2 * num2) + 1.0)) + 1.5708;
							}
							if (num3 != 1.0 && num3 != -1.0)
							{
								double_5 = Math.Atan(num3 / Math.Sqrt(-1.0 * (num3 * num3) + 1.0));
							}
							if (num2 > 0.0 && num3 > 0.0 && num2 < 1.0 && num3 < 1.0)
							{
								result = 180.0 - smethod_193(double_4, dxf_0);
								_ = 90.0 - smethod_193(double_5, dxf_0);
							}
							if (num2 < 0.0 && num3 > 0.0 && num2 > -1.0 && num3 < 1.0)
							{
								result = 180.0 - smethod_193(double_4, dxf_0);
								_ = 90.0 - smethod_193(double_5, dxf_0);
							}
							if (num2 < 0.0 && num3 < 0.0 && num2 > -1.0 && num3 > -1.0)
							{
								result = 180.0 + smethod_193(double_4, dxf_0);
								_ = 270.0 + smethod_193(double_5, dxf_0);
							}
							if (num2 > 0.0 && num3 < 0.0 && num2 < 1.0 && num3 > -1.0)
							{
								result = 180.0 + smethod_193(double_4, dxf_0);
								_ = 270.0 + smethod_193(double_5, dxf_0);
							}
						}
						else
						{
							result = 0.0;
						}
					}
					else
					{
						result = 270.0;
					}
				}
				else
				{
					result = 180.0;
				}
			}
			else
			{
				result = 90.0;
			}
		}
		return result;
	}

	static long smethod_150(double double_0)
	{
		return (double_0 >= 0.0) ? ((long)(double_0 + 0.5)) : ((long)(double_0 - 0.5));
	}

	static buFile.PLYToSchematic.Class147 smethod_151(StreamReader streamReader_0, buFile.PLYToSchematic.Class146 class146_0)
	{
		buFile.PLYToSchematic.Class147 @class = new buFile.PLYToSchematic.Class147(class146_0.int_0, 10);
		string text;
		while ((text = streamReader_0.ReadLine()) != null)
		{
			string[] array = text.Split(' ');
			if (array.Length > 6)
			{
				try
				{
					float float_ = float.Parse(array[0], CultureInfo.InvariantCulture);
					float float_2 = float.Parse(array[1], CultureInfo.InvariantCulture);
					float float_3 = float.Parse(array[2], CultureInfo.InvariantCulture);
					byte byte_ = byte.Parse(array[6], CultureInfo.InvariantCulture);
					byte byte_2 = byte.Parse(array[7], CultureInfo.InvariantCulture);
					byte byte_3 = byte.Parse(array[8], CultureInfo.InvariantCulture);
					smethod_172(@class, float_, float_2, float_3, byte_, byte_2, byte_3);
				}
				catch (Exception ex)
				{
					Console.WriteLine("[ERROR] Line not well formated : " + text + " " + ex.Message);
				}
			}
		}
		return @class;
	}

	static void smethod_152(ClipperOffset clipperOffset_0)
	{
		if (clipperOffset_0.intPoint_0.X < 0L || buClipper.Orientation(clipperOffset_0.polyNode_0.Childs[(int)clipperOffset_0.intPoint_0.X].list_0))
		{
			for (int i = 0; i < clipperOffset_0.polyNode_0.ChildCount; i++)
			{
				PolyNode polyNode = clipperOffset_0.polyNode_0.Childs[i];
				if (polyNode.endType_0 == EndType.etClosedLine && !buClipper.Orientation(polyNode.list_0))
				{
					polyNode.list_0.Reverse();
				}
			}
			return;
		}
		for (int j = 0; j < clipperOffset_0.polyNode_0.ChildCount; j++)
		{
			PolyNode polyNode2 = clipperOffset_0.polyNode_0.Childs[j];
			if (polyNode2.endType_0 == EndType.etClosedPolygon || (polyNode2.endType_0 == EndType.etClosedLine && buClipper.Orientation(polyNode2.list_0)))
			{
				polyNode2.list_0.Reverse();
			}
		}
	}

	static int smethod_153(int int_0, byte[] byte_0, int int_1, Class160.Class163 class163_0)
	{
		int num = class163_0.int_0;
		if (int_0 <= class163_0.int_1)
		{
			num = (class163_0.int_0 - class163_0.int_1 + int_0) & 0x7FFF;
		}
		else
		{
			int_0 = class163_0.int_1;
		}
		int num2 = int_0;
		int num3 = int_0 - num;
		if (num3 > 0)
		{
			Array.Copy(class163_0.byte_0, 32768 - num3, byte_0, int_1, num3);
			int_1 += num3;
			int_0 = num;
		}
		Array.Copy(class163_0.byte_0, num - int_0, byte_0, int_1, int_0);
		class163_0.int_1 -= num2;
		if (class163_0.int_1 < 0)
		{
			throw new InvalidOperationException();
		}
		return num2;
	}

	static void smethod_154(ClipperOffset clipperOffset_0, int int_0, int int_1)
	{
		double value = Math.Atan2(clipperOffset_0.double_1, clipperOffset_0.list_3[int_1].X * clipperOffset_0.list_3[int_0].X + clipperOffset_0.list_3[int_1].Y * clipperOffset_0.list_3[int_0].Y);
		int num = Math.Max((int)smethod_150(clipperOffset_0.double_5 * Math.Abs(value)), 1);
		double num2 = clipperOffset_0.list_3[int_1].X;
		double num3 = clipperOffset_0.list_3[int_1].Y;
		for (int i = 0; i < num; i++)
		{
			clipperOffset_0.list_2.Add(new IntPoint(smethod_150((double)clipperOffset_0.list_1[int_0].X + num2 * clipperOffset_0.double_0), smethod_150((double)clipperOffset_0.list_1[int_0].Y + num3 * clipperOffset_0.double_0)));
			double num4 = num2;
			num2 = num2 * clipperOffset_0.double_3 - clipperOffset_0.double_2 * num3;
			num3 = num4 * clipperOffset_0.double_2 + num3 * clipperOffset_0.double_3;
		}
		clipperOffset_0.list_2.Add(new IntPoint(smethod_150((double)clipperOffset_0.list_1[int_0].X + clipperOffset_0.list_3[int_0].X * clipperOffset_0.double_0), smethod_150((double)clipperOffset_0.list_1[int_0].Y + clipperOffset_0.list_3[int_0].Y * clipperOffset_0.double_0)));
	}

	static void smethod_155(buClipper buClipper_0)
	{
		int num = 0;
		while (num < buClipper_0.list_1.Count)
		{
			Class152 @class = buClipper_0.list_1[num++];
			Class153 class153_ = @class.class153_0;
			if (class153_ == null || @class.bool_1)
			{
				continue;
			}
			do
			{
				for (Class153 class2 = class153_.class153_0; class2 != @class.class153_0; class2 = class2.class153_0)
				{
					if (class153_.intPoint_0 == class2.intPoint_0 && class2.class153_0 != class153_ && class2.class153_1 != class153_)
					{
						Class153 class153_2 = class153_.class153_1;
						(class153_.class153_1 = class2.class153_1).class153_0 = class153_;
						class2.class153_1 = class153_2;
						class153_2.class153_0 = class2;
						@class.class153_0 = class153_;
						Class152 class3 = smethod_185((buClipperBase)buClipper_0);
						class3.class153_0 = class2;
						smethod_7(class3, buClipper_0);
						if (!smethod_167(class3.class153_0, @class.class153_0))
						{
							if (!smethod_167(@class.class153_0, class3.class153_0))
							{
								class3.bool_0 = @class.bool_0;
								class3.class152_0 = @class.class152_0;
								if (buClipper_0.bool_4)
								{
									buClipper_0.method_1(@class, class3);
								}
							}
							else
							{
								class3.bool_0 = @class.bool_0;
								@class.bool_0 = !class3.bool_0;
								class3.class152_0 = @class.class152_0;
								@class.class152_0 = class3;
								if (buClipper_0.bool_4)
								{
									buClipper_0.method_2(@class, class3);
								}
							}
						}
						else
						{
							class3.bool_0 = !@class.bool_0;
							class3.class152_0 = @class;
							if (buClipper_0.bool_4)
							{
								buClipper_0.method_2(class3, @class);
							}
						}
						class2 = class153_;
					}
				}
				class153_ = class153_.class153_0;
			}
			while (class153_ != @class.class153_0);
		}
	}

	static bool smethod_156(ref TriangulationPoint triangulationPoint_0, Point2D point2D_0, DelaunayTriangle delaunayTriangle_0, TriangulationPoint triangulationPoint_1, [Out] Point2D point2D_1)
	{
		triangulationPoint_0 = null;
		switch (TriangulationUtil.Orient2d(point2D_1, triangulationPoint_1, point2D_0))
		{
		case Orientation.Collinear:
			return false;
		default:
			throw new NotImplementedException("Orientation not handled");
		case Orientation.Clockwise:
			triangulationPoint_0 = delaunayTriangle_0.PointCCWFrom(triangulationPoint_1);
			return true;
		case Orientation.AntiClockwise:
			triangulationPoint_0 = delaunayTriangle_0.PointCWFrom(triangulationPoint_1);
			return true;
		}
	}

	static void smethod_157(TriangulationConstraint triangulationConstraint_0, AdvancingFrontNode advancingFrontNode_0, DTSweepContext dtsweepContext_0)
	{
		if (TriangulationUtil.Orient2d(advancingFrontNode_0.Next.Point, advancingFrontNode_0.Next.Next.Point, advancingFrontNode_0.Next.Next.Next.Point) != Orientation.AntiClockwise)
		{
			if (TriangulationUtil.Orient2d(triangulationConstraint_0.Q, advancingFrontNode_0.Next.Next.Point, triangulationConstraint_0.P) == Orientation.AntiClockwise)
			{
				smethod_157(triangulationConstraint_0, advancingFrontNode_0.Next, dtsweepContext_0);
			}
		}
		else
		{
			smethod_123(triangulationConstraint_0, advancingFrontNode_0.Next, dtsweepContext_0);
		}
	}

	static bool smethod_158(Class160.Class161 class161_0)
	{
		int num = smethod_231(class161_0.class163_0);
		while (num >= 258)
		{
			switch (class161_0.int_4)
			{
			case 10:
				if (class161_0.int_5 > 0)
				{
					class161_0.int_4 = 10;
					int num3 = smethod_292(class161_0.class162_0, class161_0.int_5);
					if (num3 < 0)
					{
						return false;
					}
					smethod_94(class161_0.class162_0, class161_0.int_5);
					class161_0.int_7 += num3;
				}
				smethod_33(class161_0.class163_0, class161_0.int_6, class161_0.int_7);
				num -= class161_0.int_6;
				class161_0.int_4 = 7;
				break;
			case 7:
			{
				int num2;
				while (((num2 = smethod_266(class161_0.class164_0, class161_0.class162_0)) & -256) == 0)
				{
					smethod_129(class161_0.class163_0, num2);
					if (--num < 258)
					{
						return true;
					}
				}
				if (num2 >= 257)
				{
					class161_0.int_6 = Class160.Class161.int_0[num2 - 257];
					class161_0.int_5 = Class160.Class161.int_1[num2 - 257];
					goto case 8;
				}
				if (num2 >= 0)
				{
					class161_0.class164_1 = null;
					class161_0.class164_0 = null;
					class161_0.int_4 = 2;
					return true;
				}
				return false;
			}
			case 8:
				if (class161_0.int_5 > 0)
				{
					class161_0.int_4 = 8;
					int num4 = smethod_292(class161_0.class162_0, class161_0.int_5);
					if (num4 < 0)
					{
						return false;
					}
					smethod_94(class161_0.class162_0, class161_0.int_5);
					class161_0.int_6 += num4;
				}
				class161_0.int_4 = 9;
				goto case 9;
			case 9:
			{
				int num2 = smethod_266(class161_0.class164_1, class161_0.class162_0);
				if (num2 >= 0)
				{
					class161_0.int_7 = Class160.Class161.int_2[num2];
					class161_0.int_5 = Class160.Class161.int_3[num2];
					goto case 10;
				}
				return false;
			}
			}
		}
		return true;
	}

	static void smethod_159(buClipper buClipper_0, long long_0)
	{
		Class149 class149_ = default(Class149);
		while (smethod_228((buClipperBase)buClipper_0, long_0, ref class149_))
		{
			Class148 class148_ = class149_.class148_0;
			Class148 class148_2 = class149_.class148_1;
			Class153 @class = null;
			if (class148_ != null)
			{
				if (class148_2 != null)
				{
					smethod_47((Class148)null, buClipper_0, class148_);
					smethod_47(class148_, buClipper_0, class148_2);
					smethod_168(class148_, buClipper_0);
					class148_2.int_1 = class148_.int_1;
					class148_2.int_2 = class148_.int_2;
					if (smethod_161(class148_, buClipper_0))
					{
						@class = smethod_230(buClipper_0, class148_, class148_2, class148_.intPoint_0);
					}
					smethod_232((buClipperBase)buClipper_0, class148_.intPoint_2.Y);
				}
				else
				{
					smethod_47((Class148)null, buClipper_0, class148_);
					smethod_168(class148_, buClipper_0);
					if (smethod_161(class148_, buClipper_0))
					{
						@class = smethod_246(buClipper_0, class148_, class148_.intPoint_0);
					}
					smethod_232((buClipperBase)buClipper_0, class148_.intPoint_2.Y);
				}
			}
			else
			{
				smethod_47((Class148)null, buClipper_0, class148_2);
				smethod_168(class148_2, buClipper_0);
				if (smethod_161(class148_2, buClipper_0))
				{
					@class = smethod_246(buClipper_0, class148_2, class148_2.intPoint_0);
				}
			}
			if (class148_2 != null)
			{
				if (!smethod_67(class148_2))
				{
					smethod_232((buClipperBase)buClipper_0, class148_2.intPoint_2.Y);
				}
				else
				{
					if (class148_2.class148_2 != null)
					{
						smethod_232((buClipperBase)buClipper_0, class148_2.class148_2.intPoint_2.Y);
					}
					smethod_11(buClipper_0, class148_2);
				}
			}
			if (class148_ == null || class148_2 == null)
			{
				continue;
			}
			if (@class != null && smethod_67(class148_2) && buClipper_0.list_4.Count > 0 && class148_2.int_0 != 0)
			{
				for (int i = 0; i < buClipper_0.list_4.Count; i++)
				{
					Class154 class2 = buClipper_0.list_4[i];
					long x = class2.class153_0.intPoint_0.X;
					long x2 = class2.intPoint_0.X;
					long x3 = class148_2.intPoint_0.X;
					long x4 = class148_2.intPoint_2.X;
					if (smethod_97(x4, buClipper_0, x2, x, x3))
					{
						Class153 class153_ = class2.class153_0;
						IntPoint intPoint_ = class2.intPoint_0;
						smethod_22(intPoint_, @class, class153_, buClipper_0);
					}
				}
			}
			if (class148_.int_3 >= 0 && class148_.class148_4 != null && class148_.class148_4.intPoint_1.X == class148_.intPoint_0.X && class148_.class148_4.int_3 >= 0)
			{
				IntPoint intPoint_2 = class148_.class148_4.intPoint_1;
				IntPoint intPoint_3 = class148_.class148_4.intPoint_2;
				IntPoint intPoint_4 = class148_.intPoint_1;
				IntPoint intPoint_5 = class148_.intPoint_2;
				bool bool_ = buClipper_0.bool_0;
				if (smethod_132(intPoint_4, intPoint_2, intPoint_3, intPoint_5, bool_) && class148_.int_0 != 0 && class148_.class148_4.int_0 != 0)
				{
					Class153 class153_2 = smethod_246(buClipper_0, class148_.class148_4, class148_.intPoint_0);
					smethod_22(class148_.intPoint_2, class153_2, @class, buClipper_0);
				}
			}
			if (class148_.class148_3 == class148_2)
			{
				continue;
			}
			if (class148_2.int_3 >= 0 && class148_2.class148_4.int_3 >= 0)
			{
				IntPoint intPoint_2 = class148_2.class148_4.intPoint_1;
				IntPoint intPoint_3 = class148_2.class148_4.intPoint_2;
				IntPoint intPoint_4 = class148_2.intPoint_1;
				IntPoint intPoint_5 = class148_2.intPoint_2;
				bool bool_ = buClipper_0.bool_0;
				if (smethod_132(intPoint_4, intPoint_2, intPoint_3, intPoint_5, bool_) && class148_2.int_0 != 0 && class148_2.class148_4.int_0 != 0)
				{
					Class153 class153_3 = smethod_246(buClipper_0, class148_2.class148_4, class148_2.intPoint_0);
					smethod_22(class148_2.intPoint_2, class153_3, @class, buClipper_0);
				}
			}
			Class148 class148_3 = class148_.class148_3;
			if (class148_3 != null)
			{
				while (class148_3 != class148_2)
				{
					smethod_287(class148_.intPoint_1, buClipper_0, class148_2, class148_3);
					class148_3 = class148_3.class148_3;
				}
			}
		}
	}

	static AdvancingFrontNode smethod_160(DTSweepContext dtsweepContext_0, TriangulationPoint triangulationPoint_0, AdvancingFrontNode advancingFrontNode_0)
	{
		DelaunayTriangle delaunayTriangle = new DelaunayTriangle(triangulationPoint_0, advancingFrontNode_0.Point, advancingFrontNode_0.Next.Point);
		delaunayTriangle.MarkNeighbor(advancingFrontNode_0.Triangle);
		dtsweepContext_0.Triangles.Add(delaunayTriangle);
		AdvancingFrontNode advancingFrontNode = new AdvancingFrontNode(triangulationPoint_0)
		{
			Next = advancingFrontNode_0.Next,
			Prev = advancingFrontNode_0
		};
		advancingFrontNode_0.Next.Prev = advancingFrontNode;
		advancingFrontNode_0.Next = advancingFrontNode;
		if (dtsweepContext_0.IsDebugEnabled)
		{
			dtsweepContext_0.DebugContext.ActiveNode = advancingFrontNode;
		}
		if (!smethod_226(dtsweepContext_0, delaunayTriangle))
		{
			dtsweepContext_0.MapTriangleToNodes(delaunayTriangle);
		}
		return advancingFrontNode;
	}

	static bool smethod_161(Class148 class148_0, buClipper buClipper_0)
	{
		PolyFillType polyFillType;
		PolyFillType polyFillType2;
		if (class148_0.polyType_0 != PolyType.ptSubject)
		{
			polyFillType = buClipper_0.polyFillType_0;
			polyFillType2 = buClipper_0.polyFillType_1;
		}
		else
		{
			polyFillType = buClipper_0.polyFillType_1;
			polyFillType2 = buClipper_0.polyFillType_0;
		}
		switch (polyFillType)
		{
		case PolyFillType.pftPositive:
			if (class148_0.int_1 != 1)
			{
				return false;
			}
			goto IL_0042;
		default:
			if (class148_0.int_1 != -1)
			{
				return false;
			}
			goto IL_0042;
		case PolyFillType.pftEvenOdd:
			if (class148_0.int_0 == 0 && class148_0.int_1 != 1)
			{
				return false;
			}
			goto IL_0042;
		case PolyFillType.pftNonZero:
			{
				if (Math.Abs(class148_0.int_1) != 1)
				{
					return false;
				}
				goto IL_0042;
			}
			IL_0042:
			switch (buClipper_0.clipType_0)
			{
			case ClipType.ctXor:
				if (class148_0.int_0 != 0)
				{
					return true;
				}
				switch (polyFillType2)
				{
				case PolyFillType.pftEvenOdd:
				case PolyFillType.pftNonZero:
					return class148_0.int_2 == 0;
				case PolyFillType.pftPositive:
					return class148_0.int_2 <= 0;
				default:
					return class148_0.int_2 >= 0;
				}
			default:
				return true;
			case ClipType.ctIntersection:
				switch (polyFillType2)
				{
				case PolyFillType.pftEvenOdd:
				case PolyFillType.pftNonZero:
					return class148_0.int_2 != 0;
				case PolyFillType.pftPositive:
					return class148_0.int_2 > 0;
				default:
					return class148_0.int_2 < 0;
				}
			case ClipType.ctUnion:
				switch (polyFillType2)
				{
				case PolyFillType.pftEvenOdd:
				case PolyFillType.pftNonZero:
					return class148_0.int_2 == 0;
				case PolyFillType.pftPositive:
					return class148_0.int_2 <= 0;
				default:
					return class148_0.int_2 >= 0;
				}
			case ClipType.ctDifference:
				if (class148_0.polyType_0 != PolyType.ptSubject)
				{
					switch (polyFillType2)
					{
					case PolyFillType.pftEvenOdd:
					case PolyFillType.pftNonZero:
						return class148_0.int_2 != 0;
					case PolyFillType.pftPositive:
						return class148_0.int_2 > 0;
					default:
						return class148_0.int_2 < 0;
					}
				}
				switch (polyFillType2)
				{
				case PolyFillType.pftEvenOdd:
				case PolyFillType.pftNonZero:
					return class148_0.int_2 == 0;
				case PolyFillType.pftPositive:
					return class148_0.int_2 <= 0;
				default:
					return class148_0.int_2 >= 0;
				}
			}
		}
	}

	static void smethod_162(DelaunayTriangle delaunayTriangle_0)
	{
		TriangulationPoint value = delaunayTriangle_0.Points[2];
		delaunayTriangle_0.Points[2] = delaunayTriangle_0.Points[1];
		delaunayTriangle_0.Points[1] = delaunayTriangle_0.Points[0];
		delaunayTriangle_0.Points[0] = value;
	}

	static void smethod_163(buClipper buClipper_0)
	{
		Class148 class148_ = default(Class148);
		while (smethod_298(buClipper_0, ref class148_))
		{
			smethod_211(buClipper_0, class148_);
		}
	}

	static void smethod_164(Class148 class148_0, Class148 class148_1)
	{
		Enum11 enum11_ = class148_0.enum11_0;
		class148_0.enum11_0 = class148_1.enum11_0;
		class148_1.enum11_0 = enum11_;
	}

	static KeyValuePair<string, string> smethod_165(string string_0)
	{
		if (string_0 != null)
		{
			string key = string.Empty;
			string value = string.Empty;
			int num = string_0.IndexOf(':');
			if (num >= 0 && string_0.Length >= num + 1)
			{
				key = string_0.Substring(0, num).Trim();
				value = string_0.Substring(num + 1).Trim();
			}
			return new KeyValuePair<string, string>(key, value);
		}
		throw new ArgumentNullException("rawHeader");
	}

	static string smethod_166(string string_0)
	{
		if (string_0 == null)
		{
			throw new ArgumentNullException("input");
		}
		string_0 = smethod_115(string_0);
		return Regex.Replace(string_0, "[\0-\b\v\f\u000e-\u001f\u007f]", "");
	}

	static bool smethod_167(Class153 class153_0, Class153 class153_1)
	{
		Class153 @class = class153_0;
		int num;
		while (true)
		{
			num = smethod_248(class153_1, @class.intPoint_0);
			if (num < 0)
			{
				@class = @class.class153_0;
				if (@class == class153_0)
				{
					return true;
				}
				continue;
			}
			break;
		}
		return num > 0;
	}

	static void smethod_168(Class148 class148_0, buClipper buClipper_0)
	{
		Class148 class148_1 = class148_0.class148_4;
		while (class148_1 != null && (class148_1.polyType_0 != class148_0.polyType_0 || class148_1.int_0 == 0))
		{
			class148_1 = class148_1.class148_4;
		}
		if (class148_1 != null)
		{
			if (class148_0.int_0 != 0 || buClipper_0.clipType_0 == ClipType.ctUnion)
			{
				if (!smethod_273(buClipper_0, class148_0))
				{
					if (class148_1.int_1 * class148_1.int_0 >= 0)
					{
						if (class148_0.int_0 != 0)
						{
							if (class148_1.int_0 * class148_0.int_0 >= 0)
							{
								class148_0.int_1 = class148_1.int_1 + class148_0.int_0;
							}
							else
							{
								class148_0.int_1 = class148_1.int_1;
							}
						}
						else
						{
							class148_0.int_1 = ((class148_1.int_1 >= 0) ? (class148_1.int_1 + 1) : (class148_1.int_1 - 1));
						}
					}
					else if (Math.Abs(class148_1.int_1) <= 1)
					{
						class148_0.int_1 = ((class148_0.int_0 == 0) ? 1 : class148_0.int_0);
					}
					else if (class148_1.int_0 * class148_0.int_0 >= 0)
					{
						class148_0.int_1 = class148_1.int_1 + class148_0.int_0;
					}
					else
					{
						class148_0.int_1 = class148_1.int_1;
					}
					class148_0.int_2 = class148_1.int_2;
					class148_1 = class148_1.class148_3;
				}
				else
				{
					if (class148_0.int_0 != 0)
					{
						class148_0.int_1 = class148_0.int_0;
					}
					else
					{
						bool flag = true;
						for (Class148 class148_2 = class148_1.class148_4; class148_2 != null; class148_2 = class148_2.class148_4)
						{
							if (class148_2.polyType_0 == class148_1.polyType_0 && class148_2.int_0 != 0)
							{
								flag = !flag;
							}
						}
						class148_0.int_1 = ((!flag) ? 1 : 0);
					}
					class148_0.int_2 = class148_1.int_2;
					class148_1 = class148_1.class148_3;
				}
			}
			else
			{
				class148_0.int_1 = 1;
				class148_0.int_2 = class148_1.int_2;
				class148_1 = class148_1.class148_3;
			}
		}
		else
		{
			PolyFillType polyFillType = ((class148_0.polyType_0 != PolyType.ptSubject) ? buClipper_0.polyFillType_0 : buClipper_0.polyFillType_1);
			if (class148_0.int_0 != 0)
			{
				class148_0.int_1 = class148_0.int_0;
			}
			else
			{
				class148_0.int_1 = ((polyFillType != PolyFillType.pftNegative) ? 1 : (-1));
			}
			class148_0.int_2 = 0;
			class148_1 = buClipper_0.class148_0;
		}
		if (!smethod_81(buClipper_0, class148_0))
		{
			while (class148_1 != class148_0)
			{
				class148_0.int_2 += class148_1.int_0;
				class148_1 = class148_1.class148_3;
			}
			return;
		}
		while (class148_1 != class148_0)
		{
			if (class148_1.int_0 != 0)
			{
				class148_0.int_2 = ((class148_0.int_2 == 0) ? 1 : 0);
			}
			class148_1 = class148_1.class148_3;
		}
	}

	static MessagePart smethod_169(byte[] byte_0)
	{
		byte[] byte_1 = default(byte[]);
		smethod_191(ref byte_1, out MessageHeader messageHeader_, byte_0);
		return new MessagePart(byte_1, messageHeader_);
	}

	static string smethod_170(string string_0, Encoding encoding_0)
	{
		if (string_0 != null)
		{
			if (encoding_0 == null)
			{
				throw new ArgumentNullException("encoding");
			}
			return encoding_0.GetString(smethod_297(string_0, true));
		}
		throw new ArgumentNullException("toDecode");
	}

	static void smethod_171(int int_0, Class160.Class162 class162_0, int int_1, byte[] byte_0)
	{
		if (class162_0.int_0 >= class162_0.int_1)
		{
			int num = int_0 + int_1;
			if (0 > int_0 || int_0 > num || num > byte_0.Length)
			{
				throw new ArgumentOutOfRangeException();
			}
			if ((int_1 & 1) != 0)
			{
				class162_0.uint_0 |= (uint)((byte_0[int_0++] & 0xFF) << class162_0.int_2);
				class162_0.int_2 += 8;
			}
			class162_0.byte_0 = byte_0;
			class162_0.int_0 = int_0;
			class162_0.int_1 = num;
			return;
		}
		throw new InvalidOperationException();
	}

	static void smethod_172(buFile.PLYToSchematic.Class147 class147_0, float float_0, float float_1, float float_2, byte byte_0, byte byte_1, byte byte_2)
	{
		class147_0.list_0.Add(new Pnt3D(float_0, float_1, float_2));
		class147_0.list_2.Add(Color.FromArgb(byte_0, byte_1, byte_2));
	}

	static int smethod_173(Class160.Class162 class162_0, byte[] byte_0, int int_0, int int_1)
	{
		int num = 0;
		while (class162_0.int_2 > 0 && int_1 > 0)
		{
			byte_0[int_0++] = (byte)class162_0.uint_0;
			class162_0.uint_0 >>= 8;
			class162_0.int_2 -= 8;
			int_1--;
			num++;
		}
		if (int_1 != 0)
		{
			int num2 = class162_0.int_1 - class162_0.int_0;
			if (int_1 > num2)
			{
				int_1 = num2;
			}
			Array.Copy(class162_0.byte_0, class162_0.int_0, byte_0, int_0, int_1);
			class162_0.int_0 += int_1;
			if (((class162_0.int_0 - class162_0.int_1) & 1) != 0)
			{
				class162_0.uint_0 = (uint)(class162_0.byte_0[class162_0.int_0++] & 0xFF);
				class162_0.int_2 = 8;
			}
			return num + int_1;
		}
		return num;
	}

	static string smethod_174(int int_0)
	{
		int index = int_0;
		int num = Class158.byte_0[index++];
		int num2;
		if ((num & 0x80) != 0)
		{
			num2 = (((num & 0x40) == 0) ? (((num & 0x3F) << 8) + Class158.byte_0[index++]) : (((num & 0x1F) << 24) + (Class158.byte_0[index++] << 16) + (Class158.byte_0[index++] << 8) + Class158.byte_0[index++]));
		}
		else
		{
			num2 = num;
			if (num2 == 0)
			{
				return string.Empty;
			}
		}
		try
		{
			byte[] array = Convert.FromBase64String(Encoding.UTF8.GetString(Class158.byte_0, index, num2));
			string text = string.Intern(Encoding.UTF8.GetString(array, 0, array.Length));
			if (Class158.bool_0)
			{
				smethod_64(text, int_0);
			}
			return text;
		}
		catch
		{
			return null;
		}
	}

	static AdvancingFrontNode smethod_175(AdvancingFront advancingFront_0, double double_0)
	{
		AdvancingFrontNode advancingFrontNode = advancingFront_0.head;
		if (!(double_0 < advancingFrontNode.Value))
		{
			while ((advancingFrontNode = advancingFrontNode.Next) != null)
			{
				if (double_0 < advancingFrontNode.Value)
				{
					advancingFront_0.head = advancingFrontNode.Prev;
					return advancingFrontNode.Prev;
				}
			}
		}
		else
		{
			while ((advancingFrontNode = advancingFrontNode.Prev) != null)
			{
				if (double_0 >= advancingFrontNode.Value)
				{
					advancingFront_0.head = advancingFrontNode;
					return advancingFrontNode;
				}
			}
		}
		return null;
	}

	static short smethod_176(int int_0)
	{
		return (short)((Class160.Class166.byte_0[int_0 & 0xF] << 12) | (Class160.Class166.byte_0[(int_0 >> 4) & 0xF] << 8) | (Class160.Class166.byte_0[(int_0 >> 8) & 0xF] << 4) | Class160.Class166.byte_0[int_0 >> 12]);
	}

	static int smethod_177(Class160.Class163 class163_0)
	{
		return class163_0.int_1;
	}

	static byte[] smethod_178(ContentTransferEncoding contentTransferEncoding_0, byte[] byte_0)
	{
		if (byte_0 != null)
		{
			switch (contentTransferEncoding_0)
			{
			case ContentTransferEncoding.SevenBit:
			case ContentTransferEncoding.EightBit:
			case ContentTransferEncoding.Binary:
				return byte_0;
			default:
				throw new ArgumentOutOfRangeException("contentTransferEncoding");
			case ContentTransferEncoding.QuotedPrintable:
				return smethod_275(Encoding.ASCII.GetString(byte_0));
			case ContentTransferEncoding.Base64:
				return smethod_87(Encoding.ASCII.GetString(byte_0));
			}
		}
		throw new ArgumentNullException("messageBody");
	}

	static string smethod_179(string string_0)
	{
		if (string_0 != null)
		{
			string_0 = Regex.Replace(string_0, "(?<first>\\=\\?(?<Charset>\\S+?)\\?(?<Encoding>\\w)\\?(?<Content>.+?)\\?\\=)\\s+(?<second>\\=\\?(?<Charset>\\S+?)\\?(?<Encoding>\\w)\\?(?<Content>.+?)\\?\\=)", "${first}${second}");
			string_0 = Regex.Replace(string_0, "(?<first>\\=\\?(?<Charset>\\S+?)\\?(?<Encoding>\\w)\\?(?<Content>.+?)\\?\\=)\\s+(?<second>\\=\\?(?<Charset>\\S+?)\\?(?<Encoding>\\w)\\?(?<Content>.+?)\\?\\=)", "${first}${second}");
			string text = string_0;
			MatchCollection matchCollection = Regex.Matches(string_0, "\\=\\?(?<Charset>\\S+?)\\?(?<Encoding>\\w)\\?(?<Content>.+?)\\?\\=");
			foreach (Match item in matchCollection)
			{
				if (!item.Success)
				{
					continue;
				}
				string value = item.Value;
				string value2 = item.Groups["Content"].Value;
				string value3 = item.Groups["Encoding"].Value;
				string value4 = item.Groups["Charset"].Value;
				Encoding encoding_ = smethod_224(value4);
				string text2 = value3.ToUpperInvariant();
				string text3 = text2;
				string newValue;
				if (text3 == "B")
				{
					newValue = smethod_30(value2, encoding_);
				}
				else
				{
					if (!(text3 == "Q"))
					{
						throw new ArgumentException("The encoding " + value3 + " was not recognized");
					}
					newValue = smethod_170(value2, encoding_);
				}
				text = text.Replace(value, newValue);
			}
			return text;
		}
		throw new ArgumentNullException("encodedWords");
	}

	static byte[] smethod_180(string string_0)
	{
		if (string_0 != null)
		{
			if (string_0.Length == 3)
			{
				if (string_0[0] == '=')
				{
					if (!string_0.Contains("\r\n"))
					{
						try
						{
							string value = string_0.Substring(1);
							return new byte[1] { Convert.ToByte(value, 16) };
						}
						catch (FormatException)
						{
							return Encoding.ASCII.GetBytes(string_0);
						}
					}
					return new byte[0];
				}
				throw new ArgumentException("decode must start with an equal sign", "decode");
			}
			throw new ArgumentException("decode must have length 3", "decode");
		}
		throw new ArgumentNullException("decode");
	}

	static bool smethod_181(DelaunayTriangle delaunayTriangle_0, TriangulationPoint triangulationPoint_0, TriangulationPoint triangulationPoint_1)
	{
		int num = delaunayTriangle_0.EdgeIndex(triangulationPoint_0, triangulationPoint_1);
		if (num != -1)
		{
			delaunayTriangle_0.MarkConstrainedEdge(num);
			delaunayTriangle_0 = delaunayTriangle_0.Neighbors[num];
			delaunayTriangle_0?.MarkConstrainedEdge(triangulationPoint_0, triangulationPoint_1);
			return true;
		}
		return false;
	}

	static bool smethod_182(string string_0, string string_1, List<string> list_0, List<string> list_1, List<double> list_2)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		if (!((list_1.Count > 0) & (list_0.Count > 0)))
		{
			throw new RegisterException(string_0);
		}
		for (int i = 0; i <= list_1.Count - 1; i++)
		{
			num = 0.0;
			num2 = 0.0;
			num3 = 0.0;
			for (int j = 0; j <= list_1[i].Length - 1; j++)
			{
				string value = list_1[i].Substring(j, 1);
				double num5 = (int)Convert.ToByte(Convert.ToChar(value));
				num += num5 * 17.92;
			}
			for (int k = 0; k <= list_0[0].Length - 1; k++)
			{
				string value2 = list_0[0].Substring(k, 1);
				double num6 = (int)Convert.ToByte(Convert.ToChar(value2));
				num2 += num6 * 47.93;
			}
			for (int l = 0; l <= string_1.Length - 1; l++)
			{
				string value3 = string_1.Substring(l, 1);
				double num7 = (int)Convert.ToByte(Convert.ToChar(value3));
				num3 += num7 * 51.95;
			}
			num4 = (num + num2 + num3) * 9.912;
			for (int m = 0; m <= list_2.Count - 1; m++)
			{
				double num8 = Math.Abs(list_2[m] - num4);
				if (num8 < 0.0001)
				{
					return true;
				}
			}
		}
		throw new RegisterException(string_0);
	}

	static void smethod_183(Contour contour_0, Contour contour_1)
	{
		contour_1.parent = contour_0;
		contour_0.list_0.Add(contour_1);
	}

	static int smethod_184(Class160.Class162 class162_0)
	{
		return class162_0.int_2;
	}

	static Class152 smethod_185(buClipperBase buClipperBase_0)
	{
		Class152 @class = new Class152();
		@class.int_0 = -1;
		@class.bool_0 = false;
		@class.bool_1 = false;
		@class.class152_0 = null;
		@class.class153_0 = null;
		@class.class153_1 = null;
		@class.polyNode_0 = null;
		buClipperBase_0.list_1.Add(@class);
		@class.int_0 = buClipperBase_0.list_1.Count - 1;
		return @class;
	}

	static void smethod_186(ref List<eEntities> list_0, buFile.Cf2 cf2_0, ref eEntities eEntities_0, string[] string_0)
	{
		Pnt3D pnt3D = new Pnt3D();
		Pnt3D pnt3D2 = new Pnt3D();
		Pnt3D pnt3D3 = new Pnt3D();
		int num = 0;
		Cf2FileProperties cf2FileProperties = new Cf2FileProperties();
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		double XY = 0.0;
		double XZ = 0.0;
		double YZ = 0.0;
		double num7 = 0.0;
		double ruleHeight = 0.0;
		double num8 = 0.0;
		int num9 = 0;
		if (buNumeric.IsNumeric(string_0[1]))
		{
			num8 = double.Parse(string_0[1]);
		}
		if (buNumeric.IsNumeric(string_0[2]))
		{
			num7 = double.Parse(string_0[2]);
		}
		if (buNumeric.IsNumeric(string_0[3]))
		{
			ruleHeight = double.Parse(string_0[3]);
		}
		bool flag = false;
		for (int i = 0; i <= cf2_0.FileDefinations.Count - 1; i++)
		{
			if ((cf2_0.FileDefinations[i].Cf2CodeMatchType == num7) & (cf2_0.FileDefinations[i].PtIndex == num8))
			{
				cf2FileProperties = new Cf2FileProperties(cf2_0.FileDefinations[i]);
				flag = true;
				if (cf2FileProperties.LayerIndex < 0)
				{
					cf2FileProperties.LayerIndex = i;
				}
			}
		}
		pnt3D = new Pnt3D(double.Parse(string_0[4], buSystem.CI), double.Parse(string_0[5], buSystem.CI));
		pnt3D2 = new Pnt3D(double.Parse(string_0[6], buSystem.CI), double.Parse(string_0[7], buSystem.CI));
		pnt3D3 = new Pnt3D(double.Parse(string_0[8], buSystem.CI), double.Parse(string_0[9], buSystem.CI));
		num6 = buAppCalc.cVector.Length3D(pnt3D, pnt3D3);
		num9 = int.Parse(string_0[10], buSystem.CI);
		num = int.Parse(string_0[11]);
		num2 = double.Parse(string_0[12]);
		if (num9 > 0)
		{
			num4 = buAppCalc.cVector.PointAngle(pnt3D, pnt3D3, ref XY, ref XZ, ref YZ);
			num5 = buAppCalc.cVector.PointAngle(pnt3D2, pnt3D3, ref XY, ref XZ, ref YZ);
		}
		if (num9 < 0)
		{
			num5 = buAppCalc.cVector.PointAngle(pnt3D, pnt3D3, ref XY, ref XZ, ref YZ);
			num4 = buAppCalc.cVector.PointAngle(pnt3D2, pnt3D3, ref XY, ref XZ, ref YZ);
		}
		if (num4 == num5)
		{
			num4 = 0.0;
			num5 = 360.0;
		}
		if (num4 > num5)
		{
			num5 += 360.0;
		}
		if ((num > 0) & (num2 >= cf2_0.BridgeMinLimit) & (num2 <= cf2_0.BridgeMaxLimit))
		{
			num3 = buAppCalc.cVector.ArcCircumference(num6, num4, num5) / (double)num;
			List<eArc> CalculatedArcs = new List<eArc>();
			buAppCalc.cVector.ArcToArc(pnt3D3, num6, num4, num5, num3, new WorkPlane(), ref CalculatedArcs);
			for (int j = 0; j <= CalculatedArcs.Count - 1; j++)
			{
				double num10 = 0.0;
				double num11 = 0.0;
				double num12 = 0.0;
				num12 = buAppCalc.cVector.ArcCircumference(num6, 0.0, 360.0);
				num11 = num2 * 360.0 / num12;
				num10 = (CalculatedArcs[j].StartAngle + CalculatedArcs[j].EndAngle) / 2.0;
				eArc eArc2 = new eArc(pnt3D3, num6, num10 - num11 / 2.0, num10 + num11 / 2.0, new WorkPlane());
				eArc2.Diemaker = new DiemakerData();
				eArc2.Diemaker.Pt = cf2FileProperties.PtRealValue;
				eArc2.Diemaker.RuleHeight = ruleHeight;
				eArc2.Diemaker.DiemakerType = cf2FileProperties.CodeType;
				eArc2.Diemaker.IsBridge = true;
				eArc2.Diemaker.DiemakerTYpeAsInteger = Convert.ToInt32(num7);
				eArc2.dispColor = cf2FileProperties.Color;
				eArc2.dispThickness = (float)cf2FileProperties.Thickness;
				if (!flag)
				{
					eArc2.Diemaker.Pt = num8;
				}
				if (cf2_0.FoundBridgeProperties.LayerIndex >= 0)
				{
					eArc2.LayerIndex = cf2_0.FoundBridgeProperties.LayerIndex;
				}
				list_0.Add(eArc2);
			}
		}
		if (num4 == num5)
		{
			eEntities_0 = new eCircle(pnt3D3, num6, new WorkPlane());
			eEntities_0.Diemaker = new DiemakerData();
			eEntities_0.Diemaker.Pt = cf2FileProperties.PtRealValue;
			eEntities_0.Diemaker.RuleHeight = ruleHeight;
			eEntities_0.Diemaker.DiemakerType = cf2FileProperties.CodeType;
			eEntities_0.Diemaker.DiemakerTYpeAsInteger = Convert.ToInt32(num7);
			eEntities_0.dispColor = cf2FileProperties.Color;
			eEntities_0.dispThickness = (float)cf2FileProperties.Thickness;
			if (!flag)
			{
				eEntities_0.Diemaker.Pt = num8;
			}
			if (cf2FileProperties.LayerIndex >= 0)
			{
				eEntities_0.LayerIndex = cf2FileProperties.LayerIndex;
			}
			if ((cf2_0.Layers.Count > 0) & (cf2FileProperties.LayerIndex >= 0) & (cf2FileProperties.LayerIndex <= cf2_0.Layers.Count - 1))
			{
				eEntities_0.LayerIndex = cf2FileProperties.LayerIndex;
			}
		}
		else
		{
			eEntities_0 = new eArc(pnt3D3, num6, num4, num5, new WorkPlane());
			eEntities_0.Diemaker = new DiemakerData();
			eEntities_0.Diemaker.Pt = cf2FileProperties.PtRealValue;
			eEntities_0.Diemaker.RuleHeight = ruleHeight;
			eEntities_0.Diemaker.DiemakerType = cf2FileProperties.CodeType;
			eEntities_0.Diemaker.DiemakerTYpeAsInteger = Convert.ToInt32(num7);
			eEntities_0.dispColor = cf2FileProperties.Color;
			eEntities_0.dispThickness = (float)cf2FileProperties.Thickness;
			if (!flag)
			{
				eEntities_0.Diemaker.Pt = num8;
			}
			if (cf2FileProperties.LayerIndex >= 0)
			{
				eEntities_0.LayerIndex = cf2FileProperties.LayerIndex;
			}
			if ((cf2_0.Layers.Count > 0) & (cf2FileProperties.LayerIndex >= 0) & (cf2FileProperties.LayerIndex <= cf2_0.Layers.Count - 1))
			{
				eEntities_0.LayerIndex = cf2FileProperties.LayerIndex;
			}
		}
	}

	static void smethod_187(AdvancingFrontNode advancingFrontNode_0, AdvancingFrontNode advancingFrontNode_1, DTSweepContext dtsweepContext_0)
	{
		AdvancingFrontNode advancingFrontNode = advancingFrontNode_1;
		while (advancingFrontNode_0 != dtsweepContext_0.Front.Tail)
		{
			if (dtsweepContext_0.IsDebugEnabled)
			{
				dtsweepContext_0.DebugContext.ActiveNode = advancingFrontNode_0;
			}
			if (TriangulationUtil.Orient2d(advancingFrontNode_1.Point, advancingFrontNode_0.Point, advancingFrontNode_0.Next.Point) != Orientation.AntiClockwise)
			{
				if (advancingFrontNode_1 == advancingFrontNode || TriangulationUtil.Orient2d(advancingFrontNode_1.Prev.Point, advancingFrontNode_1.Point, advancingFrontNode_0.Point) != Orientation.AntiClockwise)
				{
					advancingFrontNode_1 = advancingFrontNode_0;
					advancingFrontNode_0 = advancingFrontNode_0.Next;
				}
				else
				{
					smethod_51(dtsweepContext_0, advancingFrontNode_1);
					advancingFrontNode_1 = advancingFrontNode_1.Prev;
				}
			}
			else
			{
				smethod_51(dtsweepContext_0, advancingFrontNode_0);
				advancingFrontNode_0 = advancingFrontNode_0.Next;
			}
		}
	}

	static string smethod_188(string string_0)
	{
		if (string_0 == null)
		{
			throw new ArgumentNullException("input");
		}
		string_0 = Regex.Replace(string_0, "(\\((?>\\((?<C>)|\\)(?<-C>)|.?)*(?(C)(?!))\\))", "");
		string_0 = Regex.Replace(string_0, "\\s+", " ");
		string_0 = Regex.Replace(string_0, "^\\s+", "");
		string_0 = Regex.Replace(string_0, "\\s+$", "");
		string_0 = Regex.Replace(string_0, " ?: ?", ":");
		return string_0;
	}

	static List<string> smethod_189(char char_0, string string_0)
	{
		List<string> list = new List<string>();
		int num = 0;
		bool flag = false;
		char[] array = string_0.ToCharArray();
		for (int i = 0; i < array.Length; i++)
		{
			char c = array[i];
			if (c == '"')
			{
				flag = !flag;
			}
			if (c == char_0 && !flag)
			{
				int length = i - num;
				list.Add(string_0.Substring(num, length));
				num = i + 1;
			}
		}
		list.Add(string_0.Substring(num, string_0.Length - num));
		return list;
	}

	static uint smethod_190(ulong ulong_0)
	{
		return (uint)(((ulong_0 & 0xFFL) << 24) + ((ulong_0 & 0xFF00L) << 8) + ((ulong_0 & 0xFF0000L) >> 8) + ((ulong_0 & 0xFF000000L) >> 24));
	}

	static void smethod_191(ref byte[] byte_0, out MessageHeader messageHeader_0, [Out] byte[] byte_1)
	{
		if (byte_1 == null)
		{
			throw new ArgumentNullException("fullRawMessage");
		}
		int num = smethod_3(byte_1);
		string string_ = Encoding.ASCII.GetString(byte_1, 0, num);
		NameValueCollection nameValueCollection_ = smethod_239(string_);
		messageHeader_0 = new MessageHeader(nameValueCollection_);
		byte_0 = new byte[byte_1.Length - num];
		Array.Copy(byte_1, num, byte_0, 0, byte_0.Length);
	}

	static bool smethod_192(Class148 class148_0, bool bool_0, Class148 class148_1)
	{
		if (!bool_0)
		{
			return class148_1.intPoint_3.Y * class148_0.intPoint_3.X == class148_1.intPoint_3.X * class148_0.intPoint_3.Y;
		}
		return Struct53.smethod_0(Struct53.smethod_2(class148_1.intPoint_3.Y, class148_0.intPoint_3.X), Struct53.smethod_2(class148_1.intPoint_3.X, class148_0.intPoint_3.Y));
	}

	static double smethod_193(double double_0, buFile.Dxf dxf_0)
	{
		double num = 0.0;
		return double_0 * 180.0 / Math.PI;
	}

	static void smethod_194(buClipper buClipper_0, Class148 class148_0)
	{
		Class148 @class = smethod_110(class148_0, buClipper_0);
		if (@class != null)
		{
			Class148 class148_1 = class148_0.class148_3;
			while (class148_1 != null && class148_1 != @class)
			{
				smethod_287(class148_0.intPoint_2, buClipper_0, class148_0, class148_1);
				smethod_45(class148_1, class148_0, (buClipperBase)buClipper_0);
				class148_1 = class148_0.class148_3;
			}
			if (class148_0.int_3 != -1 || @class.int_3 != -1)
			{
				if (class148_0.int_3 < 0 || @class.int_3 < 0)
				{
					if (class148_0.int_0 != 0)
					{
						throw new Exception0("DoMaxima error");
					}
					if (class148_0.int_3 >= 0)
					{
						smethod_246(buClipper_0, class148_0, class148_0.intPoint_2);
						class148_0.int_3 = -1;
					}
					smethod_12((buClipperBase)buClipper_0, class148_0);
					if (@class.int_3 >= 0)
					{
						smethod_246(buClipper_0, @class, class148_0.intPoint_2);
						@class.int_3 = -1;
					}
					smethod_12((buClipperBase)buClipper_0, @class);
				}
				else
				{
					if (class148_0.int_3 >= 0)
					{
						smethod_1(class148_0.intPoint_2, class148_0, @class, buClipper_0);
					}
					smethod_12((buClipperBase)buClipper_0, class148_0);
					smethod_12((buClipperBase)buClipper_0, @class);
				}
			}
			else
			{
				smethod_12((buClipperBase)buClipper_0, class148_0);
				smethod_12((buClipperBase)buClipper_0, @class);
			}
		}
		else
		{
			if (class148_0.int_3 >= 0)
			{
				smethod_246(buClipper_0, class148_0, class148_0.intPoint_2);
			}
			smethod_12((buClipperBase)buClipper_0, class148_0);
		}
	}

	static Class160.Class164 smethod_195(Class160.Class165 class165_0)
	{
		byte[] array = new byte[class165_0.int_4];
		Array.Copy(class165_0.byte_1, class165_0.int_3, array, 0, class165_0.int_4);
		return new Class160.Class164(array);
	}

	static bool smethod_196(IntPoint intPoint_0, IntPoint intPoint_1, double double_0)
	{
		double num = (double)intPoint_0.X - (double)intPoint_1.X;
		double num2 = (double)intPoint_0.Y - (double)intPoint_1.Y;
		return num * num + num2 * num2 <= double_0;
	}

	static int smethod_197(Pop3Client pop3Client_0, string string_0, int int_0)
	{
		smethod_144(pop3Client_0, string_0);
		return int.Parse(pop3Client_0.method_2().Split(' ')[int_0], CultureInfo.InvariantCulture);
	}

	static ContentTransferEncoding smethod_198(string string_0)
	{
		if (string_0 != null)
		{
			switch (string_0.Trim().ToUpperInvariant())
			{
			case "7BIT":
				return ContentTransferEncoding.SevenBit;
			case "8BIT":
				return ContentTransferEncoding.EightBit;
			case "QUOTED-PRINTABLE":
				return ContentTransferEncoding.QuotedPrintable;
			case "BASE64":
				return ContentTransferEncoding.Base64;
			case "BINARY":
				return ContentTransferEncoding.Binary;
			default:
				DefaultLogger.Log.LogDebug("Wrong ContentTransferEncoding was used. It was: " + string_0);
				return ContentTransferEncoding.SevenBit;
			}
		}
		throw new ArgumentNullException("headerValue");
	}

	static long smethod_199(double double_0)
	{
		return (double_0 >= 0.0) ? ((long)(double_0 + 0.5)) : ((long)(double_0 - 0.5));
	}

	static void smethod_200(ConstrainedPointSet constrainedPointSet_0, IEnumerable<TriangulationConstraint> ienumerable_0)
	{
		if (ienumerable_0 == null)
		{
			return;
		}
		foreach (TriangulationConstraint item in ienumerable_0)
		{
			if (constrainedPointSet_0.ConstrainPointToBounds(item.P) || constrainedPointSet_0.ConstrainPointToBounds(item.Q))
			{
				item.CalculateContraintCode();
			}
			if (!constrainedPointSet_0.dictionary_1.TryGetValue(item.ConstraintCode, out var value))
			{
				value = item;
				constrainedPointSet_0.AddConstraint(value);
			}
		}
	}

	static AdvancingFrontNode smethod_201(DTSweepContext dtsweepContext_0, TriangulationPoint triangulationPoint_0)
	{
		AdvancingFrontNode advancingFrontNode = dtsweepContext_0.LocateNode(triangulationPoint_0);
		if (dtsweepContext_0.IsDebugEnabled)
		{
			dtsweepContext_0.DebugContext.ActiveNode = advancingFrontNode;
		}
		if (advancingFrontNode != null && triangulationPoint_0 != null)
		{
			AdvancingFrontNode advancingFrontNode2 = smethod_160(dtsweepContext_0, triangulationPoint_0, advancingFrontNode);
			if (triangulationPoint_0.X <= advancingFrontNode.Point.X + 1E-12)
			{
				smethod_51(dtsweepContext_0, advancingFrontNode);
			}
			smethod_91(dtsweepContext_0, advancingFrontNode2);
			return advancingFrontNode2;
		}
		return null;
	}

	static Class148 smethod_202(buClipperBase buClipperBase_0, Class148 class148_0)
	{
		class148_0.class148_1.class148_0 = class148_0.class148_0;
		class148_0.class148_0.class148_1 = class148_0.class148_1;
		Class148 class148_1 = class148_0.class148_0;
		class148_0.class148_1 = null;
		return class148_1;
	}

	static bool smethod_203(long long_0, buClipper buClipper_0)
	{
		if (buClipper_0.class148_0 != null)
		{
			try
			{
				smethod_259(long_0, buClipper_0);
				if (buClipper_0.list_2.Count == 0)
				{
					return true;
				}
				if (buClipper_0.list_2.Count != 1 && !smethod_42(buClipper_0))
				{
					return false;
				}
				smethod_235(buClipper_0);
			}
			catch
			{
				buClipper_0.class148_1 = null;
				buClipper_0.list_2.Clear();
				throw new Exception0("ProcessIntersections error");
			}
			buClipper_0.class148_1 = null;
			return true;
		}
		return true;
	}

	static double smethod_204(buFile.Dxf dxf_0, double double_0)
	{
		double result = 0.0;
		if (double_0 > 360.0)
		{
			double_0 -= 360.0;
			result = double_0 * Math.PI / 180.0;
			double_0 += 360.0;
		}
		if (double_0 <= 360.0)
		{
			result = double_0 * Math.PI / 180.0;
		}
		return result;
	}

	static void smethod_205(AdvancingFrontNode advancingFrontNode_0, DTSweepContext dtsweepContext_0)
	{
		dtsweepContext_0.Basin.LeftNode = ((TriangulationUtil.Orient2d(advancingFrontNode_0.Point, advancingFrontNode_0.Next.Point, advancingFrontNode_0.Next.Next.Point) != Orientation.AntiClockwise) ? advancingFrontNode_0.Next : advancingFrontNode_0);
		dtsweepContext_0.Basin.BottomNode = dtsweepContext_0.Basin.LeftNode;
		while (dtsweepContext_0.Basin.BottomNode.HasNext && dtsweepContext_0.Basin.BottomNode.Point.Y >= dtsweepContext_0.Basin.BottomNode.Next.Point.Y)
		{
			dtsweepContext_0.Basin.BottomNode = dtsweepContext_0.Basin.BottomNode.Next;
		}
		if (dtsweepContext_0.Basin.BottomNode != dtsweepContext_0.Basin.LeftNode)
		{
			dtsweepContext_0.Basin.RightNode = dtsweepContext_0.Basin.BottomNode;
			while (dtsweepContext_0.Basin.RightNode.HasNext && dtsweepContext_0.Basin.RightNode.Point.Y < dtsweepContext_0.Basin.RightNode.Next.Point.Y)
			{
				dtsweepContext_0.Basin.RightNode = dtsweepContext_0.Basin.RightNode.Next;
			}
			if (dtsweepContext_0.Basin.RightNode != dtsweepContext_0.Basin.BottomNode)
			{
				dtsweepContext_0.Basin.Width = dtsweepContext_0.Basin.RightNode.Point.X - dtsweepContext_0.Basin.LeftNode.Point.X;
				dtsweepContext_0.Basin.LeftHighest = dtsweepContext_0.Basin.LeftNode.Point.Y > dtsweepContext_0.Basin.RightNode.Point.Y;
				smethod_269(dtsweepContext_0, dtsweepContext_0.Basin.BottomNode);
			}
		}
	}

	static bool smethod_206(ref double double_0, ref double double_1, ref double double_2, buFile.Dxf dxf_0, ref Color color_0, ref string string_0, ref Vec3D vec3D_0, ref double double_3, ref double double_4, ref double double_5, int int_0)
	{
		bool flag = true;
		bool flag2 = false;
		bool flag3 = false;
		bool result = false;
		int num = 0;
		vec3D_0 = new Vec3D(0.0, 0.0, 1.0);
		for (int i = int_0; i <= dxf_0.list_0.Count - 1; i++)
		{
			if (num < 80)
			{
				num++;
				if (flag & (dxf_0.list_0[i] == "AcDbEntity"))
				{
					string_0 = dxf_0.list_0[i + 2];
				}
				if (flag & (dxf_0.list_0[i] == "  8"))
				{
					string_0 = dxf_0.list_0[i + 1];
				}
				if (flag & (dxf_0.list_0[i] == "AcDbCircle"))
				{
					flag2 = true;
				}
				if (flag & (dxf_0.list_0[i] == "AcDbArc"))
				{
					flag3 = true;
				}
				if (flag & (dxf_0.list_0[i] == "CONTINUOUS"))
				{
					flag2 = true;
					flag3 = true;
				}
				if (flag & (dxf_0.list_0[i] == " 62"))
				{
					int num2 = Convert.ToInt32(dxf_0.list_0[i + 1]);
					if (num2 >= dxf_0.ColorCode.Length)
					{
						color_0 = Color.Black;
					}
					else
					{
						color_0 = dxf_0.ColorCode[num2];
					}
					if ((color_0.A == 0) & (color_0.R == 0) & (color_0.G == 0) & (color_0.B == 0))
					{
						color_0 = Color.Black;
					}
				}
				if (flag2 & (dxf_0.list_0[i] == "210"))
				{
					vec3D_0.X = Math.Round(smethod_256(dxf_0, dxf_0.list_0[i + 1]), 3);
				}
				if (flag2 & (dxf_0.list_0[i] == "220"))
				{
					vec3D_0.Y = Math.Round(smethod_256(dxf_0, dxf_0.list_0[i + 1]), 3);
				}
				if (flag2 & (dxf_0.list_0[i] == "230"))
				{
					vec3D_0.Z = Math.Round(smethod_256(dxf_0, dxf_0.list_0[i + 1]), 3);
				}
				if (flag2 & (dxf_0.list_0[i] == " 10"))
				{
					double_5 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
				}
				if (flag2 & (dxf_0.list_0[i] == " 20"))
				{
					double_3 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
				}
				if (flag2 & (dxf_0.list_0[i] == " 30"))
				{
					double_4 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
				}
				if (flag2 & (dxf_0.list_0[i] == " 40"))
				{
					double_1 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
				}
				if (flag3 & (dxf_0.list_0[i] == " 50"))
				{
					double_2 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
				}
				if (flag3 & (dxf_0.list_0[i] == " 51"))
				{
					double_0 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
					if (double_2 > double_0)
					{
						double_0 += 360.0;
					}
					result = true;
					break;
				}
				continue;
			}
			result = false;
			break;
		}
		return result;
	}

	static void smethod_207(buClipper buClipper_0, ref IntPoint intPoint_0, Class148 class148_0, Class148 class148_1)
	{
		if (intPoint_0.Z != 0L || buClipper_0.ZFillFunction == null)
		{
			return;
		}
		if (!(intPoint_0 == class148_0.intPoint_0))
		{
			if (!(intPoint_0 == class148_0.intPoint_2))
			{
				if (!(intPoint_0 == class148_1.intPoint_0))
				{
					if (!(intPoint_0 == class148_1.intPoint_2))
					{
						buClipper_0.ZFillFunction(class148_0.intPoint_0, class148_0.intPoint_2, class148_1.intPoint_0, class148_1.intPoint_2, ref intPoint_0);
					}
					else
					{
						intPoint_0.Z = class148_1.intPoint_2.Z;
					}
				}
				else
				{
					intPoint_0.Z = class148_1.intPoint_0.Z;
				}
			}
			else
			{
				intPoint_0.Z = class148_0.intPoint_2.Z;
			}
		}
		else
		{
			intPoint_0.Z = class148_0.intPoint_0.Z;
		}
	}

	static byte[] smethod_208(byte[] byte_0, byte[] byte_1)
	{
		if (byte_1 != null)
		{
			if (byte_0 != null)
			{
				if (byte_1.Length == byte_0.Length)
				{
					byte[] array = new byte[byte_1.Length];
					for (int i = 0; i < byte_1.Length; i++)
					{
						array[i] = byte_1[i];
						array[i] ^= byte_0[i];
					}
					return array;
				}
				throw new ArgumentException("The lengths of the arrays must be equal");
			}
			throw new ArgumentNullException("toXorWith");
		}
		throw new ArgumentNullException("toXor");
	}

	static bool smethod_209(double double_0)
	{
		return !(double_0 <= -1E-20) && double_0 < 1E-20;
	}

	static void smethod_210(ClipperOffset clipperOffset_0, int int_0, int int_1)
	{
		double num = Math.Tan(Math.Atan2(clipperOffset_0.double_1, clipperOffset_0.list_3[int_1].X * clipperOffset_0.list_3[int_0].X + clipperOffset_0.list_3[int_1].Y * clipperOffset_0.list_3[int_0].Y) / 4.0);
		clipperOffset_0.list_2.Add(new IntPoint(smethod_150((double)clipperOffset_0.list_1[int_0].X + clipperOffset_0.double_0 * (clipperOffset_0.list_3[int_1].X - clipperOffset_0.list_3[int_1].Y * num)), smethod_150((double)clipperOffset_0.list_1[int_0].Y + clipperOffset_0.double_0 * (clipperOffset_0.list_3[int_1].Y + clipperOffset_0.list_3[int_1].X * num))));
		clipperOffset_0.list_2.Add(new IntPoint(smethod_150((double)clipperOffset_0.list_1[int_0].X + clipperOffset_0.double_0 * (clipperOffset_0.list_3[int_0].X + clipperOffset_0.list_3[int_0].Y * num)), smethod_150((double)clipperOffset_0.list_1[int_0].Y + clipperOffset_0.double_0 * (clipperOffset_0.list_3[int_0].Y - clipperOffset_0.list_3[int_0].X * num))));
	}

	static void smethod_211(buClipper buClipper_0, Class148 class148_0)
	{
		bool flag = class148_0.int_0 == 0;
		long long_2 = default(long);
		smethod_111(buClipper_0, class148_0, out Enum12 enum12_, out long long_, ref long_2);
		Class148 @class = class148_0;
		Class148 class2 = null;
		while (@class.class148_2 != null && smethod_67(@class.class148_2))
		{
			@class = @class.class148_2;
		}
		if (@class.class148_2 == null)
		{
			class2 = smethod_146(buClipper_0, @class);
		}
		Class151 class3 = buClipper_0.class151_0;
		if (class3 != null)
		{
			if (enum12_ != Enum12.const_1)
			{
				while (class3.class151_0 != null && class3.class151_0.long_0 < class148_0.intPoint_0.X)
				{
					class3 = class3.class151_0;
				}
				if (class3.long_0 <= @class.intPoint_2.X)
				{
					class3 = null;
				}
			}
			else
			{
				while (class3 != null && class3.long_0 <= class148_0.intPoint_0.X)
				{
					class3 = class3.class151_0;
				}
				if (class3 != null && class3.long_0 >= @class.intPoint_2.X)
				{
					class3 = null;
				}
			}
		}
		Class153 class4 = null;
		while (true)
		{
			bool flag2 = class148_0 == @class;
			Class148 class5 = smethod_99(buClipper_0, class148_0, enum12_);
			while (class5 != null)
			{
				if (class3 != null)
				{
					if (enum12_ != Enum12.const_1)
					{
						while (class3 != null && class3.long_0 > class5.intPoint_1.X)
						{
							if (class148_0.int_3 >= 0 && !flag)
							{
								smethod_246(buClipper_0, class148_0, new IntPoint(class3.long_0, class148_0.intPoint_0.Y));
							}
							class3 = class3.class151_1;
						}
					}
					else
					{
						while (class3 != null && class3.long_0 < class5.intPoint_1.X)
						{
							if (class148_0.int_3 >= 0 && !flag)
							{
								smethod_246(buClipper_0, class148_0, new IntPoint(class3.long_0, class148_0.intPoint_0.Y));
							}
							class3 = class3.class151_0;
						}
					}
				}
				if ((enum12_ == Enum12.const_1 && class5.intPoint_1.X > long_2) || (enum12_ == Enum12.const_0 && class5.intPoint_1.X < long_) || (class5.intPoint_1.X == class148_0.intPoint_2.X && class148_0.class148_2 != null && class5.double_0 < class148_0.class148_2.double_0))
				{
					break;
				}
				if (class148_0.int_3 >= 0 && !flag)
				{
					if (enum12_ != Enum12.const_1)
					{
						smethod_207(buClipper_0, ref class5.intPoint_1, class5, class148_0);
					}
					else
					{
						smethod_207(buClipper_0, ref class5.intPoint_1, class148_0, class5);
					}
					class4 = smethod_246(buClipper_0, class148_0, class5.intPoint_1);
					for (Class148 class6 = buClipper_0.class148_1; class6 != null; class6 = class6.class148_5)
					{
						if (class6.int_3 >= 0)
						{
							long x = class148_0.intPoint_0.X;
							long x2 = class148_0.intPoint_2.X;
							long x3 = class6.intPoint_0.X;
							long x4 = class6.intPoint_2.X;
							if (smethod_97(x4, buClipper_0, x2, x, x3))
							{
								Class153 class153_ = smethod_137(class6, buClipper_0);
								smethod_22(class6.intPoint_2, class4, class153_, buClipper_0);
							}
						}
					}
					smethod_223(class148_0.intPoint_0, class4, buClipper_0);
				}
				if (!(class5 == class2 && flag2))
				{
					if (enum12_ != Enum12.const_1)
					{
						IntPoint intPoint_ = new IntPoint(class5.intPoint_1.X, class148_0.intPoint_1.Y);
						smethod_287(intPoint_, buClipper_0, class5, class148_0);
					}
					else
					{
						IntPoint intPoint_2 = new IntPoint(class5.intPoint_1.X, class148_0.intPoint_1.Y);
						smethod_287(intPoint_2, buClipper_0, class148_0, class5);
					}
					Class148 class7 = smethod_99(buClipper_0, class5, enum12_);
					smethod_45(class5, class148_0, (buClipperBase)buClipper_0);
					class5 = class7;
					continue;
				}
				if (class148_0.int_3 >= 0)
				{
					smethod_1(class148_0.intPoint_2, class148_0, class2, buClipper_0);
				}
				smethod_12((buClipperBase)buClipper_0, class148_0);
				smethod_12((buClipperBase)buClipper_0, class2);
				return;
			}
			if (class148_0.class148_2 == null || !smethod_67(class148_0.class148_2))
			{
				break;
			}
			smethod_8((buClipperBase)buClipper_0, ref class148_0);
			if (class148_0.int_3 >= 0)
			{
				smethod_246(buClipper_0, class148_0, class148_0.intPoint_0);
			}
			smethod_111(buClipper_0, class148_0, out enum12_, out long_, ref long_2);
		}
		if (class148_0.int_3 >= 0 && class4 == null)
		{
			class4 = smethod_137(class148_0, buClipper_0);
			for (Class148 class8 = buClipper_0.class148_1; class8 != null; class8 = class8.class148_5)
			{
				if (class8.int_3 >= 0)
				{
					long x = class148_0.intPoint_0.X;
					long x2 = class148_0.intPoint_2.X;
					long x3 = class8.intPoint_0.X;
					long x4 = class8.intPoint_2.X;
					if (smethod_97(x4, buClipper_0, x2, x, x3))
					{
						Class153 class153_2 = smethod_137(class8, buClipper_0);
						smethod_22(class8.intPoint_2, class4, class153_2, buClipper_0);
					}
				}
			}
			smethod_223(class148_0.intPoint_2, class4, buClipper_0);
		}
		if (class148_0.class148_2 == null)
		{
			if (class148_0.int_3 >= 0)
			{
				smethod_246(buClipper_0, class148_0, class148_0.intPoint_2);
			}
			smethod_12((buClipperBase)buClipper_0, class148_0);
			return;
		}
		if (class148_0.int_3 < 0)
		{
			smethod_8((buClipperBase)buClipper_0, ref class148_0);
			return;
		}
		class4 = smethod_246(buClipper_0, class148_0, class148_0.intPoint_2);
		smethod_8((buClipperBase)buClipper_0, ref class148_0);
		if (class148_0.int_0 == 0)
		{
			return;
		}
		Class148 class148_1 = class148_0.class148_4;
		Class148 class148_2 = class148_0.class148_3;
		if (class148_1 == null || class148_1.intPoint_1.X != class148_0.intPoint_0.X || class148_1.intPoint_1.Y != class148_0.intPoint_0.Y || class148_1.int_0 == 0 || class148_1.int_3 < 0 || class148_1.intPoint_1.Y <= class148_1.intPoint_2.Y || !smethod_192(class148_1, buClipper_0.bool_0, class148_0))
		{
			if (class148_2 != null && class148_2.intPoint_1.X == class148_0.intPoint_0.X && class148_2.intPoint_1.Y == class148_0.intPoint_0.Y && class148_2.int_0 != 0 && class148_2.int_3 >= 0 && class148_2.intPoint_1.Y > class148_2.intPoint_2.Y && smethod_192(class148_2, buClipper_0.bool_0, class148_0))
			{
				Class153 class153_3 = smethod_246(buClipper_0, class148_2, class148_0.intPoint_0);
				smethod_22(class148_0.intPoint_2, class153_3, class4, buClipper_0);
			}
		}
		else
		{
			Class153 class153_4 = smethod_246(buClipper_0, class148_1, class148_0.intPoint_0);
			smethod_22(class148_0.intPoint_2, class153_4, class4, buClipper_0);
		}
	}

	static void smethod_212(PolyNode polyNode_0, PolyNode polyNode_1)
	{
		int count = polyNode_0.list_1.Count;
		polyNode_0.list_1.Add(polyNode_1);
		polyNode_1.polyNode_0 = polyNode_0;
		polyNode_1.int_0 = count;
	}

	static void smethod_213(PopServerException popServerException_0, string string_0)
	{
		string text = string_0.ToUpperInvariant();
		if (!text.Contains("[IN-USE]") && !text.Contains("LOCK"))
		{
			if (text.Contains("[LOGIN-DELAY]"))
			{
				throw new LoginDelayException(popServerException_0);
			}
			return;
		}
		DefaultLogger.Log.LogError("Authentication: maildrop is locked or in-use");
		throw new PopServerLockedException(popServerException_0);
	}

	static void smethod_214(Pop3Client pop3Client_0, string string_0, string string_1)
	{
		smethod_144(pop3Client_0, "USER " + string_0);
		smethod_144(pop3Client_0, "PASS " + string_1);
	}

	static void smethod_215(DelaunayTriangle delaunayTriangle_0, DTSweepContext dtsweepContext_0)
	{
		if (delaunayTriangle_0 == null || delaunayTriangle_0.IsInterior)
		{
			return;
		}
		delaunayTriangle_0.IsInterior = true;
		dtsweepContext_0.Triangulatable.AddTriangle(delaunayTriangle_0);
		for (int i = 0; i < 3; i++)
		{
			if (!delaunayTriangle_0.EdgeIsConstrained[i])
			{
				smethod_215(delaunayTriangle_0.Neighbors[i], dtsweepContext_0);
			}
		}
	}

	static double smethod_216(Class153 class153_0, buClipper buClipper_0)
	{
		Class153 @class = class153_0;
		if (class153_0 != null)
		{
			double num = 0.0;
			do
			{
				num += (double)(class153_0.class153_1.intPoint_0.X + class153_0.intPoint_0.X) * (double)(class153_0.class153_1.intPoint_0.Y - class153_0.intPoint_0.Y);
				class153_0 = class153_0.class153_0;
			}
			while (class153_0 != @class);
			return num * 0.5;
		}
		return 0.0;
	}

	static double smethod_217(Point2D point2D_0)
	{
		return 1.0 / point2D_0.Magnitude();
	}

	static double smethod_218(AdvancingFrontNode advancingFrontNode_0)
	{
		double x = advancingFrontNode_0.Point.X - advancingFrontNode_0.Next.Next.Point.X;
		double y = advancingFrontNode_0.Point.Y - advancingFrontNode_0.Next.Next.Point.Y;
		return Math.Atan2(y, x);
	}

	static int smethod_219(Class160.Class163 class163_0, Class160.Class162 class162_0, int int_0)
	{
		int_0 = Math.Min(Math.Min(int_0, 32768 - class163_0.int_1), smethod_6(class162_0));
		int num = 32768 - class163_0.int_0;
		int num2;
		if (int_0 <= num)
		{
			num2 = smethod_173(class162_0, class163_0.byte_0, class163_0.int_0, int_0);
		}
		else
		{
			num2 = smethod_173(class162_0, class163_0.byte_0, class163_0.int_0, num);
			if (num2 == num)
			{
				num2 += smethod_173(class162_0, class163_0.byte_0, 0, int_0 - num);
			}
		}
		class163_0.int_0 = (class163_0.int_0 + num2) & 0x7FFF;
		class163_0.int_1 += num2;
		return num2;
	}

	static void smethod_220(ref float float_0, ref List<Pnt3D> list_0, buFile.Dxf dxf_0, ref bool bool_0, ref List<double> list_1, ref Color color_0, int int_0, ref double double_0, ref string string_0)
	{
		bool flag = true;
		bool flag2 = false;
		int num = 0;
		Pnt3D pnt3D = new Pnt3D();
		bool_0 = false;
		for (int i = int_0; i <= dxf_0.list_0.Count - 1; i++)
		{
			if (flag & (dxf_0.list_0[i] == " 62"))
			{
				int num2 = Convert.ToInt32(dxf_0.list_0[i + 1]);
				if (num2 >= dxf_0.ColorCode.Length)
				{
					color_0 = Color.Black;
				}
				else
				{
					color_0 = dxf_0.ColorCode[num2];
				}
				if ((color_0.A == 0) & (color_0.R == 0) & (color_0.G == 0) & (color_0.B == 0))
				{
					color_0 = Color.Black;
				}
			}
			if (flag & (dxf_0.list_0[i] == "AcDbEntity"))
			{
				string_0 = dxf_0.list_0[i + 2];
			}
			if (flag & (dxf_0.list_0[i] == "  8"))
			{
				string_0 = dxf_0.list_0[i + 1];
			}
			if (flag & (dxf_0.list_0[i] == "AcDbSpline"))
			{
				flag2 = true;
			}
			if (flag2 & (dxf_0.list_0[i] == " 10"))
			{
				pnt3D = new Pnt3D();
				pnt3D.X = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
				pnt3D.Y = smethod_256(dxf_0, dxf_0.list_0[i + 3]);
				pnt3D.Z = 0.0;
				list_0.Add(pnt3D);
				num++;
			}
			if (flag2 & (dxf_0.list_0[i] == " 40"))
			{
				list_1.Add(smethod_256(dxf_0, dxf_0.list_0[i + 1]));
			}
			if (flag2 & (dxf_0.list_0[i] == " 71"))
			{
				double_0 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
			}
			if (flag2 & (dxf_0.list_0[i] == " 72"))
			{
				_ = (int)smethod_256(dxf_0, dxf_0.list_0[i + 1]);
			}
			if (flag2 & (dxf_0.list_0[i] == " 73"))
			{
				_ = (int)smethod_256(dxf_0, dxf_0.list_0[i + 1]);
			}
			if (flag2 & (dxf_0.list_0[i] == "  0"))
			{
				break;
			}
		}
	}

	static void smethod_221(ref float float_0, buFile.Dxf dxf_0, int int_0, ref Color color_0, ref string string_0, ref List<eEntities> list_0, ref bool bool_0)
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		double num = 0.0;
		Pnt3D pnt3D = new Pnt3D();
		List<Pnt3D> list = new List<Pnt3D>();
		for (int i = int_0; i <= dxf_0.list_0.Count - 1; i++)
		{
			flag3 = false;
			_ = dxf_0.list_0[i];
			if ((((!flag) ? 1u : 0u) & 1u) != 0 && ((dxf_0.list_0[i] == " 62") | (dxf_0.list_0[i] == "62")))
			{
				int num2 = Convert.ToInt32(dxf_0.list_0[i + 1]);
				if (num2 >= dxf_0.ColorCode.Length)
				{
					color_0 = Color.Black;
				}
				else
				{
					color_0 = dxf_0.ColorCode[num2];
				}
				if ((color_0.A == 0) & (color_0.R == 0) & (color_0.G == 0) & (color_0.B == 0))
				{
					color_0 = Color.Black;
				}
				i++;
				flag = true;
			}
			if (!flag2 && !flag3 && ((dxf_0.list_0[i] == "  8") | (dxf_0.list_0[i] == "8")))
			{
				string_0 = dxf_0.list_0[i + 1];
				flag2 = true;
				i++;
				flag3 = true;
			}
			if (!flag3 && ((dxf_0.list_0[i] == " 70") | (dxf_0.list_0[i] == "70")))
			{
				string text = dxf_0.list_0[i + 1];
				if (text.Trim() == "1")
				{
					bool_0 = true;
				}
				i++;
				flag3 = true;
			}
			if (!flag3)
			{
				_ = dxf_0.list_0[i];
				if (flag4)
				{
					if ((dxf_0.list_0[i] == " 42") | (dxf_0.list_0[i] == "42"))
					{
						num = Convert.ToDouble(dxf_0.list_0[i + 1]);
						i++;
					}
					if ((dxf_0.list_0[i] == " 10") | (dxf_0.list_0[i] == "10"))
					{
						if ((dxf_0.list_0[i + 2] == " 20") | (dxf_0.list_0[i + 2] == "20"))
						{
							double num3 = 0.0;
							double num4 = 0.0;
							if (num == 0.0)
							{
								num3 = Convert.ToDouble(dxf_0.list_0[i + 1]);
								num4 = Convert.ToDouble(dxf_0.list_0[i + 3]);
								Pnt3D endPoint = new Pnt3D(num3, num4);
								list_0.Add(new eLine(pnt3D, endPoint));
							}
							else
							{
								num3 = Convert.ToDouble(dxf_0.list_0[i + 1]);
								num4 = Convert.ToDouble(dxf_0.list_0[i + 3]);
								new Pnt3D(num3, num4);
								num3 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
								num4 = smethod_256(dxf_0, dxf_0.list_0[i + 3]);
								Pnt3D pnt3D2 = new Pnt3D(num3, num4);
								double num5 = buAppCalc.cVector.Length3D(pnt3D, pnt3D2) / 2.0;
								double num6 = 4.0 * Math.Atan(num);
								num6 /= 2.0;
								double value = num5 / Math.Sin(num6);
								Pnt3D ArcCenter = new Pnt3D();
								double ArcSA = 0.0;
								double ArcEA = 0.0;
								if (!(num6 > 0.0))
								{
									buAppCalc.cVector.ArcWithTwoPointAndRadius(pnt3D, pnt3D2, Math.Abs(value), CW: true, new WorkPlane(), ref ArcCenter, ref ArcSA, ref ArcEA);
								}
								else
								{
									buAppCalc.cVector.ArcWithTwoPointAndRadius(pnt3D2, pnt3D, Math.Abs(value), CW: true, new WorkPlane(), ref ArcCenter, ref ArcSA, ref ArcEA);
								}
								list_0.Add(new eArc(ArcCenter, Math.Abs(value), ArcSA, ArcEA, new WorkPlane()));
								num = 0.0;
							}
							pnt3D = new Pnt3D(num3, num4);
							list.Add(pnt3D);
						}
						flag3 = true;
					}
				}
				if (!flag4 && ((dxf_0.list_0[i] == " 10") | (dxf_0.list_0[i] == "10")) && ((dxf_0.list_0[i + 2] == " 20") | (dxf_0.list_0[i + 2] == "20")))
				{
					pnt3D = new Pnt3D(Convert.ToDouble(dxf_0.list_0[i + 1]), Convert.ToDouble(dxf_0.list_0[i + 3]));
					flag4 = true;
					i += 3;
				}
			}
			if (!flag3 && ((dxf_0.list_0[i] == "  0") | (dxf_0.list_0[i] == "0")))
			{
				flag3 = true;
				break;
			}
		}
	}

	static bool smethod_222(ref double double_0, ref double double_1, buFile.Dxf dxf_0, ref double double_2, ref Color color_0, ref double double_3, ref string string_0, ref double double_4, int int_0, ref double double_5)
	{
		bool flag = true;
		bool result = false;
		int num = 0;
		for (int i = int_0; i <= dxf_0.list_0.Count - 1; i++)
		{
			if (num < 80)
			{
				num++;
				if (flag & (dxf_0.list_0[i] == "AcDbEntity"))
				{
					string_0 = dxf_0.list_0[i + 2];
				}
				if (flag & (dxf_0.list_0[i] == "  8"))
				{
					string_0 = dxf_0.list_0[i + 1];
				}
				if (flag & (dxf_0.list_0[i] == " 62"))
				{
					int num2 = Convert.ToInt32(dxf_0.list_0[i + 1]);
					if (num2 != 1)
					{
					}
					if (num2 >= dxf_0.ColorCode.Length)
					{
						color_0 = Color.Black;
					}
					else
					{
						color_0 = dxf_0.ColorCode[num2];
					}
					if ((color_0.A == 0) & (color_0.R == 0) & (color_0.G == 0) & (color_0.B == 0))
					{
						color_0 = Color.Black;
					}
				}
				if (dxf_0.list_0[i] == " 10")
				{
					double_1 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
				}
				if (dxf_0.list_0[i] == " 20")
				{
					double_2 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
				}
				if (dxf_0.list_0[i] == " 30")
				{
					double_4 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
				}
				if (dxf_0.list_0[i] == " 11")
				{
					double_3 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
				}
				if (dxf_0.list_0[i] == " 21")
				{
					double_5 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
					if (dxf_0.list_0[i + 2] != " 31")
					{
						result = true;
						break;
					}
				}
				if (dxf_0.list_0[i] == " 31")
				{
					double_0 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
					result = true;
					break;
				}
				continue;
			}
			result = false;
			break;
		}
		return result;
	}

	static void smethod_223(IntPoint intPoint_0, Class153 class153_0, buClipper buClipper_0)
	{
		Class154 @class = new Class154();
		@class.class153_0 = class153_0;
		@class.intPoint_0 = intPoint_0;
		buClipper_0.list_4.Add(@class);
	}

	static Encoding smethod_224(string string_0)
	{
		if (string_0 != null)
		{
			string text = string_0.ToUpperInvariant();
			if (!EncodingFinder.smethod_0().ContainsKey(text))
			{
				try
				{
					if (!text.Contains("WINDOWS") && !text.Contains("CP"))
					{
						return Encoding.GetEncoding(string_0);
					}
					text = text.Replace("CP", "");
					text = text.Replace("WINDOWS", "");
					text = text.Replace("-", "");
					int codepage = int.Parse(text, CultureInfo.InvariantCulture);
					return Encoding.GetEncoding(codepage);
				}
				catch (ArgumentException)
				{
					if (EncodingFinder.FallbackDecoder == null)
					{
						throw;
					}
					Encoding encoding = EncodingFinder.FallbackDecoder(string_0);
					if (encoding == null)
					{
						throw;
					}
					return encoding;
				}
			}
			return EncodingFinder.smethod_0()[text];
		}
		throw new ArgumentNullException("characterSet");
	}

	static bool smethod_225(byte[] byte_0)
	{
		if (byte_0 != null)
		{
			return byte_0.Length == 1 && byte_0[0] == 46;
		}
		throw new ArgumentNullException("bytesReceived");
	}

	static bool smethod_226(DTSweepContext dtsweepContext_0, DelaunayTriangle delaunayTriangle_0)
	{
		for (int i = 0; i < 3; i++)
		{
			if (delaunayTriangle_0.EdgeIsDelaunay[i])
			{
				continue;
			}
			DelaunayTriangle delaunayTriangle = delaunayTriangle_0.Neighbors[i];
			if (delaunayTriangle == null)
			{
				continue;
			}
			TriangulationPoint triangulationPoint = delaunayTriangle_0.Points[i];
			TriangulationPoint triangulationPoint2 = delaunayTriangle.OppositePoint(delaunayTriangle_0, triangulationPoint);
			int index = delaunayTriangle.IndexOf(triangulationPoint2);
			if (!delaunayTriangle.EdgeIsConstrained[index] && !delaunayTriangle.EdgeIsDelaunay[index])
			{
				if (TriangulationUtil.SmartIncircle(triangulationPoint, delaunayTriangle_0.PointCCWFrom(triangulationPoint), delaunayTriangle_0.PointCWFrom(triangulationPoint), triangulationPoint2))
				{
					delaunayTriangle_0.EdgeIsDelaunay[i] = true;
					delaunayTriangle.EdgeIsDelaunay[index] = true;
					smethod_65(triangulationPoint2, delaunayTriangle, delaunayTriangle_0, triangulationPoint);
					if (!smethod_226(dtsweepContext_0, delaunayTriangle_0))
					{
						dtsweepContext_0.MapTriangleToNodes(delaunayTriangle_0);
					}
					if (!smethod_226(dtsweepContext_0, delaunayTriangle))
					{
						dtsweepContext_0.MapTriangleToNodes(delaunayTriangle);
					}
					delaunayTriangle_0.EdgeIsDelaunay[i] = false;
					delaunayTriangle.EdgeIsDelaunay[index] = false;
					return true;
				}
			}
			else
			{
				delaunayTriangle_0.SetConstrainedEdgeAcross(triangulationPoint, delaunayTriangle.EdgeIsConstrained[index]);
			}
		}
		return false;
	}

	static void smethod_227(DTSweepContext dtsweepContext_0, TriangulationConstraint triangulationConstraint_0, AdvancingFrontNode advancingFrontNode_0)
	{
		if (!dtsweepContext_0.EdgeEvent.Right)
		{
			smethod_107(advancingFrontNode_0, triangulationConstraint_0, dtsweepContext_0);
		}
		else
		{
			smethod_31(triangulationConstraint_0, advancingFrontNode_0, dtsweepContext_0);
		}
	}

	static bool smethod_228(buClipperBase buClipperBase_0, [Out] long long_0, ref Class149 class149_0)
	{
		class149_0 = buClipperBase_0.class149_1;
		if (buClipperBase_0.class149_1 == null || buClipperBase_0.class149_1.long_0 != long_0)
		{
			return false;
		}
		buClipperBase_0.class149_1 = buClipperBase_0.class149_1.class149_0;
		return true;
	}

	static string smethod_229(ref string string_0, [Out] string string_1)
	{
		if (string_1 != null)
		{
			if (string_1.IndexOf('\'') != -1)
			{
				string_0 = string_1.Substring(0, string_1.IndexOf('\''));
				string_1 = string_1.Substring(string_1.LastIndexOf('\'') + 1);
				return smethod_72(string_0, string_1);
			}
			DefaultLogger.Log.LogDebug("Rfc2231Decoder: Someone asked me to decode a string which was not encoded - returning raw string. Input: " + string_1);
			string_0 = null;
			return string_1;
		}
		throw new ArgumentNullException("toDecode");
	}

	static Class153 smethod_230(buClipper buClipper_0, Class148 class148_0, Class148 class148_1, IntPoint intPoint_0)
	{
		Class153 @class;
		Class148 class2;
		Class148 class3;
		if (!smethod_67(class148_1) && !(class148_0.double_0 > class148_1.double_0))
		{
			@class = smethod_246(buClipper_0, class148_1, intPoint_0);
			class148_0.int_3 = class148_1.int_3;
			class148_0.enum11_0 = Enum11.const_1;
			class148_1.enum11_0 = Enum11.const_0;
			class2 = class148_1;
			class3 = ((class2.class148_4 == class148_0) ? class148_0.class148_4 : class2.class148_4);
		}
		else
		{
			@class = smethod_246(buClipper_0, class148_0, intPoint_0);
			class148_1.int_3 = class148_0.int_3;
			class148_0.enum11_0 = Enum11.const_0;
			class148_1.enum11_0 = Enum11.const_1;
			class2 = class148_0;
			class3 = ((class2.class148_4 == class148_1) ? class148_1.class148_4 : class2.class148_4);
		}
		if (class3 != null && class3.int_3 >= 0 && class3.intPoint_2.Y < intPoint_0.Y && class2.intPoint_2.Y < intPoint_0.Y)
		{
			long num = smethod_101(class3, intPoint_0.Y);
			long num2 = smethod_101(class2, intPoint_0.Y);
			if (num == num2 && class2.int_0 != 0 && class3.int_0 != 0)
			{
				IntPoint intPoint_1 = new IntPoint(num, intPoint_0.Y);
				IntPoint intPoint_2 = class3.intPoint_2;
				IntPoint intPoint_3 = new IntPoint(num2, intPoint_0.Y);
				IntPoint intPoint_4 = class2.intPoint_2;
				bool bool_ = buClipper_0.bool_0;
				if (smethod_132(intPoint_3, intPoint_1, intPoint_2, intPoint_4, bool_))
				{
					Class153 class153_ = smethod_246(buClipper_0, class3, intPoint_0);
					smethod_22(class2.intPoint_2, class153_, @class, buClipper_0);
				}
			}
		}
		return @class;
	}

	static int smethod_231(Class160.Class163 class163_0)
	{
		return 32768 - class163_0.int_1;
	}

	static void smethod_232(buClipperBase buClipperBase_0, long long_0)
	{
		if (buClipperBase_0.class150_0 != null)
		{
			if (long_0 <= buClipperBase_0.class150_0.long_0)
			{
				Class150 class150_ = buClipperBase_0.class150_0;
				while (class150_.class150_0 != null && long_0 <= class150_.class150_0.long_0)
				{
					class150_ = class150_.class150_0;
				}
				if (long_0 != class150_.long_0)
				{
					Class150 @class = new Class150();
					@class.long_0 = long_0;
					@class.class150_0 = class150_.class150_0;
					class150_.class150_0 = @class;
				}
			}
			else
			{
				Class150 class2 = new Class150();
				class2.long_0 = long_0;
				class2.class150_0 = buClipperBase_0.class150_0;
				buClipperBase_0.class150_0 = class2;
			}
		}
		else
		{
			buClipperBase_0.class150_0 = new Class150();
			buClipperBase_0.class150_0.class150_0 = null;
			buClipperBase_0.class150_0.long_0 = long_0;
		}
	}

	static int smethod_233(TriangulationPoint triangulationPoint_0, DelaunayTriangle delaunayTriangle_0)
	{
		return (delaunayTriangle_0.IndexOf(triangulationPoint_0) + 1) % 3;
	}

	static DoublePoint smethod_234(IntPoint intPoint_0, IntPoint intPoint_1)
	{
		double num = intPoint_1.X - intPoint_0.X;
		double num2 = intPoint_1.Y - intPoint_0.Y;
		if (num != 0.0 || num2 != 0.0)
		{
			double num3 = 1.0 / Math.Sqrt(num * num + num2 * num2);
			num *= num3;
			num2 *= num3;
			return new DoublePoint(num2, 0.0 - num);
		}
		return default(DoublePoint);
	}

	static void smethod_235(buClipper buClipper_0)
	{
		for (int i = 0; i < buClipper_0.list_2.Count; i++)
		{
			IntersectNode intersectNode = buClipper_0.list_2[i];
			Class148 class148_ = intersectNode.class148_0;
			Class148 class148_2 = intersectNode.class148_1;
			IntPoint intPoint_ = intersectNode.intPoint_0;
			smethod_287(intPoint_, buClipper_0, class148_, class148_2);
			Class148 class148_3 = intersectNode.class148_0;
			Class148 class148_4 = intersectNode.class148_1;
			smethod_45(class148_4, class148_3, (buClipperBase)buClipper_0);
		}
		buClipper_0.list_2.Clear();
	}

	static DateTime smethod_236(string string_0)
	{
		if (string_0 != null)
		{
			string_0 = smethod_188(string_0);
			try
			{
				DateTime dateTime = smethod_52(string_0);
				if (!(dateTime == DateTime.MinValue))
				{
					smethod_124(dateTime, string_0);
					dateTime = new DateTime(dateTime.Ticks, DateTimeKind.Utc);
					return smethod_109(dateTime, string_0);
				}
				return dateTime;
			}
			catch (FormatException ex)
			{
				throw new ArgumentException("Could not parse date: " + ex.Message + ". Input was: \"" + string_0 + "\"", ex);
			}
			catch (ArgumentException ex2)
			{
				throw new ArgumentException("Could not parse date: " + ex2.Message + ". Input was: \"" + string_0 + "\"", ex2);
			}
		}
		throw new ArgumentNullException("inputDate");
	}

	static bool smethod_237(double double_0, buClipper buClipper_0, Class148 class148_0)
	{
		return class148_0 != null && (double)class148_0.intPoint_2.Y == double_0 && class148_0.class148_2 == null;
	}

	static bool smethod_238(Point2DList point2DList_0, Point2DList point2DList_1, out List<EdgeIntersectInfo> list_0)
	{
		list_0 = new List<EdgeIntersectInfo>();
		double epsilon = Math.Min(point2DList_1.Epsilon, point2DList_0.Epsilon);
		for (int i = 0; i < point2DList_1.Count; i++)
		{
			Point2D point2D = point2DList_1[i];
			Point2D point2D2 = point2DList_1[point2DList_1.NextIndex(i)];
			for (int j = 0; j < point2DList_0.Count; j++)
			{
				Point2D pIntersectionPt = new Point2D();
				Point2D point2D3 = point2DList_0[j];
				Point2D point2D4 = point2DList_0[point2DList_0.NextIndex(j)];
				if (TriangulationUtil.LinesIntersect2D(point2D, point2D2, point2D3, point2D4, ref pIntersectionPt, epsilon))
				{
					list_0.Add(new EdgeIntersectInfo(new Edge(point2D, point2D2), new Edge(point2D3, point2D4), pIntersectionPt));
				}
			}
		}
		return list_0.Count > 0;
	}

	static NameValueCollection smethod_239(string string_0)
	{
		if (string_0 != null)
		{
			NameValueCollection nameValueCollection = new NameValueCollection();
			using (StringReader stringReader = new StringReader(string_0))
			{
				string string_1;
				while (!string.IsNullOrEmpty(string_1 = stringReader.ReadLine()))
				{
					KeyValuePair<string, string> keyValuePair = smethod_165(string_1);
					string key = keyValuePair.Key;
					StringBuilder stringBuilder = new StringBuilder(keyValuePair.Value);
					while (smethod_299((TextReader)stringReader))
					{
						string text = stringReader.ReadLine();
						if (text != null)
						{
							stringBuilder.Append(text);
							continue;
						}
						throw new ArgumentException("This will never happen");
					}
					nameValueCollection.Add(key, stringBuilder.ToString());
				}
			}
			return nameValueCollection;
		}
		throw new ArgumentNullException("messageContent");
	}

	static double smethod_240(Point2D point2D_0, Point2D point2D_1)
	{
		return point2D_0.X * point2D_1.X + point2D_0.Y * point2D_1.Y;
	}

	static bool smethod_241(buClipper buClipper_0, long long_0, long long_1, long long_2, [Out] long long_3, out long long_4, ref long long_5)
	{
		if (long_0 >= long_1)
		{
			if (long_2 >= long_3)
			{
				long_4 = Math.Max(long_1, long_3);
				long_5 = Math.Min(long_0, long_2);
			}
			else
			{
				long_4 = Math.Max(long_1, long_2);
				long_5 = Math.Min(long_0, long_3);
			}
		}
		else if (long_2 >= long_3)
		{
			long_4 = Math.Max(long_0, long_3);
			long_5 = Math.Min(long_1, long_2);
		}
		else
		{
			long_4 = Math.Max(long_0, long_2);
			long_5 = Math.Min(long_1, long_3);
		}
		return long_4 < long_5;
	}

	static void smethod_242(Class153 class153_0, buClipper buClipper_0)
	{
		if (class153_0 != null)
		{
			Class153 @class = class153_0;
			do
			{
				Class153 class153_1 = @class.class153_0;
				@class.class153_0 = @class.class153_1;
				@class.class153_1 = class153_1;
				@class = class153_1;
			}
			while (@class != class153_0);
		}
	}

	static Class148 smethod_243(buClipperBase buClipperBase_0, Class148 class148_0, bool bool_0)
	{
		Class148 @class = class148_0;
		if (@class.int_3 != -2)
		{
			Class148 class2;
			if (class148_0.double_0 == -3.4E+38)
			{
				class2 = (bool_0 ? class148_0.class148_1 : class148_0.class148_0);
				if (class2.double_0 != -3.4E+38)
				{
					if (class2.intPoint_0.X != class148_0.intPoint_0.X)
					{
						smethod_284(buClipperBase_0, class148_0);
					}
				}
				else if (class2.intPoint_0.X != class148_0.intPoint_0.X && class2.intPoint_2.X != class148_0.intPoint_0.X)
				{
					smethod_284(buClipperBase_0, class148_0);
				}
			}
			class2 = class148_0;
			if (!bool_0)
			{
				while (@class.intPoint_2.Y == @class.class148_1.intPoint_0.Y && @class.class148_1.int_3 != -2)
				{
					@class = @class.class148_1;
				}
				if (@class.double_0 == -3.4E+38 && @class.class148_1.int_3 != -2)
				{
					Class148 class3 = @class;
					while (class3.class148_0.double_0 == -3.4E+38)
					{
						class3 = class3.class148_0;
					}
					if (class3.class148_0.intPoint_2.X == @class.class148_1.intPoint_2.X || class3.class148_0.intPoint_2.X > @class.class148_1.intPoint_2.X)
					{
						@class = class3.class148_0;
					}
				}
				while (class148_0 != @class)
				{
					class148_0.class148_2 = class148_0.class148_1;
					if (class148_0.double_0 == -3.4E+38 && class148_0 != class2 && class148_0.intPoint_0.X != class148_0.class148_0.intPoint_2.X)
					{
						smethod_284(buClipperBase_0, class148_0);
					}
					class148_0 = class148_0.class148_1;
				}
				if (class148_0.double_0 == -3.4E+38 && class148_0 != class2 && class148_0.intPoint_0.X != class148_0.class148_0.intPoint_2.X)
				{
					smethod_284(buClipperBase_0, class148_0);
				}
				@class = @class.class148_1;
			}
			else
			{
				while (@class.intPoint_2.Y == @class.class148_0.intPoint_0.Y && @class.class148_0.int_3 != -2)
				{
					@class = @class.class148_0;
				}
				if (@class.double_0 == -3.4E+38 && @class.class148_0.int_3 != -2)
				{
					Class148 class3 = @class;
					while (class3.class148_1.double_0 == -3.4E+38)
					{
						class3 = class3.class148_1;
					}
					if (class3.class148_1.intPoint_2.X > @class.class148_0.intPoint_2.X)
					{
						@class = class3.class148_1;
					}
				}
				while (class148_0 != @class)
				{
					class148_0.class148_2 = class148_0.class148_0;
					if (class148_0.double_0 == -3.4E+38 && class148_0 != class2 && class148_0.intPoint_0.X != class148_0.class148_1.intPoint_2.X)
					{
						smethod_284(buClipperBase_0, class148_0);
					}
					class148_0 = class148_0.class148_0;
				}
				if (class148_0.double_0 == -3.4E+38 && class148_0 != class2 && class148_0.intPoint_0.X != class148_0.class148_1.intPoint_2.X)
				{
					smethod_284(buClipperBase_0, class148_0);
				}
				@class = @class.class148_0;
			}
			return @class;
		}
		class148_0 = @class;
		if (!bool_0)
		{
			while (class148_0.intPoint_2.Y == class148_0.class148_1.intPoint_0.Y)
			{
				class148_0 = class148_0.class148_1;
			}
			while (class148_0 != @class && class148_0.double_0 == -3.4E+38)
			{
				class148_0 = class148_0.class148_0;
			}
		}
		else
		{
			while (class148_0.intPoint_2.Y == class148_0.class148_0.intPoint_0.Y)
			{
				class148_0 = class148_0.class148_0;
			}
			while (class148_0 != @class && class148_0.double_0 == -3.4E+38)
			{
				class148_0 = class148_0.class148_1;
			}
		}
		if (class148_0 == @class)
		{
			@class = (bool_0 ? class148_0.class148_0 : class148_0.class148_1);
		}
		else
		{
			class148_0 = (bool_0 ? @class.class148_0 : @class.class148_1);
			Class149 class4 = new Class149();
			class4.class149_0 = null;
			class4.long_0 = class148_0.intPoint_0.Y;
			class4.class148_0 = null;
			class4.class148_1 = class148_0;
			class148_0.int_0 = 0;
			@class = smethod_243(buClipperBase_0, class148_0, bool_0);
			smethod_92(buClipperBase_0, class4);
		}
		return @class;
	}

	static void smethod_244(MessageHeader messageHeader_0, NameValueCollection nameValueCollection_0)
	{
		if (nameValueCollection_0 != null)
		{
			foreach (string key in nameValueCollection_0.Keys)
			{
				string[] values = nameValueCollection_0.GetValues(key);
				if (values != null)
				{
					string[] array = values;
					foreach (string string_ in array)
					{
						smethod_44(string_, messageHeader_0, key);
					}
				}
			}
			return;
		}
		throw new ArgumentNullException("headers");
	}

	static void smethod_245(DTSweepContext dtsweepContext_0)
	{
		AdvancingFrontNode next = dtsweepContext_0.Front.Head.Next;
		AdvancingFrontNode next2 = next.Next;
		smethod_187(next2, next, dtsweepContext_0);
		next = dtsweepContext_0.Front.Tail.Prev;
		DelaunayTriangle delaunayTriangle;
		if (next.Triangle.Contains(next.Next.Point) && next.Triangle.Contains(next.Prev.Point))
		{
			delaunayTriangle = next.Triangle.NeighborAcrossFrom(next.Point);
			DelaunayTriangle triangle = next.Triangle;
			TriangulationPoint point = next.Point;
			TriangulationPoint triangulationPoint_ = delaunayTriangle.OppositePoint(next.Triangle, next.Point);
			smethod_65(triangulationPoint_, delaunayTriangle, triangle, point);
			dtsweepContext_0.MapTriangleToNodes(next.Triangle);
			dtsweepContext_0.MapTriangleToNodes(delaunayTriangle);
		}
		next = dtsweepContext_0.Front.Head.Next;
		if (next.Triangle.Contains(next.Prev.Point) && next.Triangle.Contains(next.Next.Point))
		{
			delaunayTriangle = next.Triangle.NeighborAcrossFrom(next.Point);
			DelaunayTriangle triangle = next.Triangle;
			TriangulationPoint point = next.Point;
			TriangulationPoint triangulationPoint_ = delaunayTriangle.OppositePoint(next.Triangle, next.Point);
			smethod_65(triangulationPoint_, delaunayTriangle, triangle, point);
			dtsweepContext_0.MapTriangleToNodes(next.Triangle);
			dtsweepContext_0.MapTriangleToNodes(delaunayTriangle);
		}
		TriangulationPoint point2 = dtsweepContext_0.Front.Head.Point;
		next2 = dtsweepContext_0.Front.Tail.Prev;
		delaunayTriangle = next2.Triangle;
		TriangulationPoint triangulationPoint = next2.Point;
		next2.Triangle = null;
		DelaunayTriangle delaunayTriangle2;
		while (true)
		{
			dtsweepContext_0.RemoveFromList(delaunayTriangle);
			triangulationPoint = delaunayTriangle.PointCCWFrom(triangulationPoint);
			if (!triangulationPoint.Equals(point2))
			{
				delaunayTriangle2 = delaunayTriangle.NeighborCCWFrom(triangulationPoint);
				delaunayTriangle.Clear();
				delaunayTriangle = delaunayTriangle2;
				continue;
			}
			break;
		}
		point2 = dtsweepContext_0.Front.Head.Next.Point;
		triangulationPoint = delaunayTriangle.PointCWFrom(dtsweepContext_0.Front.Head.Point);
		delaunayTriangle2 = delaunayTriangle.NeighborCWFrom(dtsweepContext_0.Front.Head.Point);
		delaunayTriangle.Clear();
		delaunayTriangle = delaunayTriangle2;
		while (triangulationPoint.Equals(point2))
		{
			dtsweepContext_0.RemoveFromList(delaunayTriangle);
			triangulationPoint = delaunayTriangle.PointCCWFrom(triangulationPoint);
			delaunayTriangle2 = delaunayTriangle.NeighborCCWFrom(triangulationPoint);
			delaunayTriangle.Clear();
			delaunayTriangle = delaunayTriangle2;
		}
		dtsweepContext_0.Front.Head = dtsweepContext_0.Front.Head.Next;
		dtsweepContext_0.Front.Head.Prev = null;
		dtsweepContext_0.Front.Tail = dtsweepContext_0.Front.Tail.Prev;
		dtsweepContext_0.Front.Tail.Next = null;
	}

	static Class153 smethod_246(buClipper buClipper_0, Class148 class148_0, IntPoint intPoint_0)
	{
		if (class148_0.int_3 >= 0)
		{
			Class152 @class = buClipper_0.list_1[class148_0.int_3];
			Class153 class153_ = @class.class153_0;
			bool flag;
			if (!(flag = class148_0.enum11_0 == Enum11.const_0) || !(intPoint_0 == class153_.intPoint_0))
			{
				if (flag || !(intPoint_0 == class153_.class153_1.intPoint_0))
				{
					Class153 class2 = new Class153();
					class2.int_0 = @class.int_0;
					class2.intPoint_0 = intPoint_0;
					class2.class153_0 = class153_;
					class2.class153_1 = class153_.class153_1;
					class2.class153_1.class153_0 = class2;
					class153_.class153_1 = class2;
					if (flag)
					{
						@class.class153_0 = class2;
					}
					return class2;
				}
				return class153_.class153_1;
			}
			return class153_;
		}
		Class152 class3 = smethod_185((buClipperBase)buClipper_0);
		class3.bool_1 = class148_0.int_0 == 0;
		Class153 class4 = (class3.class153_0 = new Class153());
		class4.int_0 = class3.int_0;
		class4.intPoint_0 = intPoint_0;
		class4.class153_0 = class4;
		class4.class153_1 = class4;
		if (!class3.bool_1)
		{
			smethod_262(class148_0, buClipper_0, class3);
		}
		class148_0.int_3 = class3.int_0;
		return class4;
	}

	static Class153 smethod_247(Class153 class153_0)
	{
		Class153 class153_1 = class153_0.class153_1;
		class153_1.class153_0 = class153_0.class153_0;
		class153_0.class153_0.class153_1 = class153_1;
		class153_1.int_0 = 0;
		return class153_1;
	}

	static int smethod_248(Class153 class153_0, IntPoint intPoint_0)
	{
		int num = 0;
		Class153 @class = class153_0;
		long x = intPoint_0.X;
		long y = intPoint_0.Y;
		long num2 = class153_0.intPoint_0.X;
		long num3 = class153_0.intPoint_0.Y;
		while (true)
		{
			class153_0 = class153_0.class153_0;
			long x2 = class153_0.intPoint_0.X;
			long y2 = class153_0.intPoint_0.Y;
			if (y2 != y || (x2 != x && (num3 != y || x2 > x != num2 < x)))
			{
				if (num3 < y != y2 < y)
				{
					if (num2 < x)
					{
						if (x2 > x)
						{
							double num4 = (double)(num2 - x) * (double)(y2 - y) - (double)(x2 - x) * (double)(num3 - y);
							if (num4 == 0.0)
							{
								break;
							}
							if (num4 > 0.0 == y2 > num3)
							{
								num = 1 - num;
							}
						}
					}
					else if (x2 <= x)
					{
						double num5 = (double)(num2 - x) * (double)(y2 - y) - (double)(x2 - x) * (double)(num3 - y);
						if (num5 == 0.0)
						{
							return -1;
						}
						if (num5 > 0.0 == y2 > num3)
						{
							num = 1 - num;
						}
					}
					else
					{
						num = 1 - num;
					}
				}
				num2 = x2;
				num3 = y2;
				if (@class == class153_0)
				{
					return num;
				}
				continue;
			}
			return -1;
		}
		return -1;
	}

	static double smethod_249(IntPoint intPoint_0, buClipper buClipper_0, IntPoint intPoint_1)
	{
		if (intPoint_1.Y != intPoint_0.Y)
		{
			return (double)(intPoint_0.X - intPoint_1.X) / (double)(intPoint_0.Y - intPoint_1.Y);
		}
		return -3.4E+38;
	}

	static bool smethod_250(ref double double_0, int int_0, ref string string_0, ref double double_1, ref Color color_0, buFile.Dxf dxf_0, ref double double_2, ref double double_3, ref double double_4)
	{
		bool flag = true;
		bool flag2 = true;
		bool flag3 = true;
		bool result = false;
		bool flag4 = false;
		bool flag5 = false;
		int num = 0;
		for (int i = int_0; i <= dxf_0.list_0.Count - 1; i++)
		{
			if (num < 80)
			{
				num++;
				if (!(flag4 && flag5))
				{
					if (flag & (dxf_0.list_0[i] == "AcDbEntity"))
					{
						string_0 = dxf_0.list_0[i + 2];
					}
					if (flag & (dxf_0.list_0[i] == "  8"))
					{
						string_0 = dxf_0.list_0[i + 1];
					}
					if (flag & (dxf_0.list_0[i] == "AcDbCircle"))
					{
						flag2 = true;
					}
					if (flag & (dxf_0.list_0[i] == "AcDbArc"))
					{
						flag3 = true;
					}
					if (flag & (dxf_0.list_0[i] == "CONTINUOUS"))
					{
						flag2 = true;
						flag3 = true;
					}
					if (flag & (dxf_0.list_0[i] == " 62"))
					{
						int num2 = Convert.ToInt32(dxf_0.list_0[i + 1]);
						if (num2 >= dxf_0.ColorCode.Length)
						{
							color_0 = Color.Black;
						}
						else
						{
							color_0 = dxf_0.ColorCode[num2];
						}
						if ((color_0.A == 0) & (color_0.R == 0) & (color_0.G == 0) & (color_0.B == 0))
						{
							color_0 = Color.Black;
						}
					}
					if (flag2 & (dxf_0.list_0[i] == " 10"))
					{
						double_2 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
					}
					if (flag2 & (dxf_0.list_0[i] == " 20"))
					{
						double_0 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
					}
					if (flag2 & (dxf_0.list_0[i] == " 40"))
					{
						double_4 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
					}
					if (flag3 & (dxf_0.list_0[i] == " 50"))
					{
						double_1 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
						flag5 = true;
					}
					if (flag3 & (dxf_0.list_0[i] == " 51"))
					{
						double_3 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
						flag4 = true;
					}
					continue;
				}
				if (double_1 > double_3)
				{
					double_3 += 360.0;
				}
				result = true;
				break;
			}
			result = false;
			break;
		}
		return result;
	}

	static ICryptoTransform smethod_251(byte[] byte_0, bool bool_0, byte[] byte_1)
	{
		using AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider();
		return (!bool_0) ? aesCryptoServiceProvider.CreateEncryptor(byte_1, byte_0) : aesCryptoServiceProvider.CreateDecryptor(byte_1, byte_0);
	}

	static bool smethod_252(Class160.Class162 class162_0)
	{
		return class162_0.int_0 == class162_0.int_1;
	}

	static void smethod_253(int int_0, DelaunayTriangle delaunayTriangle_0, bool bool_0)
	{
		delaunayTriangle_0.fixedArray3_0[int_0] = bool_0;
	}

	static void smethod_254(ref Color color_0, ref double double_0, ref string string_0, int int_0, buFile.Dxf dxf_0, ref double double_1, ref double double_2)
	{
		bool flag = true;
		bool flag2 = true;
		for (int i = int_0; i <= dxf_0.list_0.Count - 1; i++)
		{
			if (flag & (dxf_0.list_0[i] == "AcDbEntity"))
			{
				string_0 = dxf_0.list_0[i + 2];
			}
			if (flag & (dxf_0.list_0[i] == "  8"))
			{
				string_0 = dxf_0.list_0[i + 1];
			}
			if (flag & (dxf_0.list_0[i] == "AcDbCircle"))
			{
				flag2 = true;
			}
			if (flag & (dxf_0.list_0[i] == "CONTINUOUS"))
			{
				flag2 = true;
			}
			if (flag & (dxf_0.list_0[i] == " 62"))
			{
				int num = Convert.ToInt32(dxf_0.list_0[i + 1]);
				if (num >= dxf_0.ColorCode.Length)
				{
					color_0 = Color.Black;
				}
				else
				{
					color_0 = dxf_0.ColorCode[num];
				}
				if ((color_0.A == 0) & (color_0.R == 0) & (color_0.G == 0) & (color_0.B == 0))
				{
					color_0 = Color.Black;
				}
			}
			if (flag2 & (dxf_0.list_0[i] == " 10"))
			{
				double_0 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
			}
			if (flag2 & (dxf_0.list_0[i] == " 20"))
			{
				double_1 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
			}
			if (flag2 & (dxf_0.list_0[i] == " 40"))
			{
				double_2 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
				break;
			}
		}
	}

	static bool smethod_255(buFile.Dxf dxf_0, double double_0, double double_1)
	{
		double num = Math.Abs(double_0 - double_1);
		if (!(num < dxf_0.double_2))
		{
			return false;
		}
		return true;
	}

	static double smethod_256(buFile.Dxf dxf_0, string string_0)
	{
		return Convert.ToDouble(string_0, dxf_0.numberFormatInfo_0);
	}

	static bool smethod_257(AdvancingFrontNode advancingFrontNode_0, DTSweepContext dtsweepContext_0)
	{
		double num = (dtsweepContext_0.Basin.LeftHighest ? (dtsweepContext_0.Basin.LeftNode.Point.Y - advancingFrontNode_0.Point.Y) : (dtsweepContext_0.Basin.RightNode.Point.Y - advancingFrontNode_0.Point.Y));
		if (!(dtsweepContext_0.Basin.Width > num))
		{
			return false;
		}
		return true;
	}

	static int smethod_258(Class153 class153_0, buClipper buClipper_0)
	{
		if (class153_0 != null)
		{
			int num = 0;
			Class153 @class = class153_0;
			do
			{
				num++;
				@class = @class.class153_0;
			}
			while (@class != class153_0);
			return num;
		}
		return 0;
	}

	static void smethod_259(long long_0, buClipper buClipper_0)
	{
		if (buClipper_0.class148_0 == null)
		{
			return;
		}
		for (Class148 @class = (buClipper_0.class148_1 = buClipper_0.class148_0); @class != null; @class = @class.class148_3)
		{
			@class.class148_6 = @class.class148_4;
			@class.class148_5 = @class.class148_3;
			@class.intPoint_1.X = smethod_101(@class, long_0);
		}
		bool flag = true;
		IntPoint intPoint_ = default(IntPoint);
		while (flag && buClipper_0.class148_1 != null)
		{
			flag = false;
			Class148 @class = buClipper_0.class148_1;
			while (@class.class148_5 != null)
			{
				Class148 class148_ = @class.class148_5;
				if (@class.intPoint_1.X <= class148_.intPoint_1.X)
				{
					@class = class148_;
					continue;
				}
				smethod_108(ref intPoint_, @class, class148_, buClipper_0);
				if (intPoint_.Y < long_0)
				{
					intPoint_ = new IntPoint(smethod_101(@class, long_0), long_0);
				}
				IntersectNode intersectNode = new IntersectNode();
				intersectNode.class148_0 = @class;
				intersectNode.class148_1 = class148_;
				intersectNode.intPoint_0 = intPoint_;
				buClipper_0.list_2.Add(intersectNode);
				smethod_35(buClipper_0, @class, class148_);
				flag = true;
			}
			if (@class.class148_6 == null)
			{
				break;
			}
			@class.class148_6.class148_5 = null;
		}
		buClipper_0.class148_1 = null;
	}

	static void smethod_260(buClipperBase buClipperBase_0, Class148 class148_0)
	{
		class148_0.intPoint_3.X = class148_0.intPoint_2.X - class148_0.intPoint_0.X;
		class148_0.intPoint_3.Y = class148_0.intPoint_2.Y - class148_0.intPoint_0.Y;
		if (class148_0.intPoint_3.Y != 0L)
		{
			class148_0.double_0 = (double)class148_0.intPoint_3.X / (double)class148_0.intPoint_3.Y;
		}
		else
		{
			class148_0.double_0 = -3.4E+38;
		}
	}

	static List<IntPoint> smethod_261(IntPoint intPoint_0, List<IntPoint> list_0)
	{
		List<IntPoint> list = new List<IntPoint>(list_0.Count);
		for (int i = 0; i < list_0.Count; i++)
		{
			list.Add(new IntPoint(list_0[i].X + intPoint_0.X, list_0[i].Y + intPoint_0.Y));
		}
		return list;
	}

	static void smethod_262(Class148 class148_0, buClipper buClipper_0, Class152 class152_0)
	{
		Class148 class148_1 = class148_0.class148_4;
		Class148 @class = null;
		while (class148_1 != null)
		{
			if (class148_1.int_3 >= 0 && class148_1.int_0 != 0)
			{
				if (@class != null)
				{
					if (@class.int_3 == class148_1.int_3)
					{
						@class = null;
					}
				}
				else
				{
					@class = class148_1;
				}
			}
			class148_1 = class148_1.class148_4;
		}
		if (@class != null)
		{
			class152_0.class152_0 = buClipper_0.list_1[@class.int_3];
			class152_0.bool_0 = !class152_0.class152_0.bool_0;
		}
		else
		{
			class152_0.class152_0 = null;
			class152_0.bool_0 = false;
		}
	}

	static void smethod_263(TriangulationPoint triangulationPoint_0, TriangulationPoint triangulationPoint_1, DelaunayTriangle delaunayTriangle_0, DelaunayTriangle delaunayTriangle_1)
	{
		int num = delaunayTriangle_1.EdgeIndex(triangulationPoint_0, triangulationPoint_1);
		if (num == -1)
		{
			throw new Exception("Error marking neighbors -- t doesn't contain edge p1-p2!");
		}
		delaunayTriangle_1.Neighbors[num] = delaunayTriangle_0;
	}

	static void smethod_264(Pop3Client pop3Client_0, string string_0, string string_1)
	{
		try
		{
			smethod_144(pop3Client_0, "AUTH CRAM-MD5");
		}
		catch (PopServerException innerException)
		{
			throw new NotSupportedException("CRAM-MD5 authentication not supported", innerException);
		}
		string string_2 = pop3Client_0.method_2().Substring(2);
		string string_3 = smethod_39(string_2, string_0, string_1);
		smethod_144(pop3Client_0, string_3);
	}

	static long smethod_265(string string_0)
	{
		string_0 = string_0.Trim();
		string text = smethod_26(string_0);
		string s = string_0.Substring(0, string_0.Length - text.Length).Trim();
		long num = smethod_128(text);
		double num2 = double.Parse(s, NumberStyles.Number, CultureInfo.InvariantCulture);
		return (long)((double)num * num2);
	}

	static int smethod_266(Class160.Class164 class164_0, Class160.Class162 class162_0)
	{
		int num;
		int num2;
		if ((num = smethod_292(class162_0, 9)) < 0)
		{
			int int_ = class162_0.int_2;
			num = smethod_292(class162_0, int_);
			num2 = class164_0.short_0[num];
			if (num2 < 0 || (num2 & 0xF) > int_)
			{
				return -1;
			}
			smethod_94(class162_0, num2 & 0xF);
			return num2 >> 4;
		}
		if ((num2 = class164_0.short_0[num]) < 0)
		{
			int num3 = -(num2 >> 4);
			int int_2 = num2 & 0xF;
			if ((num = smethod_292(class162_0, int_2)) < 0)
			{
				int int_3 = class162_0.int_2;
				num = smethod_292(class162_0, int_3);
				num2 = class164_0.short_0[num3 | (num >> 9)];
				if ((num2 & 0xF) > int_3)
				{
					return -1;
				}
				smethod_94(class162_0, num2 & 0xF);
				return num2 >> 4;
			}
			num2 = class164_0.short_0[num3 | (num >> 9)];
			smethod_94(class162_0, num2 & 0xF);
			return num2 >> 4;
		}
		smethod_94(class162_0, num2 & 0xF);
		return num2 >> 4;
	}

	static RfcMailAddress smethod_267(string string_0)
	{
		if (string_0 != null)
		{
			string_0 = smethod_179(string_0.Trim());
			int num = string_0.LastIndexOf('<');
			int num2 = string_0.LastIndexOf('>');
			try
			{
				if (num >= 0 && num2 >= 0)
				{
					string displayName = ((num > 0) ? string_0.Substring(0, num).Trim() : string.Empty);
					num++;
					int length = num2 - num;
					string text = string_0.Substring(num, length).Trim();
					if (!string.IsNullOrEmpty(text))
					{
						return new RfcMailAddress(new MailAddress(text, displayName), string_0);
					}
				}
				if (string_0.Contains("@"))
				{
					return new RfcMailAddress(new MailAddress(string_0), string_0);
				}
			}
			catch (FormatException)
			{
				DefaultLogger.Log.LogError("RfcMailAddress: Improper mail address: \"" + string_0 + "\"");
			}
			return new RfcMailAddress(string_0);
		}
		throw new ArgumentNullException("input");
	}

	static Encoding smethod_268(string string_0)
	{
		Encoding result = Encoding.ASCII;
		if (!string.IsNullOrEmpty(string_0))
		{
			result = smethod_224(string_0);
		}
		return result;
	}

	static void smethod_269(DTSweepContext dtsweepContext_0, AdvancingFrontNode advancingFrontNode_0)
	{
		if (smethod_257(advancingFrontNode_0, dtsweepContext_0))
		{
			return;
		}
		smethod_51(dtsweepContext_0, advancingFrontNode_0);
		if (advancingFrontNode_0.Prev == dtsweepContext_0.Basin.LeftNode && advancingFrontNode_0.Next == dtsweepContext_0.Basin.RightNode)
		{
			return;
		}
		if (advancingFrontNode_0.Prev != dtsweepContext_0.Basin.LeftNode)
		{
			if (advancingFrontNode_0.Next != dtsweepContext_0.Basin.RightNode)
			{
				advancingFrontNode_0 = ((advancingFrontNode_0.Prev.Point.Y >= advancingFrontNode_0.Next.Point.Y) ? advancingFrontNode_0.Next : advancingFrontNode_0.Prev);
			}
			else
			{
				Orientation orientation = TriangulationUtil.Orient2d(advancingFrontNode_0.Point, advancingFrontNode_0.Prev.Point, advancingFrontNode_0.Prev.Prev.Point);
				if (orientation == Orientation.AntiClockwise)
				{
					return;
				}
				advancingFrontNode_0 = advancingFrontNode_0.Prev;
			}
		}
		else
		{
			if (TriangulationUtil.Orient2d(advancingFrontNode_0.Point, advancingFrontNode_0.Next.Point, advancingFrontNode_0.Next.Next.Point) == Orientation.Clockwise)
			{
				return;
			}
			advancingFrontNode_0 = advancingFrontNode_0.Next;
		}
		smethod_269(dtsweepContext_0, advancingFrontNode_0);
	}

	static buFile.PLYToSchematic.Class146 smethod_270(StreamReader streamReader_0)
	{
		buFile.PLYToSchematic.Class146 @class = new buFile.PLYToSchematic.Class146();
		int num = 0;
		string text = streamReader_0.ReadLine();
		num = 0 + (text.Length + 1);
		if (!(text != "ply"))
		{
			text = streamReader_0.ReadLine();
			num += text.Length + 1;
			@class.bool_0 = text == "format binary_little_endian 1.0";
			bool flag = false;
			while (true)
			{
				text = streamReader_0.ReadLine();
				num += text.Length + 1;
				if (text == "end_header")
				{
					break;
				}
				string[] array = text.Split();
				if (array[0] == "element")
				{
					if (!(array[1] == "vertex"))
					{
						flag = true;
					}
					else
					{
						@class.int_0 = Convert.ToInt32(array[2]);
						flag = false;
					}
				}
				if (flag || !(array[0] == "property"))
				{
					continue;
				}
				buFile.PLYToSchematic.Enum10 @enum = buFile.PLYToSchematic.Enum10.const_0;
				string text2 = array[2];
				string text3 = text2;
				uint num2 = smethod_119(text3);
				if (num2 > 1569418667)
				{
					if (num2 > 4228665076u)
					{
						if (num2 == 4245442695u)
						{
							if (text3 == "x")
							{
								@enum = buFile.PLYToSchematic.Enum10.const_9;
							}
						}
						else if (num2 == 4278997933u && text3 == "z")
						{
							@enum = buFile.PLYToSchematic.Enum10.const_11;
						}
					}
					else if (num2 == 2197550541u)
					{
						if (text3 == "blue")
						{
							@enum = buFile.PLYToSchematic.Enum10.const_3;
						}
					}
					else if (num2 == 4228665076u && text3 == "y")
					{
						@enum = buFile.PLYToSchematic.Enum10.const_10;
					}
				}
				else if (num2 == 18738364)
				{
					if (text3 == "green")
					{
						@enum = buFile.PLYToSchematic.Enum10.const_2;
					}
				}
				else if (num2 == 1089765596)
				{
					if (text3 == "red")
					{
						@enum = buFile.PLYToSchematic.Enum10.const_1;
					}
				}
				else if (num2 == 1569418667 && text3 == "alpha")
				{
					@enum = buFile.PLYToSchematic.Enum10.const_4;
				}
				string text4 = array[1];
				string text5 = text4;
				num2 = smethod_119(text5);
				if (num2 > 2699759368u)
				{
					if (num2 > 2929723411u)
					{
						if (num2 > 3415750305u)
						{
							if (num2 != 3473883116u)
							{
								if (num2 == 3902764048u)
								{
									if (!(text5 == "float32"))
									{
										goto IL_0326;
									}
								}
								else if (num2 != 4225688255u || !(text5 == "int32"))
								{
									goto IL_0326;
								}
								goto IL_03e2;
							}
							if (text5 == "uchar")
							{
								goto IL_012b;
							}
						}
						else if (num2 == 3122818005u)
						{
							if (text5 == "short")
							{
								goto IL_0373;
							}
						}
						else if (num2 == 3415750305u && text5 == "uint")
						{
							goto IL_03e2;
						}
					}
					else if (num2 > 2823553821u)
					{
						if (num2 == 2928590578u)
						{
							if (text5 == "uint16")
							{
								goto IL_0373;
							}
						}
						else if (num2 == 2929723411u && text5 == "uint64")
						{
							goto IL_02c3;
						}
					}
					else if (num2 == 2797886853u)
					{
						if (text5 == "float")
						{
							goto IL_03e2;
						}
					}
					else if (num2 == 2823553821u && text5 == "char")
					{
						goto IL_012b;
					}
				}
				else if (num2 > 848563180)
				{
					if (num2 > 1687288466)
					{
						if (num2 == 2090339911)
						{
							if (text5 == "float64")
							{
								goto IL_02c3;
							}
						}
						else if (num2 == 2515107422u)
						{
							if (text5 == "int")
							{
								goto IL_03e2;
							}
						}
						else if (num2 == 2699759368u && text5 == "double")
						{
							goto IL_02c3;
						}
					}
					else if (num2 == 1630192034)
					{
						if (text5 == "ushort")
						{
							goto IL_0373;
						}
					}
					else if (num2 == 1687288466 && text5 == "int8")
					{
						goto IL_012b;
					}
				}
				else if (num2 > 132346577)
				{
					if (num2 == 429781723)
					{
						if (text5 == "uint8")
						{
							goto IL_012b;
						}
					}
					else if (num2 == 848563180 && text5 == "uint32")
					{
						goto IL_03e2;
					}
				}
				else if (num2 == 64103268)
				{
					if (text5 == "int64")
					{
						goto IL_02c3;
					}
				}
				else if (num2 == 132346577 && text5 == "int16")
				{
					goto IL_0373;
				}
				goto IL_0326;
				IL_0326:
				throw new ArgumentException("Unsupported property type ('" + text + "').");
				IL_012b:
				if (@enum != buFile.PLYToSchematic.Enum10.const_0)
				{
					if (smethod_50(@enum) != 1)
					{
						throw new ArgumentException("Invalid property type ('" + text + "').");
					}
				}
				else
				{
					@enum = buFile.PLYToSchematic.Enum10.const_15;
				}
				goto IL_0147;
				IL_0373:
				switch (@enum)
				{
				case buFile.PLYToSchematic.Enum10.const_4:
					@enum = buFile.PLYToSchematic.Enum10.const_8;
					break;
				case buFile.PLYToSchematic.Enum10.const_0:
					@enum = buFile.PLYToSchematic.Enum10.const_16;
					break;
				case buFile.PLYToSchematic.Enum10.const_1:
					@enum = buFile.PLYToSchematic.Enum10.const_5;
					break;
				case buFile.PLYToSchematic.Enum10.const_2:
					@enum = buFile.PLYToSchematic.Enum10.const_6;
					break;
				case buFile.PLYToSchematic.Enum10.const_3:
					@enum = buFile.PLYToSchematic.Enum10.const_7;
					break;
				}
				if (smethod_50(@enum) != 2)
				{
					throw new ArgumentException("Invalid property type ('" + text + "').");
				}
				goto IL_0147;
				IL_03e2:
				if (@enum != buFile.PLYToSchematic.Enum10.const_0)
				{
					if (smethod_50(@enum) != 4)
					{
						throw new ArgumentException("Invalid property type ('" + text + "').");
					}
				}
				else
				{
					@enum = buFile.PLYToSchematic.Enum10.const_17;
				}
				goto IL_0147;
				IL_0147:
				@class.list_0.Add(@enum);
				continue;
				IL_02c3:
				switch (@enum)
				{
				case buFile.PLYToSchematic.Enum10.const_0:
					@enum = buFile.PLYToSchematic.Enum10.const_18;
					break;
				case buFile.PLYToSchematic.Enum10.const_11:
					@enum = buFile.PLYToSchematic.Enum10.const_14;
					break;
				case buFile.PLYToSchematic.Enum10.const_9:
					@enum = buFile.PLYToSchematic.Enum10.const_12;
					break;
				case buFile.PLYToSchematic.Enum10.const_10:
					@enum = buFile.PLYToSchematic.Enum10.const_13;
					break;
				}
				if (smethod_50(@enum) != 8)
				{
					throw new ArgumentException("Invalid property type ('" + text + "').");
				}
				goto IL_0147;
			}
			streamReader_0.BaseStream.Position = num;
			return @class;
		}
		throw new ArgumentException("Magic number ('ply') mismatch.");
	}

	static void smethod_271(AdvancingFrontNode advancingFrontNode_0, DTSweepContext dtsweepContext_0, TriangulationConstraint triangulationConstraint_0)
	{
		if (dtsweepContext_0.IsDebugEnabled)
		{
			dtsweepContext_0.DebugContext.ActiveNode = advancingFrontNode_0;
		}
		if (advancingFrontNode_0.Point.X < triangulationConstraint_0.P.X)
		{
			if (TriangulationUtil.Orient2d(advancingFrontNode_0.Point, advancingFrontNode_0.Next.Point, advancingFrontNode_0.Next.Next.Point) != Orientation.AntiClockwise)
			{
				smethod_157(triangulationConstraint_0, advancingFrontNode_0, dtsweepContext_0);
				smethod_271(advancingFrontNode_0, dtsweepContext_0, triangulationConstraint_0);
			}
			else
			{
				smethod_123(triangulationConstraint_0, advancingFrontNode_0, dtsweepContext_0);
			}
		}
	}

	static Class152 smethod_272(buClipper buClipper_0, int int_0)
	{
		Class152 @class;
		for (@class = buClipper_0.list_1[int_0]; @class != buClipper_0.list_1[@class.int_0]; @class = buClipper_0.list_1[@class.int_0])
		{
		}
		return @class;
	}

	static bool smethod_273(buClipper buClipper_0, Class148 class148_0)
	{
		if (class148_0.polyType_0 != PolyType.ptSubject)
		{
			return buClipper_0.polyFillType_0 == PolyFillType.pftEvenOdd;
		}
		return buClipper_0.polyFillType_1 == PolyFillType.pftEvenOdd;
	}

	static void smethod_274(MessagePart messagePart_0, byte[] byte_0)
	{
		if (!messagePart_0.IsMultiPart)
		{
			messagePart_0.Body = smethod_178(messagePart_0.ContentTransferEncoding, byte_0);
		}
		else
		{
			messagePart_0.method_0(byte_0);
		}
	}

	static byte[] smethod_275(string string_0)
	{
		if (string_0 == null)
		{
			throw new ArgumentNullException("toDecode");
		}
		return smethod_297(string_0, false);
	}

	static void smethod_276(buClipperBase buClipperBase_0, int int_0)
	{
		Class152 @class = buClipperBase_0.list_1[int_0];
		@class.class153_0 = null;
		@class = null;
		buClipperBase_0.list_1[int_0] = null;
	}

	static byte[] smethod_277(byte[] byte_0)
	{
		Class160.Stream3 stream = new Class160.Stream3(byte_0);
		byte[] array = new byte[0];
		int num = smethod_116(stream);
		int num2 = num >> 24;
		if (num - (num2 << 24) != 8223355)
		{
			throw new FormatException("Unknown Header");
		}
		switch ((Enum14)num2)
		{
		case Enum14.const_3:
		{
			byte[] byte_1 = new byte[16]
			{
				135, 156, 161, 171, 165, 250, 192, 197, 57, 16,
				2, 108, 15, 110, 214, 154
			};
			byte[] byte_2 = new byte[16]
			{
				73, 187, 167, 105, 241, 126, 12, 10, 154, 165,
				169, 68, 134, 76, 145, 92
			};
			using (ICryptoTransform cryptoTransform = smethod_251(byte_2, true, byte_1))
			{
				array = smethod_277(cryptoTransform.TransformFinalBlock(byte_0, 4, byte_0.Length - 4));
			}
			break;
		}
		case Enum14.const_1:
		{
			int num3 = smethod_116(stream);
			array = new byte[num3];
			int num5;
			for (int i = 0; i < num3; i += num5)
			{
				int num4 = smethod_116(stream);
				num5 = smethod_116(stream);
				byte[] array2 = new byte[num4];
				stream.Read(array2, 0, 0);
				smethod_46(array, num5, new Class160.Class161(array2), i);
			}
			break;
		}
		default:
			throw new ArgumentOutOfRangeException("version", num2, "Selected compression algorithm is not supported.");
		}
		stream.Close();
		stream = null;
		return array;
	}

	static bool smethod_278(int int_0, ref double double_0, ref Color color_0, ref double double_1, ref string string_0, buFile.Dxf dxf_0, ref double double_2, ref double double_3, ref string string_1, ref double double_4)
	{
		bool result = false;
		int num = 0;
		for (int i = int_0; i <= dxf_0.list_0.Count - 1; i++)
		{
			if (num < 45)
			{
				num++;
				_ = dxf_0.list_0[i];
				if (dxf_0.list_0[i] == "  8")
				{
					string_0 = dxf_0.list_0[i + 1];
				}
				if (dxf_0.list_0[i] == " 62")
				{
					int num2 = Convert.ToInt32(dxf_0.list_0[i + 1]);
					if (num2 != 1)
					{
					}
					if (num2 >= dxf_0.ColorCode.Length)
					{
						color_0 = Color.Black;
					}
					else
					{
						color_0 = dxf_0.ColorCode[num2];
					}
					if ((color_0.A == 0) & (color_0.R == 0) & (color_0.G == 0) & (color_0.B == 0))
					{
						color_0 = Color.Black;
					}
				}
				if (dxf_0.list_0[i] == " 10")
				{
					double_1 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
				}
				if (dxf_0.list_0[i] == " 20")
				{
					double_0 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
				}
				if (dxf_0.list_0[i] == " 30")
				{
					double_3 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
				}
				if (dxf_0.list_0[i] == " 40")
				{
					double_4 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
				}
				if (dxf_0.list_0[i] == " 50")
				{
					double_2 = smethod_256(dxf_0, dxf_0.list_0[i + 1]);
				}
				if (dxf_0.list_0[i] == "  1")
				{
					string_1 = dxf_0.list_0[i + 1];
					if (string_1.IndexOf("beyaz") < 0)
					{
					}
					result = true;
				}
				if (dxf_0.list_0[i] == "  0")
				{
					break;
				}
				continue;
			}
			result = false;
			break;
		}
		return result;
	}

	static void smethod_279(Pop3Client pop3Client_0)
	{
		pop3Client_0.method_5(null);
		pop3Client_0.Connected = false;
		pop3Client_0.method_7(Enum9.const_0);
		pop3Client_0.ApopSupported = false;
	}

	static bool smethod_280(ref DTSweepConstraint dtsweepConstraint_0, [Out] DelaunayTriangle delaunayTriangle_0, int int_0)
	{
		dtsweepConstraint_0 = null;
		if (int_0 >= 0 && int_0 <= 2)
		{
			TriangulationPoint triangulationPoint = delaunayTriangle_0.Points[(int_0 + 1) % 3];
			TriangulationPoint triangulationPoint2 = delaunayTriangle_0.Points[(int_0 + 2) % 3];
			if (!triangulationPoint.GetEdge(triangulationPoint2, out dtsweepConstraint_0))
			{
				if (!triangulationPoint2.GetEdge(triangulationPoint, out dtsweepConstraint_0))
				{
					return false;
				}
				return true;
			}
			return true;
		}
		return false;
	}

	static Class152 smethod_281(Class152 class152_0)
	{
		while (class152_0 != null && class152_0.class153_0 == null)
		{
			class152_0 = class152_0.class152_0;
		}
		return class152_0;
	}

	static bool smethod_282(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5, double double_6)
	{
		if (!MathUtil.IsValueBetween(double_5, double_1, double_0, double_3) || !MathUtil.IsValueBetween(double_2, double_6, double_4, double_3))
		{
			return false;
		}
		if (!MathUtil.AreValuesEqual(double_0 - double_1, 0.0, double_3))
		{
			double num = (double_4 - double_6) / (double_0 - double_1);
			double num2 = 0.0 - num * double_1 + double_6;
			double val = double_2 - (num * double_5 + num2);
			return MathUtil.AreValuesEqual(val, 0.0, double_3);
		}
		return true;
	}

	static void smethod_283()
	{
		EncodingFinder.smethod_1(new Dictionary<string, Encoding>());
		EncodingFinder.FallbackDecoder = null;
		EncodingFinder.AddMapping("utf8", Encoding.UTF8);
	}

	static void smethod_284(buClipperBase buClipperBase_0, Class148 class148_0)
	{
		buClipperBase_0.Swap(ref class148_0.intPoint_2.X, ref class148_0.intPoint_0.X);
		buClipperBase_0.Swap(ref class148_0.intPoint_2.Z, ref class148_0.intPoint_0.Z);
	}

	static void smethod_285(TriangulationContext triangulationContext_0)
	{
		_ = triangulationContext_0.Algorithm;
		DTSweep.Triangulate((DTSweepContext)triangulationContext_0);
	}

	static void smethod_286(buClipperBase buClipperBase_0)
	{
		while (buClipperBase_0.class149_0 != null)
		{
			Class149 class149_ = buClipperBase_0.class149_0.class149_0;
			buClipperBase_0.class149_0 = null;
			buClipperBase_0.class149_0 = class149_;
		}
		buClipperBase_0.class149_1 = null;
	}

	static void smethod_287(IntPoint intPoint_0, buClipper buClipper_0, Class148 class148_0, Class148 class148_1)
	{
		bool flag = class148_0.int_3 >= 0;
		bool flag2 = class148_1.int_3 >= 0;
		smethod_207(buClipper_0, ref intPoint_0, class148_0, class148_1);
		if (class148_0.int_0 != 0 && class148_1.int_0 != 0)
		{
			if (class148_0.polyType_0 != class148_1.polyType_0)
			{
				if (smethod_273(buClipper_0, class148_1))
				{
					class148_0.int_2 = ((class148_0.int_2 == 0) ? 1 : 0);
				}
				else
				{
					class148_0.int_2 += class148_1.int_0;
				}
				if (smethod_273(buClipper_0, class148_0))
				{
					class148_1.int_2 = ((class148_1.int_2 == 0) ? 1 : 0);
				}
				else
				{
					class148_1.int_2 -= class148_0.int_0;
				}
			}
			else if (!smethod_273(buClipper_0, class148_0))
			{
				if (class148_0.int_1 + class148_1.int_0 != 0)
				{
					class148_0.int_1 += class148_1.int_0;
				}
				else
				{
					class148_0.int_1 = -class148_0.int_1;
				}
				if (class148_1.int_1 - class148_0.int_0 != 0)
				{
					class148_1.int_1 -= class148_0.int_0;
				}
				else
				{
					class148_1.int_1 = -class148_1.int_1;
				}
			}
			else
			{
				int int_ = class148_0.int_1;
				class148_0.int_1 = class148_1.int_1;
				class148_1.int_1 = int_;
			}
			PolyFillType polyFillType;
			PolyFillType polyFillType2;
			if (class148_0.polyType_0 != PolyType.ptSubject)
			{
				polyFillType = buClipper_0.polyFillType_0;
				polyFillType2 = buClipper_0.polyFillType_1;
			}
			else
			{
				polyFillType = buClipper_0.polyFillType_1;
				polyFillType2 = buClipper_0.polyFillType_0;
			}
			PolyFillType polyFillType3;
			PolyFillType polyFillType4;
			if (class148_1.polyType_0 != PolyType.ptSubject)
			{
				polyFillType3 = buClipper_0.polyFillType_0;
				polyFillType4 = buClipper_0.polyFillType_1;
			}
			else
			{
				polyFillType3 = buClipper_0.polyFillType_1;
				polyFillType4 = buClipper_0.polyFillType_0;
			}
			PolyFillType polyFillType5 = polyFillType;
			PolyFillType polyFillType6 = polyFillType5;
			int num = ((polyFillType6 == PolyFillType.pftPositive) ? class148_0.int_1 : ((polyFillType6 != PolyFillType.pftNegative) ? Math.Abs(class148_0.int_1) : (-class148_0.int_1)));
			PolyFillType polyFillType7 = polyFillType3;
			PolyFillType polyFillType8 = polyFillType7;
			int num2 = ((polyFillType8 == PolyFillType.pftPositive) ? class148_1.int_1 : ((polyFillType8 != PolyFillType.pftNegative) ? Math.Abs(class148_1.int_1) : (-class148_1.int_1)));
			if (!(flag && flag2))
			{
				if (!flag)
				{
					if (!flag2)
					{
						if ((num != 0 && num != 1) || (num2 != 0 && num2 != 1))
						{
							return;
						}
						PolyFillType polyFillType9 = polyFillType2;
						PolyFillType polyFillType10 = polyFillType9;
						long num3 = ((polyFillType10 == PolyFillType.pftPositive) ? class148_0.int_2 : ((polyFillType10 != PolyFillType.pftNegative) ? Math.Abs(class148_0.int_2) : (-class148_0.int_2)));
						PolyFillType polyFillType11 = polyFillType4;
						PolyFillType polyFillType12 = polyFillType11;
						long num4 = ((polyFillType12 == PolyFillType.pftPositive) ? class148_1.int_2 : ((polyFillType12 != PolyFillType.pftNegative) ? Math.Abs(class148_1.int_2) : (-class148_1.int_2)));
						if (class148_0.polyType_0 == class148_1.polyType_0)
						{
							if (num != 1 || num2 != 1)
							{
								smethod_164(class148_0, class148_1);
								return;
							}
							switch (buClipper_0.clipType_0)
							{
							case ClipType.ctXor:
								smethod_230(buClipper_0, class148_0, class148_1, intPoint_0);
								break;
							case ClipType.ctIntersection:
								if (num3 > 0L && num4 > 0L)
								{
									smethod_230(buClipper_0, class148_0, class148_1, intPoint_0);
								}
								break;
							case ClipType.ctUnion:
								if (num3 <= 0L && num4 <= 0L)
								{
									smethod_230(buClipper_0, class148_0, class148_1, intPoint_0);
								}
								break;
							case ClipType.ctDifference:
								if ((class148_0.polyType_0 == PolyType.ptClip && num3 > 0L && num4 > 0L) || (class148_0.polyType_0 == PolyType.ptSubject && num3 <= 0L && num4 <= 0L))
								{
									smethod_230(buClipper_0, class148_0, class148_1, intPoint_0);
								}
								break;
							}
						}
						else
						{
							smethod_230(buClipper_0, class148_0, class148_1, intPoint_0);
						}
					}
					else if (num == 0 || num == 1)
					{
						smethod_246(buClipper_0, class148_1, intPoint_0);
						smethod_164(class148_0, class148_1);
						smethod_100(class148_0, class148_1);
					}
				}
				else if (num2 == 0 || num2 == 1)
				{
					smethod_246(buClipper_0, class148_0, intPoint_0);
					smethod_164(class148_0, class148_1);
					smethod_100(class148_0, class148_1);
				}
			}
			else if ((num == 0 || num == 1) && (num2 == 0 || num2 == 1) && (class148_0.polyType_0 == class148_1.polyType_0 || buClipper_0.clipType_0 == ClipType.ctXor))
			{
				smethod_246(buClipper_0, class148_0, intPoint_0);
				smethod_246(buClipper_0, class148_1, intPoint_0);
				smethod_164(class148_0, class148_1);
				smethod_100(class148_0, class148_1);
			}
			else
			{
				smethod_1(intPoint_0, class148_0, class148_1, buClipper_0);
			}
		}
		else
		{
			if (class148_0.int_0 == 0 && class148_1.int_0 == 0)
			{
				return;
			}
			if (class148_0.polyType_0 != class148_1.polyType_0 || class148_0.int_0 == class148_1.int_0 || buClipper_0.clipType_0 != ClipType.ctUnion)
			{
				if (class148_0.polyType_0 == class148_1.polyType_0)
				{
					return;
				}
				if (class148_0.int_0 != 0 || Math.Abs(class148_1.int_1) != 1 || (buClipper_0.clipType_0 == ClipType.ctUnion && class148_1.int_2 != 0))
				{
					if (class148_1.int_0 == 0 && Math.Abs(class148_0.int_1) == 1 && (buClipper_0.clipType_0 != ClipType.ctUnion || class148_0.int_2 == 0))
					{
						smethod_246(buClipper_0, class148_1, intPoint_0);
						if (flag2)
						{
							class148_1.int_3 = -1;
						}
					}
				}
				else
				{
					smethod_246(buClipper_0, class148_0, intPoint_0);
					if (flag)
					{
						class148_0.int_3 = -1;
					}
				}
			}
			else if (class148_0.int_0 != 0)
			{
				if (flag)
				{
					smethod_246(buClipper_0, class148_1, intPoint_0);
					if (flag2)
					{
						class148_1.int_3 = -1;
					}
				}
			}
			else if (flag2)
			{
				smethod_246(buClipper_0, class148_0, intPoint_0);
				if (flag)
				{
					class148_0.int_3 = -1;
				}
			}
		}
	}

	static bool smethod_288(char char_0)
	{
		return char_0 >= '0' && char_0 <= '9';
	}

	static void smethod_289(DelaunayTriangle delaunayTriangle_0, Point2D point2D_0, DTSweepContext dtsweepContext_0, TriangulationPoint triangulationPoint_0, DelaunayTriangle delaunayTriangle_1, TriangulationPoint triangulationPoint_1)
	{
		DelaunayTriangle delaunayTriangle = delaunayTriangle_0.NeighborAcrossFrom(triangulationPoint_0);
		TriangulationPoint triangulationPoint = delaunayTriangle.OppositePoint(delaunayTriangle_0, triangulationPoint_0);
		if (delaunayTriangle != null)
		{
			if (dtsweepContext_0.IsDebugEnabled)
			{
				Console.WriteLine("[FLIP:SCAN] - scan next point");
				dtsweepContext_0.DebugContext.PrimaryTriangle = delaunayTriangle_0;
				dtsweepContext_0.DebugContext.SecondaryTriangle = delaunayTriangle;
			}
			if (!TriangulationUtil.InScanArea(triangulationPoint_1, delaunayTriangle_1.PointCCWFrom(triangulationPoint_1), delaunayTriangle_1.PointCWFrom(triangulationPoint_1), triangulationPoint))
			{
				TriangulationPoint triangulationPoint_2 = default(TriangulationPoint);
				if (smethod_156(ref triangulationPoint_2, point2D_0, delaunayTriangle, triangulationPoint, (Point2D)triangulationPoint_1))
				{
					smethod_289(delaunayTriangle, point2D_0, dtsweepContext_0, triangulationPoint_2, delaunayTriangle_1, triangulationPoint_1);
				}
			}
			else
			{
				smethod_41(triangulationPoint, dtsweepContext_0, triangulationPoint_1, triangulationPoint, delaunayTriangle);
			}
			return;
		}
		throw new Exception("[BUG:FIXME] FLIP failed due to missing triangle");
	}

	static void smethod_290(IList<Point2D> ilist_0, Point2D point2D_0, ref List<Point2D> list_0, [Out] Point2D point2D_1)
	{
		list_0 = null;
		if (point2D_1 == null || point2D_0 == null || ilist_0 == null || ilist_0.Count < 3)
		{
			return;
		}
		list_0 = new List<Point2D>();
		int index = ilist_0.Count - 1;
		Point2D ptRayVector = new Point2D(point2D_0.X - point2D_1.X, point2D_0.Y - point2D_1.Y);
		bool flag = TriangulationUtil.Orient2d(point2D_1, point2D_0, ilist_0[index]) == Orientation.Clockwise;
		Point2D point2D = new Point2D(0.0, 0.0);
		for (int i = 0; i < ilist_0.Count; i++)
		{
			bool flag2;
			if (!(flag2 = TriangulationUtil.Orient2d(point2D_1, point2D_0, ilist_0[i]) == Orientation.Clockwise))
			{
				if (flag)
				{
					point2D.Set(ilist_0[i].X - ilist_0[index].X, ilist_0[i].Y - ilist_0[index].Y);
					Point2D ptIntersection = new Point2D(0.0, 0.0);
					if (TriangulationUtil.RaysIntersect2D(ilist_0[index], point2D, point2D_1, ptRayVector, ref ptIntersection))
					{
						list_0.Add(ptIntersection);
					}
				}
			}
			else if (!flag)
			{
				point2D.Set(ilist_0[i].X - ilist_0[index].X, ilist_0[i].Y - ilist_0[index].Y);
				Point2D ptIntersection2 = new Point2D(0.0, 0.0);
				if (TriangulationUtil.RaysIntersect2D(ilist_0[index], point2D, point2D_1, ptRayVector, ref ptIntersection2))
				{
					list_0.Add(ptIntersection2);
					list_0.Add(ilist_0[i]);
				}
			}
			else
			{
				list_0.Add(ilist_0[i]);
			}
			index = i;
			flag = flag2;
		}
	}

	static double smethod_291(Pnt3D pnt3D_0, Pnt3D pnt3D_1, buVector buVector_0, Pnt3D pnt3D_2)
	{
		return (pnt3D_2.X - pnt3D_0.X) * (pnt3D_1.Y - pnt3D_0.Y) - (pnt3D_1.X - pnt3D_0.X) * (pnt3D_2.Y - pnt3D_0.Y);
	}

	static int smethod_292(Class160.Class162 class162_0, int int_0)
	{
		if (class162_0.int_2 < int_0)
		{
			if (class162_0.int_0 == class162_0.int_1)
			{
				return -1;
			}
			class162_0.uint_0 |= (uint)(((class162_0.byte_0[class162_0.int_0++] & 0xFF) | ((class162_0.byte_0[class162_0.int_0++] & 0xFF) << 8)) << class162_0.int_2);
			class162_0.int_2 += 16;
		}
		return (int)(class162_0.uint_0 & ((1 << int_0) - 1));
	}

	static bool smethod_293(buClipper buClipper_0, Class154 class154_0, Class152 class152_0, Class152 class152_1)
	{
		Class153 @class = class154_0.class153_0;
		Class153 class153_ = class154_0.class153_1;
		bool flag;
		bool flag2;
		Class153 class2;
		Class153 class3;
		if (!(flag = class154_0.class153_0.intPoint_0.Y == class154_0.intPoint_0.Y) || !(class154_0.intPoint_0 == class154_0.class153_0.intPoint_0) || !(class154_0.intPoint_0 == class154_0.class153_1.intPoint_0))
		{
			if (!flag)
			{
				class2 = @class.class153_0;
				while (class2.intPoint_0 == @class.intPoint_0 && class2 != @class)
				{
					class2 = class2.class153_0;
				}
				int num;
				if (class2.intPoint_0.Y > @class.intPoint_0.Y)
				{
					num = 1;
				}
				else
				{
					IntPoint intPoint_ = @class.intPoint_0;
					IntPoint intPoint_2 = class2.intPoint_0;
					IntPoint intPoint_3 = class154_0.intPoint_0;
					num = ((!smethod_103(buClipper_0.bool_0, intPoint_2, intPoint_3, intPoint_)) ? 1 : 0);
				}
				flag2 = (byte)num != 0;
				if (num != 0)
				{
					class2 = @class.class153_1;
					while (class2.intPoint_0 == @class.intPoint_0 && class2 != @class)
					{
						class2 = class2.class153_1;
					}
					if (class2.intPoint_0.Y <= @class.intPoint_0.Y)
					{
						IntPoint intPoint_ = @class.intPoint_0;
						IntPoint intPoint_2 = class2.intPoint_0;
						IntPoint intPoint_3 = class154_0.intPoint_0;
						if (smethod_103(buClipper_0.bool_0, intPoint_2, intPoint_3, intPoint_))
						{
							goto IL_0529;
						}
					}
					return false;
				}
				goto IL_0529;
			}
			class2 = @class;
			while (@class.class153_1.intPoint_0.Y == @class.intPoint_0.Y && @class.class153_1 != class2 && @class.class153_1 != class153_)
			{
				@class = @class.class153_1;
			}
			while (class2.class153_0.intPoint_0.Y == class2.intPoint_0.Y && class2.class153_0 != @class && class2.class153_0 != class153_)
			{
				class2 = class2.class153_0;
			}
			if (class2.class153_0 != @class && class2.class153_0 != class153_)
			{
				class3 = class153_;
				while (class153_.class153_1.intPoint_0.Y == class153_.intPoint_0.Y && class153_.class153_1 != class3 && class153_.class153_1 != class2)
				{
					class153_ = class153_.class153_1;
				}
				while (class3.class153_0.intPoint_0.Y == class3.intPoint_0.Y && class3.class153_0 != class153_ && class3.class153_0 != @class)
				{
					class3 = class3.class153_0;
				}
				if (class3.class153_0 != class153_ && class3.class153_0 != @class)
				{
					long long_2 = default(long);
					if (smethod_241(buClipper_0, @class.intPoint_0.X, class2.intPoint_0.X, class153_.intPoint_0.X, class3.intPoint_0.X, out long long_, ref long_2))
					{
						IntPoint intPoint_4;
						bool bool_;
						if (@class.intPoint_0.X < long_ || @class.intPoint_0.X > long_2)
						{
							if (class153_.intPoint_0.X < long_ || class153_.intPoint_0.X > long_2)
							{
								if (class2.intPoint_0.X < long_ || class2.intPoint_0.X > long_2)
								{
									intPoint_4 = class3.intPoint_0;
									bool_ = class3.intPoint_0.X > class153_.intPoint_0.X;
								}
								else
								{
									intPoint_4 = class2.intPoint_0;
									bool_ = class2.intPoint_0.X > @class.intPoint_0.X;
								}
							}
							else
							{
								intPoint_4 = class153_.intPoint_0;
								bool_ = class153_.intPoint_0.X > class3.intPoint_0.X;
							}
						}
						else
						{
							intPoint_4 = @class.intPoint_0;
							bool_ = @class.intPoint_0.X > class2.intPoint_0.X;
						}
						class154_0.class153_0 = @class;
						class154_0.class153_1 = class153_;
						return smethod_66(class153_, @class, buClipper_0, class2, intPoint_4, bool_, class3);
					}
					return false;
				}
				return false;
			}
			return false;
		}
		if (class152_0 == class152_1)
		{
			class2 = class154_0.class153_0.class153_0;
			while (class2 != @class && class2.intPoint_0 == class154_0.intPoint_0)
			{
				class2 = class2.class153_0;
			}
			bool flag3 = class2.intPoint_0.Y > class154_0.intPoint_0.Y;
			class3 = class154_0.class153_1.class153_0;
			while (class3 != class153_ && class3.intPoint_0 == class154_0.intPoint_0)
			{
				class3 = class3.class153_0;
			}
			bool flag4 = class3.intPoint_0.Y > class154_0.intPoint_0.Y;
			if (flag3 != flag4)
			{
				if (!flag3)
				{
					class2 = smethod_139(buClipper_0, @class, true);
					class3 = smethod_139(buClipper_0, class153_, false);
					@class.class153_0 = class153_;
					class153_.class153_1 = @class;
					class2.class153_1 = class3;
					class3.class153_0 = class2;
					class154_0.class153_0 = @class;
					class154_0.class153_1 = class2;
					return true;
				}
				class2 = smethod_139(buClipper_0, @class, false);
				class3 = smethod_139(buClipper_0, class153_, true);
				@class.class153_1 = class153_;
				class153_.class153_0 = @class;
				class2.class153_0 = class3;
				class3.class153_1 = class2;
				class154_0.class153_0 = @class;
				class154_0.class153_1 = class2;
				return true;
			}
			return false;
		}
		return false;
		IL_0642:
		bool flag5;
		if (class2 != @class && class3 != class153_ && class2 != class3 && (class152_0 != class152_1 || flag2 != flag5))
		{
			if (!flag2)
			{
				class2 = smethod_139(buClipper_0, @class, true);
				class3 = smethod_139(buClipper_0, class153_, false);
				@class.class153_0 = class153_;
				class153_.class153_1 = @class;
				class2.class153_1 = class3;
				class3.class153_0 = class2;
				class154_0.class153_0 = @class;
				class154_0.class153_1 = class2;
				return true;
			}
			class2 = smethod_139(buClipper_0, @class, false);
			class3 = smethod_139(buClipper_0, class153_, true);
			@class.class153_1 = class153_;
			class153_.class153_0 = @class;
			class2.class153_0 = class3;
			class3.class153_1 = class2;
			class154_0.class153_0 = @class;
			class154_0.class153_1 = class2;
			return true;
		}
		return false;
		IL_0529:
		class3 = class153_.class153_0;
		while (class3.intPoint_0 == class153_.intPoint_0 && class3 != class153_)
		{
			class3 = class3.class153_0;
		}
		int num2;
		if (class3.intPoint_0.Y > class153_.intPoint_0.Y)
		{
			num2 = 1;
		}
		else
		{
			IntPoint intPoint_ = class153_.intPoint_0;
			IntPoint intPoint_2 = class3.intPoint_0;
			IntPoint intPoint_3 = class154_0.intPoint_0;
			num2 = ((!smethod_103(buClipper_0.bool_0, intPoint_2, intPoint_3, intPoint_)) ? 1 : 0);
		}
		flag5 = (byte)num2 != 0;
		if (num2 != 0)
		{
			class3 = class153_.class153_1;
			while (class3.intPoint_0 == class153_.intPoint_0 && class3 != class153_)
			{
				class3 = class3.class153_1;
			}
			if (class3.intPoint_0.Y <= class153_.intPoint_0.Y)
			{
				IntPoint intPoint_ = class153_.intPoint_0;
				IntPoint intPoint_2 = class3.intPoint_0;
				IntPoint intPoint_3 = class154_0.intPoint_0;
				if (smethod_103(buClipper_0.bool_0, intPoint_2, intPoint_3, intPoint_))
				{
					goto IL_0642;
				}
			}
			return false;
		}
		goto IL_0642;
	}

	static void smethod_294(Class160.Class162 class162_0)
	{
		class162_0.uint_0 >>= class162_0.int_2 & 7;
		class162_0.int_2 &= -8;
	}

	static List<string> smethod_295(string string_0)
	{
		List<string> list = new List<string>();
		string[] array = string_0.Trim().Split(new char[1] { '>' }, StringSplitOptions.RemoveEmptyEntries);
		string[] array2 = array;
		foreach (string string_1 in array2)
		{
			list.Add(smethod_76(string_1));
		}
		return list;
	}

	static int smethod_296(Stream stream_0, string string_0, out bool bool_0)
	{
		bool_0 = false;
		while (true)
		{
			int result = (int)stream_0.Position;
			string text = smethod_106(stream_0);
			if (text != null)
			{
				if (text.StartsWith("--" + string_0, StringComparison.Ordinal))
				{
					bool_0 = text.StartsWith("--" + string_0 + "--", StringComparison.OrdinalIgnoreCase);
					return result;
				}
				continue;
			}
			break;
		}
		return -1;
	}

	static byte[] smethod_297(string string_0, bool bool_0)
	{
		if (string_0 != null)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				string_0 = smethod_166(string_0);
				for (int i = 0; i < string_0.Length; i++)
				{
					char c = string_0[i];
					if (c != '=')
					{
						if (!(c == '_' && bool_0))
						{
							memoryStream.WriteByte((byte)c);
						}
						else
						{
							memoryStream.WriteByte(32);
						}
					}
					else
					{
						if (string_0.Length - i < 3)
						{
							smethod_18((Stream)memoryStream, smethod_300(string_0.Substring(i)));
							break;
						}
						string string_1 = string_0.Substring(i, 3);
						smethod_18((Stream)memoryStream, smethod_180(string_1));
						i += 2;
					}
				}
				return memoryStream.ToArray();
			}
		}
		throw new ArgumentNullException("toDecode");
	}

	static bool smethod_298([Out] buClipper buClipper_0, ref Class148 class148_0)
	{
		class148_0 = buClipper_0.class148_1;
		if (class148_0 != null)
		{
			Class148 @class = class148_0;
			buClipper_0.class148_1 = class148_0.class148_5;
			if (buClipper_0.class148_1 != null)
			{
				buClipper_0.class148_1.class148_6 = null;
			}
			@class.class148_5 = null;
			@class.class148_6 = null;
			return true;
		}
		return false;
	}

	static bool smethod_299(TextReader textReader_0)
	{
		int num = textReader_0.Peek();
		if (num != -1)
		{
			char c = (char)num;
			return c == ' ' || c == '\t';
		}
		return false;
	}

	static byte[] smethod_300(string string_0)
	{
		if (string_0 != null)
		{
			if (string_0.Length < 3)
			{
				if (string_0.Length > 0)
				{
					if (string_0[0] != '=')
					{
						throw new ArgumentException("First part of decode must be an equal sign", "decode");
					}
					return Encoding.ASCII.GetBytes(string_0);
				}
				throw new ArgumentException("decode must have length lower at least 1", "decode");
			}
			throw new ArgumentException("decode must have length lower than 3", "decode");
		}
		throw new ArgumentNullException("decode");
	}
}
