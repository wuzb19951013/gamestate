﻿#pragma checksum "C:\Users\wuzb19951013\Desktop\第十组UWP提交材料\UWP提交版本\gamestate\gamestate\pages\local.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0B33291704C4605F8756843304CEE199"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace gamestate.pages
{
    partial class local : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.zk = (global::Windows.UI.Xaml.Controls.FontIcon)(target);
                }
                break;
            case 2:
                {
                    this.GoScore = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 45 "..\..\..\pages\local.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.GoScore).Click += this.GoScore_Click;
                    #line default
                }
                break;
            case 3:
                {
                    this.cd = (global::Windows.UI.Xaml.Controls.FontIcon)(target);
                }
                break;
            case 4:
                {
                    this.SaveGo = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 40 "..\..\..\pages\local.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.SaveGo).Click += this.SaveGo_Click;
                    #line default
                }
                break;
            case 5:
                {
                    this.StartGo = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 26 "..\..\..\pages\local.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.StartGo).Click += this.StartGo_Click;
                    #line default
                }
                break;
            case 6:
                {
                    this.Start2048 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 19 "..\..\..\pages\local.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.Start2048).Click += this.Start2048_Click;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

