using System;

namespace ODA.Kernel.TD_RootIntegrated;

public class ShellData
{
	private OdGePoint3d[] points;

	private int[] faces;

	private EdgeData edgeData;

	private FaceData faceData;

	private VertexData vertexData;

	public OdGePoint3d[] Points
	{
		get
		{
			return points;
		}
		set
		{
			points = value;
		}
	}

	public int[] Faces
	{
		get
		{
			return faces;
		}
		set
		{
			faces = value;
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

	public void getEdgesFacesCount(out int FaceCount, out int EdgeCount)
	{
		FaceCount = 0;
		EdgeCount = 0;
		int num;
		for (num = 0; num < Faces.Length; num++)
		{
			if (Faces[num] > 0)
			{
				FaceCount++;
			}
			EdgeCount += Math.Abs(Faces[num]);
			num += Math.Abs(Faces[num]);
		}
	}
}
