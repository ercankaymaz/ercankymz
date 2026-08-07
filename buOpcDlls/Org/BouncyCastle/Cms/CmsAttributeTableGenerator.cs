// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.CmsAttributeTableGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Cms;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Cms;

public interface CmsAttributeTableGenerator
{
  AttributeTable GetAttributes(
    IDictionary<CmsAttributeTableParameter, object> parameters);
}
