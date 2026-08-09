using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Microsoft.Extensions.Logging;
using QUT.Gppg;

namespace Xbim.IO.Parser;

[GeneratedCode("Gardens Point Parser Generator", "1.5.2")]
public abstract class P21Parser : ShiftReduceParser<ValueType, LexLocation>
{
	public bool InHeader;

	private static Dictionary<int, string> aliases;

	private static Rule[] rules;

	private static State[] states;

	private static string[] nonTerms;

	protected P21Parser(Stream strm, ILoggerFactory loggerFactory)
		: base((AbstractScanner<ValueType, LexLocation>)new Scanner(strm, loggerFactory))
	{
	}

	protected P21Parser(ILoggerFactory loggerFactory)
		: base((AbstractScanner<ValueType, LexLocation>)new Scanner(loggerFactory))
	{
	}

	[Obsolete("Prefer ILoggerFactory")]
	protected P21Parser()
		: base((AbstractScanner<ValueType, LexLocation>)new Scanner())
	{
	}

	protected virtual void SetErrorMessage()
	{
	}

	protected abstract void CharacterError();

	protected abstract void BeginParse();

	protected abstract void EndParse();

	protected abstract void BeginHeader();

	protected abstract void EndHeader();

	protected abstract void BeginScope();

	protected abstract void EndScope();

	protected abstract void EndSec();

	protected abstract void BeginList();

	protected abstract void EndList();

	protected abstract void BeginComplex();

	protected abstract void EndComplex();

	protected abstract void SetType(string entityTypeName);

	protected abstract void NewEntity(string entityLabel);

	protected abstract void EndEntity();

	protected abstract void EndHeaderEntity();

	protected abstract void SetIntegerValue(string value);

	protected abstract void SetHexValue(string value);

	protected abstract void SetFloatValue(string value);

	protected abstract void SetStringValue(string value);

	protected abstract void SetInvalidStringValue(string value);

	protected abstract void SetEnumValue(string value);

	protected abstract void SetBooleanValue(string value);

	protected abstract void SetNonDefinedValue();

	protected abstract void SetOverrideValue();

	protected abstract void SetObjectValue(string value);

	protected abstract void EndNestedType(string value);

	protected abstract void BeginNestedType(string value);

