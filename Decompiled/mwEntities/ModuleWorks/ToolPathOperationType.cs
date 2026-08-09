using System;

namespace ModuleWorks;

[Serializable]
public enum ToolPathOperationType
{
	NoOperation,
	Processing,
	ReadingMeshData,
	FindingIntersection,
	PreparingGougeChecking,
	CollisionChecking,
	TestingRemainingCollisions,
	Linking,
	ContourTrimming,
	SpiralConversion,
	FilteringContours,
	Roughing,
	RemovingRemainingCollisions,
	GeometryValidation,
	CornerPegs,
	BuildingHeightNet,
	BuildingOffsets,
	TrimmingCuts,
	Ordering,
	AddingRoughingLeadIns,
	BuildingStockNet,
	PartSlicing,
	ShiftedPartSlicing,
	StockSlicing,
	ShiftedStockSlicing,
	PreparingMeshForGougeChecking,
	SmoothRotaryAxes,
	FlatlandsSearch,
	FlatlandsCreatePath,
	LayerPreparation
}
