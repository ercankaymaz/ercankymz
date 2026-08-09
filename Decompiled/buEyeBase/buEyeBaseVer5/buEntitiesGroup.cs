using System;
using System.Collections;
using System.Collections.Generic;
using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class buEntitiesGroup : buSerilization5
{
	public buEntityList Outside = new buEntityList();

	public List<buEntityList> Inside = null;

	public List<buEntityList> OpenEntities = null;

	public List<buEntityList> TempEntities = null;

	public buEntityList Text = null;

	public buEntityList Solid = null;

	public buEntitiesGroup()
	{
		Outside = new buEntityList();
		Inside = new List<buEntityList>();
	}

	public buEntitiesGroup(buEntitiesGroup data)
	{
		new object();
		if (!(this != null && data != null))
		{
			return;
		}
		if (data.Outside != null)
		{
			Outside = new buEntityList(data.Outside);
			if (data.Outside.Points != null)
			{
				Outside.Points = new List<Point3D>();
				buVector5.Copy(data.Outside.Points, ref Outside.Points);
			}
		}
		if (data.Text != null)
		{
			Text = new buEntityList(data.Text);
			if (data.Text.Points != null)
			{
				Text.Points = new List<Point3D>();
				buVector5.Copy(data.Text.Points, ref Text.Points);
			}
		}
		if (data.Solid != null)
		{
			Solid = new buEntityList(data.Solid);
			if (data.Solid.Points != null)
			{
				Solid.Points = new List<Point3D>();
				buVector5.Copy(data.Solid.Points, ref Solid.Points);
			}
		}
		if (data.Inside != null)
		{
			Inside = new List<buEntityList>();
			for (int i = 0; i <= data.Inside.Count - 1; i++)
			{
				buEntityList buEntityList2 = new buEntityList(data.Inside[i]);
				if (data.Inside[i].Points != null)
				{
					buEntityList2.Points = new List<Point3D>();
					buVector5.Copy(data.Inside[i].Points, ref buEntityList2.Points);
				}
				Inside.Add(buEntityList2);
			}
		}
		if (data.OpenEntities != null)
		{
			OpenEntities = new List<buEntityList>();
			for (int j = 0; j <= data.OpenEntities.Count - 1; j++)
			{
				buEntityList buEntityList3 = new buEntityList(data.OpenEntities[j]);
				if (data.OpenEntities[j].Points != null)
				{
					buEntityList3.Points = new List<Point3D>();
					buVector5.Copy(data.OpenEntities[j].Points, ref buEntityList3.Points);
				}
				OpenEntities.Add(buEntityList3);
			}
		}
		if (data.TempEntities == null)
		{
			return;
		}
		TempEntities = new List<buEntityList>();
		for (int k = 0; k <= data.TempEntities.Count - 1; k++)
		{
			buEntityList buEntityList4 = new buEntityList(data.TempEntities[k]);
			if (data.TempEntities[k].Points != null)
			{
				buEntityList4.Points = new List<Point3D>();
				buVector5.Copy(data.TempEntities[k].Points, ref buEntityList4.Points);
			}
			TempEntities.Add(buEntityList4);
		}
	}

	public void Translate(double dX, double dY, double dZ = 0.0)
	{
		if (Outside != null)
		{
			Outside.Translate(dX, dY, dZ);
		}
		if (Inside != null)
		{
			for (int i = 0; i <= Inside.Count - 1; i++)
			{
				buEntityList buEntityList2 = Inside[i];
				buEntityList2.Translate(dX, dY, dZ);
			}
		}
		if (OpenEntities != null)
		{
			for (int j = 0; j <= OpenEntities.Count - 1; j++)
			{
				buEntityList buEntityList3 = OpenEntities[j];
				buEntityList3.Translate(dX, dY, dZ);
			}
		}
		if (TempEntities != null)
		{
			for (int k = 0; k <= TempEntities.Count - 1; k++)
			{
				buEntityList buEntityList4 = TempEntities[k];
				buEntityList4.Translate(dX, dY, dZ);
			}
		}
		if (Text != null)
		{
			Text.Translate(dX, dY, dZ);
		}
		if (Solid != null)
		{
			Solid.Translate(dX, dY, dZ);
		}
	}

	public void Rotate(double Angle, Vector3D axis, Point3D center)
	{
		if (Outside != null)
		{
			Outside.Rotate(Angle, axis, center);
		}
		if (Inside != null)
		{
			for (int i = 0; i <= Inside.Count - 1; i++)
			{
				buEntityList buEntityList2 = Inside[i];
				buEntityList2.Rotate(Angle, axis, center);
			}
		}
		if (OpenEntities != null)
		{
			for (int j = 0; j <= OpenEntities.Count - 1; j++)
			{
				buEntityList buEntityList3 = OpenEntities[j];
				buEntityList3.Rotate(Angle, axis, center);
			}
		}
		if (TempEntities != null)
		{
			for (int k = 0; k <= TempEntities.Count - 1; k++)
			{
				buEntityList buEntityList4 = TempEntities[k];
				buEntityList4.Rotate(Angle, axis, center);
			}
		}
		if (Text != null)
		{
			Text.Rotate(Angle, axis, center);
		}
		if (Solid != null)
		{
			Solid.Rotate(Angle, axis, center);
		}
	}

	public static void Copy(List<buEntitiesGroup> refGroup, ref List<buEntitiesGroup> copiesGroup)
	{
		copiesGroup = new List<buEntitiesGroup>();
		for (int i = 0; i <= refGroup.Count - 1; i++)
		{
			if (refGroup[i] != null)
			{
				copiesGroup.Add(new buEntitiesGroup(refGroup[i]));
			}
		}
	}

	public static void ToDefGroup(buEntitiesGroup Group, int Space, ref ArrayList AL, string refChar = "")
	{
		AL = new ArrayList();
		AL.Add(buString5.SpaceChar(Space) + "<buEntitiesGroupData" + refChar + ">");
		AL.Add(buString5.SpaceChar(Space + 2) + "<buEntitiesGroupOutside>");
		AL.AddRange(buEntityList.ToDefEntity(Group.Outside, Space + 4));
		AL.Add(buString5.SpaceChar(Space + 2) + "</buEntitiesGroupOutside>");
		if (Group.Inside != null && Group.Inside.Count > 0)
		{
			AL.Add(buString5.SpaceChar(Space + 2) + "<buEntitiesGroupInside>");
			for (int i = 0; i <= Group.Inside.Count - 1; i++)
			{
				AL.Add(buString5.SpaceChar(Space + 4) + "<buEntitiesGroupInsideItem>");
				AL.AddRange(buEntityList.ToDefEntity(Group.Inside[i], Space + 6));
				AL.Add(buString5.SpaceChar(Space + 4) + "</buEntitiesGroupInsideItem>");
			}
			AL.Add(buString5.SpaceChar(Space + 2) + "</buEntitiesGroupInside>");
		}
		if (Group.OpenEntities != null && Group.OpenEntities.Count > 0)
		{
			AL.Add(buString5.SpaceChar(Space + 2) + "<buEntitiesGroupOpenEntities>");
			for (int j = 0; j <= Group.OpenEntities.Count - 1; j++)
			{
				AL.Add(buString5.SpaceChar(Space + 4) + "<buEntitiesGroupOpenEntitiesItem>");
				AL.AddRange(buEntityList.ToDefEntity(Group.OpenEntities[j], Space + 6));
				AL.Add(buString5.SpaceChar(Space + 4) + "</buEntitiesGroupOpenEntitiesItem>");
			}
			AL.Add(buString5.SpaceChar(Space + 2) + "</buEntitiesGroupOpenEntities>");
		}
		if (Group.Text != null && Group.Text.Entities.Count > 0)
		{
			AL.Add(buString5.SpaceChar(Space + 2) + "<buEntitiesGroupText>");
			AL.AddRange(buEntityList.ToDefEntity(Group.Text, Space + 4));
			AL.Add(buString5.SpaceChar(Space + 2) + "</buEntitiesGroupText>");
		}
		AL.Add(buString5.SpaceChar(Space) + "</buEntitiesGroupData" + refChar + ">");
	}

	public static ArrayList ToDefGroup(buEntitiesGroup Group, int Space, string refChar = "")
	{
		ArrayList AL = new ArrayList();
		ToDefGroup(Group, Space, ref AL, refChar);
		return AL;
	}

	public static void Decode(List<string> SL, ref buEntitiesGroup refEntityGroup, string refChar = "")
	{
		try
		{
			List<string> CalcList = new List<string>();
			buStatics.ListToSpecificList("<buEntitiesGroupData" + refChar + ">", "</buEntitiesGroupData" + refChar + ">", AddStartEndKey: true, SL, ref CalcList);
			if (CalcList.Count > 1)
			{
				SL.Clear();
				SL.AddRange(CalcList);
			}
			if (SL.Count >= 2)
			{
				refEntityGroup = new buEntitiesGroup();
				new List<string>();
				List<string> CalcList2 = new List<string>();
				List<List<string>> list = new List<List<string>>();
				buStatics.ListToSpecificList("<buEntitiesGroupOutside>", "</buEntitiesGroupOutside>", AddStartEndKey: true, SL, ref CalcList2);
				buEntityList.Decode(CalcList2, ref refEntityGroup.Outside);
				CalcList2.Clear();
				CalcList2 = new List<string>();
				list.Clear();
				list = new List<List<string>>();
				buStatics.ListToSpecificList("<buEntitiesGroupOpenEntities>", "</buEntitiesGroupOpenEntities>", AddStartEndKey: true, SL, ref CalcList2);
				buStatics.ListToSpecificList("<buEntitiesGroupOpenEntitiesItem>", "</buEntitiesGroupOpenEntitiesItem>", AddStartEndKey: true, CalcList2, ref list);
				if (list.Count > 0)
				{
					refEntityGroup.OpenEntities = new List<buEntityList>();
				}
				for (int i = 0; i <= list.Count - 1; i++)
				{
					buEntityList refEntity = new buEntityList();
					buEntityList.Decode(list[i], ref refEntity);
					refEntityGroup.OpenEntities.Add(refEntity);
				}
				CalcList2.Clear();
				CalcList2 = new List<string>();
				list.Clear();
				list = new List<List<string>>();
				buStatics.ListToSpecificList("<buEntitiesGroupInside>", "</buEntitiesGroupInside>", AddStartEndKey: true, SL, ref CalcList2);
				buStatics.ListToSpecificList("<buEntitiesGroupInsideItem>", "</buEntitiesGroupInsideItem>", AddStartEndKey: true, CalcList2, ref list);
				if (list.Count > 0)
				{
					refEntityGroup.Inside = new List<buEntityList>();
				}
				for (int j = 0; j <= list.Count - 1; j++)
				{
					buEntityList refEntity2 = new buEntityList();
					buEntityList.Decode(list[j], ref refEntity2);
					refEntityGroup.Inside.Add(refEntity2);
				}
				CalcList2.Clear();
				CalcList2 = new List<string>();
				list.Clear();
				list = new List<List<string>>();
				buStatics.ListToSpecificList("<buEntitiesGroupText>", "</buEntitiesGroupText>", AddStartEndKey: true, SL, ref CalcList2);
				buEntityList.Decode(CalcList2, ref refEntityGroup.Text);
			}
		}
		catch (Exception)
		{
		}
	}

	public override string ToString()
	{
		string text = "Outside: " + Outside.Entities.Count;
		if (Inside != null)
		{
			text = text + " - Inside: " + Inside.Count;
		}
		if (OpenEntities != null)
		{
			text = text + " - Open: " + OpenEntities.Count;
		}
		if (Text != null)
		{
			text = text + " - Text: " + Text.Entities.Count;
		}
		if (Solid != null)
		{
			text = text + " - Solid: " + Solid.Entities.Count;
		}
		return text;
	}
}
