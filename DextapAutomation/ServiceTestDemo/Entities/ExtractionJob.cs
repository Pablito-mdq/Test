using Dextap.Testing.Entities;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Testing.Entities
{
    [XmlRoot("ExtractionJobModel")]
    public class ExtractionJob
    {
        public ExtractionJob()
        {
            Reports = new List<Report>();
            DataCutFilters = new List<DataCutFilter>();
            Notifications = new List<Notification>();
            Emails = new List<Email>();
            Quotas = new List<Quota>();
            RunImmediately = true;
            ID = new Random().Next(int.MaxValue / 2, int.MaxValue);
            JobName = "AutomatedTest_" + ID;
            EndDate = DateTime.Now.AddDays(42);
        }

        public int ID { get; set; }

        public string JobName { get; set; }

        public string ProjectCode { get; set; }

        public string DatabaseName { get; set; }

        public string MDD { get; set; }

        public string ExportVariables { get; set; }

        public bool AllOpenEnds { get; set; }

        public string DataFilter { get; set; }

        public string Query { get; set; }

        [XmlElement(ElementName = "LastRun")]
        public DateTime? LastRun { get; set; }

        [XmlElement(IsNullable = true)]
        public DateTime? Created { get; set; }

        [XmlElement(IsNullable = true)]
        public DateTime? LastModified { get; set; }

        public string Status { get; set; }

        public string Results { get; set; }

        public string StandardError { get; set; }

        public int ExitCode { get; set; }

        public string Owner { get; set; }

        public string Tags { get; set; }

        public bool Archived { get; set; }

        public string MDMVersion { get; set; }

        public bool ReportsOnly { get; set; }

        [XmlElement(IsNullable = true)]
        public DateTime? Deactivated { get; set; }

        public bool CopyLatestMdd { get; set; }

        public bool ExportSampleTable { get; set; }

        public bool ExportQuotaTable { get; set; }

        public bool ExportDau { get; set; }

        public DBServer DBServer { get; set; }

        public ExportType ExportType { get; set; }

        public FrequencyType FrequencyType { get; set; }

        public WeekFilter WeekFilter { get; set; }

        public RespondentType RespondentType { get; set; }

        public OpCo OpCo { get; set; }

        public Region Region { get; set; }

        public Timezone Timezone { get; set; }

        [XmlArray(ElementName = "Reports")]
        [XmlArrayItem(ElementName = "ReportModel")]
        public List<Report> Reports { get; set; }

        [XmlArray(ElementName = "DataCutFilters")]
        [XmlArrayItem(ElementName = "DataCutFilterModel")]
        public List<DataCutFilter> DataCutFilters { get; set; }

        [XmlArray(ElementName = "Notifications")]
        [XmlArrayItem(ElementName = "NotificationModel")]
        public List<Notification> Notifications { get; set; }

        [XmlArray(ElementName = "Emails")]
        [XmlArrayItem(ElementName = "EmailModel")]
        public List<Email> Emails { get; set; }

        [XmlArray(ElementName = "Quotas")]
        [XmlArrayItem(ElementName = "QuotaModel")]
        public List<Quota> Quotas { get; set; }

        public string ReturnUrl { get; set; }

        public string Password { get; set; }

        public DataView DataView { get; set; }

        public DateTime EndDate { get; set; }

        public bool ExportLegacyShellVariables { get; set; }

        public bool LegacyShell { get; set; }

        public bool ContainsQuota()
        {
            return FrequencyType.Name == FrequencyType.QUOTA_LIMIT;
        }

        public int TimeInQueue { get; set; }

        public int TimeInPrep { get; set; }

        public int TimeInExtraction { get; set; }

        public int TimeInPoet { get; set; }

        public bool AdHoc { get; set; }

        public bool RunImmediately { get; set; }
    }

}
