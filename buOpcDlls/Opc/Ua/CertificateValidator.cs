// Decompiled with JetBrains decompiler
// Type: Opc.Ua.CertificateValidator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Microsoft.Extensions.Logging;
using Opc.Ua.Security.Certificates;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class CertificateValidator : ICertificateValidator
{
  private static readonly ReadOnlyList<StatusCode> m_suppressibleStatusCodes = new ReadOnlyList<StatusCode>((IList<StatusCode>) new List<StatusCode>()
  {
    (StatusCode) 2148925440U /*0x80160000*/,
    (StatusCode) 2149318656U /*0x801C0000*/,
    (StatusCode) 2165112832U /*0x810D0000*/,
    (StatusCode) 2148859904U /*0x80150000*/,
    (StatusCode) 2149122048U /*0x80190000*/,
    (StatusCode) 2149253120U /*0x801B0000*/,
    (StatusCode) 2148794368U /*0x80140000*/,
    (StatusCode) 2165571584U,
    (StatusCode) 2149056512U /*0x80180000*/,
    (StatusCode) 2149187584U /*0x801A0000*/
  });
  private readonly SemaphoreSlim m_semaphore = new SemaphoreSlim(1, 1);
  private readonly object m_callbackLock = new object();
  private readonly Dictionary<string, X509Certificate2> m_validatedCertificates;
  private CertificateStoreIdentifier m_trustedCertificateStore;
  private CertificateIdentifierCollection m_trustedCertificateList;
  private CertificateStoreIdentifier m_issuerCertificateStore;
  private CertificateIdentifierCollection m_issuerCertificateList;
  private CertificateStoreIdentifier m_rejectedCertificateStore;
  private X509Certificate2 m_applicationCertificate;
  private CertificateValidator.ProtectFlags m_protectFlags;
  private bool m_autoAcceptUntrustedCertificates;
  private bool m_rejectSHA1SignedCertificates;
  private bool m_rejectUnknownRevocationStatus;
  private ushort m_minimumCertificateKeySize;
  private bool m_useValidatedCertificates;

  public CertificateValidator()
  {
    this.m_validatedCertificates = new Dictionary<string, X509Certificate2>();
    this.m_protectFlags = (CertificateValidator.ProtectFlags) 0;
    this.m_autoAcceptUntrustedCertificates = false;
    this.m_rejectSHA1SignedCertificates = CertificateFactory.DefaultHashSize >= (ushort) 256 /*0x0100*/;
    this.m_rejectUnknownRevocationStatus = false;
    this.m_minimumCertificateKeySize = CertificateFactory.DefaultKeySize;
    this.m_useValidatedCertificates = false;
  }

  public event CertificateValidationEventHandler CertificateValidation
  {
    add
    {
      lock (this.m_callbackLock)
        this.m_CertificateValidation += value;
    }
    remove
    {
      lock (this.m_callbackLock)
        this.m_CertificateValidation -= value;
    }
  }

  public event CertificateUpdateEventHandler CertificateUpdate
  {
    add
    {
      lock (this.m_callbackLock)
        this.m_CertificateUpdate += value;
    }
    remove
    {
      lock (this.m_callbackLock)
        this.m_CertificateUpdate -= value;
    }
  }

  public virtual async Task Update(ApplicationConfiguration configuration)
  {
    if (configuration == null)
      throw new ArgumentNullException(nameof (configuration));
    await this.Update(configuration.SecurityConfiguration).ConfigureAwait(false);
  }

  public virtual void Update(
    CertificateTrustList issuerStore,
    CertificateTrustList trustedStore,
    CertificateStoreIdentifier rejectedCertificateStore)
  {
    try
    {
      this.m_semaphore.Wait();
      this.InternalUpdate(issuerStore, trustedStore, rejectedCertificateStore);
    }
    finally
    {
      this.m_semaphore.Release();
    }
  }

  private void InternalUpdate(
    CertificateTrustList issuerStore,
    CertificateTrustList trustedStore,
    CertificateStoreIdentifier rejectedCertificateStore)
  {
    this.InternalResetValidatedCertificates();
    this.m_trustedCertificateStore = (CertificateStoreIdentifier) null;
    this.m_trustedCertificateList = (CertificateIdentifierCollection) null;
    if (trustedStore != null)
    {
      this.m_trustedCertificateStore = new CertificateStoreIdentifier();
      this.m_trustedCertificateStore.StoreType = trustedStore.StoreType;
      this.m_trustedCertificateStore.StorePath = trustedStore.StorePath;
      this.m_trustedCertificateStore.ValidationOptions = trustedStore.ValidationOptions;
      if (trustedStore.TrustedCertificates != null)
      {
        this.m_trustedCertificateList = new CertificateIdentifierCollection();
        this.m_trustedCertificateList.AddRange((IEnumerable<CertificateIdentifier>) trustedStore.TrustedCertificates);
      }
    }
    this.m_issuerCertificateStore = (CertificateStoreIdentifier) null;
    this.m_issuerCertificateList = (CertificateIdentifierCollection) null;
    if (issuerStore != null)
    {
      this.m_issuerCertificateStore = new CertificateStoreIdentifier();
      this.m_issuerCertificateStore.StoreType = issuerStore.StoreType;
      this.m_issuerCertificateStore.StorePath = issuerStore.StorePath;
      this.m_issuerCertificateStore.ValidationOptions = issuerStore.ValidationOptions;
      if (issuerStore.TrustedCertificates != null)
      {
        this.m_issuerCertificateList = new CertificateIdentifierCollection();
        this.m_issuerCertificateList.AddRange((IEnumerable<CertificateIdentifier>) issuerStore.TrustedCertificates);
      }
    }
    this.m_rejectedCertificateStore = (CertificateStoreIdentifier) null;
    if (rejectedCertificateStore == null)
      return;
    this.m_rejectedCertificateStore = (CertificateStoreIdentifier) rejectedCertificateStore.MemberwiseClone();
  }

  public virtual async Task Update(SecurityConfiguration configuration)
  {
    if (configuration == null)
      throw new ArgumentNullException(nameof (configuration));
    try
    {
      await this.m_semaphore.WaitAsync().ConfigureAwait(false);
      this.InternalUpdate(configuration.TrustedIssuerCertificates, configuration.TrustedPeerCertificates, configuration.RejectedCertificateStore);
      if ((this.m_protectFlags & CertificateValidator.ProtectFlags.AutoAcceptUntrustedCertificates) == (CertificateValidator.ProtectFlags) 0)
        this.m_autoAcceptUntrustedCertificates = configuration.AutoAcceptUntrustedCertificates;
      if ((this.m_protectFlags & CertificateValidator.ProtectFlags.RejectSHA1SignedCertificates) == (CertificateValidator.ProtectFlags) 0)
        this.m_rejectSHA1SignedCertificates = configuration.RejectSHA1SignedCertificates;
      if ((this.m_protectFlags & CertificateValidator.ProtectFlags.RejectUnknownRevocationStatus) == (CertificateValidator.ProtectFlags) 0)
        this.m_rejectUnknownRevocationStatus = configuration.RejectUnknownRevocationStatus;
      if ((this.m_protectFlags & CertificateValidator.ProtectFlags.MinimumCertificateKeySize) == (CertificateValidator.ProtectFlags) 0)
        this.m_minimumCertificateKeySize = configuration.MinimumCertificateKeySize;
      if ((this.m_protectFlags & CertificateValidator.ProtectFlags.UseValidatedCertificates) == (CertificateValidator.ProtectFlags) 0)
        this.m_useValidatedCertificates = configuration.UseValidatedCertificates;
    }
    finally
    {
      this.m_semaphore.Release();
    }
    if (configuration.ApplicationCertificate == null)
      return;
    this.m_applicationCertificate = await configuration.ApplicationCertificate.Find(true).ConfigureAwait(false);
  }

  public virtual async Task UpdateCertificate(SecurityConfiguration securityConfiguration)
  {
    CertificateValidator sender = this;
    try
    {
      await sender.m_semaphore.WaitAsync().ConfigureAwait(false);
      securityConfiguration.ApplicationCertificate.Certificate = (X509Certificate2) null;
      X509Certificate2 x509Certificate2 = await securityConfiguration.ApplicationCertificate.LoadPrivateKeyEx(securityConfiguration.CertificatePasswordProvider).ConfigureAwait(false);
    }
    finally
    {
      sender.m_semaphore.Release();
    }
    await sender.Update(securityConfiguration).ConfigureAwait(false);
    lock (sender.m_callbackLock)
    {
      if (sender.m_CertificateUpdate == null)
        return;
      CertificateUpdateEventArgs e = new CertificateUpdateEventArgs(securityConfiguration, sender.GetChannelValidator());
      sender.m_CertificateUpdate(sender, e);
    }
  }

  public void ResetValidatedCertificates()
  {
    try
    {
      this.m_semaphore.Wait();
      this.InternalResetValidatedCertificates();
    }
    finally
    {
      this.m_semaphore.Release();
    }
  }

  private void InternalResetValidatedCertificates()
  {
    foreach (IDisposable disposable in this.m_validatedCertificates.Values)
      Utils.SilentDispose(disposable);
    this.m_validatedCertificates.Clear();
  }

  public bool AutoAcceptUntrustedCertificates
  {
    get => this.m_autoAcceptUntrustedCertificates;
    set
    {
      try
      {
        this.m_semaphore.Wait();
        this.m_protectFlags |= CertificateValidator.ProtectFlags.AutoAcceptUntrustedCertificates;
        if (this.m_autoAcceptUntrustedCertificates == value)
          return;
        this.m_autoAcceptUntrustedCertificates = value;
        this.InternalResetValidatedCertificates();
      }
      finally
      {
        this.m_semaphore.Release();
      }
    }
  }

  public bool RejectSHA1SignedCertificates
  {
    get => this.m_rejectSHA1SignedCertificates;
    set
    {
      try
      {
        this.m_semaphore.Wait();
        this.m_protectFlags |= CertificateValidator.ProtectFlags.RejectSHA1SignedCertificates;
        if (this.m_rejectSHA1SignedCertificates == value)
          return;
        this.m_rejectSHA1SignedCertificates = value;
        this.InternalResetValidatedCertificates();
      }
      finally
      {
        this.m_semaphore.Release();
      }
    }
  }

  public bool RejectUnknownRevocationStatus
  {
    get => this.m_rejectUnknownRevocationStatus;
    set
    {
      try
      {
        this.m_semaphore.Wait();
        this.m_protectFlags |= CertificateValidator.ProtectFlags.RejectUnknownRevocationStatus;
        if (this.m_rejectUnknownRevocationStatus == value)
          return;
        this.m_rejectUnknownRevocationStatus = value;
        this.InternalResetValidatedCertificates();
      }
      finally
      {
        this.m_semaphore.Release();
      }
    }
  }

  public ushort MinimumCertificateKeySize
  {
    get => this.m_minimumCertificateKeySize;
    set
    {
      try
      {
        this.m_semaphore.Wait();
        this.m_protectFlags |= CertificateValidator.ProtectFlags.MinimumCertificateKeySize;
        if ((int) this.m_minimumCertificateKeySize == (int) value)
          return;
        this.m_minimumCertificateKeySize = value;
        this.ResetValidatedCertificates();
      }
      finally
      {
        this.m_semaphore.Release();
      }
    }
  }

  public bool UseValidatedCertificates
  {
    get => this.m_useValidatedCertificates;
    set
    {
      try
      {
        this.m_semaphore.Wait();
        this.m_protectFlags |= CertificateValidator.ProtectFlags.UseValidatedCertificates;
        if (this.m_useValidatedCertificates == value)
          return;
        this.m_useValidatedCertificates = value;
        this.ResetValidatedCertificates();
      }
      finally
      {
        this.m_semaphore.Release();
      }
    }
  }

  public void Validate(X509Certificate2 certificate)
  {
    this.Validate(new X509Certificate2Collection()
    {
      certificate
    });
  }

  public virtual void Validate(X509Certificate2Collection certificateChain)
  {
    this.Validate(certificateChain, (ConfiguredEndpoint) null);
  }

  public Task ValidateAsync(X509Certificate2 certificate, CancellationToken ct)
  {
    return this.ValidateAsync(new X509Certificate2Collection()
    {
      certificate
    }, ct);
  }

  public virtual Task ValidateAsync(X509Certificate2Collection chain, CancellationToken ct)
  {
    return this.ValidateAsync(chain, (ConfiguredEndpoint) null, ct);
  }

  public virtual async Task ValidateAsync(
    X509Certificate2Collection chain,
    ConfiguredEndpoint endpoint,
    CancellationToken ct)
  {
    X509Certificate2 certificate = chain[0];
    try
    {
      ConfiguredTaskAwaitable configuredTaskAwaitable = this.m_semaphore.WaitAsync(ct).ConfigureAwait(false);
      await configuredTaskAwaitable;
      try
      {
        configuredTaskAwaitable = this.InternalValidateAsync(chain, endpoint, ct).ConfigureAwait(false);
        await configuredTaskAwaitable;
        this.m_validatedCertificates[certificate.Thumbprint] = new X509Certificate2(certificate.RawData);
        certificate = (X509Certificate2) null;
        return;
      }
      finally
      {
        this.m_semaphore.Release();
      }
    }
    catch (ServiceResultException ex)
    {
      this.HandleCertificateValidationException(ex, certificate, chain);
    }
    await this.m_semaphore.WaitAsync(ct).ConfigureAwait(false);
    try
    {
      Utils.LogCertificate(Microsoft.Extensions.Logging.LogLevel.Warning, "Validation errors suppressed: ", certificate);
      this.m_validatedCertificates[certificate.Thumbprint] = new X509Certificate2(certificate.RawData);
      certificate = (X509Certificate2) null;
    }
    finally
    {
      this.m_semaphore.Release();
    }
  }

  public virtual void Validate(X509Certificate2Collection chain, ConfiguredEndpoint endpoint)
  {
    X509Certificate2 certificate = chain[0];
    try
    {
      try
      {
        this.m_semaphore.Wait();
        this.InternalValidateAsync(chain, endpoint).GetAwaiter().GetResult();
        this.m_validatedCertificates[certificate.Thumbprint] = new X509Certificate2(certificate.RawData);
        return;
      }
      finally
      {
        this.m_semaphore.Release();
      }
    }
    catch (ServiceResultException ex)
    {
      this.HandleCertificateValidationException(ex, certificate, chain);
    }
    try
    {
      this.m_semaphore.Wait();
      Utils.LogCertificate(Microsoft.Extensions.Logging.LogLevel.Warning, "Validation errors suppressed: ", certificate);
      this.m_validatedCertificates[certificate.Thumbprint] = new X509Certificate2(certificate.RawData);
    }
    finally
    {
      this.m_semaphore.Release();
    }
  }

  private void HandleCertificateValidationException(
    ServiceResultException se,
    X509Certificate2 certificate,
    X509Certificate2Collection chain)
  {
    if (CertificateValidator.ContainsUnsuppressibleSC(se.Result))
    {
      Utils.LogCertificate(Microsoft.Extensions.Logging.LogLevel.Error, "Certificate rejected. Reason={0}.", certificate, (object) se.Result.StatusCode);
      this.SaveCertificates(chain);
      CertificateValidator.LogInnerServiceResults(Microsoft.Extensions.Logging.LogLevel.Error, se.Result.InnerResult);
      throw new ServiceResultException((Exception) se, 2148663296U /*0x80120000*/);
    }
    Utils.LogCertificate(Microsoft.Extensions.Logging.LogLevel.Warning, "Certificate Validation failed. Reason={0}.", certificate, (object) se.Result.StatusCode);
    CertificateValidator.LogInnerServiceResults(Microsoft.Extensions.Logging.LogLevel.Warning, se.Result.InnerResult);
    bool flag = false;
    string message = string.Empty;
    ServiceResult serviceResult = se.Result;
    lock (this.m_callbackLock)
    {
      do
      {
        flag = false;
        if (this.m_CertificateValidation == null)
        {
          if (this.m_autoAcceptUntrustedCertificates && serviceResult.StatusCode == 2149187584U /*0x801A0000*/)
          {
            flag = true;
            Utils.LogCertificate("Auto accepted certificate: ", certificate);
          }
        }
        else
          goto label_11;
label_6:
        if (flag)
          serviceResult = serviceResult.InnerResult;
        else
          se = !string.IsNullOrEmpty(message) ? new ServiceResultException(message) : new ServiceResultException(serviceResult);
        if (flag)
          continue;
        break;
label_11:
        CertificateValidationEventArgs e = new CertificateValidationEventArgs(serviceResult, certificate);
        this.m_CertificateValidation(this, e);
        if (!e.AcceptAll)
        {
          message = e.ApplicationErrorMsg;
          flag = e.Accept;
          goto label_6;
        }
        goto label_14;
      }
      while (serviceResult != null);
      goto label_19;
label_14:
      flag = true;
      serviceResult = (ServiceResult) null;
    }
label_19:
    if (!flag)
    {
      Utils.LogCertificate(Microsoft.Extensions.Logging.LogLevel.Error, "Certificate rejected. Reason={0}.", certificate, serviceResult != null ? (object) serviceResult.StatusCode.ToString() : (object) "Unknown Error");
      this.SaveCertificates(chain);
      throw new ServiceResultException((Exception) se, 2148663296U /*0x80120000*/);
    }
  }

  private static bool ContainsUnsuppressibleSC(ServiceResult sr)
  {
    for (; sr != null; sr = sr.InnerResult)
    {
      if (!CertificateValidator.m_suppressibleStatusCodes.Contains(sr.StatusCode))
        return true;
    }
    return false;
  }

  private static void LogInnerServiceResults(Microsoft.Extensions.Logging.LogLevel logLevel, ServiceResult result)
  {
    for (; result != null; result = result.InnerResult)
      Utils.Log(logLevel, (EventId) 512 /*0x0200*/, " -- {0}", (object) result.ToString());
  }

  private void SaveCertificate(X509Certificate2 certificate)
  {
    this.SaveCertificates(new X509Certificate2Collection()
    {
      certificate
    });
  }

  private void SaveCertificates(X509Certificate2Collection certificateChain)
  {
    try
    {
      this.m_semaphore.Wait();
      if (this.m_rejectedCertificateStore == null)
        return;
      Utils.LogTrace("Writing rejected certificate chain to: {0}", (object) this.m_rejectedCertificateStore);
      try
      {
        ICertificateStore certificateStore = this.m_rejectedCertificateStore.OpenStore();
        try
        {
          bool flag = true;
          X509Certificate2Enumerator enumerator = certificateChain.GetEnumerator();
          while (enumerator.MoveNext())
          {
            X509Certificate2 current = enumerator.Current;
            try
            {
              certificateStore.Add(current).GetAwaiter().GetResult();
              if (!flag)
                Utils.LogCertificate("Saved issuer certificate: ", current);
              flag = false;
            }
            catch (ArgumentException ex)
            {
              Utils.LogCertificate(ex.Message, current);
            }
          }
        }
        finally
        {
          certificateStore.Close();
        }
      }
      catch (Exception ex)
      {
        object[] objArray = new object[1]
        {
          (object) this.m_rejectedCertificateStore
        };
        Utils.LogError(ex, "Could not write certificate to directory: {0}", objArray);
      }
    }
    finally
    {
      this.m_semaphore.Release();
    }
  }

  private async Task<CertificateIdentifier> GetTrustedCertificateAsync(X509Certificate2 certificate)
  {
    if (this.m_trustedCertificateList != null)
    {
      for (int ii = 0; ii < this.m_trustedCertificateList.Count; ++ii)
      {
        X509Certificate2 x509Certificate2 = await this.m_trustedCertificateList[ii].Find(false).ConfigureAwait(false);
        if (x509Certificate2 != null && x509Certificate2.Thumbprint == certificate.Thumbprint && Utils.IsEqual((object) x509Certificate2.RawData, (object) certificate.RawData))
          return this.m_trustedCertificateList[ii];
      }
    }
    if (this.m_trustedCertificateStore != null)
    {
      ICertificateStore store = this.m_trustedCertificateStore.OpenStore();
      try
      {
        X509Certificate2Collection certificate2Collection = await store.FindByThumbprint(certificate.Thumbprint).ConfigureAwait(false);
        for (int index = 0; index < certificate2Collection.Count; ++index)
        {
          if (Utils.IsEqual((object) certificate2Collection[index].RawData, (object) certificate.RawData))
            return new CertificateIdentifier(certificate2Collection[index], this.m_trustedCertificateStore.ValidationOptions);
        }
      }
      finally
      {
        store.Close();
      }
      store = (ICertificateStore) null;
    }
    return (CertificateIdentifier) null;
  }

  private bool Match(
    X509Certificate2 certificate,
    X500DistinguishedName subjectName,
    string serialNumber,
    string authorityKeyId)
  {
    bool flag = false;
    if (certificate == null || !X509Utils.CompareDistinguishedName(certificate.SubjectName, subjectName))
      return false;
    if (!string.IsNullOrEmpty(serialNumber))
    {
      if (certificate.SerialNumber != serialNumber)
        return false;
      flag = true;
    }
    if (!string.IsNullOrEmpty(authorityKeyId))
    {
      X509SubjectKeyIdentifierExtension extension = certificate.FindExtension<X509SubjectKeyIdentifierExtension>();
      if (extension != null)
      {
        if (extension.SubjectKeyIdentifier != authorityKeyId)
          return false;
        flag = true;
      }
    }
    return flag;
  }

  public async Task<bool> GetIssuersNoExceptionsOnGetIssuer(
    X509Certificate2Collection certificates,
    List<CertificateIdentifier> issuers,
    Dictionary<X509Certificate2, ServiceResultException> validationErrors)
  {
    bool isTrusted = false;
    CertificateIdentifier issuer = (CertificateIdentifier) null;
    ServiceResultException revocationStatus = (ServiceResultException) null;
    X509Certificate2 certificate = certificates[0];
    CertificateIdentifierCollection untrustedCollection = new CertificateIdentifierCollection();
    for (int index = 1; index < certificates.Count; ++index)
      untrustedCollection.Add(new CertificateIdentifier(certificates[index]));
    while (!X509Utils.IsSelfSigned(certificate))
    {
      ConfiguredTaskAwaitable<(CertificateIdentifier, ServiceResultException)>.ConfiguredTaskAwaiter configuredTaskAwaiter1;
      ConfiguredTaskAwaitable<CertificateIdentifier>.ConfiguredTaskAwaiter configuredTaskAwaiter2;
      ConfiguredTaskAwaitable<(CertificateIdentifier, ServiceResultException)>.ConfiguredTaskAwaiter awaiter1;
      int num;
      ConfiguredTaskAwaitable<CertificateIdentifier>.ConfiguredTaskAwaiter awaiter2;
      if (validationErrors != null)
      {
        awaiter1 = this.GetIssuerNoExceptionAsync(certificate, this.m_trustedCertificateList, this.m_trustedCertificateStore, true).ConfigureAwait(false).GetAwaiter();
        if (awaiter1.IsCompleted)
        {
          (issuer, revocationStatus) = awaiter1.GetResult();
        }
        else
        {
          num = 0;
          // ISSUE: explicit reference operation
          // ISSUE: reference to a compiler-generated field
          (^this).\u003C\u003E1__state = 0;
          configuredTaskAwaiter1 = awaiter1;
          // ISSUE: explicit reference operation
          // ISSUE: reference to a compiler-generated field
          (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<(CertificateIdentifier, ServiceResultException)>.ConfiguredTaskAwaiter, CertificateValidator.\u003CGetIssuersNoExceptionsOnGetIssuer\u003Ed__42>(ref awaiter1, this);
          return;
        }
      }
      else
      {
        awaiter2 = this.GetIssuer(certificate, this.m_trustedCertificateList, this.m_trustedCertificateStore, true).ConfigureAwait(false).GetAwaiter();
        if (awaiter2.IsCompleted)
        {
          issuer = awaiter2.GetResult();
        }
        else
        {
          num = 1;
          // ISSUE: explicit reference operation
          // ISSUE: reference to a compiler-generated field
          (^this).\u003C\u003E1__state = 1;
          configuredTaskAwaiter2 = awaiter2;
          // ISSUE: explicit reference operation
          // ISSUE: reference to a compiler-generated field
          (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<CertificateIdentifier>.ConfiguredTaskAwaiter, CertificateValidator.\u003CGetIssuersNoExceptionsOnGetIssuer\u003Ed__42>(ref awaiter2, this);
          return;
        }
      }
      if (issuer == null)
      {
        if (validationErrors != null)
        {
          awaiter1 = this.GetIssuerNoExceptionAsync(certificate, this.m_issuerCertificateList, this.m_issuerCertificateStore, true).ConfigureAwait(false).GetAwaiter();
          if (awaiter1.IsCompleted)
          {
            (issuer, revocationStatus) = awaiter1.GetResult();
          }
          else
          {
            num = 2;
            // ISSUE: explicit reference operation
            // ISSUE: reference to a compiler-generated field
            (^this).\u003C\u003E1__state = 2;
            configuredTaskAwaiter1 = awaiter1;
            // ISSUE: explicit reference operation
            // ISSUE: reference to a compiler-generated field
            (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<(CertificateIdentifier, ServiceResultException)>.ConfiguredTaskAwaiter, CertificateValidator.\u003CGetIssuersNoExceptionsOnGetIssuer\u003Ed__42>(ref awaiter1, this);
            return;
          }
        }
        else
        {
          awaiter2 = this.GetIssuer(certificate, this.m_issuerCertificateList, this.m_issuerCertificateStore, true).ConfigureAwait(false).GetAwaiter();
          if (awaiter2.IsCompleted)
          {
            issuer = awaiter2.GetResult();
          }
          else
          {
            num = 3;
            // ISSUE: explicit reference operation
            // ISSUE: reference to a compiler-generated field
            (^this).\u003C\u003E1__state = 3;
            configuredTaskAwaiter2 = awaiter2;
            // ISSUE: explicit reference operation
            // ISSUE: reference to a compiler-generated field
            (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<CertificateIdentifier>.ConfiguredTaskAwaiter, CertificateValidator.\u003CGetIssuersNoExceptionsOnGetIssuer\u003Ed__42>(ref awaiter2, this);
            return;
          }
        }
        if (issuer == null)
        {
          if (validationErrors != null)
          {
            awaiter1 = this.GetIssuerNoExceptionAsync(certificate, untrustedCollection, (CertificateStoreIdentifier) null, true).ConfigureAwait(false).GetAwaiter();
            if (awaiter1.IsCompleted)
            {
              (issuer, revocationStatus) = awaiter1.GetResult();
            }
            else
            {
              num = 4;
              // ISSUE: explicit reference operation
              // ISSUE: reference to a compiler-generated field
              (^this).\u003C\u003E1__state = 4;
              configuredTaskAwaiter1 = awaiter1;
              // ISSUE: explicit reference operation
              // ISSUE: reference to a compiler-generated field
              (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<(CertificateIdentifier, ServiceResultException)>.ConfiguredTaskAwaiter, CertificateValidator.\u003CGetIssuersNoExceptionsOnGetIssuer\u003Ed__42>(ref awaiter1, this);
              return;
            }
          }
          else
          {
            awaiter2 = this.GetIssuer(certificate, untrustedCollection, (CertificateStoreIdentifier) null, true).ConfigureAwait(false).GetAwaiter();
            if (awaiter2.IsCompleted)
            {
              issuer = awaiter2.GetResult();
            }
            else
            {
              num = 5;
              // ISSUE: explicit reference operation
              // ISSUE: reference to a compiler-generated field
              (^this).\u003C\u003E1__state = 5;
              configuredTaskAwaiter2 = awaiter2;
              // ISSUE: explicit reference operation
              // ISSUE: reference to a compiler-generated field
              (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<CertificateIdentifier>.ConfiguredTaskAwaiter, CertificateValidator.\u003CGetIssuersNoExceptionsOnGetIssuer\u003Ed__42>(ref awaiter2, this);
              return;
            }
          }
        }
      }
      else
        isTrusted = true;
      if (issuer != null)
        goto label_24;
label_23:
      if (issuer != null)
        continue;
      break;
label_24:
      if (validationErrors != null)
        validationErrors[certificate] = revocationStatus;
      if (issuers.Find((Predicate<CertificateIdentifier>) (iss => string.Equals(iss.Thumbprint, issuer.Thumbprint, StringComparison.OrdinalIgnoreCase))) == null)
      {
        issuers.Add(issuer);
        ConfiguredTaskAwaitable<X509Certificate2>.ConfiguredTaskAwaiter awaiter3 = issuer.Find(false).ConfigureAwait(false).GetAwaiter();
        if (awaiter3.IsCompleted)
        {
          certificate = awaiter3.GetResult();
          goto label_23;
        }
        num = 6;
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003E1__state = 6;
        ConfiguredTaskAwaitable<X509Certificate2>.ConfiguredTaskAwaiter configuredTaskAwaiter3 = awaiter3;
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<X509Certificate2>.ConfiguredTaskAwaiter, CertificateValidator.\u003CGetIssuersNoExceptionsOnGetIssuer\u003Ed__42>(ref awaiter3, this);
        return;
      }
      break;
    }
    bool exceptionsOnGetIssuer = isTrusted;
    revocationStatus = (ServiceResultException) null;
    certificate = (X509Certificate2) null;
    untrustedCollection = (CertificateIdentifierCollection) null;
    return exceptionsOnGetIssuer;
  }

  public Task<bool> GetIssuers(
    X509Certificate2Collection certificates,
    List<CertificateIdentifier> issuers)
  {
    return this.GetIssuersNoExceptionsOnGetIssuer(certificates, issuers, (Dictionary<X509Certificate2, ServiceResultException>) null);
  }

  public Task<bool> GetIssuers(X509Certificate2 certificate, List<CertificateIdentifier> issuers)
  {
    return this.GetIssuers(new X509Certificate2Collection()
    {
      certificate
    }, issuers);
  }

  private async Task<(CertificateIdentifier, ServiceResultException)> GetIssuerNoExceptionAsync(
    X509Certificate2 certificate,
    CertificateIdentifierCollection explicitList,
    CertificateStoreIdentifier certificateStore,
    bool checkRecovationStatus)
  {
    ServiceResultException serviceResult = (ServiceResultException) null;
    X500DistinguishedName subjectName = certificate.IssuerName;
    string keyId = (string) null;
    string serialNumber = (string) null;
    X509AuthorityKeyIdentifierExtension extension = certificate.FindExtension<X509AuthorityKeyIdentifierExtension>();
    if (extension != null)
    {
      keyId = extension.KeyIdentifier;
      serialNumber = extension.SerialNumber;
    }
    if (explicitList != null)
    {
      for (int ii = 0; ii < explicitList.Count; ++ii)
      {
        X509Certificate2 certificate1 = await explicitList[ii].Find(false).ConfigureAwait(false);
        if (certificate1 != null && X509Utils.IsIssuerAllowed(certificate1) && this.Match(certificate1, subjectName, serialNumber, keyId))
          return (new CertificateIdentifier(certificate1, CertificateValidationOptions.SuppressRevocationStatusUnknown), (ServiceResultException) null);
      }
    }
    if (certificateStore != null)
    {
      ICertificateStore store = certificateStore.OpenStore();
      try
      {
        X509Certificate2Collection certificate2Collection = await store.Enumerate().ConfigureAwait(false);
        for (int index = 0; index < certificate2Collection.Count; ++index)
        {
          X509Certificate2 issuer = certificate2Collection[index];
          if (issuer != null)
          {
            if (X509Utils.IsIssuerAllowed(issuer))
            {
              if (this.Match(issuer, subjectName, serialNumber, keyId))
              {
                CertificateValidationOptions options = certificateStore.ValidationOptions;
                if (checkRecovationStatus)
                {
                  StatusCode statusCode = await store.IsRevoked(issuer, certificate).ConfigureAwait(false);
                  if (StatusCode.IsBad(statusCode) && statusCode != 2151481344U /*0x803D0000*/)
                  {
                    if (statusCode == 2149253120U /*0x801B0000*/)
                    {
                      if (X509Utils.IsCertificateAuthority(certificate))
                        statusCode.Code = 2149318656U /*0x801C0000*/;
                      if (this.m_rejectUnknownRevocationStatus && (options & CertificateValidationOptions.SuppressRevocationStatusUnknown) == CertificateValidationOptions.Default)
                        serviceResult = new ServiceResultException((ServiceResult) statusCode);
                    }
                    else
                    {
                      if (statusCode == 2149384192U /*0x801D0000*/ && X509Utils.IsCertificateAuthority(certificate))
                        statusCode.Code = 2149449728U /*0x801E0000*/;
                      serviceResult = new ServiceResultException((ServiceResult) statusCode);
                    }
                  }
                }
                options |= CertificateValidationOptions.SuppressRevocationStatusUnknown;
                return (new CertificateIdentifier(issuer, options), serviceResult);
              }
            }
            else
              continue;
          }
          issuer = (X509Certificate2) null;
        }
      }
      finally
      {
        store.Close();
      }
      store = (ICertificateStore) null;
    }
    return ((CertificateIdentifier) null, (ServiceResultException) null);
  }

  private async Task<CertificateIdentifier> GetIssuer(
    X509Certificate2 certificate,
    CertificateIdentifierCollection explicitList,
    CertificateStoreIdentifier certificateStore,
    bool checkRecovationStatus)
  {
    if (X509Utils.IsSelfSigned(certificate))
      return (CertificateIdentifier) null;
    (CertificateIdentifier issuer, ServiceResultException serviceResultException) = await this.GetIssuerNoExceptionAsync(certificate, explicitList, certificateStore, checkRecovationStatus).ConfigureAwait(false);
    if (serviceResultException != null)
      throw serviceResultException;
    return issuer;
  }

  protected virtual async Task InternalValidateAsync(
    X509Certificate2Collection certificates,
    ConfiguredEndpoint endpoint,
    CancellationToken ct = default (CancellationToken))
  {
    X509Certificate2 certificate = certificates[0];
    X509Certificate2 x509Certificate2 = (X509Certificate2) null;
    CertificateIdentifier trustedCertificate;
    List<CertificateIdentifier> issuers;
    Dictionary<X509Certificate2, ServiceResultException> validationErrors;
    if (this.m_useValidatedCertificates && this.m_validatedCertificates.TryGetValue(certificate.Thumbprint, out x509Certificate2) && Utils.IsEqual((object) x509Certificate2.RawData, (object) certificate.RawData))
    {
      certificate = (X509Certificate2) null;
      trustedCertificate = (CertificateIdentifier) null;
      issuers = (List<CertificateIdentifier>) null;
      validationErrors = (Dictionary<X509Certificate2, ServiceResultException>) null;
    }
    else
    {
      trustedCertificate = await this.GetTrustedCertificateAsync(certificate).ConfigureAwait(false);
      issuers = new List<CertificateIdentifier>();
      validationErrors = new Dictionary<X509Certificate2, ServiceResultException>();
      bool flag1 = await this.GetIssuersNoExceptionsOnGetIssuer(certificates, issuers, validationErrors).ConfigureAwait(false);
      ServiceResult serviceResult1 = this.PopulateSresultWithValidationErrors(validationErrors);
      X509ChainPolicy x509ChainPolicy = new X509ChainPolicy()
      {
        RevocationFlag = X509RevocationFlag.EntireChain,
        RevocationMode = X509RevocationMode.NoCheck,
        VerificationFlags = X509VerificationFlags.NoFlag,
        UrlRetrievalTimeout = TimeSpan.FromMilliseconds(1.0)
      };
      foreach (CertificateIdentifier certificateIdentifier in issuers)
      {
        if ((certificateIdentifier.ValidationOptions & CertificateValidationOptions.SuppressRevocationStatusUnknown) != CertificateValidationOptions.Default)
        {
          x509ChainPolicy.VerificationFlags |= X509VerificationFlags.IgnoreCertificateAuthorityRevocationUnknown;
          x509ChainPolicy.VerificationFlags |= X509VerificationFlags.IgnoreCtlSignerRevocationUnknown;
          x509ChainPolicy.VerificationFlags |= X509VerificationFlags.IgnoreEndRevocationUnknown;
          x509ChainPolicy.VerificationFlags |= X509VerificationFlags.IgnoreRootRevocationUnknown;
        }
        x509ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
        x509ChainPolicy.ExtraStore.Add(certificateIdentifier.Certificate);
      }
      bool flag2 = false;
      using (X509Chain x509Chain = new X509Chain())
      {
        x509Chain.ChainPolicy = x509ChainPolicy;
        x509Chain.Build(certificate);
        CertificateIdentifier id = trustedCertificate ?? new CertificateIdentifier(certificate);
        foreach (X509ChainStatus chainStatu in x509Chain.ChainStatus)
        {
          switch (chainStatu.Status)
          {
            case X509ChainStatusFlags.NoError:
            case X509ChainStatusFlags.NotTimeValid:
            case X509ChainStatusFlags.NotTimeNested:
            case X509ChainStatusFlags.Revoked:
            case X509ChainStatusFlags.NotValidForUsage:
            case X509ChainStatusFlags.UntrustedRoot:
            case X509ChainStatusFlags.RevocationStatusUnknown:
            case X509ChainStatusFlags.InvalidBasicConstraints:
            case X509ChainStatusFlags.OfflineRevocation:
              continue;
            case X509ChainStatusFlags.NotSignatureValid:
              serviceResult1 = new ServiceResult(ServiceResult.Create(2148663296U /*0x80120000*/, "Certificate validation failed. {0}: {1}", (object) chainStatu.Status, (object) chainStatu.StatusInformation), serviceResult1);
              continue;
            case X509ChainStatusFlags.PartialChain:
              flag2 = true;
              flag1 = false;
              continue;
            default:
              Utils.LogError("Unexpected status {0} processing certificate chain.", (object) chainStatu.Status);
              goto case X509ChainStatusFlags.NotSignatureValid;
          }
        }
        if (issuers.Count + 1 != x509Chain.ChainElements.Count)
        {
          flag2 = true;
          flag1 = false;
        }
        for (int index = 0; index < x509Chain.ChainElements.Count; ++index)
        {
          X509ChainElement chainElement = x509Chain.ChainElements[index];
          CertificateIdentifier issuer = (CertificateIdentifier) null;
          if (index < issuers.Count)
            issuer = issuers[index];
          if (index + 1 < x509Chain.ChainElements.Count)
          {
            X509Certificate2 certificate1 = x509Chain.ChainElements[index + 1].Certificate;
            if (issuer == null || !Utils.IsEqual((object) certificate1.RawData, (object) issuer.RawData))
            {
              Utils.LogCertificate((EventId) 512 /*0x0200*/, "An unexpected certificate was used in the certificate chain.", certificate1);
              flag2 = true;
              flag1 = false;
              break;
            }
          }
          if (chainElement.ChainElementStatus.Length != 0)
          {
            foreach (X509ChainStatus chainElementStatu in chainElement.ChainElementStatus)
            {
              ServiceResult serviceResult2 = CertificateValidator.CheckChainStatus(chainElementStatu, id, issuer, index != 0);
              if (ServiceResult.IsBad(serviceResult2))
                serviceResult1 = new ServiceResult(serviceResult2, serviceResult1);
            }
          }
          if (issuer != null)
            id = issuer;
        }
      }
      bool flag3 = !X509Utils.IsSelfSigned(certificate);
      if (issuers.Count > 0)
      {
        if (!X509Utils.IsSelfSigned(issuers[issuers.Count - 1].Certificate))
          flag2 = true;
      }
      else if (flag3)
        flag2 = true;
      if (flag3 && !flag1 && trustedCertificate == null)
        serviceResult1 = new ServiceResult((StatusCode) 2149187584U /*0x801A0000*/, (string) null, (string) null, (LocalizedText) "Certificate Issuer is not trusted.", (string) null, serviceResult1);
      if (trustedCertificate == null && !flag1 && (this.m_applicationCertificate == null || !Utils.IsEqual((object) this.m_applicationCertificate.RawData, (object) certificate.RawData)))
        serviceResult1 = new ServiceResult((StatusCode) 2149187584U /*0x801A0000*/, (string) null, (string) null, (LocalizedText) "Certificate is not trusted.", (string) null, serviceResult1);
      if (endpoint != null && !this.FindDomain(certificate, endpoint))
        serviceResult1 = new ServiceResult((StatusCode) 2148925440U /*0x80160000*/, (string) null, (string) null, (LocalizedText) Utils.Format("The domain '{0}' is not listed in the server certificate.", (object) endpoint.EndpointUrl.DnsSafeHost), (string) null, serviceResult1);
      if ((X509Utils.GetKeyUsage(certificate) & X509KeyUsageFlags.DataEncipherment) == X509KeyUsageFlags.None)
        serviceResult1 = new ServiceResult((StatusCode) 2149056512U /*0x80180000*/, (string) null, (string) null, (LocalizedText) "Usage of certificate is not allowed.", (string) null, serviceResult1);
      if (this.m_rejectSHA1SignedCertificates && CertificateValidator.IsSHA1SignatureAlgorithm(certificate.SignatureAlgorithm))
        serviceResult1 = new ServiceResult((StatusCode) 2165571584U, (string) null, (string) null, (LocalizedText) "SHA1 signed certificates are not trusted.", (string) null, serviceResult1);
      int rsaPublicKeySize = X509Utils.GetRSAPublicKeySize(certificate);
      if (rsaPublicKeySize < (int) this.m_minimumCertificateKeySize)
        serviceResult1 = new ServiceResult((StatusCode) 2165571584U, (string) null, (string) null, (LocalizedText) $"Certificate doesn't meet minimum key length requirement. ({rsaPublicKeySize}<{this.m_minimumCertificateKeySize})", (string) null, serviceResult1);
      if (flag3 & flag2)
        serviceResult1 = new ServiceResult((StatusCode) 2165112832U /*0x810D0000*/, (string) null, (string) null, (LocalizedText) "Certificate chain validation incomplete.", (string) null, serviceResult1);
      if (serviceResult1 != null)
        throw new ServiceResultException(serviceResult1);
      certificate = (X509Certificate2) null;
      trustedCertificate = (CertificateIdentifier) null;
      issuers = (List<CertificateIdentifier>) null;
      validationErrors = (Dictionary<X509Certificate2, ServiceResultException>) null;
    }
  }

  private ServiceResult PopulateSresultWithValidationErrors(
    Dictionary<X509Certificate2, ServiceResultException> validationErrors)
  {
    Dictionary<X509Certificate2, ServiceResultException> dictionary1 = new Dictionary<X509Certificate2, ServiceResultException>();
    Dictionary<X509Certificate2, ServiceResultException> dictionary2 = new Dictionary<X509Certificate2, ServiceResultException>();
    Dictionary<X509Certificate2, ServiceResultException> dictionary3 = new Dictionary<X509Certificate2, ServiceResultException>();
    ServiceResult innerResult = (ServiceResult) null;
    foreach (KeyValuePair<X509Certificate2, ServiceResultException> validationError in validationErrors)
    {
      if (validationError.Value != null)
      {
        if (validationError.Value.StatusCode == 2149384192U /*0x801D0000*/)
          dictionary1[validationError.Key] = validationError.Value;
        else if (validationError.Value.StatusCode == 2149449728U /*0x801E0000*/)
          dictionary2[validationError.Key] = validationError.Value;
        else if (validationError.Value.StatusCode == 2149253120U /*0x801B0000*/)
          dictionary3[validationError.Key] = validationError.Value;
        else if (validationError.Value.StatusCode == 2149318656U /*0x801C0000*/)
          innerResult = new ServiceResult((StatusCode) 2149318656U /*0x801C0000*/, (string) null, (string) null, (LocalizedText) this.CertificateMessage("Certificate issuer revocation list not found.", validationError.Key), (string) null, innerResult);
        else if (StatusCode.IsBad((StatusCode) validationError.Value.StatusCode))
        {
          string str = this.CertificateMessage("Unknown error while trying to determine the revocation status.", validationError.Key);
          innerResult = new ServiceResult((StatusCode) validationError.Value.StatusCode, (string) null, (string) null, (LocalizedText) str, (string) null, innerResult);
        }
      }
    }
    if (dictionary3.Count > 0)
    {
      foreach (KeyValuePair<X509Certificate2, ServiceResultException> keyValuePair in dictionary3)
        innerResult = new ServiceResult((StatusCode) 2149253120U /*0x801B0000*/, (string) null, (string) null, (LocalizedText) this.CertificateMessage("Certificate revocation list not found.", keyValuePair.Key), (string) null, innerResult);
    }
    if (dictionary2.Count > 0)
    {
      foreach (KeyValuePair<X509Certificate2, ServiceResultException> keyValuePair in dictionary2)
        innerResult = new ServiceResult((StatusCode) 2149449728U /*0x801E0000*/, (string) null, (string) null, (LocalizedText) this.CertificateMessage("Certificate issuer is revoked.", keyValuePair.Key), (string) null, innerResult);
    }
    if (dictionary1.Count > 0)
    {
      foreach (KeyValuePair<X509Certificate2, ServiceResultException> keyValuePair in dictionary1)
        innerResult = new ServiceResult((StatusCode) 2149384192U /*0x801D0000*/, (string) null, (string) null, (LocalizedText) this.CertificateMessage("Certificate is revoked.", keyValuePair.Key), (string) null, innerResult);
    }
    return innerResult;
  }

  public ICertificateValidator GetChannelValidator() => (ICertificateValidator) this;

  public void ValidateDomains(
    X509Certificate2 serverCertificate,
    ConfiguredEndpoint endpoint,
    bool serverValidation = false)
  {
    X509Certificate2 x509Certificate2;
    if (!serverValidation && this.m_useValidatedCertificates && this.m_validatedCertificates.TryGetValue(serverCertificate.Thumbprint, out x509Certificate2) && Utils.IsEqual((object) x509Certificate2.RawData, (object) serverCertificate.RawData) || this.FindDomain(serverCertificate, endpoint))
      return;
    bool flag = false;
    ServiceResultException serviceResultException = ServiceResultException.Create(2148925440U /*0x80160000*/, "The domain '{0}' is not listed in the server certificate.", (object) endpoint.EndpointUrl.DnsSafeHost);
    if (this.m_CertificateValidation != null)
    {
      CertificateValidationEventArgs e = new CertificateValidationEventArgs(new ServiceResult((Exception) serviceResultException), serverCertificate);
      this.m_CertificateValidation(this, e);
      flag = e.Accept || e.AcceptAll;
    }
    if (!flag)
    {
      if (serverValidation)
      {
        Utils.LogError("The domain '{0}' is not listed in the server certificate.", (object) endpoint.EndpointUrl.DnsSafeHost);
      }
      else
      {
        Utils.LogCertificate(Microsoft.Extensions.Logging.LogLevel.Error, "Certificate rejected. Reason={0}.", serverCertificate, serviceResultException != null ? (object) serviceResultException.ToString() : (object) "Unknown Error");
        this.SaveCertificate(serverCertificate);
      }
      throw serviceResultException;
    }
  }

  private static ServiceResult CheckChainStatus(
    X509ChainStatus status,
    CertificateIdentifier id,
    CertificateIdentifier issuer,
    bool isIssuer)
  {
    switch (status.Status)
    {
      case X509ChainStatusFlags.NoError:
      case X509ChainStatusFlags.InvalidBasicConstraints:
      case X509ChainStatusFlags.OfflineRevocation:
        return (ServiceResult) null;
      case X509ChainStatusFlags.NotTimeValid:
        if (id != null && (id.ValidationOptions & CertificateValidationOptions.SuppressCertificateExpired) != CertificateValidationOptions.Default)
        {
          Utils.LogWarning((EventId) 512 /*0x0200*/, "Error suppressed: {0}: {1}", (object) status.Status, (object) status.StatusInformation);
          goto case X509ChainStatusFlags.NoError;
        }
        return ServiceResult.Create((uint) (isIssuer ? -2146107392 /*0x80150000*/ : -2146172928 /*0x80140000*/), "Certificate has expired or is not yet valid. {0}: {1}", (object) status.Status, (object) status.StatusInformation);
      case X509ChainStatusFlags.NotTimeNested:
        if (id != null && (id.ValidationOptions & CertificateValidationOptions.SuppressCertificateExpired) != CertificateValidationOptions.Default)
        {
          Utils.LogWarning((EventId) 512 /*0x0200*/, "Error suppressed: {0}: {1}", (object) status.Status, (object) status.StatusInformation);
          goto case X509ChainStatusFlags.NoError;
        }
        return ServiceResult.Create(2148859904U /*0x80150000*/, "Issuer Certificate has expired or is not yet valid. {0}: {1}", (object) status.Status, (object) status.StatusInformation);
      case X509ChainStatusFlags.Revoked:
        return ServiceResult.Create((uint) (isIssuer ? -2145517568 /*0x801E0000*/ : -2145583104 /*0x801D0000*/), "Certificate has been revoked. {0}: {1}", (object) status.Status, (object) status.StatusInformation);
      case X509ChainStatusFlags.NotValidForUsage:
        return ServiceResult.Create((uint) (isIssuer ? -2145910784 /*0x80180000*/ : -2145845248 /*0x80190000*/), "Certificate may not be used as an application instance certificate. {0}: {1}", (object) status.Status, (object) status.StatusInformation);
      case X509ChainStatusFlags.UntrustedRoot:
      case X509ChainStatusFlags.PartialChain:
        if (issuer == null && id.Certificate != null && X509Utils.IsSelfSigned(id.Certificate))
        {
          if (CertificateValidator.IsSignatureValid(id.Certificate))
            goto case X509ChainStatusFlags.NoError;
          break;
        }
        return ServiceResult.Create(2165112832U /*0x810D0000*/, "Certificate chain validation failed. {0}: {1}", (object) status.Status, (object) status.StatusInformation);
      case X509ChainStatusFlags.RevocationStatusUnknown:
        if (issuer != null && (issuer.ValidationOptions & CertificateValidationOptions.SuppressRevocationStatusUnknown) != CertificateValidationOptions.Default)
        {
          Utils.LogWarning((EventId) 512 /*0x0200*/, "Error suppressed: {0}: {1}", (object) status.Status, (object) status.StatusInformation);
          goto case X509ChainStatusFlags.NoError;
        }
        if (id.Certificate == null || !X509Utils.IsSelfSigned(id.Certificate))
          return ServiceResult.Create((uint) (isIssuer ? -2145648640 /*0x801C0000*/ : -2145714176 /*0x801B0000*/), "Certificate revocation status cannot be verified. {0}: {1}", (object) status.Status, (object) status.StatusInformation);
        goto case X509ChainStatusFlags.NoError;
    }
    return ServiceResult.Create(2148663296U /*0x80120000*/, "Certificate validation failed. {0}: {1}", (object) status.Status, (object) status.StatusInformation);
  }

  private static bool IsSHA1SignatureAlgorithm(Oid oid)
  {
    return oid.Value == "1.3.14.3.2.29" || oid.Value == "1.2.840.10040.4.3" || oid.Value == "1.2.840.10045.4.1" || oid.Value == "1.2.840.113549.1.1.5" || oid.Value == "1.3.14.3.2.13" || oid.Value == "1.3.14.3.2.27";
  }

  private string CertificateMessage(string error, X509Certificate2 certificate)
  {
    StringBuilder stringBuilder = new StringBuilder().AppendLine(error).AppendFormat("Subject: {0}", (object) certificate.Subject).AppendLine();
    if (!string.Equals(certificate.Subject, certificate.Issuer, StringComparison.Ordinal))
      stringBuilder.AppendFormat("Issuer: {0}", (object) certificate.Issuer).AppendLine();
    return stringBuilder.ToString();
  }

  private static bool IsSignatureValid(X509Certificate2 cert) => X509Utils.VerifySelfSigned(cert);

  private bool FindDomain(X509Certificate2 serverCertificate, ConfiguredEndpoint endpoint)
  {
    bool domain = false;
    IList<string> domainsFromCertficate = X509Utils.GetDomainsFromCertficate(serverCertificate);
    if (domainsFromCertficate != null && domainsFromCertficate.Count > 0)
    {
      string a;
      string str = a = endpoint.EndpointUrl.DnsSafeHost;
      bool flag = false;
      if (endpoint.EndpointUrl.HostNameType == UriHostNameType.Dns)
      {
        if (string.Equals(str, "localhost", StringComparison.OrdinalIgnoreCase))
          flag = true;
        else
          a = str.Split('.')[0];
      }
      else
      {
        a = Utils.NormalizedIPAddress(str);
        if (a == "127.0.0.1" || a == "::1")
          flag = true;
      }
      if (flag)
      {
        str = Utils.GetFullQualifiedDomainName();
        a = Utils.GetHostName();
      }
      for (int index = 0; index < domainsFromCertficate.Count; ++index)
      {
        if (string.Equals(a, domainsFromCertficate[index], StringComparison.OrdinalIgnoreCase) || string.Equals(str, domainsFromCertficate[index], StringComparison.OrdinalIgnoreCase))
        {
          domain = true;
          break;
        }
      }
    }
    return domain;
  }

  private event CertificateValidationEventHandler m_CertificateValidation;

  private event CertificateUpdateEventHandler m_CertificateUpdate;

  [Flags]
  private enum ProtectFlags
  {
    AutoAcceptUntrustedCertificates = 1,
    RejectSHA1SignedCertificates = 2,
    RejectUnknownRevocationStatus = 4,
    MinimumCertificateKeySize = 8,
    UseValidatedCertificates = 16, // 0x00000010
  }
}
