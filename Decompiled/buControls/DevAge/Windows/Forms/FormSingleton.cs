using System;
using System.Windows.Forms;

namespace DevAge.Windows.Forms;

public class FormSingleton
{
	private Type p_FormType;

	private object[] p_Args;

	private Form form_0 = null;

	public bool IsFormCreated => form_0 != null;

	public FormSingleton(Type p_FormType, object[] p_Args)
	{
		this.p_FormType = p_FormType;
		this.p_Args = p_Args;
	}

	public Form GetForm()
	{
		if (form_0 == null)
		{
			form_0 = (Form)Activator.CreateInstance(p_FormType, p_Args);
			form_0.CreateControl();
			form_0.Closed += form_0_Closed;
		}
		return form_0;
	}

	private void form_0_Closed(object sender, EventArgs e)
	{
		form_0.Closed -= form_0_Closed;
		form_0 = null;
	}
}
