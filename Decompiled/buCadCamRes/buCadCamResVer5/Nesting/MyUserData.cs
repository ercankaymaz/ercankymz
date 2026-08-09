using System.Runtime.CompilerServices;
using PowerNest2Cs;

namespace buCadCamResVer5.Nesting;

public class MyUserData : IUserData
{
	[CompilerGenerated]
	private int int_0;

	public int NbCall
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public MyUserData()
	{
		NbCall = 0;
	}
}
