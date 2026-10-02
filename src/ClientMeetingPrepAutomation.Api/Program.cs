using ClientMeetingPrepAutomation.Api.Application.Contracts;
using ClientMeetingPrepAutomation.Api.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
builder.Services.AddSingleton<IMeetingPrepService, MeetingPrepService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors();

app.MapGet("/", () => Results.Ok(new { message = "Client Meeting Prep Automation API only. Use the dashboard UI for the interactive page." }));
app.MapControllers();

app.Run();
