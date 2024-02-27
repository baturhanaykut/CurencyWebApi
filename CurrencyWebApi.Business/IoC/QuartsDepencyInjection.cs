using CurrencyWebApi.Business.Jobs;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyWebApi.Business.IoC
{
    public static class QuartsDepencyInjection
    {
        public static void AddQuartzDependency(this IServiceCollection services)
        {
            services.AddQuartz(options =>
            {
                options.UseMicrosoftDependencyInjectionJobFactory();
                var jobKey = JobKey.Create(nameof(GetCurrencyValueJob));
                options
                    .AddJob<GetCurrencyValueJob>(jobKey)
                    .AddTrigger(trigger => trigger
                                    .ForJob(jobKey)
                                    //.WithCronSchedule("0 0/1 * 1/1 * ? *"));
                                    .WithSimpleSchedule(schedule => schedule.WithIntervalInSeconds(5).RepeatForever()));
            });

            services.AddQuartzHostedService(options =>
            {
                options.WaitForJobsToComplete = true;
            });
        }
    }
}
