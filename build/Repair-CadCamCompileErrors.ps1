$ErrorActionPreference = 'Stop'
$root = Split-Path -Parent $PSScriptRoot
$utf8 = New-Object Text.UTF8Encoding($false)

function Get-Text([string]$rel) {
    $p = Join-Path $root $rel
    if (-not (Test-Path $p)) { throw "Missing source: $rel" }
    [IO.File]::ReadAllText($p)
}
function Set-Text([string]$rel,[string]$text) {
    [IO.File]::WriteAllText((Join-Path $root $rel),$text,$utf8)
}
function Replace-Required([string]$text,[string]$old,[string]$new,[string]$name,[int]$min=1) {
    $count = ([regex]::Matches($text,[regex]::Escape($old))).Count
    if ($count -lt $min) { throw "${name}: expected at least $min occurrence(s), found $count" }
    Write-Host "$name ($count)" -ForegroundColor Green
    $text.Replace($old,$new)
}
function Replace-Optional([string]$text,[string]$old,[string]$new,[string]$name) {
    $count = ([regex]::Matches($text,[regex]::Escape($old))).Count
    if ($count -gt 0) {
        Write-Host "$name ($count)" -ForegroundColor Green
        return $text.Replace($old,$new)
    }
    $text
}

# -----------------------------------------------------------------------------
# FileDialogPlaces: reconstruct the compiler-generated dispose closure as normal C#
# and resize the places array correctly when the caller changes the number of places.
# -----------------------------------------------------------------------------
$rel='buCadCamRes/buDialogExtenders/FileDialogPlaces.cs'
$t=Get-Text $rel
$pattern='(?s)  public static void SetPlaces\(this FileDialog fd, object\[\] places\)\r?\n  \{.*?\r?\n  \}\r?\n\r?\n(?=  public static void ResetPlaces)'
$replacement=@'
  public static void SetPlaces(this FileDialog fd, object[] places)
  {
    if (fd == null || places == null)
      return;

    FileDialogPlaces.object_0 = (object[]) places.Clone();
    if (FileDialogPlaces.registryKey_0 != null)
      FileDialogPlaces.ResetPlaces(fd);

    FileDialogPlaces.smethod_0();
    fd.Disposed += (sender, e) => FileDialogPlaces.ResetPlaces(fd);
  }

'@
$count=([regex]::Matches($t,$pattern)).Count
if($count -ne 1){throw "FileDialogPlaces SetPlaces reconstruction expected 1, found $count"}
$t=[regex]::Replace($t,$pattern,$replacement)
Set-Text $rel $t
Write-Host 'FileDialogPlaces closure repaired.' -ForegroundColor Green

# -----------------------------------------------------------------------------
# Class5: restore compiler-generated locals/closure and remove designer-only
# properties that do not exist in the validated legacy buControls runtime.
# -----------------------------------------------------------------------------
$rel='buCadCamRes/ns8/Class5.cs'
$t=Get-Text $rel

# These properties are purely UI designer metadata from a newer buControls build.
# The validated runtime types do not expose them, so retaining the assignments is
# impossible and has no effect on CAD geometry/CAM calculations.
$before=$t
$t=[regex]::Replace($t,'(?m)^\s*.*\.(?:AuxInfo|ControlStyle)\s*=.*;\r?\n','')
$removed=([regex]::Matches($before,'(?m)^\s*.*\.(?:AuxInfo|ControlStyle)\s*=.*;\r?$')).Count
Write-Host "Removed unsupported buControls designer metadata assignments: $removed" -ForegroundColor Green

