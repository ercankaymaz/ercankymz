using System.Drawing;
using devDept.Eyeshot.Entities;
using devDept.Graphics;

namespace devDept.Eyeshot;

internal delegate void WorkspaceSetMatrixAndColorFunc(ShaderParameters shaderParams, DrawParams data, entityNatureType nature, Color color, Material material, bool selected, Color mySelectionColor, bool internalSelection);
