using MailSenderLib.Entityes;

using MailSenderLib.Services.Interfaces;

namespace MailSenderLib.Services.InMemory
{
    public class MailMessageDataInMemory : DataInMemory<MailMessage>, IMailMessagesData
    {       
        public override void Edit(MailMessage mail)
        {
            var db_item = GetById(mail.Id);
            if (db_item is null || ReferenceEquals(db_item, mail)) return;

            db_item.Subject = mail.Subject;
            db_item.Body = mail.Body;
        }
    }


}
