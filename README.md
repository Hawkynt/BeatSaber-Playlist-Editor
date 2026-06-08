# 🎵 BeatSaber Playlist Editor

[![License](https://img.shields.io/github/license/Hawkynt/BeatSaber-Playlist-Editor)](https://github.com/Hawkynt/BeatSaber-Playlist-Editor/blob/main/LICENSE)
[![Language](https://img.shields.io/github/languages/top/Hawkynt/BeatSaber-Playlist-Editor?color=8957D5)](https://github.com/Hawkynt/BeatSaber-Playlist-Editor)

[![CI](https://github.com/Hawkynt/BeatSaber-Playlist-Editor/actions/workflows/ci.yml/badge.svg?branch=main)](https://github.com/Hawkynt/BeatSaber-Playlist-Editor/actions/workflows/ci.yml)
![Last Commit](https://img.shields.io/github/last-commit/Hawkynt/BeatSaber-Playlist-Editor?branch=main)
![Activity](https://img.shields.io/github/commit-activity/m/Hawkynt/BeatSaber-Playlist-Editor)

[![Stars](https://img.shields.io/github/stars/Hawkynt/BeatSaber-Playlist-Editor?color=FFD700)](https://github.com/Hawkynt/BeatSaber-Playlist-Editor/stargazers)
[![Forks](https://img.shields.io/github/forks/Hawkynt/BeatSaber-Playlist-Editor?color=008080)](https://github.com/Hawkynt/BeatSaber-Playlist-Editor/network/members)
[![Issues](https://img.shields.io/github/issues/Hawkynt/BeatSaber-Playlist-Editor)](https://github.com/Hawkynt/BeatSaber-Playlist-Editor/issues)
![Code Size](https://img.shields.io/github/languages/code-size/Hawkynt/BeatSaber-Playlist-Editor?color=4CAF50)
![Repo Size](https://img.shields.io/github/repo-size/Hawkynt/BeatSaber-Playlist-Editor?color=FF9800)

[![Release](https://img.shields.io/github/v/release/Hawkynt/BeatSaber-Playlist-Editor)](https://github.com/Hawkynt/BeatSaber-Playlist-Editor/releases/latest)
[![Nightly](https://img.shields.io/github/v/release/Hawkynt/BeatSaber-Playlist-Editor?include_prereleases&sort=date&filter=nightly-*&label=nightly&color=FF9800)](https://github.com/Hawkynt/BeatSaber-Playlist-Editor/releases)
[![Downloads](https://img.shields.io/github/downloads/Hawkynt/BeatSaber-Playlist-Editor/total)](https://github.com/Hawkynt/BeatSaber-Playlist-Editor/releases)

> A user-friendly desktop application for creating and managing Beat Saber playlists for both PC and Quest — browse, reorder, cover-art and share playlists without hand-editing JSON.

![Screenshot](https://user-images.githubusercontent.com/14230988/189197825-95580757-0e23-4e33-896c-c346e0106e07.png)

## ✨ Features

*   **Playlist Management:** Create, delete, and edit your playlists with ease.
*   **Customization:** Personalize your playlists by changing their name and cover image.
*   **Song Library:** Browse and search through your entire collection of custom songs.
*   **Drag & Drop:** Intuitively add songs to a playlist by simply dragging them from your library.
*   **Song Ordering:** Arrange the songs in your playlist exactly how you want them.
*   **Save & Refresh:** Quickly save your changes or refresh your libraries to reflect the latest updates.

## 📦 Getting Started

1.  **Set Game Path:** Launch the application and click the folder icon 📂 to select your Beat Saber installation directory.
2.  **Manage Playlists:**
    *   Select a playlist from the list on the left to start editing.
    *   Click the `➕` button to create a new playlist.
    *   Click the `🗑️` button to delete the selected playlist.
3.  **Add Songs:** Drag songs from the "Available Songs" list on the right and drop them into the playlist content area.
4.  **Arrange & Remove:** Use the arrow buttons (`🔼`, `🔽`) to reorder songs or the remove button (`❌`) to take them out of the playlist.
5.  **Save:** Click the save icon `💾` to write your changes to the playlist file.

## 💻 Compatibility

This tool is designed to work with Beat Saber installations on PC (e.g., Steam, Oculus) and can manage playlists that are also used on Quest.

## 🏛️ Architecture

This project demonstrates a unique approach by applying the **Model-View-ViewModel (MVVM)** pattern to a **Windows Forms** application. While typically associated with newer frameworks like WPF and MAUI, this architectural choice brings several key benefits:

*   **Separation of Concerns:** The UI (View) is decoupled from the application logic (ViewModel), leading to a cleaner and more organized codebase.
*   **Enhanced Testability:** With the logic isolated in the ViewModel, it can be unit-tested independently of the UI, ensuring greater stability and reliability.
*   **Improved Maintainability:** This separation makes the project easier to understand, debug, and extend over time.

It serves as an interesting case study for applying modern design patterns to classic UI frameworks.

## ❤️ Support

If this project saves you time or money, consider supporting its development:

[![GitHub Sponsors](https://img.shields.io/badge/GitHub-Sponsor-EA4AAA?logo=githubsponsors)](https://github.com/sponsors/Hawkynt)
[![PayPal](https://img.shields.io/badge/PayPal-Donate-00457C?logo=paypal)](https://www.paypal.me/hawkynt)

## 📜 License

Licensed under LGPL-3.0-or-later — see [LICENSE](LICENSE).