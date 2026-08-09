namespace ODA.Kernel.TD_RootIntegrated;

public class MeshData
{
	private int numRows;

	private int numColumns;

	private OdGePoint3d[] vertexList;

	private EdgeData edgeData;

	private FaceData faceData;

	private VertexData vertexData;

	public int NumRows
	{
		get
		{
			return numRows;
		}
		set
		{
			numRows = value;
		}
	}

	public int NumColumns
	{
		get
		{
			return numColumns;
		}
		set
		{
			numColumns = value;
		}
	}

	public OdGePoint3d[] VertexList
	{
		get
		{
			return vertexList;
		}
		set
		{
			vertexList = value;
		}
	}

	public EdgeData EdgeData
	{
		get
		{
			return edgeData;
		}
		set
		{
			edgeData = value;
		}
	}

	public FaceData FaceData
	{
		get
		{
			return faceData;
		}
		set
		{
			faceData = value;
		}
	}

	public VertexData VertexData
	{
		get
		{
			return vertexData;
		}
		set
		{
			vertexData = value;
		}
	}

	public MeshData()
	{
	}

	public MeshData(int numRows, int numColumns, OdGePoint3d[] vertexList, EdgeData edgeData, FaceData faceData, VertexData vertexData)
	{
		this.numRows = numRows;
		this.numColumns = numColumns;
		this.vertexList = vertexList;
		this.edgeData = edgeData;
		this.faceData = faceData;
		this.vertexData = vertexData;
	}
}
