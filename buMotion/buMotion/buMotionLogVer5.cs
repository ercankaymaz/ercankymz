// Decompiled with JetBrains decompiler
// Type: buMotion.buMotionLogVer5
// Assembly: buMotion, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: F5000E34-965A-4264-B97F-117192F983D9
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMotion.dll

using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows.Forms;

#nullable disable
namespace buMotion;

[Serializable]
public class buMotionLogVer5
{
  public string DoyouwanttoMakeHoming;
  public string FileisNotAvailable;
  public string ParameterValueIncorrectFormat;
  public string ToolValueIncorrectFormat;
  public string WrongToolNumber;
  public string ItisAlreadyInchSystemDoYouWanttoContinue;
  public string ItisAlreadymmSystemDoYouWanttoContinue;
  public string NoFileLoaded;
  public static byte f0001F6;
  public static Timer timGeneral;
  public static Timer timWarning;
  public static int cntWarningTick;

  static bool \u0001([In] \u0003.\u0003.\u0001 obj0)
  {
    int num1 = \u0007.\u0003.\u0001(((\u0003.\u0003.\u0005) obj0).\u0001);
    while (num1 >= 258)
    {
      switch (((\u0003.\u0003.\u0005) obj0).\u0001)
      {
        case 7:
          int num2;
          while (((num2 = buMotionLogVer5.\u0001(((\u0003.\u0003.\u0005) obj0).\u0001, ((\u0003.\u0003.\u0005) obj0).\u0001)) & -256) == 0)
          {
            \u0007.\u0003.\u0001(((\u0003.\u0003.\u0005) obj0).\u0001, num2);
            if (--num1 < 258)
              return true;
          }
          if (num2 >= 257)
          {
            ((\u0003.\u0003.\u0005) obj0).\u0003 = \u0003.\u0003.\u0004.\u0001[num2 - 257];
            ((\u0003.\u0003.\u0005) obj0).\u0002 = \u0003.\u0003.\u0005.\u0002[num2 - 257];
            goto case 8;
          }
          if (num2 < 0)
            return false;
          ((\u0003.\u0003.\u0005) obj0).\u0002 = (\u0003.\u0003.\u0004) null;
          ((\u0003.\u0003.\u0005) obj0).\u0001 = (\u0003.\u0003.\u0004) null;
          ((\u0003.\u0003.\u0005) obj0).\u0001 = 2;
          return true;
        case 8:
          if (((\u0003.\u0003.\u0005) obj0).\u0002 > 0)
          {
            ((\u0003.\u0003.\u0005) obj0).\u0001 = 8;
            int num3 = \u0007.\u0003.\u0001(((\u0003.\u0003.\u0005) obj0).\u0001, ((\u0003.\u0003.\u0005) obj0).\u0002);
            if (num3 < 0)
              return false;
            buMotionLogVer5.\u0001(((\u0003.\u0003.\u0005) obj0).\u0001, ((\u0003.\u0003.\u0005) obj0).\u0002);
            ((\u0003.\u0003.\u0005) obj0).\u0003 = ((\u0003.\u0003.\u0005) obj0).\u0003 + num3;
          }
          ((\u0003.\u0003.\u0005) obj0).\u0001 = 9;
          goto case 9;
        case 9:
          int index = buMotionLogVer5.\u0001(((\u0003.\u0003.\u0005) obj0).\u0002, ((\u0003.\u0003.\u0005) obj0).\u0001);
          if (index < 0)
            return false;
          ((\u0003.\u0003.\u0005) obj0).\u0004 = \u0003.\u0003.\u0005.\u0003[index];
          ((\u0003.\u0003.\u0005) obj0).\u0002 = \u0003.\u0003.\u0005.\u0004[index];
          goto case 10;
        case 10:
          if (((\u0003.\u0003.\u0005) obj0).\u0002 > 0)
          {
            ((\u0003.\u0003.\u0005) obj0).\u0001 = 10;
            int num4 = \u0007.\u0003.\u0001(((\u0003.\u0003.\u0005) obj0).\u0001, ((\u0003.\u0003.\u0005) obj0).\u0002);
            if (num4 < 0)
              return false;
            buMotionLogVer5.\u0001(((\u0003.\u0003.\u0005) obj0).\u0001, ((\u0003.\u0003.\u0005) obj0).\u0002);
            ((\u0003.\u0003.\u0005) obj0).\u0004 = ((\u0003.\u0003.\u0005) obj0).\u0004 + num4;
          }
          \u0007.\u0003.\u0001(((\u0003.\u0003.\u0005) obj0).\u0001, ((\u0003.\u0003.\u0005) obj0).\u0003, ((\u0003.\u0003.\u0005) obj0).\u0004);
          num1 -= ((\u0003.\u0003.\u0005) obj0).\u0003;
          ((\u0003.\u0003.\u0005) obj0).\u0001 = 7;
          continue;
        default:
          continue;
      }
    }
    return true;
  }

