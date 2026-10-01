namespace ClientMeetingPrepAutomation.Api.Domain;

public sealed class MeetingPrepRequest
{
    public string ClientName { get; set; } = string.Empty;
    public string AdvisorName { get; set; } = string.Empty;
    public DateOnly MeetingDate { get; set; }
    public string LastMeetingSummary { get; set; } = string.Empty;
    public string PortfolioChangesSummary { get; set; } = string.Empty;
    public string PlanningUpdatesSummary { get; set; } = string.Empty;
    public List<string> OpenActionItems { get; set; } = [];
}

public sealed class MeetingPrepResult
{
    public string ClientName { get; set; } = string.Empty;
    public string BriefSummary { get; set; } = string.Empty;
    public List<string> WhatChanged { get; set; } = [];
    public List<string> ActionChecklist { get; set; } = [];
    public DeliverableReferences Deliverables { get; set; } = new();
}

public sealed class DeliverableReferences
{
    public string WordBriefPath { get; set; } = string.Empty;
    public string ExcelPacketPath { get; set; } = string.Empty;
    public string OutlookDraftReference { get; set; } = string.Empty;
    public string SharePointFolderPath { get; set; } = string.Empty;
}
