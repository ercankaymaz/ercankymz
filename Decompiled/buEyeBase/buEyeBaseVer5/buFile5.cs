using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using buCore;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;
using ns71;

namespace buEyeBaseVer5;

public class buFile5
{
	[Serializable]
	public class Ply : buSerilization
	{
		public Ply()
		{
			if (!buVector5.smethod_0("buPly"))
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
				Class186.smethod_94(new StreamReader(fileStream), this, ref int_2, ref bool_, ref int_);
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
		internal enum Enum15
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

		internal class Class168
		{
			public List<Enum15> list_0 = new List<Enum15>();

			public int int_0 = -1;

			public int int_1 = -1;

			public bool bool_0 = true;
		}

		internal class Class169
		{
			public List<Pnt3D> list_0;

			public List<TriangleIndex> list_1;

			public List<Color> list_2;

			public Class169(int int_0, int int_1)
			{
				list_0 = new List<Pnt3D>(int_0);
				list_2 = new List<Color>(int_0);
				list_1 = new List<TriangleIndex>(int_1);
			}
		}

		private static Class169 smethod_0(Class168 class168_0, BinaryReader binaryReader_0)
		{
			Class169 @class = new Class169(class168_0.int_0, class168_0.int_1);
			float float_ = 0f;
			float float_2 = 0f;
			float float_3 = 0f;
			byte byte_ = byte.MaxValue;
			byte byte_2 = byte.MaxValue;
			byte byte_3 = byte.MaxValue;
			for (int i = 0; i < class168_0.int_0; i++)
			{
				foreach (Enum15 item in class168_0.list_0)
				{
					switch (item)
					{
					case Enum15.const_18:
						binaryReader_0.BaseStream.Position += 8L;
						break;
					case Enum15.const_1:
						byte_ = binaryReader_0.ReadByte();
						break;
					case Enum15.const_2:
						byte_2 = binaryReader_0.ReadByte();
						break;
					case Enum15.const_3:
						byte_3 = binaryReader_0.ReadByte();
						break;
					case Enum15.const_4:
						binaryReader_0.ReadByte();
						break;
					case Enum15.const_5:
						byte_ = (byte)(binaryReader_0.ReadUInt16() >> 8);
						break;
					case Enum15.const_6:
						byte_2 = (byte)(binaryReader_0.ReadUInt16() >> 8);
						break;
					case Enum15.const_7:
						byte_3 = (byte)(binaryReader_0.ReadUInt16() >> 8);
						break;
					case Enum15.const_8:
						_ = (byte)(binaryReader_0.ReadUInt16() >> 8);
						break;
					case Enum15.const_9:
						float_ = binaryReader_0.ReadSingle();
						break;
					case Enum15.const_10:
						float_2 = binaryReader_0.ReadSingle();
						break;
					case Enum15.const_11:
						float_3 = binaryReader_0.ReadSingle();
						break;
					case Enum15.const_12:
						float_ = (float)binaryReader_0.ReadDouble();
						break;
					case Enum15.const_13:
						float_2 = (float)binaryReader_0.ReadDouble();
						break;
					case Enum15.const_14:
						float_3 = (float)binaryReader_0.ReadDouble();
						break;
					case Enum15.const_15:
						binaryReader_0.ReadByte();
						break;
					case Enum15.const_16:
						binaryReader_0.BaseStream.Position += 2L;
						break;
					case Enum15.const_17:
						binaryReader_0.BaseStream.Position += 4L;
						break;
					}
				}
				Class186.smethod_828(@class, float_, float_2, float_3, byte_, byte_2, byte_3);
			}
			return @class;
		}

		public PLYToSchematic(string path, int scale)
		{
			FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
			Class168 @class = Class186.smethod_459(new StreamReader(fileStream));
			if (!@class.bool_0)
			{
				Class186.smethod_734(@class, new StreamReader(fileStream));
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

		public List<LayerBase5> Layers = new List<LayerBase5>();

		public List<LayerBase5> FoundLayers = new List<LayerBase5>();

		internal Cf2FileProperties FoundBridgeProperties = new Cf2FileProperties();

		public Cf2()
		{
			if (!buVector5.smethod_0("buCf2"))
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
				FoundLayers = new List<LayerBase5>();
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
							Class186.smethod_9(ref eLine_, this, ref list_, array);
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
							Class186.smethod_827(ref list_2, ref eEntities_, array, this);
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
							Class186.smethod_9(ref eLine_2, this, ref Bridges, array2);
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
							Class186.smethod_827(ref Bridges, ref eEntities_2, array2, this);
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
									buCall.buVector_0.Rotate(new Pnt3D(), angle, ClockDirectionType.CW, new WorkPlane(), eEntities2, ref CalcEntities);
									eEntities2 = eEntities.CopyEntity(CalcEntities);
									CalcEntities = new eEntities();
									if (num == -1.0)
									{
										buCall.buVector_0.Mirror(new Pnt3D(), new Pnt3D(10.0, 0.0, 0.0), eEntities2, new WorkPlane(), 0.0, ref CalcEntities);
										eEntities2 = eEntities.CopyEntity(CalcEntities);
									}
									CalcEntities = new eEntities();
									if (num2 == -1.0)
									{
										buCall.buVector_0.Mirror(new Pnt3D(), new Pnt3D(0.0, 10.0, 0.0), eEntities2, new WorkPlane(), 0.0, ref CalcEntities);
										eEntities2 = eEntities.CopyEntity(CalcEntities);
									}
									buCall.buVector_0.Move(new Pnt3D(), pnt3D, ref eEntities2);
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
									buCall.buVector_0.Rotate(new Pnt3D(), angle2, ClockDirectionType.CW, new WorkPlane(), eEntities3, ref CalcEntities2);
									eEntities3 = eEntities.CopyEntity(CalcEntities2);
									CalcEntities2 = new eEntities();
									if (num3 == -1.0)
									{
										buCall.buVector_0.Mirror(new Pnt3D(), new Pnt3D(10.0, 0.0, 0.0), eEntities3, new WorkPlane(), 0.0, ref CalcEntities2);
										eEntities3 = eEntities.CopyEntity(CalcEntities2);
									}
									CalcEntities2 = new eEntities();
									if (num4 == -1.0)
									{
										buCall.buVector_0.Mirror(new Pnt3D(), new Pnt3D(0.0, 10.0, 0.0), eEntities3, new WorkPlane(), 0.0, ref CalcEntities2);
										eEntities3 = eEntities.CopyEntity(CalcEntities2);
									}
									buCall.buVector_0.Move(new Pnt3D(), pnt3D, ref eEntities3);
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
				LayerBase5 layerBase = new LayerBase5();
				layerBase.Diemaker = new LayerDiemakerProps();
				layerBase.Diemaker.Pt = eEntities_0.Diemaker.Pt;
				layerBase.Diemaker.Type = eEntities_0.Diemaker.DiemakerType;
				layerBase.LayerColor = eEntities_0.dispColor;
				layerBase.LayerThickness = eEntities_0.dispThickness;
				layerBase.Name = eEntities_0.Diemaker.DiemakerType.ToString() + "-" + eEntities_0.Diemaker.Pt + "Pt";
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
			buString5.ListToSpecificList("<Cf2FileProperties>", "</Cf2FileProperties>", AddStartEndKey: true, StringList, ref CalcList);
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

	public class GCodeRead
	{
		public GCodeChars Chars = new GCodeChars();

		public GCodeSetting5 Settings = new GCodeSetting5();

		public GCodeResult5 Result = new GCodeResult5();

		public AxesEnableWithUVW DecodeAxes = new AxesEnableWithUVW(x: true, y: true, z: true);

		public List<buEntity> EntitiesG1 = new List<buEntity>();

		public List<buEntity> EntitiesG0 = new List<buEntity>();

		public List<buEntity> EntitiesPlunge = new List<buEntity>();

		public List<buEntity> EntitiesLeave = new List<buEntity>();

		public List<Entity> Entitiesolid = null;

		public List<string> GCodeLines = new List<string>();

		public List<GCodePoint5> Coordinates = new List<GCodePoint5>();

		public Pnt9D MaxCoordinates = new Pnt9D();

		public Pnt9D MinCoordinates = new Pnt9D();

		public List<GCodeAssingmentArgs> Assingment = null;

		public GCodeRead()
		{
			if (!Class186.smethod_53() && !buVector5.smethod_0("GCodeRead"))
			{
				throw new RegisterException("GCodeRead");
			}
		}

		public void OpenGCode(string FileName, ref List<GCodePoint5> GCodeList, bool DontFillGCodList = false)
		{
			GCodeLines.Clear();
			OpenFromFile(FileName, ref GCodeLines);
			OpenGCode(GCodeLines, ref GCodeList, DontFillGCodList);
		}

		public void OpenGCode(List<string> GCodes, ref List<GCodePoint5> GCodeList, bool DontFillGCodList = false)
		{
			try
			{
				GCodeList.Clear();
				Coordinates.Clear();
				Pnt9D pnt9D = new Pnt9D();
				double Value = 0.0;
				bool isGCode = false;
				int codeType = -1;
				bool flag = false;
				List<Point3D> CopiedPnt = new List<Point3D>();
				new List<Point3D>();
				List<GCodeGraphPoint5> list = new List<GCodeGraphPoint5>();
				EntitiesG1.Clear();
				EntitiesG0.Clear();
				EntitiesLeave.Clear();
				EntitiesPlunge.Clear();
				EntitiesG1 = new List<buEntity>();
				EntitiesG0 = new List<buEntity>();
				EntitiesLeave = new List<buEntity>();
				EntitiesPlunge = new List<buEntity>();
				MaxCoordinates = new Pnt9D(double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue);
				MinCoordinates = new Pnt9D(double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue);
				if (!DecodeAxes.A)
				{
					MaxCoordinates.A = 0.0;
					MinCoordinates.A = 0.0;
				}
				if (!DecodeAxes.B)
				{
					MaxCoordinates.B = 0.0;
					MinCoordinates.B = 0.0;
				}
				if (!DecodeAxes.C)
				{
					MaxCoordinates.C = 0.0;
					MinCoordinates.C = 0.0;
				}
				for (int i = 0; i <= GCodes.Count - 1; i++)
				{
					bool flag2 = false;
					int num = -1;
					GCodePoint5 gCodePoint = new GCodePoint5();
					gCodePoint.Positions = new Pnt9D(pnt9D);
					gCodePoint.isGCode = isGCode;
					gCodePoint.CodeType = codeType;
					string text = "";
					text = (Settings.TrimLines ? GCodes[i].Trim() : GCodes[i]);
					if (Settings.CheckComma && text.IndexOf(",") >= 0)
					{
						text = text.Replace(",", ".");
					}
					if (Assingment != null)
					{
						for (int j = 0; j <= Assingment.Count - 1; j++)
						{
							if (text.IndexOf(Assingment[j].Base) >= 0)
							{
								text = Assingment[j].Change;
							}
						}
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
						if (buString5.ReadStringValue(Chars.G, text, ref gCodePoint.GValue))
						{
							gCodePoint.CodeType = Convert.ToInt32(gCodePoint.GValue);
						}
					}
					if (Settings.UseMCode)
					{
						num = text.IndexOf(Chars.M);
						if (num >= 0)
						{
							gCodePoint.isMCode = true;
							gCodePoint.isGCode = false;
						}
					}
					if (Settings.UseTCode)
					{
						num = text.IndexOf(Chars.T);
						if (num >= 0)
						{
							gCodePoint.isTCode = true;
							gCodePoint.isGCode = false;
						}
					}
					if (gCodePoint.isGCode)
					{
						flag2 = true;
						if (DecodeAxes.X && buString5.ReadStringValue(Chars.X, text, ref gCodePoint.Positions.X))
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
						if (DecodeAxes.Y && buString5.ReadStringValue(Chars.Y, text, ref gCodePoint.Positions.Y))
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
						if (DecodeAxes.Z && buString5.ReadStringValue(Chars.Z, text, ref gCodePoint.Positions.Z))
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
						if (DecodeAxes.A && buString5.ReadStringValue(Chars.A, text, ref gCodePoint.Positions.A))
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
						if (DecodeAxes.B && buString5.ReadStringValue(Chars.B, text, ref gCodePoint.Positions.B))
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
						if (DecodeAxes.C && buString5.ReadStringValue(Chars.C, text, ref gCodePoint.Positions.C))
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
						if (DecodeAxes.U && buString5.ReadStringValue(Chars.U, text, ref gCodePoint.Positions.U))
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
						if (DecodeAxes.V && buString5.ReadStringValue(Chars.V, text, ref gCodePoint.Positions.V))
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
						if (DecodeAxes.W && buString5.ReadStringValue(Chars.W, text, ref gCodePoint.Positions.W))
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
						buString5.ReadStringValue(Chars.R, text, ref gCodePoint.R);
						buString5.ReadStringValue(Chars.I, text, ref gCodePoint.IJKValue.I);
						buString5.ReadStringValue(Chars.J, text, ref gCodePoint.IJKValue.J);
						buString5.ReadStringValue(Chars.K, text, ref gCodePoint.IJKValue.K);
						buString5.ReadStringValue("F", text, ref Value);
						gCodePoint.Feed = Value;
						if (flag)
						{
							if (gCodePoint.CodeType == 0)
							{
								gCodePoint.Entity = new buLine(new Point3D(pnt9D.X, pnt9D.Y, pnt9D.Z), new Point3D(gCodePoint.Positions.X, gCodePoint.Positions.Y, gCodePoint.Positions.Z));
								gCodePoint.Entity.Color = Color.Red;
							}
							if (gCodePoint.CodeType == 1)
							{
								gCodePoint.Entity = new buLine(new Point3D(pnt9D.X, pnt9D.Y, pnt9D.Z), new Point3D(gCodePoint.Positions.X, gCodePoint.Positions.Y, gCodePoint.Positions.Z));
								gCodePoint.Entity.Color = Color.Black;
							}
							if (gCodePoint.CodeType == 2)
							{
								Point3D ArcCenter = new Point3D();
								double ArcSA = 0.0;
								double ArcEA = 0.0;
								double num2 = 0.0;
								Point3D point3D = new Point3D(pnt9D.X, pnt9D.Y, pnt9D.Z);
								Point3D point3D2 = new Point3D(gCodePoint.Positions.X, gCodePoint.Positions.Y, gCodePoint.Positions.Z);
								if (gCodePoint.R > 0.0)
								{
									buCall.buVector5_0.ArcWithTwoPointAndRadius(point3D, point3D2, Math.Abs(gCodePoint.R), CW: true, Plane.XY, ref ArcCenter, ref ArcSA, ref ArcEA);
								}
								if (gCodePoint.R < 0.0)
								{
									buCall.buVector5_0.ArcWithTwoPointAndRadius(point3D, point3D2, Math.Abs(gCodePoint.R), CW: true, Plane.XY, ref ArcCenter, ref ArcSA, ref ArcEA);
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
									buCall.buVector5_0.ArcWithIJK(point3D, point3D2, gCodePoint.IJKValue.I, gCodePoint.IJKValue.J, gCodePoint.IJKValue.K, gCodePoint.CodeType, ref ArcCenter, ref num2, ref ArcSA, ref ArcEA);
								}
								List<Point3D> Vertices = new List<Point3D>();
								buCall.buVector5_0.ArcWithCenter(ArcCenter, num2, ArcSA, ArcEA, Plane.XY, buSystem.EntitiesResolution, ref Vertices);
								gCodePoint.Entity = new buLinearPath(Vertices);
								gCodePoint.Entity.Color = Color.Black;
							}
							if (gCodePoint.CodeType == 3)
							{
								Point3D ArcCenter2 = new Point3D();
								double ArcSA2 = 0.0;
								double ArcEA2 = 0.0;
								double num4 = 0.0;
								Point3D point3D3 = new Point3D(pnt9D.X, pnt9D.Y, pnt9D.Z);
								Point3D point3D4 = new Point3D(gCodePoint.Positions.X, gCodePoint.Positions.Y, gCodePoint.Positions.Z);
								if (gCodePoint.R > 0.0)
								{
									buCall.buVector5_0.ArcWithTwoPointAndRadius(point3D3, point3D4, Math.Abs(gCodePoint.R), CW: false, Plane.XY, ref ArcCenter2, ref ArcSA2, ref ArcEA2);
								}
								if (gCodePoint.R < 0.0)
								{
									buCall.buVector5_0.ArcWithTwoPointAndRadius(point3D3, point3D4, Math.Abs(gCodePoint.R), CW: false, Plane.XY, ref ArcCenter2, ref ArcSA2, ref ArcEA2);
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
									buCall.buVector5_0.ArcWithIJK(point3D3, point3D4, gCodePoint.IJKValue.I, gCodePoint.IJKValue.J, gCodePoint.IJKValue.K, gCodePoint.CodeType, ref ArcCenter2, ref num4, ref ArcSA2, ref ArcEA2);
								}
								List<Point3D> Vertices2 = new List<Point3D>();
								buCall.buVector5_0.ArcWithCenter(ArcCenter2, num4, ArcSA2, ArcEA2, Plane.XY, buSystem.EntitiesResolution, ref Vertices2);
								gCodePoint.Entity = new buLinearPath(Vertices2);
								gCodePoint.Entity.Color = Color.Black;
							}
						}
						if ((gCodePoint.CodeType >= 0) & (gCodePoint.CodeType <= 3))
						{
							flag = true;
						}
					}
					if (gCodePoint.isMCode && buString5.ReadStringValue(Chars.M, text, ref gCodePoint.MValue))
					{
						flag2 = true;
						gCodePoint.CodeType = Convert.ToInt32(gCodePoint.MValue);
						buString5.ReadStringValue(Chars.X, text, ref gCodePoint.Positions.X);
					}
					if (gCodePoint.isTCode && buString5.ReadStringValue(Chars.T, text, ref gCodePoint.TValue))
					{
						flag2 = true;
						gCodePoint.CodeType = Convert.ToInt32(gCodePoint.TValue);
						gCodePoint.Tool = new ToolBase5();
						gCodePoint.Tool.Data.No = Convert.ToInt32(gCodePoint.TValue);
					}
					if ((gCodePoint.isGCode & ((gCodePoint.CodeType >= 0) & (gCodePoint.CodeType <= 3))) && flag)
					{
						GCodeGraphPoint5 gCodeGraphPoint = new GCodeGraphPoint5();
						gCodeGraphPoint.Positions = new Pnt9D(gCodePoint.Positions.X, gCodePoint.Positions.Y, gCodePoint.Positions.Z);
						gCodeGraphPoint.CodeType = gCodePoint.CodeType;
						gCodeGraphPoint.Radius = gCodePoint.R;
						gCodeGraphPoint.IJKValues = new IJK(gCodePoint.IJKValue);
						list.Add(gCodeGraphPoint);
					}
					double num6 = buCall.buVector5_0.Length2D(pnt9D.X, pnt9D.Y, gCodePoint.Positions.X, gCodePoint.Positions.Y);
					if (((gCodePoint.CodeType == 1) & (Settings.FilterLength > 0.0)) && num6 < Settings.FilterLength)
					{
						double num7 = Math.Abs(gCodePoint.Positions.Z - pnt9D.Z);
						if (num7 < 1.0)
						{
							flag2 = false;
						}
					}
					if (flag2 && !DontFillGCodList)
					{
						if (gCodePoint.Entity == null)
						{
							gCodePoint.Entity = new buPoint(new Point3D());
						}
						GCodeList.Add(gCodePoint);
					}
					pnt9D = new Pnt9D(gCodePoint.Positions);
					isGCode = gCodePoint.isGCode;
					codeType = gCodePoint.CodeType;
					if (gCodePoint.isGCode & (gCodePoint.CodeType >= 0) & (gCodePoint.CodeType <= 3))
					{
						Coordinates.Add(gCodePoint);
					}
				}
				GC.Collect();
				if (list.Count > 1)
				{
					if (list.Count > 1 && list[0].CodeType == 0 && ((list[0].Positions.X == 0.0) & (list[0].Positions.Y == 0.0)) && list[0].Positions.Z == list[1].Positions.Z)
					{
						list.RemoveAt(0);
					}
					new Point3D();
					for (int k = 1; k <= list.Count - 1; k++)
					{
						Point3D point3D5 = new Point3D(list[k - 1].Positions.X, list[k - 1].Positions.Y, list[k - 1].Positions.Z);
						Point3D point3D6 = new Point3D(list[k].Positions.X, list[k].Positions.Y, list[k].Positions.Z);
						if (buCompare5.EQ(point3D5, point3D6))
						{
							continue;
						}
						if (list[k].CodeType == 0)
						{
							if (CopiedPnt.Count > 1)
							{
								buLinearPath item = new buLinearPath(CopiedPnt);
								EntitiesG1.Add(item);
								CopiedPnt = new List<Point3D>();
							}
							buLine item2 = new buLine(point3D5, point3D6);
							if (!buCompare5.EQ(point3D5, point3D6))
							{
								EntitiesG0.Add(item2);
							}
							else
							{
								if (point3D5.Z > point3D6.Z)
								{
									EntitiesPlunge.Add(item2);
								}
								if (point3D5.Z < point3D6.Z)
								{
									EntitiesLeave.Add(item2);
								}
							}
						}
						if (list[k].CodeType == 1)
						{
							if (buCompare5.EQ(point3D5, point3D6))
							{
								buLine item3 = new buLine(point3D5, point3D6);
								if (point3D5.Z > point3D6.Z)
								{
									EntitiesPlunge.Add(item3);
								}
								if (point3D5.Z < point3D6.Z)
								{
									EntitiesLeave.Add(item3);
								}
							}
							if (list[k - 1].CodeType == 0)
							{
								CopiedPnt.Add(point3D5);
							}
							CopiedPnt.Add(point3D6);
						}
						if (list[k].CodeType == 2)
						{
							Point3D ArcCenter3 = new Point3D();
							double ArcSA3 = 0.0;
							double ArcEA3 = 0.0;
							double num8 = 0.0;
							if (list[k].Radius > 0.0)
							{
								buCall.buVector5_0.ArcWithTwoPointAndRadius(point3D5, point3D6, Math.Abs(list[k].Radius), CW: true, Plane.XY, ref ArcCenter3, ref ArcSA3, ref ArcEA3);
								if (point3D5.Z == point3D6.Z)
								{
									ArcCenter3.Z = point3D5.Z;
								}
							}
							if (list[k].Radius < 0.0)
							{
								buCall.buVector5_0.ArcWithTwoPointAndRadius(point3D5, point3D6, Math.Abs(list[k].Radius), CW: true, Plane.XY, ref ArcCenter3, ref ArcSA3, ref ArcEA3);
								if (ArcEA3 - ArcSA3 < 180.0)
								{
									double num9 = ArcSA3;
									ArcSA3 = ArcEA3;
									ArcEA3 = num9;
								}
								if (ArcSA3 > ArcEA3)
								{
									ArcEA3 += 360.0;
								}
								if (point3D5.Z == point3D6.Z)
								{
									ArcCenter3.Z = point3D5.Z;
								}
							}
							num8 = Math.Abs(list[k].Radius);
							if ((list[k].IJKValues.I != 0.0) | (list[k].IJKValues.J != 0.0) | (list[k].IJKValues.K != 0.0))
							{
								buCall.buVector5_0.ArcWithIJK(point3D5, point3D6, list[k].IJKValues.I, list[k].IJKValues.J, list[k].IJKValues.K, list[k].CodeType, ref ArcCenter3, ref num8, ref ArcSA3, ref ArcEA3);
								if (point3D5.Z == point3D6.Z)
								{
									ArcCenter3.Z = point3D5.Z;
								}
							}
							List<Point3D> Vertices3 = new List<Point3D>();
							buCall.buVector5_0.ArcWithCenter(ArcCenter3, num8, ArcSA3, ArcEA3, Plane.XY, buSystem.EntitiesResolution, ref Vertices3);
							Vertices3.Reverse();
							buVector5.Add(Vertices3, ref CopiedPnt);
						}
						if (list[k].CodeType == 3)
						{
							Point3D ArcCenter4 = new Point3D();
							double ArcSA4 = 0.0;
							double ArcEA4 = 0.0;
							double num10 = 0.0;
							if (list[k].Radius > 0.0)
							{
								buCall.buVector5_0.ArcWithTwoPointAndRadius(point3D5, point3D6, Math.Abs(list[k].Radius), CW: false, Plane.XY, ref ArcCenter4, ref ArcSA4, ref ArcEA4);
								if (point3D5.Z == point3D6.Z)
								{
									ArcCenter4.Z = point3D5.Z;
								}
							}
							if (list[k].Radius < 0.0)
							{
								buCall.buVector5_0.ArcWithTwoPointAndRadius(point3D5, point3D6, Math.Abs(list[k].Radius), CW: false, Plane.XY, ref ArcCenter4, ref ArcSA4, ref ArcEA4);
								if (ArcEA4 - ArcSA4 < 180.0)
								{
									double num11 = ArcSA4;
									ArcSA4 = ArcEA4;
									ArcEA4 = num11;
								}
								if (ArcSA4 > ArcEA4)
								{
									ArcEA4 += 360.0;
								}
								if (point3D5.Z == point3D6.Z)
								{
									ArcCenter4.Z = point3D5.Z;
								}
							}
							num10 = Math.Abs(list[k].Radius);
							if ((list[k].IJKValues.I != 0.0) | (list[k].IJKValues.J != 0.0) | (list[k].IJKValues.K != 0.0))
							{
								buCall.buVector5_0.ArcWithIJK(point3D5, point3D6, list[k].IJKValues.I, list[k].IJKValues.J, list[k].IJKValues.K, list[k].CodeType, ref ArcCenter4, ref num10, ref ArcSA4, ref ArcEA4);
								if (point3D5.Z == point3D6.Z)
								{
									ArcCenter4.Z = point3D5.Z;
								}
							}
							List<Point3D> Vertices4 = new List<Point3D>();
							buCall.buVector5_0.ArcWithCenter(ArcCenter4, num10, ArcSA4, ArcEA4, Plane.XY, buSystem.EntitiesResolution, ref Vertices4);
							buVector5.Add(Vertices4, ref CopiedPnt);
						}
						buVector5.ToPoint3D(point3D6);
					}
					if (CopiedPnt.Count > 1)
					{
						buLinearPath item4 = new buLinearPath(CopiedPnt);
						EntitiesG1.Add(item4);
						CopiedPnt = new List<Point3D>();
					}
				}
				Result.OriginalGCodeLineCount = GCodes.Count;
				Result.ConvertedGCodeLineCount = GCodeList.Count;
			}
			catch (Exception mSException)
			{
				string text2 = GCodes.Count.ToString();
				buLog.addLog(text2, "Not Ok", MethodBase.GetCurrentMethod().Name);
				buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text2);
			}
		}
	}

	public class GCodeAssingmentArgs
	{
		public string Base = "";

		public string Change = "";

		public GCodeAssingmentArgs()
		{
		}

		public GCodeAssingmentArgs(string sbase, string schange)
		{
			Base = sbase;
			Change = schange;
		}
	}

	public class HPGLFile
	{
		public double Devider = 10.0;

		public HPGLFile()
		{
			if (!buVector5.smethod_0("HPGLFile"))
			{
				throw new RegisterException("HPGLFile");
			}
		}

		public void ReadHPGL(string Name, ref List<Entity> Entities)
		{
			string text = "";
			List<string> list = new List<string>();
			FileInfo fileInfo = new FileInfo(Name);
			if (fileInfo.Exists)
			{
				TextReader textReader = File.OpenText(Name);
				while ((text = textReader.ReadLine()) != null)
				{
					list.Add(text);
				}
				textReader.Close();
			}
			Entities.Clear();
			Entities = new List<Entity>();
			List<Point3D> list2 = new List<Point3D>();
			for (int i = 0; i <= list.Count - 1; i++)
			{
				string[] array = list[i].Split(';');
				if (array == null)
				{
					continue;
				}
				Point3D point3D = new Point3D();
				Point3D point3D2 = new Point3D();
				for (int j = 0; j <= array.Length - 1; j++)
				{
					if (array[j].ToLower().IndexOf("pd") >= 0)
					{
						string text2 = array[j].Replace("PD", "");
						string[] array2 = text2.Split(',');
						if (array2 != null && array2.Length >= 2)
						{
							point3D2 = new Point3D(double.Parse(array2[0].Trim()) / Devider, double.Parse(array2[1].Trim()) / Devider, 0.0);
							point3D = buVector5.ToPoint3D(point3D2);
							list2.Add(point3D);
						}
					}
					if (array[j].ToLower().IndexOf("pu") >= 0)
					{
						if (list2.Count > 1)
						{
							LinearPath item = new LinearPath(list2);
							Entities.Add(item);
						}
						list2 = new List<Point3D>();
						string text3 = array[j].Replace("PU", "");
						string[] array3 = text3.Split(',');
						if (array3 != null && array3.Length >= 2)
						{
							point3D = new Point3D(double.Parse(array3[0].Trim()) / Devider, double.Parse(array3[1].Trim()) / Devider, 0.0);
							list2.Add(point3D);
						}
					}
				}
			}
			if (list2.Count > 1)
			{
				LinearPath item2 = new LinearPath(list2);
				Entities.Add(item2);
			}
			list2.Clear();
		}

		public void WriteHPGL(string Name, HPGLFileProperties Settings, List<List<Entity>> Entities)
		{
			List<string> list = new List<string>();
			Point3D MinPoint = new Point3D();
			Point3D MidPoint = new Point3D();
			Point3D MaxPoint = new Point3D();
			buCall.buVector5_0.BoxSizeCalculate(Entities, ref MinPoint, ref MidPoint, ref MaxPoint);
			if (Settings.RepeatCount > 0)
			{
				list.Add("RP" + Settings.RepeatCount);
			}
			if (Settings.UseFLStart)
			{
				list.Add("FL" + Convert.ToInt32(MaxPoint.X * Settings.XMultiply));
			}
			for (int i = 0; i <= Entities.Count - 1; i++)
			{
				List<Point3D> Points = new List<Point3D>();
				buCall.buVector5_0.EntitiesToPointsWithCamDirection(Entities[i], buSystem.RegenDeviation, ref Points);
				if (Points.Count > 0)
				{
					list.Add("SP1");
					list.Add("PU" + Convert.ToInt32(Points[0].X * Settings.XMultiply) + "," + Convert.ToInt32(Points[0].Y * Settings.YMultiply));
					for (int j = 1; j <= Points.Count - 1; j++)
					{
						list.Add("PD" + Convert.ToInt32(Points[j].X * Settings.XMultiply) + "," + Convert.ToInt32(Points[j].Y * Settings.YMultiply));
					}
				}
			}
			if (Settings.UseFFEnd)
			{
				list.Add("FF");
			}
			if (Settings.UseFLEnd)
			{
				list.Add("FL" + Convert.ToInt32(MaxPoint.X * Settings.XMultiply));
			}
			if (list.Count > 0)
			{
				SaveToFile(list, Name);
			}
		}

		public void WriteHPGL(string Name, HPGLFileProperties Settings, List<camTp> Cams)
		{
			List<string> list = new List<string>();
			new Point3D();
			new Point3D();
			Point3D point3D = new Point3D();
			if (Settings.RepeatCount > 0)
			{
				list.Add("RP" + Settings.RepeatCount);
			}
			if (Settings.UseFLStart)
			{
				list.Add("FL" + Convert.ToInt32(point3D.X * Settings.XMultiply));
			}
			for (int i = 0; i <= Cams.Count - 1; i++)
			{
				for (int j = 0; j <= Cams[i].PreCodes.Count - 1; j++)
				{
					list.Add(Cams[i].PreCodes[j].ToString());
				}
				for (int k = 0; k <= Cams[i].CamPoints.Count - 1; k++)
				{
					for (int l = 0; l <= Cams[i].CamPoints[k].PreCodes.Count - 1; l++)
					{
						list.Add(Cams[i].CamPoints[k].PreCodes[l].ToString());
					}
					list.Add("SP" + Cams[i].Tool.Data.No);
					list.Add("PU" + Convert.ToInt32(Cams[i].CamPoints[k].Points[0].P9.X * Settings.XMultiply) + "," + Convert.ToInt32(Cams[i].CamPoints[k].Points[0].P9.Y * Settings.YMultiply));
					for (int m = 1; m <= Cams[i].CamPoints[k].Points.Count - 1; m++)
					{
						for (int n = 0; n <= Cams[i].CamPoints[k].Points[m].PreCodes.Count - 1; n++)
						{
							list.Add(Cams[i].CamPoints[k].Points[m].PreCodes[n].ToString());
						}
						list.Add("PD" + Convert.ToInt32(Cams[i].CamPoints[k].Points[m].P9.X * Settings.XMultiply) + "," + Convert.ToInt32(Cams[i].CamPoints[k].Points[m].P9.Y * Settings.YMultiply));
						for (int num = 0; num <= Cams[i].CamPoints[k].Points[m].AfterCodes.Count - 1; num++)
						{
							list.Add(Cams[i].CamPoints[k].Points[m].AfterCodes[num].ToString());
						}
					}
					for (int num2 = 0; num2 <= Cams[i].CamPoints[k].AfterCodes.Count - 1; num2++)
					{
						list.Add(Cams[i].CamPoints[k].AfterCodes[num2].ToString());
					}
				}
				for (int num3 = 0; num3 <= Cams[i].AfterCodes.Count - 1; num3++)
				{
					list.Add(Cams[i].AfterCodes[num3].ToString());
				}
			}
			if (Settings.UseFFEnd)
			{
				list.Add("FF");
			}
			if (Settings.UseFLEnd)
			{
				list.Add("FL" + Convert.ToInt32(point3D.X * Settings.XMultiply));
			}
			if (list.Count > 0)
			{
				SaveToFile(list, Name);
			}
		}
	}

	public class IsoCutter
	{
		public IsoCutter()
		{
			if (!buVector5.smethod_0("IsoCutter"))
			{
				throw new RegisterException("IsoCutter");
			}
		}

		public void WriteIsoCutter()
		{
		}
	}

	[Serializable]
	public class bunesting : buSerilization
	{
		public void SaveNesting(string FileName, List<buNestingPart> Parts, List<buNestingSheet> Sheets)
		{
			SaveNesting(FileName, Parts, Sheets, null, null);
		}

		public void SaveNesting(string FileName, List<buNestingPart> Parts, List<buNestingSheet> Sheets, buNestingVar Parameters)
		{
			SaveNesting(FileName, Parts, Sheets, null, Parameters);
		}

		public void SaveNesting(string FileName, List<buNestingPart> Parts, List<buNestingSheet> Sheets, buNestedResult Result, buNestingVar Parameters)
		{
			SaveNesting(FileName, Parts, Sheets, null, Result, Parameters);
		}

		public void SaveNesting(string FileName, List<buNestingPart> Parts, List<buNestingSheet> Sheets, List<buNestingMaterials> Materials, buNestedResult Result, buNestingVar Parameters)
		{
			ArrayList arrayList = new ArrayList();
			if (Sheets != null)
			{
				arrayList.Add("------------------------------------------------------------------------");
				arrayList.Add("   Nestings Sheets");
				arrayList.Add("------------------------------------------------------------------------");
				arrayList.AddRange(buNestingSheet.ToDef(Sheets, 2).ToArray());
			}
			if (Parts != null)
			{
				arrayList.Add(" ");
				arrayList.Add("------------------------------------------------------------------------");
				arrayList.Add("   Nestings Parts");
				arrayList.Add("------------------------------------------------------------------------");
				arrayList.AddRange(buNestingPart.ToDef(Parts, 2).ToArray());
			}
			if (Materials != null)
			{
				arrayList.Add(" ");
				arrayList.Add("------------------------------------------------------------------------");
				arrayList.Add("   Nestings Materials");
				arrayList.Add("------------------------------------------------------------------------");
				arrayList.AddRange(buNestingMaterials.ToDef(Materials, 2).ToArray());
			}
			if (Parameters != null)
			{
				arrayList.Add(" ");
				arrayList.Add("------------------------------------------------------------------------");
				arrayList.Add("   Nesting Settings");
				arrayList.Add("------------------------------------------------------------------------");
				arrayList.AddRange(Parameters.AddMaterial.ToDefAll("", 2, SerilizationMode5.MultiLine));
				arrayList.AddRange(Parameters.AddPart.ToDefAll("", 2, SerilizationMode5.MultiLine));
				arrayList.AddRange(Parameters.MaterailSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
				arrayList.AddRange(Parameters.PartSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
				arrayList.AddRange(Parameters.ResultSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
				arrayList.AddRange(Parameters.Settings.ToDefAll("", 2, SerilizationMode5.MultiLine));
			}
			if (Result != null)
			{
				arrayList.Add(" ");
				arrayList.Add("------------------------------------------------------------------------");
				arrayList.Add("   Nesting Results");
				arrayList.Add("------------------------------------------------------------------------");
				arrayList.AddRange(buNestedResult.ToDef(Result, 0));
			}
			if (arrayList.Count > 0)
			{
				SaveToFile(arrayList, FileName);
			}
		}

		public void SaveNestingMaterials(string FileName, List<buNestingMaterials> Materials)
		{
			ArrayList arrayList = new ArrayList();
			if (Materials != null)
			{
				arrayList.Add(" ");
				arrayList.Add("------------------------------------------------------------------------");
				arrayList.Add("   Nestings Materials");
				arrayList.Add("------------------------------------------------------------------------");
				arrayList.AddRange(buNestingMaterials.ToDef(Materials, 2).ToArray());
			}
			if (arrayList.Count > 0)
			{
				SaveToFile(arrayList, FileName);
			}
		}

		public void OpenNesting(string FileName, ref List<buNestingPart> Parts, ref List<buNestingSheet> Sheets)
		{
			buNestedResult Result = new buNestedResult();
			buNestingVar Parameters = new buNestingVar();
			OpenNesting(FileName, ref Parts, ref Sheets, ref Result, ref Parameters);
		}

		public void OpenNesting(string FileName, ref List<buNestingPart> Parts, ref List<buNestingSheet> Sheets, ref buNestingVar Parameters)
		{
			buNestedResult Result = new buNestedResult();
			OpenNesting(FileName, ref Parts, ref Sheets, ref Result, ref Parameters);
		}

		public void OpenNesting(string FileName, ref List<buNestingPart> Parts, ref List<buNestingSheet> Sheets, ref buNestedResult Result)
		{
			buNestingVar Parameters = new buNestingVar();
			OpenNesting(FileName, ref Parts, ref Sheets, ref Result, ref Parameters);
		}

		public void OpenNesting(string FileName, ref List<buNestingPart> Parts, ref List<buNestingSheet> Sheets, ref buNestedResult Result, ref buNestingVar Parameters)
		{
			List<buNestingMaterials> Materials = new List<buNestingMaterials>();
			OpenNesting(FileName, ref Parts, ref Sheets, ref Materials, ref Result, ref Parameters);
		}

		public void OpenNesting(string FileName, ref List<buNestingPart> Parts, ref List<buNestingSheet> Sheets, ref List<buNestingMaterials> Materials, ref buNestedResult Result, ref buNestingVar Parameters)
		{
			ArrayList StringList = new ArrayList();
			OpenFromFile(FileName, ref StringList);
			Parts.Clear();
			Parts = new List<buNestingPart>();
			Sheets.Clear();
			Sheets = new List<buNestingSheet>();
			Materials.Clear();
			Materials = new List<buNestingMaterials>();
			buNestingSheet.Decode(StringList, ref Sheets);
			buNestingPart.Decode(StringList, ref Parts);
			buNestingMaterials.Decode(StringList, ref Materials);
			buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, Parameters.AddMaterial);
			buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, Parameters.AddPart);
			buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, Parameters.MaterailSettings);
			buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, Parameters.PartSettings);
			buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, Parameters.ResultSettings);
			buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, Parameters.Settings);
			Result = new buNestedResult();
			buNestedResult.Decode(StringList, ref Result);
		}

		public void OpenNestingMaterials(string FileName, ref List<buNestingMaterials> Materials)
		{
			ArrayList StringList = new ArrayList();
			OpenFromFile(FileName, ref StringList);
			Materials.Clear();
			Materials = new List<buNestingMaterials>();
			buNestingMaterials.Decode(StringList, ref Materials);
		}
	}