$t=$t.Replace('fileDialogControlBase_0.filterChangedEventHandler_0','fileDialogControlBase_0.EventFilterChanged')
$t=$t.Replace('ICurve icurve_0_1;'+"`r`n"+'    Class5.smethod_189(ref icurve_0_1,','ICurve icurve_0_1 = null;'+"`r`n"+'    Class5.smethod_189(ref icurve_0_1,')
$t=$t.Replace('ICurve icurve_0_2;'+"`r`n"+'    Class5.smethod_189(ref icurve_0_2,','ICurve icurve_0_2 = null;'+"`r`n"+'    Class5.smethod_189(ref icurve_0_2,')
$t=$t.Replace('ICurve icurve_0_1;'+"`r`n"+'    Class5.smethod_64(ref icurve_0_1,','ICurve icurve_0_1 = null;'+"`r`n"+'    Class5.smethod_64(ref icurve_0_1,')
$t=$t.Replace('ICurve icurve_0_2;'+"`r`n"+'    Class5.smethod_64(ref icurve_0_2,','ICurve icurve_0_2 = null;'+"`r`n"+'    Class5.smethod_64(ref icurve_0_2,')
$t=$t.Replace('    uint num;'+"`r`n"+'    if (string_0 != null)','    uint num = 0U;'+"`r`n"+'    if (string_0 != null)')

# Reconstruct Printer3D slicing closure with ordinary local collections.
$printerPattern='(?s)  internal static void smethod_124\(clsPrinter3D clsPrinter3D_0\)\r?\n  \{.*?\r?\n  \}\r?\n\r?\n(?=  internal static void smethod_125)'
if(-not [regex]::IsMatch($t,$printerPattern)) {
    $printerPattern='(?s)  static void smethod_124\(clsPrinter3D clsPrinter3D_0\)\r?\n  \{.*?\r?\n  \}\r?\n\r?\n(?=  static void smethod_125)'
}
$printerReplacement=@'
  internal static void smethod_124(clsPrinter3D clsPrinter3D_0)
  {
    Design viewport = (Design) ccVars.Pages[ccVars.PageIndex].Form.viewportcad;
    Class5.smethod_43(buPrinter3D.varTemps.layerCamName, viewport, clsPrinter3D_0);
    Class5.smethod_43(buPrinter3D.varTemps.layerInFill, viewport, clsPrinter3D_0);
    Class5.smethod_43(buPrinter3D.varTemps.layerOffsetSliceName, viewport, clsPrinter3D_0);
    Class5.smethod_43(buPrinter3D.varTemps.layerOnlineSimulationName, viewport, clsPrinter3D_0);
    Class5.smethod_43(buPrinter3D.varTemps.layerRegionName, viewport, clsPrinter3D_0);
    Class5.smethod_43(buPrinter3D.varTemps.layerSimulationName, viewport, clsPrinter3D_0);
    Class5.smethod_43(buPrinter3D.varTemps.layerSliceName, viewport, clsPrinter3D_0);
    Class5.smethod_43(buPrinter3D.varTemps.layerTessellationName, viewport, clsPrinter3D_0);
    viewport.Invalidate();

    Entity[] faceEntities = viewport.Entities.Where<Entity>(entity => entity is IFace).ToArray<Entity>();
    List<Mesh> meshes = new List<Mesh>();
    foreach (Entity entity in faceEntities)
    {
      if (entity is Mesh mesh)
        meshes.Add((Mesh) mesh.Clone());
      else if (entity is Brep brep)
        meshes.Add(brep.ConvertToMesh(0.01));
      else if (entity is devDept.Eyeshot.Entities.Surface surface)
        meshes.Add(surface.ConvertToMesh());
    }

    if (meshes.Count == 0)
    {
      MessageBox.Show("No available geometry to perform slicing");
      return;
    }

    bool simplify = buPrinter3D.varPrinter3DSettings.Simplify;
    bool inFill = buPrinter3D.varPrinter3DSettings.InFill;
    if (buPrinter3D.varPrinter3DSettings.SliceType == Printer3DSliceType.Step)
    {
      if (viewport.Entities.Count > 0 && viewport.Entities[0].BoxMax == (Point3D) null)
        viewport.Entities[0].Regen(0.01);
      if (viewport.Entities.Count > 0 && viewport.Entities[0].BoxMax != (Point3D) null && buPrinter3D.varPrinter3DSettings.SliceStep > 0.0)
        buPrinter3D.varPrinter3DSettings.SliceCount = Convert.ToInt32(viewport.Entities[0].BoxMax.Z / buPrinter3D.varPrinter3DSettings.SliceStep);
    }

    clsPrinter3D_0.slicing_0 = new Slicing(meshes.ToArray(), buPrinter3D.varPrinter3DSettings.SliceCount, -2, simplify, inFill);
    viewport.StartWork((WorkUnit) clsPrinter3D_0.slicing_0);
  }

