﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BulkCrapUninstaller.Functions;
using Klocman.Forms.Tools;
using UninstallTools.Uninstaller;

namespace BulkCrapUninstaller.Forms
{
    public partial class AdvancedClipboardCopyWindow : Form
    {
        private AdvancedClipboardCopyWindow()
        {
            InitializeComponent();
        }

        public static void ShowDialog(IWin32Window parent, IEnumerable<ApplicationUninstallerEntry> targets)
        {
            using (var window = new AdvancedClipboardCopyWindow())
            {
                window.advancedClipboardCopy1.Targets = targets;
                window.ShowDialog(parent);
            }
        }

        private void AdvancedClipboardCopyWindow_Shown(object sender, EventArgs e)
        {
            advancedClipboardCopy1.PatternText = "{" + nameof(ApplicationUninstallerEntry.DisplayName) + "} - {" +
                                                 nameof(ApplicationUninstallerEntry.UninstallString) + "}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(advancedClipboardCopy1.Result))
            {
                MessageBoxes.NothingToCopy();
            }
            else
            {
                try
                {
                    Clipboard.SetText(advancedClipboardCopy1.Result);
                }
                catch (Exception ex)
                {
                    PremadeDialogs.GenericError(ex);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}