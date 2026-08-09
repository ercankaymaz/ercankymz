using System;
using System.Drawing;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class hmiUIDataGridView : buSerilization
{
	public Font fontHeader = new Font("Arial", 14f, FontStyle.Bold);

	public Font fontCell = new Font("Times New Roman", 10f, FontStyle.Bold);

	public Color colorBackGround = Color.LightGray;

	public Color colorHeader = Color.Gray;

	public Color colorHeaderFore = Color.Black;

	public Color colorFore = Color.Black;

	public Color colorCell = Color.WhiteSmoke;

	public Color colorCellSelected = Color.Silver;

	public Color colorGrid = Color.Black;

	public hmiUIDataGridView()
	{
	}

	public hmiUIDataGridView(hmiUIDataGridView data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
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
}
