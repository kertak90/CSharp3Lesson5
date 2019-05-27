using MailSenderLib.Entityes;

using MailSenderLib.Services.Interfaces;

namespace MailSenderLib.Services.InMemory
{
    public class MailsListDataInMemory : DataInMemory<MailList>, IMailLists
    {
        public override void Edit(MailList mailList)
        {
            var db_item = GetById(mailList.Id);
            if (db_item is null || ReferenceEquals(db_item, mailList))
                return;

            db_item.Name = mailList.Name;
            db_item.Messages = mailList.Messages;
        }
    }


}
