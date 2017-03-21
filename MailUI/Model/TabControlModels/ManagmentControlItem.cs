﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MailUI.Utils.Languages;
using MailUI.View.MainWindowUserControls;

namespace MailUI.Model.TabControlModels
{
    [Export(typeof(ITabControl))]
    public class ManagmentControlItem : ITabControl
    {
        public string Header { get { return Localization.Get("TabItem_Managment"); } }

        public UserControl Control { get { return new ManagmentControl(); } }

        public int Order { get { return 2; } }
    }
}