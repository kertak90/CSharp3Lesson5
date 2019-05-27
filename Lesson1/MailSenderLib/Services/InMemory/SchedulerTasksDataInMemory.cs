using MailSenderLib.Entityes;

using MailSenderLib.Services.Interfaces;

namespace MailSenderLib.Services.InMemory
{
    public class SchedulerTasksDataInMemory : DataInMemory<SchedulerTask>, ISchedulerTasksData
    {
        public override void Edit(SchedulerTask task)
        {
            var db_item = GetById(task.Id);
            if (db_item is null || ReferenceEquals(db_item, task))
                return;

            db_item.Time = task.Time;
            db_item.Sender = task.Sender;
            db_item.Server = task.Server;
            db_item.Messages = task.Messages;
            db_item.Recipients = task.Recipients;
        }
    }

}
