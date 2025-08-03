# 🎵 BeatSaber Playlist Editor

[![License](https://img.shields.io/badge/License-LGPL_3.0-blue)](https://licenses.nuget.org/LGPL-3.0-or-later)
![Language](https://img.shields.io/github/languages/top/Hawkynt/BeatSaber-Playlist-Editor?color=purple)

A user-friendly desktop application for creating and managing your Beat Saber playlists for both PC and Quest!

![Screenshot](https://user-images.githubusercontent.com/14230988/189197825-95580757-0e23-4e33-896c-c346e0106e07.png)

## ✨ Features

*   **Playlist Management:** Create, delete, and edit your playlists with ease.
*   **Customization:** Personalize your playlists by changing their name and cover image.
*   **Song Library:** Browse and search through your entire collection of custom songs.
*   **Drag & Drop:** Intuitively add songs to a playlist by simply dragging them from your library.
*   **Song Ordering:** Arrange the songs in your playlist exactly how you want them.
*   **Save & Refresh:** Quickly save your changes or refresh your libraries to reflect the latest updates.

## 🚀 Getting Started

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

## 📜 License

This project is licensed under the LGPL-3.0 License. See the `LICENSE` file for more details.