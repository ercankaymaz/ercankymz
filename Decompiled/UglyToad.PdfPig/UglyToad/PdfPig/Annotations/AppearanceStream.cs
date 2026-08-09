using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Annotations;

public class AppearanceStream
{
	private readonly IDictionary<string, StreamToken>? appearanceStreamsByState;

	private readonly StreamToken? statelessAppearanceStream;

	public bool IsStateless => statelessAppearanceStream != null;

	public ICollection<string> GetStates
	{
		get
		{
			if (appearanceStreamsByState == null)
			{
				return new string[0];
			}
			return appearanceStreamsByState.Keys;
		}
	}

	internal AppearanceStream(StreamToken? streamToken)
	{
		statelessAppearanceStream = streamToken;
	}

	internal AppearanceStream(IDictionary<string, StreamToken> appearanceStreamsByState)
	{
		this.appearanceStreamsByState = appearanceStreamsByState;
	}

	public StreamToken Get(string state)
	{
		if (appearanceStreamsByState == null)
		{
			throw new Exception("Cannot get appearance by state when this is a stateless appearance stream");
		}
		if (!appearanceStreamsByState.ContainsKey(state))
		{
			throw new ArgumentOutOfRangeException("state", "Appearance stream does not have state '" + state + "' (available states: " + string.Join(",", appearanceStreamsByState.Keys) + ")");
		}
		return appearanceStreamsByState[state];
	}
}
