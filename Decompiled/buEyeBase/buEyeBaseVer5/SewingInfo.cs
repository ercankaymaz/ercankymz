using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class SewingInfo : buSerilization5
{
	public List<SewingVertex> Vertex = new List<SewingVertex>();

	public double StitchLengt = 3.3;

	public double HeadSpeed = 2000.0;

	public int StartStitchCount = 0;

	public int EndStitchCount = 0;

	public SewingAddStitchType StartStitchType = SewingAddStitchType.None;

	public SewingAddStitchType EndStitchType = SewingAddStitchType.None;

	public bool isStitchDrawing = true;

	public int ID = -1;

	public int Style = 0;

	public SewingInfo()
	{
	}

	public SewingInfo(SewingInfo data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null))
		{
			return;
		}
		if (GetType() == CopiedClass.GetType())
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
		Vertex.Clear();
		for (int j = 0; j <= data.Vertex.Count - 1; j++)
		{
			Vertex.Add(new SewingVertex(data.Vertex[j]));
		}
	}

	public ArrayList ToDef(int Space)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add(buString5.SpaceChar(Space) + buSerilization5.ClassToString(this));
		arrayList.Add(buString5.SpaceChar(Space) + "<SewingVertex>");
		for (int i = 0; i <= Vertex.Count - 1; i++)
		{
			arrayList.Add(buString5.SpaceChar(Space + 2) + "<Vertex>");
			string text = buString5.SpaceChar(Space + 4) + buSerilization5.ToDef(Vertex[i].Point);
			text += " % ";
			text = text + Vertex[i].DeltaX + " ; " + Vertex[i].DeltaY + " ; " + Vertex[i].FootHeight + " ; " + Vertex[i].Speed;
			text += " % ";
			if (Vertex[i].Codes.Count > 0)
			{
				for (int j = 0; j <= Vertex[i].Codes.Count - 1; j++)
				{
					text += buSerilization5.ClassToString(Vertex[i].Codes[j]);
					if (j < Vertex[i].Codes.Count - 1)
					{
						text += " ; ";
					}
				}
			}
			text += " % ";
			if (Vertex[i].Punterez != null)
			{
				text = text + Vertex[i].Punterez.Angle + ";" + Vertex[i].Punterez.Count + ";" + Vertex[i].Punterez.Height + ";" + Vertex[i].Punterez.Length + ";" + Vertex[i].Punterez.PunterizType.ToString() + ";" + Vertex[i].Punterez.Width;
			}
			arrayList.Add(text);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "</Vertex>");
		}
		arrayList.Add(buString5.SpaceChar(Space) + "</SewingVertex>");
		return arrayList;
	}

	public static void Decode(List<string> SL, ref SewingInfo Sewing)
	{
		try
		{
			object obj = null;
			if (SL.Count < 3)
			{
				return;
			}
			Sewing = new SewingInfo();
			obj = Sewing;
			buSerilization5.StringToClass(ref obj, SL[0]);
			List<List<string>> CalcList = new List<List<string>>();
			buString5.ListToSpecificList("<Vertex>", "</Vertex>", AddStartEndKey: false, SL, ref CalcList);
			if (CalcList.Count <= 0)
			{
				return;
			}
			string[] array = null;
			for (int i = 0; i <= CalcList.Count - 1; i++)
			{
				SewingVertex sewingVertex = new SewingVertex();
				array = CalcList[i][0].Split('%');
				if ((array != null) & (array.Length >= 1))
				{
					sewingVertex.Point = buSerilization5.DecoderFromPoint3D(array[0]);
				}
				if ((array != null) & (array.Length >= 2))
				{
					string[] array2 = array[1].Split(';');
					if ((array2 != null) & (array2.Length >= 2))
					{
						sewingVertex.DeltaX = Convert.ToDouble(array2[0]);
						sewingVertex.DeltaY = Convert.ToDouble(array2[1]);
					}
					if ((array2 != null) & (array2.Length >= 3))
					{
						sewingVertex.FootHeight = Convert.ToDouble(array2[2]);
					}
					if ((array2 != null) & (array2.Length >= 4))
					{
						sewingVertex.Speed = Convert.ToDouble(array2[3]);
					}
				}
				if ((array != null) & (array.Length >= 3))
				{
					string[] array3 = array[2].Split(';');
					if (array3 != null)
					{
						for (int j = 0; j <= array3.Length - 1; j++)
						{
							if (array3[j].Trim().Length > 0)
							{
								object ObjPar = new SewingCode();
								buSerilization5.StringToClass(ref ObjPar, array3[j]);
								sewingVertex.Codes.Add((SewingCode)ObjPar);
							}
						}
					}
				}
				if ((array != null) & (array.Length >= 4))
				{
					string[] array4 = array[3].Split(';');
					if (array4 != null && array4.Length >= 6)
					{
						sewingVertex.Punterez = new SewingPunteriz();
						sewingVertex.Punterez.Angle = Convert.ToDouble(array4[0]);
						sewingVertex.Punterez.Count = Convert.ToInt32(array4[1]);
						sewingVertex.Punterez.Height = Convert.ToDouble(array4[2]);
						sewingVertex.Punterez.Length = Convert.ToDouble(array4[3]);
						Enum.TryParse<SewingPunterizType>(array4[4], ignoreCase: true, out sewingVertex.Punterez.PunterizType);
						sewingVertex.Punterez.Width = Convert.ToDouble(array4[5]);
					}
				}
				Sewing.Vertex.Add(sewingVertex);
			}
		}
		catch (Exception)
		{
		}
	}

	public override string ToString()
	{
		string text = "Len: " + StitchLengt.ToString("f2") + " , Stitch Mode: " + isStitchDrawing;
		if (Vertex.Count > 0)
		{
			text = text + " Vertex: " + Vertex.Count;
		}
		return text;
	}
}
