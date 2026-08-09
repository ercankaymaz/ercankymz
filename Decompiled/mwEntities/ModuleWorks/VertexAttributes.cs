namespace ModuleWorks;

public class VertexAttributes
{
	public int NumVertices { get; private set; }

	public float[] Deviation { get; private set; }

	public int[] OperationId { get; private set; }

	public bool[] Collision { get; private set; }

	public int[] ChunkId { get; private set; }

	public int[] ToolId { get; private set; }

	public float[] MoveId { get; private set; }

	public VertexAttributes()
		: this(0)
	{
	}

	public VertexAttributes(int _numVertices)
	{
		NumVertices = _numVertices;
		Deviation = null;
		OperationId = null;
		Collision = null;
		ChunkId = null;
		ToolId = null;
		MoveId = null;
	}

	public VertexAttributes(int _numVertices, float[] _deviation, int[] _operationId, bool[] _collision, int[] _chunkId, int[] _toolId, float[] _moveId)
	{
		NumVertices = _numVertices;
		Deviation = _deviation;
		OperationId = _operationId;
		Collision = _collision;
		ChunkId = _chunkId;
		ToolId = _toolId;
		MoveId = _moveId;
	}
}
