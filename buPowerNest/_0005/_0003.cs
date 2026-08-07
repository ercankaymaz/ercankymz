// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buPowerNest, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: EB8978B5-B2D2-48FE-B448-717DFAAD425B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buPowerNest.dll

using dummy_ptr;
using Opaline2Cs;
using PowerNest2Cs;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

#nullable disable
namespace \u0005;

internal class \u0003
{
  [DllImport("anpn2key.dll", EntryPoint = "#24", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001([In] int obj0);

  [DllImport("anpn2key.dll", EntryPoint = "#307", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] double obj2);

  [DllImport("anpn2key.dll", EntryPoint = "#17", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] Point[] obj2, [In] int obj3);

  [DllImport("anpn2key.dll", EntryPoint = "#46", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] int obj2);

  [DllImport("anpn2key.dll", EntryPoint = "#43", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] int obj2);

  [DllImport("opaline3.dll", EntryPoint = "#100", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001();

  static \u0007.\u0003.\u0004 \u0001([In] \u0007.\u0003.\u0005 obj0)
  {
    byte[] destinationArray = new byte[obj0.\u0003];
    Array.Copy((Array) obj0.\u0002, obj0.\u0002, (Array) destinationArray, 0, obj0.\u0003);
    return (\u0007.\u0003.\u0004) new \u0007.\u0003.\u0005(destinationArray);
  }

  static void \u0001([In] byte[] obj0, [In] \u0007.\u0003.\u0004 obj1)
  {
    int[] numArray1 = new int[16 /*0x10*/];
    int[] numArray2 = new int[16 /*0x10*/];
    for (int index1 = 0; index1 < obj0.Length; ++index1)
    {
      int index2 = (int) obj0[index1];
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
    obj1.\u0001 = new short[length];
    int num4 = 512 /*0x0200*/;
    for (int index3 = 15; index3 >= 10; --index3)
    {
      int num5 = num1 & 130944;
      num1 -= numArray1[index3] << 16 /*0x10*/ - index3;
      for (int index4 = num1 & 130944; index4 < num5; index4 += 128 /*0x80*/)
      {
        obj1.\u0001[(int) \u0003.\u0001(index4)] = (short) (-num4 << 4 | index3);
        num4 += 1 << index3 - 9;
      }
    }
    for (int index5 = 0; index5 < obj0.Length; ++index5)
    {
      int index6 = (int) obj0[index5];
      if (index6 != 0)
      {
        int num6 = numArray2[index6];
        int index7 = (int) \u0003.\u0001(num6);
        if (index6 <= 9)
        {
          do
          {
            obj1.\u0001[index7] = (short) (index5 << 4 | index6);
            index7 += 1 << index6;
          }
          while (index7 < 512 /*0x0200*/);
        }
        else
        {
          int num7 = (int) obj1.\u0001[index7 & 511 /*0x01FF*/];
          int num8 = 1 << (num7 & 15);
          int num9 = -(num7 >> 4);
          do
          {
            obj1.\u0001[num9 | index7 >> 9] = (short) (index5 << 4 | index6);
            index7 += 1 << index6;
          }
          while (index7 < num8);
        }
        numArray2[index6] = num6 + (1 << 16 /*0x10*/ - index6);
      }
    }
  }

  static \u0007.\u0003.\u0004 \u0001([In] \u0007.\u0003.\u0005 obj0)
  {
    byte[] destinationArray = new byte[obj0.\u0002];
    Array.Copy((Array) obj0.\u0002, 0, (Array) destinationArray, 0, obj0.\u0002);
    return (\u0007.\u0003.\u0004) new \u0007.\u0003.\u0005(destinationArray);
  }

  [DllImport("opaline3.dll", EntryPoint = "#150", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern uint \u0001([In] IntPtr obj0, [In] IntPtr obj1);

  [DllImport("anpn2key.dll", EntryPoint = "#121", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] int obj2);

  [DllImport("anpn2key.dll", EntryPoint = "#211", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] int obj2, [In] double obj3);

  [DllImport("anpn2key.dll", EntryPoint = "#62", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001([In] IntPtr obj0, [In] Point[] obj1, [In] double[] obj2, [In] int obj3);

  [DllImport("anpn2key.dll", EntryPoint = "#34", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001([In] IntPtr obj0, [In] Point[] obj1, [In] int obj2);

  static void \u0001([In] Opaline obj0) => \u0003.\u0001(obj0.\u0001.__Ptr);

  [DllImport("opaline3.dll", EntryPoint = "#155", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern void \u0001([In] IntPtr obj0, [In] int obj1);

  static void \u0001([In] \u0007.\u0003.\u0002 obj0, [In] int obj1)
  {
    obj0.\u0001 >>= obj1;
    ((\u0007.\u0003.\u0003) obj0).\u0003 = ((\u0007.\u0003.\u0003) obj0).\u0003 - obj1;
  }

  [DllImport("anpn2key.dll", EntryPoint = "#13", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] Orientation[] obj2, [In] int obj3);

  [DllImport("anpn2key.dll", EntryPoint = "#306", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] Point[] obj2, [In] int obj3);

  [DllImport("anpn2key.dll", EntryPoint = "#27", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001([In] IntPtr obj0, [In] Point[] obj1, [In] int[] obj2, [In] int obj3, [In] Point obj4);

  [DllImport("anpn2key.dll", EntryPoint = "#603", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001(out uint _param0);

  [DllImport("opaline3.dll", EntryPoint = "#142", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern void \u0001(
    IntPtr _param0,
    IntPtr _param1,
    uint _param2,
    out IntPtr _param3,
    out double _param4,
    out double _param5,
    out double _param6);

  [DllImport("opaline3.dll", EntryPoint = "#146", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern double \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] int obj2);

  [DllImport("anpn2key.dll", EntryPoint = "#18", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] IntPtr[] obj2, [In] int obj3, [In] double obj4);

  [DllImport("opaline3.dll", EntryPoint = "#117", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern void \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] int obj2);

  [DllImport("anpn2key.dll", EntryPoint = "#36", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] string obj1);

  [DllImport("anpn2key.dll", EntryPoint = "#22", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001(
    IntPtr _param0,
    IntPtr _param1,
    IntPtr _param2,
    out Point _param3,
    out Orientation _param4);

  static void \u0001([In] \u0007.\u0003.\u0003 obj0, [In] int obj1)
  {
    \u0007.\u0003.\u0003 obj2 = obj0;
    int num1 = ((\u0007.\u0003.\u0004) obj0).\u0002;
    int num2 = num1 + 1;
    ((\u0007.\u0003.\u0004) obj2).\u0002 = num2;
    if (num1 == 32768 /*0x8000*/)
      throw new InvalidOperationException();
    byte[] numArray = obj0.\u0001;
    \u0007.\u0003.\u0003 obj3 = obj0;
    int num3 = obj0.\u0001;
    int num4 = num3 + 1;
    obj3.\u0001 = num4;
    int index = num3;
    int num5 = (int) (byte) obj1;
    numArray[index] = (byte) num5;
    obj0.\u0001 &= (int) short.MaxValue;
  }

  static int \u0001([In] \u0007.\u0003.\u0002 obj0, [In] byte[] obj1, [In] int obj2, [In] int obj3)
  {
    int num1 = 0;
    while (((\u0007.\u0003.\u0003) obj0).\u0003 > 0 && obj3 > 0)
    {
      obj1[obj2++] = (byte) obj0.\u0001;
      obj0.\u0001 >>= 8;
      ((\u0007.\u0003.\u0003) obj0).\u0003 = ((\u0007.\u0003.\u0003) obj0).\u0003 - 8;
      --obj3;
      ++num1;
    }
    if (obj3 == 0)
      return num1;
    int num2 = obj0.\u0002 - obj0.\u0001;
    if (obj3 > num2)
      obj3 = num2;
    Array.Copy((Array) obj0.\u0001, obj0.\u0001, (Array) obj1, obj2, obj3);
    obj0.\u0001 += obj3;
    if ((obj0.\u0001 - obj0.\u0002 & 1) != 0)
    {
      \u0007.\u0003.\u0002 obj4 = obj0;
      byte[] numArray = obj0.\u0001;
      \u0007.\u0003.\u0002 obj5 = obj0;
      int num3 = obj0.\u0001;
      int num4 = num3 + 1;
      obj5.\u0001 = num4;
      int index = num3;
      int num5 = (int) numArray[index] & (int) byte.MaxValue;
      obj4.\u0001 = (uint) num5;
      ((\u0007.\u0003.\u0003) obj0).\u0003 = 8;
    }
    return num1 + obj3;
  }

  [DllImport("opaline3.dll", EntryPoint = "#144", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] uint obj2);

  [DllImport("anpn2key.dll", EntryPoint = "#200", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001([In] IntPtr obj0, [In] double obj1, [In] double obj2);

  [DllImport("anpn2key.dll", EntryPoint = "#507", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] double obj2);

  [DllImport("anpn2key.dll", EntryPoint = "#511", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] int obj2);

  [DllImport("opaline3.dll", EntryPoint = "#103", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern void \u0001([In] string obj0);

  [DllImport("opaline3.dll", EntryPoint = "#106", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001([In] IntPtr obj0, [In] uint obj1, [In] uint obj2, [In] double obj3);

  [DllImport("opaline3.dll", EntryPoint = "#131", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] double obj2, [In] \u0006.\u0001 obj3);

  static void \u0001([In] \u0007.\u0003.\u0003 obj0, [In] int obj1, [In] int obj2)
  {
    if ((((\u0007.\u0003.\u0004) obj0).\u0002 = ((\u0007.\u0003.\u0004) obj0).\u0002 + obj1) > 32768 /*0x8000*/)
      throw new InvalidOperationException();
    int sourceIndex = obj0.\u0001 - obj2 & (int) short.MaxValue;
    int num1 = 32768 /*0x8000*/ - obj1;
    if (sourceIndex <= num1 && obj0.\u0001 < num1)
    {
      if (obj1 <= obj2)
      {
        Array.Copy((Array) obj0.\u0001, sourceIndex, (Array) obj0.\u0001, obj0.\u0001, obj1);
        obj0.\u0001 += obj1;
      }
      else
      {
        while (obj1-- > 0)
        {
          byte[] numArray = obj0.\u0001;
          \u0007.\u0003.\u0003 obj = obj0;
          int num2 = obj0.\u0001;
          int num3 = num2 + 1;
          obj.\u0001 = num3;
          int index = num2;
          int num4 = (int) obj0.\u0001[sourceIndex++];
          numArray[index] = (byte) num4;
        }
      }
    }
    else
      \u0003.\u0001(obj0, sourceIndex, obj1);
  }

  [DllImport("opaline3.dll", EntryPoint = "#143", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern double \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] uint obj2, [In] int obj3);

  [DllImport("anpn2key.dll", EntryPoint = "#23", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] string obj2);

  [DllImport("opaline3.dll", EntryPoint = "#132", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern uint \u0001([In] IntPtr obj0, [In] double obj1, [In] \u0006.\u0001 obj2);

  [DllImport("opaline3.dll", EntryPoint = "#102", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern void \u0001([In] IntPtr obj0);

  [DllImport("anpn2key.dll", EntryPoint = "#64", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] Point obj2);

  [DllImport("anpn2key.dll", EntryPoint = "#514", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] double obj2);

  [DllImport("anpn2key.dll", EntryPoint = "#509", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] double obj2);

  static int \u0001([In] \u0007.\u0003.\u0002 obj0, [In] int obj1)
  {
    if (((\u0007.\u0003.\u0003) obj0).\u0003 < obj1)
    {
      if (obj0.\u0001 == obj0.\u0002)
        return -1;
      \u0007.\u0003.\u0002 obj2 = obj0;
      int num1 = (int) obj0.\u0001;
      byte[] numArray1 = obj0.\u0001;
      \u0007.\u0003.\u0002 obj3 = obj0;
      int num2 = obj0.\u0001;
      int num3 = num2 + 1;
      obj3.\u0001 = num3;
      int index1 = num2;
      int num4 = (int) numArray1[index1] & (int) byte.MaxValue;
      byte[] numArray2 = obj0.\u0001;
      \u0007.\u0003.\u0002 obj4 = obj0;
      int num5 = obj0.\u0001;
      int num6 = num5 + 1;
      obj4.\u0001 = num6;
      int index2 = num5;
      int num7 = ((int) numArray2[index2] & (int) byte.MaxValue) << 8;
      int num8 = (num4 | num7) << ((\u0007.\u0003.\u0003) obj0).\u0003;
      int num9 = num1 | num8;
      obj2.\u0001 = (uint) num9;
      ((\u0007.\u0003.\u0003) obj0).\u0003 = ((\u0007.\u0003.\u0003) obj0).\u0003 + 16 /*0x10*/;
    }
    return (int) ((long) obj0.\u0001 & (long) ((1 << obj1) - 1));
  }

  [DllImport("opaline3.dll", EntryPoint = "#99", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0);

  [DllImport("opaline3.dll", EntryPoint = "#115", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern void \u0001([In] IntPtr obj0, [In] int obj1);

  [DllImport("anpn2key.dll", EntryPoint = "#72", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] IntPtr[] obj2, [In] int obj3);

  [DllImport("anpn2key.dll", EntryPoint = "#204", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001(
    [In] IntPtr obj0,
    [In] IntPtr[] obj1,
    [In] int obj2,
    [In] int[] obj3,
    [In] IntPtr[] obj4,
    [In] int obj5,
    [In] double obj6);

  [DllImport("opaline3.dll", EntryPoint = "#110", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern void \u0001(
    IntPtr _param0,
    IntPtr _param1,
    out double _param2,
    out double _param3,
    out double _param4,
    out double _param5,
    out uint _param6);

  [DllImport("anpn2key.dll", EntryPoint = "#69", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] double obj2);

  static int \u0001([In] \u0007.\u0003.\u0003 obj0) => ((\u0007.\u0003.\u0004) obj0).\u0002;

  [DllImport("opaline3.dll", EntryPoint = "#125", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern void \u0001([In] IntPtr obj0, [In] double obj1, [In] double obj2, [In] double obj3);

  static Opaline2Cs.Session \u0001([In] Opaline obj0)
  {
    return Opaline2Cs.Wrappable.Create<Opaline2Cs.Session>(\u0003.\u0001(), new Opaline2Cs.Session());
  }

  [DllImport("anpn2key.dll", EntryPoint = "#70", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] IntPtr obj2);

  [DllImport("anpn2key.dll", EntryPoint = "#201", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001([In] IntPtr obj0, [In] double obj1, [In] double obj2);

  [DllImport("anpn2key.dll", EntryPoint = "#47", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] int obj1);

  [DllImport("opaline3.dll", EntryPoint = "#119", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0);

  static ICryptoTransform \u0001([In] bool obj0, [In] byte[] obj1, [In] byte[] obj2)
  {
    using (AesCryptoServiceProvider cryptoServiceProvider = new AesCryptoServiceProvider())
      return obj0 ? cryptoServiceProvider.CreateDecryptor(obj2, obj1) : cryptoServiceProvider.CreateEncryptor(obj2, obj1);
  }

  [DllImport("anpn2key.dll", EntryPoint = "#521", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] double obj1);

  [DllImport("anpn2key.dll", EntryPoint = "#505", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] int obj2);

  [DllImport("anpn2key.dll", EntryPoint = "#214", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] IntPtr[] obj2, [In] int obj3, [In] double obj4);

  [DllImport("opaline3.dll", EntryPoint = "#108", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001(
    [In] IntPtr obj0,
    [In] IntPtr obj1,
    [In] uint obj2,
    [In] double obj3,
    [In] double obj4,
    [In] double obj5);

  [DllImport("anpn2key.dll", EntryPoint = "#14", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001(
    [In] IntPtr obj0,
    [In] IntPtr obj1,
    [In] Orientation[] obj2,
    [In] int obj3,
    [In] int obj4,
    [In] IntPtr[] obj5);

  [DllImport("anpn2key.dll", EntryPoint = "#301", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001();

  [DllImport("anpn2key.dll", EntryPoint = "#303", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0);

  [DllImport("anpn2key.dll", EntryPoint = "#63", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001([In] IntPtr obj0, [In] Point[] obj1, [In] Point[] obj2, [In] bool[] obj3, [In] int obj4);

  [DllImport("anpn2key.dll", EntryPoint = "#533", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001(IntPtr _param0, IntPtr _param1, IntPtr _param2, out int _param3);

  [DllImport("opaline3.dll", EntryPoint = "#130", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern void \u0001([In] IntPtr obj0, [In] int obj1);

  [DllImport("anpn2key.dll", EntryPoint = "#552", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] Side obj1, [In] Side obj2);

  static Opaline2Cs.Session \u0001([In] int obj0, [In] Opaline obj1)
  {
    return Opaline2Cs.Wrappable.Create<Opaline2Cs.Session>(\u0003.\u0001(), new Opaline2Cs.Session());
  }

  [DllImport("anpn2key.dll", EntryPoint = "#313", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern Orientation \u0001([In] int obj0);

  static void \u0001([In] \u0007.\u0003.\u0002 obj0)
  {
    obj0.\u0001 >>= ((\u0007.\u0003.\u0003) obj0).\u0003 & 7;
    ((\u0007.\u0003.\u0003) obj0).\u0003 = ((\u0007.\u0003.\u0003) obj0).\u0003 & -8;
  }

  [DllImport("anpn2key.dll", EntryPoint = "#1007", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] IntPtr[] obj2, [In] int obj3);

  [DllImport("opaline3.dll", EntryPoint = "#137", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern uint \u0001([In] IntPtr obj0, [In] uint obj1);

  [DllImport("anpn2key.dll", EntryPoint = "#213", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001(
    [In] IntPtr obj0,
    [In] IntPtr obj1,
    [In] IntPtr[] obj2,
    [In] int obj3,
    [In] int[] obj4,
    [In] IntPtr[] obj5,
    [In] int obj6,
    [In] double obj7);

  [DllImport("anpn2key.dll", EntryPoint = "#504", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] CommonCutType obj2);

  [DllImport("anpn2key.dll", EntryPoint = "#33", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] Point[] obj2, [In] int obj3);

  [DllImport("anpn2key.dll", EntryPoint = "#52", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001([In] IntPtr obj0, [In] IntPtr[] obj1, [In] int obj2);

  static string \u0001([In] int obj0)
  {
    int num1 = obj0;
    byte[] numArray1 = \u0001.\u0005.\u0001;
    int index1 = num1;
    int index2 = index1 + 1;
    int num2 = (int) numArray1[index1];
    int count;
    if ((num2 & 128 /*0x80*/) == 0)
    {
      count = num2;
      if (count == 0)
        return string.Empty;
    }
    else if ((num2 & 64 /*0x40*/) == 0)
    {
      count = ((num2 & 63 /*0x3F*/) << 8) + (int) \u0001.\u0005.\u0001[index2++];
    }
    else
    {
      int num3 = (num2 & 31 /*0x1F*/) << 24;
      byte[] numArray2 = \u0001.\u0005.\u0001;
      int index3 = index2;
      int num4 = index3 + 1;
      int num5 = (int) numArray2[index3] << 16 /*0x10*/;
      int num6 = num3 + num5;
      byte[] numArray3 = \u0001.\u0005.\u0001;
      int index4 = num4;
      int num7 = index4 + 1;
      int num8 = (int) numArray3[index4] << 8;
      int num9 = num6 + num8;
      byte[] numArray4 = \u0001.\u0005.\u0001;
      int index5 = num7;
      index2 = index5 + 1;
      int num10 = (int) numArray4[index5];
      count = num9 + num10;
    }
    try
    {
      byte[] bytes = Convert.FromBase64String(Encoding.UTF8.GetString(\u0001.\u0005.\u0001, index2, count));
      string str = string.Intern(Encoding.UTF8.GetString(bytes, 0, bytes.Length));
      if (\u0001.\u0005.\u0001)
        \u0003.\u0001(str, obj0);
      return str;
    }
    catch
    {
      return (string) null;
    }
  }

  [DllImport("anpn2key.dll", EntryPoint = "#502", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] double obj1);

  [DllImport("opaline3.dll", EntryPoint = "#123", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern void \u0001(
    [In] IntPtr obj0,
    [In] double obj1,
    [In] double obj2,
    [In] double obj3,
    [In] double obj4,
    [In] double obj5,
    [In] double obj6);

  static void \u0001([In] PowerNest2 obj0, [In] bool obj1)
  {
    if (!obj0.\u0001 && obj1)
    {
      \u0003.\u0001(obj0.\u0001.__Ptr);
      \u0003.\u0001(obj0);
    }
    obj0.\u0001 = true;
  }

  static void \u0001([In] int obj0, [In] byte[] obj1, [In] \u0007.\u0003.\u0002 obj2, [In] int obj3)
  {
    if (obj2.\u0001 < obj2.\u0002)
      throw new InvalidOperationException();
    int num = obj0 + obj3;
    if (0 > obj0 || obj0 > num || num > obj1.Length)
      throw new ArgumentOutOfRangeException();
    if ((obj3 & 1) != 0)
    {
      obj2.\u0001 |= (uint) (((int) obj1[obj0++] & (int) byte.MaxValue) << ((\u0007.\u0003.\u0003) obj2).\u0003);
      ((\u0007.\u0003.\u0003) obj2).\u0003 = ((\u0007.\u0003.\u0003) obj2).\u0003 + 8;
    }
    obj2.\u0001 = obj1;
    obj2.\u0001 = obj0;
    obj2.\u0002 = num;
  }

  [DllImport("anpn2key.dll", EntryPoint = "#19", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001(
    [In] IntPtr obj0,
    [In] IntPtr obj1,
    [In] IntPtr[] obj2,
    [In] Orientation[] obj3,
    [In] Point[] obj4,
    [In] int obj5);

  [DllImport("opaline3.dll", EntryPoint = "#111", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern void \u0001(
    IntPtr _param0,
    IntPtr _param1,
    out uint _param2,
    out uint _param3,
    out double _param4);

  [DllImport("anpn2key.dll", EntryPoint = "#112", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] double obj2);

  [DllImport("anpn2key.dll", EntryPoint = "#702", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001();

  [DllImport("anpn2key.dll", EntryPoint = "#216", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] int obj2, [In] double obj3);

  [DllImport("anpn2key.dll", EntryPoint = "#212", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] int obj2, [In] double obj3);

  [DllImport("anpn2key.dll", EntryPoint = "#510", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] int obj2);

  static int \u0001([In] \u0007.\u0003.\u0002 obj0) => ((\u0007.\u0003.\u0003) obj0).\u0003;

  [DllImport("anpn2key.dll", EntryPoint = "#215", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001(
    [In] IntPtr obj0,
    [In] int obj1,
    [In] IntPtr[] obj2,
    [In] int[] obj3,
    [In] IntPtr[] obj4,
    [In] Orientation[] obj5,
    [In] Point[] obj6);

  static bool \u0001([In] \u0007.\u0003.\u0001 obj0)
  {
    int num1 = \u0003.\u0001(obj0.\u0001);
    while (num1 >= 258)
    {
      switch (obj0.\u0001)
      {
        case 7:
          int num2;
          while (((num2 = \u0003.\u0001(obj0.\u0001, obj0.\u0001)) & -256) == 0)
          {
            \u0003.\u0001(obj0.\u0001, num2);
            if (--num1 < 258)
              return true;
          }
          if (num2 >= 257)
          {
            obj0.\u0003 = \u0007.\u0003.\u0001.\u0001[num2 - 257];
            obj0.\u0002 = \u0007.\u0003.\u0001.\u0002[num2 - 257];
            goto case 8;
          }
          if (num2 < 0)
            return false;
          ((\u0007.\u0003.\u0002) obj0).\u0002 = (\u0007.\u0003.\u0004) null;
          obj0.\u0001 = (\u0007.\u0003.\u0004) null;
          obj0.\u0001 = 2;
          return true;
        case 8:
          if (obj0.\u0002 > 0)
          {
            obj0.\u0001 = 8;
            int num3 = \u0003.\u0001(obj0.\u0001, obj0.\u0002);
            if (num3 < 0)
              return false;
            \u0003.\u0001(obj0.\u0001, obj0.\u0002);
            obj0.\u0003 += num3;
          }
          obj0.\u0001 = 9;
          goto case 9;
        case 9:
          int index = \u0003.\u0001(((\u0007.\u0003.\u0002) obj0).\u0002, obj0.\u0001);
          if (index < 0)
            return false;
          obj0.\u0004 = \u0007.\u0003.\u0001.\u0003[index];
          obj0.\u0002 = \u0007.\u0003.\u0001.\u0004[index];
          goto case 10;
        case 10:
          if (obj0.\u0002 > 0)
          {
            obj0.\u0001 = 10;
            int num4 = \u0003.\u0001(obj0.\u0001, obj0.\u0002);
            if (num4 < 0)
              return false;
            \u0003.\u0001(obj0.\u0001, obj0.\u0002);
            obj0.\u0004 += num4;
          }
          \u0003.\u0001(obj0.\u0001, obj0.\u0003, obj0.\u0004);
          num1 -= obj0.\u0003;
          obj0.\u0001 = 7;
          continue;
        default:
          continue;
      }
    }
    return true;
  }

  [DllImport("anpn2key.dll", EntryPoint = "#66", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001([In] IntPtr obj0, [In] IntPtr[] obj1, [In] int obj2, [In] Point obj3);

  [DllImport("opaline3.dll", EntryPoint = "#124", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern void \u0001(
    [In] IntPtr obj0,
    [In] IntPtr obj1,
    [In] double obj2,
    [In] double obj3,
    [In] double obj4,
    [In] double obj5,
    [In] double obj6,
    [In] double obj7);

  [DllImport("anpn2key.dll", EntryPoint = "#68", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001([In] IntPtr obj0, [In] IntPtr obj1);

  [DllImport("anpn2key.dll", EntryPoint = "#602", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001(out byte _param0, int _param1, uint _param2, uint _param3);

  [DllImport("anpn2key.dll", EntryPoint = "#73", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001([In] IntPtr obj0, [In] Point[] obj1, [In] double[] obj2, [In] int obj3);

  [DllImport("anpn2key.dll", EntryPoint = "#520", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] int obj1);

  [DllImport("opaline3.dll", EntryPoint = "#98", CallingConvention = CallingConvention.StdCall)]
  static extern void \u0001(IntPtr _param0, [MarshalAs((UnmanagedType) 0)] string _param1);

  [DllImport("opaline3.dll", EntryPoint = "#138", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001([In] IntPtr obj0, [In] uint obj1);

  static void \u0001([In] PowerNest2 obj0)
  {
    foreach (GCHandle gcHandle in (IEnumerable<GCHandle>) obj0.\u0001)
      gcHandle.Free();
    obj0.\u0001.Clear();
  }

  [DllImport("opaline3.dll", EntryPoint = "#122", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] IntPtr obj1);

  [DllImport("anpn2key.dll", EntryPoint = "#51", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001(
    IntPtr _param0,
    IntPtr _param1,
    int _param2,
    out IntPtr _param3,
    out Point _param4,
    out Orientation _param5);

  [DllImport("opaline3.dll", EntryPoint = "#154", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern uint \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] int obj2);

  [DllImport("opaline3.dll", EntryPoint = "#121", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] IntPtr obj1);

  [DllImport("opaline3.dll", EntryPoint = "#145", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern void \u0001(
    IntPtr _param0,
    IntPtr _param1,
    out double _param2,
    out double _param3,
    out double _param4);

  [DllImport("opaline3.dll", EntryPoint = "#133", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0);

  [DllImport("anpn2key.dll", EntryPoint = "#530", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] int obj1);

  [DllImport("anpn2key.dll", EntryPoint = "#203", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001(
    [In] IntPtr obj0,
    [In] IntPtr obj1,
    [In] IntPtr[] obj2,
    [In] int[] obj3,
    [In] int obj4,
    [In] double obj5);

  [DllImport("anpn2key.dll", EntryPoint = "#501", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] double obj1, [In] double obj2);

  [DllImport("anpn2key.dll", EntryPoint = "#32", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] StringBuilder obj0);

  [DllImport("opaline3.dll", EntryPoint = "#113", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern void \u0001(
    IntPtr _param0,
    IntPtr _param1,
    uint _param2,
    IntPtr _param3,
    out double _param4,
    out double _param5,
    out double _param6,
    out double _param7,
    out double _param8,
    out double _param9);

  static IntPtr \u0001([In] IUserData obj0, [In] PowerNest2 obj1)
  {
    IntPtr num = IntPtr.Zero;
    if (obj0 != null)
    {
      GCHandle gcHandle = GCHandle.Alloc((object) obj0);
      num = GCHandle.ToIntPtr(gcHandle);
      obj1.\u0001.Add(gcHandle);
    }
    return num;
  }

  [DllImport("anpn2key.dll", EntryPoint = "#80", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] IntPtr obj2, [In] double obj3);

  [DllImport("anpn2key.dll", EntryPoint = "#506", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] double obj2);

  [DllImport("anpn2key.dll", EntryPoint = "#16", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001(
    [In] IntPtr obj0,
    [In] IntPtr obj1,
    [In] double obj2,
    [In] double obj3,
    [In] double obj4,
    [In] double obj5);

  [DllImport("opaline3.dll", EntryPoint = "#105", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern void \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] int obj2);

  static void \u0001([In] \u0007.\u0003.\u0003 obj0, [In] int obj1, [In] int obj2)
  {
    while (obj2-- > 0)
    {
      byte[] numArray = obj0.\u0001;
      \u0007.\u0003.\u0003 obj = obj0;
      int num1 = obj0.\u0001;
      int num2 = num1 + 1;
      obj.\u0001 = num2;
      int index = num1;
      int num3 = (int) obj0.\u0001[obj1++];
      numArray[index] = (byte) num3;
      obj0.\u0001 &= (int) short.MaxValue;
      obj1 &= (int) short.MaxValue;
    }
  }

  [DllImport("opaline3.dll", EntryPoint = "#153", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001([In] IntPtr obj0, [In] IntPtr obj1);

  [DllImport("opaline3.dll", EntryPoint = "#151", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] uint obj2);

  [DllImport("opaline3.dll", EntryPoint = "#141", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern uint \u0001([In] IntPtr obj0, [In] IntPtr obj1);

  [DllImport("opaline3.dll", EntryPoint = "#135", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern void \u0001(
    IntPtr _param0,
    uint _param1,
    out uint _param2,
    out IntPtr _param3,
    out IntPtr _param4);

  static IUserData \u0001([In] IntPtr obj0)
  {
    return !(obj0 == IntPtr.Zero) ? GCHandle.FromIntPtr(obj0).Target as IUserData : (IUserData) null;
  }

  [DllImport("anpn2key.dll", EntryPoint = "#531", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] double obj1);

  static int \u0001([In] int obj0, [In] byte[] obj1, [In] \u0007.\u0003.\u0003 obj2, [In] int obj3)
  {
    int num1 = obj2.\u0001;
    if (obj3 > ((\u0007.\u0003.\u0004) obj2).\u0002)
      obj3 = ((\u0007.\u0003.\u0004) obj2).\u0002;
    else
      num1 = obj2.\u0001 - ((\u0007.\u0003.\u0004) obj2).\u0002 + obj3 & (int) short.MaxValue;
    int num2 = obj3;
    int length = obj3 - num1;
    if (length > 0)
    {
      Array.Copy((Array) obj2.\u0001, 32768 /*0x8000*/ - length, (Array) obj1, obj0, length);
      obj0 += length;
      obj3 = num1;
    }
    Array.Copy((Array) obj2.\u0001, num1 - obj3, (Array) obj1, obj0, obj3);
    ((\u0007.\u0003.\u0004) obj2).\u0002 = ((\u0007.\u0003.\u0004) obj2).\u0002 - num2;
    if (((\u0007.\u0003.\u0004) obj2).\u0002 < 0)
      throw new InvalidOperationException();
    return num2;
  }

  [DllImport("opaline3.dll", EntryPoint = "#127", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern void \u0001([In] IntPtr obj0, [In] double obj1);

  [DllImport("anpn2key.dll", EntryPoint = "#304", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001([In] IntPtr obj0, [In] Point[] obj1, [In] int obj2, [In] Point obj3);

  [DllImport("anpn2key.dll", EntryPoint = "#25", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] \u0001.\u0003 obj1, [In] IntPtr obj2, [In] \u0001.\u0002 obj3, [In] IntPtr obj4);

  [DllImport("anpn2key.dll", EntryPoint = "#61", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001([In] IntPtr obj0, [In] Point[] obj1, [In] int obj2);

  [DllImport("anpn2key.dll", EntryPoint = "#67", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] IntPtr obj2);

  [DllImport("anpn2key.dll", EntryPoint = "#44", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001(
    [In] IntPtr obj0,
    [In] IntPtr obj1,
    [In] IntPtr[] obj2,
    [In] Point[] obj3,
    [In] Point[] obj4,
    [In] int obj5);

  [DllImport("opaline3.dll", EntryPoint = "#149", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] IntPtr obj1);

  static int \u0001([In] \u0007.\u0003.\u0007 obj0) => obj0.ReadByte() | obj0.ReadByte() << 8;

  [DllImport("opaline3.dll", EntryPoint = "#109", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001(
    [In] IntPtr obj0,
    [In] IntPtr obj1,
    [In] uint obj2,
    [In] double obj3,
    [In] double obj4,
    [In] uint obj5,
    [In] uint obj6,
    [In] double obj7,
    [In] double obj8,
    [In] uint obj9,
    [In] uint obj10,
    [In] double obj11,
    [In] double obj12,
    [In] uint obj13,
    [In] uint obj14);

  [DllImport("anpn2key.dll", EntryPoint = "#305", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] Point[] obj2, [In] int obj3);

  [DllImport("anpn2key.dll", EntryPoint = "#79", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] Point[] obj2, [In] int obj3, [In] double obj4);

  [DllImport("anpn2key.dll", EntryPoint = "#534", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001(
    IntPtr _param0,
    IntPtr _param1,
    IntPtr _param2,
    int _param3,
    out IntPtr _param4);

  [DllImport("anpn2key.dll", EntryPoint = "#21", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001(IntPtr _param0, IntPtr _param1, out double _param2, out int _param3);

  [DllImport("anpn2key.dll", EntryPoint = "#308", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] Point[] obj2, [In] int[] obj3, [In] int obj4);

  [DllImport("anpn2key.dll", EntryPoint = "#513", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001(
    [In] IntPtr obj0,
    [In] IntPtr obj1,
    [In] CommonCutClusterConstraint obj2,
    [In] CommonCutClusterConstraint obj3);

  [DllImport("opaline3.dll", EntryPoint = "#140", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001([In] IntPtr obj0, [In] uint obj1);

  static PowerNest2Cs.Session \u0001([In] PowerNest2 obj0)
  {
    return PowerNest2Cs.Wrappable.Create<PowerNest2Cs.Session>(\u0003.\u0001(), new PowerNest2Cs.Session());
  }

  [DllImport("opaline3.dll", EntryPoint = "#116", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern void \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] int obj2);

  static bool \u0001([In] \u0007.\u0003.\u0002 obj0) => obj0.\u0001 == obj0.\u0002;

  static void \u0001([In] string obj0, [In] int obj1)
  {
    try
    {
      lock (\u0001.\u0005.\u0001)
        \u0001.\u0005.\u0001.Add(obj1, obj0);
    }
    catch
    {
    }
  }

  static short \u0001([In] int obj0)
  {
    return (short) ((int) \u0007.\u0003.\u0006.\u0001[obj0 & 15] << 12 | (int) \u0007.\u0003.\u0006.\u0001[obj0 >> 4 & 15] << 8 | (int) \u0007.\u0003.\u0006.\u0001[obj0 >> 8 & 15] << 4 | (int) \u0007.\u0003.\u0006.\u0001[obj0 >> 12]);
  }

  [DllImport("opaline3.dll", EntryPoint = "#104", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001(
    [In] IntPtr obj0,
    [In] double obj1,
    [In] double obj2,
    [In] double obj3,
    [In] double obj4,
    [In] uint obj5);

  [DllImport("anpn2key.dll", EntryPoint = "#2002", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001(
    [In] IntPtr obj0,
    [In] IntPtr[] obj1,
    [In] int obj2,
    [In] int[] obj3,
    [In] IntPtr[] obj4,
    [In] int obj5,
    [In] double obj6,
    [In] string obj7,
    [In] StringBuilder obj8);

  static int \u0001([In] int obj0, [In] byte[] obj1, [In] \u0007.\u0003.\u0001 obj2, [In] int obj3)
  {
    int num1 = 0;
    do
    {
      if (obj2.\u0001 != 11)
        goto label_2;
label_1:
      continue;
label_2:
      int num2 = \u0003.\u0001(obj0, obj1, obj2.\u0001, obj3);
      obj0 += num2;
      num1 += num2;
      obj3 -= num2;
      if (obj3 != 0)
        goto label_1;
      goto label_4;
    }
    while (\u0003.\u0001(obj2) || ((\u0007.\u0003.\u0004) obj2.\u0001).\u0002 > 0 && obj2.\u0001 != 11);
    goto label_5;
label_4:
    return num1;
label_5:
    return num1;
  }

  [DllImport("opaline3.dll", EntryPoint = "#118", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern void \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] int obj2);

  [DllImport("anpn2key.dll", EntryPoint = "#302", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] string obj0);

  [DllImport("anpn2key.dll", EntryPoint = "#20", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] IntPtr[] obj2, [In] int obj3, [In] double obj4);

  [DllImport("opaline3.dll", EntryPoint = "#114", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern void \u0001(
    IntPtr _param0,
    IntPtr _param1,
    out double _param2,
    out double _param3,
    out uint _param4,
    out uint _param5,
    out double _param6,
    out double _param7,
    out uint _param8,
    out uint _param9,
    out double _param10,
    out double _param11,
    out uint _param12,
    out uint _param13);

  [DllImport("anpn2key.dll", EntryPoint = "#209", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] IntPtr obj2);

  static int \u0001([In] \u0007.\u0003.\u0004 obj0, [In] \u0007.\u0003.\u0002 obj1)
  {
    int index1;
    if ((index1 = \u0003.\u0001(obj1, 9)) >= 0)
    {
      int num1;
      if ((num1 = (int) obj0.\u0001[index1]) >= 0)
      {
        \u0003.\u0001(obj1, num1 & 15);
        return num1 >> 4;
      }
      int num2 = -(num1 >> 4);
      int num3 = num1 & 15;
      int num4;
      if ((num4 = \u0003.\u0001(obj1, num3)) >= 0)
      {
        int num5 = (int) obj0.\u0001[num2 | num4 >> 9];
        \u0003.\u0001(obj1, num5 & 15);
        return num5 >> 4;
      }
      int num6 = ((\u0007.\u0003.\u0003) obj1).\u0003;
      int num7 = \u0003.\u0001(obj1, num6);
      int num8 = (int) obj0.\u0001[num2 | num7 >> 9];
      if ((num8 & 15) > num6)
        return -1;
      \u0003.\u0001(obj1, num8 & 15);
      return num8 >> 4;
    }
    int num9 = ((\u0007.\u0003.\u0003) obj1).\u0003;
    int index2 = \u0003.\u0001(obj1, num9);
    int num10 = (int) obj0.\u0001[index2];
    if (num10 < 0 || (num10 & 15) > num9)
      return -1;
    \u0003.\u0001(obj1, num10 & 15);
    return num10 >> 4;
  }

  [DllImport("anpn2key.dll", EntryPoint = "#508", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] double obj2);

  [DllImport("anpn2key.dll", EntryPoint = "#206", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001(IntPtr _param0, IntPtr _param1, int _param2, out IntPtr _param3);

  static int \u0001([In] \u0007.\u0003.\u0007 obj0)
  {
    return \u0003.\u0001(obj0) | \u0003.\u0001(obj0) << 16 /*0x10*/;
  }

  [DllImport("anpn2key.dll", EntryPoint = "#512", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001(IntPtr _param0, IntPtr _param1, IntPtr _param2, out int _param3);

  [DllImport("anpn2key.dll", EntryPoint = "#503", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] double obj1);

  static int \u0001([In] \u0007.\u0003.\u0003 obj0)
  {
    return 32768 /*0x8000*/ - ((\u0007.\u0003.\u0004) obj0).\u0002;
  }

  static string \u0001([In] int obj0)
  {
    lock (\u0001.\u0005.\u0001)
    {
      string str;
      \u0001.\u0005.\u0001.TryGetValue(obj0, out str);
      if (str != null)
        return str;
    }
    return \u0003.\u0001(obj0);
  }

  [DllImport("opaline3.dll", EntryPoint = "#134", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0);

  [DllImport("anpn2key.dll", EntryPoint = "#208", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] string obj2);

  [DllImport("anpn2key.dll", EntryPoint = "#205", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001(IntPtr _param0, IntPtr _param1, out int _param2);

  static int \u0001([In] \u0007.\u0003.\u0003 obj0, [In] \u0007.\u0003.\u0002 obj1, [In] int obj2)
  {
    obj2 = Math.Min(Math.Min(obj2, 32768 /*0x8000*/ - ((\u0007.\u0003.\u0004) obj0).\u0002), \u0003.\u0001(obj1));
    int num1 = 32768 /*0x8000*/ - obj0.\u0001;
    int num2;
    if (obj2 > num1)
    {
      num2 = \u0003.\u0001(obj1, obj0.\u0001, obj0.\u0001, num1);
      if (num2 == num1)
        num2 += \u0003.\u0001(obj1, obj0.\u0001, 0, obj2 - num1);
    }
    else
      num2 = \u0003.\u0001(obj1, obj0.\u0001, obj0.\u0001, obj2);
    obj0.\u0001 = obj0.\u0001 + num2 & (int) short.MaxValue;
    ((\u0007.\u0003.\u0004) obj0).\u0002 = ((\u0007.\u0003.\u0004) obj0).\u0002 + num2;
    return num2;
  }

  [DllImport("opaline3.dll", EntryPoint = "#107", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern void \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] int obj2);

  static int \u0001([In] \u0007.\u0003.\u0002 obj0)
  {
    return obj0.\u0002 - obj0.\u0001 + (((\u0007.\u0003.\u0003) obj0).\u0003 >> 3);
  }

  static void \u0001([In] Opaline obj0, [In] bool obj1)
  {
    if (!obj0.\u0001 && obj1)
      \u0003.\u0001(obj0);
    obj0.\u0001 = true;
  }

  [DllImport("anpn2key.dll", EntryPoint = "#65", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] IntPtr obj2);

  static bool \u0001([In] \u0007.\u0003.\u0001 obj0)
  {
    switch (obj0.\u0001)
    {
      case 2:
        if (obj0.\u0001)
        {
          obj0.\u0001 = 12;
          return false;
        }
        int num1 = \u0003.\u0001(obj0.\u0001, 3);
        if (num1 < 0)
          return false;
        \u0003.\u0001(obj0.\u0001, 3);
        if ((num1 & 1) != 0)
          obj0.\u0001 = true;
        switch (num1 >> 1)
        {
          case 0:
            \u0003.\u0001(obj0.\u0001);
            obj0.\u0001 = 3;
            break;
          case 1:
            obj0.\u0001 = \u0007.\u0003.\u0004.\u0001;
            ((\u0007.\u0003.\u0002) obj0).\u0002 = \u0007.\u0003.\u0005.\u0002;
            obj0.\u0001 = 7;
            break;
          case 2:
            obj0.\u0001 = new \u0007.\u0003.\u0005();
            obj0.\u0001 = 6;
            break;
        }
        return true;
      case 3:
        if ((obj0.\u0005 = \u0003.\u0001(obj0.\u0001, 16 /*0x10*/)) < 0)
          return false;
        \u0003.\u0001(obj0.\u0001, 16 /*0x10*/);
        obj0.\u0001 = 4;
        goto case 4;
      case 4:
        if (\u0003.\u0001(obj0.\u0001, 16 /*0x10*/) < 0)
          return false;
        \u0003.\u0001(obj0.\u0001, 16 /*0x10*/);
        obj0.\u0001 = 5;
        goto case 5;
      case 5:
        int num2 = \u0003.\u0001(obj0.\u0001, obj0.\u0001, obj0.\u0005);
        obj0.\u0005 -= num2;
        if (obj0.\u0005 != 0)
          return !\u0003.\u0001(obj0.\u0001);
        obj0.\u0001 = 2;
        return true;
      case 6:
        if (!\u0003.\u0001(obj0.\u0001, obj0.\u0001))
          return false;
        obj0.\u0001 = \u0003.\u0001(obj0.\u0001);
        ((\u0007.\u0003.\u0002) obj0).\u0002 = \u0003.\u0001(obj0.\u0001);
        obj0.\u0001 = 7;
        goto case 7;
      case 7:
      case 8:
      case 9:
      case 10:
        return \u0003.\u0001(obj0);
      case 12:
        return false;
      default:
        return false;
    }
  }

  static byte[] \u0001([In] byte[] obj0)
  {
    \u0007.\u0003.\u0007 obj = (\u0007.\u0003.\u0007) new \u007B0fff6f10\u002D6f09\u002D4330\u002Daa4f\u002D33130487e5b3\u007D(obj0);
    byte[] numArray = new byte[0];
    int num1 = \u0003.\u0001(obj);
    int actualValue = num1 >> 24;
    if (num1 - (actualValue << 24) != 8223355)
      throw new FormatException("Unknown Header");
    switch (actualValue)
    {
      case 1:
        int length1 = \u0003.\u0001(obj);
        numArray = new byte[length1];
        int num2;
        for (int index = 0; index < length1; index += num2)
        {
          int length2 = \u0003.\u0001(obj);
          num2 = \u0003.\u0001(obj);
          byte[] buffer = new byte[length2];
          obj.Read(buffer, 0, buffer.Length);
          \u0003.\u0001(index, numArray, new \u0007.\u0003.\u0001(buffer), num2);
        }
        break;
      case 3:
        using (ICryptoTransform cryptoTransform = \u0003.\u0001(true, new byte[16 /*0x10*/]
        {
          (byte) 47,
          (byte) 135,
          (byte) 167,
          (byte) 81,
          (byte) 240 /*0xF0*/,
          (byte) 166,
          (byte) 219,
          (byte) 226,
          (byte) 151,
          (byte) 214,
          (byte) 24,
          (byte) 0,
          (byte) 57,
          (byte) 48 /*0x30*/,
          (byte) 53,
          (byte) 164
        }, new byte[16 /*0x10*/]
        {
          (byte) 238,
          (byte) 192 /*0xC0*/,
          (byte) 51,
          (byte) 250,
          (byte) 7,
          (byte) 167,
          (byte) 166,
          (byte) 187,
          (byte) 75,
          (byte) 68,
          (byte) 54,
          (byte) 116,
          (byte) 10,
          (byte) 95,
          (byte) 154,
          (byte) 229
        }))
        {
          numArray = \u0003.\u0001(cryptoTransform.TransformFinalBlock(obj0, 4, obj0.Length - 4));
          break;
        }
      default:
        throw new ArgumentOutOfRangeException("version", (object) actualValue, "Selected compression algorithm is not supported.");
    }
    obj.Close();
    return numArray;
  }

  [DllImport("opaline3.dll", EntryPoint = "#120", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] IntPtr obj1);

  [DllImport("opaline3.dll", EntryPoint = "#136", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern void \u0001(
    IntPtr _param0,
    out int _param1,
    out double _param2,
    out double _param3);

  [DllImport("anpn2key.dll", EntryPoint = "#210", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] \u0001.\u0003 obj1, [In] IntPtr obj2, [In] \u0005.\u0001 obj3, [In] IntPtr obj4);

  static bool \u0001([In] \u0007.\u0003.\u0005 obj0, [In] \u0007.\u0003.\u0002 obj1)
  {
    while (true)
    {
      switch (obj0.\u0001)
      {
        case 0:
          obj0.\u0002 = \u0003.\u0001(obj1, 5);
          if (obj0.\u0002 >= 0)
          {
            obj0.\u0002 += 257;
            \u0003.\u0001(obj1, 5);
            obj0.\u0001 = 1;
            goto case 1;
          }
          goto label_23;
        case 1:
          obj0.\u0003 = \u0003.\u0001(obj1, 5);
          if (obj0.\u0003 >= 0)
          {
            ++obj0.\u0003;
            \u0003.\u0001(obj1, 5);
            obj0.\u0005 = obj0.\u0002 + obj0.\u0003;
            obj0.\u0002 = new byte[obj0.\u0005];
            obj0.\u0001 = 2;
            goto case 2;
          }
          goto label_24;
        case 2:
          obj0.\u0004 = \u0003.\u0001(obj1, 4);
          if (obj0.\u0004 >= 0)
          {
            obj0.\u0004 += 4;
            \u0003.\u0001(obj1, 4);
            obj0.\u0001 = new byte[19];
            obj0.\u0007 = 0;
            obj0.\u0001 = 3;
            goto case 3;
          }
          goto label_25;
        case 3:
          for (; obj0.\u0007 < obj0.\u0004; ++obj0.\u0007)
          {
            int num = \u0003.\u0001(obj1, 3);
            if (num < 0)
              return false;
            \u0003.\u0001(obj1, 3);
            obj0.\u0001[\u0007.\u0003.\u0006.\u0003[obj0.\u0007]] = (byte) num;
          }
          obj0.\u0001 = (\u0007.\u0003.\u0004) new \u0007.\u0003.\u0005(obj0.\u0001);
          obj0.\u0001 = (byte[]) null;
          obj0.\u0007 = 0;
          obj0.\u0001 = 4;
          goto case 4;
        case 4:
          int num1;
          while (((num1 = \u0003.\u0001(obj0.\u0001, obj1)) & -16) == 0)
          {
            byte[] numArray = obj0.\u0002;
            \u0007.\u0003.\u0005 obj = obj0;
            int num2 = obj0.\u0007;
            int num3 = num2 + 1;
            obj.\u0007 = num3;
            int index = num2;
            int num4 = (int) (obj0.\u0001 = (byte) num1);
            numArray[index] = (byte) num4;
            if (obj0.\u0007 == obj0.\u0005)
              return true;
          }
          if (num1 >= 0)
          {
            if (num1 >= 17)
              obj0.\u0001 = (byte) 0;
            obj0.\u0006 = num1 - 16 /*0x10*/;
            obj0.\u0001 = 5;
            goto case 5;
          }
          goto label_27;
        case 5:
          int num5 = \u0007.\u0003.\u0005.\u0002[obj0.\u0006];
          int num6 = \u0003.\u0001(obj1, num5);
          if (num6 >= 0)
          {
            \u0003.\u0001(obj1, num5);
            int num7 = num6 + \u0007.\u0003.\u0005.\u0001[obj0.\u0006];
            while (num7-- > 0)
            {
              byte[] numArray = obj0.\u0002;
              \u0007.\u0003.\u0005 obj = obj0;
              int num8 = obj0.\u0007;
              int num9 = num8 + 1;
              obj.\u0007 = num9;
              int index = num8;
              int num10 = (int) obj0.\u0001;
              numArray[index] = (byte) num10;
            }
            if (obj0.\u0007 != obj0.\u0005)
            {
              obj0.\u0001 = 4;
              continue;
            }
            goto label_30;
          }
          goto label_29;
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
    return false;
label_30:
    return true;
  }

  [DllImport("anpn2key.dll", EntryPoint = "#71", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] IntPtr obj1, [In] IntPtr obj2);

  [DllImport("opaline3.dll", EntryPoint = "#126", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern void \u0001([In] IntPtr obj0, [In] double obj1);

  [DllImport("opaline3.dll", EntryPoint = "#112", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern uint \u0001([In] IntPtr obj0, [In] IntPtr obj1);

  [DllImport("opaline3.dll", EntryPoint = "#147", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] IntPtr obj1);

  [DllImport("opaline3.dll", EntryPoint = "#152", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern void \u0001(
    IntPtr _param0,
    IntPtr _param1,
    out IntPtr _param2,
    out uint _param3,
    out uint _param4,
    out uint _param5);

  [DllImport("anpn2key.dll", EntryPoint = "#532", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] double obj1);

  [DllImport("anpn2key.dll", EntryPoint = "#26", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern int \u0001([In] IntPtr obj0, [In] int obj1);

  [DllImport("anpn2key.dll", EntryPoint = "#35", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern IntPtr \u0001([In] IntPtr obj0, [In] Point[] obj1, [In] int obj2, [In] double obj3);

  [DllImport("opaline3.dll", EntryPoint = "#148", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
  static extern void \u0001(IntPtr _param0, IntPtr _param1, out int _param2, out uint _param3);
}
