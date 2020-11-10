using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesTestSample.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
        }

        public virtual DbSet<Message> Messages { get; set; }

        #region snippet1
        public async virtual Task<List<Message>> GetMessagesAsync()
        {
            return await Messages
                .OrderBy(message => message.Text)
                .AsNoTracking()
                .ToListAsync();
        }
        #endregion

        #region snippet2
        public async virtual Task AddMessageAsync(Message message)
        {
            await Messages.AddAsync(message);
            await SaveChangesAsync();
        }
        #endregion

        #region snippet3
        public async virtual Task DeleteAllMessagesAsync()
        {
            foreach (Message message in Messages)
            {
                Messages.Remove(message);
            }
            
            await SaveChangesAsync();
        }
        #endregion

        #region snippet4
        public async virtual Task DeleteMessageAsync(int id)
        {
            var message = await Messages.FindAsync(id);

            if (message != null)
            {
                Messages.Remove(message);
                await SaveChangesAsync();
            }
        }
        #endregion

        public void Initialize()
        {
            Messages.AddRange(GetSeedingMessages());
            SaveChanges();
        }

        public static List<Message> GetSeedingMessages()
        {
            return new List<Message>()
            {
                new Message(){ Text = "The most powerful tool we have as developers is automation. — Scott Hanselman" },
                new Message(){ Text = "Agile and DevOps are for harnessing integration, interaction, and innovation. ―  Pearl Zhu" },
                new Message(){ Text = "To successfully implement continuous delivery, you need to change the culture of how an entire organization views software development efforts. – Tommy Tynjä" }
            };
        }
    }
}
