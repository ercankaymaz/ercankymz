// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.PgpUserAttributeSubpacketVectorGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Bcpg.Attr;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

public class PgpUserAttributeSubpacketVectorGenerator
{
  private readonly List<UserAttributeSubpacket> list = new List<UserAttributeSubpacket>();

  public virtual void SetImageAttribute(ImageAttrib.Format imageType, byte[] imageData)
  {
    if (imageData == null)
      throw new ArgumentException("attempt to set null image", nameof (imageData));
    this.list.Add((UserAttributeSubpacket) new ImageAttrib(imageType, imageData));
  }

  public virtual PgpUserAttributeSubpacketVector Generate()
  {
    return new PgpUserAttributeSubpacketVector(this.list.ToArray());
  }
}
