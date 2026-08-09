using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public enum EventSeverity
{
	Max = 1000,
	High = 900,
	MediumHigh = 700,
	Medium = 500,
	MediumLow = 300,
	Low = 100,
	Min = 1
}
