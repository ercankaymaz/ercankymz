using System;
using System.Diagnostics;

namespace UglyToad.PdfPig.Fonts.Type1.CharStrings.Commands;

internal class LazyType1Command
{
	private readonly Action<Type1BuildCharContext> runCommand;

	public string Name { get; }

	public LazyType1Command(string name, Action<Type1BuildCharContext> runCommand)
	{
		Name = name;
		this.runCommand = runCommand ?? throw new ArgumentNullException("runCommand");
	}

	[DebuggerStepThrough]
	public void Run(Type1BuildCharContext context)
	{
		runCommand(context);
	}

	public override string ToString()
	{
		return Name;
	}
}
