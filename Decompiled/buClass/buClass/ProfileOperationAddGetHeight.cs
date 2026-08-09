using System.Collections.Generic;

namespace buClass;

public delegate void ProfileOperationAddGetHeight(bool JustCalculate, planeNames Plane, ref List<double> DepthAllLayers, ref List<DepthPosition> DepthCalculatedLayers);
