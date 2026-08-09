using System;
using System.Globalization;
using System.Text;

namespace QUT.Gppg;

public abstract class ShiftReduceParser<TValue, TSpan> where TSpan : IMerge<TSpan>, new()
{
	[Serializable]
	private class AcceptException : Exception
	{
		internal AcceptException()
		{
		}
	}

	[Serializable]
	private class AbortException : Exception
	{
		internal AbortException()
		{
		}
	}

	[Serializable]
	private class ErrorException : Exception
	{
		internal ErrorException()
		{
		}
	}

	private AbstractScanner<TValue, TSpan> scanner;

	protected TValue CurrentSemanticValue;

	protected TSpan CurrentLocationSpan;

	protected int NextToken;

	private TSpan LastSpan;

	private State FsaState;

	private bool recovering;

	private int tokensSinceLastError;

	private PushdownPrefixState<State> StateStack = new PushdownPrefixState<State>();

	private PushdownPrefixState<TValue> valueStack = new PushdownPrefixState<TValue>();

	private PushdownPrefixState<TSpan> locationStack = new PushdownPrefixState<TSpan>();

	private int errorToken;

	private int endOfFileToken;

	private string[] nonTerminals;

	private State[] states;

	private Rule[] rules;

	protected AbstractScanner<TValue, TSpan> Scanner
	{
		get
		{
			return scanner;
		}
		set
		{
			scanner = value;
		}
	}

	protected PushdownPrefixState<TValue> ValueStack => valueStack;

	protected PushdownPrefixState<TSpan> LocationStack => locationStack;

	protected bool YYRecovering => recovering;

	protected ShiftReduceParser(AbstractScanner<TValue, TSpan> scanner)
	{
		this.scanner = scanner;
	}

	protected void InitRules(Rule[] rules)
	{
		this.rules = rules;
	}

	protected void InitStates(State[] states)
	{
		this.states = states;
	}

	protected void InitStateTable(int size)
	{
		states = new State[size];
	}

	protected void InitSpecialTokens(int err, int end)
	{
		errorToken = err;
		endOfFileToken = end;
	}

	protected void InitNonTerminals(string[] names)
	{
		nonTerminals = names;
	}

	protected static void YYAccept()
	{
		throw new AcceptException();
	}

	protected static void YYAbort()
	{
		throw new AbortException();
	}

	protected static void YYError()
	{
		throw new ErrorException();
	}

	protected abstract void Initialize();

	public bool Parse()
	{
		StateStack.Clear();
		valueStack.Clear();
		LocationStack.Clear();
		Initialize();
		NextToken = 0;
		FsaState = states[0];
		StateStack.Push(FsaState);
		valueStack.Push(CurrentSemanticValue);
		LocationStack.Push(CurrentLocationSpan);
		while (true)
		{
			int num = FsaState.defaultAction;
			if (FsaState.ParserTable != null)
			{
				if (NextToken == 0)
				{
					LastSpan = scanner.yylloc;
					NextToken = scanner.yylex();
				}
				if (FsaState.ParserTable.ContainsKey(NextToken))
				{
					num = FsaState.ParserTable[NextToken];
				}
			}
			if (num > 0)
			{
				Shift(num);
			}
			else if (num < 0)
			{
				try
				{
					Reduce(-num);
					if (num == -1)
					{
						return true;
					}
				}
				catch (Exception ex)
				{
					if (ex is AbortException)
					{
						return false;
					}
					if (ex is AcceptException)
					{
						return true;
					}
					if (ex is ErrorException && !ErrorRecovery())
					{
						return false;
					}
					throw;
				}
			}
			else if (num == 0 && !ErrorRecovery())
			{
				break;
			}
		}
		return false;
	}

	private void Shift(int stateIndex)
	{
		FsaState = states[stateIndex];
		valueStack.Push(scanner.yylval);
		StateStack.Push(FsaState);
		LocationStack.Push(scanner.yylloc);
		if (recovering)
		{
			if (NextToken != errorToken)
			{
				tokensSinceLastError++;
			}
			if (tokensSinceLastError > 5)
			{
				recovering = false;
			}
		}
		if (NextToken != endOfFileToken)
		{
			NextToken = 0;
		}
	}

	private void Reduce(int ruleNumber)
	{
		Rule rule = rules[ruleNumber];
		int num = rule.RightHandSide.Length;
		switch (num)
		{
		case 1:
			CurrentSemanticValue = valueStack.TopElement();
			CurrentLocationSpan = LocationStack.TopElement();
			break;
		case 0:
			CurrentSemanticValue = default(TValue);
			CurrentLocationSpan = ((scanner.yylloc != null && LastSpan != null) ? scanner.yylloc.Merge(LastSpan) : default(TSpan));
			break;
		default:
		{
			CurrentSemanticValue = valueStack[LocationStack.Depth - num];
			TSpan val = LocationStack[LocationStack.Depth - num];
			TSpan val2 = LocationStack[LocationStack.Depth - 1];
			CurrentLocationSpan = ((val != null && val2 != null) ? val.Merge(val2) : default(TSpan));
			break;
		}
		}
		DoAction(ruleNumber);
		for (int i = 0; i < rule.RightHandSide.Length; i++)
		{
			StateStack.Pop();
			valueStack.Pop();
			LocationStack.Pop();
		}
		FsaState = StateStack.TopElement();
		if (FsaState.Goto.ContainsKey(rule.LeftHandSide))
		{
			FsaState = states[FsaState.Goto[rule.LeftHandSide]];
		}
		StateStack.Push(FsaState);
		valueStack.Push(CurrentSemanticValue);
		LocationStack.Push(CurrentLocationSpan);
	}

