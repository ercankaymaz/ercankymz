// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Models.ModelContainer
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Collections;
using System;

#nullable disable
namespace SourceGrid.Cells.Models;

public class ModelContainer
{
  private ModelContainer.ModelList modelList_0 = (ModelContainer.ModelList) null;
  private IValueModel ivalueModel_0;

  public virtual IModel FindModel(Type modelType)
  {
    IModel model;
    if ((this.ivalueModel_0 == null ? 0 : (modelType.IsAssignableFrom(this.ivalueModel_0.GetType()) ? 1 : 0)) != 0)
    {
      model = (IModel) this.ivalueModel_0;
    }
    else
    {
      if (this.modelList_0 == null)
        this.modelList_0 = new ModelContainer.ModelList();
      model = this.modelList_0.GetByType(modelType);
    }
    return model;
  }

  public virtual ModelContainer AddModel(IModel model)
  {
    if (model == null)
      throw new ArgumentNullException();
    if (typeof (IValueModel).IsAssignableFrom(model.GetType()))
    {
      this.ivalueModel_0 = (IValueModel) model;
    }
    else
    {
      if (this.modelList_0 == null)
        this.modelList_0 = new ModelContainer.ModelList();
      this.modelList_0.Add(model);
    }
    return this;
  }

  public virtual ModelContainer RemoveModel(IModel model)
  {
    if (model == this.ivalueModel_0)
      this.ivalueModel_0 = (IValueModel) null;
    else if (this.modelList_0 != null)
      this.modelList_0.Remove(model);
    return this;
  }

  public virtual IValueModel ValueModel
  {
    get => this.ivalueModel_0;
    set => this.ivalueModel_0 = value;
  }

  public class ModelList : ListByType<IModel>
  {
  }
}
