﻿using Microsoft.Maui.Controls;

namespace CorkMaster
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
            
        }
    }
}