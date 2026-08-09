using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbViewport_StandardScaleType
{
	kScaleToFit = 0,
	kCustomScale = 1,
	k1_1 = 2,
	k1_2 = 3,
	k1_4 = 4,
	k1_5 = 5,
	k1_8 = 6,
	k1_10 = 7,
	k1_16 = 8,
	k1_20 = 9,
	k1_30 = 0xA,
	k1_40 = 0xB,
	k1_50 = 0xC,
	k1_100 = 0xD,
	k2_1 = 0xE,
	k4_1 = 0xF,
	k8_1 = 0x10,
	k10_1 = 0x11,
	k100_1 = 0x12,
	k1_128in_1ft = 0x13,
	k1_64in_1ft = 0x14,
	k1_32in_1ft = 0x15,
	k1_16in_1ft = 0x16,
	k3_32in_1ft = 0x17,
	k1_8in_1ft = 0x18,
	k3_16in_1ft = 0x19,
	k1_4in_1ft = 0x1A,
	k3_8in_1ft = 0x1B,
	k1_2in_1ft = 0x1C,
	k3_4in_1ft = 0x1D,
	k1in_1ft = 0x1E,
	k1and1_2in_1ft = 0x1F,
	k3in_1ft = 0x20,
	k6in_1ft = 0x21,
	k1ft_1ft = 0x22
}
