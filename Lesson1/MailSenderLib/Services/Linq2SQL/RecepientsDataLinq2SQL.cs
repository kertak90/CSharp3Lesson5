using MailSenderLib.Entityes;
using MailSenderLib.Linq2SQL;
using MailSenderLib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderLib.Services
{
    public class RecepientsDataLinq2SQL : IRecepientsData
    {
        private readonly MailSenderDB _db;
        public RecepientsDataLinq2SQL(MailSenderDB db)
        {
            _db = db;
        }

        public int Add(Recipient recipient)
        {
            if (_db.Recipients.Any(r=>r.Id==recipient.Id))
                return recipient.Id;
            _db.Recipients.InsertOnSubmit(new Recipient
            {
                Name = recipient.Name,
                Email = recipient.Email
            });
            SaveChanges();
            return recipient.Id;
        }

        public int Create(Recipient recepients)
        {
            if (recepients.Id != 0) return recepients.Id;
            _db.Recipients.InsertOnSubmit(recepients);
            return recepients.Id;
        }

        public void Edit(Recipient recipient)
        {
            var db_recipient = _db.Recipients.FirstOrDefault(r=> r.Id == recipient.Id);
            if (db_recipient is null)
            {
                Add(recipient);
                return;
            }

            db_recipient.Name = recipient.Name;
            db_recipient.Email = recipient.Email;
            SaveChanges();
        }

        public IEnumerable<Recipient> GetAll()
        {
            return _db.Recipients.Select(r=> new Recipient {Id = r.Id, Name = r.Name, Email = r.Email}).ToArray();
        }

        public Recipient GetById(int id)
        {
            var db_recipient = _db.Recipients.FirstOrDefault(i => i.Id == id);
            
            return new Recipient
            {
                Id = db_recipient.Id,
                Name = db_recipient.Name,
                Email = db_recipient.Email
            };
        }

        public void Remove(int id)
        {
            var db_recipient = _db.Recipients.FirstOrDefault(r=>r.Id == id);
            if (db_recipient is null) return;
            _db.Recipients.DeleteOnSubmit(db_recipient);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _db.SubmitChanges();
        }

        public void Write(Recipient recipient)
        {
            if (_db.Recipients.Contains(recipient)) return;
            _db.Recipients.InsertOnSubmit(recipient);
        }
    }
}
