// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pkix.PkixCertPathChecker
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.X509;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Pkix;

public abstract class PkixCertPathChecker
{
  public abstract void Init(bool forward);

  public abstract bool IsForwardCheckingSupported();

  public abstract ISet<string> GetSupportedExtensions();

  public abstract void Check(X509Certificate cert, ISet<string> unresolvedCritExts);

  public virtual object Clone() => this.MemberwiseClone();
}