  static void \u0001([In] \u0003.\u0003.\u0002 obj0, [In] int obj1)
  {
    ((\u0003.\u0003.\u0006) obj0).\u0001 = ((\u0003.\u0003.\u0006) obj0).\u0001 >> obj1;
    ((\u0003.\u0003.\u0006) obj0).\u0003 = ((\u0003.\u0003.\u0006) obj0).\u0003 - obj1;
  }

  static void \u0001([In] \u0003.\u0003.\u0003 obj0, [In] int obj1, [In] int obj2)
  {
    while (obj2-- > 0)
    {
      byte[] numArray = ((\u0003.\u0003.\u0006) obj0).\u0001;
      \u0003.\u0003.\u0003 obj = obj0;
      // ISSUE: reference to a compiler-generated field
      int num1 = ((\u0005.\u0001) obj0).\u0001;
      int num2 = num1 + 1;
      // ISSUE: reference to a compiler-generated field
      ((\u0005.\u0001) obj).\u0001 = num2;
      int index = num1;
      int num3 = (int) ((\u0003.\u0003.\u0006) obj0).\u0001[obj1++];
      numArray[index] = (byte) num3;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      ((\u0005.\u0001) obj0).\u0001 = ((\u0005.\u0001) obj0).\u0001 & (int) short.MaxValue;
      obj1 &= (int) short.MaxValue;
    }
  }

  static bool \u0001([In] \u0003.\u0003.\u0002 obj0)
  {
    return ((\u0003.\u0003.\u0006) obj0).\u0001 == ((\u0003.\u0003.\u0006) obj0).\u0002;
  }

  static int \u0001([In] \u0003.\u0003.\u0004 obj0, [In] \u0003.\u0003.\u0002 obj1)
  {
    int index1;
    if ((index1 = \u0007.\u0003.\u0001(obj1, 9)) >= 0)
    {
      int num1;
      // ISSUE: reference to a compiler-generated field
      if ((num1 = (int) ((\u0005.\u0001) obj0).\u0001[index1]) >= 0)
      {
        buMotionLogVer5.\u0001(obj1, num1 & 15);
        return num1 >> 4;
      }
      int num2 = -(num1 >> 4);
      int num3 = num1 & 15;
      int num4;
      if ((num4 = \u0007.\u0003.\u0001(obj1, num3)) >= 0)
      {
        // ISSUE: reference to a compiler-generated field
        int num5 = (int) ((\u0005.\u0001) obj0).\u0001[num2 | num4 >> 9];
        buMotionLogVer5.\u0001(obj1, num5 & 15);
        return num5 >> 4;
      }
      int num6 = ((\u0003.\u0003.\u0006) obj1).\u0003;
      int num7 = \u0007.\u0003.\u0001(obj1, num6);
      // ISSUE: reference to a compiler-generated field
      int num8 = (int) ((\u0005.\u0001) obj0).\u0001[num2 | num7 >> 9];
      if ((num8 & 15) > num6)
        return -1;
      buMotionLogVer5.\u0001(obj1, num8 & 15);
      return num8 >> 4;
    }
    int num9 = ((\u0003.\u0003.\u0006) obj1).\u0003;
    int index2 = \u0007.\u0003.\u0001(obj1, num9);
    // ISSUE: reference to a compiler-generated field
    int num10 = (int) ((\u0005.\u0001) obj0).\u0001[index2];
    if (num10 < 0 || (num10 & 15) > num9)
      return -1;
    buMotionLogVer5.\u0001(obj1, num10 & 15);
    return num10 >> 4;
  }

  static void \u0001([In] string obj0, [In] int obj1)
  {
    // ISSUE: unable to decompile the method.
  }