	protected abstract void DoAction(int actionNumber);

	private bool ErrorRecovery()
	{
		if (!recovering)
		{
			ReportError();
		}
		if (!FindErrorRecoveryState())
		{
			return false;
		}
		ShiftErrorToken();
		bool result = DiscardInvalidTokens();
		recovering = true;
		tokensSinceLastError = 0;
		return result;
	}

	private void ReportError()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("Syntax error, unexpected {0}", TerminalToString(NextToken));
		if (FsaState.ParserTable.Count < 7)
		{
			bool flag = true;
			foreach (int key in FsaState.ParserTable.Keys)
			{
				if (flag)
				{
					stringBuilder.Append(", expecting ");
				}
				else
				{
					stringBuilder.Append(", or ");
				}
				stringBuilder.Append(TerminalToString(key));
				flag = false;
			}
		}
		scanner.yyerror(stringBuilder.ToString());
	}

	private void ShiftErrorToken()
	{
		int nextToken = NextToken;
		NextToken = errorToken;
		Shift(FsaState.ParserTable[NextToken]);
		NextToken = nextToken;
	}

	private bool FindErrorRecoveryState()
	{
		while (true)
		{
			if (FsaState.ParserTable != null && FsaState.ParserTable.ContainsKey(errorToken) && FsaState.ParserTable[errorToken] > 0)
			{
				return true;
			}
			StateStack.Pop();
			valueStack.Pop();
			LocationStack.Pop();
			if (StateStack.IsEmpty())
			{
				break;
			}
			FsaState = StateStack.TopElement();
		}
		return false;
	}

	private bool DiscardInvalidTokens()
	{
		int num = FsaState.defaultAction;
		if (FsaState.ParserTable != null)
		{
			while (true)
			{
				if (NextToken == 0)
				{
					NextToken = scanner.yylex();
				}
				if (NextToken == endOfFileToken)
				{
					return false;
				}
				if (FsaState.ParserTable.ContainsKey(NextToken))
				{
					num = FsaState.ParserTable[NextToken];
				}
				if (num != 0)
				{
					break;
				}
				NextToken = 0;
			}
			return true;
		}
		if (recovering && tokensSinceLastError == 0)
		{
			if (NextToken == endOfFileToken)
			{
				return false;
			}
			NextToken = 0;
			return true;
		}
		return true;
	}

	protected void yyclearin()
	{
		NextToken = 0;
	}

	protected void yyerrok()
	{
		recovering = false;
	}

	protected void AddState(int stateNumber, State state)
	{
		states[stateNumber] = state;
		state.number = stateNumber;
	}

	private void DisplayStack()
	{
		Console.Error.Write("State stack is now:");
		for (int i = 0; i < StateStack.Depth; i++)
		{
			Console.Error.Write(" {0}", StateStack[i].number);
		}
		Console.Error.WriteLine();
	}

	private void DisplayRule(int ruleNumber)
	{
		Console.Error.Write("Reducing stack by rule {0}, ", ruleNumber);
		DisplayProduction(rules[ruleNumber]);
	}

	private void DisplayProduction(Rule rule)
	{
		if (rule.RightHandSide.Length == 0)
		{
			Console.Error.Write("/* empty */ ");
		}
		else
		{
			int[] rightHandSide = rule.RightHandSide;
			foreach (int symbol in rightHandSide)
			{
				Console.Error.Write("{0} ", SymbolToString(symbol));
			}
		}
		Console.Error.WriteLine("-> {0}", SymbolToString(rule.LeftHandSide));
	}

	protected abstract string TerminalToString(int terminal);

	private string SymbolToString(int symbol)
	{
		if (symbol < 0)
		{
			return nonTerminals[-symbol - 1];
		}
		return TerminalToString(symbol);
	}

	protected static string CharToString(char input)
	{
		return input switch
		{
			'\a' => "'\\a'", 
			'\b' => "'\\b'", 
			'\f' => "'\\f'", 
			'\n' => "'\\n'", 
			'\r' => "'\\r'", 
			'\t' => "'\\t'", 
			'\v' => "'\\v'", 
			'\0' => "'\\0'", 
			_ => string.Format(CultureInfo.InvariantCulture, "'{0}'", input), 
		};
	}
}
