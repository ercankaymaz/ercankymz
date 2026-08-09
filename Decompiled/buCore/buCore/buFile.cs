using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using ns54;

namespace buCore;

public class buFile
{
	public class GCodeRead
	{
		public GCodeChars Chars = new GCodeChars();

		public AxesEnableWithUVW DecodeAxes = new AxesEnableWithUVW(x: true, y: true, z: true);

		public List<eEntities> EntitiesG1 = new List<eEntities>();

		public List<eEntities> EntitiesG0 = new List<eEntities>();

		public List<eEntities> EntitiesPlunge = new List<eEntities>();

		public List<eEntities> EntitiesLeave = new List<eEntities>();

		public Pnt9D MaxCoordinates = new Pnt9D();

		public Pnt9D MinCoordinates = new Pnt9D();

		public int MaxLineCount = -1;

		private buVector buVector_0 = null;

		public GCodeRead()
		{
			if (!buVector.smethod_0("GCodeRead"))
			{
				throw new RegisterException("GCodeRead");
			}
			buVector_0 = new buVector();
		}

		public void OpenGCode(string FileName, ref List<GCodePoint> GCodeList)
		{
			List<string> StringList = new List<string>();
			OpenFromFile(FileName, ref StringList);
			OpenGCode(StringList, ref GCodeList);
		}

