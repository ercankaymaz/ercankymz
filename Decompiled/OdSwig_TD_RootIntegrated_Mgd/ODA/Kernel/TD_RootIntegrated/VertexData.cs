namespace ODA.Kernel.TD_RootIntegrated;

public class VertexData
{
	private OdGeVector3d[] m_pNormals;

	private OdGiOrientationType m_orientationFlag;

	private OdCmEntityColor[] m_pTrueColors;

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

	public OdGiOrientationType OrientationFlag
	{
		get
		{
			return m_orientationFlag;
		}
		set
		{
			m_orientationFlag = value;
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
}
