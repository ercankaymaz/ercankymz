// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buOpcUA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF9DFBD0-0B81-4B3D-BD5F-1E30872BDC2B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcUA.dll

using buOpcUA;
using dummy_ptr;
using Opc.Ua;
using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

#nullable disable
namespace \u0002;

internal class \u0003
{
  static \u0003()
  {
    \u0006.\u0001.\u0005.\u0001 = new int[3]{ 3, 3, 11 };
    \u0006.\u0001.\u0005.\u0002 = new int[3]{ 2, 3, 7 };
    \u0006.\u0001.\u0006.\u0003 = new int[19]
    {
      16 /*0x10*/,
      17,
      18,
      0,
      8,
      7,
      9,
      6,
      10,
      5,
      11,
      4,
      12,
      3,
      13,
      2,
      14,
      1,
      15
    };
  }

  static \u0003()
  {
    \u0006.\u0001.\u0006.\u0001 = new int[19]
    {
      16 /*0x10*/,
      17,
      18,
      0,
      8,
      7,
      9,
      6,
      10,
      5,
      11,
      4,
      12,
      3,
      13,
      2,
      14,
      1,
      15
    };
    // ISSUE: reference to a compiler-generated field
    \u0004.\u0001.\u0001 = new byte[16 /*0x10*/]
    {
      (byte) 0,
      (byte) 8,
      (byte) 4,
      (byte) 12,
      (byte) 2,
      (byte) 10,
      (byte) 6,
      (byte) 14,
      (byte) 1,
      (byte) 9,
      (byte) 5,
      (byte) 13,
      (byte) 3,
      (byte) 11,
      (byte) 7,
      (byte) 15
    };
    // ISSUE: reference to a compiler-generated field
    \u0004.\u0001.\u0001 = new short[286];
    // ISSUE: reference to a compiler-generated field
    \u0004.\u0001.\u0002 = new byte[286];
    int index1;
    // ISSUE: reference to a compiler-generated field
    for (index1 = 0; index1 < 144 /*0x90*/; \u0004.\u0001.\u0002[index1++] = (byte) 8)
    {
      // ISSUE: reference to a compiler-generated field
      \u0004.\u0001.\u0001[index1] = \u0003.\u0001(48 /*0x30*/ + index1 << 8);
    }
    // ISSUE: reference to a compiler-generated field
    for (; index1 < 256 /*0x0100*/; \u0004.\u0001.\u0002[index1++] = (byte) 9)
    {
      // ISSUE: reference to a compiler-generated field
      \u0004.\u0001.\u0001[index1] = \u0003.\u0001(256 /*0x0100*/ + index1 << 7);
    }
    // ISSUE: reference to a compiler-generated field
    for (; index1 < 280; \u0004.\u0001.\u0002[index1++] = (byte) 7)
    {
      // ISSUE: reference to a compiler-generated field
      \u0004.\u0001.\u0001[index1] = \u0003.\u0001(index1 - 256 /*0x0100*/ << 9);
    }
    // ISSUE: reference to a compiler-generated field
    for (; index1 < 286; \u0004.\u0001.\u0002[index1++] = (byte) 8)
    {
      // ISSUE: reference to a compiler-generated field
      \u0004.\u0001.\u0001[index1] = \u0003.\u0001(index1 - 88 << 8);
    }
    // ISSUE: reference to a compiler-generated field
    \u0004.\u0001.\u0002 = new short[30];
    // ISSUE: reference to a compiler-generated field
    \u0004.\u0001.\u0003 = new byte[30];
    for (int index2 = 0; index2 < 30; ++index2)
    {
      // ISSUE: reference to a compiler-generated field
      \u0004.\u0001.\u0002[index2] = \u0003.\u0001(index2 << 11);
      // ISSUE: reference to a compiler-generated field
      \u0004.\u0001.\u0003[index2] = (byte) 5;
    }
  }

  public \u0003([In] byte[] obj0)
    : this(obj0, false)
  {
  }

  static int \u0001([In] \u0006.\u0001.\u0003 obj0) => ((\u0006.\u0001.\u0005) obj0).\u0002;

  static int \u0001([In] \u0006.\u0001.\u0003 obj0)
  {
    return 32768 /*0x8000*/ - ((\u0006.\u0001.\u0005) obj0).\u0002;
  }

