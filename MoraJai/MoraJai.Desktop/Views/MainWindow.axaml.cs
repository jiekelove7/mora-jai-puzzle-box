﻿using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MoraJai.Core;
using MoraJai.ViewModels;

namespace MoraJai.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}