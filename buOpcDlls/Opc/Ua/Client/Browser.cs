// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Client.Browser
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua.Client;

[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class Browser
{
  private ISession m_session;
  private ViewDescription m_view;
  private uint m_maxReferencesReturned;
  private BrowseDirection m_browseDirection;
  private NodeId m_referenceTypeId;
  private bool m_includeSubtypes;
  private uint m_nodeClassMask;
  private uint m_resultMask;
  private bool m_continueUntilDone;
  private bool m_browseInProgress;

  public Browser() => this.Initialize();

  public Browser(ISession session)
  {
    this.Initialize();
    this.m_session = session;
  }

  public Browser(Browser template)
  {
    this.Initialize();
    if (template == null)
      return;
    this.m_session = template.m_session;
    this.m_view = template.m_view;
    this.m_maxReferencesReturned = template.m_maxReferencesReturned;
    this.m_browseDirection = template.m_browseDirection;
    this.m_referenceTypeId = template.m_referenceTypeId;
    this.m_includeSubtypes = template.m_includeSubtypes;
    this.m_nodeClassMask = template.m_nodeClassMask;
    this.m_resultMask = template.m_resultMask;
    this.m_continueUntilDone = template.m_continueUntilDone;
  }

  private void Initialize()
  {
    this.m_session = (ISession) null;
    this.m_view = (ViewDescription) null;
    this.m_maxReferencesReturned = 0U;
    this.m_browseDirection = BrowseDirection.Forward;
    this.m_referenceTypeId = (NodeId) null;
    this.m_includeSubtypes = true;
    this.m_nodeClassMask = 0U;
    this.m_resultMask = 63U /*0x3F*/;
    this.m_continueUntilDone = false;
    this.m_browseInProgress = false;
  }

  public ISession Session
  {
    get => this.m_session;
    set
    {
      this.CheckBrowserState();
      this.m_session = value;
    }
  }

  [DataMember(Order = 1)]
  public ViewDescription View
  {
    get => this.m_view;
    set
    {
      this.CheckBrowserState();
      this.m_view = value;
    }
  }

  [DataMember(Order = 2)]
  public uint MaxReferencesReturned
  {
    get => this.m_maxReferencesReturned;
    set
    {
      this.CheckBrowserState();
      this.m_maxReferencesReturned = value;
    }
  }

  [DataMember(Order = 3)]
  public BrowseDirection BrowseDirection
  {
    get => this.m_browseDirection;
    set
    {
      this.CheckBrowserState();
      this.m_browseDirection = value;
    }
  }

  [DataMember(Order = 4)]
  public NodeId ReferenceTypeId
  {
    get => this.m_referenceTypeId;
    set
    {
      this.CheckBrowserState();
      this.m_referenceTypeId = value;
    }
  }

  [DataMember(Order = 5)]
  public bool IncludeSubtypes
  {
    get => this.m_includeSubtypes;
    set
    {
      this.CheckBrowserState();
      this.m_includeSubtypes = value;
    }
  }

  [DataMember(Order = 6)]
  public int NodeClassMask
  {
    get => Utils.ToInt32(this.m_nodeClassMask);
    set
    {
      this.CheckBrowserState();
      this.m_nodeClassMask = Utils.ToUInt32(value);
    }
  }

  [DataMember(Order = 6)]
  public uint ResultMask
  {
    get => this.m_resultMask;
    set
    {
      this.CheckBrowserState();
      this.m_resultMask = value;
    }
  }

  public event BrowserEventHandler MoreReferences
  {
    add => this.m_MoreReferences += value;
    remove => this.m_MoreReferences -= value;
  }

  public bool ContinueUntilDone
  {
    get => this.m_continueUntilDone;
    set
    {
      this.CheckBrowserState();
      this.m_continueUntilDone = value;
    }
  }

  public ReferenceDescriptionCollection Browse(NodeId nodeId)
  {
    if (this.m_session == null)
      throw new ServiceResultException(2148335616U /*0x800D0000*/, "Cannot browse if not connected to a server.");
    try
    {
      this.m_browseInProgress = true;
      BrowseDescription browseDescription = new BrowseDescription();
      browseDescription.NodeId = nodeId;
      browseDescription.BrowseDirection = this.m_browseDirection;
      browseDescription.ReferenceTypeId = this.m_referenceTypeId;
      browseDescription.IncludeSubtypes = this.m_includeSubtypes;
      browseDescription.NodeClassMask = this.m_nodeClassMask;
      browseDescription.ResultMask = this.m_resultMask;
      BrowseDescriptionCollection descriptionCollection = new BrowseDescriptionCollection();
      descriptionCollection.Add(browseDescription);
      BrowseResultCollection results;
      DiagnosticInfoCollection diagnosticInfos;
      ResponseHeader responseHeader = this.m_session.Browse((RequestHeader) null, this.m_view, this.m_maxReferencesReturned, descriptionCollection, out results, out diagnosticInfos);
      ClientBase.ValidateResponse((IList) results, (IList) descriptionCollection);
      ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) descriptionCollection);
      byte[] continuationPoint = !StatusCode.IsBad(results[0].StatusCode) ? results[0].ContinuationPoint : throw ServiceResultException.Create(results[0].StatusCode, 0, diagnosticInfos, (IList<string>) responseHeader.StringTable);
      ReferenceDescriptionCollection references = results[0].References;
      while (continuationPoint != null)
      {
        if (!this.m_continueUntilDone && this.m_MoreReferences != null)
        {
          BrowserEventArgs e = new BrowserEventArgs(references);
          this.m_MoreReferences(this, e);
          if (!e.Cancel)
          {
            this.m_continueUntilDone = e.ContinueUntilDone;
          }
          else
          {
            this.BrowseNext(ref continuationPoint, true);
            return references;
          }
        }
        ReferenceDescriptionCollection collection = this.BrowseNext(ref continuationPoint, false);
        if (collection != null && collection.Count > 0)
        {
          references.AddRange((IEnumerable<ReferenceDescription>) collection);
        }
        else
        {
          Utils.LogWarning("Browser: Continuation point exists, but the browse results are null/empty.");
          break;
        }
      }
      return references;
    }
    finally
    {
      this.m_browseInProgress = false;
    }
  }

  private void CheckBrowserState()
  {
    if (this.m_browseInProgress)
      throw new ServiceResultException(2158952448U /*0x80AF0000*/, "Cannot change browse parameters while a browse operation is in progress.");
  }

  private ReferenceDescriptionCollection BrowseNext(ref byte[] continuationPoint, bool cancel)
  {
    ByteStringCollection stringCollection = new ByteStringCollection();
    stringCollection.Add(continuationPoint);
    BrowseResultCollection results;
    DiagnosticInfoCollection diagnosticInfos;
    ResponseHeader responseHeader = this.m_session.BrowseNext((RequestHeader) null, cancel, stringCollection, out results, out diagnosticInfos);
    ClientBase.ValidateResponse((IList) results, (IList) stringCollection);
    ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) stringCollection);
    continuationPoint = !StatusCode.IsBad(results[0].StatusCode) ? results[0].ContinuationPoint : throw ServiceResultException.Create(results[0].StatusCode, 0, diagnosticInfos, (IList<string>) responseHeader.StringTable);
    return results[0].References;
  }

  private event BrowserEventHandler m_MoreReferences;
}
