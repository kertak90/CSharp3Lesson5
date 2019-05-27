using MailSenderLib.Entityes;

using MailSenderLib.Services.Interfaces;

namespace MailSenderLib.Services.InMemory
{
    public class ServersDataInMemory : DataInMemory<Server>, IServerData
    {

        public ServersDataInMemory()
        {
            _Items.AddRange(TestData.Servers);
        }
        public override void Edit(Server server)
        {
            var db_item = GetById(server.Id);
            if (db_item is null || ReferenceEquals(db_item, server))
                return;
            db_item.Address = server.Address;
            db_item.Port = server.Port;
            db_item.UseSSL = server.UseSSL;
            db_item.Login = server.Login;
            db_item.Password = server.Password;
        }
    }


}
