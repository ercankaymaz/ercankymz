// Decompiled with JetBrains decompiler
// Type: ns3.Class25
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns4;
using ns7;
using System;
using System.ComponentModel;

#nullable disable
namespace ns3;

internal sealed class Class25(Type type_0) : TypeDescriptionProvider(Class39.smethod_821(type_0))
{
  virtual ICustomTypeDescriptor TypeDescriptionProvider.GetTypeDescriptor(
    Type objectType,
    object instance)
  {
    // ISSUE: explicit non-virtual call
    return (ICustomTypeDescriptor) new Class26(__nonvirtual (((TypeDescriptionProvider) this).GetTypeDescriptor(objectType, instance)), instance);
  }
}