		public void OpenGCode(List<string> GCodes, ref List<GCodePoint> GCodeList)
		{
			try
			{
				GCodeList.Clear();
				Pnt9D pnt9D = new Pnt9D();
				double Value = 0.0;
				bool isGCode = false;
				int codeType = -1;
				bool flag = false;
				List<Pnt3D> CopiedPnt = new List<Pnt3D>();
				new List<Pnt3D>();
				List<GCodeGraphPoint> Points = new List<GCodeGraphPoint>();
				EntitiesG1.Clear();
				EntitiesG0.Clear();
				EntitiesLeave.Clear();
				EntitiesPlunge.Clear();
				EntitiesG1 = new List<eEntities>();
				EntitiesG0 = new List<eEntities>();
				EntitiesLeave = new List<eEntities>();
				EntitiesPlunge = new List<eEntities>();
				MaxCoordinates = new Pnt9D(double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue);
				MinCoordinates = new Pnt9D(double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue);
				for (int i = 0; i <= GCodes.Count - 1; i++)
				{
					bool flag2 = false;
					int num = -1;
					GCodePoint gCodePoint = new GCodePoint();
					gCodePoint.Positions = new Pnt9D(pnt9D);
					gCodePoint.isGCode = isGCode;
					gCodePoint.CodeType = codeType;
					string text = GCodes[i].Trim();
					if (text.IndexOf(",") >= 0)
					{
						text = text.Replace(",", ".");
					}
					if (i % 1000 == 0)
					{
						GC.Collect();
					}
					if (text.Length <= 0)
					{
						gCodePoint.isGCode = false;
						gCodePoint.isG0Move = false;
						gCodePoint.isMCode = false;
						gCodePoint.isTCode = false;
						gCodePoint.CodeType = -1;
					}
					else
					{
						gCodePoint.CodeString = text;
					}
					num = text.IndexOf(Chars.G);
					if (num >= 0)
					{
						gCodePoint.isGCode = true;
						gCodePoint.isMCode = false;
						if (buString.ReadStringValue(Chars.G, text, ref gCodePoint.GValue))
						{
							gCodePoint.CodeType = Convert.ToInt32(gCodePoint.GValue);
						}
					}
					num = text.IndexOf(Chars.M);
					if (num >= 0)
					{
						gCodePoint.isMCode = true;
						gCodePoint.isGCode = false;
					}
					num = text.IndexOf(Chars.T);
					if (num >= 0)
					{
						gCodePoint.isTCode = true;
						gCodePoint.isGCode = false;
					}
					gCodePoint.Entity = new geoPoint(new Pnt3D());
					gCodePoint.Entity.Visible = false;
					if (gCodePoint.isGCode)
					{
						flag2 = true;
						if (DecodeAxes.X && buString.ReadStringValue(Chars.X, text, ref gCodePoint.Positions.X))
						{
							if (gCodePoint.Positions.X > MaxCoordinates.X)
							{
								MaxCoordinates.X = gCodePoint.Positions.X;
							}
							if (gCodePoint.Positions.X < MinCoordinates.X)
							{
								MinCoordinates.X = gCodePoint.Positions.X;
							}
						}
						if (DecodeAxes.Y && buString.ReadStringValue(Chars.Y, text, ref gCodePoint.Positions.Y))
						{
							if (gCodePoint.Positions.Y > MaxCoordinates.Y)
							{
								MaxCoordinates.Y = gCodePoint.Positions.Y;
							}
							if (gCodePoint.Positions.Y < MinCoordinates.Y)
							{
								MinCoordinates.Y = gCodePoint.Positions.Y;
							}
						}
						if (DecodeAxes.Z && buString.ReadStringValue(Chars.Z, text, ref gCodePoint.Positions.Z))
						{
							if (gCodePoint.Positions.Z > MaxCoordinates.Z)
							{
								MaxCoordinates.Z = gCodePoint.Positions.Z;
							}
							if (gCodePoint.Positions.Z < MinCoordinates.Z)
							{
								MinCoordinates.Z = gCodePoint.Positions.Z;
							}
						}
						if (DecodeAxes.A && buString.ReadStringValue(Chars.A, text, ref gCodePoint.Positions.A))
						{
							if (gCodePoint.Positions.A > MaxCoordinates.A)
							{
								MaxCoordinates.A = gCodePoint.Positions.A;
							}
							if (gCodePoint.Positions.A < MinCoordinates.A)
							{
								MinCoordinates.A = gCodePoint.Positions.A;
							}
						}
						if (DecodeAxes.B && buString.ReadStringValue(Chars.B, text, ref gCodePoint.Positions.B))
						{
							if (gCodePoint.Positions.B > MaxCoordinates.B)
							{
								MaxCoordinates.B = gCodePoint.Positions.B;
							}
							if (gCodePoint.Positions.B < MinCoordinates.B)
							{
								MinCoordinates.B = gCodePoint.Positions.B;
							}
						}
						if (DecodeAxes.C && buString.ReadStringValue(Chars.C, text, ref gCodePoint.Positions.C))
						{
							if (gCodePoint.Positions.C > MaxCoordinates.C)
							{
								MaxCoordinates.C = gCodePoint.Positions.C;
							}
							if (gCodePoint.Positions.C < MinCoordinates.C)
							{
								MinCoordinates.C = gCodePoint.Positions.C;
							}
						}
						if (DecodeAxes.U && buString.ReadStringValue(Chars.U, text, ref gCodePoint.Positions.U))
						{
							if (gCodePoint.Positions.U > MaxCoordinates.U)
							{
								MaxCoordinates.U = gCodePoint.Positions.U;
							}
							if (gCodePoint.Positions.U < MinCoordinates.U)
							{
								MinCoordinates.U = gCodePoint.Positions.U;
							}
						}
						if (DecodeAxes.V && buString.ReadStringValue(Chars.V, text, ref gCodePoint.Positions.V))
						{
							if (gCodePoint.Positions.V > MaxCoordinates.V)
							{
								MaxCoordinates.V = gCodePoint.Positions.V;
							}
							if (gCodePoint.Positions.V < MinCoordinates.V)
							{
								MinCoordinates.V = gCodePoint.Positions.V;
							}
						}
						if (DecodeAxes.W && buString.ReadStringValue(Chars.W, text, ref gCodePoint.Positions.W))
						{
							if (gCodePoint.Positions.W > MaxCoordinates.W)
							{
								MaxCoordinates.W = gCodePoint.Positions.W;
							}
							if (gCodePoint.Positions.W < MinCoordinates.W)
							{
								MinCoordinates.W = gCodePoint.Positions.W;
							}
						}
						buString.ReadStringValue(Chars.R, text, ref gCodePoint.R);
						buString.ReadStringValue(Chars.I, text, ref gCodePoint.IJKValue.I);
						buString.ReadStringValue(Chars.J, text, ref gCodePoint.IJKValue.J);
						buString.ReadStringValue(Chars.K, text, ref gCodePoint.IJKValue.K);
						buString.ReadStringValue("F", text, ref Value);
						gCodePoint.Feed = Value;
						if (flag)
						{
							if (gCodePoint.CodeType == 0)
							{
								gCodePoint.Entity = new geoLine(new Pnt3D(pnt9D.X, pnt9D.Y, pnt9D.Z), new Pnt3D(gCodePoint.Positions.X, gCodePoint.Positions.Y, gCodePoint.Positions.Z));
								gCodePoint.Entity.Color = Color.Red;
							}
							if (gCodePoint.CodeType == 1)
							{
								gCodePoint.Entity = new geoLine(new Pnt3D(pnt9D.X, pnt9D.Y, pnt9D.Z), new Pnt3D(gCodePoint.Positions.X, gCodePoint.Positions.Y, gCodePoint.Positions.Z));
								gCodePoint.Entity.Color = Color.Black;
							}
							if (gCodePoint.CodeType == 2)
							{
								Pnt3D ArcCenter = new Pnt3D();
								double ArcSA = 0.0;
								double ArcEA = 0.0;
								double num2 = 0.0;
								Pnt3D pnt3D = new Pnt3D(pnt9D.X, pnt9D.Y, pnt9D.Z);
								Pnt3D pnt3D2 = new Pnt3D(gCodePoint.Positions.X, gCodePoint.Positions.Y, gCodePoint.Positions.Z);
								if (gCodePoint.R > 0.0)
								{
									buVector_0.ArcWithTwoPointAndRadius(pnt3D, pnt3D2, Math.Abs(gCodePoint.R), CW: true, new WorkPlane(), ref ArcCenter, ref ArcSA, ref ArcEA);
								}
								if (gCodePoint.R < 0.0)
								{
									buVector_0.ArcWithTwoPointAndRadius(pnt3D, pnt3D2, Math.Abs(gCodePoint.R), CW: true, new WorkPlane(), ref ArcCenter, ref ArcSA, ref ArcEA);
									if (ArcEA - ArcSA < 180.0)
									{
										double num3 = ArcSA;
										ArcSA = ArcEA;
										ArcEA = num3;
									}
									if (ArcSA > ArcEA)
									{
										ArcEA += 360.0;
									}
								}
								num2 = Math.Abs(gCodePoint.R);
								if ((gCodePoint.IJKValue.I != 0.0) | (gCodePoint.IJKValue.J != 0.0) | (gCodePoint.IJKValue.K != 0.0))
								{
									buVector_0.ArcWithIJK(pnt3D, pnt3D2, gCodePoint.IJKValue.I, gCodePoint.IJKValue.J, gCodePoint.IJKValue.K, gCodePoint.CodeType, ref ArcCenter, ref num2, ref ArcSA, ref ArcEA);
								}
								List<Pnt3D> Vertices = new List<Pnt3D>();
								buVector_0.ArcWithCenter(ArcCenter, num2, ArcSA, ArcEA, new WorkPlane(), buSystem.EntitiesResolution, ref Vertices);
								gCodePoint.Entity = new geoPolyline(Vertices);
								gCodePoint.Entity.Color = Color.Black;
							}
							if (gCodePoint.CodeType == 3)
							{
								Pnt3D ArcCenter2 = new Pnt3D();
								double ArcSA2 = 0.0;
								double ArcEA2 = 0.0;
								double num4 = 0.0;
								Pnt3D pnt3D3 = new Pnt3D(pnt9D.X, pnt9D.Y, pnt9D.Z);
								Pnt3D pnt3D4 = new Pnt3D(gCodePoint.Positions.X, gCodePoint.Positions.Y, gCodePoint.Positions.Z);
								if (gCodePoint.R > 0.0)
								{
									buVector_0.ArcWithTwoPointAndRadius(pnt3D3, pnt3D4, Math.Abs(gCodePoint.R), CW: false, new WorkPlane(), ref ArcCenter2, ref ArcSA2, ref ArcEA2);
								}
								if (gCodePoint.R < 0.0)
								{
									buVector_0.ArcWithTwoPointAndRadius(pnt3D3, pnt3D4, Math.Abs(gCodePoint.R), CW: false, new WorkPlane(), ref ArcCenter2, ref ArcSA2, ref ArcEA2);
									if (ArcEA2 - ArcSA2 < 180.0)
									{
										double num5 = ArcSA2;
										ArcSA2 = ArcEA2;
										ArcEA2 = num5;
									}
									if (ArcSA2 > ArcEA2)
									{
										ArcEA2 += 360.0;
									}
								}
								num4 = Math.Abs(gCodePoint.R);
								if ((gCodePoint.IJKValue.I != 0.0) | (gCodePoint.IJKValue.J != 0.0) | (gCodePoint.IJKValue.K != 0.0))
								{
									buVector_0.ArcWithIJK(pnt3D3, pnt3D4, gCodePoint.IJKValue.I, gCodePoint.IJKValue.J, gCodePoint.IJKValue.K, gCodePoint.CodeType, ref ArcCenter2, ref num4, ref ArcSA2, ref ArcEA2);
								}
								List<Pnt3D> Vertices2 = new List<Pnt3D>();
								buVector_0.ArcWithCenter(ArcCenter2, num4, ArcSA2, ArcEA2, new WorkPlane(), buSystem.EntitiesResolution, ref Vertices2);
								gCodePoint.Entity = new geoPolyline(Vertices2);
								gCodePoint.Entity.Color = Color.Black;
							}
						}
						if ((gCodePoint.CodeType >= 0) & (gCodePoint.CodeType <= 3))
						{
							flag = true;
						}
					}
					if (gCodePoint.isMCode && buString.ReadStringValue(Chars.M, text, ref gCodePoint.MValue))
					{
						flag2 = true;
						gCodePoint.CodeType = Convert.ToInt32(gCodePoint.MValue);
						buString.ReadStringValue(Chars.X, text, ref gCodePoint.Positions.X);
					}
					if (gCodePoint.isTCode && buString.ReadStringValue(Chars.T, text, ref gCodePoint.TValue))
					{
						flag2 = true;
						gCodePoint.CodeType = Convert.ToInt32(gCodePoint.TValue);
						gCodePoint.Tool = new ToolBase();
						gCodePoint.Tool.Data.No = Convert.ToInt32(gCodePoint.TValue);
					}
					if ((gCodePoint.isGCode & ((gCodePoint.CodeType >= 0) & (gCodePoint.CodeType <= 3))) && flag)
					{
						GCodeGraphPoint gCodeGraphPoint = new GCodeGraphPoint();
						gCodeGraphPoint.Positions = new Pnt9D(gCodePoint.Positions.X, gCodePoint.Positions.Y, gCodePoint.Positions.Z);
						gCodeGraphPoint.CodeType = gCodePoint.CodeType;
						gCodeGraphPoint.Radius = gCodePoint.R;
						gCodeGraphPoint.IJKValues = new IJK(gCodePoint.IJKValue);
						Points.Add(gCodeGraphPoint);
					}
					if (flag2)
					{
						GCodeList.Add(gCodePoint);
						pnt9D = new Pnt9D(gCodePoint.Positions);
					}
					isGCode = gCodePoint.isGCode;
					codeType = gCodePoint.CodeType;
					if (((MaxLineCount > 0) & (i > MaxLineCount)) && i > 0)
					{
						i = GCodes.Count;
					}
				}
				if (Points.Count <= 1)
				{
					return;
				}
				buVector_0.CheckDuplicatedPointsWithPrevious(ref Points);
				if (Points.Count > 1 && Points[0].CodeType == 0 && ((Points[0].Positions.X == 0.0) & (Points[0].Positions.Y == 0.0)) && Points[0].Positions.Z == Points[1].Positions.Z)
				{
					Points.RemoveAt(0);
				}
				new Pnt3D();
				for (int j = 1; j <= Points.Count - 1; j++)
				{
					Pnt3D pnt3D5 = new Pnt3D(Points[j - 1].Positions.X, Points[j - 1].Positions.Y, Points[j - 1].Positions.Z);
					Pnt3D pnt3D6 = new Pnt3D(Points[j].Positions.X, Points[j].Positions.Y, Points[j].Positions.Z);
					if (Pnt3D.Equal(pnt3D5, pnt3D6))
					{
						continue;
					}
					if (Points[j].CodeType == 0)
					{
						if (CopiedPnt.Count > 1)
						{
							ePolyline item = new ePolyline(CopiedPnt);
							EntitiesG1.Add(item);
							CopiedPnt = new List<Pnt3D>();
						}
						eLine item2 = new eLine(pnt3D5, pnt3D6);
						if (!Pnt3D.EqualXY(pnt3D5, pnt3D6))
						{
							EntitiesG0.Add(item2);
						}
						else
						{
							if (pnt3D5.Z > pnt3D6.Z)
							{
								EntitiesPlunge.Add(item2);
							}
							if (pnt3D5.Z < pnt3D6.Z)
							{
								EntitiesLeave.Add(item2);
							}
						}
					}
					if (Points[j].CodeType == 1)
					{
						if (Pnt3D.EqualXY(pnt3D5, pnt3D6))
						{
							eLine item3 = new eLine(pnt3D5, pnt3D6);
							if (pnt3D5.Z > pnt3D6.Z)
							{
								EntitiesPlunge.Add(item3);
							}
							if (pnt3D5.Z < pnt3D6.Z)
							{
								EntitiesLeave.Add(item3);
							}
						}
						if (Points[j - 1].CodeType == 0)
						{
							CopiedPnt.Add(pnt3D5);
						}
						CopiedPnt.Add(pnt3D6);
					}
					if (Points[j].CodeType == 2)
					{
						Pnt3D ArcCenter3 = new Pnt3D();
						double ArcSA3 = 0.0;
						double ArcEA3 = 0.0;
						double num6 = 0.0;
						if (Points[j].Radius > 0.0)
						{
							buVector_0.ArcWithTwoPointAndRadius(pnt3D5, pnt3D6, Math.Abs(Points[j].Radius), CW: true, new WorkPlane(), ref ArcCenter3, ref ArcSA3, ref ArcEA3);
							if (pnt3D5.Z == pnt3D6.Z)
							{
								ArcCenter3.Z = pnt3D5.Z;
							}
						}
						if (Points[j].Radius < 0.0)
						{
							buVector_0.ArcWithTwoPointAndRadius(pnt3D5, pnt3D6, Math.Abs(Points[j].Radius), CW: true, new WorkPlane(), ref ArcCenter3, ref ArcSA3, ref ArcEA3);
							if (ArcEA3 - ArcSA3 < 180.0)
							{
								double num7 = ArcSA3;
								ArcSA3 = ArcEA3;
								ArcEA3 = num7;
							}
							if (ArcSA3 > ArcEA3)
							{
								ArcEA3 += 360.0;
							}
							if (pnt3D5.Z == pnt3D6.Z)
							{
								ArcCenter3.Z = pnt3D5.Z;
							}
						}
						num6 = Math.Abs(Points[j].Radius);
						if ((Points[j].IJKValues.I != 0.0) | (Points[j].IJKValues.J != 0.0) | (Points[j].IJKValues.K != 0.0))
						{
							buVector_0.ArcWithIJK(pnt3D5, pnt3D6, Points[j].IJKValues.I, Points[j].IJKValues.J, Points[j].IJKValues.K, Points[j].CodeType, ref ArcCenter3, ref num6, ref ArcSA3, ref ArcEA3);
							if (pnt3D5.Z == pnt3D6.Z)
							{
								ArcCenter3.Z = pnt3D5.Z;
							}
						}
						List<Pnt3D> Vertices3 = new List<Pnt3D>();
						buVector_0.ArcWithCenter(ArcCenter3, num6, ArcSA3, ArcEA3, new WorkPlane(), buSystem.EntitiesResolution, ref Vertices3);
						Vertices3.Reverse();
						Pnt3D.Add(Vertices3, ref CopiedPnt);
					}
					if (Points[j].CodeType == 3)
					{
						Pnt3D ArcCenter4 = new Pnt3D();
						double ArcSA4 = 0.0;
						double ArcEA4 = 0.0;
						double num8 = 0.0;
						if (Points[j].Radius > 0.0)
						{
							buVector_0.ArcWithTwoPointAndRadius(pnt3D5, pnt3D6, Math.Abs(Points[j].Radius), CW: false, new WorkPlane(), ref ArcCenter4, ref ArcSA4, ref ArcEA4);
							if (pnt3D5.Z == pnt3D6.Z)
							{
								ArcCenter4.Z = pnt3D5.Z;
							}
						}
						if (Points[j].Radius < 0.0)
						{
							buVector_0.ArcWithTwoPointAndRadius(pnt3D5, pnt3D6, Math.Abs(Points[j].Radius), CW: false, new WorkPlane(), ref ArcCenter4, ref ArcSA4, ref ArcEA4);
							if (ArcEA4 - ArcSA4 < 180.0)
							{
								double num9 = ArcSA4;
								ArcSA4 = ArcEA4;
								ArcEA4 = num9;
							}
							if (ArcSA4 > ArcEA4)
							{
								ArcEA4 += 360.0;
							}
							if (pnt3D5.Z == pnt3D6.Z)
							{
								ArcCenter4.Z = pnt3D5.Z;
							}
						}
						num8 = Math.Abs(Points[j].Radius);
						if ((Points[j].IJKValues.I != 0.0) | (Points[j].IJKValues.J != 0.0) | (Points[j].IJKValues.K != 0.0))
						{
							buVector_0.ArcWithIJK(pnt3D5, pnt3D6, Points[j].IJKValues.I, Points[j].IJKValues.J, Points[j].IJKValues.K, Points[j].CodeType, ref ArcCenter4, ref num8, ref ArcSA4, ref ArcEA4);
							if (pnt3D5.Z == pnt3D6.Z)
							{
								ArcCenter4.Z = pnt3D5.Z;
							}
						}
						List<Pnt3D> Vertices4 = new List<Pnt3D>();
						buVector_0.ArcWithCenter(ArcCenter4, num8, ArcSA4, ArcEA4, new WorkPlane(), buSystem.EntitiesResolution, ref Vertices4);
						Pnt3D.Add(Vertices4, ref CopiedPnt);
					}
					new Pnt3D(pnt3D6);
				}
				if (CopiedPnt.Count > 1)
				{
					ePolyline item4 = new ePolyline(CopiedPnt);
					EntitiesG1.Add(item4);
					CopiedPnt = new List<Pnt3D>();
				}
			}
			catch (Exception mSException)
			{
				string text2 = GCodes.Count.ToString();
				buLog.addLog(text2, "Not Ok", MethodBase.GetCurrentMethod().Name);
				buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text2);
			}
		}
	}

	public class Dxf
	{
		public Pnt3D MaxPnt = new Pnt3D();

		public Pnt3D MinPnt = new Pnt3D();

		internal double double_0;

		internal double double_1;

		private string string_0 = "SEO-DXF.Ver:1.2.0.1-1906ZG";

		public Color[] ColorCode = new Color[256];

		public string Key;

		public bool ArcToLine;

		public double ArcToLineLength;

		public string LayerName;

		public Color LayerColor;

		public float PointThicknessOffset = 1f;

		public bool TextToUpperCase = false;

		public bool OnlyPoints = false;

		public bool ArcToLineWithRadiusLimitEnable = true;

		public double ArcToLineRadiusLimit = 0.9;

		public double ArcToLineWithRadiusType = 0.0;

		public Pnt3D BoxSizeMax = new Pnt3D();

		public Pnt3D BoxSizeMin = new Pnt3D();

		public int LayerType;

		public string LayerFilterChars = "";

		public List<DxfText> DXFText = new List<DxfText>();

		public Vec3D UCSOffset = new Vec3D();

		public Color ViewportBackColor = Color.Yellow;

		public entityBSplineType SplineType = entityBSplineType.BSplineQuadratic;

		internal double double_2 = 0.001;

		private bool bool_0 = false;

		private bool bool_1 = true;

		private bool bool_2 = true;

		public Dxf L_Data = null;

		public List<eEntities> BlockEntityList = new List<eEntities>();

		internal NumberFormatInfo numberFormatInfo_0 = new CultureInfo("en-US", useUserOverride: false).NumberFormat;

		internal List<string> list_0 = new List<string>();

		private CultureInfo cultureInfo_0 = new CultureInfo("en-US", useUserOverride: false);

		public Dxf()
		{
			if (!buVector.smethod_0("Dxf"))
			{
				throw new RegisterException("Dxf");
			}
			ColorCode[0] = Color.Black;
			ColorCode[1] = Color.DarkGray;
			ColorCode[2] = Color.Yellow;
			ColorCode[3] = Color.Green;
			ColorCode[4] = Color.Blue;
			ColorCode[5] = Color.Cyan;
			ColorCode[6] = Color.Gray;
			ColorCode[7] = Color.Red;
			ColorCode[8] = Color.Brown;
			ColorCode[9] = Color.Lime;
			ColorCode[10] = Color.Orange;
			ColorCode[11] = Color.Tan;
			ColorCode[12] = Color.LightBlue;
			ColorCode[13] = Color.Magenta;
			ColorCode[14] = Color.Purple;
			ColorCode[15] = Color.Salmon;
			ColorCode[16] = Color.Sienna;
			ColorCode[17] = Color.Thistle;
			ColorCode[18] = Color.Wheat;
			ColorCode[19] = Color.White;
			ColorCode[20] = Color.Turquoise;
		}

		public Dxf(Pnt3D MinP, Pnt3D MaxP)
		{
			if ((buSystem.strIDScale != "IUTvstjutru784gfsbtNYRJGdrebgre75RFSDVCSD-?YT?_?.<+!%+^&GSDGDSGA5&bdfbdrb") | (buSystem.strTest != "AtWR65*-vftyfc74dafqw124fFSTEWFEEVAEARHGFVSDVERGVd89eet98rbFREGRAVRETTBYWFVDetrqVVR") | (buSystem.valCheckFactor != 97245796635758.77) | (buSystem.valMidPointConstant != -598745789953.8955))
			{
				throw new RegisterException("buVector");
			}
			MaxPnt = new Pnt3D(MaxP);
			MinPnt = new Pnt3D(MinP);
			ColorCode[0] = Color.Black;
			ColorCode[1] = Color.Red;
			ColorCode[2] = Color.Yellow;
			ColorCode[3] = Color.Green;
			ColorCode[4] = Color.Blue;
			ColorCode[5] = Color.Cyan;
			ColorCode[6] = Color.Gray;
			ColorCode[7] = Color.Pink;
			ColorCode[8] = Color.Brown;
			ColorCode[9] = Color.Lime;
			ColorCode[10] = Color.Orange;
			ColorCode[11] = Color.Tan;
			ColorCode[12] = Color.LightBlue;
			ColorCode[13] = Color.Magenta;
			ColorCode[14] = Color.Purple;
			ColorCode[15] = Color.Salmon;
			ColorCode[16] = Color.Sienna;
			ColorCode[17] = Color.Thistle;
			ColorCode[18] = Color.Wheat;
			ColorCode[19] = Color.White;
			ColorCode[20] = Color.Turquoise;
		}

		public void WriteDXF(string FileName, List<eEntities> RefEntities)
		{
			try
			{
				TextWriter textWriter = File.CreateText(FileName);
				textWriter.WriteLine("  0");
				textWriter.WriteLine("SECTION");
				textWriter.WriteLine("  2");
				textWriter.WriteLine("HEADER");
				textWriter.WriteLine("  9");
				textWriter.WriteLine("$LIMMIN");
				textWriter.WriteLine(" 10");
				textWriter.WriteLine(MinPnt.X.ToString("f10", cultureInfo_0));
				textWriter.WriteLine(" 20");
				textWriter.WriteLine(MinPnt.Y.ToString("f10", cultureInfo_0));
				textWriter.WriteLine("  9");
				textWriter.WriteLine("$LIMMAX");
				textWriter.WriteLine(" 10");
				textWriter.WriteLine(MaxPnt.X.ToString("f10", cultureInfo_0));
				textWriter.WriteLine(" 20");
				textWriter.WriteLine(MaxPnt.Y.ToString("f10", cultureInfo_0));
				textWriter.WriteLine("  0");
				textWriter.WriteLine("ENDSEC");
				textWriter.WriteLine("  0");
				textWriter.WriteLine("SECTION");
				textWriter.WriteLine("  2");
				textWriter.WriteLine("ENTITIES");
				textWriter.WriteLine("  0");
				for (int i = 0; i <= RefEntities.Count - 1; i++)
				{
					if (RefEntities[i].GetType() == typeof(eLine))
					{
						textWriter.WriteLine("LINE");
						textWriter.WriteLine("  8");
						textWriter.WriteLine("0");
						textWriter.WriteLine(" 62");
						textWriter.WriteLine("13");
						textWriter.WriteLine(" 10");
						textWriter.WriteLine(((eLine)RefEntities[i]).StartPoint.X.ToString("f10", cultureInfo_0));
						textWriter.WriteLine(" 20");
						textWriter.WriteLine(((eLine)RefEntities[i]).StartPoint.Y.ToString("f10", cultureInfo_0));
						textWriter.WriteLine(" 30");
						textWriter.WriteLine(((eLine)RefEntities[i]).StartPoint.Z.ToString("f10", cultureInfo_0));
						textWriter.WriteLine(" 11");
						textWriter.WriteLine(((eLine)RefEntities[i]).EndPoint.X.ToString("f10", cultureInfo_0));
						textWriter.WriteLine(" 21");
						textWriter.WriteLine(((eLine)RefEntities[i]).EndPoint.Y.ToString("f10", cultureInfo_0));
						textWriter.WriteLine(" 31");
						textWriter.WriteLine(((eLine)RefEntities[i]).EndPoint.Z.ToString("f10", cultureInfo_0));
						textWriter.WriteLine("  0");
					}
					if (RefEntities[i].GetType() == typeof(eArc))
					{
						textWriter.WriteLine("ARC");
						textWriter.WriteLine("  8");
						textWriter.WriteLine("0");
						textWriter.WriteLine(" 62");
						textWriter.WriteLine("13");
						textWriter.WriteLine(" 10");
						textWriter.WriteLine(((eArc)RefEntities[i]).CenterPoint.X.ToString("f10", cultureInfo_0));
						textWriter.WriteLine(" 20");
						textWriter.WriteLine(((eArc)RefEntities[i]).CenterPoint.Y.ToString("f10", cultureInfo_0));
						textWriter.WriteLine(" 30");
						textWriter.WriteLine(((eArc)RefEntities[i]).CenterPoint.Z.ToString("f10", cultureInfo_0));
						textWriter.WriteLine(" 40");
						textWriter.WriteLine(((eArc)RefEntities[i]).Radius.ToString("f10", cultureInfo_0));
						textWriter.WriteLine(" 50");
						textWriter.WriteLine(((eArc)RefEntities[i]).StartAngle.ToString("f10", cultureInfo_0));
						textWriter.WriteLine(" 51");
						textWriter.WriteLine(((eArc)RefEntities[i]).EndAngle.ToString("f10", cultureInfo_0));
						textWriter.WriteLine("  0");
					}
					if (RefEntities[i].GetType() == typeof(eCircle))
					{
						textWriter.WriteLine("CIRCLE");
						textWriter.WriteLine("  8");
						textWriter.WriteLine("0");
						textWriter.WriteLine(" 62");
						textWriter.WriteLine("13");
						textWriter.WriteLine(" 10");
						textWriter.WriteLine(((eCircle)RefEntities[i]).CenterPoint.X.ToString("f10", cultureInfo_0));
						textWriter.WriteLine(" 20");
						textWriter.WriteLine(((eCircle)RefEntities[i]).CenterPoint.Y.ToString("f10", cultureInfo_0));
						textWriter.WriteLine(" 30");
						textWriter.WriteLine(((eCircle)RefEntities[i]).CenterPoint.Z.ToString("f10", cultureInfo_0));
						textWriter.WriteLine(" 40");
						textWriter.WriteLine(((eCircle)RefEntities[i]).Radius.ToString("f10", cultureInfo_0));
						textWriter.WriteLine("  0");
					}
					if ((RefEntities[i].GetType() == typeof(ePolyline)) | (RefEntities[i].GetType() == typeof(eBSpline)) | (RefEntities[i].GetType() == typeof(eBezeir)))
					{
						textWriter.WriteLine("POLYLINE");
						textWriter.WriteLine("  8");
						textWriter.WriteLine("0");
						textWriter.WriteLine(" 66");
						textWriter.WriteLine("1");
						textWriter.WriteLine("  70");
						textWriter.WriteLine("0");
						textWriter.WriteLine("  0");
						for (int j = 0; j <= RefEntities[i].Vertice.Count - 1; j++)
						{
							textWriter.WriteLine("VERTEX");
							textWriter.WriteLine("  8");
							textWriter.WriteLine("0");
							textWriter.WriteLine(" 10");
							textWriter.WriteLine(RefEntities[i].Vertice[j].X.ToString("f10", cultureInfo_0));
							textWriter.WriteLine(" 20");
							textWriter.WriteLine(RefEntities[i].Vertice[j].Y.ToString("f10", cultureInfo_0));
							textWriter.WriteLine(" 30");
							textWriter.WriteLine(RefEntities[i].Vertice[j].Z.ToString("f10", cultureInfo_0));
							textWriter.WriteLine("  0");
						}
						textWriter.WriteLine("SEQEND");
						textWriter.WriteLine("  0");
					}
				}
				textWriter.WriteLine("ENDSEC");
				textWriter.WriteLine("  0");
				textWriter.WriteLine("EOF");
				textWriter.Close();
			}
			catch (Exception mSException)
			{
				string text = "FileName: " + FileName.ToString();
				buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
				buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
			}
		}

		public void ReadDXF(string FileName, ref List<eEntities> RefEntities, ref List<LayerBase> Layers)
		{
			try
			{
				bool flag = false;
				bool flag2 = false;
				int num = 0;
				int num2 = 0;
				float num3 = 1f;
				int num4 = 1;
				int num5 = 0;
				int num6 = 0;
				int num7 = 0;
				int num8 = 0;
				eEntities eEntities2 = null;
				Pnt3D pnt3D = new Pnt3D();
				Pnt3D pnt3D2 = new Pnt3D();
				Pnt3D pnt3D3 = new Pnt3D();
				Pnt3D pnt3D4 = new Pnt3D();
				Color color_ = Color.Black;
				float num9 = 1f;
				bool flag3 = false;
				bool flag4 = true;
				bool flag5 = false;
				double double_ = 0.0;
				double double_2 = 0.0;
				double double_3 = 0.0;
				double num10 = 0.0;
				double double_4 = 0.0;
				double double_5 = 0.0;
				float float_ = 1f;
				double double_6 = 0.0;
				double double_7 = 0.0;
				double double_8 = 0.0;
				double double_9 = 0.0;
				double double_10 = 0.0;
				double z = 0.0;
				double num11 = 1.0;
				double num12 = 1.0;
				double double_11 = 0.0;
				string string_ = "";
				List<Pnt3D> list = new List<Pnt3D>();
				new List<double>();
				new List<double>();
				new List<double>();
				List<double> list_ = new List<double>();
				List<double> list2 = new List<double>();
				List<double> list_2 = new List<double>();
				List<double> list_3 = new List<double>();
				List<double> list_4 = new List<double>();
				List<double> list_5 = new List<double>();
				List<double> list_6 = new List<double>();
				List<double> list_7 = new List<double>();
				List<double> list_8 = new List<double>();
				List<int> list_9 = new List<int>();
				List<string> list_10 = new List<string>();
				List<int> list_11 = new List<int>();
				numberFormatInfo_0.NumberDecimalSeparator = ".";
				num = 0;
				string string_2 = "";
				num3 = 1f;
				this.double_2 = 0.0001;
				num2 = -1;
				num4 = LayerFilterChars.Length;
				FileInfo fileInfo = new FileInfo(FileName);
				list_0 = new List<string>();
				if (fileInfo.Exists)
				{
					list_0.AddRange(File.ReadLines(fileInfo.FullName, Encoding.GetEncoding(1254)).ToList());
					num = list_0.Count;
				}
				RefEntities = new List<eEntities>();
				BlockEntityList = new List<eEntities>();
				Layers.Clear();
				bool flag6 = false;
				string tag = "";
				new List<double>();
				new List<double>();
				new List<double>();
				new List<double>();
				new List<string>();
				new List<string>();
				DXFText.Clear();
				for (int i = 1; i <= num - 1; i++)
				{
					if (list_0[i] == "ENTITIES")
					{
						flag2 = true;
					}
					if (list_0[i] == "$UCSORG")
					{
						UCSOffset.X = Class156.smethod_256(this, list_0[i + 2]);
						UCSOffset.Y = Class156.smethod_256(this, list_0[i + 4]);
						UCSOffset.Z = Class156.smethod_256(this, list_0[i + 6]);
					}
					if (list_0[i] == "$EXTMIN")
					{
						pnt3D.X = Class156.smethod_256(this, list_0[i + 2]);
						pnt3D.Y = Class156.smethod_256(this, list_0[i + 4]);
					}
					if (list_0[i] == "$EXTMAX")
					{
						pnt3D2.X = Class156.smethod_256(this, list_0[i + 2]);
						pnt3D2.Y = Class156.smethod_256(this, list_0[i + 4]);
					}
					if (list_0[i] == "BLOCK")
					{
						flag6 = true;
						flag = true;
					}
					if (list_0[i] == "ENDBLK")
					{
						flag = false;
					}
					if (flag && !flag2 && flag6 && list_0[i] == "  2")
					{
						flag6 = false;
						tag = list_0[i + 1];
					}
					if (list_0[i] == "LAYER")
					{
						LayerBase layerBase_ = new LayerBase();
						Color color_2 = Color.Black;
						flag3 = Class156.smethod_93(ref color_2, i, this, ref layerBase_);
						layerBase_.LayerColor = color_2;
						if (layerBase_.LayerColor == ViewportBackColor)
						{
							layerBase_.LayerColor = buImage.InvertColor(layerBase_.LayerColor);
						}
						if (layerBase_.Name.Length > 0)
						{
							Layers.Add(layerBase_);
						}
					}
					if ((list_0[i] == "LINE") & !OnlyPoints)
					{
						if (!(flag3 = Class156.smethod_222(ref z, ref double_6, this, ref double_7, ref color_, ref double_9, ref string_2, ref double_8, i, ref double_10)) && !(flag3 = Class156.smethod_79(ref double_8, ref double_7, this, ref z, ref color_, i, ref string_2, ref double_9, ref double_6, ref double_10)))
						{
							flag3 = Class156.smethod_43(i, ref color_, ref z, this, ref double_9, ref double_7, ref string_2, ref double_10, ref double_6, ref double_8);
						}
						num2++;
						num9 = num3;
						if (color_ == ViewportBackColor)
						{
							color_ = buImage.InvertColor(color_);
						}
						eEntities2 = new eLine(new Pnt3D(double_6, double_7, double_8), new Pnt3D(double_9, double_10, z), num9, color_);
						for (int j = 0; j <= Layers.Count - 1; j++)
						{
							if (Layers[j].Name == string_2)
							{
								eEntities2.LayerIndex = j;
							}
						}
						flag4 = true;
						if (((LayerType == 1) & (string_2.Length >= num4) & (Layers.Count > 0)) && Layers[Layers.Count - 1].Name.Substring(0, num4) != LayerFilterChars)
						{
							flag4 = false;
						}
						if (flag4)
						{
							if (!flag && flag2)
							{
								num5++;
								RefEntities.Add(eEntities2);
							}
							if (flag && !flag2)
							{
								num5++;
								eEntities2.Tag = tag;
								BlockEntityList.Add(eEntities2);
							}
						}
					}
					if ((list_0[i] == "LWPOLYLINE") & !OnlyPoints)
					{
						List<eEntities> list3 = new List<eEntities>();
						Class156.smethod_221(ref float_, this, i, ref color_, ref string_2, ref list3, ref flag5);
						for (int k = 0; k <= list3.Count - 1; k++)
						{
							eEntities copiedEnt = new eEntities();
							eEntities.CopyEntity(list3[k], ref copiedEnt);
							if (copiedEnt.Vertice.Count > 0)
							{
								RefEntities.Add(copiedEnt);
							}
						}
					}
					if ((list_0[i] == "SPLINE") & !OnlyPoints)
					{
						list = new List<Pnt3D>();
						List<double> list_12 = new List<double>();
						double num13 = 1.0;
						Class156.smethod_220(ref float_, ref list, this, ref flag5, ref list_12, ref color_, i, ref num13, ref string_2);
						if (color_ == ViewportBackColor)
						{
							color_ = buImage.InvertColor(color_);
						}
						if (list.Count > 0)
						{
							eEntities2 = new eBSpline(list, float_, color_, Closed_: false, SplineType);
							for (int l = 0; l <= Layers.Count - 1; l++)
							{
								if (Layers[l].Name == string_2)
								{
									eEntities2.LayerIndex = l;
								}
							}
							num2++;
							flag4 = true;
							if (((LayerType == 1) & (string_2.Length >= num4) & (Layers.Count > 0)) && Layers[Layers.Count - 1].Name.Substring(0, num4) != LayerFilterChars)
							{
								flag4 = false;
							}
							if (flag4)
							{
								if (!flag && flag2)
								{
									num8++;
									RefEntities.Add(eEntities2);
								}
								if (flag && !flag2)
								{
									eEntities2.Tag = tag;
									BlockEntityList.Add(eEntities2);
								}
							}
						}
					}
					if ((list_0[i] == "CIRCLE") & !OnlyPoints)
					{
						Class156.smethod_254(ref color_, ref double_, ref string_2, i, this, ref double_2, ref double_5);
						num2++;
						if (color_ == ViewportBackColor)
						{
							color_ = buImage.InvertColor(color_);
						}
						eEntities2 = new eCircle(new Pnt3D(double_, double_2, 0.0), double_5, new WorkPlane(), num9, color_);
						flag4 = true;
						if (ArcToLine)
						{
							list = new List<Pnt3D>();
							Class156.smethod_104(360.0, ArcToLineLength, ref list, this, double_, double_5, 0.0, double_2);
							eEntities2 = new ePolyline(list, num9, color_);
						}
						for (int m = 0; m <= Layers.Count - 1; m++)
						{
							if (Layers[m].Name == string_2)
							{
								eEntities2.LayerIndex = m;
							}
						}
						if (((LayerType == 1) & (string_2.Length >= num4) & (Layers.Count > 0)) && Layers[Layers.Count - 1].Name.Substring(0, num4) != LayerFilterChars)
						{
							flag4 = false;
						}
						if (flag4)
						{
							num6++;
							if (!flag && flag2 && eEntities2.Vertice.Count > 0)
							{
								RefEntities.Add(eEntities2);
							}
							if (flag && !flag2)
							{
								num5++;
								eEntities2.Tag = tag;
								BlockEntityList.Add(eEntities2);
							}
						}
					}
					if ((list_0[i] == "ARC") & !OnlyPoints)
					{
						Vec3D vec3D_ = new Vec3D(0.0, 0.0, 1.0);
						if (!(flag3 = Class156.smethod_206(ref double_4, ref double_5, ref num10, this, ref color_, ref string_2, ref vec3D_, ref double_2, ref double_3, ref double_, i)))
						{
							flag3 = Class156.smethod_250(ref double_2, i, ref string_2, ref num10, ref color_, this, ref double_, ref double_4, ref double_5);
						}
						num2++;
						if (color_ == ViewportBackColor)
						{
							color_ = buImage.InvertColor(color_);
						}
						WorkPlane plane = new WorkPlane();
						if (vec3D_.X != 0.0)
						{
							plane = new WorkPlane(planeType.YZ, (int)vec3D_.X);
							double num14 = double_;
							double num15 = double_2;
							double num16 = double_3;
							double_2 = num14;
							double_3 = num15;
							double_ = num16;
							if (vec3D_.X < 0.0)
							{
								num10 -= 90.0;
								double_4 -= 90.0;
								double_ *= -1.0;
								double_2 *= -1.0;
								double_3 *= 1.0;
							}
						}
						if (vec3D_.Y != 0.0)
						{
							plane = new WorkPlane(planeType.XZ, (int)vec3D_.Y);
						}
						eEntities2 = new eArc(new Pnt3D(double_, double_2, double_3), double_5, num10, double_4, plane, num9, color_);
						if (vec3D_.Z == -1.0)
						{
							buAppCalc.cVector.Mirror(new Pnt3D(0.0, double_2, 0.0), new Pnt3D(0.0, 10.0, 0.0), new WorkPlane(), 0.0, ref eEntities2);
						}
						if (ArcToLine)
						{
							list = new List<Pnt3D>();
							Class156.smethod_104(double_4, ArcToLineLength, ref list, this, double_, double_5, num10, double_2);
							eEntities2 = new ePolyline(list, num9, color_);
						}
						for (int n = 0; n <= Layers.Count - 1; n++)
						{
							if (Layers[n].Name == string_2)
							{
								eEntities2.LayerIndex = n;
							}
						}
						flag4 = true;
						if (((LayerType == 1) & (string_2.Length >= num4) & (Layers.Count > 0)) && Layers.Count > 0 && Layers[Layers.Count - 1].Name.Substring(0, num4) != LayerFilterChars)
						{
							flag4 = false;
						}
						if (flag4)
						{
							if (!flag && flag2)
							{
								num7++;
								if (eEntities2.Vertice.Count > 0)
								{
									double num17 = ((eArc)eEntities2).EndAngle - ((eArc)eEntities2).StartAngle;
									double num18 = 0.0;
									if (!(num17 > 180.0))
									{
										RefEntities.Add(eEntities2);
									}
									else
									{
										num18 = (((eArc)eEntities2).EndAngle + ((eArc)eEntities2).StartAngle) / 2.0;
										eEntities2 = new eArc(new Pnt3D(double_, double_2, 0.0), double_5, num10, num18, new WorkPlane(), num9, color_);
										RefEntities.Add(eEntities2);
										if (num18 > 360.0 && double_4 > 360.0)
										{
											num18 -= 360.0;
											double_4 -= 360.0;
										}
										eEntities2 = new eArc(new Pnt3D(double_, double_2, 0.0), double_5, num18, double_4, new WorkPlane(), num9, color_);
										RefEntities.Add(eEntities2);
									}
								}
							}
							if (flag && !flag2)
							{
								num7++;
								eEntities2.Tag = tag;
								if (eEntities2.Vertice.Count > 0)
								{
									BlockEntityList.Add(eEntities2);
								}
							}
						}
					}
					if ((list_0[i] == "POLYLINE") & !OnlyPoints)
					{
						Class156.smethod_82(ref list2, ref list_9, this, ref list_4, ref list_2, ref list_11, ref list_, ref list_8, ref list_3, ref list_10, i, ref list_7, ref list_5, ref list_6);
						if (list_11.Count > 0)
						{
							bool flag7 = true;
							for (int num19 = 0; num19 <= list_11.Count - 1; num19++)
							{
								if (list_11[num19] != 1)
								{
									flag7 = false;
									num19 = list_11.Count + 1;
								}
							}
							if (color_ == ViewportBackColor)
							{
								color_ = buImage.InvertColor(color_);
							}
							if (flag7)
							{
								List<Pnt3D> list4 = new List<Pnt3D>();
								for (int num20 = 0; num20 <= list_.Count - 1; num20++)
								{
									list4.Add(new Pnt3D(list_[num20], list2[num20]));
								}
								list4.Add(new Pnt3D(list_2[list_2.Count - 1], list_3[list_3.Count - 1]));
								eEntities2 = new ePolyline(list4, num9, color_);
								if (list4.Count == 2 && buCompare.EQ(list4[0], list4[1]))
								{
									eEntities2 = new ePoint(new Pnt3D(list4[0]), num9 + PointThicknessOffset, color_);
								}
								for (int num21 = 0; num21 <= Layers.Count - 1; num21++)
								{
									for (int num22 = 0; num22 <= list_10.Count - 1; num22++)
									{
										if (Layers[num21].Name == list_10[num22])
										{
											eEntities2.LayerIndex = num21;
										}
									}
								}
								if (!flag2)
								{
									num5++;
									eEntities2.Tag = tag;
									BlockEntityList.Add(eEntities2);
								}
								else
								{
									RefEntities.Add(eEntities2);
								}
							}
							if (!flag7)
							{
								for (int num23 = 0; num23 <= list_11.Count - 1; num23++)
								{
									if (list_11[num23] == 10)
									{
										eEntities2 = new ePoint(new Pnt3D(list_[num23], list2[num23], 0.0), num9 + PointThicknessOffset, color_);
										for (int num24 = 0; num24 <= Layers.Count - 1; num24++)
										{
											for (int num25 = 0; num25 <= list_10.Count - 1; num25++)
											{
												if (Layers[num24].Name == list_10[num25])
												{
													eEntities2.LayerIndex = num24;
												}
											}
										}
										if (!flag2)
										{
											num5++;
											eEntities2.Tag = tag;
											BlockEntityList.Add(eEntities2);
										}
										else
										{
											RefEntities.Add(eEntities2);
										}
									}
									if (list_11[num23] == 1)
									{
										eEntities2 = new eLine(new Pnt3D(list_[num23], list2[num23], 0.0), new Pnt3D(list_2[num23], list_3[num23], 0.0), num9, color_);
										for (int num26 = 0; num26 <= Layers.Count - 1; num26++)
										{
											for (int num27 = 0; num27 <= list_10.Count - 1; num27++)
											{
												if (Layers[num26].Name == list_10[num27])
												{
													eEntities2.LayerIndex = num26;
												}
											}
										}
										if (!flag2)
										{
											num5++;
											eEntities2.Tag = tag;
											BlockEntityList.Add(eEntities2);
										}
										else
										{
											num5++;
											RefEntities.Add(eEntities2);
										}
									}
									if (list_11[num23] != 3)
									{
										continue;
									}
									eEntities2 = new eArc(new Pnt3D(list_4[num23], list_5[num23], 0.0), list_6[num23], list_7[num23], list_8[num23], new WorkPlane(), num9, color_);
									for (int num28 = 0; num28 <= Layers.Count - 1; num28++)
									{
										for (int num29 = 0; num29 <= list_10.Count - 1; num29++)
										{
											if (Layers[num28].Name == list_10[num29])
											{
												eEntities2.LayerIndex = num28;
											}
										}
									}
									if (ArcToLine)
									{
										list = new List<Pnt3D>();
										double num30 = list_4[num23];
										double double_12 = list_5[num23];
										double double_13 = list_6[num23];
										double double_14 = list_7[num23];
										double num31 = list_8[num23];
										double arcToLineLength = ArcToLineLength;
										Class156.smethod_104(num31, arcToLineLength, ref list, this, num30, double_13, double_14, double_12);
									}
									if (!flag2)
									{
										num7++;
										eEntities2.Tag = tag;
										BlockEntityList.Add(eEntities2);
									}
									else
									{
										num7++;
										RefEntities.Add(eEntities2);
									}
								}
							}
						}
					}
					if ((list_0[i] == "INSERT" && !flag && flag2) & !OnlyPoints)
					{
						double num32 = 0.0;
						double num33 = 0.0;
						Class156.smethod_56(ref num12, ref string_2, ref double_6, ref num11, i, ref string_, ref double_8, ref double_7, this, ref double_11, ref color_);
						if (color_ == ViewportBackColor)
						{
							color_ = buImage.InvertColor(color_);
						}
						if (BlockEntityList.Count > 0)
						{
							for (int num34 = 0; num34 <= BlockEntityList.Count - 1; num34++)
							{
								if (!(BlockEntityList[num34].Tag == string_))
								{
									continue;
								}
								if (BlockEntityList[num34].GetType() == typeof(eLine))
								{
									pnt3D3 = new Pnt3D(((eLine)BlockEntityList[num34]).StartPoint);
									pnt3D4 = new Pnt3D(((eLine)BlockEntityList[num34]).EndPoint);
									pnt3D3.X *= num11;
									pnt3D3.Y *= num12;
									pnt3D4.X *= num11;
									pnt3D4.Y *= num12;
									num32 = Math.Sqrt(pnt3D3.X * pnt3D3.X + pnt3D3.Y * pnt3D3.Y);
									num33 = Class156.smethod_149(this, pnt3D3.X, pnt3D3.Y, 0.0, 0.0);
									num33 += double_11;
									pnt3D3.X = num32 * Math.Cos(Class156.smethod_204(this, num33)) + double_6;
									pnt3D3.Y = num32 * Math.Sin(Class156.smethod_204(this, num33)) + double_7;
									num32 = Math.Sqrt(pnt3D4.X * pnt3D4.X + pnt3D4.Y * pnt3D4.Y);
									num33 = Class156.smethod_149(this, pnt3D4.X, pnt3D4.Y, 0.0, 0.0);
									num33 += double_11;
									pnt3D4.X = num32 * Math.Cos(Class156.smethod_204(this, num33)) + double_6;
									pnt3D4.Y = num32 * Math.Sin(Class156.smethod_204(this, num33)) + double_7;
									eEntities2 = new eLine(pnt3D3, pnt3D4, num9, color_);
									num5++;
									RefEntities.Add(eEntities2);
								}
								if (BlockEntityList[num34].GetType() == typeof(eArc))
								{
									pnt3D3 = new Pnt3D(((eArc)BlockEntityList[num34]).CenterPoint);
									double_5 = ((eArc)BlockEntityList[num34]).Radius;
									num10 = ((eArc)BlockEntityList[num34]).StartAngle;
									double_4 = ((eArc)BlockEntityList[num34]).EndAngle;
									pnt3D3.X *= num11;
									pnt3D3.Y *= num12;
									double_5 *= num11;
									num32 = Math.Sqrt(pnt3D3.X * pnt3D3.X + pnt3D3.Y * pnt3D3.Y);
									num33 = Class156.smethod_149(this, pnt3D3.X, pnt3D3.Y, 0.0, 0.0);
									num33 += double_11;
									pnt3D3.X = num32 * Math.Cos(Class156.smethod_204(this, num33)) + double_6;
									pnt3D3.Y = num32 * Math.Sin(Class156.smethod_204(this, num33)) + double_7;
									num10 += double_11;
									double_4 = num10 + double_11;
									eEntities2 = new eArc(pnt3D3, double_5, num10, double_4, new WorkPlane(), num9, color_);
									num7++;
									RefEntities.Add(eEntities2);
								}
								if (BlockEntityList[num34].GetType() == typeof(ePolyline))
								{
									list = new List<Pnt3D>();
									for (int num35 = 0; num35 < BlockEntityList[num34].Vertice.Count; num35++)
									{
										double_9 = BlockEntityList[num34].Vertice[num35].X * num11;
										double_10 = BlockEntityList[num34].Vertice[num35].Y * num12;
										num32 = Math.Sqrt(double_9 * double_9 + double_10 * double_10);
										num33 = Class156.smethod_149(this, double_9, double_10, 0.0, 0.0);
										num33 += double_11;
										double_9 = num32 * Math.Cos(Class156.smethod_204(this, num33)) + double_6;
										double_10 = num32 * Math.Sin(Class156.smethod_204(this, num33)) + double_7;
										list.Add(new Pnt3D(double_9, double_10));
									}
									eEntities2 = new ePolyline(list, num9, color_);
									num8++;
									RefEntities.Add(eEntities2);
								}
								if (BlockEntityList[num34].GetType() == typeof(ePoint))
								{
									pnt3D3 = new Pnt3D(((ePoint)BlockEntityList[num34]).StartPoint);
									pnt3D3.X += double_6;
									pnt3D3.Y += double_7;
									eEntities2 = new ePoint(pnt3D3, num9, color_);
									eEntities2.geoAngleXY = BlockEntityList[num34].geoAngleXY;
									eEntities2.auxText = BlockEntityList[num34].auxText;
									eEntities2.auxValue = BlockEntityList[num34].auxValue;
									num5++;
									RefEntities.Add(eEntities2);
								}
							}
						}
					}
					if ((list_0[i] == "TEXT") & !OnlyPoints)
					{
						if (color_ == ViewportBackColor)
						{
							color_ = buImage.InvertColor(color_);
						}
						DxfText dxfText = new DxfText();
						ref double rotation = ref dxfText.Rotation;
						ref double height = ref dxfText.Height;
						ref string text = ref dxfText.Text;
						flag3 = Class156.smethod_278(i, ref double_7, ref dxfText.Color, ref double_6, ref dxfText.Layer, this, ref rotation, ref double_8, ref text, ref height);
						dxfText.StartPoint = new Pnt3D(double_6, double_7, double_8);
						num2++;
						if (TextToUpperCase)
						{
							dxfText.Text = dxfText.Text.ToUpper();
						}
						if (flag3)
						{
							DXFText.Add(dxfText);
						}
					}
					if (!(list_0[i] == "POINT"))
					{
						continue;
					}
					double double_15 = 0.0;
					double geoAngleXY = 0.0;
					string auxText = "";
					flag3 = Class156.smethod_70(ref double_7, ref double_6, ref auxText, ref string_2, ref color_, ref geoAngleXY, ref double_8, this, ref double_15, i);
					num2++;
					num9 = num3;
					if (color_ == ViewportBackColor)
					{
						color_ = buImage.InvertColor(color_);
					}
					eEntities2 = new ePoint(new Pnt3D(double_6, double_7, double_8), num9, color_);
					eEntities2.auxValue = double_15;
					eEntities2.geoAngleXY = geoAngleXY;
					eEntities2.auxText = auxText;
					for (int num36 = 0; num36 <= Layers.Count - 1; num36++)
					{
						if (Layers[num36].Name == string_2)
						{
							eEntities2.LayerIndex = num36;
						}
					}
					flag4 = true;
					if (((LayerType == 1) & (string_2.Length >= num4) & (Layers.Count > 0)) && Layers[Layers.Count - 1].Name.Substring(0, num4) != LayerFilterChars)
					{
						flag4 = false;
					}
					if (flag4)
					{
						if (!flag && flag2)
						{
							num5++;
							RefEntities.Add(eEntities2);
						}
						if (flag && !flag2)
						{
							num5++;
							eEntities2.Tag = tag;
							BlockEntityList.Add(eEntities2);
						}
					}
				}
				if (BlockEntityList.Count > 0)
				{
					for (int num37 = 0; num37 <= BlockEntityList.Count - 1; num37++)
					{
					}
				}
				buAppCalc.cVector.BoxSizeCalculate(RefEntities, ref BoxSizeMin, ref BoxSizeMax);
			}
			catch (Exception mSException)
			{
				string text2 = "FileName: " + FileName.ToString();
				buLog.addLog(text2, "Not Ok", MethodBase.GetCurrentMethod().Name);
				buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text2);
			}
		}
	}

	[Serializable]
	public class Ply : buSerilization
	{
		public Ply()
		{
			if (!buVector.smethod_0("buPly"))
			{
				throw new RegisterException("buPly");
			}
		}

		public void ReadPly(string FileName, ref List<eEntities> Entities)
		{
			try
			{
				FileInfo fileInfo = new FileInfo(FileName);
				if (!fileInfo.Exists)
				{
					return;
				}
				Entities.Clear();
				List<Pnt3D> list = new List<Pnt3D>();
				List<TriangleIndex> list2 = new List<TriangleIndex>();
				bool bool_ = false;
				int int_ = 0;
				int int_2 = 0;
				FileStream fileStream = File.Open(FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
				Class156.smethod_63(ref bool_, this, ref int_, ref int_2, new StreamReader(fileStream));
				if (!bool_)
				{
					StreamReader streamReader = new StreamReader(fileStream);
					for (int i = 0; i <= int_ - 1; i++)
					{
						string text = streamReader.ReadLine();
						string[] array = null;
						array = text.Split(' ');
						if (array != null)
						{
							double x = 0.0;
							double y = 0.0;
							double z = 0.0;
							if (array.Length >= 2)
							{
								x = double.Parse(array[0]);
								y = double.Parse(array[1]);
							}
							if (array.Length >= 3)
							{
								z = double.Parse(array[2]);
							}
							Pnt3D item = new Pnt3D(x, y, z);
							list.Add(item);
						}
					}
					for (int j = 0; j <= int_2 - 1; j++)
					{
						string text2 = streamReader.ReadLine();
						string[] array2 = null;
						array2 = text2.Split(' ');
						if (array2 != null)
						{
							int v = 0;
							int v2 = 0;
							int v3 = 0;
							int result = 0;
							if (array2.Length >= 4)
							{
								v = int.Parse(array2[1]);
								v2 = int.Parse(array2[2]);
								v3 = int.Parse(array2[3]);
							}
							if (array2.Length >= 5)
							{
								int.TryParse(array2[4], out result);
							}
							TriangleIndex item2 = new TriangleIndex(v, v2, v3);
							list2.Add(item2);
						}
					}
				}
				else
				{
					BinaryReader binaryReader = new BinaryReader(fileStream);
					for (int k = 0; k <= int_ - 1; k++)
					{
						float num = binaryReader.ReadSingle();
						float num2 = binaryReader.ReadSingle();
						float num3 = binaryReader.ReadSingle();
						Pnt3D item3 = new Pnt3D(num, num2, num3);
						list.Add(item3);
					}
					for (int l = 0; l <= int_2 - 1; l++)
					{
						binaryReader.ReadByte();
						int v4 = binaryReader.ReadInt32();
						int v5 = binaryReader.ReadInt32();
						int v6 = binaryReader.ReadInt32();
						TriangleIndex item4 = new TriangleIndex(v4, v5, v6);
						list2.Add(item4);
					}
				}
				if ((list2.Count > 0) & (list.Count > 0))
				{
					eMesh item5 = new eMesh(list2, list, Color.Gray);
					Entities.Add(item5);
				}
			}
			catch (Exception)
			{
			}
		}
	}

	public class PLYToSchematic : buSerilization
	{
		internal enum Enum10
		{
			const_0,
			const_1,
			const_2,
			const_3,
			const_4,
			const_5,
			const_6,
			const_7,
			const_8,
			const_9,
			const_10,
			const_11,
			const_12,
			const_13,
			const_14,
			const_15,
			const_16,
			const_17,
			const_18
		}

		internal class Class146
		{
			public List<Enum10> list_0 = new List<Enum10>();

			public int int_0 = -1;

			public int int_1 = -1;

			public bool bool_0 = true;
		}

		internal class Class147
		{
			public List<Pnt3D> list_0;

			public List<TriangleIndex> list_1;

			public List<Color> list_2;

			public Class147(int int_0, int int_1)
			{
				list_0 = new List<Pnt3D>(int_0);
				list_2 = new List<Color>(int_0);
				list_1 = new List<TriangleIndex>(int_1);
			}
		}

		private static Class147 smethod_0(Class146 class146_0, BinaryReader binaryReader_0)
		{
			Class147 @class = new Class147(class146_0.int_0, class146_0.int_1);
			float float_ = 0f;
			float float_2 = 0f;
			float float_3 = 0f;
			byte byte_ = byte.MaxValue;
			byte byte_2 = byte.MaxValue;
			byte byte_3 = byte.MaxValue;
			for (int i = 0; i < class146_0.int_0; i++)
			{
				foreach (Enum10 item in class146_0.list_0)
				{
					switch (item)
					{
					case Enum10.const_18:
						binaryReader_0.BaseStream.Position += 8L;
						break;
					case Enum10.const_1:
						byte_ = binaryReader_0.ReadByte();
						break;
					case Enum10.const_2:
						byte_2 = binaryReader_0.ReadByte();
						break;
					case Enum10.const_3:
						byte_3 = binaryReader_0.ReadByte();
						break;
					case Enum10.const_4:
						binaryReader_0.ReadByte();
						break;
					case Enum10.const_5:
						byte_ = (byte)(binaryReader_0.ReadUInt16() >> 8);
						break;
					case Enum10.const_6:
						byte_2 = (byte)(binaryReader_0.ReadUInt16() >> 8);
						break;
					case Enum10.const_7:
						byte_3 = (byte)(binaryReader_0.ReadUInt16() >> 8);
						break;
					case Enum10.const_8:
						_ = (byte)(binaryReader_0.ReadUInt16() >> 8);
						break;
					case Enum10.const_9:
						float_ = binaryReader_0.ReadSingle();
						break;
					case Enum10.const_10:
						float_2 = binaryReader_0.ReadSingle();
						break;
					case Enum10.const_11:
						float_3 = binaryReader_0.ReadSingle();
						break;
					case Enum10.const_12:
						float_ = (float)binaryReader_0.ReadDouble();
						break;
					case Enum10.const_13:
						float_2 = (float)binaryReader_0.ReadDouble();
						break;
					case Enum10.const_14:
						float_3 = (float)binaryReader_0.ReadDouble();
						break;
					case Enum10.const_15:
						binaryReader_0.ReadByte();
						break;
					case Enum10.const_16:
						binaryReader_0.BaseStream.Position += 2L;
						break;
					case Enum10.const_17:
						binaryReader_0.BaseStream.Position += 4L;
						break;
					}
				}
				Class156.smethod_172(@class, float_, float_2, float_3, byte_, byte_2, byte_3);
			}
			return @class;
		}

		public PLYToSchematic(string path, int scale)
		{
			FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
			Class146 @class = Class156.smethod_270(new StreamReader(fileStream));
			if (!@class.bool_0)
			{
				Class156.smethod_151(new StreamReader(fileStream), @class);
			}
			else
				smethod_0(@class, new BinaryReader(fileStream));
		}
	}

	[Serializable]
	public class Cf2 : buSerilization
	{
		public double BridgeMinLimit = 3.0;

		public double BridgeMaxLimit = 20.0;

		public double MinEntityLength = 0.0;

		private List<List<eEntities>> SubEntites = new List<List<eEntities>>();

		private List<List<eEntities>> SubBridges = new List<List<eEntities>>();

		private List<string> SubName = new List<string>();

		public List<Cf2FileProperties> FileDefinations = new List<Cf2FileProperties>();

		public List<LayerBase> Layers = new List<LayerBase>();

		public List<LayerBase> FoundLayers = new List<LayerBase>();

		internal Cf2FileProperties FoundBridgeProperties = new Cf2FileProperties();

		public Cf2()
		{
			if (!buVector.smethod_0("buCf2"))
			{
				throw new RegisterException("buCf2");
			}
		}

		public void ReadCf2(string FileName, ref List<eEntities> Entities, ref List<eEntities> Bridges)
		{
			try
			{
				string text = "";
				List<string> list = new List<string>();
				FileInfo fileInfo = new FileInfo(FileName);
				FoundLayers = new List<LayerBase>();
				if (!fileInfo.Exists)
				{
					return;
				}
				TextReader textReader = File.OpenText(FileName);
				while ((text = textReader.ReadLine()) != null)
				{
					list.Add(text);
				}
				textReader.Close();
				Entities.Clear();
				Bridges.Clear();
				Pnt3D pnt3D = new Pnt3D();
				bool flag = false;
				bool flag2 = false;
				string item = "";
				List<eEntities> list2 = new List<eEntities>();
				List<eEntities> list3 = new List<eEntities>();
				for (int i = 0; i <= FileDefinations.Count - 1; i++)
				{
					if (FileDefinations[i].CodeType == DiemakerType.Bridge)
					{
						FoundBridgeProperties = new Cf2FileProperties(FileDefinations[i]);
						if (FoundBridgeProperties.LayerIndex < 0)
						{
							FoundBridgeProperties.LayerIndex = i;
						}
					}
				}
				for (int j = 0; j <= list.Count - 1; j++)
				{
					bool flag3 = true;
					string[] array = list[j].Split(',');
					if (array.Length < 1)
					{
						continue;
					}
					if (array[0].ToLower() == "end" && flag)
					{
						flag = false;
						SubEntites.Add(list2);
						SubName.Add(item);
						SubBridges.Add(list3);
						list2 = new List<eEntities>();
						list3 = new List<eEntities>();
					}
					if (flag)
					{
						if (array.Length >= 10 && array[0] == "L")
						{
							eLine eLine_ = new eLine();
							List<eEntities> list_ = new List<eEntities>();
							Class156.smethod_38(ref list_, ref eLine_, this, array);
							if (MinEntityLength > 0.0 && eLine_.geoLength < MinEntityLength)
							{
								flag3 = false;
							}
							if (flag3)
							{
								list2.Add(eLine_);
								list3.AddRange(list_.ToArray());
							}
						}
						if (array.Length >= 13 && array[0] == "A")
						{
							eEntities eEntities_ = new eEntities();
							List<eEntities> list_2 = new List<eEntities>();
							Class156.smethod_186(ref list_2, this, ref eEntities_, array);
							if (MinEntityLength > 0.0 && eEntities_.geoLength < MinEntityLength)
							{
								flag3 = false;
							}
							if (flag3)
							{
								list2.Add(eEntities_);
								list3.AddRange(list_2.ToArray());
							}
						}
					}
					if (array[0].ToLower() == "sub")
					{
						flag = true;
						item = array[1];
						list2 = new List<eEntities>();
						list3 = new List<eEntities>();
					}
				}
				for (int k = 0; k <= list.Count - 1; k++)
				{
					bool flag4 = true;
					new List<Pnt3D>();
					string[] array2 = list[k].Split(',');
					if (array2.Length < 1)
					{
						continue;
					}
					if (array2[0].ToLower() == "end" && flag2)
					{
						flag2 = false;
					}
					if (flag2)
					{
						if (array2.Length >= 10 && array2[0] == "L")
						{
							eLine eLine_2 = new eLine();
							Class156.smethod_38(ref Bridges, ref eLine_2, this, array2);
							if (MinEntityLength > 0.0 && eLine_2.geoLength < MinEntityLength)
							{
								flag4 = false;
							}
							if (flag4)
							{
								method_0(eLine_2);
								Entities.Add(eLine_2);
							}
						}
						if (array2.Length >= 13 && array2[0] == "A")
						{
							eEntities eEntities_2 = new eEntities();
							Class156.smethod_186(ref Bridges, this, ref eEntities_2, array2);
							if (MinEntityLength > 0.0 && eEntities_2.geoLength < MinEntityLength)
							{
								flag4 = false;
							}
							if (flag4)
							{
								method_0(eEntities_2);
								Entities.Add(eEntities_2);
							}
						}
						if (array2.Length >= 9 && array2[0] == "T")
						{
							string textString_ = list[k + 1];
							pnt3D = new Pnt3D(double.Parse(array2[4], buSystem.CI), double.Parse(array2[5], buSystem.CI));
							double height_ = double.Parse(array2[7], buSystem.CI);
							eText eText2 = new eText(pnt3D, textString_, height_, Color.Black, new WorkPlane());
							eText2.Diemaker = new DiemakerData();
							eText2.Diemaker.Pt = double.Parse(array2[1], buSystem.CI);
							eText2.Diemaker.DiemakerTYpeAsInteger = Convert.ToInt32(double.Parse(array2[2], buSystem.CI));
							method_0(eText2);
							Entities.Add(eText2);
						}
						if (array2.Length >= 4 && array2[0] == "C")
						{
							for (int l = 0; l <= SubName.Count - 1; l++)
							{
								if (!(array2[1].Trim() == SubName[l].Trim()))
								{
									continue;
								}
								for (int m = 0; m <= SubEntites[l].Count - 1; m++)
								{
									eEntities eEntities2 = new eEntities();
									eEntities2 = eEntities.CopyEntity(SubEntites[l][m]);
									pnt3D = new Pnt3D(double.Parse(array2[2], buSystem.CI), double.Parse(array2[3], buSystem.CI));
									double angle = double.Parse(array2[4]);
									double num = 1.0;
									double num2 = 1.0;
									num = double.Parse(array2[5]);
									num2 = double.Parse(array2[6]);
									eEntities CalcEntities = new eEntities();
									buAppCalc.cVector.Rotate(new Pnt3D(), angle, ClockDirectionType.CW, new WorkPlane(), eEntities2, ref CalcEntities);
									eEntities2 = eEntities.CopyEntity(CalcEntities);
									CalcEntities = new eEntities();
									if (num == -1.0)
									{
										buAppCalc.cVector.Mirror(new Pnt3D(), new Pnt3D(10.0, 0.0, 0.0), eEntities2, new WorkPlane(), 0.0, ref CalcEntities);
										eEntities2 = eEntities.CopyEntity(CalcEntities);
									}
									CalcEntities = new eEntities();
									if (num2 == -1.0)
									{
										buAppCalc.cVector.Mirror(new Pnt3D(), new Pnt3D(0.0, 10.0, 0.0), eEntities2, new WorkPlane(), 0.0, ref CalcEntities);
										eEntities2 = eEntities.CopyEntity(CalcEntities);
									}
									buAppCalc.cVector.Move(new Pnt3D(), pnt3D, ref eEntities2);
									method_0(eEntities2);
									Entities.Add(eEntities2);
								}
								for (int n = 0; n <= SubBridges[l].Count - 1; n++)
								{
									eEntities eEntities3 = new eEntities();
									eEntities3 = eEntities.CopyEntity(SubBridges[l][n]);
									pnt3D = new Pnt3D(double.Parse(array2[2], buSystem.CI), double.Parse(array2[3], buSystem.CI));
									double angle2 = double.Parse(array2[4]);
									double num3 = 1.0;
									double num4 = 1.0;
									num3 = double.Parse(array2[5]);
									num4 = double.Parse(array2[6]);
									eEntities CalcEntities2 = new eEntities();
									buAppCalc.cVector.Rotate(new Pnt3D(), angle2, ClockDirectionType.CW, new WorkPlane(), eEntities3, ref CalcEntities2);
									eEntities3 = eEntities.CopyEntity(CalcEntities2);
									CalcEntities2 = new eEntities();
									if (num3 == -1.0)
									{
										buAppCalc.cVector.Mirror(new Pnt3D(), new Pnt3D(10.0, 0.0, 0.0), eEntities3, new WorkPlane(), 0.0, ref CalcEntities2);
										eEntities3 = eEntities.CopyEntity(CalcEntities2);
									}
									CalcEntities2 = new eEntities();
									if (num4 == -1.0)
									{
										buAppCalc.cVector.Mirror(new Pnt3D(), new Pnt3D(0.0, 10.0, 0.0), eEntities3, new WorkPlane(), 0.0, ref CalcEntities2);
										eEntities3 = eEntities.CopyEntity(CalcEntities2);
									}
									buAppCalc.cVector.Move(new Pnt3D(), pnt3D, ref eEntities3);
									Bridges.Add(eEntities3);
								}
							}
						}
					}
					if (array2[0].ToLower() == "main")
					{
						flag2 = true;
					}
				}
			}
			catch (Exception mSException)
			{
				buLog.addLog(FileName, "Not Ok", MethodBase.GetCurrentMethod().Name);
				buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, FileName);
			}
		}

		private void method_0(eEntities eEntities_0)
		{
			if (eEntities_0.Diemaker == null)
			{
				return;
			}
			bool flag = true;
			for (int i = 0; i <= FoundLayers.Count - 1; i++)
			{
				if ((FoundLayers[i].Diemaker.Pt == eEntities_0.Diemaker.Pt) & (FoundLayers[i].Diemaker.Type == eEntities_0.Diemaker.DiemakerType))
				{
					flag = false;
				}
			}
			if (flag)
			{
				LayerBase layerBase = new LayerBase();
				layerBase.Diemaker = new LayerDiemakerProps();
				layerBase.Diemaker.Pt = eEntities_0.Diemaker.Pt;
				layerBase.Diemaker.Type = eEntities_0.Diemaker.DiemakerType;
				layerBase.LayerColor = eEntities_0.dispColor;
				layerBase.LayerThickness = eEntities_0.dispThickness;
				layerBase.Name = eEntities_0.Diemaker.DiemakerType.ToString() + "-" + eEntities_0.Diemaker.Pt + " Pt";
				FoundLayers.Add(layerBase);
			}
		}

		public static void SaveCf2Properties(string FileName, List<Cf2FileProperties> Cf2Properties)
		{
			ArrayList arrayList = new ArrayList();
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   CF2 File Properties ");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("<CF2Prop>");
			for (int i = 0; i <= Cf2Properties.Count - 1; i++)
			{
				arrayList.AddRange(Cf2Properties[i].ToDefAll("", 2, SerilizationMode.MultiLine));
			}
			arrayList.Add("</CF2Prop>");
			SaveToFile(arrayList, FileName);
		}

		public static void OpenCf2Properties(string FileName, ref List<Cf2FileProperties> Cf2Properties)
		{
			ArrayList StringList = new ArrayList();
			OpenFromFile(FileName, ref StringList);
			Cf2Properties.Clear();
			Cf2Properties = new List<Cf2FileProperties>();
			List<List<string>> CalcList = new List<List<string>>();
			buString.ListToSpecificList("<Cf2FileProperties>", "</Cf2FileProperties>", AddStartEndKey: true, StringList, ref CalcList);
			for (int i = 0; i <= CalcList.Count - 1; i++)
			{
				ArrayList arrayList = new ArrayList();
				arrayList.AddRange(CalcList[i].ToArray());
				Cf2FileProperties cf2FileProperties = new Cf2FileProperties();
				buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, cf2FileProperties);
				Cf2Properties.Add(cf2FileProperties);
			}
			buLog.addLog("CF2 Properties Loaded", "Ok", MethodBase.GetCurrentMethod().Name, FileName, "", 0.0, 0.0);
		}
	}

	public class HPGLFile
	{
		public List<eEntities> Entities = new List<eEntities>();

		public List<Pnt3D> CoordinateList = new List<Pnt3D>();

		public HPGLFile()
		{
			if (!buVector.smethod_0("HPGLFile"))
			{
				throw new RegisterException("HPGLFile");
			}
		}

		public void ReadHPGL(string Name)
		{
			string text = "";
			List<string> list = new List<string>();
			FileInfo fileInfo = new FileInfo(Name);
			if (fileInfo.Exists)
			{
				CoordinateList = new List<Pnt3D>();
				TextReader textReader = File.OpenText(Name);
				while ((text = textReader.ReadLine()) != null)
				{
					list.Add(text);
				}
				textReader.Close();
			}
			Entities.Clear();
			List<Pnt3D> list2 = new List<Pnt3D>();
			for (int i = 0; i <= list.Count - 1; i++)
			{
				string[] array = list[i].Split(';');
				if (array == null)
				{
					continue;
				}
				Pnt3D pnt3D = new Pnt3D();
				Pnt3D pnt3D2 = new Pnt3D();
				for (int j = 0; j <= array.Length - 1; j++)
				{
					if (array[j].ToLower().IndexOf("pd") >= 0)
					{
						string text2 = array[j].Replace("PD", "");
						string[] array2 = text2.Split(',');
						if (array2 != null && array2.Length >= 2)
						{
							pnt3D2 = new Pnt3D(double.Parse(array2[0].Trim()) / 10.0, double.Parse(array2[1].Trim()) / 10.0);
							pnt3D = new Pnt3D(pnt3D2);
							list2.Add(pnt3D);
						}
					}
					if (array[j].ToLower().IndexOf("pu") >= 0)
					{
						if (list2.Count > 1)
						{
							ePolyline item = new ePolyline(list2);
							Entities.Add(item);
						}
						list2.Clear();
						string text3 = array[j].Replace("PU", "");
						string[] array3 = text3.Split(',');
						if (array3 != null && array3.Length >= 2)
						{
							pnt3D = new Pnt3D(double.Parse(array3[0].Trim()) / 10.0, double.Parse(array3[1].Trim()) / 10.0);
							list2.Add(pnt3D);
						}
					}
				}
			}
			if (list2.Count > 1)
			{
				ePolyline item2 = new ePolyline(list2);
				Entities.Add(item2);
			}
			list2.Clear();
		}
	}

	[Serializable]
	public class Rul : buSerilization
	{
		public void ReadRulFile(string FileName, ref RulProperties Properties)
		{
			FileInfo fileInfo = new FileInfo(FileName);
			Properties = new RulProperties();
			if (!fileInfo.Exists)
			{
				return;
			}
			List<string> StringList = new List<string>();
			OpenFromFile(FileName, ref StringList);
			if (StringList.Count <= 0)
			{
				return;
			}
			for (int i = 0; i <= StringList.Count - 1; i++)
			{
				string[] array = StringList[i].Split(':');
				if (array == null || array.Length < 2)
				{
					continue;
				}
				if (array[0].ToLower().IndexOf("version") >= 0)
				{
					Properties.Version = array[1].Trim();
				}
				if (array[0].ToLower().IndexOf("author") >= 0)
				{
					Properties.Author = array[1].Trim();
				}
				if (array[0].ToLower().IndexOf("date") >= 0)
				{
					Properties.Date = array[1].Trim();
				}
				if (array[0].ToLower().IndexOf("time") >= 0)
				{
					Properties.Time = array[1].Trim();
				}
				if (array[0].ToLower().IndexOf("unit") >= 0)
				{
					Properties.Unit = array[1].Trim();
				}
				if (array[0].ToLower().IndexOf("rule table") >= 0)
				{
					Properties.RuleTable = array[1].Trim();
				}
				if (array[0].ToLower().IndexOf("sample size") >= 0)
				{
					Properties.SampleSize = array[1].Trim();
				}
				if (array[0].ToLower().IndexOf("number of sizes") >= 0)
				{
					Properties.NumberOfSize = Convert.ToInt32(array[1].Trim());
				}
				if (array[0].ToLower().IndexOf("size list") >= 0)
				{
					string[] Lines = null;
					buString.SplitStringByRefWord(array[1], " ", ref Lines);
					if (Lines != null)
					{
						for (int j = 0; j <= Lines.Length - 1; j++)
						{
							Properties.SizeList.Add(Lines[j].Trim());
						}
					}
				}
				if (array[0].ToLower().IndexOf("rule") < 0)
				{
					continue;
				}
				string[] Lines2 = null;
				buString.SplitStringByRefWord(array[1], "   ", ref Lines2);
				if (Lines2 == null)
				{
					continue;
				}
				RulRule rulRule = new RulRule();
				if (Lines2.Length != 2)
				{
					continue;
				}
				string[] Lines3 = null;
				buString.SplitStringByRefWord(Lines2[0], " ", ref Lines3);
				if (Lines3 != null && Lines3.Length == 2 && Lines3[0].ToLower().IndexOf("delta") >= 0)
				{
					rulRule.No = Convert.ToInt32(Lines3[1]);
				}
				string[] Lines4 = null;
				buString.SplitStringByRefWord(Lines2[1], "  ", ref Lines4);
				if (Lines4 != null)
				{
					for (int k = 0; k <= Lines4.Length - 1; k++)
					{
						string[] Lines5 = null;
						buString.SplitStringByRefWord(Lines4[k], ",", ref Lines5);
						if (Lines5 == null)
						{
							continue;
						}
						if (Lines5.Length < 2)
						{
							string[] Lines6 = null;
							buString.SplitStringByRefWord(Lines4[k], " ", ref Lines6);
							if (Lines6.Length >= 2)
							{
								rulRule.Position.Add(new Pnt3D(Convert.ToDouble(Lines6[0]), Convert.ToDouble(Lines6[1])));
							}
						}
						else
						{
							rulRule.Position.Add(new Pnt3D(Convert.ToDouble(Lines5[0]), Convert.ToDouble(Lines5[1])));
						}
					}
				}
				Properties.RuleList.Add(rulRule);
			}
		}
	}

	[Serializable]
	public class bunesting : buSerilization
	{
	}

	private static string string_0 = "fduyfuFDSGERTHSAF-*05435/&%(hgfdhgfHGFHGFHvxcvcvTREQWEFVFDNB gR E%YT%E";

	private static string string_1 = "QWEFGHLJHGFhjklopoıuygtfc-*098h?=)(/TFDERTYUI)OKNBVFDRErd345678uhgfdXCVBHJ/&%RDW^+%&/()=)(/TRFCVBNYTrEDSX";

	private static string string_2 = "";

	private static string string_3 = "";

	private static double double_0 = 0.0;

	private static double double_1 = 0.0;

	public buFile()
	{
		if (!buVector.smethod_0("buFile"))
		{
			throw new RegisterException("buFile");
		}
	}

	public static void getFiles(string Path, ref List<string> Files)
	{
		try
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(Path);
			if (!directoryInfo.Exists)
			{
				return;
			}
			Files = new List<string>();
			string[] files = Directory.GetFiles(Path);
			if (files != null)
			{
				for (int i = 0; i <= files.Length - 1; i++)
				{
					Files.Add(files[i]);
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "Path: " + Path.ToString();
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void getDirectories(string Path, ref List<string> Directories)
	{
		try
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(Path);
			if (!directoryInfo.Exists)
			{
				return;
			}
			Directories = new List<string>();
			string[] directories = Directory.GetDirectories(Path);
			if (directories != null)
			{
				for (int i = 0; i <= directories.Length - 1; i++)
				{
					Directories.Add(directories[i]);
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "Path: " + Path.ToString();
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static List<string> GetPathInPath(string Path)
	{
		List<string> list = new List<string>();
		string[] directories = Directory.GetDirectories(Path);
		foreach (string item in directories)
		{
			list.Add(item);
		}
		return list;
	}

	public static string getFileName(string FullPath)
	{
		return Path.GetFileName(FullPath);
	}

	public static string getFileNameWithoutExtension(string FullPath)
	{
		return Path.GetFileNameWithoutExtension(FullPath);
	}

	public static string GetPreviousPath(string FullPath)
	{
		try
		{
			DirectoryInfo parent = Directory.GetParent(FullPath);
			return parent.FullName;
		}
		catch (Exception mSException)
		{
			string text = "FullPath: " + FullPath.ToString();
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return "";
		}
	}

	public static string GetPath(string FullFileName)
	{
		try
		{
			if (FullFileName.Length <= 1)
			{
				return "";
			}
			return Path.GetDirectoryName(FullFileName);
		}
		catch (Exception mSException)
		{
			string text = "FullFileName: " + FullFileName.ToString();
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return "";
		}
	}

	public static void GetFilesInDirectory(string Dir, string Extension, ref List<string> Files)
	{
		try
		{
			string text = Extension.Replace(".", "");
			text = text.Replace("*", "");
			DirectoryInfo directoryInfo = new DirectoryInfo(Dir);
			if (directoryInfo.Exists)
			{
				string[] files = Directory.GetFiles(Dir, "*." + text);
				for (int i = 0; i <= files.Length - 1; i++)
				{
					Files.Add(files[i]);
				}
			}
		}
		catch (Exception mSException)
		{
			string text2 = "Dir: " + Dir.ToString() + " - FileType: " + Extension.ToString();
			buLog.addLog(text2, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text2);
		}
	}

	public static string PathToFileWithExtension(string FullPath)
	{
		try
		{
			string result = "";
			int num = FullPath.Length - 1;
			while (num > 0)
			{
				if (!(FullPath.Substring(num, 1) == "\\"))
				{
					num--;
					continue;
				}
				result = FullPath.Substring(num + 1, FullPath.Length - num - 1);
				break;
			}
			return result;
		}
		catch (Exception mSException)
		{
			string text = "FullPath: " + FullPath.ToString();
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return "";
		}
	}

	public static string PathToFileWithoutExtension(string FullPath)
	{
		try
		{
			string result = "";
			int num = 0;
			int num2 = FullPath.Length - 1;
			while (num2 > 0)
			{
				if (!(FullPath.Substring(num2, 1) == "\\"))
				{
					num2--;
					continue;
				}
				num = num2 + 1;
				break;
			}
			for (int i = num; i <= FullPath.Length - 1; i++)
			{
				if (FullPath.Substring(i, 1) == ".")
				{
					result = FullPath.Substring(num, i - num);
					break;
				}
			}
			return result;
		}
		catch (Exception mSException)
		{
			string text = "FullPath: " + FullPath.ToString();
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return "";
		}
	}

	public static List<string> FindFilesOneDirectory(string Dir, string FileType, FileFilterType FileFilter)
	{
		List<string> list = null;
		try
		{
			list = new List<string>();
			DirectoryInfo directoryInfo = new DirectoryInfo(Dir);
			if (directoryInfo.Exists)
			{
				string[] files = Directory.GetFiles(Dir, "*." + FileType);
				if (files != null)
				{
					for (int i = 0; i <= files.Length - 1; i++)
					{
						if (FileFilter == FileFilterType.FileWithExtension)
						{
							list.Add(PathToFileWithExtension(files[i]));
						}
						if (FileFilter == FileFilterType.FileWithoutExtension)
						{
							list.Add(PathToFileWithoutExtension(files[i]));
						}
						if (FileFilter == FileFilterType.FullPath)
						{
							list.Add(files[i]);
						}
					}
				}
			}
			return list;
		}
		catch (Exception mSException)
		{
			string text = "Dir: " + Dir.ToString() + " - FileType: " + FileType.ToString() + " - FileFilter: " + FileFilter;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return new List<string>();
		}
	}

	public static void GetFileArgumans(string FileName, ref FileEventArg FileArg)
	{
		try
		{
			FileArg.FileName = FileName;
			FileArg.FilePath = GetPath(FileName);
			FileArg.JustFileName = getFileName(FileName);
			FileArg.JustFileNameWithoutExtension = getFileNameWithoutExtension(FileName);
		}
		catch (Exception mSException)
		{
			string text = "FileName: " + FileName.ToString();
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void GetLineCounfOfFile(string FileName, ref int LineCount)
	{
		try
		{
			LineCount = 0;
			LineCount = File.ReadLines(FileName).Count();
		}
		catch (Exception)
		{
		}
	}

	public static void GetFileInitPathByType(List<string> ExtensionList, int Index, FileOpenModes Settings, ref string Path)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i <= ExtensionList.Count - 1; i++)
		{
			arrayList.Add(ExtensionList[i]);
		}
		GetFileInitPathByType(arrayList, Index, Settings, ref Path);
		arrayList.Clear();
	}

	public static void GetFileInitPathByType(ArrayList ExtensionList, int Index, FileOpenModes Settings, ref string Path)
	{
		if (Path.Trim().Length <= 0)
		{
			Path = Application.StartupPath;
		}
		if ((Index >= 0) & (Index <= ExtensionList.Count - 1))
		{
			string text = ExtensionList[Index].ToString().ToLower();
			if (text.IndexOf("bucad") >= 0)
			{
				Path = Settings.InitPathBuCadV5;
			}
			if (text.IndexOf("dwc") >= 0)
			{
				Path = Settings.InitPathDwc;
			}
			if (text.IndexOf("dwx") >= 0)
			{
				Path = Settings.InitPathDxf;
			}
			if (text.IndexOf("dwg") >= 0)
			{
				Path = Settings.InitPathDwg;
			}
			if (text.IndexOf("stl") >= 0)
			{
				Path = Settings.InitPathStl;
			}
			if (text.IndexOf("igs") >= 0)
			{
				Path = Settings.InitPathIges;
			}
			if (text.IndexOf("step") >= 0)
			{
				Path = Settings.InitPathStep;
			}
		}
	}

	public static void SetFileInitPathByType(ArrayList ExtensionList, int Index, string Path, ref FileOpenModes Settings)
	{
		if (Path.Trim().Length <= 0)
		{
			Path = Application.StartupPath;
		}
		if ((Index >= 0) & (Index <= ExtensionList.Count - 1))
		{
			string text = ExtensionList[Index].ToString().ToLower();
			if (text.IndexOf("bucad") >= 0)
			{
				Settings.InitPathBuCadV5 = Path;
			}
			if (text.IndexOf("dwc") >= 0)
			{
				Settings.InitPathDwc = Path;
			}
			if (text.IndexOf("dwx") >= 0)
			{
				Settings.InitPathDxf = Path;
			}
			if (text.IndexOf("dwg") >= 0)
			{
				Settings.InitPathDwg = Path;
			}
			if (text.IndexOf("stl") >= 0)
			{
				Settings.InitPathStl = Path;
			}
			if (text.IndexOf("igs") >= 0)
			{
				Settings.InitPathIges = Path;
			}
			if (text.IndexOf("step") >= 0)
			{
				Settings.InitPathStep = Path;
			}
		}
	}

	public static string FileNameFromDate(int Mode)
	{
		string result = "";
		if (Mode == 0)
		{
			result = DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
		}
		return result;
	}

	public static void CopyFromDirectortToAnotherDirectory(string sourceDir, string targetDir)
	{
		Directory.CreateDirectory(targetDir);
		string[] files = Directory.GetFiles(sourceDir);
		foreach (string text in files)
		{
			File.Copy(text, Path.Combine(targetDir, Path.GetFileName(text)));
		}
		string[] directories = Directory.GetDirectories(sourceDir);
		foreach (string text2 in directories)
		{
			CopyFromDirectortToAnotherDirectory(text2, Path.Combine(targetDir, Path.GetFileName(text2)));
		}
	}

	public static void DeleteAllFilesInDirectory(string sourceDir)
	{
		new DirectoryInfo(sourceDir);
		string[] files = Directory.GetFiles(sourceDir);
		foreach (string path in files)
		{
			File.Delete(path);
		}
		string[] directories = Directory.GetDirectories(sourceDir);
		foreach (string sourceDir2 in directories)
		{
			DeleteAllFilesInDirectory(sourceDir2);
		}
	}

	public static void DeleteAllEmptyDirectoryInDirectory(string sourceDir)
	{
		string[] directories = Directory.GetDirectories(sourceDir);
		foreach (string path in directories)
		{
			string[] directories2 = Directory.GetDirectories(path);
			if (directories2.Length != 0)
			{
				for (int j = 0; j <= directories2.Length - 1; j++)
				{
					DeleteAllEmptyDirectoryInDirectory(directories2[j]);
				}
				DirectoryInfo directoryInfo = new DirectoryInfo(path);
				directoryInfo.Delete();
			}
			else
			{
				DirectoryInfo directoryInfo2 = new DirectoryInfo(path);
				directoryInfo2.Delete();
			}
		}
	}

	public static void OpenPassword(string FileName, double Key)
	{
		try
		{
			int num = 0;
			string text = "";
			FileInfo fileInfo = new FileInfo(FileName);
			if (fileInfo.Exists)
			{
				FileStream input = new FileStream(FileName, FileMode.Open);
				BinaryReader binaryReader = new BinaryReader(input);
				num = binaryReader.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					byte value = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
					text = (AppSecurity.Pass1 = text + Convert.ToChar(value));
				}
				text = "";
				num = binaryReader.ReadInt32();
				for (int j = 0; j < num; j++)
				{
					byte value2 = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
					text = (AppSecurity.Pass2 = text + Convert.ToChar(value2));
				}
				text = "";
				num = binaryReader.ReadInt32();
				for (int k = 0; k < num; k++)
				{
					byte value3 = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
					text = (AppSecurity.Pass3 = text + Convert.ToChar(value3));
				}
				text = "";
				num = binaryReader.ReadInt32();
				for (int l = 0; l < num; l++)
				{
					byte value4 = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
					text = (AppSecurity.Pass4 = text + Convert.ToChar(value4));
				}
				text = "";
				num = binaryReader.ReadInt32();
				for (int m = 0; m < num; m++)
				{
					byte value5 = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
					text = (AppSecurity.Pass5 = text + Convert.ToChar(value5));
				}
				text = "";
				num = binaryReader.ReadInt32();
				for (int n = 0; n < num; n++)
				{
					byte value6 = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
					text = (AppSecurity.Pass6 = text + Convert.ToChar(value6));
				}
				text = "";
				num = binaryReader.ReadInt32();
				for (int num2 = 0; num2 < num; num2++)
				{
					byte value7 = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
					text = (AppSecurity.Pass7 = text + Convert.ToChar(value7));
				}
				text = "";
				num = binaryReader.ReadInt32();
				for (int num3 = 0; num3 < num; num3++)
				{
					byte value8 = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
					text = (AppSecurity.Pass8 = text + Convert.ToChar(value8));
				}
				text = "";
				num = binaryReader.ReadInt32();
				for (int num4 = 0; num4 < num; num4++)
				{
					byte value9 = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
					text = (AppSecurity.Pass9 = text + Convert.ToChar(value9));
				}
				text = "";
				num = binaryReader.ReadInt32();
				for (int num5 = 0; num5 < num; num5++)
				{
					byte value10 = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
					text = (AppSecurity.Pass10 = text + Convert.ToChar(value10));
				}
				binaryReader.Close();
			}
			buLogVer5.addToLog("buFile", "PasswordOpen", "Password Load", "Ok", -1.0, 0.0);
		}
		catch (Exception mSException)
		{
			string auxMessage = "";
			buLogVer5.addToLog("buFile", "PasswordOpen", "Password Load", "Fail", -1.0, 0.0);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, auxMessage);
		}
	}

	public static void OpenLastUndoItem(string FileName, int GetCount, ref List<Undo> UndoItems)
	{
		try
		{
			UndoItems = new List<Undo>();
			ArrayList StringList = new ArrayList();
			List<List<string>> CalcList = new List<List<string>>();
			OpenFromFile(FileName, ref StringList);
			buString.ListToSpecificList("<UndoItem>", "</UndoItem>", AddStartEndKey: false, StringList, ref CalcList);
			if (CalcList.Count > 0)
			{
				int num = 0;
				for (int num2 = CalcList.Count - 1; num2 >= 0; num2--)
				{
					Undo undo = new Undo();
					List<List<string>> CalcList2 = new List<List<string>>();
					buString.ListToSpecificList("<eEntities>", "</eEntities>", AddStartEndKey: false, CalcList[num2], ref CalcList2);
					for (int i = 0; i <= CalcList2.Count - 1; i++)
					{
						eEntities eEntities2 = new eEntities();
						eEntities2 = eEntities.Decode(CalcList2[i], "", SerilizationMode.MultiLine);
						undo.Entities.Add(eEntities2);
					}
					UndoItems.Add(undo);
					num++;
					CalcList.RemoveAt(num2);
					if (num >= GetCount)
					{
						num2 = -1;
					}
				}
			}
			StringList.Clear();
			StringList = new ArrayList();
			for (int j = 0; j <= CalcList.Count - 1; j++)
			{
				StringList.Add("<UndoItem>");
				StringList.AddRange(CalcList[j].ToArray());
				StringList.Add("</UndoItem>");
			}
			SaveToFile(StringList, FileName);
		}
		catch (Exception mSException)
		{
			string text = "FileName: " + FileName.ToString() + " - GetCount: " + GetCount;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public static void SaveUndoFile(string FileName, Undo Undo)
	{
		try
		{
			ArrayList arrayList = new ArrayList();
			arrayList.Add("<UndoItem>");
			for (int i = 0; i <= Undo.Entities.Count - 1; i++)
			{
				buSerilization.ExceptionalVariables.Clear();
				if (Undo.Entities[i].GetType() != typeof(ePolyline))
				{
					buSerilization.ExceptionalVariables.Add("Vertice");
				}
				ArrayList arrayList2 = new ArrayList();
				arrayList2.AddRange(Undo.Entities[i].ToDefAll(2).ToArray());
				arrayList.AddRange(arrayList2.ToArray());
			}
			for (int j = 0; j <= Undo.Cams.Count - 1; j++)
			{
				buSerilization.ExceptionalVariables.Clear();
				ArrayList arrayList3 = new ArrayList();
				arrayList3.AddRange(Undo.Cams[j].ToDefAll(2).ToArray());
				arrayList.AddRange(arrayList3.ToArray());
			}
			if (Undo.DiemakerProp != null)
			{
				arrayList.Add("  <DiemakerUndo>");
				arrayList.Add("    <DiemakerCuttingUndo>");
				for (int k = 0; k <= Undo.DiemakerProp.Cutting.Count - 1; k++)
				{
					Undo.DiemakerProp.Cutting[k].ToDefAll("", 6, SerilizationMode.MultiLine);
				}
				arrayList.Add("    <DiemakerCuttingUndo>");
				arrayList.Add("    <DiemakerCreasingUndo>");
				for (int l = 0; l <= Undo.DiemakerProp.Creasing.Count - 1; l++)
				{
					Undo.DiemakerProp.Creasing[l].ToDefAll("", 6, SerilizationMode.MultiLine);
				}
				arrayList.Add("    <DiemakerCreasingUndo>");
				arrayList.Add("    <DiemakerPerfoUndo>");
				for (int m = 0; m <= Undo.DiemakerProp.Perfo.Count - 1; m++)
				{
					Undo.DiemakerProp.Perfo[m].ToDefAll("", 6, SerilizationMode.MultiLine);
				}
				arrayList.Add("    <DiemakerPerfoUndo>");
				arrayList.Add("    <DiemakerCutCreaseUndo>");
				for (int n = 0; n <= Undo.DiemakerProp.CutCrease.Count - 1; n++)
				{
					Undo.DiemakerProp.CutCrease[n].ToDefAll("", 6, SerilizationMode.MultiLine);
				}
				arrayList.Add("    <DiemakerCutCreaseUndo>");
				arrayList.Add("  </DiemakerUndo>");
			}
			arrayList.Add("</UndoItem>");
			SaveToFile(arrayList, FileName, Append: true);
		}
		catch (Exception mSException)
		{
			string text = "FileName: " + FileName.ToString() + " - Undo: " + Undo.ToString();
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public static void OpenBuCadCam(string FileName, buCadFileOpenOptions Options, ref List<eEntities> Entities)
	{
		List<camBase> CamList = new List<camBase>();
		List<LayerBase> Layers = new List<LayerBase>();
		List<string> Tags = new List<string>();
		OpenBuCadCam(FileName, Options, ref Entities, ref CamList, ref Layers, ref Tags);
	}

	public static void OpenBuCadCam(ArrayList EntitiesLines, ref List<eEntities> Entities)
	{
		List<List<string>> CalcList = new List<List<string>>();
		Entities.Clear();
		buString.ListToSpecificList("<eEntities>", "</eEntities>", AddStartEndKey: false, EntitiesLines, ref CalcList);
		for (int i = 0; i <= CalcList.Count - 1; i++)
		{
			eEntities eEntities2 = new eEntities();
			eEntities2 = eEntities.Decode(CalcList[i], "", SerilizationMode.MultiLine);
			Entities.Add(eEntities2);
		}
	}

	public static void OpenBuCadCam(string FileName, buCadFileOpenOptions Options, ref List<eEntities> Entities, ref List<camBase> CamList, ref List<LayerBase> Layers, ref List<string> Tags)
	{
		buCadCamFileInfo FileInfo = new buCadCamFileInfo();
		OpenBuCadCam(FileName, Options, ref FileInfo, ref Entities, ref CamList, ref Layers, ref Tags);
	}

	public static void OpenBuCadCam(string FileName, buCadFileOpenOptions Options, ref buCadCamFileInfo FileInfo, ref List<eEntities> Entities, ref List<LayerBase> Layers)
	{
		try
		{
			object AppOption = null;
			List<camBase> CamList = new List<camBase>();
			List<string> Tags = new List<string>();
			List<ProfileJob> Profiles = new List<ProfileJob>();
			OpenBuCadCam(FileName, Options, ref FileInfo, ref Entities, ref CamList, ref Layers, ref Tags, ref AppOption, ref Profiles);
		}
		catch (Exception mSException)
		{
			string text = "FileName : " + FileName;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public static void OpenBuCadCam(string FileName, buCadFileOpenOptions Options, ref buCadCamFileInfo FileInfo, ref List<eEntities> Entities, ref List<camBase> CamList, ref List<LayerBase> Layers, ref List<string> Tags)
	{
		try
		{
			object AppOption = null;
			List<ProfileJob> Profiles = new List<ProfileJob>();
			OpenBuCadCam(FileName, Options, ref FileInfo, ref Entities, ref CamList, ref Layers, ref Tags, ref AppOption, ref Profiles);
		}
		catch (Exception mSException)
		{
			string text = "FileName : " + FileName;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public static void OpenBuCadCam(string FileName, buCadFileOpenOptions Options, ref buCadCamFileInfo FileInfo, ref List<eEntities> Entities, ref List<camBase> CamList, ref List<LayerBase> Layers, ref List<string> Tags, ref object AppOption)
	{
		try
		{
			List<ProfileJob> Profiles = new List<ProfileJob>();
			OpenBuCadCam(FileName, Options, ref FileInfo, ref Entities, ref CamList, ref Layers, ref Tags, ref AppOption, ref Profiles);
		}
		catch (Exception mSException)
		{
			string text = "FileName : " + FileName;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public static void OpenBuCadCam(string FileName, buCadFileOpenOptions Options, ref buCadCamFileInfo FileInfo, ref List<eEntities> Entities, ref List<camBase> CamList, ref List<LayerBase> Layers, ref List<string> Tags, ref object AppOption, ref List<ProfileJob> Profiles)
	{
		try
		{
			ArrayList StringList = new ArrayList();
			OpenFromFile(FileName, ref StringList);
			OpenBuCadCam(StringList, Options, ref FileInfo, ref Entities, ref CamList, ref Layers, ref Tags, ref AppOption, ref Profiles);
		}
		catch (Exception mSException)
		{
			string text = "FileName : " + FileName;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public static void OpenBuCadCam(ArrayList Lines, buCadFileOpenOptions Options, ref buCadCamFileInfo FileInfo, ref List<eEntities> Entities, ref List<camBase> CamList, ref List<LayerBase> Layers, ref List<string> Tags, ref object AppOption, ref List<ProfileJob> Profiles)
	{
		try
		{
			List<List<string>> CalcList = new List<List<string>>();
			Entities.Clear();
			Profiles.Clear();
			buString.ListToSpecificList("<eEntities>", "</eEntities>", AddStartEndKey: true, Lines, ref CalcList);
			for (int i = 0; i <= CalcList.Count - 1; i++)
			{
				eEntities eEntities2 = new eEntities();
				eEntities2 = eEntities.Decode(CalcList[i], "", SerilizationMode.MultiLine);
				eEntities2.EntityIndex = Entities.Count;
				Entities.Add(eEntities2);
			}
			CalcList = new List<List<string>>();
			buString.ListToSpecificList("<LayerBase>", "</LayerBase>", AddStartEndKey: false, Lines, ref CalcList);
			for (int j = 0; j <= CalcList.Count - 1; j++)
			{
				ArrayList arrayList = new ArrayList();
				arrayList.AddRange(CalcList[j].ToArray());
				arrayList.Insert(0, "<LayerBase>");
				arrayList.Add("</LayerBase>");
				LayerBase layerBase = new LayerBase();
				buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, layerBase);
				layerBase = new LayerBase(layerBase);
				Layers.Add(layerBase);
			}
			CalcList = new List<List<string>>();
			buString.ListToSpecificList("<ProfileJob>", "</ProfileJob>", AddStartEndKey: true, Lines, ref CalcList);
			for (int k = 0; k <= CalcList.Count - 1; k++)
			{
				ProfileJob Job = new ProfileJob();
				ProfileJob.Decode(CalcList[k], ref Job);
				Profiles.Add(Job);
			}
			if (AppOption != null)
			{
				if (AppOption.GetType() == typeof(DiemakerPageProp))
				{
					DiemakerPageProp Diemaker = new DiemakerPageProp();
					DiemakerPageProp.Decode(Lines, ref Diemaker);
					AppOption = Diemaker;
				}
				if (AppOption.GetType() == typeof(jewelInterface))
				{
					jewelInterface jewelInterface2 = new jewelInterface();
					buSerilization.Decode(Lines, "", SerilizationMode.MultiLine, jewelInterface2);
					AppOption = jewelInterface2;
				}
			}
			CalcList = new List<List<string>>();
			buString.ListToSpecificList("<buCadCamFileInfo>", "</buCadCamFileInfo>", AddStartEndKey: true, Lines, ref CalcList);
			if (CalcList.Count > 0)
			{
				buCadCamFileInfo buCadCamFileInfo2 = new buCadCamFileInfo();
				buSerilization.Decode(CalcList[0], "", SerilizationMode.MultiLine, buCadCamFileInfo2);
				string notes = buCadCamFileInfo2.Notes;
				buCadCamFileInfo2.Notes = notes.Replace("{[NewLine]}", "\r\n");
				FileInfo = buCadCamFileInfo2;
			}
			CalcList.Clear();
			Lines.Clear();
			GC.Collect();
		}
		catch (Exception mSException)
		{
			string text = "Lines : " + Lines.Count;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public static void SaveBuCadCam(string FileName, buCadFileSaveOptions Options, List<eEntities> Entities, List<camBase> CamList, List<LayerBase> Layers, List<string> Tags)
	{
		SaveBuCadCam(FileName, Options, new buCadCamFileInfo(), Entities, CamList, Layers, Tags, null, null, null);
	}

	public static void SaveBuCadCam(string FileName, buCadFileSaveOptions Options, buCadCamFileInfo FileInfo, List<eEntities> Entities, List<camBase> CamList, List<LayerBase> Layers, List<string> Tags)
	{
		try
		{
			SaveBuCadCam(FileName, Options, FileInfo, Entities, CamList, Layers, Tags, null, null, null);
		}
		catch (Exception mSException)
		{
			string text = "FileName : " + FileName;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public static void SaveBuCadCam(string FileName, buCadFileSaveOptions Options, buCadCamFileInfo FileInfo, List<eEntities> Entities, List<camBase> CamList, List<LayerBase> Layers, List<string> Tags, object AppOption, object AuxOption, List<ProfileJob> ProfileJobs)
	{
		try
		{
			ArrayList arrayList = new ArrayList();
			string notes = FileInfo.Notes;
			FileInfo.Notes = notes.Replace("\r\n", "{[NewLine]}");
			arrayList.AddRange(FileInfo.ToDefAll("", 2, SerilizationMode.MultiLine).ToArray());
			for (int i = 0; i <= Layers.Count - 1; i++)
			{
				arrayList.AddRange(Layers[i].ToDefAll("", 2, SerilizationMode.MultiLine).ToArray());
			}
			for (int j = 0; j <= Entities.Count - 1; j++)
			{
				buSerilization.ExceptionalVariables.Clear();
				if (Entities[j].GetType() != typeof(ePolyline))
				{
					buSerilization.ExceptionalVariables.Add("Vertice");
				}
				ArrayList arrayList2 = new ArrayList();
				arrayList2.AddRange(Entities[j].ToDefAll(2).ToArray());
				arrayList.AddRange(arrayList2.ToArray());
			}
			if (Options.SaveCamList)
			{
				for (int k = 0; k <= CamList.Count - 1; k++)
				{
					buSerilization.ExceptionalVariables.Clear();
					ArrayList arrayList3 = new ArrayList();
					arrayList3.AddRange(CamList[k].ToDefAll(2).ToArray());
					arrayList.AddRange(arrayList3.ToArray());
				}
			}
			if (AppOption != null)
			{
				if (AppOption.GetType() == typeof(DiemakerPageProp))
				{
					arrayList.AddRange(((DiemakerPageProp)AppOption).ToDef(2));
				}
				if (AppOption.GetType() == typeof(jewelInterface))
				{
					arrayList.AddRange(((jewelInterface)AppOption).ToDefAll("", 2, SerilizationMode.MultiLine));
				}
			}
			if (Options.SaveProfileList && ProfileJobs != null && ProfileJobs.Count > 0)
			{
				arrayList.AddRange(ProfileJob.ToDef(ProfileJobs, 2));
			}
			TextWriter textWriter = File.CreateText(FileName);
			for (int l = 0; l <= arrayList.Count - 1; l++)
			{
				textWriter.WriteLine(arrayList[l].ToString());
			}
			textWriter.Close();
			arrayList.Clear();
			GC.Collect();
		}
		catch (Exception mSException)
		{
			string text = "FileName : " + FileName;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public static void OpenKinemticFile(string FileName, ref KinematicBase Kinematic)
	{
		try
		{
			ArrayList StringList = new ArrayList();
			Kinematic = new KinematicBase();
			List<List<string>> CalcList = new List<List<string>>();
			OpenFromFile(FileName, ref StringList);
			buSerilization.Decode(StringList, "", SerilizationMode.MultiLine, Kinematic);
			buString.ListToSpecificList("<KinematicItem>", "</KinematicItem>", AddStartEndKey: false, StringList, ref CalcList);
			for (int i = 0; i <= CalcList.Count - 1; i++)
			{
				ArrayList arrayList = new ArrayList();
				arrayList.AddRange(CalcList[i].ToArray());
				arrayList.Insert(0, "<KinematicItem>");
				arrayList.Add("</KinematicItem>");
				KinematicItem kinematicItem = new KinematicItem();
				buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, kinematicItem);
				new eEntities();
				new List<string>();
				List<List<string>> CalcList2 = new List<List<string>>();
				buString.ListToSpecificList("<SubEntities>", "</SubEntities>", AddStartEndKey: true, CalcList[i], ref CalcList2);
				for (int j = 0; j <= CalcList2.Count - 1; j++)
				{
					eEntities eEntities2 = new eEntities();
					eEntities2 = eEntities.Decode(CalcList2[j], "", SerilizationMode.MultiLine);
					kinematicItem.Entities.Add(eEntities2);
				}
				Kinematic.Items.Add(kinematicItem);
			}
			Kinematic.FileName = FileName;
			GC.Collect();
			buLog.addLog("Kinematic File Opened - ", "Ok", MethodBase.GetCurrentMethod().Name, FileName, "", 0.0, 0.0);
		}
		catch (Exception mSException)
		{
			string text = "FileName : " + FileName;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public static void SaveKinematicFile(string FileName, KinematicBase Kinematic)
	{
		try
		{
			ArrayList arrayList = new ArrayList();
			arrayList.AddRange(Kinematic.ToDefAll("", 2, SerilizationMode.MultiLine));
			string value = arrayList[arrayList.Count - 1].ToString();
			arrayList.RemoveAt(arrayList.Count - 1);
			for (int i = 0; i <= Kinematic.Items.Count - 1; i++)
			{
				buSerilization.ExceptionalVariables.Clear();
				arrayList.AddRange(Kinematic.Items[i].ToDefAll("", 4, SerilizationMode.MultiLine));
				string value2 = arrayList[arrayList.Count - 1].ToString();
				arrayList.RemoveAt(arrayList.Count - 1);
				for (int j = 0; j <= Kinematic.Items[i].Entities.Count - 1; j++)
				{
					arrayList.Add("<SubEntities>");
					arrayList.AddRange(Kinematic.Items[i].Entities[j].ToDefAll(6));
					arrayList.Add("</SubEntities>");
				}
				arrayList.Add(value2);
			}
			arrayList.Add(value);
			TextWriter textWriter = File.CreateText(FileName);
			for (int k = 0; k <= arrayList.Count - 1; k++)
			{
				textWriter.WriteLine(arrayList[k].ToString());
			}
			textWriter.Close();
			arrayList.Clear();
			GC.Collect();
		}
		catch (Exception mSException)
		{
			string text = "FileName : " + FileName;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public static void OpenPostProcessorFile(string FileName, ref PostProcessor Post)
	{
		try
		{
			ArrayList StringList = new ArrayList();
			Post = new PostProcessor();
			new List<List<string>>();
			OpenFromFile(FileName, ref StringList);
			Post.RepetitionDef.AxesRepetation = new AxesEnableWithUVW(x: false, y: false, z: false, a: false, b: false, c: false, u: false, v: false, w: false);
			buSerilization.Decode(StringList, "", SerilizationMode.MultiLine, Post);
			StringList = new ArrayList();
			for (int i = 0; i <= Post.CamPageVelocity.Count - 1; i++)
			{
				string text = Post.CamPageVelocity[i].ToString();
				string[] array = null;
				array = text.Split(',');
				if (array == null)
				{
					continue;
				}
				if (array.Length < 2)
				{
					if (array.Length == 1)
					{
						StringList.Add(array[0].Trim());
					}
				}
				else if ((array[1].Trim() == "1") | (array[1].Trim().ToLower() == "true") | (array[1].Trim().ToLower() == "visible"))
				{
					StringList.Add(array[0].Trim());
				}
			}
			if (StringList.Count > 0)
			{
				Post.CamPageVelocity.Clear();
				Post.CamPageVelocity.AddRange(StringList.ToArray());
			}
			StringList = new ArrayList();
			for (int j = 0; j <= Post.CamPageDistance.Count - 1; j++)
			{
				string text2 = Post.CamPageDistance[j].ToString();
				string[] array2 = null;
				array2 = text2.Split(',');
				if (array2 == null)
				{
					continue;
				}
				if (array2.Length < 2)
				{
					if (array2.Length == 1)
					{
						StringList.Add(array2[0].Trim());
					}
				}
				else if ((array2[1].Trim() == "1") | (array2[1].Trim().ToLower() == "true") | (array2[1].Trim().ToLower() == "visible"))
				{
					StringList.Add(array2[0].Trim());
				}
			}
			if (StringList.Count > 0)
			{
				Post.CamPageDistance.Clear();
				Post.CamPageDistance.AddRange(StringList.ToArray());
			}
			StringList = new ArrayList();
			for (int k = 0; k <= Post.CamPageStep.Count - 1; k++)
			{
				string text3 = Post.CamPageStep[k].ToString();
				string[] array3 = null;
				array3 = text3.Split(',');
				if (array3 == null)
				{
					continue;
				}
				if (array3.Length < 2)
				{
					if (array3.Length == 1)
					{
						StringList.Add(array3[0].Trim());
					}
				}
				else if ((array3[1].Trim() == "1") | (array3[1].Trim().ToLower() == "true") | (array3[1].Trim().ToLower() == "visible"))
				{
					StringList.Add(array3[0].Trim());
				}
			}
			if (StringList.Count > 0)
			{
				Post.CamPageStep.Clear();
				Post.CamPageStep.AddRange(StringList.ToArray());
			}
			StringList = new ArrayList();
			for (int l = 0; l <= Post.CamPageOperation.Count - 1; l++)
			{
				string text4 = Post.CamPageOperation[l].ToString();
				string[] array4 = null;
				array4 = text4.Split(',');
				if (array4 == null)
				{
					continue;
				}
				if (array4.Length < 2)
				{
					if (array4.Length == 1)
					{
						StringList.Add(array4[0].Trim());
					}
				}
				else if ((array4[1].Trim() == "1") | (array4[1].Trim().ToLower() == "true") | (array4[1].Trim().ToLower() == "visible"))
				{
					StringList.Add(array4[0].Trim());
				}
			}
			if (StringList.Count > 0)
			{
				Post.CamPageOperation.Clear();
				Post.CamPageOperation.AddRange(StringList.ToArray());
			}
			StringList = new ArrayList();
			for (int m = 0; m <= Post.CamPageOffset.Count - 1; m++)
			{
				string text5 = Post.CamPageOffset[m].ToString();
				string[] array5 = null;
				array5 = text5.Split(',');
				if (array5 == null)
				{
					continue;
				}
				if (array5.Length < 2)
				{
					if (array5.Length == 1)
					{
						StringList.Add(array5[0].Trim());
					}
				}
				else if ((array5[1].Trim() == "1") | (array5[1].Trim().ToLower() == "true") | (array5[1].Trim().ToLower() == "visible"))
				{
					StringList.Add(array5[0].Trim());
				}
			}
			if (StringList.Count > 0)
			{
				Post.CamPageOffset.Clear();
				Post.CamPageOffset.AddRange(StringList.ToArray());
			}
			StringList = new ArrayList();
			for (int n = 0; n <= Post.CamPageLeadIn.Count - 1; n++)
			{
				string text6 = Post.CamPageLeadIn[n].ToString();
				string[] array6 = null;
				array6 = text6.Split(',');
				if (array6 == null)
				{
					continue;
				}
				if (array6.Length < 2)
				{
					if (array6.Length == 1)
					{
						StringList.Add(array6[0].Trim());
					}
				}
				else if ((array6[1].Trim() == "1") | (array6[1].Trim().ToLower() == "true") | (array6[1].Trim().ToLower() == "visible"))
				{
					StringList.Add(array6[0].Trim());
				}
			}
			if (StringList.Count > 0)
			{
				Post.CamPageLeadIn.Clear();
				Post.CamPageLeadIn.AddRange(StringList.ToArray());
			}
			StringList = new ArrayList();
			for (int num = 0; num <= Post.CamPageLeadOut.Count - 1; num++)
			{
				string text7 = Post.CamPageLeadOut[num].ToString();
				string[] array7 = null;
				array7 = text7.Split(',');
				if (array7 == null)
				{
					continue;
				}
				if (array7.Length < 2)
				{
					if (array7.Length == 1)
					{
						StringList.Add(array7[0].Trim());
					}
				}
				else if ((array7[1].Trim() == "1") | (array7[1].Trim().ToLower() == "true") | (array7[1].Trim().ToLower() == "visible"))
				{
					StringList.Add(array7[0].Trim());
				}
			}
			if (StringList.Count > 0)
			{
				Post.CamPageLeadOut.Clear();
				Post.CamPageLeadOut.AddRange(StringList.ToArray());
			}
			StringList = new ArrayList();
			for (int num2 = 0; num2 <= Post.CamPageTools.Count - 1; num2++)
			{
				string text8 = Post.CamPageTools[num2].ToString();
				string[] array8 = null;
				array8 = text8.Split(',');
				if (array8 == null)
				{
					continue;
				}
				if (array8.Length < 2)
				{
					if (array8.Length == 1)
					{
						StringList.Add(array8[0].Trim());
					}
				}
				else if ((array8[1].Trim() == "1") | (array8[1].Trim().ToLower() == "true") | (array8[1].Trim().ToLower() == "visible"))
				{
					StringList.Add(array8[0].Trim());
				}
			}
			if (StringList.Count > 0)
			{
				Post.CamPageTools.Clear();
				Post.CamPageTools.AddRange(StringList.ToArray());
			}
			StringList = new ArrayList();
			for (int num3 = 0; num3 <= Post.CamPageMisc.Count - 1; num3++)
			{
				string text9 = Post.CamPageMisc[num3].ToString();
				string[] array9 = null;
				array9 = text9.Split(',');
				if (array9 == null)
				{
					continue;
				}
				if (array9.Length < 2)
				{
					if (array9.Length == 1)
					{
						StringList.Add(array9[0].Trim());
					}
				}
				else if ((array9[1].Trim() == "1") | (array9[1].Trim().ToLower() == "true") | (array9[1].Trim().ToLower() == "visible"))
				{
					StringList.Add(array9[0].Trim());
				}
			}
			if (StringList.Count > 0)
			{
				Post.CamPageMisc.Clear();
				Post.CamPageMisc.AddRange(StringList.ToArray());
			}
			Post.FileName = FileName;
			buLog.addLog("Post File Opened", "Ok", MethodBase.GetCurrentMethod().Name, FileName, "", 0.0, 0.0);
			GC.Collect();
		}
		catch (Exception mSException)
		{
			string text10 = "FileName : " + FileName;
			buLog.addLog(text10, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text10);
		}
	}

	public static void SavePostProcessorFile(string FileName, PostProcessor Post)
	{
		try
		{
			ArrayList arrayList = new ArrayList();
			arrayList.AddRange(Post.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList[arrayList.Count - 1].ToString();
			TextWriter textWriter = File.CreateText(FileName);
			for (int i = 0; i <= arrayList.Count - 1; i++)
			{
				textWriter.WriteLine(arrayList[i].ToString());
			}
			textWriter.Close();
			arrayList.Clear();
			GC.Collect();
		}
		catch (Exception mSException)
		{
			string text = "FileName : " + FileName;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public static void OpenFromFile(string FileName, ref List<string> StringList)
	{
		try
		{
			if (buVector.bool_0)
			{
				string text = "";
				StringList = new List<string>();
				TextReader textReader = File.OpenText(FileName);
				while ((text = textReader.ReadLine()) != null)
				{
					StringList.Add(text);
				}
				textReader.Close();
			}
			else
			{
				MessageBox.Show("License Error");
			}
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, FileName);
		}
	}

	public static void OpenFromFile(string FileName, ref ArrayList StringList)
	{
		try
		{
			if (buVector.bool_0)
			{
				string text = "";
				StringList = new ArrayList();
				TextReader textReader = File.OpenText(FileName);
				while ((text = textReader.ReadLine()) != null)
				{
					StringList.Add(text);
				}
				textReader.Close();
			}
			else
			{
				MessageBox.Show("License Error");
			}
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, FileName);
		}
	}

	public static void OpenFromFile(string FileName, ref string Str)
	{
		try
		{
			if (buVector.bool_0)
			{
				StreamReader streamReader = new StreamReader(FileName);
				Str = streamReader.ReadToEnd();
				streamReader.Close();
			}
			else
			{
				MessageBox.Show("License Error");
			}
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, FileName);
		}
	}

	public static void SaveToFile(string String, string FileName)
	{
		if (buVector.bool_0)
		{
			TextWriter textWriter = File.CreateText(FileName);
			try
			{
				textWriter.WriteLine(String);
				textWriter.Close();
				return;
			}
			catch (Exception mSException)
			{
				buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, FileName);
				return;
			}
			finally
			{
				textWriter.Close();
			}
		}
		MessageBox.Show("License Error");
	}

	public static void SaveToFile(string String, string FileName, bool Append)
	{
		if (buVector.bool_0)
		{
			TextWriter textWriter = null;
			textWriter = (Append ? File.AppendText(FileName) : File.CreateText(FileName));
			try
			{
				textWriter.WriteLine(String);
				textWriter.Close();
				return;
			}
			catch (Exception mSException)
			{
				buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, FileName);
				return;
			}
			finally
			{
				textWriter.Close();
			}
		}
		MessageBox.Show("License Error");
	}

	public static void SaveToFile(List<string> StringList, string FileName)
	{
		if (buVector.bool_0)
		{
			TextWriter textWriter = File.CreateText(FileName);
			try
			{
				for (int i = 0; i <= StringList.Count - 1; i++)
				{
					textWriter.WriteLine(StringList[i].ToString());
				}
				textWriter.Close();
				return;
			}
			catch (Exception mSException)
			{
				buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, FileName);
				return;
			}
			finally
			{
				textWriter.Close();
			}
		}
		MessageBox.Show("License Error");
	}

	public static void SaveToFile(List<string> StringList, string FileName, bool Append)
	{
		if (buVector.bool_0)
		{
			TextWriter textWriter = null;
			textWriter = (Append ? File.AppendText(FileName) : File.CreateText(FileName));
			try
			{
				for (int i = 0; i <= StringList.Count - 1; i++)
				{
					textWriter.WriteLine(StringList[i].ToString());
				}
				textWriter.Close();
				return;
			}
			catch (Exception mSException)
			{
				buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, FileName);
				return;
			}
			finally
			{
				textWriter.Close();
			}
		}
		MessageBox.Show("License Error");
	}

	public static void SaveToFile(List<List<string>> StringList, string FileName)
	{
		if (buVector.bool_0)
		{
			TextWriter textWriter = File.CreateText(FileName);
			try
			{
				for (int i = 0; i <= StringList.Count - 1; i++)
				{
					for (int j = 0; j <= StringList[i].Count - 1; j++)
					{
						textWriter.WriteLine(StringList[i][j].ToString());
					}
				}
				textWriter.Close();
				return;
			}
			catch (Exception mSException)
			{
				buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, FileName);
				return;
			}
			finally
			{
				textWriter.Close();
			}
		}
		MessageBox.Show("License Error");
	}

	public static void SaveToFile(List<List<string>> StringList, string FileName, bool Append)
	{
		if (buVector.bool_0)
		{
			TextWriter textWriter = null;
			textWriter = (Append ? File.AppendText(FileName) : File.CreateText(FileName));
			try
			{
				for (int i = 0; i <= StringList.Count - 1; i++)
				{
					for (int j = 0; j <= StringList[i].Count - 1; j++)
					{
						textWriter.WriteLine(StringList[i][j].ToString());
					}
				}
				textWriter.Close();
				return;
			}
			catch (Exception mSException)
			{
				buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, FileName);
				return;
			}
			finally
			{
				textWriter.Close();
			}
		}
		MessageBox.Show("License Error");
	}

	public static void SaveToFile(ArrayList StringList, string FileName)
	{
		if (buVector.bool_0)
		{
			TextWriter textWriter = File.CreateText(FileName);
			try
			{
				for (int i = 0; i <= StringList.Count - 1; i++)
				{
					textWriter.WriteLine(StringList[i].ToString());
				}
				textWriter.Close();
				return;
			}
			catch (Exception mSException)
			{
				buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, FileName);
				return;
			}
			finally
			{
				textWriter.Close();
			}
		}
		MessageBox.Show("License Error");
	}

	public static void SaveToFile(ArrayList StringList, string FileName, bool Append)
	{
		if (buVector.bool_0)
		{
			TextWriter textWriter = null;
			textWriter = (Append ? File.AppendText(FileName) : File.CreateText(FileName));
			try
			{
				for (int i = 0; i <= StringList.Count - 1; i++)
				{
					textWriter.WriteLine(StringList[i].ToString());
				}
				textWriter.Close();
				return;
			}
			catch (Exception mSException)
			{
				buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, FileName);
				return;
			}
			finally
			{
				textWriter.Close();
			}
		}
		MessageBox.Show("License Error");
	}

	public static void AppendToFile(string String, string FileName)
	{
		TextWriter textWriter = File.AppendText(FileName);
		try
		{
			textWriter.WriteLine(String);
			textWriter.Close();
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, FileName);
		}
		finally
		{
			textWriter.Close();
		}
	}

	public static void ZipFolderToFile(string Folder, string FileName)
	{
		ZipFile.CreateFromDirectory(Folder, FileName);
	}

	public static void ZipFolderToFile(string Folder, string FileName, CompressionLevel Level)
	{
		ZipFile.CreateFromDirectory(Folder, FileName, Level, includeBaseDirectory: false);
	}

	public static void ExtractToFolder(string Folder, string FileName)
	{
		ZipFile.ExtractToDirectory(FileName, Folder);
	}

	public static void OpenSurfaceReadFile(string Filename, ref List<Pnt3D> pntTeachList)
	{
		ArrayList StringList = new ArrayList();
		OpenFromFile(Filename, ref StringList);
		ArrayList CalcList = new ArrayList();
		buString.ListToSpecificList("<CalibRatio>", "</CalibRatio>", AddStartEndKey: false, StringList, ref CalcList);
		double result = 1.0;
		if (CalcList.Count > 0)
		{
			double.TryParse(CalcList[0].ToString(), out result);
		}
		CalcList = new ArrayList();
		pntTeachList.Clear();
		buString.ListToSpecificList("<ReadSurface>", "</ReadSurface>", AddStartEndKey: false, StringList, ref CalcList);
		double num = 0.0;
		for (int i = 0; i <= CalcList.Count - 1; i++)
		{
			Pnt3D pnt3D = new Pnt3D();
			pnt3D = Pnt3D.DecodeFromString(CalcList[i].ToString());
			pnt3D.Z *= -1.0;
			pnt3D.Z /= result;
			if (i == 0)
			{
				num = pnt3D.Z;
			}
			pnt3D.Z -= num;
			pntTeachList.Add(pnt3D);
		}
		if (pntTeachList.Count > 2)
		{
			double num2 = Math.Abs(pntTeachList[pntTeachList.Count - 1].X - pntTeachList[pntTeachList.Count - 2].X);
			if (num2 > 100.0)
			{
				pntTeachList.RemoveAt(pntTeachList.Count - 1);
			}
		}
	}

	public static string SoapSerialize(object graph)
	{
		try
		{
			using MemoryStream memoryStream = new MemoryStream();
			SoapFormatter soapFormatter = new SoapFormatter();
			soapFormatter.Serialize(memoryStream, graph);
			return Encoding.UTF8.GetString(memoryStream.GetBuffer(), 0, (int)memoryStream.Position);
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, graph.ToString());
			return "";
		}
	}

	public static object SoapDeserialize(string buffer)
	{
		try
		{
			using MemoryStream serializationStream = new MemoryStream(Encoding.UTF8.GetBytes(buffer));
			SoapFormatter soapFormatter = new SoapFormatter();
			return soapFormatter.Deserialize(serializationStream);
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, buffer);
			return null;
		}
	}
}
