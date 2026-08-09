using System;

namespace ODA.Kernel.TD_RootIntegrated;

public class EdgeData
{
	private ushort[] m_pColors;

	private OdCmEntityColor[] m_pTrueColors;

	private OdDbStub[] m_pLayerIds;

	private OdDbStub[] m_pLinetypeIds;

	private IntPtr[] m_pSelectionMarkers;

	private byte[] m_pVisibilities;

	public ushort[] Colors
	{
		get
		{
			return m_pColors;
		}
		set
		{
			m_pColors = value;
		}
	}

	public OdCmEntityColor[] TrueColors
	{
		get
		{
			return m_pTrueColors;
		}
		set
		{
			m_pTrueColors = value;
		}
	}

	public OdDbStub[] LayerIds
	{
		get
		{
			return m_pLayerIds;
		}
		set
		{
			m_pLayerIds = value;
		}
	}

	public OdDbStub[] LinetypeIds
	{
		get
		{
			return m_pLinetypeIds;
		}
		set
		{
			m_pLinetypeIds = value;
		}
	}

	public IntPtr[] SelectionMarkers
	{
		get
		{
			return m_pSelectionMarkers;
		}
		set
		{
			m_pSelectionMarkers = value;
		}
	}

	public byte[] Visibilities
	{
		get
		{
			return m_pVisibilities;
		}
		set
		{
			m_pVisibilities = value;
		}
	}
}
