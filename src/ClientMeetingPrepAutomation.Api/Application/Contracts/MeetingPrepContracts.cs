using ClientMeetingPrepAutomation.Api.Domain;

namespace ClientMeetingPrepAutomation.Api.Application.Contracts;

public interface IMeetingPrepService
{
    MeetingPrepResult BuildPacket(MeetingPrepRequest request);
}
