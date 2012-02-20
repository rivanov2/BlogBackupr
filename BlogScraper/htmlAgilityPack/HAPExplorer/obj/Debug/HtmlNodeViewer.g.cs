﻿#pragma checksum "..\..\HtmlNodeViewer.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "834F7B70D80F5E8736104D4C4F44C4EB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
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


namespace HAPExplorer {
    
    
    /// <summary>
    /// HtmlNodeViewer
    /// </summary>
    public partial class HtmlNodeViewer : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\HtmlNodeViewer.xaml"
        internal System.Windows.Controls.ColumnDefinition Headers;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\HtmlNodeViewer.xaml"
        internal System.Windows.Controls.ColumnDefinition Values;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\HtmlNodeViewer.xaml"
        internal System.Windows.Controls.RowDefinition Tag;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\HtmlNodeViewer.xaml"
        internal System.Windows.Controls.RowDefinition Type;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\HtmlNodeViewer.xaml"
        internal System.Windows.Controls.RowDefinition XpathRow;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\HtmlNodeViewer.xaml"
        internal System.Windows.Controls.RowDefinition Value;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\HtmlNodeViewer.xaml"
        internal System.Windows.Controls.Label lblTagHeader;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\HtmlNodeViewer.xaml"
        internal System.Windows.Controls.Label lblTypeHeader;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\HtmlNodeViewer.xaml"
        internal System.Windows.Controls.Label lblXpathHeader;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\HtmlNodeViewer.xaml"
        internal System.Windows.Controls.Label lblValueHeader;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\HtmlNodeViewer.xaml"
        internal System.Windows.Controls.Label lblTag;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\HtmlNodeViewer.xaml"
        internal System.Windows.Controls.Label lblType;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\HtmlNodeViewer.xaml"
        internal System.Windows.Controls.Button btnCheckXpath;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\HtmlNodeViewer.xaml"
        internal System.Windows.Controls.TextBox lblXpath;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\HtmlNodeViewer.xaml"
        internal System.Windows.Controls.TextBox lblValue;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/HAPExplorer;component/htmlnodeviewer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\HtmlNodeViewer.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Headers = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 2:
            this.Values = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 3:
            this.Tag = ((System.Windows.Controls.RowDefinition)(target));
            return;
            case 4:
            this.Type = ((System.Windows.Controls.RowDefinition)(target));
            return;
            case 5:
            this.XpathRow = ((System.Windows.Controls.RowDefinition)(target));
            return;
            case 6:
            this.Value = ((System.Windows.Controls.RowDefinition)(target));
            return;
            case 7:
            this.lblTagHeader = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.lblTypeHeader = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.lblXpathHeader = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.lblValueHeader = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.lblTag = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.lblType = ((System.Windows.Controls.Label)(target));
            return;
            case 13:
            this.btnCheckXpath = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\HtmlNodeViewer.xaml"
            this.btnCheckXpath.Click += new System.Windows.RoutedEventHandler(this.btnCheckXpath_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.lblXpath = ((System.Windows.Controls.TextBox)(target));
            return;
            case 15:
            this.lblValue = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

