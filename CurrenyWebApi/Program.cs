using Autofac;
using Autofac.Extensions.DependencyInjection;
using CurrencyWebApi.Business.Hubs;
using CurrencyWebApi.Business.IoC;
using CurrencyWebApi.Infrastructre.AppDbContext;
using Microsoft.EntityFrameworkCore;
using Quartz;


var builder = WebApplication.CreateBuilder(args);

#region Quartz 
//builder.Services.AddQuartz(q =>
//{
//    q.UseMicrosoftDependencyInjectionJobFactory();
//    // Just use the name of your job that you created in the Jobs folder.
//    var jobKey = new JobKey("GetCurrencyValue");
//    q.AddJob<GetCurrencyValue>(opts => opts.WithIdentity(jobKey));

//    q.AddTrigger(opts => opts
//        .ForJob(jobKey)
//        .WithIdentity("GetCurrencyValue-trigger")
//        //This Cron interval can be described as "run every minute" (when second is zero)
//        //.WithCronSchedule("0 0/1 * * * ?")
//        .WithSimpleSchedule(schedule => schedule.WithIntervalInSeconds(5).RepeatForever())
//    );
//});
//builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
#endregion
builder.Services.AddQuartzDependency();
builder.Services.AddSignalR();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Connection string will be taken from appsettings.json file

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new DependencyResolver());
}); // Dependency injection için kullanýlan container burada implimente edildi.



builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
    builder =>
    {
        builder
        .AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials();
    }));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("CorsPolicy");
app.MapHub<CurrencyHub>("/currencyHub");

app.MapControllers();

app.Run();
