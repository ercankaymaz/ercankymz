using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Logging;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Outline.Destinations;

public class NamedDestinations
{
	private readonly IReadOnlyDictionary<string, ExplicitDestination> namedDestinations;

	private readonly Pages pages;

	internal NamedDestinations(IReadOnlyDictionary<string, ExplicitDestination> namedDestinations, Pages pages)
	{
		this.namedDestinations = namedDestinations;
		this.pages = pages;
	}

	internal bool TryGet(string name, [NotNullWhen(true)] out ExplicitDestination? destination)
	{
		return namedDestinations.TryGetValue(name, out destination);
	}

	internal bool TryGetExplicitDestination(ArrayToken explicitDestinationArray, ILog log, bool isRemoteDestination, [NotNullWhen(true)] out ExplicitDestination? destination)
	{
		return NamedDestinationsProvider.TryGetExplicitDestination(explicitDestinationArray, pages, log, isRemoteDestination, out destination);
	}
}
