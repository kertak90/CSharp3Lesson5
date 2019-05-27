using MailSenderLib.Entityes;

using MailSenderLib.Services.Interfaces;

namespace MailSenderLib.Services.InMemory
{
    public class RecipientsListDataInMemory : DataInMemory<RecipientsList>, IRecipientsListData
    {
        public override void Edit(RecipientsList recipient)
        {
            var db_item = GetById(recipient.Id);
            if (db_item is null || ReferenceEquals(db_item, recipient))
                return;
            db_item.Name = recipient.Name;
            db_item.Recipients = recipient.Recipients;
        }
    }


}
