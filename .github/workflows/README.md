# CI/CD Pipeline — BeatSaber Playlist Editor

> Everything in this folder is the automated pipeline. Workflows live here, scripts live in `scripts/`.

## Files

| File                            | Trigger                             | Purpose                                 |
|---------------------------------|-------------------------------------|-----------------------------------------|
| `ci.yml`                        | push + PR + `workflow_call`         | Build + tests + coverage (windows)      |
| `release.yml`                   | tag push `v*`                       | GitHub Release (exe zip)                |
| `nightly.yml`                   | CI success on `master`/`main`       | `nightly-YYYY-MM-DD` prerelease + GFS   |
| `_build.yml`                    | `workflow_call` (internal)          | WinForms publish + zip                  |
| `scripts/*`                     | invoked by workflows                | version/changelog/GFS prune             |

## Version source

`VERSION` file at repo root. The csproj at `src/BeatSaber Playlist Editor/` lives two levels deep (below root), so `version.pl`'s csproj-scan doesn't reach it — the VERSION file is the authoritative source.

## Release artifacts

| Artifact                                              | Produced by          |
|-------------------------------------------------------|----------------------|
| `BeatSaber-Playlist-Editor-win-x64-<version>.zip`     | release + nightly    |

Self-contained WinForms app (net6.0-windows). Windows only.
