﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WindowsInput.Native;
using WindowsInput;

namespace Typingcom2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : Application
    {
        public static bool isCheatRunning = false;
        public static bool cheatFinished = false;
        public async static void simulateTypingText(string Text, int typingDelay)
        {
            isCheatRunning = true;
            cheatFinished = false;
            InputSimulator sim = new InputSimulator();
            char[] letters = Text.Replace("\u00A0", " ").ToCharArray();
            foreach (char letter in letters)
            {
                sim.Keyboard.TextEntry(letter);
                if (cheatFinished)
                {
                    break;
                }
                await Task.Delay(typingDelay);
            }
            isCheatRunning = false;
        }
    }
}