	static P21Parser()
	{
		rules = new Rule[64];
		states = new State[99];
		nonTerms = new string[30]
		{
			"stepFile", "trailingSpace", "$accept", "endStep", "beginStep", "startHeader", "stepFile1", "headerEntities", "endSec", "endOfHeader",
			"model", "stepFile2", "stepFile3", "headerEntity", "entityType", "listArgument", "argument", "listType", "beginList", "endList",
			"argumentList", "bloc", "entityLabel", "entity", "beginScope", "endScope", "complex", "uniqueID", "export", "beginExport"
		};
		states[0] = new State(new int[6] { 65, 95, 72, 74, 63, 75 }, new int[16]
		{
			-1, 1, -7, 3, -5, 4, -12, 96, -13, 97,
			-11, 98, -22, 79, -23, 19
		});
		states[1] = new State(new int[2] { 64, 2 });
		states[2] = new State(-1);
		states[3] = new State(-11);
		states[4] = new State(new int[2] { 66, 94 }, new int[2] { -6, 5 });
		states[5] = new State(new int[8] { 73, 56, 84, 57, 63, 86, 67, 17 }, new int[8] { -8, 6, -9, 87, -14, 93, -15, 83 });
		states[6] = new State(new int[8] { 67, 17, 73, 56, 84, 57, 63, 86 }, new int[6] { -9, 7, -14, 82, -15, 83 });
		states[7] = new State(new int[2] { 68, 81 }, new int[2] { -10, 8 });
		states[8] = new State(new int[4] { 72, 74, 63, 75 }, new int[6] { -11, 9, -22, 79, -23, 19 });
		states[9] = new State(new int[6] { 67, 17, 72, 74, 63, 75 }, new int[6] { -9, 10, -22, 16, -23, 19 });
		states[10] = new State(new int[2] { 69, 12 }, new int[2] { -4, 11 });
		states[11] = new State(-8);
		states[12] = new State(new int[4] { 32, 15, 64, -4 }, new int[2] { -2, 13 });
		states[13] = new State(new int[4] { 32, 14, 64, -5 });
		states[14] = new State(-3);
		states[15] = new State(-2);
		states[16] = new State(-45);
		states[17] = new State(new int[6] { 32, 15, 68, -15, 69, -15 }, new int[2] { -2, 18 });
		states[18] = new State(new int[6] { 32, 14, 68, -16, 69, -16 });
		states[19] = new State(new int[2] { 61, 20 });
		states[20] = new State(new int[8] { 73, 56, 84, 57, 40, 58, 70, 80 }, new int[6] { -24, 21, -25, 23, -15, 28 });
		states[21] = new State(new int[2] { 59, 22 });
		states[22] = new State(-46);
		states[23] = new State(new int[6] { 72, 74, 63, 75, 71, 65 }, new int[8] { -11, 24, -26, 76, -22, 79, -23, 19 });
		states[24] = new State(new int[6] { 71, 65, 72, 74, 63, 75 }, new int[6] { -26, 25, -22, 16, -23, 19 });
		states[25] = new State(new int[6] { 73, 56, 84, 57, 40, 58 }, new int[4] { -24, 26, -15, 28 });
		states[26] = new State(new int[2] { 59, 27 });
		states[27] = new State(-47);
		states[28] = new State(new int[2] { 40, 48 }, new int[4] { -16, 29, -19, 30 });
		states[29] = new State(-52);
		states[30] = new State(new int[30]
		{
			63, 54, 41, 53, 78, 36, 74, 37, 75, 38,
			76, 39, 86, 40, 87, 41, 77, 42, 82, 43,
			83, 44, 80, 45, 81, 46, 40, 48, 73, 51
		}, new int[12]
		{
			-20, 31, -21, 32, -17, 55, -16, 47, -19, 30,
			-18, 49
		});
		states[31] = new State(-38);
		states[32] = new State(new int[6] { 44, 34, 63, 52, 41, 53 }, new int[2] { -20, 33 });
		states[33] = new State(-39);
		states[34] = new State(new int[26]
		{
			78, 36, 74, 37, 75, 38, 76, 39, 86, 40,
			87, 41, 77, 42, 82, 43, 83, 44, 80, 45,
			81, 46, 40, 48, 73, 51
		}, new int[8] { -17, 35, -16, 47, -19, 30, -18, 49 });
		states[35] = new State(-42);
		states[36] = new State(-22);
		states[37] = new State(-23);
		states[38] = new State(-24);
		states[39] = new State(-25);
		states[40] = new State(-26);
		states[41] = new State(-27);
		states[42] = new State(-28);
		states[43] = new State(-29);
		states[44] = new State(-30);
		states[45] = new State(-31);
		states[46] = new State(-32);
		states[47] = new State(-33);
		states[48] = new State(-36);
		states[49] = new State(new int[2] { 40, 48 }, new int[4] { -16, 50, -19, 30 });
		states[50] = new State(-34);
		states[51] = new State(-35);
		states[52] = new State(-43);
		states[53] = new State(-37);
		states[54] = new State(-40);
		states[55] = new State(-41);
		states[56] = new State(-62);
		states[57] = new State(-63);
		states[58] = new State(new int[4] { 73, 56, 84, 57 }, new int[4] { -27, 59, -15, 63 });
		states[59] = new State(new int[6] { 41, 60, 73, 56, 84, 57 }, new int[2] { -15, 61 });
		states[60] = new State(-53);
		states[61] = new State(new int[2] { 40, 48 }, new int[4] { -16, 62, -19, 30 });
		states[62] = new State(-51);
		states[63] = new State(new int[2] { 40, 48 }, new int[4] { -16, 64, -19, 30 });
		states[64] = new State(-50);
		states[65] = new State(new int[8] { 47, 73, 73, -59, 84, -59, 40, -59 }, new int[2] { -30, 66 });
		states[66] = new State(new int[2] { 78, 71 }, new int[4] { -29, 67, -28, 72 });
		states[67] = new State(new int[4] { 47, 68, 44, 69 });
		states[68] = new State(-60);
		states[69] = new State(new int[2] { 78, 71 }, new int[2] { -28, 70 });
		states[70] = new State(-57);
		states[71] = new State(-55);
		states[72] = new State(-56);
		states[73] = new State(-58);
		states[74] = new State(-61);
		states[75] = new State(-49);
		states[76] = new State(new int[6] { 73, 56, 84, 57, 40, 58 }, new int[4] { -24, 77, -15, 28 });
		states[77] = new State(new int[2] { 59, 78 });
		states[78] = new State(-48);
		states[79] = new State(-44);
		states[80] = new State(-54);
		states[81] = new State(-21);
		states[82] = new State(-18);
		states[83] = new State(new int[2] { 40, 48 }, new int[4] { -16, 84, -19, 30 });
		states[84] = new State(new int[2] { 59, 85 });
		states[85] = new State(-19);
		states[86] = new State(-20);
		states[87] = new State(new int[2] { 68, 81 }, new int[2] { -10, 88 });
		states[88] = new State(new int[4] { 72, 74, 63, 75 }, new int[6] { -11, 89, -22, 79, -23, 19 });
		states[89] = new State(new int[6] { 63, 92, 67, 17, 72, 74 }, new int[6] { -9, 90, -22, 16, -23, 19 });
		states[90] = new State(new int[2] { 69, 12 }, new int[2] { -4, 91 });
		states[91] = new State(-9);
		states[92] = new State(new int[8] { 64, -10, 63, -49, 67, -49, 72, -49 });
		states[93] = new State(-17);
		states[94] = new State(-7);
		states[95] = new State(-6);
		states[96] = new State(-12);
		states[97] = new State(-13);
		states[98] = new State(new int[6] { 72, 74, 63, 75, 64, -14 }, new int[4] { -22, 16, -23, 19 });
		for (int i = 0; i < states.Length; i++)
		{
			states[i].number = i;
		}
		rules[1] = new Rule(-3, new int[2] { -1, 64 });
		rules[2] = new Rule(-2, new int[1] { 32 });
		rules[3] = new Rule(-2, new int[2] { -2, 32 });
		rules[4] = new Rule(-4, new int[1] { 69 });
		rules[5] = new Rule(-4, new int[2] { 69, -2 });
		rules[6] = new Rule(-5, new int[1] { 65 });
		rules[7] = new Rule(-6, new int[1] { 66 });
		rules[8] = new Rule(-7, new int[8] { -5, -6, -8, -9, -10, -11, -9, -4 });
		rules[9] = new Rule(-12, new int[7] { -5, -6, -9, -10, -11, -9, -4 });
		rules[10] = new Rule(-13, new int[6] { -5, -6, -9, -10, -11, 63 });
		rules[11] = new Rule(-1, new int[1] { -7 });
		rules[12] = new Rule(-1, new int[1] { -12 });
		rules[13] = new Rule(-1, new int[1] { -13 });
		rules[14] = new Rule(-1, new int[1] { -11 });
		rules[15] = new Rule(-9, new int[1] { 67 });
		rules[16] = new Rule(-9, new int[2] { 67, -2 });
		rules[17] = new Rule(-8, new int[1] { -14 });
		rules[18] = new Rule(-8, new int[2] { -8, -14 });
		rules[19] = new Rule(-14, new int[3] { -15, -16, 59 });
		rules[20] = new Rule(-14, new int[1] { 63 });
		rules[21] = new Rule(-10, new int[1] { 68 });
		rules[22] = new Rule(-17, new int[1] { 78 });
		rules[23] = new Rule(-17, new int[1] { 74 });
		rules[24] = new Rule(-17, new int[1] { 75 });
		rules[25] = new Rule(-17, new int[1] { 76 });
		rules[26] = new Rule(-17, new int[1] { 86 });
		rules[27] = new Rule(-17, new int[1] { 87 });
		rules[28] = new Rule(-17, new int[1] { 77 });
		rules[29] = new Rule(-17, new int[1] { 82 });
		rules[30] = new Rule(-17, new int[1] { 83 });
		rules[31] = new Rule(-17, new int[1] { 80 });
		rules[32] = new Rule(-17, new int[1] { 81 });
		rules[33] = new Rule(-17, new int[1] { -16 });
		rules[34] = new Rule(-17, new int[2] { -18, -16 });
		rules[35] = new Rule(-18, new int[1] { 73 });
		rules[36] = new Rule(-19, new int[1] { 40 });
		rules[37] = new Rule(-20, new int[1] { 41 });
		rules[38] = new Rule(-16, new int[2] { -19, -20 });
		rules[39] = new Rule(-16, new int[3] { -19, -21, -20 });
		rules[40] = new Rule(-16, new int[2] { -19, 63 });
		rules[41] = new Rule(-21, new int[1] { -17 });
		rules[42] = new Rule(-21, new int[3] { -21, 44, -17 });
		rules[43] = new Rule(-21, new int[2] { -21, 63 });
		rules[44] = new Rule(-11, new int[1] { -22 });
		rules[45] = new Rule(-11, new int[2] { -11, -22 });
		rules[46] = new Rule(-22, new int[4] { -23, 61, -24, 59 });
		rules[47] = new Rule(-22, new int[7] { -23, 61, -25, -11, -26, -24, 59 });
		rules[48] = new Rule(-22, new int[6] { -23, 61, -25, -26, -24, 59 });
		rules[49] = new Rule(-22, new int[1] { 63 });
		rules[50] = new Rule(-27, new int[2] { -15, -16 });
		rules[51] = new Rule(-27, new int[3] { -27, -15, -16 });
		rules[52] = new Rule(-24, new int[2] { -15, -16 });
		rules[53] = new Rule(-24, new int[3] { 40, -27, 41 });
		rules[54] = new Rule(-25, new int[1] { 70 });
		rules[55] = new Rule(-28, new int[1] { 78 });
		rules[56] = new Rule(-29, new int[1] { -28 });
		rules[57] = new Rule(-29, new int[3] { -29, 44, -28 });
		rules[58] = new Rule(-30, new int[1] { 47 });
		rules[59] = new Rule(-26, new int[1] { 71 });
		rules[60] = new Rule(-26, new int[4] { 71, -30, -29, 47 });
		rules[61] = new Rule(-23, new int[1] { 72 });
		rules[62] = new Rule(-15, new int[1] { 73 });
		rules[63] = new Rule(-15, new int[1] { 84 });
	}

