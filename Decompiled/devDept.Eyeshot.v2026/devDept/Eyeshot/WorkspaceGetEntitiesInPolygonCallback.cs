using System.Collections.Generic;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

internal delegate int[] WorkspaceGetEntitiesInPolygonCallback(FrustumParams myParams, IList<Entity> entList, bool selectableOnly, out SelectedItem[] selectedItem, IsInScreenDelegate isInScreenDelegate, bool checkIsInFrustum);
