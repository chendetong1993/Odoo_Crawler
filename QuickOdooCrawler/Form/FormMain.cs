// Copyright © 2010-2015 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickOdooCrawler
{
    public partial class FormMain : Form
    {
        private readonly Core Core;
        private readonly ChromiumWebBrowser browser;
        //private readonly Communication Communication;
        public FormMain()
        {
            InitializeComponent();
            browser = new ChromiumWebBrowser("") { Dock = DockStyle.Fill };
            panelWebBrowser.Controls.Add(browser);
            Core = new Core(browser, new Action<bool>((CoreIsBusy) => {
                toolStripButtonStart.Visible = !CoreIsBusy;
                toolStripButtonEndTask.Visible = CoreIsBusy;
                tabControlMain.Enabled = !CoreIsBusy;
                //comboBoxInfoSearch.Enabled = !CoreIsBusy;
                //checkBoxInfoAutoAppendLineToken.Enabled = !CoreIsBusy;
                //checkBoxInfoAutoResetText.Enabled = !CoreIsBusy;
                //richTextBoxInfoSearchMulti.Enabled = !CoreIsBusy;
                if (!CoreIsBusy) {
                    if (richTextBoxInfoResultMulti.Text.Length > 0) {
                        Clipboard.SetText(richTextBoxInfoResultMulti.Text);
                    }
                }
            }));

            /*
            Communication = new Communication(new Action<string, Action<string>>((string input, Action<string> Return) =>
            {
                Core.Search(input, Return);
            }));
            */
        }


        private void buttonInfoSearchMulti_Click(object sender, EventArgs e)
        {
            if (toolStripButtonStart.Visible)
            {
                richTextBoxInfoResultMulti.Text = "";
                foreach (var i in richTextBoxInfoSearchMulti.Text.Split('\n').Where(c => (c.Length > 0)).ToArray())
                {
                    Core.Run(
                        string.Format(
                            "{0}{1} {2}:{3}",
                            i, Core.SplitSymbol, 
                            Core.CommandToken, comboBoxInfoSearch.SelectedItem.ToString()),
                        new Action<string>((string Value) =>
                        {
                            richTextBoxInfoResultMulti.AppendText(Value + "\n");
                        }
                    ));
                }
            }
        }

        private void toolStripLabelSetting_Click(object sender, EventArgs e)
        {
            Process.Start(Core.SettingPath);
        }

        private void toolStripButtonRestart_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }

        private string GetInputInfoFormat()
        {
            StringBuilder Text = new StringBuilder();
            HashSet<string> CrawlerLabels = new HashSet<string>();
            foreach (var i0 in Core.SearchListInfoFlow[comboBoxInfoSearch.SelectedItem.ToString()])
            {
                foreach (var i1 in i0.Item2)
                {
                    if (!CrawlerLabels.Contains(i1))
                    {
                        Text.Append(string.Format("{0}: {1}   ", i1, Core.SplitSymbol));
                    }
                }
                foreach (var i1 in i0.Item4)
                {
                    if (!CrawlerLabels.Contains(i1.Item4))
                    {
                        CrawlerLabels.Add(i1.Item4);
                    }
                }
            }
            return Text.ToString();
        }

        private void InfoResetText_Click()
        {
            richTextBoxInfoSearchMulti.Text = GetInputInfoFormat().TrimEnd(new char[] { ' ', Core.SplitSymbol });
            richTextBoxInfoSearchMulti.Select(richTextBoxInfoSearchMulti.Text.Length, 0);
            richTextBoxInfoSearchMulti.Focus();
        }

        private void checkBoxInfoAutoResetText_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxInfoAutoResetText.Checked)
            {
                InfoResetText_Click();
            }
        }

        private void comboBoxInfo_SelectedIndexChanged(object sender, EventArgs e)
        {

            checkBoxInfoAutoResetText_CheckedChanged(null, null);
            if (Core.SearchListInfoFlow[comboBoxInfoSearch.SelectedItem.ToString()].Length > 0)
            {
                browser.Load(Core.SearchListInfoFlow[comboBoxInfoSearch.SelectedItem.ToString()][0].Item1);
            }
        }


        private void richTextBoxInfoSearchMulti_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F1)
            {
                richTextBoxInfoSearchMulti.AppendText(string.Format("{0}{1}", (richTextBoxInfoSearchMulti.Text.EndsWith("\n") || richTextBoxInfoSearchMulti.Text.Length == 0)? "" : "\n", GetInputInfoFormat()).TrimEnd(new char[] { ' ', Core.SplitSymbol }));
            } else if (e.KeyData == Keys.F3) {
                buttonInfoSearchMulti_Click(null, null);
            }
            else if (e.KeyData == Keys.F4)
            {
                toolStripButtonEndTask_Click(null, null);
            }
        }

        private void toolStripButtonEndTask_Click(object sender, EventArgs e)
        {
            Core.EndTask();
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            foreach (var i in Core.SearchListInfoFlow)
            {
                comboBoxInfoSearch.Items.Add(i.Key);
            }
            comboBoxInfoSearch.SelectedIndex = 0;
        }

        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }
    }
}
