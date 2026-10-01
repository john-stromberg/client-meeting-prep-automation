# Client Meeting Prep Automation

Workflow-oriented advisor tool for generating pre-meeting briefs, change summaries, action checklists, and Office-ready deliverable references.

## Stack
- .NET 10 ASP.NET Core Web API
- Lightweight web UI
- Graph-ready Office deliverable reference pattern

## MVP Features
- Pre-meeting brief summary
- What changed since last meeting summary
- Action checklist generation
- Deliverable references for Word, Excel, Outlook, and SharePoint

## Run
```bash
dotnet restore client-meeting-prep-automation.slnx
dotnet run --project src/ClientMeetingPrepAutomation.Api/ClientMeetingPrepAutomation.Api.csproj
```

Open:
- `/` for UI
- `POST /api/meeting-prep/build-packet` for API
