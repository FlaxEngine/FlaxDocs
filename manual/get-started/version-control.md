# Version Control Systems

When working in a team using Flax Engine, it's very common to use a **version control system**.
Using a version control system makes it easier for users to manage their code and assets. It is a repository of files with monitored access, which in the case of Flax, will be all the files associated with a Flax project. With version control it is possible to follow every change to the source along with information on who made the change, why they made it and what they changed/added. This makes it easy to revert back to an earlier version of the code or to compare differences in versions. It also becomes easier to locate when a bug first occurred along with what code might have caused it.

By default, all Flax project data is split into two parts: **Content** and **Source**. This means that all C# script files are organized in a single directory (including subdirectories). Asset files are in a separate directory making the use of an external storage solution easier (OwnCloud, Dropbox, etc.) This is especially useful when dealing with large file sizes.

## Example .gitignore

Here is an example `.gitignore` file for a **Git** repository with a Flax project ([download link](https://github.com/FlaxEngine/FlaxSamples/blob/master/.gitignore)).

```.gitignore
# Ignore Flax project files
/Binaries/
/Cache/
/Logs/
/Output/
/Screenshots/
*.HotReload.*
Source/*.Gen.*

# Ignore Visual Studio project files (generated locally)
*.csproj
*.sln
launchSettings.json

# Ignore Visual Studio Code project files (generated locally)
*.code-workspace
*.vscode/

# Ignore Rider project files (generated locally)
*.idea/

# Ignore thumbnails created by Windows and MacOS
Thumbs.db
.DS_Store

# Ignore files built by Visual Studio
*.obj
*.exe
*.pdb
*.user
*.aps
*.pch
*.vspscc
*_i.c
*_p.c
*.ncb
*.suo
*.tlb
*.tlh
*.bak
*.cache
*.ilk
*.log
[Bb]in
*.lib
*.sbr
/Source/obj/
_ReSharper*/
[Tt]est[Rr]esult*
.vs/

# Ignore Nuget packages folder
packages/
```

## Example .gitattributes

Here is an example `.gitattributes` file for the **Git LFS** repository with a Flax project. By using [Large Files Storage](https://github.com/git-lfs/git-lfs/wiki/Tutorial) you can improve repository performance for asset files that are using binary format and tend to be big (models, textures, etc.).

```.gitattributes
# Flax Engine files
*.flax filter=lfs diff=lfs merge=lfs -text

# Asset source file types
*.png filter=lfs diff=lfs merge=lfs -text
*.tga filter=lfs diff=lfs merge=lfs -text
*.raw filter=lfs diff=lfs merge=lfs -text
*.wav filter=lfs diff=lfs merge=lfs -text
*.psd filter=lfs diff=lfs merge=lfs -text
*.mov filter=lfs diff=lfs merge=lfs -text
*.jpg filter=lfs diff=lfs merge=lfs -text
*.jpeg filter=lfs diff=lfs merge=lfs -text
*.hdr filter=lfs diff=lfs merge=lfs -text
*.fbx filter=lfs diff=lfs merge=lfs -text
```
