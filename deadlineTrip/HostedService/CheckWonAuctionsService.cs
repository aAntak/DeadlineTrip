using deadlineTrip.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace deadlineTrip.HostedService
{
    public class CheckWonAuctionsService : BackgroundService
    {
        public IServiceProvider Services;

        public CheckWonAuctionsService(IServiceProvider services)
        {
            Services = services;
        }
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = Services.CreateScope())
                {
                    var _auctionRepo =
                            scope.ServiceProvider
                                .GetRequiredService<IAuctionRepository>();


                    var auctions = _auctionRepo.GetAll();
                    foreach(var auction in auctions)
                    {
                        // Finished
                        if(auction.EndDate <= DateTime.Now && String.IsNullOrEmpty(auction.WinnerEmail))
                        {
                            var latestBet = auction.Bets.OrderByDescending(x => x.Date).FirstOrDefault();
                            if(latestBet != null) 
                            {
                                _auctionRepo.setWinnerToAuction(auction.Id, latestBet.UserId, latestBet.Bet);
                            }
                        }
                    }
                }


                await Task.Delay(1000, stoppingToken);
            }

        }
    }
}
