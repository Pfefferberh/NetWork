﻿#pragma checksum "..\..\MailWind.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E6549E3D17AE5C6B456EE364D9D4EB97B1CB93527682B24B5951D9BAA88D0BE2"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Mail;
using System;
using System.Collections;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Mail {
    
    
    /// <summary>
    /// MailWind
    /// </summary>
    public partial class MailWind : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\MailWind.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNewMs;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\MailWind.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRefresh;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\MailWind.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lbItem;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\MailWind.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar progress;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Mail;component/mailwind.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MailWind.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btnNewMs = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\MailWind.xaml"
            this.btnNewMs.Click += new System.Windows.RoutedEventHandler(this.btnNewMs_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnRefresh = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\MailWind.xaml"
            this.btnRefresh.Click += new System.Windows.RoutedEventHandler(this.btnRefresh_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lbItem = ((System.Windows.Controls.ListView)(target));
            
            #line 24 "..\..\MailWind.xaml"
            this.lbItem.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.lbItem_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.progress = ((System.Windows.Controls.ProgressBar)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
