using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbPlotSettings_StdScaleType
{
	kScaleToFit = 0,
	k1_128in_1ft = 1,
	k1_64in_1ft = 2,
	k1_32in_1ft = 3,
	k1_16in_1ft = 4,
	k3_32in_1ft = 5,
	k1_8in_1ft = 6,
	k3_16in_1ft = 7,
	k1_4in_1ft = 8,
	k3_8in_1ft = 9,
	k1_2in_1ft = 0xA,
	k3_4in_1ft = 0xB,
	k1in_1ft = 0xC,
	k3in_1ft = 0xD,
	k6in_1ft = 0xE,
	k1ft_1ft = 0xF,
	k1_1 = 0x10,
	k1_2 = 0x11,
	k1_4 = 0x12,
	k1_5 = 0x13,
	k1_8 = 0x14,
	k1_10 = 0x15,
	k1_16 = 0x16,
	k1_20 = 0x17,
	k1_30 = 0x18,
	k1_40 = 0x19,
	k1_50 = 0x1A,
	k1_100 = 0x1B,
	k2_1 = 0x1C,
	k4_1 = 0x1D,
	k8_1 = 0x1E,
	k10_1 = 0x1F,
	k100_1 = 0x20,
	k1000_1 = 0x21,
	k1and1_2in_1ft = 0x22
}
