﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GrSU.University.Clients.Resources.Entities {
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
    public class DisplayNames {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal DisplayNames() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("GrSU.University.Clients.Resources.Entities.DisplayNames", typeof(DisplayNames).Assembly);
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
        ///   Looks up a localized string similar to Имя.
        /// </summary>
        public static string FirstName {
            get {
                return ResourceManager.GetString("FirstName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Группа.
        /// </summary>
        public static string Group {
            get {
                return ResourceManager.GetString("Group", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Фамилия.
        /// </summary>
        public static string LastName {
            get {
                return ResourceManager.GetString("LastName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Название.
        /// </summary>
        public static string Name {
            get {
                return ResourceManager.GetString("Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Количество мест.
        /// </summary>
        public static string SitsCount {
            get {
                return ResourceManager.GetString("SitsCount", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Количество студентов.
        /// </summary>
        public static string StudentCount {
            get {
                return ResourceManager.GetString("StudentCount", resourceCulture);
            }
        }
    }
}