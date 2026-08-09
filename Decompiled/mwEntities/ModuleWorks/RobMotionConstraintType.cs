using System;

namespace ModuleWorks;

[Serializable]
public enum RobMotionConstraintType
{
	Free_Spin_In_Z_End_Effector,
	Point_End_Effector,
	Frame_End_Effector,
	Linear_Constraint_End_Effector,
	XY_Constraint_End_Effector,
	General_Spatial_Constrain_End_Effector
}
