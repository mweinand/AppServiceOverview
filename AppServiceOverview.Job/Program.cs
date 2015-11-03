using AppServiceOverview.Data;
using AppServiceOverview.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppServiceOverview.Job
{
    class Program
    {
        static void Main(string[] args)
        {
            var cancellationToken = new CancellationTokenSource();
            Program.DoWork(cancellationToken);

            while(Console.ReadLine() != "q")
            {

            }

            cancellationToken.Cancel();
        }

        public static async Task DoWork(CancellationTokenSource cancellationToken)
        {
            while(!cancellationToken.IsCancellationRequested)
            {
                await UpdateRank();
                await Task.Delay(5000);
            }
        }

        public static async Task UpdateRank()
        {
            using (var dataContext = new AppServiceDataContext())
            {
                var repository = new Repository(dataContext);

                var team = await repository.Query<Team>().FirstOrDefaultAsync();
                if (team != null)
                {
                    Console.WriteLine("Loaded team: {0}", team.Id);
                    var random = new Random();
                    var increment = random.Next(-5, 5);
                    team.Rank += increment;
                    await repository.SaveChangesAsync();
                    Console.WriteLine("Updated team rank to: {0}", team.Rank);
                }
            }
        }
    }
}
