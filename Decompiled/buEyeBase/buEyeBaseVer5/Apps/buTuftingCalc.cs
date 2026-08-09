using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;

namespace buEyeBaseVer5.Apps;

public class buTuftingCalc
{
	public static List<TuftingSequenceItem> Sorted;

	public void GetAvailableSequenceID(EntityList refEntities, ref int SequenceID)
	{
		try
		{
			new List<int>();
			int num = -1;
			for (int i = 0; i <= refEntities.Count - 1; i++)
			{
				if (refEntities[i].EntityData != null && refEntities[i].EntityData.GetType() == typeof(CustomData))
				{
					CustomData customData = (CustomData)refEntities[i].EntityData;
					if (customData.Sequence > num)
					{
						num = customData.Sequence;
					}
				}
			}
			SequenceID = num + 1;
		}
		catch (Exception mSException)
		{
			string text = "buTuftingCalc - ID = 101-00001";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public bool isSameLayerTuftOrOutline(string refLayerName, string checkLayerName)
	{
		string[] array = refLayerName.Split('_');
		string[] array2 = checkLayerName.Split('_');
		if (!((array.Length >= 2) & (array2.Length >= 2)) || !(array[1] == array2[1]))
		{
			return false;
		}
		return true;
	}
}
