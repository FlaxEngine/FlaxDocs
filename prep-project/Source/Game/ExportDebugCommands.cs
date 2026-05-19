// Copyright (c) Wojciech Figat. All rights reserved.

using System.Collections.Generic;
using System.IO;
using System.Text;
using FlaxEngine;

namespace Game;

/// <summary>
/// Utility script that exports all Debug Commands for online documentation.
/// </summary>
public static class ExportDebugCommands
{
    public static void Export(string docsRoot)
    {
        // Get all debug commands and sort them
        DebugCommands.GetAllCommands(out var commands);
        var sorted = new List<string>(commands);
        sorted.Sort();
        commands = sorted.ToArray();

        // Generate a single reference table with all commands
        var sb = new StringBuilder();
        sb.AppendLine("| **Command** | **Description** |");
        sb.AppendLine("|-------|------|");
        foreach (var command in commands)
        {
            var help = DebugCommands.GetCommandHelp(command) ?? string.Empty;
            if (help.Contains("[Deprecated"))
                continue; // Skip deprecated commands
            help = help.Replace('\n', ' ');
            sb.AppendFormat("| `{0}` | {1} |", command, help).AppendLine();
        }

        // Write to file for docs
        File.WriteAllText(Path.Combine(docsRoot, "manual/scripting/advanced/debug-commands.gen.md"), sb.ToString(), Encoding.UTF8);
    }
}
