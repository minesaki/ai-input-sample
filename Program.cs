using ai_input_sample.Components;
using SmartComponents.Inference.OpenAI;

namespace ai_input_sample;

public class Program
{
    public static void Main(string[] args)
    {
        DotNetEnv.Env.Load();   // Load .env file

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        // Add SmartComponents
        builder.Services.AddSmartComponents()
            .WithInferenceBackend<OpenAIInferenceBackend>()
            .WithAntiforgeryValidation();

        var app = builder.Build();

        // // Configure the HTTP request pipeline.
        // if (!app.Environment.IsDevelopment())
        // {
        //     app.UseExceptionHandler("/Error");
        //     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        //     app.UseHsts();
        // }

        // app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}
