﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kanban.Desktop.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.5.0.0")]
    public sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<KanbanConfiguration xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <ProjectId>12</ProjectId>
  <HorizontalDimension>
    <DimensionName>Status</DimensionName>
  </HorizontalDimension>
  <VerticalDimension>
    <DimensionName>AssignedTo</DimensionName>
  </VerticalDimension>
  <CardsItemsConfiguration>
    <CardsItems>
        <CardItem>
          <Area>Main</Area>
          <Path>Subject</Path>
        </CardItem>
        <CardItem>
          <Path>Tracker</Path>
        </CardItem>
        <CardItem>
          <Path>Priority</Path>
        </CardItem>
        <CardItem>
          <Area>Additional</Area>
          <Path>Description</Path>
        </CardItem>
    </CardsItems>
  </CardsItemsConfiguration>
</KanbanConfiguration>")]
        public string h_status_v_assigned_c_subject_treker_details {
            get {
                return ((string)(this["h_status_v_assigned_c_subject_treker_details"]));
            }
            set {
                this["h_status_v_assigned_c_subject_treker_details"] = value;
            }
        }
    }
}
