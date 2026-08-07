// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.CmsAuthenticatedGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Cms;

public class CmsAuthenticatedGenerator : CmsEnvelopedGenerator
{
  public CmsAuthenticatedGenerator()
  {
  }

  public CmsAuthenticatedGenerator(SecureRandom random)
    : base(random)
  {
  }
}
