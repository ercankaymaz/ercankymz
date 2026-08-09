using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using buClass.Apps;
using buEyeBaseVer5.buEntities;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleReCalculateParameter : buSerilization5
{
	public camParameters5 CamPar = new camParameters5();

	public marbleOperation Operation = new marbleOperation();

	public marbleCamParameters CamMarblePar = new marbleCamParameters();

	public List<List<buEntity>> ReCalcEntities = new List<List<buEntity>>();

	public List<List<buEntity>> ReCalcAfterEntities = new List<List<buEntity>>();

	public List<List<Pnt6D>> CalculatedPnt6D = new List<List<Pnt6D>>();

	public int CamIndex = -1;

	public bool Copy = false;

	public marbleReCalculateParameter()
	{
	}

	public marbleReCalculateParameter(marbleReCalculateParameter data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null))
		{
			return;
		}
		if (GetType() == CopiedClass.GetType())
		{
			FieldInfo[] fields = GetType().GetFields();
			if (fields != null)
			{
				for (int i = 0; i <= fields.Length - 1; i++)
				{
					_ = fields[i].Name;
					object value = fields[i].GetValue(CopiedClass);
					fields[i].SetValue(this, value);
				}
			}
		}
		CamPar = new camParameters5(data.CamPar);
		Operation = new marbleOperation(data.Operation);
		CamMarblePar = new marbleCamParameters(data.CamMarblePar);
		buEntity.Copy(data.ReCalcEntities, ref ReCalcEntities);
		buEntity.Copy(data.ReCalcAfterEntities, ref ReCalcAfterEntities);
		Pnt6D.Copy(data.CalculatedPnt6D, ref CalculatedPnt6D);
	}
}
