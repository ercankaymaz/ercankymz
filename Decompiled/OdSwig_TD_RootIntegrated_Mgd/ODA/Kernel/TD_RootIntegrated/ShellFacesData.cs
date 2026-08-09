namespace ODA.Kernel.TD_RootIntegrated;

public class ShellFacesData
{
	private int[] faceList;

	private EdgeData edgeData;

	private FaceData faceData;

	public int[] FaceList
	{
		get
		{
			return faceList;
		}
		set
		{
			faceList = value;
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

	public ShellFacesData()
	{
	}

	public ShellFacesData(int[] fList, EdgeData edgeData, FaceData faceData)
	{
		faceList = fList;
		this.edgeData = edgeData;
		this.faceData = faceData;
	}
}
