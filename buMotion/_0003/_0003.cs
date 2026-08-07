// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buMotion, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: F5000E34-965A-4264-B97F-117192F983D9
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMotion.dll

using buMotion;
using System.IO;
using System.Runtime.CompilerServices;

#nullable disable
namespace \u0003;

internal static class \u0003
{
  internal sealed class \u0001
  {
    public const TechnicianType Mechanic = ; // Unable to render the field
    public const TechnicianType TechnicalService = ; // Unable to render the field
    public const TechnicianType Supervisor = ; // Unable to render the field
    [SpecialName]
    public int value__;
    public const AlarmWarningActionType Warning = ; // Unable to render the field
    public const AlarmWarningActionType SoftAlarm = ; // Unable to render the field
    public const AlarmWarningActionType HardAlarm = ; // Unable to render the field
    public const AlarmWarningActionType Information = ; // Unable to render the field
    public const AlarmWarningActionType NoAction = ; // Unable to render the field
    public const AlarmWarningActionType Pause = ; // Unable to render the field
    public static byte f000221;
    public static byte f000222;
    internal static readonly \u0003.\u0001.\u0001 \u0001;
    public static byte f000224;
    public static byte f000225;

    public \u0001(TechnicianLoginInfo data)
    {
      // ISSUE: unable to decompile the method.
    }

    public override string ToString() => ((AlarmWarningActionType) this).TechName;
  }

  internal sealed class \u0002
  {
    public static byte f000226;
    public static byte f000227;
    public static byte f000228;
    public static byte f000229;
    public static byte f00022A;

    public abstract void m0000BE();
  }

  internal sealed class \u0003
  {
    [SpecialName]
    public int value__;
    public const \u0003.\u0002 \u0001 = \u0003.\u0002.Electrician;
    public const \u0003.\u0002 \u0002 = (\u0003.\u0002) 1;

    public abstract void m0000BF();
  }

  internal sealed class \u0004
  {
    public const \u0003.\u0002 \u0003 = (\u0003.\u0002) 2;
    public const \u0003.\u0002 \u0004 = (\u0003.\u0002) 3;
    internal static readonly int[] \u0001;

    public abstract void m0000C0();

    public abstract void m0000C1();
  }

  internal sealed class \u0005
  {
    internal static readonly int[] \u0002;
    internal static readonly int[] \u0003;
    internal static readonly int[] \u0004;
    internal int \u0001;
    internal int \u0002;
    internal int \u0003;
    internal int \u0004;
    internal int \u0005;
    internal bool \u0001;
    internal \u0003.\u0003.\u0002 \u0001;
    internal \u0003.\u0003.\u0003 \u0001;
    internal \u0003.\u0003.\u0005 \u0001;
    internal \u0003.\u0003.\u0004 \u0001;
    internal \u0003.\u0003.\u0004 \u0002;

    public abstract void m0000C2();

    public abstract void m0000C3();
  }

  internal sealed class \u0006
  {
    internal byte[] \u0001;
    internal int \u0001;
    internal int \u0002;
    internal uint \u0001;
    internal int \u0003;
    internal byte[] \u0001;

    public abstract void m0000C4();
  }

  internal sealed class \u0007 : MemoryStream
  {
    public abstract void m0000C5();
  }
}
