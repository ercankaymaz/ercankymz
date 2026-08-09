using System;
using System.Collections;
using System.Reflection;
using System.Windows.Forms;
using buControls.Controls;

namespace buEyeBaseVer5;

[Serializable]
public class hmiUIOptions : buSerilization5
{
	public bool VisibleStatus = true;

	public int ControlLeft = -100;

	public int ControlTop = -100;

	public int ControlWidth = 0;

	public int ControlHeight = 0;

	public int ImageIndex = -1;

	public hmiUIOptions()
	{
	}

	public hmiUIOptions(hmiUIOptions data)
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

	public static buControl hmiToControl(hmiUIOptions data, buControl Ctrl)
	{
		try
		{
			Ctrl.Visible = data.VisibleStatus;
			if (data.ControlTop >= 0)
			{
				Ctrl.Top = data.ControlTop;
			}
			if (data.ControlLeft >= 0)
			{
				Ctrl.Left = data.ControlLeft;
			}
			if (data.ControlWidth > 0)
			{
				Ctrl.Width = data.ControlWidth;
			}
			if (data.ControlHeight > 0)
			{
				Ctrl.Height = data.ControlHeight;
			}
			if (data.ImageIndex >= 0)
			{
				Ctrl.ImageIndex = data.ImageIndex;
			}
			return Ctrl;
		}
		catch (Exception)
		{
			return Ctrl;
		}
	}

	public static void controlToHmi(ref hmiUIOptions data, buControl Ctrl)
	{
		try
		{
			if (data == null)
			{
				data = new hmiUIOptions();
			}
			data.VisibleStatus = Ctrl.Visible;
			data.ControlTop = Ctrl.Top;
			data.ControlLeft = Ctrl.Left;
			data.ControlWidth = Ctrl.Width;
			data.ControlHeight = Ctrl.Height;
			data.ImageIndex = Ctrl.ImageIndex;
		}
		catch (Exception)
		{
		}
	}

	public static void CreateSerilizationOptionFromControl(Control.ControlCollection Controls, int Space, ref ArrayList AL)
	{
		string text = new string(' ', Space);
		for (int i = 0; i <= Controls.Count - 1; i++)
		{
			if (Controls[i] is buButton)
			{
				hmiUIOptions data = new hmiUIOptions();
				controlToHmi(ref data, (buControl)Controls[i]);
				AL.Add(text + Controls[i].Name + " = " + buSerilization5.ClassToString(data));
			}
			if (Controls[i] is buSpin)
			{
				hmiUIOptions data2 = new hmiUIOptions();
				controlToHmi(ref data2, (buControl)Controls[i]);
				AL.Add(text + Controls[i].Name + " = " + buSerilization5.ClassToString(data2));
			}
			if (Controls[i] is buTextBox)
			{
				hmiUIOptions data3 = new hmiUIOptions();
				controlToHmi(ref data3, (buControl)Controls[i]);
				AL.Add(text + Controls[i].Name + " = " + buSerilization5.ClassToString(data3));
			}
			if (Controls[i] is buLabel)
			{
				hmiUIOptions data4 = new hmiUIOptions();
				controlToHmi(ref data4, (buControl)Controls[i]);
				AL.Add(text + Controls[i].Name + " = " + buSerilization5.ClassToString(data4));
			}
			if (Controls[i] is buCheckBox)
			{
				hmiUIOptions data5 = new hmiUIOptions();
				controlToHmi(ref data5, (buControl)Controls[i]);
				AL.Add(text + Controls[i].Name + " = " + buSerilization5.ClassToString(data5));
			}
		}
	}

	public override string ToString()
	{
		return "Visible: " + VisibleStatus + " ImageIndex: " + ImageIndex;
	}
}
