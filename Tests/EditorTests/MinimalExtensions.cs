using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BeatSaber_Playlist_Editor.ViewModel;

internal static class MinimalExtensions {
  public static bool SetProperty<T>(this object owner, Action<string?>? changed, ref T field, T value, [CallerMemberName] string? propertyName = null) {
    if (EqualityComparer<T>.Default.Equals(field, value))
      return false;
    field = value;
    changed?.Invoke(propertyName);
    return true;
  }

  public static void AddRange<T>(this IList<T> list, IEnumerable<T> items) {
    foreach (var item in items)
      list.Add(item);
  }

  public static bool ContainsNot<T>(this ICollection<T> collection, T item) => !collection.Contains(item);

  public static bool IsNotNullOrWhiteSpace(this string? text) => !string.IsNullOrWhiteSpace(text);
}

public class SortableBindingList<T> : BindingList<T> {
  public SortableBindingList() { }
  public SortableBindingList(IList<T> list) : base(list) { }
}