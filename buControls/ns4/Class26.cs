// Decompiled with JetBrains decompiler
// Type: ns4.Class26
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns5;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace ns4;

internal sealed class Class26 : CustomTypeDescriptor
{
  private ICustomTypeDescriptor icustomTypeDescriptor_0;
  private object object_0;

  public Class26(ICustomTypeDescriptor icustomTypeDescriptor_1, object object_1)
    : base(icustomTypeDescriptor_1)
  {
    this.icustomTypeDescriptor_0 = icustomTypeDescriptor_1;
    this.object_0 = object_1;
  }

  virtual string CustomTypeDescriptor.GetComponentName()
  {
    return !(this.object_0 is Control object0) ? (string) null : object0.Name;
  }

  virtual EventDescriptorCollection CustomTypeDescriptor.GetEvents()
  {
    // ISSUE: explicit non-virtual call
    EventDescriptorCollection events1 = __nonvirtual (((CustomTypeDescriptor) this).GetEvents());
    EventDescriptor[] events2 = new EventDescriptor[events1.Count];
    for (int index = 0; index < events1.Count; ++index)
      events2[index] = !(events1[index].Name == "TextChanged") ? events1[index] : (EventDescriptor) new Class27((MemberDescriptor) events1[index]);
    return new EventDescriptorCollection(events2);
  }
}
