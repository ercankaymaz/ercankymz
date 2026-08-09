using System;
using System.Diagnostics;

namespace UglyToad.PdfPig.Fonts.CompactFontFormat.CharStrings;

internal class LazyType2Command
{
	private readonly int minimumStackParameters;

	private readonly Action<Type2BuildCharContext> runCommand;

	public string Name { get; }

	public LazyType2Command(string name, int minimumStackParameters, Action<Type2BuildCharContext> runCommand)
	{
		Name = name ?? throw new ArgumentNullException("name");
		this.minimumStackParameters = minimumStackParameters;
		this.runCommand = runCommand ?? throw new ArgumentNullException("runCommand");
	}

	[DebuggerStepThrough]
	public void Run(Type2BuildCharContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (context.Stack.Length < minimumStackParameters)
		{
			context.Stack.Clear();
		}
		else
		{
			runCommand(context);
		}
	}

	public override string ToString()
	{
		return Name;
	}
}