'@
$pc=([regex]::Matches($t,$printerPattern)).Count
if($pc -ne 1){throw "Printer3D closure reconstruction expected 1, found $pc"}
$t=[regex]::Replace($t,$printerPattern,$printerReplacement)
Set-Text $rel $t
Write-Host 'Class5 compile artifacts repaired.' -ForegroundColor Green

# -----------------------------------------------------------------------------
# clsCommand: lost assignment in layer caption generation.
# -----------------------------------------------------------------------------
$rel='buCadCamRes/buCadCamResVer5/clsCommand.cs'
$t=Get-Text $rel
$old='            $"{str} , {Layers[index].Tufting.StitchMode.ToString()} , P: {Layers[index].Tufting.PileHeight.ToString("f1")} , S: {Layers[index].Tufting.StitchLength.ToString("f1")}";'
$new='            str = $"{str} , {Layers[index].Tufting.StitchMode.ToString()} , P: {Layers[index].Tufting.PileHeight.ToString("f1")} , S: {Layers[index].Tufting.StitchLength.ToString("f1")}";'
$t=Replace-Required $t $old $new 'Layer description assignment'
Set-Text $rel $t

# -----------------------------------------------------------------------------
# Screen DPI helper: initialize point directly instead of an unassigned ref local.
# -----------------------------------------------------------------------------
$rel='buCadCamRes/buCadCamResVer5/ScreenExtensions.cs'
$t=Get-Text $rel
$old=@'
    Point point_0;
    ref Point local = ref point_0;
    Rectangle bounds = screen.Bounds;
    int x = bounds.Left + 1;
    bounds = screen.Bounds;
    int y = bounds.Top + 1;
    local = new Point(x, y);
    Class5.GetDpiForMonitor(Class5.MonitorFromPoint(point_0, 2U), dpiType, out dpiX, out dpiY);
'@
$new=@'
    Rectangle bounds = screen.Bounds;
    Point monitorPoint = new Point(bounds.Left + 1, bounds.Top + 1);
    Class5.GetDpiForMonitor(Class5.MonitorFromPoint(monitorPoint, 2U), dpiType, out dpiX, out dpiY);
'@
$t=Replace-Required $t $old $new 'ScreenExtensions point initialization'
Set-Text $rel $t

# -----------------------------------------------------------------------------
# clsEditorV2: reconstruct missing async state machine as the established synchronous
# editor-open path used by clsEditor. Eyeshot itself still performs DXF/DWG work async.
# -----------------------------------------------------------------------------
$rel='buCadCamRes/buCadCamResVer5/Editor/clsEditorV2.cs'
$t=Get-Text $rel
$openPattern='(?s)  public void cmdOpen\(string FileName = ""\)\r?\n  \{.*?\r?\n  \}\r?\n\r?\n(?=  public void cmdSave\(\))'
$openReplacement=@'
  public void cmdOpen(string FileName = "")
  {
    OpenFileDialog openFileDialog = new OpenFileDialog();
    openFileDialog.InitialDirectory = clsVar.varInterface.pathEditor;
    IList extensions = clsItem.frmEditorV2.OpenFileExtension.Count == 0 ? AppExtension.OpenFileExtension : clsItem.frmEditorV2.OpenFileExtension;
    for (int index = 0; index < extensions.Count; ++index)
      openFileDialog.Filter = index == 0 ? extensions[index].ToString() : $"{openFileDialog.Filter}|{extensions[index]}";

    openFileDialog.FilterIndex = clsVar.varInterface.indexFileEditor;
    bool useDialog = true;
    bool suppliedFile = false;
    DialogResult result = DialogResult.None;
    if (!string.IsNullOrEmpty(FileName))
    {
      FileInfo fileInfo = new FileInfo(FileName);
      if (fileInfo.Exists)
      {
        suppliedFile = true;
        useDialog = false;
        openFileDialog.FileName = fileInfo.FullName;
      }
    }
    if (useDialog)
      result = openFileDialog.ShowDialog();
    if (result != DialogResult.OK && !suppliedFile)
      return;

    this.UndoBuffer();
    string extension = buFile5.getFileExtension(openFileDialog.FileName).ToLower();
    if (extension == ".dxf" || extension == ".dwg")
    {
      ReadAutodesk reader = new ReadAutodesk(openFileDialog.FileName);
      reader.ExtrudeByThickness = clsVar.varFile.ExtrudeByThickness;
      clsItem.frmEditorV2.viewport.Clear();
      clsItem.frmEditorV2.viewport.StartWork((WorkUnit) reader);
    }
    else if (extension == ".bucadv5")
    {
      clsItem.frmEditorV2.viewport.Clear();
      List<Entity> entities = new List<Entity>();
      clsInit.appFiles.OpenBuCadFileVer5(openFileDialog.FileName, true, ref entities);
      foreach (Entity entity in entities)
        clsItem.frmEditorV2.viewport.Entities.Add(entity);
      clsItem.frmEditorV2.viewport.SetView(viewType.Top);
      clsItem.frmEditorV2.viewport.ZoomFit();
      clsItem.frmEditorV2.viewport.Invalidate();
    }

    clsVar.varInterface.indexFileEditor = openFileDialog.FilterIndex;
    clsVar.varInterface.pathEditor = buFile5.GetPath(openFileDialog.FileName);
    clsFiles.SaveParameter();
  }

