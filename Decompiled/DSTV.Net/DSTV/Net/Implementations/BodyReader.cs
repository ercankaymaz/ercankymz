using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DSTV.Net.Data;
using DSTV.Net.Enums;
using DSTV.Net.Exceptions;

namespace DSTV.Net.Implementations;

internal static class BodyReader
{
	private static void SkipSelfAndExecute(this IEnumerable<string> items, ContourType contourType, Action<string> action)
	{
		foreach (string item in items)
		{
			try
			{
				if (!item.Equals(contourType.ToString(), StringComparison.Ordinal))
				{
					action(item);
				}
			}
			catch (DstvParseException value)
			{
				Console.WriteLine(value);
			}
		}
	}

	public static async Task<IEnumerable<DstvElement>> GetElementsAsync(ReaderContext readerContext)
	{
		List<DstvElement> outputList = new List<DstvElement>();
		Dictionary<ContourType, List<List<string>>> dictionary = await GetElementMapAsync(readerContext).ConfigureAwait(continueOnCapturedContext: false);
		(dictionary.GetValueOrDefault(ContourType.BO) ?? new List<List<string>>()).SelectMany((List<string> holeList) => holeList).SkipSelfAndExecute(ContourType.BO, delegate(string holeNote)
		{
			outputList.Add(DstvHole.CreateHole(holeNote));
		});
		AddContoursByType(notesBlockList: dictionary.GetValueOrDefault(ContourType.AK), outElemList: outputList, type: ContourType.AK);
		AddContoursByType(notesBlockList: dictionary.GetValueOrDefault(ContourType.IK), outElemList: outputList, type: ContourType.IK);
		AddContoursByType(notesBlockList: dictionary.GetValueOrDefault(ContourType.PU), outElemList: outputList, type: ContourType.PU);
		AddContoursByType(notesBlockList: dictionary.GetValueOrDefault(ContourType.KO), outElemList: outputList, type: ContourType.KO);
		(dictionary.GetValueOrDefault(ContourType.SI) ?? new List<List<string>>()).SelectMany((List<string> numNote) => numNote).SkipSelfAndExecute(ContourType.SI, delegate(string numNote)
		{
			outputList.Add(DstvNumeration.CreateNumeration(numNote));
		});
		(dictionary.GetValueOrDefault(ContourType.KA) ?? new List<List<string>>()).SelectMany((List<string> bendNote) => bendNote).SkipSelfAndExecute(ContourType.KA, delegate(string bendNote)
		{
			outputList.Add(DstvBend.CreateBend(bendNote));
		});
		(dictionary.GetValueOrDefault(ContourType.SC) ?? new List<List<string>>()).SelectMany((List<string> cutNote) => cutNote).SkipSelfAndExecute(ContourType.SC, delegate(string cutNote)
		{
			outputList.Add(DstvCut.CreateCut(cutNote));
		});
		return outputList;
	}

	private static void AddContoursByType(List<DstvElement> outElemList, List<List<string>>? notesBlockList, ContourType type)
	{
		if (notesBlockList == null)
		{
			return;
		}
		foreach (List<string> notesBlock in notesBlockList)
		{
			List<DstvContourPoint> list = new List<DstvContourPoint>();
			foreach (string item in notesBlock)
			{
				try
				{
					if (!item.Equals(type.ToString(), StringComparison.Ordinal))
					{
						list.Add(DstvContourPoint.CreatePoint(item));
					}
				}
				catch (DstvParseException value)
				{
					Console.WriteLine(value);
				}
			}
			try
			{
				outElemList.AddRange(Contour.CreateSeveralContours(list, type));
			}
			catch (DstvParseException value2)
			{
				Console.WriteLine(value2);
			}
		}
	}

	private static async Task<Dictionary<ContourType, List<List<string>>?>> GetElementMapAsync(ReaderContext context)
	{
		TextReader reader = context.Source;
		Dictionary<ContourType, List<List<string>>?> elemMap = new Dictionary<ContourType, List<List<string>>>();
		ContourType curKey = ContourType.None;
		while (true)
		{
			string text = await reader.ReadLineAsync().ConfigureAwait(continueOnCapturedContext: false);
			if ((text?.Equals("EN", StringComparison.Ordinal) ?? true) || text.Equals("IN", StringComparison.Ordinal))
			{
				break;
			}
			if (Regex.IsMatch(text, "^\\*\\*.*", RegexOptions.None, TimeSpan.FromSeconds(1.0)))
			{
				continue;
			}
			if (CheckCodeLine(text))
			{
				curKey = (ContourType)Enum.Parse(typeof(ContourType), text);
				if (!CheckIfMark(text))
				{
					Console.WriteLine(text + "Warning: unregistered DStV code-line detected: ");
				}
				if (!elemMap.ContainsKey(curKey))
				{
					elemMap.Add(curKey, new List<List<string>>());
				}
				elemMap.GetValueOrDefault(curKey)?.Add(new List<string>());
			}
			if (curKey != ContourType.None)
			{
				elemMap.GetValueOrDefault(curKey)?.Last().Add(text);
			}
		}
		return elemMap;
	}

	private static bool CheckIfMark(string str)
	{
		return Regex.IsMatch(str, "^BO$|^SI$|^AK$|^IK$|^PU$|^KO$|^SC$|^UE$|^KA$|^EN$|^ST$|^E[0-9]$|^B[0-9]$|^S[0-9]$|^A[0-9]$|^I[0-9]$|^P[0-9]$|^K[0-9]$", RegexOptions.None, TimeSpan.FromSeconds(1.0));
	}

	private static bool CheckCodeLine(string str)
	{
		return Regex.IsMatch(str, "^[A-Z0-9]{2}$", RegexOptions.None, TimeSpan.FromSeconds(1.0));
	}

	public static string[] RemoveVoids(IEnumerable<string> toBeRefined)
	{
		List<string> list = new List<string>(toBeRefined);
		list.RemoveAll(string.IsNullOrEmpty);
		return list.ToArray();
	}
}
