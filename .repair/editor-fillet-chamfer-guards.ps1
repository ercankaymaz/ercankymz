$ErrorActionPreference = 'Stop'
New-Item -ItemType Directory -Force build-logs | Out-Null
$log = 'build-logs/editor-fillet-chamfer-guards.txt'
Remove-Item $log -ErrorAction Ignore
$patched = 0

$path = 'Decompiled/buCadCamRes/buCadCamResVer5/Editor/Drafting2D.cs'
if (-not (Test-Path -LiteralPath $path)) {
    "MISS $path" | Tee-Object $log
    exit 0
}

$text = [IO.File]::ReadAllText($path)
$original = $text

# selEntityIndex is cursor state and may outlive an entity-list mutation. Normalize
# stale indexes before fillet/chamfer attempt to index Entities directly.
$oldFilletHead = @'
  public void EventFillet()
  {
    if (this.firstSelectedEntity == null)
'@
$newFilletHead = @'
  public void EventFillet()
  {
    if (this.selEntityIndex < -1 || this.selEntityIndex >= this.Entities.Count)
      this.selEntityIndex = -1;
    if (this.firstSelectedEntity == null)
'@
if ($text.Contains($oldFilletHead)) {
    $text = $text.Replace($oldFilletHead, $newFilletHead)
    "FIX fillet stale selection-index bounds: $path" | Tee-Object -Append $log
}

$oldChamferHead = @'
  public void EventChamfer()
  {
    if (this.firstSelectedEntity == null)
'@
$newChamferHead = @'
  public void EventChamfer()
  {
    if (this.selEntityIndex < -1 || this.selEntityIndex >= this.Entities.Count)
      this.selEntityIndex = -1;
    if (this.firstSelectedEntity == null)
'@
if ($text.Contains($oldChamferHead)) {
    $text = $text.Replace($oldChamferHead, $newChamferHead)
    "FIX chamfer stale selection-index bounds: $path" | Tee-Object -Append $log
}

# Numeric input controls can still receive damaged/persisted non-finite values.
# Reject them before any clone/intersection/fillet geometry is mutated.
$oldFilletRadius = @'
        clsVar.varEditorRuntimeSet.FilletRadius = clsItem.frmEditorV2.spn_filletrad.Value;
        this.firstSelectedEntity = this.method_19(this.firstSelectedEntity);
'@
$newFilletRadius = @'
        clsVar.varEditorRuntimeSet.FilletRadius = clsItem.frmEditorV2.spn_filletrad.Value;
        if (double.IsNaN(clsVar.varEditorRuntimeSet.FilletRadius) || double.IsInfinity(clsVar.varEditorRuntimeSet.FilletRadius) || clsVar.varEditorRuntimeSet.FilletRadius < 0.0)
        {
          this.ReportDraftingError(new InvalidOperationException("Fillet radius must be a finite non-negative value."), "Fillet");
          this.ClearAllPreviousCommandData();
          return;
        }
        this.firstSelectedEntity = this.method_19(this.firstSelectedEntity);
'@
if ($text.Contains($oldFilletRadius)) {
    $text = $text.Replace($oldFilletRadius, $newFilletRadius)
    "FIX fillet non-finite/negative radius validation: $path" | Tee-Object -Append $log
}

$oldChamferLength = @'
      clsVar.varEditorRuntimeSet.ChamferLength = clsItem.frmEditorV2.spn_chamgerlen.Value;
      this.firstSelectedEntity = this.method_19(this.firstSelectedEntity);
'@
$newChamferLength = @'
      clsVar.varEditorRuntimeSet.ChamferLength = clsItem.frmEditorV2.spn_chamgerlen.Value;
      if (double.IsNaN(clsVar.varEditorRuntimeSet.ChamferLength) || double.IsInfinity(clsVar.varEditorRuntimeSet.ChamferLength) || clsVar.varEditorRuntimeSet.ChamferLength < 0.0)
      {
        this.ReportDraftingError(new InvalidOperationException("Chamfer length must be a finite non-negative value."), "Chamfer");
        this.ClearAllPreviousCommandData();
        return;
      }
      this.firstSelectedEntity = this.method_19(this.firstSelectedEntity);
'@
if ($text.Contains($oldChamferLength)) {
    $text = $text.Replace($oldChamferLength, $newChamferLength)
    "FIX chamfer non-finite/negative length validation: $path" | Tee-Object -Append $log
}

# Decompiled Fillet swallowed every geometry exception. Preserve command cleanup
# but surface the failure through the same status/log channel used elsewhere.
$oldSilentCatch = @'
      catch
      {
      }
      this.ClearAllPreviousCommandData();
'@
$newSilentCatch = @'
      catch (Exception ex)
      {
        this.ReportDraftingError(ex, "Fillet");
      }
      this.ClearAllPreviousCommandData();
'@
if ($text.Contains($oldSilentCatch)) {
    $text = $text.Replace($oldSilentCatch, $newSilentCatch)
    "FIX fillet swallowed exception reporting: $path" | Tee-Object -Append $log
}

# Trim preview checked only Item != null before `as Entity`.Clone(). Labels or
# other selectable objects can therefore produce a null dereference during hover.
$oldTrimPreview = @'
    Drafting2D.entToTrim = (Drafting2D.entityMouseUnder == null ? 0 : (Drafting2D.entityMouseUnder.Item != null ? 1 : 0)) == 0 ? (Entity) null : (Drafting2D.entityMouseUnder.Item as Entity).Clone() as Entity;
    List<Entity> previewEntities = new List<Entity>();
'@
$newTrimPreview = @'
    Entity trimSource = Drafting2D.entityMouseUnder.Item as Entity;
    if (trimSource == null)
      return;
    Drafting2D.entToTrim = trimSource.Clone() as Entity;
    if (Drafting2D.entToTrim == null)
      return;
    List<Entity> previewEntities = new List<Entity>();
'@
if ($text.Contains($oldTrimPreview)) {
    $text = $text.Replace($oldTrimPreview, $newTrimPreview)
    "FIX trim preview non-Entity/clone null guard: $path" | Tee-Object -Append $log
}

if ($text -ne $original) {
    [IO.File]::WriteAllText($path, $text, [Text.UTF8Encoding]::new($false))
    $patched = 1
} else {
    "NO_MATCH_OR_ALREADY_FIXED $path" | Tee-Object -Append $log
}

"Patched fillet/chamfer editor files: $patched" | Tee-Object -Append $log