'@
$oc=([regex]::Matches($t,$openPattern)).Count
if($oc -ne 1){throw "clsEditorV2 cmdOpen reconstruction expected 1, found $oc"}
$t=[regex]::Replace($t,$openPattern,$openReplacement)
$t=$t.Replace('      int int_1;'+"`r`n"+'      Class5.smethod_116(', '      int int_1 = 0;'+"`r`n"+'      Class5.smethod_116(')
Set-Text $rel $t

# clsEditor rectangle helper has the symmetric ref-local issue.
$rel='buCadCamRes/buCadCamResVer5/Editor/clsEditor.cs'
$t=Get-Text $rel
$t=$t.Replace('      int int_0;'+"`r`n"+'      int int_1;'+"`r`n"+'      Class5.smethod_72(ref int_0,', '      int int_0 = 0;'+"`r`n"+'      int int_1;'+"`r`n"+'      Class5.smethod_72(ref int_0,')
Set-Text $rel $t

# -----------------------------------------------------------------------------
# Editor key-hole dialog: use the standard Form dialog result supported by the
# validated buControls F_Barrel instead of newer PropertiesForm metadata.
# -----------------------------------------------------------------------------
$rel='buCadCamRes/buCadCamResVer5/Editor/F_Editor.cs'
$t=Get-Text $rel
$t=$t.Replace('      fBarrel.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;'+"`r`n",'')
$t=$t.Replace('      fBarrel.PropertiesForm.FormPosition = FormStartPosition.CenterParent;','      fBarrel.StartPosition = FormStartPosition.CenterParent;')
$t=$t.Replace('      int num = (int) fBarrel.ShowDialog();'+"`r`n"+'      if (fBarrel.PropertiesForm.Result == DialogResult.OK)','      DialogResult barrelResult = fBarrel.ShowDialog();'+"`r`n"+'      if (barrelResult == DialogResult.OK)')
Set-Text $rel $t

