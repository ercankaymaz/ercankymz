using System;

namespace ModuleWorks;

[Serializable]
public struct VerifierMeshCollisionReport
{
	public int MeshId { get; set; }

	public float ViolatedSafetyDistance { get; set; }

	public int SafetyDistanceIndex { get; set; }

	public Vectorf CollisionPoint { get; set; }

	public int ChunkId { get; set; }

	public VerifierMeshCollisionReport(int meshId, float violatedSafetyDistance, int safetyDistanceIndex, Vectorf collisionPoint, int chunkId = -1)
	{
		this = default(VerifierMeshCollisionReport);
		MeshId = meshId;
		ViolatedSafetyDistance = violatedSafetyDistance;
		SafetyDistanceIndex = safetyDistanceIndex;
		CollisionPoint = collisionPoint;
		ChunkId = chunkId;
	}
}