  static int \u0001([In] int obj0, [In] byte[] obj1, [In] int obj2, [In] \u0003.\u0003.\u0003 obj3)
  {
    // ISSUE: reference to a compiler-generated field
    int num1 = ((\u0005.\u0001) obj3).\u0001;
    // ISSUE: reference to a compiler-generated field
    if (obj0 > ((\u0005.\u0001) obj3).\u0002)
    {
      // ISSUE: reference to a compiler-generated field
      obj0 = ((\u0005.\u0001) obj3).\u0002;
    }
    else
    {
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      num1 = ((\u0005.\u0001) obj3).\u0001 - ((\u0005.\u0001) obj3).\u0002 + obj0 & (int) short.MaxValue;
    }
    int num2 = obj0;
    int length = obj0 - num1;
    if (length > 0)
    {
      Array.Copy((Array) ((\u0003.\u0003.\u0006) obj3).\u0001, 32768 /*0x8000*/ - length, (Array) obj1, obj2, length);
      obj2 += length;
      obj0 = num1;
    }
    Array.Copy((Array) ((\u0003.\u0003.\u0006) obj3).\u0001, num1 - obj0, (Array) obj1, obj2, obj0);
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    ((\u0005.\u0001) obj3).\u0002 = ((\u0005.\u0001) obj3).\u0002 - num2;
    // ISSUE: reference to a compiler-generated field
    if (((\u0005.\u0001) obj3).\u0002 < 0)
      throw new InvalidOperationException();
    return num2;
  }

  static ICryptoTransform \u0001([In] bool obj0, [In] byte[] obj1, [In] byte[] obj2)
  {
    using (AesCryptoServiceProvider cryptoServiceProvider = new AesCryptoServiceProvider())
      return obj0 ? cryptoServiceProvider.CreateDecryptor(obj1, obj2) : cryptoServiceProvider.CreateEncryptor(obj1, obj2);
  }

  static string \u0001([In] int obj0)
  {
    // ISSUE: unable to decompile the method.
  }

  static int \u0001([In] \u0003.\u0003.\u0002 obj0, [In] byte[] obj1, [In] int obj2, [In] int obj3)
  {
    int num1 = 0;
    while (((\u0003.\u0003.\u0006) obj0).\u0003 > 0 && obj3 > 0)
    {
      obj1[obj2++] = (byte) ((\u0003.\u0003.\u0006) obj0).\u0001;
      ((\u0003.\u0003.\u0006) obj0).\u0001 = ((\u0003.\u0003.\u0006) obj0).\u0001 >> 8;
      ((\u0003.\u0003.\u0006) obj0).\u0003 = ((\u0003.\u0003.\u0006) obj0).\u0003 - 8;
      --obj3;
      ++num1;
    }
    if (obj3 == 0)
      return num1;
    int num2 = ((\u0003.\u0003.\u0006) obj0).\u0002 - ((\u0003.\u0003.\u0006) obj0).\u0001;
    if (obj3 > num2)
      obj3 = num2;
    Array.Copy((Array) ((\u0003.\u0003.\u0006) obj0).\u0001, ((\u0003.\u0003.\u0006) obj0).\u0001, (Array) obj1, obj2, obj3);
    ((\u0003.\u0003.\u0006) obj0).\u0001 = ((\u0003.\u0003.\u0006) obj0).\u0001 + obj3;
    if ((((\u0003.\u0003.\u0006) obj0).\u0001 - ((\u0003.\u0003.\u0006) obj0).\u0002 & 1) != 0)
    {
      \u0003.\u0003.\u0002 obj4 = obj0;
      byte[] numArray = ((\u0003.\u0003.\u0006) obj0).\u0001;
      \u0003.\u0003.\u0002 obj5 = obj0;
      int num3 = ((\u0003.\u0003.\u0006) obj0).\u0001;
      int num4 = num3 + 1;
      ((\u0003.\u0003.\u0006) obj5).\u0001 = num4;
      int index = num3;
      int num5 = (int) numArray[index] & (int) byte.MaxValue;
      ((\u0003.\u0003.\u0006) obj4).\u0001 = (uint) num5;
      ((\u0003.\u0003.\u0006) obj0).\u0003 = 8;
    }
    return num1 + obj3;
  }
}