	protected override void Initialize()
	{
		InitSpecialTokens(63, 64);
		InitStates(states);
		InitRules(rules);
		InitNonTerminals(nonTerms);
	}

	protected override void DoAction(int action)
	{
		switch (action)
		{
		case 4:
			EndParse();
			break;
		case 5:
			EndParse();
			break;
		case 6:
			BeginParse();
			break;
		case 7:
			InHeader = true;
			BeginHeader();
			break;
		case 14:
			EndParse();
			break;
		case 15:
			EndSec();
			break;
		case 16:
			EndSec();
			break;
		case 19:
			EndHeaderEntity();
			break;
		case 21:
			InHeader = false;
			EndHeader();
			break;
		case 22:
			SetObjectValue(CurrentSemanticValue.strVal);
			break;
		case 23:
			SetIntegerValue(CurrentSemanticValue.strVal);
			break;
		case 24:
			SetFloatValue(CurrentSemanticValue.strVal);
			break;
		case 25:
			SetStringValue(CurrentSemanticValue.strVal);
			break;
		case 26:
			SetStringValue(CurrentSemanticValue.strVal);
			break;
		case 27:
			SetInvalidStringValue(CurrentSemanticValue.strVal);
			break;
		case 28:
			SetBooleanValue(CurrentSemanticValue.strVal);
			break;
		case 29:
			SetEnumValue(CurrentSemanticValue.strVal);
			break;
		case 30:
			SetHexValue(CurrentSemanticValue.strVal);
			break;
		case 31:
			SetNonDefinedValue();
			break;
		case 32:
			SetOverrideValue();
			break;
		case 34:
			EndNestedType(CurrentSemanticValue.strVal);
			break;
		case 35:
			BeginNestedType(CurrentSemanticValue.strVal);
			break;
		case 36:
			BeginList();
			break;
		case 37:
			EndList();
			break;
		case 43:
			SetErrorMessage();
			break;
		case 46:
			EndEntity();
			break;
		case 47:
			EndEntity();
			break;
		case 48:
			EndEntity();
			break;
		case 49:
			SetErrorMessage();
			EndEntity();
			break;
		case 55:
			SetObjectValue(CurrentSemanticValue.strVal);
			break;
		case 58:
			BeginList();
			break;
		case 61:
			NewEntity(CurrentSemanticValue.strVal);
			break;
		case 62:
			SetType(CurrentSemanticValue.strVal);
			break;
		case 63:
			CharacterError();
			break;
		case 8:
		case 9:
		case 10:
		case 11:
		case 12:
		case 13:
		case 17:
		case 18:
		case 20:
		case 33:
		case 38:
		case 39:
		case 40:
		case 41:
		case 42:
		case 44:
		case 45:
		case 50:
		case 51:
		case 52:
		case 53:
		case 54:
		case 56:
		case 57:
		case 59:
		case 60:
			break;
		}
	}

	protected override string TerminalToString(int terminal)
	{
		if (aliases != null && aliases.ContainsKey(terminal))
		{
			return aliases[terminal];
		}
		Tokens tokens = (Tokens)terminal;
		if (tokens.ToString() != terminal.ToString(CultureInfo.InvariantCulture))
		{
			tokens = (Tokens)terminal;
			return tokens.ToString();
		}
		return ShiftReduceParser<ValueType, LexLocation>.CharToString((char)terminal);
	}
}