# -----------------------------------------------------------------------------
# Profile source: resolve a local variable that shadows the buEntity type and
# replace a decompiler-only "ref new" expression with an assignable local.
# -----------------------------------------------------------------------------
$rel='buCadCamRes/buCadCamResVer5/Profile/clsProfile.cs'
$t=Get-Text $rel
$t=$t.Replace('          buEntity buEntity = (buEntity) null;','          buEntity scaledEntity = (buEntity) null;')
$t=$t.Replace('buEntity.Copy(this.shapeCreateParameters_0.entitiesCurveList[index7].Entities[index8], ref buEntity);','buEntity.Copy(this.shapeCreateParameters_0.entitiesCurveList[index7].Entities[index8], ref scaledEntity);')
$t=$t.Replace('clsInit.cVector5.Scale(new Point3D(), scaleX, scaleY, 1.0, ref buEntity);','clsInit.cVector5.Scale(new Point3D(), scaleX, scaleY, 1.0, ref scaledEntity);')
$t=$t.Replace('            buEntity.Rotate(Angle, Vector3D.AxisZ, new Point3D());','            scaledEntity.Rotate(Angle, Vector3D.AxisZ, new Point3D());')
$t=$t.Replace('            buEntity.Rotate(90.0, Vector3D.AxisX, new Point3D());','            scaledEntity.Rotate(90.0, Vector3D.AxisX, new Point3D());')
$t=$t.Replace('            if (buEntity != null)','            if (scaledEntity != null)')
$t=$t.Replace('CoordinateFromObjectLocation(OP.OperationData.Alignment, buConversion5.PlaneNamesToPlaneBoxNames(OP.OperationData.selectedPlaneName), buEntity, ref MoveDistance3);','CoordinateFromObjectLocation(OP.OperationData.Alignment, buConversion5.PlaneNamesToPlaneBoxNames(OP.OperationData.selectedPlaneName), scaledEntity, ref MoveDistance3);')
$t=$t.Replace('              entitiesList.Entities.Add(buEntity);','              entitiesList.Entities.Add(scaledEntity);')
$t=$t.Replace('CoordinateFromObjectLocation(OP.OperationData.Alignment, planeBoxNames.Top, buEntity, ref MoveDistance4);','CoordinateFromObjectLocation(OP.OperationData.Alignment, planeBoxNames.Top, scaledEntity, ref MoveDistance4);')
$t=$t.Replace('EntitiesToPointsWithCamDirection(buEntity, buProfileCalc.varProfileSettings.RegenDeviation, ref Points);','EntitiesToPointsWithCamDirection(scaledEntity, buProfileCalc.varProfileSettings.RegenDeviation, ref Points);')

$refNewPattern='(?s)      clsInit\.cVector5\.CoordinateFromPlaneAndCorner\(Size, CopiedOperation\[index\]\.OperationData\.Corner, buConversion5\.PlaneNamesToPlaneBoxNames\(CopiedOperation\[index\]\.OperationData\.selectedPlaneName\), ref new buShape\(\)\r?\n      \{\r?\n        BasePoint = new Point3D\(CopiedOperation\[index\]\.OperationData\.basePosition\.X, CopiedOperation\[index\]\.OperationData\.basePosition\.Y, CopiedOperation\[index\]\.OperationData\.basePosition\.Z\)\r?\n      \}, ref CopiedOperation\[index\]\.OperationData\.Position, this\.shapeCreateParameters_0\.SingX, this\.shapeCreateParameters_0\.SingY\);'
$refNewReplacement=@'
      buShape referenceShape = new buShape()
      {
        BasePoint = new Point3D(CopiedOperation[index].OperationData.basePosition.X, CopiedOperation[index].OperationData.basePosition.Y, CopiedOperation[index].OperationData.basePosition.Z)
      };
      clsInit.cVector5.CoordinateFromPlaneAndCorner(Size, CopiedOperation[index].OperationData.Corner, buConversion5.PlaneNamesToPlaneBoxNames(CopiedOperation[index].OperationData.selectedPlaneName), ref referenceShape, ref CopiedOperation[index].OperationData.Position, this.shapeCreateParameters_0.SingX, this.shapeCreateParameters_0.SingY);
'@
if([regex]::IsMatch($t,$refNewPattern)){$t=[regex]::Replace($t,$refNewPattern,$refNewReplacement)}
Set-Text $rel $t

