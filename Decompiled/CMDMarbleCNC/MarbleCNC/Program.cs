using System;
using System.Threading;
using System.Windows.Forms;

namespace MarbleCNC;

internal static class Program
{
	[STAThread]
	private static void Main(string[] arcg)
	{
		using Mutex mutex = new Mutex(initiallyOwned: false, "Global\\f2a3eef4-cfb1-407d-9076-cc35aa5ace26");
		if (!mutex.WaitOne(0, exitContext: false))
		{
			MessageBox.Show("Instance already running");
			return;
		}
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(defaultValue: false);
		Application.Run(new F_Intro());
	}
}
