// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using dummy_ptr;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace \u0005;

[AttributeUsage(AttributeTargets.Method)]
internal class \u0001 : Attribute
{
  static bool \u0001([In] \u0018.\u0002.\u0005 obj0, [In] \u0018.\u0002.\u0002 obj1)
  {
    while (true)
    {
      switch (((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0001)
      {
        case 0:
          ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0002 = \u0007.\u0001.\u0001(obj1, 5);
          if (((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0002 >= 0)
          {
            ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0002 = ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0002 + 257;
            \u0007.\u0001.\u0001(obj1, 5);
            ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0001 = 1;
            goto case 1;
          }
          goto label_23;
        case 1:
          ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0003 = \u0007.\u0001.\u0001(obj1, 5);
          if (((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0003 >= 0)
          {
            ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0003 = ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0003 + 1;
            \u0007.\u0001.\u0001(obj1, 5);
            ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0005 = ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0002 + ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0003;
            ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0002 = new byte[((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0005];
            ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0001 = 2;
            goto case 2;
          }
          goto label_24;
        case 2:
          ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0004 = \u0007.\u0001.\u0001(obj1, 4);
          if (((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0004 >= 0)
          {
            ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0004 = ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0004 + 4;
            \u0007.\u0001.\u0001(obj1, 4);
            ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0001 = new byte[19];
            ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0007 = 0;
            ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0001 = 3;
            goto case 3;
          }
          goto label_25;
        case 3:
          for (; ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0007 < ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0004; ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0007 = ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0007 + 1)
          {
            int num = \u0007.\u0001.\u0001(obj1, 3);
            if (num < 0)
              return false;
            \u0007.\u0001.\u0001(obj1, 3);
            ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0001[\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0003[((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0007]] = (byte) num;
          }
          ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0001 = (\u0018.\u0002.\u0004) new \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D(((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0001);
          ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0001 = (byte[]) null;
          ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0007 = 0;
          ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0001 = 4;
          goto case 4;
        case 4:
          int num1;
          while (((num1 = \u0007.\u0001.\u0001(((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0001, obj1)) & -16) == 0)
          {
            byte[] numArray = ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0002;
            \u0018.\u0002.\u0005 obj = obj0;
            int num2 = ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0007;
            int num3 = num2 + 1;
            ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj).\u0007 = num3;
            int index = num2;
            int num4 = (int) (((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0001 = (byte) num1);
            numArray[index] = (byte) num4;
            if (((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0007 == ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0005)
              return true;
          }
          if (num1 >= 0)
          {
            if (num1 >= 17)
              ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0001 = (byte) 0;
            ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0006 = num1 - 16 /*0x10*/;
            ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0001 = 5;
            goto case 5;
          }
          goto label_27;
        case 5:
          int num5 = \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0002[((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0006];
          int num6 = \u0007.\u0001.\u0001(obj1, num5);
          if (num6 >= 0)
          {
            \u0007.\u0001.\u0001(obj1, num5);
            int num7 = num6 + \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001[((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0006];
            while (num7-- > 0)
            {
              byte[] numArray = ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0002;
              \u0018.\u0002.\u0005 obj = obj0;
              int num8 = ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0007;
              int num9 = num8 + 1;
              ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj).\u0007 = num9;
              int index = num8;
              int num10 = (int) ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0001;
              numArray[index] = (byte) num10;
            }
            if (((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0007 != ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0005)
            {
              ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) obj0).\u0001 = 4;
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
}
