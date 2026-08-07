// Decompiled with JetBrains decompiler
// Type: ns5.Class27
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buMutliTextbox;
using System;
using System.ComponentModel;

#nullable disable
namespace ns5;

internal sealed class Class27(MemberDescriptor memberDescriptor_0) : EventDescriptor(memberDescriptor_0)
{
  virtual void EventDescriptor.AddEventHandler(object component, Delegate value)
  {
    (component as buMultiTextBox).method_0(value as EventHandler);
  }

  virtual Type EventDescriptor.ComponentType => typeof (buMultiTextBox);

  virtual Type EventDescriptor.EventType => typeof (EventHandler);

  virtual bool EventDescriptor.IsMulticast => true;

  virtual void EventDescriptor.RemoveEventHandler(object component, Delegate value)
  {
    (component as buMultiTextBox).method_1(value as EventHandler);
  }
}
