using System.Text;

namespace UglyToad.PdfPig.Functions.Type4;

internal static class Parser
{
	internal enum State
	{
		NEWLINE,
		WHITESPACE,
		COMMENT,
		TOKEN
	}

	public interface SyntaxHandler
	{
		void NewLine(string text);

		void Whitespace(string text);

		void Token(string text);

		void Comment(string text);
	}

	public abstract class AbstractSyntaxHandler : SyntaxHandler
	{
		public void Comment(string text)
		{
		}

		public void NewLine(string text)
		{
		}

		public void Whitespace(string text)
		{
		}

		public abstract void Token(string text);
	}

	internal class Tokenizer
	{
		private const char NUL = '\0';

		private const char EOT = '\u0004';

		private const char TAB = '\t';

		private const char FF = '\f';

		private const char CR = '\r';

		private const char LF = '\n';

		private const char SPACE = ' ';

		private readonly string input;

		private int index;

		private readonly SyntaxHandler handler;

		private State state = State.WHITESPACE;

		private readonly StringBuilder buffer = new StringBuilder();

		internal Tokenizer(string text, SyntaxHandler syntaxHandler)
		{
			input = text;
			handler = syntaxHandler;
		}

		private bool HasMore()
		{
			return index < input.Length;
		}

		private char CurrentChar()
		{
			return input[index];
		}

		private char NextChar()
		{
			index++;
			if (!HasMore())
			{
				return '\u0004';
			}
			return CurrentChar();
		}

		private char Peek()
		{
			if (index < input.Length - 1)
			{
				return input[index + 1];
			}
			return '\u0004';
		}

		private State NextState()
		{
			switch (CurrentChar())
			{
			case '\n':
			case '\f':
			case '\r':
				state = State.NEWLINE;
				break;
			case '\0':
			case '\t':
			case ' ':
				state = State.WHITESPACE;
				break;
			case '%':
				state = State.COMMENT;
				break;
			default:
				state = State.TOKEN;
				break;
			}
			return state;
		}

		internal void Tokenize()
		{
			while (HasMore())
			{
				buffer.Length = 0;
				NextState();
				switch (state)
				{
				case State.NEWLINE:
					ScanNewLine();
					break;
				case State.WHITESPACE:
					ScanWhitespace();
					break;
				case State.COMMENT:
					ScanComment();
					break;
				default:
					ScanToken();
					break;
				}
			}
		}

		private void ScanNewLine()
		{
			char c = CurrentChar();
			buffer.Append(c);
			if (c == '\r' && Peek() == '\n')
			{
				buffer.Append(NextChar());
			}
			handler.NewLine(buffer.ToString());
			NextChar();
		}

		private void ScanWhitespace()
		{
			buffer.Append(CurrentChar());
			bool flag = true;
			while (HasMore() && flag)
			{
				char c = NextChar();
				if (c == '\0' || c == '\t' || c == ' ')
				{
					buffer.Append(c);
				}
				else
				{
					flag = false;
				}
			}
			handler.Whitespace(buffer.ToString());
		}

		private void ScanComment()
		{
			buffer.Append(CurrentChar());
			bool flag = true;
			while (HasMore() && flag)
			{
				char c = NextChar();
				switch (c)
				{
				case '\n':
				case '\f':
				case '\r':
					flag = false;
					break;
				default:
					buffer.Append(c);
					break;
				}
			}
			handler.Comment(buffer.ToString());
		}

		private void ScanToken()
		{
			char c = CurrentChar();
			buffer.Append(c);
			if (c == '{' || c == '}')
			{
				handler.Token(buffer.ToString());
				NextChar();
				return;
			}
			bool flag = true;
			while (HasMore() && flag)
			{
				c = NextChar();
				switch (c)
				{
				case '\0':
				case '\u0004':
				case '\t':
				case '\n':
				case '\f':
				case '\r':
				case ' ':
				case '{':
				case '}':
					flag = false;
					break;
				default:
					buffer.Append(c);
					break;
				}
			}
			handler.Token(buffer.ToString());
		}
	}

	public static void Parse(string input, SyntaxHandler handler)
	{
		new Tokenizer(input, handler).Tokenize();
	}
}
