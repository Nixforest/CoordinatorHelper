﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MainPrj.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1691")]
        public int UdpMainPort {
            get {
                return ((int)(this["UdpMainPort"]));
            }
            set {
                this["UdpMainPort"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://spj.daukhimiennam.com")]
        public string ServerURL {
            get {
                return ((string)(this["ServerURL"]));
            }
            set {
                this["ServerURL"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("phone")]
        public string PhoneKey {
            get {
                return ((string)(this["PhoneKey"]));
            }
            set {
                this["PhoneKey"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("/api/default/getCustomerByPhone")]
        public string URLGetCustomerByPhone {
            get {
                return ((string)(this["URLGetCustomerByPhone"]));
            }
            set {
                this["URLGetCustomerByPhone"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("-")]
        public string PhoneListToken {
            get {
                return ((string)(this["PhoneListToken"]));
            }
            set {
                this["PhoneListToken"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool TestingMode {
            get {
                return ((bool)(this["TestingMode"]));
            }
            set {
                this["TestingMode"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("8")]
        public int ChannelNumber {
            get {
                return ((int)(this["ChannelNumber"]));
            }
            set {
                this["ChannelNumber"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("/api/default/getCustomerByKeyword")]
        public string URLGetCustomerByKeyword {
            get {
                return ((string)(this["URLGetCustomerByKeyword"]));
            }
            set {
                this["URLGetCustomerByKeyword"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool ListeningCardMode {
            get {
                return ((bool)(this["ListeningCardMode"]));
            }
            set {
                this["ListeningCardMode"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("5")]
        public int PhoneCutLength {
            get {
                return ((int)(this["PhoneCutLength"]));
            }
            set {
                this["PhoneCutLength"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("keyword")]
        public string KeywordKey {
            get {
                return ((string)(this["KeywordKey"]));
            }
            set {
                this["KeywordKey"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("/api/default/updateCustomerPhone")]
        public string URLUpdateCustomerPhone {
            get {
                return ((string)(this["URLUpdateCustomerPhone"]));
            }
            set {
                this["URLUpdateCustomerPhone"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("customer_id")]
        public string CustomerIdKey {
            get {
                return ((string)(this["CustomerIdKey"]));
            }
            set {
                this["CustomerIdKey"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\CoordinatorHelper")]
        public string HistoryFilePath {
            get {
                return ((string)(this["HistoryFilePath"]));
            }
            set {
                this["HistoryFilePath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("history.txt")]
        public string HistoryFileName {
            get {
                return ((string)(this["HistoryFileName"]));
            }
            set {
                this["HistoryFileName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("yyyyMMddHHmmssFFF")]
        public string CallIdFormat {
            get {
                return ((string)(this["CallIdFormat"]));
            }
            set {
                this["CallIdFormat"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("X")]
        public string FinishMark {
            get {
                return ((string)(this["FinishMark"]));
            }
            set {
                this["FinishMark"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("White")]
        public global::System.Drawing.Color ColorTabActiveBackground {
            get {
                return ((global::System.Drawing.Color)(this["ColorTabActiveBackground"]));
            }
            set {
                this["ColorTabActiveBackground"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Lime")]
        public global::System.Drawing.Color ColorIncommingCallText {
            get {
                return ((global::System.Drawing.Color)(this["ColorIncommingCallText"]));
            }
            set {
                this["ColorIncommingCallText"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Blue")]
        public global::System.Drawing.Color ColorHandleCallText {
            get {
                return ((global::System.Drawing.Color)(this["ColorHandleCallText"]));
            }
            set {
                this["ColorHandleCallText"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Black")]
        public global::System.Drawing.Color ColorFinishCallTabText {
            get {
                return ((global::System.Drawing.Color)(this["ColorFinishCallTabText"]));
            }
            set {
                this["ColorFinishCallTabText"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Red")]
        public global::System.Drawing.Color ColorMissCallText {
            get {
                return ((global::System.Drawing.Color)(this["ColorMissCallText"]));
            }
            set {
                this["ColorMissCallText"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2")]
        public int StartSearchTextLength {
            get {
                return ((int)(this["StartSearchTextLength"]));
            }
            set {
                this["StartSearchTextLength"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Black")]
        public global::System.Drawing.Color ColorFinishCallText {
            get {
                return ((global::System.Drawing.Color)(this["ColorFinishCallText"]));
            }
            set {
                this["ColorFinishCallText"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("InactiveCaption")]
        public global::System.Drawing.Color ColorFinishCallBackground {
            get {
                return ((global::System.Drawing.Color)(this["ColorFinishCallBackground"]));
            }
            set {
                this["ColorFinishCallBackground"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("60000")]
        public double TimeAutoCloseMsgBox {
            get {
                return ((double)(this["TimeAutoCloseMsgBox"]));
            }
            set {
                this["TimeAutoCloseMsgBox"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool UpdatePhone {
            get {
                return ((bool)(this["UpdatePhone"]));
            }
            set {
                this["UpdatePhone"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Black")]
        public global::System.Drawing.Color ColorFoundKeywordText {
            get {
                return ((global::System.Drawing.Color)(this["ColorFoundKeywordText"]));
            }
            set {
                this["ColorFoundKeywordText"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0, 192, 0")]
        public global::System.Drawing.Color ColorFoundKeywordBackground {
            get {
                return ((global::System.Drawing.Color)(this["ColorFoundKeywordBackground"]));
            }
            set {
                this["ColorFoundKeywordBackground"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string UserToken {
            get {
                return ((string)(this["UserToken"]));
            }
            set {
                this["UserToken"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("/api/site/login")]
        public string URLLogin {
            get {
                return ((string)(this["URLLogin"]));
            }
            set {
                this["URLLogin"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("751")]
        public int NameLabelPosX {
            get {
                return ((int)(this["NameLabelPosX"]));
            }
            set {
                this["NameLabelPosX"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("760")]
        public int RoleLabelPosX {
            get {
                return ((int)(this["RoleLabelPosX"]));
            }
            set {
                this["RoleLabelPosX"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("/api/site/logout")]
        public string URLLogout {
            get {
                return ((string)(this["URLLogout"]));
            }
            set {
                this["URLLogout"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("/api/user/profile")]
        public string URLUserProfile {
            get {
                return ((string)(this["URLUserProfile"]));
            }
            set {
                this["URLUserProfile"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("/api/default/windowGetConfig")]
        public string URLGetConfig {
            get {
                return ((string)(this["URLGetConfig"]));
            }
            set {
                this["URLGetConfig"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("20000")]
        public double PromoteMoney {
            get {
                return ((double)(this["PromoteMoney"]));
            }
            set {
                this["PromoteMoney"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("786")]
        public int AgentLabelPosX {
            get {
                return ((int)(this["AgentLabelPosX"]));
            }
            set {
                this["AgentLabelPosX"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("/api/default/windowOrderCreate")]
        public string URLCreateOrder {
            get {
                return ((string)(this["URLCreateOrder"]));
            }
            set {
                this["URLCreateOrder"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("/api/default/windowOrderUpdate")]
        public string URLUpdateOrder {
            get {
                return ((string)(this["URLUpdateOrder"]));
            }
            set {
                this["URLUpdateOrder"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("/api/default/windowGetInfoAgent")]
        public string URLGetAgentInfo {
            get {
                return ((string)(this["URLGetAgentInfo"]));
            }
            set {
                this["URLGetAgentInfo"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\CoordinatorHelper")]
        public string OrdersFilePath {
            get {
                return ((string)(this["OrdersFilePath"]));
            }
            set {
                this["OrdersFilePath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("orders.txt")]
        public string OrdersFileName {
            get {
                return ((string)(this["OrdersFileName"]));
            }
            set {
                this["OrdersFileName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("GAS 24H")]
        public string BillBrand {
            get {
                return ((string)(this["BillBrand"]));
            }
            set {
                this["BillBrand"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Times New Roman")]
        public string BilllFont {
            get {
                return ((string)(this["BilllFont"]));
            }
            set {
                this["BilllFont"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("280")]
        public int BillSizeW {
            get {
                return ((int)(this["BillSizeW"]));
            }
            set {
                this["BillSizeW"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("820")]
        public int BillSizeH {
            get {
                return ((int)(this["BillSizeH"]));
            }
            set {
                this["BillSizeH"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("/api/default/windowCustomerCreate")]
        public string URLCreateCustomer {
            get {
                return ((string)(this["URLCreateCustomer"]));
            }
            set {
                this["URLCreateCustomer"] = value;
            }
        }
    }
}