  static int \u0001([In] \u0006.\u0001.\u0002 obj0)
  {
    return ((\u0006.\u0001.\u0003) obj0).\u0002 - ((\u0006.\u0001.\u0003) obj0).\u0001 + (((\u0006.\u0001.\u0004) obj0).\u0003 >> 3);
  }

  static void \u0001([In] \u0006.\u0001.\u0002 obj0)
  {
    ((\u0006.\u0001.\u0004) obj0).\u0001 = ((\u0006.\u0001.\u0004) obj0).\u0001 >> (((\u0006.\u0001.\u0004) obj0).\u0003 & 7);
    ((\u0006.\u0001.\u0004) obj0).\u0003 = ((\u0006.\u0001.\u0004) obj0).\u0003 & -8;
  }

  static bool \u0001([In] \u0006.\u0001.\u0002 obj0)
  {
    return ((\u0006.\u0001.\u0003) obj0).\u0001 == ((\u0006.\u0001.\u0003) obj0).\u0002;
  }

  static int \u0001([In] \u0006.\u0001.\u0007 obj0)
  {
    return \u0003.\u0001(obj0) | \u0003.\u0001(obj0) << 16 /*0x10*/;
  }

  static bool \u0001([In] \u0006.\u0001.\u0005 obj0, [In] \u0006.\u0001.\u0002 obj1)
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
            ((\u0006.\u0001.\u0006) obj0).\u0005 = obj0.\u0002 + obj0.\u0003;
            obj0.\u0002 = new byte[((\u0006.\u0001.\u0006) obj0).\u0005];
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
            ((\u0006.\u0001.\u0006) obj0).\u0007 = 0;
            obj0.\u0001 = 3;
            goto case 3;
          }
          goto label_25;
        case 3:
          for (; ((\u0006.\u0001.\u0006) obj0).\u0007 < obj0.\u0004; ((\u0006.\u0001.\u0006) obj0).\u0007 = ((\u0006.\u0001.\u0006) obj0).\u0007 + 1)
          {
            int num = \u0003.\u0001(obj1, 3);
            if (num < 0)
              return false;
            \u0003.\u0001(obj1, 3);
            obj0.\u0001[\u0006.\u0001.\u0006.\u0003[((\u0006.\u0001.\u0006) obj0).\u0007]] = (byte) num;
          }
          obj0.\u0001 = (\u0006.\u0001.\u0004) new \u0006.\u0001.\u0006(obj0.\u0001);
          obj0.\u0001 = (byte[]) null;
          ((\u0006.\u0001.\u0006) obj0).\u0007 = 0;
          obj0.\u0001 = 4;
          goto case 4;
        case 4:
          int num1;
          while (((num1 = \u0003.\u0001(obj0.\u0001, obj1)) & -16) == 0)
          {
            byte[] numArray = obj0.\u0002;
            \u0006.\u0001.\u0005 obj = obj0;
            int num2 = ((\u0006.\u0001.\u0006) obj0).\u0007;
            int num3 = num2 + 1;
            ((\u0006.\u0001.\u0006) obj).\u0007 = num3;
            int index = num2;
            int num4 = (int) (((\u0006.\u0001.\u0006) obj0).\u0001 = (byte) num1);
            numArray[index] = (byte) num4;
            if (((\u0006.\u0001.\u0006) obj0).\u0007 == ((\u0006.\u0001.\u0006) obj0).\u0005)
              return true;
          }
          if (num1 >= 0)
          {
            if (num1 >= 17)
              ((\u0006.\u0001.\u0006) obj0).\u0001 = (byte) 0;
            ((\u0006.\u0001.\u0006) obj0).\u0006 = num1 - 16 /*0x10*/;
            obj0.\u0001 = 5;
            goto case 5;
          }
          goto label_27;
        case 5:
          int num5 = \u0006.\u0001.\u0005.\u0002[((\u0006.\u0001.\u0006) obj0).\u0006];
          int num6 = \u0003.\u0001(obj1, num5);
          if (num6 >= 0)
          {
            \u0003.\u0001(obj1, num5);
            int num7 = num6 + \u0006.\u0001.\u0005.\u0001[((\u0006.\u0001.\u0006) obj0).\u0006];
            while (num7-- > 0)
            {
              byte[] numArray = obj0.\u0002;
              \u0006.\u0001.\u0005 obj = obj0;
              int num8 = ((\u0006.\u0001.\u0006) obj0).\u0007;
              int num9 = num8 + 1;
              ((\u0006.\u0001.\u0006) obj).\u0007 = num9;
              int index = num8;
              int num10 = (int) ((\u0006.\u0001.\u0006) obj0).\u0001;
              numArray[index] = (byte) num10;
            }
            if (((\u0006.\u0001.\u0006) obj0).\u0007 != ((\u0006.\u0001.\u0006) obj0).\u0005)
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

  static ApplicationConfiguration \u0001([In] OpcClient obj0)
  {
    return new ApplicationConfiguration()
    {
      ApplicationName = obj0.\u0001,
      ApplicationType = ApplicationType.Client,
      ApplicationUri = Opc.Ua.Utils.Format("urn:{0}:MyOPCClient", (object) Dns.GetHostName()),
      SecurityConfiguration = new SecurityConfiguration()
      {
        AutoAcceptUntrustedCertificates = true
      },
      TransportQuotas = new TransportQuotas()
      {
        OperationTimeout = 120000
      },
      ClientConfiguration = new ClientConfiguration()
      {
        DefaultSessionTimeout = 120000
      },
      TraceConfiguration = new TraceConfiguration()
    };
  }

  static void \u0001([In] byte[] obj0, [In] \u0006.\u0001.\u0002 obj1, [In] int obj2, [In] int obj3)
  {
    if (((\u0006.\u0001.\u0003) obj1).\u0001 < ((\u0006.\u0001.\u0003) obj1).\u0002)
      throw new InvalidOperationException();
    int num = obj2 + obj3;
    if (0 > obj2 || obj2 > num || num > obj0.Length)
      throw new ArgumentOutOfRangeException();
    if ((obj3 & 1) != 0)
    {
      ((\u0006.\u0001.\u0004) obj1).\u0001 = ((\u0006.\u0001.\u0004) obj1).\u0001 | (uint) (((int) obj0[obj2++] & (int) byte.MaxValue) << ((\u0006.\u0001.\u0004) obj1).\u0003);
      ((\u0006.\u0001.\u0004) obj1).\u0003 = ((\u0006.\u0001.\u0004) obj1).\u0003 + 8;
    }
    ((\u0006.\u0001.\u0003) obj1).\u0001 = obj0;
    ((\u0006.\u0001.\u0003) obj1).\u0001 = obj2;
    ((\u0006.\u0001.\u0003) obj1).\u0002 = num;
  }

  static void \u0001([In] \u0006.\u0001.\u0003 obj0, [In] int obj1)
  {
    \u0006.\u0001.\u0003 obj2 = obj0;
    int num1 = ((\u0006.\u0001.\u0005) obj0).\u0002;
    int num2 = num1 + 1;
    ((\u0006.\u0001.\u0005) obj2).\u0002 = num2;
    if (num1 == 32768 /*0x8000*/)
      throw new InvalidOperationException();
    byte[] numArray = ((\u0006.\u0001.\u0004) obj0).\u0001;
    \u0006.\u0001.\u0003 obj3 = obj0;
    int num3 = ((\u0006.\u0001.\u0005) obj0).\u0001;
    int num4 = num3 + 1;
    ((\u0006.\u0001.\u0005) obj3).\u0001 = num4;
    int index = num3;
    int num5 = (int) (byte) obj1;
    numArray[index] = (byte) num5;
    ((\u0006.\u0001.\u0005) obj0).\u0001 = ((\u0006.\u0001.\u0005) obj0).\u0001 & (int) short.MaxValue;
  }

  static void \u0001([In] \u0006.\u0001.\u0002 obj0, [In] int obj1)
  {
    ((\u0006.\u0001.\u0004) obj0).\u0001 = ((\u0006.\u0001.\u0004) obj0).\u0001 >> obj1;
    ((\u0006.\u0001.\u0004) obj0).\u0003 = ((\u0006.\u0001.\u0004) obj0).\u0003 - obj1;
  }

  static int \u0001([In] \u0006.\u0001.\u0002 obj0, [In] byte[] obj1, [In] int obj2, [In] int obj3)
  {
    int num1 = 0;
    while (((\u0006.\u0001.\u0004) obj0).\u0003 > 0 && obj3 > 0)
    {
      obj1[obj2++] = (byte) ((\u0006.\u0001.\u0004) obj0).\u0001;
      ((\u0006.\u0001.\u0004) obj0).\u0001 = ((\u0006.\u0001.\u0004) obj0).\u0001 >> 8;
      ((\u0006.\u0001.\u0004) obj0).\u0003 = ((\u0006.\u0001.\u0004) obj0).\u0003 - 8;
      --obj3;
      ++num1;
    }
    if (obj3 == 0)
      return num1;
    int num2 = ((\u0006.\u0001.\u0003) obj0).\u0002 - ((\u0006.\u0001.\u0003) obj0).\u0001;
    if (obj3 > num2)
      obj3 = num2;
    Array.Copy((Array) ((\u0006.\u0001.\u0003) obj0).\u0001, ((\u0006.\u0001.\u0003) obj0).\u0001, (Array) obj1, obj2, obj3);
    ((\u0006.\u0001.\u0003) obj0).\u0001 = ((\u0006.\u0001.\u0003) obj0).\u0001 + obj3;
    if ((((\u0006.\u0001.\u0003) obj0).\u0001 - ((\u0006.\u0001.\u0003) obj0).\u0002 & 1) != 0)
    {
      \u0006.\u0001.\u0002 obj4 = obj0;
      byte[] numArray = ((\u0006.\u0001.\u0003) obj0).\u0001;
      \u0006.\u0001.\u0002 obj5 = obj0;
      int num3 = ((\u0006.\u0001.\u0003) obj0).\u0001;
      int num4 = num3 + 1;
      ((\u0006.\u0001.\u0003) obj5).\u0001 = num4;
      int index = num3;
      int num5 = (int) numArray[index] & (int) byte.MaxValue;
      ((\u0006.\u0001.\u0004) obj4).\u0001 = (uint) num5;
      ((\u0006.\u0001.\u0004) obj0).\u0003 = 8;
    }
    return num1 + obj3;
  }

  static void \u0001([In] \u0006.\u0001.\u0003 obj0, [In] int obj1, [In] int obj2)
  {
    if ((((\u0006.\u0001.\u0005) obj0).\u0002 = ((\u0006.\u0001.\u0005) obj0).\u0002 + obj1) > 32768 /*0x8000*/)
      throw new InvalidOperationException();
    int sourceIndex = ((\u0006.\u0001.\u0005) obj0).\u0001 - obj2 & (int) short.MaxValue;
    int num1 = 32768 /*0x8000*/ - obj1;
    if (sourceIndex <= num1 && ((\u0006.\u0001.\u0005) obj0).\u0001 < num1)
    {
      if (obj1 <= obj2)
      {
        Array.Copy((Array) ((\u0006.\u0001.\u0004) obj0).\u0001, sourceIndex, (Array) ((\u0006.\u0001.\u0004) obj0).\u0001, ((\u0006.\u0001.\u0005) obj0).\u0001, obj1);
        ((\u0006.\u0001.\u0005) obj0).\u0001 = ((\u0006.\u0001.\u0005) obj0).\u0001 + obj1;
      }
      else
      {
        while (obj1-- > 0)
        {
          byte[] numArray = ((\u0006.\u0001.\u0004) obj0).\u0001;
          \u0006.\u0001.\u0003 obj = obj0;
          int num2 = ((\u0006.\u0001.\u0005) obj0).\u0001;
          int num3 = num2 + 1;
          ((\u0006.\u0001.\u0005) obj).\u0001 = num3;
          int index = num2;
          int num4 = (int) ((\u0006.\u0001.\u0004) obj0).\u0001[sourceIndex++];
          numArray[index] = (byte) num4;
        }
      }
    }
    else
      \u0003.\u0001(obj0, sourceIndex, obj1);
  }

  static void \u0001([In] int obj0, [In] string obj1)
  {
    try
    {
      lock (\u0005.\u0003.\u0001)
        \u0005.\u0003.\u0001.Add(obj0, obj1);
    }
    catch
    {
    }
  }

  static int \u0001([In] \u0006.\u0001.\u0002 obj0) => ((\u0006.\u0001.\u0004) obj0).\u0003;

  static int \u0001([In] \u0006.\u0001.\u0007 obj0) => obj0.ReadByte() | obj0.ReadByte() << 8;

  static short \u0001([In] int obj0)
  {
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    return (short) ((int) \u0004.\u0001.\u0001[obj0 & 15] << 12 | (int) \u0004.\u0001.\u0001[obj0 >> 4 & 15] << 8 | (int) \u0004.\u0001.\u0001[obj0 >> 8 & 15] << 4 | (int) \u0004.\u0001.\u0001[obj0 >> 12]);
  }

  static void \u0001([In] \u0006.\u0001.\u0003 obj0, [In] int obj1, [In] int obj2)
  {
    while (obj2-- > 0)
    {
      byte[] numArray = ((\u0006.\u0001.\u0004) obj0).\u0001;
      \u0006.\u0001.\u0003 obj = obj0;
      int num1 = ((\u0006.\u0001.\u0005) obj0).\u0001;
      int num2 = num1 + 1;
      ((\u0006.\u0001.\u0005) obj).\u0001 = num2;
      int index = num1;
      int num3 = (int) ((\u0006.\u0001.\u0004) obj0).\u0001[obj1++];
      numArray[index] = (byte) num3;
      ((\u0006.\u0001.\u0005) obj0).\u0001 = ((\u0006.\u0001.\u0005) obj0).\u0001 & (int) short.MaxValue;
      obj1 &= (int) short.MaxValue;
    }
  }

  static bool \u0001([In] \u0006.\u0001.\u0001 obj0)
  {
    switch (obj0.\u0001)
    {
      case 2:
        if (obj0.\u0001)
        {
          obj0.\u0001 = 12;
          return false;
        }
        int num1 = \u0003.\u0001(((\u0006.\u0001.\u0002) obj0).\u0001, 3);
        if (num1 < 0)
          return false;
        \u0003.\u0001(((\u0006.\u0001.\u0002) obj0).\u0001, 3);
        if ((num1 & 1) != 0)
          obj0.\u0001 = true;
        switch (num1 >> 1)
        {
          case 0:
            \u0003.\u0001(((\u0006.\u0001.\u0002) obj0).\u0001);
            obj0.\u0001 = 3;
            break;
          case 1:
            ((\u0006.\u0001.\u0002) obj0).\u0001 = \u0006.\u0001.\u0005.\u0001;
            ((\u0006.\u0001.\u0002) obj0).\u0002 = \u0006.\u0001.\u0005.\u0002;
            obj0.\u0001 = 7;
            break;
          case 2:
            ((\u0006.\u0001.\u0002) obj0).\u0001 = (\u0006.\u0001.\u0005) new \u0006.\u0001.\u0007();
            obj0.\u0001 = 6;
            break;
        }
        return true;
      case 3:
        if ((obj0.\u0005 = \u0003.\u0001(((\u0006.\u0001.\u0002) obj0).\u0001, 16 /*0x10*/)) < 0)
          return false;
        \u0003.\u0001(((\u0006.\u0001.\u0002) obj0).\u0001, 16 /*0x10*/);
        obj0.\u0001 = 4;
        goto case 4;
      case 4:
        if (\u0003.\u0001(((\u0006.\u0001.\u0002) obj0).\u0001, 16 /*0x10*/) < 0)
          return false;
        \u0003.\u0001(((\u0006.\u0001.\u0002) obj0).\u0001, 16 /*0x10*/);
        obj0.\u0001 = 5;
        goto case 5;
      case 5:
        int num2 = \u0003.\u0001(((\u0006.\u0001.\u0002) obj0).\u0001, ((\u0006.\u0001.\u0002) obj0).\u0001, obj0.\u0005);
        obj0.\u0005 -= num2;
        if (obj0.\u0005 != 0)
          return !\u0003.\u0001(((\u0006.\u0001.\u0002) obj0).\u0001);
        obj0.\u0001 = 2;
        return true;
      case 6:
        if (!\u0003.\u0001(((\u0006.\u0001.\u0002) obj0).\u0001, ((\u0006.\u0001.\u0002) obj0).\u0001))
          return false;
        ((\u0006.\u0001.\u0002) obj0).\u0001 = \u0003.\u0001(((\u0006.\u0001.\u0002) obj0).\u0001);
        ((\u0006.\u0001.\u0002) obj0).\u0002 = \u007Bc4786be5\u002D4d12\u002D491c\u002D8bef\u002D494b08e93552\u007D.\u0001(((\u0006.\u0001.\u0002) obj0).\u0001);
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

  static bool \u0001([In] \u0006.\u0001.\u0001 obj0)
  {
    int num1 = \u0003.\u0001(((\u0006.\u0001.\u0002) obj0).\u0001);
    while (num1 >= 258)
    {
      switch (obj0.\u0001)
      {
        case 7:
          int num2;
          while (((num2 = \u0003.\u0001(((\u0006.\u0001.\u0002) obj0).\u0001, ((\u0006.\u0001.\u0002) obj0).\u0001)) & -256) == 0)
          {
            \u0003.\u0001(((\u0006.\u0001.\u0002) obj0).\u0001, num2);
            if (--num1 < 258)
              return true;
          }
          if (num2 >= 257)
          {
            obj0.\u0003 = \u0006.\u0001.\u0001.\u0001[num2 - 257];
            obj0.\u0002 = \u0006.\u0001.\u0001.\u0002[num2 - 257];
            goto case 8;
          }
          if (num2 < 0)
            return false;
          ((\u0006.\u0001.\u0002) obj0).\u0002 = (\u0006.\u0001.\u0004) null;
          ((\u0006.\u0001.\u0002) obj0).\u0001 = (\u0006.\u0001.\u0004) null;
          obj0.\u0001 = 2;
          return true;
        case 8:
          if (obj0.\u0002 > 0)
          {
            obj0.\u0001 = 8;
            int num3 = \u0003.\u0001(((\u0006.\u0001.\u0002) obj0).\u0001, obj0.\u0002);
            if (num3 < 0)
              return false;
            \u0003.\u0001(((\u0006.\u0001.\u0002) obj0).\u0001, obj0.\u0002);
            obj0.\u0003 += num3;
          }
          obj0.\u0001 = 9;
          goto case 9;
        case 9:
          int index = \u0003.\u0001(((\u0006.\u0001.\u0002) obj0).\u0002, ((\u0006.\u0001.\u0002) obj0).\u0001);
          if (index < 0)
            return false;
          obj0.\u0004 = \u0006.\u0001.\u0001.\u0003[index];
          obj0.\u0002 = \u0006.\u0001.\u0001.\u0004[index];
          goto case 10;
        case 10:
          if (obj0.\u0002 > 0)
          {
            obj0.\u0001 = 10;
            int num4 = \u0003.\u0001(((\u0006.\u0001.\u0002) obj0).\u0001, obj0.\u0002);
            if (num4 < 0)
              return false;
            \u0003.\u0001(((\u0006.\u0001.\u0002) obj0).\u0001, obj0.\u0002);
            obj0.\u0004 += num4;
          }
          \u0003.\u0001(((\u0006.\u0001.\u0002) obj0).\u0001, obj0.\u0003, obj0.\u0004);
          num1 -= obj0.\u0003;
          obj0.\u0001 = 7;
          continue;
        default:
          continue;
      }
    }
    return true;
  }

  static int \u0001([In] byte[] obj0, [In] \u0006.\u0001.\u0001 obj1, [In] int obj2, [In] int obj3)
  {
    int num1 = 0;
    do
    {
      if (obj1.\u0001 != 11)
        goto label_2;
label_1:
      continue;
label_2:
      int num2 = \u0003.\u0001(obj3, obj2, obj0, ((\u0006.\u0001.\u0002) obj1).\u0001);
      obj3 += num2;
      num1 += num2;
      obj2 -= num2;
      if (obj2 != 0)
        goto label_1;
      goto label_4;
    }
    while (\u0003.\u0001(obj1) || ((\u0006.\u0001.\u0005) ((\u0006.\u0001.\u0002) obj1).\u0001).\u0002 > 0 && obj1.\u0001 != 11);
    goto label_5;
label_4:
    return num1;
label_5:
    return num1;
  }

  static int \u0001([In] \u0006.\u0001.\u0004 obj0, [In] \u0006.\u0001.\u0002 obj1)
  {
    int index1;
    if ((index1 = \u0003.\u0001(obj1, 9)) >= 0)
    {
      int num1;
      if ((num1 = (int) ((\u0006.\u0001.\u0005) obj0).\u0001[index1]) >= 0)
      {
        \u0003.\u0001(obj1, num1 & 15);
        return num1 >> 4;
      }
      int num2 = -(num1 >> 4);
      int num3 = num1 & 15;
      int num4;
      if ((num4 = \u0003.\u0001(obj1, num3)) >= 0)
      {
        int num5 = (int) ((\u0006.\u0001.\u0005) obj0).\u0001[num2 | num4 >> 9];
        \u0003.\u0001(obj1, num5 & 15);
        return num5 >> 4;
      }
      int num6 = ((\u0006.\u0001.\u0004) obj1).\u0003;
      int num7 = \u0003.\u0001(obj1, num6);
      int num8 = (int) ((\u0006.\u0001.\u0005) obj0).\u0001[num2 | num7 >> 9];
      if ((num8 & 15) > num6)
        return -1;
      \u0003.\u0001(obj1, num8 & 15);
      return num8 >> 4;
    }
    int num9 = ((\u0006.\u0001.\u0004) obj1).\u0003;
    int index2 = \u0003.\u0001(obj1, num9);
    int num10 = (int) ((\u0006.\u0001.\u0005) obj0).\u0001[index2];
    if (num10 < 0 || (num10 & 15) > num9)
      return -1;
    \u0003.\u0001(obj1, num10 & 15);
    return num10 >> 4;
  }

  static int \u0001([In] int obj0, [In] int obj1, [In] byte[] obj2, [In] \u0006.\u0001.\u0003 obj3)
  {
    int num1 = ((\u0006.\u0001.\u0005) obj3).\u0001;
    if (obj1 > ((\u0006.\u0001.\u0005) obj3).\u0002)
      obj1 = ((\u0006.\u0001.\u0005) obj3).\u0002;
    else
      num1 = ((\u0006.\u0001.\u0005) obj3).\u0001 - ((\u0006.\u0001.\u0005) obj3).\u0002 + obj1 & (int) short.MaxValue;
    int num2 = obj1;
    int length = obj1 - num1;
    if (length > 0)
    {
      Array.Copy((Array) ((\u0006.\u0001.\u0004) obj3).\u0001, 32768 /*0x8000*/ - length, (Array) obj2, obj0, length);
      obj0 += length;
      obj1 = num1;
    }
    Array.Copy((Array) ((\u0006.\u0001.\u0004) obj3).\u0001, num1 - obj1, (Array) obj2, obj0, obj1);
    ((\u0006.\u0001.\u0005) obj3).\u0002 = ((\u0006.\u0001.\u0005) obj3).\u0002 - num2;
    if (((\u0006.\u0001.\u0005) obj3).\u0002 < 0)
      throw new InvalidOperationException();
    return num2;
  }

  static int \u0001([In] \u0006.\u0001.\u0002 obj0, [In] int obj1)
  {
    if (((\u0006.\u0001.\u0004) obj0).\u0003 < obj1)
    {
      if (((\u0006.\u0001.\u0003) obj0).\u0001 == ((\u0006.\u0001.\u0003) obj0).\u0002)
        return -1;
      \u0006.\u0001.\u0002 obj2 = obj0;
      int num1 = (int) ((\u0006.\u0001.\u0004) obj0).\u0001;
      byte[] numArray1 = ((\u0006.\u0001.\u0003) obj0).\u0001;
      \u0006.\u0001.\u0002 obj3 = obj0;
      int num2 = ((\u0006.\u0001.\u0003) obj0).\u0001;
      int num3 = num2 + 1;
      ((\u0006.\u0001.\u0003) obj3).\u0001 = num3;
      int index1 = num2;
      int num4 = (int) numArray1[index1] & (int) byte.MaxValue;
      byte[] numArray2 = ((\u0006.\u0001.\u0003) obj0).\u0001;
      \u0006.\u0001.\u0002 obj4 = obj0;
      int num5 = ((\u0006.\u0001.\u0003) obj0).\u0001;
      int num6 = num5 + 1;
      ((\u0006.\u0001.\u0003) obj4).\u0001 = num6;
      int index2 = num5;
      int num7 = ((int) numArray2[index2] & (int) byte.MaxValue) << 8;
      int num8 = (num4 | num7) << ((\u0006.\u0001.\u0004) obj0).\u0003;
      int num9 = num1 | num8;
      ((\u0006.\u0001.\u0004) obj2).\u0001 = (uint) num9;
      ((\u0006.\u0001.\u0004) obj0).\u0003 = ((\u0006.\u0001.\u0004) obj0).\u0003 + 16 /*0x10*/;
    }
    return (int) ((long) ((\u0006.\u0001.\u0004) obj0).\u0001 & (long) ((1 << obj1) - 1));
  }

  static string \u0001([In] int obj0)
  {
    lock (\u0005.\u0003.\u0001)
    {
      string str;
      \u0005.\u0003.\u0001.TryGetValue(obj0, out str);
      if (str != null)
        return str;
    }
    return \u007Bc4786be5\u002D4d12\u002D491c\u002D8bef\u002D494b08e93552\u007D.\u0001(obj0);
  }

  static void \u0001([In] \u0006.\u0001.\u0004 obj0, [In] byte[] obj1)
  {
    int[] numArray1 = new int[16 /*0x10*/];
    int[] numArray2 = new int[16 /*0x10*/];
    for (int index1 = 0; index1 < obj1.Length; ++index1)
    {
      int index2 = (int) obj1[index1];
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
    ((\u0006.\u0001.\u0005) obj0).\u0001 = new short[length];
    int num4 = 512 /*0x0200*/;
    for (int index3 = 15; index3 >= 10; --index3)
    {
      int num5 = num1 & 130944;
      num1 -= numArray1[index3] << 16 /*0x10*/ - index3;
      for (int index4 = num1 & 130944; index4 < num5; index4 += 128 /*0x80*/)
      {
        ((\u0006.\u0001.\u0005) obj0).\u0001[(int) \u0003.\u0001(index4)] = (short) (-num4 << 4 | index3);
        num4 += 1 << index3 - 9;
      }
    }
    for (int index5 = 0; index5 < obj1.Length; ++index5)
    {
      int index6 = (int) obj1[index5];
      if (index6 != 0)
      {
        int num6 = numArray2[index6];
        int index7 = (int) \u0003.\u0001(num6);
        if (index6 <= 9)
        {
          do
          {
            ((\u0006.\u0001.\u0005) obj0).\u0001[index7] = (short) (index5 << 4 | index6);
            index7 += 1 << index6;
          }
          while (index7 < 512 /*0x0200*/);
        }
        else
        {
          int num7 = (int) ((\u0006.\u0001.\u0005) obj0).\u0001[index7 & 511 /*0x01FF*/];
          int num8 = 1 << (num7 & 15);
          int num9 = -(num7 >> 4);
          do
          {
            ((\u0006.\u0001.\u0005) obj0).\u0001[num9 | index7 >> 9] = (short) (index5 << 4 | index6);
            index7 += 1 << index6;
          }
          while (index7 < num8);
        }
        numArray2[index6] = num6 + (1 << 16 /*0x10*/ - index6);
      }
    }
  }

  static \u0006.\u0001.\u0004 \u0001([In] \u0006.\u0001.\u0005 obj0)
  {
    byte[] destinationArray = new byte[obj0.\u0002];
    Array.Copy((Array) obj0.\u0002, 0, (Array) destinationArray, 0, obj0.\u0002);
    return (\u0006.\u0001.\u0004) new \u0006.\u0001.\u0006(destinationArray);
  }

  static int \u0001([In] \u0006.\u0001.\u0003 obj0, [In] \u0006.\u0001.\u0002 obj1, [In] int obj2)
  {
    obj2 = Math.Min(Math.Min(obj2, 32768 /*0x8000*/ - ((\u0006.\u0001.\u0005) obj0).\u0002), \u0003.\u0001(obj1));
    int num1 = 32768 /*0x8000*/ - ((\u0006.\u0001.\u0005) obj0).\u0001;
    int num2;
    if (obj2 > num1)
    {
      num2 = \u0003.\u0001(obj1, ((\u0006.\u0001.\u0004) obj0).\u0001, ((\u0006.\u0001.\u0005) obj0).\u0001, num1);
      if (num2 == num1)
        num2 += \u0003.\u0001(obj1, ((\u0006.\u0001.\u0004) obj0).\u0001, 0, obj2 - num1);
    }
    else
      num2 = \u0003.\u0001(obj1, ((\u0006.\u0001.\u0004) obj0).\u0001, ((\u0006.\u0001.\u0005) obj0).\u0001, obj2);
    ((\u0006.\u0001.\u0005) obj0).\u0001 = ((\u0006.\u0001.\u0005) obj0).\u0001 + num2 & (int) short.MaxValue;
    ((\u0006.\u0001.\u0005) obj0).\u0002 = ((\u0006.\u0001.\u0005) obj0).\u0002 + num2;
    return num2;
  }

  static ICryptoTransform \u0001([In] byte[] obj0, [In] bool obj1, [In] byte[] obj2)
  {
    using (AesCryptoServiceProvider cryptoServiceProvider = new AesCryptoServiceProvider())
      return obj1 ? cryptoServiceProvider.CreateDecryptor(obj2, obj0) : cryptoServiceProvider.CreateEncryptor(obj2, obj0);
  }
}
