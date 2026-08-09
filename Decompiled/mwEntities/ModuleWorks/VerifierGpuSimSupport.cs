namespace ModuleWorks;

public enum VerifierGpuSimSupport
{
	None = 0,
	SufficientVramInstalled = 1,
	SufficientSystemMemoryInstalled = 2,
	CommandBufferPreemption = 4,
	Fp64 = 8,
	Full = 15
}
