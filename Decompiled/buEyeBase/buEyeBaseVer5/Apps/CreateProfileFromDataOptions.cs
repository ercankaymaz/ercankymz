using System;
using System.Drawing;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class CreateProfileFromDataOptions : buSerilization5
{
	public double Length = 1000.0;

	public double NeededWidth = 0.0;

	public double NeededHeight = 0.0;

	public double SupportBlockZWidth = 0.0;

	public double SupportBlockZHeight = 0.0;

	public double SupportBlockY1Width = 0.0;

	public double SupportBlockY1Height = 0.0;

	public double SupportBlockY2Width = 0.0;

	public double SupportBlockY2Height = 0.0;

	public bool ConnectSmallGap = true;

	public double GapConnection = 0.1;

	public double SortResolituon = 0.05;

	public double MinPointFilterLength = 0.0;

	public SortingIntersectionRulesType IntersectionRules = SortingIntersectionRulesType.LowerIndex;

	public SortingNextGroupFindRulesType NextFroupRules = SortingNextGroupFindRulesType.ClosestLength;

	public int MaxClamper = 4;

	public int Transparency = 200;

	public Color color = Color.DarkGray;

	public string FileName = "";

	public string FullName = "";

	public string Name = "";

	public CreateProfileFromDataOptions()
	{
	}

	public CreateProfileFromDataOptions(CreateProfileFromDataOptions data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
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

	public override string ToString()
	{
		return "Length :" + Length;
	}
}
