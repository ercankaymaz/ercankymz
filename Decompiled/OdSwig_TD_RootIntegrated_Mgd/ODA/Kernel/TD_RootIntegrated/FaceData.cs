using System;

namespace ODA.Kernel.TD_RootIntegrated;

public class FaceData
{
	private ushort[] m_pColors;

	private OdCmEntityColor[] m_pTrueColors;

	private OdDbStub[] m_pLayerIds;

	private IntPtr[] m_pSelectionMarkers;

	private byte[] m_pVisibilities;

	private OdGeVector3d[] m_pNormals;

	private OdDbStub[] m_pMaterialIds;

	private OdGiMapper[] m_pMappers;

	private OdCmTransparency[] m_pTransparency;

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

	public OdGeVector3d[] Normals
	{
		get
		{
			return m_pNormals;
		}
		set
		{
			m_pNormals = value;
		}
	}

	public OdDbStub[] MaterialIds
	{
		get
		{
			return m_pMaterialIds;
		}
		set
		{
			m_pMaterialIds = value;
		}
	}

	public OdGiMapper[] Mappers
	{
		get
		{
			return m_pMappers;
		}
		set
		{
			m_pMappers = value;
		}
	}

	public OdCmTransparency[] Transparency
	{
		get
		{
			return m_pTransparency;
		}
		set
		{
			m_pTransparency = value;
		}
	}
}
