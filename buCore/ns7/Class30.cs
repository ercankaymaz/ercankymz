// Decompiled with JetBrains decompiler
// Type: ns7.Class30
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using buClass;
using buCore;
using buCore.buClipperLib;
using buPop3.Common.Logging;
using buPop3.Mime;
using buPop3.Mime.Decode;
using buPop3.Mime.Header;
using buPop3.Pop3;
using buPop3.Pop3.Exceptions;
using ns0;
using ns1;
using ns10;
using ns2;
using ns3;
using ns6;
using ns8;
using ns9;
using Poly2Tri.Triangulation;
using Poly2Tri.Triangulation.Delaunay;
using Poly2Tri.Triangulation.Delaunay.Sweep;
using Poly2Tri.Triangulation.Polygon;
using Poly2Tri.Triangulation.Sets;
using Poly2Tri.Triangulation.Util;
using Poly2Tri.Utility;
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

#nullable disable
namespace ns7;

internal class Class30
{
  static List<byte[]> smethod_0(string string_0, byte[] byte_0)
  {
    if (byte_0 == null)
      throw new ArgumentNullException("rawBody");
    List<byte[]> numArrayList = new List<byte[]>();
    using (MemoryStream stream_0 = new MemoryStream(byte_0))
    {
      bool bool_0;
      int sourceIndex = Class30.smethod_296((Stream) stream_0, string_0, out bool_0) + $"--{string_0}\r\n".Length;
      while (!bool_0)
      {
        int num = Class30.smethod_296((Stream) stream_0, string_0, out bool_0) - "\r\n".Length;
        if (num <= -1)
        {
          num = (int) stream_0.Length - "\r\n".Length;
          bool_0 = true;
          if (sourceIndex >= num)
            break;
        }
        int length = num - sourceIndex;
        byte[] destinationArray = new byte[length];
        Array.Copy((Array) byte_0, sourceIndex, (Array) destinationArray, 0, length);
        numArrayList.Add(destinationArray);
        sourceIndex = num + $"\r\n--{string_0}\r\n".Length;
      }
    }
    return numArrayList;
  }

  static void smethod_1(
    IntPoint intPoint_0,
    Class22 class22_0,
    Class22 class22_1,
    buClipper buClipper_0)
  {
    Class30.smethod_246(buClipper_0, class22_0, intPoint_0);
    if (class22_1.int_0 == 0)
      Class30.smethod_246(buClipper_0, class22_1, intPoint_0);
    if (class22_0.int_3 == class22_1.int_3)
    {
      class22_0.int_3 = -1;
      class22_1.int_3 = -1;
    }
    else if (class22_0.int_3 < class22_1.int_3)
      Class30.smethod_89(buClipper_0, class22_0, class22_1);
    else
      Class30.smethod_89(buClipper_0, class22_1, class22_0);
  }

  static void smethod_2(buClipper buClipper_0, Class26 class26_0)
  {
    Class27 class27 = class26_0.class27_0;
    Class27 class271_1 = class27.class27_1;
    while (class27 != class271_1)
    {
      class27 = class27.class27_0;
      if (class27.intPoint_0 == class27.class27_1.intPoint_0)
      {
        if (class27 == class271_1)
          class271_1 = class27.class27_1;
        Class27 class271_2 = class27.class27_1;
        class271_2.class27_0 = class27.class27_0;
        class27.class27_0.class27_1 = class271_2;
        class27 = class271_2;
      }
    }
    if (class27 != class27.class27_1)
      return;
    class26_0.class27_0 = (Class27) null;
  }

  static int smethod_3(byte[] byte_0)
  {
    if (byte_0 == null)
      throw new ArgumentNullException("messageContent");
    using (Stream stream_0 = (Stream) new MemoryStream(byte_0))
    {
      do
        ;
      while (!string.IsNullOrEmpty(Class30.smethod_106(stream_0)));
      return (int) stream_0.Position;
    }
  }

  static bool smethod_4(PolyNode polyNode_0)
  {
    bool flag = true;
    for (PolyNode polyNode0 = polyNode_0.polyNode_0; polyNode0 != null; polyNode0 = polyNode0.polyNode_0)
      flag = !flag;
    return flag;
  }

  static bool smethod_5(
    double double_0,
    SplitComplexPolygonNode splitComplexPolygonNode_0,
    double double_1,
    double double_2,
    double double_3)
  {
    return double_1 >= 0.0 ? (double_0 < 0.0 ? 1 : (double_2 <= double_3 ? 1 : 0)) == 0 : (double_0 > 0.0 ? 1 : (double_2 <= double_3 ? 1 : 0)) != 0;
  }

  static int smethod_6(Class34.Class36 class36_0)
  {
    return class36_0.int_1 - class36_0.int_0 + (class36_0.int_2 >> 3);
  }

  static void smethod_7(Class26 class26_0, buClipper buClipper_0)
  {
    Class27 class27 = class26_0.class27_0;
    do
    {
      class27.int_0 = class26_0.int_0;
      class27 = class27.class27_1;
    }
    while (class27 != class26_0.class27_0);
  }

  static void smethod_8(buClipperBase buClipperBase_0, ref Class22 class22_0)
  {
    if (class22_0.class22_2 == null)
      throw new Exception0("UpdateEdgeIntoAEL: invalid call");
    Class22 class224 = class22_0.class22_4;
    Class22 class223 = class22_0.class22_3;
    class22_0.class22_2.int_3 = class22_0.int_3;
    if (class224 != null)
      class224.class22_3 = class22_0.class22_2;
    else
      buClipperBase_0.class22_0 = class22_0.class22_2;
    if (class223 != null)
      class223.class22_4 = class22_0.class22_2;
    class22_0.class22_2.enum2_0 = class22_0.enum2_0;
    class22_0.class22_2.int_0 = class22_0.int_0;
    class22_0.class22_2.int_1 = class22_0.int_1;
    class22_0.class22_2.int_2 = class22_0.int_2;
    class22_0 = class22_0.class22_2;
    class22_0.intPoint_1 = class22_0.intPoint_0;
    class22_0.class22_4 = class224;
    class22_0.class22_3 = class223;
    if (Class30.smethod_67(class22_0))
      return;
    Class30.smethod_232(buClipperBase_0, class22_0.intPoint_2.Y);
  }

  static bool smethod_9(Class22 class22_0, double double_0, buClipper buClipper_0)
  {
    return (double) class22_0.intPoint_2.Y == double_0 && class22_0.class22_2 != null;
  }

  static string smethod_10(string string_0)
  {
    if (string_0 == null)
      throw new ArgumentNullException("text");
    return (string_0.Length <= 1 || string_0[0] != '"' ? 0 : (string_0[string_0.Length - 1] == '"' ? 1 : 0)) == 0 ? string_0 : string_0.Substring(1, string_0.Length - 2);
  }

  static void smethod_11(buClipper buClipper_0, Class22 class22_0)
  {
    if (buClipper_0.class22_1 == null)
    {
      buClipper_0.class22_1 = class22_0;
      class22_0.class22_6 = (Class22) null;
      class22_0.class22_5 = (Class22) null;
    }
    else
    {
      class22_0.class22_5 = buClipper_0.class22_1;
      class22_0.class22_6 = (Class22) null;
      buClipper_0.class22_1.class22_6 = class22_0;
      buClipper_0.class22_1 = class22_0;
    }
  }

  static void smethod_12(buClipperBase buClipperBase_0, Class22 class22_0)
  {
    Class22 class224 = class22_0.class22_4;
    Class22 class223 = class22_0.class22_3;
    if ((class224 != null || class223 != null ? 0 : (class22_0 != buClipperBase_0.class22_0 ? 1 : 0)) != 0)
      return;
    if (class224 != null)
      class224.class22_3 = class223;
    else
      buClipperBase_0.class22_0 = class223;
    if (class223 != null)
      class223.class22_4 = class224;
    class22_0.class22_3 = (Class22) null;
    class22_0.class22_4 = (Class22) null;
  }

  static void smethod_13(int int_0, double double_0, ClipperOffset clipperOffset_0, int int_1)
  {
    double num = clipperOffset_0.double_0 / double_0;
    clipperOffset_0.list_2.Add(new IntPoint(Class30.smethod_150((double) clipperOffset_0.list_1[int_1].X + (clipperOffset_0.list_3[int_0].X + clipperOffset_0.list_3[int_1].X) * num), Class30.smethod_150((double) clipperOffset_0.list_1[int_1].Y + (clipperOffset_0.list_3[int_0].Y + clipperOffset_0.list_3[int_1].Y) * num)));
  }

  static Dictionary<string, string> smethod_14(string string_0)
  {
    Dictionary<string, string> dictionary = new Dictionary<string, string>();
    string input = string_0;
    if (string_0.Contains(";"))
      input = string_0.Substring(0, string_0.LastIndexOf(";"));
    foreach (Match match in Regex.Matches(Regex.Replace(input, "\\s+", " "), "(?<name>[^\\s]+)\\s(?<value>[^\\s]+(\\s\\(.+?\\))*)"))
    {
      string key = match.Groups["name"].Value;
      string str = match.Groups["value"].Value;
      if (!key.StartsWith("(") && !dictionary.ContainsKey(key))
        dictionary.Add(key, str);
    }
    return dictionary;
  }

  static void smethod_15(IntPoint intPoint_0, ref bool bool_0, buClipperBase buClipperBase_0)
  {
    if (bool_0)
    {
      if ((intPoint_0.X > 4611686018427387903L /*0x3FFFFFFFFFFFFFFF*/ || intPoint_0.Y > 4611686018427387903L /*0x3FFFFFFFFFFFFFFF*/ || -intPoint_0.X > 4611686018427387903L /*0x3FFFFFFFFFFFFFFF*/ ? 1 : (-intPoint_0.Y > 4611686018427387903L /*0x3FFFFFFFFFFFFFFF*/ ? 1 : 0)) != 0)
        throw new Exception0("Coordinate outside allowed range");
    }
    else
    {
      if ((intPoint_0.X > 1073741823L /*0x3FFFFFFF*/ || intPoint_0.Y > 1073741823L /*0x3FFFFFFF*/ || -intPoint_0.X > 1073741823L /*0x3FFFFFFF*/ ? 1 : (-intPoint_0.Y > 1073741823L /*0x3FFFFFFF*/ ? 1 : 0)) == 0)
        return;
      bool_0 = true;
      Class30.smethod_15(intPoint_0, ref bool_0, buClipperBase_0);
    }
  }

  static IEnumerable<Point2DList> smethod_16(IEnumerable<Point2D> ienumerable_0)
  {
    List<Point2DList> point2DlistList = new List<Point2DList>();
    Point2DList point2Dlist1 = new Point2DList();
    point2Dlist1.AddRange(ienumerable_0);
    point2DlistList.Add(point2Dlist1);
    int index1 = 0;
    for (int count1 = point2DlistList.Count; index1 < count1; ++index1)
    {
      int count2 = point2DlistList[index1].Count;
      for (int index2 = 0; index2 < count2; ++index2)
      {
        for (int index3 = index2 + 1; index3 < count2; ++index3)
        {
          if (point2DlistList[index1][index2].Equals(point2DlistList[index1][index3], point2Dlist1.Epsilon))
          {
            int count3 = index3 - index2;
            Point2DList point2Dlist2 = new Point2DList();
            for (int index4 = index2 + 1; index4 <= index3; ++index4)
              point2Dlist2.Add(point2DlistList[index1][index4]);
            point2DlistList[index1].RemoveRange(index2 + 1, count3);
            point2DlistList.Add(point2Dlist2);
            ++count1;
            count2 -= count3;
            index3 = index2 + 1;
          }
        }
      }
      point2DlistList[index1].Simplify();
    }
    return (IEnumerable<Point2DList>) point2DlistList;
  }

  static bool smethod_17(buClipperBase buClipperBase_0) => buClipperBase_0.class23_1 != null;

  static void smethod_18(Stream stream_0, byte[] byte_0)
  {
    stream_0.Write(byte_0, 0, byte_0.Length);
  }

  static bool smethod_19(Class22 class22_0, Class22 class22_1, buClipper buClipper_0)
  {
    return class22_1.intPoint_1.X != class22_0.intPoint_1.X ? class22_1.intPoint_1.X < class22_0.intPoint_1.X : (class22_1.intPoint_2.Y <= class22_0.intPoint_2.Y ? class22_0.intPoint_2.X > Class30.smethod_101(class22_1, class22_0.intPoint_2.Y) : class22_1.intPoint_2.X < Class30.smethod_101(class22_0, class22_1.intPoint_2.Y));
  }

  static void smethod_20(
    ref double double_0,
    Pnt3D pnt3D_0,
    ref Pnt3D pnt3D_1,
    [Out] Pnt3D pnt3D_2,
    [Out] Pnt3D pnt3D_3,
    buVector buVector_0)
  {
    double x1 = (pnt3D_2.X + pnt3D_0.X) / 2.0;
    double y1 = (pnt3D_2.Y + pnt3D_0.Y) / 2.0;
    double num1 = pnt3D_2.X - pnt3D_0.X;
    double num2 = -(pnt3D_2.Y - pnt3D_0.Y);
    double x2 = (pnt3D_3.X + pnt3D_2.X) / 2.0;
    double y2 = (pnt3D_3.Y + pnt3D_2.Y) / 2.0;
    double num3 = pnt3D_3.X - pnt3D_2.X;
    double num4 = -(pnt3D_3.Y - pnt3D_2.Y);
    bool IsLineIntersect = false;
    bool IsIntersecPointInsideLines = false;
    Pnt3D IntersectionPoint = new Pnt3D();
    buVector_0.LineLineIntersection(new Pnt3D(x1, y1), new Pnt3D(x1 + num2, y1 + num1), new Pnt3D(x2, y2), new Pnt3D(x2 + num4, y2 + num3), new WorkPlane(), ref IntersectionPoint, ref IsLineIntersect, ref IsIntersecPointInsideLines);
    if (!IsLineIntersect)
    {
      pnt3D_1 = new Pnt3D(0.0, 0.0);
      double_0 = 0.0;
    }
    else
    {
      pnt3D_1 = IntersectionPoint;
      double num5 = pnt3D_1.X - pnt3D_0.X;
      double num6 = pnt3D_1.Y - pnt3D_0.Y;
      double_0 = Math.Sqrt(num5 * num5 + num6 * num6);
    }
  }

  static void smethod_21(int int_0)
  {
    if (int_0 <= 0)
      throw new InvalidUseException("The messageNumber argument cannot have a value of zero or less. Valid messageNumber is in the range [1, messageCount]");
  }

  static void smethod_22(
    IntPoint intPoint_0,
    Class27 class27_0,
    Class27 class27_1,
    buClipper buClipper_0)
  {
    buClipper_0.list_3.Add(new Class28()
    {
      class27_0 = class27_1,
      class27_1 = class27_0,
      intPoint_0 = intPoint_0
    });
  }

  static bool smethod_23(
    IntPoint intPoint_0,
    IntPoint intPoint_1,
    IntPoint intPoint_2,
    double double_0)
  {
    return Math.Abs(intPoint_0.X - intPoint_1.X) <= Math.Abs(intPoint_0.Y - intPoint_1.Y) ? (intPoint_0.Y > intPoint_1.Y != intPoint_0.Y < intPoint_2.Y ? (intPoint_1.Y > intPoint_0.Y != intPoint_1.Y < intPoint_2.Y ? Class30.smethod_143(intPoint_2, intPoint_0, intPoint_1) < double_0 : Class30.smethod_143(intPoint_1, intPoint_0, intPoint_2) < double_0) : Class30.smethod_143(intPoint_0, intPoint_1, intPoint_2) < double_0) : (intPoint_0.X > intPoint_1.X != intPoint_0.X < intPoint_2.X ? (intPoint_1.X > intPoint_0.X != intPoint_1.X < intPoint_2.X ? Class30.smethod_143(intPoint_2, intPoint_0, intPoint_1) < double_0 : Class30.smethod_143(intPoint_1, intPoint_0, intPoint_2) < double_0) : Class30.smethod_143(intPoint_0, intPoint_1, intPoint_2) < double_0);
  }

  static void smethod_24(DTSweepContext dtsweepContext_0)
  {
    DelaunayTriangle triangle = dtsweepContext_0.Front.Head.Next.Triangle;
    DelaunayTriangle delaunayTriangle;
    for (TriangulationPoint point = dtsweepContext_0.Front.Head.Next.Point; !triangle.GetConstrainedEdgeCW(point); triangle = delaunayTriangle)
    {
      delaunayTriangle = triangle.NeighborCCWFrom(point);
      if (delaunayTriangle == null)
        break;
    }
    dtsweepContext_0.MeshClean(triangle);
  }

  static void smethod_25(buClipper buClipper_0)
  {
    Class22 class22 = buClipper_0.class22_0;
    buClipper_0.class22_1 = class22;
    for (; class22 != null; class22 = class22.class22_3)
    {
      class22.class22_6 = class22.class22_4;
      class22.class22_5 = class22.class22_3;
    }
  }

  static string smethod_26(string string_0)
  {
    int num1 = string_0.Length - 1;
    int num2 = 0;
    while ((num2 > num1 || string_0[num1 - num2] == ' ' ? 0 : (!Class30.smethod_288(string_0[num1 - num2]) ? 1 : 0)) != 0)
      ++num2;
    return string_0.Substring(string_0.Length - num2).ToUpperInvariant();
  }

  static int smethod_27(Class34.Stream0 stream0_0)
  {
    return stream0_0.ReadByte() | stream0_0.ReadByte() << 8;
  }

  static MailPriority smethod_28(string string_0)
  {
    if (string_0 == null)
      throw new ArgumentNullException("headerValue");
    MailPriority mailPriority;
    switch (string_0.ToUpperInvariant())
    {
      case "5":
      case "HIGH":
        mailPriority = MailPriority.High;
        break;
      case "3":
      case "NORMAL":
        mailPriority = MailPriority.Normal;
        break;
      case "1":
      case "LOW":
        mailPriority = MailPriority.Low;
        break;
      default:
        DefaultLogger.Log.LogDebug($"HeaderFieldParser: Unknown importance value: \"{string_0}\". Using default of normal importance.");
        mailPriority = MailPriority.Normal;
        break;
    }
    return mailPriority;
  }

  static Class34.Class38 smethod_29(Class34.Class39 class39_0)
  {
    byte[] numArray = new byte[class39_0.int_3];
    Array.Copy((Array) class39_0.byte_1, 0, (Array) numArray, 0, class39_0.int_3);
    return new Class34.Class38(numArray);
  }

  static string smethod_30(string string_0, Encoding encoding_0)
  {
    if (string_0 == null)
      throw new ArgumentNullException("base64Encoded");
    return encoding_0 != null ? encoding_0.GetString(Class30.smethod_87(string_0)) : throw new ArgumentNullException("encoding");
  }

  static void smethod_31(
    TriangulationConstraint triangulationConstraint_0,
    AdvancingFrontNode advancingFrontNode_0,
    DTSweepContext dtsweepContext_0)
  {
    while (advancingFrontNode_0.Next.Point.X < triangulationConstraint_0.P.X)
    {
      if (dtsweepContext_0.IsDebugEnabled)
        dtsweepContext_0.DebugContext.ActiveNode = advancingFrontNode_0;
      if (TriangulationUtil.Orient2d((Point2D) triangulationConstraint_0.Q, (Point2D) advancingFrontNode_0.Next.Point, (Point2D) triangulationConstraint_0.P) == Orientation.AntiClockwise)
        Class30.smethod_271(advancingFrontNode_0, dtsweepContext_0, triangulationConstraint_0);
      else
        advancingFrontNode_0 = advancingFrontNode_0.Next;
    }
  }

  static bool smethod_32(
    IntPoint intPoint_0,
    IntPoint intPoint_1,
    buClipperBase buClipperBase_0,
    IntPoint intPoint_2)
  {
    return (intPoint_0 == intPoint_2 || intPoint_0 == intPoint_1 ? 1 : (intPoint_2 == intPoint_1 ? 1 : 0)) == 0 && (intPoint_0.X == intPoint_2.X ? intPoint_1.Y > intPoint_0.Y == intPoint_1.Y < intPoint_2.Y : intPoint_1.X > intPoint_0.X == intPoint_1.X < intPoint_2.X);
  }

  static void smethod_33(Class34.Class37 class37_0, int int_0, int int_1)
  {
    if ((class37_0.int_1 += int_0) > 32768 /*0x8000*/)
      throw new InvalidOperationException();
    int num1 = class37_0.int_0 - int_1 & (int) short.MaxValue;
    int num2 = 32768 /*0x8000*/ - int_0;
    if (num1 <= num2 && class37_0.int_0 < num2)
    {
      if (int_0 <= int_1)
      {
        Array.Copy((Array) class37_0.byte_0, num1, (Array) class37_0.byte_0, class37_0.int_0, int_0);
        class37_0.int_0 += int_0;
      }
      else
      {
        while (int_0-- > 0)
        {
          byte[] byte0 = class37_0.byte_0;
          Class34.Class37 class37 = class37_0;
          int int0 = class37_0.int_0;
          int num3 = int0 + 1;
          class37.int_0 = num3;
          int index = int0;
          int num4 = (int) class37_0.byte_0[num1++];
          byte0[index] = (byte) num4;
        }
      }
    }
    else
      Class30.smethod_80(class37_0, num1, int_0);
  }

  static bool smethod_34(buClipper buClipper_0, Class26 class26_0, Class26 class26_1)
  {
    do
    {
      class26_0 = class26_0.class26_0;
      if (class26_0 == class26_1)
        goto label_3;
    }
    while (class26_0 != null);
    goto label_4;
label_3:
    bool flag = true;
    goto label_5;
label_4:
    flag = false;
label_5:
    return flag;
  }

  static void smethod_35(buClipper buClipper_0, Class22 class22_0, Class22 class22_1)
  {
    if ((class22_0.class22_5 != null ? 0 : (class22_0.class22_6 == null ? 1 : 0)) != 0 || (class22_1.class22_5 != null ? 0 : (class22_1.class22_6 == null ? 1 : 0)) != 0)
      return;
    if (class22_0.class22_5 == class22_1)
    {
      Class22 class225 = class22_1.class22_5;
      if (class225 != null)
        class225.class22_6 = class22_0;
      Class22 class226 = class22_0.class22_6;
      if (class226 != null)
        class226.class22_5 = class22_1;
      class22_1.class22_6 = class226;
      class22_1.class22_5 = class22_0;
      class22_0.class22_6 = class22_1;
      class22_0.class22_5 = class225;
    }
    else if (class22_1.class22_5 == class22_0)
    {
      Class22 class225 = class22_0.class22_5;
      if (class225 != null)
        class225.class22_6 = class22_1;
      Class22 class226 = class22_1.class22_6;
      if (class226 != null)
        class226.class22_5 = class22_0;
      class22_0.class22_6 = class226;
      class22_0.class22_5 = class22_1;
      class22_1.class22_6 = class22_0;
      class22_1.class22_5 = class225;
    }
    else
    {
      Class22 class225 = class22_0.class22_5;
      Class22 class226 = class22_0.class22_6;
      class22_0.class22_5 = class22_1.class22_5;
      if (class22_0.class22_5 != null)
        class22_0.class22_5.class22_6 = class22_0;
      class22_0.class22_6 = class22_1.class22_6;
      if (class22_0.class22_6 != null)
        class22_0.class22_6.class22_5 = class22_0;
      class22_1.class22_5 = class225;
      if (class22_1.class22_5 != null)
        class22_1.class22_5.class22_6 = class22_1;
      class22_1.class22_6 = class226;
      if (class22_1.class22_6 != null)
        class22_1.class22_6.class22_5 = class22_1;
    }
    if (class22_0.class22_6 == null)
    {
      buClipper_0.class22_1 = class22_0;
    }
    else
    {
      if (class22_1.class22_6 != null)
        return;
      buClipper_0.class22_1 = class22_1;
    }
  }

  static void smethod_36(DelaunayTriangle delaunayTriangle_0)
  {
    delaunayTriangle_0.Neighbors[0] = delaunayTriangle_0.Neighbors[1] = delaunayTriangle_0.Neighbors[2] = (DelaunayTriangle) null;
  }

  static string smethod_37(Match match_0)
  {
    string string_0 = match_0.Success ? match_0.Value : throw new ArgumentException("Match success are always true");
    string str;
    switch (Class30.smethod_119(string_0))
    {
      case 308297344:
        if (string_0 == "MDT")
        {
          str = "-0600";
          goto label_72;
        }
        goto default;
      case 339145631:
        if (string_0 == "MST")
        {
          str = "-0700";
          goto label_72;
        }
        goto default;
      case 995535842:
        if (string_0 == "CDT")
        {
          str = "-0500";
          goto label_72;
        }
        goto default;
      case 1727238636:
        if (string_0 == "UT")
          break;
        goto default;
      case 2099357029:
        if (string_0 == "CST")
        {
          str = "-0600";
          goto label_72;
        }
        goto default;
      case 2586683136:
        if (string_0 == "PST")
        {
          str = "-0800";
          goto label_72;
        }
        goto default;
      case 2617531423:
        if (string_0 == "PDT")
        {
          str = "-0700";
          goto label_72;
        }
        goto default;
      case 3140198408:
        if (string_0 == "EDT")
        {
          str = "-0400";
          goto label_72;
        }
        goto default;
      case 3222007936:
        if (string_0 == "E")
        {
          str = "+0500";
          goto label_72;
        }
        goto default;
      case 3238785555:
        if (string_0 == "D")
        {
          str = "+0400";
          goto label_72;
        }
        goto default;
      case 3255563174:
        if (string_0 == "G")
        {
          str = "+0700";
          goto label_72;
        }
        goto default;
      case 3272340793:
        if (string_0 == "F")
        {
          str = "+0600";
          goto label_72;
        }
        goto default;
      case 3289118412:
        if (string_0 == "A")
        {
          str = "+0100";
          goto label_72;
        }
        goto default;
      case 3322673650:
        if (string_0 == "C")
        {
          str = "+0300";
          goto label_72;
        }
        goto default;
      case 3338310079:
        if (string_0 == "GMT")
          break;
        goto default;
      case 3339451269:
        if (string_0 == "B")
        {
          str = "+0200";
          goto label_72;
        }
        goto default;
      case 3356228888:
        if (string_0 == "M")
        {
          str = "+1200";
          goto label_72;
        }
        goto default;
      case 3373006507:
        if (string_0 == "L")
        {
          str = "+1100";
          goto label_72;
        }
        goto default;
      case 3389784126:
        if (string_0 == "O")
        {
          str = "-0200";
          goto label_72;
        }
        goto default;
      case 3406561745:
        if (string_0 == "N")
        {
          str = "-0100";
          goto label_72;
        }
        goto default;
      case 3423339364:
        if (string_0 == "I")
        {
          str = "+0900";
          goto label_72;
        }
        goto default;
      case 3440116983:
        if (string_0 == "H")
        {
          str = "+0800";
          goto label_72;
        }
        goto default;
      case 3456894602:
        if (string_0 == "K")
        {
          str = "+1000";
          goto label_72;
        }
        goto default;
      case 3490449840:
        if (string_0 == "U")
        {
          str = "-0800";
          goto label_72;
        }
        goto default;
      case 3507227459:
        if (string_0 == "T")
        {
          str = "-0700";
          goto label_72;
        }
        goto default;
      case 3524005078:
        if (string_0 == "W")
        {
          str = "-1000";
          goto label_72;
        }
        goto default;
      case 3540782697:
        if (string_0 == "V")
        {
          str = "-0900";
          goto label_72;
        }
        goto default;
      case 3557560316:
        if (string_0 == "Q")
        {
          str = "-0400";
          goto label_72;
        }
        goto default;
      case 3574337935:
        if (string_0 == "P")
        {
          str = "-0300";
          goto label_72;
        }
        goto default;
      case 3591115554:
        if (string_0 == "S")
        {
          str = "-0600";
          goto label_72;
        }
        goto default;
      case 3607893173:
        if (string_0 == "R")
        {
          str = "-0500";
          goto label_72;
        }
        goto default;
      case 3691781268:
        if (string_0 == "Y")
        {
          str = "-1200";
          goto label_72;
        }
        goto default;
      case 3708558887:
        if (string_0 == "X")
        {
          str = "-1100";
          goto label_72;
        }
        goto default;
      case 3742114125:
        if (!(string_0 == "Z"))
          goto default;
        break;
      case 4249934023:
        if (string_0 == "EST")
        {
          str = "-0500";
          goto label_72;
        }
        goto default;
      default:
        throw new ArgumentException("Unexpected input");
    }
    str = "+0000";
label_72:
    return str;
  }

  static void smethod_38(
    ref List<eEntities> list_0,
    ref eLine eLine_0,
    buFile.Cf2 cf2_0,
    string[] string_0)
  {
    Pnt3D pnt3D1 = new Pnt3D();
    Pnt3D pnt3D2 = new Pnt3D();
    Pnt3D StartPoint = new Pnt3D();
    Pnt3D EndPoint = new Pnt3D();
    Pnt3D pnt3D3 = new Pnt3D();
    Cf2FileProperties cf2FileProperties = new Cf2FileProperties();
    double num1 = 0.0;
    double num2 = 0.0;
    double num3 = 0.0;
    if (buNumeric.IsNumeric(string_0[1]))
      num3 = double.Parse(string_0[1]);
    if (buNumeric.IsNumeric(string_0[2]))
      num1 = double.Parse(string_0[2]);
    if (buNumeric.IsNumeric(string_0[3]))
      num2 = double.Parse(string_0[3]);
    bool flag = false;
    for (int index = 0; index <= cf2_0.FileDefinations.Count - 1; ++index)
    {
      if (cf2_0.FileDefinations[index].Cf2CodeMatchType == num1 & cf2_0.FileDefinations[index].PtIndex == num3)
      {
        cf2FileProperties = new Cf2FileProperties(cf2_0.FileDefinations[index]);
        if (cf2FileProperties.LayerIndex < 0)
          cf2FileProperties.LayerIndex = index;
        flag = true;
      }
    }
    Pnt3D pnt3D4 = new Pnt3D(double.Parse(string_0[4], (IFormatProvider) buSystem.CI), double.Parse(string_0[5], (IFormatProvider) buSystem.CI));
    Pnt3D pnt3D5 = new Pnt3D(double.Parse(string_0[6], (IFormatProvider) buSystem.CI), double.Parse(string_0[7], (IFormatProvider) buSystem.CI));
    eLine_0 = new eLine(pnt3D4, pnt3D5);
    eLine_0.Diemaker = new DiemakerData();
    eLine_0.Diemaker.Pt = cf2FileProperties.PtRealValue;
    eLine_0.Diemaker.RuleHeight = num2;
    eLine_0.Diemaker.DiemakerType = cf2FileProperties.CodeType;
    eLine_0.Diemaker.DiemakerTYpeAsInteger = Convert.ToInt32(num1);
    eLine_0.dispColor = cf2FileProperties.Color;
    eLine_0.dispThickness = (float) cf2FileProperties.Thickness;
    if (!flag)
      eLine_0.Diemaker.Pt = num3;
    if (cf2FileProperties.LayerIndex >= 0)
      eLine_0.LayerIndex = cf2FileProperties.LayerIndex;
    if (cf2_0.Layers.Count > 0 & cf2FileProperties.LayerIndex >= 0 & cf2FileProperties.LayerIndex <= cf2_0.Layers.Count - 1)
      eLine_0.LayerIndex = cf2FileProperties.LayerIndex;
    int num4 = int.Parse(string_0[8], (IFormatProvider) buSystem.CI);
    double num5 = double.Parse(string_0[9], (IFormatProvider) buSystem.CI);
    List<Pnt3D> Vertices = new List<Pnt3D>();
    if (!(num4 > 0 & num5 >= cf2_0.BridgeMinLimit & num5 <= cf2_0.BridgeMaxLimit))
      return;
    double Length = buAppCalc.cVector.Length3D(pnt3D4, pnt3D5) / (double) num4;
    buAppCalc.cVector.LineerToLineer(pnt3D4, pnt3D5, Length, ref Vertices);
    double Angle = buAppCalc.cVector.PointAngle(pnt3D5, pnt3D4);
    for (int index = 1; index <= Vertices.Count - 1; ++index)
    {
      Pnt3D CenterPoint = buAppCalc.cVector.MiddlePointOfLine(Vertices[index - 1], Vertices[index]);
      buAppCalc.cVector.LineWithCenterPointByLengthAndAngle(CenterPoint, num5 / 2.0, Angle, new WorkPlane(), ref StartPoint, ref EndPoint);
      eLine eLine = new eLine(StartPoint, EndPoint);
      eLine.Diemaker = new DiemakerData();
      eLine.Diemaker.IsBridge = true;
      eLine.Diemaker.Pt = cf2FileProperties.PtRealValue;
      eLine.Diemaker.DiemakerType = cf2FileProperties.CodeType;
      eLine.Diemaker.DiemakerTYpeAsInteger = Convert.ToInt32((object) DiemakerType.Bridge);
      if (cf2FileProperties.CodeType == DiemakerType.None)
        eLine.Diemaker.Pt = num3;
      if (cf2_0.FoundBridgeProperties.LayerIndex >= 0)
        eLine.LayerIndex = cf2_0.FoundBridgeProperties.LayerIndex;
      list_0.Add((eEntities) eLine);
    }
  }

  static string smethod_39(string string_0, string string_1, string string_2)
  {
    if (string_1 == null)
      throw new ArgumentNullException("username");
    if (string_2 == null)
      throw new ArgumentNullException("password");
    if (string_0 == null)
      throw new ArgumentNullException("challenge");
    byte[] byte_1_1 = Class30.smethod_86(string_2);
    byte[] byte_1_2 = Convert.FromBase64String(string_0);
    string lowerInvariant = BitConverter.ToString(Class30.smethod_59(Class30.smethod_122(Class30.smethod_208(Class5.byte_1, byte_1_1), Class30.smethod_59(Class30.smethod_122(Class30.smethod_208(Class5.byte_0, byte_1_1), byte_1_2))))).Replace("-", "").ToLowerInvariant();
    return Convert.ToBase64String(Encoding.ASCII.GetBytes($"{string_1} {lowerInvariant}"));
  }

  static double[,] smethod_40(FIP fip_0, double[,] double_0)
  {
    double[,] numArray = new double[double_0.GetLength(0), double_0.GetLength(1)];
    for (int index1 = 0; index1 < double_0.GetLength(0); ++index1)
    {
      for (int index2 = 0; index2 < double_0.GetLength(1); ++index2)
        numArray[index1, index2] = Math.Pow(-1.0, (double) (index1 + index2)) * double_0[index1, index2];
    }
    return numArray;
  }

  static void smethod_41(
    TriangulationPoint triangulationPoint_0,
    DTSweepContext dtsweepContext_0,
    TriangulationPoint triangulationPoint_1,
    TriangulationPoint triangulationPoint_2,
    DelaunayTriangle delaunayTriangle_0)
  {
    DelaunayTriangle delaunayTriangle = delaunayTriangle_0.NeighborAcrossFrom(triangulationPoint_0);
    TriangulationPoint triangulationPoint = delaunayTriangle.OppositePoint(delaunayTriangle_0, triangulationPoint_0);
    if (delaunayTriangle == null)
      throw new InvalidOperationException("[BUG:FIXME] FLIP failed due to missing triangle");
    if (dtsweepContext_0.IsDebugEnabled)
    {
      dtsweepContext_0.DebugContext.PrimaryTriangle = delaunayTriangle_0;
      dtsweepContext_0.DebugContext.SecondaryTriangle = delaunayTriangle;
    }
    if (TriangulationUtil.InScanArea((Point2D) triangulationPoint_0, (Point2D) delaunayTriangle_0.PointCCWFrom(triangulationPoint_0), (Point2D) delaunayTriangle_0.PointCWFrom(triangulationPoint_0), (Point2D) triangulationPoint))
    {
      Class30.smethod_65(triangulationPoint, delaunayTriangle, delaunayTriangle_0, triangulationPoint_0);
      dtsweepContext_0.MapTriangleToNodes(delaunayTriangle_0);
      dtsweepContext_0.MapTriangleToNodes(delaunayTriangle);
      if ((!triangulationPoint_0.Equals(triangulationPoint_2) ? 0 : (triangulationPoint.Equals(triangulationPoint_1) ? 1 : 0)) != 0)
      {
        if ((!triangulationPoint_2.Equals(dtsweepContext_0.EdgeEvent.ConstrainedEdge.Q) ? 0 : (triangulationPoint_1.Equals(dtsweepContext_0.EdgeEvent.ConstrainedEdge.P) ? 1 : 0)) != 0)
        {
          if (dtsweepContext_0.IsDebugEnabled)
            Console.WriteLine("[FLIP] - constrained edge done");
          delaunayTriangle_0.MarkConstrainedEdge(triangulationPoint_1, triangulationPoint_2);
          delaunayTriangle.MarkConstrainedEdge(triangulationPoint_1, triangulationPoint_2);
          Class30.smethod_226(dtsweepContext_0, delaunayTriangle_0);
          Class30.smethod_226(dtsweepContext_0, delaunayTriangle);
        }
        else
        {
          if (!dtsweepContext_0.IsDebugEnabled)
            return;
          Console.WriteLine("[FLIP] - subedge done");
        }
      }
      else
      {
        if (dtsweepContext_0.IsDebugEnabled)
          Console.WriteLine("[FLIP] - flipping and continuing with triangle still crossing edge");
        Orientation orientation_0 = TriangulationUtil.Orient2d((Point2D) triangulationPoint_2, (Point2D) triangulationPoint, (Point2D) triangulationPoint_1);
        delaunayTriangle_0 = Class30.smethod_73(triangulationPoint, orientation_0, dtsweepContext_0, delaunayTriangle_0, delaunayTriangle, triangulationPoint_0);
        Class30.smethod_41(triangulationPoint_0, dtsweepContext_0, triangulationPoint_1, triangulationPoint_2, delaunayTriangle_0);
      }
    }
    else
    {
      TriangulationPoint triangulationPoint_0_1;
      if (!Class30.smethod_156(ref triangulationPoint_0_1, (Point2D) triangulationPoint_1, delaunayTriangle, triangulationPoint, (Point2D) triangulationPoint_2))
        return;
      Class30.smethod_289(delaunayTriangle, (Point2D) triangulationPoint_1, dtsweepContext_0, triangulationPoint_0_1, delaunayTriangle_0, triangulationPoint_2);
      Class30.smethod_49(triangulationPoint_1, triangulationPoint_0, dtsweepContext_0, delaunayTriangle_0, triangulationPoint_2);
    }
  }

  static bool smethod_42(buClipper buClipper_0)
  {
    buClipper_0.list_2.Sort(buClipper_0.icomparer_0);
    Class30.smethod_25(buClipper_0);
    int count = buClipper_0.list_2.Count;
    bool flag;
    for (int index1 = 0; index1 < count; ++index1)
    {
      if (!Class30.smethod_85(buClipper_0, buClipper_0.list_2[index1]))
      {
        int index2 = index1 + 1;
        while ((index2 >= count ? 0 : (!Class30.smethod_85(buClipper_0, buClipper_0.list_2[index2]) ? 1 : 0)) != 0)
          ++index2;
        if (index2 != count)
        {
          IntersectNode intersectNode = buClipper_0.list_2[index1];
          buClipper_0.list_2[index1] = buClipper_0.list_2[index2];
          buClipper_0.list_2[index2] = intersectNode;
        }
        else
        {
          flag = false;
          goto label_11;
        }
      }
      Class30.smethod_35(buClipper_0, buClipper_0.list_2[index1].class22_0, buClipper_0.list_2[index1].class22_1);
    }
    flag = true;
label_11:
    return flag;
  }

  static bool smethod_43(
    int int_0,
    ref Color color_0,
    ref double double_0,
    buFile.Dxf dxf_0,
    ref double double_1,
    ref double double_2,
    ref string string_0,
    ref double double_3,
    ref double double_4,
    ref double double_5)
  {
    bool flag1 = true;
    bool flag2 = false;
    int num = 0;
    for (int index = int_0; index <= dxf_0.list_0.Count - 1; ++index)
    {
      if (num < 80 /*0x50*/)
      {
        string str = dxf_0.list_0[index];
        ++num;
        if (flag1 & dxf_0.list_0[index] == "AcDbEntity")
          string_0 = dxf_0.list_0[index + 2];
        if (flag1 & dxf_0.list_0[index] == "  8")
          string_0 = dxf_0.list_0[index + 1];
        if (flag1 & dxf_0.list_0[index] == " 62")
        {
          int int32 = Convert.ToInt32(dxf_0.list_0[index + 1]);
          color_0 = int32 >= dxf_0.ColorCode.Length ? Color.Black : dxf_0.ColorCode[int32];
          if (color_0.A == (byte) 0 & color_0.R == (byte) 0 & color_0.G == (byte) 0 & color_0.B == (byte) 0)
            color_0 = Color.Black;
        }
        if (dxf_0.list_0[index] == "10")
          double_4 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
        if (dxf_0.list_0[index] == "20")
          double_2 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
        if (dxf_0.list_0[index] == "30")
          double_5 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
        if (dxf_0.list_0[index] == "11")
          double_1 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
        if (dxf_0.list_0[index] == "21")
        {
          double_3 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
          if (dxf_0.list_0[index + 2] != "31")
          {
            flag2 = true;
            break;
          }
        }
        if (dxf_0.list_0[index] == "31")
        {
          double_0 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
          flag2 = false;
          break;
        }
      }
      else
      {
        flag2 = false;
        break;
      }
    }
    return flag2;
  }

  static void smethod_44(string string_0, MessageHeader messageHeader_0, string string_1)
  {
    if (string_1 == null)
      throw new ArgumentNullException("headerName");
    if (string_0 == null)
      throw new ArgumentNullException("headerValue");
    string upperInvariant = string_1.ToUpperInvariant();
    switch (Class30.smethod_119(upperInvariant))
    {
      case 569730020:
        if (upperInvariant == "TO")
        {
          messageHeader_0.To = Class30.smethod_96(string_0);
          return;
        }
        break;
      case 633019157:
        if (upperInvariant == "KEYWORDS")
        {
          string str1 = string_0;
          char[] chArray = new char[1]{ ',' };
          foreach (string str2 in str1.Split(chArray))
            messageHeader_0.Keywords.Add(Class30.smethod_10(str2.Trim()));
          return;
        }
        break;
      case 905391459:
        if (upperInvariant == "REPLY-TO")
        {
          messageHeader_0.ReplyTo = Class30.smethod_267(string_0);
          return;
        }
        break;
      case 963715476:
        if (upperInvariant == "CONTENT-TRANSFER-ENCODING")
        {
          messageHeader_0.ContentTransferEncoding = Class30.smethod_198(string_0.Trim());
          return;
        }
        break;
      case 1349348241:
        if (upperInvariant == "CONTENT-DESCRIPTION")
        {
          messageHeader_0.ContentDescription = Class30.smethod_179(string_0.Trim());
          return;
        }
        break;
      case 1396931398:
        if (upperInvariant == "MESSAGE-ID")
        {
          messageHeader_0.MessageId = Class30.smethod_76(string_0);
          return;
        }
        break;
      case 1411505060:
        if (upperInvariant == "SENDER")
        {
          messageHeader_0.Sender = Class30.smethod_267(string_0);
          return;
        }
        break;
      case 1415727179:
        if (upperInvariant == "REFERENCES")
        {
          messageHeader_0.References = Class30.smethod_295(string_0);
          return;
        }
        break;
      case 1418384879:
        if (upperInvariant == "SUBJECT")
        {
          messageHeader_0.Subject = Class30.smethod_179(string_0);
          return;
        }
        break;
      case 1509690621:
        if (upperInvariant == "RETURN-PATH")
        {
          messageHeader_0.ReturnPath = Class30.smethod_267(string_0);
          return;
        }
        break;
      case 1977225635:
        if (upperInvariant == "CC")
        {
          messageHeader_0.Cc = Class30.smethod_96(string_0);
          return;
        }
        break;
      case 2438262959:
        if (upperInvariant == "IMPORTANCE")
        {
          messageHeader_0.Importance = Class30.smethod_28(string_0.Trim());
          return;
        }
        break;
      case 2462664700:
        if (upperInvariant == "MIME-VERSION")
        {
          messageHeader_0.MimeVersion = string_0.Trim();
          return;
        }
        break;
      case 2478748789:
        if (upperInvariant == "FROM")
        {
          messageHeader_0.From = Class30.smethod_267(string_0);
          return;
        }
        break;
      case 3027495439:
        if (upperInvariant == "IN-REPLY-TO")
        {
          messageHeader_0.InReplyTo = Class30.smethod_295(string_0);
          return;
        }
        break;
      case 3093786662:
        if (upperInvariant == "DISPOSITION-NOTIFICATION-TO")
        {
          messageHeader_0.DispositionNotificationTo = Class30.smethod_96(string_0);
          return;
        }
        break;
      case 3098799004:
        if (upperInvariant == "CONTENT-DISPOSITION")
        {
          messageHeader_0.ContentDisposition = Class11.smethod_1(string_0);
          return;
        }
        break;
      case 3221746841:
        if (upperInvariant == "DATE")
        {
          messageHeader_0.Date = string_0.Trim();
          messageHeader_0.DateSent = Class30.smethod_236(string_0);
          return;
        }
        break;
      case 3357413298:
        if (upperInvariant == "RECEIVED")
        {
          messageHeader_0.Received.Add(new Received(string_0.Trim()));
          return;
        }
        break;
      case 3747899112:
        if (upperInvariant == "CONTENT-ID")
        {
          messageHeader_0.ContentId = Class30.smethod_76(string_0);
          return;
        }
        break;
      case 3945365109:
        if (upperInvariant == "CONTENT-TYPE")
        {
          messageHeader_0.ContentType = Class11.smethod_0(string_0);
          return;
        }
        break;
      case 4101178211:
        if (upperInvariant == "BCC")
        {
          messageHeader_0.Bcc = Class30.smethod_96(string_0);
          return;
        }
        break;
    }
    messageHeader_0.UnknownHeaders.Add(string_1, string_0);
  }

  static void smethod_45(Class22 class22_0, Class22 class22_1, buClipperBase buClipperBase_0)
  {
    if ((class22_1.class22_3 == class22_1.class22_4 ? 1 : (class22_0.class22_3 == class22_0.class22_4 ? 1 : 0)) != 0)
      return;
    if (class22_1.class22_3 == class22_0)
    {
      Class22 class223 = class22_0.class22_3;
      if (class223 != null)
        class223.class22_4 = class22_1;
      Class22 class224 = class22_1.class22_4;
      if (class224 != null)
        class224.class22_3 = class22_0;
      class22_0.class22_4 = class224;
      class22_0.class22_3 = class22_1;
      class22_1.class22_4 = class22_0;
      class22_1.class22_3 = class223;
    }
    else if (class22_0.class22_3 == class22_1)
    {
      Class22 class223 = class22_1.class22_3;
      if (class223 != null)
        class223.class22_4 = class22_0;
      Class22 class224 = class22_0.class22_4;
      if (class224 != null)
        class224.class22_3 = class22_1;
      class22_1.class22_4 = class224;
      class22_1.class22_3 = class22_0;
      class22_0.class22_4 = class22_1;
      class22_0.class22_3 = class223;
    }
    else
    {
      Class22 class223 = class22_1.class22_3;
      Class22 class224 = class22_1.class22_4;
      class22_1.class22_3 = class22_0.class22_3;
      if (class22_1.class22_3 != null)
        class22_1.class22_3.class22_4 = class22_1;
      class22_1.class22_4 = class22_0.class22_4;
      if (class22_1.class22_4 != null)
        class22_1.class22_4.class22_3 = class22_1;
      class22_0.class22_3 = class223;
      if (class22_0.class22_3 != null)
        class22_0.class22_3.class22_4 = class22_0;
      class22_0.class22_4 = class224;
      if (class22_0.class22_4 != null)
        class22_0.class22_4.class22_3 = class22_0;
    }
    if (class22_1.class22_4 == null)
    {
      buClipperBase_0.class22_0 = class22_1;
    }
    else
    {
      if (class22_0.class22_4 != null)
        return;
      buClipperBase_0.class22_0 = class22_0;
    }
  }

  static int smethod_46(byte[] byte_0, int int_0, Class34.Class35 class35_0, int int_1)
  {
    int num1 = 0;
    do
    {
      if (class35_0.int_4 != 11)
        goto label_2;
label_1:
      continue;
label_2:
      int num2 = Class30.smethod_153(int_0, byte_0, int_1, class35_0.class37_0);
      int_1 += num2;
      num1 += num2;
      int_0 -= num2;
      if (int_0 != 0)
        goto label_1;
      goto label_4;
    }
    while (Class30.smethod_138(class35_0) || class35_0.class37_0.int_1 > 0 && class35_0.int_4 != 11);
    goto label_5;
label_4:
    return num1;
label_5:
    return num1;
  }

  static void smethod_47(Class22 class22_0, buClipper buClipper_0, Class22 class22_1)
  {
    if (buClipper_0.class22_0 == null)
    {
      class22_1.class22_4 = (Class22) null;
      class22_1.class22_3 = (Class22) null;
      buClipper_0.class22_0 = class22_1;
    }
    else if ((class22_0 != null ? 0 : (Class30.smethod_19(buClipper_0.class22_0, class22_1, buClipper_0) ? 1 : 0)) != 0)
    {
      class22_1.class22_4 = (Class22) null;
      class22_1.class22_3 = buClipper_0.class22_0;
      buClipper_0.class22_0.class22_4 = class22_1;
      buClipper_0.class22_0 = class22_1;
    }
    else
    {
      if (class22_0 == null)
        class22_0 = buClipper_0.class22_0;
      while ((class22_0.class22_3 == null ? 0 : (!Class30.smethod_19(class22_0.class22_3, class22_1, buClipper_0) ? 1 : 0)) != 0)
        class22_0 = class22_0.class22_3;
      class22_1.class22_3 = class22_0.class22_3;
      if (class22_0.class22_3 != null)
        class22_0.class22_3.class22_4 = class22_1;
      class22_1.class22_4 = class22_0;
      class22_0.class22_3 = class22_1;
    }
  }

  static void smethod_48(
    Class22 class22_0,
    buClipperBase buClipperBase_0,
    Class22 class22_1,
    Class22 class22_2,
    IntPoint intPoint_0)
  {
    class22_0.class22_0 = class22_1;
    class22_0.class22_1 = class22_2;
    class22_0.intPoint_1 = intPoint_0;
    class22_0.int_3 = -1;
  }

  static void smethod_49(
    TriangulationPoint triangulationPoint_0,
    TriangulationPoint triangulationPoint_1,
    DTSweepContext dtsweepContext_0,
    DelaunayTriangle delaunayTriangle_0,
    TriangulationPoint triangulationPoint_2)
  {
    if (dtsweepContext_0.IsDebugEnabled)
      dtsweepContext_0.DebugContext.PrimaryTriangle = delaunayTriangle_0;
    if (Class30.smethod_181(delaunayTriangle_0, triangulationPoint_0, triangulationPoint_2))
      return;
    TriangulationPoint triangulationPoint1 = delaunayTriangle_0.PointCCWFrom(triangulationPoint_1);
    Orientation orientation1 = TriangulationUtil.Orient2d((Point2D) triangulationPoint_2, (Point2D) triangulationPoint1, (Point2D) triangulationPoint_0);
    if (orientation1 == Orientation.Collinear)
    {
      if ((!delaunayTriangle_0.Contains(triangulationPoint_2) ? 0 : (delaunayTriangle_0.Contains(triangulationPoint1) ? 1 : 0)) == 0)
        throw new PointOnEdgeException("EdgeEvent - Point on constrained edge not supported yet", triangulationPoint_0, triangulationPoint_2, triangulationPoint1);
      delaunayTriangle_0.MarkConstrainedEdge(triangulationPoint_2, triangulationPoint1);
      dtsweepContext_0.EdgeEvent.ConstrainedEdge.Q = triangulationPoint1;
      delaunayTriangle_0 = delaunayTriangle_0.NeighborAcrossFrom(triangulationPoint_1);
      Class30.smethod_49(triangulationPoint_0, triangulationPoint1, dtsweepContext_0, delaunayTriangle_0, triangulationPoint1);
      if (!dtsweepContext_0.IsDebugEnabled)
        return;
      Console.WriteLine("EdgeEvent - Point on constrained edge");
    }
    else
    {
      TriangulationPoint triangulationPoint2 = delaunayTriangle_0.PointCWFrom(triangulationPoint_1);
      Orientation orientation2 = TriangulationUtil.Orient2d((Point2D) triangulationPoint_2, (Point2D) triangulationPoint2, (Point2D) triangulationPoint_0);
      if (orientation2 == Orientation.Collinear)
      {
        if ((!delaunayTriangle_0.Contains(triangulationPoint_2) ? 0 : (delaunayTriangle_0.Contains(triangulationPoint2) ? 1 : 0)) == 0)
          throw new PointOnEdgeException("EdgeEvent - Point on constrained edge not supported yet", triangulationPoint_0, triangulationPoint_2, triangulationPoint2);
        delaunayTriangle_0.MarkConstrainedEdge(triangulationPoint_2, triangulationPoint2);
        dtsweepContext_0.EdgeEvent.ConstrainedEdge.Q = triangulationPoint2;
        delaunayTriangle_0 = delaunayTriangle_0.NeighborAcrossFrom(triangulationPoint_1);
        if (delaunayTriangle_0 != null)
          Class30.smethod_49(triangulationPoint_0, triangulationPoint2, dtsweepContext_0, delaunayTriangle_0, triangulationPoint2);
        if (!dtsweepContext_0.IsDebugEnabled)
          return;
        Console.WriteLine("EdgeEvent - Point on constrained edge");
      }
      else if (orientation1 == orientation2)
      {
        delaunayTriangle_0 = orientation1 == Orientation.Clockwise ? delaunayTriangle_0.NeighborCCWFrom(triangulationPoint_1) : delaunayTriangle_0.NeighborCWFrom(triangulationPoint_1);
        Class30.smethod_49(triangulationPoint_0, triangulationPoint_1, dtsweepContext_0, delaunayTriangle_0, triangulationPoint_2);
      }
      else
        Class30.smethod_41(triangulationPoint_1, dtsweepContext_0, triangulationPoint_0, triangulationPoint_2, delaunayTriangle_0);
    }
  }

  static int smethod_50(buFile.PLYToSchematic.Enum1 enum1_0)
  {
    int num;
    switch (enum1_0)
    {
      case buFile.PLYToSchematic.Enum1.const_1:
        num = 1;
        break;
      case buFile.PLYToSchematic.Enum1.const_2:
        num = 1;
        break;
      case buFile.PLYToSchematic.Enum1.const_3:
        num = 1;
        break;
      case buFile.PLYToSchematic.Enum1.const_4:
        num = 1;
        break;
      case buFile.PLYToSchematic.Enum1.const_5:
        num = 2;
        break;
      case buFile.PLYToSchematic.Enum1.const_6:
        num = 2;
        break;
      case buFile.PLYToSchematic.Enum1.const_7:
        num = 2;
        break;
      case buFile.PLYToSchematic.Enum1.const_8:
        num = 2;
        break;
      case buFile.PLYToSchematic.Enum1.const_9:
        num = 4;
        break;
      case buFile.PLYToSchematic.Enum1.const_10:
        num = 4;
        break;
      case buFile.PLYToSchematic.Enum1.const_11:
        num = 4;
        break;
      case buFile.PLYToSchematic.Enum1.const_12:
        num = 8;
        break;
      case buFile.PLYToSchematic.Enum1.const_13:
        num = 8;
        break;
      case buFile.PLYToSchematic.Enum1.const_14:
        num = 8;
        break;
      case buFile.PLYToSchematic.Enum1.const_15:
        num = 1;
        break;
      case buFile.PLYToSchematic.Enum1.const_16:
        num = 2;
        break;
      case buFile.PLYToSchematic.Enum1.const_17:
        num = 4;
        break;
      case buFile.PLYToSchematic.Enum1.const_18:
        num = 8;
        break;
      default:
        num = 0;
        break;
    }
    return num;
  }

  static void smethod_51(DTSweepContext dtsweepContext_0, AdvancingFrontNode advancingFrontNode_0)
  {
    DelaunayTriangle delaunayTriangle = new DelaunayTriangle(advancingFrontNode_0.Prev.Point, advancingFrontNode_0.Point, advancingFrontNode_0.Next.Point);
    delaunayTriangle.MarkNeighbor(advancingFrontNode_0.Prev.Triangle);
    delaunayTriangle.MarkNeighbor(advancingFrontNode_0.Triangle);
    dtsweepContext_0.Triangles.Add(delaunayTriangle);
    advancingFrontNode_0.Prev.Next = advancingFrontNode_0.Next;
    advancingFrontNode_0.Next.Prev = advancingFrontNode_0.Prev;
    if (Class30.smethod_226(dtsweepContext_0, delaunayTriangle))
      return;
    dtsweepContext_0.MapTriangleToNodes(delaunayTriangle);
  }

  static DateTime smethod_52(string string_0)
  {
    Match match = string_0 != null ? Regex.Match(string_0, "(\\d\\d? .+ (\\d\\d\\d\\d|\\d\\d) \\d?\\d:\\d?\\d(:\\d?\\d)?)|((\\d\\d\\d\\d|\\d\\d)-\\d?\\d-\\d?\\d \\d?\\d:\\d?\\d(:\\d?\\d)?)|(\\d\\d?-[A-Za-z]{3}-(\\d\\d\\d\\d|\\d\\d) \\d?\\d:\\d?\\d(:\\d?\\d)?)") : throw new ArgumentNullException("dateInput");
    DateTime dateTime;
    if (match.Success)
    {
      dateTime = Convert.ToDateTime(match.Value, (IFormatProvider) CultureInfo.InvariantCulture);
    }
    else
    {
      DefaultLogger.Log.LogError("The given date does not appear to be in a valid format: " + string_0);
      dateTime = DateTime.MinValue;
    }
    return dateTime;
  }

  static bool smethod_53(
    buFile.Dxf dxf_0,
    double double_0,
    double double_1,
    double double_2,
    double double_3)
  {
    double num1 = Math.Abs(double_0 - double_1);
    double num2 = Math.Abs(double_2 - double_3);
    return num1 < dxf_0.double_2 & num2 < dxf_0.double_2;
  }

  static bool smethod_54([Out] buClipperBase buClipperBase_0, ref long long_0)
  {
    bool flag;
    if (buClipperBase_0.class24_0 == null)
    {
      long_0 = 0L;
      flag = false;
    }
    else
    {
      long_0 = buClipperBase_0.class24_0.long_0;
      buClipperBase_0.class24_0 = buClipperBase_0.class24_0.class24_0;
      flag = true;
    }
    return flag;
  }

  static double[,] smethod_55(Bitmap bitmap_0, FIP fip_0)
  {
    double[,] numArray = new double[bitmap_0.Width, bitmap_0.Height];
    for (int x = 0; x < bitmap_0.Width; ++x)
    {
      for (int y = 0; y < bitmap_0.Height; ++y)
        numArray[x, y] = Math.Pow(-1.0, (double) (x + y)) * Convert.ToDouble(bitmap_0.GetPixel(x, y).R);
    }
    return numArray;
  }

  static void smethod_56(
    ref double double_0,
    ref string string_0,
    ref double double_1,
    ref double double_2,
    int int_0,
    ref string string_1,
    ref double double_3,
    ref double double_4,
    buFile.Dxf dxf_0,
    ref double double_5,
    ref Color color_0)
  {
    bool flag1 = true;
    bool flag2 = false;
    for (int index = int_0; index <= dxf_0.list_0.Count - 1; ++index)
    {
      if (flag1 & dxf_0.list_0[index] == "AcDbEntity")
        string_0 = dxf_0.list_0[index + 2];
      if (flag1 & dxf_0.list_0[index] == "  8")
        string_0 = dxf_0.list_0[index + 1];
      if (flag1 & dxf_0.list_0[index] == "CONTINUOUS")
        flag2 = true;
      bool flag3 = true;
      if (flag1 & dxf_0.list_0[index] == "  2")
        string_1 = dxf_0.list_0[index + 1];
      if (flag1 & dxf_0.list_0[index] == " 62")
      {
        int int32 = Convert.ToInt32(dxf_0.list_0[index + 1]);
        color_0 = int32 >= dxf_0.ColorCode.Length ? Color.Black : dxf_0.ColorCode[int32];
        if (color_0.A == (byte) 0 & color_0.R == (byte) 0 & color_0.G == (byte) 0 & color_0.B == (byte) 0)
          color_0 = Color.Black;
      }
      if (flag3 & dxf_0.list_0[index] == " 10")
        double_1 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
      if (flag3 & dxf_0.list_0[index] == " 20")
        double_4 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
      if (flag3 & dxf_0.list_0[index] == " 30")
        double_3 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
      if (flag3 & dxf_0.list_0[index] == " 41")
        double_2 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
      if (flag3 & dxf_0.list_0[index] == " 42")
        double_0 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
      if (!(flag3 & dxf_0.list_0[index] == " 50"))
      {
        if (dxf_0.list_0[index] == "  0" || dxf_0.list_0[index] == "ENDSEC")
          break;
      }
      else
      {
        double_5 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
        break;
      }
    }
  }

  static double smethod_57(AdvancingFrontNode advancingFrontNode_0)
  {
    double x = advancingFrontNode_0.Point.X;
    double y = advancingFrontNode_0.Point.Y;
    double num1 = advancingFrontNode_0.Next.Point.X - x;
    double num2 = advancingFrontNode_0.Next.Point.Y - y;
    double num3 = advancingFrontNode_0.Prev.Point.X - x;
    double num4 = advancingFrontNode_0.Prev.Point.Y - y;
    return Math.Atan2(num1 * num4 - num2 * num3, num1 * num3 + num2 * num4);
  }

  static void smethod_58(Point2D point2D_0, double double_0)
  {
    point2D_0.X *= double_0;
    point2D_0.Y *= double_0;
  }

  static byte[] smethod_59(byte[] byte_0)
  {
    if (byte_0 == null)
      throw new ArgumentNullException("toHash");
    using (MD5 md5 = (MD5) new MD5CryptoServiceProvider())
      return md5.ComputeHash(byte_0);
  }

  static void smethod_60(buClipper buClipper_0)
  {
    for (int index = 0; index < buClipper_0.list_3.Count; ++index)
    {
      Class28 class28_0 = buClipper_0.list_3[index];
      Class26 class26_1 = Class30.smethod_272(buClipper_0, class28_0.class27_0.int_0);
      Class26 class26_2 = Class30.smethod_272(buClipper_0, class28_0.class27_1.int_0);
      if ((class26_1.class27_0 == null ? 1 : (class26_2.class27_0 == null ? 1 : 0)) == 0 && (class26_1.bool_1 ? 1 : (class26_2.bool_1 ? 1 : 0)) == 0)
      {
        Class26 class26_3 = class26_1 != class26_2 ? (!Class30.smethod_34(buClipper_0, class26_1, class26_2) ? (!Class30.smethod_34(buClipper_0, class26_2, class26_1) ? Class30.smethod_126(buClipper_0, class26_1, class26_2) : class26_1) : class26_2) : class26_1;
        if (Class30.smethod_293(buClipper_0, class28_0, class26_1, class26_2))
        {
          if (class26_1 == class26_2)
          {
            class26_1.class27_0 = class28_0.class27_0;
            class26_1.class27_1 = (Class27) null;
            Class26 class26_4 = Class30.smethod_185((buClipperBase) buClipper_0);
            class26_4.class27_0 = class28_0.class27_1;
            Class30.smethod_7(class26_4, buClipper_0);
            if (Class30.smethod_167(class26_4.class27_0, class26_1.class27_0))
            {
              class26_4.bool_0 = !class26_1.bool_0;
              class26_4.class26_0 = class26_1;
              if (buClipper_0.bool_4)
                buClipper_0.method_2(class26_4, class26_1);
              if ((class26_4.bool_0 ^ buClipper_0.ReverseSolution) == Class30.smethod_142(buClipper_0, class26_4) > 0.0)
                Class30.smethod_242(class26_4.class27_0, buClipper_0);
            }
            else if (Class30.smethod_167(class26_1.class27_0, class26_4.class27_0))
            {
              class26_4.bool_0 = class26_1.bool_0;
              class26_1.bool_0 = !class26_4.bool_0;
              class26_4.class26_0 = class26_1.class26_0;
              class26_1.class26_0 = class26_4;
              if (buClipper_0.bool_4)
                buClipper_0.method_2(class26_1, class26_4);
              if ((class26_1.bool_0 ^ buClipper_0.ReverseSolution) == Class30.smethod_142(buClipper_0, class26_1) > 0.0)
                Class30.smethod_242(class26_1.class27_0, buClipper_0);
            }
            else
            {
              class26_4.bool_0 = class26_1.bool_0;
              class26_4.class26_0 = class26_1.class26_0;
              if (buClipper_0.bool_4)
                buClipper_0.method_1(class26_1, class26_4);
            }
          }
          else
          {
            class26_2.class27_0 = (Class27) null;
            class26_2.class27_1 = (Class27) null;
            class26_2.int_0 = class26_1.int_0;
            class26_1.bool_0 = class26_3.bool_0;
            if (class26_3 == class26_2)
              class26_1.class26_0 = class26_2.class26_0;
            class26_2.class26_0 = class26_1;
            if (buClipper_0.bool_4)
              buClipper_0.method_3(class26_2, class26_1);
          }
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
      Class30.smethod_279(pop3Client_0);
    }
  }

  static void smethod_62(Pop3Client pop3Client_0, string string_0)
  {
    Match match = string_0 != null ? Regex.Match(string_0, "<.+>") : throw new ArgumentNullException("response");
    if (!match.Success)
      return;
    pop3Client_0.method_5(match.Value);
    pop3Client_0.ApopSupported = true;
  }

  static void smethod_63(
    ref bool bool_0,
    buFile.Ply ply_0,
    ref int int_0,
    ref int int_1,
    StreamReader streamReader_0)
  {
    string str1 = streamReader_0.ReadLine();
    int num1 = 0 + (str1.Length + 1);
    if (str1 != "ply")
      throw new ArgumentException("Magic number ('ply') mismatch.");
    string str2 = streamReader_0.ReadLine();
    int num2 = num1 + (str2.Length + 1);
    if (str2.IndexOf("binary") >= 0)
      bool_0 = true;
    bool flag = false;
label_14:
    do
    {
      string str3 = streamReader_0.ReadLine();
      num2 += str3.Length + 1;
      if (!(str3 == "end_header"))
      {
        string[] strArray = str3.Split();
        if (strArray[0] == "element")
        {
          if (strArray[1] == "vertex")
          {
            int_0 = Convert.ToInt32(strArray[2]);
            flag = false;
          }
          else
            flag = true;
        }
        if (strArray[0] == "element")
        {
          if (strArray[1] == "face")
          {
            int_1 = Convert.ToInt32(strArray[2]);
            flag = false;
          }
          else
            flag = true;
        }
      }
      else
        goto label_15;
    }
    while (!flag);
    goto label_14;
label_15:
    streamReader_0.BaseStream.Position = (long) num2;
  }

  static void smethod_64(string string_0, int int_0)
  {
    try
    {
      lock (Class32.object_0)
        Class32.dictionary_0.Add(int_0, string_0);
    }
    catch
    {
    }
  }

  static void smethod_65(
    TriangulationPoint triangulationPoint_0,
    DelaunayTriangle delaunayTriangle_0,
    DelaunayTriangle delaunayTriangle_1,
    TriangulationPoint triangulationPoint_1)
  {
    DelaunayTriangle t1 = delaunayTriangle_1.NeighborCCWFrom(triangulationPoint_1);
    DelaunayTriangle t2 = delaunayTriangle_1.NeighborCWFrom(triangulationPoint_1);
    DelaunayTriangle t3 = delaunayTriangle_0.NeighborCCWFrom(triangulationPoint_0);
    DelaunayTriangle t4 = delaunayTriangle_0.NeighborCWFrom(triangulationPoint_0);
    bool constrainedEdgeCcw1 = delaunayTriangle_1.GetConstrainedEdgeCCW(triangulationPoint_1);
    bool constrainedEdgeCw1 = delaunayTriangle_1.GetConstrainedEdgeCW(triangulationPoint_1);
    bool constrainedEdgeCcw2 = delaunayTriangle_0.GetConstrainedEdgeCCW(triangulationPoint_0);
    bool constrainedEdgeCw2 = delaunayTriangle_0.GetConstrainedEdgeCW(triangulationPoint_0);
    bool delaunayEdgeCcw1 = delaunayTriangle_1.GetDelaunayEdgeCCW(triangulationPoint_1);
    bool delaunayEdgeCw1 = delaunayTriangle_1.GetDelaunayEdgeCW(triangulationPoint_1);
    bool delaunayEdgeCcw2 = delaunayTriangle_0.GetDelaunayEdgeCCW(triangulationPoint_0);
    bool delaunayEdgeCw2 = delaunayTriangle_0.GetDelaunayEdgeCW(triangulationPoint_0);
    delaunayTriangle_1.Legalize(triangulationPoint_1, triangulationPoint_0);
    delaunayTriangle_0.Legalize(triangulationPoint_0, triangulationPoint_1);
    delaunayTriangle_0.SetDelaunayEdgeCCW(triangulationPoint_1, delaunayEdgeCcw1);
    delaunayTriangle_1.SetDelaunayEdgeCW(triangulationPoint_1, delaunayEdgeCw1);
    delaunayTriangle_1.SetDelaunayEdgeCCW(triangulationPoint_0, delaunayEdgeCcw2);
    delaunayTriangle_0.SetDelaunayEdgeCW(triangulationPoint_0, delaunayEdgeCw2);
    delaunayTriangle_0.SetConstrainedEdgeCCW(triangulationPoint_1, constrainedEdgeCcw1);
    delaunayTriangle_1.SetConstrainedEdgeCW(triangulationPoint_1, constrainedEdgeCw1);
    delaunayTriangle_1.SetConstrainedEdgeCCW(triangulationPoint_0, constrainedEdgeCcw2);
    delaunayTriangle_0.SetConstrainedEdgeCW(triangulationPoint_0, constrainedEdgeCw2);
    delaunayTriangle_1.Neighbors.Clear();
    delaunayTriangle_0.Neighbors.Clear();
    if (t1 != null)
      delaunayTriangle_0.MarkNeighbor(t1);
    if (t2 != null)
      delaunayTriangle_1.MarkNeighbor(t2);
    if (t3 != null)
      delaunayTriangle_1.MarkNeighbor(t3);
    if (t4 != null)
      delaunayTriangle_0.MarkNeighbor(t4);
    delaunayTriangle_1.MarkNeighbor(delaunayTriangle_0);
  }

  static bool smethod_66(
    Class27 class27_0,
    Class27 class27_1,
    buClipper buClipper_0,
    Class27 class27_2,
    IntPoint intPoint_0,
    bool bool_0,
    Class27 class27_3)
  {
    Enum3 enum3_1 = class27_1.intPoint_0.X > class27_2.intPoint_0.X ? Enum3.const_0 : Enum3.const_1;
    Enum3 enum3_2 = class27_0.intPoint_0.X > class27_3.intPoint_0.X ? Enum3.const_0 : Enum3.const_1;
    bool flag;
    if (enum3_1 == enum3_2)
    {
      flag = false;
    }
    else
    {
      if (enum3_1 == Enum3.const_1)
      {
        while ((class27_1.class27_0.intPoint_0.X > intPoint_0.X || class27_1.class27_0.intPoint_0.X < class27_1.intPoint_0.X ? 0 : (class27_1.class27_0.intPoint_0.Y == intPoint_0.Y ? 1 : 0)) != 0)
          class27_1 = class27_1.class27_0;
        if ((!bool_0 ? 0 : (class27_1.intPoint_0.X != intPoint_0.X ? 1 : 0)) != 0)
          class27_1 = class27_1.class27_0;
        class27_2 = Class30.smethod_139(buClipper_0, class27_1, !bool_0);
        if (class27_2.intPoint_0 != intPoint_0)
        {
          class27_1 = class27_2;
          class27_1.intPoint_0 = intPoint_0;
          class27_2 = Class30.smethod_139(buClipper_0, class27_1, !bool_0);
        }
      }
      else
      {
        while ((class27_1.class27_0.intPoint_0.X < intPoint_0.X || class27_1.class27_0.intPoint_0.X > class27_1.intPoint_0.X ? 0 : (class27_1.class27_0.intPoint_0.Y == intPoint_0.Y ? 1 : 0)) != 0)
          class27_1 = class27_1.class27_0;
        if ((bool_0 ? 0 : (class27_1.intPoint_0.X != intPoint_0.X ? 1 : 0)) != 0)
          class27_1 = class27_1.class27_0;
        class27_2 = Class30.smethod_139(buClipper_0, class27_1, bool_0);
        if (class27_2.intPoint_0 != intPoint_0)
        {
          class27_1 = class27_2;
          class27_1.intPoint_0 = intPoint_0;
          class27_2 = Class30.smethod_139(buClipper_0, class27_1, bool_0);
        }
      }
      if (enum3_2 == Enum3.const_1)
      {
        while ((class27_0.class27_0.intPoint_0.X > intPoint_0.X || class27_0.class27_0.intPoint_0.X < class27_0.intPoint_0.X ? 0 : (class27_0.class27_0.intPoint_0.Y == intPoint_0.Y ? 1 : 0)) != 0)
          class27_0 = class27_0.class27_0;
        if ((!bool_0 ? 0 : (class27_0.intPoint_0.X != intPoint_0.X ? 1 : 0)) != 0)
          class27_0 = class27_0.class27_0;
        class27_3 = Class30.smethod_139(buClipper_0, class27_0, !bool_0);
        if (class27_3.intPoint_0 != intPoint_0)
        {
          class27_0 = class27_3;
          class27_0.intPoint_0 = intPoint_0;
          class27_3 = Class30.smethod_139(buClipper_0, class27_0, !bool_0);
        }
      }
      else
      {
        while ((class27_0.class27_0.intPoint_0.X < intPoint_0.X || class27_0.class27_0.intPoint_0.X > class27_0.intPoint_0.X ? 0 : (class27_0.class27_0.intPoint_0.Y == intPoint_0.Y ? 1 : 0)) != 0)
          class27_0 = class27_0.class27_0;
        if ((bool_0 ? 0 : (class27_0.intPoint_0.X != intPoint_0.X ? 1 : 0)) != 0)
          class27_0 = class27_0.class27_0;
        class27_3 = Class30.smethod_139(buClipper_0, class27_0, bool_0);
        if (class27_3.intPoint_0 != intPoint_0)
        {
          class27_0 = class27_3;
          class27_0.intPoint_0 = intPoint_0;
          class27_3 = Class30.smethod_139(buClipper_0, class27_0, bool_0);
        }
      }
      if (enum3_1 == Enum3.const_1 == bool_0)
      {
        class27_1.class27_1 = class27_0;
        class27_0.class27_0 = class27_1;
        class27_2.class27_0 = class27_3;
        class27_3.class27_1 = class27_2;
      }
      else
      {
        class27_1.class27_0 = class27_0;
        class27_0.class27_1 = class27_1;
        class27_2.class27_1 = class27_3;
        class27_3.class27_0 = class27_2;
      }
      flag = true;
    }
    return flag;
  }

  static bool smethod_67(Class22 class22_0) => class22_0.intPoint_3.Y == 0L;

  static void smethod_68(Pop3Client pop3Client_0, string string_0, string string_1)
  {
    if (!pop3Client_0.ApopSupported)
      throw new NotSupportedException("APOP is not supported on this server");
    Class30.smethod_144(pop3Client_0, $"APOP {string_0} {Class30.smethod_84(pop3Client_0.method_4(), string_1)}");
  }

  static bool smethod_69(string string_0)
  {
    if (string_0 == null)
      throw new ArgumentNullException("lineReceived");
    return string_0.Length == 1 && Class30.smethod_225(Encoding.ASCII.GetBytes(string_0));
  }

  static bool smethod_70(
    ref double double_0,
    ref double double_1,
    ref string string_0,
    ref string string_1,
    ref Color color_0,
    ref double double_2,
    ref double double_3,
    buFile.Dxf dxf_0,
    ref double double_4,
    int int_0)
  {
    bool flag1 = true;
    bool flag2 = false;
    bool flag3 = false;
    bool flag4 = false;
    int num = 0;
    bool flag5;
    for (int index = int_0; index <= dxf_0.list_0.Count - 1; ++index)
    {
      if (num < 80 /*0x50*/)
      {
        ++num;
        if (flag1 & dxf_0.list_0[index] == "AcDbEntity")
          string_1 = dxf_0.list_0[index + 2];
        if (flag1 & dxf_0.list_0[index] == "  8")
          string_1 = dxf_0.list_0[index + 1];
        if (flag1 & dxf_0.list_0[index] == " 62")
        {
          int int32 = Convert.ToInt32(dxf_0.list_0[index + 1]);
          if (int32 != 1)
            ;
          color_0 = int32 >= dxf_0.ColorCode.Length ? Color.Black : dxf_0.ColorCode[int32];
          if (color_0.A == (byte) 0 & color_0.R == (byte) 0 & color_0.G == (byte) 0 & color_0.B == (byte) 0)
            color_0 = Color.Black;
        }
        if (dxf_0.list_0[index] == " 10")
        {
          double_1 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
          flag3 = true;
        }
        if (dxf_0.list_0[index] == " 20")
        {
          double_0 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
          flag4 = true;
        }
        if (dxf_0.list_0[index] == " 30")
          double_3 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
        if (dxf_0.list_0[index] == " 39")
        {
          string_0 += "39";
          double_4 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
        }
        if (dxf_0.list_0[index] == " 50")
        {
          string_0 += "50";
          double_2 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
        }
        if ((dxf_0.list_0[index] == "  0" | dxf_0.list_0[index] == "0") & flag3 & flag4)
        {
          flag5 = true;
          goto label_26;
        }
      }
      else
      {
        flag2 = false;
        break;
      }
    }
    flag5 = flag2;
label_26:
    return flag5;
  }

  static string smethod_71(int int_0)
  {
    lock (Class32.object_0)
    {
      string str;
      Class32.dictionary_0.TryGetValue(int_0, out str);
      if (str != null)
        return str;
    }
    return Class30.smethod_174(int_0);
  }

  static string smethod_72(string string_0, string string_1)
  {
    if (string_1 == null)
      throw new ArgumentNullException("valueToDecode");
    if (string_0 == null)
      throw new ArgumentNullException("encoding");
    string_1 = $"=?{string_0}?Q?{string_1.Replace("%", "=")}?=";
    return Class30.smethod_179(string_1);
  }

  static DelaunayTriangle smethod_73(
    TriangulationPoint triangulationPoint_0,
    Orientation orientation_0,
    DTSweepContext dtsweepContext_0,
    DelaunayTriangle delaunayTriangle_0,
    DelaunayTriangle delaunayTriangle_1,
    TriangulationPoint triangulationPoint_1)
  {
    DelaunayTriangle delaunayTriangle;
    if (orientation_0 == Orientation.AntiClockwise)
    {
      int index = delaunayTriangle_1.EdgeIndex(triangulationPoint_1, triangulationPoint_0);
      delaunayTriangle_1.EdgeIsDelaunay[index] = true;
      Class30.smethod_226(dtsweepContext_0, delaunayTriangle_1);
      delaunayTriangle_1.EdgeIsDelaunay.Clear();
      delaunayTriangle = delaunayTriangle_0;
    }
    else
    {
      int index = delaunayTriangle_0.EdgeIndex(triangulationPoint_1, triangulationPoint_0);
      delaunayTriangle_0.EdgeIsDelaunay[index] = true;
      Class30.smethod_226(dtsweepContext_0, delaunayTriangle_0);
      delaunayTriangle_0.EdgeIsDelaunay.Clear();
      delaunayTriangle = delaunayTriangle_1;
    }
    return delaunayTriangle;
  }

  static void smethod_74(PolyType polyType_0, Class22 class22_0, buClipperBase buClipperBase_0)
  {
    if (class22_0.intPoint_1.Y >= class22_0.class22_0.intPoint_1.Y)
    {
      class22_0.intPoint_0 = class22_0.intPoint_1;
      class22_0.intPoint_2 = class22_0.class22_0.intPoint_1;
    }
    else
    {
      class22_0.intPoint_2 = class22_0.intPoint_1;
      class22_0.intPoint_0 = class22_0.class22_0.intPoint_1;
    }
    Class30.smethod_260(buClipperBase_0, class22_0);
    class22_0.polyType_0 = polyType_0;
  }

  static TriangulationContext smethod_75(TriangulationAlgorithm triangulationAlgorithm_0)
  {
    return (TriangulationContext) new DTSweepContext();
  }

  static string smethod_76(string string_0) => string_0.Trim().TrimEnd('>').TrimStart('<');

  static PolyNode smethod_77(PolyNode polyNode_0)
  {
    return polyNode_0.polyNode_0 != null ? (polyNode_0.int_0 != polyNode_0.polyNode_0.list_1.Count - 1 ? polyNode_0.polyNode_0.list_1[polyNode_0.int_0 + 1] : Class30.smethod_77(polyNode_0.polyNode_0)) : (PolyNode) null;
  }

  static void smethod_78(
    TriangulationConstraint triangulationConstraint_0,
    AdvancingFrontNode advancingFrontNode_0,
    DTSweepContext dtsweepContext_0)
  {
    if (TriangulationUtil.Orient2d((Point2D) advancingFrontNode_0.Prev.Point, (Point2D) advancingFrontNode_0.Prev.Prev.Point, (Point2D) advancingFrontNode_0.Prev.Prev.Prev.Point) == Orientation.Clockwise)
    {
      Class30.smethod_112(triangulationConstraint_0, advancingFrontNode_0.Prev, dtsweepContext_0);
    }
    else
    {
      if (TriangulationUtil.Orient2d((Point2D) triangulationConstraint_0.Q, (Point2D) advancingFrontNode_0.Prev.Prev.Point, (Point2D) triangulationConstraint_0.P) != Orientation.Clockwise)
        return;
      Class30.smethod_78(triangulationConstraint_0, advancingFrontNode_0.Prev, dtsweepContext_0);
    }
  }

  static bool smethod_79(
    ref double double_0,
    ref double double_1,
    buFile.Dxf dxf_0,
    ref double double_2,
    ref Color color_0,
    int int_0,
    ref string string_0,
    ref double double_3,
    ref double double_4,
    ref double double_5)
  {
    bool flag1 = true;
    bool flag2 = true;
    bool flag3 = false;
    int num = 0;
    for (int index = int_0; index <= dxf_0.list_0.Count - 1; ++index)
    {
      if (num < 80 /*0x50*/)
      {
        ++num;
        if (flag1 & dxf_0.list_0[index] == "AcDbEntity")
          string_0 = dxf_0.list_0[index + 2];
        if (flag1 & dxf_0.list_0[index] == "  8")
          string_0 = dxf_0.list_0[index + 1];
        if (flag1 & dxf_0.list_0[index] == "AcDbLine")
          flag2 = true;
        if (flag1 & dxf_0.list_0[index] == "CONTINUOUS")
          flag2 = true;
        if (flag1 & dxf_0.list_0[index] == " 62")
        {
          int int32 = Convert.ToInt32(dxf_0.list_0[index + 1]);
          color_0 = int32 >= dxf_0.ColorCode.Length ? Color.Black : dxf_0.ColorCode[int32];
          if (color_0.A == (byte) 0 & color_0.R == (byte) 0 & color_0.G == (byte) 0 & color_0.B == (byte) 0)
            color_0 = Color.Black;
        }
        if (flag2 & dxf_0.list_0[index] == " 10")
          double_4 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
        if (flag2 & dxf_0.list_0[index] == " 20")
          double_1 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
        if (flag2 & dxf_0.list_0[index] == " 30")
          double_0 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
        if (flag2 & dxf_0.list_0[index] == " 11")
          double_3 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
        if (flag2 & dxf_0.list_0[index] == " 21")
        {
          double_5 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
          if (dxf_0.list_0[index + 2] != " 31")
          {
            flag3 = true;
            break;
          }
        }
        if (flag2 & dxf_0.list_0[index] == " 31")
        {
          double_2 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
          flag3 = true;
          break;
        }
      }
      else
      {
        flag3 = false;
        break;
      }
    }
    return flag3;
  }

  static void smethod_80(Class34.Class37 class37_0, int int_0, int int_1)
  {
    while (int_1-- > 0)
    {
      byte[] byte0 = class37_0.byte_0;
      Class34.Class37 class37 = class37_0;
      int int0 = class37_0.int_0;
      int num1 = int0 + 1;
      class37.int_0 = num1;
      int index = int0;
      int num2 = (int) class37_0.byte_0[int_0++];
      byte0[index] = (byte) num2;
      class37_0.int_0 &= (int) short.MaxValue;
      int_0 &= (int) short.MaxValue;
    }
  }

  static bool smethod_81(buClipper buClipper_0, Class22 class22_0)
  {
    return class22_0.polyType_0 != PolyType.ptSubject ? buClipper_0.polyFillType_1 == PolyFillType.pftEvenOdd : buClipper_0.polyFillType_0 == PolyFillType.pftEvenOdd;
  }

  static void smethod_82(
    ref List<double> list_0,
    ref List<int> list_1,
    buFile.Dxf dxf_0,
    ref List<double> list_2,
    ref List<double> list_3,
    ref List<int> list_4,
    ref List<double> list_5,
    ref List<double> list_6,
    ref List<double> list_7,
    ref List<string> list_8,
    int int_0,
    ref List<double> list_9,
    ref List<double> list_10,
    ref List<double> list_11)
  {
    int num1 = 0;
    int num2 = 0;
    bool flag1 = false;
    bool flag2 = false;
    bool flag3 = false;
    double double_3 = 0.0;
    double double_2 = 0.0;
    List<double> doubleList1 = new List<double>();
    List<double> doubleList2 = new List<double>();
    List<double> doubleList3 = new List<double>();
    List<int> intList = new List<int>();
    string str = "";
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
    for (int index1 = int_0; index1 <= dxf_0.list_0.Count - 1; ++index1)
    {
      if (dxf_0.list_0[index1] == "POLYLINE")
      {
        num1 = index1;
        flag1 = true;
      }
      if (dxf_0.list_0[index1] == "SEQEND" & flag1)
      {
        int num3 = index1;
        flag1 = false;
        bool flag4 = false;
        doubleList1.Clear();
        doubleList2.Clear();
        intList.Clear();
        doubleList3.Clear();
        for (int index2 = num1; index2 <= num3; ++index2)
        {
          if (dxf_0.list_0[index2] == "VERTEX")
            flag2 = true;
          if (dxf_0.list_0[index2] == "  8" & !flag3)
          {
            str = dxf_0.list_0[index2 + 1];
            flag3 = true;
          }
          if (!(dxf_0.list_0[index2] == "  6"))
            ;
          if (!flag2 & dxf_0.list_0[index2].Trim() == "70" && Convert.ToInt32(dxf_0.list_0[index2 + 1]) == 1 | Convert.ToInt32(dxf_0.list_0[index2 + 1]) == 129)
            flag4 = true;
          if (flag2 & dxf_0.list_0[index2].Trim() == "10")
          {
            ++num2;
            doubleList1.Add(Class30.smethod_256(dxf_0, dxf_0.list_0[index2 + 1]));
            doubleList2.Add(Class30.smethod_256(dxf_0, dxf_0.list_0[index2 + 3]));
            int num4 = !(dxf_0.list_0[index2 + 4].Trim() == "30") ? 4 : 6;
            if (dxf_0.list_0[index2 + num4].Trim() == "42")
            {
              doubleList3.Add(Class30.smethod_256(dxf_0, dxf_0.list_0[index2 + num4 + 1]));
              intList.Add(3);
            }
            else
            {
              doubleList3.Add(0.0);
              intList.Add(1);
            }
          }
        }
        int num5 = num2;
        if (num2 >= num5)
        {
          if (doubleList1.Count == 1 & doubleList2.Count == 1 && intList[0] == 1)
          {
            list_5.Add(doubleList1[0]);
            list_0.Add(doubleList2[0]);
            list_1.Add(0);
            list_8.Add(str);
            list_4.Add(10);
            list_2.Add(0.0);
            list_10.Add(0.0);
            list_11.Add(0.0);
            list_9.Add(0.0);
            list_6.Add(0.0);
          }
          for (int index3 = 0; index3 <= doubleList1.Count - 2; ++index3)
          {
            if (intList[index3] == 1)
            {
              list_5.Add(doubleList1[index3]);
              list_0.Add(doubleList2[index3]);
              list_3.Add(doubleList1[index3 + 1]);
              list_7.Add(doubleList2[index3 + 1]);
              list_1.Add(0);
              list_8.Add(str);
              list_4.Add(1);
              list_2.Add(0.0);
              list_10.Add(0.0);
              list_11.Add(0.0);
              list_9.Add(0.0);
              list_6.Add(0.0);
            }
            if (intList[index3] == 3)
            {
              double num6 = Math.Abs(Class30.smethod_193(Math.Atan(Math.Abs(doubleList3[index3])), dxf_0) * 4.0);
              double double_0_1 = Math.Abs(Class30.smethod_193(Math.Atan(Math.Abs(doubleList3[index3])), dxf_0) * 4.0);
              if (Math.Abs(num6) > 180.0)
                num6 = 360.0 - Math.Abs(num6);
              double num7 = Math.Sqrt(Math.Pow(doubleList1[index3] - doubleList1[index3 + 1], 2.0) + Math.Pow(doubleList2[index3] - doubleList2[index3 + 1], 2.0));
              double x = num7 / Math.Tan(Class30.smethod_204(dxf_0, num6 / 2.0)) / 2.0;
              double double_6 = !(double_0_1 < 180.0 | Class30.smethod_255(dxf_0, double_0_1, 180.0)) ? Math.Sqrt(Math.Pow(x, 2.0) + Math.Pow(num7 / 2.0, 2.0)) * -1.0 : Math.Sqrt(Math.Pow(x, 2.0) + Math.Pow(num7 / 2.0, 2.0));
              if (doubleList3[index3] < 0.0)
              {
                double double_1 = doubleList1[index3];
                double double_4 = doubleList2[index3];
                double double_0_2 = doubleList1[index3 + 1];
                double double_5 = doubleList2[index3 + 1];
                Class30.smethod_140(double_0_2, double_1, ref double_2, ref double_3, (short) 2, double_4, dxf_0, double_5, double_6);
              }
              else
              {
                double double_1 = doubleList1[index3];
                double double_4 = doubleList2[index3];
                double double_0_3 = doubleList1[index3 + 1];
                double double_5 = doubleList2[index3 + 1];
                Class30.smethod_140(double_0_3, double_1, ref double_2, ref double_3, (short) 3, double_4, dxf_0, double_5, double_6);
              }
              double num8 = double_6;
              double double_0_4 = Class30.smethod_149(dxf_0, doubleList1[index3], doubleList2[index3], double_3, double_2);
              double double_0_5 = Class30.smethod_149(dxf_0, doubleList1[index3 + 1], doubleList2[index3 + 1], double_3, double_2);
              if (doubleList3[index3] < 0.0)
              {
                if (Class30.smethod_255(dxf_0, double_0_1, Math.Abs(double_0_4 - double_0_5)))
                {
                  double num9 = double_0_4;
                  double_0_4 = double_0_5;
                  double_0_5 = num9;
                }
                if (!Class30.smethod_255(dxf_0, double_0_1, Math.Abs(double_0_4 - double_0_5)))
                {
                  double num10 = double_0_4;
                  double_0_4 = double_0_5;
                  double_0_5 = num10 + 360.0;
                }
              }
              if (doubleList3[index3] > 0.0)
              {
                if (!Class30.smethod_255(dxf_0, double_0_1, Math.Abs(double_0_4 - double_0_5)))
                  ;
                if (!Class30.smethod_255(dxf_0, double_0_1, Math.Abs(double_0_4 - double_0_5)))
                  double_0_5 += 360.0;
              }
              if (doubleList3[index3] == -1.0 & Class30.smethod_255(dxf_0, double_0_5, 0.0))
              {
                double_0_4 = 180.0;
                double_0_5 = 360.0;
              }
              if (doubleList3[index3] == -1.0 & Class30.smethod_255(dxf_0, double_0_4, 0.0))
              {
                double_0_4 = 0.0;
                double_0_5 = 180.0;
              }
              if (doubleList3[index3] == 1.0 & Class30.smethod_255(dxf_0, double_0_5, 0.0))
              {
                double_0_4 = 0.0;
                double_0_5 = 180.0;
              }
              if (doubleList3[index3] == 1.0 & Class30.smethod_255(dxf_0, double_0_4, 0.0))
              {
                double_0_4 = 180.0;
                double_0_5 = 360.0;
              }
              if (Math.Abs(double_0_4 - double_0_5) > 360.0)
                double_0_5 -= 360.0;
              list_2.Add(double_3);
              list_10.Add(double_2);
              list_11.Add(Math.Abs(num8));
              list_9.Add(double_0_4);
              list_6.Add(double_0_5);
              list_4.Add(3);
              list_1.Add(0);
              list_8.Add(str);
              list_5.Add(0.0);
              list_0.Add(0.0);
              list_3.Add(0.0);
              list_7.Add(0.0);
            }
          }
          if (flag4)
          {
            if (intList[doubleList1.Count - 1] == 1 && !Class30.smethod_255(dxf_0, doubleList1[doubleList1.Count - 1], doubleList1[0]) | !Class30.smethod_255(dxf_0, doubleList2[doubleList2.Count - 1], doubleList2[0]))
            {
              list_2.Add(0.0);
              list_10.Add(0.0);
              list_11.Add(0.0);
              list_9.Add(0.0);
              list_6.Add(0.0);
              list_4.Add(1);
              list_1.Add(0);
              list_8.Add(str);
              list_5.Add(doubleList1[doubleList1.Count - 1]);
              list_0.Add(doubleList2[doubleList1.Count - 1]);
              list_3.Add(doubleList1[0]);
              list_7.Add(doubleList2[0]);
            }
            if (intList[doubleList1.Count - 1] == 3)
            {
              double num11 = Math.Abs(Class30.smethod_193(Math.Atan(Math.Abs(doubleList3[doubleList1.Count - 1])), dxf_0) * 4.0);
              double double_0_6 = Math.Abs(Class30.smethod_193(Math.Atan(Math.Abs(doubleList3[doubleList1.Count - 1])), dxf_0) * 4.0);
              if (Math.Abs(num11) > 180.0)
                num11 = 360.0 - Math.Abs(num11);
              double num12 = Math.Sqrt(Math.Pow(doubleList1[doubleList1.Count - 1] - doubleList1[0], 2.0) + Math.Pow(doubleList2[doubleList1.Count - 1] - doubleList2[0], 2.0));
              double x = num12 / Math.Tan(Class30.smethod_204(dxf_0, num11 / 2.0)) / 2.0;
              double double_6 = !(double_0_6 < 180.0 | Class30.smethod_255(dxf_0, double_0_6, 180.0)) ? Math.Sqrt(Math.Pow(x, 2.0) + Math.Pow(num12 / 2.0, 2.0)) * -1.0 : Math.Sqrt(Math.Pow(x, 2.0) + Math.Pow(num12 / 2.0, 2.0));
              if (doubleList3[doubleList1.Count - 1] < 0.0)
              {
                double double_1 = doubleList1[doubleList1.Count - 1];
                double double_4 = doubleList2[doubleList1.Count - 1];
                double double_0_7 = doubleList1[0];
                double double_5 = doubleList2[0];
                Class30.smethod_140(double_0_7, double_1, ref double_2, ref double_3, (short) 2, double_4, dxf_0, double_5, double_6);
              }
              else
              {
                double double_1 = doubleList1[doubleList1.Count - 1];
                double double_4 = doubleList2[doubleList1.Count - 1];
                double double_0_8 = doubleList1[0];
                double double_5 = doubleList2[0];
                Class30.smethod_140(double_0_8, double_1, ref double_2, ref double_3, (short) 3, double_4, dxf_0, double_5, double_6);
              }
              double num13 = double_6;
              double double_0_9 = Class30.smethod_149(dxf_0, doubleList1[doubleList1.Count - 1], doubleList2[doubleList1.Count - 1], double_3, double_2);
              double double_0_10 = Class30.smethod_149(dxf_0, doubleList1[0], doubleList2[0], double_3, double_2);
              if (doubleList3[doubleList1.Count - 1] < 0.0)
              {
                if (Class30.smethod_255(dxf_0, double_0_6, Math.Abs(double_0_9 - double_0_10)))
                {
                  double num14 = double_0_9;
                  double_0_9 = double_0_10;
                  double_0_10 = num14;
                }
                if (!Class30.smethod_255(dxf_0, double_0_6, Math.Abs(double_0_9 - double_0_10)))
                {
                  double num15 = double_0_9;
                  double_0_9 = double_0_10;
                  double_0_10 = num15 + 360.0;
                }
              }
              if (doubleList3[doubleList1.Count - 1] > 0.0)
              {
                if (!Class30.smethod_255(dxf_0, double_0_6, Math.Abs(double_0_9 - double_0_10)))
                  ;
                if (!Class30.smethod_255(dxf_0, double_0_6, Math.Abs(double_0_9 - double_0_10)))
                  double_0_10 += 360.0;
              }
              if (doubleList3[doubleList1.Count - 1] == -1.0 & Class30.smethod_255(dxf_0, double_0_10, 0.0))
              {
                double_0_9 = 180.0;
                double_0_10 = 360.0;
              }
              if (doubleList3[doubleList1.Count - 1] == -1.0 & Class30.smethod_255(dxf_0, double_0_9, 0.0))
              {
                double_0_9 = 0.0;
                double_0_10 = 180.0;
              }
              if (doubleList3[doubleList1.Count - 1] == 1.0 & Class30.smethod_255(dxf_0, double_0_10, 0.0))
              {
                double_0_9 = 0.0;
                double_0_10 = 180.0;
              }
              if (doubleList3[doubleList1.Count - 1] == 1.0 & Class30.smethod_255(dxf_0, double_0_9, 0.0))
              {
                double_0_9 = 180.0;
                double_0_10 = 360.0;
              }
              if (Math.Abs(double_0_9 - double_0_10) > 360.0)
                double_0_10 -= 360.0;
              list_2.Add(double_3);
              list_10.Add(double_2);
              list_11.Add(num13);
              list_9.Add(double_0_9);
              list_6.Add(double_0_10);
              list_4.Add(3);
              list_1.Add(0);
              list_8.Add(str);
              list_5.Add(0.0);
              list_0.Add(0.0);
              list_3.Add(0.0);
              list_7.Add(0.0);
            }
          }
          break;
        }
      }
    }
  }

  static bool smethod_83(Class34.Class39 class39_0, Class34.Class36 class36_0)
  {
    while (true)
    {
      switch (class39_0.int_2)
      {
        case 0:
          class39_0.int_3 = Class30.smethod_292(class36_0, 5);
          if (class39_0.int_3 >= 0)
          {
            class39_0.int_3 += 257;
            Class30.smethod_94(class36_0, 5);
            class39_0.int_2 = 1;
            goto case 1;
          }
          goto label_23;
        case 1:
          class39_0.int_4 = Class30.smethod_292(class36_0, 5);
          if (class39_0.int_4 >= 0)
          {
            ++class39_0.int_4;
            Class30.smethod_94(class36_0, 5);
            class39_0.int_6 = class39_0.int_3 + class39_0.int_4;
            class39_0.byte_1 = new byte[class39_0.int_6];
            class39_0.int_2 = 2;
            goto case 2;
          }
          goto label_24;
        case 2:
          class39_0.int_5 = Class30.smethod_292(class36_0, 4);
          if (class39_0.int_5 >= 0)
          {
            class39_0.int_5 += 4;
            Class30.smethod_94(class36_0, 4);
            class39_0.byte_0 = new byte[19];
            class39_0.int_8 = 0;
            class39_0.int_2 = 3;
            goto case 3;
          }
          goto label_25;
        case 3:
          for (; class39_0.int_8 < class39_0.int_5; ++class39_0.int_8)
          {
            int num = Class30.smethod_292(class36_0, 3);
            if (num < 0)
              return false;
            Class30.smethod_94(class36_0, 3);
            class39_0.byte_0[Class34.Class39.int_9[class39_0.int_8]] = (byte) num;
          }
          class39_0.class38_0 = new Class34.Class38(class39_0.byte_0);
          class39_0.byte_0 = (byte[]) null;
          class39_0.int_8 = 0;
          class39_0.int_2 = 4;
          goto case 4;
        case 4:
          int num1;
          while (((num1 = Class30.smethod_266(class39_0.class38_0, class36_0)) & -16) == 0)
          {
            byte[] byte1 = class39_0.byte_1;
            Class34.Class39 class39 = class39_0;
            int int8 = class39_0.int_8;
            int num2 = int8 + 1;
            class39.int_8 = num2;
            int index = int8;
            int num3 = (int) (class39_0.byte_2 = (byte) num1);
            byte1[index] = (byte) num3;
            if (class39_0.int_8 == class39_0.int_6)
              return true;
          }
          if (num1 >= 0)
          {
            if (num1 >= 17)
              class39_0.byte_2 = (byte) 0;
            class39_0.int_7 = num1 - 16 /*0x10*/;
            class39_0.int_2 = 5;
            goto case 5;
          }
          goto label_27;
        case 5:
          int int_0 = Class34.Class39.int_1[class39_0.int_7];
          int num4 = Class30.smethod_292(class36_0, int_0);
          if (num4 >= 0)
          {
            Class30.smethod_94(class36_0, int_0);
            int num5 = num4 + Class34.Class39.int_0[class39_0.int_7];
            while (num5-- > 0)
            {
              byte[] byte1 = class39_0.byte_1;
              Class34.Class39 class39 = class39_0;
              int int8 = class39_0.int_8;
              int num6 = int8 + 1;
              class39.int_8 = num6;
              int index = int8;
              int byte2 = (int) class39_0.byte_2;
              byte1[index] = (byte) byte2;
            }
            if (class39_0.int_8 != class39_0.int_6)
            {
              class39_0.int_2 = 4;
              continue;
            }
            goto label_29;
          }
          goto label_30;
        default:
          continue;
      }
    }
label_23:
    return false;
label_24:
    return false;
label_25:
    return false;
label_27:
    return false;
label_29:
    return true;
label_30:
    return false;
  }

  static string smethod_84(string string_0, string string_1)
  {
    if (string_1 == null)
      throw new ArgumentNullException("password");
    if (string_0 == null)
      throw new ArgumentNullException("serverTimestamp");
    byte[] bytes = Encoding.ASCII.GetBytes(string_0 + string_1);
    using (MD5 md5 = (MD5) new MD5CryptoServiceProvider())
      return BitConverter.ToString(md5.ComputeHash(bytes)).Replace("-", "").ToLowerInvariant();
  }

  static bool smethod_85(buClipper buClipper_0, IntersectNode intersectNode_0)
  {
    return intersectNode_0.class22_0.class22_5 == intersectNode_0.class22_1 || intersectNode_0.class22_0.class22_6 == intersectNode_0.class22_1;
  }

  static byte[] smethod_86(string string_0)
  {
    byte[] buffer = string_0 != null ? Encoding.ASCII.GetBytes(string_0) : throw new ArgumentNullException("password");
    if (buffer.Length > 64 /*0x40*/)
      buffer = new MD5CryptoServiceProvider().ComputeHash(buffer);
    byte[] numArray1;
    if (buffer.Length != 64 /*0x40*/)
    {
      byte[] numArray2 = new byte[64 /*0x40*/];
      for (int index = 0; index < buffer.Length; ++index)
        numArray2[index] = buffer[index];
      numArray1 = numArray2;
    }
    else
      numArray1 = buffer;
    return numArray1;
  }

  static byte[] smethod_87(string string_0)
  {
    try
    {
      using (MemoryStream memoryStream = new MemoryStream())
      {
        string_0 = string_0.Replace("\r\n", "");
        byte[] bytes = Encoding.ASCII.GetBytes(string_0);
        using (FromBase64Transform fromBase64Transform = new FromBase64Transform(FromBase64TransformMode.DoNotIgnoreWhiteSpaces))
        {
          byte[] numArray = new byte[fromBase64Transform.OutputBlockSize];
          int inputOffset = 0;
          while (bytes.Length - inputOffset > 4)
          {
            fromBase64Transform.TransformBlock(bytes, inputOffset, 4, numArray, 0);
            inputOffset += 4;
            memoryStream.Write(numArray, 0, fromBase64Transform.OutputBlockSize);
          }
          byte[] buffer = fromBase64Transform.TransformFinalBlock(bytes, inputOffset, bytes.Length - inputOffset);
          memoryStream.Write(buffer, 0, buffer.Length);
        }
        return memoryStream.ToArray();
      }
    }
    catch (FormatException ex)
    {
      DefaultLogger.Log.LogError($"Base64: (FormatException) {ex.Message}\r\nOn string: {string_0}");
      throw;
    }
  }

  static Class27 smethod_88(Class27 class27_0, buClipper buClipper_0)
  {
    Class27 class27_1 = (Class27) null;
    Class27 class270;
    for (class270 = class27_0.class27_0; class270 != class27_0; class270 = class270.class27_0)
    {
      if (class270.intPoint_0.Y > class27_0.intPoint_0.Y)
      {
        class27_0 = class270;
        class27_1 = (Class27) null;
      }
      else if ((class270.intPoint_0.Y != class27_0.intPoint_0.Y ? 0 : (class270.intPoint_0.X <= class27_0.intPoint_0.X ? 1 : 0)) != 0)
      {
        if (class270.intPoint_0.X < class27_0.intPoint_0.X)
        {
          class27_1 = (Class27) null;
          class27_0 = class270;
        }
        else if ((class270.class27_0 == class27_0 ? 0 : (class270.class27_1 != class27_0 ? 1 : 0)) != 0)
          class27_1 = class270;
      }
    }
    if (class27_1 != null)
    {
      while (class27_1 != class270)
      {
        if (!Class30.smethod_125(buClipper_0, class270, class27_1))
          class27_0 = class27_1;
        class27_1 = class27_1.class27_0;
        while (class27_1.intPoint_0 != class27_0.intPoint_0)
          class27_1 = class27_1.class27_0;
      }
    }
    return class27_0;
  }

  static void smethod_89(buClipper buClipper_0, Class22 class22_0, Class22 class22_1)
  {
    Class26 class26_1 = buClipper_0.list_1[class22_0.int_3];
    Class26 class26_2 = buClipper_0.list_1[class22_1.int_3];
    Class26 class26_3 = !Class30.smethod_34(buClipper_0, class26_1, class26_2) ? (!Class30.smethod_34(buClipper_0, class26_2, class26_1) ? Class30.smethod_126(buClipper_0, class26_1, class26_2) : class26_1) : class26_2;
    Class27 class270_1 = class26_1.class27_0;
    Class27 class271_1 = class270_1.class27_1;
    Class27 class270_2 = class26_2.class27_0;
    Class27 class271_2 = class270_2.class27_1;
    if (class22_0.enum2_0 == Enum2.const_0)
    {
      if (class22_1.enum2_0 == Enum2.const_0)
      {
        Class30.smethod_242(class270_2, buClipper_0);
        class270_2.class27_0 = class270_1;
        class270_1.class27_1 = class270_2;
        class271_1.class27_0 = class271_2;
        class271_2.class27_1 = class271_1;
        class26_1.class27_0 = class271_2;
      }
      else
      {
        class271_2.class27_0 = class270_1;
        class270_1.class27_1 = class271_2;
        class270_2.class27_1 = class271_1;
        class271_1.class27_0 = class270_2;
        class26_1.class27_0 = class270_2;
      }
    }
    else if (class22_1.enum2_0 == Enum2.const_1)
    {
      Class30.smethod_242(class270_2, buClipper_0);
      class271_1.class27_0 = class271_2;
      class271_2.class27_1 = class271_1;
      class270_2.class27_0 = class270_1;
      class270_1.class27_1 = class270_2;
    }
    else
    {
      class271_1.class27_0 = class270_2;
      class270_2.class27_1 = class271_1;
      class270_1.class27_1 = class271_2;
      class271_2.class27_0 = class270_1;
    }
    class26_1.class27_1 = (Class27) null;
    if (class26_3 == class26_2)
    {
      if (class26_2.class26_0 != class26_1)
        class26_1.class26_0 = class26_2.class26_0;
      class26_1.bool_0 = class26_2.bool_0;
    }
    class26_2.class27_0 = (Class27) null;
    class26_2.class27_1 = (Class27) null;
    class26_2.class26_0 = class26_1;
    int int3_1 = class22_0.int_3;
    int int3_2 = class22_1.int_3;
    class22_0.int_3 = -1;
    class22_1.int_3 = -1;
    for (Class22 class22 = buClipper_0.class22_0; class22 != null; class22 = class22.class22_3)
    {
      if (class22.int_3 == int3_2)
      {
        class22.int_3 = int3_1;
        class22.enum2_0 = class22_0.enum2_0;
        break;
      }
    }
    class26_2.int_0 = class26_1.int_0;
  }

  static void smethod_90(buClipper buClipper_0, Class26 class26_0)
  {
    Class27 class27_1 = (Class27) null;
    class26_0.class27_1 = (Class27) null;
    Class27 class27_2 = class26_0.class27_0;
    bool flag = buClipper_0.PreserveCollinear || buClipper_0.StrictlySimple;
    while ((class27_2.class27_1 == class27_2 ? 1 : (class27_2.class27_1 == class27_2.class27_0 ? 1 : 0)) == 0)
    {
      int num;
      if (!(class27_2.intPoint_0 == class27_2.class27_0.intPoint_0) && !(class27_2.intPoint_0 == class27_2.class27_1.intPoint_0))
      {
        IntPoint intPoint0_1 = class27_2.class27_1.intPoint_0;
        IntPoint intPoint0_2 = class27_2.intPoint_0;
        IntPoint intPoint0_3 = class27_2.class27_0.intPoint_0;
        if (Class30.smethod_103(buClipper_0.bool_0, intPoint0_2, intPoint0_3, intPoint0_1))
        {
          if (flag)
          {
            IntPoint intPoint0_4 = class27_2.class27_1.intPoint_0;
            IntPoint intPoint0_5 = class27_2.intPoint_0;
            IntPoint intPoint0_6 = class27_2.class27_0.intPoint_0;
            num = !Class30.smethod_32(intPoint0_4, intPoint0_5, (buClipperBase) buClipper_0, intPoint0_6) ? 1 : 0;
          }
          else
            num = 1;
        }
        else
          num = 0;
      }
      else
        num = 1;
      if (num != 0)
      {
        class27_1 = (Class27) null;
        class27_2.class27_1.class27_0 = class27_2.class27_0;
        class27_2.class27_0.class27_1 = class27_2.class27_1;
        class27_2 = class27_2.class27_1;
      }
      else if (class27_2 != class27_1)
      {
        if (class27_1 == null)
          class27_1 = class27_2;
        class27_2 = class27_2.class27_0;
      }
      else
      {
        class26_0.class27_0 = class27_2;
        return;
      }
    }
    class26_0.class27_0 = (Class27) null;
  }

  static void smethod_91(DTSweepContext dtsweepContext_0, AdvancingFrontNode advancingFrontNode_0)
  {
    for (AdvancingFrontNode next = advancingFrontNode_0.Next; next.HasNext; next = next.Next)
    {
      double num = Class30.smethod_57(next);
      if ((num > Math.PI / 2.0 ? 1 : (num < -1.0 * Math.PI / 2.0 ? 1 : 0)) == 0)
        Class30.smethod_51(dtsweepContext_0, next);
      else
        break;
    }
    for (AdvancingFrontNode prev = advancingFrontNode_0.Prev; prev.HasPrev; prev = prev.Prev)
    {
      double num = Class30.smethod_57(prev);
      if ((num > Math.PI / 2.0 ? 1 : (num < -1.0 * Math.PI / 2.0 ? 1 : 0)) == 0)
        Class30.smethod_51(dtsweepContext_0, prev);
      else
        break;
    }
    if ((!advancingFrontNode_0.HasNext ? 0 : (advancingFrontNode_0.Next.HasNext ? 1 : 0)) == 0 || Class30.smethod_218(advancingFrontNode_0) >= 3.0 * Math.PI / 4.0)
      return;
    Class30.smethod_205(advancingFrontNode_0, dtsweepContext_0);
  }

  static void smethod_92(buClipperBase buClipperBase_0, Class23 class23_0)
  {
    if (buClipperBase_0.class23_0 == null)
      buClipperBase_0.class23_0 = class23_0;
    else if (class23_0.long_0 >= buClipperBase_0.class23_0.long_0)
    {
      class23_0.class23_0 = buClipperBase_0.class23_0;
      buClipperBase_0.class23_0 = class23_0;
    }
    else
    {
      Class23 class230 = buClipperBase_0.class23_0;
      while ((class230.class23_0 == null ? 0 : (class23_0.long_0 < class230.class23_0.long_0 ? 1 : 0)) != 0)
        class230 = class230.class23_0;
      class23_0.class23_0 = class230.class23_0;
      class230.class23_0 = class23_0;
    }
  }

  static bool smethod_93(
    ref Color color_0,
    int int_0,
    buFile.Dxf dxf_0,
    ref LayerBase layerBase_0)
  {
    bool flag = false;
    int num = 0;
    Color color = Color.Black;
    layerBase_0 = new LayerBase();
    layerBase_0.Name = "";
    for (int index = int_0; index <= int_0 + 100; ++index)
    {
      ++num;
      if (dxf_0.list_0[index] == "  2" | dxf_0.list_0[index] == " 2")
        layerBase_0.Name = dxf_0.list_0[index + 1];
      if (!(dxf_0.list_0[index] == "  0" | dxf_0.list_0[index] == " 0"))
      {
        if (dxf_0.list_0[index] == " 62")
        {
          int int32 = Convert.ToInt32(dxf_0.list_0[index + 1]);
          if (int32 != 1)
            ;
          color = !(int32 >= 0 & int32 < dxf_0.ColorCode.Length) ? Color.Black : dxf_0.ColorCode[int32];
          if (color.A == (byte) 0 & color.R == (byte) 0 & color.G == (byte) 0 & color.B == (byte) 0)
            color = Color.Black;
        }
      }
      else
      {
        flag = true;
        break;
      }
    }
    color_0 = color;
    return flag;
  }

  static void smethod_94(Class34.Class36 class36_0, int int_0)
  {
    class36_0.uint_0 >>= int_0;
    class36_0.int_2 -= int_0;
  }

  static void smethod_95(buClipper buClipper_0, long long_0)
  {
    Class22 class22_0_1 = buClipper_0.class22_0;
    while (class22_0_1 != null)
    {
      bool flag;
      if (flag = Class30.smethod_237((double) long_0, buClipper_0, class22_0_1))
      {
        Class22 class22_0_2 = Class30.smethod_110(class22_0_1, buClipper_0);
        flag = class22_0_2 == null || !Class30.smethod_67(class22_0_2);
      }
      if (flag)
      {
        if (buClipper_0.StrictlySimple)
          Class30.smethod_134(buClipper_0, class22_0_1.intPoint_2.X);
        Class22 class224 = class22_0_1.class22_4;
        Class30.smethod_194(buClipper_0, class22_0_1);
        class22_0_1 = class224 != null ? class224.class22_3 : buClipper_0.class22_0;
      }
      else
      {
        if ((!Class30.smethod_9(class22_0_1, (double) long_0, buClipper_0) ? 0 : (Class30.smethod_67(class22_0_1.class22_2) ? 1 : 0)) != 0)
        {
          Class30.smethod_8((buClipperBase) buClipper_0, ref class22_0_1);
          if (class22_0_1.int_3 >= 0)
            Class30.smethod_246(buClipper_0, class22_0_1, class22_0_1.intPoint_0);
          Class30.smethod_11(buClipper_0, class22_0_1);
        }
        else
        {
          class22_0_1.intPoint_1.X = Class30.smethod_101(class22_0_1, long_0);
          class22_0_1.intPoint_1.Y = long_0;
          class22_0_1.intPoint_1.Z = class22_0_1.intPoint_2.Y != long_0 ? (class22_0_1.intPoint_0.Y != long_0 ? 0L : class22_0_1.intPoint_0.Z) : class22_0_1.intPoint_2.Z;
        }
        if (buClipper_0.StrictlySimple)
        {
          Class22 class224 = class22_0_1.class22_4;
          if ((class22_0_1.int_3 < 0 || class22_0_1.int_0 == 0 || class224 == null || class224.int_3 < 0 || class224.intPoint_1.X != class22_0_1.intPoint_1.X ? 0 : (class224.int_0 != 0 ? 1 : 0)) != 0)
          {
            IntPoint intPoint_0 = new IntPoint(class22_0_1.intPoint_1);
            Class30.smethod_207(buClipper_0, ref intPoint_0, class224, class22_0_1);
            Class27 class27_1 = Class30.smethod_246(buClipper_0, class224, intPoint_0);
            Class27 class27_0 = Class30.smethod_246(buClipper_0, class22_0_1, intPoint_0);
            Class30.smethod_22(intPoint_0, class27_0, class27_1, buClipper_0);
          }
        }
        class22_0_1 = class22_0_1.class22_3;
      }
    }
    Class30.smethod_163(buClipper_0);
    buClipper_0.class25_0 = (Class25) null;
    for (Class22 class22_0_3 = buClipper_0.class22_0; class22_0_3 != null; class22_0_3 = class22_0_3.class22_3)
    {
      if (Class30.smethod_9(class22_0_3, (double) long_0, buClipper_0))
      {
        Class27 class27_1 = (Class27) null;
        if (class22_0_3.int_3 >= 0)
          class27_1 = Class30.smethod_246(buClipper_0, class22_0_3, class22_0_3.intPoint_2);
        Class30.smethod_8((buClipperBase) buClipper_0, ref class22_0_3);
        Class22 class224 = class22_0_3.class22_4;
        Class22 class223 = class22_0_3.class22_3;
        int num1;
        if (class224 != null && class224.intPoint_1.X == class22_0_3.intPoint_0.X && class224.intPoint_1.Y == class22_0_3.intPoint_0.Y && class27_1 != null && class224.int_3 >= 0 && class224.intPoint_1.Y > class224.intPoint_2.Y)
        {
          IntPoint intPoint1_1 = class22_0_3.intPoint_1;
          IntPoint intPoint2_1 = class22_0_3.intPoint_2;
          IntPoint intPoint1_2 = class224.intPoint_1;
          IntPoint intPoint2_2 = class224.intPoint_2;
          bool bool0 = buClipper_0.bool_0;
          if (Class30.smethod_132(intPoint1_2, intPoint1_1, intPoint2_1, intPoint2_2, bool0) && class22_0_3.int_0 != 0)
          {
            num1 = class224.int_0 != 0 ? 1 : 0;
            goto label_25;
          }
        }
        num1 = 0;
label_25:
        if (num1 != 0)
        {
          Class27 class27_0 = Class30.smethod_246(buClipper_0, class224, class22_0_3.intPoint_0);
          Class30.smethod_22(class22_0_3.intPoint_2, class27_0, class27_1, buClipper_0);
        }
        else
        {
          int num2;
          if (class223 != null && class223.intPoint_1.X == class22_0_3.intPoint_0.X && class223.intPoint_1.Y == class22_0_3.intPoint_0.Y && class27_1 != null && class223.int_3 >= 0 && class223.intPoint_1.Y > class223.intPoint_2.Y)
          {
            IntPoint intPoint1_3 = class22_0_3.intPoint_1;
            IntPoint intPoint2_3 = class22_0_3.intPoint_2;
            IntPoint intPoint1_4 = class223.intPoint_1;
            IntPoint intPoint2_4 = class223.intPoint_2;
            bool bool0 = buClipper_0.bool_0;
            if (Class30.smethod_132(intPoint1_4, intPoint1_3, intPoint2_3, intPoint2_4, bool0) && class22_0_3.int_0 != 0)
            {
              num2 = class223.int_0 != 0 ? 1 : 0;
              goto label_31;
            }
          }
          num2 = 0;
label_31:
          if (num2 != 0)
          {
            Class27 class27_0 = Class30.smethod_246(buClipper_0, class223, class22_0_3.intPoint_0);
            Class30.smethod_22(class22_0_3.intPoint_2, class27_0, class27_1, buClipper_0);
          }
        }
      }
    }
  }

  static List<RfcMailAddress> smethod_96(string string_0)
  {
    if (string_0 == null)
      throw new ArgumentNullException("input");
    List<RfcMailAddress> rfcMailAddressList = new List<RfcMailAddress>();
    foreach (string string_0_1 in (IEnumerable<string>) Class30.smethod_189(',', string_0))
      rfcMailAddressList.Add(Class30.smethod_267(string_0_1));
    return rfcMailAddressList;
  }

  static bool smethod_97(
    long long_0,
    buClipper buClipper_0,
    long long_1,
    long long_2,
    long long_3)
  {
    if (long_2 > long_1)
      buClipper_0.Swap(ref long_2, ref long_1);
    if (long_3 > long_0)
      buClipper_0.Swap(ref long_3, ref long_0);
    return long_2 < long_0 && long_3 < long_1;
  }

  static void smethod_98(string string_0)
  {
    if (string_0 == null)
      throw new PopServerException("The stream used to retrieve responses from was closed");
    if (!string_0.StartsWith("+", StringComparison.OrdinalIgnoreCase))
      throw new PopServerException($"The server did not respond with a + response. The response was: \"{string_0}\"");
  }

  static Class22 smethod_99(buClipper buClipper_0, Class22 class22_0, Enum3 enum3_0)
  {
    return enum3_0 == Enum3.const_1 ? class22_0.class22_3 : class22_0.class22_4;
  }

  static void smethod_100(Class22 class22_0, Class22 class22_1)
  {
    int int3 = class22_0.int_3;
    class22_0.int_3 = class22_1.int_3;
    class22_1.int_3 = int3;
  }

  static long smethod_101(Class22 class22_0, long long_0)
  {
    return long_0 != class22_0.intPoint_2.Y ? class22_0.intPoint_0.X + Class30.smethod_199(class22_0.double_0 * (double) (long_0 - class22_0.intPoint_0.Y)) : class22_0.intPoint_2.X;
  }

  static void smethod_102(
    AdvancingFrontNode advancingFrontNode_0,
    TriangulationConstraint triangulationConstraint_0,
    DTSweepContext dtsweepContext_0)
  {
    if (dtsweepContext_0.IsDebugEnabled)
      dtsweepContext_0.DebugContext.ActiveNode = advancingFrontNode_0;
    if (advancingFrontNode_0.Point.X <= triangulationConstraint_0.P.X)
      return;
    if (TriangulationUtil.Orient2d((Point2D) advancingFrontNode_0.Point, (Point2D) advancingFrontNode_0.Prev.Point, (Point2D) advancingFrontNode_0.Prev.Prev.Point) == Orientation.Clockwise)
    {
      Class30.smethod_112(triangulationConstraint_0, advancingFrontNode_0, dtsweepContext_0);
    }
    else
    {
      Class30.smethod_78(triangulationConstraint_0, advancingFrontNode_0, dtsweepContext_0);
      Class30.smethod_102(advancingFrontNode_0, triangulationConstraint_0, dtsweepContext_0);
    }
  }

  static bool smethod_103(
    bool bool_0,
    IntPoint intPoint_0,
    IntPoint intPoint_1,
    IntPoint intPoint_2)
  {
    return !bool_0 ? (intPoint_2.Y - intPoint_0.Y) * (intPoint_0.X - intPoint_1.X) - (intPoint_2.X - intPoint_0.X) * (intPoint_0.Y - intPoint_1.Y) == 0L : Struct0.smethod_0(Struct0.smethod_2(intPoint_2.Y - intPoint_0.Y, intPoint_0.X - intPoint_1.X), Struct0.smethod_2(intPoint_2.X - intPoint_0.X, intPoint_0.Y - intPoint_1.Y));
  }

  static void smethod_104(
    double double_0,
    double double_1,
    ref List<Pnt3D> list_0,
    buFile.Dxf dxf_0,
    double double_2,
    double double_3,
    double double_4,
    double double_5)
  {
    double num1 = 0.0;
    Pnt3D pnt3D1 = new Pnt3D();
    list_0 = new List<Pnt3D>();
    double num2 = double_0 - double_4;
    int num3 = (int) (2.0 * Math.PI * double_3 * (double_0 - double_4) / 360.0 / double_1);
    double num4 = num3 == 0 ? 0.0 : num2 / (double) num3;
    if (num4 != 0.0 & num4 <= num2 / 2.0)
    {
      Pnt3D pnt3D2 = new Pnt3D();
      pnt3D2.X = double_2 + double_3 * Math.Cos(Class30.smethod_204(dxf_0, double_4));
      pnt3D2.Y = double_5 + double_3 * Math.Sin(Class30.smethod_204(dxf_0, double_4));
      list_0.Add(pnt3D2);
      for (double num5 = double_4; num5 <= double_0 - num4; num5 += num4)
      {
        Pnt3D pnt3D3 = new Pnt3D();
        pnt3D3.X = double_2 + double_3 * Math.Cos(Class30.smethod_204(dxf_0, num5 + num4));
        pnt3D3.Y = double_5 + double_3 * Math.Sin(Class30.smethod_204(dxf_0, num5 + num4));
        num1 = num5 + num4;
        list_0.Add(pnt3D3);
      }
      if (Math.Abs(num1 - double_0) <= 0.01)
        return;
      Pnt3D pnt3D4 = new Pnt3D();
      pnt3D4.X = double_2 + double_3 * Math.Cos(Class30.smethod_204(dxf_0, double_0));
      pnt3D4.Y = double_5 + double_3 * Math.Sin(Class30.smethod_204(dxf_0, double_0));
      list_0.Add(pnt3D4);
    }
    else
    {
      Pnt3D pnt3D5 = new Pnt3D();
      pnt3D5.X = double_2 + double_3 * Math.Cos(Class30.smethod_204(dxf_0, double_4));
      pnt3D5.Y = double_5 + double_3 * Math.Sin(Class30.smethod_204(dxf_0, double_4));
      list_0.Add(pnt3D5);
      Pnt3D pnt3D6 = new Pnt3D();
      pnt3D6.X = double_2 + double_3 * Math.Cos(Class30.smethod_204(dxf_0, double_0));
      pnt3D6.Y = double_5 + double_3 * Math.Sin(Class30.smethod_204(dxf_0, double_0));
      list_0.Add(pnt3D6);
    }
  }

  static Class22 smethod_105(Class22 class22_0, buClipperBase buClipperBase_0)
  {
    Class22 class22;
    do
    {
      while ((class22_0.intPoint_0 != class22_0.class22_1.intPoint_0 ? 1 : (class22_0.intPoint_1 == class22_0.intPoint_2 ? 1 : 0)) != 0)
        class22_0 = class22_0.class22_0;
      if ((class22_0.double_0 == -3.4E+38 ? 0 : (class22_0.class22_1.double_0 != -3.4E+38 ? 1 : 0)) == 0)
      {
        while (class22_0.class22_1.double_0 == -3.4E+38)
          class22_0 = class22_0.class22_1;
        class22 = class22_0;
        while (class22_0.double_0 == -3.4E+38)
          class22_0 = class22_0.class22_0;
      }
      else
        goto label_12;
    }
    while (class22_0.intPoint_2.Y == class22_0.class22_1.intPoint_0.Y);
    if (class22.class22_1.intPoint_0.X < class22_0.intPoint_0.X)
      class22_0 = class22;
label_12:
    return class22_0;
  }

  static string smethod_106(Stream stream_0)
  {
    byte[] bytes = Class30.smethod_113(stream_0);
    return bytes != null ? Encoding.ASCII.GetString(bytes) : (string) null;
  }

  static void smethod_107(
    AdvancingFrontNode advancingFrontNode_0,
    TriangulationConstraint triangulationConstraint_0,
    DTSweepContext dtsweepContext_0)
  {
    while (advancingFrontNode_0.Prev.Point.X > triangulationConstraint_0.P.X)
    {
      if (dtsweepContext_0.IsDebugEnabled)
        dtsweepContext_0.DebugContext.ActiveNode = advancingFrontNode_0;
      if (TriangulationUtil.Orient2d((Point2D) triangulationConstraint_0.Q, (Point2D) advancingFrontNode_0.Prev.Point, (Point2D) triangulationConstraint_0.P) == Orientation.Clockwise)
        Class30.smethod_102(advancingFrontNode_0, triangulationConstraint_0, dtsweepContext_0);
      else
        advancingFrontNode_0 = advancingFrontNode_0.Prev;
    }
  }

  static void smethod_108(
    ref IntPoint intPoint_0,
    Class22 class22_0,
    [Out] Class22 class22_1,
    buClipper buClipper_0)
  {
    intPoint_0 = new IntPoint();
    if (class22_0.double_0 == class22_1.double_0)
    {
      intPoint_0.Y = class22_0.intPoint_1.Y;
      intPoint_0.X = Class30.smethod_101(class22_0, intPoint_0.Y);
    }
    else
    {
      if (class22_0.intPoint_3.X == 0L)
      {
        intPoint_0.X = class22_0.intPoint_0.X;
        if (Class30.smethod_67(class22_1))
        {
          intPoint_0.Y = class22_1.intPoint_0.Y;
        }
        else
        {
          double num = (double) class22_1.intPoint_0.Y - (double) class22_1.intPoint_0.X / class22_1.double_0;
          intPoint_0.Y = Class30.smethod_199((double) intPoint_0.X / class22_1.double_0 + num);
        }
      }
      else if (class22_1.intPoint_3.X == 0L)
      {
        intPoint_0.X = class22_1.intPoint_0.X;
        if (Class30.smethod_67(class22_0))
        {
          intPoint_0.Y = class22_0.intPoint_0.Y;
        }
        else
        {
          double num = (double) class22_0.intPoint_0.Y - (double) class22_0.intPoint_0.X / class22_0.double_0;
          intPoint_0.Y = Class30.smethod_199((double) intPoint_0.X / class22_0.double_0 + num);
        }
      }
      else
      {
        double num1 = (double) class22_0.intPoint_0.X - (double) class22_0.intPoint_0.Y * class22_0.double_0;
        double num2 = (double) class22_1.intPoint_0.X - (double) class22_1.intPoint_0.Y * class22_1.double_0;
        double double_0 = (num2 - num1) / (class22_0.double_0 - class22_1.double_0);
        intPoint_0.Y = Class30.smethod_199(double_0);
        intPoint_0.X = Math.Abs(class22_0.double_0) >= Math.Abs(class22_1.double_0) ? Class30.smethod_199(class22_1.double_0 * double_0 + num2) : Class30.smethod_199(class22_0.double_0 * double_0 + num1);
      }
      if ((intPoint_0.Y < class22_0.intPoint_2.Y ? 1 : (intPoint_0.Y < class22_1.intPoint_2.Y ? 1 : 0)) != 0)
      {
        intPoint_0.Y = class22_0.intPoint_2.Y <= class22_1.intPoint_2.Y ? class22_1.intPoint_2.Y : class22_0.intPoint_2.Y;
        intPoint_0.X = Math.Abs(class22_0.double_0) >= Math.Abs(class22_1.double_0) ? Class30.smethod_101(class22_1, intPoint_0.Y) : Class30.smethod_101(class22_0, intPoint_0.Y);
      }
      if (intPoint_0.Y <= class22_0.intPoint_1.Y)
        return;
      intPoint_0.Y = class22_0.intPoint_1.Y;
      if (Math.Abs(class22_0.double_0) > Math.Abs(class22_1.double_0))
        intPoint_0.X = Class30.smethod_101(class22_1, intPoint_0.Y);
      else
        intPoint_0.X = Class30.smethod_101(class22_0, intPoint_0.Y);
    }
  }

  static DateTime smethod_109(DateTime dateTime_0, string string_0)
  {
    string[] strArray = string_0.Split(' ');
    Match match = Regex.Match(Regex.Replace(strArray[strArray.Length - 1], "UT|GMT|EST|EDT|CST|CDT|MST|MDT|PST|PDT|[A-I]|[K-Y]|Z", new MatchEvaluator(Class30.smethod_37)), "[\\+-](?<hours>\\d\\d)(?<minutes>\\d\\d)");
    DateTime dateTime;
    if (match.Success)
    {
      int num1 = int.Parse(match.Groups["hours"].Value);
      int num2 = int.Parse(match.Groups["minutes"].Value);
      int num3 = match.Value[0] == '+' ? -1 : 1;
      dateTime_0 = dateTime_0.AddHours((double) (num3 * num1));
      dateTime_0 = dateTime_0.AddMinutes((double) (num3 * num2));
      dateTime = dateTime_0;
    }
    else
    {
      DefaultLogger.Log.LogDebug($"No timezone found in date: {string_0}. Using -0000 as default.");
      dateTime = dateTime_0;
    }
    return dateTime;
  }

  static Class22 smethod_110(Class22 class22_0, buClipper buClipper_0)
  {
    Class22 class22_0_1 = Class30.smethod_146(buClipper_0, class22_0);
    return (class22_0_1 == null || class22_0_1.int_3 == -2 ? 1 : (class22_0_1.class22_3 != class22_0_1.class22_4 ? 0 : (!Class30.smethod_67(class22_0_1) ? 1 : 0))) == 0 ? class22_0_1 : (Class22) null;
  }

  static void smethod_111(
    buClipper buClipper_0,
    [Out] Class22 class22_0,
    out Enum3 enum3_0,
    out long long_0,
    ref long long_1)
  {
    if (class22_0.intPoint_0.X < class22_0.intPoint_2.X)
    {
      long_0 = class22_0.intPoint_0.X;
      long_1 = class22_0.intPoint_2.X;
      enum3_0 = Enum3.const_1;
    }
    else
    {
      long_0 = class22_0.intPoint_2.X;
      long_1 = class22_0.intPoint_0.X;
      enum3_0 = Enum3.const_0;
    }
  }

  static void smethod_112(
    TriangulationConstraint triangulationConstraint_0,
    AdvancingFrontNode advancingFrontNode_0,
    DTSweepContext dtsweepContext_0)
  {
    Class30.smethod_51(dtsweepContext_0, advancingFrontNode_0.Prev);
    if (!advancingFrontNode_0.Prev.Point.Equals(triangulationConstraint_0.P) || TriangulationUtil.Orient2d((Point2D) triangulationConstraint_0.Q, (Point2D) advancingFrontNode_0.Prev.Point, (Point2D) triangulationConstraint_0.P) != Orientation.Clockwise || TriangulationUtil.Orient2d((Point2D) advancingFrontNode_0.Point, (Point2D) advancingFrontNode_0.Prev.Point, (Point2D) advancingFrontNode_0.Prev.Prev.Point) != Orientation.Clockwise)
      return;
    Class30.smethod_112(triangulationConstraint_0, advancingFrontNode_0, dtsweepContext_0);
  }

  static byte[] smethod_113(Stream stream_0)
  {
    if (stream_0 == null)
      throw new ArgumentNullException("stream");
    using (MemoryStream memoryStream = new MemoryStream())
    {
      char ch;
      do
      {
        int num = stream_0.ReadByte();
        if ((num != -1 ? 0 : (memoryStream.Length > 0L ? 1 : 0)) == 0)
        {
          if ((num != -1 ? 0 : (memoryStream.Length == 0L ? 1 : 0)) == 0)
          {
            ch = (char) num;
            if ((ch == '\r' ? 0 : (ch != '\n' ? 1 : 0)) != 0)
              memoryStream.WriteByte((byte) num);
          }
          else
            goto label_9;
        }
        else
          break;
      }
      while (ch != '\n');
      goto label_10;
label_9:
      return (byte[]) null;
label_10:
      return memoryStream.ToArray();
    }
  }

  static void smethod_114(DelaunayTriangle delaunayTriangle_0, DelaunayTriangle delaunayTriangle_1)
  {
    if (delaunayTriangle_1.Neighbors[0] == delaunayTriangle_0)
      delaunayTriangle_1.Neighbors[0] = (DelaunayTriangle) null;
    else if (delaunayTriangle_1.Neighbors[1] == delaunayTriangle_0)
    {
      delaunayTriangle_1.Neighbors[1] = (DelaunayTriangle) null;
    }
    else
    {
      if (delaunayTriangle_1.Neighbors[2] != delaunayTriangle_0)
        return;
      delaunayTriangle_1.Neighbors[2] = (DelaunayTriangle) null;
    }
  }

  static string smethod_115(string string_0)
  {
    StringBuilder stringBuilder = string_0 != null ? new StringBuilder(string_0.Length) : throw new ArgumentNullException("input");
    for (int index = 0; index < string_0.Length; ++index)
    {
      if ((string_0[index] != '\r' ? 0 : (index + 1 >= string_0.Length ? 1 : (string_0[index + 1] != '\n' ? 1 : 0))) == 0 && (string_0[index] != '\n' ? 0 : (index - 1 < 0 ? 1 : (string_0[index - 1] != '\r' ? 1 : 0))) == 0)
        stringBuilder.Append(string_0[index]);
    }
    return stringBuilder.ToString();
  }

  static int smethod_116(Class34.Stream0 stream0_0)
  {
    return Class30.smethod_27(stream0_0) | Class30.smethod_27(stream0_0) << 16 /*0x10*/;
  }

  static void smethod_117(buClipper buClipper_0, Class26 class26_0)
  {
    if ((class26_0.class26_0 == null ? 1 : (class26_0.bool_0 == class26_0.class26_0.bool_0 ? 0 : (class26_0.class26_0.class27_0 != null ? 1 : 0))) != 0)
      return;
    Class26 class260 = class26_0.class26_0;
    while ((class260 == null ? 0 : (class260.bool_0 == class26_0.bool_0 ? 1 : (class260.class27_0 == null ? 1 : 0))) != 0)
      class260 = class260.class26_0;
    class26_0.class26_0 = class260;
  }

  static void smethod_118(buClipper buClipper_0, List<List<IntPoint>> list_0)
  {
    list_0.Clear();
    list_0.Capacity = buClipper_0.list_1.Count;
    for (int index1 = 0; index1 < buClipper_0.list_1.Count; ++index1)
    {
      Class26 class26 = buClipper_0.list_1[index1];
      if (class26.class27_0 != null)
      {
        Class27 class271 = class26.class27_0.class27_1;
        int capacity = Class30.smethod_258(class271, buClipper_0);
        if (capacity >= 2)
        {
          List<IntPoint> intPointList = new List<IntPoint>(capacity);
          for (int index2 = 0; index2 < capacity; ++index2)
          {
            intPointList.Add(class271.intPoint_0);
            class271 = class271.class27_1;
          }
          list_0.Add(intPointList);
        }
      }
    }
  }

  static uint smethod_119(string string_0)
  {
    uint num;
    if (string_0 != null)
    {
      num = 2166136261U;
      for (int index = 0; index < string_0.Length; ++index)
        num = (uint) (((int) string_0[index] ^ (int) num) * 16777619);
    }
    return num;
  }

  static bool smethod_120(Point2D point2D_0, Contour contour_0)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Contour.Class3 class3 = new Contour.Class3();
    // ISSUE: reference to a compiler-generated field
    class3.point2D_0 = point2D_0;
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated method
    return PolygonUtil.PointInPolygon2D((IList<Point2D>) contour_0, class3.point2D_0) && contour_0.list_0.All<Contour>(new Func<Contour, bool>(class3.method_0));
  }

  static void smethod_121(
    ClipperOffset clipperOffset_0,
    int int_0,
    ref int int_1,
    JoinType joinType_0)
  {
    clipperOffset_0.double_1 = clipperOffset_0.list_3[int_1].X * clipperOffset_0.list_3[int_0].Y - clipperOffset_0.list_3[int_0].X * clipperOffset_0.list_3[int_1].Y;
    if (Math.Abs(clipperOffset_0.double_1 * clipperOffset_0.double_0) < 1.0)
    {
      if (clipperOffset_0.list_3[int_1].X * clipperOffset_0.list_3[int_0].X + clipperOffset_0.list_3[int_0].Y * clipperOffset_0.list_3[int_1].Y > 0.0)
      {
        clipperOffset_0.list_2.Add(new IntPoint(Class30.smethod_150((double) clipperOffset_0.list_1[int_0].X + clipperOffset_0.list_3[int_1].X * clipperOffset_0.double_0), Class30.smethod_150((double) clipperOffset_0.list_1[int_0].Y + clipperOffset_0.list_3[int_1].Y * clipperOffset_0.double_0)));
        return;
      }
    }
    else if (clipperOffset_0.double_1 > 1.0)
      clipperOffset_0.double_1 = 1.0;
    else if (clipperOffset_0.double_1 < -1.0)
      clipperOffset_0.double_1 = -1.0;
    if (clipperOffset_0.double_1 * clipperOffset_0.double_0 < 0.0)
    {
      clipperOffset_0.list_2.Add(new IntPoint(Class30.smethod_150((double) clipperOffset_0.list_1[int_0].X + clipperOffset_0.list_3[int_1].X * clipperOffset_0.double_0), Class30.smethod_150((double) clipperOffset_0.list_1[int_0].Y + clipperOffset_0.list_3[int_1].Y * clipperOffset_0.double_0)));
      clipperOffset_0.list_2.Add(clipperOffset_0.list_1[int_0]);
      clipperOffset_0.list_2.Add(new IntPoint(Class30.smethod_150((double) clipperOffset_0.list_1[int_0].X + clipperOffset_0.list_3[int_0].X * clipperOffset_0.double_0), Class30.smethod_150((double) clipperOffset_0.list_1[int_0].Y + clipperOffset_0.list_3[int_0].Y * clipperOffset_0.double_0)));
    }
    else
    {
      switch (joinType_0)
      {
        case JoinType.jtSquare:
          Class30.smethod_210(clipperOffset_0, int_0, int_1);
          break;
        case JoinType.jtRound:
          Class30.smethod_154(clipperOffset_0, int_0, int_1);
          break;
        case JoinType.jtMiter:
          double double_0 = 1.0 + (clipperOffset_0.list_3[int_0].X * clipperOffset_0.list_3[int_1].X + clipperOffset_0.list_3[int_0].Y * clipperOffset_0.list_3[int_1].Y);
          if (double_0 >= clipperOffset_0.double_4)
          {
            Class30.smethod_13(int_1, double_0, clipperOffset_0, int_0);
            break;
          }
          Class30.smethod_210(clipperOffset_0, int_0, int_1);
          break;
      }
    }
    int_1 = int_0;
  }

  static byte[] smethod_122(byte[] byte_0, byte[] byte_1)
  {
    if (byte_0 == null)
      throw new ArgumentNullException("one");
    if (byte_1 == null)
      throw new ArgumentNullException("two");
    byte[] dst = new byte[byte_0.Length + byte_1.Length];
    Buffer.BlockCopy((Array) byte_0, 0, (Array) dst, 0, byte_0.Length);
    Buffer.BlockCopy((Array) byte_1, 0, (Array) dst, byte_0.Length, byte_1.Length);
    return dst;
  }

  static void smethod_123(
    TriangulationConstraint triangulationConstraint_0,
    AdvancingFrontNode advancingFrontNode_0,
    DTSweepContext dtsweepContext_0)
  {
    Class30.smethod_51(dtsweepContext_0, advancingFrontNode_0.Next);
    if (!advancingFrontNode_0.Next.Point.Equals(triangulationConstraint_0.P) || TriangulationUtil.Orient2d((Point2D) triangulationConstraint_0.Q, (Point2D) advancingFrontNode_0.Next.Point, (Point2D) triangulationConstraint_0.P) != Orientation.AntiClockwise || TriangulationUtil.Orient2d((Point2D) advancingFrontNode_0.Point, (Point2D) advancingFrontNode_0.Next.Point, (Point2D) advancingFrontNode_0.Next.Next.Point) != Orientation.AntiClockwise)
      return;
    Class30.smethod_123(triangulationConstraint_0, advancingFrontNode_0, dtsweepContext_0);
  }

  static void smethod_124(DateTime dateTime_0, string string_0)
  {
    if ((string_0.Length < 4 ? 0 : (string_0[3] == ',' ? 1 : 0)) == 0)
      return;
    string str = string_0.Substring(0, 3);
    if ((dateTime_0.DayOfWeek == DayOfWeek.Monday && !str.Equals("Mon") || dateTime_0.DayOfWeek == DayOfWeek.Tuesday && !str.Equals("Tue") || dateTime_0.DayOfWeek == DayOfWeek.Wednesday && !str.Equals("Wed") || dateTime_0.DayOfWeek == DayOfWeek.Thursday && !str.Equals("Thu") || dateTime_0.DayOfWeek == DayOfWeek.Friday && !str.Equals("Fri") || dateTime_0.DayOfWeek == DayOfWeek.Saturday && !str.Equals("Sat") ? 1 : (dateTime_0.DayOfWeek != DayOfWeek.Sunday ? 0 : (!str.Equals("Sun") ? 1 : 0))) == 0)
      return;
    DefaultLogger.Log.LogDebug("Day-name does not correspond to the weekday of the date: " + string_0);
  }

  static bool smethod_125(buClipper buClipper_0, Class27 class27_0, Class27 class27_1)
  {
    Class27 class271_1 = class27_0.class27_1;
    while ((!(class271_1.intPoint_0 == class27_0.intPoint_0) ? 0 : (class271_1 != class27_0 ? 1 : 0)) != 0)
      class271_1 = class271_1.class27_1;
    IntPoint intPoint0_1 = class27_0.intPoint_0;
    double val1_1 = Math.Abs(Class30.smethod_249(class271_1.intPoint_0, buClipper_0, intPoint0_1));
    Class27 class270_1 = class27_0.class27_0;
    while ((!(class270_1.intPoint_0 == class27_0.intPoint_0) ? 0 : (class270_1 != class27_0 ? 1 : 0)) != 0)
      class270_1 = class270_1.class27_0;
    IntPoint intPoint0_2 = class27_0.intPoint_0;
    double val2_1 = Math.Abs(Class30.smethod_249(class270_1.intPoint_0, buClipper_0, intPoint0_2));
    Class27 class271_2 = class27_1.class27_1;
    while ((!(class271_2.intPoint_0 == class27_1.intPoint_0) ? 0 : (class271_2 != class27_1 ? 1 : 0)) != 0)
      class271_2 = class271_2.class27_1;
    IntPoint intPoint0_3 = class27_1.intPoint_0;
    double val1_2 = Math.Abs(Class30.smethod_249(class271_2.intPoint_0, buClipper_0, intPoint0_3));
    Class27 class270_2 = class27_1.class27_0;
    while ((!(class270_2.intPoint_0 == class27_1.intPoint_0) ? 0 : (class270_2 != class27_1 ? 1 : 0)) != 0)
      class270_2 = class270_2.class27_0;
    IntPoint intPoint0_4 = class27_1.intPoint_0;
    double val2_2 = Math.Abs(Class30.smethod_249(class270_2.intPoint_0, buClipper_0, intPoint0_4));
    return (Math.Max(val1_1, val2_1) != Math.Max(val1_2, val2_2) ? 0 : (Math.Min(val1_1, val2_1) == Math.Min(val1_2, val2_2) ? 1 : 0)) == 0 ? val1_1 >= val1_2 && val1_1 >= val2_2 || val2_1 >= val1_2 && val2_1 >= val2_2 : Class30.smethod_216(class27_0, buClipper_0) > 0.0;
  }

  static Class26 smethod_126(buClipper buClipper_0, Class26 class26_0, Class26 class26_1)
  {
    if (class26_0.class27_1 == null)
      class26_0.class27_1 = Class30.smethod_88(class26_0.class27_0, buClipper_0);
    if (class26_1.class27_1 == null)
      class26_1.class27_1 = Class30.smethod_88(class26_1.class27_0, buClipper_0);
    Class27 class271_1 = class26_0.class27_1;
    Class27 class271_2 = class26_1.class27_1;
    return class271_1.intPoint_0.Y <= class271_2.intPoint_0.Y ? (class271_1.intPoint_0.Y >= class271_2.intPoint_0.Y ? (class271_1.intPoint_0.X >= class271_2.intPoint_0.X ? (class271_1.intPoint_0.X <= class271_2.intPoint_0.X ? (class271_1.class27_0 != class271_1 ? (class271_2.class27_0 != class271_2 ? (!Class30.smethod_125(buClipper_0, class271_1, class271_2) ? class26_1 : class26_0) : class26_0) : class26_1) : class26_1) : class26_0) : class26_1) : class26_0;
  }

  static Contour smethod_127(int int_0, Contour contour_0)
  {
    return (int_0 < 0 ? 1 : (int_0 >= contour_0.list_0.Count ? 1 : 0)) == 0 ? contour_0.list_0[int_0] : (Contour) null;
  }

  static long smethod_128(string string_0)
  {
    string_0 = string_0.ToUpperInvariant();
    return Class17.dictionary_0.ContainsKey(string_0) ? Class17.dictionary_0[string_0] : throw new ArgumentException($"illegal or unknown unit: \"{string_0}\"", "unit");
  }

  static void smethod_129(Class34.Class37 class37_0, int int_0)
  {
    Class34.Class37 class37_1 = class37_0;
    int int1 = class37_0.int_1;
    int num1 = int1 + 1;
    class37_1.int_1 = num1;
    if (int1 == 32768 /*0x8000*/)
      throw new InvalidOperationException();
    byte[] byte0 = class37_0.byte_0;
    Class34.Class37 class37_2 = class37_0;
    int int0 = class37_0.int_0;
    int num2 = int0 + 1;
    class37_2.int_0 = num2;
    int index = int0;
    int num3 = (int) (byte) int_0;
    byte0[index] = (byte) num3;
    class37_0.int_0 &= (int) short.MaxValue;
  }

  static int smethod_130(Contour contour_0) => contour_0.list_0.Count;

  static double smethod_131(
    double double_0,
    double double_1,
    double double_2,
    buVector buVector_0,
    double double_3)
  {
    double num1 = Math.Atan2(double_3, double_1);
    double num2 = Math.Atan2(double_0, double_2) - num1;
    while (num2 > Math.PI)
      num2 -= 2.0 * Math.PI;
    while (num2 < -1.0 * Math.PI)
      num2 += 2.0 * Math.PI;
    return num2;
  }

  static bool smethod_132(
    IntPoint intPoint_0,
    IntPoint intPoint_1,
    IntPoint intPoint_2,
    IntPoint intPoint_3,
    bool bool_0)
  {
    return !bool_0 ? (intPoint_1.Y - intPoint_2.Y) * (intPoint_0.X - intPoint_3.X) - (intPoint_1.X - intPoint_2.X) * (intPoint_0.Y - intPoint_3.Y) == 0L : Struct0.smethod_0(Struct0.smethod_2(intPoint_1.Y - intPoint_2.Y, intPoint_0.X - intPoint_3.X), Struct0.smethod_2(intPoint_1.X - intPoint_2.X, intPoint_0.Y - intPoint_3.Y));
  }

  static void smethod_133(buClipper buClipper_0)
  {
    for (int int_0 = 0; int_0 < buClipper_0.list_1.Count; ++int_0)
      Class30.smethod_276((buClipperBase) buClipper_0, int_0);
    buClipper_0.list_1.Clear();
  }

  static void smethod_134(buClipper buClipper_0, long long_0)
  {
    Class25 class25 = new Class25();
    class25.long_0 = long_0;
    if (buClipper_0.class25_0 == null)
    {
      buClipper_0.class25_0 = class25;
      buClipper_0.class25_0.class25_0 = (Class25) null;
      buClipper_0.class25_0.class25_1 = (Class25) null;
    }
    else if (long_0 < buClipper_0.class25_0.long_0)
    {
      class25.class25_0 = buClipper_0.class25_0;
      class25.class25_1 = (Class25) null;
      buClipper_0.class25_0 = class25;
    }
    else
    {
      Class25 class250 = buClipper_0.class25_0;
      while ((class250.class25_0 == null ? 0 : (long_0 >= class250.class25_0.long_0 ? 1 : 0)) != 0)
        class250 = class250.class25_0;
      if (long_0 == class250.long_0)
        return;
      class25.class25_0 = class250.class25_0;
      class25.class25_1 = class250;
      if (class250.class25_0 != null)
        class250.class25_0.class25_1 = class25;
      class250.class25_0 = class25;
    }
  }

  static void smethod_135(
    DTSweepContext dtsweepContext_0,
    DTSweepConstraint dtsweepConstraint_0,
    AdvancingFrontNode advancingFrontNode_0)
  {
    dtsweepContext_0.EdgeEvent.ConstrainedEdge = dtsweepConstraint_0;
    dtsweepContext_0.EdgeEvent.Right = dtsweepConstraint_0.P.X > dtsweepConstraint_0.Q.X;
    if (dtsweepContext_0.IsDebugEnabled)
      dtsweepContext_0.DebugContext.PrimaryTriangle = advancingFrontNode_0.Triangle;
    if (Class30.smethod_181(advancingFrontNode_0.Triangle, dtsweepConstraint_0.P, dtsweepConstraint_0.Q))
      return;
    Class30.smethod_227(dtsweepContext_0, (TriangulationConstraint) dtsweepConstraint_0, advancingFrontNode_0);
    TriangulationPoint p = dtsweepConstraint_0.P;
    TriangulationPoint q1 = dtsweepConstraint_0.Q;
    DelaunayTriangle triangle = advancingFrontNode_0.Triangle;
    TriangulationPoint q2 = dtsweepConstraint_0.Q;
    Class30.smethod_49(p, q2, dtsweepContext_0, triangle, q1);
  }

  static Dictionary<string, long> smethod_136()
  {
    return new Dictionary<string, long>()
    {
      {
        "",
        1L
      },
      {
        "B",
        1L
      },
      {
        "KB",
        1024L /*0x0400*/
      },
      {
        "MB",
        1048576L /*0x100000*/
      },
      {
        "GB",
        1073741824L /*0x40000000*/
      },
      {
        "TB",
        1099511627776L /*0x010000000000*/
      }
    };
  }

  static Class27 smethod_137(Class22 class22_0, buClipper buClipper_0)
  {
    Class26 class26 = buClipper_0.list_1[class22_0.int_3];
    return class22_0.enum2_0 != Enum2.const_0 ? class26.class27_0.class27_1 : class26.class27_0;
  }

  static bool smethod_138(Class34.Class35 class35_0)
  {
    switch (class35_0.int_4)
    {
      case 2:
        if (class35_0.bool_0)
        {
          class35_0.int_4 = 12;
          return false;
        }
        int num1 = Class30.smethod_292(class35_0.class36_0, 3);
        if (num1 < 0)
          return false;
        Class30.smethod_94(class35_0.class36_0, 3);
        if ((num1 & 1) != 0)
          class35_0.bool_0 = true;
        switch (num1 >> 1)
        {
          case 0:
            Class30.smethod_294(class35_0.class36_0);
            class35_0.int_4 = 3;
            break;
          case 1:
            class35_0.class38_0 = Class34.Class38.class38_0;
            class35_0.class38_1 = Class34.Class38.class38_1;
            class35_0.int_4 = 7;
            break;
          case 2:
            class35_0.class39_0 = new Class34.Class39();
            class35_0.int_4 = 6;
            break;
        }
        return true;
      case 3:
        if ((class35_0.int_8 = Class30.smethod_292(class35_0.class36_0, 16 /*0x10*/)) < 0)
          return false;
        Class30.smethod_94(class35_0.class36_0, 16 /*0x10*/);
        class35_0.int_4 = 4;
        goto case 4;
      case 4:
        if (Class30.smethod_292(class35_0.class36_0, 16 /*0x10*/) < 0)
          return false;
        Class30.smethod_94(class35_0.class36_0, 16 /*0x10*/);
        class35_0.int_4 = 5;
        goto case 5;
      case 5:
        int num2 = Class30.smethod_219(class35_0.class37_0, class35_0.class36_0, class35_0.int_8);
        class35_0.int_8 -= num2;
        if (class35_0.int_8 != 0)
          return !Class30.smethod_252(class35_0.class36_0);
        class35_0.int_4 = 2;
        return true;
      case 6:
        if (!Class30.smethod_83(class35_0.class39_0, class35_0.class36_0))
          return false;
        class35_0.class38_0 = Class30.smethod_29(class35_0.class39_0);
        class35_0.class38_1 = Class30.smethod_195(class35_0.class39_0);
        class35_0.int_4 = 7;
        goto case 7;
      case 7:
      case 8:
      case 9:
      case 10:
        return Class30.smethod_158(class35_0);
      case 12:
        return false;
      default:
        return false;
    }
  }

  static Class27 smethod_139(buClipper buClipper_0, Class27 class27_0, bool bool_0)
  {
    Class27 class27 = new Class27();
    class27.intPoint_0 = class27_0.intPoint_0;
    class27.int_0 = class27_0.int_0;
    if (bool_0)
    {
      class27.class27_0 = class27_0.class27_0;
      class27.class27_1 = class27_0;
      class27_0.class27_0.class27_1 = class27;
      class27_0.class27_0 = class27;
    }
    else
    {
      class27.class27_1 = class27_0.class27_1;
      class27.class27_0 = class27_0;
      class27_0.class27_1.class27_0 = class27;
      class27_0.class27_1 = class27;
    }
    return class27;
  }

  static void smethod_140(
    double double_0,
    double double_1,
    ref double double_2,
    ref double double_3,
    short short_0,
    double double_4,
    buFile.Dxf dxf_0,
    double double_5,
    double double_6)
  {
    double x1 = 0.0;
    bool flag1 = false;
    if (double_6 < 0.0)
      flag1 = true;
    double num1 = (double_1 + double_0) / 2.0;
    double num2 = (double_4 + double_5) / 2.0;
    double_6 = Math.Abs(double_6);
    double double_3_1;
    double double_3_2;
    double double_2_1;
    double double_2_2;
    if (double_4 != double_5)
    {
      double x2 = (double_1 - double_0) / (double_5 - double_4);
      double x3 = Math.Sqrt(Math.Pow(double_5 - num2, 2.0) + Math.Pow(double_0 - num1, 2.0));
      double num3 = Math.Sqrt(Math.Pow(double_6, 2.0) - Math.Pow(x3, 2.0)) / Math.Sqrt(Math.Pow(x2, 2.0) + 1.0);
      double_3_1 = num2 + x2 * num3;
      double_3_2 = num2 - x2 * num3;
      double_2_1 = num1 + num3;
      double_2_2 = num1 - num3;
    }
    else
    {
      double num4 = Math.Sqrt(Math.Pow(double_5 - num2, 2.0) + Math.Pow(double_0 - num1, 2.0));
      double num5 = (!Class30.smethod_255(dxf_0, double_6, num4) ? Math.Sqrt(Math.Pow(double_6, 2.0) - Math.Pow(num4, 2.0)) : 0.0) / Math.Sqrt(Math.Pow(x1, 2.0) + 1.0);
      double_3_1 = num2 + num5;
      double_3_2 = num2 - num5;
      double_2_1 = num1;
      double_2_2 = num1;
    }
    bool flag2 = false;
    if (short_0 == (short) 2)
    {
      double double_0_1 = Class30.smethod_149(dxf_0, double_1, double_4, double_2_1, double_3_1);
      double double_0_2 = Class30.smethod_149(dxf_0, double_0, double_5, double_2_1, double_3_1);
      if (!flag1)
      {
        if (double_0_2 > 180.0 & Class30.smethod_255(dxf_0, double_0_1, 0.0))
          double_0_1 = 360.0;
        if (double_0_1 < 180.0 & Class30.smethod_255(dxf_0, double_0_2, 0.0))
          double_0_2 = 0.0;
      }
      if (!flag1 & double_0_1 > double_0_2 & (double_0_1 - double_0_2 < 180.0 | Class30.smethod_255(dxf_0, double_0_1 - double_0_2, 180.0)))
      {
        double_3 = double_2_1;
        double_2 = double_3_1;
        dxf_0.double_0 = double_0_1;
        dxf_0.double_1 = double_0_2;
        flag2 = true;
      }
      if (flag1 & double_0_1 > double_0_2 & double_0_1 - double_0_2 > 180.0)
      {
        double_3 = double_2_1;
        double_2 = double_3_1;
        dxf_0.double_0 = double_0_1;
        dxf_0.double_1 = double_0_2;
        flag2 = true;
      }
      double double_0_3 = Class30.smethod_149(dxf_0, double_1, double_4, double_2_2, double_3_2);
      double double_0_4 = Class30.smethod_149(dxf_0, double_0, double_5, double_2_2, double_3_2);
      if (!flag1)
      {
        if (double_0_4 > 180.0 & Class30.smethod_255(dxf_0, double_0_3, 0.0))
          double_0_3 = 360.0;
        if (double_0_3 < 180.0 & Class30.smethod_255(dxf_0, double_0_4, 0.0))
          double_0_4 = 0.0;
      }
      if (!flag1 & double_0_3 > double_0_4 & (double_0_3 - double_0_4 < 180.0 | Class30.smethod_255(dxf_0, double_0_3 - double_0_4, 180.0)))
      {
        double_3 = double_2_2;
        double_2 = double_3_2;
        dxf_0.double_0 = double_0_3;
        dxf_0.double_1 = double_0_4;
        flag2 = true;
      }
      if (flag1 & double_0_3 > double_0_4 & double_0_3 - double_0_4 > 180.0)
      {
        double_3 = double_2_2;
        double_2 = double_3_2;
        dxf_0.double_0 = double_0_3;
        dxf_0.double_1 = double_0_4;
        flag2 = true;
      }
      if (!flag2 & !flag1 & double_0_2 > double_0_1 & (double_0_2 - double_0_1 < 180.0 | Class30.smethod_255(dxf_0, double_0_2 - double_0_1, 180.0)) && double_0_1 + 360.0 - double_0_2 < 180.0 | Class30.smethod_255(dxf_0, double_0_1 + 360.0 - double_0_2, 180.0))
      {
        dxf_0.double_0 = double_0_1 + 360.0;
        dxf_0.double_1 = double_0_2;
        double_3 = double_2_1;
        double_2 = double_3_1;
        flag2 = true;
      }
      if (!flag2 & flag1 & double_0_2 > double_0_1 && double_0_1 + 360.0 - double_0_2 > 180.0)
      {
        dxf_0.double_0 = double_0_1 + 360.0;
        dxf_0.double_1 = double_0_2;
        double_3 = double_2_1;
        double_2 = double_3_1;
        flag2 = true;
      }
      if (!flag2 & !flag1 & double_0_4 > double_0_3 && double_0_3 + 360.0 - double_0_4 < 180.0 | Class30.smethod_255(dxf_0, double_0_3 + 360.0 - double_0_4, 180.0))
      {
        double_3 = double_2_2;
        double_2 = double_3_2;
        dxf_0.double_0 = double_0_3 + 360.0;
        dxf_0.double_1 = double_0_4;
        flag2 = true;
      }
      if (!flag2 & flag1 & double_0_4 > double_0_3 && double_0_3 + 360.0 - double_0_4 > 180.0)
      {
        double_3 = double_2_2;
        double_2 = double_3_2;
        dxf_0.double_0 = double_0_3 + 360.0;
        dxf_0.double_1 = double_0_4;
        flag2 = true;
      }
    }
    if (short_0 != (short) 3)
      return;
    double double_0_5 = Class30.smethod_149(dxf_0, double_1, double_4, double_2_1, double_3_1);
    double double_0_6 = Class30.smethod_149(dxf_0, double_0, double_5, double_2_1, double_3_1);
    if (!flag1)
    {
      if (double_0_5 > 180.0 & Class30.smethod_255(dxf_0, double_0_6, 0.0))
        double_0_6 = 360.0;
      if (double_0_6 < 180.0 & Class30.smethod_255(dxf_0, double_0_5, 0.0))
        double_0_5 = 0.0;
    }
    if (!flag1 & double_0_6 > double_0_5 & (double_0_6 - double_0_5 < 180.0 | Class30.smethod_255(dxf_0, double_0_6 - double_0_5, 180.0)))
    {
      double_3 = double_2_1;
      double_2 = double_3_1;
      dxf_0.double_0 = double_0_5;
      dxf_0.double_1 = double_0_6;
      flag2 = true;
    }
    if (flag1 & double_0_6 > double_0_5 & double_0_6 - double_0_5 > 180.0)
    {
      double_3 = double_2_1;
      double_2 = double_3_1;
      dxf_0.double_0 = double_0_5;
      dxf_0.double_1 = double_0_6;
      flag2 = true;
    }
    double double_0_7 = Class30.smethod_149(dxf_0, double_1, double_4, double_2_2, double_3_2);
    double double_0_8 = Class30.smethod_149(dxf_0, double_0, double_5, double_2_2, double_3_2);
    if (!flag1)
    {
      if (double_0_7 > 180.0 & Class30.smethod_255(dxf_0, double_0_8, 0.0))
        double_0_8 = 360.0;
      if (double_0_8 < 180.0 & Class30.smethod_255(dxf_0, double_0_7, 0.0))
        double_0_7 = 0.0;
    }
    if (!flag1 & double_0_8 > double_0_7 & (double_0_8 - double_0_7 < 180.0 | Class30.smethod_255(dxf_0, double_0_8 - double_0_7, 180.0)))
    {
      double_3 = double_2_2;
      double_2 = double_3_2;
      dxf_0.double_0 = double_0_7;
      dxf_0.double_1 = double_0_8;
      flag2 = true;
    }
    if (flag1 & double_0_8 > double_0_7 & double_0_8 - double_0_7 > 180.0)
    {
      double_3 = double_2_2;
      double_2 = double_3_2;
      dxf_0.double_0 = double_0_7;
      dxf_0.double_1 = double_0_8;
      flag2 = true;
    }
    if (!flag2 & !flag1 & double_0_5 > double_0_6 & (double_0_5 - double_0_6 < 180.0 | Class30.smethod_255(dxf_0, double_0_5 - double_0_6, 180.0)) && double_0_6 + 360.0 - double_0_5 < 180.0 | Class30.smethod_255(dxf_0, double_0_6 + 360.0 - double_0_5, 180.0))
    {
      dxf_0.double_0 = double_0_5;
      dxf_0.double_1 = double_0_6 + 360.0;
      double_3 = double_2_1;
      double_2 = double_3_1;
      flag2 = true;
    }
    if (!flag2 & flag1 & double_0_5 > double_0_6 && double_0_6 + 360.0 - double_0_5 > 180.0)
    {
      dxf_0.double_0 = double_0_5;
      dxf_0.double_1 = double_0_6 + 360.0;
      double_3 = double_2_1;
      double_2 = double_3_1;
      flag2 = true;
    }
    if (!flag2 & !flag1 & double_0_7 > double_0_8 && double_0_8 + 360.0 - double_0_7 < 180.0 | Class30.smethod_255(dxf_0, double_0_8 + 360.0 - double_0_7, 180.0))
    {
      double_3 = double_2_2;
      double_2 = double_3_2;
      dxf_0.double_0 = double_0_7;
      dxf_0.double_1 = double_0_8 + 360.0;
      flag2 = true;
    }
    if (!(!flag2 & flag1 & double_0_7 > double_0_8) || double_0_8 + 360.0 - double_0_7 <= 180.0)
      return;
    double_3 = double_2_2;
    double_2 = double_3_2;
    dxf_0.double_0 = double_0_7;
    dxf_0.double_1 = double_0_8 + 360.0;
  }

  static void smethod_141(ClipperOffset clipperOffset_0, double double_0)
  {
    clipperOffset_0.list_0 = new List<List<IntPoint>>();
    clipperOffset_0.double_0 = double_0;
    if (Class30.smethod_209(double_0))
    {
      clipperOffset_0.list_0.Capacity = clipperOffset_0.polyNode_0.ChildCount;
      for (int index = 0; index < clipperOffset_0.polyNode_0.ChildCount; ++index)
      {
        PolyNode child = clipperOffset_0.polyNode_0.Childs[index];
        if (child.endType_0 == EndType.etClosedPolygon)
          clipperOffset_0.list_0.Add(child.list_0);
      }
    }
    else
    {
      clipperOffset_0.double_4 = clipperOffset_0.MiterLimit <= 2.0 ? 0.5 : 2.0 / (clipperOffset_0.MiterLimit * clipperOffset_0.MiterLimit);
      double num1 = Math.PI / Math.Acos(1.0 - (clipperOffset_0.ArcTolerance > 0.0 ? (clipperOffset_0.ArcTolerance <= Math.Abs(double_0) * 0.25 ? clipperOffset_0.ArcTolerance : Math.Abs(double_0) * 0.25) : 0.25) / Math.Abs(double_0));
      clipperOffset_0.double_2 = Math.Sin(2.0 * Math.PI / num1);
      clipperOffset_0.double_3 = Math.Cos(2.0 * Math.PI / num1);
      clipperOffset_0.double_5 = num1 / (2.0 * Math.PI);
      if (double_0 < 0.0)
        clipperOffset_0.double_2 = -clipperOffset_0.double_2;
      clipperOffset_0.list_0.Capacity = clipperOffset_0.polyNode_0.ChildCount * 2;
      for (int index1 = 0; index1 < clipperOffset_0.polyNode_0.ChildCount; ++index1)
      {
        PolyNode child = clipperOffset_0.polyNode_0.Childs[index1];
        clipperOffset_0.list_1 = child.list_0;
        int count = clipperOffset_0.list_1.Count;
        if ((count == 0 ? 1 : (double_0 > 0.0 ? 0 : (count < 3 ? 1 : (child.endType_0 != 0 ? 1 : 0)))) == 0)
        {
          clipperOffset_0.list_2 = new List<IntPoint>();
          if (count == 1)
          {
            if (child.joinType_0 == JoinType.jtRound)
            {
              double num2 = 1.0;
              double num3 = 0.0;
              for (int index2 = 1; (double) index2 <= num1; ++index2)
              {
                clipperOffset_0.list_2.Add(new IntPoint(Class30.smethod_150((double) clipperOffset_0.list_1[0].X + num2 * double_0), Class30.smethod_150((double) clipperOffset_0.list_1[0].Y + num3 * double_0)));
                double num4 = num2;
                num2 = num2 * clipperOffset_0.double_3 - clipperOffset_0.double_2 * num3;
                num3 = num4 * clipperOffset_0.double_2 + num3 * clipperOffset_0.double_3;
              }
            }
            else
            {
              double num5 = -1.0;
              double num6 = -1.0;
              for (int index3 = 0; index3 < 4; ++index3)
              {
                clipperOffset_0.list_2.Add(new IntPoint(Class30.smethod_150((double) clipperOffset_0.list_1[0].X + num5 * double_0), Class30.smethod_150((double) clipperOffset_0.list_1[0].Y + num6 * double_0)));
                if (num5 < 0.0)
                  num5 = 1.0;
                else if (num6 < 0.0)
                  num6 = 1.0;
                else
                  num5 = -1.0;
              }
            }
            clipperOffset_0.list_0.Add(clipperOffset_0.list_2);
          }
          else
          {
            clipperOffset_0.list_3.Clear();
            clipperOffset_0.list_3.Capacity = count;
            for (int index4 = 0; index4 < count - 1; ++index4)
              clipperOffset_0.list_3.Add(Class30.smethod_234(clipperOffset_0.list_1[index4], clipperOffset_0.list_1[index4 + 1]));
            if ((child.endType_0 == EndType.etClosedLine ? 1 : (child.endType_0 == EndType.etClosedPolygon ? 1 : 0)) != 0)
              clipperOffset_0.list_3.Add(Class30.smethod_234(clipperOffset_0.list_1[count - 1], clipperOffset_0.list_1[0]));
            else
              clipperOffset_0.list_3.Add(new DoublePoint(clipperOffset_0.list_3[count - 2]));
            if (child.endType_0 == EndType.etClosedPolygon)
            {
              int int_1 = count - 1;
              for (int int_0 = 0; int_0 < count; ++int_0)
                Class30.smethod_121(clipperOffset_0, int_0, ref int_1, child.joinType_0);
              clipperOffset_0.list_0.Add(clipperOffset_0.list_2);
            }
            else if (child.endType_0 == EndType.etClosedLine)
            {
              int int_1 = count - 1;
              for (int int_0 = 0; int_0 < count; ++int_0)
                Class30.smethod_121(clipperOffset_0, int_0, ref int_1, child.joinType_0);
              clipperOffset_0.list_0.Add(clipperOffset_0.list_2);
              clipperOffset_0.list_2 = new List<IntPoint>();
              DoublePoint doublePoint = clipperOffset_0.list_3[count - 1];
              for (int index5 = count - 1; index5 > 0; --index5)
                clipperOffset_0.list_3[index5] = new DoublePoint(-clipperOffset_0.list_3[index5 - 1].X, -clipperOffset_0.list_3[index5 - 1].Y);
              clipperOffset_0.list_3[0] = new DoublePoint(-doublePoint.X, -doublePoint.Y);
              int_1 = 0;
              for (int int_0 = count - 1; int_0 >= 0; --int_0)
                Class30.smethod_121(clipperOffset_0, int_0, ref int_1, child.joinType_0);
              clipperOffset_0.list_0.Add(clipperOffset_0.list_2);
            }
            else
            {
              int int_1 = 0;
              for (int int_0 = 1; int_0 < count - 1; ++int_0)
                Class30.smethod_121(clipperOffset_0, int_0, ref int_1, child.joinType_0);
              IntPoint intPoint;
              if (child.endType_0 == EndType.etOpenButt)
              {
                int index6 = count - 1;
                intPoint = new IntPoint(Class30.smethod_150((double) clipperOffset_0.list_1[index6].X + clipperOffset_0.list_3[index6].X * double_0), Class30.smethod_150((double) clipperOffset_0.list_1[index6].Y + clipperOffset_0.list_3[index6].Y * double_0));
                clipperOffset_0.list_2.Add(intPoint);
                intPoint = new IntPoint(Class30.smethod_150((double) clipperOffset_0.list_1[index6].X - clipperOffset_0.list_3[index6].X * double_0), Class30.smethod_150((double) clipperOffset_0.list_1[index6].Y - clipperOffset_0.list_3[index6].Y * double_0));
                clipperOffset_0.list_2.Add(intPoint);
              }
              else
              {
                int num7 = count - 1;
                int_1 = count - 2;
                clipperOffset_0.double_1 = 0.0;
                clipperOffset_0.list_3[num7] = new DoublePoint(-clipperOffset_0.list_3[num7].X, -clipperOffset_0.list_3[num7].Y);
                if (child.endType_0 == EndType.etOpenSquare)
                  Class30.smethod_210(clipperOffset_0, num7, int_1);
                else
                  Class30.smethod_154(clipperOffset_0, num7, int_1);
              }
              for (int index7 = count - 1; index7 > 0; --index7)
                clipperOffset_0.list_3[index7] = new DoublePoint(-clipperOffset_0.list_3[index7 - 1].X, -clipperOffset_0.list_3[index7 - 1].Y);
              clipperOffset_0.list_3[0] = new DoublePoint(-clipperOffset_0.list_3[1].X, -clipperOffset_0.list_3[1].Y);
              int_1 = count - 1;
              for (int int_0 = int_1 - 1; int_0 > 0; --int_0)
                Class30.smethod_121(clipperOffset_0, int_0, ref int_1, child.joinType_0);
              if (child.endType_0 == EndType.etOpenButt)
              {
                intPoint = new IntPoint(Class30.smethod_150((double) clipperOffset_0.list_1[0].X - clipperOffset_0.list_3[0].X * double_0), Class30.smethod_150((double) clipperOffset_0.list_1[0].Y - clipperOffset_0.list_3[0].Y * double_0));
                clipperOffset_0.list_2.Add(intPoint);
                intPoint = new IntPoint(Class30.smethod_150((double) clipperOffset_0.list_1[0].X + clipperOffset_0.list_3[0].X * double_0), Class30.smethod_150((double) clipperOffset_0.list_1[0].Y + clipperOffset_0.list_3[0].Y * double_0));
                clipperOffset_0.list_2.Add(intPoint);
              }
              else
              {
                int_1 = 1;
                clipperOffset_0.double_1 = 0.0;
                if (child.endType_0 == EndType.etOpenSquare)
                  Class30.smethod_210(clipperOffset_0, 0, 1);
                else
                  Class30.smethod_154(clipperOffset_0, 0, 1);
              }
              clipperOffset_0.list_0.Add(clipperOffset_0.list_2);
            }
          }
        }
      }
    }
  }

  static double smethod_142(buClipper buClipper_0, Class26 class26_0)
  {
    return Class30.smethod_216(class26_0.class27_0, buClipper_0);
  }

  static double smethod_143(IntPoint intPoint_0, IntPoint intPoint_1, IntPoint intPoint_2)
  {
    double num1 = (double) (intPoint_1.Y - intPoint_2.Y);
    double num2 = (double) (intPoint_2.X - intPoint_1.X);
    double num3 = num1 * (double) intPoint_1.X + num2 * (double) intPoint_1.Y;
    double num4 = num1 * (double) intPoint_0.X + num2 * (double) intPoint_0.Y - num3;
    return num4 * num4 / (num1 * num1 + num2 * num2);
  }

  static void smethod_144(Pop3Client pop3Client_0, string string_0)
  {
    byte[] bytes = Encoding.ASCII.GetBytes(string_0 + "\r\n");
    pop3Client_0.method_0().Write(bytes, 0, bytes.Length);
    pop3Client_0.method_0().Flush();
    pop3Client_0.method_3(Class30.smethod_106(pop3Client_0.method_0()));
    Class30.smethod_98(pop3Client_0.method_2());
  }

  static void smethod_145(PolyTree polyTree_0, buClipper buClipper_0)
  {
    polyTree_0.Clear();
    polyTree_0.list_2.Capacity = buClipper_0.list_1.Count;
    for (int index1 = 0; index1 < buClipper_0.list_1.Count; ++index1)
    {
      Class26 class26_0 = buClipper_0.list_1[index1];
      int num = Class30.smethod_258(class26_0.class27_0, buClipper_0);
      if ((!class26_0.bool_1 || num >= 2 ? (class26_0.bool_1 ? 0 : (num < 3 ? 1 : 0)) : 1) == 0)
      {
        Class30.smethod_117(buClipper_0, class26_0);
        PolyNode polyNode = new PolyNode();
        polyTree_0.list_2.Add(polyNode);
        class26_0.polyNode_0 = polyNode;
        polyNode.list_0.Capacity = num;
        Class27 class271 = class26_0.class27_0.class27_1;
        for (int index2 = 0; index2 < num; ++index2)
        {
          polyNode.list_0.Add(class271.intPoint_0);
          class271 = class271.class27_1;
        }
      }
    }
    polyTree_0.list_1.Capacity = buClipper_0.list_1.Count;
    for (int index = 0; index < buClipper_0.list_1.Count; ++index)
    {
      Class26 class26 = buClipper_0.list_1[index];
      if (class26.polyNode_0 != null)
      {
        if (class26.bool_1)
        {
          class26.polyNode_0.IsOpen = true;
          Class30.smethod_212((PolyNode) polyTree_0, class26.polyNode_0);
        }
        else if ((class26.class26_0 == null ? 0 : (class26.class26_0.polyNode_0 != null ? 1 : 0)) != 0)
          Class30.smethod_212(class26.class26_0.polyNode_0, class26.polyNode_0);
        else
          Class30.smethod_212((PolyNode) polyTree_0, class26.polyNode_0);
      }
    }
  }

  static Class22 smethod_146(buClipper buClipper_0, Class22 class22_0)
  {
    return (!(class22_0.class22_0.intPoint_2 == class22_0.intPoint_2) ? 0 : (class22_0.class22_0.class22_2 == null ? 1 : 0)) == 0 ? ((!(class22_0.class22_1.intPoint_2 == class22_0.intPoint_2) ? 0 : (class22_0.class22_1.class22_2 == null ? 1 : 0)) == 0 ? (Class22) null : class22_0.class22_1) : class22_0.class22_0;
  }

  static string smethod_147(
    string string_0,
    ContentDisposition contentDisposition_0,
    ContentType contentType_0)
  {
    if (contentType_0 == null)
      throw new ArgumentNullException("contentType");
    return (contentDisposition_0 == null ? 0 : (contentDisposition_0.FileName != null ? 1 : 0)) == 0 ? (contentType_0.Name == null ? string_0 : contentType_0.Name) : contentDisposition_0.FileName;
  }

  static void smethod_148(Class34.Class38 class38_0, byte[] byte_0)
  {
    int[] numArray1 = new int[16 /*0x10*/];
    int[] numArray2 = new int[16 /*0x10*/];
    for (int index1 = 0; index1 < byte_0.Length; ++index1)
    {
      int index2 = (int) byte_0[index1];
      if (index2 > 0)
        ++numArray1[index2];
    }
    int num1 = 0;
    int length = 512 /*0x0200*/;
    for (int index = 1; index <= 15; ++index)
    {
      numArray2[index] = num1;
      num1 += numArray1[index] << 16 /*0x10*/ - index;
      if (index >= 10)
      {
        int num2 = numArray2[index] & 130944;
        int num3 = num1 & 130944;
        length += num3 - num2 >> 16 /*0x10*/ - index;
      }
    }
    class38_0.short_0 = new short[length];
    int num4 = 512 /*0x0200*/;
    for (int index = 15; index >= 10; --index)
    {
      int num5 = num1 & 130944;
      num1 -= numArray1[index] << 16 /*0x10*/ - index;
      for (int int_0 = num1 & 130944; int_0 < num5; int_0 += 128 /*0x80*/)
      {
        class38_0.short_0[(int) Class30.smethod_176(int_0)] = (short) (-num4 << 4 | index);
        num4 += 1 << index - 9;
      }
    }
    for (int index3 = 0; index3 < byte_0.Length; ++index3)
    {
      int index4 = (int) byte_0[index3];
      if (index4 != 0)
      {
        int int_0 = numArray2[index4];
        int index5 = (int) Class30.smethod_176(int_0);
        if (index4 <= 9)
        {
          do
          {
            class38_0.short_0[index5] = (short) (index3 << 4 | index4);
            index5 += 1 << index4;
          }
          while (index5 < 512 /*0x0200*/);
        }
        else
        {
          int num6 = (int) class38_0.short_0[index5 & 511 /*0x01FF*/];
          int num7 = 1 << (num6 & 15);
          int num8 = -(num6 >> 4);
          do
          {
            class38_0.short_0[num8 | index5 >> 9] = (short) (index3 << 4 | index4);
            index5 += 1 << index4;
          }
          while (index5 < num7);
        }
        numArray2[index4] = int_0 + (1 << 16 /*0x10*/ - index4);
      }
    }
  }

  static double smethod_149(
    buFile.Dxf dxf_0,
    double double_0,
    double double_1,
    double double_2,
    double double_3)
  {
    double double_0_1 = 0.0;
    double double_0_2 = 0.0;
    double num1 = 0.0;
    double num2 = Math.Sqrt((double_0 - double_2) * (double_0 - double_2) + (double_1 - double_3) * (double_1 - double_3));
    if (num2 != 0.0)
    {
      double double_0_3 = (double_0 - double_2) / num2;
      double double_2_1 = (double_1 - double_3) / num2;
      if (Class30.smethod_53(dxf_0, double_0_3, 0.0, double_2_1, 1.0))
        num1 = 90.0;
      else if (Class30.smethod_53(dxf_0, double_0_3, -1.0, double_2_1, 0.0))
        num1 = 180.0;
      else if (Class30.smethod_53(dxf_0, double_0_3, 0.0, double_2_1, -1.0))
        num1 = 270.0;
      else if (Class30.smethod_53(dxf_0, double_0_3, 1.0, double_2_1, 0.0))
      {
        num1 = 0.0;
      }
      else
      {
        if (double_0_3 != 1.0 & double_0_3 != -1.0)
          double_0_1 = Math.Atan(double_0_3 / Math.Sqrt(-1.0 * (double_0_3 * double_0_3) + 1.0)) + 1.5708;
        if (double_2_1 != 1.0 & double_2_1 != -1.0)
          double_0_2 = Math.Atan(double_2_1 / Math.Sqrt(-1.0 * (double_2_1 * double_2_1) + 1.0));
        if (double_0_3 > 0.0 & double_2_1 > 0.0 && double_0_3 < 1.0 & double_2_1 < 1.0)
        {
          num1 = 180.0 - Class30.smethod_193(double_0_1, dxf_0);
          double num3 = 90.0 - Class30.smethod_193(double_0_2, dxf_0);
        }
        if (double_0_3 < 0.0 & double_2_1 > 0.0 && double_0_3 > -1.0 & double_2_1 < 1.0)
        {
          num1 = 180.0 - Class30.smethod_193(double_0_1, dxf_0);
          double num4 = 90.0 - Class30.smethod_193(double_0_2, dxf_0);
        }
        if (double_0_3 < 0.0 & double_2_1 < 0.0 && double_0_3 > -1.0 & double_2_1 > -1.0)
        {
          num1 = 180.0 + Class30.smethod_193(double_0_1, dxf_0);
          double num5 = 270.0 + Class30.smethod_193(double_0_2, dxf_0);
        }
        if (double_0_3 > 0.0 & double_2_1 < 0.0 && double_0_3 < 1.0 & double_2_1 > -1.0)
        {
          num1 = 180.0 + Class30.smethod_193(double_0_1, dxf_0);
          double num6 = 270.0 + Class30.smethod_193(double_0_2, dxf_0);
        }
      }
    }
    return num1;
  }

  static long smethod_150(double double_0)
  {
    return double_0 < 0.0 ? (long) (double_0 - 0.5) : (long) (double_0 + 0.5);
  }

  static buFile.PLYToSchematic.Class21 smethod_151(
    StreamReader streamReader_0,
    buFile.PLYToSchematic.Class20 class20_0)
  {
    buFile.PLYToSchematic.Class21 class21_0 = new buFile.PLYToSchematic.Class21(class20_0.int_0, 10);
    string str;
    while ((str = streamReader_0.ReadLine()) != null)
    {
      string[] strArray = str.Split(' ');
      if (strArray.Length > 6)
      {
        try
        {
          float float_0 = float.Parse(strArray[0], (IFormatProvider) CultureInfo.InvariantCulture);
          float float_1 = float.Parse(strArray[1], (IFormatProvider) CultureInfo.InvariantCulture);
          float float_2 = float.Parse(strArray[2], (IFormatProvider) CultureInfo.InvariantCulture);
          byte byte_0 = byte.Parse(strArray[6], (IFormatProvider) CultureInfo.InvariantCulture);
          byte byte_1 = byte.Parse(strArray[7], (IFormatProvider) CultureInfo.InvariantCulture);
          byte byte_2 = byte.Parse(strArray[8], (IFormatProvider) CultureInfo.InvariantCulture);
          Class30.smethod_172(class21_0, float_0, float_1, float_2, byte_0, byte_1, byte_2);
        }
        catch (Exception ex)
        {
          Console.WriteLine($"[ERROR] Line not well formated : {str} {ex.Message}");
        }
      }
    }
    return class21_0;
  }

  static void smethod_152(ClipperOffset clipperOffset_0)
  {
    if ((clipperOffset_0.intPoint_0.X < 0L ? 0 : (!buClipper.Orientation(clipperOffset_0.polyNode_0.Childs[(int) clipperOffset_0.intPoint_0.X].list_0) ? 1 : 0)) != 0)
    {
      for (int index = 0; index < clipperOffset_0.polyNode_0.ChildCount; ++index)
      {
        PolyNode child = clipperOffset_0.polyNode_0.Childs[index];
        if ((child.endType_0 == EndType.etClosedPolygon ? 1 : (child.endType_0 != EndType.etClosedLine ? 0 : (buClipper.Orientation(child.list_0) ? 1 : 0))) != 0)
          child.list_0.Reverse();
      }
    }
    else
    {
      for (int index = 0; index < clipperOffset_0.polyNode_0.ChildCount; ++index)
      {
        PolyNode child = clipperOffset_0.polyNode_0.Childs[index];
        if ((child.endType_0 != EndType.etClosedLine ? 0 : (!buClipper.Orientation(child.list_0) ? 1 : 0)) != 0)
          child.list_0.Reverse();
      }
    }
  }

  static int smethod_153(int int_0, byte[] byte_0, int int_1, Class34.Class37 class37_0)
  {
    int num1 = class37_0.int_0;
    if (int_0 > class37_0.int_1)
      int_0 = class37_0.int_1;
    else
      num1 = class37_0.int_0 - class37_0.int_1 + int_0 & (int) short.MaxValue;
    int num2 = int_0;
    int length = int_0 - num1;
    if (length > 0)
    {
      Array.Copy((Array) class37_0.byte_0, 32768 /*0x8000*/ - length, (Array) byte_0, int_1, length);
      int_1 += length;
      int_0 = num1;
    }
    Array.Copy((Array) class37_0.byte_0, num1 - int_0, (Array) byte_0, int_1, int_0);
    class37_0.int_1 -= num2;
    if (class37_0.int_1 < 0)
      throw new InvalidOperationException();
    return num2;
  }

  static void smethod_154(ClipperOffset clipperOffset_0, int int_0, int int_1)
  {
    double num1 = Math.Atan2(clipperOffset_0.double_1, clipperOffset_0.list_3[int_1].X * clipperOffset_0.list_3[int_0].X + clipperOffset_0.list_3[int_1].Y * clipperOffset_0.list_3[int_0].Y);
    int num2 = Math.Max((int) Class30.smethod_150(clipperOffset_0.double_5 * Math.Abs(num1)), 1);
    double num3 = clipperOffset_0.list_3[int_1].X;
    double num4 = clipperOffset_0.list_3[int_1].Y;
    for (int index = 0; index < num2; ++index)
    {
      clipperOffset_0.list_2.Add(new IntPoint(Class30.smethod_150((double) clipperOffset_0.list_1[int_0].X + num3 * clipperOffset_0.double_0), Class30.smethod_150((double) clipperOffset_0.list_1[int_0].Y + num4 * clipperOffset_0.double_0)));
      double num5 = num3;
      num3 = num3 * clipperOffset_0.double_3 - clipperOffset_0.double_2 * num4;
      num4 = num5 * clipperOffset_0.double_2 + num4 * clipperOffset_0.double_3;
    }
    clipperOffset_0.list_2.Add(new IntPoint(Class30.smethod_150((double) clipperOffset_0.list_1[int_0].X + clipperOffset_0.list_3[int_0].X * clipperOffset_0.double_0), Class30.smethod_150((double) clipperOffset_0.list_1[int_0].Y + clipperOffset_0.list_3[int_0].Y * clipperOffset_0.double_0)));
  }

  static void smethod_155(buClipper buClipper_0)
  {
    int num = 0;
    while (num < buClipper_0.list_1.Count)
    {
      Class26 class26_1 = buClipper_0.list_1[num++];
      Class27 class270 = class26_1.class27_0;
      if ((class270 == null ? 1 : (class26_1.bool_1 ? 1 : 0)) == 0)
      {
        do
        {
          for (Class27 class27 = class270.class27_0; class27 != class26_1.class27_0; class27 = class27.class27_0)
          {
            if ((!(class270.intPoint_0 == class27.intPoint_0) || class27.class27_0 == class270 ? 0 : (class27.class27_1 != class270 ? 1 : 0)) != 0)
            {
              Class27 class271_1 = class270.class27_1;
              Class27 class271_2 = class27.class27_1;
              class270.class27_1 = class271_2;
              class271_2.class27_0 = class270;
              class27.class27_1 = class271_1;
              class271_1.class27_0 = class27;
              class26_1.class27_0 = class270;
              Class26 class26_2 = Class30.smethod_185((buClipperBase) buClipper_0);
              class26_2.class27_0 = class27;
              Class30.smethod_7(class26_2, buClipper_0);
              if (Class30.smethod_167(class26_2.class27_0, class26_1.class27_0))
              {
                class26_2.bool_0 = !class26_1.bool_0;
                class26_2.class26_0 = class26_1;
                if (buClipper_0.bool_4)
                  buClipper_0.method_2(class26_2, class26_1);
              }
              else if (Class30.smethod_167(class26_1.class27_0, class26_2.class27_0))
              {
                class26_2.bool_0 = class26_1.bool_0;
                class26_1.bool_0 = !class26_2.bool_0;
                class26_2.class26_0 = class26_1.class26_0;
                class26_1.class26_0 = class26_2;
                if (buClipper_0.bool_4)
                  buClipper_0.method_2(class26_1, class26_2);
              }
              else
              {
                class26_2.bool_0 = class26_1.bool_0;
                class26_2.class26_0 = class26_1.class26_0;
                if (buClipper_0.bool_4)
                  buClipper_0.method_1(class26_1, class26_2);
              }
              class27 = class270;
            }
          }
          class270 = class270.class27_0;
        }
        while (class270 != class26_1.class27_0);
      }
    }
  }

  static bool smethod_156(
    ref TriangulationPoint triangulationPoint_0,
    Point2D point2D_0,
    DelaunayTriangle delaunayTriangle_0,
    TriangulationPoint triangulationPoint_1,
    [Out] Point2D point2D_1)
  {
    triangulationPoint_0 = (TriangulationPoint) null;
    bool flag;
    switch (TriangulationUtil.Orient2d(point2D_1, (Point2D) triangulationPoint_1, point2D_0))
    {
      case Orientation.Clockwise:
        triangulationPoint_0 = delaunayTriangle_0.PointCCWFrom(triangulationPoint_1);
        flag = true;
        break;
      case Orientation.AntiClockwise:
        triangulationPoint_0 = delaunayTriangle_0.PointCWFrom(triangulationPoint_1);
        flag = true;
        break;
      case Orientation.Collinear:
        flag = false;
        break;
      default:
        throw new NotImplementedException("Orientation not handled");
    }
    return flag;
  }

  static void smethod_157(
    TriangulationConstraint triangulationConstraint_0,
    AdvancingFrontNode advancingFrontNode_0,
    DTSweepContext dtsweepContext_0)
  {
    if (TriangulationUtil.Orient2d((Point2D) advancingFrontNode_0.Next.Point, (Point2D) advancingFrontNode_0.Next.Next.Point, (Point2D) advancingFrontNode_0.Next.Next.Next.Point) == Orientation.AntiClockwise)
    {
      Class30.smethod_123(triangulationConstraint_0, advancingFrontNode_0.Next, dtsweepContext_0);
    }
    else
    {
      if (TriangulationUtil.Orient2d((Point2D) triangulationConstraint_0.Q, (Point2D) advancingFrontNode_0.Next.Next.Point, (Point2D) triangulationConstraint_0.P) != Orientation.AntiClockwise)
        return;
      Class30.smethod_157(triangulationConstraint_0, advancingFrontNode_0.Next, dtsweepContext_0);
    }
  }

  static bool smethod_158(Class34.Class35 class35_0)
  {
    int num1 = Class30.smethod_231(class35_0.class37_0);
    while (num1 >= 258)
    {
      switch (class35_0.int_4)
      {
        case 7:
          int int_0;
          while (((int_0 = Class30.smethod_266(class35_0.class38_0, class35_0.class36_0)) & -256) == 0)
          {
            Class30.smethod_129(class35_0.class37_0, int_0);
            if (--num1 < 258)
              return true;
          }
          if (int_0 >= 257)
          {
            class35_0.int_6 = Class34.Class35.int_0[int_0 - 257];
            class35_0.int_5 = Class34.Class35.int_1[int_0 - 257];
            goto case 8;
          }
          if (int_0 < 0)
            return false;
          class35_0.class38_1 = (Class34.Class38) null;
          class35_0.class38_0 = (Class34.Class38) null;
          class35_0.int_4 = 2;
          return true;
        case 8:
          if (class35_0.int_5 > 0)
          {
            class35_0.int_4 = 8;
            int num2 = Class30.smethod_292(class35_0.class36_0, class35_0.int_5);
            if (num2 < 0)
              return false;
            Class30.smethod_94(class35_0.class36_0, class35_0.int_5);
            class35_0.int_6 += num2;
          }
          class35_0.int_4 = 9;
          goto case 9;
        case 9:
          int index = Class30.smethod_266(class35_0.class38_1, class35_0.class36_0);
          if (index < 0)
            return false;
          class35_0.int_7 = Class34.Class35.int_2[index];
          class35_0.int_5 = Class34.Class35.int_3[index];
          goto case 10;
        case 10:
          if (class35_0.int_5 > 0)
          {
            class35_0.int_4 = 10;
            int num3 = Class30.smethod_292(class35_0.class36_0, class35_0.int_5);
            if (num3 < 0)
              return false;
            Class30.smethod_94(class35_0.class36_0, class35_0.int_5);
            class35_0.int_7 += num3;
          }
          Class30.smethod_33(class35_0.class37_0, class35_0.int_6, class35_0.int_7);
          num1 -= class35_0.int_6;
          class35_0.int_4 = 7;
          continue;
        default:
          continue;
      }
    }
    return true;
  }

  static void smethod_159(buClipper buClipper_0, long long_0)
  {
    Class23 class23_0;
    while (Class30.smethod_228((buClipperBase) buClipper_0, long_0, ref class23_0))
    {
      Class22 class220 = class23_0.class22_0;
      Class22 class221 = class23_0.class22_1;
      Class27 class27 = (Class27) null;
      if (class220 == null)
      {
        Class30.smethod_47((Class22) null, buClipper_0, class221);
        Class30.smethod_168(class221, buClipper_0);
        if (Class30.smethod_161(class221, buClipper_0))
          class27 = Class30.smethod_246(buClipper_0, class221, class221.intPoint_0);
      }
      else if (class221 == null)
      {
        Class30.smethod_47((Class22) null, buClipper_0, class220);
        Class30.smethod_168(class220, buClipper_0);
        if (Class30.smethod_161(class220, buClipper_0))
          class27 = Class30.smethod_246(buClipper_0, class220, class220.intPoint_0);
        Class30.smethod_232((buClipperBase) buClipper_0, class220.intPoint_2.Y);
      }
      else
      {
        Class30.smethod_47((Class22) null, buClipper_0, class220);
        Class30.smethod_47(class220, buClipper_0, class221);
        Class30.smethod_168(class220, buClipper_0);
        class221.int_1 = class220.int_1;
        class221.int_2 = class220.int_2;
        if (Class30.smethod_161(class220, buClipper_0))
          class27 = Class30.smethod_230(buClipper_0, class220, class221, class220.intPoint_0);
        Class30.smethod_232((buClipperBase) buClipper_0, class220.intPoint_2.Y);
      }
      if (class221 != null)
      {
        if (Class30.smethod_67(class221))
        {
          if (class221.class22_2 != null)
            Class30.smethod_232((buClipperBase) buClipper_0, class221.class22_2.intPoint_2.Y);
          Class30.smethod_11(buClipper_0, class221);
        }
        else
          Class30.smethod_232((buClipperBase) buClipper_0, class221.intPoint_2.Y);
      }
      if ((class220 == null ? 1 : (class221 == null ? 1 : 0)) == 0)
      {
        if ((class27 == null || !Class30.smethod_67(class221) || buClipper_0.list_4.Count <= 0 ? 0 : (class221.int_0 != 0 ? 1 : 0)) != 0)
        {
          for (int index = 0; index < buClipper_0.list_4.Count; ++index)
          {
            Class28 class28 = buClipper_0.list_4[index];
            long x1 = class28.class27_0.intPoint_0.X;
            long x2 = class28.intPoint_0.X;
            long x3 = class221.intPoint_0.X;
            if (Class30.smethod_97(class221.intPoint_2.X, buClipper_0, x2, x1, x3))
            {
              Class27 class270 = class28.class27_0;
              Class30.smethod_22(class28.intPoint_0, class27, class270, buClipper_0);
            }
          }
        }
        int num1;
        if (class220.int_3 >= 0 && class220.class22_4 != null && class220.class22_4.intPoint_1.X == class220.intPoint_0.X && class220.class22_4.int_3 >= 0)
        {
          IntPoint intPoint1_1 = class220.class22_4.intPoint_1;
          IntPoint intPoint2_1 = class220.class22_4.intPoint_2;
          IntPoint intPoint1_2 = class220.intPoint_1;
          IntPoint intPoint2_2 = class220.intPoint_2;
          bool bool0 = buClipper_0.bool_0;
          if (Class30.smethod_132(intPoint1_2, intPoint1_1, intPoint2_1, intPoint2_2, bool0) && class220.int_0 != 0)
          {
            num1 = class220.class22_4.int_0 != 0 ? 1 : 0;
            goto label_28;
          }
        }
        num1 = 0;
label_28:
        if (num1 != 0)
        {
          Class27 class27_0 = Class30.smethod_246(buClipper_0, class220.class22_4, class220.intPoint_0);
          Class30.smethod_22(class220.intPoint_2, class27_0, class27, buClipper_0);
        }
        if (class220.class22_3 != class221)
        {
          int num2;
          if (class221.int_3 >= 0 && class221.class22_4.int_3 >= 0)
          {
            IntPoint intPoint1_3 = class221.class22_4.intPoint_1;
            IntPoint intPoint2_3 = class221.class22_4.intPoint_2;
            IntPoint intPoint1_4 = class221.intPoint_1;
            IntPoint intPoint2_4 = class221.intPoint_2;
            bool bool0 = buClipper_0.bool_0;
            if (Class30.smethod_132(intPoint1_4, intPoint1_3, intPoint2_3, intPoint2_4, bool0) && class221.int_0 != 0)
            {
              num2 = class221.class22_4.int_0 != 0 ? 1 : 0;
              goto label_35;
            }
          }
          num2 = 0;
label_35:
          if (num2 != 0)
          {
            Class27 class27_0 = Class30.smethod_246(buClipper_0, class221.class22_4, class221.intPoint_0);
            Class30.smethod_22(class221.intPoint_2, class27_0, class27, buClipper_0);
          }
          Class22 class223 = class220.class22_3;
          if (class223 != null)
          {
            for (; class223 != class221; class223 = class223.class22_3)
              Class30.smethod_287(class220.intPoint_1, buClipper_0, class221, class223);
          }
        }
      }
    }
  }

  static AdvancingFrontNode smethod_160(
    DTSweepContext dtsweepContext_0,
    TriangulationPoint triangulationPoint_0,
    AdvancingFrontNode advancingFrontNode_0)
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
      dtsweepContext_0.DebugContext.ActiveNode = advancingFrontNode;
    if (!Class30.smethod_226(dtsweepContext_0, delaunayTriangle))
      dtsweepContext_0.MapTriangleToNodes(delaunayTriangle);
    return advancingFrontNode;
  }

  static bool smethod_161(Class22 class22_0, buClipper buClipper_0)
  {
    PolyFillType polyFillType1;
    PolyFillType polyFillType2;
    if (class22_0.polyType_0 == PolyType.ptSubject)
    {
      polyFillType1 = buClipper_0.polyFillType_1;
      polyFillType2 = buClipper_0.polyFillType_0;
    }
    else
    {
      polyFillType1 = buClipper_0.polyFillType_0;
      polyFillType2 = buClipper_0.polyFillType_1;
    }
    bool flag;
    switch (polyFillType1)
    {
      case PolyFillType.pftEvenOdd:
        if ((class22_0.int_0 != 0 ? 0 : (class22_0.int_1 != 1 ? 1 : 0)) != 0)
        {
          flag = false;
          goto label_37;
        }
        break;
      case PolyFillType.pftNonZero:
        if (Math.Abs(class22_0.int_1) != 1)
        {
          flag = false;
          goto label_37;
        }
        break;
      case PolyFillType.pftPositive:
        if (class22_0.int_1 != 1)
        {
          flag = false;
          goto label_37;
        }
        break;
      default:
        if (class22_0.int_1 != -1)
        {
          flag = false;
          goto label_37;
        }
        break;
    }
    switch (buClipper_0.clipType_0)
    {
      case ClipType.ctIntersection:
        switch (polyFillType2)
        {
          case PolyFillType.pftEvenOdd:
          case PolyFillType.pftNonZero:
            flag = class22_0.int_2 != 0;
            break;
          case PolyFillType.pftPositive:
            flag = class22_0.int_2 > 0;
            break;
          default:
            flag = class22_0.int_2 < 0;
            break;
        }
        break;
      case ClipType.ctUnion:
        switch (polyFillType2)
        {
          case PolyFillType.pftEvenOdd:
          case PolyFillType.pftNonZero:
            flag = class22_0.int_2 == 0;
            break;
          case PolyFillType.pftPositive:
            flag = class22_0.int_2 <= 0;
            break;
          default:
            flag = class22_0.int_2 >= 0;
            break;
        }
        break;
      case ClipType.ctDifference:
        if (class22_0.polyType_0 == PolyType.ptSubject)
        {
          switch (polyFillType2)
          {
            case PolyFillType.pftEvenOdd:
            case PolyFillType.pftNonZero:
              flag = class22_0.int_2 == 0;
              break;
            case PolyFillType.pftPositive:
              flag = class22_0.int_2 <= 0;
              break;
            default:
              flag = class22_0.int_2 >= 0;
              break;
          }
        }
        else
        {
          switch (polyFillType2)
          {
            case PolyFillType.pftEvenOdd:
            case PolyFillType.pftNonZero:
              flag = class22_0.int_2 != 0;
              break;
            case PolyFillType.pftPositive:
              flag = class22_0.int_2 > 0;
              break;
            default:
              flag = class22_0.int_2 < 0;
              break;
          }
        }
        break;
      case ClipType.ctXor:
        if (class22_0.int_0 == 0)
        {
          switch (polyFillType2)
          {
            case PolyFillType.pftEvenOdd:
            case PolyFillType.pftNonZero:
              flag = class22_0.int_2 == 0;
              break;
            case PolyFillType.pftPositive:
              flag = class22_0.int_2 <= 0;
              break;
            default:
              flag = class22_0.int_2 >= 0;
              break;
          }
        }
        else
        {
          flag = true;
          break;
        }
        break;
      default:
        flag = true;
        break;
    }
label_37:
    return flag;
  }

  static void smethod_162(DelaunayTriangle delaunayTriangle_0)
  {
    TriangulationPoint point = delaunayTriangle_0.Points[2];
    delaunayTriangle_0.Points[2] = delaunayTriangle_0.Points[1];
    delaunayTriangle_0.Points[1] = delaunayTriangle_0.Points[0];
    delaunayTriangle_0.Points[0] = point;
  }

  static void smethod_163(buClipper buClipper_0)
  {
    Class22 class22_0;
    while (Class30.smethod_298(buClipper_0, ref class22_0))
      Class30.smethod_211(buClipper_0, class22_0);
  }

  static void smethod_164(Class22 class22_0, Class22 class22_1)
  {
    Enum2 enum20 = class22_0.enum2_0;
    class22_0.enum2_0 = class22_1.enum2_0;
    class22_1.enum2_0 = enum20;
  }

  static KeyValuePair<string, string> smethod_165(string string_0)
  {
    if (string_0 == null)
      throw new ArgumentNullException("rawHeader");
    string key = string.Empty;
    string str = string.Empty;
    int length = string_0.IndexOf(':');
    if ((length < 0 ? 0 : (string_0.Length >= length + 1 ? 1 : 0)) != 0)
    {
      key = string_0.Substring(0, length).Trim();
      str = string_0.Substring(length + 1).Trim();
    }
    return new KeyValuePair<string, string>(key, str);
  }

  static string smethod_166(string string_0)
  {
    string_0 = string_0 != null ? Class30.smethod_115(string_0) : throw new ArgumentNullException("input");
    return Regex.Replace(string_0, "[\0-\b\v\f\u000E-\u001F\u007F]", "");
  }

  static bool smethod_167(Class27 class27_0, Class27 class27_1)
  {
    Class27 class27 = class27_0;
    int num;
    do
    {
      num = Class30.smethod_248(class27_1, class27.intPoint_0);
      if (num < 0)
        class27 = class27.class27_0;
      else
        goto label_3;
    }
    while (class27 != class27_0);
    goto label_4;
label_3:
    bool flag = num > 0;
    goto label_5;
label_4:
    flag = true;
label_5:
    return flag;
  }

  static void smethod_168(Class22 class22_0, buClipper buClipper_0)
  {
    Class22 class224_1 = class22_0.class22_4;
    while ((class224_1 == null ? 0 : (class224_1.polyType_0 != class22_0.polyType_0 ? 1 : (class224_1.int_0 == 0 ? 1 : 0))) != 0)
      class224_1 = class224_1.class22_4;
    Class22 class22;
    if (class224_1 == null)
    {
      PolyFillType polyFillType = class22_0.polyType_0 == PolyType.ptSubject ? buClipper_0.polyFillType_1 : buClipper_0.polyFillType_0;
      class22_0.int_1 = class22_0.int_0 != 0 ? class22_0.int_0 : (polyFillType == PolyFillType.pftNegative ? -1 : 1);
      class22_0.int_2 = 0;
      class22 = buClipper_0.class22_0;
    }
    else if ((class22_0.int_0 != 0 ? 0 : (buClipper_0.clipType_0 != ClipType.ctUnion ? 1 : 0)) != 0)
    {
      class22_0.int_1 = 1;
      class22_0.int_2 = class224_1.int_2;
      class22 = class224_1.class22_3;
    }
    else if (Class30.smethod_273(buClipper_0, class22_0))
    {
      if (class22_0.int_0 == 0)
      {
        bool flag = true;
        for (Class22 class224_2 = class224_1.class22_4; class224_2 != null; class224_2 = class224_2.class22_4)
        {
          if ((class224_2.polyType_0 != class224_1.polyType_0 ? 0 : (class224_2.int_0 != 0 ? 1 : 0)) != 0)
            flag = !flag;
        }
        class22_0.int_1 = flag ? 0 : 1;
      }
      else
        class22_0.int_1 = class22_0.int_0;
      class22_0.int_2 = class224_1.int_2;
      class22 = class224_1.class22_3;
    }
    else
    {
      class22_0.int_1 = class224_1.int_1 * class224_1.int_0 >= 0 ? (class22_0.int_0 != 0 ? (class224_1.int_0 * class22_0.int_0 >= 0 ? class224_1.int_1 + class22_0.int_0 : class224_1.int_1) : (class224_1.int_1 < 0 ? class224_1.int_1 - 1 : class224_1.int_1 + 1)) : (Math.Abs(class224_1.int_1) <= 1 ? (class22_0.int_0 == 0 ? 1 : class22_0.int_0) : (class224_1.int_0 * class22_0.int_0 >= 0 ? class224_1.int_1 + class22_0.int_0 : class224_1.int_1));
      class22_0.int_2 = class224_1.int_2;
      class22 = class224_1.class22_3;
    }
    if (Class30.smethod_81(buClipper_0, class22_0))
    {
      for (; class22 != class22_0; class22 = class22.class22_3)
      {
        if (class22.int_0 != 0)
          class22_0.int_2 = class22_0.int_2 == 0 ? 1 : 0;
      }
    }
    else
    {
      for (; class22 != class22_0; class22 = class22.class22_3)
        class22_0.int_2 += class22.int_0;
    }
  }

  static MessagePart smethod_169(byte[] byte_0)
  {
    byte[] byte_0_1;
    MessageHeader messageHeader_0;
    Class30.smethod_191(ref byte_0_1, out messageHeader_0, byte_0);
    return new MessagePart(byte_0_1, messageHeader_0);
  }

  static string smethod_170(string string_0, Encoding encoding_0)
  {
    if (string_0 == null)
      throw new ArgumentNullException("toDecode");
    return encoding_0 != null ? encoding_0.GetString(Class30.smethod_297(string_0, true)) : throw new ArgumentNullException("encoding");
  }

  static void smethod_171(int int_0, Class34.Class36 class36_0, int int_1, byte[] byte_0)
  {
    if (class36_0.int_0 < class36_0.int_1)
      throw new InvalidOperationException();
    int num = int_0 + int_1;
    if (0 > int_0 || int_0 > num || num > byte_0.Length)
      throw new ArgumentOutOfRangeException();
    if ((int_1 & 1) != 0)
    {
      class36_0.uint_0 |= (uint) (((int) byte_0[int_0++] & (int) byte.MaxValue) << class36_0.int_2);
      class36_0.int_2 += 8;
    }
    class36_0.byte_0 = byte_0;
    class36_0.int_0 = int_0;
    class36_0.int_1 = num;
  }

  static void smethod_172(
    buFile.PLYToSchematic.Class21 class21_0,
    float float_0,
    float float_1,
    float float_2,
    byte byte_0,
    byte byte_1,
    byte byte_2)
  {
    class21_0.list_0.Add(new Pnt3D((double) float_0, (double) float_1, (double) float_2));
    class21_0.list_2.Add(Color.FromArgb((int) byte_0, (int) byte_1, (int) byte_2));
  }

  static int smethod_173(Class34.Class36 class36_0, byte[] byte_0, int int_0, int int_1)
  {
    int num1 = 0;
    while (class36_0.int_2 > 0 && int_1 > 0)
    {
      byte_0[int_0++] = (byte) class36_0.uint_0;
      class36_0.uint_0 >>= 8;
      class36_0.int_2 -= 8;
      --int_1;
      ++num1;
    }
    if (int_1 == 0)
      return num1;
    int num2 = class36_0.int_1 - class36_0.int_0;
    if (int_1 > num2)
      int_1 = num2;
    Array.Copy((Array) class36_0.byte_0, class36_0.int_0, (Array) byte_0, int_0, int_1);
    class36_0.int_0 += int_1;
    if ((class36_0.int_0 - class36_0.int_1 & 1) != 0)
    {
      Class34.Class36 class36_1 = class36_0;
      byte[] byte0 = class36_0.byte_0;
      Class34.Class36 class36_2 = class36_0;
      int int0 = class36_0.int_0;
      int num3 = int0 + 1;
      class36_2.int_0 = num3;
      int index = int0;
      int num4 = (int) byte0[index] & (int) byte.MaxValue;
      class36_1.uint_0 = (uint) num4;
      class36_0.int_2 = 8;
    }
    return num1 + int_1;
  }

  static string smethod_174(int int_0)
  {
    int num1 = int_0;
    byte[] byte0_1 = Class32.byte_0;
    int index1 = num1;
    int index2 = index1 + 1;
    int num2 = (int) byte0_1[index1];
    int count;
    if ((num2 & 128 /*0x80*/) == 0)
    {
      count = num2;
      if (count == 0)
        return string.Empty;
    }
    else if ((num2 & 64 /*0x40*/) == 0)
    {
      count = ((num2 & 63 /*0x3F*/) << 8) + (int) Class32.byte_0[index2++];
    }
    else
    {
      int num3 = (num2 & 31 /*0x1F*/) << 24;
      byte[] byte0_2 = Class32.byte_0;
      int index3 = index2;
      int num4 = index3 + 1;
      int num5 = (int) byte0_2[index3] << 16 /*0x10*/;
      int num6 = num3 + num5;
      byte[] byte0_3 = Class32.byte_0;
      int index4 = num4;
      int num7 = index4 + 1;
      int num8 = (int) byte0_3[index4] << 8;
      int num9 = num6 + num8;
      byte[] byte0_4 = Class32.byte_0;
      int index5 = num7;
      index2 = index5 + 1;
      int num10 = (int) byte0_4[index5];
      count = num9 + num10;
    }
    try
    {
      byte[] bytes = Convert.FromBase64String(Encoding.UTF8.GetString(Class32.byte_0, index2, count));
      string string_0 = string.Intern(Encoding.UTF8.GetString(bytes, 0, bytes.Length));
      if (Class32.bool_0)
        Class30.smethod_64(string_0, int_0);
      return string_0;
    }
    catch
    {
      return (string) null;
    }
  }

  static AdvancingFrontNode smethod_175(AdvancingFront advancingFront_0, double double_0)
  {
    AdvancingFrontNode advancingFrontNode1 = advancingFront_0.head;
    AdvancingFrontNode advancingFrontNode2;
    if (double_0 < advancingFrontNode1.Value)
    {
      while ((advancingFrontNode1 = advancingFrontNode1.Prev) != null)
      {
        if (double_0 >= advancingFrontNode1.Value)
        {
          advancingFront_0.head = advancingFrontNode1;
          advancingFrontNode2 = advancingFrontNode1;
          goto label_8;
        }
      }
    }
    else
    {
      while ((advancingFrontNode1 = advancingFrontNode1.Next) != null)
      {
        if (double_0 < advancingFrontNode1.Value)
        {
          advancingFront_0.head = advancingFrontNode1.Prev;
          advancingFrontNode2 = advancingFrontNode1.Prev;
          goto label_8;
        }
      }
    }
    advancingFrontNode2 = (AdvancingFrontNode) null;
label_8:
    return advancingFrontNode2;
  }

  static short smethod_176(int int_0)
  {
    return (short) ((int) Class34.Class40.byte_0[int_0 & 15] << 12 | (int) Class34.Class40.byte_0[int_0 >> 4 & 15] << 8 | (int) Class34.Class40.byte_0[int_0 >> 8 & 15] << 4 | (int) Class34.Class40.byte_0[int_0 >> 12]);
  }

  static int smethod_177(Class34.Class37 class37_0) => class37_0.int_1;

  static byte[] smethod_178(buPop3.Mime.Header.ContentTransferEncoding contentTransferEncoding_0, byte[] byte_0)
  {
    if (byte_0 == null)
      throw new ArgumentNullException("messageBody");
    byte[] numArray;
    switch (contentTransferEncoding_0)
    {
      case buPop3.Mime.Header.ContentTransferEncoding.SevenBit:
      case buPop3.Mime.Header.ContentTransferEncoding.EightBit:
      case buPop3.Mime.Header.ContentTransferEncoding.Binary:
        numArray = byte_0;
        break;
      case buPop3.Mime.Header.ContentTransferEncoding.QuotedPrintable:
        numArray = Class30.smethod_275(Encoding.ASCII.GetString(byte_0));
        break;
      case buPop3.Mime.Header.ContentTransferEncoding.Base64:
        numArray = Class30.smethod_87(Encoding.ASCII.GetString(byte_0));
        break;
      default:
        throw new ArgumentOutOfRangeException("contentTransferEncoding");
    }
    return numArray;
  }

  static string smethod_179(string string_0)
  {
    string_0 = string_0 != null ? Regex.Replace(string_0, "(?<first>\\=\\?(?<Charset>\\S+?)\\?(?<Encoding>\\w)\\?(?<Content>.+?)\\?\\=)\\s+(?<second>\\=\\?(?<Charset>\\S+?)\\?(?<Encoding>\\w)\\?(?<Content>.+?)\\?\\=)", "${first}${second}") : throw new ArgumentNullException("encodedWords");
    string_0 = Regex.Replace(string_0, "(?<first>\\=\\?(?<Charset>\\S+?)\\?(?<Encoding>\\w)\\?(?<Content>.+?)\\?\\=)\\s+(?<second>\\=\\?(?<Charset>\\S+?)\\?(?<Encoding>\\w)\\?(?<Content>.+?)\\?\\=)", "${first}${second}");
    string str1 = string_0;
    foreach (Match match in Regex.Matches(string_0, "\\=\\?(?<Charset>\\S+?)\\?(?<Encoding>\\w)\\?(?<Content>.+?)\\?\\="))
    {
      if (match.Success)
      {
        string oldValue = match.Value;
        string string_0_1 = match.Groups["Content"].Value;
        string str2 = match.Groups["Encoding"].Value;
        Encoding encoding_0 = Class30.smethod_224(match.Groups["Charset"].Value);
        string newValue;
        switch (str2.ToUpperInvariant())
        {
          case "B":
            newValue = Class30.smethod_30(string_0_1, encoding_0);
            break;
          case "Q":
            newValue = Class30.smethod_170(string_0_1, encoding_0);
            break;
          default:
            throw new ArgumentException($"The encoding {str2} was not recognized");
        }
        str1 = str1.Replace(oldValue, newValue);
      }
    }
    return str1;
  }

  static byte[] smethod_180(string string_0)
  {
    if (string_0 == null)
      throw new ArgumentNullException("decode");
    if (string_0.Length != 3)
      throw new ArgumentException("decode must have length 3", "decode");
    if (string_0[0] != '=')
      throw new ArgumentException("decode must start with an equal sign", "decode");
    if (string_0.Contains("\r\n"))
      return new byte[0];
    try
    {
      return new byte[1]
      {
        Convert.ToByte(string_0.Substring(1), 16 /*0x10*/)
      };
    }
    catch (FormatException ex)
    {
      return Encoding.ASCII.GetBytes(string_0);
    }
  }

  static bool smethod_181(
    DelaunayTriangle delaunayTriangle_0,
    TriangulationPoint triangulationPoint_0,
    TriangulationPoint triangulationPoint_1)
  {
    int index = delaunayTriangle_0.EdgeIndex(triangulationPoint_0, triangulationPoint_1);
    bool flag;
    if (index == -1)
    {
      flag = false;
    }
    else
    {
      delaunayTriangle_0.MarkConstrainedEdge(index);
      delaunayTriangle_0 = delaunayTriangle_0.Neighbors[index];
      delaunayTriangle_0?.MarkConstrainedEdge(triangulationPoint_0, triangulationPoint_1);
      flag = true;
    }
    return flag;
  }

  static bool smethod_182(
    string string_0,
    string string_1,
    List<string> list_0,
    List<string> list_1,
    List<double> list_2)
  {
    if (list_1.Count > 0 & list_0.Count > 0)
    {
      for (int index1 = 0; index1 <= list_1.Count - 1; ++index1)
      {
        double num1 = 0.0;
        double num2 = 0.0;
        double num3 = 0.0;
        for (int startIndex = 0; startIndex <= list_1[index1].Length - 1; ++startIndex)
        {
          double num4 = (double) Convert.ToByte(Convert.ToChar(list_1[index1].Substring(startIndex, 1)));
          num1 += num4 * 17.92;
        }
        for (int startIndex = 0; startIndex <= list_0[0].Length - 1; ++startIndex)
        {
          double num5 = (double) Convert.ToByte(Convert.ToChar(list_0[0].Substring(startIndex, 1)));
          num2 += num5 * 47.93;
        }
        for (int startIndex = 0; startIndex <= string_1.Length - 1; ++startIndex)
        {
          double num6 = (double) Convert.ToByte(Convert.ToChar(string_1.Substring(startIndex, 1)));
          num3 += num6 * 51.95;
        }
        double num7 = (num1 + num2 + num3) * 9.912;
        for (int index2 = 0; index2 <= list_2.Count - 1; ++index2)
        {
          if (Math.Abs(list_2[index2] - num7) < 0.0001)
            return true;
        }
      }
      throw new RegisterException(string_0);
    }
    throw new RegisterException(string_0);
  }

  static void smethod_183(Contour contour_0, Contour contour_1)
  {
    contour_1.parent = (ITriangulatable) contour_0;
    contour_0.list_0.Add(contour_1);
  }

  static int smethod_184(Class34.Class36 class36_0) => class36_0.int_2;

  static Class26 smethod_185(buClipperBase buClipperBase_0)
  {
    Class26 class26 = new Class26();
    class26.int_0 = -1;
    class26.bool_0 = false;
    class26.bool_1 = false;
    class26.class26_0 = (Class26) null;
    class26.class27_0 = (Class27) null;
    class26.class27_1 = (Class27) null;
    class26.polyNode_0 = (PolyNode) null;
    buClipperBase_0.list_1.Add(class26);
    class26.int_0 = buClipperBase_0.list_1.Count - 1;
    return class26;
  }

  static void smethod_186(
    ref List<eEntities> list_0,
    buFile.Cf2 cf2_0,
    ref eEntities eEntities_0,
    string[] string_0)
  {
    Pnt3D pnt3D1 = new Pnt3D();
    Pnt3D pnt3D2 = new Pnt3D();
    Pnt3D pnt3D3 = new Pnt3D();
    Cf2FileProperties cf2FileProperties = new Cf2FileProperties();
    double num1 = 0.0;
    double num2 = 0.0;
    double XY = 0.0;
    double XZ = 0.0;
    double YZ = 0.0;
    double num3 = 0.0;
    double num4 = 0.0;
    double num5 = 0.0;
    if (buNumeric.IsNumeric(string_0[1]))
      num5 = double.Parse(string_0[1]);
    if (buNumeric.IsNumeric(string_0[2]))
      num3 = double.Parse(string_0[2]);
    if (buNumeric.IsNumeric(string_0[3]))
      num4 = double.Parse(string_0[3]);
    bool flag = false;
    for (int index = 0; index <= cf2_0.FileDefinations.Count - 1; ++index)
    {
      if (cf2_0.FileDefinations[index].Cf2CodeMatchType == num3 & cf2_0.FileDefinations[index].PtIndex == num5)
      {
        cf2FileProperties = new Cf2FileProperties(cf2_0.FileDefinations[index]);
        flag = true;
        if (cf2FileProperties.LayerIndex < 0)
          cf2FileProperties.LayerIndex = index;
      }
    }
    Pnt3D pnt3D4 = new Pnt3D(double.Parse(string_0[4], (IFormatProvider) buSystem.CI), double.Parse(string_0[5], (IFormatProvider) buSystem.CI));
    Pnt3D PntEnd = new Pnt3D(double.Parse(string_0[6], (IFormatProvider) buSystem.CI), double.Parse(string_0[7], (IFormatProvider) buSystem.CI));
    Pnt3D pnt3D5 = new Pnt3D(double.Parse(string_0[8], (IFormatProvider) buSystem.CI), double.Parse(string_0[9], (IFormatProvider) buSystem.CI));
    double Radius = buAppCalc.cVector.Length3D(pnt3D4, pnt3D5);
    int num6 = int.Parse(string_0[10], (IFormatProvider) buSystem.CI);
    int num7 = int.Parse(string_0[11]);
    double num8 = double.Parse(string_0[12]);
    if (num6 > 0)
    {
      num1 = buAppCalc.cVector.PointAngle(pnt3D4, pnt3D5, ref XY, ref XZ, ref YZ);
      num2 = buAppCalc.cVector.PointAngle(PntEnd, pnt3D5, ref XY, ref XZ, ref YZ);
    }
    if (num6 < 0)
    {
      num2 = buAppCalc.cVector.PointAngle(pnt3D4, pnt3D5, ref XY, ref XZ, ref YZ);
      num1 = buAppCalc.cVector.PointAngle(PntEnd, pnt3D5, ref XY, ref XZ, ref YZ);
    }
    if (num1 == num2)
    {
      num1 = 0.0;
      num2 = 360.0;
    }
    if (num1 > num2)
      num2 += 360.0;
    if (num7 > 0 & num8 >= cf2_0.BridgeMinLimit & num8 <= cf2_0.BridgeMaxLimit)
    {
      double Length = buAppCalc.cVector.ArcCircumference(Radius, num1, num2) / (double) num7;
      List<eArc> CalculatedArcs = new List<eArc>();
      buAppCalc.cVector.ArcToArc(pnt3D5, Radius, num1, num2, Length, new WorkPlane(), ref CalculatedArcs);
      for (int index = 0; index <= CalculatedArcs.Count - 1; ++index)
      {
        double num9 = buAppCalc.cVector.ArcCircumference(Radius, 0.0, 360.0);
        double num10 = num8 * 360.0 / num9;
        double num11 = (CalculatedArcs[index].StartAngle + CalculatedArcs[index].EndAngle) / 2.0;
        eArc eArc = new eArc(pnt3D5, Radius, num11 - num10 / 2.0, num11 + num10 / 2.0, new WorkPlane());
        eArc.Diemaker = new DiemakerData();
        eArc.Diemaker.Pt = cf2FileProperties.PtRealValue;
        eArc.Diemaker.RuleHeight = num4;
        eArc.Diemaker.DiemakerType = cf2FileProperties.CodeType;
        eArc.Diemaker.IsBridge = true;
        eArc.Diemaker.DiemakerTYpeAsInteger = Convert.ToInt32(num3);
        eArc.dispColor = cf2FileProperties.Color;
        eArc.dispThickness = (float) cf2FileProperties.Thickness;
        if (!flag)
          eArc.Diemaker.Pt = num5;
        if (cf2_0.FoundBridgeProperties.LayerIndex >= 0)
          eArc.LayerIndex = cf2_0.FoundBridgeProperties.LayerIndex;
        list_0.Add((eEntities) eArc);
      }
    }
    if (num1 != num2)
    {
      eEntities_0 = (eEntities) new eArc(pnt3D5, Radius, num1, num2, new WorkPlane());
      eEntities_0.Diemaker = new DiemakerData();
      eEntities_0.Diemaker.Pt = cf2FileProperties.PtRealValue;
      eEntities_0.Diemaker.RuleHeight = num4;
      eEntities_0.Diemaker.DiemakerType = cf2FileProperties.CodeType;
      eEntities_0.Diemaker.DiemakerTYpeAsInteger = Convert.ToInt32(num3);
      eEntities_0.dispColor = cf2FileProperties.Color;
      eEntities_0.dispThickness = (float) cf2FileProperties.Thickness;
      if (!flag)
        eEntities_0.Diemaker.Pt = num5;
      if (cf2FileProperties.LayerIndex >= 0)
        eEntities_0.LayerIndex = cf2FileProperties.LayerIndex;
      if (!(cf2_0.Layers.Count > 0 & cf2FileProperties.LayerIndex >= 0 & cf2FileProperties.LayerIndex <= cf2_0.Layers.Count - 1))
        return;
      eEntities_0.LayerIndex = cf2FileProperties.LayerIndex;
    }
    else
    {
      eEntities_0 = (eEntities) new eCircle(pnt3D5, Radius, new WorkPlane());
      eEntities_0.Diemaker = new DiemakerData();
      eEntities_0.Diemaker.Pt = cf2FileProperties.PtRealValue;
      eEntities_0.Diemaker.RuleHeight = num4;
      eEntities_0.Diemaker.DiemakerType = cf2FileProperties.CodeType;
      eEntities_0.Diemaker.DiemakerTYpeAsInteger = Convert.ToInt32(num3);
      eEntities_0.dispColor = cf2FileProperties.Color;
      eEntities_0.dispThickness = (float) cf2FileProperties.Thickness;
      if (!flag)
        eEntities_0.Diemaker.Pt = num5;
      if (cf2FileProperties.LayerIndex >= 0)
        eEntities_0.LayerIndex = cf2FileProperties.LayerIndex;
      if (!(cf2_0.Layers.Count > 0 & cf2FileProperties.LayerIndex >= 0 & cf2FileProperties.LayerIndex <= cf2_0.Layers.Count - 1))
        return;
      eEntities_0.LayerIndex = cf2FileProperties.LayerIndex;
    }
  }

  static void smethod_187(
    AdvancingFrontNode advancingFrontNode_0,
    AdvancingFrontNode advancingFrontNode_1,
    DTSweepContext dtsweepContext_0)
  {
    AdvancingFrontNode advancingFrontNode = advancingFrontNode_1;
    while (advancingFrontNode_0 != dtsweepContext_0.Front.Tail)
    {
      if (dtsweepContext_0.IsDebugEnabled)
        dtsweepContext_0.DebugContext.ActiveNode = advancingFrontNode_0;
      if (TriangulationUtil.Orient2d((Point2D) advancingFrontNode_1.Point, (Point2D) advancingFrontNode_0.Point, (Point2D) advancingFrontNode_0.Next.Point) == Orientation.AntiClockwise)
      {
        Class30.smethod_51(dtsweepContext_0, advancingFrontNode_0);
        advancingFrontNode_0 = advancingFrontNode_0.Next;
      }
      else if ((advancingFrontNode_1 == advancingFrontNode ? 0 : (TriangulationUtil.Orient2d((Point2D) advancingFrontNode_1.Prev.Point, (Point2D) advancingFrontNode_1.Point, (Point2D) advancingFrontNode_0.Point) == Orientation.AntiClockwise ? 1 : 0)) != 0)
      {
        Class30.smethod_51(dtsweepContext_0, advancingFrontNode_1);
        advancingFrontNode_1 = advancingFrontNode_1.Prev;
      }
      else
      {
        advancingFrontNode_1 = advancingFrontNode_0;
        advancingFrontNode_0 = advancingFrontNode_0.Next;
      }
    }
  }

  static string smethod_188(string string_0)
  {
    string_0 = string_0 != null ? Regex.Replace(string_0, "(\\((?>\\((?<C>)|\\)(?<-C>)|.?)*(?(C)(?!))\\))", "") : throw new ArgumentNullException("input");
    string_0 = Regex.Replace(string_0, "\\s+", " ");
    string_0 = Regex.Replace(string_0, "^\\s+", "");
    string_0 = Regex.Replace(string_0, "\\s+$", "");
    string_0 = Regex.Replace(string_0, " ?: ?", ":");
    return string_0;
  }

  static List<string> smethod_189(char char_0, string string_0)
  {
    List<string> stringList = new List<string>();
    int startIndex = 0;
    bool flag = false;
    char[] charArray = string_0.ToCharArray();
    for (int index = 0; index < charArray.Length; ++index)
    {
      char ch = charArray[index];
      if (ch == '"')
        flag = !flag;
      if (((int) ch != (int) char_0 ? 0 : (!flag ? 1 : 0)) != 0)
      {
        int length = index - startIndex;
        stringList.Add(string_0.Substring(startIndex, length));
        startIndex = index + 1;
      }
    }
    stringList.Add(string_0.Substring(startIndex, string_0.Length - startIndex));
    return stringList;
  }

  static uint smethod_190(ulong ulong_0)
  {
    return (uint) ((ulong) ((((long) ulong_0 & (long) byte.MaxValue) << 24) + (((long) ulong_0 & 65280L) << 8)) + ((ulong_0 & 16711680UL /*0xFF0000*/) >> 8) + ((ulong_0 & 4278190080UL /*0xFF000000*/) >> 24));
  }

  static void smethod_191(ref byte[] byte_0, out MessageHeader messageHeader_0, [Out] byte[] byte_1)
  {
    int num = byte_1 != null ? Class30.smethod_3(byte_1) : throw new ArgumentNullException("fullRawMessage");
    NameValueCollection nameValueCollection_1 = Class30.smethod_239(Encoding.ASCII.GetString(byte_1, 0, num));
    messageHeader_0 = new MessageHeader(nameValueCollection_1);
    byte_0 = new byte[byte_1.Length - num];
    Array.Copy((Array) byte_1, num, (Array) byte_0, 0, byte_0.Length);
  }

  static bool smethod_192(Class22 class22_0, bool bool_0, Class22 class22_1)
  {
    return !bool_0 ? class22_1.intPoint_3.Y * class22_0.intPoint_3.X == class22_1.intPoint_3.X * class22_0.intPoint_3.Y : Struct0.smethod_0(Struct0.smethod_2(class22_1.intPoint_3.Y, class22_0.intPoint_3.X), Struct0.smethod_2(class22_1.intPoint_3.X, class22_0.intPoint_3.Y));
  }

  static double smethod_193(double double_0, buFile.Dxf dxf_0) => double_0 * 180.0 / Math.PI;

  static void smethod_194(buClipper buClipper_0, Class22 class22_0)
  {
    Class22 class22 = Class30.smethod_110(class22_0, buClipper_0);
    if (class22 == null)
    {
      if (class22_0.int_3 >= 0)
        Class30.smethod_246(buClipper_0, class22_0, class22_0.intPoint_2);
      Class30.smethod_12((buClipperBase) buClipper_0, class22_0);
    }
    else
    {
      for (Class22 class223 = class22_0.class22_3; (class223 == null ? 0 : (class223 != class22 ? 1 : 0)) != 0; class223 = class22_0.class22_3)
      {
        Class30.smethod_287(class22_0.intPoint_2, buClipper_0, class22_0, class223);
        Class30.smethod_45(class223, class22_0, (buClipperBase) buClipper_0);
      }
      if ((class22_0.int_3 != -1 ? 0 : (class22.int_3 == -1 ? 1 : 0)) != 0)
      {
        Class30.smethod_12((buClipperBase) buClipper_0, class22_0);
        Class30.smethod_12((buClipperBase) buClipper_0, class22);
      }
      else if ((class22_0.int_3 < 0 ? 0 : (class22.int_3 >= 0 ? 1 : 0)) != 0)
      {
        if (class22_0.int_3 >= 0)
          Class30.smethod_1(class22_0.intPoint_2, class22_0, class22, buClipper_0);
        Class30.smethod_12((buClipperBase) buClipper_0, class22_0);
        Class30.smethod_12((buClipperBase) buClipper_0, class22);
      }
      else
      {
        if (class22_0.int_0 != 0)
          throw new Exception0("DoMaxima error");
        if (class22_0.int_3 >= 0)
        {
          Class30.smethod_246(buClipper_0, class22_0, class22_0.intPoint_2);
          class22_0.int_3 = -1;
        }
        Class30.smethod_12((buClipperBase) buClipper_0, class22_0);
        if (class22.int_3 >= 0)
        {
          Class30.smethod_246(buClipper_0, class22, class22_0.intPoint_2);
          class22.int_3 = -1;
        }
        Class30.smethod_12((buClipperBase) buClipper_0, class22);
      }
    }
  }

  static Class34.Class38 smethod_195(Class34.Class39 class39_0)
  {
    byte[] numArray = new byte[class39_0.int_4];
    Array.Copy((Array) class39_0.byte_1, class39_0.int_3, (Array) numArray, 0, class39_0.int_4);
    return new Class34.Class38(numArray);
  }

  static bool smethod_196(IntPoint intPoint_0, IntPoint intPoint_1, double double_0)
  {
    double num1 = (double) intPoint_0.X - (double) intPoint_1.X;
    double num2 = (double) intPoint_0.Y - (double) intPoint_1.Y;
    return num1 * num1 + num2 * num2 <= double_0;
  }

  static int smethod_197(Pop3Client pop3Client_0, string string_0, int int_0)
  {
    Class30.smethod_144(pop3Client_0, string_0);
    return int.Parse(pop3Client_0.method_2().Split(' ')[int_0], (IFormatProvider) CultureInfo.InvariantCulture);
  }

  static buPop3.Mime.Header.ContentTransferEncoding smethod_198(string string_0)
  {
    if (string_0 == null)
      throw new ArgumentNullException("headerValue");
    buPop3.Mime.Header.ContentTransferEncoding transferEncoding;
    switch (string_0.Trim().ToUpperInvariant())
    {
      case "7BIT":
        transferEncoding = buPop3.Mime.Header.ContentTransferEncoding.SevenBit;
        break;
      case "8BIT":
        transferEncoding = buPop3.Mime.Header.ContentTransferEncoding.EightBit;
        break;
      case "QUOTED-PRINTABLE":
        transferEncoding = buPop3.Mime.Header.ContentTransferEncoding.QuotedPrintable;
        break;
      case "BASE64":
        transferEncoding = buPop3.Mime.Header.ContentTransferEncoding.Base64;
        break;
      case "BINARY":
        transferEncoding = buPop3.Mime.Header.ContentTransferEncoding.Binary;
        break;
      default:
        DefaultLogger.Log.LogDebug("Wrong ContentTransferEncoding was used. It was: " + string_0);
        transferEncoding = buPop3.Mime.Header.ContentTransferEncoding.SevenBit;
        break;
    }
    return transferEncoding;
  }

  static long smethod_199(double double_0)
  {
    return double_0 < 0.0 ? (long) (double_0 - 0.5) : (long) (double_0 + 0.5);
  }

  static void smethod_200(
    ConstrainedPointSet constrainedPointSet_0,
    IEnumerable<TriangulationConstraint> ienumerable_0)
  {
    if (ienumerable_0 == null)
      return;
    foreach (TriangulationConstraint triangulationConstraint in ienumerable_0)
    {
      if ((constrainedPointSet_0.ConstrainPointToBounds(triangulationConstraint.P) ? 1 : (constrainedPointSet_0.ConstrainPointToBounds(triangulationConstraint.Q) ? 1 : 0)) != 0)
        triangulationConstraint.CalculateContraintCode();
      TriangulationConstraint tc;
      if (!constrainedPointSet_0.dictionary_1.TryGetValue(triangulationConstraint.ConstraintCode, out tc))
      {
        tc = triangulationConstraint;
        constrainedPointSet_0.AddConstraint(tc);
      }
    }
  }

  static AdvancingFrontNode smethod_201(
    DTSweepContext dtsweepContext_0,
    TriangulationPoint triangulationPoint_0)
  {
    AdvancingFrontNode advancingFrontNode_0_1 = dtsweepContext_0.LocateNode(triangulationPoint_0);
    if (dtsweepContext_0.IsDebugEnabled)
      dtsweepContext_0.DebugContext.ActiveNode = advancingFrontNode_0_1;
    AdvancingFrontNode advancingFrontNode;
    if ((advancingFrontNode_0_1 == null ? 1 : (triangulationPoint_0 == null ? 1 : 0)) != 0)
    {
      advancingFrontNode = (AdvancingFrontNode) null;
    }
    else
    {
      AdvancingFrontNode advancingFrontNode_0_2 = Class30.smethod_160(dtsweepContext_0, triangulationPoint_0, advancingFrontNode_0_1);
      if (triangulationPoint_0.X <= advancingFrontNode_0_1.Point.X + 1E-12)
        Class30.smethod_51(dtsweepContext_0, advancingFrontNode_0_1);
      Class30.smethod_91(dtsweepContext_0, advancingFrontNode_0_2);
      advancingFrontNode = advancingFrontNode_0_2;
    }
    return advancingFrontNode;
  }

  static Class22 smethod_202(buClipperBase buClipperBase_0, Class22 class22_0)
  {
    class22_0.class22_1.class22_0 = class22_0.class22_0;
    class22_0.class22_0.class22_1 = class22_0.class22_1;
    Class22 class220 = class22_0.class22_0;
    class22_0.class22_1 = (Class22) null;
    return class220;
  }

  static bool smethod_203(long long_0, buClipper buClipper_0)
  {
    bool flag;
    if (buClipper_0.class22_0 == null)
    {
      flag = true;
    }
    else
    {
      try
      {
        Class30.smethod_259(long_0, buClipper_0);
        if (buClipper_0.list_2.Count == 0)
        {
          flag = true;
          goto label_9;
        }
        if ((buClipper_0.list_2.Count == 1 ? 1 : (Class30.smethod_42(buClipper_0) ? 1 : 0)) != 0)
        {
          Class30.smethod_235(buClipper_0);
        }
        else
        {
          flag = false;
          goto label_9;
        }
      }
      catch
      {
        buClipper_0.class22_1 = (Class22) null;
        buClipper_0.list_2.Clear();
        throw new Exception0("ProcessIntersections error");
      }
      buClipper_0.class22_1 = (Class22) null;
      flag = true;
    }
label_9:
    return flag;
  }

  static double smethod_204(buFile.Dxf dxf_0, double double_0)
  {
    double num = 0.0;
    if (double_0 > 360.0)
    {
      double_0 -= 360.0;
      num = double_0 * Math.PI / 180.0;
      double_0 += 360.0;
    }
    if (double_0 <= 360.0)
      num = double_0 * Math.PI / 180.0;
    return num;
  }

  static void smethod_205(AdvancingFrontNode advancingFrontNode_0, DTSweepContext dtsweepContext_0)
  {
    dtsweepContext_0.Basin.LeftNode = TriangulationUtil.Orient2d((Point2D) advancingFrontNode_0.Point, (Point2D) advancingFrontNode_0.Next.Point, (Point2D) advancingFrontNode_0.Next.Next.Point) == Orientation.AntiClockwise ? advancingFrontNode_0 : advancingFrontNode_0.Next;
    dtsweepContext_0.Basin.BottomNode = dtsweepContext_0.Basin.LeftNode;
    while ((!dtsweepContext_0.Basin.BottomNode.HasNext ? 0 : (dtsweepContext_0.Basin.BottomNode.Point.Y >= dtsweepContext_0.Basin.BottomNode.Next.Point.Y ? 1 : 0)) != 0)
      dtsweepContext_0.Basin.BottomNode = dtsweepContext_0.Basin.BottomNode.Next;
    if (dtsweepContext_0.Basin.BottomNode == dtsweepContext_0.Basin.LeftNode)
      return;
    dtsweepContext_0.Basin.RightNode = dtsweepContext_0.Basin.BottomNode;
    while ((!dtsweepContext_0.Basin.RightNode.HasNext ? 0 : (dtsweepContext_0.Basin.RightNode.Point.Y < dtsweepContext_0.Basin.RightNode.Next.Point.Y ? 1 : 0)) != 0)
      dtsweepContext_0.Basin.RightNode = dtsweepContext_0.Basin.RightNode.Next;
    if (dtsweepContext_0.Basin.RightNode == dtsweepContext_0.Basin.BottomNode)
      return;
    dtsweepContext_0.Basin.Width = dtsweepContext_0.Basin.RightNode.Point.X - dtsweepContext_0.Basin.LeftNode.Point.X;
    dtsweepContext_0.Basin.LeftHighest = dtsweepContext_0.Basin.LeftNode.Point.Y > dtsweepContext_0.Basin.RightNode.Point.Y;
    Class30.smethod_269(dtsweepContext_0, dtsweepContext_0.Basin.BottomNode);
  }

  static bool smethod_206(
    ref double double_0,
    ref double double_1,
    ref double double_2,
    buFile.Dxf dxf_0,
    ref Color color_0,
    ref string string_0,
    ref Vec3D vec3D_0,
    ref double double_3,
    ref double double_4,
    ref double double_5,
    int int_0)
  {
    bool flag1 = true;
    bool flag2 = false;
    bool flag3 = false;
    bool flag4 = false;
    int num = 0;
    vec3D_0 = new Vec3D(0.0, 0.0, 1.0);
    for (int index = int_0; index <= dxf_0.list_0.Count - 1; ++index)
    {
      if (num < 80 /*0x50*/)
      {
        ++num;
        if (flag1 & dxf_0.list_0[index] == "AcDbEntity")
          string_0 = dxf_0.list_0[index + 2];
        if (flag1 & dxf_0.list_0[index] == "  8")
          string_0 = dxf_0.list_0[index + 1];
        if (flag1 & dxf_0.list_0[index] == "AcDbCircle")
          flag2 = true;
        if (flag1 & dxf_0.list_0[index] == "AcDbArc")
          flag3 = true;
        if (flag1 & dxf_0.list_0[index] == "CONTINUOUS")
        {
          flag2 = true;
          flag3 = true;
        }
        if (flag1 & dxf_0.list_0[index] == " 62")
        {
          int int32 = Convert.ToInt32(dxf_0.list_0[index + 1]);
          color_0 = int32 >= dxf_0.ColorCode.Length ? Color.Black : dxf_0.ColorCode[int32];
          if (color_0.A == (byte) 0 & color_0.R == (byte) 0 & color_0.G == (byte) 0 & color_0.B == (byte) 0)
            color_0 = Color.Black;
        }
        if (flag2 & dxf_0.list_0[index] == "210")
          vec3D_0.X = Math.Round(Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]), 3);
        if (flag2 & dxf_0.list_0[index] == "220")
          vec3D_0.Y = Math.Round(Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]), 3);
        if (flag2 & dxf_0.list_0[index] == "230")
          vec3D_0.Z = Math.Round(Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]), 3);
        if (flag2 & dxf_0.list_0[index] == " 10")
          double_5 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
        if (flag2 & dxf_0.list_0[index] == " 20")
          double_3 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
        if (flag2 & dxf_0.list_0[index] == " 30")
          double_4 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
        if (flag2 & dxf_0.list_0[index] == " 40")
          double_1 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
        if (flag3 & dxf_0.list_0[index] == " 50")
          double_2 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
        if (flag3 & dxf_0.list_0[index] == " 51")
        {
          double_0 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
          if (double_2 > double_0)
            double_0 += 360.0;
          flag4 = true;
          break;
        }
      }
      else
      {
        flag4 = false;
        break;
      }
    }
    return flag4;
  }

  static void smethod_207(
    buClipper buClipper_0,
    ref IntPoint intPoint_0,
    Class22 class22_0,
    Class22 class22_1)
  {
    if ((intPoint_0.Z != 0L ? 1 : (buClipper_0.ZFillFunction == null ? 1 : 0)) != 0)
      return;
    if (intPoint_0 == class22_0.intPoint_0)
      intPoint_0.Z = class22_0.intPoint_0.Z;
    else if (intPoint_0 == class22_0.intPoint_2)
      intPoint_0.Z = class22_0.intPoint_2.Z;
    else if (intPoint_0 == class22_1.intPoint_0)
      intPoint_0.Z = class22_1.intPoint_0.Z;
    else if (intPoint_0 == class22_1.intPoint_2)
      intPoint_0.Z = class22_1.intPoint_2.Z;
    else
      buClipper_0.ZFillFunction(class22_0.intPoint_0, class22_0.intPoint_2, class22_1.intPoint_0, class22_1.intPoint_2, ref intPoint_0);
  }

  static byte[] smethod_208(byte[] byte_0, byte[] byte_1)
  {
    if (byte_1 == null)
      throw new ArgumentNullException("toXor");
    if (byte_0 == null)
      throw new ArgumentNullException("toXorWith");
    if (byte_1.Length != byte_0.Length)
      throw new ArgumentException("The lengths of the arrays must be equal");
    byte[] numArray = new byte[byte_1.Length];
    for (int index = 0; index < byte_1.Length; ++index)
    {
      numArray[index] = byte_1[index];
      numArray[index] ^= byte_0[index];
    }
    return numArray;
  }

  static bool smethod_209(double double_0) => double_0 > -1E-20 && double_0 < 1E-20;

  static void smethod_210(ClipperOffset clipperOffset_0, int int_0, int int_1)
  {
    double num = Math.Tan(Math.Atan2(clipperOffset_0.double_1, clipperOffset_0.list_3[int_1].X * clipperOffset_0.list_3[int_0].X + clipperOffset_0.list_3[int_1].Y * clipperOffset_0.list_3[int_0].Y) / 4.0);
    clipperOffset_0.list_2.Add(new IntPoint(Class30.smethod_150((double) clipperOffset_0.list_1[int_0].X + clipperOffset_0.double_0 * (clipperOffset_0.list_3[int_1].X - clipperOffset_0.list_3[int_1].Y * num)), Class30.smethod_150((double) clipperOffset_0.list_1[int_0].Y + clipperOffset_0.double_0 * (clipperOffset_0.list_3[int_1].Y + clipperOffset_0.list_3[int_1].X * num))));
    clipperOffset_0.list_2.Add(new IntPoint(Class30.smethod_150((double) clipperOffset_0.list_1[int_0].X + clipperOffset_0.double_0 * (clipperOffset_0.list_3[int_0].X + clipperOffset_0.list_3[int_0].Y * num)), Class30.smethod_150((double) clipperOffset_0.list_1[int_0].Y + clipperOffset_0.double_0 * (clipperOffset_0.list_3[int_0].Y - clipperOffset_0.list_3[int_0].X * num))));
  }

  static void smethod_211(buClipper buClipper_0, Class22 class22_0)
  {
    bool flag1 = class22_0.int_0 == 0;
    Enum3 enum3_0;
    long long_0;
    long long_1;
    Class30.smethod_111(buClipper_0, class22_0, out enum3_0, out long_0, ref long_1);
    Class22 class22_0_1 = class22_0;
    Class22 class22_1 = (Class22) null;
    while ((class22_0_1.class22_2 == null ? 0 : (Class30.smethod_67(class22_0_1.class22_2) ? 1 : 0)) != 0)
      class22_0_1 = class22_0_1.class22_2;
    if (class22_0_1.class22_2 == null)
      class22_1 = Class30.smethod_146(buClipper_0, class22_0_1);
    Class25 class25 = buClipper_0.class25_0;
    if (class25 != null)
    {
      if (enum3_0 == Enum3.const_1)
      {
        while ((class25 == null ? 0 : (class25.long_0 <= class22_0.intPoint_0.X ? 1 : 0)) != 0)
          class25 = class25.class25_0;
        if ((class25 == null ? 0 : (class25.long_0 >= class22_0_1.intPoint_2.X ? 1 : 0)) != 0)
          class25 = (Class25) null;
      }
      else
      {
        while ((class25.class25_0 == null ? 0 : (class25.class25_0.long_0 < class22_0.intPoint_0.X ? 1 : 0)) != 0)
          class25 = class25.class25_0;
        if (class25.long_0 <= class22_0_1.intPoint_2.X)
          class25 = (Class25) null;
      }
    }
    Class27 class27_0_1 = (Class27) null;
    while (true)
    {
      bool flag2 = class22_0 == class22_0_1;
      Class22 class22_2;
      for (Class22 class22_3 = Class30.smethod_99(buClipper_0, class22_0, enum3_0); class22_3 != null; class22_3 = class22_2)
      {
        if (class25 != null)
        {
          if (enum3_0 == Enum3.const_1)
          {
            for (; (class25 == null ? 0 : (class25.long_0 < class22_3.intPoint_1.X ? 1 : 0)) != 0; class25 = class25.class25_0)
            {
              if ((class22_0.int_3 < 0 ? 0 : (!flag1 ? 1 : 0)) != 0)
                Class30.smethod_246(buClipper_0, class22_0, new IntPoint(class25.long_0, class22_0.intPoint_0.Y));
            }
          }
          else
          {
            for (; (class25 == null ? 0 : (class25.long_0 > class22_3.intPoint_1.X ? 1 : 0)) != 0; class25 = class25.class25_1)
            {
              if ((class22_0.int_3 < 0 ? 0 : (!flag1 ? 1 : 0)) != 0)
                Class30.smethod_246(buClipper_0, class22_0, new IntPoint(class25.long_0, class22_0.intPoint_0.Y));
            }
          }
        }
        if ((enum3_0 != Enum3.const_1 || class22_3.intPoint_1.X <= long_1 ? (enum3_0 != Enum3.const_0 ? 0 : (class22_3.intPoint_1.X < long_0 ? 1 : 0)) : 1) == 0 && (class22_3.intPoint_1.X != class22_0.intPoint_2.X || class22_0.class22_2 == null ? 0 : (class22_3.double_0 < class22_0.class22_2.double_0 ? 1 : 0)) == 0)
        {
          if ((class22_0.int_3 < 0 ? 0 : (!flag1 ? 1 : 0)) != 0)
          {
            if (enum3_0 == Enum3.const_1)
              Class30.smethod_207(buClipper_0, ref class22_3.intPoint_1, class22_0, class22_3);
            else
              Class30.smethod_207(buClipper_0, ref class22_3.intPoint_1, class22_3, class22_0);
            class27_0_1 = Class30.smethod_246(buClipper_0, class22_0, class22_3.intPoint_1);
            for (Class22 class22_0_2 = buClipper_0.class22_1; class22_0_2 != null; class22_0_2 = class22_0_2.class22_5)
            {
              int num;
              if (class22_0_2.int_3 >= 0)
              {
                long x1 = class22_0.intPoint_0.X;
                long x2 = class22_0.intPoint_2.X;
                long x3 = class22_0_2.intPoint_0.X;
                num = Class30.smethod_97(class22_0_2.intPoint_2.X, buClipper_0, x2, x1, x3) ? 1 : 0;
              }
              else
                num = 0;
              if (num != 0)
              {
                Class27 class27_1 = Class30.smethod_137(class22_0_2, buClipper_0);
                Class30.smethod_22(class22_0_2.intPoint_2, class27_0_1, class27_1, buClipper_0);
              }
            }
            Class30.smethod_223(class22_0.intPoint_0, class27_0_1, buClipper_0);
          }
          if (!(class22_3 == class22_1 & flag2))
          {
            if (enum3_0 == Enum3.const_1)
              Class30.smethod_287(new IntPoint(class22_3.intPoint_1.X, class22_0.intPoint_1.Y), buClipper_0, class22_0, class22_3);
            else
              Class30.smethod_287(new IntPoint(class22_3.intPoint_1.X, class22_0.intPoint_1.Y), buClipper_0, class22_3, class22_0);
            class22_2 = Class30.smethod_99(buClipper_0, class22_3, enum3_0);
            Class30.smethod_45(class22_3, class22_0, (buClipperBase) buClipper_0);
          }
          else
          {
            if (class22_0.int_3 >= 0)
              Class30.smethod_1(class22_0.intPoint_2, class22_0, class22_1, buClipper_0);
            Class30.smethod_12((buClipperBase) buClipper_0, class22_0);
            Class30.smethod_12((buClipperBase) buClipper_0, class22_1);
            return;
          }
        }
        else
          break;
      }
      if ((class22_0.class22_2 == null ? 1 : (!Class30.smethod_67(class22_0.class22_2) ? 1 : 0)) == 0)
      {
        Class30.smethod_8((buClipperBase) buClipper_0, ref class22_0);
        if (class22_0.int_3 >= 0)
          Class30.smethod_246(buClipper_0, class22_0, class22_0.intPoint_0);
        Class30.smethod_111(buClipper_0, class22_0, out enum3_0, out long_0, ref long_1);
      }
      else
        break;
    }
    if ((class22_0.int_3 < 0 ? 0 : (class27_0_1 == null ? 1 : 0)) != 0)
    {
      Class27 class27_0_2 = Class30.smethod_137(class22_0, buClipper_0);
      for (Class22 class22_0_3 = buClipper_0.class22_1; class22_0_3 != null; class22_0_3 = class22_0_3.class22_5)
      {
        int num;
        if (class22_0_3.int_3 >= 0)
        {
          long x4 = class22_0.intPoint_0.X;
          long x5 = class22_0.intPoint_2.X;
          long x6 = class22_0_3.intPoint_0.X;
          num = Class30.smethod_97(class22_0_3.intPoint_2.X, buClipper_0, x5, x4, x6) ? 1 : 0;
        }
        else
          num = 0;
        if (num != 0)
        {
          Class27 class27_1 = Class30.smethod_137(class22_0_3, buClipper_0);
          Class30.smethod_22(class22_0_3.intPoint_2, class27_0_2, class27_1, buClipper_0);
        }
      }
      Class30.smethod_223(class22_0.intPoint_2, class27_0_2, buClipper_0);
    }
    if (class22_0.class22_2 != null)
    {
      if (class22_0.int_3 >= 0)
      {
        Class27 class27_1 = Class30.smethod_246(buClipper_0, class22_0, class22_0.intPoint_2);
        Class30.smethod_8((buClipperBase) buClipper_0, ref class22_0);
        if (class22_0.int_0 == 0)
          return;
        Class22 class224 = class22_0.class22_4;
        Class22 class223 = class22_0.class22_3;
        if ((class224 == null || class224.intPoint_1.X != class22_0.intPoint_0.X || class224.intPoint_1.Y != class22_0.intPoint_0.Y || class224.int_0 == 0 ? 0 : (class224.int_3 < 0 || class224.intPoint_1.Y <= class224.intPoint_2.Y ? 0 : (Class30.smethod_192(class224, buClipper_0.bool_0, class22_0) ? 1 : 0))) != 0)
        {
          Class27 class27_0_3 = Class30.smethod_246(buClipper_0, class224, class22_0.intPoint_0);
          Class30.smethod_22(class22_0.intPoint_2, class27_0_3, class27_1, buClipper_0);
        }
        else
        {
          if ((class223 == null || class223.intPoint_1.X != class22_0.intPoint_0.X || class223.intPoint_1.Y != class22_0.intPoint_0.Y || class223.int_0 == 0 || class223.int_3 < 0 || class223.intPoint_1.Y <= class223.intPoint_2.Y ? 0 : (Class30.smethod_192(class223, buClipper_0.bool_0, class22_0) ? 1 : 0)) == 0)
            return;
          Class27 class27_0_4 = Class30.smethod_246(buClipper_0, class223, class22_0.intPoint_0);
          Class30.smethod_22(class22_0.intPoint_2, class27_0_4, class27_1, buClipper_0);
        }
      }
      else
        Class30.smethod_8((buClipperBase) buClipper_0, ref class22_0);
    }
    else
    {
      if (class22_0.int_3 >= 0)
        Class30.smethod_246(buClipper_0, class22_0, class22_0.intPoint_2);
      Class30.smethod_12((buClipperBase) buClipper_0, class22_0);
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
    string upperInvariant = string_0.ToUpperInvariant();
    if ((upperInvariant.Contains("[IN-USE]") ? 1 : (upperInvariant.Contains("LOCK") ? 1 : 0)) != 0)
    {
      DefaultLogger.Log.LogError("Authentication: maildrop is locked or in-use");
      throw new PopServerLockedException(popServerException_0);
    }
    if (upperInvariant.Contains("[LOGIN-DELAY]"))
      throw new LoginDelayException(popServerException_0);
  }

  static void smethod_214(Pop3Client pop3Client_0, string string_0, string string_1)
  {
    Class30.smethod_144(pop3Client_0, "USER " + string_0);
    Class30.smethod_144(pop3Client_0, "PASS " + string_1);
  }

  static void smethod_215(DelaunayTriangle delaunayTriangle_0, DTSweepContext dtsweepContext_0)
  {
    if ((delaunayTriangle_0 == null ? 0 : (!delaunayTriangle_0.IsInterior ? 1 : 0)) == 0)
      return;
    delaunayTriangle_0.IsInterior = true;
    dtsweepContext_0.Triangulatable.AddTriangle(delaunayTriangle_0);
    for (int index = 0; index < 3; ++index)
    {
      if (!delaunayTriangle_0.EdgeIsConstrained[index])
        Class30.smethod_215(delaunayTriangle_0.Neighbors[index], dtsweepContext_0);
    }
  }

  static double smethod_216(Class27 class27_0, buClipper buClipper_0)
  {
    Class27 class27 = class27_0;
    double num1;
    if (class27_0 == null)
    {
      num1 = 0.0;
    }
    else
    {
      double num2 = 0.0;
      do
      {
        num2 += (double) (class27_0.class27_1.intPoint_0.X + class27_0.intPoint_0.X) * (double) (class27_0.class27_1.intPoint_0.Y - class27_0.intPoint_0.Y);
        class27_0 = class27_0.class27_0;
      }
      while (class27_0 != class27);
      num1 = num2 * 0.5;
    }
    return num1;
  }

  static double smethod_217(Point2D point2D_0) => 1.0 / point2D_0.Magnitude();

  static double smethod_218(AdvancingFrontNode advancingFrontNode_0)
  {
    double x = advancingFrontNode_0.Point.X - advancingFrontNode_0.Next.Next.Point.X;
    return Math.Atan2(advancingFrontNode_0.Point.Y - advancingFrontNode_0.Next.Next.Point.Y, x);
  }

  static int smethod_219(Class34.Class37 class37_0, Class34.Class36 class36_0, int int_0)
  {
    int_0 = Math.Min(Math.Min(int_0, 32768 /*0x8000*/ - class37_0.int_1), Class30.smethod_6(class36_0));
    int int_1 = 32768 /*0x8000*/ - class37_0.int_0;
    int num;
    if (int_0 > int_1)
    {
      num = Class30.smethod_173(class36_0, class37_0.byte_0, class37_0.int_0, int_1);
      if (num == int_1)
        num += Class30.smethod_173(class36_0, class37_0.byte_0, 0, int_0 - int_1);
    }
    else
      num = Class30.smethod_173(class36_0, class37_0.byte_0, class37_0.int_0, int_0);
    class37_0.int_0 = class37_0.int_0 + num & (int) short.MaxValue;
    class37_0.int_1 += num;
    return num;
  }

  static void smethod_220(
    ref float float_0,
    ref List<Pnt3D> list_0,
    buFile.Dxf dxf_0,
    ref bool bool_0,
    ref List<double> list_1,
    ref Color color_0,
    int int_0,
    ref double double_0,
    ref string string_0)
  {
    bool flag1 = true;
    bool flag2 = false;
    int num1 = 0;
    Pnt3D pnt3D1 = new Pnt3D();
    bool_0 = false;
    for (int index = int_0; index <= dxf_0.list_0.Count - 1; ++index)
    {
      if (flag1 & dxf_0.list_0[index] == " 62")
      {
        int int32 = Convert.ToInt32(dxf_0.list_0[index + 1]);
        color_0 = int32 >= dxf_0.ColorCode.Length ? Color.Black : dxf_0.ColorCode[int32];
        if (color_0.A == (byte) 0 & color_0.R == (byte) 0 & color_0.G == (byte) 0 & color_0.B == (byte) 0)
          color_0 = Color.Black;
      }
      if (flag1 & dxf_0.list_0[index] == "AcDbEntity")
        string_0 = dxf_0.list_0[index + 2];
      if (flag1 & dxf_0.list_0[index] == "  8")
        string_0 = dxf_0.list_0[index + 1];
      if (flag1 & dxf_0.list_0[index] == "AcDbSpline")
        flag2 = true;
      if (flag2 & dxf_0.list_0[index] == " 10")
      {
        Pnt3D pnt3D2 = new Pnt3D();
        pnt3D2.X = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
        pnt3D2.Y = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 3]);
        pnt3D2.Z = 0.0;
        list_0.Add(pnt3D2);
        ++num1;
      }
      if (flag2 & dxf_0.list_0[index] == " 40")
        list_1.Add(Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]));
      if (flag2 & dxf_0.list_0[index] == " 71")
        double_0 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
      if (flag2 & dxf_0.list_0[index] == " 72")
      {
        int num2 = (int) Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
      }
      if (flag2 & dxf_0.list_0[index] == " 73")
      {
        int num3 = (int) Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
      }
      if (flag2 & dxf_0.list_0[index] == "  0")
        break;
    }
  }

  static void smethod_221(
    ref float float_0,
    buFile.Dxf dxf_0,
    int int_0,
    ref Color color_0,
    ref string string_0,
    ref List<eEntities> list_0,
    ref bool bool_0)
  {
    bool flag1 = false;
    bool flag2 = false;
    bool flag3 = false;
    bool flag4 = false;
    double d = 0.0;
    Pnt3D pnt3D1 = new Pnt3D();
    List<Pnt3D> pnt3DList = new List<Pnt3D>();
    for (int index = int_0; index <= dxf_0.list_0.Count - 1; ++index)
    {
      bool flag5 = false;
      string str1 = dxf_0.list_0[index];
      if (((!flag1 ? 1 : 0) & 1) != 0 && dxf_0.list_0[index] == " 62" | dxf_0.list_0[index] == "62")
      {
        int int32 = Convert.ToInt32(dxf_0.list_0[index + 1]);
        color_0 = int32 >= dxf_0.ColorCode.Length ? Color.Black : dxf_0.ColorCode[int32];
        if (color_0.A == (byte) 0 & color_0.R == (byte) 0 & color_0.G == (byte) 0 & color_0.B == (byte) 0)
          color_0 = Color.Black;
        ++index;
        flag1 = true;
      }
      if (!flag2 & !flag5 && dxf_0.list_0[index] == "  8" | dxf_0.list_0[index] == "8")
      {
        string_0 = dxf_0.list_0[index + 1];
        flag2 = true;
        ++index;
        flag5 = true;
      }
      if (!flag5 && dxf_0.list_0[index] == " 70" | dxf_0.list_0[index] == "70")
      {
        if (dxf_0.list_0[index + 1].Trim() == "1")
          bool_0 = true;
        ++index;
        flag5 = true;
      }
      if (!flag5)
      {
        string str2 = dxf_0.list_0[index];
        if (flag4)
        {
          if (dxf_0.list_0[index] == " 42" | dxf_0.list_0[index] == "42")
          {
            d = Convert.ToDouble(dxf_0.list_0[index + 1]);
            ++index;
          }
          if (dxf_0.list_0[index] == " 10" | dxf_0.list_0[index] == "10")
          {
            if (dxf_0.list_0[index + 2] == " 20" | dxf_0.list_0[index + 2] == "20")
            {
              double x;
              double y;
              if (d != 0.0)
              {
                Pnt3D pnt3D2 = new Pnt3D(Convert.ToDouble(dxf_0.list_0[index + 1]), Convert.ToDouble(dxf_0.list_0[index + 3]));
                x = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
                y = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 3]);
                Pnt3D pnt3D3 = new Pnt3D(x, y);
                double num1 = buAppCalc.cVector.Length3D(pnt3D1, pnt3D3) / 2.0;
                double a = 4.0 * Math.Atan(d) / 2.0;
                double num2 = num1 / Math.Sin(a);
                Pnt3D ArcCenter = new Pnt3D();
                double ArcSA = 0.0;
                double ArcEA = 0.0;
                if (a > 0.0)
                  buAppCalc.cVector.ArcWithTwoPointAndRadius(pnt3D3, pnt3D1, Math.Abs(num2), true, new WorkPlane(), ref ArcCenter, ref ArcSA, ref ArcEA);
                else
                  buAppCalc.cVector.ArcWithTwoPointAndRadius(pnt3D1, pnt3D3, Math.Abs(num2), true, new WorkPlane(), ref ArcCenter, ref ArcSA, ref ArcEA);
                list_0.Add((eEntities) new eArc(ArcCenter, Math.Abs(num2), ArcSA, ArcEA, new WorkPlane()));
                d = 0.0;
              }
              else
              {
                x = Convert.ToDouble(dxf_0.list_0[index + 1]);
                y = Convert.ToDouble(dxf_0.list_0[index + 3]);
                Pnt3D EndPoint = new Pnt3D(x, y);
                list_0.Add((eEntities) new eLine(pnt3D1, EndPoint));
              }
              pnt3D1 = new Pnt3D(x, y);
              pnt3DList.Add(pnt3D1);
            }
            flag5 = true;
          }
        }
        if (!flag4 && dxf_0.list_0[index] == " 10" | dxf_0.list_0[index] == "10" && dxf_0.list_0[index + 2] == " 20" | dxf_0.list_0[index + 2] == "20")
        {
          pnt3D1 = new Pnt3D(Convert.ToDouble(dxf_0.list_0[index + 1]), Convert.ToDouble(dxf_0.list_0[index + 3]));
          flag4 = true;
          index += 3;
        }
      }
      if (!flag5 && dxf_0.list_0[index] == "  0" | dxf_0.list_0[index] == "0")
      {
        flag3 = true;
        break;
      }
    }
  }

  static bool smethod_222(
    ref double double_0,
    ref double double_1,
    buFile.Dxf dxf_0,
    ref double double_2,
    ref Color color_0,
    ref double double_3,
    ref string string_0,
    ref double double_4,
    int int_0,
    ref double double_5)
  {
    bool flag1 = true;
    bool flag2 = false;
    int num = 0;
    for (int index = int_0; index <= dxf_0.list_0.Count - 1; ++index)
    {
      if (num < 80 /*0x50*/)
      {
        ++num;
        if (flag1 & dxf_0.list_0[index] == "AcDbEntity")
          string_0 = dxf_0.list_0[index + 2];
        if (flag1 & dxf_0.list_0[index] == "  8")
          string_0 = dxf_0.list_0[index + 1];
        if (flag1 & dxf_0.list_0[index] == " 62")
        {
          int int32 = Convert.ToInt32(dxf_0.list_0[index + 1]);
          if (int32 != 1)
            ;
          color_0 = int32 >= dxf_0.ColorCode.Length ? Color.Black : dxf_0.ColorCode[int32];
          if (color_0.A == (byte) 0 & color_0.R == (byte) 0 & color_0.G == (byte) 0 & color_0.B == (byte) 0)
            color_0 = Color.Black;
        }
        if (dxf_0.list_0[index] == " 10")
          double_1 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
        if (dxf_0.list_0[index] == " 20")
          double_2 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
        if (dxf_0.list_0[index] == " 30")
          double_4 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
        if (dxf_0.list_0[index] == " 11")
          double_3 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
        if (dxf_0.list_0[index] == " 21")
        {
          double_5 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
          if (dxf_0.list_0[index + 2] != " 31")
          {
            flag2 = true;
            break;
          }
        }
        if (dxf_0.list_0[index] == " 31")
        {
          double_0 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
          flag2 = true;
          break;
        }
      }
      else
      {
        flag2 = false;
        break;
      }
    }
    return flag2;
  }

  static void smethod_223(IntPoint intPoint_0, Class27 class27_0, buClipper buClipper_0)
  {
    buClipper_0.list_4.Add(new Class28()
    {
      class27_0 = class27_0,
      intPoint_0 = intPoint_0
    });
  }

  static Encoding smethod_224(string string_0)
  {
    string key = string_0 != null ? string_0.ToUpperInvariant() : throw new ArgumentNullException("characterSet");
    if (EncodingFinder.smethod_0().ContainsKey(key))
      return EncodingFinder.smethod_0()[key];
    try
    {
      return (key.Contains("WINDOWS") ? 1 : (key.Contains("CP") ? 1 : 0)) != 0 ? Encoding.GetEncoding(int.Parse(key.Replace("CP", "").Replace("WINDOWS", "").Replace("-", ""), (IFormatProvider) CultureInfo.InvariantCulture)) : Encoding.GetEncoding(string_0);
    }
    catch (ArgumentException ex)
    {
      if (EncodingFinder.FallbackDecoder == null)
        throw;
      Encoding encoding = EncodingFinder.FallbackDecoder(string_0);
      if (encoding != null)
        return encoding;
      throw;
    }
  }

  static bool smethod_225(byte[] byte_0)
  {
    if (byte_0 == null)
      throw new ArgumentNullException("bytesReceived");
    return byte_0.Length == 1 && byte_0[0] == (byte) 46;
  }

  static bool smethod_226(DTSweepContext dtsweepContext_0, DelaunayTriangle delaunayTriangle_0)
  {
    bool flag;
    for (int index1 = 0; index1 < 3; ++index1)
    {
      if (!delaunayTriangle_0.EdgeIsDelaunay[index1])
      {
        DelaunayTriangle neighbor = delaunayTriangle_0.Neighbors[index1];
        if (neighbor != null)
        {
          TriangulationPoint point = delaunayTriangle_0.Points[index1];
          TriangulationPoint triangulationPoint = neighbor.OppositePoint(delaunayTriangle_0, point);
          int index2 = neighbor.IndexOf(triangulationPoint);
          FixedArray3<bool> edgeIsConstrained = neighbor.EdgeIsConstrained;
          if ((edgeIsConstrained[index2] ? 1 : (neighbor.EdgeIsDelaunay[index2] ? 1 : 0)) != 0)
          {
            DelaunayTriangle delaunayTriangle = delaunayTriangle_0;
            TriangulationPoint p = point;
            edgeIsConstrained = neighbor.EdgeIsConstrained;
            int num = edgeIsConstrained[index2] ? 1 : 0;
            delaunayTriangle.SetConstrainedEdgeAcross(p, num != 0);
          }
          else if (TriangulationUtil.SmartIncircle((Point2D) point, (Point2D) delaunayTriangle_0.PointCCWFrom(point), (Point2D) delaunayTriangle_0.PointCWFrom(point), (Point2D) triangulationPoint))
          {
            delaunayTriangle_0.EdgeIsDelaunay[index1] = true;
            neighbor.EdgeIsDelaunay[index2] = true;
            Class30.smethod_65(triangulationPoint, neighbor, delaunayTriangle_0, point);
            if (!Class30.smethod_226(dtsweepContext_0, delaunayTriangle_0))
              dtsweepContext_0.MapTriangleToNodes(delaunayTriangle_0);
            if (!Class30.smethod_226(dtsweepContext_0, neighbor))
              dtsweepContext_0.MapTriangleToNodes(neighbor);
            delaunayTriangle_0.EdgeIsDelaunay[index1] = false;
            neighbor.EdgeIsDelaunay[index2] = false;
            flag = true;
            goto label_14;
          }
        }
      }
    }
    flag = false;
label_14:
    return flag;
  }

  static void smethod_227(
    DTSweepContext dtsweepContext_0,
    TriangulationConstraint triangulationConstraint_0,
    AdvancingFrontNode advancingFrontNode_0)
  {
    if (dtsweepContext_0.EdgeEvent.Right)
      Class30.smethod_31(triangulationConstraint_0, advancingFrontNode_0, dtsweepContext_0);
    else
      Class30.smethod_107(advancingFrontNode_0, triangulationConstraint_0, dtsweepContext_0);
  }

  static bool smethod_228(buClipperBase buClipperBase_0, [Out] long long_0, ref Class23 class23_0)
  {
    class23_0 = buClipperBase_0.class23_1;
    bool flag;
    if ((buClipperBase_0.class23_1 == null ? 0 : (buClipperBase_0.class23_1.long_0 == long_0 ? 1 : 0)) != 0)
    {
      buClipperBase_0.class23_1 = buClipperBase_0.class23_1.class23_0;
      flag = true;
    }
    else
      flag = false;
    return flag;
  }

  static string smethod_229(ref string string_0, [Out] string string_1)
  {
    if (string_1 == null)
      throw new ArgumentNullException("toDecode");
    string str;
    if (string_1.IndexOf('\'') == -1)
    {
      DefaultLogger.Log.LogDebug("Rfc2231Decoder: Someone asked me to decode a string which was not encoded - returning raw string. Input: " + string_1);
      string_0 = (string) null;
      str = string_1;
    }
    else
    {
      string_0 = string_1.Substring(0, string_1.IndexOf('\''));
      string_1 = string_1.Substring(string_1.LastIndexOf('\'') + 1);
      str = Class30.smethod_72(string_0, string_1);
    }
    return str;
  }

  static Class27 smethod_230(
    buClipper buClipper_0,
    Class22 class22_0,
    Class22 class22_1,
    IntPoint intPoint_0)
  {
    Class27 class27_1;
    Class22 class22_0_1;
    Class22 class22_0_2;
    if ((Class30.smethod_67(class22_1) ? 1 : (class22_0.double_0 > class22_1.double_0 ? 1 : 0)) != 0)
    {
      class27_1 = Class30.smethod_246(buClipper_0, class22_0, intPoint_0);
      class22_1.int_3 = class22_0.int_3;
      class22_0.enum2_0 = Enum2.const_0;
      class22_1.enum2_0 = Enum2.const_1;
      class22_0_1 = class22_0;
      class22_0_2 = class22_0_1.class22_4 != class22_1 ? class22_0_1.class22_4 : class22_1.class22_4;
    }
    else
    {
      class27_1 = Class30.smethod_246(buClipper_0, class22_1, intPoint_0);
      class22_0.int_3 = class22_1.int_3;
      class22_0.enum2_0 = Enum2.const_1;
      class22_1.enum2_0 = Enum2.const_0;
      class22_0_1 = class22_1;
      class22_0_2 = class22_0_1.class22_4 != class22_0 ? class22_0_1.class22_4 : class22_0.class22_4;
    }
    if ((class22_0_2 == null || class22_0_2.int_3 < 0 || class22_0_2.intPoint_2.Y >= intPoint_0.Y ? 0 : (class22_0_1.intPoint_2.Y < intPoint_0.Y ? 1 : 0)) != 0)
    {
      long x1 = Class30.smethod_101(class22_0_2, intPoint_0.Y);
      long x2 = Class30.smethod_101(class22_0_1, intPoint_0.Y);
      int num;
      if (x1 == x2 && class22_0_1.int_0 != 0 && class22_0_2.int_0 != 0)
      {
        IntPoint intPoint_1 = new IntPoint(x1, intPoint_0.Y);
        IntPoint intPoint2_1 = class22_0_2.intPoint_2;
        IntPoint intPoint_0_1 = new IntPoint(x2, intPoint_0.Y);
        IntPoint intPoint2_2 = class22_0_1.intPoint_2;
        bool bool0 = buClipper_0.bool_0;
        num = Class30.smethod_132(intPoint_0_1, intPoint_1, intPoint2_1, intPoint2_2, bool0) ? 1 : 0;
      }
      else
        num = 0;
      if (num != 0)
      {
        Class27 class27_0 = Class30.smethod_246(buClipper_0, class22_0_2, intPoint_0);
        Class30.smethod_22(class22_0_1.intPoint_2, class27_0, class27_1, buClipper_0);
      }
    }
    return class27_1;
  }

  static int smethod_231(Class34.Class37 class37_0) => 32768 /*0x8000*/ - class37_0.int_1;

  static void smethod_232(buClipperBase buClipperBase_0, long long_0)
  {
    if (buClipperBase_0.class24_0 == null)
    {
      buClipperBase_0.class24_0 = new Class24();
      buClipperBase_0.class24_0.class24_0 = (Class24) null;
      buClipperBase_0.class24_0.long_0 = long_0;
    }
    else if (long_0 > buClipperBase_0.class24_0.long_0)
    {
      buClipperBase_0.class24_0 = new Class24()
      {
        long_0 = long_0,
        class24_0 = buClipperBase_0.class24_0
      };
    }
    else
    {
      Class24 class240 = buClipperBase_0.class24_0;
      while ((class240.class24_0 == null ? 0 : (long_0 <= class240.class24_0.long_0 ? 1 : 0)) != 0)
        class240 = class240.class24_0;
      if (long_0 == class240.long_0)
        return;
      class240.class24_0 = new Class24()
      {
        long_0 = long_0,
        class24_0 = class240.class24_0
      };
    }
  }

  static int smethod_233(
    TriangulationPoint triangulationPoint_0,
    DelaunayTriangle delaunayTriangle_0)
  {
    return (delaunayTriangle_0.IndexOf(triangulationPoint_0) + 1) % 3;
  }

  static DoublePoint smethod_234(IntPoint intPoint_0, IntPoint intPoint_1)
  {
    double num1 = (double) (intPoint_1.X - intPoint_0.X);
    double num2 = (double) (intPoint_1.Y - intPoint_0.Y);
    DoublePoint doublePoint;
    if ((num1 != 0.0 ? 0 : (num2 == 0.0 ? 1 : 0)) != 0)
    {
      doublePoint = new DoublePoint();
    }
    else
    {
      double num3 = 1.0 / Math.Sqrt(num1 * num1 + num2 * num2);
      double num4 = num1 * num3;
      doublePoint = new DoublePoint(num2 * num3, -num4);
    }
    return doublePoint;
  }

  static void smethod_235(buClipper buClipper_0)
  {
    for (int index = 0; index < buClipper_0.list_2.Count; ++index)
    {
      IntersectNode intersectNode = buClipper_0.list_2[index];
      Class22 class220_1 = intersectNode.class22_0;
      Class22 class221 = intersectNode.class22_1;
      Class30.smethod_287(intersectNode.intPoint_0, buClipper_0, class220_1, class221);
      Class22 class220_2 = intersectNode.class22_0;
      Class30.smethod_45(intersectNode.class22_1, class220_2, (buClipperBase) buClipper_0);
    }
    buClipper_0.list_2.Clear();
  }

  static DateTime smethod_236(string string_0)
  {
    string_0 = string_0 != null ? Class30.smethod_188(string_0) : throw new ArgumentNullException("inputDate");
    try
    {
      DateTime dateTime_0 = Class30.smethod_52(string_0);
      if (dateTime_0 == DateTime.MinValue)
        return dateTime_0;
      Class30.smethod_124(dateTime_0, string_0);
      dateTime_0 = new DateTime(dateTime_0.Ticks, DateTimeKind.Utc);
      dateTime_0 = Class30.smethod_109(dateTime_0, string_0);
      return dateTime_0;
    }
    catch (FormatException ex)
    {
      throw new ArgumentException($"Could not parse date: {ex.Message}. Input was: \"{string_0}\"", (Exception) ex);
    }
    catch (ArgumentException ex)
    {
      throw new ArgumentException($"Could not parse date: {ex.Message}. Input was: \"{string_0}\"", (Exception) ex);
    }
  }

  static bool smethod_237(double double_0, buClipper buClipper_0, Class22 class22_0)
  {
    return class22_0 != null && (double) class22_0.intPoint_2.Y == double_0 && class22_0.class22_2 == null;
  }

  static bool smethod_238(
    Point2DList point2DList_0,
    Point2DList point2DList_1,
    out List<EdgeIntersectInfo> list_0)
  {
    list_0 = new List<EdgeIntersectInfo>();
    double epsilon = Math.Min(point2DList_1.Epsilon, point2DList_0.Epsilon);
    for (int index1 = 0; index1 < point2DList_1.Count; ++index1)
    {
      Point2D point2D1 = point2DList_1[index1];
      Point2D point2D2 = point2DList_1[point2DList_1.NextIndex(index1)];
      for (int index2 = 0; index2 < point2DList_0.Count; ++index2)
      {
        Point2D pIntersectionPt = new Point2D();
        Point2D point2D3 = point2DList_0[index2];
        Point2D point2D4 = point2DList_0[point2DList_0.NextIndex(index2)];
        if (TriangulationUtil.LinesIntersect2D(point2D1, point2D2, point2D3, point2D4, ref pIntersectionPt, epsilon))
          list_0.Add(new EdgeIntersectInfo(new Edge(point2D1, point2D2), new Edge(point2D3, point2D4), pIntersectionPt));
      }
    }
    return list_0.Count > 0;
  }

  static NameValueCollection smethod_239(string string_0)
  {
    if (string_0 == null)
      throw new ArgumentNullException("messageContent");
    NameValueCollection nameValueCollection = new NameValueCollection();
    using (StringReader textReader_0 = new StringReader(string_0))
    {
      string string_0_1;
      while (!string.IsNullOrEmpty(string_0_1 = textReader_0.ReadLine()))
      {
        KeyValuePair<string, string> keyValuePair = Class30.smethod_165(string_0_1);
        string key = keyValuePair.Key;
        StringBuilder stringBuilder = new StringBuilder(keyValuePair.Value);
        while (Class30.smethod_299((TextReader) textReader_0))
          stringBuilder.Append(textReader_0.ReadLine() ?? throw new ArgumentException("This will never happen"));
        nameValueCollection.Add(key, stringBuilder.ToString());
      }
    }
    return nameValueCollection;
  }

  static double smethod_240(Point2D point2D_0, Point2D point2D_1)
  {
    return point2D_0.X * point2D_1.X + point2D_0.Y * point2D_1.Y;
  }

  static bool smethod_241(
    buClipper buClipper_0,
    long long_0,
    long long_1,
    long long_2,
    [Out] long long_3,
    out long long_4,
    ref long long_5)
  {
    if (long_0 < long_1)
    {
      if (long_2 < long_3)
      {
        long_4 = Math.Max(long_0, long_2);
        long_5 = Math.Min(long_1, long_3);
      }
      else
      {
        long_4 = Math.Max(long_0, long_3);
        long_5 = Math.Min(long_1, long_2);
      }
    }
    else if (long_2 < long_3)
    {
      long_4 = Math.Max(long_1, long_2);
      long_5 = Math.Min(long_0, long_3);
    }
    else
    {
      long_4 = Math.Max(long_1, long_3);
      long_5 = Math.Min(long_0, long_2);
    }
    return long_4 < long_5;
  }

  static void smethod_242(Class27 class27_0, buClipper buClipper_0)
  {
    if (class27_0 == null)
      return;
    Class27 class27 = class27_0;
    do
    {
      Class27 class270 = class27.class27_0;
      class27.class27_0 = class27.class27_1;
      class27.class27_1 = class270;
      class27 = class270;
    }
    while (class27 != class27_0);
  }

  static Class22 smethod_243(buClipperBase buClipperBase_0, Class22 class22_0, bool bool_0)
  {
    Class22 class22_1 = class22_0;
    Class22 class22_2;
    if (class22_1.int_3 == -2)
    {
      class22_0 = class22_1;
      if (bool_0)
      {
        while (class22_0.intPoint_2.Y == class22_0.class22_0.intPoint_0.Y)
          class22_0 = class22_0.class22_0;
        while ((class22_0 == class22_1 ? 0 : (class22_0.double_0 == -3.4E+38 ? 1 : 0)) != 0)
          class22_0 = class22_0.class22_1;
      }
      else
      {
        while (class22_0.intPoint_2.Y == class22_0.class22_1.intPoint_0.Y)
          class22_0 = class22_0.class22_1;
        while ((class22_0 == class22_1 ? 0 : (class22_0.double_0 == -3.4E+38 ? 1 : 0)) != 0)
          class22_0 = class22_0.class22_0;
      }
      Class22 class22_3;
      if (class22_0 == class22_1)
      {
        class22_3 = !bool_0 ? class22_0.class22_1 : class22_0.class22_0;
      }
      else
      {
        class22_0 = !bool_0 ? class22_1.class22_1 : class22_1.class22_0;
        Class23 class23_0 = new Class23();
        class23_0.class23_0 = (Class23) null;
        class23_0.long_0 = class22_0.intPoint_0.Y;
        class23_0.class22_0 = (Class22) null;
        class23_0.class22_1 = class22_0;
        class22_0.int_0 = 0;
        class22_3 = Class30.smethod_243(buClipperBase_0, class22_0, bool_0);
        Class30.smethod_92(buClipperBase_0, class23_0);
      }
      class22_2 = class22_3;
    }
    else
    {
      if (class22_0.double_0 == -3.4E+38)
      {
        Class22 class22_4 = !bool_0 ? class22_0.class22_0 : class22_0.class22_1;
        if (class22_4.double_0 == -3.4E+38)
        {
          if ((class22_4.intPoint_0.X == class22_0.intPoint_0.X ? 0 : (class22_4.intPoint_2.X != class22_0.intPoint_0.X ? 1 : 0)) != 0)
            Class30.smethod_284(buClipperBase_0, class22_0);
        }
        else if (class22_4.intPoint_0.X != class22_0.intPoint_0.X)
          Class30.smethod_284(buClipperBase_0, class22_0);
      }
      Class22 class22_5 = class22_0;
      Class22 class22_6;
      if (bool_0)
      {
        while ((class22_1.intPoint_2.Y != class22_1.class22_0.intPoint_0.Y ? 0 : (class22_1.class22_0.int_3 != -2 ? 1 : 0)) != 0)
          class22_1 = class22_1.class22_0;
        if ((class22_1.double_0 != -3.4E+38 ? 0 : (class22_1.class22_0.int_3 != -2 ? 1 : 0)) != 0)
        {
          Class22 class22_7 = class22_1;
          while (class22_7.class22_1.double_0 == -3.4E+38)
            class22_7 = class22_7.class22_1;
          if (class22_7.class22_1.intPoint_2.X > class22_1.class22_0.intPoint_2.X)
            class22_1 = class22_7.class22_1;
        }
        for (; class22_0 != class22_1; class22_0 = class22_0.class22_0)
        {
          class22_0.class22_2 = class22_0.class22_0;
          if ((class22_0.double_0 != -3.4E+38 || class22_0 == class22_5 ? 0 : (class22_0.intPoint_0.X != class22_0.class22_1.intPoint_2.X ? 1 : 0)) != 0)
            Class30.smethod_284(buClipperBase_0, class22_0);
        }
        if ((class22_0.double_0 != -3.4E+38 || class22_0 == class22_5 ? 0 : (class22_0.intPoint_0.X != class22_0.class22_1.intPoint_2.X ? 1 : 0)) != 0)
          Class30.smethod_284(buClipperBase_0, class22_0);
        class22_6 = class22_1.class22_0;
      }
      else
      {
        while ((class22_1.intPoint_2.Y != class22_1.class22_1.intPoint_0.Y ? 0 : (class22_1.class22_1.int_3 != -2 ? 1 : 0)) != 0)
          class22_1 = class22_1.class22_1;
        if ((class22_1.double_0 != -3.4E+38 ? 0 : (class22_1.class22_1.int_3 != -2 ? 1 : 0)) != 0)
        {
          Class22 class22_8 = class22_1;
          while (class22_8.class22_0.double_0 == -3.4E+38)
            class22_8 = class22_8.class22_0;
          if ((class22_8.class22_0.intPoint_2.X == class22_1.class22_1.intPoint_2.X ? 1 : (class22_8.class22_0.intPoint_2.X > class22_1.class22_1.intPoint_2.X ? 1 : 0)) != 0)
            class22_1 = class22_8.class22_0;
        }
        for (; class22_0 != class22_1; class22_0 = class22_0.class22_1)
        {
          class22_0.class22_2 = class22_0.class22_1;
          if ((class22_0.double_0 != -3.4E+38 || class22_0 == class22_5 ? 0 : (class22_0.intPoint_0.X != class22_0.class22_0.intPoint_2.X ? 1 : 0)) != 0)
            Class30.smethod_284(buClipperBase_0, class22_0);
        }
        if ((class22_0.double_0 != -3.4E+38 || class22_0 == class22_5 ? 0 : (class22_0.intPoint_0.X != class22_0.class22_0.intPoint_2.X ? 1 : 0)) != 0)
          Class30.smethod_284(buClipperBase_0, class22_0);
        class22_6 = class22_1.class22_1;
      }
      class22_2 = class22_6;
    }
    return class22_2;
  }

  static void smethod_244(MessageHeader messageHeader_0, NameValueCollection nameValueCollection_0)
  {
    if (nameValueCollection_0 == null)
      throw new ArgumentNullException("headers");
    foreach (string key in nameValueCollection_0.Keys)
    {
      string[] values = nameValueCollection_0.GetValues(key);
      if (values != null)
      {
        foreach (string string_0 in values)
          Class30.smethod_44(string_0, messageHeader_0, key);
      }
    }
  }

  static void smethod_245(DTSweepContext dtsweepContext_0)
  {
    AdvancingFrontNode next1 = dtsweepContext_0.Front.Head.Next;
    Class30.smethod_187(next1.Next, next1, dtsweepContext_0);
    AdvancingFrontNode prev1 = dtsweepContext_0.Front.Tail.Prev;
    if ((!prev1.Triangle.Contains(prev1.Next.Point) ? 0 : (prev1.Triangle.Contains(prev1.Prev.Point) ? 1 : 0)) != 0)
    {
      DelaunayTriangle delaunayTriangle = prev1.Triangle.NeighborAcrossFrom(prev1.Point);
      DelaunayTriangle triangle = prev1.Triangle;
      TriangulationPoint point = prev1.Point;
      Class30.smethod_65(delaunayTriangle.OppositePoint(prev1.Triangle, prev1.Point), delaunayTriangle, triangle, point);
      dtsweepContext_0.MapTriangleToNodes(prev1.Triangle);
      dtsweepContext_0.MapTriangleToNodes(delaunayTriangle);
    }
    AdvancingFrontNode next2 = dtsweepContext_0.Front.Head.Next;
    if ((!next2.Triangle.Contains(next2.Prev.Point) ? 0 : (next2.Triangle.Contains(next2.Next.Point) ? 1 : 0)) != 0)
    {
      DelaunayTriangle delaunayTriangle = next2.Triangle.NeighborAcrossFrom(next2.Point);
      DelaunayTriangle triangle = next2.Triangle;
      TriangulationPoint point = next2.Point;
      Class30.smethod_65(delaunayTriangle.OppositePoint(next2.Triangle, next2.Point), delaunayTriangle, triangle, point);
      dtsweepContext_0.MapTriangleToNodes(next2.Triangle);
      dtsweepContext_0.MapTriangleToNodes(delaunayTriangle);
    }
    TriangulationPoint point1 = dtsweepContext_0.Front.Head.Point;
    AdvancingFrontNode prev2 = dtsweepContext_0.Front.Tail.Prev;
    DelaunayTriangle triangle1 = prev2.Triangle;
    TriangulationPoint point2 = prev2.Point;
    prev2.Triangle = (DelaunayTriangle) null;
    while (true)
    {
      dtsweepContext_0.RemoveFromList(triangle1);
      point2 = triangle1.PointCCWFrom(point2);
      if (!point2.Equals(point1))
      {
        DelaunayTriangle delaunayTriangle = triangle1.NeighborCCWFrom(point2);
        triangle1.Clear();
        triangle1 = delaunayTriangle;
      }
      else
        break;
    }
    TriangulationPoint point3 = dtsweepContext_0.Front.Head.Next.Point;
    TriangulationPoint point4 = triangle1.PointCWFrom(dtsweepContext_0.Front.Head.Point);
    DelaunayTriangle delaunayTriangle1 = triangle1.NeighborCWFrom(dtsweepContext_0.Front.Head.Point);
    triangle1.Clear();
    DelaunayTriangle triangle2 = delaunayTriangle1;
    while (point4.Equals(point3))
    {
      dtsweepContext_0.RemoveFromList(triangle2);
      point4 = triangle2.PointCCWFrom(point4);
      DelaunayTriangle delaunayTriangle2 = triangle2.NeighborCCWFrom(point4);
      triangle2.Clear();
      triangle2 = delaunayTriangle2;
    }
    dtsweepContext_0.Front.Head = dtsweepContext_0.Front.Head.Next;
    dtsweepContext_0.Front.Head.Prev = (AdvancingFrontNode) null;
    dtsweepContext_0.Front.Tail = dtsweepContext_0.Front.Tail.Prev;
    dtsweepContext_0.Front.Tail.Next = (AdvancingFrontNode) null;
  }

  static Class27 smethod_246(buClipper buClipper_0, Class22 class22_0, IntPoint intPoint_0)
  {
    Class27 class27_1;
    if (class22_0.int_3 < 0)
    {
      Class26 class26_0 = Class30.smethod_185((buClipperBase) buClipper_0);
      class26_0.bool_1 = class22_0.int_0 == 0;
      Class27 class27_2 = new Class27();
      class26_0.class27_0 = class27_2;
      class27_2.int_0 = class26_0.int_0;
      class27_2.intPoint_0 = intPoint_0;
      class27_2.class27_0 = class27_2;
      class27_2.class27_1 = class27_2;
      if (!class26_0.bool_1)
        Class30.smethod_262(class22_0, buClipper_0, class26_0);
      class22_0.int_3 = class26_0.int_0;
      class27_1 = class27_2;
    }
    else
    {
      Class26 class26 = buClipper_0.list_1[class22_0.int_3];
      Class27 class270 = class26.class27_0;
      bool flag;
      if ((!(flag = class22_0.enum2_0 == Enum2.const_0) ? 0 : (intPoint_0 == class270.intPoint_0 ? 1 : 0)) != 0)
        class27_1 = class270;
      else if ((flag ? 0 : (intPoint_0 == class270.class27_1.intPoint_0 ? 1 : 0)) != 0)
      {
        class27_1 = class270.class27_1;
      }
      else
      {
        Class27 class27_3 = new Class27()
        {
          int_0 = class26.int_0,
          intPoint_0 = intPoint_0,
          class27_0 = class270,
          class27_1 = class270.class27_1
        };
        class27_3.class27_1.class27_0 = class27_3;
        class270.class27_1 = class27_3;
        if (flag)
          class26.class27_0 = class27_3;
        class27_1 = class27_3;
      }
    }
    return class27_1;
  }

  static Class27 smethod_247(Class27 class27_0)
  {
    Class27 class271 = class27_0.class27_1;
    class271.class27_0 = class27_0.class27_0;
    class27_0.class27_0.class27_1 = class271;
    class271.int_0 = 0;
    return class271;
  }

  static int smethod_248(Class27 class27_0, IntPoint intPoint_0)
  {
    int num1 = 0;
    Class27 class27 = class27_0;
    long x1 = intPoint_0.X;
    long y1 = intPoint_0.Y;
    long num2 = class27_0.intPoint_0.X;
    long num3 = class27_0.intPoint_0.Y;
    do
    {
      class27_0 = class27_0.class27_0;
      long x2 = class27_0.intPoint_0.X;
      long y2 = class27_0.intPoint_0.Y;
      if (y2 != y1 || (x2 == x1 ? 1 : (num3 != y1 ? 0 : (x2 > x1 == num2 < x1 ? 1 : 0))) == 0)
      {
        if (num3 < y1 != y2 < y1)
        {
          if (num2 >= x1)
          {
            if (x2 > x1)
            {
              num1 = 1 - num1;
            }
            else
            {
              double num4 = (double) (num2 - x1) * (double) (y2 - y1) - (double) (x2 - x1) * (double) (num3 - y1);
              if (num4 != 0.0)
              {
                if (num4 > 0.0 == y2 > num3)
                  num1 = 1 - num1;
              }
              else
                goto label_15;
            }
          }
          else if (x2 > x1)
          {
            double num5 = (double) (num2 - x1) * (double) (y2 - y1) - (double) (x2 - x1) * (double) (num3 - y1);
            if (num5 != 0.0)
            {
              if (num5 > 0.0 == y2 > num3)
                num1 = 1 - num1;
            }
            else
              goto label_16;
          }
        }
        num2 = x2;
        num3 = y2;
      }
      else
        goto label_14;
    }
    while (class27 != class27_0);
    goto label_17;
label_14:
    int num6 = -1;
    goto label_18;
label_15:
    num6 = -1;
    goto label_18;
label_16:
    num6 = -1;
    goto label_18;
label_17:
    num6 = num1;
label_18:
    return num6;
  }

  static double smethod_249(IntPoint intPoint_0, buClipper buClipper_0, IntPoint intPoint_1)
  {
    return intPoint_1.Y != intPoint_0.Y ? (double) (intPoint_0.X - intPoint_1.X) / (double) (intPoint_0.Y - intPoint_1.Y) : -3.4E+38;
  }

  static bool smethod_250(
    ref double double_0,
    int int_0,
    ref string string_0,
    ref double double_1,
    ref Color color_0,
    buFile.Dxf dxf_0,
    ref double double_2,
    ref double double_3,
    ref double double_4)
  {
    bool flag1 = true;
    bool flag2 = true;
    bool flag3 = true;
    bool flag4 = false;
    bool flag5 = false;
    bool flag6 = false;
    int num = 0;
    for (int index = int_0; index <= dxf_0.list_0.Count - 1; ++index)
    {
      if (num < 80 /*0x50*/)
      {
        ++num;
        if (!(flag5 & flag6))
        {
          if (flag1 & dxf_0.list_0[index] == "AcDbEntity")
            string_0 = dxf_0.list_0[index + 2];
          if (flag1 & dxf_0.list_0[index] == "  8")
            string_0 = dxf_0.list_0[index + 1];
          if (flag1 & dxf_0.list_0[index] == "AcDbCircle")
            flag2 = true;
          if (flag1 & dxf_0.list_0[index] == "AcDbArc")
            flag3 = true;
          if (flag1 & dxf_0.list_0[index] == "CONTINUOUS")
          {
            flag2 = true;
            flag3 = true;
          }
          if (flag1 & dxf_0.list_0[index] == " 62")
          {
            int int32 = Convert.ToInt32(dxf_0.list_0[index + 1]);
            color_0 = int32 >= dxf_0.ColorCode.Length ? Color.Black : dxf_0.ColorCode[int32];
            if (color_0.A == (byte) 0 & color_0.R == (byte) 0 & color_0.G == (byte) 0 & color_0.B == (byte) 0)
              color_0 = Color.Black;
          }
          if (flag2 & dxf_0.list_0[index] == " 10")
            double_2 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
          if (flag2 & dxf_0.list_0[index] == " 20")
            double_0 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
          if (flag2 & dxf_0.list_0[index] == " 40")
            double_4 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
          if (flag3 & dxf_0.list_0[index] == " 50")
          {
            double_1 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
            flag6 = true;
          }
          if (flag3 & dxf_0.list_0[index] == " 51")
          {
            double_3 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
            flag5 = true;
          }
        }
        else
        {
          if (double_1 > double_3)
            double_3 += 360.0;
          flag4 = true;
          break;
        }
      }
      else
      {
        flag4 = false;
        break;
      }
    }
    return flag4;
  }

  static ICryptoTransform smethod_251(byte[] byte_0, bool bool_0, byte[] byte_1)
  {
    using (AesCryptoServiceProvider cryptoServiceProvider = new AesCryptoServiceProvider())
      return bool_0 ? cryptoServiceProvider.CreateDecryptor(byte_1, byte_0) : cryptoServiceProvider.CreateEncryptor(byte_1, byte_0);
  }

  static bool smethod_252(Class34.Class36 class36_0) => class36_0.int_0 == class36_0.int_1;

  static void smethod_253(int int_0, DelaunayTriangle delaunayTriangle_0, bool bool_0)
  {
    delaunayTriangle_0.fixedArray3_0[int_0] = bool_0;
  }

  static void smethod_254(
    ref Color color_0,
    ref double double_0,
    ref string string_0,
    int int_0,
    buFile.Dxf dxf_0,
    ref double double_1,
    ref double double_2)
  {
    bool flag1 = true;
    bool flag2 = true;
    for (int index = int_0; index <= dxf_0.list_0.Count - 1; ++index)
    {
      if (flag1 & dxf_0.list_0[index] == "AcDbEntity")
        string_0 = dxf_0.list_0[index + 2];
      if (flag1 & dxf_0.list_0[index] == "  8")
        string_0 = dxf_0.list_0[index + 1];
      if (flag1 & dxf_0.list_0[index] == "AcDbCircle")
        flag2 = true;
      if (flag1 & dxf_0.list_0[index] == "CONTINUOUS")
        flag2 = true;
      if (flag1 & dxf_0.list_0[index] == " 62")
      {
        int int32 = Convert.ToInt32(dxf_0.list_0[index + 1]);
        color_0 = int32 >= dxf_0.ColorCode.Length ? Color.Black : dxf_0.ColorCode[int32];
        if (color_0.A == (byte) 0 & color_0.R == (byte) 0 & color_0.G == (byte) 0 & color_0.B == (byte) 0)
          color_0 = Color.Black;
      }
      if (flag2 & dxf_0.list_0[index] == " 10")
        double_0 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
      if (flag2 & dxf_0.list_0[index] == " 20")
        double_1 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
      if (flag2 & dxf_0.list_0[index] == " 40")
      {
        double_2 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
        break;
      }
    }
  }

  static bool smethod_255(buFile.Dxf dxf_0, double double_0, double double_1)
  {
    return Math.Abs(double_0 - double_1) < dxf_0.double_2;
  }

  static double smethod_256(buFile.Dxf dxf_0, string string_0)
  {
    return Convert.ToDouble(string_0, (IFormatProvider) dxf_0.numberFormatInfo_0);
  }

  static bool smethod_257(AdvancingFrontNode advancingFrontNode_0, DTSweepContext dtsweepContext_0)
  {
    double num = !dtsweepContext_0.Basin.LeftHighest ? dtsweepContext_0.Basin.RightNode.Point.Y - advancingFrontNode_0.Point.Y : dtsweepContext_0.Basin.LeftNode.Point.Y - advancingFrontNode_0.Point.Y;
    return dtsweepContext_0.Basin.Width > num;
  }

  static int smethod_258(Class27 class27_0, buClipper buClipper_0)
  {
    int num1;
    if (class27_0 == null)
    {
      num1 = 0;
    }
    else
    {
      int num2 = 0;
      Class27 class27 = class27_0;
      do
      {
        ++num2;
        class27 = class27.class27_0;
      }
      while (class27 != class27_0);
      num1 = num2;
    }
    return num1;
  }

  static void smethod_259(long long_0, buClipper buClipper_0)
  {
    if (buClipper_0.class22_0 == null)
      return;
    Class22 class22_0_1 = buClipper_0.class22_0;
    buClipper_0.class22_1 = class22_0_1;
    for (; class22_0_1 != null; class22_0_1 = class22_0_1.class22_3)
    {
      class22_0_1.class22_6 = class22_0_1.class22_4;
      class22_0_1.class22_5 = class22_0_1.class22_3;
      class22_0_1.intPoint_1.X = Class30.smethod_101(class22_0_1, long_0);
    }
    bool flag = true;
    while ((!flag ? 0 : (buClipper_0.class22_1 != null ? 1 : 0)) != 0)
    {
      flag = false;
      Class22 class22_0_2 = buClipper_0.class22_1;
      while (class22_0_2.class22_5 != null)
      {
        Class22 class225 = class22_0_2.class22_5;
        if (class22_0_2.intPoint_1.X > class225.intPoint_1.X)
        {
          IntPoint intPoint_0;
          Class30.smethod_108(ref intPoint_0, class22_0_2, class225, buClipper_0);
          if (intPoint_0.Y < long_0)
            intPoint_0 = new IntPoint(Class30.smethod_101(class22_0_2, long_0), long_0);
          buClipper_0.list_2.Add(new IntersectNode()
          {
            class22_0 = class22_0_2,
            class22_1 = class225,
            intPoint_0 = intPoint_0
          });
          Class30.smethod_35(buClipper_0, class22_0_2, class225);
          flag = true;
        }
        else
          class22_0_2 = class225;
      }
      if (class22_0_2.class22_6 != null)
        class22_0_2.class22_6.class22_5 = (Class22) null;
      else
        break;
    }
    buClipper_0.class22_1 = (Class22) null;
  }

  static void smethod_260(buClipperBase buClipperBase_0, Class22 class22_0)
  {
    class22_0.intPoint_3.X = class22_0.intPoint_2.X - class22_0.intPoint_0.X;
    class22_0.intPoint_3.Y = class22_0.intPoint_2.Y - class22_0.intPoint_0.Y;
    if (class22_0.intPoint_3.Y == 0L)
      class22_0.double_0 = -3.4E+38;
    else
      class22_0.double_0 = (double) class22_0.intPoint_3.X / (double) class22_0.intPoint_3.Y;
  }

  static List<IntPoint> smethod_261(IntPoint intPoint_0, List<IntPoint> list_0)
  {
    List<IntPoint> intPointList = new List<IntPoint>(list_0.Count);
    for (int index = 0; index < list_0.Count; ++index)
      intPointList.Add(new IntPoint(list_0[index].X + intPoint_0.X, list_0[index].Y + intPoint_0.Y));
    return intPointList;
  }

  static void smethod_262(Class22 class22_0, buClipper buClipper_0, Class26 class26_0)
  {
    Class22 class224 = class22_0.class22_4;
    Class22 class22 = (Class22) null;
    for (; class224 != null; class224 = class224.class22_4)
    {
      if ((class224.int_3 < 0 ? 0 : (class224.int_0 != 0 ? 1 : 0)) != 0)
      {
        if (class22 == null)
          class22 = class224;
        else if (class22.int_3 == class224.int_3)
          class22 = (Class22) null;
      }
    }
    if (class22 == null)
    {
      class26_0.class26_0 = (Class26) null;
      class26_0.bool_0 = false;
    }
    else
    {
      class26_0.class26_0 = buClipper_0.list_1[class22.int_3];
      class26_0.bool_0 = !class26_0.class26_0.bool_0;
    }
  }

  static void smethod_263(
    TriangulationPoint triangulationPoint_0,
    TriangulationPoint triangulationPoint_1,
    DelaunayTriangle delaunayTriangle_0,
    DelaunayTriangle delaunayTriangle_1)
  {
    int index = delaunayTriangle_1.EdgeIndex(triangulationPoint_0, triangulationPoint_1);
    if (index == -1)
      throw new Exception("Error marking neighbors -- t doesn't contain edge p1-p2!");
    delaunayTriangle_1.Neighbors[index] = delaunayTriangle_0;
  }

  static void smethod_264(Pop3Client pop3Client_0, string string_0, string string_1)
  {
    try
    {
      Class30.smethod_144(pop3Client_0, "AUTH CRAM-MD5");
    }
    catch (PopServerException ex)
    {
      throw new NotSupportedException("CRAM-MD5 authentication not supported", (Exception) ex);
    }
    string string_0_1 = Class30.smethod_39(pop3Client_0.method_2().Substring(2), string_0, string_1);
    Class30.smethod_144(pop3Client_0, string_0_1);
  }

  static long smethod_265(string string_0)
  {
    string_0 = string_0.Trim();
    string string_0_1 = Class30.smethod_26(string_0);
    string s = string_0.Substring(0, string_0.Length - string_0_1.Length).Trim();
    return (long) ((double) Class30.smethod_128(string_0_1) * double.Parse(s, NumberStyles.Number, (IFormatProvider) CultureInfo.InvariantCulture));
  }

  static int smethod_266(Class34.Class38 class38_0, Class34.Class36 class36_0)
  {
    int index1;
    if ((index1 = Class30.smethod_292(class36_0, 9)) >= 0)
    {
      int num1;
      if ((num1 = (int) class38_0.short_0[index1]) >= 0)
      {
        Class30.smethod_94(class36_0, num1 & 15);
        return num1 >> 4;
      }
      int num2 = -(num1 >> 4);
      int int_0 = num1 & 15;
      int num3;
      if ((num3 = Class30.smethod_292(class36_0, int_0)) >= 0)
      {
        int num4 = (int) class38_0.short_0[num2 | num3 >> 9];
        Class30.smethod_94(class36_0, num4 & 15);
        return num4 >> 4;
      }
      int int2 = class36_0.int_2;
      int num5 = Class30.smethod_292(class36_0, int2);
      int num6 = (int) class38_0.short_0[num2 | num5 >> 9];
      if ((num6 & 15) > int2)
        return -1;
      Class30.smethod_94(class36_0, num6 & 15);
      return num6 >> 4;
    }
    int int2_1 = class36_0.int_2;
    int index2 = Class30.smethod_292(class36_0, int2_1);
    int num = (int) class38_0.short_0[index2];
    if (num < 0 || (num & 15) > int2_1)
      return -1;
    Class30.smethod_94(class36_0, num & 15);
    return num >> 4;
  }

  static RfcMailAddress smethod_267(string string_0)
  {
    string_0 = string_0 != null ? Class30.smethod_179(string_0.Trim()) : throw new ArgumentNullException("input");
    int length1 = string_0.LastIndexOf('<');
    int num = string_0.LastIndexOf('>');
    RfcMailAddress rfcMailAddress;
    try
    {
      if ((length1 < 0 ? 0 : (num >= 0 ? 1 : 0)) != 0)
      {
        string displayName = length1 <= 0 ? string.Empty : string_0.Substring(0, length1).Trim();
        int startIndex = length1 + 1;
        int length2 = num - startIndex;
        string address = string_0.Substring(startIndex, length2).Trim();
        if (!string.IsNullOrEmpty(address))
        {
          rfcMailAddress = new RfcMailAddress(new MailAddress(address, displayName), string_0);
          goto label_10;
        }
      }
      if (string_0.Contains("@"))
      {
        rfcMailAddress = new RfcMailAddress(new MailAddress(string_0), string_0);
        goto label_10;
      }
    }
    catch (FormatException ex)
    {
      DefaultLogger.Log.LogError($"RfcMailAddress: Improper mail address: \"{string_0}\"");
    }
    rfcMailAddress = new RfcMailAddress(string_0);
label_10:
    return rfcMailAddress;
  }

  static Encoding smethod_268(string string_0)
  {
    Encoding encoding = Encoding.ASCII;
    if (!string.IsNullOrEmpty(string_0))
      encoding = Class30.smethod_224(string_0);
    return encoding;
  }

  static void smethod_269(DTSweepContext dtsweepContext_0, AdvancingFrontNode advancingFrontNode_0)
  {
    if (Class30.smethod_257(advancingFrontNode_0, dtsweepContext_0))
      return;
    Class30.smethod_51(dtsweepContext_0, advancingFrontNode_0);
    if ((advancingFrontNode_0.Prev != dtsweepContext_0.Basin.LeftNode ? 0 : (advancingFrontNode_0.Next == dtsweepContext_0.Basin.RightNode ? 1 : 0)) != 0)
      return;
    if (advancingFrontNode_0.Prev == dtsweepContext_0.Basin.LeftNode)
    {
      if (TriangulationUtil.Orient2d((Point2D) advancingFrontNode_0.Point, (Point2D) advancingFrontNode_0.Next.Point, (Point2D) advancingFrontNode_0.Next.Next.Point) == Orientation.Clockwise)
        return;
      advancingFrontNode_0 = advancingFrontNode_0.Next;
    }
    else if (advancingFrontNode_0.Next == dtsweepContext_0.Basin.RightNode)
    {
      if (TriangulationUtil.Orient2d((Point2D) advancingFrontNode_0.Point, (Point2D) advancingFrontNode_0.Prev.Point, (Point2D) advancingFrontNode_0.Prev.Prev.Point) == Orientation.AntiClockwise)
        return;
      advancingFrontNode_0 = advancingFrontNode_0.Prev;
    }
    else
      advancingFrontNode_0 = advancingFrontNode_0.Prev.Point.Y < advancingFrontNode_0.Next.Point.Y ? advancingFrontNode_0.Prev : advancingFrontNode_0.Next;
    Class30.smethod_269(dtsweepContext_0, advancingFrontNode_0);
  }

  static buFile.PLYToSchematic.Class20 smethod_270(StreamReader streamReader_0)
  {
    buFile.PLYToSchematic.Class20 class20 = new buFile.PLYToSchematic.Class20();
    string str1 = streamReader_0.ReadLine();
    int num1 = 0 + (str1.Length + 1);
    if (str1 != "ply")
      throw new ArgumentException("Magic number ('ply') mismatch.");
    string str2 = streamReader_0.ReadLine();
    int num2 = num1 + (str2.Length + 1);
    class20.bool_0 = str2 == "format binary_little_endian 1.0";
    bool flag = false;
    string str3;
    while (true)
    {
      string[] strArray;
      do
      {
        str3 = streamReader_0.ReadLine();
        num2 += str3.Length + 1;
        if (!(str3 == "end_header"))
        {
          strArray = str3.Split();
          if (strArray[0] == "element")
          {
            if (strArray[1] == "vertex")
            {
              class20.int_0 = Convert.ToInt32(strArray[2]);
              flag = false;
            }
            else
              flag = true;
          }
        }
        else
          goto label_68;
      }
      while (flag || !(strArray[0] == "property"));
      buFile.PLYToSchematic.Enum1 enum1_0 = buFile.PLYToSchematic.Enum1.const_0;
      string string_0_1 = strArray[2];
      switch (Class30.smethod_119(string_0_1))
      {
        case 18738364:
          if (string_0_1 == "green")
          {
            enum1_0 = buFile.PLYToSchematic.Enum1.const_2;
            break;
          }
          break;
        case 1089765596:
          if (string_0_1 == "red")
          {
            enum1_0 = buFile.PLYToSchematic.Enum1.const_1;
            break;
          }
          break;
        case 1569418667:
          if (string_0_1 == "alpha")
          {
            enum1_0 = buFile.PLYToSchematic.Enum1.const_4;
            break;
          }
          break;
        case 2197550541:
          if (string_0_1 == "blue")
          {
            enum1_0 = buFile.PLYToSchematic.Enum1.const_3;
            break;
          }
          break;
        case 4228665076:
          if (string_0_1 == "y")
          {
            enum1_0 = buFile.PLYToSchematic.Enum1.const_10;
            break;
          }
          break;
        case 4245442695:
          if (string_0_1 == "x")
          {
            enum1_0 = buFile.PLYToSchematic.Enum1.const_9;
            break;
          }
          break;
        case 4278997933:
          if (string_0_1 == "z")
          {
            enum1_0 = buFile.PLYToSchematic.Enum1.const_11;
            break;
          }
          break;
      }
      string string_0_2 = strArray[1];
      switch (Class30.smethod_119(string_0_2))
      {
        case 64103268:
          if (string_0_2 == "int64")
            break;
          goto label_67;
        case 132346577:
          if (string_0_2 == "int16")
            goto label_45;
          goto label_67;
        case 429781723:
          if (string_0_2 == "uint8")
            goto label_58;
          goto label_67;
        case 848563180:
          if (string_0_2 == "uint32")
            goto label_54;
          goto label_67;
        case 1630192034:
          if (string_0_2 == "ushort")
            goto label_45;
          goto label_67;
        case 1687288466:
          if (string_0_2 == "int8")
            goto label_58;
          goto label_67;
        case 2090339911:
          if (string_0_2 == "float64")
            break;
          goto label_67;
        case 2515107422:
          if (string_0_2 == "int")
            goto label_54;
          goto label_67;
        case 2699759368:
          if (string_0_2 == "double")
            break;
          goto label_67;
        case 2797886853:
          if (string_0_2 == "float")
            goto label_54;
          goto label_67;
        case 2823553821:
          if (string_0_2 == "char")
            goto label_58;
          goto label_67;
        case 2928590578:
          if (string_0_2 == "uint16")
            goto label_45;
          goto label_67;
        case 2929723411:
          if (!(string_0_2 == "uint64"))
            goto label_67;
          break;
        case 3122818005:
          if (!(string_0_2 == "short"))
            goto label_67;
          goto label_45;
        case 3415750305:
          if (string_0_2 == "uint")
            goto label_54;
          goto label_67;
        case 3473883116:
          if (!(string_0_2 == "uchar"))
            goto label_67;
          goto label_58;
        case 3902764048:
          if (!(string_0_2 == "float32"))
            goto label_67;
          goto label_54;
        case 4225688255:
          if (string_0_2 == "int32")
            goto label_54;
          goto label_67;
        default:
          goto label_67;
      }
      switch (enum1_0)
      {
        case buFile.PLYToSchematic.Enum1.const_0:
          enum1_0 = buFile.PLYToSchematic.Enum1.const_18;
          break;
        case buFile.PLYToSchematic.Enum1.const_9:
          enum1_0 = buFile.PLYToSchematic.Enum1.const_12;
          break;
        case buFile.PLYToSchematic.Enum1.const_10:
          enum1_0 = buFile.PLYToSchematic.Enum1.const_13;
          break;
        case buFile.PLYToSchematic.Enum1.const_11:
          enum1_0 = buFile.PLYToSchematic.Enum1.const_14;
          break;
      }
      if (Class30.smethod_50(enum1_0) == 8)
        goto label_61;
      break;
label_45:
      switch (enum1_0)
      {
        case buFile.PLYToSchematic.Enum1.const_0:
          enum1_0 = buFile.PLYToSchematic.Enum1.const_16;
          break;
        case buFile.PLYToSchematic.Enum1.const_1:
          enum1_0 = buFile.PLYToSchematic.Enum1.const_5;
          break;
        case buFile.PLYToSchematic.Enum1.const_2:
          enum1_0 = buFile.PLYToSchematic.Enum1.const_6;
          break;
        case buFile.PLYToSchematic.Enum1.const_3:
          enum1_0 = buFile.PLYToSchematic.Enum1.const_7;
          break;
        case buFile.PLYToSchematic.Enum1.const_4:
          enum1_0 = buFile.PLYToSchematic.Enum1.const_8;
          break;
      }
      if (Class30.smethod_50(enum1_0) == 2)
        goto label_61;
      goto label_64;
label_54:
      if (enum1_0 == buFile.PLYToSchematic.Enum1.const_0)
      {
        enum1_0 = buFile.PLYToSchematic.Enum1.const_17;
        goto label_61;
      }
      if (Class30.smethod_50(enum1_0) == 4)
        goto label_61;
      goto label_65;
label_58:
      if (enum1_0 == buFile.PLYToSchematic.Enum1.const_0)
        enum1_0 = buFile.PLYToSchematic.Enum1.const_15;
      else if (Class30.smethod_50(enum1_0) != 1)
        goto label_66;
label_61:
      class20.list_0.Add(enum1_0);
    }
    throw new ArgumentException($"Invalid property type ('{str3}').");
label_64:
    throw new ArgumentException($"Invalid property type ('{str3}').");
label_65:
    throw new ArgumentException($"Invalid property type ('{str3}').");
label_66:
    throw new ArgumentException($"Invalid property type ('{str3}').");
label_67:
    throw new ArgumentException($"Unsupported property type ('{str3}').");
label_68:
    streamReader_0.BaseStream.Position = (long) num2;
    return class20;
  }

  static void smethod_271(
    AdvancingFrontNode advancingFrontNode_0,
    DTSweepContext dtsweepContext_0,
    TriangulationConstraint triangulationConstraint_0)
  {
    if (dtsweepContext_0.IsDebugEnabled)
      dtsweepContext_0.DebugContext.ActiveNode = advancingFrontNode_0;
    if (advancingFrontNode_0.Point.X >= triangulationConstraint_0.P.X)
      return;
    if (TriangulationUtil.Orient2d((Point2D) advancingFrontNode_0.Point, (Point2D) advancingFrontNode_0.Next.Point, (Point2D) advancingFrontNode_0.Next.Next.Point) == Orientation.AntiClockwise)
    {
      Class30.smethod_123(triangulationConstraint_0, advancingFrontNode_0, dtsweepContext_0);
    }
    else
    {
      Class30.smethod_157(triangulationConstraint_0, advancingFrontNode_0, dtsweepContext_0);
      Class30.smethod_271(advancingFrontNode_0, dtsweepContext_0, triangulationConstraint_0);
    }
  }

  static Class26 smethod_272(buClipper buClipper_0, int int_0)
  {
    Class26 class26 = buClipper_0.list_1[int_0];
    while (class26 != buClipper_0.list_1[class26.int_0])
      class26 = buClipper_0.list_1[class26.int_0];
    return class26;
  }

  static bool smethod_273(buClipper buClipper_0, Class22 class22_0)
  {
    return class22_0.polyType_0 != PolyType.ptSubject ? buClipper_0.polyFillType_0 == PolyFillType.pftEvenOdd : buClipper_0.polyFillType_1 == PolyFillType.pftEvenOdd;
  }

  static void smethod_274(MessagePart messagePart_0, byte[] byte_0)
  {
    if (messagePart_0.IsMultiPart)
      messagePart_0.method_0(byte_0);
    else
      messagePart_0.Body = Class30.smethod_178(messagePart_0.ContentTransferEncoding, byte_0);
  }

  static byte[] smethod_275(string string_0)
  {
    return string_0 != null ? Class30.smethod_297(string_0, false) : throw new ArgumentNullException("toDecode");
  }

  static void smethod_276(buClipperBase buClipperBase_0, int int_0)
  {
    buClipperBase_0.list_1[int_0].class27_0 = (Class27) null;
    buClipperBase_0.list_1[int_0] = (Class26) null;
  }

  static byte[] smethod_277(byte[] byte_0)
  {
    Class34.Stream0 stream0_0 = new Class34.Stream0(byte_0);
    byte[] byte_0_1 = new byte[0];
    int num = Class30.smethod_116(stream0_0);
    int actualValue = num >> 24;
    if (num - (actualValue << 24) != 8223355)
      throw new FormatException("Unknown Header");
    switch (actualValue)
    {
      case 1:
        int length1 = Class30.smethod_116(stream0_0);
        byte_0_1 = new byte[length1];
        int int_0;
        for (int int_1 = 0; int_1 < length1; int_1 += int_0)
        {
          int length2 = Class30.smethod_116(stream0_0);
          int_0 = Class30.smethod_116(stream0_0);
          byte[] numArray = new byte[length2];
          stream0_0.Read(numArray, 0, numArray.Length);
          Class30.smethod_46(byte_0_1, int_0, new Class34.Class35(numArray), int_1);
        }
        break;
      case 3:
        using (ICryptoTransform cryptoTransform = Class30.smethod_251(new byte[16 /*0x10*/]
        {
          (byte) 73,
          (byte) 187,
          (byte) 167,
          (byte) 105,
          (byte) 241,
          (byte) 126,
          (byte) 12,
          (byte) 10,
          (byte) 154,
          (byte) 165,
          (byte) 169,
          (byte) 68,
          (byte) 134,
          (byte) 76,
          (byte) 145,
          (byte) 92
        }, true, new byte[16 /*0x10*/]
        {
          (byte) 135,
          (byte) 156,
          (byte) 161,
          (byte) 171,
          (byte) 165,
          (byte) 250,
          (byte) 192 /*0xC0*/,
          (byte) 197,
          (byte) 57,
          (byte) 16 /*0x10*/,
          (byte) 2,
          (byte) 108,
          (byte) 15,
          (byte) 110,
          (byte) 214,
          (byte) 154
        }))
        {
          byte_0_1 = Class30.smethod_277(cryptoTransform.TransformFinalBlock(byte_0, 4, byte_0.Length - 4));
          break;
        }
      default:
        throw new ArgumentOutOfRangeException("version", (object) actualValue, "Selected compression algorithm is not supported.");
    }
    stream0_0.Close();
    return byte_0_1;
  }

  static bool smethod_278(
    int int_0,
    ref double double_0,
    ref Color color_0,
    ref double double_1,
    ref string string_0,
    buFile.Dxf dxf_0,
    ref double double_2,
    ref double double_3,
    ref string string_1,
    ref double double_4)
  {
    bool flag = false;
    int num = 0;
    for (int index = int_0; index <= dxf_0.list_0.Count - 1; ++index)
    {
      if (num < 45)
      {
        ++num;
        string str = dxf_0.list_0[index];
        if (dxf_0.list_0[index] == "  8")
          string_0 = dxf_0.list_0[index + 1];
        if (dxf_0.list_0[index] == " 62")
        {
          int int32 = Convert.ToInt32(dxf_0.list_0[index + 1]);
          if (int32 != 1)
            ;
          color_0 = int32 >= dxf_0.ColorCode.Length ? Color.Black : dxf_0.ColorCode[int32];
          if (color_0.A == (byte) 0 & color_0.R == (byte) 0 & color_0.G == (byte) 0 & color_0.B == (byte) 0)
            color_0 = Color.Black;
        }
        if (dxf_0.list_0[index] == " 10")
          double_1 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
        if (dxf_0.list_0[index] == " 20")
          double_0 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
        if (dxf_0.list_0[index] == " 30")
          double_3 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
        if (dxf_0.list_0[index] == " 40")
          double_4 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
        if (dxf_0.list_0[index] == " 50")
          double_2 = Class30.smethod_256(dxf_0, dxf_0.list_0[index + 1]);
        if (dxf_0.list_0[index] == "  1")
        {
          string_1 = dxf_0.list_0[index + 1];
          if (string_1.IndexOf("beyaz") < 0)
            ;
          flag = true;
        }
        if (dxf_0.list_0[index] == "  0")
          break;
      }
      else
      {
        flag = false;
        break;
      }
    }
    return flag;
  }

  static void smethod_279(Pop3Client pop3Client_0)
  {
    pop3Client_0.method_5((string) null);
    pop3Client_0.Connected = false;
    pop3Client_0.method_7(Enum0.const_0);
    pop3Client_0.ApopSupported = false;
  }

  static bool smethod_280(
    ref DTSweepConstraint dtsweepConstraint_0,
    [Out] DelaunayTriangle delaunayTriangle_0,
    int int_0)
  {
    dtsweepConstraint_0 = (DTSweepConstraint) null;
    bool flag;
    if ((int_0 < 0 ? 1 : (int_0 > 2 ? 1 : 0)) != 0)
    {
      flag = false;
    }
    else
    {
      TriangulationPoint point1 = delaunayTriangle_0.Points[(int_0 + 1) % 3];
      TriangulationPoint point2 = delaunayTriangle_0.Points[(int_0 + 2) % 3];
      flag = point1.GetEdge(point2, out dtsweepConstraint_0) || point2.GetEdge(point1, out dtsweepConstraint_0);
    }
    return flag;
  }

  static Class26 smethod_281(Class26 class26_0)
  {
    while ((class26_0 == null ? 0 : (class26_0.class27_0 == null ? 1 : 0)) != 0)
      class26_0 = class26_0.class26_0;
    return class26_0;
  }

  static bool smethod_282(
    double double_0,
    double double_1,
    double double_2,
    double double_3,
    double double_4,
    double double_5,
    double double_6)
  {
    bool flag;
    if ((!MathUtil.IsValueBetween(double_5, double_1, double_0, double_3) ? 0 : (MathUtil.IsValueBetween(double_2, double_6, double_4, double_3) ? 1 : 0)) != 0)
    {
      if (MathUtil.AreValuesEqual(double_0 - double_1, 0.0, double_3))
      {
        flag = true;
      }
      else
      {
        double num1 = (double_4 - double_6) / (double_0 - double_1);
        double num2 = -(num1 * double_1) + double_6;
        flag = MathUtil.AreValuesEqual(double_2 - (num1 * double_5 + num2), 0.0, double_3);
      }
    }
    else
      flag = false;
    return flag;
  }

  static void smethod_283()
  {
    EncodingFinder.smethod_1(new Dictionary<string, Encoding>());
    EncodingFinder.FallbackDecoder = (EncodingFinder.FallbackDecoderDelegate) null;
    EncodingFinder.AddMapping("utf8", Encoding.UTF8);
  }

  static void smethod_284(buClipperBase buClipperBase_0, Class22 class22_0)
  {
    buClipperBase_0.Swap(ref class22_0.intPoint_2.X, ref class22_0.intPoint_0.X);
    buClipperBase_0.Swap(ref class22_0.intPoint_2.Z, ref class22_0.intPoint_0.Z);
  }

  static void smethod_285(TriangulationContext triangulationContext_0)
  {
    int algorithm = (int) triangulationContext_0.Algorithm;
    DTSweep.Triangulate((DTSweepContext) triangulationContext_0);
  }

  static void smethod_286(buClipperBase buClipperBase_0)
  {
    Class23 class230;
    for (; buClipperBase_0.class23_0 != null; buClipperBase_0.class23_0 = class230)
    {
      class230 = buClipperBase_0.class23_0.class23_0;
      buClipperBase_0.class23_0 = (Class23) null;
    }
    buClipperBase_0.class23_1 = (Class23) null;
  }

  static void smethod_287(
    IntPoint intPoint_0,
    buClipper buClipper_0,
    Class22 class22_0,
    Class22 class22_1)
  {
    bool flag1 = class22_0.int_3 >= 0;
    bool flag2 = class22_1.int_3 >= 0;
    Class30.smethod_207(buClipper_0, ref intPoint_0, class22_0, class22_1);
    if ((class22_0.int_0 == 0 ? 1 : (class22_1.int_0 == 0 ? 1 : 0)) != 0)
    {
      if ((class22_0.int_0 != 0 ? 0 : (class22_1.int_0 == 0 ? 1 : 0)) != 0)
        return;
      if ((class22_0.polyType_0 != class22_1.polyType_0 || class22_0.int_0 == class22_1.int_0 ? 0 : (buClipper_0.clipType_0 == ClipType.ctUnion ? 1 : 0)) != 0)
      {
        if (class22_0.int_0 == 0)
        {
          if (!flag2)
            return;
          Class30.smethod_246(buClipper_0, class22_0, intPoint_0);
          if (!flag1)
            return;
          class22_0.int_3 = -1;
        }
        else
        {
          if (!flag1)
            return;
          Class30.smethod_246(buClipper_0, class22_1, intPoint_0);
          if (!flag2)
            return;
          class22_1.int_3 = -1;
        }
      }
      else
      {
        if (class22_0.polyType_0 == class22_1.polyType_0)
          return;
        if ((class22_0.int_0 != 0 || Math.Abs(class22_1.int_1) != 1 ? 0 : (buClipper_0.clipType_0 != ClipType.ctUnion ? 1 : (class22_1.int_2 == 0 ? 1 : 0))) != 0)
        {
          Class30.smethod_246(buClipper_0, class22_0, intPoint_0);
          if (!flag1)
            return;
          class22_0.int_3 = -1;
        }
        else
        {
          if ((class22_1.int_0 != 0 || Math.Abs(class22_0.int_1) != 1 ? 0 : (buClipper_0.clipType_0 != ClipType.ctUnion ? 1 : (class22_0.int_2 == 0 ? 1 : 0))) == 0)
            return;
          Class30.smethod_246(buClipper_0, class22_1, intPoint_0);
          if (!flag2)
            return;
          class22_1.int_3 = -1;
        }
      }
    }
    else
    {
      if (class22_0.polyType_0 == class22_1.polyType_0)
      {
        if (Class30.smethod_273(buClipper_0, class22_0))
        {
          int int1 = class22_0.int_1;
          class22_0.int_1 = class22_1.int_1;
          class22_1.int_1 = int1;
        }
        else
        {
          if (class22_0.int_1 + class22_1.int_0 == 0)
            class22_0.int_1 = -class22_0.int_1;
          else
            class22_0.int_1 += class22_1.int_0;
          if (class22_1.int_1 - class22_0.int_0 == 0)
            class22_1.int_1 = -class22_1.int_1;
          else
            class22_1.int_1 -= class22_0.int_0;
        }
      }
      else
      {
        if (!Class30.smethod_273(buClipper_0, class22_1))
          class22_0.int_2 += class22_1.int_0;
        else
          class22_0.int_2 = class22_0.int_2 == 0 ? 1 : 0;
        if (!Class30.smethod_273(buClipper_0, class22_0))
          class22_1.int_2 -= class22_0.int_0;
        else
          class22_1.int_2 = class22_1.int_2 == 0 ? 1 : 0;
      }
      PolyFillType polyFillType1;
      PolyFillType polyFillType2;
      if (class22_0.polyType_0 == PolyType.ptSubject)
      {
        polyFillType1 = buClipper_0.polyFillType_1;
        polyFillType2 = buClipper_0.polyFillType_0;
      }
      else
      {
        polyFillType1 = buClipper_0.polyFillType_0;
        polyFillType2 = buClipper_0.polyFillType_1;
      }
      PolyFillType polyFillType3;
      PolyFillType polyFillType4;
      if (class22_1.polyType_0 == PolyType.ptSubject)
      {
        polyFillType3 = buClipper_0.polyFillType_1;
        polyFillType4 = buClipper_0.polyFillType_0;
      }
      else
      {
        polyFillType3 = buClipper_0.polyFillType_0;
        polyFillType4 = buClipper_0.polyFillType_1;
      }
      int num1;
      switch (polyFillType1)
      {
        case PolyFillType.pftPositive:
          num1 = class22_0.int_1;
          break;
        case PolyFillType.pftNegative:
          num1 = -class22_0.int_1;
          break;
        default:
          num1 = Math.Abs(class22_0.int_1);
          break;
      }
      int num2;
      switch (polyFillType3)
      {
        case PolyFillType.pftPositive:
          num2 = class22_1.int_1;
          break;
        case PolyFillType.pftNegative:
          num2 = -class22_1.int_1;
          break;
        default:
          num2 = Math.Abs(class22_1.int_1);
          break;
      }
      if (flag1 & flag2)
      {
        if ((num1 != 0 && num1 != 1 || num2 != 0 && num2 != 1 ? 1 : (class22_0.polyType_0 == class22_1.polyType_0 ? 0 : (buClipper_0.clipType_0 != ClipType.ctXor ? 1 : 0))) != 0)
        {
          Class30.smethod_1(intPoint_0, class22_0, class22_1, buClipper_0);
        }
        else
        {
          Class30.smethod_246(buClipper_0, class22_0, intPoint_0);
          Class30.smethod_246(buClipper_0, class22_1, intPoint_0);
          Class30.smethod_164(class22_0, class22_1);
          Class30.smethod_100(class22_0, class22_1);
        }
      }
      else if (flag1)
      {
        if ((num2 == 0 ? 1 : (num2 == 1 ? 1 : 0)) == 0)
          return;
        Class30.smethod_246(buClipper_0, class22_0, intPoint_0);
        Class30.smethod_164(class22_0, class22_1);
        Class30.smethod_100(class22_0, class22_1);
      }
      else if (flag2)
      {
        if ((num1 == 0 ? 1 : (num1 == 1 ? 1 : 0)) == 0)
          return;
        Class30.smethod_246(buClipper_0, class22_1, intPoint_0);
        Class30.smethod_164(class22_0, class22_1);
        Class30.smethod_100(class22_0, class22_1);
      }
      else
      {
        if ((num1 == 0 || num1 == 1 ? (num2 == 0 ? 1 : (num2 == 1 ? 1 : 0)) : 0) == 0)
          return;
        long num3;
        switch (polyFillType2)
        {
          case PolyFillType.pftPositive:
            num3 = (long) class22_0.int_2;
            break;
          case PolyFillType.pftNegative:
            num3 = (long) -class22_0.int_2;
            break;
          default:
            num3 = (long) Math.Abs(class22_0.int_2);
            break;
        }
        long num4;
        switch (polyFillType4)
        {
          case PolyFillType.pftPositive:
            num4 = (long) class22_1.int_2;
            break;
          case PolyFillType.pftNegative:
            num4 = (long) -class22_1.int_2;
            break;
          default:
            num4 = (long) Math.Abs(class22_1.int_2);
            break;
        }
        if (class22_0.polyType_0 != class22_1.polyType_0)
          Class30.smethod_230(buClipper_0, class22_0, class22_1, intPoint_0);
        else if ((num1 != 1 ? 0 : (num2 == 1 ? 1 : 0)) != 0)
        {
          switch (buClipper_0.clipType_0)
          {
            case ClipType.ctIntersection:
              if ((num3 <= 0L ? 0 : (num4 > 0L ? 1 : 0)) == 0)
                break;
              Class30.smethod_230(buClipper_0, class22_0, class22_1, intPoint_0);
              break;
            case ClipType.ctUnion:
              if ((num3 > 0L ? 0 : (num4 <= 0L ? 1 : 0)) == 0)
                break;
              Class30.smethod_230(buClipper_0, class22_0, class22_1, intPoint_0);
              break;
            case ClipType.ctDifference:
              if ((class22_0.polyType_0 != PolyType.ptClip || num3 <= 0L || num4 <= 0L ? (class22_0.polyType_0 != PolyType.ptSubject || num3 > 0L ? 0 : (num4 <= 0L ? 1 : 0)) : 1) == 0)
                break;
              Class30.smethod_230(buClipper_0, class22_0, class22_1, intPoint_0);
              break;
            case ClipType.ctXor:
              Class30.smethod_230(buClipper_0, class22_0, class22_1, intPoint_0);
              break;
          }
        }
        else
          Class30.smethod_164(class22_0, class22_1);
      }
    }
  }

  static bool smethod_288(char char_0) => char_0 >= '0' && char_0 <= '9';

  static void smethod_289(
    DelaunayTriangle delaunayTriangle_0,
    Point2D point2D_0,
    DTSweepContext dtsweepContext_0,
    TriangulationPoint triangulationPoint_0,
    DelaunayTriangle delaunayTriangle_1,
    TriangulationPoint triangulationPoint_1)
  {
    DelaunayTriangle delaunayTriangle_0_1 = delaunayTriangle_0.NeighborAcrossFrom(triangulationPoint_0);
    TriangulationPoint triangulationPoint = delaunayTriangle_0_1.OppositePoint(delaunayTriangle_0, triangulationPoint_0);
    if (delaunayTriangle_0_1 == null)
      throw new Exception("[BUG:FIXME] FLIP failed due to missing triangle");
    if (dtsweepContext_0.IsDebugEnabled)
    {
      Console.WriteLine("[FLIP:SCAN] - scan next point");
      dtsweepContext_0.DebugContext.PrimaryTriangle = delaunayTriangle_0;
      dtsweepContext_0.DebugContext.SecondaryTriangle = delaunayTriangle_0_1;
    }
    if (TriangulationUtil.InScanArea((Point2D) triangulationPoint_1, (Point2D) delaunayTriangle_1.PointCCWFrom(triangulationPoint_1), (Point2D) delaunayTriangle_1.PointCWFrom(triangulationPoint_1), (Point2D) triangulationPoint))
    {
      Class30.smethod_41(triangulationPoint, dtsweepContext_0, triangulationPoint_1, triangulationPoint, delaunayTriangle_0_1);
    }
    else
    {
      TriangulationPoint triangulationPoint_0_1;
      if (!Class30.smethod_156(ref triangulationPoint_0_1, point2D_0, delaunayTriangle_0_1, triangulationPoint, (Point2D) triangulationPoint_1))
        return;
      Class30.smethod_289(delaunayTriangle_0_1, point2D_0, dtsweepContext_0, triangulationPoint_0_1, delaunayTriangle_1, triangulationPoint_1);
    }
  }

  static void smethod_290(
    IList<Point2D> ilist_0,
    Point2D point2D_0,
    ref List<Point2D> list_0,
    [Out] Point2D point2D_1)
  {
    list_0 = (List<Point2D>) null;
    if ((point2D_1 == null || point2D_0 == null || ilist_0 == null ? 1 : (ilist_0.Count < 3 ? 1 : 0)) != 0)
      return;
    list_0 = new List<Point2D>();
    int index1 = ilist_0.Count - 1;
    Point2D ptRayVector1 = new Point2D(point2D_0.X - point2D_1.X, point2D_0.Y - point2D_1.Y);
    bool flag1 = TriangulationUtil.Orient2d(point2D_1, point2D_0, ilist_0[index1]) == Orientation.Clockwise;
    Point2D ptRayVector0 = new Point2D(0.0, 0.0);
    for (int index2 = 0; index2 < ilist_0.Count; ++index2)
    {
      bool flag2;
      if (flag2 = TriangulationUtil.Orient2d(point2D_1, point2D_0, ilist_0[index2]) == Orientation.Clockwise)
      {
        if (flag1)
        {
          list_0.Add(ilist_0[index2]);
        }
        else
        {
          ptRayVector0.Set(ilist_0[index2].X - ilist_0[index1].X, ilist_0[index2].Y - ilist_0[index1].Y);
          Point2D ptIntersection = new Point2D(0.0, 0.0);
          if (TriangulationUtil.RaysIntersect2D(ilist_0[index1], ptRayVector0, point2D_1, ptRayVector1, ref ptIntersection))
          {
            list_0.Add(ptIntersection);
            list_0.Add(ilist_0[index2]);
          }
        }
      }
      else if (flag1)
      {
        ptRayVector0.Set(ilist_0[index2].X - ilist_0[index1].X, ilist_0[index2].Y - ilist_0[index1].Y);
        Point2D ptIntersection = new Point2D(0.0, 0.0);
        if (TriangulationUtil.RaysIntersect2D(ilist_0[index1], ptRayVector0, point2D_1, ptRayVector1, ref ptIntersection))
          list_0.Add(ptIntersection);
      }
      index1 = index2;
      flag1 = flag2;
    }
  }

  static double smethod_291(Pnt3D pnt3D_0, Pnt3D pnt3D_1, buVector buVector_0, Pnt3D pnt3D_2)
  {
    return (pnt3D_2.X - pnt3D_0.X) * (pnt3D_1.Y - pnt3D_0.Y) - (pnt3D_1.X - pnt3D_0.X) * (pnt3D_2.Y - pnt3D_0.Y);
  }

  static int smethod_292(Class34.Class36 class36_0, int int_0)
  {
    if (class36_0.int_2 < int_0)
    {
      if (class36_0.int_0 == class36_0.int_1)
        return -1;
      Class34.Class36 class36_1 = class36_0;
      int uint0 = (int) class36_0.uint_0;
      byte[] byte0_1 = class36_0.byte_0;
      Class34.Class36 class36_2 = class36_0;
      int int0_1 = class36_0.int_0;
      int num1 = int0_1 + 1;
      class36_2.int_0 = num1;
      int index1 = int0_1;
      int num2 = (int) byte0_1[index1] & (int) byte.MaxValue;
      byte[] byte0_2 = class36_0.byte_0;
      Class34.Class36 class36_3 = class36_0;
      int int0_2 = class36_0.int_0;
      int num3 = int0_2 + 1;
      class36_3.int_0 = num3;
      int index2 = int0_2;
      int num4 = ((int) byte0_2[index2] & (int) byte.MaxValue) << 8;
      int num5 = (num2 | num4) << class36_0.int_2;
      int num6 = uint0 | num5;
      class36_1.uint_0 = (uint) num6;
      class36_0.int_2 += 16 /*0x10*/;
    }
    return (int) ((long) class36_0.uint_0 & (long) ((1 << int_0) - 1));
  }

  static bool smethod_293(
    buClipper buClipper_0,
    Class28 class28_0,
    Class26 class26_0,
    Class26 class26_1)
  {
    Class27 class27_1 = class28_0.class27_0;
    Class27 class271 = class28_0.class27_1;
    bool flag1;
    bool flag2;
    if ((!(flag1 = class28_0.class27_0.intPoint_0.Y == class28_0.intPoint_0.Y) || !(class28_0.intPoint_0 == class28_0.class27_0.intPoint_0) ? 0 : (class28_0.intPoint_0 == class28_0.class27_1.intPoint_0 ? 1 : 0)) != 0)
    {
      if (class26_0 != class26_1)
      {
        flag2 = false;
      }
      else
      {
        Class27 class270_1 = class28_0.class27_0.class27_0;
        while ((class270_1 == class27_1 ? 0 : (class270_1.intPoint_0 == class28_0.intPoint_0 ? 1 : 0)) != 0)
          class270_1 = class270_1.class27_0;
        bool flag3 = class270_1.intPoint_0.Y > class28_0.intPoint_0.Y;
        Class27 class270_2 = class28_0.class27_1.class27_0;
        while ((class270_2 == class271 ? 0 : (class270_2.intPoint_0 == class28_0.intPoint_0 ? 1 : 0)) != 0)
          class270_2 = class270_2.class27_0;
        bool flag4 = class270_2.intPoint_0.Y > class28_0.intPoint_0.Y;
        if (flag3 == flag4)
          flag2 = false;
        else if (flag3)
        {
          Class27 class27_2 = Class30.smethod_139(buClipper_0, class27_1, false);
          Class27 class27_3 = Class30.smethod_139(buClipper_0, class271, true);
          class27_1.class27_1 = class271;
          class271.class27_0 = class27_1;
          class27_2.class27_0 = class27_3;
          class27_3.class27_1 = class27_2;
          class28_0.class27_0 = class27_1;
          class28_0.class27_1 = class27_2;
          flag2 = true;
        }
        else
        {
          Class27 class27_4 = Class30.smethod_139(buClipper_0, class27_1, true);
          Class27 class27_5 = Class30.smethod_139(buClipper_0, class271, false);
          class27_1.class27_0 = class271;
          class271.class27_1 = class27_1;
          class27_4.class27_1 = class27_5;
          class27_5.class27_0 = class27_4;
          class28_0.class27_0 = class27_1;
          class28_0.class27_1 = class27_4;
          flag2 = true;
        }
      }
    }
    else if (flag1)
    {
      Class27 class27_2 = class27_1;
      while ((class27_1.class27_1.intPoint_0.Y != class27_1.intPoint_0.Y || class27_1.class27_1 == class27_2 ? 0 : (class27_1.class27_1 != class271 ? 1 : 0)) != 0)
        class27_1 = class27_1.class27_1;
      while ((class27_2.class27_0.intPoint_0.Y != class27_2.intPoint_0.Y || class27_2.class27_0 == class27_1 ? 0 : (class27_2.class27_0 != class271 ? 1 : 0)) != 0)
        class27_2 = class27_2.class27_0;
      if ((class27_2.class27_0 == class27_1 ? 1 : (class27_2.class27_0 == class271 ? 1 : 0)) != 0)
      {
        flag2 = false;
      }
      else
      {
        Class27 class27_3 = class271;
        while ((class271.class27_1.intPoint_0.Y != class271.intPoint_0.Y || class271.class27_1 == class27_3 ? 0 : (class271.class27_1 != class27_2 ? 1 : 0)) != 0)
          class271 = class271.class27_1;
        while ((class27_3.class27_0.intPoint_0.Y != class27_3.intPoint_0.Y || class27_3.class27_0 == class271 ? 0 : (class27_3.class27_0 != class27_1 ? 1 : 0)) != 0)
          class27_3 = class27_3.class27_0;
        if ((class27_3.class27_0 == class271 ? 1 : (class27_3.class27_0 == class27_1 ? 1 : 0)) != 0)
        {
          flag2 = false;
        }
        else
        {
          long long_4;
          long long_5;
          if (!Class30.smethod_241(buClipper_0, class27_1.intPoint_0.X, class27_2.intPoint_0.X, class271.intPoint_0.X, class27_3.intPoint_0.X, out long_4, ref long_5))
          {
            flag2 = false;
          }
          else
          {
            IntPoint intPoint0;
            bool bool_0;
            if ((class27_1.intPoint_0.X < long_4 ? 0 : (class27_1.intPoint_0.X <= long_5 ? 1 : 0)) != 0)
            {
              intPoint0 = class27_1.intPoint_0;
              bool_0 = class27_1.intPoint_0.X > class27_2.intPoint_0.X;
            }
            else if ((class271.intPoint_0.X < long_4 ? 0 : (class271.intPoint_0.X <= long_5 ? 1 : 0)) != 0)
            {
              intPoint0 = class271.intPoint_0;
              bool_0 = class271.intPoint_0.X > class27_3.intPoint_0.X;
            }
            else if ((class27_2.intPoint_0.X < long_4 ? 0 : (class27_2.intPoint_0.X <= long_5 ? 1 : 0)) != 0)
            {
              intPoint0 = class27_2.intPoint_0;
              bool_0 = class27_2.intPoint_0.X > class27_1.intPoint_0.X;
            }
            else
            {
              intPoint0 = class27_3.intPoint_0;
              bool_0 = class27_3.intPoint_0.X > class271.intPoint_0.X;
            }
            class28_0.class27_0 = class27_1;
            class28_0.class27_1 = class271;
            flag2 = Class30.smethod_66(class271, class27_1, buClipper_0, class27_2, intPoint0, bool_0, class27_3);
          }
        }
      }
    }
    else
    {
      Class27 class27_6 = class27_1.class27_0;
      while ((!(class27_6.intPoint_0 == class27_1.intPoint_0) ? 0 : (class27_6 != class27_1 ? 1 : 0)) != 0)
        class27_6 = class27_6.class27_0;
      int num1;
      if (class27_6.intPoint_0.Y <= class27_1.intPoint_0.Y)
      {
        IntPoint intPoint0_1 = class27_1.intPoint_0;
        IntPoint intPoint0_2 = class27_6.intPoint_0;
        IntPoint intPoint0_3 = class28_0.intPoint_0;
        num1 = !Class30.smethod_103(buClipper_0.bool_0, intPoint0_2, intPoint0_3, intPoint0_1) ? 1 : 0;
      }
      else
        num1 = 1;
      bool flag5 = num1 != 0;
      if (num1 != 0)
      {
        class27_6 = class27_1.class27_1;
        while ((!(class27_6.intPoint_0 == class27_1.intPoint_0) ? 0 : (class27_6 != class27_1 ? 1 : 0)) != 0)
          class27_6 = class27_6.class27_1;
        int num2;
        if (class27_6.intPoint_0.Y <= class27_1.intPoint_0.Y)
        {
          IntPoint intPoint0_4 = class27_1.intPoint_0;
          IntPoint intPoint0_5 = class27_6.intPoint_0;
          IntPoint intPoint0_6 = class28_0.intPoint_0;
          num2 = !Class30.smethod_103(buClipper_0.bool_0, intPoint0_5, intPoint0_6, intPoint0_4) ? 1 : 0;
        }
        else
          num2 = 1;
        if (num2 != 0)
        {
          flag2 = false;
          goto label_74;
        }
      }
      Class27 class27_7 = class271.class27_0;
      while ((!(class27_7.intPoint_0 == class271.intPoint_0) ? 0 : (class27_7 != class271 ? 1 : 0)) != 0)
        class27_7 = class27_7.class27_0;
      int num3;
      if (class27_7.intPoint_0.Y <= class271.intPoint_0.Y)
      {
        IntPoint intPoint0_7 = class271.intPoint_0;
        IntPoint intPoint0_8 = class27_7.intPoint_0;
        IntPoint intPoint0_9 = class28_0.intPoint_0;
        num3 = !Class30.smethod_103(buClipper_0.bool_0, intPoint0_8, intPoint0_9, intPoint0_7) ? 1 : 0;
      }
      else
        num3 = 1;
      bool flag6 = num3 != 0;
      if (num3 != 0)
      {
        class27_7 = class271.class27_1;
        while ((!(class27_7.intPoint_0 == class271.intPoint_0) ? 0 : (class27_7 != class271 ? 1 : 0)) != 0)
          class27_7 = class27_7.class27_1;
        int num4;
        if (class27_7.intPoint_0.Y <= class271.intPoint_0.Y)
        {
          IntPoint intPoint0_10 = class271.intPoint_0;
          IntPoint intPoint0_11 = class27_7.intPoint_0;
          IntPoint intPoint0_12 = class28_0.intPoint_0;
          num4 = !Class30.smethod_103(buClipper_0.bool_0, intPoint0_11, intPoint0_12, intPoint0_10) ? 1 : 0;
        }
        else
          num4 = 1;
        if (num4 != 0)
        {
          flag2 = false;
          goto label_74;
        }
      }
      if ((class27_6 == class27_1 || class27_7 == class271 || class27_6 == class27_7 ? 1 : (class26_0 != class26_1 ? 0 : (flag5 == flag6 ? 1 : 0))) != 0)
        flag2 = false;
      else if (flag5)
      {
        Class27 class27_8 = Class30.smethod_139(buClipper_0, class27_1, false);
        Class27 class27_9 = Class30.smethod_139(buClipper_0, class271, true);
        class27_1.class27_1 = class271;
        class271.class27_0 = class27_1;
        class27_8.class27_0 = class27_9;
        class27_9.class27_1 = class27_8;
        class28_0.class27_0 = class27_1;
        class28_0.class27_1 = class27_8;
        flag2 = true;
      }
      else
      {
        Class27 class27_10 = Class30.smethod_139(buClipper_0, class27_1, true);
        Class27 class27_11 = Class30.smethod_139(buClipper_0, class271, false);
        class27_1.class27_0 = class271;
        class271.class27_1 = class27_1;
        class27_10.class27_1 = class27_11;
        class27_11.class27_0 = class27_10;
        class28_0.class27_0 = class27_1;
        class28_0.class27_1 = class27_10;
        flag2 = true;
      }
    }
label_74:
    return flag2;
  }

  static void smethod_294(Class34.Class36 class36_0)
  {
    class36_0.uint_0 >>= class36_0.int_2 & 7;
    class36_0.int_2 &= -8;
  }

  static List<string> smethod_295(string string_0)
  {
    List<string> stringList = new List<string>();
    string str = string_0.Trim();
    char[] separator = new char[1]{ '>' };
    foreach (string string_0_1 in str.Split(separator, StringSplitOptions.RemoveEmptyEntries))
      stringList.Add(Class30.smethod_76(string_0_1));
    return stringList;
  }

  static int smethod_296(Stream stream_0, string string_0, out bool bool_0)
  {
    bool_0 = false;
    string str;
    int position;
    do
    {
      position = (int) stream_0.Position;
      str = Class30.smethod_106(stream_0);
      if (str == null)
        goto label_3;
    }
    while (!str.StartsWith("--" + string_0, StringComparison.Ordinal));
    goto label_4;
label_3:
    int num = -1;
    goto label_5;
label_4:
    bool_0 = str.StartsWith($"--{string_0}--", StringComparison.OrdinalIgnoreCase);
    num = position;
label_5:
    return num;
  }

  static byte[] smethod_297(string string_0, bool bool_0)
  {
    if (string_0 == null)
      throw new ArgumentNullException("toDecode");
    using (MemoryStream stream_0 = new MemoryStream())
    {
      string_0 = Class30.smethod_166(string_0);
      for (int index = 0; index < string_0.Length; ++index)
      {
        char ch = string_0[index];
        if (ch == '=')
        {
          if (string_0.Length - index >= 3)
          {
            string string_0_1 = string_0.Substring(index, 3);
            Class30.smethod_18((Stream) stream_0, Class30.smethod_180(string_0_1));
            index += 2;
          }
          else
          {
            Class30.smethod_18((Stream) stream_0, Class30.smethod_300(string_0.Substring(index)));
            break;
          }
        }
        else if (ch == '_' & bool_0)
          stream_0.WriteByte((byte) 32 /*0x20*/);
        else
          stream_0.WriteByte((byte) ch);
      }
      return stream_0.ToArray();
    }
  }

  static bool smethod_298([Out] buClipper buClipper_0, ref Class22 class22_0)
  {
    class22_0 = buClipper_0.class22_1;
    bool flag;
    if (class22_0 == null)
    {
      flag = false;
    }
    else
    {
      Class22 class22 = class22_0;
      buClipper_0.class22_1 = class22_0.class22_5;
      if (buClipper_0.class22_1 != null)
        buClipper_0.class22_1.class22_6 = (Class22) null;
      class22.class22_5 = (Class22) null;
      class22.class22_6 = (Class22) null;
      flag = true;
    }
    return flag;
  }

  static bool smethod_299(TextReader textReader_0)
  {
    int num = textReader_0.Peek();
    bool flag;
    if (num == -1)
    {
      flag = false;
    }
    else
    {
      char ch = (char) num;
      flag = ch == ' ' || ch == '\t';
    }
    return flag;
  }

  static byte[] smethod_300(string string_0)
  {
    if (string_0 == null)
      throw new ArgumentNullException("decode");
    if (string_0.Length >= 3)
      throw new ArgumentException("decode must have length lower than 3", "decode");
    if (string_0.Length <= 0)
      throw new ArgumentException("decode must have length lower at least 1", "decode");
    return string_0[0] == '=' ? Encoding.ASCII.GetBytes(string_0) : throw new ArgumentException("First part of decode must be an equal sign", "decode");
  }
}
