// Decompiled with JetBrains decompiler
// Type: buClass.CounterResetAllEventHandler
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace buClass;

public delegate void CounterResetAllEventHandler(DateTime ResetTime, List<CounterItem> Counters);
