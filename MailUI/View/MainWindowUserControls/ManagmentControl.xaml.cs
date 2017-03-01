﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MailUI.ViewModel;

namespace MailUI.View.MainWindowUserControls
{
    /// <summary>
    /// Interaction logic for ManagmentControl.xaml
    /// </summary>
    public partial class ManagmentControl : UserControl
    {
        public ManagmentControl()
        {
            InitializeComponent();
            var managment = new ManagmentViewModel();
            DataContext = managment;
        }
    }
}