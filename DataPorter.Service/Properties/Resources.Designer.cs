﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CAS.DataPorter.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CAS.DataPorter.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Problem with license.
        /// (reason: &quot;{0}&quot;) 
        ///Verify or install new license..
        /// </summary>
        public static string tx_DataPorter_MainForm_LicenceExceptionOnInitialisation {
            get {
                return ResourceManager.GetString("tx_DataPorter_MainForm_LicenceExceptionOnInitialisation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot SwitchOn the transaction.
        /// </summary>
        public static string tx_OPCDataQueue_CannotSwitchOn {
            get {
                return ResourceManager.GetString("tx_OPCDataQueue_CannotSwitchOn", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The transaction is empty..
        /// </summary>
        public static string tx_OPCDataQueue_CannotSwitchOn_empty {
            get {
                return ResourceManager.GetString("tx_OPCDataQueue_CannotSwitchOn_empty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Operation: {0} cannot be added..
        /// </summary>
        public static string tx_OPCDataQueue_Operation_CannotBeAdded {
            get {
                return ResourceManager.GetString("tx_OPCDataQueue_Operation_CannotBeAdded", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Transaction: {0} cannot be added..
        /// </summary>
        public static string tx_OPCDataQueue_Transaction_CannotBeAdded {
            get {
                return ResourceManager.GetString("tx_OPCDataQueue_Transaction_CannotBeAdded", resourceCulture);
            }
        }
    }
}