	[CompilerGenerated]
	private sealed class Class170
	{
		public string string_0;

		internal bool method_0(string string_1)
		{
			return Path.GetFileName(string_1).ToLower().Contains(string_0.ToLower());
		}
	}

	[CompilerGenerated]
	private sealed class Class171
	{
		public string string_0;

		internal bool method_0(string string_1)
		{
			return Path.GetFileName(string_1).ToLower().Contains(string_0.ToLower());
		}
	}

	[CompilerGenerated]
	private sealed class Class172 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncTaskMethodBuilder<ReadFileAsync> asyncTaskMethodBuilder_0;

		public Design design_0;

		public string string_0;

		public buFile5 buFile5_0;

		private ReadFileAsync readFileAsync_0;

		private BlockReference blockReference_0;

		private TaskAwaiter taskAwaiter_0;

		void IAsyncStateMachine.MoveNext()
		{
			TaskAwaiter awaiter;
			if (int_0 == 0)
			{
				awaiter = taskAwaiter_0;
				taskAwaiter_0 = default(TaskAwaiter);
				int num = -1;
				int_0 = -1;
			}
			else
			{
				readFileAsync_0 = new ReadAutodesk(string_0);
				awaiter = design_0.DoWorkAsync(readFileAsync_0).GetAwaiter();
				if (!awaiter.IsCompleted)
				{
					int num = 0;
					int_0 = 0;
					taskAwaiter_0 = awaiter;
					Class172 stateMachine = this;
					asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
					return;
				}
			}
			awaiter.GetResult();
			blockReference_0 = readFileAsync_0.OpenTo(design_0);
			ReadFileAsync result = readFileAsync_0;
			int_0 = -2;
			readFileAsync_0 = null;
			blockReference_0 = null;
			asyncTaskMethodBuilder_0.SetResult(result);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class Class173 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		public Design design_0;

		public string string_0;

		public buFile5 buFile5_0;

		private WriteFileAsync writeFileAsync_0;

		private Exception exception_0;

		private string string_1;

		private TaskAwaiter taskAwaiter_0;

		void IAsyncStateMachine.MoveNext()
		{
			int num = int_0;
			if (num == 0)
			{
			}
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = taskAwaiter_0;
					taskAwaiter_0 = default(TaskAwaiter);
					num = -1;
					int_0 = -1;
				}
				else
				{
					writeFileAsync_0 = null;
					writeFileAsync_0 = new WriteAutodesk(new WriteAutodeskParams(design_0.Document), string_0);
					awaiter = design_0.DoWorkAsync(writeFileAsync_0).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = 0;
						int_0 = 0;
						taskAwaiter_0 = awaiter;
						Class173 stateMachine = this;
						asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
						return;
					}
				}
				awaiter.GetResult();
				writeFileAsync_0 = null;
			}
			catch (Exception ex)
			{
				exception_0 = ex;
				string_1 = "FileNmae : " + string_0;
				buLog.addLog(string_1, "Not Ok", MethodBase.GetCurrentMethod().Name);
				buException.throwException(exception_0, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, string_1);
				string_1 = null;
			}
			int_0 = -2;
			asyncVoidMethodBuilder_0.SetResult();
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	internal static double double_0 = 0.0;

