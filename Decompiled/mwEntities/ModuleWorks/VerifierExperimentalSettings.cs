using System;

namespace ModuleWorks;

[Serializable]
public struct VerifierExperimentalSettings
{
	public int SubVolumeSize { get; set; }

	public bool GraphBasedTriangulation { get; set; }

	public float SolidStampingMaxAngle5x { get; set; }

	public bool UseSweepDist { get; set; }

	public bool CorrectStampingRotation { get; set; }

	public bool FastMeshDecimation { get; set; }

	public bool FreeMemoryOnToolChange { get; set; }

	public VerifierMeshImportStrategy MeshImportStrategy { get; set; }

	public bool UseMeshToolsFor5x { get; set; }

	[Obsolete("Deprecated since 2025.08. Please use Verification::GpuMode!")]
	public bool GPUSimEnabled { get; set; }
}
