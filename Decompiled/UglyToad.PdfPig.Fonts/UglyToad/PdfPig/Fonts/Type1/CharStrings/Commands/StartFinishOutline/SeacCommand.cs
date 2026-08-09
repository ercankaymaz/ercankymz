using System.Collections.Generic;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Fonts.Encodings;

namespace UglyToad.PdfPig.Fonts.Type1.CharStrings.Commands.StartFinishOutline;

internal static class SeacCommand
{
	public const string Name = "seac";

	public static readonly byte First = 12;

	public static readonly byte? Second = (byte)6;

	public static bool TakeFromStackBottom { get; } = true;

	public static bool ClearsOperandStack { get; } = true;

	public static LazyType1Command Lazy { get; } = new LazyType1Command("seac", Run);

	public static void Run(Type1BuildCharContext context)
	{
		context.Stack.PopBottom();
		context.Stack.PopBottom();
		context.Stack.PopBottom();
		int key = (int)context.Stack.PopBottom();
		int key2 = (int)context.Stack.PopBottom();
		string characterName = StandardEncoding.Instance.CodeToNameMap[key];
		string characterName2 = StandardEncoding.Instance.CodeToNameMap[key2];
		IReadOnlyList<PdfSubpath> character = context.GetCharacter(characterName);
		context.GetCharacter(characterName2);
		context.SetPath(character);
		context.Stack.Clear();
	}
}
