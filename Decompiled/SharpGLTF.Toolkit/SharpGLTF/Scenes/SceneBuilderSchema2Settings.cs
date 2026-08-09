namespace SharpGLTF.Scenes;

public struct SceneBuilderSchema2Settings
{
	public static SceneBuilderSchema2Settings Default => new SceneBuilderSchema2Settings
	{
		UseStridedBuffers = true,
		CompactVertexWeights = false,
		GpuMeshInstancingMinCount = int.MaxValue,
		MergeBuffers = true
	};

	public static SceneBuilderSchema2Settings WithGpuInstancing => new SceneBuilderSchema2Settings
	{
		UseStridedBuffers = true,
		CompactVertexWeights = false,
		GpuMeshInstancingMinCount = 3,
		MergeBuffers = true
	};

	public bool UseStridedBuffers { get; set; }

	public bool CompactVertexWeights { get; set; }

	public int GpuMeshInstancingMinCount { get; set; }

	public bool MergeBuffers { get; set; }
}
