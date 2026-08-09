using System.Runtime.InteropServices;
using System.Runtime.Serialization;

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

	public ISession Session
	{
		get
		{
			return m_session;
		}
		set
		{
			CheckBrowserState();
			m_session = value;
		}
	}

	[DataMember(Order = 1)]
	public ViewDescription View
	{
		get
		{
			return m_view;
		}
		set
		{
			CheckBrowserState();
			m_view = value;
		}
	}

	[DataMember(Order = 2)]
	public uint MaxReferencesReturned
	{
		get
		{
			return m_maxReferencesReturned;
		}
		set
		{
			CheckBrowserState();
			m_maxReferencesReturned = value;
		}
	}

	[DataMember(Order = 3)]
	public BrowseDirection BrowseDirection
	{
		get
		{
			return m_browseDirection;
		}
		set
		{
			CheckBrowserState();
			m_browseDirection = value;
		}
	}

	[DataMember(Order = 4)]
	public NodeId ReferenceTypeId
	{
		get
		{
			return m_referenceTypeId;
		}
		set
		{
			CheckBrowserState();
			m_referenceTypeId = value;
		}
	}

	[DataMember(Order = 5)]
	public bool IncludeSubtypes
	{
		get
		{
			return m_includeSubtypes;
		}
		set
		{
			CheckBrowserState();
			m_includeSubtypes = value;
		}
	}

	[DataMember(Order = 6)]
	public int NodeClassMask
	{
		get
		{
			return Utils.ToInt32(m_nodeClassMask);
		}
		set
		{
			CheckBrowserState();
			m_nodeClassMask = Utils.ToUInt32(value);
		}
	}

	[DataMember(Order = 6)]
	public uint ResultMask
	{
		get
		{
			return m_resultMask;
		}
		set
		{
			CheckBrowserState();
			m_resultMask = value;
		}
	}

	public bool ContinueUntilDone
	{
		get
		{
			return m_continueUntilDone;
		}
		set
		{
			CheckBrowserState();
			m_continueUntilDone = value;
		}
	}

	public event BrowserEventHandler MoreReferences
	{
		add
		{
			m_MoreReferences += value;
		}
		remove
		{
			m_MoreReferences -= value;
		}
	}

	private event BrowserEventHandler m_MoreReferences;

	public Browser()
	{
		Initialize();
	}

	public Browser(ISession session)
	{
		Initialize();
		m_session = session;
	}

	public Browser(Browser template)
	{
		Initialize();
		if (template != null)
		{
			m_session = template.m_session;
			m_view = template.m_view;
			m_maxReferencesReturned = template.m_maxReferencesReturned;
			m_browseDirection = template.m_browseDirection;
			m_referenceTypeId = template.m_referenceTypeId;
			m_includeSubtypes = template.m_includeSubtypes;
			m_nodeClassMask = template.m_nodeClassMask;
			m_resultMask = template.m_resultMask;
			m_continueUntilDone = template.m_continueUntilDone;
		}
	}

	private void Initialize()
	{
		m_session = null;
		m_view = null;
		m_maxReferencesReturned = 0u;
		m_browseDirection = BrowseDirection.Forward;
		m_referenceTypeId = null;
		m_includeSubtypes = true;
		m_nodeClassMask = 0u;
		m_resultMask = 63u;
		m_continueUntilDone = false;
		m_browseInProgress = false;
	}

	public ReferenceDescriptionCollection Browse(NodeId nodeId)
	{
		if (m_session == null)
		{
			throw new ServiceResultException(2148335616u, "Cannot browse if not connected to a server.");
		}
		try
		{
			m_browseInProgress = true;
			BrowseDescription browseDescription = new BrowseDescription();
			browseDescription.NodeId = nodeId;
			browseDescription.BrowseDirection = m_browseDirection;
			browseDescription.ReferenceTypeId = m_referenceTypeId;
			browseDescription.IncludeSubtypes = m_includeSubtypes;
			browseDescription.NodeClassMask = m_nodeClassMask;
			browseDescription.ResultMask = m_resultMask;
			BrowseDescriptionCollection browseDescriptionCollection = new BrowseDescriptionCollection();
			browseDescriptionCollection.Add(browseDescription);
			BrowseResultCollection results;
			DiagnosticInfoCollection diagnosticInfos;
			ResponseHeader responseHeader = m_session.Browse(null, m_view, m_maxReferencesReturned, browseDescriptionCollection, out results, out diagnosticInfos);
			ClientBase.ValidateResponse(results, browseDescriptionCollection);
			ClientBase.ValidateDiagnosticInfos(diagnosticInfos, browseDescriptionCollection);
			if (StatusCode.IsBad(results[0].StatusCode))
			{
				throw ServiceResultException.Create(results[0].StatusCode, 0, diagnosticInfos, responseHeader.StringTable);
			}
			byte[] continuationPoint = results[0].ContinuationPoint;
			ReferenceDescriptionCollection references = results[0].References;
			while (continuationPoint != null)
			{
				if (!m_continueUntilDone && this.m_MoreReferences != null)
				{
					BrowserEventArgs e = new BrowserEventArgs(references);
					this.m_MoreReferences(this, e);
					if (e.Cancel)
					{
						BrowseNext(ref continuationPoint, cancel: true);
						return references;
					}
					m_continueUntilDone = e.ContinueUntilDone;
				}
				ReferenceDescriptionCollection referenceDescriptionCollection = BrowseNext(ref continuationPoint, cancel: false);
				if (referenceDescriptionCollection != null && referenceDescriptionCollection.Count > 0)
				{
					references.AddRange(referenceDescriptionCollection);
					continue;
				}
				Utils.LogWarning("Browser: Continuation point exists, but the browse results are null/empty.");
				break;
			}
			return references;
		}
		finally
		{
			m_browseInProgress = false;
		}
	}

	private void CheckBrowserState()
	{
		if (m_browseInProgress)
		{
			throw new ServiceResultException(2158952448u, "Cannot change browse parameters while a browse operation is in progress.");
		}
	}

	private ReferenceDescriptionCollection BrowseNext(ref byte[] continuationPoint, bool cancel)
	{
		ByteStringCollection byteStringCollection = new ByteStringCollection();
		byteStringCollection.Add(continuationPoint);
		BrowseResultCollection results;
		DiagnosticInfoCollection diagnosticInfos;
		ResponseHeader responseHeader = m_session.BrowseNext(null, cancel, byteStringCollection, out results, out diagnosticInfos);
		ClientBase.ValidateResponse(results, byteStringCollection);
		ClientBase.ValidateDiagnosticInfos(diagnosticInfos, byteStringCollection);
		if (StatusCode.IsBad(results[0].StatusCode))
		{
			throw ServiceResultException.Create(results[0].StatusCode, 0, diagnosticInfos, responseHeader.StringTable);
		}
		continuationPoint = results[0].ContinuationPoint;
		return results[0].References;
	}
}
