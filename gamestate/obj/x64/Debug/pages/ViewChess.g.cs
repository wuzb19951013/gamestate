﻿#pragma checksum "C:\Users\wuzb19951013\Desktop\第十组UWP提交材料\UWP提交版本\gamestate\gamestate\pages\ViewChess.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "384DFE4182438AE2F0D8F0F4F8484B3A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace gamestate
{
    partial class ViewChess : 
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
                    global::Windows.UI.Xaml.Controls.ScrollViewer element1 = (global::Windows.UI.Xaml.Controls.ScrollViewer)(target);
                    #line 11 "..\..\..\pages\ViewChess.xaml"
                    ((global::Windows.UI.Xaml.Controls.ScrollViewer)element1).ViewChanged += this.ScrollViewer_ViewChanged;
                    #line default
                }
                break;
            case 2:
                {
                    this.chessBoard = (global::Windows.UI.Xaml.Controls.Canvas)(target);
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
