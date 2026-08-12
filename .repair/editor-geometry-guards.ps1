$ErrorActionPreference = 'Stop'
New-Item -ItemType Directory -Force build-logs | Out-Null
$log = 'build-logs/editor-geometry-guards.txt'
Remove-Item $log -ErrorAction Ignore
$patched = 0

$path = 'Decompiled/buCadCamRes/buCadCamResVer5/Editor/Drafting2D.cs'
if (-not (Test-Path -LiteralPath $path)) {
    "MISS $path" | Tee-Object -Append $log
    exit 0
}

$text = [IO.File]::ReadAllText($path)
$original = $text

# Final 3-click arc creation normalizes vectors without checking their lengths.
# Repeated clicks can therefore normalize a zero vector and propagate NaN into
# SignedAngleBetween/Arc construction. Keep the command retryable by dropping
# only the invalid click state where possible.
$oldArc = @'
            if (Drafting2D.points.Count == 3)
            {
              this.drawingPlane = Class5.smethod_209(this, Drafting2D.points[1].Pnt3D);
              Vector2D u = new Vector2D((Point2D) Drafting2D.points[0].Pnt3D, (Point2D) Drafting2D.points[1].Pnt3D);
              u.Normalize();
              Vector2D v = new Vector2D((Point2D) Drafting2D.points[0].Pnt3D, (Point2D) this.current);
              v.Normalize();
              this.arcSpanAngle = Vector2D.SignedAngleBetween(u, v);
              clsInit.appEditor2.AddArc(this.drawingPlane, this.drawingPlane.Origin, this.radius, 0.0, this.arcSpanAngle);
            }
'@
$newArc = @'
            if (Drafting2D.points.Count == 3)
            {
              double baseLength = Drafting2D.points[0].Pnt3D.DistanceTo(Drafting2D.points[1].Pnt3D);
              double spanLength = Drafting2D.points[0].Pnt3D.DistanceTo(Drafting2D.points[2].Pnt3D);
              if (baseLength <= 0.001 || double.IsNaN(baseLength) || double.IsInfinity(baseLength))
              {
                while (Drafting2D.points.Count > 1)
                  Drafting2D.points.RemoveAt(Drafting2D.points.Count - 1);
                clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineNextPoint, buLangTranslate.preDef.Arc);
                return;
              }
              if (spanLength <= 0.001 || double.IsNaN(spanLength) || double.IsInfinity(spanLength))
              {
                Drafting2D.points.RemoveAt(Drafting2D.points.Count - 1);
                clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineLastPoint, buLangTranslate.preDef.Arc);
                return;
              }
              this.drawingPlane = Class5.smethod_209(this, Drafting2D.points[1].Pnt3D);
              Vector2D u = new Vector2D((Point2D) Drafting2D.points[0].Pnt3D, (Point2D) Drafting2D.points[1].Pnt3D);
              u.Normalize();
              Vector2D v = new Vector2D((Point2D) Drafting2D.points[0].Pnt3D, (Point2D) this.current);
              v.Normalize();
              this.arcSpanAngle = Vector2D.SignedAngleBetween(u, v);
              if (double.IsNaN(this.arcSpanAngle) || double.IsInfinity(this.arcSpanAngle) || Math.Abs(this.arcSpanAngle) <= 0.001)
              {
                Drafting2D.points.RemoveAt(Drafting2D.points.Count - 1);
                clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineLastPoint, buLangTranslate.preDef.Arc);
                return;
              }
              clsInit.appEditor2.AddArc(this.drawingPlane, this.drawingPlane.Origin, this.radius, 0.0, this.arcSpanAngle);
            }
'@
if ($text.Contains($oldArc)) {
    $text = $text.Replace($oldArc, $newArc)
    "FIX editor final arc zero-vector/non-finite angle guards: $path" | Tee-Object -Append $log
}

# Dynamic arc preview already protects a zero base radius, but the cursor may be
# exactly on the first point, making the second normalized vector zero.
$oldPreview = @'
    this.drawingPlane = Class5.smethod_209(this, Drafting2D.points[1].Pnt3D);
    Vector2D u = new Vector2D((Point2D) Drafting2D.points[0].Pnt3D, (Point2D) Drafting2D.points[1].Pnt3D);
    u.Normalize();
    Vector2D v = new Vector2D((Point2D) Drafting2D.points[0].Pnt3D, (Point2D) this.current);
'@
$newPreview = @'
    if (this.current == null || Drafting2D.points[0].Pnt3D.DistanceTo(this.current) <= 0.001)
      return;
    this.drawingPlane = Class5.smethod_209(this, Drafting2D.points[1].Pnt3D);
    Vector2D u = new Vector2D((Point2D) Drafting2D.points[0].Pnt3D, (Point2D) Drafting2D.points[1].Pnt3D);
    u.Normalize();
    Vector2D v = new Vector2D((Point2D) Drafting2D.points[0].Pnt3D, (Point2D) this.current);
'@
if ($text.Contains($oldPreview)) {
    $text = $text.Replace($oldPreview, $newPreview)
    "FIX editor dynamic arc cursor zero-vector guard: $path" | Tee-Object -Append $log
}

if ($text -ne $original) {
    [IO.File]::WriteAllText($path, $text, [Text.UTF8Encoding]::new($false))
    $patched++
} else {
    "NO_MATCH_OR_ALREADY_FIXED editor geometry: $path" | Tee-Object -Append $log
}

"Patched editor geometry files: $patched" | Tee-Object -Append $log
