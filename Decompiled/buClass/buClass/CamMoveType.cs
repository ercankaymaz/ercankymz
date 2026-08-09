using System;

namespace buClass;

[Serializable]
public enum CamMoveType
{
	G0,
	G1,
	Plunge,
	Leave,
	Mark,
	LeadIn,
	LeadOut,
	Connection,
	Other
}
