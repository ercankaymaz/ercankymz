using System;
using System.Windows.Forms;

namespace buClass;

public class RegisterException : ApplicationException
{
	public RegisterException(string str)
		: base("Without Permission Using")
	{
		MessageBox.Show(str, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		Environment.Exit(0);
	}
}
