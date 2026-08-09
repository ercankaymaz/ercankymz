using System.IO;

namespace QUT.GplexBuffers;

internal class Guesser
{
	private ScanBuff buffer;

	private const int maxAccept = 10;

	private const int initial = 0;

	private const int eofNum = 0;

	private const int goStart = -1;

	private const int INITIAL = 0;

	private const int EndToken = 0;

	public long utfX;

	public long uppr;

	private int state;

	private int currentStart = startState[0];

	private int code;

	private static int[] startState;

	private static sbyte[] map;

	private static sbyte[][] nextState;

	public int GuessCodePage()
	{
		return Scan();
	}

	static Guesser()
	{
		startState = new int[2] { 11, 0 };
		map = new sbyte[256]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 2, 2,
			2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
			2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
			2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
			2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
			2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
			2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
			2, 2, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 3, 3, 3, 3, 3, 3,
			3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
			4, 4, 4, 4, 4, 4, 4, 4, 5, 5,
			5, 5, 5, 5, 5, 5
		};
		nextState = new sbyte[12][]
		{
			new sbyte[6],
			new sbyte[6] { -1, -1, 10, -1, -1, -1 },
			new sbyte[6] { -1, -1, -1, -1, -1, -1 },
			new sbyte[6] { -1, -1, 8, -1, -1, -1 },
			new sbyte[6] { -1, -1, 5, -1, -1, -1 },
			new sbyte[6] { -1, -1, 6, -1, -1, -1 },
			new sbyte[6] { -1, -1, 7, -1, -1, -1 },
			null,
			new sbyte[6] { -1, -1, 9, -1, -1, -1 },
			null,
			null,
			new sbyte[6] { -1, 1, 2, 3, 4, 2 }
		};
		nextState[7] = nextState[2];
		nextState[9] = nextState[2];
		nextState[10] = nextState[2];
	}

	private int NextState()
	{
		if (code == -1)
		{
			return 0;
		}
		return nextState[state][map[code]];
	}

	public Guesser(Stream file)
	{
		SetSource(file);
	}

	public void SetSource(Stream source)
	{
		buffer = new BuildBuffer(source);
		code = buffer.Read();
	}

	private int Scan()
	{
		while (true)
		{
			state = currentStart;
			int num;
			while ((num = NextState()) == -1)
			{
				code = buffer.Read();
			}
			state = num;
			code = buffer.Read();
			while ((num = NextState()) > 0)
			{
				state = num;
				code = buffer.Read();
			}
			if (state > 10)
			{
				continue;
			}
			switch (state)
			{
			case 0:
				if (currentStart == 11)
				{
					if (utfX == 0L && uppr == 0L)
					{
						return -1;
					}
					if (uppr * 10 > utfX)
					{
						return 0;
					}
					return 65001;
				}
				return 0;
			case 1:
			case 2:
			case 3:
			case 4:
				uppr++;
				break;
			case 5:
				uppr += 2L;
				break;
			case 6:
				uppr += 3L;
				break;
			case 7:
				utfX += 3L;
				break;
			case 8:
				uppr += 2L;
				break;
			case 9:
				utfX += 2L;
				break;
			case 10:
				utfX++;
				break;
			}
		}
	}
}