	internal static double double_1 = 0.0;

	internal static string string_0 = "";

	public buFile5()
	{
		if (!buVector5.smethod_0("buFile"))
		{
			throw new RegisterException("buFile");
		}
		double_0 = 65759743252464860.0;
		double_1 = -94571056733.0;
		string_0 = "Ur43576Gc/+%6_*uwqvbuesETRQEUNFDANTRJWJTHTN(+%+%/754734BDFREHERH";
	}

	public static void GetFilesWithKeyword(string folder, string keyword, ref List<string> FileNames)
	{
		try
		{
			FileNames.Clear();
			IEnumerable<string> enumerable = from string_1 in Directory.EnumerateFiles(folder, "*.*", SearchOption.AllDirectories)
				where Path.GetFileName(string_1).ToLower().Contains(keyword.ToLower())
				select string_1;
			foreach (string item in enumerable)
			{
				FileNames.Add(item);
			}
		}
		catch (Exception)
		{
			FileNames = new List<string>();
		}
	}

	public static void GetFilesWithKeywordWithExtension(string folder, string keyword, string Extension, ref List<string> FileNames)
	{
		try
		{
			FileNames.Clear();
			IEnumerable<string> enumerable = from string_1 in Directory.EnumerateFiles(folder, "*." + Extension, SearchOption.AllDirectories)
				where Path.GetFileName(string_1).ToLower().Contains(keyword.ToLower())
				select string_1;
			foreach (string item in enumerable)
			{
				FileNames.Add(item);
			}
		}
		catch (Exception)
		{
			FileNames = new List<string>();
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

	public static string GetDesktopFolder()
	{
		return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
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

	public static string getFileName(string FullPath)
	{
		return Path.GetFileName(FullPath);
	}

	public static string getFileNameWithoutExtension(string FullPath)
	{
		return Path.GetFileNameWithoutExtension(FullPath);
	}

	public static string getFileExtension(string FullPath)
	{
		return Path.GetExtension(FullPath);
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

	public static void getPathsInFullPath(string Path, ref List<string> Paths)
	{
		try
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(Path);
			Paths = new List<string>();
			if (directoryInfo.Exists)
			{
				string[] directories = Directory.GetDirectories(directoryInfo.FullName);
				string[] array = directories;
				foreach (string item in array)
				{
					Paths.Add(item);
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

	public static void getPathsInPath(string BasePath, ref List<string> Paths)
	{
		try
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(BasePath);
			Paths = new List<string>();
			if (directoryInfo.Exists)
			{
				string[] array = (from string_0 in Directory.GetDirectories(directoryInfo.FullName).Select(Path.GetFileName)
					orderby string_0
					select string_0).ToArray();
				string[] array2 = array;
				foreach (string item in array2)
				{
					Paths.Add(item);
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "Path: " + BasePath.ToString();
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
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

	public static void CopyFilesRecursively(string sourcePath, string targetPath)
	{
		string[] directories = Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories);
		foreach (string text in directories)
		{
			Directory.CreateDirectory(text.Replace(sourcePath, targetPath));
		}
		string[] files = Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories);
		foreach (string text2 in files)
		{
			File.Copy(text2, text2.Replace(sourcePath, targetPath), overwrite: true);
		}
	}

	public static void CopyFileToFolder(string FileName, string Path)
	{
		try
		{
			FileInfo fileInfo = new FileInfo(FileName);
			if (fileInfo.Exists)
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(Path);
				if (!directoryInfo.Exists)
				{
					directoryInfo.Create();
				}
				string fileName = getFileName(fileInfo.FullName);
				fileInfo.CopyTo(directoryInfo?.ToString() + "\\" + fileName);
			}
		}
		catch (Exception)
		{
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
		}
		catch (Exception mSException)
		{
			string text2 = "";
			buLog.addLog(text2, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text2);
		}
	}

	public static void OpenPasswordCS(string FileName, double Key)
	{
		try
		{
			string text = "";
			int num = 0;
			FileStream input = new FileStream(FileName, FileMode.Open);
			BinaryReader binaryReader = new BinaryReader(input);
			try
			{
				num = binaryReader.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					byte value = Convert.ToByte(binaryReader.ReadDouble() / (67.928 * Key));
					text = (AppSecurity.Pass1 = text + Convert.ToChar(value));
				}
				text = "";
				num = binaryReader.ReadInt32();
				for (int j = 0; j < num; j++)
				{
					byte value2 = Convert.ToByte(binaryReader.ReadDouble() / (67.928 * Key));
					text = (AppSecurity.Pass2 = text + Convert.ToChar(value2));
				}
				text = "";
				num = binaryReader.ReadInt32();
				for (int k = 0; k < num; k++)
				{
					byte value3 = Convert.ToByte(binaryReader.ReadDouble() / (67.928 * Key));
					text = (AppSecurity.Pass3 = text + Convert.ToChar(value3));
				}
				text = "";
				num = binaryReader.ReadInt32();
				for (int l = 0; l < num; l++)
				{
					byte value4 = Convert.ToByte(binaryReader.ReadDouble() / (67.928 * Key));
					text = (AppSecurity.Pass4 = text + Convert.ToChar(value4));
				}
				text = "";
				num = binaryReader.ReadInt32();
				for (int m = 0; m < num; m++)
				{
					byte value5 = Convert.ToByte(binaryReader.ReadDouble() / (67.928 * Key));
					text = (AppSecurity.Pass5 = text + Convert.ToChar(value5));
				}
				text = "";
				num = binaryReader.ReadInt32();
				for (int n = 0; n < num; n++)
				{
					byte value6 = Convert.ToByte(binaryReader.ReadDouble() / (67.928 * Key));
					text = (AppSecurity.Pass6 = text + Convert.ToChar(value6));
				}
				text = "";
				num = binaryReader.ReadInt32();
				for (int num2 = 0; num2 < num; num2++)
				{
					byte value7 = Convert.ToByte(binaryReader.ReadDouble() / (67.928 * Key));
					text = (AppSecurity.Pass7 = text + Convert.ToChar(value7));
				}
				text = "";
				num = binaryReader.ReadInt32();
				for (int num3 = 0; num3 < num; num3++)
				{
					byte value8 = Convert.ToByte(binaryReader.ReadDouble() / (67.928 * Key));
					text = (AppSecurity.Pass8 = text + Convert.ToChar(value8));
				}
				text = "";
				num = binaryReader.ReadInt32();
				for (int num4 = 0; num4 < num; num4++)
				{
					byte value9 = Convert.ToByte(binaryReader.ReadDouble() / (67.928 * Key));
					text = (AppSecurity.Pass9 = text + Convert.ToChar(value9));
				}
				text = "";
				num = binaryReader.ReadInt32();
				for (int num5 = 0; num5 < num; num5++)
				{
					byte value10 = Convert.ToByte(binaryReader.ReadDouble() / (67.928 * Key));
					text = (AppSecurity.Pass10 = text + Convert.ToChar(value10));
				}
				binaryReader.Close();
			}
			catch (Exception)
			{
			}
			finally
			{
				binaryReader.Close();
			}
		}
		catch (Exception mSException)
		{
			string text2 = "";
			buLog.addLog(text2, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text2);
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
			buString5.ListToSpecificList("<UndoItem>", "</UndoItem>", AddStartEndKey: false, StringList, ref CalcList);
			if (CalcList.Count > 0)
			{
				int num = 0;
				for (int num2 = CalcList.Count - 1; num2 >= 0; num2--)
				{
					Undo undo = new Undo();
					List<List<string>> CalcList2 = new List<List<string>>();
					buString5.ListToSpecificList("<eEntities>", "</eEntities>", AddStartEndKey: false, CalcList[num2], ref CalcList2);
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
		buString5.ListToSpecificList("<eEntities>", "</eEntities>", AddStartEndKey: false, EntitiesLines, ref CalcList);
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
			List<buClass.Apps.ProfileJob> Profiles = new List<buClass.Apps.ProfileJob>();
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
			List<buClass.Apps.ProfileJob> Profiles = new List<buClass.Apps.ProfileJob>();
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
			List<buClass.Apps.ProfileJob> Profiles = new List<buClass.Apps.ProfileJob>();
			OpenBuCadCam(FileName, Options, ref FileInfo, ref Entities, ref CamList, ref Layers, ref Tags, ref AppOption, ref Profiles);
		}
		catch (Exception mSException)
		{
			string text = "FileName : " + FileName;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public static void OpenBuCadCam(string FileName, buCadFileOpenOptions Options, ref buCadCamFileInfo FileInfo, ref List<eEntities> Entities, ref List<camBase> CamList, ref List<LayerBase> Layers, ref List<string> Tags, ref object AppOption, ref List<buClass.Apps.ProfileJob> Profiles)
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

	public static void OpenBuCadCam(ArrayList Lines, buCadFileOpenOptions Options, ref buCadCamFileInfo FileInfo, ref List<eEntities> Entities, ref List<camBase> CamList, ref List<LayerBase> Layers, ref List<string> Tags, ref object AppOption, ref List<buClass.Apps.ProfileJob> Profiles)
	{
		try
		{
			List<List<string>> CalcList = new List<List<string>>();
			Entities.Clear();
			Profiles.Clear();
			buString5.ListToSpecificList("<eEntities>", "</eEntities>", AddStartEndKey: true, Lines, ref CalcList);
			for (int i = 0; i <= CalcList.Count - 1; i++)
			{
				eEntities eEntities2 = new eEntities();
				eEntities2 = eEntities.Decode(CalcList[i], "", SerilizationMode.MultiLine);
				eEntities2.EntityIndex = Entities.Count;
				Entities.Add(eEntities2);
			}
			CalcList = new List<List<string>>();
			buString5.ListToSpecificList("<LayerBase>", "</LayerBase>", AddStartEndKey: false, Lines, ref CalcList);
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
			buString5.ListToSpecificList("<ProfileJob>", "</ProfileJob>", AddStartEndKey: true, Lines, ref CalcList);
			for (int k = 0; k <= CalcList.Count - 1; k++)
			{
				buClass.Apps.ProfileJob Job = new buClass.Apps.ProfileJob();
				buClass.Apps.ProfileJob.Decode(CalcList[k], ref Job);
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
			buString5.ListToSpecificList("<buCadCamFileInfo>", "</buCadCamFileInfo>", AddStartEndKey: true, Lines, ref CalcList);
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

	public static void SaveBuCadCam(string FileName, buCadFileSaveOptions Options, buCadCamFileInfo FileInfo, List<eEntities> Entities, List<camBase> CamList, List<LayerBase> Layers, List<string> Tags, object AppOption, object AuxOption, List<buClass.Apps.ProfileJob> ProfileJobs)
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
				arrayList.AddRange(buClass.Apps.ProfileJob.ToDef(ProfileJobs, 2));
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

	public static void OpenKinemticFile(string FileName, ref KinematicBase5 Kinematic)
	{
		try
		{
			ArrayList StringList = new ArrayList();
			Kinematic = new KinematicBase5();
			new List<List<string>>();
			OpenFromFile(FileName, ref StringList);
			buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, Kinematic);
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

	public static void SaveKinematicFile(string FileName, KinematicBase5 Kinematic)
	{
		try
		{
			ArrayList arrayList = new ArrayList();
			arrayList.AddRange(Kinematic.ToDefAll("", 2, SerilizationMode5.MultiLine));
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

	public static void SavePlaneFile(string FileName, List<Plane> Planes)
	{
		try
		{
			if (Planes.Count > 0)
			{
				ArrayList arrayList = new ArrayList();
				for (int i = 0; i <= Planes.Count - 1; i++)
				{
					string value = "Plane: " + buSerilization5.ToDef(Planes[i]);
					arrayList.Add(value);
				}
				SaveToFile(arrayList, FileName);
				buLogVer5.addToLog("SavePlaneFile", "SavePlaneFile", "SavePlaneFile Saved", "Ok", -1.0, 0.0);
			}
		}
		catch (Exception mSException)
		{
			string auxMessage = "FileName : " + FileName;
			buLogVer5.addToLog("SavePlaneFile", "SavePlaneFile", "SavePlaneFile Saved", "Error", -1.0, 0.0);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, auxMessage);
		}
	}

	public static void SavePlaneFile(string FileName, List<SelectedPlaneInfo> Planes)
	{
		try
		{
			if (Planes.Count > 0)
			{
				ArrayList arrayList = new ArrayList();
				for (int i = 0; i <= Planes.Count - 1; i++)
				{
					arrayList.Add("<SelectedPlaneInfo>");
					arrayList.Add("  Plane: " + buSerilization5.ToDef(Planes[i].refPlane));
					arrayList.Add("  Explanation: " + Planes[i].Explanation);
					arrayList.Add("  Length: " + Planes[i].Length);
					arrayList.Add("  Height: " + Planes[i].Height);
					arrayList.Add("</SelectedPlaneInfo>");
				}
				SaveToFile(arrayList, FileName);
				buLogVer5.addToLog("SavePlaneFile", "SavePlaneFile", "SavePlaneFile Saved", "Ok", -1.0, 0.0);
			}
		}
		catch (Exception mSException)
		{
			string auxMessage = "FileName : " + FileName;
			buLogVer5.addToLog("SavePlaneFile", "SavePlaneFile", "SavePlaneFile Saved", "Error", -1.0, 0.0);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, auxMessage);
		}
	}

	public static void OpenPlaneFile(string FileName, ref List<Plane> Planes)
	{
		try
		{
			ArrayList StringList = new ArrayList();
			Planes = new List<Plane>();
			OpenFromFile(FileName, ref StringList);
			for (int i = 0; i <= StringList.Count - 1; i++)
			{
				Planes.Add(buSerilization5.DecoderFromPlane(StringList[i].ToString()));
			}
			buLogVer5.addToLog("OpenPlaneFile", "OpenPlaneFile", "OpenPlaneFile Opened", "Ok", -1.0, 0.0);
			GC.Collect();
		}
		catch (Exception mSException)
		{
			string auxMessage = "FileName : " + FileName;
			buLogVer5.addToLog("OpenPlaneFile", "OpenPlaneFile", "OpenPlaneFile Opened", "Error", -1.0, 0.0);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, auxMessage);
		}
	}

	public static void OpenPlaneFile(string FileName, ref List<SelectedPlaneInfo> Planes)
	{
		try
		{
			ArrayList StringList = new ArrayList();
			List<List<string>> CalcList = new List<List<string>>();
			OpenFromFile(FileName, ref StringList);
			buString5.ListToSpecificList("<SelectedPlaneInfo>", "</SelectedPlaneInfo>", AddStartEndKey: false, StringList, ref CalcList);
			Planes = new List<SelectedPlaneInfo>();
			for (int i = 0; i <= CalcList.Count - 1; i++)
			{
				SelectedPlaneInfo selectedPlaneInfo = null;
				if (CalcList[i].Count >= 1)
				{
					selectedPlaneInfo = new SelectedPlaneInfo();
					selectedPlaneInfo.refPlane = buSerilization5.DecoderFromPlane(CalcList[i][0]);
				}
				if (CalcList[i].Count >= 2)
				{
					string[] array = CalcList[i][1].Split(':');
					if ((array != null) & (array.Length >= 2))
					{
						selectedPlaneInfo.Explanation = array[1].Trim();
					}
				}
				if (CalcList[i].Count >= 3)
				{
					string[] array2 = CalcList[i][2].Split(':');
					if (((array2 != null) & (array2.Length >= 2)) && buNumeric5.IsNumeric(array2[1]))
					{
						selectedPlaneInfo.Length = Convert.ToDouble(array2[1].Trim());
					}
				}
				if (CalcList[i].Count >= 3)
				{
					string[] array3 = CalcList[i][3].Split(':');
					if (((array3 != null) & (array3.Length >= 2)) && buNumeric5.IsNumeric(array3[1]))
					{
						selectedPlaneInfo.Height = Convert.ToDouble(array3[1].Trim());
					}
				}
				if (selectedPlaneInfo != null)
				{
					devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(CompositeCurve.CreateRectangle(selectedPlaneInfo.refPlane, selectedPlaneInfo.refPlane.AxisX.X * selectedPlaneInfo.Length, selectedPlaneInfo.Height));
					selectedPlaneInfo.entityPlane = region.ConvertToMesh();
					Planes.Add(selectedPlaneInfo);
				}
			}
			buLogVer5.addToLog("OpenPlaneFile", "OpenPlaneFile", "OpenPlaneFile Opened", "Ok", -1.0, 0.0);
			GC.Collect();
		}
		catch (Exception mSException)
		{
			string auxMessage = "FileName : " + FileName;
			buLogVer5.addToLog("OpenPlaneFile", "OpenPlaneFile", "OpenPlaneFile Opened", "Error", -1.0, 0.0);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, auxMessage);
		}
	}

	public static void SaveMachineConfigFile(string FileName, MachineDef Config)
	{
		try
		{
		}
		catch (Exception mSException)
		{
			string text = "FileName : " + FileName;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public static void OpenMachineConfigFile(string FileName, ref MachineDef Mach, MachineConfigSettings Settings)
	{
		try
		{
			ArrayList StringList = new ArrayList();
			Mach = new MachineDef();
			List<List<string>> CalcList = new List<List<string>>();
			OpenFromFile(FileName, ref StringList);
			buString5.ListToSpecificList("<MachineDefPart>", "</MachineDefPart>", AddStartEndKey: true, StringList, ref CalcList);
			for (int i = 0; i <= CalcList.Count - 1; i++)
			{
				MachineDefPart machineDefPart = new MachineDefPart();
				buSerilization5.Decode(CalcList[i], "", SerilizationMode5.MultiLine, machineDefPart);
				if (machineDefPart.PartType.Trim() == Settings.PartTypeInfo.Trim())
				{
					string path = GetPath(machineDefPart.PartFileName);
					string fileNameWithoutExtension = getFileNameWithoutExtension(machineDefPart.PartFileName);
					string fileExtension = getFileExtension(machineDefPart.PartFileName);
					machineDefPart.PartFileName = path + "\\" + fileNameWithoutExtension + Settings.PartTypeAdder + fileExtension;
				}
				FileInfo fileInfo = new FileInfo(AppPath.MachineSimConfig + "\\" + machineDefPart.PartFileName);
				if (fileInfo.Exists)
				{
					buCall.buVector5_0.ReadStlFile(fileInfo.FullName, ref machineDefPart.Entities);
					machineDefPart.Entities[0].Regen(0.1);
					Mach.MachineParts.Add(machineDefPart);
				}
			}
			CalcList = new List<List<string>>();
			OpenFromFile(FileName, ref StringList);
			buString5.ListToSpecificList("<ClamperDefPart>", "</ClamperDefPart>", AddStartEndKey: false, StringList, ref CalcList);
			for (int j = 0; j <= CalcList.Count - 1; j++)
			{
				CalcList[j].Insert(0, "<MachineDefPart>");
				CalcList[j].Add("/<MachineDefPart>");
				MachineDefPart machineDefPart2 = new MachineDefPart();
				buSerilization5.Decode(CalcList[j], "", SerilizationMode5.MultiLine, machineDefPart2);
				FileInfo fileInfo2 = new FileInfo(AppPath.MachineSimConfig + "\\" + machineDefPart2.PartFileName);
				if (fileInfo2.Exists)
				{
					buCall.buVector5_0.ReadStlFile(fileInfo2.FullName, ref machineDefPart2.Entities);
					Mach.Clampers.Add(machineDefPart2);
				}
			}
			buLog.addLog("Macihne Config File Opened", "Ok", MethodBase.GetCurrentMethod().Name, FileName, "", 0.0, 0.0);
			GC.Collect();
		}
		catch (Exception mSException)
		{
			string text = "FileName : " + FileName;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public static void OpenDxfDwg(ref List<Entity> EntityList, string FileName, string LayerName = "Default")
	{
		try
		{
			ReadFileAsync readFileAsync = new ReadAutodesk(FileName);
			((ReadAutodesk)readFileAsync).ExtrudeByThickness = false;
			Design design = new Design();
			design.Clear();
			design.DoWork(readFileAsync);
			for (int i = 0; i <= readFileAsync.Entities.Count - 1; i++)
			{
				Entity entity = readFileAsync.Entities[i];
				entity.EntityData = new CustomData();
				if (LayerName.Length > 0)
				{
					entity.LayerName = "Default";
				}
				EntityList.Add(entity);
			}
		}
		catch (Exception mSException)
		{
			string text = "FileNmae : " + FileName;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public static void OpenDxfDwg(ref Design Viewport, string FileName)
	{
		try
		{
			ReadFileAsync readFileAsync = new ReadAutodesk(FileName);
			Viewport.Clear();
			Viewport.DoWork(readFileAsync);
			if (readFileAsync.Entities != null && readFileAsync.Entities.Count > 0)
			{
				readFileAsync.OpenTo(Viewport);
			}
		}
		catch (Exception mSException)
		{
			string text = "FileNmae : " + FileName;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	[AsyncStateMachine(typeof(Class172))]
	[DebuggerStepThrough]
	public Task<ReadFileAsync> OpenDxfDwgAsync(Design Viewport, string filePath)
	{
		Class172 stateMachine = new Class172();
		stateMachine.asyncTaskMethodBuilder_0 = AsyncTaskMethodBuilder<ReadFileAsync>.Create();
		stateMachine.buFile5_0 = this;
		stateMachine.design_0 = Viewport;
		stateMachine.string_0 = filePath;
		stateMachine.int_0 = -1;
		stateMachine.asyncTaskMethodBuilder_0.Start(ref stateMachine);
		return stateMachine.asyncTaskMethodBuilder_0.Task;
	}

	public static void SaveDxfDwg(List<Entity> EntityList, string FileName)
	{
		try
		{
			Design viewport = null;
			EyeCreateProps eyeCreateProps = new EyeCreateProps();
			eyeCreateProps.ShowToolBar = false;
			eyeCreateProps.ShowViewCube = false;
			eyeCreateProps.ShowCoordinateArrow = false;
			buEyeShotFunctions.CreateControlsTool(FirstCreate: true, eyeCreateProps, ref viewport);
			for (int i = 0; i <= EntityList.Count - 1; i++)
			{
				EntityList[i].LayerName = "Default";
				viewport.Entities.Add(EntityList[i]);
			}
			WriteFileAsync writeFileAsync = null;
			writeFileAsync = new WriteAutodesk(new WriteAutodeskParams(viewport.Document), FileName);
			viewport.StartWork(writeFileAsync);
		}
		catch (Exception mSException)
		{
			string text = "FileNmae : " + FileName;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public static void SaveDxfDwg(Design viewport, string FileName)
	{
		try
		{
			WriteFileAsync writeFileAsync = null;
			writeFileAsync = new WriteAutodesk(new WriteAutodeskParams(viewport.Document), FileName);
			viewport.DoWork(writeFileAsync);
		}
		catch (Exception mSException)
		{
			string text = "FileNmae : " + FileName;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	[AsyncStateMachine(typeof(Class173))]
	[DebuggerStepThrough]
	public void SaveDxfDwgAsyc(Design viewport, string FileName)
	{
		Class173 stateMachine = new Class173();
		stateMachine.asyncVoidMethodBuilder_0 = AsyncVoidMethodBuilder.Create();
		stateMachine.buFile5_0 = this;
		stateMachine.design_0 = viewport;
		stateMachine.string_0 = FileName;
		stateMachine.int_0 = -1;
		stateMachine.asyncVoidMethodBuilder_0.Start(ref stateMachine);
	}

	public static void OpenStl(ref List<Entity> EntityList, string FileName)
	{
		try
		{
			ReadFileAsync readFileAsync = new ReadSTL(FileName);
			Design design = new Design();
			design.Clear();
			design.DoWork(readFileAsync);
			for (int i = 0; i <= readFileAsync.Entities.Count - 1; i++)
			{
				Entity entity = readFileAsync.Entities[i];
				entity.EntityData = new CustomData();
				entity.LayerName = "Default";
				EntityList.Add(entity);
			}
		}
		catch (Exception mSException)
		{
			string text = "FileNmae : " + FileName;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public static void OpenStl(ref Design Viewport, string FileName)
	{
		try
		{
			ReadFileAsync readFileAsync = new ReadSTL(FileName);
			Viewport.Clear();
			Viewport.DoWork(readFileAsync);
			if (readFileAsync.Entities != null && readFileAsync.Entities.Count > 0)
			{
				readFileAsync.OpenTo(Viewport);
			}
		}
		catch (Exception mSException)
		{
			string text = "FileNmae : " + FileName;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public static void SaveStl(Design Viewport, string FileName)
	{
		WriteFileAsync writeFileAsync = null;
		writeFileAsync = new WriteSTL(new WriteParams(Viewport.Document), FileName);
		Viewport.DoWork(writeFileAsync);
	}

	public static void SaveStl(Design Viewport, string FileName, double Deviation, bool SelectedOnly = false)
	{
		WriteFileAsync writeFileAsync = null;
		writeFileAsync = new WriteSTL(Viewport.Document, FileName, Deviation, ascii: false, SelectedOnly);
		Viewport.DoWork(writeFileAsync);
	}

	public static void OpenObj(ref List<Entity> EntityList, string FileName)
	{
		try
		{
			ReadFileAsync readFileAsync = new ReadOBJ(FileName);
			Design design = new Design();
			design.Clear();
			design.DoWork(readFileAsync);
			for (int i = 0; i <= readFileAsync.Entities.Count - 1; i++)
			{
				Entity entity = readFileAsync.Entities[i];
				entity.EntityData = new CustomData();
				entity.LayerName = "Default";
				EntityList.Add(entity);
			}
		}
		catch (Exception mSException)
		{
			string text = "FileNmae : " + FileName;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public static void OpenObj(ref Design Viewport, string FileName)
	{
		try
		{
			ReadFileAsync readFileAsync = new ReadOBJ(FileName);
			Viewport.Clear();
			Viewport.DoWork(readFileAsync);
			if (readFileAsync.Entities != null && readFileAsync.Entities.Count > 0)
			{
				readFileAsync.OpenTo(Viewport);
			}
		}
		catch (Exception mSException)
		{
			string text = "FileNmae : " + FileName;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public static void SaveObj(Design Viewport, string FileName)
	{
		WriteFileAsync writeFileAsync = null;
		writeFileAsync = new WriteOBJ(new WriteParamsWithMaterials(Viewport.Document), FileName);
		Viewport.DoWork(writeFileAsync);
	}

	public static void OpenStep(ref List<Entity> EntityList, string FileName)
	{
		try
		{
			ReadFileAsync readFileAsync = new ReadSTEP(FileName);
			Design design = new Design();
			design.DoWork(readFileAsync);
			for (int i = 0; i <= readFileAsync.Entities.Count - 1; i++)
			{
				Entity entity = readFileAsync.Entities[i];
				entity.EntityData = new CustomData();
				entity.LayerName = "Default";
				EntityList.Add(entity);
			}
		}
		catch (Exception mSException)
		{
			string text = "FileNmae : " + FileName;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public static void OpenStep(ref Design Viewport, string FileName)
	{
		try
		{
			ReadFileAsync readFileAsync = new ReadSTEP(FileName);
			new Design();
			Viewport.Clear();
			Viewport.DoWork(readFileAsync);
			readFileAsync.OpenTo(Viewport);
		}
		catch (Exception mSException)
		{
			string text = "FileNmae : " + FileName;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public static void SaveStep(Design Viewport, string FileName)
	{
		WriteFileAsync writeFileAsync = null;
		writeFileAsync = new WriteSTEP(new WriteParamsWithUnits(Viewport.Document), FileName);
		Viewport.DoWork(writeFileAsync);
	}

	public static void OpenIges(ref List<Entity> EntityList, string FileName)
	{
		try
		{
			ReadFileAsync readFileAsync = new ReadIGES(FileName);
			Design design = new Design();
			design.Clear();
			design.DoWork(readFileAsync);
			for (int i = 0; i <= readFileAsync.Entities.Count - 1; i++)
			{
				Entity entity = readFileAsync.Entities[i];
				entity.EntityData = new CustomData();
				entity.LayerName = "Default";
				EntityList.Add(entity);
			}
		}
		catch (Exception mSException)
		{
			string text = "FileNmae : " + FileName;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public static void OpenIges(ref Design Viewport, string FileName)
	{
		try
		{
			ReadFileAsync readFileAsync = new ReadIGES(FileName);
			new Design();
			Viewport.Clear();
			Viewport.DoWork(readFileAsync);
			if (readFileAsync.Entities.Count > 0)
			{
				readFileAsync.OpenTo(Viewport);
			}
		}
		catch (Exception mSException)
		{
			string text = "FileNmae : " + FileName;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public static void SaveIges(Design Viewport, string FileName)
	{
		WriteFileAsync writeFileAsync = null;
		writeFileAsync = new WriteIGES(new WriteParamsWithUnits(Viewport.Document), FileName);
		Viewport.DoWork(writeFileAsync);
	}

	public static void OpenFromFile(string FileName, ref List<string> StringList)
	{
		try
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
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, FileName);
		}
	}

	public static void OpenFromFile(string FileName, ref ArrayList StringList)
	{
		try
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
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, FileName);
		}
	}

	public static void OpenFromFile(string FileName, ref string Str)
	{
		try
		{
			StreamReader streamReader = new StreamReader(FileName);
			Str = streamReader.ReadToEnd();
			streamReader.Close();
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, FileName);
		}
	}

	public static void SaveToFile(string String, string FileName)
	{
		TextWriter textWriter = File.CreateText(FileName);
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

	public static void SaveToFile(string String, string FileName, bool Append)
	{
		TextWriter textWriter = null;
		textWriter = (Append ? File.AppendText(FileName) : File.CreateText(FileName));
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

	public static void SaveToFile(List<string> StringList, string FileName)
	{
		TextWriter textWriter = File.CreateText(FileName);
		try
		{
			for (int i = 0; i <= StringList.Count - 1; i++)
			{
				textWriter.WriteLine(StringList[i].ToString());
			}
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

	public static void SaveToFile(List<string> StringList, string FileName, bool Append)
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

	public static void SaveToFile(List<List<string>> StringList, string FileName)
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

	public static void SaveToFile(List<List<string>> StringList, string FileName, bool Append)
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

	public static void SaveToFile(ArrayList StringList, string FileName)
	{
		TextWriter textWriter = File.CreateText(FileName);
		try
		{
			for (int i = 0; i <= StringList.Count - 1; i++)
			{
				textWriter.WriteLine(StringList[i].ToString());
			}
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

	public static void SaveToFile(ArrayList StringList, string FileName, bool Append)
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
		FileInfo fileInfo = new FileInfo(FileName);
		if (fileInfo.Exists)
		{
			fileInfo.Delete();
		}
		ZipFile.CreateFromDirectory(Folder, FileName);
	}

	public static void ZipFolderToFile(string Folder, string FileName, CompressionLevel Level)
	{
		ZipFile.CreateFromDirectory(Folder, FileName, Level, includeBaseDirectory: false);
	}

	public static void ExtractToFolder(string Folder, string FileName)
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(Folder);
		if (directoryInfo.Exists)
		{
			directoryInfo.Delete(recursive: true);
		}
		ZipFile.ExtractToDirectory(FileName, Folder);
	}

	public static void OpenSurfaceReadFile(string Filename, ref List<Pnt3D> pntTeachList)
	{
		ArrayList StringList = new ArrayList();
		OpenFromFile(Filename, ref StringList);
		ArrayList CalcList = new ArrayList();
		buString5.ListToSpecificList("<CalibRatio>", "</CalibRatio>", AddStartEndKey: false, StringList, ref CalcList);
		double result = 1.0;
		if (CalcList.Count > 0)
		{
			double.TryParse(CalcList[0].ToString(), out result);
		}
		CalcList = new ArrayList();
		pntTeachList.Clear();
		buString5.ListToSpecificList("<ReadSurface>", "</ReadSurface>", AddStartEndKey: false, StringList, ref CalcList);
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

	public static void SaveLRAFile(string FileName, List<BendingLRAMaterialData> BendingList)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add("<LRAList>");
		for (int i = 0; i <= BendingList.Count - 1; i++)
		{
			arrayList.AddRange(BendingList[i].ToDefAll("", 2, SerilizationMode.MultiLine));
		}
		arrayList.Add("</LRAList>");
		SaveToFile(arrayList, FileName);
	}

	public static void OpenLRAFile(string FileName, ref List<BendingLRAMaterialData> BendingList)
	{
		try
		{
			ArrayList arrayList = new ArrayList();
			arrayList = new ArrayList();
			buFile.OpenFromFile(FileName, ref arrayList);
			List<List<string>> CalcList = new List<List<string>>();
			buString.ListToSpecificList("<BendingLRAMaterialData>", "</BendingLRAMaterialData>", AddStartEndKey: true, arrayList, ref CalcList);
			for (int i = 0; i <= CalcList.Count - 1; i++)
			{
				BendingLRAMaterialData bendingLRAMaterialData = new BendingLRAMaterialData();
				buSerilization.Decode(CalcList[i], "", SerilizationMode.MultiLine, bendingLRAMaterialData);
				BendingList.Add(bendingLRAMaterialData);
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("OpenLRAFile", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "OpenLRAFile");
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
