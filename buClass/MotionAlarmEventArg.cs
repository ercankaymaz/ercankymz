// Decompiled with JetBrains decompiler
// Type: buClass.MotionAlarmEventArg
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Collections.Generic;

#nullable disable
namespace buClass;

public class MotionAlarmEventArg
{
  public List<CodesysAlarm> AlarmList = new List<CodesysAlarm>();
  public int AlarmCount = 0;

  public MotionAlarmEventArg()
  {
  }

  public MotionAlarmEventArg(List<CodesysAlarm> alarmList, int count)
  {
    this.AlarmCount = count;
    this.AlarmList.Clear();
    for (int index = 0; index <= alarmList.Count - 1; ++index)
      this.AlarmList.Add(new CodesysAlarm(alarmList[index]));
  }

  public override string ToString() => "Count =  " + this.AlarmCount.ToString();
}
