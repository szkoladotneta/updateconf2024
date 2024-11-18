// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using ExampleBlazorApp.Components;
using SmartComponents.Inference;
using SmartComponents.Inference.OpenAI;
using SmartComponents.LocalEmbeddings;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddRepoSharedConfig();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSmartComponents()
    .WithInferenceBackend<OpenAIInferenceBackend>()
    .WithAntiforgeryValidation();

builder.Services.AddSingleton<LocalEmbedder>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

var embedder = app.Services.GetRequiredService<LocalEmbedder>();
var issueLabels = embedder.EmbedRange(
    ["Bug", "Docs", "Enhancement", "Question", "UI (Android)", "UI (iOS)", "UI (Windows)", "UI (Mac)", "Performance", "Security", "Authentication", "Accessibility"]);

app.MapPost("/api/suggestions/issue-label", async context =>
{
    var form = await context.Request.ReadFormAsync();
    int maxResults = 5; 
    float similarityThreshold = 0.5f;
    float.TryParse(form["similarityThreshold"], out similarityThreshold);
    int.TryParse( form["MaxResults"], out maxResults);
    var inputValue = form["inputValue"];
    var query = new SimilarityQuery
    {
        SearchText = inputValue!,
        MaxResults = maxResults,
        MinSimilarity = similarityThreshold
    };
    var suggestions = embedder.FindClosest(query, issueLabels);
    await context.Response.WriteAsJsonAsync(suggestions);
});

app.Run();
