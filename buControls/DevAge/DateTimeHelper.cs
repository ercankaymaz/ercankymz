// Decompiled with JetBrains decompiler
// Type: DevAge.DateTimeHelper
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace DevAge;

public class DateTimeHelper
{
  public static int YearsDifference(DateTime dateA, DateTime dateB)
  {
    return DateTimeHelper.MonthsDifference(dateA, dateB) / 12;
  }

  public static int MonthsDifference(DateTime dateA, DateTime dateB)
  {
    int num;
    if (dateA == dateB)
      num = 0;
    else if (dateA > dateB)
    {
      int months = (dateA.Year - dateB.Year) * 12 + (dateA.Month - dateB.Month);
      if (months == 0)
      {
        num = months;
      }
      else
      {
        DateTime dateTime = dateB.AddMonths(months);
        num = (dateA - dateTime).Ticks < 0L ? months - 1 : months;
      }
    }
    else
      num = -DateTimeHelper.MonthsDifference(dateB, dateA);
    return num;
  }
}
