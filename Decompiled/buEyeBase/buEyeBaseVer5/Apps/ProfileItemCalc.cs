using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileItemCalc : buSerilization5
{
	public bool IsClamperDone = false;

	public bool isSimulationDone = false;

	public bool isError = false;

	public bool OriginalIsLongProfile = false;

	public double Width = 0.0;

	public double Height = 0.0;

	public double Length = 1000.0;

	public double MaxOperationXPosition = 0.0;

	public double LongProfileFirstPartLength = 0.0;

	public int MaxClamperNumber = 4;

	public Point3D TotalOffset = new Point3D();

	public Point3D ProfileMinPoint = new Point3D();

	public Point3D ProfileMaxPoint = new Point3D();

	public Point3D ProfileCenterPoint = new Point3D();

	public LeftRightType XReferanceLocation = LeftRightType.Left;

	public ProfileExcType CalcType = ProfileExcType.Normal;

	public List<GProfileOperation> calcOperations = new List<GProfileOperation>();

	public ProfileClamperSettings ClamperSettings = new ProfileClamperSettings();

	public List<Pnt6DSimMove> SimMoves = new List<Pnt6DSimMove>();

	public List<string> ProfileTraformations = new List<string>();

	public List<camTp> Cams = new List<camTp>();

	public List<string> GCodesItem = new List<string>();

	public List<List<ProfileClamper>> ClamperLists = new List<List<ProfileClamper>>();

	public ProfileItemCalc()
	{
	}

	public ProfileItemCalc(ProfileItemCalc data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
		{
			FieldInfo[] fields = GetType().GetFields();
			if (fields != null)
			{
				for (int i = 0; i <= fields.Length - 1; i++)
				{
					_ = fields[i].Name;
					object value = fields[i].GetValue(CopiedClass);
					fields[i].SetValue(this, value);
				}
			}
		}
		ProfileCenterPoint = new Point3D(data.ProfileCenterPoint.X, data.ProfileCenterPoint.Y, data.ProfileCenterPoint.Z);
		ProfileMinPoint = new Point3D(data.ProfileMinPoint.X, data.ProfileMinPoint.Y, data.ProfileMinPoint.Z);
		ProfileMaxPoint = new Point3D(data.ProfileMaxPoint.X, data.ProfileMaxPoint.Y, data.ProfileMaxPoint.Z);
		ClamperSettings = new ProfileClamperSettings(data.ClamperSettings);
		calcOperations = new List<GProfileOperation>();
		GProfileOperation.Copy(data.calcOperations, ref calcOperations);
		Pnt6DSimMove.Copy(data.SimMoves, ref SimMoves);
		for (int j = 0; j <= data.Cams.Count - 1; j++)
		{
			Cams.Add(new camTp(data.Cams[j]));
		}
		for (int k = 0; k <= data.ClamperLists.Count - 1; k++)
		{
			List<ProfileClamper> CopiedClamper = new List<ProfileClamper>();
			ProfileClamper.Copy(data.ClamperLists[k], ref CopiedClamper);
			ClamperLists.Add(CopiedClamper);
		}
	}

	public ProfileItemCalc(ProfileItem data, bool CopyOperations = false)
	{
		Length = data.Length;
		Width = data.Width;
		Height = data.Height;
		MaxOperationXPosition = data.MaxOperationXPosition;
		MaxClamperNumber = data.MaxClamperNumber;
		IsClamperDone = data.IsClamperDone;
		isSimulationDone = data.isSimulationDone;
		isError = data.isError;
		XReferanceLocation = data.XReferanceLocation;
		TotalOffset = new Point3D(data.TotalOffset.X, data.TotalOffset.Y, data.TotalOffset.Z);
		ProfileCenterPoint = new Point3D(data.ProfileCenterPoint.X, data.ProfileCenterPoint.Y, data.ProfileCenterPoint.Z);
		ProfileMinPoint = new Point3D(data.ProfileMinPoint.X, data.ProfileMinPoint.Y, data.ProfileMinPoint.Z);
		ProfileMaxPoint = new Point3D(data.ProfileMaxPoint.X, data.ProfileMaxPoint.Y, data.ProfileMaxPoint.Z);
		ClamperSettings = new ProfileClamperSettings(data.ClamperSettings);
		calcOperations = new List<GProfileOperation>();
		if (CopyOperations)
		{
			for (int i = 0; i <= data.Operations.Count - 1; i++)
			{
				if (!(data.Operations[i].OperationData.Array.LineerEnable & (data.Operations[i].OperationData.Array.LineerXCount * data.Operations[i].OperationData.Array.LineerYCount > 1)))
				{
					if (data.Operations[i].OperationData.OperationType != ProfileOperationTypes.Tapping)
					{
						calcOperations.Add(new GProfileOperation(data.Operations[i]));
						continue;
					}
					GProfileOperation gProfileOperation = new GProfileOperation(data.Operations[i])
					{
						OperationData = 
						{
							OperationType = ProfileOperationTypes.Hole,
							Action = actionTypeBU.profileHole
						}
					};
					if (data.Operations[i].ToolAux != null)
					{
						gProfileOperation.Tool = new ToolBase5(data.Operations[i].ToolAux);
					}
					calcOperations.Add(gProfileOperation);
					GProfileOperation gProfileOperation2 = new GProfileOperation(data.Operations[i]);
					if (gProfileOperation2.OperationData.selectedPlaneName == planeNames.Top)
					{
						double num = 0.0;
						if (gProfileOperation2.OperationData.DepthValues.Count > 0)
						{
							num = gProfileOperation2.OperationData.HoleData.TappingDepth - Math.Abs(gProfileOperation2.OperationData.DepthValues[0].Depth);
							for (int j = 0; j <= gProfileOperation2.CamCalculation[0].CamPoints[0].Points.Count - 1; j++)
							{
								if (gProfileOperation2.CamCalculation[0].CamPoints[0].Points[j].PlungeAxisMovement)
								{
									gProfileOperation2.CamCalculation[0].CamPoints[0].Points[j].P9.Z = gProfileOperation2.CamCalculation[0].CamPoints[0].Points[j].P9.Z - num;
								}
							}
						}
					}
					if (gProfileOperation2.OperationData.selectedPlaneName == planeNames.Front)
					{
						double num2 = 0.0;
						if (gProfileOperation2.OperationData.DepthValues.Count > 0)
						{
							num2 = gProfileOperation2.OperationData.HoleData.TappingDepth - Math.Abs(gProfileOperation2.OperationData.DepthValues[0].Depth);
							for (int k = 0; k <= gProfileOperation2.CamCalculation[0].CamPoints[0].Points.Count - 1; k++)
							{
								if (gProfileOperation2.CamCalculation[0].CamPoints[0].Points[k].PlungeAxisMovement)
								{
									gProfileOperation2.CamCalculation[0].CamPoints[0].Points[k].P9.Y = gProfileOperation2.CamCalculation[0].CamPoints[0].Points[k].P9.Y + num2;
								}
							}
						}
					}
					if (gProfileOperation2.OperationData.selectedPlaneName == planeNames.Back)
					{
						double num3 = 0.0;
						if (gProfileOperation2.OperationData.DepthValues.Count > 0)
						{
							num3 = gProfileOperation2.OperationData.HoleData.TappingDepth - Math.Abs(gProfileOperation2.OperationData.DepthValues[0].Depth);
							for (int l = 0; l <= gProfileOperation2.CamCalculation[0].CamPoints[0].Points.Count - 1; l++)
							{
								if (gProfileOperation2.CamCalculation[0].CamPoints[0].Points[l].PlungeAxisMovement)
								{
									gProfileOperation2.CamCalculation[0].CamPoints[0].Points[l].Type = 0;
									gProfileOperation2.CamCalculation[0].CamPoints[0].Points[l].P9.Y = gProfileOperation2.CamCalculation[0].CamPoints[0].Points[l].P9.Y - num3;
								}
							}
						}
					}
					calcOperations.Add(gProfileOperation2);
					continue;
				}
				int num4 = data.Operations[i].OperationData.Array.LineerXCount * data.Operations[i].OperationData.Array.LineerYCount;
				for (int m = 0; m <= num4 - 1; m++)
				{
					GProfileOperation gProfileOperation3 = new GProfileOperation(data.Operations[i]);
					gProfileOperation3.EntityMultiCam.Clear();
					List<buEntity> list = new List<buEntity>();
					for (int n = 0; n <= data.Operations[i].EntityMultiCam.Count - 1; n++)
					{
						if (data.Operations[i].EntityMultiCam[n].Info.CamID == m)
						{
							gProfileOperation3.EntityMultiCam.Add(buEntity.Copy(data.Operations[i].EntityMultiCam[n]));
						}
					}
					for (int num5 = 0; num5 <= data.Operations[i].EntityMultiContour.Count - 1; num5++)
					{
						if (data.Operations[i].EntityMultiContour[num5].Info.CamID == m)
						{
							list.Add(buEntity.Copy(data.Operations[i].EntityMultiContour[num5]));
						}
					}
					if (list.Count > 0)
					{
						buCall.buVector5_0.BoxSizeCalculate(list, ref gProfileOperation3.SizePoint.MinPoint, ref gProfileOperation3.SizePoint.MidPoint, ref gProfileOperation3.SizePoint.MaxPoint);
						gProfileOperation3.SizePoint.Delta.X = gProfileOperation3.SizePoint.MaxPoint.X - gProfileOperation3.SizePoint.MinPoint.X;
						gProfileOperation3.SizePoint.Delta.Y = gProfileOperation3.SizePoint.MaxPoint.Y - gProfileOperation3.SizePoint.MinPoint.Y;
						gProfileOperation3.SizePoint.Delta.Z = gProfileOperation3.SizePoint.MaxPoint.Z - gProfileOperation3.SizePoint.MinPoint.Z;
						gProfileOperation3.OperationData.Position.X = gProfileOperation3.SizePoint.MidPoint.X;
					}
					list.Clear();
					if (data.Operations[i].OperationData.OperationType == ProfileOperationTypes.Tapping)
					{
						GProfileOperation gProfileOperation4 = new GProfileOperation(gProfileOperation3)
						{
							OperationData = 
							{
								OperationType = ProfileOperationTypes.Hole,
								Action = actionTypeBU.profileHole
							}
						};
						if (data.Operations[i].ToolAux != null)
						{
							gProfileOperation4.Tool = new ToolBase5(data.Operations[i].ToolAux);
						}
						calcOperations.Add(gProfileOperation4);
					}
					calcOperations.Add(gProfileOperation3);
				}
			}
		}
		if (data.MultiplyProfile.ProfileMultiplyEnable & (data.MultiplyProfile.ProfileMultiplyCount > 1))
		{
			if (data.MultiplyProfile.ProfileMultiplyMirror)
			{
				double num6 = 0.0 - (data.Width + data.MultiplyProfile.ProfileMultiplySpace / 2.0);
				Plane plane = new Plane(new Point3D(0.0, num6, 0.0), Vector3D.AxisZ, Vector3D.AxisX);
				Mirror mirror = new Mirror(plane);
				Plane plane2 = new Plane(new Point3D(data.Length / 2.0, 0.0, 0.0), Vector3D.AxisZ, Vector3D.AxisY);
				Mirror mirror2 = new Mirror(plane2);
				for (int num7 = 0; num7 <= data.Operations.Count - 1; num7++)
				{
					GProfileOperation gProfileOperation5 = new GProfileOperation(data.Operations[num7]);
					Point3D point3D = new Point3D(data.Operations[num7].OperationData.selectedPlane.Origin.X, data.Operations[num7].OperationData.selectedPlane.Origin.Y, data.Operations[num7].OperationData.selectedPlane.Origin.Z);
					new Vector3D(data.Operations[num7].OperationData.selectedPlane.AxisZ.X, data.Operations[num7].OperationData.selectedPlane.AxisZ.Y, data.Operations[num7].OperationData.selectedPlane.AxisZ.Z);
					Vector3D vector3D = new Vector3D(data.Operations[num7].OperationData.selectedPlane.AxisY.X, data.Operations[num7].OperationData.selectedPlane.AxisY.Y, data.Operations[num7].OperationData.selectedPlane.AxisY.Z);
					point3D.TransformBy(mirror);
					vector3D.TransformBy(mirror);
					point3D.TransformBy(mirror2);
					vector3D.TransformBy(mirror2);
					gProfileOperation5.OperationData.selectedPlane = new Plane(point3D, gProfileOperation5.OperationData.selectedPlane.AxisX * -1.0, vector3D);
					for (int num8 = 0; num8 <= gProfileOperation5.EntityMultiCam.Count - 1; num8++)
					{
						gProfileOperation5.EntityMultiCam[num8].TransformBy(mirror);
						gProfileOperation5.EntityMultiCam[num8].TransformBy(mirror2);
						gProfileOperation5.EntityMultiCam[num8].Orientation.A = 0.0 - gProfileOperation5.EntityMultiCam[num8].Orientation.A;
					}
					for (int num9 = 0; num9 <= gProfileOperation5.CamCalculation.Count - 1; num9++)
					{
						camTp camTp2 = gProfileOperation5.CamCalculation[num9];
						for (int num10 = 0; num10 <= camTp2.CamPoints.Count - 1; num10++)
						{
							for (int num11 = 0; num11 <= camTp2.CamPoints[num10].Points.Count - 1; num11++)
							{
								TpPnt9D tpPnt9D = camTp2.CamPoints[num10].Points[num11];
								tpPnt9D.P9.A = 0.0 - tpPnt9D.P9.A;
								double num12 = num6 - tpPnt9D.P9.Y;
								tpPnt9D.P9.Y = num6 + num12;
								double x = data.Length - tpPnt9D.P9.X;
								tpPnt9D.P9.X = x;
							}
						}
					}
					if (gProfileOperation5.OperationData.selectedPlaneName != planeNames.Front)
					{
						if (gProfileOperation5.OperationData.selectedPlaneName == planeNames.Back)
						{
							gProfileOperation5.OperationData.selectedPlaneName = planeNames.Front;
						}
					}
					else
					{
						gProfileOperation5.OperationData.selectedPlaneName = planeNames.Back;
					}
					calcOperations.Add(gProfileOperation5);
				}
			}
			else
			{
				for (int num13 = 1; num13 <= data.MultiplyProfile.ProfileMultiplyCount - 1; num13++)
				{
					double num14 = (double)num13 * (data.Width + data.MultiplyProfile.ProfileMultiplySpace);
					for (int num15 = 0; num15 <= data.Operations.Count - 1; num15++)
					{
						GProfileOperation gProfileOperation6 = new GProfileOperation(data.Operations[num15]);
						buCall.buVector5_0.Move(0.0, 0.0 - num14, 0.0, ref gProfileOperation6.EntityMultiCam);
						for (int num16 = 0; num16 <= gProfileOperation6.CamCalculation.Count - 1; num16++)
						{
							camTp Cam = gProfileOperation6.CamCalculation[num16];
							buCall.buCam5_0.MoveCam(0.0, 0.0 - num14, 0.0, ref Cam);
						}
						calcOperations.Add(gProfileOperation6);
					}
				}
			}
		}
		for (int num17 = 0; num17 <= data.ProfileTraformations.Count - 1; num17++)
		{
			ProfileTraformations.Add(data.ProfileTraformations[num17]);
		}
	}

	public override string ToString()
	{
		return "Len: " + Length.ToString("f3") + " - OP: " + calcOperations.Count;
	}
}
