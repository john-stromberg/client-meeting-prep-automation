using ClientMeetingPrepAutomation.Api.Application.Contracts;
using ClientMeetingPrepAutomation.Api.Domain;

namespace ClientMeetingPrepAutomation.Api.Application.Services;

public sealed class MeetingPrepService : IMeetingPrepService
{
    public MeetingPrepResult BuildPacket(MeetingPrepRequest request)
    {
        var slug = request.ClientName.Trim().ToLowerInvariant().Replace(" ", "-");

        var whatChanged = new List<string>();
        if (!string.IsNullOrWhiteSpace(request.PortfolioChangesSummary))
        {
            whatChanged.Add($"Portfolio: {request.PortfolioChangesSummary.Trim()}");
        }

        if (!string.IsNullOrWhiteSpace(request.PlanningUpdatesSummary))
        {
            whatChanged.Add($"Planning: {request.PlanningUpdatesSummary.Trim()}");
        }

        if (!string.IsNullOrWhiteSpace(request.LastMeetingSummary))
        {
            whatChanged.Add($"Last meeting follow-up: {request.LastMeetingSummary.Trim()}");
        }

        var checklist = new List<string>
        {
            "Review household priorities and meeting objective.",
            "Confirm recent account, planning, and cashflow changes.",
            "Validate action owners and follow-up deadlines."
        };
        checklist.AddRange(request.OpenActionItems.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => $"Open item: {x.Trim()}"));

        return new MeetingPrepResult
        {
            ClientName = request.ClientName,
            BriefSummary = $"Prepare {request.ClientName} for the {request.MeetingDate:yyyy-MM-dd} advisor review with an Office-ready pre-meeting packet.",
            WhatChanged = whatChanged,
            ActionChecklist = checklist,
            Deliverables = new DeliverableReferences
            {
                WordBriefPath = $"/outputs/word/{slug}-meeting-brief.docx",
                ExcelPacketPath = $"/outputs/excel/{slug}-meeting-packet.xlsx",
                OutlookDraftReference = $"draft://outlook/{slug}-meeting-brief",
                SharePointFolderPath = $"/sharepoint/clients/{slug}/meeting-prep"
            }
        };
    }
}
