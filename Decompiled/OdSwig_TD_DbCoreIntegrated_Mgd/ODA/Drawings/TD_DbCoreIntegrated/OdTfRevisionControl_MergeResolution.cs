namespace ODA.Drawings.TD_DbCoreIntegrated;

public enum OdTfRevisionControl_MergeResolution
{
	kMergeRevertFull = 4,
	kMergeMineConflict = 1,
	kMergeMineFull = 5,
	kMergeTheirsConflict = 2,
	kMergeTheirsFull = 6,
	kMergePostpone = 5,
	kMergeNoResolution = 0
}
