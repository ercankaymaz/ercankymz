// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pkix.PkixCrlUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.X509.Store;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Pkix;

public class PkixCrlUtilities
{
  public virtual ISet<X509Crl> FindCrls(X509CrlStoreSelector crlSelector, PkixParameters paramsPkix)
  {
    try
    {
      return (ISet<X509Crl>) this.FindCrls((ISelector<X509Crl>) crlSelector, (IEnumerable<IStore<X509Crl>>) paramsPkix.GetStoresCrl());
    }
    catch (Exception ex)
    {
      throw new Exception("Exception obtaining complete CRLs.", ex);
    }
  }

  public virtual ISet<X509Crl> FindCrls(
    X509CrlStoreSelector crlSelector,
    PkixParameters paramsPkix,
    DateTime currentDate)
  {
    ISet<X509Crl> crls1 = this.FindCrls(crlSelector, paramsPkix);
    HashSet<X509Crl> crls2 = new HashSet<X509Crl>();
    DateTime dateTime = currentDate;
    if (paramsPkix.Date.HasValue)
      dateTime = paramsPkix.Date.Value;
    X509Certificate certificateChecking = crlSelector.CertificateChecking;
    foreach (X509Crl x509Crl in (IEnumerable<X509Crl>) crls1)
    {
      DateTime? nextUpdate = x509Crl.NextUpdate;
      DateTime thisUpdate;
      if (nextUpdate.HasValue)
      {
        thisUpdate = nextUpdate.Value;
        if (thisUpdate.CompareTo(dateTime) <= 0)
          continue;
      }
      if (certificateChecking != null)
      {
        thisUpdate = x509Crl.ThisUpdate;
        if (thisUpdate.CompareTo(certificateChecking.NotAfter) >= 0)
          continue;
      }
      crls2.Add(x509Crl);
    }
    return (ISet<X509Crl>) crls2;
  }

  private HashSet<X509Crl> FindCrls(
    ISelector<X509Crl> crlSelector,
    IEnumerable<IStore<X509Crl>> crlStores)
  {
    HashSet<X509Crl> crls = new HashSet<X509Crl>();
    Exception exception = (Exception) null;
    bool flag = false;
    foreach (IStore<X509Crl> crlStore in crlStores)
    {
      try
      {
        crls.UnionWith(crlStore.EnumerateMatches(crlSelector));
        flag = true;
      }
      catch (Exception ex)
      {
        exception = new Exception("Exception searching in X.509 CRL store.", ex);
      }
    }
    if (!flag && exception != null)
      throw exception;
    return crls;
  }
}