# -----------------------------------------------------------------------------
# Drill code generation: a temporary list passed by ref must be a local variable.
# -----------------------------------------------------------------------------
foreach($rel in @('buCadCamRes/buCadCamResVer5/Drill/clsDrillGoAtc.cs','buCadCamRes/buCadCamResVer5/Drill/clsDrillSirius.cs')) {
    $t=Get-Text $rel
    $pattern='(?s)      for \(int index = 0; index <= drillCalcItemList15\.Count - 1; \+\+index\)\r?\n        this\.CreateCodeForSlotTopSide\(ref Job, ref new List<DrillCalcItem>\(\)\r?\n        \{\r?\n          drillCalcItemList15\[index\]\r?\n        \}\);'
    $replacement=@'
      for (int index = 0; index <= drillCalcItemList15.Count - 1; ++index)
      {
        List<DrillCalcItem> slotItems = new List<DrillCalcItem>() { drillCalcItemList15[index] };
        this.CreateCodeForSlotTopSide(ref Job, ref slotItems);
      }
'@
    $n=([regex]::Matches($t,$pattern)).Count
    if($n -ne 1){throw "${rel}: ref-list repair expected 1, found $n"}
    $t=[regex]::Replace($t,$pattern,$replacement)
    Set-Text $rel $t
}

# -----------------------------------------------------------------------------
# Marble: namespace/version mismatches, pattern-variable decompiler artifacts,
# sender conversion and CamType name shadowing.
# -----------------------------------------------------------------------------
$rel='buCadCamRes/buCadCamResVer5/Marble/clsMarble.cs'
$t=Get-Text $rel
$t=$t.Replace('buMarble.LangMarbleMessage','buMarbleCalc.LangMarbleMessage')
$t=$t.Replace('buMarble.LangMarbleCaptions','buMarbleCalc.LangMarbleCaptions')

$menuOld=@'
    if (!(sender is System.Windows.Forms.Control control))
    {
      sender.GetType().ToString();
      if (sender is ToolStripMenuItem)
      {
        control = new System.Windows.Forms.Control();
        control.Name = ((ToolStripItem) sender).Name;
      }
    }
'@
$menuNew=@'
    System.Windows.Forms.Control control = sender as System.Windows.Forms.Control;
    if (control == null)
    {
      ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
      if (menuItem == null)
        return;
      control = new System.Windows.Forms.Control();
      control.Name = menuItem.Name;
    }
'@
$t=Replace-Required $t $menuOld $menuNew 'Marble popup sender repair'

$method6Old=@'
    Cmd = MarbleCadCamCommands.None;
    alingmentCommands = MarbleAlingmentCommands.None;
    double num = 0.0;
    if (!(object_0 is MarbleCadCamCommands Cmd))
      ;
    if (object_1 != null && buNumeric5.IsNumeric(object_1.ToString()))
      num = Convert.ToDouble(object_1.ToString());
    if (!(object_2 is MarbleAlingmentCommands alingmentCommands))
      ;
'@
$method6New=@'
    MarbleCadCamCommands Cmd = object_0 is MarbleCadCamCommands command ? command : MarbleCadCamCommands.None;
    MarbleAlingmentCommands alingmentCommands = object_2 is MarbleAlingmentCommands alignment ? alignment : MarbleAlingmentCommands.None;
    double num = 0.0;
    if (object_1 != null && buNumeric5.IsNumeric(object_1.ToString()))
      num = Convert.ToDouble(object_1.ToString());
'@
$t=Replace-Required $t $method6Old $method6New 'Marble alignment command variables'

$method7Old=@'
    marbleCadCamCommands = MarbleCadCamCommands.None;
    double num = 0.0;
    if (!(object_0 is MarbleCadCamCommands marbleCadCamCommands))
      ;
'@
$method7New=@'
    MarbleCadCamCommands marbleCadCamCommands = object_0 is MarbleCadCamCommands command ? command : MarbleCadCamCommands.None;
    double num = 0.0;
'@
$t=Replace-Required $t $method7Old $method7New 'Marble vacuum command variable'

$camMembers='Rough|Finish|ParallelCut|ConstantZ|Flatlands|Pencil|Projection|Geodesic|ConstantCusp'
$t=[regex]::Replace($t,"(?<![A-Za-z0-9_\.])CamType\.($camMembers)",'buClass.CamType.$1')
Set-Text $rel $t

Write-Host 'Remaining high-confidence compile artifacts repaired.' -ForegroundColor Green
