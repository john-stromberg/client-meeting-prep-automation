using ClientMeetingPrepAutomation.Api.Application.Contracts;
using ClientMeetingPrepAutomation.Api.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ClientMeetingPrepAutomation.Api.Controllers;

[ApiController]
[Route("api/meeting-prep")]
public sealed class MeetingPrepController : ControllerBase
{
    private readonly IMeetingPrepService _meetingPrepService;

    public MeetingPrepController(IMeetingPrepService meetingPrepService)
    {
        _meetingPrepService = meetingPrepService;
    }

    [HttpPost("build-packet")]
    public ActionResult<MeetingPrepResult> BuildPacket([FromBody] MeetingPrepRequest request)
    {
        return Ok(_meetingPrepService.BuildPacket(request));
    }
}
