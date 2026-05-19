// Copyright (c) Wojciech Figat. All rights reserved.

using System;
using System.IO;
using FlaxEditor;
using FlaxEngine;

namespace Game;

/// <summary>
/// Plugin to run documentation preparations code on startup.
/// </summary>
public class PrepPlugin : EditorPlugin
{
    /// <inheritdoc/>
    public override void Initialize()
    {
        base.Initialize();

        try
        {
            // Get docs folder
            var docsRoot = Path.Combine(Globals.ProjectFolder, "..");
            docsRoot = StringUtils.NormalizePath(docsRoot);
            if (!File.Exists(Path.Combine(docsRoot, "docfx.json")))
                throw new Exception("Invalid workspace, cannot find Flax Docs folder");

            // Export data
            ExportGitVersion.Export(docsRoot);
            ExportDebugCommands.Export(docsRoot);

            // Shutdown
            Engine.RequestExit();
        }
        catch (Exception ex)
        {
            Debug.LogError("Failed to export engine info for docs");
            Debug.LogException(ex);
            Engine.RequestExit(1);
        }
    }
}
