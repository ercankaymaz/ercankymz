using System;
using System.Reflection;
using System.Windows.Forms;

namespace buClass;

[Serializable]
public class FormProperties : buSerilization
{
	public bool TopMost = false;

	public bool ReadOnly = false;

	public FormStartPosition FormPosition = FormStartPosition.CenterParent;

	public AutoScaleMode ScaleFromMode = AutoScaleMode.None;

	public DialogResult Result = DialogResult.None;

	public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;

	public int Width = 0;

	public int Height = 0;

	public bool Inited = false;

	public bool TouchPad = false;

	public bool ShowHelp = true;

	public bool Updated = false;

	public bool VisualUpdated = false;

	public string Message = "";

	public string sClassName = "";

	public FormProperties()
	{
	}

	public FormProperties(FormProperties data)
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
				string name = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}

	public FormProperties(FormCloseModeType formclosemode, AutoScaleMode scalefrommode, FormStartPosition formposition, bool topmost, int width, int height)
	{
		FormCloseMode = formclosemode;
		ScaleFromMode = scalefrommode;
		FormPosition = formposition;
		TopMost = topmost;
		Width = width;
		Height = height;
	}
}
