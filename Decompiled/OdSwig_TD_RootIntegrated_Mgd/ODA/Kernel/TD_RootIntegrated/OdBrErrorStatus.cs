namespace ODA.Kernel.TD_RootIntegrated;

public enum OdBrErrorStatus
{
	odbrOK = 0,
	odbrWrongObjectType = 39,
	odbrInvalidObject = 121,
	odbrUnsuitableTopology = 3013,
	odbrMissingGeometry = 147,
	odbrInvalidInput = 5,
	odbrDegenerateTopology = 3020,
	odbrUninitialisedObject = 3021,
	odbrOutOfMemory = 9,
	odbrBrepChanged = 3008,
	odbrNotImplementedYet = 3,
	odbrNullObjectId = 21,
	odbrNotApplicable = 4,
	odbrWrongSubentityType = 189,
	odbrNullSubentityId = 28,
	odbrNullObjectPointer = 121,
	odbrObjectIdMismatch = 40,
	odbrTopologyMismatch = 40,
	odbrUnsuitableGeometry = 8,
	odbrMissingSubentity = 138,
	odbrAmbiguousOutput = 8,
	odbrUnrecoverableErrors = 121,
	odbrMissingTopology = 3020,
	odbrWrongDatabase = 40,
	odbrNotInDatabase = 138,
	odbrDegenerateGeometry = 147
}
