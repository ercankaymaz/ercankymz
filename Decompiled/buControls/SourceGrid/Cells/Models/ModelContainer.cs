using System;
using DevAge.Collections;

namespace SourceGrid.Cells.Models;

public class ModelContainer
{
	public class ModelList : ListByType<IModel>
	{
	}

	private ModelList modelList_0 = null;

	private IValueModel ivalueModel_0;

	public virtual IValueModel ValueModel
	{
		get
		{
			return ivalueModel_0;
		}
		set
		{
			ivalueModel_0 = value;
		}
	}

	public virtual IModel FindModel(Type modelType)
	{
		if (ivalueModel_0 == null || !modelType.IsAssignableFrom(ivalueModel_0.GetType()))
		{
			if (modelList_0 == null)
			{
				modelList_0 = new ModelList();
			}
			return modelList_0.GetByType(modelType);
		}
		return ivalueModel_0;
	}

	public virtual ModelContainer AddModel(IModel model)
	{
		if (model != null)
		{
			Type type = model.GetType();
			if (!typeof(IValueModel).IsAssignableFrom(type))
			{
				if (modelList_0 == null)
				{
					modelList_0 = new ModelList();
				}
				modelList_0.Add(model);
			}
			else
			{
				ivalueModel_0 = (IValueModel)model;
			}
			return this;
		}
		throw new ArgumentNullException();
	}

	public virtual ModelContainer RemoveModel(IModel model)
	{
		if (model != ivalueModel_0)
		{
			if (modelList_0 != null)
			{
				modelList_0.Remove(model);
			}
		}
		else
		{
			ivalueModel_0 = null;
		}
		return this;
	}
}
