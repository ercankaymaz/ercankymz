#!/usr/bin/env python3
"""Fail-closed audit for the deployed CMD Marble five-axis Settings tree."""

from __future__ import annotations

import argparse
import json
import math
import pathlib
import re


INACTIVE = {"old", "backup", "temp"}
AXES = ("X", "Y", "Z", "A", "C")


def active_files(root: pathlib.Path, name: str) -> list[pathlib.Path]:
    matches: list[pathlib.Path] = []
    for path in root.rglob(name):
        relative = path.relative_to(root)
        if any(part.lower() in INACTIVE for part in relative.parts):
            continue
        matches.append(path)
    return sorted(matches)


def assignment(text: str, key: str) -> str:
    pattern = re.compile(rf"^\s*{re.escape(key)}\s*=\s*(.*?)\s*$", re.IGNORECASE | re.MULTILINE)
    match = pattern.search(text)
    if not match:
        raise ValueError(f"missing assignment: {key}")
    return match.group(1)


def finite(value: str, label: str) -> float:
    parsed = float(value.strip())
    if not math.isfinite(parsed):
        raise ValueError(f"non-finite {label}")
    return parsed


def plc_ranges(path: pathlib.Path) -> dict[str, tuple[float, float]]:
    text = path.read_text(encoding="utf-8-sig")
    ranges: dict[str, tuple[float, float]] = {}
    for axis in AXES:
        section_match = re.search(rf"<Axis{axis}>(.*?)</Axis{axis}>", text, re.IGNORECASE | re.DOTALL)
        if not section_match:
            raise ValueError(f"PLCSettings.par missing Axis{axis}")
        set_line = next((line.strip() for line in section_match.group(1).splitlines() if line.strip().lower().startswith("set;")), None)
        if set_line is None:
            raise ValueError(f"PLCSettings.par missing Axis{axis} Set record")
        fields = set_line.split(";")
        if len(fields) < 21:
            raise ValueError(f"PLCSettings.par incomplete Axis{axis} Set record")
        soft_min, soft_max = finite(fields[13], axis), finite(fields[14], axis)
        data_min, data_max = finite(fields[19], axis), finite(fields[20], axis)
        ranges[axis] = (max(soft_min, data_min), min(soft_max, data_max))
    return ranges


def machine_ranges(path: pathlib.Path) -> dict[str, tuple[float, float]]:
    text = path.read_text(encoding="utf-8-sig")
    ranges: dict[str, tuple[float, float]] = {}
    for axis in AXES:
        section_match = re.search(rf"<CodesysAxis_{axis}>(.*?)</CodesysAxis_{axis}>", text, re.IGNORECASE | re.DOTALL)
        if not section_match:
            raise ValueError(f"Machine.prm missing CodesysAxis_{axis}")
        section = section_match.group(1)
        if assignment(section, "CodesysAxSets.setSoftLimitEnable").lower() != "true":
            raise ValueError(f"Machine.prm disables {axis} soft limits")
        soft_min = finite(assignment(section, "CodesysAxSets.setSoftLimitNegative"), axis)
        soft_max = finite(assignment(section, "CodesysAxSets.setSoftLimitPositive"), axis)
        data_min = finite(assignment(section, "CodesysAxSets.setDataLimitNegative"), axis)
        data_max = finite(assignment(section, "CodesysAxSets.setDataLimitPositive"), axis)
        ranges[axis] = (max(soft_min, data_min), min(soft_max, data_max))
    return ranges


