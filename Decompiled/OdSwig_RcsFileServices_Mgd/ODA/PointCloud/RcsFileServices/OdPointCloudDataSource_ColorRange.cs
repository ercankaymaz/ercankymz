using System;

namespace ODA.PointCloud.RcsFileServices;

[Flags]
public enum OdPointCloudDataSource_ColorRange
{
	kNoColorRange = -1,
	kColorRange1 = 0,
	kColorRange255 = 1,
	kColorRange65280 = 2
}
