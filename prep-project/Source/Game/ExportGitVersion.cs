// Copyright (c) Wojciech Figat. All rights reserved.

using System.IO;
using System.Reflection;
using FlaxEngine;

namespace Game;

/// <summary>
/// Utility script that exports current engine Git revision hash to sync documentation API reference.
/// </summary>
public static class ExportGitVersion
{
    public static void Export(string docsRoot)
    {
        // Get git hash from assembly
        var assembly = typeof(FlaxEditor.Editor).Assembly;
        var assemblyInformationalVersion = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
        var versionParts = assemblyInformationalVersion.InformationalVersion.Split('+');
        var path = Path.Combine(docsRoot, "commit.txt");
        var commit = versionParts[2];
        File.WriteAllText(path, commit);
        Debug.Log($"Exported commit hash ({commit}) to: " + path);
    }
}