def main() -> None:
    parser = argparse.ArgumentParser()
    parser.add_argument("root", type=pathlib.Path)
    args = parser.parse_args()
    root = args.root.resolve()

    runtime_files = active_files(root, "Runtime.prm")
    if len(runtime_files) != 1:
        raise SystemExit(f"FAIL expected one active Runtime.prm, found {len(runtime_files)}")
    runtime = runtime_files[0].read_text(encoding="utf-8-sig")
    machine_id = int(assignment(runtime, "setRuntime.MachineID"))
    app_root = runtime_files[0].parent.parent
    machine_settings = app_root / "Machines" / str(machine_id) / "Settings"
    if not machine_settings.is_dir():
        raise SystemExit(f"FAIL missing active machine Settings: {machine_settings}")

    plc_file = app_root / "PLCSettings.par"
    machine_file = machine_settings / "Machine.prm"
    kinematic_file = machine_settings / "Kinematic5Axis.bukinematic"
    post_file = machine_settings / "postMachine.bupost"
    program_file = machine_settings / "Cam" / "Program.prm"
    marble_file = machine_settings / "Cam" / "Marble" / "Marble.prm"
    for path in (plc_file, machine_file, kinematic_file, post_file, program_file, marble_file):
        if not path.is_file():
            raise SystemExit(f"FAIL missing required setting: {path}")

    plc = plc_ranges(plc_file)
    machine = machine_ranges(machine_file)
    machine_text = machine_file.read_text(encoding="utf-8-sig")
    required_machine_values = {
        "clsAppMarbleOPVar.OptionRTCPEnable": "True",
        "clsAppMarbleOPVar.OptionServoAxisA": "True",
        "clsAppMarbleOPVar.OptionAllAbsoluteEncoder": "True",
        "clsAppMarbleOPVar.InhibitXLimitCheckAlarm": "False",
        "clsAppMarbleOPVar.InhibitYLimitCheckAlarm": "False",
        "clsAppMarbleOPVar.InhibitZLimitCheckAlarm": "False",
        "AlarmActionSettings.XLimitAction": "HardAlarm",
        "AlarmActionSettings.YLimitAction": "HardAlarm",
        "AlarmActionSettings.ZLimitAction": "HardAlarm",
    }
    for key, expected in required_machine_values.items():
        if assignment(machine_text, key).lower() != expected.lower():
            raise SystemExit(f"FAIL unsafe Machine.prm setting: {key}")
    envelope = {axis: (max(plc[axis][0], machine[axis][0]), min(plc[axis][1], machine[axis][1])) for axis in AXES}
    if any(low >= high for low, high in envelope.values()):
        raise SystemExit("FAIL PLC and Machine.prm limits do not intersect")

    kinematic = kinematic_file.read_text(encoding="utf-8-sig")
    if assignment(kinematic, "KinematicBase5.Type").lower() != "cartezianxyz_wristac_5axis":
        raise SystemExit("FAIL active kinematic is not WristAC five-axis")
    vectors = {}
    for key in ("KinematicBase5.OffsetXYZ", "KinematicBase5.RotateCenterOffsetOfA", "KinematicBase5.RotateCenterOffsetOfC"):
        values = tuple(finite(value, key) for value in assignment(kinematic, key).split(";"))
        if len(values) != 3:
            raise SystemExit(f"FAIL invalid vector: {key}")
        vectors[key.rsplit(".", 1)[-1]] = values
    if not any(value != 0.0 for vector in vectors.values() for value in vector):
        raise SystemExit("FAIL kinematic contains no measured offsets")

    post = post_file.read_text(encoding="utf-8-sig")
    axes_section = re.search(r"<AxesUsing>(.*?)</AxesUsing>", post, re.IGNORECASE | re.DOTALL)
    if not axes_section:
        raise SystemExit("FAIL post missing AxesUsing")
    post_axes = {axis: assignment(axes_section.group(1), axis).lower() == "true" for axis in "XYZABC"}
    if post_axes != {"X": True, "Y": True, "Z": True, "A": True, "B": False, "C": True}:
        raise SystemExit(f"FAIL post axis mapping mismatch: {post_axes}")
    if "G51 D0" not in post.upper() or "G20 L$JMP$ K$GOJMP$" not in post.upper():
        raise SystemExit("FAIL post is not the audited CMD dialect")

    marble = marble_file.read_text(encoding="utf-8-sig")
    required_true = (
        "MarbleProgramSettings.CheckMachineLimits",
        "MarbleProgramSettings.CheckPartLimits",
        "MarbleMachineOptionsSettings.RTCPEnable",
        "marbleCamPars.MoveZCAAxesToSafeDistance",
    )
    for key in required_true:
        if assignment(marble, key).lower() != "true":
            raise SystemExit(f"FAIL required Marble safety setting is disabled: {key}")

    program = program_file.read_text(encoding="utf-8-sig")
    c_min = finite(assignment(program, "setCam.CAxisMinLimit"), "Program C minimum")
    c_max = finite(assignment(program, "setCam.CAxisMaxLimit"), "Program C maximum")
    envelope["C"] = (max(envelope["C"][0], c_min), min(envelope["C"][1], c_max))

    result = {
        "status": "PASS",
        "machine_id": machine_id,
        "axis_mapping": "XYZAC",
        "envelope": {axis: {"min": limits[0], "max": limits[1]} for axis, limits in envelope.items()},
        "kinematic": vectors,
        "post": post_file.name,
        "rtcp": True,
    }
    print(json.dumps(result, indent=2, sort_keys=True))


if __name__ == "__main__":
    main()
