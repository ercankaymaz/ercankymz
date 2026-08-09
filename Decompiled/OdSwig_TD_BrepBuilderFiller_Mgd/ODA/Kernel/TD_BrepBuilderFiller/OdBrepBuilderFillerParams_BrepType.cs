using System;

namespace ODA.Kernel.TD_BrepBuilderFiller;

[Flags]
public enum OdBrepBuilderFillerParams_BrepType
{
	kBrepUnknown = 0,
	kBrepAcisDgn = 1,
	kBrepAcisDwg = 2,
	kBrepBimRv = 3,
	kBrepIfc = 4,
	kBrepMd = 5,
	kBrepPrc = 6,
	kBrepPS = 7,
	kBrepVisualize = 8,
	kBrepStep = 9,
	kBrepQif = 0xA,
	kBrepIges = 0xB
}
