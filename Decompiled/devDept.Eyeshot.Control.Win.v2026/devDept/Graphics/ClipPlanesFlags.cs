using System;

namespace devDept.Graphics;

[Flags]
internal enum ClipPlanesFlags
{
	Zero = 0,
	One = 1,
	Two = 2,
	Three = 4,
	Four = 8,
	Five = 0x10,
	Six = 0x20
}
