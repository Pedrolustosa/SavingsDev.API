using Microsoft.EntityFrameworkCore;
using SavingsDev.API.Persistence;

namespace SavingsDev.API.Jobs
{
    public class YieldAutomateJob : IHostedService
    {
        private Timer _timer;
        public IServiceProvider _serviceProvider { get; set; }

        public YieldAutomateJob(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(RenderBalance, null, 0, 10000);

            return Task.CompletedTask;
        }

        public void RenderBalance(object? state)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<Context>();

                var objectives = context.Objectives.Include(o => o.Operations);

                foreach (var objective in objectives)
                {
                    objective.Render();
                }

                context.SaveChanges();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}