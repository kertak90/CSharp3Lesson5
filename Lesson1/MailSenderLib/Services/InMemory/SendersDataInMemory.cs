using MailSenderLib.Entityes;

using MailSenderLib.Services.Interfaces;

namespace MailSenderLib.Services.InMemory
{
    public class SendersDataInMemory : DataInMemory<Sender>, ISendersData
    {

        public SendersDataInMemory()
        {
            _Items.AddRange(TestData.Senders);
        }
        public override void Edit(Sender recipient)
        {
            var db_item = GetById(recipient.Id);
            if (db_item is null || ReferenceEquals(db_item, recipient))
                return;
            db_item.Name = recipient.Name;
            db_item.Email = recipient.Email;
        }
    }


}
